
Imports System.Data.Common
Imports System.Data.Odbc

Public Class Form1

    ' If you want to understand this code, first read about ODBC connections and how to set them up in Windows. 
    '    Windows does not come with a MySQL ODBC driver, so you will need to install one.
    '    The MySQL ODBC driver can be downloaded from https://dev.mysql.com/downloads/connector/odbc/
    '    After installing the MySQL ODBC driver, you can create a DSN (Data Source Name) using the ODBC Data Source Administrator in Windows.
    '    The DSN is a named connection to a database that stores the connection information (IP address, port, user, password, etc.)
    '    so that you don't have to specify it in your code.
    ' The MySQL server must also be installed and running.  It can be running locally or remotely.  The northwind database must also exist on the MySQL server.
    ' The northwind database can be downloaded from many sources which you can find on the internet

    '
    ' for this code to work under Windows, you need to firstrun ODBC Data Source Administrator to create a DSN named "cs312fa26" that points to the northwind database
    ' the connection IP address, port, user, and password are stored in the DSN, so they don't need to be specified here
    ' the DSN (data source name) is a string that identifies the database connection
    '   this string is assigned when the ODBC connection is created, and it is used to connect to the database
    '   the database must reside on the same machine as the ODBC connection, or the ODBC connection must be configured to connect to a remote database
    '   assigning the database here allows me to connect to any database on the same server without having to create a new DSN for each database
    Dim ODBCString As String = "DSN=cs312fa26;DATABASE=northwind;"

    ' the adapter allows maipulation of the database through the DataTable, and it is used to update the database with changes made in the DataTable
    ' Keep adapter and table accessible at the class level so SaveButton can use them
    Private adapter As OdbcDataAdapter
    Private table As DataTable

    ' The command builder automatically generates the SQL statements for the adapter based on the select command
    '   if the data is modified in the DataTable, the command builder will generate the appropriate SQL statements to update the database when adapter.Update(table) is called
    '   this only works if there is a PRIMARY KEY in the table, and the select command must include the primary key column(s)
    '
    Private commandBuilder As OdbcCommandBuilder


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Using conn As New OdbcConnection(ODBCString)
            conn.Open()
            Using cmd As New OdbcCommand("SELECT * FROM Customers", conn)
                Dim table As New DataTable()
                Using adapter As New OdbcDataAdapter(cmd)
                    adapter.Fill(table)
                End Using
                DataGridView1.DataSource = table
            End Using


        End Using  ' this also closes the connection


    End Sub

    Private Async Sub ButtonQuery_Click(sender As Object, e As EventArgs) Handles ButtonQuery.Click

        Dim thisButton As Button = CType(sender, Button)

        ' Disable UI controls during query execution to prevent double-clicks
        DataGridView2.DataSource = Nothing
        thisButton.Enabled = False
        Dim query As String = TextBoxQuery.Text

        ' Run query loading in the background
        Dim result = Await Task.Run(
            Function() As (Success As Boolean, Data As DataTable, Adapter As OdbcDataAdapter, ErrorMessage As String)

                ' surround this with a Try/Catch block to handle any exceptions that may occur during the query execution
                ' without this, the application will crash if the query is invalid or if there is a problem with the database connection
                Try
                    ' IMPORTANT: Select query MUST include the primary key for OdbcCommandBuilder to generate UPDATE commands
                    Dim conn As New OdbcConnection(ODBCString)
                    Dim localAdapter As New OdbcDataAdapter(query, conn)
                    Dim localTable As New DataTable()

                    ' Tells the adapter to fetch Primary Key information from the database
                    '   this makes sure the primary key is included in the DataTable, which is required for the OdbcCommandBuilder to generate UPDATE commands
                    localAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

                    ' display the data in the DataGridView
                    localAdapter.Fill(localTable)

                    Return (True, localTable, localAdapter, String.Empty)
                Catch ex As OdbcException
                    Return (False, Nothing, Nothing, ex.Message)
                Catch ex As Exception
                    Return (False, Nothing, Nothing, ex.Message)
                End Try
            End Function)

        If result.Success Then
            table = result.Data
            adapter = result.Adapter

            ' Automatically generates UPDATE, INSERT, and DELETE statements for the adapter
            commandBuilder = New OdbcCommandBuilder(adapter)

            ' Bind data to DataGridView
            DataGridView2.DataSource = table
        Else
            MessageBox.Show($"Error loading data: {result.ErrorMessage}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        thisButton.Enabled = True


    End Sub

    Private Async Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click

        Dim thisButton As Button = CType(sender, Button)

        If adapter Is Nothing OrElse table Is Nothing Then
            MessageBox.Show("No data loaded to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Commit any pending cell edit in the DataGridView
        DataGridView2.EndEdit()


        ' disable the button to prevent multiple clicks while the save operation is in progress
        thisButton.Enabled = False


        Dim result = Await Task.Run(
            Function() As (Success As Boolean, RowsUpdated As Integer, ErrorMessage As String)


                ' surround this with a Try/Catch block to handle any exceptions that may occur during the save operation
                Try
                    ' Persists DataGridView changes back to MySQL
                    'When you call adapter.Update(table), the OdbcDataAdapter loops through every
                    'row in the table, inspects its RowState, and executes the corresponding SQL
                    'statement:
                    'RowStateSQL Action TriggeredRequires Command Property
                    'Modified  Executes UPDATE ... SET ... WHERE ...   adapter.UpdateCommand
                    'Added     Executes INSERT INTO ... VALUES (...)   adapter.InsertCommand
                    'Deleted   Executes DELETE FROM ... WHERE ...      adapter.DeleteCommand
                    'Unchanged Ignored (no SQL sent to database)       None
                    Dim count As Integer = adapter.Update(table)


                    Return (True, count, String.Empty)
                Catch ex As OdbcException
                    Return (False, 0, ex.Message)
                Catch ex As Exception
                    Return (False, 0, ex.Message)
                End Try
            End Function)

        If result.Success Then
            MessageBox.Show($"{result.RowsUpdated} record(s) updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show($"Failed to save changes: {result.ErrorMessage}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


        ' re-enable the button after the operation is complete
        thisButton.Enabled = True

    End Sub


End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        DataGridView1 = New DataGridView()
        Button1 = New Button()
        ButtonQuery = New Button()
        TextBoxQuery = New TextBox()
        DataGridView2 = New DataGridView()
        ButtonSave = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(21, 54)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(1273, 294)
        DataGridView1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(24, 11)
        Button1.Name = "Button1"
        Button1.Size = New Size(200, 23)
        Button1.TabIndex = 1
        Button1.Text = "Connect and Display"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ButtonQuery
        ' 
        ButtonQuery.Location = New Point(21, 363)
        ButtonQuery.Name = "ButtonQuery"
        ButtonQuery.Size = New Size(203, 23)
        ButtonQuery.TabIndex = 2
        ButtonQuery.Text = "Run Query"
        ButtonQuery.UseVisualStyleBackColor = True
        ' 
        ' TextBoxQuery
        ' 
        TextBoxQuery.Location = New Point(230, 363)
        TextBoxQuery.Name = "TextBoxQuery"
        TextBoxQuery.Size = New Size(462, 23)
        TextBoxQuery.TabIndex = 3
        ' 
        ' DataGridView2
        ' 
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Location = New Point(24, 392)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.Size = New Size(1270, 254)
        DataGridView2.TabIndex = 4
        ' 
        ' ButtonSave
        ' 
        ButtonSave.Location = New Point(1112, 360)
        ButtonSave.Name = "ButtonSave"
        ButtonSave.Size = New Size(182, 23)
        ButtonSave.TabIndex = 5
        ButtonSave.Text = "Save Edits"
        ButtonSave.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1378, 671)
        Controls.Add(ButtonSave)
        Controls.Add(DataGridView2)
        Controls.Add(TextBoxQuery)
        Controls.Add(ButtonQuery)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Name = "Form1"
        Text = "Form1"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents ButtonQuery As Button
    Friend WithEvents TextBoxQuery As TextBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents ButtonSave As Button

End Class

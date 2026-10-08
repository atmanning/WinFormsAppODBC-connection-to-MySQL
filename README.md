This example VB to ODBC app was created under Visual Studio Community 2025 on Windows 11

Having general knowledge of MySQL databases and VB, I knew there was a way to connect and display the contents of a table.
The table resides in a remote MariaDB database which I set up in a Docker container running MariaDB under Ubuntu Linux
The MySQL ODBC driver is also needed along with the northwind database created and populated

The first button simply dumps the contents of the NorthWind Customers table.  Easy!
The second button attempts to run a query entered by the user, with proper exception handling
  It has not been fully tested for all exceptions, but it stopped hard crashing due to typo's in the table name, for example

I added the ability to write my own queries and display the results.
It wasn't too hard to modify that code to also update the table after editing the dataGrid control, which was new to me
The Save Edits button does the work for that once the odbc adapter is properly configured - nice!
It does require that the table to be edited contain a primary key!


Acknowledgements:
gemini.google.com guided me, but I modified the code some and added many comments to help future coders

amanning@emmaus.edu
Arthur T. Manning - Emmaus University - Computer Information Systems
   www.emmaus.edu  2570 Asbury Road  Dubuque, IA 52001 
people.emmaus.edu/manningat

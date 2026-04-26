Imports System.Data.OleDb
Imports System.IO

Public Module DatabaseManager
    Public ConnectionString As String = ""

    Public Function Connect(databasePath As String) As Boolean
        Try
            ' Check if file exists - OleDb cannot create the file itself on most setups
            If Not File.Exists(databasePath) Then
                ' In a real Windows environment with Access installed, you'd use ADOX.
                ' For this educational project, we prompt the user to ensure the file exists.
                MessageBox.Show("Database file not found. Please create an empty Access file first at: " & databasePath)
                Return False
            End If

            If databasePath.EndsWith(".accdb") Then
                ConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;"
            Else
                ConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={databasePath};"
            End If

            Using tempConn As New OleDbConnection(ConnectionString)
                tempConn.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error connecting to database: " & ex.Message)
            Return False
        End Try
    End Function

    Public Sub InitializeDatabase()
        Try
            Using connection As New OleDbConnection(ConnectionString)
                connection.Open()

                ' Create Tables if they don't exist
                ExecuteNonQuery("CREATE TABLE Users (UserID AUTOINCREMENT PRIMARY KEY, Username TEXT(50), [Password] TEXT(50), Role TEXT(20))", connection)
                ExecuteNonQuery("CREATE TABLE Students (StudentID AUTOINCREMENT PRIMARY KEY, StudentName TEXT(100), Phone TEXT(20), RegistrationDate DATE)", connection)
                ExecuteNonQuery("CREATE TABLE Payments (PaymentID AUTOINCREMENT PRIMARY KEY, StudentName TEXT(100), Amount CURRENCY, PaymentDate DATE, Notes TEXT(255))", connection)
                ExecuteNonQuery("CREATE TABLE Expenses (ExpenseID AUTOINCREMENT PRIMARY KEY, Description TEXT(255), Amount CURRENCY, ExpenseDate DATE, Category TEXT(50))", connection)

                SeedAdminUser(connection)
            End Using
        Catch ex As Exception
            ' If table creation fails, it's likely they already exist
        End Try
    End Sub

    Private Sub ExecuteNonQuery(sql As String, connection As OleDbConnection)
        Try
            Dim cmd As New OleDbCommand(sql, connection)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SeedAdminUser(connection As OleDbConnection)
        Try
            Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM Users WHERE Username = 'admin'", connection)
            Dim count As Integer = CInt(checkCmd.ExecuteScalar())

            If count = 0 Then
                Dim insertCmd As New OleDbCommand("INSERT INTO Users (Username, [Password], Role) VALUES ('admin', 'admin123', 'Admin')", connection)
                insertCmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetDataTable(sql As String) As DataTable
        Return GetDataTableWithParams(sql, Nothing)
    End Function

    Public Function GetDataTableWithParams(sql As String, parameters As OleDbParameter()) As DataTable
        Dim dt As New DataTable()
        Try
            Using connection As New OleDbConnection(ConnectionString)
                Dim cmd As New OleDbCommand(sql, connection)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If
                Dim adapter As New OleDbDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function ExecuteAction(sql As String, parameters As OleDbParameter()) As Integer
        Try
            Using connection As New OleDbConnection(ConnectionString)
                connection.Open()
                Dim cmd As New OleDbCommand(sql, connection)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If
                Return cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Database Action Error: " & ex.Message)
            Return -1
        End Try
    End Function
End Module

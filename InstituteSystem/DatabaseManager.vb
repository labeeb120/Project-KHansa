Imports System.Data.OleDb
Imports System.IO

Public Module DatabaseManager
    Public ConnectionString As String = ""

    ''' <summary>
    ''' Connects to the Access database and sets the global ConnectionString.
    ''' </summary>
    Public Function Connect(databasePath As String) As Boolean
        Try
            If String.IsNullOrWhiteSpace(databasePath) Then Return False

            ' Connection string for Access .accdb and .mdb files
            If databasePath.EndsWith(".accdb", StringComparison.OrdinalIgnoreCase) Then
                ConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;"
            Else
                ConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={databasePath};"
            End If

            ' Test connection
            Using tempConn As New OleDbConnection(ConnectionString)
                tempConn.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("خطأ في الاتصال بقاعدة البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Initializes the database schema and seeds the default admin user.
    ''' </summary>
    Public Sub InitializeDatabase()
        If String.IsNullOrEmpty(ConnectionString) Then Return

        Using connection As New OleDbConnection(ConnectionString)
            Try
                connection.Open()

                ' Table creation logic with basic existence check via error handling or schema query
                CreateTables(connection)
                SeedAdminUser(connection)
            Catch ex As Exception
                MessageBox.Show("خطأ أثناء تهيئة قاعدة البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub CreateTables(connection As OleDbConnection)
        ' Define tables and their schemas
        Dim tables As New Dictionary(Of String, String) From {
            {"Users", "CREATE TABLE Users (UserID AUTOINCREMENT PRIMARY KEY, Username TEXT(50), [Password] TEXT(50), Role TEXT(20))"},
            {"Students", "CREATE TABLE Students (StudentID AUTOINCREMENT PRIMARY KEY, StudentName TEXT(100), Phone TEXT(20), RegistrationDate DATE)"},
            {"Payments", "CREATE TABLE Payments (PaymentID AUTOINCREMENT PRIMARY KEY, StudentName TEXT(100), Amount CURRENCY, PaymentDate DATE, Notes TEXT(255))"},
            {"Expenses", "CREATE TABLE Expenses (ExpenseID AUTOINCREMENT PRIMARY KEY, Description TEXT(255), Amount CURRENCY, ExpenseDate DATE, Category TEXT(50))"}
        }

        For Each table In tables
            If Not TableExists(table.Key, connection) Then
                ExecuteNonQuery(table.Value, connection)
            End If
        Next
    End Sub

    Private Function TableExists(tableName As String, connection As OleDbConnection) As Boolean
        Dim schemaTable As DataTable = connection.GetSchema("Tables", New String() {Nothing, Nothing, tableName, "TABLE"})
        Return schemaTable.Rows.Count > 0
    End Function

    Private Sub ExecuteNonQuery(sql As String, connection As OleDbConnection)
        Try
            Using cmd As New OleDbCommand(sql, connection)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ' Silent fail if table creation fails for other reasons
        End Try
    End Sub

    Private Sub SeedAdminUser(connection As OleDbConnection)
        Try
            Dim sqlCheck As String = "SELECT COUNT(*) FROM Users WHERE Username = 'admin'"
            Using checkCmd As New OleDbCommand(sqlCheck, connection)
                Dim count As Integer = CInt(checkCmd.ExecuteScalar())

                If count = 0 Then
                    Dim sqlInsert As String = "INSERT INTO Users (Username, [Password], Role) VALUES (?, ?, ?)"
                    Using insertCmd As New OleDbCommand(sqlInsert, connection)
                        insertCmd.Parameters.AddWithValue("@u", "admin")
                        insertCmd.Parameters.AddWithValue("@p", "admin123")
                        insertCmd.Parameters.AddWithValue("@r", "Admin")
                        insertCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Catch ex As Exception
            ' Log error if needed
        End Try
    End Sub

    Public Function GetDataTableWithParams(sql As String, parameters As OleDbParameter()) As DataTable
        Dim dt As New DataTable()
        Try
            Using connection As New OleDbConnection(ConnectionString)
                Using cmd As New OleDbCommand(sql, connection)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    Using adapter As New OleDbDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("خطأ في جلب البيانات: " & ex.Message, "خطأ قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

    Public Function GetDataTable(sql As String) As DataTable
        Return GetDataTableWithParams(sql, Nothing)
    End Function

    Public Function ExecuteAction(sql As String, parameters As OleDbParameter()) As Integer
        Try
            Using connection As New OleDbConnection(ConnectionString)
                connection.Open()
                Using cmd As New OleDbCommand(sql, connection)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("خطأ في تنفيذ العملية: " & ex.Message, "خطأ قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function
End Module

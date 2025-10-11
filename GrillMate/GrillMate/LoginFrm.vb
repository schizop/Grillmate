Imports System.Data.SqlClient

Public Class LoginFrm

    Private connectionString As String = "Server=AEGON;Database=GrillMate;Trusted_Connection=True;"

    Private connection As SqlConnection


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New SqlConnection(connectionString)
    End Sub


    Private Sub TestConnection()
        Try
            connection.Open()
            MessageBox.Show("Connection successful!")
            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Connection failed: " & ex.Message)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.PasswordChar = "*"c
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"c
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text.Trim()

        Dim query As String = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password"
        Using cmd As New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)

            Try
                connection.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                connection.Close()

                If count > 0 Then
                    MessageBox.Show("Login successful!")
                    Dim Form2 As New Dashboard()
                    Me.Hide()  ' Hide Form1
                    form2.Show()  ' Show Form2
                Else
                    MessageBox.Show("Wrong username or password.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End Using
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        If connection IsNot Nothing Then
            connection.Dispose()
        End If
        MyBase.OnFormClosing(e)
    End Sub


End Class

Imports System.Data.SqlClient

Public Class MenuEditorControl
    Private connectionString As String = "Server=AEGON;Database=GrillMate;Trusted_Connection=True;"

    ' Load menu items into DataGridView
    Private Sub LoadMenuEditor()
        dgvMenuEditor.Rows.Clear()
        dgvMenuEditor.Columns.Clear()

        ' Define columns if not using AutoGenerateColumns
        dgvMenuEditor.Columns.Add("ItemID", "ID")
        dgvMenuEditor.Columns.Add("ItemName", "Name")
        dgvMenuEditor.Columns.Add("Price", "Price")
        dgvMenuEditor.Columns.Add("Category", "Category")

        Dim query As String = "SELECT ItemID, ItemName, Price, Category FROM MenuItems"
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    dgvMenuEditor.Rows.Add(reader("ItemID"), reader("ItemName"), reader("Price"), reader("Category"))
                End While
            End Using
        End Using
    End Sub

    ' Call LoadMenuEditor when the control loads
    Private Sub MenuEditorControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMenuEditor()
        LoadCategories()
    End Sub

    ' Add new menu item
    Private Sub btnAddMenu_Click(sender As Object, e As EventArgs) Handles btnAddMenu.Click
        Dim query As String = "INSERT INTO MenuItems (ItemName, Price, Category) VALUES (@ItemName, @Price, @Category)"
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text)
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text))
                cmd.Parameters.AddWithValue("@Category", cmbCategory.Text)
                cmd.ExecuteNonQuery()
            End Using
        End Using
        MessageBox.Show("Menu item added successfully!")
        LoadMenuEditor()
    End Sub

    ' Update menu item
    Private Sub btnUpdateMenu_Click(sender As Object, e As EventArgs) Handles btnUpdateMenu.Click
        If dgvMenuEditor.SelectedRows.Count > 0 Then
            Dim itemId As Integer = dgvMenuEditor.SelectedRows(0).Cells("ItemID").Value
            Dim query As String = "UPDATE MenuItems SET ItemName=@ItemName, Price=@Price, Category=@Category WHERE ItemID=@ItemID"
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ItemID", itemId)
                    cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text)
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text))
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Menu item updated successfully!")
            LoadMenuEditor()
        End If
    End Sub

    ' Delete menu item
    Private Sub btnDeleteMenu_Click(sender As Object, e As EventArgs) Handles btnDeleteMenu.Click
        If dgvMenuEditor.SelectedRows.Count > 0 Then
            Dim itemId As Integer = dgvMenuEditor.SelectedRows(0).Cells("ItemID").Value
            Dim query As String = "DELETE FROM MenuItems WHERE ItemID=@ItemID"
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ItemID", itemId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Menu item deleted successfully!")
            LoadMenuEditor()
        End If
    End Sub

    ' Select row in DataGridView → load into textboxes
    Private Sub dgvMenuEditor_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenuEditor.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvMenuEditor.Rows(e.RowIndex)
            txtItemName.Text = row.Cells("ItemName").Value.ToString()
            txtPrice.Text = row.Cells("Price").Value.ToString()
            cmbCategory.Text = row.Cells("Category").Value.ToString()
        End If
    End Sub

    ' Clear input fields
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtItemName.Clear()
        txtPrice.Clear()
        cmbCategory.SelectedIndex = -1
    End Sub
    Private Sub LoadCategories()
        cmbCategory.Items.Clear()
        Dim query As String = "SELECT DISTINCT Category FROM MenuItems ORDER BY Category"
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    cmbCategory.Items.Add(reader("Category").ToString())
                End While
            End Using
        End Using
    End Sub
End Class


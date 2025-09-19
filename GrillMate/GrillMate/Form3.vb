Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class Form3

    Private connectionString As String = "Server=AEGON;Database=GrillMate;Trusted_Connection=True;"
    Private currentCategory As String = "All"

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()   ' Load category buttons
        LoadMenuItems()    ' Load all menu items initially
        LoadTables()       ' Load table buttons
        InitializeOrderGrid()
    End Sub


    Private Sub LoadCategories()
        flpCategory.Controls.Clear()

        Dim query As String = "SELECT DISTINCT Category FROM MenuItems"
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                ' Add "All" button first
                Dim allBtn As New Button()
                allBtn.Text = "All"
                allBtn.Tag = "All"
                allBtn.Width = 50
                allBtn.Height = 40
                AddHandler allBtn.Click, AddressOf Category_Click
                flpCategory.Controls.Add(allBtn)

                While reader.Read()
                    Dim btn As New Button()
                    btn.Text = reader("Category").ToString()
                    btn.Tag = reader("Category").ToString()
                    btn.Width = 70
                    btn.Height = 40
                    AddHandler btn.Click, AddressOf Category_Click
                    flpCategory.Controls.Add(btn)
                End While
            End Using
        End Using
    End Sub


    Private Sub Category_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        currentCategory = btn.Tag.ToString()
        LoadMenuItems(currentCategory)
    End Sub


    Private Sub LoadMenuItems(Optional category As String = "All")
        flpMenu.Controls.Clear()

        Dim query As String
        If category = "All" Then
            query = "SELECT ItemID, ItemName, Price, Category FROM MenuItems"
        Else
            query = "SELECT ItemID, ItemName, Price, Category FROM MenuItems WHERE Category = @Category"
        End If

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                If category <> "All" Then
                    cmd.Parameters.AddWithValue("@Category", category)
                End If

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim btn As New Button()
                    btn.Text = reader("ItemName").ToString()
                    btn.Tag = reader("Price") ' store price
                    btn.Width = 120
                    btn.Height = 60
                    AddHandler btn.Click, AddressOf Item_Click
                    flpMenu.Controls.Add(btn)
                End While
            End Using
        End Using
    End Sub

    Private Sub InitializeOrderGrid()
        dgvOrder.Columns.Clear()
        dgvOrder.Columns.Add("ItemName", "Item")
        dgvOrder.Columns.Add("Price", "Price")
        dgvOrder.Columns.Add("Quantity", "Quantity")
        dgvOrder.Columns.Add("Total", "Total")
        dgvOrder.Columns("Price").DefaultCellStyle.Format = "C2"
        dgvOrder.Columns("Total").DefaultCellStyle.Format = "C2"
    End Sub

    Private Sub Item_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim itemName As String = btn.Text
        Dim price As Decimal = Convert.ToDecimal(btn.Tag)

        For Each row As DataGridViewRow In dgvOrder.Rows
            If row.Cells("ItemName").Value = itemName Then
                row.Cells("Quantity").Value = CInt(row.Cells("Quantity").Value) + 1
                row.Cells("Total").Value = CDec(row.Cells("Price").Value) * CInt(row.Cells("Quantity").Value)
                UpdateTotal()
                Exit Sub
            End If
        Next

        Dim newRow As String() = {itemName, price.ToString(), "1", price.ToString()}
        dgvOrder.Rows.Add(newRow)
        UpdateTotal()
    End Sub

    Private Sub LoadTables()
        flpTables.Controls.Clear()
        Dim query As String = "SELECT TableID, TableName, Status FROM Tables"
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim btn As New Button()
                    btn.Text = reader("TableName").ToString()
                    btn.Tag = reader("TableID")
                    btn.Width = 60
                    btn.Height = 40

                    Dim status As String = reader("Status").ToString()
                    If status = "Vacant" Then
                        btn.BackColor = Color.LightGreen
                    ElseIf status = "Occupied" Then
                        btn.BackColor = Color.Orange
                    ElseIf status = "Reserved" Then
                        btn.BackColor = Color.Red
                    End If

                    flpTables.Controls.Add(btn)
                End While
            End Using
        End Using
    End Sub

    Private Sub UpdateTotal()
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvOrder.Rows
            If row.Cells("Total").Value IsNot Nothing Then
                total += CDec(row.Cells("Total").Value)
            End If
        Next
        lblTotal.Text = "Total: ₱" & total.ToString("N2")
    End Sub

    Private Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click
        ' logout logic here
    End Sub

    Private Sub btnEditMenu_Click(sender As Object, e As EventArgs) Handles btnEditMenu.Click




        Dim f As New Form()
        Dim editor As New MenuEditorControl()
        editor.Dock = DockStyle.Fill

        f.Controls.Add(editor)
        f.Text = "Menu Editor"
        f.Size = New Size(800, 600) ' Adjust window size
        f.StartPosition = FormStartPosition.CenterParent

        f.ShowDialog()



    End Sub
End Class

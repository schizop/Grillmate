Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar

Public Class OrderEntryFrm

    Private connectionString As String = "Server=AEGON;Database=GrillMate;Trusted_Connection=True;"
    Private currentCategory As String = "All"
    Private selectedTableId As Integer = -1   ' <-- DECLARATION

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()   ' Load category buttons
        LoadMenuItems()    ' Load all menu items initially
        LoadTables()       ' Load table buttons
        InitializeOrderGrid()

        ' Payment methods
        If cmbPaymentMethod IsNot Nothing Then
            cmbPaymentMethod.Items.Clear()
            cmbPaymentMethod.Items.Add("Cash")
            cmbPaymentMethod.Items.Add("GCash")
            cmbPaymentMethod.SelectedIndex = 0
        End If
    End Sub

    ' ---------------------- CATEGORY ----------------------
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

    ' ---------------------- MENU ITEMS ----------------------
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

    ' ---------------------- ORDER GRID ----------------------
    Private Sub InitializeOrderGrid()
        dgvOrder.Columns.Clear()
        dgvOrder.Columns.Add("ItemName", "Item")
        dgvOrder.Columns.Add("Price", "Price")
        dgvOrder.Columns.Add("Quantity", "Quantity")
        dgvOrder.Columns.Add("Total", "Total")
        dgvOrder.Columns("Price").DefaultCellStyle.Format = "C2"
        dgvOrder.Columns("Total").DefaultCellStyle.Format = "C2"
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

    ' ---------------------- TABLES ----------------------
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

                    AddHandler btn.Click, AddressOf Table_Click
                    flpTables.Controls.Add(btn)
                End While
            End Using
        End Using
    End Sub

    Private Sub Table_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        selectedTableId = CInt(btn.Tag)

        ' highlight selected
        For Each ctrl As Control In flpTables.Controls
            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).FlatStyle = FlatStyle.Standard
            End If
        Next
        btn.FlatStyle = FlatStyle.Popup
    End Sub

    ' ---------------------- SUBMIT ORDER ----------------------
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If dgvOrder.Rows.Count = 0 Then
            MessageBox.Show("No items in the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If cmbPaymentMethod.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If selectedTableId = -1 Then
            MessageBox.Show("Please select a table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim paymentType As String = cmbPaymentMethod.SelectedItem.ToString()
        Dim totalAmount As Decimal = 0

        For Each row As DataGridViewRow In dgvOrder.Rows
            If row.IsNewRow Then Continue For
            totalAmount += Convert.ToDecimal(row.Cells("Total").Value)
        Next

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim trans As SqlTransaction = conn.BeginTransaction() ' ✅ transaction declared here

            Try
                ' Insert into Orders
                Dim queryOrder As String =
                "INSERT INTO Orders (OrderDate, TableNo, Total, PaymentType) 
                 OUTPUT INSERTED.OrderID 
                 VALUES (@OrderDate, @TableNo, @Total, @PaymentType)"

                Dim orderId As Integer
                Using cmdOrder As New SqlCommand(queryOrder, conn, trans)
                    cmdOrder.Parameters.AddWithValue("@OrderDate", DateTime.Now)
                    cmdOrder.Parameters.AddWithValue("@TableNo", selectedTableId) ' make sure this is set when clicking a table
                    cmdOrder.Parameters.AddWithValue("@Total", totalAmount)
                    cmdOrder.Parameters.AddWithValue("@PaymentType", paymentType)

                    orderId = Convert.ToInt32(cmdOrder.ExecuteScalar())
                End Using

                ' Insert each order item into OrderDetails
                For Each row As DataGridViewRow In dgvOrder.Rows
                    If row.IsNewRow Then Continue For

                    Dim productName As String = row.Cells("ItemName").Value.ToString().Trim()
                    Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
                    Dim quantity As Integer = Convert.ToInt32(row.Cells("Quantity").Value)
                    Dim subtotal As Decimal = Convert.ToDecimal(row.Cells("Total").Value)

                    ' Get ProductID from MenuItems
                    Dim productId As Integer = -1
                    Using cmdProduct As New SqlCommand("SELECT ItemID FROM MenuItems WHERE ItemName = @ItemName", conn, trans)
                        cmdProduct.Parameters.AddWithValue("@ItemName", productName)
                        Dim result = cmdProduct.ExecuteScalar()
                        If result IsNot Nothing Then
                            productId = Convert.ToInt32(result)
                        End If
                    End Using

                    If productId <> -1 Then
                        Dim queryDetail As String =
                        "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price, Subtotal) 
                         VALUES (@OrderID, @ProductID, @Quantity, @Price, @Subtotal)"
                        Using cmdDetail As New SqlCommand(queryDetail, conn, trans)
                            cmdDetail.Parameters.AddWithValue("@OrderID", orderId)
                            cmdDetail.Parameters.AddWithValue("@ProductID", productId)
                            cmdDetail.Parameters.AddWithValue("@Quantity", quantity)
                            cmdDetail.Parameters.AddWithValue("@Price", price)
                            cmdDetail.Parameters.AddWithValue("@Subtotal", subtotal)
                            cmdDetail.ExecuteNonQuery()
                        End Using
                    End If
                Next

                ' Update table status to Occupied
                Dim updateTableQuery As String = "UPDATE Tables SET Status = 'Occupied' WHERE TableID = @TableID"
                Using cmdUpdateTable As New SqlCommand(updateTableQuery, conn, trans)
                    cmdUpdateTable.Parameters.AddWithValue("@TableID", selectedTableId)
                    cmdUpdateTable.ExecuteNonQuery()
                End Using

                trans.Commit() ' ✅ commit transaction
                MessageBox.Show("Order submitted successfully! Table status updated to Occupied.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvOrder.Rows.Clear()
                lblTotal.Text = "Total: ₱0.00"

                ' Refresh table display to show updated status
                LoadTables()

            Catch ex As Exception
                trans.Rollback() ' ✅ rollback if error
                MessageBox.Show("Error submitting order: " & ex.Message)
            End Try
        End Using
    End Sub


    ' ---------------------- OTHER BUTTONS ----------------------
    Private Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click
        ' logout logic here
    End Sub

    Private Sub btnEditMenu_Click(sender As Object, e As EventArgs) Handles btnEditMenu.Click
        Dim f As New Form()
        Dim editor As New MenuEditorControl()
        editor.Dock = DockStyle.Fill

        f.Controls.Add(editor)
        f.Text = "Menu Editor"
        f.Size = New Size(800, 600)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub Backbtn_Click(sender As Object, e As EventArgs) Handles Backbtn.Click
        Dashboard.Show()   ' Show Form3 again
        Me.Close()     ' Close the current form (OrderHistoryFrm)
    End Sub

    Private Sub btnDelivery_Click(sender As Object, e As EventArgs) Handles btnDelivery.Click
        If dgvOrder.Rows.Count = 0 Then
            MessageBox.Show("No items in the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open delivery form and pass current order data
        Dim deliveryForm As New DeliveryFrm()
        deliveryForm.SetOrderData(dgvOrder, cmbPaymentMethod.SelectedItem?.ToString())
        deliveryForm.Show()
        Me.Hide()
    End Sub


End Class

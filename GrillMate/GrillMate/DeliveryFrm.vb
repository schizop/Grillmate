Imports System.Data.SqlClient

Public Class DeliveryFrm
    Private connectionString As String = "Server=AEGON;Database=GrillMate;Trusted_Connection=True;"
    Private isEditing As Boolean = False
    Private selectedDeliveryId As Integer = -1
    Private currentOrderData As DataGridView
    Private currentPaymentMethod As String
    Private orderTotal As Decimal = 0

    Private Sub DeliveryFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDrivers()
        LoadDeliveries()
        ResetForm()
        SetupForm()
    End Sub

    ' ---------------------- FORM SETUP ----------------------
    Private Sub SetupForm()
        ' Set minimum date to today
        dtpDeliveryDate.MinDate = DateTime.Today
        dtpDeliveryDate.MaxDate = DateTime.Today.AddMonths(1)
        
        ' Set default delivery time to 1 hour from now
        dtpDeliveryTime.Value = DateTime.Now.AddHours(1)
    End Sub

    Public Sub SetOrderData(orderGrid As DataGridView, paymentMethod As String)
        currentOrderData = orderGrid
        currentPaymentMethod = paymentMethod
        LoadOrderSummary()
    End Sub

    ' ---------------------- LOAD DATA ----------------------
    Private Sub LoadDrivers()
        cmbDriver.Items.Clear()
        Dim query As String = "SELECT DriverID, DriverName, Vehicle, Status FROM DeliveryDrivers WHERE Status = 'Available' ORDER BY DriverName"
        
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim displayText As String = reader("DriverName").ToString() & " (" & reader("Vehicle").ToString() & ")"
                    cmbDriver.Items.Add(New ComboBoxItem(displayText, Convert.ToInt32(reader("DriverID"))))
                End While
            End Using
        End Using
    End Sub

    Private Sub LoadOrderSummary()
        If currentOrderData Is Nothing Then Return

        dgvOrderItems.Rows.Clear()
        dgvOrderItems.Columns.Clear()

        ' Define columns
        dgvOrderItems.Columns.Add("ItemName", "Item")
        dgvOrderItems.Columns.Add("Price", "Price")
        dgvOrderItems.Columns.Add("Quantity", "Quantity")
        dgvOrderItems.Columns.Add("Total", "Total")
        dgvOrderItems.Columns("Price").DefaultCellStyle.Format = "C2"
        dgvOrderItems.Columns("Total").DefaultCellStyle.Format = "C2"

        orderTotal = 0
        For Each row As DataGridViewRow In currentOrderData.Rows
            If row.IsNewRow Then Continue For
            Dim itemName As String = row.Cells("ItemName").Value.ToString()
            Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
            Dim quantity As Integer = Convert.ToInt32(row.Cells("Quantity").Value)
            Dim total As Decimal = Convert.ToDecimal(row.Cells("Total").Value)

            dgvOrderItems.Rows.Add(itemName, price, quantity, total)
            orderTotal += total
        Next

        lblOrderTotal.Text = "Order Total: ₱" & orderTotal.ToString("N2")
        dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub LoadDeliveries()
        dgvDeliveries.Rows.Clear()
        dgvDeliveries.Columns.Clear()

        ' Define columns
        dgvDeliveries.Columns.Add("DeliveryID", "ID")
        dgvDeliveries.Columns.Add("CustomerName", "Customer")
        dgvDeliveries.Columns.Add("Phone", "Phone")
        dgvDeliveries.Columns.Add("Address", "Address")
        dgvDeliveries.Columns.Add("DriverName", "Driver")
        dgvDeliveries.Columns.Add("DeliveryDate", "Date")
        dgvDeliveries.Columns.Add("DeliveryTime", "Time")
        dgvDeliveries.Columns.Add("Status", "Status")
        dgvDeliveries.Columns.Add("DeliveryFee", "Fee")

        Dim query As String = "
            SELECT do.DeliveryID, dc.CustomerName, dc.Phone, do.DeliveryAddress,
                   ISNULL(dd.DriverName, 'Not Assigned') AS DriverName,
                   do.DeliveryDate, do.DeliveryTime, do.Status, do.DeliveryFee
            FROM DeliveryOrders do
            INNER JOIN DeliveryCustomers dc ON do.CustomerID = dc.CustomerID
            LEFT JOIN DeliveryDrivers dd ON do.DriverID = dd.DriverID
            ORDER BY do.DeliveryDate DESC, do.DeliveryTime DESC"

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    Dim rowIndex As Integer = dgvDeliveries.Rows.Add(
                        reader("DeliveryID"),
                        reader("CustomerName"),
                        reader("Phone"),
                        reader("DeliveryAddress"),
                        reader("DriverName"),
                        Convert.ToDateTime(reader("DeliveryDate")).ToString("MMM dd, yyyy"),
                        Convert.ToDateTime(reader("DeliveryTime")).ToString("HH:mm"),
                        reader("Status"),
                        Convert.ToDecimal(reader("DeliveryFee")).ToString("C2")
                    )

                    ' Color code by status
                    Dim status As String = reader("Status").ToString()
                    Select Case status
                        Case "Pending"
                            dgvDeliveries.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightYellow
                        Case "Out for Delivery"
                            dgvDeliveries.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightBlue
                        Case "Completed"
                            dgvDeliveries.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                        Case "Cancelled"
                            dgvDeliveries.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightCoral
                    End Select
                End While
            End Using
        End Using

        dgvDeliveries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' ---------------------- FORM CONTROLS ----------------------
    Private Sub ResetForm()
        isEditing = False
        selectedDeliveryId = -1
        
        ' Clear customer info
        txtCustomerName.Clear()
        txtCustomerPhone.Clear()
        txtCustomerEmail.Clear()
        txtAddress.Clear()
        txtCity.Clear()
        txtPostalCode.Clear()
        txtSpecialInstructions.Clear()
        
        ' Reset delivery details
        dtpDeliveryDate.Value = DateTime.Today
        dtpDeliveryTime.Value = DateTime.Now.AddHours(1)
        cmbDriver.SelectedIndex = -1
        nudDeliveryFee.Value = 50 ' Default delivery fee
        txtNotes.Clear()
        
        ' Enable/disable buttons
        btnSaveDelivery.Enabled = False
        btnCancelDelivery.Enabled = False
        btnDeleteDelivery.Enabled = False
        btnEditDelivery.Enabled = False
        btnNewDelivery.Enabled = True
        
        ' Enable form controls
        EnableFormControls(True)
    End Sub

    Private Sub EnableFormControls(enabled As Boolean)
        txtCustomerName.Enabled = enabled
        txtCustomerPhone.Enabled = enabled
        txtCustomerEmail.Enabled = enabled
        txtAddress.Enabled = enabled
        txtCity.Enabled = enabled
        txtPostalCode.Enabled = enabled
        txtSpecialInstructions.Enabled = enabled
        dtpDeliveryDate.Enabled = enabled
        dtpDeliveryTime.Enabled = enabled
        cmbDriver.Enabled = enabled
        nudDeliveryFee.Enabled = enabled
        txtNotes.Enabled = enabled
    End Sub

    ' ---------------------- DELIVERY SELECTION ----------------------
    Private Sub dgvDeliveries_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDeliveries.SelectionChanged
        If dgvDeliveries.SelectedRows.Count > 0 AndAlso Not isEditing Then
            Dim selectedRow As DataGridViewRow = dgvDeliveries.SelectedRows(0)
            selectedDeliveryId = Convert.ToInt32(selectedRow.Cells("DeliveryID").Value)
            
            ' Enable edit and delete buttons
            btnEditDelivery.Enabled = True
            btnDeleteDelivery.Enabled = True
        End If
    End Sub

    ' ---------------------- BUTTON EVENTS ----------------------
    Private Sub btnNewDelivery_Click(sender As Object, e As EventArgs) Handles btnNewDelivery.Click
        If currentOrderData Is Nothing OrElse currentOrderData.Rows.Count = 0 Then
            MessageBox.Show("No order data available. Please go back to Order Entry and add items first.", "No Order Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ResetForm()
        EnableFormControls(True)
        btnSaveDelivery.Enabled = True
        btnCancelDelivery.Enabled = True
        txtCustomerName.Focus()
    End Sub

    Private Sub btnEditDelivery_Click(sender As Object, e As EventArgs) Handles btnEditDelivery.Click
        If selectedDeliveryId = -1 Then
            MessageBox.Show("Please select a delivery to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        LoadDeliveryData(selectedDeliveryId)
        isEditing = True
        EnableFormControls(True)
        btnSaveDelivery.Enabled = True
        btnCancelDelivery.Enabled = True
        btnEditDelivery.Enabled = False
        btnDeleteDelivery.Enabled = False
        btnNewDelivery.Enabled = False
    End Sub

    Private Sub LoadDeliveryData(deliveryId As Integer)
        Dim query As String = "
            SELECT do.*, dc.CustomerName, dc.Phone, dc.Email, dc.Address, dc.City, dc.PostalCode, dc.SpecialInstructions
            FROM DeliveryOrders do
            INNER JOIN DeliveryCustomers dc ON do.CustomerID = dc.CustomerID
            WHERE do.DeliveryID = @DeliveryID"

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@DeliveryID", deliveryId)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    txtCustomerName.Text = reader("CustomerName").ToString()
                    txtCustomerPhone.Text = reader("Phone").ToString()
                    txtCustomerEmail.Text = reader("Email").ToString()
                    txtAddress.Text = reader("Address").ToString()
                    txtCity.Text = reader("City").ToString()
                    txtPostalCode.Text = reader("PostalCode").ToString()
                    txtSpecialInstructions.Text = reader("SpecialInstructions").ToString()
                    
                    dtpDeliveryDate.Value = Convert.ToDateTime(reader("DeliveryDate"))
                    dtpDeliveryTime.Value = Convert.ToDateTime(reader("DeliveryTime"))
                    nudDeliveryFee.Value = Convert.ToDecimal(reader("DeliveryFee"))
                    txtNotes.Text = reader("Notes").ToString()

                    ' Select the driver in combo box
                    Dim driverId As Object = reader("DriverID")
                    If driverId IsNot DBNull.Value Then
                        For i As Integer = 0 To cmbDriver.Items.Count - 1
                            Dim item As ComboBoxItem = CType(cmbDriver.Items(i), ComboBoxItem)
                            If item.Value = Convert.ToInt32(driverId) Then
                                cmbDriver.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                End If
            End Using
        End Using
    End Sub

    Private Sub btnSaveDelivery_Click(sender As Object, e As EventArgs) Handles btnSaveDelivery.Click
        If Not ValidateForm() Then Return

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim trans As SqlTransaction = conn.BeginTransaction()

                Try
                    If isEditing Then
                        ' Update existing delivery
                        UpdateDelivery(conn, trans)
                    Else
                        ' Create new delivery order
                        CreateDeliveryOrder(conn, trans)
                    End If

                    trans.Commit()
                    Dim message As String = If(isEditing, "Delivery updated successfully!", "Delivery order created successfully!")
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LoadDeliveries()
                    LoadDrivers() ' Refresh driver list in case status changed
                    ResetForm()

                Catch ex As Exception
                    trans.Rollback()
                    Throw ex
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving delivery: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateDeliveryOrder(conn As SqlConnection, trans As SqlTransaction)
        ' First, create the main order
        Dim orderId As Integer = CreateMainOrder(conn, trans)

        ' Create or find customer
        Dim customerId As Integer = CreateOrFindCustomer(conn, trans)

        ' Create delivery order
        Dim deliveryQuery As String = "
            INSERT INTO DeliveryOrders (OrderID, CustomerID, DriverID, DeliveryAddress, DeliveryDate, DeliveryTime, 
                                      DeliveryFee, Status, Notes)
            VALUES (@OrderID, @CustomerID, @DriverID, @DeliveryAddress, @DeliveryDate, @DeliveryTime, 
                    @DeliveryFee, @Status, @Notes)"

        Using cmd As New SqlCommand(deliveryQuery, conn, trans)
            cmd.Parameters.AddWithValue("@OrderID", orderId)
            cmd.Parameters.AddWithValue("@CustomerID", customerId)
            
            If cmbDriver.SelectedIndex >= 0 Then
                cmd.Parameters.AddWithValue("@DriverID", CType(cmbDriver.SelectedItem, ComboBoxItem).Value)
            Else
                cmd.Parameters.AddWithValue("@DriverID", DBNull.Value)
            End If

            cmd.Parameters.AddWithValue("@DeliveryAddress", GetFullAddress())
            cmd.Parameters.AddWithValue("@DeliveryDate", dtpDeliveryDate.Value.Date)
            cmd.Parameters.AddWithValue("@DeliveryTime", dtpDeliveryTime.Value.TimeOfDay)
            cmd.Parameters.AddWithValue("@DeliveryFee", nudDeliveryFee.Value)
            cmd.Parameters.AddWithValue("@Status", "Pending")
            cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text))

            cmd.ExecuteNonQuery()
        End Using

        ' Update driver status if assigned
        If cmbDriver.SelectedIndex >= 0 Then
            UpdateDriverStatus(conn, trans, CType(cmbDriver.SelectedItem, ComboBoxItem).Value, "Busy")
        End If
    End Sub

    Private Sub UpdateDelivery(conn As SqlConnection, trans As SqlTransaction)
        ' Update customer information
        UpdateCustomer(conn, trans)

        ' Update delivery order
        Dim deliveryQuery As String = "
            UPDATE DeliveryOrders 
            SET DriverID = @DriverID, DeliveryAddress = @DeliveryAddress, 
                DeliveryDate = @DeliveryDate, DeliveryTime = @DeliveryTime, 
                DeliveryFee = @DeliveryFee, Notes = @Notes
            WHERE DeliveryID = @DeliveryID"

        Using cmd As New SqlCommand(deliveryQuery, conn, trans)
            If cmbDriver.SelectedIndex >= 0 Then
                cmd.Parameters.AddWithValue("@DriverID", CType(cmbDriver.SelectedItem, ComboBoxItem).Value)
            Else
                cmd.Parameters.AddWithValue("@DriverID", DBNull.Value)
            End If

            cmd.Parameters.AddWithValue("@DeliveryAddress", GetFullAddress())
            cmd.Parameters.AddWithValue("@DeliveryDate", dtpDeliveryDate.Value.Date)
            cmd.Parameters.AddWithValue("@DeliveryTime", dtpDeliveryTime.Value.TimeOfDay)
            cmd.Parameters.AddWithValue("@DeliveryFee", nudDeliveryFee.Value)
            cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text))
            cmd.Parameters.AddWithValue("@DeliveryID", selectedDeliveryId)

            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function CreateMainOrder(conn As SqlConnection, trans As SqlTransaction) As Integer
        ' Insert into Orders table
        Dim orderQuery As String = "
            INSERT INTO Orders (OrderDate, TableNo, Total, PaymentType) 
            OUTPUT INSERTED.OrderID 
            VALUES (@OrderDate, @TableNo, @Total, @PaymentType)"

        Dim orderId As Integer
        Using cmdOrder As New SqlCommand(orderQuery, conn, trans)
            cmdOrder.Parameters.AddWithValue("@OrderDate", DateTime.Now)
            cmdOrder.Parameters.AddWithValue("@TableNo", 0) ' 0 for delivery orders
            cmdOrder.Parameters.AddWithValue("@Total", orderTotal + nudDeliveryFee.Value)
            cmdOrder.Parameters.AddWithValue("@PaymentType", currentPaymentMethod)

            orderId = Convert.ToInt32(cmdOrder.ExecuteScalar())
        End Using

        ' Insert order details
        For Each row As DataGridViewRow In currentOrderData.Rows
            If row.IsNewRow Then Continue For

            Dim itemName As String = row.Cells("ItemName").Value.ToString()
            Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
            Dim quantity As Integer = Convert.ToInt32(row.Cells("Quantity").Value)
            Dim subtotal As Decimal = Convert.ToDecimal(row.Cells("Total").Value)

            ' Get ProductID from MenuItems
            Dim productId As Integer = -1
            Using cmdProduct As New SqlCommand("SELECT ItemID FROM MenuItems WHERE ItemName = @ItemName", conn, trans)
                cmdProduct.Parameters.AddWithValue("@ItemName", itemName)
                Dim result = cmdProduct.ExecuteScalar()
                If result IsNot Nothing Then
                    productId = Convert.ToInt32(result)
                End If
            End Using

            If productId <> -1 Then
                Dim detailQuery As String = "
                    INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price, Subtotal) 
                    VALUES (@OrderID, @ProductID, @Quantity, @Price, @Subtotal)"
                Using cmdDetail As New SqlCommand(detailQuery, conn, trans)
                    cmdDetail.Parameters.AddWithValue("@OrderID", orderId)
                    cmdDetail.Parameters.AddWithValue("@ProductID", productId)
                    cmdDetail.Parameters.AddWithValue("@Quantity", quantity)
                    cmdDetail.Parameters.AddWithValue("@Price", price)
                    cmdDetail.Parameters.AddWithValue("@Subtotal", subtotal)
                    cmdDetail.ExecuteNonQuery()
                End Using
            End If
        Next

        Return orderId
    End Function

    Private Function CreateOrFindCustomer(conn As SqlConnection, trans As SqlTransaction) As Integer
        ' Check if customer already exists by phone
        Dim checkQuery As String = "SELECT CustomerID FROM DeliveryCustomers WHERE Phone = @Phone"
        Using cmd As New SqlCommand(checkQuery, conn, trans)
            cmd.Parameters.AddWithValue("@Phone", txtCustomerPhone.Text.Trim())
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                Return Convert.ToInt32(result)
            End If
        End Using

        ' Create new customer
        Dim insertQuery As String = "
            INSERT INTO DeliveryCustomers (CustomerName, Phone, Email, Address, City, PostalCode, SpecialInstructions)
            OUTPUT INSERTED.CustomerID
            VALUES (@CustomerName, @Phone, @Email, @Address, @City, @PostalCode, @SpecialInstructions)"

        Using cmd As New SqlCommand(insertQuery, conn, trans)
            cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim())
            cmd.Parameters.AddWithValue("@Phone", txtCustomerPhone.Text.Trim())
            cmd.Parameters.AddWithValue("@Email", If(String.IsNullOrEmpty(txtCustomerEmail.Text), DBNull.Value, txtCustomerEmail.Text.Trim()))
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
            cmd.Parameters.AddWithValue("@City", If(String.IsNullOrEmpty(txtCity.Text), DBNull.Value, txtCity.Text.Trim()))
            cmd.Parameters.AddWithValue("@PostalCode", If(String.IsNullOrEmpty(txtPostalCode.Text), DBNull.Value, txtPostalCode.Text.Trim()))
            cmd.Parameters.AddWithValue("@SpecialInstructions", If(String.IsNullOrEmpty(txtSpecialInstructions.Text), DBNull.Value, txtSpecialInstructions.Text.Trim()))

            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Private Sub UpdateCustomer(conn As SqlConnection, trans As SqlTransaction)
        Dim customerQuery As String = "
            UPDATE DeliveryCustomers 
            SET CustomerName = @CustomerName, Phone = @Phone, Email = @Email, 
                Address = @Address, City = @City, PostalCode = @PostalCode, SpecialInstructions = @SpecialInstructions
            WHERE CustomerID = (SELECT CustomerID FROM DeliveryOrders WHERE DeliveryID = @DeliveryID)"

        Using cmd As New SqlCommand(customerQuery, conn, trans)
            cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim())
            cmd.Parameters.AddWithValue("@Phone", txtCustomerPhone.Text.Trim())
            cmd.Parameters.AddWithValue("@Email", If(String.IsNullOrEmpty(txtCustomerEmail.Text), DBNull.Value, txtCustomerEmail.Text.Trim()))
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
            cmd.Parameters.AddWithValue("@City", If(String.IsNullOrEmpty(txtCity.Text), DBNull.Value, txtCity.Text.Trim()))
            cmd.Parameters.AddWithValue("@PostalCode", If(String.IsNullOrEmpty(txtPostalCode.Text), DBNull.Value, txtPostalCode.Text.Trim()))
            cmd.Parameters.AddWithValue("@SpecialInstructions", If(String.IsNullOrEmpty(txtSpecialInstructions.Text), DBNull.Value, txtSpecialInstructions.Text.Trim()))
            cmd.Parameters.AddWithValue("@DeliveryID", selectedDeliveryId)

            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub UpdateDriverStatus(conn As SqlConnection, trans As SqlTransaction, driverId As Integer, status As String)
        Dim query As String = "UPDATE DeliveryDrivers SET Status = @Status WHERE DriverID = @DriverID"
        Using cmd As New SqlCommand(query, conn, trans)
            cmd.Parameters.AddWithValue("@Status", status)
            cmd.Parameters.AddWithValue("@DriverID", driverId)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function GetFullAddress() As String
        Dim address As String = txtAddress.Text.Trim()
        If Not String.IsNullOrEmpty(txtCity.Text) Then
            address &= ", " & txtCity.Text.Trim()
        End If
        If Not String.IsNullOrEmpty(txtPostalCode.Text) Then
            address &= " " & txtPostalCode.Text.Trim()
        End If
        Return address
    End Function

    Private Sub btnDeleteDelivery_Click(sender As Object, e As EventArgs) Handles btnDeleteDelivery.Click
        If selectedDeliveryId = -1 Then
            MessageBox.Show("Please select a delivery to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this delivery? This action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(connectionString)
                    conn.Open()
                    Dim query As String = "DELETE FROM DeliveryOrders WHERE DeliveryID = @DeliveryID"
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@DeliveryID", selectedDeliveryId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Delivery deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDeliveries()
                LoadDrivers() ' Refresh driver list
                ResetForm()

            Catch ex As Exception
                MessageBox.Show("Error deleting delivery: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnUpdateStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateStatus.Click
        If selectedDeliveryId = -1 Then
            MessageBox.Show("Please select a delivery to update status.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get current status
        Dim currentStatus As String = ""
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT Status FROM DeliveryOrders WHERE DeliveryID = @DeliveryID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@DeliveryID", selectedDeliveryId)
                currentStatus = cmd.ExecuteScalar().ToString()
            End Using
        End Using

        ' Show status update dialog
        Dim statusForm As New StatusUpdateForm(currentStatus)
        If statusForm.ShowDialog() = DialogResult.OK Then
            Try
                Using conn As New SqlConnection(connectionString)
                    conn.Open()
                    Dim query As String = "UPDATE DeliveryOrders SET Status = @Status WHERE DeliveryID = @DeliveryID"
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@Status", statusForm.SelectedStatus)
                        cmd.Parameters.AddWithValue("@DeliveryID", selectedDeliveryId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show($"Delivery status updated to {statusForm.SelectedStatus}.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDeliveries()
                LoadDrivers() ' Refresh driver list in case driver status changed

            Catch ex As Exception
                MessageBox.Show("Error updating status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnCancelDelivery_Click(sender As Object, e As EventArgs) Handles btnCancelDelivery.Click
        ResetForm()
    End Sub

    Private Sub btnRefreshDeliveries_Click(sender As Object, e As EventArgs) Handles btnRefreshDeliveries.Click
        LoadDeliveries()
        LoadDrivers()
    End Sub

    ' ---------------------- VALIDATION ----------------------
    Private Function ValidateForm() As Boolean
        If String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
            MessageBox.Show("Please enter customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCustomerName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtCustomerPhone.Text) Then
            MessageBox.Show("Please enter customer phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCustomerPhone.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Please enter delivery address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Return False
        End If

        ' Check if delivery date is in the past (except when editing)
        If Not isEditing AndAlso dtpDeliveryDate.Value.Date < DateTime.Today Then
            MessageBox.Show("Delivery date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpDeliveryDate.Focus()
            Return False
        End If

        Return True
    End Function

    ' ---------------------- NAVIGATION ----------------------
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim orderEntryForm As New OrderEntryFrm
        orderEntryForm.Show()
        Close()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim loginForm As New LoginFrm()
        loginForm.Show()
        Me.Close()
    End Sub

    ' ---------------------- COMBO BOX HELPER CLASS ----------------------
    Private Class ComboBoxItem
        Public Property Text As String
        Public Property Value As Integer

        Public Sub New(text As String, value As Integer)
            Me.Text = text
            Me.Value = value
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class
End Class

' ---------------------- STATUS UPDATE FORM ----------------------
Public Class StatusUpdateForm
    Inherits Form
    
    Public Property SelectedStatus As String

    Private cmbStatus As ComboBox
    Private btnOK As Button
    Private btnCancel As Button

    Public Sub New(currentStatus As String)
        InitializeComponent()
        SelectedStatus = currentStatus
        
        ' Populate status options
        cmbStatus.Items.Add("Pending")
        cmbStatus.Items.Add("Out for Delivery")
        cmbStatus.Items.Add("Completed")
        cmbStatus.Items.Add("Cancelled")
        
        ' Select current status
        cmbStatus.SelectedItem = currentStatus
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Update Delivery Status"
        Me.Size = New Size(300, 150)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        Dim lblStatus As New Label()
        lblStatus.Text = "Select New Status:"
        lblStatus.Location = New Point(20, 20)
        lblStatus.Size = New Size(100, 20)

        cmbStatus = New ComboBox()
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.Location = New Point(20, 45)
        cmbStatus.Size = New Size(240, 20)

        btnOK = New Button()
        btnOK.Text = "OK"
        btnOK.Location = New Point(110, 80)
        btnOK.Size = New Size(75, 25)
        AddHandler btnOK.Click, AddressOf BtnOK_Click

        btnCancel = New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Location = New Point(190, 80)
        btnCancel.Size = New Size(75, 25)
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click

        Me.Controls.Add(lblStatus)
        Me.Controls.Add(cmbStatus)
        Me.Controls.Add(btnOK)
        Me.Controls.Add(btnCancel)
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs)
        If cmbStatus.SelectedItem IsNot Nothing Then
            SelectedStatus = cmbStatus.SelectedItem.ToString()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class

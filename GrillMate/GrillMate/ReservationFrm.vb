Imports System.Data.SqlClient

Public Class ReservationFrm
    Private connectionString As String = "Server=AEGON;Database=GrillMate;Trusted_Connection=True;"
    Private isEditing As Boolean = False
    Private selectedReservationId As Integer = -1
    Private currentReservationDate As DateTime = DateTime.Today

    Private Sub ReservationFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTables()
        LoadReservations()
        ResetForm()
        SetupCalendar()
    End Sub

    ' ---------------------- FORM SETUP ----------------------
    Private Sub SetupCalendar()
        ' Set minimum date to today
        monthCalendar.MinDate = DateTime.Today
        monthCalendar.MaxDate = DateTime.Today.AddMonths(3)

        ' Add event handler for calendar selection
        AddHandler monthCalendar.DateSelected, AddressOf MonthCalendar_DateSelected
    End Sub

    Private Sub MonthCalendar_DateSelected(sender As Object, e As DateRangeEventArgs)
        currentReservationDate = e.Start
        lblSelectedDate.Text = "Selected Date: " & currentReservationDate.ToString("MMM dd, yyyy")
        LoadReservationsForDate(currentReservationDate)
    End Sub

    ' ---------------------- LOAD DATA ----------------------
    Private Sub LoadTables()
        cmbTable.Items.Clear()
        Dim query As String = "SELECT TableID, TableName, Status FROM Tables WHERE Status IN ('Vacant', 'Reserved') ORDER BY TableName"

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim status As String = reader("Status").ToString()
                    Dim displayText As String = reader("TableName").ToString() & " (" & status & ")"
                    cmbTable.Items.Add(New ComboBoxItem(displayText, Convert.ToInt32(reader("TableID"))))
                End While
            End Using
        End Using
    End Sub

    Private Sub LoadReservations()
        LoadReservationsForDate(currentReservationDate)
    End Sub

    Private Sub LoadReservationsForDate(selectedDate As DateTime)
        dgvReservations.Rows.Clear()
        dgvReservations.Columns.Clear()

        ' Define columns
        dgvReservations.Columns.Add("ReservationID", "ID")
        dgvReservations.Columns.Add("CustomerName", "Customer")
        dgvReservations.Columns.Add("Phone", "Phone")
        dgvReservations.Columns.Add("ReservationTime", "Time")
        dgvReservations.Columns.Add("TableName", "Table")
        dgvReservations.Columns.Add("PartySize", "Party Size")
        dgvReservations.Columns.Add("Status", "Status")

        Dim query As String = "
            SELECT r.ReservationID, r.CustomerName, r.CustomerPhone, r.ReservationTime, 
                   t.TableName, r.PartySize, r.Status
            FROM Reservations r
            INNER JOIN Tables t ON r.TableID = t.TableID
            WHERE r.ReservationDate = @ReservationDate
            ORDER BY r.ReservationTime"

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ReservationDate", selectedDate.Date)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    Dim rowIndex As Integer = dgvReservations.Rows.Add(
                        reader("ReservationID"),
                        reader("CustomerName"),
                        reader("CustomerPhone"),
                        Convert.ToDateTime(reader("ReservationTime")).ToString("HH:mm"),
                        reader("TableName"),
                        reader("PartySize"),
                        reader("Status")
                    )

                    ' Color code by status
                    Dim status As String = reader("Status").ToString()
                    Select Case status
                        Case "Confirmed"
                            dgvReservations.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                        Case "Cancelled"
                            dgvReservations.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightCoral
                        Case "Completed"
                            dgvReservations.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightBlue
                    End Select
                End While
            End Using
        End Using

        ' Auto-size columns
        dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' ---------------------- FORM CONTROLS ----------------------
    Private Sub ResetForm()
        isEditing = False
        selectedReservationId = -1

        ' Clear customer details
        txtCustomerName.Clear()
        txtPhone.Clear()
        txtEmail.Clear()

        ' Reset reservation details
        dtpReservationDate.Value = currentReservationDate
        dtpReservationTime.Value = DateTime.Today.AddHours(18) ' Default to 6 PM
        cmbTable.SelectedIndex = -1
        nudPartySize.Value = 2
        txtSpecialRequests.Clear()

        ' Enable/disable buttons
        btnSaveReservation.Enabled = False
        btnCancelReservation.Enabled = False
        btnDeleteReservation.Enabled = False
        btnEditReservation.Enabled = False
        btnNewReservation.Enabled = True

        ' Enable form controls
        EnableFormControls(True)
    End Sub

    Private Sub EnableFormControls(enabled As Boolean)
        txtCustomerName.Enabled = enabled
        txtPhone.Enabled = enabled
        txtEmail.Enabled = enabled
        dtpReservationDate.Enabled = enabled
        dtpReservationTime.Enabled = enabled
        cmbTable.Enabled = enabled
        nudPartySize.Enabled = enabled
        txtSpecialRequests.Enabled = enabled
    End Sub

    ' ---------------------- RESERVATION SELECTION ----------------------
    Private Sub dgvReservations_SelectionChanged(sender As Object, e As EventArgs) Handles dgvReservations.SelectionChanged
        If dgvReservations.SelectedRows.Count > 0 AndAlso Not isEditing Then
            Dim selectedRow As DataGridViewRow = dgvReservations.SelectedRows(0)
            selectedReservationId = Convert.ToInt32(selectedRow.Cells("ReservationID").Value)

            ' Enable edit and delete buttons
            btnEditReservation.Enabled = True
            btnDeleteReservation.Enabled = True
        End If
    End Sub

    ' ---------------------- BUTTON EVENTS ----------------------
    Private Sub btnNewReservation_Click(sender As Object, e As EventArgs) Handles btnNewReservation.Click
        ResetForm()
        EnableFormControls(True)
        btnSaveReservation.Enabled = True
        btnCancelReservation.Enabled = True
        txtCustomerName.Focus()
    End Sub

    Private Sub btnEditReservation_Click(sender As Object, e As EventArgs) Handles btnEditReservation.Click
        If selectedReservationId = -1 Then
            MessageBox.Show("Please select a reservation to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        LoadReservationData(selectedReservationId)
        isEditing = True
        EnableFormControls(True)
        btnSaveReservation.Enabled = True
        btnCancelReservation.Enabled = True
        btnEditReservation.Enabled = False
        btnDeleteReservation.Enabled = False
        btnNewReservation.Enabled = False
    End Sub

    Private Sub LoadReservationData(reservationId As Integer)
        Dim query As String = "
            SELECT CustomerName, CustomerPhone, CustomerEmail, ReservationDate, 
                   ReservationTime, TableID, PartySize, SpecialRequests
            FROM Reservations 
            WHERE ReservationID = @ReservationID"

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ReservationID", reservationId)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    txtCustomerName.Text = reader("CustomerName").ToString()
                    txtPhone.Text = reader("CustomerPhone").ToString()
                    txtEmail.Text = reader("CustomerEmail").ToString()
                    dtpReservationDate.Value = Convert.ToDateTime(reader("ReservationDate"))
                    dtpReservationTime.Value = Convert.ToDateTime(reader("ReservationTime"))
                    nudPartySize.Value = Convert.ToInt32(reader("PartySize"))
                    txtSpecialRequests.Text = reader("SpecialRequests").ToString()

                    ' Select the table in combo box
                    Dim tableId As Integer = Convert.ToInt32(reader("TableID"))
                    For i As Integer = 0 To cmbTable.Items.Count - 1
                        Dim item As ComboBoxItem = CType(cmbTable.Items(i), ComboBoxItem)
                        If item.Value = tableId Then
                            cmbTable.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End Using
        End Using
    End Sub

    Private Sub btnSaveReservation_Click(sender As Object, e As EventArgs) Handles btnSaveReservation.Click
        If Not ValidateForm() Then Return

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String

                If isEditing Then
                    ' Update existing reservation
                    query = "
                        UPDATE Reservations 
                        SET CustomerName = @CustomerName, CustomerPhone = @CustomerPhone, 
                            CustomerEmail = @CustomerEmail, ReservationDate = @ReservationDate, 
                            ReservationTime = @ReservationTime, TableID = @TableID, 
                            PartySize = @PartySize, SpecialRequests = @SpecialRequests
                        WHERE ReservationID = @ReservationID"
                Else
                    ' Insert new reservation
                    query = "
                        INSERT INTO Reservations (CustomerName, CustomerPhone, CustomerEmail, 
                                                ReservationDate, ReservationTime, TableID, 
                                                PartySize, SpecialRequests, Status)
                        VALUES (@CustomerName, @CustomerPhone, @CustomerEmail, 
                                @ReservationDate, @ReservationTime, @TableID, 
                                @PartySize, @SpecialRequests, 'Confirmed')"
                End If

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim())
                    cmd.Parameters.AddWithValue("@CustomerPhone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@CustomerEmail", If(String.IsNullOrEmpty(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim()))
                    cmd.Parameters.AddWithValue("@ReservationDate", dtpReservationDate.Value.Date)
                    cmd.Parameters.AddWithValue("@ReservationTime", dtpReservationTime.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@TableID", CType(cmbTable.SelectedItem, ComboBoxItem).Value)
                    cmd.Parameters.AddWithValue("@PartySize", Convert.ToInt32(nudPartySize.Value))
                    cmd.Parameters.AddWithValue("@SpecialRequests", If(String.IsNullOrEmpty(txtSpecialRequests.Text), DBNull.Value, txtSpecialRequests.Text.Trim()))

                    If isEditing Then
                        cmd.Parameters.AddWithValue("@ReservationID", selectedReservationId)
                    End If

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Dim message As String = If(isEditing, "Reservation updated successfully!", "Reservation created successfully!")
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Update table status if new reservation
            If Not isEditing Then
                UpdateTableStatus(CType(cmbTable.SelectedItem, ComboBoxItem).Value, "Reserved")
            End If

            LoadTables() ' Refresh table list
            LoadReservations()
            ResetForm()

        Catch ex As Exception
            MessageBox.Show("Error saving reservation: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeleteReservation_Click(sender As Object, e As EventArgs) Handles btnDeleteReservation.Click
        If selectedReservationId = -1 Then
            MessageBox.Show("Please select a reservation to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this reservation? This action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            Try
                ' Get table ID before deleting
                Dim tableId As Integer = -1
                Using conn As New SqlConnection(connectionString)
                    conn.Open()
                    Dim getTableQuery As String = "SELECT TableID FROM Reservations WHERE ReservationID = @ReservationID"
                    Using cmd As New SqlCommand(getTableQuery, conn)
                        cmd.Parameters.AddWithValue("@ReservationID", selectedReservationId)
                        Dim result_obj = cmd.ExecuteScalar()
                        If result_obj IsNot Nothing Then
                            tableId = Convert.ToInt32(result_obj)
                        End If
                    End Using
                End Using

                ' Delete reservation
                Using conn As New SqlConnection(connectionString)
                    conn.Open()
                    Dim query As String = "DELETE FROM Reservations WHERE ReservationID = @ReservationID"
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@ReservationID", selectedReservationId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                ' Update table status to Vacant if it was reserved
                If tableId <> -1 Then
                    UpdateTableStatus(tableId, "Vacant")
                End If

                MessageBox.Show("Reservation deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTables() ' Refresh table list
                LoadReservations()
                ResetForm()

            Catch ex As Exception
                MessageBox.Show("Error deleting reservation: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnCancelReservation_Click(sender As Object, e As EventArgs) Handles btnCancelReservation.Click
        ResetForm()
    End Sub

    ' ---------------------- VALIDATION ----------------------
    Private Function ValidateForm() As Boolean
        If String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
            MessageBox.Show("Please enter customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCustomerName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPhone.Text) Then
            MessageBox.Show("Please enter customer phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Return False
        End If

        If cmbTable.SelectedIndex = -1 Then
            MessageBox.Show("Please select a table.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTable.Focus()
            Return False
        End If

        ' Check if reservation date is in the past (except when editing)
        If Not isEditing AndAlso dtpReservationDate.Value.Date < DateTime.Today Then
            MessageBox.Show("Reservation date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpReservationDate.Focus()
            Return False
        End If

        ' Check for time conflicts (optional - can be enhanced)
        If Not CheckTimeConflict() Then
            Return False
        End If

        Return True
    End Function

    Private Function CheckTimeConflict() As Boolean
        Dim selectedTableId As Integer = CType(cmbTable.SelectedItem, ComboBoxItem).Value
        Dim reservationDate As DateTime = dtpReservationDate.Value.Date
        Dim reservationTime As TimeSpan = dtpReservationTime.Value.TimeOfDay

        Dim query As String = "
            SELECT COUNT(*) FROM Reservations 
            WHERE TableID = @TableID 
            AND ReservationDate = @ReservationDate 
            AND ReservationTime = @ReservationTime
            AND Status = 'Confirmed'"

        If isEditing Then
            query &= " AND ReservationID <> @ReservationID"
        End If

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@TableID", selectedTableId)
                cmd.Parameters.AddWithValue("@ReservationDate", reservationDate)
                cmd.Parameters.AddWithValue("@ReservationTime", reservationTime)
                If isEditing Then
                    cmd.Parameters.AddWithValue("@ReservationID", selectedReservationId)
                End If

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("This table is already reserved at the selected time.", "Time Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using
        End Using

        Return True
    End Function

    ' ---------------------- HELPER METHODS ----------------------
    Private Sub UpdateTableStatus(tableId As Integer, newStatus As String)
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE Tables SET Status = @Status WHERE TableID = @TableID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Status", newStatus)
                    cmd.Parameters.AddWithValue("@TableID", tableId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Log error but don't show to user as this is a secondary operation
            Console.WriteLine("Error updating table status: " & ex.Message)
        End Try
    End Sub

    ' ---------------------- NAVIGATION ----------------------
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim dashboard As New Dashboard
        dashboard.Show
        Close
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dashboard As New Dashboard
        dashboard.Show()
        Close()
    End Sub
End Class


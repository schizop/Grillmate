Imports System.Data.SqlClient

Public Class TableManagementFrm
    Private connectionString As String = "Server=AEGON;Database=GrillMate;Trusted_Connection=True;"
    Private isEditing As Boolean = False
    Private selectedTableId As Integer = -1

    Private Sub TableManagementFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTables()
        ResetForm()
    End Sub

    ' ---------------------- LOAD TABLES ----------------------
    Private Sub LoadTables()
        dgvTables.Rows.Clear()
        dgvTables.Columns.Clear()

        ' Define columns
        dgvTables.Columns.Add("TableID", "ID")
        dgvTables.Columns.Add("TableName", "Table Name")
        dgvTables.Columns.Add("Status", "Status")

        Dim query As String = "SELECT TableID, TableName, Status FROM Tables ORDER BY TableName"
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim status As String = reader("Status").ToString()
                    Dim rowIndex As Integer = dgvTables.Rows.Add(
                        reader("TableID"),
                        reader("TableName"),
                        status
                    )

                    ' Color code the status
                    Select Case status
                        Case "Vacant"
                            dgvTables.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                        Case "Occupied"
                            dgvTables.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Orange
                        Case "Reserved"
                            dgvTables.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightCoral
                    End Select
                End While
            End Using
        End Using

        ' Auto-size columns
        dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' ---------------------- FORM CONTROLS ----------------------
    Private Sub ResetForm()
        isEditing = False
        selectedTableId = -1
        txtTableName.Clear()
        txtTableName.Enabled = False
        
        btnSaveTable.Enabled = False
        btnCancelEdit.Enabled = False
        btnEditTable.Enabled = True
        btnDeleteTable.Enabled = True
        btnAddTable.Enabled = True
        
        btnSetVacant.Enabled = False
        btnSetOccupied.Enabled = False
        btnSetReserved.Enabled = False
    End Sub

    Private Sub EnableEditMode()
        isEditing = True
        txtTableName.Enabled = True
        
        btnSaveTable.Enabled = True
        btnCancelEdit.Enabled = True
        btnEditTable.Enabled = False
        btnDeleteTable.Enabled = False
        btnAddTable.Enabled = False
    End Sub

    ' ---------------------- TABLE SELECTION ----------------------
    Private Sub dgvTables_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTables.SelectionChanged
        If dgvTables.SelectedRows.Count > 0 AndAlso Not isEditing Then
            Dim selectedRow As DataGridViewRow = dgvTables.SelectedRows(0)
            selectedTableId = Convert.ToInt32(selectedRow.Cells("TableID").Value)
            
            ' Populate form with selected table data
            txtTableName.Text = selectedRow.Cells("TableName").Value.ToString()
            
            ' Enable status buttons
            btnSetVacant.Enabled = True
            btnSetOccupied.Enabled = True
            btnSetReserved.Enabled = True
        End If
    End Sub

    ' ---------------------- BUTTON EVENTS ----------------------
    Private Sub btnAddTable_Click(sender As Object, e As EventArgs) Handles btnAddTable.Click
        ResetForm()
        EnableEditMode()
        txtTableName.Focus()
        btnAddTable.Enabled = True
    End Sub

    Private Sub btnEditTable_Click(sender As Object, e As EventArgs) Handles btnEditTable.Click
        If selectedTableId = -1 Then
            MessageBox.Show("Please select a table to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        EnableEditMode()
    End Sub

    Private Sub btnDeleteTable_Click(sender As Object, e As EventArgs) Handles btnDeleteTable.Click
        If selectedTableId = -1 Then
            MessageBox.Show("Please select a table to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this table? This action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(connectionString)
                    conn.Open()
                    Dim query As String = "DELETE FROM Tables WHERE TableID = @TableID"
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@TableID", selectedTableId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show("Table deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTables()
                ResetForm()
            Catch ex As Exception
                MessageBox.Show("Error deleting table: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnSaveTable_Click(sender As Object, e As EventArgs) Handles btnSaveTable.Click
        If String.IsNullOrWhiteSpace(txtTableName.Text) Then
            MessageBox.Show("Please enter a table name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTableName.Focus()
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String

                If selectedTableId = -1 Then
                    ' Adding new table
                    query = "INSERT INTO Tables (TableName, Status) VALUES (@TableName, @Status)"
                Else
                    ' Updating existing table
                    query = "UPDATE Tables SET TableName = @TableName WHERE TableID = @TableID"
                End If

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@TableName", txtTableName.Text.Trim())
                    
                    If selectedTableId = -1 Then
                        cmd.Parameters.AddWithValue("@Status", "Vacant")
                    Else
                        cmd.Parameters.AddWithValue("@TableID", selectedTableId)
                    End If

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Dim message As String = If(selectedTableId = -1, "Table added successfully.", "Table updated successfully.")
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadTables()
            ResetForm()

        Catch ex As Exception
            MessageBox.Show("Error saving table: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelEdit_Click(sender As Object, e As EventArgs) Handles btnCancelEdit.Click
        ResetForm()
        LoadTables()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadTables()
        ResetForm()
    End Sub

    ' ---------------------- STATUS MANAGEMENT ----------------------
    Private Sub btnSetVacant_Click(sender As Object, e As EventArgs) Handles btnSetVacant.Click
        ChangeTableStatus("Vacant")
    End Sub

    Private Sub btnSetOccupied_Click(sender As Object, e As EventArgs) Handles btnSetOccupied.Click
        ChangeTableStatus("Occupied")
    End Sub

    Private Sub btnSetReserved_Click(sender As Object, e As EventArgs) Handles btnSetReserved.Click
        ChangeTableStatus("Reserved")
    End Sub

    Private Sub ChangeTableStatus(newStatus As String)
        If selectedTableId = -1 Then
            MessageBox.Show("Please select a table first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE Tables SET Status = @Status WHERE TableID = @TableID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Status", newStatus)
                    cmd.Parameters.AddWithValue("@TableID", selectedTableId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show($"Table status changed to {newStatus}.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadTables()
            
            ' Keep the same table selected
            For Each row As DataGridViewRow In dgvTables.Rows
                If Convert.ToInt32(row.Cells("TableID").Value) = selectedTableId Then
                    row.Selected = True
                    Exit For
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error updating table status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---------------------- NAVIGATION ----------------------
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim dashboard As New Dashboard()
        dashboard.Show()
        Me.Close()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim loginForm As New LoginFrm()
        loginForm.Show()
        Me.Close()
    End Sub
End Class

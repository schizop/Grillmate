<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReservationFrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        pnlHeader = New Panel()
        lblTitle = New Label()
        btnBack = New Button()
        btnLogout = New Button()
        grpCustomerDetails = New GroupBox()
        txtEmail = New TextBox()
        lblEmail = New Label()
        txtPhone = New TextBox()
        lblPhone = New Label()
        txtCustomerName = New TextBox()
        lblCustomerName = New Label()
        grpReservationDetails = New GroupBox()
        txtSpecialRequests = New TextBox()
        lblSpecialRequests = New Label()
        nudPartySize = New NumericUpDown()
        lblPartySize = New Label()
        cmbTable = New ComboBox()
        lblTable = New Label()
        dtpReservationDate = New DateTimePicker()
        lblReservationDate = New Label()
        dtpReservationTime = New DateTimePicker()
        lblReservationTime = New Label()
        grpCalendarView = New GroupBox()
        monthCalendar = New MonthCalendar()
        lblSelectedDate = New Label()
        dgvReservations = New DataGridView()
        btnNewReservation = New Button()
        btnSaveReservation = New Button()
        btnCancelReservation = New Button()
        btnDeleteReservation = New Button()
        btnEditReservation = New Button()
        ToolTip1 = New ToolTip(components)
        Button1 = New Button()
        pnlHeader.SuspendLayout()
        grpCustomerDetails.SuspendLayout()
        grpReservationDetails.SuspendLayout()
        CType(nudPartySize, ComponentModel.ISupportInitialize).BeginInit()
        grpCalendarView.SuspendLayout()
        CType(dgvReservations, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.DarkGray
        pnlHeader.Controls.Add(Button1)
        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Controls.Add(btnBack)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1050, 80)
        pnlHeader.TabIndex = 11
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.LightCoral
        btnLogout.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogout.Location = New Point(875, 665)
        btnLogout.Margin = New Padding(4, 3, 4, 3)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(117, 40)
        btnLogout.TabIndex = 9
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.Black
        lblTitle.Location = New Point(400, 18)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(403, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Reservation Management"
        ' 
        ' grpCustomerDetails
        ' 
        grpCustomerDetails.Controls.Add(txtEmail)
        grpCustomerDetails.Controls.Add(lblEmail)
        grpCustomerDetails.Controls.Add(txtPhone)
        grpCustomerDetails.Controls.Add(lblPhone)
        grpCustomerDetails.Controls.Add(txtCustomerName)
        grpCustomerDetails.Controls.Add(lblCustomerName)
        grpCustomerDetails.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpCustomerDetails.Location = New Point(14, 100)
        grpCustomerDetails.Margin = New Padding(4, 3, 4, 3)
        grpCustomerDetails.Name = "grpCustomerDetails"
        grpCustomerDetails.Padding = New Padding(4, 3, 4, 3)
        grpCustomerDetails.Size = New Size(408, 162)
        grpCustomerDetails.TabIndex = 0
        grpCustomerDetails.TabStop = False
        grpCustomerDetails.Text = "Customer Details"
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(117, 115)
        txtEmail.Margin = New Padding(4, 3, 4, 3)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(268, 23)
        txtEmail.TabIndex = 5
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmail.Location = New Point(18, 119)
        lblEmail.Margin = New Padding(4, 0, 4, 0)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(39, 15)
        lblEmail.TabIndex = 4
        lblEmail.Text = "Email:"
        ' 
        ' txtPhone
        ' 
        txtPhone.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPhone.Location = New Point(117, 75)
        txtPhone.Margin = New Padding(4, 3, 4, 3)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(268, 23)
        txtPhone.TabIndex = 3
        ' 
        ' lblPhone
        ' 
        lblPhone.AutoSize = True
        lblPhone.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPhone.Location = New Point(18, 78)
        lblPhone.Margin = New Padding(4, 0, 4, 0)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(44, 15)
        lblPhone.TabIndex = 2
        lblPhone.Text = "Phone:"
        ' 
        ' txtCustomerName
        ' 
        txtCustomerName.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCustomerName.Location = New Point(117, 35)
        txtCustomerName.Margin = New Padding(4, 3, 4, 3)
        txtCustomerName.Name = "txtCustomerName"
        txtCustomerName.Size = New Size(268, 23)
        txtCustomerName.TabIndex = 1
        ' 
        ' lblCustomerName
        ' 
        lblCustomerName.AutoSize = True
        lblCustomerName.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCustomerName.Location = New Point(18, 38)
        lblCustomerName.Margin = New Padding(4, 0, 4, 0)
        lblCustomerName.Name = "lblCustomerName"
        lblCustomerName.Size = New Size(97, 15)
        lblCustomerName.TabIndex = 0
        lblCustomerName.Text = "Customer Name:"
        ' 
        ' grpReservationDetails
        ' 
        grpReservationDetails.Controls.Add(txtSpecialRequests)
        grpReservationDetails.Controls.Add(lblSpecialRequests)
        grpReservationDetails.Controls.Add(nudPartySize)
        grpReservationDetails.Controls.Add(lblPartySize)
        grpReservationDetails.Controls.Add(cmbTable)
        grpReservationDetails.Controls.Add(lblTable)
        grpReservationDetails.Controls.Add(dtpReservationDate)
        grpReservationDetails.Controls.Add(lblReservationDate)
        grpReservationDetails.Controls.Add(dtpReservationTime)
        grpReservationDetails.Controls.Add(lblReservationTime)
        grpReservationDetails.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpReservationDetails.Location = New Point(14, 285)
        grpReservationDetails.Margin = New Padding(4, 3, 4, 3)
        grpReservationDetails.Name = "grpReservationDetails"
        grpReservationDetails.Padding = New Padding(4, 3, 4, 3)
        grpReservationDetails.Size = New Size(408, 300)
        grpReservationDetails.TabIndex = 1
        grpReservationDetails.TabStop = False
        grpReservationDetails.Text = "Reservation Details"
        ' 
        ' txtSpecialRequests
        ' 
        txtSpecialRequests.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSpecialRequests.Location = New Point(117, 242)
        txtSpecialRequests.Margin = New Padding(4, 3, 4, 3)
        txtSpecialRequests.Multiline = True
        txtSpecialRequests.Name = "txtSpecialRequests"
        txtSpecialRequests.ScrollBars = ScrollBars.Vertical
        txtSpecialRequests.Size = New Size(268, 46)
        txtSpecialRequests.TabIndex = 9
        ' 
        ' lblSpecialRequests
        ' 
        lblSpecialRequests.AutoSize = True
        lblSpecialRequests.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSpecialRequests.Location = New Point(18, 246)
        lblSpecialRequests.Margin = New Padding(4, 0, 4, 0)
        lblSpecialRequests.Name = "lblSpecialRequests"
        lblSpecialRequests.Size = New Size(97, 15)
        lblSpecialRequests.TabIndex = 8
        lblSpecialRequests.Text = "Special Requests:"
        ' 
        ' nudPartySize
        ' 
        nudPartySize.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        nudPartySize.Location = New Point(117, 202)
        nudPartySize.Margin = New Padding(4, 3, 4, 3)
        nudPartySize.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        nudPartySize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudPartySize.Name = "nudPartySize"
        nudPartySize.Size = New Size(70, 23)
        nudPartySize.TabIndex = 7
        nudPartySize.Value = New Decimal(New Integer() {2, 0, 0, 0})
        ' 
        ' lblPartySize
        ' 
        lblPartySize.AutoSize = True
        lblPartySize.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPartySize.Location = New Point(18, 205)
        lblPartySize.Margin = New Padding(4, 0, 4, 0)
        lblPartySize.Name = "lblPartySize"
        lblPartySize.Size = New Size(60, 15)
        lblPartySize.TabIndex = 6
        lblPartySize.Text = "Party Size:"
        ' 
        ' cmbTable
        ' 
        cmbTable.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTable.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbTable.FormattingEnabled = True
        cmbTable.Location = New Point(117, 162)
        cmbTable.Margin = New Padding(4, 3, 4, 3)
        cmbTable.Name = "cmbTable"
        cmbTable.Size = New Size(268, 23)
        cmbTable.TabIndex = 5
        ' 
        ' lblTable
        ' 
        lblTable.AutoSize = True
        lblTable.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTable.Location = New Point(18, 165)
        lblTable.Margin = New Padding(4, 0, 4, 0)
        lblTable.Name = "lblTable"
        lblTable.Size = New Size(37, 15)
        lblTable.TabIndex = 4
        lblTable.Text = "Table:"
        ' 
        ' dtpReservationDate
        ' 
        dtpReservationDate.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dtpReservationDate.Format = DateTimePickerFormat.Short
        dtpReservationDate.Location = New Point(117, 40)
        dtpReservationDate.Margin = New Padding(4, 3, 4, 3)
        dtpReservationDate.MinDate = New Date(2024, 1, 1, 0, 0, 0, 0)
        dtpReservationDate.Name = "dtpReservationDate"
        dtpReservationDate.Size = New Size(139, 23)
        dtpReservationDate.TabIndex = 1
        ' 
        ' lblReservationDate
        ' 
        lblReservationDate.AutoSize = True
        lblReservationDate.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblReservationDate.Location = New Point(18, 44)
        lblReservationDate.Margin = New Padding(4, 0, 4, 0)
        lblReservationDate.Name = "lblReservationDate"
        lblReservationDate.Size = New Size(34, 15)
        lblReservationDate.TabIndex = 0
        lblReservationDate.Text = "Date:"
        ' 
        ' dtpReservationTime
        ' 
        dtpReservationTime.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dtpReservationTime.Format = DateTimePickerFormat.Time
        dtpReservationTime.Location = New Point(117, 81)
        dtpReservationTime.Margin = New Padding(4, 3, 4, 3)
        dtpReservationTime.Name = "dtpReservationTime"
        dtpReservationTime.ShowUpDown = True
        dtpReservationTime.Size = New Size(139, 23)
        dtpReservationTime.TabIndex = 3
        ' 
        ' lblReservationTime
        ' 
        lblReservationTime.AutoSize = True
        lblReservationTime.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblReservationTime.Location = New Point(18, 84)
        lblReservationTime.Margin = New Padding(4, 0, 4, 0)
        lblReservationTime.Name = "lblReservationTime"
        lblReservationTime.Size = New Size(36, 15)
        lblReservationTime.TabIndex = 2
        lblReservationTime.Text = "Time:"
        ' 
        ' grpCalendarView
        ' 
        grpCalendarView.Controls.Add(monthCalendar)
        grpCalendarView.Controls.Add(lblSelectedDate)
        grpCalendarView.Controls.Add(dgvReservations)
        grpCalendarView.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpCalendarView.Location = New Point(443, 100)
        grpCalendarView.Margin = New Padding(4, 3, 4, 3)
        grpCalendarView.Name = "grpCalendarView"
        grpCalendarView.Padding = New Padding(4, 3, 4, 3)
        grpCalendarView.Size = New Size(583, 485)
        grpCalendarView.TabIndex = 2
        grpCalendarView.TabStop = False
        grpCalendarView.Text = "Reservation Calendar & View"
        ' 
        ' monthCalendar
        ' 
        monthCalendar.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        monthCalendar.Location = New Point(18, 29)
        monthCalendar.Margin = New Padding(10)
        monthCalendar.Name = "monthCalendar"
        monthCalendar.TabIndex = 0
        ' 
        ' lblSelectedDate
        ' 
        lblSelectedDate.AutoSize = True
        lblSelectedDate.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSelectedDate.Location = New Point(18, 242)
        lblSelectedDate.Margin = New Padding(4, 0, 4, 0)
        lblSelectedDate.Name = "lblSelectedDate"
        lblSelectedDate.Size = New Size(84, 15)
        lblSelectedDate.TabIndex = 1
        lblSelectedDate.Text = "Selected Date: "
        ' 
        ' dgvReservations
        ' 
        dgvReservations.AllowUserToAddRows = False
        dgvReservations.AllowUserToDeleteRows = False
        dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReservations.Location = New Point(18, 271)
        dgvReservations.Margin = New Padding(4, 3, 4, 3)
        dgvReservations.MultiSelect = False
        dgvReservations.Name = "dgvReservations"
        dgvReservations.ReadOnly = True
        dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReservations.Size = New Size(548, 196)
        dgvReservations.TabIndex = 2
        ' 
        ' btnNewReservation
        ' 
        btnNewReservation.BackColor = Color.LightBlue
        btnNewReservation.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewReservation.Location = New Point(14, 615)
        btnNewReservation.Margin = New Padding(4, 3, 4, 3)
        btnNewReservation.Name = "btnNewReservation"
        btnNewReservation.Size = New Size(140, 40)
        btnNewReservation.TabIndex = 3
        btnNewReservation.Text = "New Reservation"
        btnNewReservation.UseVisualStyleBackColor = False
        ' 
        ' btnSaveReservation
        ' 
        btnSaveReservation.BackColor = Color.LightGreen
        btnSaveReservation.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveReservation.Location = New Point(163, 615)
        btnSaveReservation.Margin = New Padding(4, 3, 4, 3)
        btnSaveReservation.Name = "btnSaveReservation"
        btnSaveReservation.Size = New Size(140, 40)
        btnSaveReservation.TabIndex = 4
        btnSaveReservation.Text = "Save Reservation"
        btnSaveReservation.UseVisualStyleBackColor = False
        ' 
        ' btnCancelReservation
        ' 
        btnCancelReservation.BackColor = Color.LightCoral
        btnCancelReservation.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancelReservation.Location = New Point(313, 615)
        btnCancelReservation.Margin = New Padding(4, 3, 4, 3)
        btnCancelReservation.Name = "btnCancelReservation"
        btnCancelReservation.Size = New Size(140, 40)
        btnCancelReservation.TabIndex = 5
        btnCancelReservation.Text = "Cancel"
        btnCancelReservation.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteReservation
        ' 
        btnDeleteReservation.BackColor = Color.Salmon
        btnDeleteReservation.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDeleteReservation.Location = New Point(163, 665)
        btnDeleteReservation.Margin = New Padding(4, 3, 4, 3)
        btnDeleteReservation.Name = "btnDeleteReservation"
        btnDeleteReservation.Size = New Size(140, 40)
        btnDeleteReservation.TabIndex = 7
        btnDeleteReservation.Text = "Delete Reservation"
        btnDeleteReservation.UseVisualStyleBackColor = False
        ' 
        ' btnEditReservation
        ' 
        btnEditReservation.BackColor = Color.LightYellow
        btnEditReservation.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEditReservation.Location = New Point(14, 665)
        btnEditReservation.Margin = New Padding(4, 3, 4, 3)
        btnEditReservation.Name = "btnEditReservation"
        btnEditReservation.Size = New Size(140, 40)
        btnEditReservation.TabIndex = 6
        btnEditReservation.Text = "Edit Reservation"
        btnEditReservation.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(32, 33)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 30)
        Button1.TabIndex = 10
        Button1.Text = "Back"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ReservationFrm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1050, 750)
        Controls.Add(pnlHeader)
        Controls.Add(btnDeleteReservation)
        Controls.Add(btnEditReservation)
        Controls.Add(btnCancelReservation)
        Controls.Add(btnSaveReservation)
        Controls.Add(btnNewReservation)
        Controls.Add(grpCalendarView)
        Controls.Add(grpReservationDetails)
        Controls.Add(grpCustomerDetails)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        Name = "ReservationFrm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GrillMate - Reservation Management"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        grpCustomerDetails.ResumeLayout(False)
        grpCustomerDetails.PerformLayout()
        grpReservationDetails.ResumeLayout(False)
        grpReservationDetails.PerformLayout()
        CType(nudPartySize, ComponentModel.ISupportInitialize).EndInit()
        grpCalendarView.ResumeLayout(False)
        grpCalendarView.PerformLayout()
        CType(dgvReservations, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents grpCustomerDetails As GroupBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents lblCustomerName As Label
    Friend WithEvents grpReservationDetails As GroupBox
    Friend WithEvents txtSpecialRequests As TextBox
    Friend WithEvents lblSpecialRequests As Label
    Friend WithEvents nudPartySize As NumericUpDown
    Friend WithEvents lblPartySize As Label
    Friend WithEvents cmbTable As ComboBox
    Friend WithEvents lblTable As Label
    Friend WithEvents dtpReservationDate As DateTimePicker
    Friend WithEvents lblReservationDate As Label
    Friend WithEvents dtpReservationTime As DateTimePicker
    Friend WithEvents lblReservationTime As Label
    Friend WithEvents grpCalendarView As GroupBox
    Friend WithEvents monthCalendar As MonthCalendar
    Friend WithEvents lblSelectedDate As Label
    Friend WithEvents dgvReservations As DataGridView
    Friend WithEvents btnNewReservation As Button
    Friend WithEvents btnSaveReservation As Button
    Friend WithEvents btnCancelReservation As Button
    Friend WithEvents btnDeleteReservation As Button
    Friend WithEvents btnEditReservation As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents Button1 As Button
End Class

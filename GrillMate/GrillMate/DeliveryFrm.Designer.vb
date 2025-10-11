<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeliveryFrm
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
        grpCustomerInfo = New GroupBox()
        txtSpecialInstructions = New TextBox()
        lblSpecialInstructions = New Label()
        txtPostalCode = New TextBox()
        lblPostalCode = New Label()
        txtCity = New TextBox()
        lblCity = New Label()
        txtAddress = New TextBox()
        lblAddress = New Label()
        txtCustomerEmail = New TextBox()
        lblCustomerEmail = New Label()
        txtCustomerPhone = New TextBox()
        lblCustomerPhone = New Label()
        txtCustomerName = New TextBox()
        lblCustomerName = New Label()
        grpDeliveryDetails = New GroupBox()
        dtpDeliveryDate = New DateTimePicker()
        lblDeliveryDate = New Label()
        dtpDeliveryTime = New DateTimePicker()
        lblDeliveryTime = New Label()
        cmbDriver = New ComboBox()
        lblDriver = New Label()
        nudDeliveryFee = New NumericUpDown()
        lblDeliveryFee = New Label()
        txtNotes = New TextBox()
        lblNotes = New Label()
        grpOrderSummary = New GroupBox()
        dgvOrderItems = New DataGridView()
        lblOrderTotal = New Label()
        grpDeliveryManagement = New GroupBox()
        dgvDeliveries = New DataGridView()
        btnRefreshDeliveries = New Button()
        btnUpdateStatus = New Button()
        btnNewDelivery = New Button()
        btnSaveDelivery = New Button()
        btnCancelDelivery = New Button()
        btnDeleteDelivery = New Button()
        btnEditDelivery = New Button()
        lblTitle = New Label()
        ToolTip1 = New ToolTip(components)
        grpCustomerInfo.SuspendLayout()
        grpDeliveryDetails.SuspendLayout()
        CType(nudDeliveryFee, ComponentModel.ISupportInitialize).BeginInit()
        grpOrderSummary.SuspendLayout()
        CType(dgvOrderItems, ComponentModel.ISupportInitialize).BeginInit()
        grpDeliveryManagement.SuspendLayout()
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).BeginInit()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.DarkGray
        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Controls.Add(btnBack)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1260, 80)
        pnlHeader.TabIndex = 12
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.Black
        lblTitle.Location = New Point(500, 18)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(302, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Delivery Management"
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.LightGray
        btnBack.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBack.Location = New Point(20, 25)
        btnBack.Margin = New Padding(4, 3, 4, 3)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(117, 40)
        btnBack.TabIndex = 1
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.IndianRed
        btnLogout.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogout.Location = New Point(1130, 25)
        btnLogout.Margin = New Padding(4, 3, 4, 3)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(117, 40)
        btnLogout.TabIndex = 2
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' grpCustomerInfo
        ' 
        grpCustomerInfo.Controls.Add(txtSpecialInstructions)
        grpCustomerInfo.Controls.Add(lblSpecialInstructions)
        grpCustomerInfo.Controls.Add(txtPostalCode)
        grpCustomerInfo.Controls.Add(lblPostalCode)
        grpCustomerInfo.Controls.Add(txtCity)
        grpCustomerInfo.Controls.Add(lblCity)
        grpCustomerInfo.Controls.Add(txtAddress)
        grpCustomerInfo.Controls.Add(lblAddress)
        grpCustomerInfo.Controls.Add(txtCustomerEmail)
        grpCustomerInfo.Controls.Add(lblCustomerEmail)
        grpCustomerInfo.Controls.Add(txtCustomerPhone)
        grpCustomerInfo.Controls.Add(lblCustomerPhone)
        grpCustomerInfo.Controls.Add(txtCustomerName)
        grpCustomerInfo.Controls.Add(lblCustomerName)
        grpCustomerInfo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpCustomerInfo.Location = New Point(14, 100)
        grpCustomerInfo.Margin = New Padding(4, 3, 4, 3)
        grpCustomerInfo.Name = "grpCustomerInfo"
        grpCustomerInfo.Padding = New Padding(4, 3, 4, 3)
        grpCustomerInfo.Size = New Size(400, 320)
        grpCustomerInfo.TabIndex = 0
        grpCustomerInfo.TabStop = False
        grpCustomerInfo.Text = "Customer Information"
        ' 
        ' txtSpecialInstructions
        ' 
        txtSpecialInstructions.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSpecialInstructions.Location = New Point(117, 275)
        txtSpecialInstructions.Margin = New Padding(4, 3, 4, 3)
        txtSpecialInstructions.Multiline = True
        txtSpecialInstructions.Name = "txtSpecialInstructions"
        txtSpecialInstructions.ScrollBars = ScrollBars.Vertical
        txtSpecialInstructions.Size = New Size(268, 40)
        txtSpecialInstructions.TabIndex = 13
        ' 
        ' lblSpecialInstructions
        ' 
        lblSpecialInstructions.AutoSize = True
        lblSpecialInstructions.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSpecialInstructions.Location = New Point(18, 278)
        lblSpecialInstructions.Margin = New Padding(4, 0, 4, 0)
        lblSpecialInstructions.Name = "lblSpecialInstructions"
        lblSpecialInstructions.Size = New Size(122, 15)
        lblSpecialInstructions.TabIndex = 12
        lblSpecialInstructions.Text = "Special Instructions:"
        ' 
        ' txtPostalCode
        ' 
        txtPostalCode.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPostalCode.Location = New Point(117, 235)
        txtPostalCode.Margin = New Padding(4, 3, 4, 3)
        txtPostalCode.Name = "txtPostalCode"
        txtPostalCode.Size = New Size(120, 23)
        txtPostalCode.TabIndex = 11
        ' 
        ' lblPostalCode
        ' 
        lblPostalCode.AutoSize = True
        lblPostalCode.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPostalCode.Location = New Point(18, 238)
        lblPostalCode.Margin = New Padding(4, 0, 4, 0)
        lblPostalCode.Name = "lblPostalCode"
        lblPostalCode.Size = New Size(78, 15)
        lblPostalCode.TabIndex = 10
        lblPostalCode.Text = "Postal Code:"
        ' 
        ' txtCity
        ' 
        txtCity.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCity.Location = New Point(117, 195)
        txtCity.Margin = New Padding(4, 3, 4, 3)
        txtCity.Name = "txtCity"
        txtCity.Size = New Size(268, 23)
        txtCity.TabIndex = 9
        ' 
        ' lblCity
        ' 
        lblCity.AutoSize = True
        lblCity.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCity.Location = New Point(18, 198)
        lblCity.Margin = New Padding(4, 0, 4, 0)
        lblCity.Name = "lblCity"
        lblCity.Size = New Size(31, 15)
        lblCity.TabIndex = 8
        lblCity.Text = "City:"
        ' 
        ' txtAddress
        ' 
        txtAddress.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAddress.Location = New Point(117, 155)
        txtAddress.Margin = New Padding(4, 3, 4, 3)
        txtAddress.Multiline = True
        txtAddress.Name = "txtAddress"
        txtAddress.ScrollBars = ScrollBars.Vertical
        txtAddress.Size = New Size(268, 30)
        txtAddress.TabIndex = 7
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        lblAddress.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAddress.Location = New Point(18, 158)
        lblAddress.Margin = New Padding(4, 0, 4, 0)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(52, 15)
        lblAddress.TabIndex = 6
        lblAddress.Text = "Address:"
        ' 
        ' txtCustomerEmail
        ' 
        txtCustomerEmail.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCustomerEmail.Location = New Point(117, 115)
        txtCustomerEmail.Margin = New Padding(4, 3, 4, 3)
        txtCustomerEmail.Name = "txtCustomerEmail"
        txtCustomerEmail.Size = New Size(268, 23)
        txtCustomerEmail.TabIndex = 5
        ' 
        ' lblCustomerEmail
        ' 
        lblCustomerEmail.AutoSize = True
        lblCustomerEmail.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCustomerEmail.Location = New Point(18, 118)
        lblCustomerEmail.Margin = New Padding(4, 0, 4, 0)
        lblCustomerEmail.Name = "lblCustomerEmail"
        lblCustomerEmail.Size = New Size(39, 15)
        lblCustomerEmail.TabIndex = 4
        lblCustomerEmail.Text = "Email:"
        ' 
        ' txtCustomerPhone
        ' 
        txtCustomerPhone.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCustomerPhone.Location = New Point(117, 75)
        txtCustomerPhone.Margin = New Padding(4, 3, 4, 3)
        txtCustomerPhone.Name = "txtCustomerPhone"
        txtCustomerPhone.Size = New Size(268, 23)
        txtCustomerPhone.TabIndex = 3
        ' 
        ' lblCustomerPhone
        ' 
        lblCustomerPhone.AutoSize = True
        lblCustomerPhone.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCustomerPhone.Location = New Point(18, 78)
        lblCustomerPhone.Margin = New Padding(4, 0, 4, 0)
        lblCustomerPhone.Name = "lblCustomerPhone"
        lblCustomerPhone.Size = New Size(44, 15)
        lblCustomerPhone.TabIndex = 2
        lblCustomerPhone.Text = "Phone:"
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
        ' grpDeliveryDetails
        ' 
        grpDeliveryDetails.Controls.Add(dtpDeliveryDate)
        grpDeliveryDetails.Controls.Add(lblDeliveryDate)
        grpDeliveryDetails.Controls.Add(dtpDeliveryTime)
        grpDeliveryDetails.Controls.Add(lblDeliveryTime)
        grpDeliveryDetails.Controls.Add(cmbDriver)
        grpDeliveryDetails.Controls.Add(lblDriver)
        grpDeliveryDetails.Controls.Add(nudDeliveryFee)
        grpDeliveryDetails.Controls.Add(lblDeliveryFee)
        grpDeliveryDetails.Controls.Add(txtNotes)
        grpDeliveryDetails.Controls.Add(lblNotes)
        grpDeliveryDetails.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpDeliveryDetails.Location = New Point(430, 100)
        grpDeliveryDetails.Margin = New Padding(4, 3, 4, 3)
        grpDeliveryDetails.Name = "grpDeliveryDetails"
        grpDeliveryDetails.Padding = New Padding(4, 3, 4, 3)
        grpDeliveryDetails.Size = New Size(400, 320)
        grpDeliveryDetails.TabIndex = 1
        grpDeliveryDetails.TabStop = False
        grpDeliveryDetails.Text = "Delivery Details"
        ' 
        ' dtpDeliveryDate
        ' 
        dtpDeliveryDate.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dtpDeliveryDate.Format = DateTimePickerFormat.Short
        dtpDeliveryDate.Location = New Point(117, 40)
        dtpDeliveryDate.Margin = New Padding(4, 3, 4, 3)
        dtpDeliveryDate.MinDate = New Date(2024, 1, 1, 0, 0, 0, 0)
        dtpDeliveryDate.Name = "dtpDeliveryDate"
        dtpDeliveryDate.Size = New Size(139, 23)
        dtpDeliveryDate.TabIndex = 1
        ' 
        ' lblDeliveryDate
        ' 
        lblDeliveryDate.AutoSize = True
        lblDeliveryDate.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDeliveryDate.Location = New Point(18, 44)
        lblDeliveryDate.Margin = New Padding(4, 0, 4, 0)
        lblDeliveryDate.Name = "lblDeliveryDate"
        lblDeliveryDate.Size = New Size(34, 15)
        lblDeliveryDate.TabIndex = 0
        lblDeliveryDate.Text = "Date:"
        ' 
        ' dtpDeliveryTime
        ' 
        dtpDeliveryTime.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dtpDeliveryTime.Format = DateTimePickerFormat.Time
        dtpDeliveryTime.Location = New Point(117, 81)
        dtpDeliveryTime.Margin = New Padding(4, 3, 4, 3)
        dtpDeliveryTime.Name = "dtpDeliveryTime"
        dtpDeliveryTime.ShowUpDown = True
        dtpDeliveryTime.Size = New Size(139, 23)
        dtpDeliveryTime.TabIndex = 3
        ' 
        ' lblDeliveryTime
        ' 
        lblDeliveryTime.AutoSize = True
        lblDeliveryTime.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDeliveryTime.Location = New Point(18, 84)
        lblDeliveryTime.Margin = New Padding(4, 0, 4, 0)
        lblDeliveryTime.Name = "lblDeliveryTime"
        lblDeliveryTime.Size = New Size(36, 15)
        lblDeliveryTime.TabIndex = 2
        lblDeliveryTime.Text = "Time:"
        ' 
        ' cmbDriver
        ' 
        cmbDriver.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDriver.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbDriver.FormattingEnabled = True
        cmbDriver.Location = New Point(117, 122)
        cmbDriver.Margin = New Padding(4, 3, 4, 3)
        cmbDriver.Name = "cmbDriver"
        cmbDriver.Size = New Size(268, 23)
        cmbDriver.TabIndex = 5
        ' 
        ' lblDriver
        ' 
        lblDriver.AutoSize = True
        lblDriver.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDriver.Location = New Point(18, 125)
        lblDriver.Margin = New Padding(4, 0, 4, 0)
        lblDriver.Name = "lblDriver"
        lblDriver.Size = New Size(43, 15)
        lblDriver.TabIndex = 4
        lblDriver.Text = "Driver:"
        ' 
        ' nudDeliveryFee
        ' 
        nudDeliveryFee.DecimalPlaces = 2
        nudDeliveryFee.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        nudDeliveryFee.Location = New Point(117, 162)
        nudDeliveryFee.Margin = New Padding(4, 3, 4, 3)
        nudDeliveryFee.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        nudDeliveryFee.Name = "nudDeliveryFee"
        nudDeliveryFee.Size = New Size(120, 23)
        nudDeliveryFee.TabIndex = 7
        ' 
        ' lblDeliveryFee
        ' 
        lblDeliveryFee.AutoSize = True
        lblDeliveryFee.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDeliveryFee.Location = New Point(18, 165)
        lblDeliveryFee.Margin = New Padding(4, 0, 4, 0)
        lblDeliveryFee.Name = "lblDeliveryFee"
        lblDeliveryFee.Size = New Size(77, 15)
        lblDeliveryFee.TabIndex = 6
        lblDeliveryFee.Text = "Delivery Fee:"
        ' 
        ' txtNotes
        ' 
        txtNotes.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNotes.Location = New Point(117, 202)
        txtNotes.Margin = New Padding(4, 3, 4, 3)
        txtNotes.Multiline = True
        txtNotes.Name = "txtNotes"
        txtNotes.ScrollBars = ScrollBars.Vertical
        txtNotes.Size = New Size(268, 100)
        txtNotes.TabIndex = 9
        ' 
        ' lblNotes
        ' 
        lblNotes.AutoSize = True
        lblNotes.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNotes.Location = New Point(18, 205)
        lblNotes.Margin = New Padding(4, 0, 4, 0)
        lblNotes.Name = "lblNotes"
        lblNotes.Size = New Size(40, 15)
        lblNotes.TabIndex = 8
        lblNotes.Text = "Notes:"
        ' 
        ' grpOrderSummary
        ' 
        grpOrderSummary.Controls.Add(dgvOrderItems)
        grpOrderSummary.Controls.Add(lblOrderTotal)
        grpOrderSummary.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpOrderSummary.Location = New Point(846, 100)
        grpOrderSummary.Margin = New Padding(4, 3, 4, 3)
        grpOrderSummary.Name = "grpOrderSummary"
        grpOrderSummary.Padding = New Padding(4, 3, 4, 3)
        grpOrderSummary.Size = New Size(400, 320)
        grpOrderSummary.TabIndex = 2
        grpOrderSummary.TabStop = False
        grpOrderSummary.Text = "Order Summary"
        ' 
        ' dgvOrderItems
        ' 
        dgvOrderItems.AllowUserToAddRows = False
        dgvOrderItems.AllowUserToDeleteRows = False
        dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrderItems.Location = New Point(18, 29)
        dgvOrderItems.Margin = New Padding(4, 3, 4, 3)
        dgvOrderItems.MultiSelect = False
        dgvOrderItems.Name = "dgvOrderItems"
        dgvOrderItems.ReadOnly = True
        dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrderItems.Size = New Size(365, 250)
        dgvOrderItems.TabIndex = 1
        ' 
        ' lblOrderTotal
        ' 
        lblOrderTotal.AutoSize = True
        lblOrderTotal.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderTotal.ForeColor = Color.DarkBlue
        lblOrderTotal.Location = New Point(18, 285)
        lblOrderTotal.Margin = New Padding(4, 0, 4, 0)
        lblOrderTotal.Name = "lblOrderTotal"
        lblOrderTotal.Size = New Size(100, 21)
        lblOrderTotal.TabIndex = 0
        lblOrderTotal.Text = "Order Total:"
        ' 
        ' grpDeliveryManagement
        ' 
        grpDeliveryManagement.Controls.Add(dgvDeliveries)
        grpDeliveryManagement.Controls.Add(btnRefreshDeliveries)
        grpDeliveryManagement.Controls.Add(btnUpdateStatus)
        grpDeliveryManagement.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpDeliveryManagement.Location = New Point(14, 435)
        grpDeliveryManagement.Margin = New Padding(4, 3, 4, 3)
        grpDeliveryManagement.Name = "grpDeliveryManagement"
        grpDeliveryManagement.Padding = New Padding(4, 3, 4, 3)
        grpDeliveryManagement.Size = New Size(1232, 280)
        grpDeliveryManagement.TabIndex = 3
        grpDeliveryManagement.TabStop = False
        grpDeliveryManagement.Text = "Delivery Management"
        ' 
        ' dgvDeliveries
        ' 
        dgvDeliveries.AllowUserToAddRows = False
        dgvDeliveries.AllowUserToDeleteRows = False
        dgvDeliveries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDeliveries.Location = New Point(18, 29)
        dgvDeliveries.Margin = New Padding(4, 3, 4, 3)
        dgvDeliveries.MultiSelect = False
        dgvDeliveries.Name = "dgvDeliveries"
        dgvDeliveries.ReadOnly = True
        dgvDeliveries.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDeliveries.Size = New Size(1190, 200)
        dgvDeliveries.TabIndex = 2
        ' 
        ' btnRefreshDeliveries
        ' 
        btnRefreshDeliveries.BackColor = Color.LightBlue
        btnRefreshDeliveries.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRefreshDeliveries.Location = New Point(18, 235)
        btnRefreshDeliveries.Margin = New Padding(4, 3, 4, 3)
        btnRefreshDeliveries.Name = "btnRefreshDeliveries"
        btnRefreshDeliveries.Size = New Size(120, 35)
        btnRefreshDeliveries.TabIndex = 1
        btnRefreshDeliveries.Text = "Refresh"
        btnRefreshDeliveries.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateStatus
        ' 
        btnUpdateStatus.BackColor = Color.LightGreen
        btnUpdateStatus.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpdateStatus.Location = New Point(146, 235)
        btnUpdateStatus.Margin = New Padding(4, 3, 4, 3)
        btnUpdateStatus.Name = "btnUpdateStatus"
        btnUpdateStatus.Size = New Size(120, 35)
        btnUpdateStatus.TabIndex = 0
        btnUpdateStatus.Text = "Update Status"
        btnUpdateStatus.UseVisualStyleBackColor = False
        ' 
        ' btnNewDelivery
        ' 
        btnNewDelivery.BackColor = Color.LightBlue
        btnNewDelivery.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewDelivery.Location = New Point(14, 735)
        btnNewDelivery.Margin = New Padding(4, 3, 4, 3)
        btnNewDelivery.Name = "btnNewDelivery"
        btnNewDelivery.Size = New Size(140, 40)
        btnNewDelivery.TabIndex = 4
        btnNewDelivery.Text = "New Delivery"
        btnNewDelivery.UseVisualStyleBackColor = False
        ' 
        ' btnSaveDelivery
        ' 
        btnSaveDelivery.BackColor = Color.LightGreen
        btnSaveDelivery.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveDelivery.Location = New Point(163, 735)
        btnSaveDelivery.Margin = New Padding(4, 3, 4, 3)
        btnSaveDelivery.Name = "btnSaveDelivery"
        btnSaveDelivery.Size = New Size(140, 40)
        btnSaveDelivery.TabIndex = 5
        btnSaveDelivery.Text = "Save Delivery"
        btnSaveDelivery.UseVisualStyleBackColor = False
        ' 
        ' btnCancelDelivery
        ' 
        btnCancelDelivery.BackColor = Color.LightCoral
        btnCancelDelivery.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancelDelivery.Location = New Point(313, 735)
        btnCancelDelivery.Margin = New Padding(4, 3, 4, 3)
        btnCancelDelivery.Name = "btnCancelDelivery"
        btnCancelDelivery.Size = New Size(140, 40)
        btnCancelDelivery.TabIndex = 6
        btnCancelDelivery.Text = "Cancel"
        btnCancelDelivery.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteDelivery
        ' 
        btnDeleteDelivery.BackColor = Color.Salmon
        btnDeleteDelivery.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDeleteDelivery.Location = New Point(163, 785)
        btnDeleteDelivery.Margin = New Padding(4, 3, 4, 3)
        btnDeleteDelivery.Name = "btnDeleteDelivery"
        btnDeleteDelivery.Size = New Size(140, 40)
        btnDeleteDelivery.TabIndex = 8
        btnDeleteDelivery.Text = "Delete Delivery"
        btnDeleteDelivery.UseVisualStyleBackColor = False
        ' 
        ' btnEditDelivery
        ' 
        btnEditDelivery.BackColor = Color.LightYellow
        btnEditDelivery.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEditDelivery.Location = New Point(14, 785)
        btnEditDelivery.Margin = New Padding(4, 3, 4, 3)
        btnEditDelivery.Name = "btnEditDelivery"
        btnEditDelivery.Size = New Size(140, 40)
        btnEditDelivery.TabIndex = 7
        btnEditDelivery.Text = "Edit Delivery"
        btnEditDelivery.UseVisualStyleBackColor = False
        ' 
        ' 
        ' DeliveryFrm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1260, 880)
        Controls.Add(pnlHeader)
        Controls.Add(btnDeleteDelivery)
        Controls.Add(btnEditDelivery)
        Controls.Add(btnCancelDelivery)
        Controls.Add(btnSaveDelivery)
        Controls.Add(btnNewDelivery)
        Controls.Add(grpDeliveryManagement)
        Controls.Add(grpOrderSummary)
        Controls.Add(grpDeliveryDetails)
        Controls.Add(grpCustomerInfo)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        Name = "DeliveryFrm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GrillMate - Delivery Management"
        grpCustomerInfo.ResumeLayout(False)
        grpCustomerInfo.PerformLayout()
        grpDeliveryDetails.ResumeLayout(False)
        grpDeliveryDetails.PerformLayout()
        CType(nudDeliveryFee, ComponentModel.ISupportInitialize).EndInit()
        grpOrderSummary.ResumeLayout(False)
        grpOrderSummary.PerformLayout()
        CType(dgvOrderItems, ComponentModel.ISupportInitialize).EndInit()
        grpDeliveryManagement.ResumeLayout(False)
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).EndInit()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents grpCustomerInfo As GroupBox
    Friend WithEvents txtSpecialInstructions As TextBox
    Friend WithEvents lblSpecialInstructions As Label
    Friend WithEvents txtPostalCode As TextBox
    Friend WithEvents lblPostalCode As Label
    Friend WithEvents txtCity As TextBox
    Friend WithEvents lblCity As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtCustomerEmail As TextBox
    Friend WithEvents lblCustomerEmail As Label
    Friend WithEvents txtCustomerPhone As TextBox
    Friend WithEvents lblCustomerPhone As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents lblCustomerName As Label
    Friend WithEvents grpDeliveryDetails As GroupBox
    Friend WithEvents dtpDeliveryDate As DateTimePicker
    Friend WithEvents lblDeliveryDate As Label
    Friend WithEvents dtpDeliveryTime As DateTimePicker
    Friend WithEvents lblDeliveryTime As Label
    Friend WithEvents cmbDriver As ComboBox
    Friend WithEvents lblDriver As Label
    Friend WithEvents nudDeliveryFee As NumericUpDown
    Friend WithEvents lblDeliveryFee As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents grpOrderSummary As GroupBox
    Friend WithEvents dgvOrderItems As DataGridView
    Friend WithEvents lblOrderTotal As Label
    Friend WithEvents grpDeliveryManagement As GroupBox
    Friend WithEvents dgvDeliveries As DataGridView
    Friend WithEvents btnRefreshDeliveries As Button
    Friend WithEvents btnUpdateStatus As Button
    Friend WithEvents btnNewDelivery As Button
    Friend WithEvents btnSaveDelivery As Button
    Friend WithEvents btnCancelDelivery As Button
    Friend WithEvents btnDeleteDelivery As Button
    Friend WithEvents btnEditDelivery As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
End Class

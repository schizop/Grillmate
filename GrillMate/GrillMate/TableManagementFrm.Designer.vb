<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TableManagementFrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        pnlHeader = New Panel()
        lblTitle = New Label()
        btnBack = New Button()
        btnLogout = New Button()
        pnlMain = New Panel()
        dgvTables = New DataGridView()
        pnlControls = New Panel()
        btnAddTable = New Button()
        btnEditTable = New Button()
        btnDeleteTable = New Button()
        btnRefresh = New Button()
        pnlStatus = New Panel()
        lblStatusInfo = New Label()
        btnSetVacant = New Button()
        btnSetOccupied = New Button()
        btnSetReserved = New Button()
        pnlTableInfo = New Panel()
        lblTableName = New Label()
        txtTableName = New TextBox()
        btnSaveTable = New Button()
        btnCancelEdit = New Button()
        CType(dgvTables, ComponentModel.ISupportInitialize).BeginInit()
        pnlHeader.SuspendLayout()
        pnlMain.SuspendLayout()
        pnlControls.SuspendLayout()
        pnlStatus.SuspendLayout()
        pnlTableInfo.SuspendLayout()
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
        pnlHeader.Size = New Size(1200, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblTitle.Location = New Point(480, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(240, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Table Management"
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(20, 25)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(75, 30)
        btnBack.TabIndex = 1
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.IndianRed
        btnLogout.Location = New Point(1100, 25)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(80, 30)
        btnLogout.TabIndex = 2
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' pnlMain
        ' 
        pnlMain.Controls.Add(pnlTableInfo)
        pnlMain.Controls.Add(pnlStatus)
        pnlMain.Controls.Add(pnlControls)
        pnlMain.Controls.Add(dgvTables)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 80)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(1200, 620)
        pnlMain.TabIndex = 1
        ' 
        ' dgvTables
        ' 
        dgvTables.AllowUserToAddRows = False
        dgvTables.AllowUserToDeleteRows = False
        dgvTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTables.Location = New Point(20, 20)
        dgvTables.Name = "dgvTables"
        dgvTables.ReadOnly = True
        dgvTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTables.Size = New Size(600, 580)
        dgvTables.TabIndex = 0
        ' 
        ' pnlControls
        ' 
        pnlControls.Controls.Add(btnCancelEdit)
        pnlControls.Controls.Add(btnSaveTable)
        pnlControls.Controls.Add(btnRefresh)
        pnlControls.Controls.Add(btnDeleteTable)
        pnlControls.Controls.Add(btnEditTable)
        pnlControls.Controls.Add(btnAddTable)
        pnlControls.Location = New Point(640, 20)
        pnlControls.Name = "pnlControls"
        pnlControls.Size = New Size(540, 120)
        pnlControls.TabIndex = 1
        ' 
        ' btnAddTable
        ' 
        btnAddTable.BackColor = Color.LightGreen
        btnAddTable.Location = New Point(20, 20)
        btnAddTable.Name = "btnAddTable"
        btnAddTable.Size = New Size(100, 35)
        btnAddTable.TabIndex = 0
        btnAddTable.Text = "Add Table"
        btnAddTable.UseVisualStyleBackColor = False
        ' 
        ' btnEditTable
        ' 
        btnEditTable.BackColor = Color.LightBlue
        btnEditTable.Location = New Point(140, 20)
        btnEditTable.Name = "btnEditTable"
        btnEditTable.Size = New Size(100, 35)
        btnEditTable.TabIndex = 1
        btnEditTable.Text = "Edit Table"
        btnEditTable.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteTable
        ' 
        btnDeleteTable.BackColor = Color.LightCoral
        btnDeleteTable.Location = New Point(260, 20)
        btnDeleteTable.Name = "btnDeleteTable"
        btnDeleteTable.Size = New Size(100, 35)
        btnDeleteTable.TabIndex = 2
        btnDeleteTable.Text = "Delete Table"
        btnDeleteTable.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(380, 20)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 35)
        btnRefresh.TabIndex = 3
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnSaveTable
        ' 
        btnSaveTable.BackColor = Color.LightGreen
        btnSaveTable.Enabled = False
        btnSaveTable.Location = New Point(20, 70)
        btnSaveTable.Name = "btnSaveTable"
        btnSaveTable.Size = New Size(100, 35)
        btnSaveTable.TabIndex = 4
        btnSaveTable.Text = "Save Changes"
        btnSaveTable.UseVisualStyleBackColor = False
        ' 
        ' btnCancelEdit
        ' 
        btnCancelEdit.BackColor = Color.LightGray
        btnCancelEdit.Enabled = False
        btnCancelEdit.Location = New Point(140, 70)
        btnCancelEdit.Name = "btnCancelEdit"
        btnCancelEdit.Size = New Size(100, 35)
        btnCancelEdit.TabIndex = 5
        btnCancelEdit.Text = "Cancel"
        btnCancelEdit.UseVisualStyleBackColor = False
        ' 
        ' pnlStatus
        ' 
        pnlStatus.BorderStyle = BorderStyle.FixedSingle
        pnlStatus.Controls.Add(btnSetReserved)
        pnlStatus.Controls.Add(btnSetOccupied)
        pnlStatus.Controls.Add(btnSetVacant)
        pnlStatus.Controls.Add(lblStatusInfo)
        pnlStatus.Location = New Point(640, 160)
        pnlStatus.Name = "pnlStatus"
        pnlStatus.Size = New Size(540, 120)
        pnlStatus.TabIndex = 2
        ' 
        ' lblStatusInfo
        ' 
        lblStatusInfo.AutoSize = True
        lblStatusInfo.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblStatusInfo.Location = New Point(20, 15)
        lblStatusInfo.Name = "lblStatusInfo"
        lblStatusInfo.Size = New Size(160, 21)
        lblStatusInfo.TabIndex = 0
        lblStatusInfo.Text = "Change Table Status:"
        ' 
        ' btnSetVacant
        ' 
        btnSetVacant.BackColor = Color.LightGreen
        btnSetVacant.Enabled = False
        btnSetVacant.Location = New Point(20, 45)
        btnSetVacant.Name = "btnSetVacant"
        btnSetVacant.Size = New Size(120, 35)
        btnSetVacant.TabIndex = 1
        btnSetVacant.Text = "Set Vacant"
        btnSetVacant.UseVisualStyleBackColor = False
        ' 
        ' btnSetOccupied
        ' 
        btnSetOccupied.BackColor = Color.Orange
        btnSetOccupied.Enabled = False
        btnSetOccupied.Location = New Point(160, 45)
        btnSetOccupied.Name = "btnSetOccupied"
        btnSetOccupied.Size = New Size(120, 35)
        btnSetOccupied.TabIndex = 2
        btnSetOccupied.Text = "Set Occupied"
        btnSetOccupied.UseVisualStyleBackColor = False
        ' 
        ' btnSetReserved
        ' 
        btnSetReserved.BackColor = Color.LightCoral
        btnSetReserved.Enabled = False
        btnSetReserved.Location = New Point(300, 45)
        btnSetReserved.Name = "btnSetReserved"
        btnSetReserved.Size = New Size(120, 35)
        btnSetReserved.TabIndex = 3
        btnSetReserved.Text = "Set Reserved"
        btnSetReserved.UseVisualStyleBackColor = False
        ' 
        ' pnlTableInfo
        ' 
        pnlTableInfo.BorderStyle = BorderStyle.FixedSingle
        pnlTableInfo.Controls.Add(txtTableName)
        pnlTableInfo.Controls.Add(lblTableName)
        pnlTableInfo.Location = New Point(640, 300)
        pnlTableInfo.Name = "pnlTableInfo"
        pnlTableInfo.Size = New Size(540, 120)
        pnlTableInfo.TabIndex = 3
        ' 
        ' lblTableName
        ' 
        lblTableName.AutoSize = True
        lblTableName.Location = New Point(20, 30)
        lblTableName.Name = "lblTableName"
        lblTableName.Size = New Size(76, 15)
        lblTableName.TabIndex = 0
        lblTableName.Text = "Table Name:"
        ' 
        ' txtTableName
        ' 
        txtTableName.Enabled = False
        txtTableName.Location = New Point(120, 27)
        txtTableName.Name = "txtTableName"
        txtTableName.Size = New Size(200, 23)
        txtTableName.TabIndex = 1
        ' 
        ' TableManagementFrm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 700)
        Controls.Add(pnlMain)
        Controls.Add(pnlHeader)
        Name = "TableManagementFrm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Table Management - GrillMate"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(dgvTables, ComponentModel.ISupportInitialize).EndInit()
        pnlMain.ResumeLayout(False)
        pnlControls.ResumeLayout(False)
        pnlStatus.ResumeLayout(False)
        pnlStatus.PerformLayout()
        pnlTableInfo.ResumeLayout(False)
        pnlTableInfo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlMain As Panel
    Friend WithEvents dgvTables As DataGridView
    Friend WithEvents pnlControls As Panel
    Friend WithEvents btnAddTable As Button
    Friend WithEvents btnEditTable As Button
    Friend WithEvents btnDeleteTable As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnSaveTable As Button
    Friend WithEvents btnCancelEdit As Button
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents lblStatusInfo As Label
    Friend WithEvents btnSetVacant As Button
    Friend WithEvents btnSetOccupied As Button
    Friend WithEvents btnSetReserved As Button
    Friend WithEvents pnlTableInfo As Panel
    Friend WithEvents lblTableName As Label
    Friend WithEvents txtTableName As TextBox
End Class
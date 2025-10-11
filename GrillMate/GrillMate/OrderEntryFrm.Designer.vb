<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OrderEntryFrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        pnlHeaderLine = New Panel()
        Backbtn = New Button()
        Logout = New Button()
        lblDashboard = New Label()
        DataGridView1 = New DataGridView()
        flpMenu = New FlowLayoutPanel()
        Label1 = New Label()
        Label2 = New Label()
        flpTables = New FlowLayoutPanel()
        lblTotal = New Label()
        btnSubmit = New Button()
        dgvOrder = New DataGridView()
        flpCategory = New FlowLayoutPanel()
        btnEditMenu = New Button()
        cmbPaymentMethod = New ComboBox()
        btnDelivery = New Button()
        pnlHeaderLine.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvOrder, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeaderLine
        ' 
        pnlHeaderLine.BackColor = Color.DarkGray
        pnlHeaderLine.Controls.Add(Backbtn)
        pnlHeaderLine.Controls.Add(Logout)
        pnlHeaderLine.Controls.Add(lblDashboard)
        pnlHeaderLine.Location = New Point(-1, 0)
        pnlHeaderLine.Name = "pnlHeaderLine"
        pnlHeaderLine.Size = New Size(1269, 101)
        pnlHeaderLine.TabIndex = 10
        ' 
        ' Backbtn
        ' 
        Backbtn.Location = New Point(33, 38)
        Backbtn.Name = "Backbtn"
        Backbtn.Size = New Size(75, 23)
        Backbtn.TabIndex = 24
        Backbtn.Text = "Back"
        Backbtn.UseVisualStyleBackColor = True
        ' 
        ' Logout
        ' 
        Logout.AccessibleName = ""
        Logout.BackColor = Color.IndianRed
        Logout.Location = New Point(1157, 38)
        Logout.Name = "Logout"
        Logout.Size = New Size(100, 40)
        Logout.TabIndex = 10
        Logout.Text = "Logout"
        Logout.UseVisualStyleBackColor = False
        ' 
        ' lblDashboard
        ' 
        lblDashboard.AutoSize = True
        lblDashboard.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        lblDashboard.Location = New Point(536, 23)
        lblDashboard.Name = "lblDashboard"
        lblDashboard.Size = New Size(199, 51)
        lblDashboard.TabIndex = 0
        lblDashboard.Text = "GrillMate "
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(851, 203)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(405, 489)
        DataGridView1.TabIndex = 11
        ' 
        ' flpMenu
        ' 
        flpMenu.AutoScroll = True
        flpMenu.Location = New Point(12, 203)
        flpMenu.Name = "flpMenu"
        flpMenu.Size = New Size(802, 489)
        flpMenu.TabIndex = 12
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(868, 215)
        Label1.Name = "Label1"
        Label1.Size = New Size(90, 15)
        Label1.TabIndex = 14
        Label1.Text = """Current Order"""
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(1033, 231)
        Label2.Name = "Label2"
        Label2.Size = New Size(34, 15)
        Label2.TabIndex = 15
        Label2.Text = "Table"
        ' 
        ' flpTables
        ' 
        flpTables.Location = New Point(868, 249)
        flpTables.Name = "flpTables"
        flpTables.Size = New Size(376, 149)
        flpTables.TabIndex = 16
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(871, 623)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(45, 15)
        lblTotal.TabIndex = 18
        lblTotal.Text = """Total:"""
        ' 
        ' btnSubmit
        ' 
        btnSubmit.Location = New Point(1013, 644)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(104, 36)
        btnSubmit.TabIndex = 19
        btnSubmit.Text = """Submit Order"""
        btnSubmit.UseVisualStyleBackColor = True
        ' 
        ' dgvOrder
        ' 
        dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrder.Location = New Point(871, 419)
        dgvOrder.Name = "dgvOrder"
        dgvOrder.Size = New Size(373, 201)
        dgvOrder.TabIndex = 20
        ' 
        ' flpCategory
        ' 
        flpCategory.Location = New Point(12, 131)
        flpCategory.Name = "flpCategory"
        flpCategory.Size = New Size(802, 57)
        flpCategory.TabIndex = 21
        ' 
        ' btnEditMenu
        ' 
        btnEditMenu.Location = New Point(1139, 120)
        btnEditMenu.Name = "btnEditMenu"
        btnEditMenu.Size = New Size(117, 49)
        btnEditMenu.TabIndex = 22
        btnEditMenu.Text = "Edit Menu"
        btnEditMenu.UseVisualStyleBackColor = True
        ' 
        ' cmbPaymentMethod
        ' 
        cmbPaymentMethod.FormattingEnabled = True
        cmbPaymentMethod.Location = New Point(1122, 620)
        cmbPaymentMethod.Name = "cmbPaymentMethod"
        cmbPaymentMethod.Size = New Size(121, 23)
        cmbPaymentMethod.TabIndex = 23
        cmbPaymentMethod.Text = "Payment Method"
        ' 
        ' btnDelivery
        ' 
        btnDelivery.BackColor = Color.LightCyan
        btnDelivery.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDelivery.Location = New Point(1139, 644)
        btnDelivery.Name = "btnDelivery"
        btnDelivery.Size = New Size(104, 36)
        btnDelivery.TabIndex = 20
        btnDelivery.Text = "Delivery Order"
        btnDelivery.UseVisualStyleBackColor = False
        ' 
        ' OrderEntryFrm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1280, 720)
        Controls.Add(cmbPaymentMethod)
        Controls.Add(btnEditMenu)
        Controls.Add(Label2)
        Controls.Add(flpCategory)
        Controls.Add(dgvOrder)
        Controls.Add(btnSubmit)
        Controls.Add(btnDelivery)
        Controls.Add(lblTotal)
        Controls.Add(flpTables)
        Controls.Add(Label1)
        Controls.Add(flpMenu)
        Controls.Add(DataGridView1)
        Controls.Add(pnlHeaderLine)
        Name = "OrderEntryFrm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form3"
        pnlHeaderLine.ResumeLayout(False)
        pnlHeaderLine.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvOrder, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlHeaderLine As Panel
    Friend WithEvents Logout As Button
    Friend WithEvents lblDashboard As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents flpMenu As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents flpTables As FlowLayoutPanel
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnDelivery As Button
    Friend WithEvents dgvOrder As DataGridView
    Friend WithEvents flpCategory As FlowLayoutPanel
    Friend WithEvents btnEditMenu As Button
    Friend WithEvents cmbPaymentMethod As ComboBox
    Friend WithEvents Backbtn As Button
End Class

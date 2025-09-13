<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        lblDashboard = New Label()
        btnOrderEntry = New Button()
        btnTableManagement = New Button()
        btnOrderHistory = New Button()
        btnReportsAnalytics = New Button()
        btnSettings = New Button()
        btnReservations = New Button()
        btnDelivery = New Button()
        SplitContainer1 = New SplitContainer()
        pnlHeaderLine = New Panel()
        Logout = New Button()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.SuspendLayout()
        pnlHeaderLine.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblDashboard
        ' 
        lblDashboard.AutoSize = True
        lblDashboard.Font = New Font("Segoe UI", 28.0F, FontStyle.Bold)
        lblDashboard.Location = New Point(548, 27)
        lblDashboard.Name = "lblDashboard"
        lblDashboard.Size = New Size(199, 51)
        lblDashboard.TabIndex = 0
        lblDashboard.Text = "GrillMate "
        ' 
        ' btnOrderEntry
        ' 
        btnOrderEntry.Font = New Font("Segoe UI", 14.0F)
        btnOrderEntry.Location = New Point(262, 174)
        btnOrderEntry.Name = "btnOrderEntry"
        btnOrderEntry.Size = New Size(217, 116)
        btnOrderEntry.TabIndex = 1
        btnOrderEntry.Text = "Order Entry"
        btnOrderEntry.UseVisualStyleBackColor = True
        ' 
        ' btnTableManagement
        ' 
        btnTableManagement.Font = New Font("Segoe UI", 12.0F)
        btnTableManagement.Location = New Point(525, 174)
        btnTableManagement.Name = "btnTableManagement"
        btnTableManagement.Size = New Size(217, 118)
        btnTableManagement.TabIndex = 2
        btnTableManagement.Text = "Table Management"
        btnTableManagement.UseVisualStyleBackColor = True
        ' 
        ' btnOrderHistory
        ' 
        btnOrderHistory.Font = New Font("Segoe UI", 12.0F)
        btnOrderHistory.Location = New Point(525, 330)
        btnOrderHistory.Name = "btnOrderHistory"
        btnOrderHistory.Size = New Size(217, 118)
        btnOrderHistory.TabIndex = 3
        btnOrderHistory.Text = "Order History"
        btnOrderHistory.UseVisualStyleBackColor = True
        ' 
        ' btnReportsAnalytics
        ' 
        btnReportsAnalytics.Font = New Font("Segoe UI", 12.0F)
        btnReportsAnalytics.Location = New Point(783, 177)
        btnReportsAnalytics.Name = "btnReportsAnalytics"
        btnReportsAnalytics.Size = New Size(217, 118)
        btnReportsAnalytics.TabIndex = 4
        btnReportsAnalytics.Text = "Reports && Analytics"
        btnReportsAnalytics.UseVisualStyleBackColor = True
        ' 
        ' btnSettings
        ' 
        btnSettings.Font = New Font("Segoe UI", 12.0F)
        btnSettings.Location = New Point(525, 496)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(217, 118)
        btnSettings.TabIndex = 5
        btnSettings.Text = "Settings"
        btnSettings.UseVisualStyleBackColor = True
        ' 
        ' btnReservations
        ' 
        btnReservations.Font = New Font("Segoe UI", 12.0F)
        btnReservations.Location = New Point(783, 333)
        btnReservations.Name = "btnReservations"
        btnReservations.Size = New Size(217, 118)
        btnReservations.TabIndex = 6
        btnReservations.Text = "Reservations"
        btnReservations.UseVisualStyleBackColor = True
        ' 
        ' btnDelivery
        ' 
        btnDelivery.Font = New Font("Segoe UI", 12.0F)
        btnDelivery.Location = New Point(262, 330)
        btnDelivery.Name = "btnDelivery"
        btnDelivery.Size = New Size(217, 118)
        btnDelivery.TabIndex = 7
        btnDelivery.Text = "Delivery"
        btnDelivery.UseVisualStyleBackColor = True
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Location = New Point(50, 517)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Size = New Size(54, 10)
        SplitContainer1.SplitterDistance = 25
        SplitContainer1.TabIndex = 8
        ' 
        ' pnlHeaderLine
        ' 
        pnlHeaderLine.BackColor = Color.DarkGray
        pnlHeaderLine.Controls.Add(Logout)
        pnlHeaderLine.Controls.Add(lblDashboard)
        pnlHeaderLine.Location = New Point(-5, -3)
        pnlHeaderLine.Name = "pnlHeaderLine"
        pnlHeaderLine.Size = New Size(1269, 101)
        pnlHeaderLine.TabIndex = 9
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
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1264, 681)
        Controls.Add(btnDelivery)
        Controls.Add(btnReservations)
        Controls.Add(btnSettings)
        Controls.Add(btnReportsAnalytics)
        Controls.Add(btnOrderHistory)
        Controls.Add(btnTableManagement)
        Controls.Add(btnOrderEntry)
        Controls.Add(SplitContainer1)
        Controls.Add(pnlHeaderLine)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GrillMate Dashboard"
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        pnlHeaderLine.ResumeLayout(False)
        pnlHeaderLine.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblDashboard As Label
    Friend WithEvents btnOrderEntry As Button
    Friend WithEvents btnTableManagement As Button
    Friend WithEvents btnOrderHistory As Button
    Friend WithEvents btnReportsAnalytics As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnReservations As Button
    Friend WithEvents btnDelivery As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pnlHeaderLine As Panel
    Friend WithEvents Logout As Button
End Class

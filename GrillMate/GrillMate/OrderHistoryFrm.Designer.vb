<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderHistoryFrm
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
        DgvOrders = New DataGridView()
        Search = New Label()
        dtpFrom = New DateTimePicker()
        dtpTo = New DateTimePicker()
        Label1 = New Label()
        Label2 = New Label()
        Searchtxtbox = New TextBox()
        Label3 = New Label()
        FltrPayMethodCmbox = New ComboBox()
        Label4 = New Label()
        DgvOrderDetails = New DataGridView()
        Refreshbtn = New Button()
        Backbtn = New Button()
        CType(DgvOrders, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvOrderDetails, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvOrders
        ' 
        DgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvOrders.Location = New Point(29, 115)
        DgvOrders.Name = "DgvOrders"
        DgvOrders.Size = New Size(723, 550)
        DgvOrders.TabIndex = 0
        ' 
        ' Search
        ' 
        Search.AutoSize = True
        Search.Location = New Point(29, 58)
        Search.Name = "Search"
        Search.Size = New Size(42, 15)
        Search.TabIndex = 2
        Search.Text = "Search"
        ' 
        ' dtpFrom
        ' 
        dtpFrom.Location = New Point(321, 75)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(200, 23)
        dtpFrom.TabIndex = 3
        ' 
        ' dtpTo
        ' 
        dtpTo.Location = New Point(550, 75)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(200, 23)
        dtpTo.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(321, 57)
        Label1.Name = "Label1"
        Label1.Size = New Size(76, 15)
        Label1.TabIndex = 5
        Label1.Text = "Filter by Date"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(527, 81)
        Label2.Name = "Label2"
        Label2.Size = New Size(19, 15)
        Label2.TabIndex = 6
        Label2.Text = "To"
        ' 
        ' Searchtxtbox
        ' 
        Searchtxtbox.Location = New Point(29, 76)
        Searchtxtbox.Name = "Searchtxtbox"
        Searchtxtbox.Size = New Size(134, 23)
        Searchtxtbox.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(171, 57)
        Label3.Name = "Label3"
        Label3.Size = New Size(144, 15)
        Label3.TabIndex = 8
        Label3.Text = "Filter by Payment Method"
        ' 
        ' FltrPayMethodCmbox
        ' 
        FltrPayMethodCmbox.FormattingEnabled = True
        FltrPayMethodCmbox.Location = New Point(184, 75)
        FltrPayMethodCmbox.Name = "FltrPayMethodCmbox"
        FltrPayMethodCmbox.Size = New Size(121, 23)
        FltrPayMethodCmbox.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 18.0F)
        Label4.Location = New Point(819, 80)
        Label4.Name = "Label4"
        Label4.Size = New Size(154, 32)
        Label4.TabIndex = 10
        Label4.Text = "Order Details"
        ' 
        ' DgvOrderDetails
        ' 
        DgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvOrderDetails.Location = New Point(819, 115)
        DgvOrderDetails.Name = "DgvOrderDetails"
        DgvOrderDetails.Size = New Size(416, 562)
        DgvOrderDetails.TabIndex = 11
        ' 
        ' Refreshbtn
        ' 
        Refreshbtn.Location = New Point(1160, 86)
        Refreshbtn.Name = "Refreshbtn"
        Refreshbtn.Size = New Size(75, 23)
        Refreshbtn.TabIndex = 13
        Refreshbtn.Text = "Refresh"
        Refreshbtn.UseVisualStyleBackColor = True
        ' 
        ' Backbtn
        ' 
        Backbtn.Location = New Point(14, 10)
        Backbtn.Name = "Backbtn"
        Backbtn.Size = New Size(75, 23)
        Backbtn.TabIndex = 14
        Backbtn.Text = "Back"
        Backbtn.UseVisualStyleBackColor = True
        ' 
        ' OrderHistoryFrm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1264, 681)
        Controls.Add(Backbtn)
        Controls.Add(Refreshbtn)
        Controls.Add(DgvOrderDetails)
        Controls.Add(Label4)
        Controls.Add(FltrPayMethodCmbox)
        Controls.Add(Label3)
        Controls.Add(Searchtxtbox)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dtpTo)
        Controls.Add(dtpFrom)
        Controls.Add(Search)
        Controls.Add(DgvOrders)
        Name = "OrderHistoryFrm"
        Text = "OrderHistoryFrm"
        CType(DgvOrders, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvOrderDetails, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DgvOrders As DataGridView
    Friend WithEvents Search As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Searchtxtbox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents FltrPayMethodCmbox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents DgvOrderDetails As DataGridView
    Friend WithEvents Refreshbtn As Button
    Friend WithEvents Backbtn As Button
End Class

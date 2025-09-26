<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuEditorControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        txtItemName = New TextBox()
        Label1 = New Label()
        Price = New Label()
        txtPrice = New TextBox()
        Label2 = New Label()
        btnAddMenu = New Button()
        btnUpdateMenu = New Button()
        btnDeleteMenu = New Button()
        dgvMenuEditor = New DataGridView()
        btnClear = New Button()
        cmbCategory = New ComboBox()
        CType(dgvMenuEditor, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtItemName
        ' 
        txtItemName.Location = New Point(147, 356)
        txtItemName.Name = "txtItemName"
        txtItemName.Size = New Size(100, 23)
        txtItemName.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(70, 359)
        Label1.Name = "Label1"
        Label1.Size = New Size(73, 15)
        Label1.TabIndex = 1
        Label1.Text = "Menu Name"
        ' 
        ' Price
        ' 
        Price.AutoSize = True
        Price.Location = New Point(282, 359)
        Price.Name = "Price"
        Price.Size = New Size(33, 15)
        Price.TabIndex = 3
        Price.Text = "Price"
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(321, 356)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(100, 23)
        txtPrice.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(462, 359)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 15)
        Label2.TabIndex = 5
        Label2.Text = "Category"
        ' 
        ' btnAddMenu
        ' 
        btnAddMenu.Location = New Point(92, 396)
        btnAddMenu.Name = "btnAddMenu"
        btnAddMenu.Size = New Size(101, 23)
        btnAddMenu.TabIndex = 6
        btnAddMenu.Text = "add new item"
        btnAddMenu.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateMenu
        ' 
        btnUpdateMenu.Location = New Point(223, 396)
        btnUpdateMenu.Name = "btnUpdateMenu"
        btnUpdateMenu.Size = New Size(101, 23)
        btnUpdateMenu.TabIndex = 7
        btnUpdateMenu.Text = "update selected"
        btnUpdateMenu.UseVisualStyleBackColor = True
        ' 
        ' btnDeleteMenu
        ' 
        btnDeleteMenu.Location = New Point(349, 396)
        btnDeleteMenu.Name = "btnDeleteMenu"
        btnDeleteMenu.Size = New Size(101, 23)
        btnDeleteMenu.TabIndex = 8
        btnDeleteMenu.Text = "delete selected"
        btnDeleteMenu.UseVisualStyleBackColor = True
        ' 
        ' dgvMenuEditor
        ' 
        dgvMenuEditor.AllowUserToAddRows = False
        dgvMenuEditor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMenuEditor.Location = New Point(106, 27)
        dgvMenuEditor.Name = "dgvMenuEditor"
        dgvMenuEditor.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMenuEditor.Size = New Size(468, 295)
        dgvMenuEditor.TabIndex = 10
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(492, 396)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(101, 23)
        btnClear.TabIndex = 11
        btnClear.Text = "clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' cmbCategory
        ' 
        cmbCategory.FormattingEnabled = True
        cmbCategory.Location = New Point(524, 356)
        cmbCategory.Name = "cmbCategory"
        cmbCategory.Size = New Size(121, 23)
        cmbCategory.TabIndex = 12
        ' 
        ' MenuEditorControl
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(cmbCategory)
        Controls.Add(btnClear)
        Controls.Add(dgvMenuEditor)
        Controls.Add(btnDeleteMenu)
        Controls.Add(btnUpdateMenu)
        Controls.Add(btnAddMenu)
        Controls.Add(Label2)
        Controls.Add(Price)
        Controls.Add(txtPrice)
        Controls.Add(Label1)
        Controls.Add(txtItemName)
        Name = "MenuEditorControl"
        Size = New Size(697, 456)
        CType(dgvMenuEditor, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtItemName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Price As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAddMenu As Button
    Friend WithEvents btnUpdateMenu As Button
    Friend WithEvents btnDeleteMenu As Button
    Friend WithEvents dgvMenuEditor As DataGridView
    Friend WithEvents btnClear As Button
    Friend WithEvents cmbCategory As ComboBox

End Class

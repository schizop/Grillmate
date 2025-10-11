Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class OrderHistoryFrm
    Private connectionString As String = "Server=AEGON;Database=GrillMate;Trusted_Connection=True;"

    Private Sub OrderHistoryFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPaymentMethods()
        dtpFrom.Value = DateTime.Today.AddDays(-7)
        dtpTo.Value = DateTime.Today
        LoadOrders()
    End Sub


    Private Sub LoadPaymentMethods()
        FltrPayMethodCmbox.Items.Clear()
        FltrPayMethodCmbox.Items.Add("All")
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim q As String = "SELECT DISTINCT PaymentType FROM Orders WHERE PaymentType IS NOT NULL"
            Using cmd As New SqlCommand(q, conn)
                Using rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        FltrPayMethodCmbox.Items.Add(rdr("PaymentType").ToString())
                    End While
                End Using
            End Using
        End Using
        FltrPayMethodCmbox.SelectedIndex = 0
    End Sub


    Private Sub LoadOrders(Optional search As String = "", Optional payment As String = "All", Optional fromDate As Nullable(Of DateTime) = Nothing, Optional toDate As Nullable(Of DateTime) = Nothing)
        Dim sql As String = "
            SELECT 
                o.OrderID,
                o.TableNo,
                o.OrderDate,
                o.PaymentType,
                o.Total
            FROM Orders o
        "

        Dim whereConditions As New List(Of String)
        Dim parameters As New List(Of SqlParameter)

        ' Search filter
        If Not String.IsNullOrEmpty(search) Then
            whereConditions.Add("(CAST(o.OrderID AS NVARCHAR) LIKE @search OR CAST(o.TableNo AS NVARCHAR) LIKE @search)")
            parameters.Add(New SqlParameter("@search", "%" & search & "%"))
        End If

        ' Payment filter
        If payment <> "All" Then
            whereConditions.Add("o.PaymentType = @payment")
            parameters.Add(New SqlParameter("@payment", payment))
        End If

        ' Date filter
        If fromDate.HasValue AndAlso toDate.HasValue Then
            whereConditions.Add("o.OrderDate BETWEEN @fromDate AND @toDate")
            parameters.Add(New SqlParameter("@fromDate", fromDate.Value))
            parameters.Add(New SqlParameter("@toDate", toDate.Value))
        End If

        If whereConditions.Count > 0 Then
            sql &= " WHERE " & String.Join(" AND ", whereConditions)
        End If

        sql &= " ORDER BY o.OrderDate DESC"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddRange(parameters.ToArray())
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                DgvOrders.AutoGenerateColumns = True
                DgvOrders.DataSource = dt

                ' --- Format Orders Grid ---
                If DgvOrders.Columns.Contains("OrderID") Then DgvOrders.Columns("OrderID").HeaderText = "Order #"
                If DgvOrders.Columns.Contains("TableNo") Then DgvOrders.Columns("TableNo").HeaderText = "Table"
                If DgvOrders.Columns.Contains("OrderDate") Then
                    DgvOrders.Columns("OrderDate").HeaderText = "Date"
                    DgvOrders.Columns("OrderDate").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                End If
                If DgvOrders.Columns.Contains("PaymentType") Then DgvOrders.Columns("PaymentType").HeaderText = "Payment Method"
                If DgvOrders.Columns.Contains("Total") Then
                    DgvOrders.Columns("Total").HeaderText = "Total Amount"
                    DgvOrders.Columns("Total").DefaultCellStyle.Format = "C2"
                End If

                DgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End Using
        End Using
    End Sub


    Private Sub LoadOrderDetails(orderID As Integer)
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "
            SELECT od.OrderDetailID,
                   ISNULL(m.ItemName, 'Unknown Item') AS Item,
                   ISNULL(od.Quantity, 0) AS Quantity,
                   ISNULL(od.Price, 0) AS Price,
                   (ISNULL(od.Quantity, 0) * ISNULL(od.Price, 0)) AS [Total Price]
            FROM OrderDetails od
            INNER JOIN MenuItems m ON od.ProductID = m.ItemID
            WHERE od.OrderID = @OrderID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@OrderID", orderID)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                DgvOrderDetails.AutoGenerateColumns = True
                DgvOrderDetails.DataSource = dt

                ' --- Format Order Details Grid ---
                If DgvOrderDetails.Columns.Contains("OrderDetailID") Then DgvOrderDetails.Columns("OrderDetailID").Visible = False
                If DgvOrderDetails.Columns.Contains("Item") Then DgvOrderDetails.Columns("Item").HeaderText = "Item"
                If DgvOrderDetails.Columns.Contains("Quantity") Then DgvOrderDetails.Columns("Quantity").HeaderText = "Qty"
                If DgvOrderDetails.Columns.Contains("Price") Then
                    DgvOrderDetails.Columns("Price").DefaultCellStyle.Format = "C2"
                End If
                If DgvOrderDetails.Columns.Contains("Total Price") Then
                    DgvOrderDetails.Columns("Total Price").DefaultCellStyle.Format = "C2"
                End If

                DgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End Using
        End Using
    End Sub


    Private Sub Searchtxtbox_TextChanged(sender As Object, e As EventArgs) Handles Searchtxtbox.TextChanged
        ApplyFilters()
    End Sub

    Private Sub FltrPayMethodCmbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FltrPayMethodCmbox.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        ApplyFilters()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        ApplyFilters()
    End Sub

    Private Sub ApplyFilters()
        Dim search As String = Searchtxtbox.Text.Trim()
        Dim payment As String = If(FltrPayMethodCmbox.SelectedItem IsNot Nothing, FltrPayMethodCmbox.SelectedItem.ToString(), "All")
        Dim fromDate As DateTime = dtpFrom.Value.Date
        Dim toDate As DateTime = dtpTo.Value.Date.AddDays(1).AddSeconds(-1)
        LoadOrders(search, payment, fromDate, toDate)
    End Sub

    Private Sub DgvOrders_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvOrders.CellClick
        If e.RowIndex >= 0 Then
            Dim orderId As Integer = Convert.ToInt32(DgvOrders.Rows(e.RowIndex).Cells("OrderID").Value)
            LoadOrderDetails(orderId)
        End If
    End Sub

    Private Sub Refreshbtn_Click(sender As Object, e As EventArgs) Handles Refreshbtn.Click
        Searchtxtbox.Clear()
        FltrPayMethodCmbox.SelectedIndex = 0
        dtpFrom.Value = DateTime.Today.AddDays(-7)
        dtpTo.Value = DateTime.Today
        LoadOrders()
    End Sub

    Private Sub Backbtn_Click(sender As Object, e As EventArgs) Handles Backbtn.Click
        Dashboard.Show()   ' Show Form3 again
        Me.Close()     ' Close the current form (OrderHistoryFrm)
    End Sub
End Class

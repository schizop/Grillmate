Public Class Dashboard
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' You can add any initialization code here
    End Sub

    Private Sub btnOrderEntry_Click(sender As Object, e As EventArgs) Handles btnOrderEntry.Click
        Dim orderEntryForm As New OrderEntryFrm()
        orderEntryForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnTableManagement_Click(sender As Object, e As EventArgs) Handles btnTableManagement.Click
        Dim tableManagementForm As New TableManagementFrm()
        tableManagementForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnOrderHistory_Click(sender As Object, e As EventArgs) Handles btnOrderHistory.Click
        Dim orderHistoryForm As New OrderHistoryFrm()
        orderHistoryForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnReportsAnalytics_Click(sender As Object, e As EventArgs) Handles btnReportsAnalytics.Click
        ' Add reports and analytics functionality
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ' Add settings functionality
    End Sub

    Private Sub btnReservations_Click(sender As Object, e As EventArgs) Handles btnReservations.Click
        Dim reservationForm As New ReservationFrm()
        reservationForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnDelivery_Click(sender As Object, e As EventArgs) Handles btnDelivery.Click
        Dim deliveryForm As New DeliveryFrm()
        deliveryForm.Show()
        Me.Hide()
    End Sub

    Private Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click

    End Sub
End Class
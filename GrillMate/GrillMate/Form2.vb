Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' You can add any initialization code here
    End Sub

    Private Sub btnOrderEntry_Click(sender As Object, e As EventArgs) Handles btnOrderEntry.Click
        Dim orderEntryForm As New Form3()
        orderEntryForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnTableManagement_Click(sender As Object, e As EventArgs) Handles btnTableManagement.Click
        ' Add table management functionality
    End Sub

    Private Sub btnOrderHistory_Click(sender As Object, e As EventArgs) Handles btnOrderHistory.Click
        Dim orderHistoryForm As New OrderHistoryFrm()

        ' Show it as a dialog (modal)
        orderHistoryForm.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub btnReportsAnalytics_Click(sender As Object, e As EventArgs) Handles btnReportsAnalytics.Click
        ' Add reports and analytics functionality
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ' Add settings functionality
    End Sub

    Private Sub btnReservations_Click(sender As Object, e As EventArgs) Handles btnReservations.Click
        ' Add reservations functionality
    End Sub

    Private Sub btnDelivery_Click(sender As Object, e As EventArgs) Handles btnDelivery.Click
        ' Add delivery functionality
    End Sub

    Private Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click

    End Sub
End Class
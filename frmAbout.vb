Imports MapWinUtility
Public Class frmAbout

    Private Sub frmAbout_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblVersion.Text = "PKFQWin Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
    End Sub

    Private Sub OpenLinkURL(ByVal aLink As Windows.Forms.LinkLabel)
        Try
            Diagnostics.Process.Start(aLink.Text.Substring(aLink.LinkArea.Start, aLink.LinkArea.Length))
        Catch ex As System.Exception
            'g_MapWin.ShowErrorDialog(ex)
        End Try
    End Sub

    Private Sub lblFAQLink_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblFAQLink.LinkClicked
        OpenLinkURL(lblFAQLink)
    End Sub

    Private Sub txtTestPath_Click(sender As Object, e As System.EventArgs) Handles txtTestPath.Click
        With cdlSave
            .Title = "Open the directory containing PeakFQ test data"
            .FileName = "(PeakFQ Data)"
            If .ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                txtTestPath.Text = PathNameOnly(.FileName)
            End If
        End With

    End Sub

    Private Sub txtOutputPath_Click(sender As Object, e As System.EventArgs) Handles txtOutputPath.Click
        With cdlSave
            .Title = "Specify the directory for PeakFQ test results"
            .FileName = "(PeakFQ Results)"
            If .ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                txtOutputPath.Text = PathNameOnly(.FileName)
            End If
        End With

    End Sub

    Private Sub cmdTestAll_Click(sender As Object, e As System.EventArgs) Handles cmdTestAll.Click
        If txtTestPath.Text.Length > 0 And txtOutputPath.Text.Length > 0 Then
            frmPeakfq.RunTests(txtTestPath.Text, txtOutputPath.Text)
        End If
    End Sub
End Class
Option Strict Off
Option Explicit On
Module modPeakfq
	Public PfqPrj As New pfqProject
    Public DefPfqPrj As New pfqProject
    'Public LOTestType As String = "Single Grubbs-Beck"
    Public PFQExePath As String = IO.Path.GetDirectoryName(Application.ExecutablePath)

    Friend Declare Sub PEAKFQ Lib "peakfq.dll" (ByVal aSourceFile As String, ByVal aSourceFileNameLength As Short)
    Friend Declare Sub GETDATA Lib "peakfq.dll" (ByRef aStnInd As Integer, ByRef aNPkPlt As Integer, _
                                                 ByVal aPkLog() As Single, ByVal aSysPP() As Single, _
                                                 ByVal aWrcPP() As Single, ByVal aXQual(,) As Integer, _
                                                 ByVal aPkSeq() As Integer, ByRef aWeiba As Single, _
                                                 ByRef aNPlot As Integer, ByVal aSysRfc() As Single, _
                                                 ByVal aWrcFc() As Single, ByVal aTxProb() As Single, _
                                                 ByRef aHistFlg As Integer, _
                                                 ByVal aCLimL() As Single, ByVal aCLimU() As Single, _
                                                 ByRef aNT As Integer, ByVal aThr() As Single, _
                                                 ByVal aPPTh() As Single, ByVal aNObsTh() As Integer, _
                                                 ByVal aThrSYr() As Integer, ByVal aThrEYr() As Integer, _
                                                 ByRef aNInt As Integer, ByVal aIntLwr() As Single, _
                                                 ByVal aIntUpr() As Single, ByVal aIntPPos() As Single, _
                                                 ByVal aIntYr() As Integer, ByRef aGBCrit As Single, _
                                                 ByRef aNLow As Integer, ByRef aNZero As Integer, _
                                                 ByRef aSkew As Single, ByRef aRMSegs As Single, _
                                                 ByVal aHeader As String, ByVal aHeaderLength As Short)
    Friend Declare Sub GETPEAKS Lib "peakfq.dll" (ByRef aStnInd As Integer, ByRef aNPkPlt As Integer, _
                                                  ByVal aPks() As Single, ByVal aXQual(,) As Integer, _
                                                  ByVal aPkSeq() As Integer)

    Friend Declare Sub F90_SPIPH Lib "peakfq.dll" (ByRef aHin As Integer, ByRef aHout As Integer)

    Friend pPipeWriteToStatus As Integer = 0
    Friend pPipeReadFromStatus As Integer = 0

	'UPGRADE_WARNING: Application will terminate when Sub Main() finishes. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"'
	Public Sub Main()

        'TODO: locate the PKFQBat.exe, seems like a separate program?
        'ff.SetDialogProperties("Please locate the PKFQWin Batch Executable 'PKFQBat.EXE'", My.Application.Info.DirectoryPath & "\PKFQBat.exe")
        'ff.SetRegistryInfo("PKFQWin", "files", "PKFQBat.exe")
        'PfqPrj.PFQExeFileName = atcUtility.FindFile("Please locate the PKFQWin Batch Executable 'PKFQBat.EXE'", "PKFQBat.EXE")
		
        'ff.SetDialogProperties("Please locate PKFQWin help file 'PeakFQ.chm'", My.Application.Info.DirectoryPath & "\PeakFQ.chm")
        'ff.SetRegistryInfo("PKFQWin", "files", "PeakFQ.chm")
		'UPGRADE_ISSUE: App property App.HelpFile was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'App.HelpFile = ff.GetName

        Dim lfrmPeakfq As New frmPeakfq
        lfrmPeakfq.ShowDialog()
		
	End Sub
End Module
''' <summary>
''' Sends messages to VB6 Status Monitor. 
''' Passes messages received from Status Monitor to file handle pPipeReadFromStatus
''' </summary>
''' <remarks></remarks>
Friend Class StatusMonitor
    Implements MapWinUtility.IProgressStatus

    Dim pInit As Boolean = False
    Dim pMonitorProcess As Process

    Public Sub Progress(ByVal aCurrentPosition As Integer, ByVal aLastPosition As Integer) Implements MapWinUtility.IProgressStatus.Progress
        WriteStatus("PROGRESS " & aCurrentPosition & " of " & aLastPosition)
    End Sub

    Public Sub Status(ByVal aStatusMessage As String) Implements MapWinUtility.IProgressStatus.Status
        If Not pInit Then
            Try
                Dim lProcessId As Integer = Process.GetCurrentProcess.Id
                pMonitorProcess = New Process
                With pMonitorProcess.StartInfo
                    .FileName = atcUtility.FindFile("Status Monitor", "statusMonitor.exe")
                    .Arguments = lProcessId
                    .CreateNoWindow = True
                    .UseShellExecute = False
                    .RedirectStandardInput = True
                    .RedirectStandardOutput = True
                    'AddHandler pMonitorProcess.OutputDataReceived, AddressOf MonitorMessageHandler
                    .RedirectStandardError = True
                    'AddHandler pMonitorProcess.ErrorDataReceived, AddressOf MonitorMessageHandler
                End With
                pMonitorProcess.Start()
                '
                'NOTE: to debug pMonitorProcess, in VS2005 (not Express) - choose Tools:AttachToProcess - StatusMonitor
                '
                'pMonitorProcess.StandardInput.WriteLine("Show")
                'pMonitorProcess.BeginErrorReadLine()
                'pMonitorProcess.BeginOutputReadLine()
                MapWinUtility.Logger.Dbg("MonitorLaunched")
                Dim lStreamMonitorInputFromMyOutput As IO.FileStream = pMonitorProcess.StandardInput.BaseStream
                pPipeWriteToStatus = lStreamMonitorInputFromMyOutput.SafeFileHandle.DangerousGetHandle
                Dim lStreamMonitorOutputToMyInput As IO.FileStream = pMonitorProcess.StandardOutput.BaseStream
                pPipeReadFromStatus = lStreamMonitorOutputToMyInput.SafeFileHandle.DangerousGetHandle

                Call F90_SPIPH(pPipeReadFromStatus, pPipeWriteToStatus)
            Catch ex As Exception
                MapWinUtility.Logger.Msg("StatusProcessStartError:" & ex.Message)
            End Try
            pInit = True
        End If

        WriteStatus(aStatusMessage)

        If aStatusMessage.ToLower = "exit" Then
            If Not pMonitorProcess.HasExited Then
                pMonitorProcess.StandardInput.WriteLine("Exit")
            End If
        End If
    End Sub

    Private Function WriteStatus(ByVal aMsg As String) As Boolean
        If Not IsNothing(pMonitorProcess) Then
            If pMonitorProcess.HasExited Then
                If pMonitorProcess.ExitCode <> &H103S Then 'TODO: check to be sure codes have not changed
                    Return False  'Process at other end of pipe is dead, stop talking to it
                End If
            End If
        End If

        If aMsg.StartsWith("(") AndAlso aMsg.EndsWith(")") Then
            aMsg = aMsg.Substring(1, aMsg.Length - 2)
        End If

        If aMsg.Length > 0 Then
            Dim OpenParenEscape As String = Chr(6)
            aMsg = aMsg.Replace("(", OpenParenEscape)
            Dim CloseParenEscape As String = Chr(7)
            aMsg = aMsg.Replace(")", CloseParenEscape)
            If Asc(Right(aMsg, 1)) > 31 Then
                aMsg = "(" & aMsg & ")"
            End If
            MapWinUtility.Logger.Dbg(aMsg)
            pMonitorProcess.StandardInput.WriteLine(aMsg)
        End If
        Return True
    End Function
End Class
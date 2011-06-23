Option Strict Off
Option Explicit On
Module modPeakfq
	Public PfqPrj As New pfqProject
    Public DefPfqPrj As New pfqProject
    Public LOTestType As String = "Multiple Grubbs-Beck"
    Public PFQExePath As String = IO.Path.GetDirectoryName(Application.ExecutablePath)

    Friend Declare Sub PEAKFQ Lib "peakfq.dll" (ByVal aSourceFile As String, ByVal aSourceFileNameLength As Short)
    Friend Declare Sub GETDATA Lib "peakfq.dll" (ByRef aStnInd As Integer, ByRef aNPkPlt As Integer, _
                                                 ByVal aPkLog() As Single, ByVal aSysPP() As Single, _
                                                 ByVal aWrcPP() As Single, ByVal aXQual(,) As Integer, _
                                                 ByVal aPkSeq() As Integer, ByRef aWeiba As Single, _
                                                 ByRef aNPlot As Integer, ByVal aSysRfc() As Single, _
                                                 ByVal aWrcFc() As Single, ByVal aTxProb() As Single, _
                                                 ByRef aHistFlg As Integer, ByRef aNoCLim As Integer, _
                                                 ByVal aCLimL() As Single, ByVal aCLimU() As Single, _
                                                 ByVal aHeader As String, ByVal aHeaderLength As Short)

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
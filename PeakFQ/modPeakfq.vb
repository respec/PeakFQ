Option Strict Off
Option Explicit On
Module modPeakfq
	Public PfqPrj As New pfqProject
	Public DefPfqPrj As New pfqProject
	Public gIPC As ATCoCtl.ATCoIPC
    Public gHelpFilename As String
	
	'UPGRADE_WARNING: Application will terminate when Sub Main() finishes. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"'
	Public Sub Main()

        PfqPrj.PFQExeFileName = atcUtility.FindFile("Please locate the PKFQWin Batch Executable 'PKFQBat.EXE'", My.Application.Info.DirectoryPath & "\PKFQBat.exe")
        'Dim ff As New ATCoCtl.ATCoFindFile
        'ff.SetDialogProperties("Please locate the PKFQWin Batch Executable 'PKFQBat.EXE'", My.Application.Info.DirectoryPath & "\PKFQBat.exe")
        'ff.SetRegistryInfo("PKFQWin", "files", "PKFQBat.exe")
        'PfqPrj.PFQExeFileName = ff.GetName

        gHelpFilename = atcUtility.FindFile("Please locate PKFQWin help file 'PeakFQ.chm'", My.Application.Info.DirectoryPath & "\PeakFQ.chm")
        'ff.SetDialogProperties("Please locate PKFQWin help file 'PeakFQ.chm'", My.Application.Info.DirectoryPath & "\PeakFQ.chm")
        'ff.SetRegistryInfo("PKFQWin", "files", "PeakFQ.chm")
		'UPGRADE_ISSUE: App property App.HelpFile was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'App.HelpFile = ff.GetName
		
		gIPC = New ATCoCtl.ATCoIPC
		gIPC.SendMonitorMessage("(Caption PKFQWin Status)")
		
		frmPeakfq.Show()
		
	End Sub
End Module
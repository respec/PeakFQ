Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmPeakfq
	Inherits System.Windows.Forms.Form
	Dim DefaultSpecFile As String
	Const tmpSpecName As String = "PKFQWPSF.TMP"
	Dim CurGraphName As String
	Dim RemoveBMPs As Boolean
	
	'UPGRADE_WARNING: Event chkAddOut.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkAddOut_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAddOut.CheckStateChanged
		Dim Index As Short = chkAddOut.GetIndex(eventSender)
		If Index = 1 Then 'text file additional output
			If chkAddOut(1).CheckState = System.Windows.Forms.CheckState.Checked Then
				'expand frame to show additional output file and button to edit it
				fraAddOut.Height = VB6.TwipsToPixelsY(1575)
				If Len(PfqPrj.AddOutFileName) = 0 Then 'set default
                    lblOutFile(1).Text = IO.Path.ChangeExtension((PfqPrj.OutFile), ".bcd")
				End If
				lblOutFile(1).Visible = TriState.True
				cmdOpenOut(1).Visible = TriState.True
				optAddFormat(0).Visible = TriState.True
				optAddFormat(1).Visible = TriState.True
			Else 'smaller frame is fine
				fraAddOut.Height = VB6.TwipsToPixelsY(735)
				lblOutFile(1).Visible = TriState.False
				cmdOpenOut(1).Visible = TriState.False
				optAddFormat(0).Visible = TriState.False
				optAddFormat(1).Visible = TriState.False
			End If
		End If
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        frmPeakfq_FormClosed(Me, Nothing)
	End Sub
	
    Private Sub cmdGraph_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim i As Integer
        Dim GraphName As String
        Dim newform As frmGraph

        '  For i = 1 To grdGraphs.Rows
        '    If grdGraphs.Selected(i, 0) Then
        '      GraphName = grdGraphs.TextMatrix(i, 0) & ".BMP"
        For i = 0 To lstGraphs.Items.Count - 1
            If lstGraphs.GetSelected(i) Then
                GraphName = VB6.GetItemString(lstGraphs, i) & ".BMP"
                If IO.File.Exists(GraphName) Then
                    newform = New frmGraph
                    newform.Height = VB6.TwipsToPixelsY(7600)
                    newform.Width = VB6.TwipsToPixelsX(9700)
                    newform.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
                    newform.BackgroundImage = System.Drawing.Image.FromFile(GraphName)
                    newform.Show()
                Else
                    MsgBox("No graph available for station " & VB6.GetItemString(lstGraphs, i) & "." & vbCrLf & "This station was likely skipped due to faulty data - see PeakFQ output file for details.", MsgBoxStyle.Exclamation, "PeakFQ")
                End If
            End If
        Next i
    End Sub
	
	Private Sub PopulateGrid()
		
		Dim ipos, j, i, ilen, Ind As Integer
        Dim lStation As Object

        With grdSpecs
            .Rows = 0
            i = 0
            For Each lStation In PfqPrj.Stations
                i = i + 1
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 0, lStation.id)
                .col = 0
                .row = i
                .CellBackColor = grdSpecs.BackColorFixed
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.Active. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If lStation.Active Then
                    .set_TextMatrix(i, 1, "Yes")
                Else
                    .set_TextMatrix(i, 1, "No")
                End If
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.BegYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 2, lStation.BegYear)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.EndYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 3, lStation.EndYear)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.HistoricPeriod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 4, lStation.HistoricPeriod)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.SkewOpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If lStation.SkewOpt = -1 Then
                    .set_TextMatrix(i, 5, "Station")
                    'UPGRADE_WARNING: Couldn't resolve default property of object vSta.SkewOpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf lStation.SkewOpt = 0 Then
                    .set_TextMatrix(i, 5, "Weighted")
                    'UPGRADE_WARNING: Couldn't resolve default property of object vSta.SkewOpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf lStation.SkewOpt = 1 Then
                    .set_TextMatrix(i, 5, "Generalized")
                End If
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.GenSkew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 6, lStation.GenSkew)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.SESkew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 7, lStation.SESkew)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.SESkew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 8, lStation.SESkew ^ 2)
                .CellBackColor = .BackColorFixed
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.LowHistPeak. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 9, lStation.LowHistPeak)
                .CellBackColor = .BackColorFixed
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.LowOutlier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 10, lStation.LowOutlier)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.HighSysPeak. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 11, lStation.HighSysPeak)
                .CellBackColor = .BackColorFixed
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.HighOutlier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 12, lStation.HighOutlier)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.GageBaseDischarge. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 13, lStation.GageBaseDischarge)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.UrbanRegPeaks. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If lStation.UrbanRegPeaks Then
                    .set_TextMatrix(i, 14, "Yes")
                Else
                    .set_TextMatrix(i, 14, "No")
                End If
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.Lat. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 15, lStation.Lat)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.Lng. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 16, lStation.Lng)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.PlotName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .set_TextMatrix(i, 17, lStation.PlotName)
                'UPGRADE_WARNING: Couldn't resolve default property of object vSta.PlotName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ilen = Len(lStation.PlotName)
                For j = i - 1 To 1 Step -1 'look for duplicate plot names and adjust as needed
                    'UPGRADE_WARNING: Couldn't resolve default property of object vSta.PlotName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If VB.Left(.get_TextMatrix(j, 17), ilen) = lStation.PlotName Then 'duplicate found
                        ipos = InStr(.get_TextMatrix(j, 17), "-")
                        If ipos > 0 Then 'not first duplicate, increase index number
                            Ind = CInt(Mid(.get_TextMatrix(j, 17), ipos + 1))
                            'UPGRADE_WARNING: Couldn't resolve default property of object vSta.PlotName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            .set_TextMatrix(i, 17, lStation.PlotName & "-" & CStr(Ind + 1))
                        Else 'first duplicate
                            'UPGRADE_WARNING: Couldn't resolve default property of object vSta.PlotName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            .set_TextMatrix(i, 17, lStation.PlotName & "-1")
                        End If
                    End If
                Next j
            Next lStation
            .ColsSizeByContents()
        End With
		
	End Sub
	
	Private Sub ProcessGrid()
		
		Dim i As Integer
		Dim curSta As pfqStation
		
		'UPGRADE_NOTE: Object PfqPrj.Stations may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		PfqPrj.Stations = Nothing
		'  lstGraphs.Clear
		For i = 1 To grdSpecs.Rows
			curSta = New pfqStation
			curSta.id = grdSpecs.get_TextMatrix(i, 0)
			If grdSpecs.get_TextMatrix(i, 1) = "Yes" Then
				curSta.Active = True
				'      lstGraphs.AddItem curSta.id
			Else
				curSta.Active = False
			End If
			If IsNumeric(grdSpecs.get_TextMatrix(i, 2)) Then curSta.BegYear = CInt(grdSpecs.get_TextMatrix(i, 2))
			If IsNumeric(grdSpecs.get_TextMatrix(i, 3)) Then curSta.EndYear = CInt(grdSpecs.get_TextMatrix(i, 3))
			If IsNumeric(grdSpecs.get_TextMatrix(i, 4)) Then curSta.HistoricPeriod = CSng(grdSpecs.get_TextMatrix(i, 4))
			If grdSpecs.get_TextMatrix(i, 5) = "Station" Then
				curSta.SkewOpt = -1
			ElseIf grdSpecs.get_TextMatrix(i, 5) = "Weighted" Then 
				curSta.SkewOpt = 0
			ElseIf grdSpecs.get_TextMatrix(i, 5) = "Generalized" Then 
				curSta.SkewOpt = 1
			End If
			If IsNumeric(grdSpecs.get_TextMatrix(i, 6)) Then curSta.GenSkew = CSng(grdSpecs.get_TextMatrix(i, 6))
			If IsNumeric(grdSpecs.get_TextMatrix(i, 7)) Then curSta.SESkew = CSng(grdSpecs.get_TextMatrix(i, 7))
			If IsNumeric(grdSpecs.get_TextMatrix(i, 10)) Then curSta.LowOutlier = CSng(grdSpecs.get_TextMatrix(i, 10))
			If IsNumeric(grdSpecs.get_TextMatrix(i, 12)) Then curSta.HighOutlier = CSng(grdSpecs.get_TextMatrix(i, 12))
			If IsNumeric(grdSpecs.get_TextMatrix(i, 13)) Then curSta.GageBaseDischarge = CSng(grdSpecs.get_TextMatrix(i, 13))
			If grdSpecs.get_TextMatrix(i, 14) = "Yes" Then
				curSta.UrbanRegPeaks = True
			Else
				curSta.UrbanRegPeaks = False
			End If
			If IsNumeric(grdSpecs.get_TextMatrix(i, 15)) Then curSta.Lat = CSng(grdSpecs.get_TextMatrix(i, 15))
			If IsNumeric(grdSpecs.get_TextMatrix(i, 16)) Then curSta.Lng = CSng(grdSpecs.get_TextMatrix(i, 16))
			curSta.PlotName = grdSpecs.get_TextMatrix(i, 17)
			PfqPrj.Stations.Add(curSta)
		Next 
		
	End Sub
	
	Private Sub PopulateOutput()
		
		lblOutFile(0).Text = PfqPrj.OutFile
		If PfqPrj.DataType = 0 Then 'ASCII input, can't output to WDM
			chkAddOut(0).Enabled = False
			chkAddOut(0).CheckState = System.Windows.Forms.CheckState.Unchecked
		Else
			chkAddOut(0).Enabled = True
			If PfqPrj.AdditionalOutput Mod 2 = 1 Then
				chkAddOut(0).CheckState = System.Windows.Forms.CheckState.Checked
			End If
		End If
		If PfqPrj.AdditionalOutput >= 2 Then
			chkAddOut(1).CheckState = System.Windows.Forms.CheckState.Checked
			lblOutFile(1).Text = PfqPrj.AddOutFileName
			lblOutFile(1).Visible = TriState.True
			cmdOpenOut(1).Visible = TriState.True
			optAddFormat(0).Visible = TriState.True
			optAddFormat(1).Visible = TriState.True
			If PfqPrj.AdditionalOutput < 4 Then 'watstore format
				optAddFormat(0).Checked = TriState.True
			Else 'tab-separated format
				optAddFormat(1).Checked = TriState.True
			End If
			fraAddOut.Height = VB6.TwipsToPixelsY(1575)
		Else
			chkAddOut(1).CheckState = System.Windows.Forms.CheckState.Unchecked
			lblOutFile(1).Text = "(none)"
			lblOutFile(1).Visible = TriState.False
			cmdOpenOut(1).Visible = TriState.False
			optAddFormat(0).Visible = TriState.False
			optAddFormat(1).Visible = TriState.False
			fraAddOut.Height = VB6.TwipsToPixelsY(735)
		End If
		If PfqPrj.IntermediateResults Then
			chkIntRes.CheckState = System.Windows.Forms.CheckState.Checked
		Else
			chkIntRes.CheckState = System.Windows.Forms.CheckState.Unchecked
		End If
		If PfqPrj.LinePrinter Then
			chkLinePrinter.CheckState = System.Windows.Forms.CheckState.Checked
		Else
			chkLinePrinter.CheckState = System.Windows.Forms.CheckState.Unchecked
		End If
		If PfqPrj.Graphic Then
			If UCase(PfqPrj.GraphFormat) = "CGM" Then
				optGraphFormat(2).Checked = True
			ElseIf UCase(PfqPrj.GraphFormat) = "PS" Then 
				optGraphFormat(3).Checked = True
			ElseIf UCase(PfqPrj.GraphFormat) = "WMF" Then 
				optGraphFormat(4).Checked = True
			Else 'use BMP
				optGraphFormat(1).Checked = True
			End If
		Else
			optGraphFormat(0).Checked = True
		End If
		If PfqPrj.PrintPlotPos Then
			chkPlotPos.CheckState = System.Windows.Forms.CheckState.Checked
		Else
			chkPlotPos.CheckState = System.Windows.Forms.CheckState.Unchecked
		End If
		txtCL.Value = PfqPrj.ConfidenceLimits
		txtPlotPos.Value = PfqPrj.PlotPos
	End Sub
	
	Private Sub ProcessOutput()
		Dim i As Short
		Dim lOutDir As String
		
		PfqPrj.OutFile = lblOutFile(0).Text
        lOutDir = IO.Path.GetDirectoryName((PfqPrj.OutFile))
		If Len(lOutDir) > 0 And lOutDir <> PfqPrj.InputDir Then PfqPrj.OutputDir = lOutDir
		lblOutFileView(0).Text = PfqPrj.OutFile
		If chkAddOut(0).CheckState = System.Windows.Forms.CheckState.Checked Then
			PfqPrj.AdditionalOutput = 1
		Else
			PfqPrj.AdditionalOutput = 0
		End If
		If chkAddOut(1).CheckState = System.Windows.Forms.CheckState.Checked Then
			If optAddFormat(0).Checked = TriState.True Then 'watstore format
				PfqPrj.AdditionalOutput = PfqPrj.AdditionalOutput + 2
			Else 'tab-separated format
				PfqPrj.AdditionalOutput = PfqPrj.AdditionalOutput + 4
			End If
			PfqPrj.AddOutFileName = lblOutFile(1).Text
			lblOutFileView(1).Text = PfqPrj.AddOutFileName
		Else
			PfqPrj.AddOutFileName = ""
			lblOutFileView(1).Text = "(none)"
		End If
		If chkIntRes.CheckState = System.Windows.Forms.CheckState.Checked Then
			PfqPrj.IntermediateResults = True
		Else
			PfqPrj.IntermediateResults = False
		End If
		If chkLinePrinter.CheckState = System.Windows.Forms.CheckState.Checked Then
			PfqPrj.LinePrinter = True
		Else
			PfqPrj.LinePrinter = False
		End If
		If optGraphFormat(0).Checked Then 'no graphics
			PfqPrj.Graphic = False
		Else 'get graphic format
			PfqPrj.Graphic = True
			For i = 1 To 4
				If optGraphFormat(i).Checked Then
					PfqPrj.GraphFormat = optGraphFormat(i).Text
					Exit For
				End If
			Next 
		End If
		If chkPlotPos.CheckState = System.Windows.Forms.CheckState.Checked Then
			PfqPrj.PrintPlotPos = True
		Else
			PfqPrj.PrintPlotPos = False
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object txtCL.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		PfqPrj.ConfidenceLimits = txtCL.Value
		'UPGRADE_WARNING: Couldn't resolve default property of object txtPlotPos.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		PfqPrj.PlotPos = txtPlotPos.Value
		
	End Sub
	
	Private Sub cmdOpenOut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpenOut.Click
		Dim Index As Short = cmdOpenOut.GetIndex(eventSender)
		
		On Error GoTo FileCancel
		If Index = 0 Then
			cdlOpenOpen.Title = "Main PeakFQ Output File"
			cdlOpenSave.Title = "Main PeakFQ Output File"
			'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			cdlOpenOpen.Filter = "PeakFQ Output (*.prt)|*.prt|All Files (*.*)|*.*"
			cdlOpenSave.Filter = "PeakFQ Output (*.prt)|*.prt|All Files (*.*)|*.*"
			cdlOpenOpen.FileName = PfqPrj.OutFile
			cdlOpenSave.FileName = PfqPrj.OutFile
		Else 'additional output file
			cdlOpenOpen.Title = "Additional PeakFQ Output File"
			cdlOpenSave.Title = "Additional PeakFQ Output File"
			If optAddFormat(0).Checked = TriState.True Then
				'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				cdlOpenOpen.Filter = "Watstore Output (*.bcd)|*.bcd|All Files (*.*)|*.*"
				cdlOpenSave.Filter = "Watstore Output (*.bcd)|*.bcd|All Files (*.*)|*.*"
				If Len(PfqPrj.AddOutFileName) = 0 Then 'provide default file name
                    PfqPrj.AddOutFileName = IO.Path.ChangeExtension((PfqPrj.DataFileName), ".bcd")
				End If
			Else
				'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				cdlOpenOpen.Filter = "Tab-delimited Output (*.tab)|*.tab|All Files (*.*)|*.*"
				cdlOpenSave.Filter = "Tab-delimited Output (*.tab)|*.tab|All Files (*.*)|*.*"
				If Len(PfqPrj.AddOutFileName) = 0 Then 'provide default file name
                    PfqPrj.AddOutFileName = IO.Path.ChangeExtension((PfqPrj.DataFileName), ".tab")
				End If
			End If
			cdlOpenOpen.FileName = PfqPrj.AddOutFileName
			cdlOpenSave.FileName = PfqPrj.AddOutFileName
		End If
		cdlOpenSave.ShowDialog()
		cdlOpenOpen.FileName = cdlOpenSave.FileName
        If IO.File.Exists(cdlOpenOpen.FileName) Then 'make sure it's OK to overwrite
            If MsgBox("File exists.  Do you want to overwrite it?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo FileCancel
        End If
		lblOutFile(Index).Text = cdlOpenOpen.FileName
		
FileCancel: 
	End Sub
	
	Private Sub cmdOutFileView_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOutFileView.Click
		Dim Index As Short = cmdOutFileView.GetIndex(eventSender)

        If Len(lblOutFileView(Index).Text) > 0 And lblOutFileView(Index).Text <> "(none)" Then
            atcUtility.OpenFile(lblOutFileView(Index).Text)
            'Shell(Chr(34) & FileViewer & Chr(34) & " " & lblOutFileView(Index).Text, AppWinStyle.NormalFocus)
        Else
            MsgBox("No " & fraOutFileRes(Index).Text & " is available for viewing.", MsgBoxStyle.Information, "PeakFQ")
        End If
		
	End Sub
	
    'Private Function FileViewer() As String
    '	Static Viewer As String
    '	Dim fun As Integer
    '	If Len(Viewer) = 0 Then
    '		fun = FreeFile()
    '		FileOpen(fun, "xxx.txt", OpenMode.Output)
    '		Viewer = FindAssociatedApplication("xxx.txt")
    '		FileClose(fun)
    '		Kill("xxx.txt")
    '	End If
    '	FileViewer = Viewer
    'End Function
		
	Private Sub cmdRun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRun.Click
		
		Dim i As Integer
		Dim s As String
		
		If Len(PfqPrj.SpecFileName) > 0 Then
			Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
			lstGraphs.Items.Clear()
			ProcessGrid()
			ProcessOutput()
			s = PfqPrj.SaveAsString
            IO.File.WriteAllText((PfqPrj.SpecFileName), s)
			System.Windows.Forms.Application.DoEvents()
			PfqPrj.RunBatchModel()
			System.Windows.Forms.Application.DoEvents()
			If RemoveBMPs Then
				'      For i = 1 To grdGraphs.Rows
				'        Kill grdGraphs.TextMatrix(i, 0) & ".BMP"
				For i = 1 To lstGraphs.Items.Count
					Kill(VB6.GetItemString(lstGraphs, i - 1) & ".BMP")
				Next i
			End If
			If PfqPrj.Graphic Then
				SetGraphNames()
				cmdGraph.Enabled = True
				If UCase(PfqPrj.GraphFormat) <> "BMP" Then
					RemoveBMPs = True
				Else
					RemoveBMPs = False
				End If
			Else
				'      grdGraphs.Rows = 0
				lstGraphs.Items.Clear()
				cmdGraph.Enabled = False
				RemoveBMPs = False
			End If
            Me.Cursor = System.Windows.Forms.Cursors.Default

            MainTabs.TabPages.Item(2).Enabled = True
            MainTabs.SelectedIndex = 2
			'    cmdSave.Enabled = True
			'    mnuSaveSpecs.Enabled = True
		Else
			MsgBox("PeakFQ Specfication or Data File must be opened before viewing results.", MsgBoxStyle.Information, "PeakFQ Results")
		End If
		
	End Sub
	
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
		SaveSpecFile()
	End Sub
	
	Private Sub frmPeakfq_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		Dim i As Integer
		
		lblInstruct.Text = "Use File menu to Open PeakFQ data or PKFQWin spec file." & vbLf & "Update Station and Output specifications as desired." & vbLf & "Click Run PeakFQ button to generate results."
		
		'  grdSpecs.cols = 16
		For i = 0 To 17
			grdSpecs.set_ColEditable(i, False)
		Next i
		grdSpecs.set_TextMatrix(0, 0, "Station ID")
		grdSpecs.set_ColType(0, ATCoCtl.ATCoDataType.ATCotxt)
		grdSpecs.set_TextMatrix(-1, 1, "Include in")
		grdSpecs.set_TextMatrix(0, 1, "Analysis?")
		grdSpecs.set_ColType(1, ATCoCtl.ATCoDataType.ATCotxt)
		grdSpecs.set_TextMatrix(-1, 2, "Beginning")
		grdSpecs.set_TextMatrix(0, 2, "Year")
		grdSpecs.set_ColType(2, ATCoCtl.ATCoDataType.ATCoInt)
		grdSpecs.set_TextMatrix(-1, 3, "Ending")
		grdSpecs.set_TextMatrix(0, 3, "Year")
		grdSpecs.set_ColType(3, ATCoCtl.ATCoDataType.ATCoInt)
		grdSpecs.set_TextMatrix(-1, 4, "Historic")
		grdSpecs.set_TextMatrix(0, 4, "Period")
		grdSpecs.set_ColType(4, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 5, "Skew")
		grdSpecs.set_TextMatrix(0, 5, "Option")
		grdSpecs.set_ColType(5, ATCoCtl.ATCoDataType.ATCotxt)
		grdSpecs.set_TextMatrix(-1, 6, "Generalized")
		grdSpecs.set_TextMatrix(0, 6, "Skew")
		grdSpecs.set_ColType(6, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 7, "Gen Skew")
		grdSpecs.set_TextMatrix(0, 7, "Std Error")
		grdSpecs.set_ColType(7, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 8, "Mean")
		grdSpecs.set_TextMatrix(0, 8, "Sqr Err")
		grdSpecs.set_ColType(8, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 9, "Low Hist")
		grdSpecs.set_TextMatrix(0, 9, "Peak")
		grdSpecs.set_ColType(9, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 10, "Lo-Outlier")
		grdSpecs.set_TextMatrix(0, 10, "Threshold")
		grdSpecs.set_ColType(10, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 11, "High Sys")
		grdSpecs.set_TextMatrix(0, 11, "Peak")
		grdSpecs.set_ColType(11, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 12, "Hi-Outlier")
		grdSpecs.set_TextMatrix(0, 12, "Threshold")
		grdSpecs.set_ColType(12, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 13, "Gage Base")
		grdSpecs.set_TextMatrix(0, 13, "Discharge")
		grdSpecs.set_ColType(13, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 14, "Urban/Reg")
		grdSpecs.set_TextMatrix(0, 14, "Peaks")
		grdSpecs.set_TextMatrix(0, 15, "Latitude")
		grdSpecs.set_ColType(15, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(0, 16, "Longitude")
		grdSpecs.set_ColType(16, ATCoCtl.ATCoDataType.ATCoSng)
		grdSpecs.set_TextMatrix(-1, 17, "Plot")
		grdSpecs.set_TextMatrix(0, 17, "Name")
		grdSpecs.set_ColType(17, ATCoCtl.ATCoDataType.ATCotxt)
		grdSpecs.ColsSizeByContents()
		
        MainTabs.SelectedIndex = 0
        MainTabs.TabPages.Item(0).Enabled = False
        MainTabs.TabPages.Item(1).Enabled = False
        MainTabs.TabPages.Item(2).Enabled = False
		cmdRun.Enabled = False
		cmdSave.Enabled = False
		'  grdGraphs.TextMatrix(0, 0) = "Graphs"
		'  grdGraphs.ColEditable(0) = True
		grdGraphs.Visible = False
		RemoveBMPs = False
		
	End Sub
	
	'UPGRADE_WARNING: Event frmPeakfq.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    'Private Sub frmPeakfq_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
    '	Dim w, h As Integer
    '	w = VB6.PixelsToTwipsX(Me.ClientRectangle.Width)
    '	h = VB6.PixelsToTwipsY(Me.ClientRectangle.Height)
    '	If h < 5070 And h > 0 Then 'height too small
    '		Me.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - h + 5070)
    '	End If
    '	If w > 7300 Then
    '		'    txtData.Width = w - txtData.Left - sstPfq.Left
    '		'    txtSpec.Width = txtData.Width
    '		lblData.Width = VB6.TwipsToPixelsX(w - VB6.PixelsToTwipsX(lblData.Left) - VB6.PixelsToTwipsX(sstPfq.Left))
    '		lblSpec.Width = lblData.Width
    '		sstPfq.Width = VB6.TwipsToPixelsX(w - (VB6.PixelsToTwipsX(sstPfq.Left) * 2))
    '		fraButtons.Left = VB6.TwipsToPixelsX(w - VB6.PixelsToTwipsX(fraButtons.Width) - 120)
    '		Select Case sstPfq.SelectedIndex
    '			Case 0 : grdSpecs.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(sstPfq.Width) - (VB6.PixelsToTwipsX(grdSpecs.Left) * 2))
    '			Case 1 : fraOutRight.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(sstPfq.Width) - VB6.PixelsToTwipsX(fraOutRight.Width) - 120)
    '				fraOutFile.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(fraOutRight.Left) - (VB6.PixelsToTwipsX(fraOutFile.Left) * 3))
    '				fraAddOut.Width = fraOutFile.Width
    '				lblOutFile(0).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(fraOutFile.Width) - VB6.PixelsToTwipsX(lblOutFile(0).Left) - 120)
    '				lblOutFile(1).Width = lblOutFile(0).Width
    '			Case 2 : fraGraphics.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(sstPfq.Width) - VB6.PixelsToTwipsX(fraGraphics.Width) - 120)
    '				'                grdGraphs.Left = sstPfq.Width - grdGraphs.Width - 240
    '				'                cmdGraph.Left = grdGraphs.Left + (grdGraphs.Width / 2) - (cmdGraph.Width / 2)
    '				fraOutFileRes(0).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(fraGraphics.Left) - (VB6.PixelsToTwipsX(fraOutFileRes(0).Left) * 3))
    '				fraOutFileRes(1).Width = fraOutFileRes(0).Width
    '				lblOutFileView(0).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(fraOutFileRes(0).Width) - VB6.PixelsToTwipsX(lblOutFileView(0).Left) - 120)
    '				lblOutFileView(1).Width = lblOutFileView(0).Width
    '		End Select
    '	End If
    '	If h > 5070 Then
    '		fraButtons.Top = VB6.TwipsToPixelsY(h - VB6.PixelsToTwipsY(fraButtons.Height) - 120)
    '		sstPfq.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(fraButtons.Top) - VB6.PixelsToTwipsY(sstPfq.Top) - 120)
    '		Select Case sstPfq.SelectedIndex
    '			Case 0 : grdSpecs.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(sstPfq.Height) - VB6.PixelsToTwipsY(grdSpecs.Top) - 120)
    '			Case 2 : fraGraphics.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(sstPfq.Height) - VB6.PixelsToTwipsY(fraGraphics.Top) - 120)
    '				'              grdGraphs.Height = sstPfq.Height - grdGraphs.Top - cmdGraph.Height - 240
    '				lstGraphs.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(fraGraphics.Height) - VB6.PixelsToTwipsY(lstGraphs.Top) - VB6.PixelsToTwipsY(cmdGraph.Height) - 240)
    '				cmdGraph.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lstGraphs.Top) + VB6.PixelsToTwipsY(lstGraphs.Height) + 120)
    '		End Select
    '	End If
    'End Sub
	
	Private Sub frmPeakfq_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Dim i As Integer
		
		On Error Resume Next
		
		If RemoveBMPs Then 'remove BMP graphics
			For i = 1 To lstGraphs.Items.Count
				Kill(VB6.GetItemString(lstGraphs, i - 1) & ".BMP")
			Next i
		End If
		
		gIPC.MonitorEnabled = False
		'UPGRADE_NOTE: Object gIPC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		gIPC = Nothing
		
		End
	End Sub
	
	'Private Sub grdGraphs_CommitChange(ChangeFromRow As Long, ChangeToRow As Long, ChangeFromCol As Long, ChangeToCol As Long)
	'  Dim NewGraphName As String
	'
	'  NewGraphName = FilenameNoExt(grdGraphs.TextMatrix(ChangeFromRow, ChangeFromCol)) & ".BMP"
	'  RenameGraph CurGraphName, NewGraphName
	'End Sub
	'
	'Private Sub grdGraphs_RowColChange()
	'  CurGraphName = FilenameNoExt(grdGraphs.TextMatrix(grdGraphs.row, grdGraphs.col)) & ".BMP"
	'End Sub
	
    Private Sub grdSpecs_CommitChange(ByVal eventSender As System.Object, ByVal eventArgs As AxATCoCtl.__ATCoGrid_CommitChangeEvent)
        If eventArgs.changeFromCol = 7 Then 'changed std skew err, update mean sqr err
            grdSpecs.set_TextMatrix(eventArgs.changeFromRow, 8, CSng(grdSpecs.get_TextMatrix(eventArgs.changeFromRow, eventArgs.changeFromCol)) ^ 2)
            grdSpecs.CellBackColor = grdSpecs.BackColorFixed
        End If
    End Sub
	
    Private Sub grdSpecs_RowColChange(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        grdSpecs.ClearValues()
        If grdSpecs.col = 1 Or grdSpecs.col = 14 Then
            grdSpecs.addValue("Yes")
            grdSpecs.addValue("No")
        ElseIf grdSpecs.col = 5 Then
            grdSpecs.addValue("Station")
            grdSpecs.addValue("Weighted")
            grdSpecs.addValue("Generalized")
        End If
    End Sub
	
    Private Sub lstGraphs_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmdGraph_Click(cmdGraph, New System.EventArgs())
    End Sub
	
	Public Sub mnuAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAbout.Click
		MsgBox("Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision, MsgBoxStyle.Information, "PKFQWin")
	End Sub
	
	Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
        frmPeakfq_FormClosed(Me, Nothing)
	End Sub
	
	Public Sub mnuFeedback_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFeedback.Click
		'  Dim stepname As String
		'  On Error GoTo errmsg
		'                                       stepname = "1: Dim feedback As clsATCoFeedback"
		'  Dim feedback As ATCoFeedback.clsATCoFeedback
		'                                       stepname = "2: Set feedback = New clsATCoFeedback"
		'  Set feedback = New clsATCoFeedback
		'  '                                     stepname = "3: feedback.AddText"
		'  'feedback.AddText AboutString(False)
		'                                       stepname = "4: feedback.AddFile"
		'  feedback.AddFile Left(App.path, InStr(4, App.path, "\")) & "unins000.dat"
		'                                       stepname = "5: feedback.Show"
		'  feedback.Show App, Me.Icon
		'
		'  Exit Sub
		'
		'errmsg:
		'  MsgBox "Error opening feedback in step " & stepname & vbCr & Err.Description, _
		''                         "Send Feedback"
	End Sub
	
	Public Sub mnuHelpMain_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpMain.Click
        atcUtility.OpenFile(gHelpFilename)
	End Sub
	
	Public Sub mnuOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuOpen.Click
		Dim FName As String
		Dim s As String
		On Error GoTo FileCancel
		
		cdlOpenOpen.Title = "Open PeakFQ File"
		cdlOpenSave.Title = "Open PeakFQ File"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		cdlOpenOpen.Filter = "PeakFQ Watstore Data (*.pkf,*.inp,*.txt)|*.pkf;*.inp;*.txt|PeakFQ Watstore Data (*.*)|*.*|PeakFQ WDM Data (*.wdm)|*.wdm|PKFQWin Spec (*.psf)|*.psf"
		cdlOpenSave.Filter = "PeakFQ Watstore Data (*.pkf,*.inp,*.txt)|*.pkf;*.inp;*.txt|PeakFQ Watstore Data (*.*)|*.*|PeakFQ WDM Data (*.wdm)|*.wdm|PKFQWin Spec (*.psf)|*.psf"
		cdlOpenOpen.ShowDialog()
		cdlOpenSave.FileName = cdlOpenOpen.FileName
		FName = cdlOpenOpen.FileName
        PfqPrj.InputDir = IO.Path.GetDirectoryName(FName)
        PfqPrj.OutputDir = IO.Path.GetDirectoryName(FName) 'default output directory to same as input
        MainTabs.SelectedIndex = 0
        MainTabs.TabPages.Item(2).Enabled = False
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		System.Windows.Forms.Application.DoEvents()
		If cdlOpenOpen.FilterIndex <= 3 Then 'open data file
			PfqPrj.DataFileName = FName
			PfqPrj.BuildNewSpecFile() 'build basic spec file (I/O files)
			PfqPrj.RunBatchModel() 'run model to generate verbose spec file
			PfqPrj.ReadSpecFile() 'read verbose spec file
			DefPfqPrj = PfqPrj.Copy
		Else 'open spec file
            s = IO.File.ReadAllText(FName)
			'build default project from initial version of spec file
            IO.File.WriteAllText(tmpSpecName, s)
			PfqPrj.SpecFileName = tmpSpecName 'make working verbose copy
			DefPfqPrj = PfqPrj.SaveDefaults(s)
		End If
        If IO.File.Exists(PfqPrj.OutFile) Then 'delete output file generated from reading data
            Kill(PfqPrj.OutFile)
        End If
		Me.Cursor = System.Windows.Forms.Cursors.Default
		If PfqPrj.Stations.Count > 0 Then
			'    txtData.Text = PfqPrj.DataFileName
			lblData.Text = "PeakFQ Data File:  " & PfqPrj.DataFileName
			If cdlOpenOpen.FilterIndex = 4 Then 'opened spec file, put name on main form
				'      txtSpec.Text = fname
				lblSpec.Text = "PKFQWin Spec File:  " & FName
			End If
			EnableGrid()
			PopulateGrid()
			PopulateOutput()
            MainTabs.TabPages.Item(0).Enabled = True
            MainTabs.TabPages.Item(1).Enabled = True
			cmdRun.Enabled = True
			cmdSave.Enabled = True
			mnuSaveSpecs.Enabled = True
			'    PfqPrj.SpecFileName = tmpSpecName 'use temporary name for active spec file
		End If
		
FileCancel: 
	End Sub
	
	Private Sub EnableGrid()
		Dim i As Short
		
		For i = 1 To 17
			If i <> 8 And i <> 9 And i <> 11 Then grdSpecs.set_ColEditable(i, True)
		Next i
		'  grdSpecs.ColEditable(0) = False 'station number not editable
		'  grdSpecs.ColEditable(8) = False 'low historic peak not editable
		'  grdspecs.ColEditable(9) = False 'root mean square error not editable
		'  grdSpecs.ColEditable(10) = False 'high historic peak not editable
		
	End Sub
	
	Public Sub mnuSaveSpecs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSaveSpecs.Click
		SaveSpecFile()
	End Sub
	
	Private Sub SaveSpecFile()
		
		Dim s As String
		
		On Error GoTo FileCancel
		
		cdlOpenOpen.Title = "PKFQWin Specification File"
		cdlOpenSave.Title = "PKFQWin Specification File"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		cdlOpenOpen.Filter = "PKFQWin Spec File (*.psf)|*.psf|All Files (*.*)|*.*"
		cdlOpenSave.Filter = "PKFQWin Spec File (*.psf)|*.psf|All Files (*.*)|*.*"
		If VB.Right(PfqPrj.SpecFileName, 12) = tmpSpecName Then 'no spec file yet
            cdlOpenOpen.FileName = IO.Path.ChangeExtension((PfqPrj.DataFileName), ".psf")
            cdlOpenSave.FileName = IO.Path.ChangeExtension((PfqPrj.DataFileName), ".psf")
		Else 'use existing spec file as default
			cdlOpenOpen.FileName = DefaultSpecFile
			cdlOpenSave.FileName = DefaultSpecFile
		End If
		cdlOpenSave.ShowDialog()
		cdlOpenOpen.FileName = cdlOpenSave.FileName
		ProcessGrid()
		ProcessOutput()
		s = PfqPrj.SaveAsString(DefPfqPrj)
        IO.File.WriteAllText((cdlOpenOpen.FileName), s) 'save spec file under selected name
		lblSpec.Text = cdlOpenOpen.FileName
		
FileCancel: 
	End Sub
	
    'Private Sub sstPfq_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sstPfq.SelectedIndexChanged
    '	Static PreviousTab As Short = sstPfq.SelectedIndex()
    '	frmPeakfq_Resize(Me, New System.EventArgs())
    '	PreviousTab = sstPfq.SelectedIndex()
    'End Sub
	
	Private Sub SetGraphNames()
		Dim j, i, k As Integer
		Dim ipos, ilen, Ind As Integer
		Dim newName, oldName, GraphName As String
		
		On Error Resume Next
		
		'  grdGraphs.Rows = 0
		lstGraphs.Items.Clear()
		For i = 1 To grdSpecs.Rows
			If grdSpecs.get_TextMatrix(i, 1) = "Yes" Then
				j = j + 1
				oldName = "PKFQ-" & j & ".BMP"
				newName = grdSpecs.get_TextMatrix(i, 17)
				If i > 1 Then 'look for repeating station IDs
					ilen = Len(newName)
					For k = i - 1 To 1 Step -1
						'          GraphName = grdGraphs.TextMatrix(k, 0)
						GraphName = VB6.GetItemString(lstGraphs, k)
						If VB.Left(GraphName, ilen) = newName Then
							'same station ID, add index number
							If Len(GraphName) > ilen Then 'add one to this index
								ipos = InStrRev(GraphName, "-")
								Ind = CInt(VB.Right(GraphName, ipos - 1))
								newName = newName & CStr(Ind + 1)
							Else 'just add "-1"
								newName = newName & "-1"
							End If
						End If
					Next k
				End If
				newName = newName & ".BMP"
				RenameGraph(oldName, newName)
				'      grdGraphs.TextMatrix(i, 0) = FilenameNoExt(newName)
                lstGraphs.Items.Add(IO.Path.GetFileNameWithoutExtension(newName))
			End If
		Next i
        CurGraphName = IO.Path.GetFileNameWithoutExtension(VB6.GetItemString(lstGraphs, 0)) & ".BMP"
		
	End Sub
	
	Private Sub RenameGraph(ByRef oldName As String, ByVal newName As String)
		'rename PeakFQ graphic files
		'always BMPs; other graphic files too if BMP is not the graphic format
		On Error Resume Next
		
		Kill(newName)
		Rename(oldName, newName)
		If PfqPrj.GraphFormat <> "BMP" Then 'rename other graphic files too
            newName = IO.Path.ChangeExtension(newName, PfqPrj.GraphFormat)
			Kill(newName)
            Rename(IO.Path.ChangeExtension(oldName, PfqPrj.GraphFormat), newName)
		End If
		
	End Sub

End Class
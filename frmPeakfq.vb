Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports atcUtility
Imports atcControls
Imports MapWinUtility
Imports MapWinUtility.Strings
Imports System.Drawing.SystemColors
Imports ZedGraph

Friend Class frmPeakfq
    Inherits System.Windows.Forms.Form

    Friend DefaultMajorGridColor As Color = Color.FromArgb(255, 225, 225, 225)
    Friend DefaultMinorGridColor As Color = Color.FromArgb(255, 245, 245, 245)

    Dim DefaultSpecFile As String
    Const tmpSpecName As String = "PKFQWPSF.TMP"
    'Friend ThreshColors(255) As System.Drawing.Color '= {Color.CornflowerBlue, Color.DarkSeaGreen, Color.DeepPink, Color.DarkGoldenrod, Color.LightSlateGray, Color.Violet}
    Friend ThreshColors() As System.Drawing.Color = {Color.LightGoldenrodYellow, Color.Lime, Color.Cyan, Color.Magenta, Color.DeepPink, Color.Violet}
    Dim CurGraphName As String
    Dim CurStationIndex As Integer = -1
    Dim CurThreshRow As Integer = 0
    Dim CurIntervalRow As Integer = 0

    Dim pLastClickedRow As Integer

    Private Class GraphListItem
        Public Label As String
        Public Index As Integer
        Public Overrides Function ToString() As String
            Return Label
        End Function
        Public Sub New(ByVal aLabel As String, ByVal aIndex As Integer)
            Label = aLabel
            Index = aIndex
        End Sub
    End Class

    Private Sub chkAddOut_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAddOut.CheckStateChanged
        Dim Index As Short = chkAddOut.GetIndex(eventSender)
        If Index = 1 Then 'text file additional output
            If chkAddOut(1).CheckState = CheckState.Checked Then
                If Len(PfqPrj.AddOutFileName) = 0 Then 'set default
                    lblOutFile(1).Text = IO.Path.ChangeExtension(PfqPrj.OutFile, ".bcd")
                End If
                lblOutFile(1).Visible = True
                cmdOpenOut(1).Visible = True
                optAddFormat(0).Visible = True
                optAddFormat(1).Visible = True
            Else 'smaller frame is fine
                lblOutFile(1).Visible = False
                cmdOpenOut(1).Visible = False
                optAddFormat(0).Visible = False
                optAddFormat(1).Visible = False
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Call frmPeakfq_FormClosed(Me, New System.Windows.Forms.FormClosedEventArgs(CloseReason.None))
    End Sub

    Private Sub cmdGraph_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGraph.Click

        For i As Integer = 0 To lstGraphs.Items.Count - 1
            If lstGraphs.GetSelected(i) Then
                GenFrequencyGraph(i)
            End If
        Next i
    End Sub

    Private Sub PopulateGrid()

        Dim ipos, j, i, ilen, Ind As Integer
        Dim lRow As Integer = 1
        Dim vSta As pfqStation = Nothing
        Dim lName As String

        With grdSpecs 'At this point, there should already be one instantiated with header rows
            .Enabled = True
            .BackColor = SystemColors.Control
        End With

        With grdSpecs.Source
            .ColorCells = True

            For Each vSta In PfqPrj.Stations
                lRow += 1
                .CellValue(lRow, 0) = vSta.id
                .CellEditable(lRow, 0) = False
                .Alignment(lRow, 0) = atcAlignment.HAlignRight
                .CellColor(lRow, 0) = SystemColors.ControlDark
                .CellEditable(lRow, 0) = False
                'add stations to pull-down list on Threshold tab
                lName = vSta.id
                i = 0
                While cboStation.Items.Contains(lName)
                    i += 1
                    lName = vSta.id & "-" & i
                End While
                cboStation.Items.Add(lName)

                .CellValue(lRow, 1) = vSta.AnalysisOption
                .CellEditable(lRow, 1) = True

                .CellValue(lRow, 2) = vSta.BegYear
                .CellEditable(lRow, 2) = True
                .Alignment(lRow, 2) = atcAlignment.HAlignRight

                .CellValue(lRow, 3) = vSta.EndYear
                .CellEditable(lRow, 3) = True
                .Alignment(lRow, 3) = atcAlignment.HAlignRight

                .CellValue(lRow, 4) = vSta.EndYear - vSta.BegYear + 1
                .CellEditable(lRow, 4) = False
                .CellColor(lRow, 4) = SystemColors.ControlDark
                .Alignment(lRow, 4) = atcAlignment.HAlignRight

                If vSta.HistoricPeriod Then
                    .CellValue(lRow, 5) = "Yes"
                Else
                    .CellValue(lRow, 5) = "No"
                End If
                .CellEditable(lRow, 5) = True

                If vSta.SkewOpt = 0 Then
                    .CellValue(lRow, 6) = "Station"
                ElseIf vSta.SkewOpt = 1 Then
                    .CellValue(lRow, 6) = "Weighted"
                ElseIf vSta.SkewOpt = 2 Then
                    .CellValue(lRow, 6) = "Generalized"
                End If
                .CellEditable(lRow, 6) = True

                .CellValue(lRow, 7) = vSta.GenSkew
                .CellEditable(lRow, 7) = True
                .Alignment(lRow, 7) = atcAlignment.HAlignRight

                .CellValue(lRow, 8) = vSta.SESkew
                .CellEditable(lRow, 8) = True
                .Alignment(lRow, 8) = atcAlignment.HAlignRight

                .CellValue(lRow, 9) = DecimalAlign((vSta.SESkew ^ 2).ToString, , 4)
                .CellColor(lRow, 9) = SystemColors.ControlDark
                .CellEditable(lRow, 9) = False

                .CellValue(lRow, 10) = vSta.LowHistPeak
                .CellColor(lRow, 10) = SystemColors.ControlDark
                .CellEditable(lRow, 10) = False
                .Alignment(lRow, 10) = atcAlignment.HAlignRight

                .CellValue(lRow, 11) = vSta.LowOutlier
                .CellEditable(lRow, 11) = True
                .Alignment(lRow, 11) = atcAlignment.HAlignRight

                .CellValue(lRow, 12) = vSta.LOTestType
                .CellEditable(lRow, 12) = True

                .CellValue(lRow, 13) = vSta.HighSysPeak
                .CellColor(lRow, 13) = SystemColors.ControlDark
                .CellEditable(lRow, 13) = False
                .Alignment(lRow, 13) = atcAlignment.HAlignRight

                .CellValue(lRow, 14) = vSta.HighOutlier
                .Alignment(lRow, 14) = atcAlignment.HAlignRight
                .CellValue(lRow, 15) = vSta.GageBaseDischarge
                .Alignment(lRow, 15) = atcAlignment.HAlignRight
                If vSta.AnalysisOption = "EMA" Then
                    'don't allow editing of hi-outlier field
                    .CellEditable(lRow, 14) = False
                    .CellColor(lRow, 14) = SystemColors.ControlDark
                    .CellEditable(lRow, 15) = False
                    .CellColor(lRow, 15) = SystemColors.ControlDark
                Else
                    .CellEditable(lRow, 14) = True
                    .CellColor(lRow, 14) = Color.White
                    .CellEditable(lRow, 15) = True
                    .CellColor(lRow, 15) = Color.White
                End If


                If vSta.UrbanRegPeaks Then
                    .CellValue(lRow, 16) = "Yes"
                Else
                    .CellValue(lRow, 16) = "No"
                End If
                .CellEditable(lRow, 16) = True

                .CellValue(lRow, 17) = vSta.Lat
                .CellEditable(lRow, 17) = True
                .Alignment(lRow, 17) = atcAlignment.HAlignRight

                .CellValue(lRow, 18) = vSta.Lng
                .CellEditable(lRow, 18) = True
                .Alignment(lRow, 18) = atcAlignment.HAlignRight

                .CellValue(lRow, 19) = vSta.PlotName
                .CellEditable(lRow, 19) = True

                ilen = Len(vSta.PlotName)
                For j = .Rows - 2 To .FixedRows Step -1 'look for duplicate plot names and adjust as needed
                    If vSta.PlotName = Nothing Then

                    ElseIf VB.Left(.CellValue(j, 19), ilen) = vSta.PlotName Then 'duplicate found
                        ipos = InStr(.CellValue(j, 19), "-")
                        If ipos > 0 Then 'not first duplicate, increase index number
                            Dim larr() As String = .CellValue(lRow, 19).Split("-")
                            Dim lastInd As Integer = Integer.Parse(larr(larr.Length - 1))
                            Ind = lastInd
                            'Ind = CInt(Mid(.CellValue(j, 17), ipos + 1))
                            .CellValue(lRow, 19) = vSta.PlotName & "-" & CStr(Ind + 1)
                        Else 'first duplicate
                            .CellValue(lRow, 19) = vSta.PlotName & "-1"
                        End If
                    End If
                Next j
            Next vSta
        End With

        'post population settings
        With grdSpecs
            .AllowHorizontalScrolling = True
            .Visible = True
            .SizeAllColumnsToContents()
            .Refresh()
        End With

    End Sub

    Private Sub ProcessGrid()

        Dim i As Integer
        Dim curSta As pfqStation

        With grdSpecs.Source
            For i = .FixedRows To .Rows - 1
                curSta = PfqPrj.Stations.Item(i - .FixedRows) ' New pfqStation
                curSta.id = .CellValue(i, 0)
                curSta.AnalysisOption = .CellValue(i, 1)
                If IsNumeric(.CellValue(i, 2)) Then curSta.BegYear = CInt(.CellValue(i, 2))
                If IsNumeric(.CellValue(i, 3)) Then curSta.EndYear = CInt(.CellValue(i, 3))
                If .CellValue(i, 5) = "Yes" Then
                    curSta.HistoricPeriod = True
                Else
                    curSta.HistoricPeriod = False
                End If
                If .CellValue(i, 6) = "Station" Then
                    curSta.SkewOpt = 0
                ElseIf .CellValue(i, 6) = "Weighted" Then
                    curSta.SkewOpt = 1
                ElseIf .CellValue(i, 6) = "Generalized" Then
                    curSta.SkewOpt = 2
                End If
                If IsNumeric(.CellValue(i, 7)) Then curSta.GenSkew = CSng(.CellValue(i, 7))
                If IsNumeric(.CellValue(i, 8)) Then curSta.SESkew = CSng(.CellValue(i, 8))
                If IsNumeric(.CellValue(i, 11)) Then curSta.LowOutlier = CSng(.CellValue(i, 11))
                curSta.LOTestType = .CellValue(i, 12)
                If IsNumeric(.CellValue(i, 14)) Then curSta.HighOutlier = CSng(.CellValue(i, 14))
                If IsNumeric(.CellValue(i, 15)) Then curSta.GageBaseDischarge = CSng(.CellValue(i, 15))
                If .CellValue(i, 16) = "Yes" Then
                    curSta.UrbanRegPeaks = True
                Else
                    curSta.UrbanRegPeaks = False
                End If
                If IsNumeric(.CellValue(i, 17)) Then curSta.Lat = CSng(.CellValue(i, 17))
                If IsNumeric(.CellValue(i, 18)) Then curSta.Lng = CSng(.CellValue(i, 18))
                curSta.PlotName = .CellValue(i, 19)
                'PfqPrj.Stations.Add(curSta)
            Next
        End With
    End Sub

    Private Sub PopulateOutput()

        lblOutFile(0).Text = PfqPrj.OutFile
        If PfqPrj.DataType = 0 Then 'ASCII input, can't output to WDM
            chkAddOut(0).Enabled = False
            chkAddOut(0).CheckState = CheckState.Unchecked
        Else
            chkAddOut(0).Enabled = True
            If PfqPrj.AdditionalOutput Mod 2 = 1 Then
                chkAddOut(0).CheckState = CheckState.Checked
            End If
        End If
        If PfqPrj.AdditionalOutput >= 2 Then
            chkAddOut(1).CheckState = CheckState.Checked
            lblOutFile(1).Text = PfqPrj.AddOutFileName
            lblOutFile(1).Visible = True
            cmdOpenOut(1).Visible = True
            optAddFormat(0).Visible = True
            optAddFormat(1).Visible = True
            If PfqPrj.AdditionalOutput < 4 Then 'watstore format
                optAddFormat(0).Checked = True
            Else 'tab-separated format
                optAddFormat(1).Checked = True
            End If
            'fraAddOut.Height = VB6.TwipsToPixelsY(1575)
        Else
            chkAddOut(1).CheckState = CheckState.Unchecked
            lblOutFile(1).Text = "(none)"
            lblOutFile(1).Visible = False
            cmdOpenOut(1).Visible = False
            optAddFormat(0).Visible = False
            optAddFormat(1).Visible = False
            'fraAddOut.Height = VB6.TwipsToPixelsY(735)
        End If
        If PfqPrj.ExportFileName.Length > 0 Then
            chkExport.CheckState = CheckState.Checked
            lblExportFile.Text = PfqPrj.ExportFileName
            lblExportFile.Visible = True
            cmdOpenExport.Visible = True
        Else
            chkExport.CheckState = CheckState.Unchecked
            lblExportFile.Text = "(none)"
            lblExportFile.Visible = False
            cmdOpenExport.Visible = False
        End If
        If PfqPrj.EmpiricalFileName.Length > 0 Then
            chkEmpirical.CheckState = CheckState.Checked
            lblEmpirical.Text = PfqPrj.EmpiricalFileName
            lblEmpirical.Visible = True
            cmdOpenEmpirical.Visible = True
        Else
            chkEmpirical.CheckState = CheckState.Unchecked
            lblEmpirical.Text = "(none)"
            lblEmpirical.Visible = False
            cmdOpenEmpirical.Visible = False
        End If
        If PfqPrj.IntermediateResults Then
            chkIntRes.CheckState = CheckState.Checked
        Else
            chkIntRes.CheckState = CheckState.Unchecked
        End If
        If PfqPrj.LinePrinter Then
            chkLinePrinter.CheckState = CheckState.Checked
        Else
            chkLinePrinter.CheckState = CheckState.Unchecked
        End If
        If PfqPrj.Graphic Then
            If UCase(PfqPrj.GraphFormat) = "EMF" Then
                cboGraphFormat.SelectedIndex = 1
            ElseIf UCase(PfqPrj.GraphFormat) = "PNG" Then
                cboGraphFormat.SelectedIndex = 2
            ElseIf UCase(PfqPrj.GraphFormat) = "GIF" Then
                cboGraphFormat.SelectedIndex = 3
            ElseIf UCase(PfqPrj.GraphFormat) = "JPEG" Then
                cboGraphFormat.SelectedIndex = 4
            ElseIf UCase(PfqPrj.GraphFormat) = "TIFF" Then
                cboGraphFormat.SelectedIndex = 5
            Else 'use BMP
                cboGraphFormat.SelectedIndex = 6
            End If
            cboDataGraphFormat.SelectedIndex = cboGraphFormat.SelectedIndex
        Else
            cboGraphFormat.SelectedIndex = 0
        End If
        If PfqPrj.PrintPlotPos Then
            chkPlotPos.CheckState = CheckState.Checked
        Else
            chkPlotPos.CheckState = CheckState.Unchecked
        End If
        txtCL.Text = PfqPrj.ConfidenceLimits
        txtPlotPos.Text = PfqPrj.PlotPos
    End Sub

    Private Sub ProcessOutput()
        Dim i As Short
        Dim lOutDir As String

        PfqPrj.OutFile = lblOutFile(0).Text
        lOutDir = PathNameOnly((PfqPrj.OutFile))
        If Len(lOutDir) > 0 And lOutDir <> PfqPrj.InputDir Then PfqPrj.OutputDir = lOutDir
        lblOutFileView(0).Text = PfqPrj.OutFile
        If chkAddOut(0).CheckState = CheckState.Checked Then
            PfqPrj.AdditionalOutput = 1
        Else
            PfqPrj.AdditionalOutput = 0
        End If
        If chkAddOut(1).CheckState = CheckState.Checked Then
            If optAddFormat(0).Checked = True Then 'watstore format
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
        If chkExport.CheckState = CheckState.Checked Then
            PfqPrj.ExportFileName = lblExportFile.Text
            lblExportFileView.Text = PfqPrj.ExportFileName
        Else
            PfqPrj.ExportFileName = ""
            lblExportFileView.Text = "(none)"
        End If
        If chkEmpirical.CheckState = CheckState.Checked Then
            PfqPrj.EmpiricalFileName = lblEmpirical.Text
            lblEmpiricalFileView.Text = PfqPrj.EmpiricalFileName
        Else
            PfqPrj.EmpiricalFileName = ""
            lblEmpiricalFileView.Text = "(none)"
        End If
        If chkIntRes.CheckState = CheckState.Checked Then
            PfqPrj.IntermediateResults = True
        Else
            PfqPrj.IntermediateResults = False
        End If
        If chkLinePrinter.CheckState = CheckState.Checked Then
            PfqPrj.LinePrinter = True
        Else
            PfqPrj.LinePrinter = False
        End If
        If cboGraphFormat.SelectedIndex = 0 Then 'no graphics
            PfqPrj.Graphic = False
        Else 'get graphic format
            PfqPrj.Graphic = True
            PfqPrj.GraphFormat = StrRetRem(cboGraphFormat.Text)
        End If
        If chkPlotPos.CheckState = CheckState.Checked Then
            PfqPrj.PrintPlotPos = True
        Else
            PfqPrj.PrintPlotPos = False
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object txtCL.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PfqPrj.ConfidenceLimits = txtCL.Text
        'UPGRADE_WARNING: Couldn't resolve default property of object txtPlotPos.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PfqPrj.PlotPos = txtPlotPos.Text

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
            If optAddFormat(0).Checked = True Then
                'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                cdlOpenOpen.Filter = "Watstore Output (*.bcd)|*.bcd|All Files (*.*)|*.*"
                cdlOpenSave.Filter = "Watstore Output (*.bcd)|*.bcd|All Files (*.*)|*.*"
                If Len(PfqPrj.AddOutFileName) = 0 Then 'provide default file name
                    PfqPrj.AddOutFileName = IO.Path.ChangeExtension(PfqPrj.DataFileName, ".bcd")
                End If
            Else
                'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                cdlOpenOpen.Filter = "Tab-delimited Output (*.tab)|*.tab|All Files (*.*)|*.*"
                cdlOpenSave.Filter = "Tab-delimited Output (*.tab)|*.tab|All Files (*.*)|*.*"
                If Len(PfqPrj.AddOutFileName) = 0 Then 'provide default file name
                    PfqPrj.AddOutFileName = IO.Path.ChangeExtension(PfqPrj.DataFileName, ".tab")
                End If
            End If
            cdlOpenOpen.FileName = PfqPrj.AddOutFileName
            cdlOpenSave.FileName = PfqPrj.AddOutFileName
        End If
        cdlOpenSave.ShowDialog()
        cdlOpenOpen.FileName = cdlOpenSave.FileName
        If FileExists(cdlOpenOpen.FileName) Then 'make sure it's OK to overwrite
            If MsgBox("File exists.  Do you want to overwrite it?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo FileCancel
        End If
        lblOutFile(Index).Text = cdlOpenOpen.FileName

FileCancel:
    End Sub

    Private Sub cmdOutFileView_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOutFileView.Click
        Dim Index As Short = cmdOutFileView.GetIndex(eventSender)

        If Len(lblOutFileView(Index).Text) > 0 And lblOutFileView(Index).Text <> "(none)" Then
            'Shell(Chr(34) & FileViewer() & Chr(34) & " " & lblOutFileView(Index).Text, AppWinStyle.NormalFocus)
            System.Diagnostics.Process.Start("notepad.exe", lblOutFileView(Index).Text)
        Else
            MsgBox("No " & fraOutFileRes(Index).Text & " is available for viewing.", MsgBoxStyle.Information, "PeakFQ")
        End If

    End Sub

    Private Sub cmdRun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRun.Click

        Dim i As Integer
        Dim s As String
        Dim lStnInd As Integer

        If Len(PfqPrj.SpecFileName) > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            lstGraphs.Items.Clear()
            ProcessGrid()
            If CurStationIndex >= 0 Then ProcessThresholds()
            If cboDataGraphFormat.SelectedIndex > 0 Then
                'save all data input graphs in specified format
                lStnInd = CurStationIndex
                For CurStationIndex = 0 To PfqPrj.Stations.Count - 1
                    If PfqPrj.Stations(CurStationIndex).AnalysisOption.ToUpper <> "SKIP" Then
                        UpdateInputGraph(vbTrue)
                    End If
                Next
                CurStationIndex = lStnInd
            End If
            ProcessOutput()
            s = PfqPrj.SaveAsString
            If s.Length > 0 Then
                SaveFileString((PfqPrj.SpecFileName), s)
                Application.DoEvents()
                PfqPrj.RunBatchModel()
                Application.DoEvents()

                SetGraphNames()
                cmdGraph.Enabled = True
                sstPfq.TabPages.Item(3).Enabled = True
                sstPfq.SelectedIndex = 3
            End If
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Else
            MsgBox("PeakFQ Specfication or Data File must be opened before viewing results.", MsgBoxStyle.Information, "PeakFQ Results")
        End If

    End Sub

    Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
        SaveSpecFile()
    End Sub

    Private Sub frmPeakfq_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Dim i As Integer

        Logger.StartToFile("PeakFQ.log", , False)
        lblInstruct.Text = "Use File menu to Open PeakFQ data or PKFQWin spec file." & vbLf & "Update Station, Threshold and Output specifications as desired." & vbLf & "Click Run PeakFQ button to generate results."
        With grdSpecs
            .Source = New atcControls.atcGridSource
        End With
        With grdSpecs.Source
            .FixedRows = 2
            .Rows = 1
            .Columns = 19
            .CellValue(1, 0) = "Station ID"
            .CellValue(0, 1) = "Analysis"
            .CellValue(1, 1) = "Option"
            .CellValue(0, 2) = "Beginning"
            .CellValue(1, 2) = "Year"
            .CellValue(0, 3) = "Ending"
            .CellValue(1, 3) = "Year"
            .CellValue(0, 4) = "Record"
            .CellValue(1, 4) = "Length"
            .CellValue(0, 5) = "Inc Hist"
            .CellValue(1, 5) = "Peaks"
            .CellValue(0, 6) = "Skew"
            .CellValue(1, 6) = "Option"
            .CellValue(0, 7) = "Generalized"
            .CellValue(1, 7) = "Skew"
            .CellValue(0, 8) = "Gen Skew"
            .CellValue(1, 8) = "Std Error"
            .CellValue(0, 9) = "Mean"
            .CellValue(1, 9) = "Sqr Err"
            .CellValue(0, 10) = "Low Hist"
            .CellValue(1, 10) = "Peak"
            .CellValue(0, 11) = "PILF (LO)"
            .CellValue(1, 11) = "Threshold"
            .CellValue(0, 12) = "PILF (LO)"
            .CellValue(1, 12) = "Test"
            .CellValue(0, 13) = "High Sys"
            .CellValue(1, 13) = "Peak"
            .CellValue(0, 14) = "Hi-Outlier"
            .CellValue(1, 14) = "Threshold"
            .CellValue(0, 15) = "Gage Base"
            .CellValue(1, 15) = "Discharge"
            .CellValue(0, 16) = "Urban/Reg"
            .CellValue(1, 16) = "Peaks"
            .CellValue(1, 17) = "Latitude"
            .CellValue(1, 18) = "Longitude"
            .CellValue(0, 19) = "Plot"
            .CellValue(1, 19) = "Name"

        End With

        grdSpecs.SizeAllColumnsToContents()

        grdThresh.Source = New atcControls.atcGridSource
        With grdThresh.Source
            .FixedRows = 1
            .CellValue(0, 0) = "Start Year"
            .CellValue(0, 1) = "End Year"
            .CellValue(0, 2) = "Low Threshold"
            .CellValue(0, 3) = "High Threshold"
            .CellValue(0, 4) = "Comment (Required)"
            .ColorCells = True
            For i = 0 To .Columns - 1
                grdThresh.SizeColumnToString(i, .CellValue(0, i))
            Next
        End With

        grdInterval.Source = New atcControls.atcGridSource
        With grdInterval.Source
            .FixedRows = 1
            .CellValue(0, 0) = "Year"
            .CellValue(0, 1) = "Peak"
            .CellValue(0, 2) = "Remark Codes"
            .CellValue(0, 3) = "Low Value"
            .CellValue(0, 4) = "High Value"
            .CellValue(0, 5) = "Comment (Required)"
            .ColorCells = True
            For i = 0 To .Columns - 1
                grdInterval.SizeColumnToString(i, .CellValue(0, i))
            Next
            grdInterval.SizeColumnToString(1, .CellValue(0, 1) & .CellValue(0, 1))
        End With

        InitGraph(zgcThresh, "T")
        'Dim lRed As Integer
        'Dim lGreen As Integer
        'Dim lBlue As Integer
        'Dim lOffset As Integer
        'For i = 0 To 255
        '    lOffset = 10 * i
        '    lRed = (20 * lOffset + 20) Mod 255
        '    If lRed < 150 Then lRed += 100
        '    lGreen = (130 * lOffset + 130) Mod 255
        '    If lGreen < 150 Then lGreen += 100
        '    lBlue = (240 * lOffset + 200) Mod 255
        '    If lBlue < 150 Then lBlue += 100
        '    ThreshColors(i) = Color.FromArgb(255, lRed, lGreen, lBlue)
        'Next

        sstPfq.SelectedIndex = 0
        sstPfq.TabPages.Item(0).Enabled = False
        sstPfq.TabPages.Item(1).Enabled = False
        sstPfq.TabPages.Item(2).Enabled = False
        sstPfq.TabPages.Item(3).Enabled = False
        cmdRun.Enabled = False
        cmdSave.Enabled = False
    End Sub

    Private Sub frmPeakfq_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Logger.Flush()

        End
    End Sub

    Private Sub lstGraphs_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstGraphs.DoubleClick
        cmdGraph_Click(cmdGraph, New System.EventArgs())
    End Sub

    Public Sub mnuAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAbout.Click
        'MsgBox("Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision, MsgBoxStyle.Information, "PKFQWin")
        frmAbout.Show()
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
        Call frmPeakfq_FormClosed(Me, New System.Windows.Forms.FormClosedEventArgs(CloseReason.None))
    End Sub

    Public Sub mnuFeedback_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFeedback.Click

        '*********************
        'New feedback routine STARTS
        '*********************
        Dim lName As String = ""
        Dim lEmail As String = ""
        Dim lMessage As String = ""

        Dim lFeedbackForm As New frmFeedback

        'TODO: format as an html document?
        Dim lFeedback As String = lFeedbackForm.GetSystemInfo()
        Dim lSectionFooter As String = "___________________________" & vbCrLf

        'lFeedback &= "Project: " & g_Project.FileName & vbCrLf
        'lFeedback &= "Config: " & g_Project.ConfigFileName & vbCrLf

        lFeedback &= lSectionFooter

        lName = System.Reflection.Assembly.GetExecutingAssembly.FullName
        If lFeedbackForm.ShowFeedback(lName, lEmail, lMessage, lFeedback, False, False, False, PathNameOnly(System.Reflection.Assembly.GetExecutingAssembly.Location)) Then
            Dim lFeedbackCollection As New System.Collections.Specialized.NameValueCollection
            lFeedbackCollection.Add("name", Trim(lName))
            lFeedbackCollection.Add("email", Trim(lEmail))
            lFeedbackCollection.Add("message", Trim(lMessage))
            lFeedbackCollection.Add("sysinfo", lFeedback)
            Try
                Dim lClient As New System.Net.WebClient
                lClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
                lClient.UploadValues("http://hspf.com/cgi-bin/feedback-basins4.cgi", "POST", lFeedbackCollection)
                Logger.Msg("Feedback successfully sent", "Send Feedback")
            Catch e As Exception
                Logger.Msg("Feedback could not be sent", "Send Feedback")
            End Try
        End If

        '*********************
        'New feedback routine ENDS
        '*********************
    End Sub

    Public Sub mnuHelpMain_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpMain.Click

        'temporarily not referencing on-line help as it is very outdated, prh 3/2014
        frmAbout.Show()

        'Dim lHelpFilename As String
        'lHelpFilename = FindFile("", "C:\Doc\Peakfq\Out\peakfq.chm")
        'If FileExists(lHelpFilename) Then
        '    ShowHelp(lHelpFilename)
        '    ShowHelp("")
        'Else
        '    Logger.Dbg("Help File Not Found")
        'End If

    End Sub

    Public Sub mnuOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuOpen.Click
        Dim FName As String
        Dim s As String
        On Error GoTo FileCancel

        cdlOpenOpen.Title = "Open PeakFQ File"
        cdlOpenSave.Title = "Open PeakFQ File"
        cdlOpenOpen.Filter = "PeakFQ Watstore Data (*.pkf,*.inp,*.txt)|*.pkf;*.inp;*.txt|PeakFQ Watstore Data (*.*)|*.*|PeakFQ WDM Data (*.wdm)|*.wdm|PKFQWin Spec (*.psf)|*.psf"
        cdlOpenSave.Filter = "PeakFQ Watstore Data (*.pkf,*.inp,*.txt)|*.pkf;*.inp;*.txt|PeakFQ Watstore Data (*.*)|*.*|PeakFQ WDM Data (*.wdm)|*.wdm|PKFQWin Spec (*.psf)|*.psf"
        cdlOpenOpen.ShowDialog()
        cdlOpenSave.FileName = cdlOpenOpen.FileName
        FName = cdlOpenOpen.FileName
        PfqPrj.Stations.Clear()
        PfqPrj = New pfqProject
        PfqPrj.InputDir = PathNameOnly(FName)
        PfqPrj.OutputDir = PathNameOnly(FName) 'default output directory to same as input
        grdSpecs.Source.Rows = grdSpecs.Source.FixedRows
        cboStation.Items.Clear()
        CurStationIndex = -1
        'set to current directory
        ChDriveDir(PfqPrj.InputDir)
        sstPfq.SelectedIndex = 0
        sstPfq.TabPages.Item(3).Enabled = False
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Application.DoEvents()
        If cdlOpenOpen.FilterIndex <= 3 Then 'open data file
            PfqPrj.DataFileName = FName
            PfqPrj.BuildNewSpecFile() 'build basic spec file (I/O files)
            PfqPrj.RunBatchModel() 'run model to generate verbose spec file
            PfqPrj.ReadSpecFile() 'read verbose spec file
            DefPfqPrj = PfqPrj.Copy
        Else 'open spec file
            s = WholeFileString(FName)
            'build default project from initial version of spec file
            SaveFileString(PathNameOnly(FName) & "\" & tmpSpecName, s)
            PfqPrj.SpecFileName = PathNameOnly(FName) & "\" & tmpSpecName 'make working verbose copy
            If FileExists(PfqPrj.DataFileName) AndAlso PfqPrj.Stations.Count > 0 Then
                '                DefPfqPrj = PfqPrj.SaveDefaults(s)
                DefPfqPrj.DataFileName = PfqPrj.DataFileName
                DefPfqPrj.BuildNewSpecFile() 'build basic spec file (I/O files)
                DefPfqPrj.RunBatchModel() 'run model to generate verbose spec file
                DefPfqPrj.ReadSpecFile() 'read verbose spec file
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If FileExists(PfqPrj.DataFileName) Then
            If PfqPrj.Stations.Count > 0 Then
                'read peak data for each station from output file
                PfqPrj.ReadPeaks()
                If FileExists(PfqPrj.OutFile) Then
                    'delete output file generated from reading data
                    Kill(PfqPrj.OutFile)
                End If
                '    txtData.Text = PfqPrj.DataFileName
                lblData.Text = "PeakFQ Data File:  " & PfqPrj.DataFileName
                If cdlOpenOpen.FilterIndex = 4 Then 'opened spec file, put name on main form
                    '      txtSpec.Text = fname
                    lblSpec.Text = "PKFQWin Spec File:  " & FName
                End If
                If PfqPrj.EMA Then
                    cboAnalysisOption.SelectedItem = "EMA"
                Else
                    cboAnalysisOption.SelectedItem = "B17B"
                End If
                cboLOTest.SelectedItem = "Single Grubbs-Beck"
                EnableGrid()
                PopulateGrid()
                PopulateOutput()
                sstPfq.TabPages.Item(0).Enabled = True
                sstPfq.TabPages.Item(1).Enabled = True
                sstPfq.TabPages.Item(2).Enabled = True
                cmdRun.Enabled = True
                cmdSave.Enabled = True
                mnuSaveSpecs.Enabled = True
                '    PfqPrj.SpecFileName = tmpSpecName 'use temporary name for active spec file
            Else
                MessageBox.Show("Problem processing peak station data." & vbCrLf & _
                                "Check file and path names of selected files", "File-Open Problem")
            End If
        End If
FileCancel:
    End Sub

    Private Sub EnableGrid()
        Dim i As Short
        For i = 1 To 19
            If i <> 4 AndAlso i <> 9 AndAlso i <> 10 AndAlso i <> 13 Then
                'grdSpecs.set_ColEditable(i, True)
                With grdSpecs.Source
                    For lrow As Integer = .FixedRows To .Rows - 1
                        If lrow + 1 > .FixedRows Then
                            .CellEditable(lrow, i) = True
                        End If
                    Next
                End With
            End If
        Next i
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
            cdlOpenOpen.FileName = IO.Path.ChangeExtension(PfqPrj.DataFileName, ".psf")
            cdlOpenSave.FileName = IO.Path.ChangeExtension(PfqPrj.DataFileName, ".psf")
        Else 'use existing spec file as default
            cdlOpenOpen.FileName = DefaultSpecFile
            cdlOpenSave.FileName = DefaultSpecFile
        End If
        cdlOpenSave.ShowDialog()
        cdlOpenOpen.FileName = cdlOpenSave.FileName
        ProcessGrid()
        If CurStationIndex >= 0 Then ProcessThresholds()
        ProcessOutput()
        s = PfqPrj.SaveAsString(DefPfqPrj)
        If s.Length > 0 Then
            SaveFileString((cdlOpenOpen.FileName), s) 'save spec file under selected name
            lblSpec.Text = cdlOpenOpen.FileName
        End If

FileCancel:
    End Sub

    Private Sub sstPfq_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sstPfq.SelectedIndexChanged
        Static PreviousTab As Short = sstPfq.SelectedIndex()
        'frmPeakfq_Resize(Me, New System.EventArgs())
        PreviousTab = sstPfq.SelectedIndex()
        sstPfq.SelectedTab.Focus()
        If sstPfq.SelectedIndex = 1 Then
            cmdCodeLookup.Visible = True
        Else
            cmdCodeLookup.Visible = False
        End If
    End Sub

    Private Sub SetGraphNames()
        Dim j, i, k As Integer
        Dim ipos, ilen, Ind As Integer
        Dim newName, oldName, GraphName As String

        On Error Resume Next

        lstGraphs.Items.Clear()
        With grdSpecs.Source
            For i = 1 To .Rows - .FixedRows
                If .CellValue(i + 1, 1) <> "Skip" Then
                    j = j + 1
                    'oldName = "PKFQ-" & j & ".BMP"
                    newName = .CellValue(i + 1, 19)
                    If i > 1 Then 'look for repeating station IDs
                        ilen = Len(newName)
                        For k = i - 1 To 1 Step -1
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
                    lstGraphs.Items.Add(New GraphListItem(newName, i))
                    If PfqPrj.Graphic Then 'save graph to file
                        GenFrequencyGraph(lstGraphs.Items.Count - 1, True)
                    End If
                End If
            Next i
        End With
        CurGraphName = IO.Path.ChangeExtension(VB6.GetItemString(lstGraphs, 0), ".BMP")

    End Sub

    Private Sub RenameGraph(ByRef oldName As String, ByVal newName As String)
        'rename PeakFQ graphic files
        'always BMPs; other graphic files too if BMP is not the graphic format
        On Error Resume Next

        Kill(newName)
        Rename(oldName, newName)
        If PfqPrj.GraphFormat <> "BMP" Then 'rename other graphic files too
            newName = FilenameNoExt(newName) & "." & PfqPrj.GraphFormat
            Kill(newName)
            Rename(FilenameNoExt(oldName) & "." & PfqPrj.GraphFormat, newName)
        End If

    End Sub

    Private Sub grdSpecs_CellEdited(ByVal aGrid As atcControls.atcGrid, ByVal aRow As Integer, ByVal aColumn As Integer) Handles grdSpecs.CellEdited
        Try
            Dim lSYear As Integer = 0
            Dim lEYear As Integer = 0
            With grdSpecs.Source
                Dim lStnIndex As Integer = aRow - .FixedRows
                If aColumn = 1 Then 'check to see if switching to EMA
                    If .CellValue(aRow, aColumn) = "EMA" Then 'force inclusion of historic peaks
                        .CellValue(aRow, 5) = "Yes"
                        'set to Multiple G-B test
                        .CellValue(aRow, 12) = "Multiple"
                        'don't allow editing of hi-outlier or gage base fields
                        .CellEditable(aRow, 14) = False
                        .CellColor(aRow, 14) = SystemColors.ControlDark
                        .CellEditable(aRow, 15) = False
                        .CellColor(aRow, 15) = SystemColors.ControlDark
                    Else
                        'allow editing of hi-outlier and gage base fields
                        .CellEditable(aRow, 14) = True
                        .CellColor(aRow, 14) = Color.White
                        .CellEditable(aRow, 15) = True
                        .CellColor(aRow, 15) = Color.White
                    End If
                    ProcessGrid()
                    UpdateStationDataDisplay(lStnIndex) 'force re-population of info on Input/View tab
                ElseIf aColumn = 2 Or aColumn = 3 Then 'start/end year edited, update record length field
                    lSYear = Integer.Parse(.CellValue(aRow, 2))
                    lEYear = Integer.Parse(.CellValue(aRow, 3))
                    .CellValue(aRow, 4) = lEYear - lSYear + 1
                    'If PfqPrj.Stations(aRow - .FixedRows).Thresholds.Count > 0 Then
                    '    Dim lThresh As pfqStation.ThresholdType = PfqPrj.Stations(aRow - .FixedRows).Thresholds(0)
                    '    If aColumn = 2 Then 'update default threshold start year
                    '        lThresh.SYear = Integer.Parse(.CellValue(aRow, 2))
                    '    Else 'update default threshold end year
                    '        lThresh.EYear = Integer.Parse(.CellValue(aRow, 3))
                    '    End If
                    '    PfqPrj.Stations(aRow - .FixedRows).Thresholds.RemoveAt(0)
                    '    PfqPrj.Stations(aRow - .FixedRows).Thresholds.Insert(0, lThresh)
                    '    'PfqPrj.Stations(aRow - .FixedRows).Thresholds(0) = lThresh
                    'End If
                ElseIf aColumn = 5 Then
                    If .CellValue(aRow, aColumn) = "No" Then
                        'update start/end years to systematic range
                        lSYear = PfqPrj.Stations(lStnIndex).FirstSystematic
                        .CellValue(aRow, 2) = lSYear
                        lEYear = PfqPrj.Stations(lStnIndex).LastSystematic
                        .CellValue(aRow, 3) = lEYear
                        '.CellValue(aRow, 4) = PfqPrj.Stations(aRow - .FixedRows).LastSystematic - PfqPrj.Stations(aRow - .FixedRows).FirstSystematic + 1
                    Else
                        lSYear = PfqPrj.Stations(lStnIndex).FirstPeak
                        .CellValue(aRow, 2) = lSYear
                        lEYear = PfqPrj.Stations(lStnIndex).LastPeak
                        .CellValue(aRow, 3) = lEYear
                        '.CellValue(aRow, 4) = PfqPrj.Stations(aRow - .FixedRows).EndYear - PfqPrj.Stations(aRow - .FixedRows).BegYear + 1
                    End If
                    'Must use historic period if EMA is analysis option
                    'If .CellValue(aRow, 1) = "EMA" Then
                    '    MsgBox("Must use Historic Peaks when using EMA analysis method", MsgBoxStyle.Information, "PeakFQ Specification Issue")
                    '    .CellValue(aRow, aColumn) = "Yes"
                    'End If
                ElseIf aColumn = 8 Then 'changed std skew err, update mean sqr err
                    .CellValue(aRow, 9) = Single.Parse(.CellValue(aRow, aColumn) ^ 2)
                    .Alignment(aRow, 9) = atcAlignment.HAlignRight
                    '.CellColor(aRow, 9) = SystemColors.ControlDark
                ElseIf aColumn = 16 Then 'changed urban/regulated option, force update of Input/View tab
                    ProcessGrid()
                    UpdateStationDataDisplay(lStnIndex) 'force re-population of info on Input/View tab
                End If
                If lSYear > 0 And lEYear > 0 Then
                    Dim lIncludeHistoricPeaks As Boolean = .CellValue(aRow, 5) = "Yes"
                    PfqPrj.Stations(aRow - .FixedRows).SetDefaultThresholds(lSYear, lEYear, lIncludeHistoricPeaks)
                    .CellValue(aRow, 4) = lEYear - lSYear + 1
                    ProcessGrid()
                    If lStnIndex = CurStationIndex Then UpdateStationDataDisplay(lStnIndex) 'force re-population of info on Input/View tab
                End If
            End With
            grdSpecs.Refresh()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdSpecs_MouseDownCell(ByVal aGrid As atcControls.atcGrid, ByVal aRow As Integer, ByVal aColumn As Integer) Handles grdSpecs.MouseDownCell
        Dim lUniqueValues As New ArrayList
        pLastClickedRow = aRow
        If aColumn = 1 Then 'analysis type
            lUniqueValues.Add("Skip")
            lUniqueValues.Add("B17B")
            lUniqueValues.Add("EMA")
            aGrid.AllowNewValidValues = True
        ElseIf aColumn = 5 Then 'Historic period option column
            lUniqueValues.Add("Yes")
            lUniqueValues.Add("No")
            aGrid.AllowNewValidValues = True
        ElseIf aColumn = 6 Then ' The Skew option column
            lUniqueValues.Add("Station")
            lUniqueValues.Add("Weighted")
            lUniqueValues.Add("Generalized")
            aGrid.AllowNewValidValues = True
        ElseIf aColumn = 12 Then 'Low-outlier test option
            lUniqueValues.Add("Single")
            lUniqueValues.Add("Multiple")
            aGrid.AllowNewValidValues = True
        ElseIf aColumn = 16 Then 'Urban/Reg Peaks column
            lUniqueValues.Add("Yes")
            lUniqueValues.Add("No")
            aGrid.AllowNewValidValues = True
        Else
            aGrid.AllowNewValidValues = False
        End If
        aGrid.ValidValues = lUniqueValues
    End Sub

    Private Sub cboStation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStation.SelectedIndexChanged
        If CurStationIndex >= 0 Then 'process threshold/interval specs for current station
            ProcessThresholds()
        End If
        'update current station for threshold/interval specifying
        CurStationIndex = cboStation.SelectedIndex '+ 1
        UpdateStationDataDisplay(CurStationIndex)
    End Sub

    Public Sub UpdateStationDataDisplay(ByVal aStationIndex As Integer)
        Dim lStn As pfqStation = PfqPrj.Stations.Item(aStationIndex)
        Dim lThrColl As Generic.List(Of pfqStation.ThresholdType) = lStn.Thresholds
        Dim lDataColl As Generic.List(Of pfqStation.PeakDataType) = lStn.PeakData
        Dim lColor As System.Drawing.Color
        Dim j As Integer

        If lStn.AnalysisOption = "EMA" Then
            lblB17BWarning.Visible = False
        Else
            lblB17BWarning.Visible = True
        End If

        With grdThresh.Source ' lNewSource
            .FixedRows = 1
            .Rows = .FixedRows ' row counter progress, set to be started from the last fixed header row
            If lThrColl.Count > 0 Then
                j = 0
                For Each lThresh As pfqStation.ThresholdType In lThrColl
                    If j = 0 AndAlso lThresh.LowerLimit = 0 AndAlso lThresh.UpperLimit >= 1.0E+20 Then
                        'default threshold, use default background color
                        lColor = ThreshColors(0)
                    Else
                        lColor = ThreshColors(j)
                    End If
                    j += 1
                    .CellValue(j, 0) = lThresh.SYear
                    .CellEditable(j, 0) = True
                    .Alignment(j, 0) = atcAlignment.HAlignRight
                    .CellColor(j, 0) = lColor
                    .CellValue(j, 1) = lThresh.EYear
                    .CellEditable(j, 1) = True
                    .Alignment(j, 1) = atcAlignment.HAlignRight
                    .CellColor(j, 1) = lColor
                    If lThresh.LowerLimit >= 1.0E+20 Then
                        .CellValue(j, 2) = "inf"
                    Else
                        .CellValue(j, 2) = lThresh.LowerLimit
                    End If
                    .CellEditable(j, 2) = True
                    .Alignment(j, 2) = atcAlignment.HAlignRight
                    .CellColor(j, 2) = lColor
                    If lThresh.UpperLimit >= 1.0E+20 Then
                        .CellValue(j, 3) = "inf"
                    Else
                        .CellValue(j, 3) = lThresh.UpperLimit
                    End If
                    .CellEditable(j, 3) = True
                    .Alignment(j, 3) = atcAlignment.HAlignRight
                    .CellColor(j, 3) = lColor
                    .CellValue(j, 4) = lThresh.Comment
                    .CellEditable(j, 4) = True
                    .Alignment(j, 4) = atcAlignment.HAlignLeft
                    .CellColor(j, 4) = lColor
                Next
            End If
        End With
        AddThreshRow()

        With grdInterval.Source ' lNewSource
            .Rows = .FixedRows ' row counter progress, set to be started from the last fixed header row
            If lDataColl.Count > 0 Then
                j = 0
                For Each lData As pfqStation.PeakDataType In lDataColl
                    j += 1
                    .CellValue(j, 0) = Math.Abs(lData.Year)
                    .Alignment(j, 0) = atcAlignment.HAlignRight
                    If lData.Value = -8888 Then
                        .CellValue(j, 1) = "-8888"
                    Else
                        .CellValue(j, 1) = DoubleToString(Math.Abs(lData.Value), , "########.#", "#######0.#", , 7)
                    End If
                    .Alignment(j, 1) = atcAlignment.HAlignRight
                    .CellValue(j, 2) = lData.Code
                    .Alignment(j, 2) = atcAlignment.HAlignLeft
                    If Math.Abs(lData.Year) < lStn.BegYear OrElse (lData.Code.Contains("D") Or lData.Code.Contains("3")) OrElse _
                        ((lData.Code.Contains("K") OrElse lData.Code.Contains("6") OrElse lData.Code.Contains("C")) AndAlso Not lStn.UrbanRegPeaks) OrElse _
                        (lData.Code.Contains("H") AndAlso lStn.HistoricPeriod = 0) Then
                        'gray out since it preceeds analysis start year, is unused code, or it's urban/regulated and that option is off
                        .CellEditable(j, 0) = False
                        .CellEditable(j, 1) = False
                        .CellEditable(j, 2) = False
                        .CellColor(j, 0) = SystemColors.ControlDark
                        .CellColor(j, 1) = SystemColors.ControlDark
                        .CellColor(j, 2) = SystemColors.ControlDark
                    Else
                        .CellEditable(j, 0) = True
                        .CellEditable(j, 1) = True
                        .CellEditable(j, 2) = True
                        .CellColor(j, 0) = Color.White
                        .CellColor(j, 1) = Color.White
                        .CellColor(j, 2) = Color.White
                    End If
                    If lStn.AnalysisOption = "EMA" Then
                        If lData.LowerLimit >= 0 Then
                            .CellValue(j, 3) = lData.LowerLimit
                        ElseIf lData.Value = -8888 Then
                            .CellValue(j, 3) = "-8888"
                        Else
                            .CellValue(j, 3) = DoubleToString(Math.Abs(lData.Value), , "########.#", "#######0.#", , 7)
                        End If
                    Else
                        .CellValue(j, 3) = " "
                    End If
                    .CellEditable(j, 3) = True
                    .Alignment(j, 3) = atcAlignment.HAlignRight
                    If lStn.AnalysisOption = "EMA" Then
                        If lData.UpperLimit >= 1.0E+20 Then
                            .CellValue(j, 4) = "inf"
                        ElseIf lData.UpperLimit > 0 Then
                            .CellValue(j, 4) = lData.UpperLimit
                        ElseIf lData.Value = -8888 Then
                            .CellValue(j, 4) = "-8888"
                        Else
                            .CellValue(j, 4) = DoubleToString(Math.Abs(lData.Value), , "########.#", "#######0.#", , 7)
                        End If
                    Else
                        .CellValue(j, 4) = " "
                    End If
                    .CellEditable(j, 4) = True
                    .Alignment(j, 4) = atcAlignment.HAlignRight
                    .CellValue(j, 5) = lData.Comment
                    .CellEditable(j, 5) = True
                    .Alignment(j, 5) = atcAlignment.HAlignLeft
                Next
            End If
        End With
        AddIntervalRow()

        UpdateInputGraph()
    End Sub

    Private Sub ProcessThresholds()
        Dim lThrColl As Generic.List(Of pfqStation.ThresholdType) = Nothing
        Dim lDataColl As Generic.List(Of pfqStation.PeakDataType) = Nothing
        Dim i As Integer
        Dim lStn As pfqStation = PfqPrj.Stations.Item(CurStationIndex)

        With grdThresh.Source
            lThrColl = New Generic.List(Of pfqStation.ThresholdType)
            For i = .FixedRows To .Rows - 1
                If IsNumeric(.CellValue(i, 0)) AndAlso IsNumeric(.CellValue(i, 1)) AndAlso _
                   (IsNumeric(.CellValue(i, 2)) Or (.CellValue(i, 2) IsNot Nothing AndAlso .CellValue(i, 2).ToLower.Contains("inf"))) AndAlso _
                   (IsNumeric(.CellValue(i, 3)) Or (.CellValue(i, 3) IsNot Nothing AndAlso .CellValue(i, 3).ToLower.Contains("inf"))) Then
                    Dim lThresh As New pfqStation.ThresholdType
                    lThresh.SYear = CInt(.CellValue(i, 0))
                    lThresh.EYear = CInt(.CellValue(i, 1))
                    If .CellValue(i, 2).ToLower.Contains("inf") Then
                        lThresh.LowerLimit = 1.0E+20
                    Else
                        lThresh.LowerLimit = CSng(.CellValue(i, 2))
                    End If
                    If .CellValue(i, 3).ToLower.Contains("inf") Then
                        lThresh.UpperLimit = 1.0E+20
                    Else
                        lThresh.UpperLimit = CSng(.CellValue(i, 3))
                    End If
                    lThresh.Comment = .CellValue(i, 4)
                    lThrColl.Add(lThresh)
                End If
            Next
        End With
        With grdInterval.Source
            lDataColl = New Generic.List(Of pfqStation.PeakDataType)
            For i = .FixedRows To .Rows - 1
                If IsNumeric(.CellValue(i, 0)) Then
                    Dim lData As New pfqStation.PeakDataType
                    lData.Year = CInt(.CellValue(i, 0))
                    If .CellColor(i, 0) = SystemColors.ControlDark Then 'peak not in use, set to original peak data values
                        For Each lPeak As pfqStation.PeakDataType In lStn.PeakDataOrig
                            If Math.Abs(lData.Year) = Math.Abs(lPeak.Year) Then
                                lData = lPeak
                                Exit For
                            End If
                        Next
                    Else 'process peak value entry
                        lData.Value = CSng(.CellValue(i, 1))
                        If .CellValue(i, 2) Is Nothing Then
                            lData.Code = ""
                        Else
                            lData.Code = .CellValue(i, 2)
                        End If
                        If Not (lData.Code.Contains("D") OrElse (lData.Code.Contains("K") AndAlso Not lStn.UrbanRegPeaks)) Then
                            If .CellValue(i, 3).ToLower.Contains("inf") Then
                                lData.LowerLimit = 1.0E+20
                            ElseIf IsNumeric(.CellValue(i, 3)) Then
                                lData.LowerLimit = CSng(.CellValue(i, 3))
                            End If
                            If .CellValue(i, 4).ToLower.Contains("inf") Then
                                lData.UpperLimit = 1.0E+20
                            ElseIf IsNumeric(.CellValue(i, 4)) Then
                                lData.UpperLimit = CSng(.CellValue(i, 4))
                            End If
                            If Not .CellValue(i, 5) Is Nothing Then
                                lData.Comment = .CellValue(i, 5)
                            Else
                                lData.Comment = ""
                            End If
                        End If
                    End If
                    lDataColl.Add(lData)
                End If
            Next
            lDataColl.Sort()
        End With
        lStn.Thresholds = lThrColl
        lStn.PeakData = lDataColl
    End Sub

    Private Sub tabThresholds_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabThresholds.GotFocus
        ProcessGrid()
        If cboStation.Items.Count > 0 Then
            If CurStationIndex < 0 Then cboStation.SelectedIndex = 0
            With grdThresh 'At this point, there should already be one instantiated with header rows
                .Enabled = True
                .BackColor = SystemColors.Control
            End With
            With grdInterval 'At this point, there should already be one instantiated with header rows
                .Enabled = True
                .BackColor = SystemColors.Control
            End With
        End If
    End Sub

    Private Sub cmdAddInt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddInt.Click
        With grdInterval.Source
            .Rows += 1
            For i As Integer = 0 To 5
                .CellEditable(.Rows - 1, i) = True
                If i = 2 Or i = 5 Then
                    .Alignment(.Rows - 1, i) = atcAlignment.HAlignLeft
                Else
                    .Alignment(.Rows - 1, i) = atcAlignment.HAlignRight
                End If
            Next
        End With
    End Sub

    Private Sub cmdAddThr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddThr.Click
        With grdThresh.Source
            .Rows += 1
            For i As Integer = 0 To 4
                .CellEditable(.Rows - 1, i) = True
                If i = 4 Then
                    .Alignment(.Rows, i) = atcAlignment.HAlignLeft
                Else
                    .Alignment(.Rows, i) = atcAlignment.HAlignRight
                End If
            Next
        End With
    End Sub

    Private Sub cmdUpdateGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProcessThresholds()
        UpdateInputGraph()
    End Sub

    Private Sub UpdateInputGraph(Optional ByVal aSaveToFile As Boolean = False)
        Dim lStn As pfqStation = PfqPrj.Stations.Item(CurStationIndex)
        Dim vThresh As pfqStation.ThresholdType
        Dim lYearMin As Double = lStn.BegYear ' 10000
        Dim lYearMax As Double = lStn.EndYear ' -10000
        Dim lPkVals(lStn.PeakData.Count - 1) As Double
        Dim lDateVals(lStn.PeakData.Count - 1) As Double
        Dim lHistVals(lStn.PeakData.Count - 1) As Double
        Dim lHistDates(lStn.PeakData.Count - 1) As Double
        Dim lThrshVals(1) As Double
        Dim lThrshDates(1) As Double
        Dim lDataMin As Double = 10000
        Dim lDataMax As Double = -10000
        Dim lLogFlag As Boolean = (cmdLogReal.Text = "Real") 'True
        Dim lPane As GraphPane = zgcThresh.MasterPane.PaneList(0)
        Dim lYAxis As Axis = lPane.YAxis
        Dim lCurve As LineItem = Nothing
        Dim lCurves As atcCollection
        Dim lX(0) As Double
        Dim lY(0) As Double
        Dim i As Integer
        Dim j As Integer
        Dim lPkCnt As Integer = -1
        Dim lHistCnt As Integer = -1
        Dim lYr As Integer
        Dim lPk As Double
        Dim lCode As String

        'build threshold symbol
        Dim lThreshSymbol As New System.Drawing.Drawing2D.GraphicsPath
        Dim lSize As Single = 0.5
        lThreshSymbol.AddLine(0, 0, lSize, -2 * lSize)
        lThreshSymbol.AddLine(lSize, -2 * lSize, -lSize, -2 * lSize)
        lThreshSymbol.AddLine(-lSize, -2 * lSize, 0, 0)

        'clear previous curves
        lPane.CurveList.Clear()

        Dim lThreshColors(lStn.Thresholds.Count) As System.Drawing.Color
        Dim lThreshLegendLabels(lStn.Thresholds.Count) As String
        i = 0
        'find ranges for axes
        For Each vThresh In lStn.Thresholds
            If vThresh.SYear < lYearMin Then lYearMin = vThresh.SYear
            If vThresh.EYear > lYearMax Then lYearMax = vThresh.EYear
            If vThresh.LowerLimit > 0 AndAlso vThresh.LowerLimit < lDataMin Then lDataMin = vThresh.LowerLimit
            If vThresh.UpperLimit < 1.0E+19 AndAlso vThresh.UpperLimit > lDataMax Then lDataMax = vThresh.UpperLimit
            lThreshColors(i) = ThreshColors(i)
            lThreshLegendLabels(i) = "Threshold (" & CStr(vThresh.SYear) & "-" & CStr(vThresh.EYear) & ")"
            For j = 0 To i - 1
                If vThresh.LowerLimit = lStn.Thresholds(j).LowerLimit AndAlso vThresh.UpperLimit = lStn.Thresholds(j).UpperLimit Then
                    'matching threshold, set to same color
                    lThreshColors(i) = lThreshColors(j)
                    lThreshLegendLabels(j) = "Threshold (multiple periods)"
                    lThreshLegendLabels(i) = ""
                    Exit For
                End If
            Next
            i += 1
        Next

        Dim lAllObs As New Generic.List(Of pfqStation.PeakDataType)
        Dim lQ As pfqStation.PeakDataType
        For i = lYearMin To lYearMax
            lQ = New pfqStation.PeakDataType
            lQ.Year = i
            lQ.LowerLimit = -10000
            lQ.UpperLimit = -10000
            lAllObs.Add(lQ)
        Next

        lCurves = New atcCollection
        For Each lPeak As pfqStation.PeakDataType In lStn.PeakData
            If lPeak.Value <> -8888 Then
                lYr = Math.Abs(lPeak.Year)
                lPk = Math.Abs(lPeak.Value)
                If lYr < lYearMin Then lYearMin = lYr
                If lYr > lYearMax Then lYearMax = lYr
                If lPeak.LowerLimit >= 0 AndAlso lPeak.UpperLimit > 0 AndAlso Math.Abs(lPeak.UpperLimit - lPeak.LowerLimit) > 0.1 Then
                    'will be plotted after peaks
                Else
                    If lYr < lStn.BegYear Or lYr > lStn.EndYear Then 'set code to indicate peak won't be used
                        lCode = "D"
                    ElseIf lPeak.Code Is Nothing Then
                        lCode = ""
                    ElseIf lPeak.Code.Length > 1 Then
                        If lPeak.Code.Contains("3") Or lPeak.Code.Contains("D") Then 'check for code 3 or D first - never used
                            lCode = "D"
                        ElseIf lPeak.Code.Contains("7") Or lPeak.Code.Contains("H") Then 'next check for historic first
                            lCode = "H"
                        ElseIf lPeak.Code.Contains("K") OrElse lPeak.Code.Contains("6") OrElse lPeak.Code.Contains("C") Then
                            'urban/regulated peak
                            lCode = "K"
                        End If
                    Else
                        lCode = lPeak.Code
                    End If
                    If (lCode = "H" Or lCode = "7") And Not lStn.HistoricPeriod Then 'historic period not in use
                        lCode = "D" 'set code to not be used
                    End If
                    If lCurves.Keys.Contains(lCode) Then 'add point to this curve
                        lCurve = lCurves.ItemByKey(lCode)
                        lCurve.AddPoint(lYr, lPk)
                    Else 'new curve needed for another threshold span
                        lX(0) = lYr
                        lY(0) = lPk
                        Select Case lCode
                            Case "7", "H"
                                lCurve = lPane.AddCurve("Historic Peaks", lX, lY, Color.Black, SymbolType.Triangle)
                            Case "D", "3"
                                lCurve = lPane.AddCurve("Peaks Not Used", lX, lY, Color.Black, SymbolType.XCross)
                            Case "G", "X", "8", "3+8"
                                lCurve = lPane.AddCurve("Peaks > Shown", lX, lY, Color.Black, SymbolType.Star)
                            Case "K", "6", "C"
                                lCurve = lPane.AddCurve("Urban or Reg Peaks", lX, lY, Color.Black, SymbolType.Square)
                            Case "L", "4"
                                lCurve = lPane.AddCurve("Peaks < Shown", lX, lY, Color.Black, SymbolType.Diamond)
                            Case Else
                                lCurve = lPane.AddCurve("Gaged Peaks", lX, lY, Color.Black, SymbolType.Circle)
                        End Select
                        lCurve.Line.IsVisible = False
                        lCurves.Add(lCode, lCurve)
                    End If

                    If lPk > 0 AndAlso lPk < lDataMin Then lDataMin = lPk
                    If lPk > lDataMax Then lDataMax = lPk
                End If
                If lYr >= lStn.BegYear AndAlso lYr <= lStn.EndYear Then
                    i = lYr - lStn.BegYear
                    lAllObs(i).LowerLimit = lPk
                    lAllObs(i).UpperLimit = lPk
                End If
            End If
        Next
        'set y-axis range
        lYAxis.Scale.MaxAuto = False
        Scalit(lDataMin, lDataMax, lLogFlag, lYAxis.Scale.Min, lYAxis.Scale.Max)
        If Not lLogFlag Then
            lYAxis.Type = AxisType.Linear
            lYAxis.Scale.Min = 0
        Else
            lYAxis.Type = AxisType.Log
        End If
        'set x-axis range
        lPane.X2Axis.Scale.Min = lYearMin
        lPane.X2Axis.Scale.Max = lYearMax
        lPane.XAxis.Title.Text = "Water Year" & vbCrLf & "Station - " & lStn.PlotName ' lStn.id & " " & lStn.Name

        'now draw curves
        lYAxis.IsVisible = True
        lYAxis.Scale.IsVisible = True

        'plot any interval data
        Dim lIntervalsPlotted As Boolean = False
        i = 0
        For Each vData As pfqStation.PeakDataType In lStn.PeakData
            If vData.LowerLimit >= 0 AndAlso vData.UpperLimit > 0 AndAlso Math.Abs(vData.UpperLimit - vData.LowerLimit) > 0.1 Then
                lThrshDates(0) = vData.Year
                lThrshDates(1) = vData.Year
                If vData.LowerLimit < lYAxis.Scale.Min Then
                    lThrshVals(0) = lYAxis.Scale.Min
                Else
                    lThrshVals(0) = vData.LowerLimit
                End If
                lThrshVals(1) = vData.UpperLimit
                lCurve = lPane.AddCurve("Intervals", lThrshDates, lThrshVals, Color.Black, SymbolType.HDash)
                If lIntervalsPlotted Then
                    lCurve.Label.IsVisible = False
                End If
                lIntervalsPlotted = True
                i += 1
                If vData.Year >= lStn.BegYear AndAlso vData.Year <= lStn.EndYear Then
                    j = vData.Year - lStn.BegYear
                    lAllObs(j).LowerLimit = vData.LowerLimit
                    lAllObs(j).UpperLimit = vData.UpperLimit
                End If
            End If
        Next
        'plot peaks implied from thresholds and plot default threshold
        Dim lThreshFound As Boolean
        For Each lQ In lAllObs
            For Each vThresh In lStn.Thresholds
                lThreshFound = False
                If lQ.Year >= vThresh.SYear AndAlso lQ.Year <= vThresh.EYear AndAlso (vThresh.LowerLimit > 0 Or vThresh.UpperLimit < 1.0E+20) Then
                    'valid non-default threshold for this year
                    If lQ.LowerLimit < -9999 Then 'peak undefined for this year
                        If vThresh.LowerLimit > 0 Then
                            'implied interval from 0 to lower threshold
                            lThrshDates(0) = lQ.Year
                            lThrshDates(1) = lQ.Year
                            lThrshVals(0) = lYAxis.Scale.Min
                            lThrshVals(1) = vThresh.LowerLimit
                            lCurve = lPane.AddCurve("Intervals", lThrshDates, lThrshVals, Color.Black, SymbolType.HDash)
                            If lIntervalsPlotted Then
                                lCurve.Label.IsVisible = False
                            End If
                            lIntervalsPlotted = True
                        End If
                    End If
                    lThreshFound = True
                    Exit For
                End If
            Next
            If Not lThreshFound AndAlso lQ.Year >= lStn.Thresholds(0).SYear AndAlso lQ.Year < lStn.Thresholds(0).EYear Then
                'default threshold applies for this year, plot it
                lThrshDates(0) = lQ.Year
                lThrshDates(1) = lQ.Year + 1
                lThrshVals(0) = lYAxis.Scale.Max ' 1.0E+20
                lThrshVals(1) = lYAxis.Scale.Max '1.0E+20
                lCurve = lPane.AddCurve("Default Threshold", lThrshDates, lThrshVals, ThreshColors(0), SymbolType.None)
                lCurve.Line.Fill = New Fill(ThreshColors(0), ThreshColors(0))
                lCurve.Label.IsVisible = False
            End If
        Next

        'thresholds
        i = 0
        For Each vThresh In lStn.Thresholds
            i += 1
            If i > 1 OrElse (vThresh.LowerLimit > 0 Or vThresh.UpperLimit < 1.0E+19) Then
                '1st curve is lower limit down to bottom of graph
                lThrshDates(0) = vThresh.SYear
                lThrshDates(1) = vThresh.EYear + 0.75
                lThrshVals(0) = Math.Max(vThresh.LowerLimit, lYAxis.Scale.Min)
                If lThrshVals(0) = lYAxis.Scale.Min Then
                    If lLogFlag Then
                        lThrshVals(0) = 1.005 * lThrshVals(0)
                    Else
                        lThrshVals(0) = 1.05 * lThrshVals(0)
                    End If
                End If
                lThrshVals(1) = lThrshVals(0) ' vThresh.LowerLimit
                'lCurve = lPane.AddCurve("Threshold (" & CStr(vThresh.SYear) & "-" & CStr(vThresh.EYear) & ")", lThrshDates, lThrshVals, lThreshColors(i - 1), SymbolType.None)
                lCurve = lPane.AddCurve(lThreshLegendLabels(i - 1), lThrshDates, lThrshVals, lThreshColors(i - 1), SymbolType.None)
                lCurve.Line.Width = 6
                If lThreshLegendLabels(i - 1).Length = 0 Then lCurve.Label.IsVisible = False
                'lCurve.Line.Fill = New Fill(ThreshColors(i - 1), ThreshColors(i - 1))
                'If vThresh.UpperLimit < 1.0E+19 Then 'need other curves to show both limits
                '2nd curve fills gap between threshold limits with white fill
                If lLogFlag Then
                    lThrshVals(0) = 0.98 * Math.Min(vThresh.UpperLimit, lYAxis.Scale.Max)
                Else
                    lThrshVals(0) = 0.995 * Math.Min(vThresh.UpperLimit, lYAxis.Scale.Max)
                End If
                lThrshVals(1) = lThrshVals(0) ' vThresh.UpperLimit
                lCurve = lPane.AddCurve(lThreshLegendLabels(i - 1), lThrshDates, lThrshVals, lThreshColors(i - 1), SymbolType.None)
                lCurve.Line.Width = 6
                lCurve.Label.IsVisible = False
                ''3rd curve shows upper limit to top of graph
                'lThrshVals(0) = 1.0E+20
                'lThrshVals(1) = 1.0E+20
                'lCurve = lPane.AddCurve("Threshold (" & CStr(vThresh.SYear) & "-" & CStr(vThresh.EYear) & ")", lThrshDates, lThrshVals, ThreshColors(i - 1), SymbolType.None)
                'lCurve.Line.Fill = New Fill(ThreshColors(i - 1), ThreshColors(i - 1))
                'lCurve.Label.IsVisible = False
                'End If
            End If
        Next

        'check for missing years with no non-default threshold specified
        Dim lThreshDefined As Boolean
        Dim lAlreadyOnLegend As Boolean = False
        Dim lPrevYear As Integer = 0
        lThrshVals(0) = 1.0E+20
        lThrshVals(1) = 1.0E+20
        For Each i In lStn.FindMissingYears
            lThreshDefined = False
            For Each vThresh In lStn.Thresholds
                If i >= vThresh.SYear AndAlso i <= vThresh.EYear AndAlso _
                    (vThresh.LowerLimit <> 0 Or vThresh.UpperLimit < 1.0E+20) Then
                    'valid threshold for this missing year
                    lThreshDefined = True
                    Exit For
                End If
            Next
            If Not lThreshDefined Then 'indicate problem for this year
                If i = lPrevYear + 1 Then 'continuation of missing period
                    lCurve.AddPoint(CDbl(i + 0.75), lThrshVals(0))
                Else 'new missing period
                    lThrshDates(0) = i
                    lThrshDates(1) = i + 0.75
                    lCurve = lPane.AddCurve("Missing Year(s)", lThrshDates, lThrshVals, Color.Red, SymbolType.None)
                    lCurve.Line.Fill = New Fill(Color.Red, Color.Red)
                    If lAlreadyOnLegend Then
                        lCurve.Label.IsVisible = False
                    End If
                    lAlreadyOnLegend = True
                End If
                lPrevYear = i
            End If
        Next

        zgcThresh.AxisChange()
        zgcThresh.Invalidate()
        zgcThresh.Refresh()
        If aSaveToFile Then
            Dim lFmt As String = StrRetRem(cboDataGraphFormat.SelectedItem.ToString)
            zgcThresh.SaveIn(PfqPrj.OutputDir & "\" & cboStation.Items(CurStationIndex).ToString & "_inp." & lFmt)
        End If

    End Sub

    Private Sub InitGraph(ByVal aZGC As ZedGraphControl, ByVal aType As String)

        With aZGC
            .Visible = True
            With .MasterPane
                .PaneList.Clear() 'remove default GraphPane
                .Border.IsVisible = False
                .Legend.IsVisible = False
                .Margin.All = 2
                .InnerPaneGap = 1
                .IsCommonScaleFactor = True
                Dim lPaneMain As New ZedGraph.GraphPane
                FormatPaneWithDefaults(lPaneMain, aType)
                .PaneList.Add(lPaneMain)
            End With
        End With

    End Sub

    Public Sub FormatPaneWithDefaults(ByVal aPane As ZedGraph.GraphPane, ByVal aType As String)
        With aPane
            .IsAlignGrids = True
            .IsFontsScaled = False
            .IsPenWidthScaled = False
            .Margin.Top = 20
            .Margin.Bottom = 20
            With .XAxis
                If aType = "T" Then
                    .Scale.FontSpec.Size = 8
                    .Title.FontSpec.Size = 8
                Else
                    .Scale.FontSpec.Size = 12
                    .Title.FontSpec.Size = 12
                End If
                .Scale.FontSpec.IsBold = True
                .Scale.IsUseTenPower = False
                .Title.IsOmitMag = True
                .Scale.Mag = 0
                .MajorTic.IsOutside = False
                .MajorTic.IsInside = True
                .MajorTic.IsOpposite = True
                .MinorTic.IsOutside = False
                .MinorTic.IsInside = True
                .MinorTic.IsOpposite = True
                With .MajorGrid
                    .Color = DefaultMajorGridColor
                    .DashOn = 0
                    .DashOff = 0
                    .IsVisible = True
                End With
                With .MinorGrid
                    .Color = DefaultMinorGridColor
                    .DashOn = 0
                    .DashOff = 0
                    .IsVisible = True
                End With
                If aType = "T" Then
                    If .Type <> AxisType.Linear Then
                        .Type = AxisType.Linear
                    End If
                    .Title.Text = "Water Year"
                    .Scale.Format = "0000"
                Else
                    If .Type <> AxisType.Probability Then
                        .Type = AxisType.Probability
                    End If
                    .Scale.Format = "0.####"
                    .Scale.MaxAuto = False
                    .Scale.Min = 0.0015
                    .Scale.Max = 0.996
                    Dim lProbScale As ProbabilityScale = .Scale
                    lProbScale.LabelStyle = ProbabilityScale.ProbabilityLabelStyle.Percent
                    lProbScale.IsReverse = True
                End If
            End With
            With .X2Axis
                .IsVisible = False
            End With
            SetYaxisDefaults(.YAxis, aType)
            SetYaxisDefaults(.Y2Axis, aType)
            .YAxis.MinSpace = 80
            .Y2Axis.MinSpace = 20
            .Y2Axis.Scale.IsVisible = False 'Default to not labeling on Y2, will be turned on later if different from Y
            With .Legend
                .Position = LegendPos.Float
                .Location = New Location(0.05, 0.05, CoordType.ChartFraction, AlignH.Left, AlignV.Top)
                .IsHStack = False
                .Border.IsVisible = False
                .Fill.IsVisible = False
            End With
            .Border.IsVisible = False
        End With
    End Sub

    Private Sub SetYaxisDefaults(ByVal aYaxis As Axis, ByVal aType As String)
        With aYaxis
            If aType = "T" Then
                .Type = AxisType.Linear
            Else
                .Type = AxisType.Log
            End If
            .Title.IsOmitMag = True
            .MajorGrid.IsVisible = True
            .MajorTic.IsOutside = False
            .MajorTic.IsInside = True
            .MinorTic.IsOutside = False
            .MinorTic.IsInside = True
            .Scale.IsUseTenPower = False
            .Scale.FontSpec.IsBold = True
            .Scale.Mag = 0
            .Scale.Format = "#,##0.###"
            .Scale.Align = AlignP.Inside
            With .MajorGrid
                .Color = DefaultMajorGridColor
                .DashOn = 0
                .DashOff = 0
                .IsVisible = True
            End With
            With .MinorGrid
                .Color = DefaultMinorGridColor
                .DashOn = 0
                .DashOff = 0
                .IsVisible = True
            End With
            .Title.Text = "Annual Peak Discharge (cfs)"
            If aType = "T" Then
                '.Title.Text = "Discharge (cfs)"
                .Title.FontSpec.Size = 8
                .Scale.FontSpec.Size = 8
            Else
                '.Title.Text = "Annual Peak Discharge (cfs)"
                .Title.FontSpec.Size = 12
                .Scale.FontSpec.Size = 12
            End If
        End With
    End Sub

    ''' <summary>
    ''' Determines an appropriate scale based on the minimum and maximum values and 
    ''' whether an arithmetic or logarithmic scale is requested. 
    ''' For log scales, the minimum and maximum must not be transformed.
    ''' </summary>
    ''' <param name="aDataMin"></param>
    ''' <param name="aDataMax"></param>
    ''' <param name="aLogScale"></param>
    ''' <param name="aScaleMin"></param>
    ''' <param name="aScaleMax"></param>
    ''' <remarks></remarks>
    Public Sub Scalit(ByVal aDataMin As Double, ByVal aDataMax As Double, ByVal aLogScale As Boolean, _
                      ByRef aScaleMin As Double, ByRef aScaleMax As Double)
        'TODO: should existing ScaleMin and ScaleMax be respected?
        If Not aLogScale Then 'arithmetic scale
            'get next lowest mult of 10
            Static lRange(15) As Double
            If lRange(1) < 0.09 Then 'need to initialze
                lRange(1) = 0.1
                lRange(2) = 0.15
                lRange(3) = 0.2
                lRange(4) = 0.4
                lRange(5) = 0.5
                lRange(6) = 0.6
                lRange(7) = 0.8
                lRange(8) = 1.0#
                lRange(9) = 1.5
                lRange(10) = 2.0#
                lRange(11) = 4.0#
                lRange(12) = 5.0#
                lRange(13) = 6.0#
                lRange(14) = 8.0#
                lRange(15) = 10.0#
            End If

            Dim lRangeIndex As Integer
            Dim lRangeInc As Integer
            Dim lDataRndlow As Double = Rndlow(aDataMax)
            If lDataRndlow > 0.0# Then
                lRangeInc = 1
                lRangeIndex = 1
            Else
                lRangeInc = -1
                lRangeIndex = 15
            End If
            Do
                aScaleMax = lRange(lRangeIndex) * lDataRndlow
                lRangeIndex += lRangeInc
            Loop While aDataMax > aScaleMax And lRangeIndex <= 15 And lRangeIndex >= 1

            If aDataMin < 0.5 * aDataMax And aDataMin >= 0.0# And aDataMin = 1 Then
                aScaleMin = 0.0#
            Else 'get next lowest mult of 10
                lDataRndlow = Rndlow(aDataMin)
                If lDataRndlow >= 0.0# Then
                    lRangeInc = -1
                    lRangeIndex = 15
                Else
                    lRangeInc = 1
                    lRangeIndex = 1
                End If
                Do
                    aScaleMin = lRange(lRangeIndex) * lDataRndlow
                    lRangeIndex += lRangeInc
                Loop While aDataMin < aScaleMin And lRangeIndex >= 1 And lRangeIndex <= 15
            End If
        Else 'logarithmic scale
            Dim lLogMin As Integer
            If aDataMin > 0.000000001 Then
                lLogMin = Fix(Math.Log10(aDataMin))
            Else
                'too small or neg value, set to -9
                lLogMin = -9
            End If
            If aDataMin < 1.0# Then
                lLogMin -= 1
            End If
            aScaleMin = 10.0# ^ lLogMin

            Dim lLogMax As Integer
            If aDataMax > 0.000000001 Then
                lLogMax = Fix(Math.Log10(aDataMax))
            Else
                'too small or neg value, set to -8
                lLogMax = -8
            End If
            If aDataMax > 1.0# Then
                lLogMax += 1
            End If
            aScaleMax = 10.0# ^ lLogMax

            If aScaleMin * 10000000.0# < aScaleMax Then
                'limit range to 7 cycles
                aScaleMin = aScaleMax / 10000000.0
            End If
        End If
    End Sub

    Public Sub GenFrequencyGraph(ByVal aStnInd As Integer, Optional ByVal aToFile As Boolean = False)
        Dim newform As New atcGraph.atcGraphForm
        Dim lCurve As LineItem = Nothing
        Dim i As Integer
        Dim j As Integer
        Dim lNPkPlt As Integer
        Dim lPkLog(499) As Single
        Dim lSysPP(499) As Single
        Dim lWrcPP(499) As Single
        Dim lIQual(499, 4) As Integer
        Dim lXQual(499) As String
        Dim lPkYear(499) As Integer
        Dim lThr(499) As Single
        Dim lPPTh(499) As Single
        Dim lNObsTh(499) As Integer
        Dim lThrSYr(499) As Integer
        Dim lThrEYr(499) As Integer
        Dim lNInt As Integer
        Dim lIntLwr(499) As Single
        Dim lIntUpr(499) As Single
        Dim lIntPPos(499) As Single
        Dim lIntYr(499) As Integer
        Dim lNT As Integer
        Dim lThrDef As Boolean
        Dim lWeiba As Single
        Dim lNPlot As Integer
        Dim lGBCrit As Single
        Dim lNLow As Integer
        Dim lNZero As Integer
        Dim lSkew As Single
        Dim lRMSegs As Single
        Dim lLOTestStr As String
        Dim lSysRFC(31) As Single
        Dim lWrcFC(31) As Single
        Dim lTxProb(31) As Single
        Dim lHistFlg As Integer
        Dim lCLimL(31) As Single
        Dim lCLimU(31) As Single
        Const lPP1 As Double = 0.002 '0.995 '-2.577
        Const lPP0 As Double = 0.995 '0.002 '2.879
        Dim lNPlot1 As Integer
        Dim lNPlot2 As Integer
        Dim lNPlCL1 As Integer
        Dim lNPlCL2 As Integer
        Dim lPMin As Double = 1.0E+20
        Dim lPMax As Double = -1.0E+20
        Dim lCurves As atcCollection
        Dim lThresh As Integer
        Dim lThrMinPk As Double
        Dim lKey As String
        Dim lX(0) As Double
        Dim lY(0) As Double
        Dim lX2(1) As Double
        Dim lY2(1) As Double
        Dim lIsInterval As Boolean = False
        Dim lColor As System.Drawing.Color
        'build threshold symbol
        Dim lThreshSymbol As New System.Drawing.Drawing2D.GraphicsPath
        Dim lSize As Single = 0.5
        lThreshSymbol.AddLine(0, 0, lSize, -2 * lSize)
        lThreshSymbol.AddLine(lSize, -2 * lSize, -lSize, -2 * lSize)
        lThreshSymbol.AddLine(-lSize, -2 * lSize, 0, 0)
        lThreshSymbol.StartFigure()
        lThreshSymbol.AddLine(-lSize, 0, lSize, 0)
        Dim lThreshSymbolDown As New System.Drawing.Drawing2D.GraphicsPath
        lThreshSymbolDown.AddLine(lSize, 0, lSize, 2 * lSize)
        lThreshSymbolDown.AddLine(lSize, 2 * lSize, 2 * lSize, 2 * lSize)
        lThreshSymbolDown.AddLine(2 * lSize, 2 * lSize, 0, 4 * lSize)
        lThreshSymbolDown.AddLine(0, 4 * lSize, -2 * lSize, 2 * lSize)
        lThreshSymbolDown.AddLine(-2 * lSize, 2 * lSize, -lSize, 2 * lSize)
        lThreshSymbolDown.AddLine(-lSize, 2 * lSize, -lSize, 0)
        lThreshSymbolDown.StartFigure()
        lThreshSymbolDown.AddLine(-3 * lSize, 0, 3 * lSize, 0)
        Dim lThreshSymbolUp As New System.Drawing.Drawing2D.GraphicsPath
        lThreshSymbolUp.AddLine(lSize, 0, lSize, -2 * lSize)
        lThreshSymbolUp.AddLine(lSize, -2 * lSize, 2 * lSize, -2 * lSize)
        lThreshSymbolUp.AddLine(2 * lSize, -2 * lSize, 0, -4 * lSize)
        lThreshSymbolUp.AddLine(0, -4 * lSize, -2 * lSize, -2 * lSize)
        lThreshSymbolUp.AddLine(-2 * lSize, -2 * lSize, -lSize, -2 * lSize)
        lThreshSymbolUp.AddLine(-lSize, -2 * lSize, -lSize, 0)
        lThreshSymbolUp.StartFigure()
        lThreshSymbolUp.AddLine(-3 * lSize, 0, 3 * lSize, 0)
        'build low outlier threshold
        Dim lLOThreshSymbol As New System.Drawing.Drawing2D.GraphicsPath
        lLOThreshSymbol.AddEllipse(-lSize, -lSize, 2 * lSize, 2 * lSize)
        lLOThreshSymbol.StartFigure()
        lLOThreshSymbol.AddLine(-2 * lSize, 0, 2 * lSize, 0)

        newform.Height = VB6.TwipsToPixelsY(9450)
        newform.Width = VB6.TwipsToPixelsX(13200)
        Dim lZGC As ZedGraphControl = newform.ZedGraphCtrl
        InitGraph(lZGC, "R")
        Dim lPane As GraphPane = lZGC.MasterPane.PaneList(0)
        Dim lYAxis As Axis = lPane.YAxis

        'for GETDATA, lStnInd is sequence index of stations that were run (i.e. not skipped)
        Dim lStnInd As Integer = aStnInd + 1
        Dim lHeader As String = " ".PadLeft(80)
        Call GETDATA(lStnInd, lNPkPlt, lPkLog, lSysPP, lWrcPP, lIQual, lPkYear, _
                     lWeiba, lNPlot, lSysRFC, lWrcFC, lTxProb, lHistFlg, _
                     lCLimL, lCLimU, lNT, lThr, lPPTh, lNObsTh, _
                     lThrSYr, lThrEYr, lNInt, lIntLwr, lIntUpr, lIntPPos, _
                     lIntYr, lGBCrit, lNLow, lNZero, lSkew, lRMSegs, _
                     lHeader, lHeader.Length)
        NumChr(5, 200, lIQual, lXQual)

        If lGBCrit > 0 Then lGBCrit = 10 ^ lGBCrit 'convert low outlier threshold from log to base 10

        If lstGraphs.Items.Count > 0 Then
            'for project stations, need overall station index found in lstGraph Items
            lStnInd = lstGraphs.Items(aStnInd).index - 1
        Else 'calling from batch mode (RunTests), so no items in lstGraphs
            lStnInd = aStnInd
        End If
        If PfqPrj.Stations(lStnInd).Thresholds.Count = 0 Then 'no threshold specified, use default from PeakFQ 
            lThrDef = True
        Else
            lThrDef = False
        End If

        lNPlot1 = 0
        lNPlot2 = lNPlot - 1
        For i = 0 To lNPlot - 1
            If lTxProb(i) < lPP0 Then lNPlot2 = i
            j = lNPlot - i - 1 '+ 1 - i
            If lTxProb(j) > lPP1 AndAlso lWrcFC(j) > -1.0 Then lNPlot1 = j
        Next
        'save start/end plot positions for CLs
        lNPlCL1 = lNPlot1
        lNPlCL2 = lNPlot2

        'WRC frequency
        Dim lYVals(lNPlot2 - lNPlot1) As Double
        Dim lXVals(lNPlot2 - lNPlot1) As Double
        For i = lNPlot1 To lNPlot2
            j = i - lNPlot1
            If lWrcFC(i) >= 29.0 Then 'problem with this value
                lYVals(j) = 0.0
            Else
                lYVals(j) = 10 ^ lWrcFC(i)
                If lYVals(j) > lPMax Then lPMax = lYVals(j)
                If lYVals(j) < lPMin Then lPMin = lYVals(j)
            End If
            lXVals(j) = lTxProb(i)
        Next
        lYAxis.IsVisible = True
        lYAxis.Scale.IsVisible = True
        lCurve = lPane.AddCurve("Fitted frequency", lXVals, lYVals, Color.Red, SymbolType.None)
        lCurve.Line.Width = 2

        'LO Threshold
        If lGBCrit > -99 Then
            lX2(0) = 1.0
            lX2(1) = lTxProb(1)
            lY2(0) = lGBCrit
            lY2(1) = lGBCrit
            lCurve = lPane.AddCurve("PILF (LO) Threshold", lX2, lY2, Color.Black, SymbolType.None)
            lCurve.Line.Width = 2
        End If

        'observed peaks
        lCurves = New atcCollection
        ReDim lYVals(lNPkPlt - 1), lXVals(lNPkPlt - 1)
        For i = 0 To lNPkPlt - 1
            lIsInterval = False
            lYVals(i) = 10 ^ lPkLog(i)
            If lYVals(i) > 0.001 AndAlso lYVals(i) < 10000000000.0 Then
                If lYVals(i) > lPMax Then lPMax = lYVals(i)
                If lYVals(i) < lPMin Then lPMin = lYVals(i)
                If lHistFlg = 0 Then
                    lXVals(i) = lWrcPP(i)
                Else
                    lXVals(i) = lSysPP(i)
                End If
                lThresh = -1
                For j = 0 To lNT - 1
                    If Math.Abs(lPkYear(i)) >= lThrSYr(j) AndAlso Math.Abs(lPkYear(i)) <= lThrEYr(j) Then 'peak is in a threshold
                        lThresh = j
                        If j > 0 Then Exit For 'don't exit loop if this is the default (0th) threshold
                    End If
                Next
                For j = 0 To lNInt - 1
                    If Math.Abs(lPkYear(i)) = lIntYr(j) Then 'this year is a flow interval, don't plot a point
                        lIsInterval = True
                        Exit For
                    End If
                Next
                If Not lIsInterval Then
                    'If Math.Abs(lYVals(i) - lGBCrit) < 0.1 Then
                    '    lKey = "LO Threshold"
                    'ElseIf lYVals(i) > lGBCrit Then 'above low outlier threshold
                    If (lYVals(i) - lGBCrit) > -0.01 Then 'above low outlier threshold
                        lKey = lXQual(i)
                        If lKey.Length > 0 Then
                            If lKey <> "H" AndAlso lKey <> "7" AndAlso lThresh >= 0 Then lKey &= CStr(lPPTh(lThresh)) ' CStr(lThresh)
                        End If
                    Else
                        lKey = "Low Outlier"
                    End If
                    'If lKey = "LO Threshold" AndAlso lCurves.Keys.Contains(lKey) Then
                    '    'don't want duplicates for LO Threshold, set this to normal peak
                    '    Dim lProb As Double = lCurves.ItemByKey(lKey).points(0).x
                    '    If lXVals(i) > lProb Then 'make leftmost LO the indicator
                    '        lCurves.ItemByKey(lKey).points(0).x = lXVals(i)
                    '        lXVals(i) = lProb
                    '    End If
                    '    lKey = lXQual(i) & CStr(lThresh)
                    'End If
                    If lCurves.Keys.Contains(lKey) Then 'add point to this curve
                        lCurve = lCurves.ItemByKey(lKey)
                        lCurve.AddPoint(lXVals(i), lYVals(i))
                    Else 'need a new curve
                        If lThresh = 0 Then 'use specific color for default threshold
                            lColor = Color.DarkCyan
                        ElseIf lThresh > 0 Then 'match color of threshold
                            lColor = ThreshColors(lThresh)
                        Else
                            lColor = Color.Black
                        End If
                        lX(0) = lXVals(i) 'lSysPP(i)
                        lY(0) = lYVals(i) '10 ^ lPkLog(i)
                        'If Math.Abs(lY(0) - lGBCrit) < 0.1 Then 'this is the low outlier threshold
                        '    lX2(0) = 1.0
                        '    lX2(1) = lTxProb(1)
                        '    lY2(0) = lY(0)
                        '    lY2(1) = lY(0)
                        '    lCurve = lPane.AddCurve("PILF (LO) Threshold", lX2, lY2, Color.Black, SymbolType.None)
                        '    lCurve.Line.Width = 2
                        '    'lCurve.Symbol.UserSymbol = lLOThreshSymbol
                        '    'lCurve.Symbol.Fill.Type = FillType.Solid
                        '    'lCurve.Symbol.Size = 15
                        '    'lCurve = lPane.AddCurve("Low Outlier Threshold", lX, lY, Color.Red, SymbolType.Circle)
                        '    'lCurve.Label.IsVisible = False
                        'ElseIf lY(0) < lGBCrit Then
                        If lY(0) < lGBCrit Then
                            lCurve = lPane.AddCurve("PILF (LO)", lX, lY, Color.Black, SymbolType.Circle)
                            lCurve.Line.IsVisible = False
                        Else
                            If lXQual(i).Contains("7") Or lXQual(i).Contains("H") Then
                                lCurve = lPane.AddCurve("Historic Peaks", lX, lY, Color.Pink, SymbolType.Triangle)
                            ElseIf lXQual(i).Contains("K") Or lXQual(i).Contains("6") Or lXQual(i).Contains("C") Then
                                lCurve = lPane.AddCurve("Urban or Reg Peaks", lX, lY, lColor, SymbolType.Square)
                            ElseIf lXQual(i).Contains("D") Or lXQual(i).Contains("G") Or lXQual(i).Contains("X") Or _
                                   lXQual(i).Contains("3") Or lXQual(i).Contains("8") Or lXQual(i).Contains("3+8") Then
                                lCurve = lPane.AddCurve("Peaks Not Used", lX, lY, lColor, SymbolType.XCross)
                            ElseIf lXQual(i).Contains("L") Or lXQual(i).Contains("4") Then
                                lCurve = lPane.AddCurve("Peaks < Shown", lX, lY, lColor, SymbolType.Diamond)
                            Else
                                lCurve = lPane.AddCurve("Gaged Peaks", lX, lY, Color.Turquoise, SymbolType.Circle)
                            End If
                            lCurve.Symbol.Fill.Type = FillType.Solid
                            lCurve.Line.IsVisible = False
                        End If
                        lCurves.Add(lKey, lCurve)
                    End If
                End If
            End If
        Next

        'confidence limits
        ReDim lYVals(lNPlot2 - lNPlot1)
        ReDim lXVals(lNPlot2 - lNPlot1)
        For i = lNPlCL1 To lNPlCL2
            j = i - lNPlCL1
            If lCLimL(i) >= 29.0 Then 'problem with this value
                lYVals(j) = 0
            Else
                lYVals(j) = 10 ^ lCLimL(i)
                If lYVals(j) > lPMax Then lPMax = lYVals(j)
                If lYVals(j) < lPMin Then lPMin = lYVals(j)
            End If
            lXVals(j) = lTxProb(i)
        Next
        lCurve = lPane.AddCurve(CInt(100 * PfqPrj.ConfidenceLimits) & "% Confidence limits", lXVals, lYVals, Color.Blue, SymbolType.None)
        'lCurve.Line.Style = Drawing2D.DashStyle.Dot
        For i = lNPlCL1 To lNPlCL2
            j = i - lNPlCL1
            If lCLimU(i) >= 29.0 Then 'problem with this value
                lYVals(j) = 0
            Else
                lYVals(j) = 10 ^ lCLimU(i)
                If lYVals(j) > lPMax Then lPMax = lYVals(j)
                If lYVals(j) < lPMin Then lPMin = lYVals(j)
            End If
            lXVals(j) = lTxProb(i)
        Next
        lCurve = lPane.AddCurve("Confidence Limits", lXVals, lYVals, Color.Blue, SymbolType.None)
        lCurve.Label.IsVisible = False
        'lCurve.Line.Style = Drawing2D.DashStyle.Dot

        'set y-axis range
        Scalit(lPMin, lPMax, True, lPane.YAxis.Scale.Min, lPane.YAxis.Scale.Max)
        lPane.YAxis.Scale.MinAuto = False
        lPane.YAxis.Scale.MaxAuto = False

        'plot any interval data
        For i = 0 To lNInt - 1
            lX2(0) = lIntPPos(i)
            lX2(1) = lIntPPos(i)
            'lY2(0) = lIntLwr(i)
            If lIntLwr(i) < lPMin Then ' lYAxis.Scale.Min Then
                lY2(0) = lYAxis.Scale.Min 'lPMin ' lYAxis.Scale.Min
            Else
                lY2(0) = lIntLwr(i)
            End If
            lY2(1) = lIntUpr(i)
            If lY2(1) > lPMax AndAlso lY2(1) < 1000000000.0 Then lPMax = lY2(1)
            lCurve = lPane.AddCurve("Interval Flood Estimate", lX2, lY2, Color.Turquoise, SymbolType.HDash)
            If i > 0 Then
                lCurve.Label.IsVisible = False
            End If
        Next

        'thresholds
        Dim lAddGlyph As Boolean
        For i = 0 To lNT - 1
            If lNObsTh(i) > 0 AndAlso lPPTh(i) > 0 AndAlso lPPTh(i) < 1.0 Then
                lX(0) = lPPTh(i)
                lY(0) = lThr(i)
                'add dummy curve to create regular-sized legend symbol
                lAddGlyph = True 'assume we're adding glyph, but check for repeats
                For j = 0 To i - 1
                    If Math.Abs(lThr(i) - lThr(j)) < 0.001 AndAlso lNObsTh(i) = lNObsTh(j) Then
                        lAddGlyph = False
                        For k As Integer = lPane.CurveList.Count - 1 To 0 Step -1
                            If lPane.CurveList(k).Label.Text.Contains(lThrSYr(j).ToString) Then 'change specific date range to multiple spans
                                lPane.CurveList(k).Label.Text = "Threshold (multiple periods)"
                            End If
                        Next
                        Exit For
                    End If
                Next
                If lAddGlyph Then
                    Dim lPtList As New ZedGraph.PointPairList
                    If lThrDef Then
                        lCurve = lPane.AddCurve("Default Threshold (" & CStr(lThrSYr(i)) & "-" & CStr(lThrEYr(i)) & ")", lPtList, ThreshColors(i), SymbolType.UserDefined)
                    Else
                        lCurve = lPane.AddCurve(lNObsTh(i) & "Censored Peaks (" & CStr(lThrSYr(i)) & "-" & CStr(lThrEYr(i)) & ")", lPtList, ThreshColors(i), SymbolType.UserDefined)
                    End If
                    lCurve.Symbol.UserSymbol = lThreshSymbolDown
                    lCurve.Symbol.Size = 5
                    If lY(0) >= lGBCrit Then lCurve.Symbol.Fill.Type = FillType.Solid
                    'lCurve.Symbol.Border.Width = 2
                    'lCurve.Line.IsVisible = False
                    'now plot symbol at appropriate scale
                    If lThrDef Then
                        lCurve = lPane.AddCurve("Default Threshold (" & CStr(lThrSYr(i)) & "-" & CStr(lThrEYr(i)) & ")", lX, lY, ThreshColors(i), SymbolType.UserDefined)
                    Else
                        lCurve = lPane.AddCurve("Threshold (" & CStr(lThrSYr(i)) & "-" & CStr(lThrEYr(i)) & ")", lX, lY, ThreshColors(i), SymbolType.UserDefined)
                    End If
                    lCurve.Symbol.UserSymbol = lThreshSymbolDown
                    lCurve.Line.IsVisible = False
                    lCurve.Label.IsVisible = False
                    lCurve.Symbol.Size = 5 '7 * Math.Sqrt(lNObsTh(i))
                    If lY(0) >= lGBCrit Then lCurve.Symbol.Fill.Type = FillType.Solid
                    lCurve.Symbol.Border.Width = 2
                End If
            End If
        Next

        lPane.XAxis.Title.Text = "Annual Exceedance Probability, Percent" & vbCrLf & lHeader

        Dim lSkewOptionText As String
        If PfqPrj.Stations(lStnInd).SkewOpt = 0 Then
            lSkewOptionText = "Station"
        ElseIf PfqPrj.Stations(lStnInd).SkewOpt = 1 Then
            lSkewOptionText = "Weighted"
        ElseIf PfqPrj.Stations(lStnInd).SkewOpt = 2 Then
            lSkewOptionText = "Generalized"
        End If
        If PfqPrj.Stations(lStnInd).LowOutlier > 0 Then
            lLOTestStr = "Fixed at " & PfqPrj.Stations(lStnInd).LowOutlier
        ElseIf PfqPrj.Stations(lStnInd).LOTestType.StartsWith("Single") Then
            lLOTestStr = "Single Grubbs-Beck"
        Else
            lLOTestStr = "Multiple Grubbs-Beck"
        End If

        Dim lWarning As String = "Peakfq v 7.1 run " & System.DateTime.Now & vbCrLf & _
                                 PfqPrj.Stations(lStnInd).AnalysisOption & " using " & lSkewOptionText & " Skew option" & vbCrLf & _
                                 DoubleToString(CDbl(lSkew), , , , , 3) & " = Skew (G)" & vbCrLf
        If PfqPrj.Stations(lStnInd).SkewOpt = 1 Then
            lWarning &= lNZero & " Zeroes not displayed" & vbCrLf & _
                        lNLow & " Peaks below PILF (LO) Threshold " & vbCrLf & lLOTestStr
        Else
            lWarning &= DoubleToString(CDbl(lRMSegs), , , , , 3) & " = Mean Sq Error (MSE sub G)" & vbCrLf & _
                        lNZero & " Zeroes not displayed" & vbCrLf & _
                        lNLow & " Peaks below PILF (LO) Threshold " & vbCrLf & lLOTestStr
        End If
        Dim lText As New TextObj(lWarning, 0.6, 0.68)
        lText.Location.CoordinateFrame = CoordType.PaneFraction
        lText.FontSpec.StringAlignment = StringAlignment.Near
        lText.FontSpec.IsBold = True
        lText.FontSpec.Size = 12
        lText.FontSpec.Border.IsVisible = False
        lText.FontSpec.Fill.IsVisible = False
        lText.Location.AlignH = AlignH.Left
        lText.Location.AlignV = AlignV.Top
        lPane.GraphObjList.Add(lText)

        If aToFile Then 'save plot to file
            lZGC.MasterPane.PaneList(0).Rect = New System.Drawing.Rectangle( _
                    0, 0, _
                    lZGC.Width, lZGC.Height)
            lZGC.AxisChange()
            lZGC.Invalidate()
            lZGC.Refresh()
            lZGC.SaveIn(PfqPrj.OutputDir & "\" & PfqPrj.Stations(aStnInd).PlotName & "." & PfqPrj.GraphFormat)
        Else 'display plot on form
            lZGC.AxisChange()
            lZGC.Invalidate()
            lZGC.Refresh()
            newform.Show()
        End If

    End Sub

    Public Sub NumChr(ByRef aSLen As Integer, ByRef aArrayLen As Integer, ByRef aIntStr(,) As Integer, ByRef aStr() As String)
        Dim lStr As String
        For lArrayInd As Integer = 0 To aArrayLen - 1
            lStr = ""
            For lInd As Integer = 0 To aSLen - 1 'added "- 1" 8/16/2002 Mark Gray
                If aIntStr(lArrayInd, lInd) > 0 Then
                    lStr &= Chr(aIntStr(lArrayInd, lInd))
                End If
            Next lInd
            aStr(lArrayInd) = Trim(lStr)
        Next lArrayInd
    End Sub

    Private Sub zgcThresh_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles zgcThresh.MouseClick
        With zgcThresh.MasterPane.PaneList(0).Legend 'pPane.Legend
            .Position = LegendPos.Float
            .Location = New Location((e.X - zgcThresh.MasterPane.Rect.Left) / zgcThresh.Width, _
                                     (e.Y - zgcThresh.MasterPane.Rect.Top) / zgcThresh.MasterPane.Rect.Height, _
                                     CoordType.PaneFraction)
            .IsVisible = True
        End With
        zgcThresh.Refresh()

    End Sub

    Private Sub zgcThresh_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles zgcThresh.Paint
        zgcThresh.MasterPane.ReSize(e.Graphics)
    End Sub

    Private Sub cboAnalysisOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAnalysisOption.SelectedIndexChanged
        Dim lstr As String = cboAnalysisOption.Text
        With grdSpecs.Source
            For i As Integer = .FixedRows To .Rows - 1
                .CellValue(i, 1) = lstr
                If lstr = "EMA" Then
                    'force use of historic period
                    .CellValue(i, 5) = "Yes"
                    'set to Multiple G-B test
                    .CellValue(i, 12) = "Multiple"
                    'don't allow editing of hi-outlier field
                    .CellEditable(i, 14) = False
                    .CellColor(i, 14) = SystemColors.ControlDark
                Else
                    'allow editing of hi-outlier field
                    .CellEditable(i, 14) = True
                    .CellColor(i, 14) = Color.White
                End If
            Next
        End With
        'post population settings
        grdSpecs.Refresh()
    End Sub

    Private Sub grdThresh_CellEdited(ByVal aGrid As atcControls.atcGrid, ByVal aRow As Integer, ByVal aColumn As Integer) Handles grdThresh.CellEdited
        With aGrid.Source
            Dim lVal As String = .CellValue(aRow, aColumn)
            Dim lGoodRow As Boolean = True
            If aColumn < .Columns - 1 Then
                'check for case of 'inf' entered for threshold value
                If IsNumeric(lVal) OrElse (aColumn > 1 AndAlso lVal.ToLower = "inf") Then 'set to this threshold's color
                    If IsNumeric(lVal) AndAlso CDbl(lVal) > 1.0E+19 Then .CellValue(aRow, aColumn) = "inf"
                    .CellColor(aRow, aColumn) = ThreshColors(aRow - .FixedRows)
                Else 'reminder that values should be numeric
                    MessageBox.Show("All fields (except Comment) for Perception Thresholds must be numeric.", "Perception Threshold Problem")
                    .CellColor(aRow, aColumn) = Color.White
                End If
            Else 'check for text entry in last column
                If lVal.Length > 0 Then 'set to this threshold's color
                    .CellColor(aRow, aColumn) = ThreshColors(aRow - .FixedRows)
                Else 'reminder that comment entry needs to be made
                    MessageBox.Show("Comment field must be entered for Perception Thresholds.", "Perception Threshold Problem")
                    .CellColor(aRow, aColumn) = Color.White
                End If
            End If
            For i As Integer = 0 To .Columns - 2
                If Not IsNumeric(.CellValue(aRow, i)) Then
                    If i < 2 OrElse .CellValue(aRow, i) Is Nothing OrElse .CellValue(aRow, i).ToLower <> "inf" Then
                        'not 'inf' entered for threshold value
                        lGoodRow = False
                        Exit For
                    End If
                End If
            Next
            If IsNothing(.CellValue(aRow, .Columns - 1)) OrElse .CellValue(aRow, .Columns - 1).Length = 0 Then lGoodRow = False
            If lGoodRow Then
                For i As Integer = .FixedRows To .Rows - 2
                    If .CellValue(aRow, 2) = .CellValue(i, 2) AndAlso .CellValue(aRow, 3) = .CellValue(i, 3) Then 'this threshold same as previous, set to same color
                        For j As Integer = 0 To .Columns - 1
                            .CellColor(aRow, j) = .CellColor(i, j)
                        Next
                        grdThresh.Refresh()
                        Exit For
                    End If
                Next
                If aRow = .Rows - 1 Then 'add another blank row
                    AddThreshRow()
                ElseIf aRow = .FixedRows Then 'default thresh, check whether or not to color it
                    Dim lColor As System.Drawing.Color
                    If .CellValue(aRow, 2) = "0" AndAlso .CellValue(aRow, 3) = "inf" Then 'defaults, set to white
                        lColor = Color.White
                    Else
                        lColor = ThreshColors(0)
                    End If
                    For i As Integer = 0 To .Columns - 1
                        .CellColor(aRow, i) = lColor
                    Next
                    grdThresh.Refresh()
                End If
                ProcessThresholds()
                UpdateInputGraph()
            End If
        End With
    End Sub

    Private Sub grdInterval_CellEdited(ByVal aGrid As atcControls.atcGrid, ByVal aRow As Integer, ByVal aColumn As Integer) Handles grdInterval.CellEdited
        With aGrid.Source
            Dim lVal As String = .CellValue(aRow, aColumn)
            Dim lGoodRow As Boolean = False
            If aColumn = .Columns - 1 AndAlso lVal.Length = 0 Then
                MessageBox.Show("Comment field must be entered for new Data elements.", "Data Grid Problem")
            ElseIf aColumn < .Columns - 1 And aColumn <> 2 Then
                If Not IsNumeric(lVal) AndAlso Not lVal.ToLower.Contains("inf") Then 'reminder that values should be numeric
                    MessageBox.Show("Values for this field must be numeric.", "Data Grid Problem")
                End If
                If IsNumeric(lVal) AndAlso Double.Parse(lVal) > 1.0E+19 Then
                    .CellValue(aRow, aColumn) = "inf"
                End If
            End If
            If IsNumeric(.CellValue(aRow, 0)) Then 'valid year entered
                If IsNumeric(.CellValue(aRow, 1)) AndAlso _
                   (Not .CellValue(aRow, 5) Is Nothing AndAlso .CellValue(aRow, 5).Length > 0) Then 'valid peak value entry
                    lGoodRow = True
                End If
                If IsNumeric(.CellValue(aRow, 3)) And IsNumeric(.CellValue(aRow, 4)) Then 'some interval data entered, check it
                    If IsNumeric(.CellValue(aRow, 0)) AndAlso _
                       (IsNumeric(.CellValue(aRow, 3)) OrElse .CellValue(aRow, 3).ToLower.Contains("inf")) AndAlso _
                       (IsNumeric(.CellValue(aRow, 4)) OrElse .CellValue(aRow, 4).ToLower.Contains("inf")) AndAlso _
                       (Not .CellValue(aRow, 5) Is Nothing AndAlso .CellValue(aRow, 5).Length > 0) Then 'valid interval value entry
                        lGoodRow = True
                    Else
                        lGoodRow = False
                    End If
                End If
            End If
            If lGoodRow Then
                ProcessThresholds()
                UpdateInputGraph()
                If aRow = .Rows - 1 Then
                    AddIntervalRow()
                End If
            End If
        End With
    End Sub

    Private Sub AddThreshRow()
        With grdThresh.Source
            .Rows += 1
            For i As Integer = 0 To .Columns - 1
                .CellEditable(.Rows - 1, i) = True
                If i = .Columns - 1 Then
                    .Alignment(.Rows - 1, i) = atcAlignment.HAlignLeft
                Else
                    .Alignment(.Rows - 1, i) = atcAlignment.HAlignRight
                End If
                If i = 3 Then 'default high threshold value and assign threshold color
                    .CellValue(.Rows - 1, i) = "inf" '"1.0e20"
                    .CellColor(.Rows - 1, i) = ThreshColors(.Rows - .FixedRows - 1)
                End If
            Next
        End With
    End Sub

    Private Sub AddIntervalRow()
        With grdInterval.Source
            .Rows += 1
            For i As Integer = 0 To .Columns - 1
                .CellEditable(.Rows - 1, i) = True
                If i = 2 Or i = .Columns - 1 Then
                    .Alignment(.Rows - 1, i) = atcAlignment.HAlignLeft
                Else
                    .Alignment(.Rows - 1, i) = atcAlignment.HAlignRight
                End If
            Next
        End With
    End Sub

    Private Sub cboLOTest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLOTest.SelectedIndexChanged
        Dim lStr As String = cboLOTest.SelectedItem
        With grdSpecs.Source
            For i As Integer = .FixedRows To .Rows - 1
                .CellValue(i, 12) = lStr
            Next
        End With
        grdSpecs.Refresh()
    End Sub

    Private Sub chkExport_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkExport.CheckStateChanged
        If chkExport.CheckState = CheckState.Checked Then
            lblExportFile.Visible = True
            cmdOpenExport.Visible = True
            If Len(PfqPrj.ExportFileName) = 0 Then 'set default
                lblExportFile.Text = IO.Path.ChangeExtension(PfqPrj.OutFile, ".exp")
            End If
        Else
            lblExportFile.Visible = False
            cmdOpenExport.Visible = False
        End If
    End Sub

    Private Sub chkEmpirical_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEmpirical.CheckStateChanged
        If chkEmpirical.CheckState = CheckState.Checked Then
            lblEmpirical.Visible = True
            cmdOpenEmpirical.Visible = True
            If Len(PfqPrj.EmpiricalFileName) = 0 Then 'set default
                lblEmpirical.Text = IO.Path.ChangeExtension(PfqPrj.OutFile, ".emp")
            End If
        Else
            lblEmpirical.Visible = False
            cmdOpenEmpirical.Visible = False
        End If
    End Sub

    Private Sub cmdOpenExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOpenExport.Click

        cdlOpenSave.Title = "PeakFQ Export File"
        cdlOpenSave.Filter = "PeakFQ Export (*.exp)|*.exp|All Files (*.*)|*.*"
        cdlOpenSave.OverwritePrompt = False
        If Len(PfqPrj.ExportFileName) = 0 Then 'provide default file name
            PfqPrj.ExportFileName = IO.Path.ChangeExtension(PfqPrj.DataFileName, ".exp")
        End If
        cdlOpenSave.FileName = PfqPrj.ExportFileName
        cdlOpenSave.ShowDialog()
        If FileExists(cdlOpenSave.FileName) Then 'make sure it's OK to overwrite
            If MsgBox("File exists.  Do you want to overwrite it?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo FileCancel
        End If
        lblExportFile.Text = cdlOpenSave.FileName

FileCancel:
    End Sub

    Private Sub cmdOpenEmpirical_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOpenEmpirical.Click

        cdlOpenSave.Title = "Empirical Frequency Curve Table File"
        cdlOpenSave.Filter = "PeakFQ Empirical Frequency Curve (*.emp)|*.exp|All Files (*.*)|*.*"
        cdlOpenSave.OverwritePrompt = False
        If Len(PfqPrj.EmpiricalFileName) = 0 Then 'provide default file name
            PfqPrj.EmpiricalFileName = IO.Path.ChangeExtension(PfqPrj.DataFileName, ".emp")
        End If
        cdlOpenSave.FileName = PfqPrj.EmpiricalFileName
        cdlOpenSave.ShowDialog()
        If FileExists(cdlOpenSave.FileName) Then 'make sure it's OK to overwrite
            If MsgBox("File exists.  Do you want to overwrite it?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo FileCancel
        End If
        lblEmpirical.Text = cdlOpenSave.FileName

FileCancel:
    End Sub

    Private Sub cmdExportFileView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportFileView.Click

        If lblExportFileView.Text.Length > 0 And lblExportFileView.Text <> "(none)" Then
            System.Diagnostics.Process.Start("notepad.exe", lblExportFileView.Text)
        Else
            MsgBox("No Export file is available for viewing.", MsgBoxStyle.Information, "PeakFQ")
        End If
    End Sub

    Private Sub cmdEmpiricalFileView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEmpiricalFileView.Click

        If lblEmpiricalFileView.Text.Length > 0 And lblEmpiricalFileView.Text <> "(none)" Then
            System.Diagnostics.Process.Start("notepad.exe", lblEmpiricalFileView.Text)
        Else
            MsgBox("No Empirical Frequency Curve file is available for viewing.", MsgBoxStyle.Information, "PeakFQ")
        End If
    End Sub

    Private Sub spltInputViewTab_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles spltInputViewTab.MouseUp
        With grdThresh.Source
            For i As Integer = 0 To .Columns - 1
                grdThresh.SizeColumnToString(i, .CellValue(0, i))
            Next
        End With
        With grdInterval.Source
            For i As Integer = 0 To .Columns - 1
                grdInterval.SizeColumnToString(i, .CellValue(0, i))
            Next
            grdInterval.SizeColumnToString(1, .CellValue(0, 1) & .CellValue(0, 1))
        End With

    End Sub

    Public Sub RunTests(ByVal aInputPath As String, ByVal aOutputPath As String)
        Dim lDataFiles As New System.Collections.Specialized.NameValueCollection
        Dim lSpecFileContents As String
        Dim lSpecFileName As String

        AddFilesInDir(lDataFiles, aInputPath, False, "*.psf")
        ChDir(aInputPath)
        For Each lFile As String In lDataFiles
            PfqPrj = New pfqProject
            PfqPrj.InputDir = aInputPath
            PfqPrj.OutputDir = aOutputPath
            lSpecFileContents = WholeFileString(lFile)
            lSpecFileName = PathNameOnly(lFile) & "\" & tmpSpecName
            'build default project from initial version of spec file
            SaveFileString(lSpecFileName, lSpecFileContents)
            PfqPrj.SpecFileName = lSpecFileName 'make working verbose copy
            If FileExists(PfqPrj.DataFileName) AndAlso PfqPrj.Stations.Count > 0 Then
                '                DefPfqPrj = PfqPrj.SaveDefaults(lSpecFileContents)
                'PfqPrj.SpecFileName = lFile
                PfqPrj.OutFile = RelativeFilename(aOutputPath & "\" & FilenameNoPath(PfqPrj.OutFile), PathNameOnly(PfqPrj.SpecFileName))
                If PfqPrj.AddOutFileName.Length > 0 Then PfqPrj.AddOutFileName = RelativeFilename(aOutputPath & "\" & FilenameNoPath(PfqPrj.AddOutFileName), PathNameOnly(PfqPrj.SpecFileName))
                If PfqPrj.ExportFileName.Length > 0 Then PfqPrj.ExportFileName = RelativeFilename(aOutputPath & "\" & FilenameNoPath(PfqPrj.ExportFileName), PathNameOnly(PfqPrj.SpecFileName))
                If PfqPrj.EmpiricalFileName.Length > 0 Then PfqPrj.EmpiricalFileName = RelativeFilename(aOutputPath & "\" & FilenameNoPath(PfqPrj.EmpiricalFileName), PathNameOnly(PfqPrj.SpecFileName))
                PfqPrj.ReadPeaks()
                lSpecFileContents = PfqPrj.SaveAsString()
                'lSpecFileName = aInputPath & "\" & FilenameNoPath(lFile)
                'SaveFileString(lSpecFileName, lSpecFileContents)
                SaveFileString(lSpecFileName, lSpecFileContents)
                PfqPrj.SpecFileName = lSpecFileName
                PfqPrj.RunBatchModel()
                If PfqPrj.Graphic Then 'save graph to file
                    For i As Integer = 0 To PfqPrj.Stations.Count - 1
                        GenFrequencyGraph(i, True)
                    Next
                End If
                Kill("error.fil")
            End If
            Application.DoEvents()

        Next
        MsgBox("Finished running PeakFQ runs from directory " & aInputPath)
    End Sub

    Private Sub cmdCodeLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCodeLookup.Click
        frmCodeLookup.Show()
    End Sub

    Private Sub cmdLogReal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogReal.Click
        If cmdLogReal.Text = "Log" Then
            cmdLogReal.Text = "Real"
        Else
            cmdLogReal.Text = "Log"
        End If
        UpdateInputGraph()
    End Sub
End Class
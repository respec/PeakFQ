Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports atcUtility
Imports atcControls
Imports MapWinUtility
Imports System.Drawing.SystemColors
Imports ZedGraph

Friend Class frmPeakfq
    Inherits System.Windows.Forms.Form

    Friend DefaultMajorGridColor As Color = Color.FromArgb(255, 225, 225, 225)
    Friend DefaultMinorGridColor As Color = Color.FromArgb(255, 245, 245, 245)

    Dim DefaultSpecFile As String
    Const tmpSpecName As String = "PKFQWPSF.TMP"
    Dim CurGraphName As String
    Dim RemoveBMPs As Boolean
    Dim CurStationIndex As Integer = -1
    Dim CurThreshRow As Integer = 0
    Dim CurIntervalRow As Integer = 0

    Dim pLastClickedRow As Integer

    'UPGRADE_WARNING: Event chkAddOut.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkAddOut_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAddOut.CheckStateChanged
        Dim Index As Short = chkAddOut.GetIndex(eventSender)
        If Index = 1 Then 'text file additional output
            If chkAddOut(1).CheckState = System.Windows.Forms.CheckState.Checked Then
                'expand frame to show additional output file and button to edit it
                'fraAddOut.Height = VB6.TwipsToPixelsY(1575)
                If Len(PfqPrj.AddOutFileName) = 0 Then 'set default
                    lblOutFile(1).Text = IO.Path.ChangeExtension(PfqPrj.OutFile, ".bcd")
                End If
                lblOutFile(1).Visible = TriState.True
                cmdOpenOut(1).Visible = TriState.True
                optAddFormat(0).Visible = TriState.True
                optAddFormat(1).Visible = TriState.True
            Else 'smaller frame is fine
                'fraAddOut.Height = VB6.TwipsToPixelsY(735)
                lblOutFile(1).Visible = TriState.False
                cmdOpenOut(1).Visible = TriState.False
                optAddFormat(0).Visible = TriState.False
                optAddFormat(1).Visible = TriState.False
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Call frmPeakfq_FormClosed(Me, New System.Windows.Forms.FormClosedEventArgs(CloseReason.None))
    End Sub

    Private Sub cmdGraph_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGraph.Click
        Dim i As Integer
        'Dim GraphName As String
        'Dim newform As frmGraph

        For i = 0 To lstGraphs.Items.Count - 1
            If lstGraphs.GetSelected(i) Then
                GenGraph(i)
                'GraphName = VB6.GetItemString(lstGraphs, i) & ".BMP"
                'If FileExists(GraphName) Then
                '    newform = New frmGraph
                '    newform.Height = VB6.TwipsToPixelsY(7600)
                '    newform.Width = VB6.TwipsToPixelsX(9700)
                '    newform.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
                '    newform.BackgroundImage = System.Drawing.Image.FromFile(GraphName)
                '    newform.Show()
                'Else
                '    MsgBox("No graph available for station " & VB6.GetItemString(lstGraphs, i) & "." & vbCrLf & "This station was likely skipped due to faulty data - see PeakFQ output file for details.", MsgBoxStyle.Exclamation, "PeakFQ")
                'End If
            End If
        Next i
    End Sub

    Private Sub PopulateGrid()

        Dim ipos, j, i, ilen, Ind As Integer
        Dim vSta As pfqStation = Nothing
        Dim lName As String

        With grdSpecs 'At this point, there should already be one instantiated with header rows
            .Enabled = True
            .BackColor = SystemColors.Control
        End With

        With grdSpecs.Source
            .ColorCells = True

            '.FixedRows = 2
            '.FixedColumns = 0

            .Rows = .FixedRows ' row counter progress, set to be started from the last fixed header row
            .Columns = 18 ' already know there are 18 columns
            For Each vSta In PfqPrj.Stations
                .Rows += 1
                .CellValue(.Rows - 1, 0) = vSta.id
                .CellEditable(.Rows - 1, 0) = False
                .Alignment(.Rows - 1, 0) = atcAlignment.HAlignRight
                'add stations to pull-down list on Threshold tab
                lName = vSta.id
                i = 0
                While cboStation.Items.Contains(lName)
                    i += 1
                    lName = vSta.id & "-" & i
                End While
                cboStation.Items.Add(lName)

                If vSta.Active Then
                    .CellValue(.Rows - 1, 1) = "Yes"
                Else
                    .CellValue(.Rows - 1, 1) = "No"
                End If
                .CellEditable(.Rows - 1, 1) = True

                .CellValue(.Rows - 1, 2) = vSta.BegYear
                .CellEditable(.Rows - 1, 2) = True
                .Alignment(.Rows - 1, 2) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 3) = vSta.EndYear
                .CellEditable(.Rows - 1, 3) = True
                .Alignment(.Rows - 1, 3) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 4) = vSta.HistoricPeriod
                .CellEditable(.Rows - 1, 4) = True
                .Alignment(.Rows - 1, 4) = atcAlignment.HAlignRight

                If vSta.SkewOpt = 0 Then
                    .CellValue(.Rows - 1, 5) = "Station"
                ElseIf vSta.SkewOpt = 1 Then
                    .CellValue(.Rows - 1, 5) = "Weighted"
                ElseIf vSta.SkewOpt = 2 Then
                    .CellValue(.Rows - 1, 5) = "Generalized"
                End If
                .CellEditable(.Rows - 1, 5) = True

                .CellValue(.Rows - 1, 6) = vSta.GenSkew
                .CellEditable(.Rows - 1, 6) = True
                .Alignment(.Rows - 1, 6) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 7) = vSta.SESkew
                .CellEditable(.Rows - 1, 7) = True
                .Alignment(.Rows - 1, 7) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 8) = DecimalAlign((vSta.SESkew ^ 2).ToString, , 4)
                .CellColor(.Rows - 1, 8) = SystemColors.ControlDark
                .CellEditable(.Rows - 1, 8) = False

                .CellValue(.Rows - 1, 9) = vSta.LowHistPeak
                .CellColor(.Rows - 1, 9) = SystemColors.ControlDark
                .CellEditable(.Rows - 1, 9) = False
                .Alignment(.Rows - 1, 9) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 10) = vSta.LowOutlier
                .CellEditable(.Rows - 1, 10) = True
                .Alignment(.Rows - 1, 10) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 11) = vSta.HighSysPeak
                .CellColor(.Rows - 1, 11) = SystemColors.ControlDark
                .CellEditable(.Rows - 1, 11) = False
                .Alignment(.Rows - 1, 11) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 12) = vSta.HighOutlier
                .CellEditable(.Rows - 1, 12) = True
                .Alignment(.Rows - 1, 12) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 13) = vSta.GageBaseDischarge
                .CellEditable(.Rows - 1, 13) = True
                .Alignment(.Rows - 1, 13) = atcAlignment.HAlignRight

                If vSta.UrbanRegPeaks Then
                    .CellValue(.Rows - 1, 14) = "Yes"
                Else
                    .CellValue(.Rows - 1, 14) = "No"
                End If
                .CellEditable(.Rows - 1, 14) = True

                .CellValue(.Rows - 1, 15) = vSta.Lat
                .CellEditable(.Rows - 1, 15) = True
                .Alignment(.Rows - 1, 15) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 16) = vSta.Lng
                .CellEditable(.Rows - 1, 16) = True
                .Alignment(.Rows - 1, 16) = atcAlignment.HAlignRight

                .CellValue(.Rows - 1, 17) = vSta.PlotName
                .CellEditable(.Rows - 1, 17) = True

                ilen = Len(vSta.PlotName)
                For j = .Rows - 2 To .FixedRows Step -1 'look for duplicate plot names and adjust as needed
                    If vSta.PlotName = Nothing Then

                    ElseIf VB.Left(.CellValue(j, 17), ilen) = vSta.PlotName Then 'duplicate found
                        ipos = InStr(.CellValue(j, 17), "-")
                        If ipos > 0 Then 'not first duplicate, increase index number
                            Dim larr() As String = .CellValue(.Rows - 1, 17).Split("-")
                            Dim lastInd As Integer = Integer.Parse(larr(larr.Length - 1))
                            Ind = lastInd
                            'Ind = CInt(Mid(.CellValue(j, 17), ipos + 1))
                            .CellValue(.Rows - 1, 17) = vSta.PlotName & "-" & CStr(Ind + 1)
                        Else 'first duplicate
                            .CellValue(.Rows - 1, 17) = vSta.PlotName & "-1"
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
        End With

    End Sub

    Private Sub ProcessGrid()

        Dim i As Integer
        Dim curSta As pfqStation

        'UPGRADE_NOTE: Object PfqPrj.Stations may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '        PfqPrj.Stations.Clear()
        '       PfqPrj.Stations = Nothing
        With grdSpecs.Source
            For i = .FixedRows To .Rows - 1
                curSta = PfqPrj.Stations.Item(i - .FixedRows) ' New pfqStation
                curSta.id = .CellValue(i, 0)
                If .CellValue(i, 1) = "Yes" Then
                    curSta.Active = True
                Else
                    curSta.Active = False
                End If
                If IsNumeric(.CellValue(i, 2)) Then curSta.BegYear = CInt(.CellValue(i, 2))
                If IsNumeric(.CellValue(i, 3)) Then curSta.EndYear = CInt(.CellValue(i, 3))
                If IsNumeric(.CellValue(i, 4)) Then curSta.HistoricPeriod = CSng(.CellValue(i, 4))
                If .CellValue(i, 5) = "Station" Then
                    curSta.SkewOpt = 0
                ElseIf .CellValue(i, 5) = "Weighted" Then
                    curSta.SkewOpt = 1
                ElseIf .CellValue(i, 5) = "Generalized" Then
                    curSta.SkewOpt = 2
                End If
                If IsNumeric(.CellValue(i, 6)) Then curSta.GenSkew = CSng(.CellValue(i, 6))
                If IsNumeric(.CellValue(i, 7)) Then curSta.SESkew = CSng(.CellValue(i, 7))
                If IsNumeric(.CellValue(i, 10)) Then curSta.LowOutlier = CSng(.CellValue(i, 10))
                If IsNumeric(.CellValue(i, 12)) Then curSta.HighOutlier = CSng(.CellValue(i, 12))
                If IsNumeric(.CellValue(i, 13)) Then curSta.GageBaseDischarge = CSng(.CellValue(i, 13))
                If .CellValue(i, 14) = "Yes" Then
                    curSta.UrbanRegPeaks = True
                Else
                    curSta.UrbanRegPeaks = False
                End If
                If IsNumeric(.CellValue(i, 15)) Then curSta.Lat = CSng(.CellValue(i, 15))
                If IsNumeric(.CellValue(i, 16)) Then curSta.Lng = CSng(.CellValue(i, 16))
                curSta.PlotName = .CellValue(i, 17)
                'PfqPrj.Stations.Add(curSta)
            Next
        End With
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
            'fraAddOut.Height = VB6.TwipsToPixelsY(1575)
        Else
            chkAddOut(1).CheckState = System.Windows.Forms.CheckState.Unchecked
            lblOutFile(1).Text = "(none)"
            lblOutFile(1).Visible = TriState.False
            cmdOpenOut(1).Visible = TriState.False
            optAddFormat(0).Visible = TriState.False
            optAddFormat(1).Visible = TriState.False
            'fraAddOut.Height = VB6.TwipsToPixelsY(735)
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
            If optAddFormat(0).Checked = TriState.True Then
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

        If Len(PfqPrj.SpecFileName) > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            lstGraphs.Items.Clear()
            ProcessGrid()
            If CurStationIndex >= 0 Then ProcessThresholds()
            ProcessOutput()
            s = PfqPrj.SaveAsString
            SaveFileString((PfqPrj.SpecFileName), s)
            System.Windows.Forms.Application.DoEvents()
            PfqPrj.RunBatchModel()
            System.Windows.Forms.Application.DoEvents()
            If RemoveBMPs Then
                For i = 1 To lstGraphs.Items.Count
                    Kill(VB6.GetItemString(lstGraphs, i - 1) & ".BMP")
                Next i
            End If
            'If PfqPrj.Graphic Then
            SetGraphNames()
            cmdGraph.Enabled = True
            '    If UCase(PfqPrj.GraphFormat) <> "BMP" Then
            '        RemoveBMPs = True
            '    Else
            '        RemoveBMPs = False
            '    End If
            'Else
            '    lstGraphs.Items.Clear()
            '    cmdGraph.Enabled = False
            '    RemoveBMPs = False
            'End If
            Me.Cursor = System.Windows.Forms.Cursors.Default
            sstPfq.TabPages.Item(3).Enabled = True
            sstPfq.SelectedIndex = 3
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
        With grdSpecs
            .Source = New atcControls.atcGridSource
        End With
        With grdSpecs.Source
            .FixedRows = 2
            .Rows = 1
            '  grdSpecs.cols = 16
            .Columns = 18
            'For i = 0 To 17
            '    grdSpecs.set_ColEditable(i, False)
            'Next i
            .CellValue(1, 0) = "Station ID"
            'grdSpecs.set_ColType(0, ATCoCtl.ATCoDataType.ATCoTxt)
            .CellValue(0, 1) = "Include in"
            .CellValue(1, 1) = "Analysis?"
            'grdSpecs.set_ColType(1, ATCoCtl.ATCoDataType.ATCoTxt)
            .CellValue(0, 2) = "Beginning"
            .CellValue(1, 2) = "Year"
            'grdSpecs.set_ColType(2, ATCoCtl.ATCoDataType.ATCoInt)
            .CellValue(0, 3) = "Ending"
            .CellValue(1, 3) = "Year"
            'grdSpecs.set_ColType(3, ATCoCtl.ATCoDataType.ATCoInt)
            .CellValue(0, 4) = "Historic"
            .CellValue(1, 4) = "Period"
            'grdSpecs.set_ColType(4, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 5) = "Skew"
            .CellValue(1, 5) = "Option"
            'grdSpecs.set_ColType(5, ATCoCtl.ATCoDataType.ATCoTxt)
            .CellValue(0, 6) = "Generalized"
            .CellValue(1, 6) = "Skew"
            'grdSpecs.set_ColType(6, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 7) = "Gen Skew"
            .CellValue(1, 7) = "Std Error"
            'grdSpecs.set_ColType(7, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 8) = "Mean"
            .CellValue(1, 8) = "Sqr Err"
            'grdSpecs.set_ColType(8, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 9) = "Low Hist"
            .CellValue(1, 9) = "Peak"
            'grdSpecs.set_ColType(9, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 10) = "Lo-Outlier"
            .CellValue(1, 10) = "Threshold"
            'grdSpecs.set_ColType(10, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 11) = "High Sys"
            .CellValue(1, 11) = "Peak"
            'grdSpecs.set_ColType(11, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 12) = "Hi-Outlier"
            .CellValue(1, 12) = "Threshold"
            'grdSpecs.set_ColType(12, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 13) = "Gage Base"
            .CellValue(1, 13) = "Discharge"
            'grdSpecs.set_ColType(13, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 14) = "Urban/Reg"
            .CellValue(1, 14) = "Peaks"
            .CellValue(1, 15) = "Latitude"
            'grdSpecs.set_ColType(15, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(1, 16) = "Longitude"
            'grdSpecs.set_ColType(16, ATCoCtl.ATCoDataType.ATCoSng)
            .CellValue(0, 17) = "Plot"
            .CellValue(1, 17) = "Name"
            'grdSpecs.set_ColType(17, ATCoCtl.ATCoDataType.ATCoTxt)

        End With

        grdSpecs.SizeAllColumnsToContents()

        grdThresh.Source = New atcControls.atcGridSource
        With grdThresh.Source
            .FixedRows = 2
            .Rows = 1
            .Columns = 4
            .CellValue(0, 0) = "Start"
            .CellValue(1, 0) = "Year"
            .CellValue(0, 1) = "End"
            .CellValue(1, 1) = "Year"
            .CellValue(0, 2) = "Low"
            .CellValue(1, 2) = "Threshold"
            .CellValue(0, 3) = "High"
            .CellValue(1, 3) = "Threshold"
        End With
        grdThresh.SizeAllColumnsToContents(grdThresh.Width)

        grdInterval.Source = New atcControls.atcGridSource
        With grdInterval.Source
            .FixedRows = 2
            .Rows = 1
            .Columns = 3
            .CellValue(1, 0) = "Year"
            .CellValue(0, 1) = "Low"
            .CellValue(1, 1) = "Interval"
            .CellValue(0, 2) = "High"
            .CellValue(1, 2) = "Interval"
        End With
        grdInterval.SizeAllColumnsToContents(grdInterval.Width)

        InitGraph(zgcThresh, "T")

        sstPfq.SelectedIndex = 0
        sstPfq.TabPages.Item(0).Enabled = False
        sstPfq.TabPages.Item(1).Enabled = False
        sstPfq.TabPages.Item(2).Enabled = False
        sstPfq.TabPages.Item(3).Enabled = False
        cmdRun.Enabled = False
        cmdSave.Enabled = False
        RemoveBMPs = False
    End Sub

    'UPGRADE_WARNING: Event frmPeakfq.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    'Private Sub frmPeakfq_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
    '    Dim w, h As Integer
    '    w = VB6.PixelsToTwipsX(Me.ClientRectangle.Width)
    '    h = VB6.PixelsToTwipsY(Me.ClientRectangle.Height)
    '    If h < 5070 And h > 0 Then 'height too small
    '        Me.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - h + 5070)
    '    End If
    '    If w > 7300 Then
    '        '    txtData.Width = w - txtData.Left - sstPfq.Left
    '        '    txtSpec.Width = txtData.Width
    '        lblData.Width = VB6.TwipsToPixelsX(w - VB6.PixelsToTwipsX(lblData.Left) - VB6.PixelsToTwipsX(sstPfq.Left))
    '        lblSpec.Width = lblData.Width
    '        sstPfq.Width = VB6.TwipsToPixelsX(w - (VB6.PixelsToTwipsX(sstPfq.Left) * 2))
    '        fraButtons.Left = VB6.TwipsToPixelsX(w - VB6.PixelsToTwipsX(fraButtons.Width) - 120)
    '        Select Case sstPfq.SelectedIndex
    '            Case 0 : grdSpecs.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(sstPfq.Width) - (VB6.PixelsToTwipsX(grdSpecs.Left) * 2))
    '            Case 1
    '            Case 2 : fraOutRight.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(sstPfq.Width) - VB6.PixelsToTwipsX(fraOutRight.Width) - 120)
    '                fraOutFile.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(fraOutRight.Left) - (VB6.PixelsToTwipsX(fraOutFile.Left) * 3))
    '                fraAddOut.Width = fraOutFile.Width
    '                lblOutFile(0).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(fraOutFile.Width) - VB6.PixelsToTwipsX(lblOutFile(0).Left) - 120)
    '                lblOutFile(1).Width = lblOutFile(0).Width
    '            Case 3 : fraGraphics.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(sstPfq.Width) - VB6.PixelsToTwipsX(fraGraphics.Width) - 120)
    '                fraOutFileRes(0).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(fraGraphics.Left) - (VB6.PixelsToTwipsX(fraOutFileRes(0).Left) * 3))
    '                fraOutFileRes(1).Width = fraOutFileRes(0).Width
    '                lblOutFileView(0).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(fraOutFileRes(0).Width) - VB6.PixelsToTwipsX(lblOutFileView(0).Left) - 120)
    '                lblOutFileView(1).Width = lblOutFileView(0).Width
    '        End Select
    '    End If
    '    If h > 5070 Then
    '        fraButtons.Top = VB6.TwipsToPixelsY(h - VB6.PixelsToTwipsY(fraButtons.Height) - 120)
    '        sstPfq.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(fraButtons.Top) - VB6.PixelsToTwipsY(sstPfq.Top) - 120)
    '        Select Case sstPfq.SelectedIndex
    '            Case 0 : grdSpecs.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(sstPfq.Height) - VB6.PixelsToTwipsY(grdSpecs.Top) - 120)
    '            Case 2 : fraGraphics.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(sstPfq.Height) - VB6.PixelsToTwipsY(fraGraphics.Top) - 120)
    '                lstGraphs.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(fraGraphics.Height) - VB6.PixelsToTwipsY(lstGraphs.Top) - VB6.PixelsToTwipsY(cmdGraph.Height) - 240)
    '                cmdGraph.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lstGraphs.Top) + VB6.PixelsToTwipsY(lstGraphs.Height) + 120)
    '        End Select
    '    End If
    'End Sub

    Private Sub frmPeakfq_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Dim i As Integer

        'On Error Resume Next

        'If RemoveBMPs Then 'remove BMP graphics
        '    For i = 1 To lstGraphs.Items.Count
        '        Kill(VB6.GetItemString(lstGraphs, i - 1) & ".BMP")
        '    Next i
        'End If

        End
    End Sub

    Private Sub lstGraphs_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstGraphs.DoubleClick
        cmdGraph_Click(cmdGraph, New System.EventArgs())
    End Sub

    Public Sub mnuAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAbout.Click
        MsgBox("Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision, MsgBoxStyle.Information, "PKFQWin")
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
        Call frmPeakfq_FormClosed(Me, New System.Windows.Forms.FormClosedEventArgs(CloseReason.None))
    End Sub

    Public Sub mnuFeedback_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFeedback.Click
        '        Dim stepname As String
        '        On Error GoTo errmsg
        '        stepname = "1: Dim feedback As clsATCoFeedback"
        '        'UPGRADE_ISSUE: clsATCoFeedback object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '        Dim feedback As clsATCoFeedback
        '        stepname = "2: Set feedback = New clsATCoFeedback"
        '        feedback = New clsATCoFeedback
        '        '                                     stepname = "3: feedback.AddText"
        '        'feedback.AddText AboutString(False)
        '        stepname = "4: feedback.AddFile"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object feedback.AddFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        feedback.AddFile(VB.Left(My.Application.Info.DirectoryPath, InStr(4, My.Application.Info.DirectoryPath, "\")) & "unins000.dat")
        '        stepname = "5: feedback.Show"
        '        'UPGRADE_ISSUE: App object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object feedback.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        feedback.Show(App, Me.Icon)

        '        Exit Sub

        'errmsg:
        '        MsgBox("Error opening feedback in step " & stepname & vbCr & Err.Description, CDbl("Send Feedback"))

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
        If lFeedbackForm.ShowFeedback(lName, lEmail, lMessage, lFeedback, "", False, False, "") Then
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
        'Dim s As String
        ''UPGRADE_ISSUE: MSComDlg.CommonDialog control cdlOpen was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E047632-2D91-44D6-B2A3-0801707AF686"'
        ''UPGRADE_ISSUE: App property App.HelpFile was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        's = OpenFile(App.HelpFile, cdlOpen)

        Dim lHelpFilename As String
        lHelpFilename = FindFile("", "C:\Doc\Peakfq\Out\peakfq.chm")
        If FileExists(lHelpFilename) Then
            ShowHelp(lHelpFilename)
        Else
            Logger.Dbg("Help File Not Found")
        End If

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
        PfqPrj.InputDir = PathNameOnly(FName)
        PfqPrj.OutputDir = PathNameOnly(FName) 'default output directory to same as input
        sstPfq.SelectedIndex = 0
        sstPfq.TabPages.Item(3).Enabled = False
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.Windows.Forms.Application.DoEvents()
        If cdlOpenOpen.FilterIndex <= 3 Then 'open data file
            PfqPrj.DataFileName = FName
            PfqPrj.BuildNewSpecFile() 'build basic spec file (I/O files)
            PfqPrj.RunBatchModel() 'run model to generate verbose spec file
            PfqPrj.ReadSpecFile() 'read verbose spec file
            DefPfqPrj = PfqPrj.Copy
        Else 'open spec file
            s = WholeFileString(FName)
            'build default project from initial version of spec file
            SaveFileString(tmpSpecName, s)
            PfqPrj.SpecFileName = tmpSpecName 'make working verbose copy
            DefPfqPrj = PfqPrj.SaveDefaults(s)
        End If
        If FileExists(PfqPrj.OutFile) Then
            'read peak data for each station from output file
            PfqPrj.ReadPeaks()
            'delete output file generated from reading data
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
            sstPfq.TabPages.Item(0).Enabled = True
            sstPfq.TabPages.Item(1).Enabled = True
            sstPfq.TabPages.Item(2).Enabled = True
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
            If i <> 8 And i <> 9 And i <> 11 Then
                'grdSpecs.set_ColEditable(i, True)
                With grdSpecs.Source
                    For lrow As Integer = 0 To .Rows - 1
                        If lrow + 1 > .FixedRows Then
                            .CellEditable(lrow, i) = True
                        End If
                    Next
                End With
            End If
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
        SaveFileString((cdlOpenOpen.FileName), s) 'save spec file under selected name
        lblSpec.Text = cdlOpenOpen.FileName

FileCancel:
    End Sub

    Private Sub sstPfq_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sstPfq.SelectedIndexChanged
        Static PreviousTab As Short = sstPfq.SelectedIndex()
        'frmPeakfq_Resize(Me, New System.EventArgs())
        PreviousTab = sstPfq.SelectedIndex()
        sstPfq.SelectedTab.Focus()
    End Sub

    Private Sub SetGraphNames()
        Dim j, i, k As Integer
        Dim ipos, ilen, Ind As Integer
        Dim newName, oldName, GraphName As String

        On Error Resume Next

        lstGraphs.Items.Clear()
        For i = 1 To grdSpecs.Source.Rows
            If grdSpecs.Source.CellValue(i, 1) = "Yes" Then
                j = j + 1
                'oldName = "PKFQ-" & j & ".BMP"
                newName = grdSpecs.Source.CellValue(i, 17)
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
                'newName = newName & ".BMP"
                'RenameGraph(oldName, newName)
                'lstGraphs.Items.Add(FilenameNoExt(newName))
                lstGraphs.Items.Add(newName)
            End If
        Next i
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
        If aColumn = 7 Then 'changed std skew err, update mean sqr err
            With grdSpecs.Source
                .CellValue(aRow, 8) = CSng(.CellValue(aRow, aColumn) ^ 2)
                'grdSpecs.CellBackColor = grdSpecs.BackColorFixed
                .CellColor(aRow, 8) = SystemColors.ControlDark
            End With
        End If

    End Sub

    Private Sub grdSpecs_MouseDownCell(ByVal aGrid As atcControls.atcGrid, ByVal aRow As Integer, ByVal aColumn As Integer) Handles grdSpecs.MouseDownCell
        Dim lUniqueValues As New ArrayList
        pLastClickedRow = aRow
        If aColumn = 5 Then ' The Skew option column
            'With aGrid.Source
            '    For lRow As Integer = .FixedRows To .Rows - 1
            '        Dim lRowValue As String = .CellValue(lRow, aColumn)
            '        If Not lRowValue Is Nothing AndAlso Not lUniqueValues.Contains(lRowValue) Then
            '            lUniqueValues.Add(lRowValue)
            '        End If
            '    Next
            'End With
            lUniqueValues.Add("Station")
            lUniqueValues.Add("Weighted")
            lUniqueValues.Add("Generalized")
            aGrid.AllowNewValidValues = True
        ElseIf aColumn = 1 Or aColumn = 14 Then ' The Urban/Reg Peaks column
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
        Dim lStn As pfqStation = PfqPrj.Stations.Item(CurStationIndex)
        Dim lThrColl As Generic.List(Of pfqStation.ThresholdType) = lStn.Thresholds
        Dim lIntColl As Generic.List(Of pfqStation.IntervalType) = lStn.Intervals
        Dim lNewSource As New atcControls.atcGridSource

        With lNewSource
            .FixedRows = 2
            .Rows = .FixedRows ' row counter progress, set to be started from the last fixed header row
            .Columns = 4 'start/end year followed by low/high thresholds
            .CellValue(0, 0) = "Start"
            .CellValue(1, 0) = "Year"
            .CellValue(0, 1) = "End"
            .CellValue(1, 1) = "Year"
            .CellValue(0, 2) = "Low"
            .CellValue(1, 2) = "Threshold"
            .CellValue(0, 3) = "High"
            .CellValue(1, 3) = "Threshold"
            .ColorCells = True
            If lThrColl.Count > 0 Then
                For Each lThresh As pfqStation.ThresholdType In lThrColl
                    .Rows += 1
                    .CellValue(.Rows - 1, 0) = lThresh.SYear
                    .CellEditable(.Rows - 1, 0) = True
                    .Alignment(.Rows - 1, 0) = atcAlignment.HAlignRight
                    .CellValue(.Rows - 1, 1) = lThresh.EYear
                    .CellEditable(.Rows - 1, 1) = True
                    .Alignment(.Rows - 1, 1) = atcAlignment.HAlignRight
                    .CellValue(.Rows - 1, 2) = lThresh.LowerLimit
                    .CellEditable(.Rows - 1, 2) = True
                    .Alignment(.Rows - 1, 2) = atcAlignment.HAlignRight
                    .CellValue(.Rows - 1, 3) = lThresh.UpperLimit
                    .CellEditable(.Rows - 1, 3) = True
                    .Alignment(.Rows - 1, 3) = atcAlignment.HAlignRight
                Next
            Else 'add one blank row
                .Rows += 1
                For i As Integer = 0 To 3
                    .CellEditable(.Rows - 1, i) = True
                    .Alignment(.Rows - 1, i) = atcAlignment.HAlignRight
                Next
            End If
        End With
        grdThresh.Initialize(lNewSource)
        grdThresh.Visible = True
        grdThresh.SizeAllColumnsToContents(grdThresh.Width, True)
        grdThresh.Refresh()

        lNewSource = New atcControls.atcGridSource
        With lNewSource
            .FixedRows = 2
            .Rows = .FixedRows ' row counter progress, set to be started from the last fixed header row
            .Columns = 3 'year followed by low/high thresholds
            .CellValue(1, 0) = "Year"
            .CellValue(0, 1) = "Low"
            .CellValue(1, 1) = "Interval"
            .CellValue(0, 2) = "High"
            .CellValue(1, 2) = "Interval"
            .ColorCells = True
            If lIntColl.Count > 0 Then
                For Each lInterval As pfqStation.IntervalType In lIntColl
                    .Rows += 1
                    .CellValue(.Rows - 1, 0) = lInterval.Year
                    .CellEditable(.Rows - 1, 0) = True
                    .Alignment(.Rows - 1, 0) = atcAlignment.HAlignRight
                    .CellValue(.Rows - 1, 1) = lInterval.LowerLimit
                    .CellEditable(.Rows - 1, 1) = True
                    .Alignment(.Rows - 1, 1) = atcAlignment.HAlignRight
                    .CellValue(.Rows - 1, 2) = lInterval.UpperLimit
                    .CellEditable(.Rows - 1, 2) = True
                    .Alignment(.Rows - 1, 2) = atcAlignment.HAlignRight
                Next
            Else 'add one blank row
                .Rows += 1
                For i As Integer = 0 To 2
                    .CellEditable(.Rows - 1, i) = True
                    .Alignment(.Rows - 1, i) = atcAlignment.HAlignRight
                Next
            End If
        End With
        grdInterval.Initialize(lNewSource)
        grdInterval.Visible = True
        grdInterval.SizeAllColumnsToContents(grdInterval.Width, True)
        grdInterval.Refresh()

        UpdateGraph()
    End Sub

    Private Sub ProcessThresholds()
        Dim lThrColl As Generic.List(Of pfqStation.ThresholdType) = Nothing
        Dim lIntColl As Generic.List(Of pfqStation.IntervalType) = Nothing
        'Dim lThresh As pfqStation.ThresholdType
        'Dim lInterval As pfqStation.IntervalType
        Dim i As Integer

        With grdThresh.Source
            lThrColl = New Generic.List(Of pfqStation.ThresholdType)
            For i = .FixedRows To .Rows - 1
                If IsNumeric(.CellValue(i, 0)) AndAlso IsNumeric(.CellValue(i, 1)) AndAlso _
                   IsNumeric(.CellValue(i, 2)) AndAlso IsNumeric(.CellValue(i, 3)) Then
                    Dim lThresh As New pfqStation.ThresholdType
                    lThresh.SYear = CInt(.CellValue(i, 0))
                    lThresh.EYear = CInt(.CellValue(i, 1))
                    lThresh.LowerLimit = CSng(.CellValue(i, 2))
                    lThresh.UpperLimit = CSng(.CellValue(i, 3))
                    lThrColl.Add(lThresh)
                End If
            Next
        End With
        With grdInterval.Source
            lIntColl = New Generic.List(Of pfqStation.IntervalType)
            For i = .FixedRows To .Rows - 1
                If IsNumeric(.CellValue(i, 0)) AndAlso IsNumeric(.CellValue(i, 1)) AndAlso _
                   IsNumeric(.CellValue(i, 2)) Then
                    Dim lInterval As New pfqStation.IntervalType
                    lInterval.Year = CInt(.CellValue(i, 0))
                    lInterval.LowerLimit = CSng(.CellValue(i, 1))
                    lInterval.UpperLimit = CSng(.CellValue(i, 2))
                    lIntColl.Add(lInterval)
                End If
            Next
        End With
        Dim lStn As pfqStation = PfqPrj.Stations.Item(CurStationIndex)
        lStn.Thresholds = lThrColl
        lStn.Intervals = lIntColl
    End Sub

    Private Sub tabThresholds_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabThresholds.GotFocus
        ProcessGrid()
        If CurStationIndex < 0 Then cboStation.SelectedIndex = 0
        With grdThresh 'At this point, there should already be one instantiated with header rows
            .Enabled = True
            .BackColor = SystemColors.Control
            .AllowHorizontalScrolling = False
            .Visible = True
            .SizeAllColumnsToContents(.Width, True)
        End With
        With grdInterval 'At this point, there should already be one instantiated with header rows
            .Enabled = True
            .BackColor = SystemColors.Control
            .AllowHorizontalScrolling = False
            .Visible = True
            .SizeAllColumnsToContents(.Width, True)
        End With
    End Sub

    Private Sub cmdAddInt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddInt.Click
        With grdInterval.Source
            .Rows += 1
            For i As Integer = 0 To 2
                .CellEditable(.Rows - 1, i) = True
                .Alignment(.Rows - 1, i) = atcAlignment.HAlignRight
            Next
        End With
    End Sub

    Private Sub cmdAddThr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddThr.Click
        With grdThresh.Source
            .Rows += 1
            For i As Integer = 0 To 3
                .CellEditable(.Rows - 1, i) = True
                .Alignment(.Rows - 1, i) = atcAlignment.HAlignRight
            Next
        End With
    End Sub

    Private Sub cmdUpdateGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateGraph.Click
        ProcessThresholds()
        UpdateGraph()
    End Sub

    Private Sub UpdateGraph()
        Dim lStn As pfqStation = PfqPrj.Stations.Item(CurStationIndex)
        Dim lYearMin As Double = 10000
        Dim lYearMax As Double = -10000
        Dim lPkVals(lStn.Peaks.Count - 1) As Double
        Dim lDateVals(lStn.Peaks.Count - 1) As Double
        Dim lThrshVals(1) As Double
        Dim lThrshDates(1) As Double
        Dim lDataMin As Double = 10000
        Dim lDataMax As Double = -10000
        Dim lLogFlag As Boolean = True
        Dim lPane As GraphPane = zgcThresh.MasterPane.PaneList(0)
        Dim lYAxis As Axis = lPane.YAxis
        Dim lCurve As LineItem = Nothing

        'clear previous curves
        lPane.CurveList.Clear()

        'find ranges for axes
        For Each vThresh As pfqStation.ThresholdType In lStn.Thresholds
            lThrshDates(0) = vThresh.SYear
            lThrshDates(1) = vThresh.EYear
            If lThrshDates(0) < lYearMin Then lYearMin = lThrshDates(0)
            If lThrshDates(1) > lYearMax Then lYearMax = lThrshDates(1)
            lThrshVals(0) = vThresh.LowerLimit
            lThrshVals(1) = vThresh.LowerLimit
            If lThrshVals(0) < lDataMin Then lDataMin = lThrshVals(0)
            If lThrshVals(1) > lDataMax Then lDataMax = lThrshVals(1)
            lCurve = lPane.AddCurve("Thresholds", lThrshDates, lThrshVals, Color.Blue, SymbolType.None)
            lCurve.Line.Fill = New Fill(Color.Blue, Color.Blue, 45)
        Next
        For Each vInterval As pfqStation.IntervalType In lStn.Intervals
            lThrshDates(0) = vInterval.Year
            lThrshDates(1) = vInterval.Year
            If lThrshDates(0) < lYearMin Then lYearMin = lThrshDates(0)
            If lThrshDates(0) > lYearMax Then lYearMax = lThrshDates(0)
            lThrshVals(0) = vInterval.LowerLimit
            lThrshVals(1) = vInterval.UpperLimit
            If lThrshVals(0) < lDataMin Then lDataMin = lThrshVals(0)
            If lThrshVals(1) > lDataMax Then lDataMax = lThrshVals(1)
            lCurve = lPane.AddCurve("Intervals", lThrshDates, lThrshVals, Color.Green, SymbolType.HDash)
        Next
        If lStn.Peaks(0).Year < lYearMin Then lYearMin = lStn.Peaks(0).Year
        If lStn.Peaks(lStn.Peaks.Count - 1).Year > lYearMax Then lYearMax = lStn.Peaks(lStn.Peaks.Count - 1).Year
        For i As Integer = 0 To lStn.Peaks.Count - 1
            If lStn.Peaks(i).Code <> "H" Or lStn.HistoricPeriod > 0 Then
                lPkVals(i) = Math.Abs(lStn.Peaks(i).Value)
                lDateVals(i) = Math.Abs(lStn.Peaks(i).Year)
                If lPkVals(i) > 0 AndAlso lPkVals(i) < lDataMin Then lDataMin = lPkVals(i)
                If lPkVals(i) > lDataMax Then lDataMax = lPkVals(i)
            End If
        Next
        'set y-axis range
        Scalit(lDataMin, lDataMax, lLogFlag, lPane.YAxis.Scale.Min, lPane.YAxis.Scale.Max)
        'set x-axis range
        lPane.X2Axis.Scale.Min = lYearMin
        lPane.X2Axis.Scale.Max = lYearMax

        lYAxis.IsVisible = True
        lYAxis.Scale.IsVisible = True
        lCurve = lPane.AddCurve("Peaks", lDateVals, lPkVals, Color.Red, SymbolType.Plus)
        lCurve.Line.IsVisible = False

        zgcThresh.AxisChange()
        zgcThresh.Invalidate()
        zgcThresh.Refresh()

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
            .Type = AxisType.Log
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
            If aType = "T" Then
                .Title.Text = "Discharge (cfs)"
                .Title.FontSpec.Size = 8
                .Scale.FontSpec.Size = 8
            Else
                .Title.Text = "Annual Peak Discharge (cfs)"
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
                lLogMin = Fix(Log10(aDataMin))
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
                lLogMax = Fix(Log10(aDataMax))
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

    Public Sub GenGraph(ByVal aStnInd As Integer)
        Dim newform As New atcGraph.atcGraphForm
        Dim lCurve As LineItem = Nothing
        Dim i As Integer
        Dim j As Integer
        Dim lNPkPlt As Integer
        Dim lPkLog(199) As Single
        Dim lSysPP(199) As Single
        Dim lWrcPP(199) As Single
        Dim lWeiba As Single
        Dim lNPlot As Integer
        Dim lSysRFC(31) As Single
        Dim lWrcFC(31) As Single
        Dim lTxProb(31) As Single
        Dim lHistFlg As Integer
        Dim lNoCLim As Integer
        Dim lCLimL(31) As Single
        Dim lCLimU(31) As Single
        Const lPP1 As Double = 0.995 '-2.577
        Const lPP0 As Double = 0.002 '2.879
        Dim lNPlot1 As Integer
        Dim lNPlot2 As Integer
        Dim lNPlCL1 As Integer
        Dim lNPlCL2 As Integer
        Dim lPMin As Double = 1.0E+20
        Dim lPMax As Double = -1.0E+20

        newform.Height = VB6.TwipsToPixelsY(7600)
        newform.Width = VB6.TwipsToPixelsX(9700)
        Dim lZGC As ZedGraphControl = newform.ZedGraphCtrl
        InitGraph(lZGC, "R")
        Dim lPane As GraphPane = lZGC.MasterPane.PaneList(0)
        Dim lYAxis As Axis = lPane.YAxis

        Dim lStnInd As Integer = aStnInd + 1
        Dim lHeader As String = " ".PadLeft(80)
        Call GETDATA(lStnInd, lNPkPlt, lPkLog, lSysPP, lWrcPP, lWeiba, _
                    lNPlot, lSysRFC, lWrcFC, lTxProb, lHistFlg, _
                    lNoCLim, lCLimL, lCLimU, lHeader, lHeader.Length)
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
            lYVals(j) = 10 ^ lWrcFC(i)
            If lYVals(j) > lPMax Then lPMax = lYVals(j)
            If lYVals(j) < lPMin Then lPMin = lYVals(j)
            lXVals(j) = lTxProb(i)
        Next
        lYAxis.IsVisible = True
        lYAxis.Scale.IsVisible = True
        lCurve = lPane.AddCurve("Bull. 17-B frequency", lXVals, lYVals, Color.Red, SymbolType.None)

        'observed peaks
        ReDim lYVals(lNPkPlt - 1), lXVals(lNPkPlt - 1)
        For i = 0 To lNPkPlt - 1
            lYVals(i) = 10 ^ lPkLog(i)
            If lYVals(i) > lPMax Then lPMax = lYVals(i)
            If lYVals(i) < lPMin Then lPMin = lYVals(i)
            lXVals(i) = lSysPP(i)
        Next
        lCurve = lPane.AddCurve("Systematic peaks", lXVals, lYVals, Color.Black, SymbolType.Circle)
        lCurve.Line.IsVisible = False

        'Systematic record
        lNPlot1 = 0
        lNPlot2 = lNPlot - 1
        For i = 0 To lNPlot - 1
            If lTxProb(i) < lPP0 Then lNPlot2 = i
            j = lNPlot - i - 1 ' + 1 - i
            If lTxProb(j) > lPP1 AndAlso lWrcFC(j) > -1.0 Then lNPlot1 = j
        Next
        ReDim lYVals(lNPlot2 - lNPlot1)
        ReDim lXVals(lNPlot2 - lNPlot1)
        For i = lNPlot1 To lNPlot2
            j = i - lNPlot1
            lYVals(j) = 10 ^ lSysRFC(i)
            If lYVals(j) > lPMax Then lPMax = lYVals(j)
            If lYVals(j) < lPMin Then lPMin = lYVals(j)
            lXVals(j) = lTxProb(i)
        Next
        lCurve = lPane.AddCurve("Systematic frequency", lXVals, lYVals, Color.Blue, SymbolType.None)
        lCurve.Line.Style = Drawing2D.DashStyle.Dash

        If lHistFlg = 0 Then 'include historical peaks
            ReDim lYVals(lNPkPlt - 1), lXVals(lNPkPlt - 1)
            For i = 0 To lNPkPlt - 1
                lYVals(i) = 10 ^ lPkLog(i)
                If lYVals(i) > lPMax Then lPMax = lYVals(i)
                If lYVals(i) < lPMin Then lPMin = lYVals(i)
                lXVals(i) = lWrcPP(i)
            Next
            lCurve = lPane.AddCurve("Historical adjusted", lXVals, lYVals, Color.Black, SymbolType.XCross)
            lCurve.Line.IsVisible = False
        End If

        'confidence limits
        ReDim lYVals(lNPlot2 - lNPlot1)
        ReDim lXVals(lNPlot2 - lNPlot1)
        For i = lNPlCL1 To lNPlCL2
            j = i - lNPlCL1
            lYVals(j) = 10 ^ lCLimL(i)
            If lYVals(j) > lPMax Then lPMax = lYVals(j)
            If lYVals(j) < lPMin Then lPMin = lYVals(j)
            lXVals(j) = lTxProb(i)
        Next
        lCurve = lPane.AddCurve("Confidence limits", lXVals, lYVals, Color.Red, SymbolType.None)
        lCurve.Line.Style = Drawing2D.DashStyle.Dot
        For i = lNPlCL1 To lNPlCL2
            j = i - lNPlCL1
            lYVals(j) = 10 ^ lCLimU(i)
            If lYVals(j) > lPMax Then lPMax = lYVals(j)
            If lYVals(j) < lPMin Then lPMin = lYVals(j)
            lXVals(j) = lTxProb(i)
        Next
        lCurve = lPane.AddCurve("Confidence Limits", lXVals, lYVals, Color.Red, SymbolType.None)
        lCurve.Label.IsVisible = False
        lCurve.Line.Style = Drawing2D.DashStyle.Dot

        'set y-axis range
        Scalit(lPMin, lPMax, True, lPane.YAxis.Scale.Min, lPane.YAxis.Scale.Max)

        lPane.XAxis.Title.Text = "Annual Exceedance Probability, Percent" & vbCrLf & "Station - " & lHeader

        Dim lWarning As String = "Peakfq 5 run " & System.DateTime.Now & vbCrLf & _
                                 "NOTE - Preliminary computation" & vbCrLf & _
                                 "User is responsible for" & vbCrLf & _
                                 "assessment and interpretation."
        Dim lText As New TextObj(lWarning, 0.5, 0.7)
        lText.Location.CoordinateFrame = CoordType.PaneFraction
        lText.FontSpec.StringAlignment = StringAlignment.Near
        lText.FontSpec.IsBold = True
        lText.FontSpec.Size = 12
        lText.FontSpec.Border.IsVisible = False
        lText.FontSpec.Fill.IsVisible = False
        lText.Location.AlignH = AlignH.Left
        lText.Location.AlignV = AlignV.Top
        lPane.GraphObjList.Add(lText)

        lZGC.AxisChange()
        lZGC.Invalidate()
        lZGC.Refresh()
        newform.Show()

    End Sub

    Private Sub zgcThresh_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles zgcThresh.Paint
        zgcThresh.MasterPane.ReSize(e.Graphics)
    End Sub
End Class
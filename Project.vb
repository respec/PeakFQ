Option Strict Off
Option Explicit On

Imports atcUtility
Imports MapWinUtility
Imports MapWinUtility.Strings


Friend Class pfqProject
	
    Private pSpecFileName As String
	Private pDataFileName As String
	Private pDataType As Integer '0 - ASCII(Watstore), 1 - WDM
    Private pStations As Generic.List(Of pfqStation)
	Private pOutFile As String
	Private pAdditionalOutput As Integer
    Private pAddOutFileName As String
    Private pExportFileName As String
    Private pEmpiricalFileName As String
	Private pIntermediateResults As Boolean
	Private pLinePrinter As Boolean
	Private pGraphic As Boolean
	Private pGraphFormat As String
	Private pPrintPlotPos As Boolean
	Private pPlotPos As Single
    Private pConfidenceInterval As Single
    Private pInputDir As String
    Private pOutputDir As String
    Private pEMA As Boolean
    Private pExtendedOutput As Boolean
    'the following are for storing comments for various specification records
    Private pCDataFile As String
    Private pCOutFile As String
    Private pCPlotStyle As String
    Private pCPlotFormat As String
    Private pCPrintPlotPos As String
    Private pCPlotPos As String
    Private pCAdditional As String
    Private pCExportFileName As String
    Private pCEmpiricalFileName As String
    Private pCIntermediate As String
    Private pCConfidenceInterval As String
    Private pCEMA As String
    Private pCExtendedOutput As String

    Private FType(1) As String

    Public Property SpecFileName() As String
        Get
            SpecFileName = pSpecFileName
        End Get
        Set(ByVal Value As String)
            Dim s As String

            pSpecFileName = Value
            s = WholeFileString(pSpecFileName)
            If UCase(Left(s, 7)) <> "VERBOSE" Then
                'update spec file to verbose mode that explicitly defines all station specs
                If InStr(Right(s, 2), vbLf) > 0 Then 'already have line feed
                    s = s & "Update"
                Else 'include CR/LF
                    s = s & vbCrLf & "Update"
                End If
                SaveFileString(pSpecFileName, s)
                ReadSpecFile() 'populate what we can now (at least get output file)
                RunBatchModel()

            End If
            ReadSpecFile()
        End Set
    End Property

    Public Property DataFileName() As String
        Get
            DataFileName = pDataFileName
        End Get
        Set(ByVal Value As String)
            pDataFileName = Value
        End Set
    End Property

    Public Property DataType() As Integer
        Get
            DataType = pDataType
        End Get
        Set(ByVal Value As Integer)
            pDataType = Value
        End Set
    End Property

    Public Property Stations() As Generic.List(Of pfqStation)
        Get
            If pStations Is Nothing Then pStations = New Generic.List(Of pfqStation)
            Stations = pStations
        End Get
        Set(ByVal Value As Generic.List(Of pfqStation))
            pStations = Value
        End Set
    End Property

    Public Property OutFile() As String
        Get
            OutFile = pOutFile
        End Get
        Set(ByVal Value As String)
            pOutFile = Value
        End Set
    End Property

    Public Property AdditionalOutput() As Integer
        Get
            AdditionalOutput = pAdditionalOutput
        End Get
        Set(ByVal Value As Integer)
            pAdditionalOutput = Value
        End Set
    End Property

    Public Property AddOutFileName() As String
        Get
            AddOutFileName = pAddOutFileName
        End Get
        Set(ByVal Value As String)
            pAddOutFileName = Value
        End Set
    End Property

    Public Property ExportFileName() As String
        Get
            ExportFileName = pExportFileName
        End Get
        Set(ByVal Value As String)
            pExportFileName = Value
        End Set
    End Property

    Public Property EmpiricalFileName() As String
        Get
            EmpiricalFileName = pEmpiricalFileName
        End Get
        Set(ByVal Value As String)
            pEmpiricalFileName = Value
        End Set
    End Property

    Public Property IntermediateResults() As Boolean
        Get
            IntermediateResults = pIntermediateResults
        End Get
        Set(ByVal Value As Boolean)
            pIntermediateResults = Value
        End Set
    End Property

    Public Property ConfidenceInterval() As Single
        Get
            ConfidenceInterval = pConfidenceInterval
        End Get
        Set(ByVal Value As Single)
            pConfidenceInterval = Value
        End Set
    End Property

    Public Property LinePrinter() As Boolean
        Get
            LinePrinter = pLinePrinter
        End Get
        Set(ByVal Value As Boolean)
            pLinePrinter = Value
        End Set
    End Property

    Public Property Graphic() As Boolean
        Get
            Graphic = pGraphic
        End Get
        Set(ByVal Value As Boolean)
            pGraphic = Value
        End Set
    End Property

    Public Property GraphFormat() As String
        Get
            GraphFormat = pGraphFormat
        End Get
        Set(ByVal Value As String)
            pGraphFormat = Value
        End Set
    End Property

    Public Property PlotPos() As Single
        Get
            PlotPos = pPlotPos
        End Get
        Set(ByVal Value As Single)
            pPlotPos = Value
        End Set
    End Property

    Public Property PrintPlotPos() As Boolean
        Get
            PrintPlotPos = pPrintPlotPos
        End Get
        Set(ByVal Value As Boolean)
            pPrintPlotPos = Value
        End Set
    End Property

    Public Property InputDir() As String
        Get
            InputDir = pInputDir
        End Get
        Set(ByVal Value As String)
            pInputDir = Value
        End Set
    End Property

    Public Property OutputDir() As String
        Get
            OutputDir = pOutputDir
        End Get
        Set(ByVal Value As String)
            pOutputDir = Value
        End Set
    End Property

    Public Property EMA() As Boolean
        Get
            EMA = pEMA
        End Get
        Set(ByVal Value As Boolean)
            pEMA = Value
        End Set
    End Property

    Public Property ExtendedOutput() As Boolean
        Get
            ExtendedOutput = pExtendedOutput
        End Get
        Set(ByVal Value As Boolean)
            pExtendedOutput = Value
        End Set
    End Property

    Public Property CDataFile() As String
        Get
            CDataFile = pCDataFile
        End Get
        Set(ByVal Value As String)
            pCDataFile = Value
        End Set
    End Property

    Public Property COutFile() As String
        Get
            COutFile = pCOutFile
        End Get
        Set(ByVal Value As String)
            pCOutFile = Value
        End Set
    End Property

    Public Property CPlotStyle() As String
        Get
            CPlotStyle = pCPlotStyle
        End Get
        Set(ByVal Value As String)
            pCPlotStyle = Value
        End Set
    End Property

    Public Property CPlotFormat() As String
        Get
            CPlotFormat = pCPlotFormat
        End Get
        Set(ByVal Value As String)
            pCPlotFormat = Value
        End Set
    End Property

    Public Property CPrintPlotPos() As String
        Get
            CPrintPlotPos = pCPrintPlotPos
        End Get
        Set(ByVal Value As String)
            pCPrintPlotPos = Value
        End Set
    End Property

    Public Property CPlotPos() As String
        Get
            CPlotPos = pCPlotPos
        End Get
        Set(ByVal Value As String)
            pCPlotPos = Value
        End Set
    End Property

    Public Property CAdditional() As String
        Get
            CAdditional = pCAdditional
        End Get
        Set(ByVal Value As String)
            pCAdditional = Value
        End Set
    End Property

    Public Property CExportFileName() As String
        Get
            CExportFileName = pCExportFileName
        End Get
        Set(ByVal Value As String)
            pCExportFileName = Value
        End Set
    End Property

    Public Property CEmpiricalFileName() As String
        Get
            CEmpiricalFileName = pCEmpiricalFileName
        End Get
        Set(ByVal Value As String)
            pCEmpiricalFileName = Value
        End Set
    End Property

    Public Property CIntermediate() As String
        Get
            CIntermediate = pCIntermediate
        End Get
        Set(ByVal Value As String)
            pCIntermediate = Value
        End Set
    End Property

    Public Property CConfidenceInterval() As String
        Get
            CConfidenceInterval = pCConfidenceInterval
        End Get
        Set(ByVal Value As String)
            pCConfidenceInterval = Value
        End Set
    End Property

    Public Property CEMA() As String
        Get
            CEMA = pCEMA
        End Get
        Set(ByVal Value As String)
            pCEMA = Value
        End Set
    End Property

    Public Property CExtendedOutput() As String
        Get
            CExtendedOutput = pCExtendedOutput
        End Get
        Set(ByVal Value As String)
            pCExtendedOutput = Value
        End Set
    End Property

    Public Sub ReadSpecFile()

        Dim i As Short
        Dim SpecFile As String
        Dim Rec, Kwd As String
        Dim lCom As String = ""
        Dim CommentPending As Boolean
        Dim CurStation As pfqStation = Nothing
        Dim lThresh As pfqStation.ThresholdType = Nothing
        Dim lData As pfqStation.PeakDataType = Nothing

        CommentPending = False
        pStations = New Generic.List(Of pfqStation)
        SpecFile = WholeFileString(pSpecFileName)

        While Len(SpecFile) > 0
            Rec = StrSplit(SpecFile, vbCrLf, "")
            If Left(Rec, 1) = "'" AndAlso Left(Rec, 3) <> "'NO" Then 'process comment, except for "NO Historic" record
                If CommentPending Then 'multiple line comment
                    lCom = lCom & vbCrLf & Rec
                Else 'new comment
                    lCom = Rec
                    CommentPending = True
                End If
            Else 'process specification
                Kwd = UCase(StrRetRem(Rec))
                Select Case Kwd
                    Case "I"
                        Kwd = UCase(StrRetRem(Rec))
                        For i = 0 To 1
                            If Kwd = FType(i) Then pDataType = i
                        Next i
                        pDataFileName = Rec
                        If CommentPending Then pCDataFile = lCom
                    Case "O"
                        Kwd = UCase(StrRetRem(Rec))
                        Select Case Kwd
                            Case "FILE"
                                pOutFile = Rec
                                If CommentPending Then pCOutFile = lCom
                            Case "PLOT"
                                Kwd = UCase(StrRetRem(Rec))
                                If Kwd = "STYLE" Then
                                    If UCase(Rec) = "PRINTER" Or UCase(Rec) = "BOTH" Then
                                        pLinePrinter = True
                                    End If
                                    If UCase(Rec) = "GRAPHICS" Or UCase(Rec) = "BOTH" Then
                                        pGraphic = True
                                    End If
                                    If CommentPending Then pCPlotStyle = lCom
                                ElseIf Kwd = "FORMAT" Then
                                    pGraphFormat = UCase(Rec)
                                    If CommentPending Then pCPlotFormat = lCom
                                ElseIf Kwd = "PRINTPOS" Then
                                    If UCase(Rec) = "YES" Then
                                        pPrintPlotPos = True
                                    Else
                                        pPrintPlotPos = False
                                    End If
                                    If CommentPending Then pCPrintPlotPos = lCom
                                ElseIf Kwd = "POSITION" Then
                                    pPlotPos = CSng(Rec)
                                    If CommentPending Then pCPlotPos = lCom
                                End If
                            Case "ADDITIONAL"
                                Kwd = UCase(StrRetRem(Rec))
                                If Kwd = "WDM" Then
                                    pAdditionalOutput = 1
                                ElseIf Left(Kwd, 3) = "WAT" Then
                                    pAdditionalOutput = 2
                                ElseIf Left(Kwd, 3) = "TAB" Then
                                    pAdditionalOutput = 4
                                ElseIf Kwd = "BOTH" Then
                                    Kwd = UCase(StrRetRem(Rec))
                                    If Left(Kwd, 3) = "WAT" Then 'watstore format
                                        pAdditionalOutput = 3
                                    Else 'assume tab-separated
                                        pAdditionalOutput = 5
                                    End If
                                Else
                                    pAdditionalOutput = 0
                                End If
                                If pAdditionalOutput >= 2 Then
                                    'remaining text should be file name
                                    pAddOutFileName = Rec
                                End If
                                If CommentPending Then pCAdditional = lCom
                            Case "EXPORT"
                                pExportFileName = Rec
                                If CommentPending Then pCExportFileName = lCom
                            Case "EMPIRICAL"
                                pEmpiricalFileName = Rec
                                If CommentPending Then pCEmpiricalFileName = lCom
                            Case "DEBUG"
                                If UCase(Rec) = "YES" Then
                                    pIntermediateResults = True
                                Else
                                    pIntermediateResults = False
                                End If
                                If CommentPending Then pCIntermediate = lCom
                            Case "CONFINTERVAL"
                                pConfidenceInterval = CSng(Rec)
                                If CommentPending Then pCConfidenceInterval = lCom
                            Case "EXTENDED"
                                If UCase(Rec) = "YES" Then
                                    pExtendedOutput = True
                                Else
                                    pExtendedOutput = False
                                End If
                                If CommentPending Then pCExtendedOutput = lCom
                            Case "EMA"
                                If UCase(Rec) = "YES" Then
                                    pEMA = True
                                Else
                                    pEMA = False
                                End If
                                If CommentPending Then pCEMA = lCom
                        End Select
                    Case "STATION"
                        If Not CurStation Is Nothing Then
                            'previous station info exists, add it to collection
                            pStations.Add(CurStation)
                        End If
                        'build new station
                        CurStation = New pfqStation
                        CurStation.id = Rec
                        If pEMA Then 'global EMA option was set, use for all stations
                            CurStation.AnalysisOption = "EMA"
                        End If
                        'always default Skew Weight option to HWN method, only update if found in spec file
                        CurStation.WeightOpt = "HWN"
                        If CommentPending Then CurStation.Comment = lCom
                    Case "ANALYZE"
                        CurStation.AnalysisOption = Rec
                        If CommentPending Then CurStation.CAnalysisOption = lCom
                        If CurStation.AnalysisOption.ToUpper = "EMA" Then
                            CurStation.LOTestType = "Multiple"
                            CurStation.HistoricPeriod = True
                        End If
                    Case "GENSKEW"
                        CurStation.GenSkew = CSng(Rec)
                        If CommentPending Then CurStation.CGenSkew = lCom
                    Case "SKEWSE"
                        CurStation.SESkew = CSng(Rec)
                        If CommentPending Then CurStation.CSESkew = lCom
                    Case "BEGYEAR"
                        CurStation.BegYear = CInt(Rec)
                        If CommentPending Then CurStation.CBegYear = lCom
                    Case "ENDYEAR"
                        CurStation.EndYear = CInt(Rec)
                        If CommentPending Then CurStation.CEndYear = lCom
                    Case "HISTPERIOD"
                        CurStation.HistoricPeriod = CSng(Rec)
                        If CommentPending Then CurStation.CHistoric = lCom
                    Case "NO HISTORIC PERIOD IN USE"
                        CurStation.HistoricPeriod = False
                    Case "SKEWOPT"
                        If UCase(Rec) = "STATION" Then
                            CurStation.SkewOpt = 0
                        ElseIf UCase(Rec) = "WEIGHTED" Then
                            CurStation.SkewOpt = 1
                        ElseIf UCase(Rec) = "REGIONAL" Then
                            CurStation.SkewOpt = 2
                        End If
                        If CommentPending Then CurStation.CSkewOpt = lCom
                    Case "WEIGHTOPT"
                        CurStation.WeightOpt = Rec
                    Case "LOTYPE"
                        If Rec.ToUpper = "MGBT" Then
                            CurStation.LOTestType = "Multiple"
                        Else
                            CurStation.LOTestType = "Single"
                        End If
                    Case "URB/REG"
                        If UCase(Rec) = "YES" Then
                            CurStation.UrbanRegPeaks = 1
                        Else
                            CurStation.UrbanRegPeaks = 0
                        End If
                        If CommentPending Then CurStation.CUrban = lCom
                        'Case "LOTYPE"
                        '    If UCase(Rec) <> "NONE" AndAlso LOTestType.Length = 0 Then
                        '        If UCase(Rec) = "SINGLE" Then
                        '            LOTestType = "Single Grubbs-Beck"
                        '        ElseIf UCase(Rec) = "MULTIPLE" Then
                        '            LOTestType = "Multiple Grubbs-Beck"
                        '        End If
                        '    End If
                    Case "LOTHRESH"
                        CurStation.LowOutlier = CSng(Rec)
                        If CommentPending Then CurStation.CLowOutlier = lCom
                    Case "HITHRESH"
                        CurStation.HighOutlier = CSng(Rec)
                        If CommentPending Then CurStation.CHighOutlier = lCom
                    Case "GAGEBASE"
                        CurStation.GageBaseDischarge = CSng(Rec)
                        If CommentPending Then CurStation.CGageBase = lCom
                    Case "LATITUDE"
                        CurStation.Lat = CSng(Rec)
                        If CommentPending Then CurStation.CLat = lCom
                    Case "LONGITUDE"
                        CurStation.Lng = CSng(Rec)
                        If CommentPending Then CurStation.CLong = lCom
                    Case "HISYS" 'no comment for HISYS as it is just info for the interface
                        CurStation.HighSysPeak = CSng(Rec)
                    Case "LOHIST" 'no comment for LOHIST as it is just info for the interface
                        CurStation.LowHistPeak = CSng(Rec)
                    Case "PLOTNAME"
                        CurStation.PlotName = Rec
                        If CommentPending Then CurStation.CPlotName = lCom
                    Case "PCPT_THRESH"
                        lThresh = New pfqStation.ThresholdType
                        lThresh.SYear = CSng(StrRetRem(Rec))
                        lThresh.EYear = CSng(StrRetRem(Rec))
                        lThresh.LowerLimit = CSng(StrRetRem(Rec))
                        lThresh.UpperLimit = CSng(StrRetRem(Rec))
                        lThresh.Comment = Rec
                        CurStation.Thresholds.Add(lThresh)
                        If CommentPending Then CurStation.CThresholds = lCom
                    Case "INTERVAL"
                        lData = New pfqStation.PeakDataType
                        lData.Year = CSng(StrRetRem(Rec))
                        lData.LowerLimit = CSng(StrRetRem(Rec))
                        lData.UpperLimit = CSng(StrRetRem(Rec))
                        lData.Comment = Rec
                        CurStation.PeakData.Add(lData)
                        If CommentPending Then CurStation.CIntervals = lCom
                    Case "PEAK"
                        lData = New pfqStation.PeakDataType
                        lData.Year = CSng(StrRetRem(Rec))
                        lData.Value = CSng(StrRetRem(Rec))
                        lData.LowerLimit = lData.Value
                        lData.UpperLimit = lData.Value
                        If Rec.Contains("'") Then
                            Dim lPos As Integer = Rec.IndexOf("'")
                            lData.Comment = Rec.Substring(lPos + 1)
                            If lPos > 0 Then lData.Code = Rec.Substring(0, lPos - 1)
                        Else
                            lData.Code = Rec
                        End If
                        CurStation.PeakData.Add(lData)
                    Case "USESKEWMAP"
                        If UCase(Rec) = "YES" Then
                            CurStation.UseSkewMap = 1
                        Else
                            CurStation.UseSkewMap = 0
                        End If
                        If CommentPending Then CurStation.CUseSkewMap = lCom
                End Select
                CommentPending = False 'assume any pending comment was stored with a specification
            End If
        End While
        If Not CurStation Is Nothing Then
            'station info exists, add it to collection
            pStations.Add(CurStation)
            'UPGRADE_NOTE: Object CurStation may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            CurStation = Nothing
        End If
    End Sub

    Public Function SaveAsString(Optional ByRef DefPrj As pfqProject = Nothing) As String

        Dim i As Integer
        Dim s As String
        Dim vSta As pfqStation
        Dim defsta As New pfqStation

        s = ""
        If DefPrj Is Nothing Then 'no default specs, write out verbose
            s = "Verbose" & vbCrLf
        End If
        If Len(pCDataFile) > 0 Then s = s & pCDataFile & vbCrLf
        '        s = s & "I " & FType(pDataType) & " " & pInputDir & "\" & FilenameNoPath(pDataFileName) & vbCrLf
        s = s & "I " & FType(pDataType) & " " & RelativeFilename(pDataFileName, pInputDir) & vbCrLf
        If Len(pCOutFile) > 0 Then s = s & pCOutFile & vbCrLf
        '        s = s & "O File " & pOutputDir & "\" & FilenameNoPath(pOutFile) & vbCrLf
        s = s & "O File " & RelativeFilename(pOutFile, pInputDir) & vbCrLf
        If Len(pCPlotStyle) > 0 Then s = s & pCPlotStyle & vbCrLf
        If pLinePrinter And pGraphic Then
            s = s & "O Plot Style Both" & vbCrLf
        ElseIf pLinePrinter Then
            s = s & "O Plot Style Printer" & vbCrLf
        ElseIf pGraphic Then
            s = s & "O Plot Style Graphics" & vbCrLf
        End If
        If Len(pCPlotFormat) > 0 Then s = s & pCPlotFormat & vbCrLf
        If pGraphic Then s = s & "O Plot Format " & pGraphFormat & vbCrLf
        If Len(pCPrintPlotPos) > 0 Then s = s & pCPrintPlotPos & vbCrLf
        If pPrintPlotPos Then 'default, don't print it
            '    S = S & "O Plot PrintPos YES" & vbCrLf
        Else
            s = s & "O Plot PrintPos NO" & vbCrLf
        End If
        If Len(pCPlotPos) > 0 Then s = s & pCPlotPos & vbCrLf
        If System.Math.Abs(pPlotPos) > 0.000001 Then 'not using default of 0, print it
            s = s & "O Plot Position " & CStr(pPlotPos) & vbCrLf
        End If
        If Len(pCAdditional) > 0 Then s = s & pCAdditional & vbCrLf
        If pAdditionalOutput = 1 Then
            s = s & "O Additional WDM" & vbCrLf
        ElseIf pAdditionalOutput = 2 Then
            s = s & "O Additional Watstore " & RelativeFilename(pAddOutFileName, pInputDir) & vbCrLf
        ElseIf pAdditionalOutput = 3 Then
            s = s & "O Additional Both WAT " & RelativeFilename(pAddOutFileName, pInputDir) & vbCrLf
        ElseIf pAdditionalOutput = 4 Then
            s = s & "O Additional Tab " & RelativeFilename(pAddOutFileName, pInputDir) & vbCrLf
        ElseIf pAdditionalOutput = 5 Then
            s = s & "O Additional Both Tab " & RelativeFilename(pAddOutFileName, pInputDir) & vbCrLf
        End If
        If Len(pCExportFileName) > 0 Then s = s & pCExportFileName & vbCrLf
        If Len(pExportFileName) > 0 Then s = s & "O Export " & RelativeFilename(pExportFileName, pInputDir) & vbCrLf
        If Len(pCEmpiricalFileName) > 0 Then s = s & pCEmpiricalFileName & vbCrLf
        If Len(pEmpiricalFileName) > 0 Then s = s & "O Empirical " & RelativeFilename(pEmpiricalFileName, pInputDir) & vbCrLf
        If Len(pCIntermediate) > 0 Then s = s & pCIntermediate & vbCrLf
        If pIntermediateResults Then s = s & "O Debug YES" & vbCrLf
        If Len(pCConfidenceInterval) > 0 Then s = s & pCConfidenceInterval & vbCrLf
        s = s & "O ConfInterval " & CStr(pConfidenceInterval) & vbCrLf
        If Len(pCExtendedOutput) > 0 Then s = s & pCExtendedOutput & vbCrLf
        If pExtendedOutput Then
            s = s & "O EXTENDED YES" & vbCrLf
        End If
        If Len(pCEMA) > 0 Then s = s & pCEMA & vbCrLf
        If pEMA Then
            s = s & "O EMA YES" & vbCrLf
        End If
        i = 0
        For Each vSta In pStations
            If vSta.AnalysisOption <> "Skip" Then 'write station specs to string
                If vSta.AnalysisOption = "B17B" OrElse vSta.CheckThreshSpecs Then
                    'always write out all station specs (decided w/USGS on 2/23/24)
                    s = s & vSta.WriteSpecsVerbose
                Else
                    MsgBox("For Station " & vSta.id & " use of a threshold range of 0 to infinity is unacceptable for periods of missing systematic record." & vbCrLf &
                           "Use a threshold range of infinity to infinity for periods of missing systematic record to indicate a lack of knowledge." & vbCrLf &
                           "If information is available, please specify a more appropriate lower threshold value (greater than 0 and less than infinity) or another more appropriate threshold range." & vbCrLf &
                           "Alternatively, to NOT run an EMA analysis on this site, on the Station Specifications Tab, select either Skip or B17B for the analysis option for this station.",
                           MsgBoxStyle.Information, "PeakFQ Run Problem")
                    s = ""
                    Exit For
                End If
                If vSta.SkewOpt > 0 AndAlso (vSta.GenSkew < -10 Or vSta.GenSkew > 10) Then
                    MsgBox("For Station " & vSta.id & " a valid Reional Skew value has not been entered." & vbCrLf &
                           "When using either the Weighted or Regional Skew option, a Generalized Skew value must be provided",
                           MsgBoxStyle.Information, "PeakFQ Run Problem")
                    s = ""
                    Exit For
                End If
                If vSta.SkewOpt > 0 AndAlso (vSta.SESkew <= 0 Or vSta.SESkew > 1) Then
                    MsgBox("For Station " & vSta.id & " a valid Regional Skew Standard Error value has not been entered." & vbCrLf &
                           "When using either the Weighted or Generalized Skew option, a Regional Skew Standard Error value (> 0.0) must be provided",
                           MsgBoxStyle.Information, "PeakFQ Run Problem")
                    s = ""
                    Exit For
                End If
            End If
            i = i + 1
        Next vSta
        SaveAsString = s

    End Function

    Public Sub BuildNewSpecFile(Optional ByRef tmpSpecName As String = "PKFQWPSF.TMP")
        'BuildNewSpecFile is called when a PeakFQ data file is opened
        'and a new spec file is needed for it to run PeakFQ.
        'Contains simplest set of specs: Input file, Output file, "Update" flag
        'It is given a temporary name (tmpSpecName) that will not be saved.
        Dim s As String

        If PathNameOnly(pDataFileName).Length > 0 Then
            pSpecFileName = PathNameOnly(pDataFileName) & "\" & tmpSpecName
        Else
            pSpecFileName = tmpSpecName
        End If
        If UCase(Right(pDataFileName, 3)) = "WDM" Then 'WDM data file
            s = "I WDM " & FilenameNoPath(pDataFileName) & vbCrLf
        Else 'assume asci text data file
            s = "I ASCI " & FilenameNoPath(pDataFileName) & vbCrLf
        End If
        pOutFile = IO.Path.ChangeExtension(pDataFileName, ".prt") '".out"
        s = s & "O File " & FilenameNoPath(pOutFile) & vbCrLf
        s = s & "Update"
        SaveFileString(pSpecFileName, s) '(PathNameOnly(pDataFileName) & "\" & pSpecFileName, s)

    End Sub

    Public Sub RunBatchModel()
        Dim s As String
        Dim oldlen, i, curlen As Integer

        On Error Resume Next

        If CurDir() <> PFQExePath Then
            'copy support files for fortran dll
            FileCopy(PFQExePath & "\pkfqms.wdm", "pkfqms.wdm")
        End If

        If IO.File.Exists(PfqPrj.OutFile) Then 'delete old output file
            IO.File.Delete(PfqPrj.OutFile)
        End If

        If TypeOf (Logger.ProgressStatus) Is MapWinUtility.NullProgressStatus Then
            Logger.ProgressStatus = New StatusMonitor 'MonitorProgressStatus
        End If
        Logger.Status("Begin")
        Logger.Status("Show")
        'Logger.Status("Caption PKFQWin Status")
        Logger.Status("Label Title PKFQWin 7.5.1 ")


        'Dim lSpecFileName As String = FilenameNoPath(pSpecFileName)
        Logger.Status("Running PeakFQ from " & CurDir() & " using spec file " & pSpecFileName, True)
        Call PEAKFQ(pSpecFileName, pSpecFileName.Length)

        If Not FileExists(PfqPrj.OutFile) Then
            Logger.Status("Problem running PeakFQ batch program.", True)
        Else
            Logger.Status("PeakFQ run successfully.", True)
        End If
        Logger.Status("Exit")
        Logger.ProgressStatus = New MapWinUtility.NullProgressStatus

        If CurDir() <> PFQExePath Then
            Kill("pkfqms.wdm")
        End If

    End Sub

    Public Function Copy() As pfqProject
        Dim oldStation As pfqStation = Nothing
        Dim newStation As pfqStation = Nothing
        Dim retval As New pfqProject
        Dim vPT As Object = Nothing

        With retval
            .AdditionalOutput = pAdditionalOutput
            .AddOutFileName = pAddOutFileName
            .ExportFileName = pExportFileName
            .EmpiricalFileName = pEmpiricalFileName
            .ConfidenceInterval = pConfidenceInterval
            .DataFileName = pDataFileName
            .DataType = pDataType
            .Graphic = pGraphic
            .GraphFormat = pGraphFormat
            .IntermediateResults = pIntermediateResults
            .LinePrinter = pLinePrinter
            .OutFile = pOutFile
            .PlotPos = pPlotPos
            .PrintPlotPos = pPrintPlotPos
            .InputDir = pInputDir
            .OutputDir = pOutputDir
            .EMA = pEMA
            .CDataFile = pCDataFile
            .COutFile = pCOutFile
            .CPlotStyle = pCPlotStyle
            .CPlotFormat = pCPlotFormat
            .CPrintPlotPos = pCPrintPlotPos
            .CPlotPos = pCPlotPos
            .CAdditional = pCAdditional
            .CExportFileName = pCExportFileName
            .CEmpiricalFileName = pCEmpiricalFileName
            .CIntermediate = pCIntermediate
            .CConfidenceInterval = pCConfidenceInterval
            .CEMA = pCEMA

            '.SpecFileName = pSpecFileName
            'UPGRADE_NOTE: Object retval.Stations may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            .Stations.Clear()
            '.Stations = Nothing
            For Each oldStation In Stations
                newStation = New pfqStation
                With newStation
                    .AnalysisOption = oldStation.AnalysisOption
                    .Thresholds = oldStation.Thresholds
                    .PeakData = oldStation.PeakData
                    .BegYear = oldStation.BegYear
                    .EndYear = oldStation.EndYear
                    .GageBaseDischarge = oldStation.GageBaseDischarge
                    .GenSkew = oldStation.GenSkew
                    .HighSysPeak = oldStation.HighSysPeak
                    .HighOutlier = oldStation.HighOutlier
                    .HistoricPeriod = oldStation.HistoricPeriod
                    .id = oldStation.id
                    .Lat = oldStation.Lat
                    .Lng = oldStation.Lng
                    .LowHistPeak = oldStation.LowHistPeak
                    .LowOutlier = oldStation.LowOutlier
                    .Name = oldStation.Name
                    .PlotMade = oldStation.PlotMade
                    .SESkew = oldStation.SESkew
                    .SkewOpt = oldStation.SkewOpt
                    .UrbanRegPeaks = oldStation.UrbanRegPeaks
                    .PlotName = oldStation.PlotName
                    .Comment = oldStation.Comment
                    .CGenSkew = oldStation.CGenSkew
                    .CSESkew = oldStation.CSESkew
                    .CBegYear = oldStation.CBegYear
                    .CEndYear = oldStation.CEndYear
                    .CHistoric = oldStation.CHistoric
                    .CSkewOpt = oldStation.CSkewOpt
                    .CUrban = oldStation.CUrban
                    .CLowOutlier = oldStation.CLowOutlier
                    .CHighOutlier = oldStation.CHighOutlier
                    .CGageBase = oldStation.CGageBase
                    .CLat = oldStation.CLat
                    .CLong = oldStation.CLong
                    .CPlotName = oldStation.CPlotName
                End With
                .Stations.Add(newStation)
                'UPGRADE_NOTE: Object newStation may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                newStation = Nothing
            Next oldStation
        End With
        Copy = retval
        'UPGRADE_NOTE: Object retval may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        retval = Nothing
    End Function

    Public Function SaveDefaults(ByRef FileStr As String) As pfqProject
        'Reads an existing spec file (contained in FileStr),
        'any station specfications found are assumed to be non-default
        'and are set to -999 so they will be written out if file is saved
        Dim prj As New pfqProject
        Dim i As Integer
        Dim Rec, Kwd As String
        Dim lCom As String
        Dim CommentPending As Boolean
        '  Dim CurStation As pfqStation

        CommentPending = False
        i = -1 '0
        prj = Me.Copy
        With prj
            While Len(FileStr) > 0
                Rec = StrSplit(FileStr, vbCrLf, "")
                If Left(Rec, 1) = "'" Then 'process comment
                    If CommentPending Then 'multiple line comment
                        lCom = lCom & vbCrLf & Rec
                    Else 'new comment
                        lCom = Rec
                        CommentPending = True
                    End If
                Else 'process specification
                    Kwd = UCase(StrRetRem(Rec))
                    Select Case Kwd
                        '        Case "I"
                        '          Kwd = UCase(StrRetRem(Rec))
                        '          For i = 0 To 1
                        '            If Kwd = FType(i) Then .DataType = i
                        '          Next i
                        '          .DataFileName = Rec
                        '        Case "O"
                        '          Kwd = UCase(StrRetRem(Rec))
                        '          Select Case Kwd
                        '            Case "FILE"
                        '              .OutFile = Rec
                        '            Case "PLOT"
                        '              Kwd = UCase(StrRetRem(Rec))
                        '              If Kwd = "STYLE" Then
                        '                If UCase(Rec) = "PRINTER" Or UCase(Rec) = "BOTH" Then
                        '                  .LinePrinter = True
                        '                End If
                        '                If UCase(Rec) = "GRAPHICS" Or UCase(Rec) = "BOTH" Then
                        '                  .Graphic = True
                        '                End If
                        '              ElseIf Kwd = "PRINTPOS" Then
                        '                If UCase(Rec) = "YES" Then
                        '                  .PrintPlotPos = True
                        '                Else
                        '                  .PrintPlotPos = False
                        '                End If
                        '              ElseIf Kwd = "POSITION" Then
                        '                .PlotPos = CSng(Rec)
                        '              End If
                        '            Case "ADDITIONAL"
                        '              Kwd = UCase(StrRetRem(Rec))
                        '              If Kwd = "WDM" Then
                        '                .AdditionalOutput = 1
                        '              ElseIf Left(Kwd, 3) = "WAT" Then
                        '                .AdditionalOutput = 2
                        '              ElseIf Kwd = "BOTH" Then
                        '                .AdditionalOutput = 3
                        '              Else
                        '                .AdditionalOutput = 0
                        '              End If
                        '              If pAdditionalOutput >= 2 Then
                        '                'remaining text should be file name
                        '                .AddOutFileName = Rec
                        '              End If
                        '            Case "DEBUG"
                        '              If UCase(Rec) = "YES" Then
                        '                .IntermediateResults = True
                        '              Else
                        '                .IntermediateResults = False
                        '              End If
                        '            Case "CONFIDENCE"
                        '              .ConfidenceLimits = CSng(Rec)
                        '          End Select
                        Case "STATION"
                            '          If Not CurStation Is Nothing Then
                            '            'previous station info exists, add it to collection
                            '            .Stations.Add CurStation
                            '          End If
                            '          'build new station
                            '          Set CurStation = New pfqStation
                            '          CurStation.id = Rec
                            i = i + 1
                            If CommentPending Then .Stations(i).Comment = lCom
                        Case "ANALYZE"
                            .Stations(i).AnalysisOption = "-999"
                            If CommentPending Then .Stations(i).CAnalysisOption = lCom
                        Case "LOTYPE"
                            .Stations(i).LOTestType = "-999"
                            If CommentPending Then .Stations(i).CLOTestType = lCom
                        Case "GENSKEW"
                            .Stations(i).GenSkew = -999.0#
                            If CommentPending Then .Stations(i).CGenSkew = lCom
                        Case "SKEWSE"
                            .Stations(i).SESkew = -999.0#
                            If CommentPending Then .Stations(i).CSESkew = lCom
                        Case "BEGYEAR"
                            .Stations(i).BegYear = -999.0#
                            If CommentPending Then .Stations(i).CBegYear = lCom
                        Case "ENDYEAR"
                            .Stations(i).EndYear = -999.0#
                            If CommentPending Then .Stations(i).CEndYear = lCom
                        Case "HISTPERIOD"
                            .Stations(i).HistoricPeriod = -999.0#
                            If CommentPending Then .Stations(i).CHistoric = lCom
                        Case "SKEWOPT"
                            .Stations(i).SkewOpt = -999.0#
                            If CommentPending Then .Stations(i).CSkewOpt = lCom
                        Case "URB/REG"
                            'set default to opposite of spec file so this spec will be written out
                            If Me.Stations(i).UrbanRegPeaks Then
                                .Stations(i).UrbanRegPeaks = True
                            Else
                                .Stations(i).UrbanRegPeaks = False
                            End If
                            If CommentPending Then .Stations(i).CUrban = lCom
                        Case "LOTHRESH"
                            If .Stations(i).LowOutlier > 0 Then .Stations(i).LowOutlier = -999.0#
                            If CommentPending Then .Stations(i).CLowOutlier = lCom
                        Case "HITHRESH"
                            If .Stations(i).HighOutlier > 0 Then .Stations(i).HighOutlier = -999.0#
                            If CommentPending Then .Stations(i).CHighOutlier = lCom
                        Case "GAGEBASE"
                            If .Stations(i).GageBaseDischarge Then .Stations(i).GageBaseDischarge = -999.0#
                            If CommentPending Then .Stations(i).CGageBase = lCom
                        Case "LATITUDE"
                            .Stations(i).Lat = -999.0#
                            If CommentPending Then .Stations(i).CLat = lCom
                        Case "LONGITUDE"
                            .Stations(i).Lng = -999.0#
                            If CommentPending Then .Stations(i).CLong = lCom
                        Case "PLOTNAME"
                            .Stations(i).PlotName = "-999"
                            If CommentPending Then .Stations(i).CPlotName = lCom
                    End Select
                    CommentPending = False 'assume any pending comment was stored with a specification
                End If
            End While
            '    If Not CurStation Is Nothing Then
            '      'station info exists, add it to collection
            '      .Stations.Add CurStation
            '      Set CurStation = Nothing
            '    End If
        End With

        SaveDefaults = prj

    End Function

    Public Sub ReadPeaks()
        Dim lInd As Integer = 0
        Dim i As Integer
        Dim lNPks As Integer
        Dim lPks(499) As Single
        Dim lPksSeq(499) As Integer
        Dim lIQual(499, 4) As Integer
        Dim lXQual(499) As String
        Dim lPeak As pfqStation.PeakDataType
        Dim lPeaks As Generic.List(Of pfqStation.PeakDataType)
        Dim lAllRegulated As Boolean = True

        For Each lStn As pfqStation In PfqPrj.Stations
            lPeaks = New Generic.List(Of pfqStation.PeakDataType)
            lInd += 1
            GETPEAKS(lInd, lNPks, lPks, lIQual, lPksSeq)
            NumChr(5, 500, lIQual, lXQual)
            For i = 0 To lNPks - 1
                lPeak = New pfqStation.PeakDataType
                lPeak.Year = Math.Abs(lPksSeq(i))
                lPeak.Value = lPks(i)
                lPeak.Code = lXQual(i)
                lPeak.LowerLimit = lPeak.Value
                lPeak.UpperLimit = lPeak.Value
                lPeaks.Add(lPeak)
                If Not lPeak.Code.Contains("H") And Not lPeak.Code.Contains("7") Then
                    If lStn.FirstSystematic = 0 Then lStn.FirstSystematic = lPeak.Year
                    lStn.LastSystematic = lPeak.Year
                End If
                If Not lPeak.Code.Contains("K") And Not lPeak.Code.Contains("C") And Not lPeak.Code.Contains("6") Then lAllRegulated = False
            Next i
            lPeaks.Sort()
            lStn.FirstPeak = lPeaks(0).Year
            lStn.LastPeak = lPeaks(lPeaks.Count - 1).Year

            'save original peaks read from data file
            lStn.PeakDataOrig = New Generic.List(Of pfqStation.PeakDataType)
            For Each lPeak In lPeaks
                lStn.PeakDataOrig.Add(lPeak.Clone)
            Next

            If lStn.PeakData.Count > 0 Then 'merge peaks with peak info from spec file
                Dim lMatchingYearIndex As Integer
                For Each lSpecPeak As pfqStation.PeakDataType In lStn.PeakData
                    lMatchingYearIndex = -1
                    i = 0
                    For Each lPeak In lPeaks
                        If Math.Abs(lSpecPeak.Year) = Math.Abs(lPeak.Year) Then
                            lMatchingYearIndex = i
                            Exit For
                        End If
                        i += 1
                    Next
                    If lMatchingYearIndex >= 0 Then 'replace this peak with spec file peak
                        If Math.Abs(lPeaks(i).Value) > 0 AndAlso lSpecPeak.Value = 0 Then 'preserve original peak value & code
                            lSpecPeak.Value = lPeaks(i).Value
                            lSpecPeak.Code = lPeaks(i).Code
                        End If
                        lPeaks.RemoveAt(i)
                    End If
                    lPeaks.Add(lSpecPeak) 'add spec file peak to data peaks
                Next
                lPeaks.Sort()
            End If

            lStn.PeakData = lPeaks
            If lStn.Thresholds.Count < 1 Then
                lStn.SetDefaultThresholds(lStn.BegYear, lStn.EndYear)
            End If
        Next
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

    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()
        pSpecFileName = ""
        pDataFileName = ""
        pStations = New Generic.List(Of pfqStation)
        pAdditionalOutput = 0
        pAddOutFileName = ""
        pExportFileName = ""
        pEmpiricalFileName = ""
        pIntermediateResults = False
        pLinePrinter = False
        pGraphic = False
        pGraphFormat = ""
        pPrintPlotPos = True
        pPlotPos = 0#
        pConfidenceInterval = 0.9
        FType(0) = "ASCI"
		FType(1) = "WDM"
        pOutputDir = ""
        pExtendedOutput = False
        pEMA = True
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
End Class
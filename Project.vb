Option Strict Off
Option Explicit On

Imports atcUtility
Imports MapWinUtility


Friend Class pfqProject
	
	Private pPFQExeFileName As String
	Private pSpecFileName As String
	Private pDataFileName As String
	Private pDataType As Integer '0 - ASCII(Watstore), 1 - WDM
    Private pStations As Generic.List(Of pfqStation)
	Private pOutFile As String
	Private pAdditionalOutput As Integer
	Private pAddOutFileName As String
	Private pIntermediateResults As Boolean
	Private pLinePrinter As Boolean
	Private pGraphic As Boolean
	Private pGraphFormat As String
	Private pPrintPlotPos As Boolean
	Private pPlotPos As Single
	Private pConfidenceLimits As Single
	Private pInputDir As String
	Private pOutputDir As String
	Private pEMA As Boolean
	'the following are for storing comments for various specification records
	Private pCDataFile As String
	Private pCOutFile As String
	Private pCPlotStyle As String
	Private pCPlotFormat As String
	Private pCPrintPlotPos As String
	Private pCPlotPos As String
	Private pCAdditional As String
	Private pCIntermediate As String
	Private pCConfidenceLimits As String
	Private pCEMA As String
	
	Private FType(1) As String
	
	Public Property PFQExeFileName() As String
		Get
			PFQExeFileName = pPFQExeFileName
		End Get
		Set(ByVal Value As String)
			pPFQExeFileName = Value
		End Set
	End Property
	
	Public Property SpecFileName() As String
		Get
			SpecFileName = pSpecFileName
		End Get
		Set(ByVal Value As String)
			Dim LastFile, s, CurFile As String
			Dim FileIsStatic As Boolean
			
			pSpecFileName = Value
			'  ReadSpecFile
			'  If pStations.Count = 0 Then 'may be defaulted to do all stations
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
	
	Public Property IntermediateResults() As Boolean
		Get
			IntermediateResults = pIntermediateResults
		End Get
		Set(ByVal Value As Boolean)
			pIntermediateResults = Value
		End Set
	End Property
	
	Public Property ConfidenceLimits() As Single
		Get
			ConfidenceLimits = pConfidenceLimits
		End Get
		Set(ByVal Value As Single)
			pConfidenceLimits = Value
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
	
	Public Property CIntermediate() As String
		Get
			CIntermediate = pCIntermediate
		End Get
		Set(ByVal Value As String)
			pCIntermediate = Value
		End Set
	End Property
	
	Public Property CConfidenceLimits() As String
		Get
			CConfidenceLimits = pCConfidenceLimits
		End Get
		Set(ByVal Value As String)
			pCConfidenceLimits = Value
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
	
	Public Sub ReadSpecFile()
		
		Dim i As Short
		Dim SpecFile As String
		Dim Rec, Kwd As String
        Dim lCom As String = ""
		Dim CommentPending As Boolean
        Dim CurStation As pfqStation = Nothing
        Dim lThresh As pfqStation.ThresholdType = Nothing
        Dim lInterval As pfqStation.IntervalType = Nothing
		
		CommentPending = False
        pStations = New Generic.List(Of pfqStation)
		SpecFile = WholeFileString(pSpecFileName)
		
		While Len(SpecFile) > 0
			Rec = StrSplit(SpecFile, vbCrLf, "")
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
							Case "DEBUG"
								If UCase(Rec) = "YES" Then
									pIntermediateResults = True
								Else
									pIntermediateResults = False
								End If
								If CommentPending Then pCIntermediate = lCom
							Case "CONFIDENCE"
								pConfidenceLimits = CSng(Rec)
								If CommentPending Then pCConfidenceLimits = lCom
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
						If CommentPending Then CurStation.Comment = lCom
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
					Case "SKEWOPT"
						If UCase(Rec) = "STATION" Then
                            CurStation.SkewOpt = 0
						ElseIf UCase(Rec) = "WEIGHTED" Then 
                            CurStation.SkewOpt = 1
						ElseIf UCase(Rec) = "GENERALIZED" Then 
                            CurStation.SkewOpt = 2
						End If
						If CommentPending Then CurStation.CSkewOpt = lCom
					Case "URB/REG"
						If UCase(Rec) = "YES" Then
							CurStation.UrbanRegPeaks = 1
						Else
							CurStation.UrbanRegPeaks = 0
						End If
						If CommentPending Then CurStation.CUrban = lCom
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
                        CurStation.Thresholds.Add(lThresh)
                    Case "INTERVAL"
                        lInterval = New pfqStation.IntervalType
                        lInterval.Year = CSng(StrRetRem(Rec))
                        lInterval.LowerLimit = CSng(StrRetRem(Rec))
                        lInterval.UpperLimit = CSng(StrRetRem(Rec))
                        CurStation.Intervals.Add(lInterval)
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
		s = s & "I " & FType(pDataType) & " " & pInputDir & "\" & FilenameNoPath(pDataFileName) & vbCrLf
		If Len(pCOutFile) > 0 Then s = s & pCOutFile & vbCrLf
		s = s & "O File " & pOutputDir & "\" & FilenameNoPath(pOutFile) & vbCrLf
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
			s = s & "O Additional Watstore " & pAddOutFileName & vbCrLf
		ElseIf pAdditionalOutput = 3 Then 
			s = s & "O Additional Both WAT " & pAddOutFileName & vbCrLf
		ElseIf pAdditionalOutput = 4 Then 
			s = s & "O Additional Tab " & pAddOutFileName & vbCrLf
		ElseIf pAdditionalOutput = 5 Then 
			s = s & "O Additional Both Tab " & pAddOutFileName & vbCrLf
		End If
		If Len(pCIntermediate) > 0 Then s = s & pCIntermediate & vbCrLf
		If pIntermediateResults Then s = s & "O Debug YES" & vbCrLf
		If Len(pCConfidenceLimits) > 0 Then s = s & pCConfidenceLimits & vbCrLf
		If System.Math.Abs(pConfidenceLimits - 0.95) > 0.000001 Then 'not using .95, print it
			s = s & "O Confidence " & CStr(pConfidenceLimits) & vbCrLf
		End If
		If Len(pCEMA) > 0 Then s = s & pCEMA & vbCrLf
		If pEMA Then
			s = s & "O EMA YES" & vbCrLf
		End If
		i = 0
		For	Each vSta In pStations
			i = i + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object vSta.Active. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If vSta.Active Then 'write station specs to string
				If DefPrj Is Nothing Then 'write out all station specs
					'UPGRADE_WARNING: Couldn't resolve default property of object vSta.WriteSpecsVerbose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					s = s & vSta.WriteSpecsVerbose
				Else 'only write out non-default station specs
					defsta = DefPrj.Stations(i)
					'UPGRADE_WARNING: Couldn't resolve default property of object vSta.WriteSpecsNonDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					s = s & vSta.WriteSpecsNonDefault(defsta)
					'UPGRADE_NOTE: Object defsta may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					defsta = Nothing
				End If
			End If
		Next vSta
		SaveAsString = s
		
	End Function
	
	Public Sub BuildNewSpecFile(Optional ByRef tmpSpecName As String = "PKFQWPSF.TMP")
		'BuildNewSpecFile is called when a PeakFQ data file is opened
		'and a new spec file is needed for it to run PeakFQ.
		'Contains simplest set of specs: Input file, Output file, "Update" flag
		'It is given a temporary name (tmpSpecName) that will not be saved.
		Dim s As String
		
		pSpecFileName = tmpSpecName
		If UCase(Right(pDataFileName, 3)) = "WDM" Then 'WDM data file
			s = "I WDM " & FilenameNoPath(pDataFileName) & vbCrLf
		Else 'assume asci text data file
			s = "I ASCI " & FilenameNoPath(pDataFileName) & vbCrLf
		End If
        pOutFile = IO.Path.ChangeExtension(pDataFileName, ".prt") '".out"
		s = s & "O File " & FilenameNoPath(pOutFile) & vbCrLf
		s = s & "Update"
		SaveFileString(pSpecFileName, s)
		
	End Sub
	
	Public Sub RunBatchModel()
		Dim s As String
		Dim oldlen, i, curlen As Integer
		
		On Error Resume Next
		If Len(pPFQExeFileName) > 0 Then
			If CurDir() <> PathNameOnly(pPFQExeFileName) Then
				'copy support files for batch executable
				FileCopy(PathNameOnly(pPFQExeFileName) & "\pkfqms.wdm", "pkfqms.wdm")
				FileCopy(PathNameOnly(pPFQExeFileName) & "\interact.ini", "interact.ini")
			End If
			
			If FileExists(PfqPrj.OutFile) Then 'delete old output file
				Kill(PfqPrj.OutFile)
			End If
			
            'gIPC.SendMonitorMessage("(Caption PKFQWin Status)")
            'gIPC.SendMonitorMessage("Starting " & pPFQExeFileName)
            Logger.Status("Caption PKFQWin Status")
            Logger.Status("Starting " & pPFQExeFileName)
            Dim lProcess As New Process
            With lProcess.StartInfo
                .FileName = pPFQExeFileName
                .WorkingDirectory = CurDir()
                .Arguments = FilenameNoPath(pSpecFileName)
                .CreateNoWindow = True
                .UseShellExecute = False
            End With
            lProcess.Start()

            'If lProcess Is Nothing Then
            '    'gIPC.SendMonitorMessage("(Open)")
            '    'gIPC.SendMonitorMessage("(MSG1 Unable to start PeakFQ batch program.)")
            '    Logger.Status("Unable to start PeakFQ batch program.")
            'Else
            lProcess.WaitForExit(60000)
            If Not FileExists(PfqPrj.OutFile) Then
                'gIPC.SendMonitorMessage("(Open)")
                'gIPC.SendMonitorMessage("(MSG1 Problem running PeakFQ batch program.)")
                Logger.Status("Problem running PeakFQ batch program.")
            End If
            'End If

            '    i = Shell(pPFQExeFileName & " " & FilenameNoPath(pSpecFileName) & " >PeakFQ.run")
            '    oldlen = -1
            '    curlen = 0
            '    If i > 0 Then
            '      'this while loop should be replaced with StatusMonitor
            '      While oldlen <> curlen
            '        If FileExists(PfqPrj.OutFile) Then
            '          oldlen = FileLen(PfqPrj.OutFile)
            '        Else
            '          oldlen = 0
            '        End If
            '        Sleep 2000
            '        If FileExists(PfqPrj.OutFile) Then
            '          curlen = FileLen(PfqPrj.OutFile)
            '        Else 'problem if still no output file
            '          curlen = 0
            '        End If
            '      Wend
            '    End If
            '    If curlen = 0 Then
            '      MsgBox "Problem running PeakFQ batch program." & vbCrLf & _
            ''             "Check PeakFQ.RUN file for details", vbExclamation, "PKFQWin"
            '    End If
            If CurDir() <> PathNameOnly(pPFQExeFileName) Then
                Kill("pkfqms.wdm")
                Kill("interact.ini")
            End If

            '    this code works fine for first run,
            '    but not when VERBOSE spec file already exists
            '    s = WholeFileString(pSpecFileName)
            '    While UCase(Left(s, 7)) <> "VERBOSE"
            '      'when specfile has been written in Verbose mode the batch run has ended
            '      Sleep 2000
            '      s = WholeFileString(pSpecFileName)
            '    Wend
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
			.ConfidenceLimits = pConfidenceLimits
			.DataFileName = pDataFileName
			.DataType = pDataType
			.Graphic = pGraphic
			.GraphFormat = pGraphFormat
			.IntermediateResults = pIntermediateResults
			.LinePrinter = pLinePrinter
			.OutFile = pOutFile
			.PFQExeFileName = pPFQExeFileName
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
			.CIntermediate = pCIntermediate
			.CConfidenceLimits = pCConfidenceLimits
			.CEMA = pCEMA
			
            '.SpecFileName = pSpecFileName
            'UPGRADE_NOTE: Object retval.Stations may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            .Stations.Clear()
            '.Stations = Nothing
            For Each oldStation In Stations
                newStation = New pfqStation
                With newStation
                    .Active = oldStation.Active
                    'For Each vPT In oldStation.PerceptThresh
                    'Next

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
		i = 0
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
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().Comment. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).Comment = lCom
						Case "GENSKEW"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().GenSkew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).GenSkew = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CGenSkew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CGenSkew = lCom
						Case "SKEWSE"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().SESkew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).SESkew = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CSESkew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CSESkew = lCom
						Case "BEGYEAR"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().BegYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).BegYear = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CBegYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CBegYear = lCom
						Case "ENDYEAR"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().EndYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).EndYear = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CEndYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CEndYear = lCom
						Case "HISTPERIOD"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().HistoricPeriod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).HistoricPeriod = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CHistoric. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CHistoric = lCom
						Case "SKEWOPT"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().SkewOpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).SkewOpt = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CSkewOpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CSkewOpt = lCom
						Case "URB/REG"
							'set default to opposite of spec file so this spec will be written out
							'UPGRADE_WARNING: Couldn't resolve default property of object Me.Stations(i).UrbanRegPeaks. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If Me.Stations(i).UrbanRegPeaks Then
								'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().UrbanRegPeaks. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								.Stations(i).UrbanRegPeaks = False
							Else
								'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().UrbanRegPeaks. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								.Stations(i).UrbanRegPeaks = True
							End If
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CUrban. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CUrban = lCom
						Case "LOTHRESH"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().LowOutlier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).LowOutlier = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CLowOutlier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CLowOutlier = lCom
						Case "HITHRESH"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().HighOutlier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).HighOutlier = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CHighOutlier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CHighOutlier = lCom
						Case "GAGEBASE"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().GageBaseDischarge. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).GageBaseDischarge = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CGageBase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CGageBase = lCom
						Case "LATITUDE"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().Lat. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).Lat = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CLat. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CLat = lCom
						Case "LONGITUDE"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().Lng. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).Lng = -999#
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CLong. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If CommentPending Then .Stations(i).CLong = lCom
						Case "PLOTNAME"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().PlotName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Stations(i).PlotName = "-999"
							'UPGRADE_WARNING: Couldn't resolve default property of object prj.Stations().CPlotName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
	
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		pPFQExeFileName = ""
		pSpecFileName = ""
		pDataFileName = ""
        pStations = New Generic.List(Of pfqStation)
		pAdditionalOutput = 0
		pIntermediateResults = False
		pLinePrinter = False
		pGraphic = False
		pGraphFormat = ""
		pPrintPlotPos = True
		pPlotPos = 0#
		pConfidenceLimits = 0.95
		FType(0) = "ASCI"
		FType(1) = "WDM"
		pOutputDir = ""
		pEMA = False
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
End Class
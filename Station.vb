Option Strict Off
Option Explicit On

Imports atcUtility

Friend Class pfqStation

    Public Structure ThresholdType
        Dim SYear As Integer
        Dim EYear As Integer
        Dim LowerLimit As Single
        Dim UpperLimit As Single
        Dim Comment As String
    End Structure

    Public Class PeakDataType
        Implements IComparable

        Public Year As Integer
        Public Value As Double
        Public Code As String = ""
        Public LowerLimit As Single = -999
        Public UpperLimit As Single = -999
        Public Comment As String = ""

        Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            Return Year.CompareTo(obj.Year)
        End Function

        Public Function Clone() As PeakDataType
            Dim lNewPeak As New PeakDataType
            lNewPeak.Code = Code.Clone
            lNewPeak.Comment = Comment.Clone
            lNewPeak.LowerLimit = LowerLimit
            lNewPeak.UpperLimit = UpperLimit
            lNewPeak.Value = Value
            lNewPeak.Year = Year
            Return lNewPeak
        End Function
    End Class

    Private pID As String
    Private pName As String
    Private pAnalysisOption As String 'Skip, B17B, EMA
    Private pBegYear As Integer
    Private pEndYear As Integer
    Private pSkewOpt As Integer '0 - Station, 1 - Weighted, 2 - Generalized
    Private pUrbanRegPeaks As Boolean
    Private pHistoricPeriod As Boolean
    Private pGenSkew As Single
    Private pHighSysPeak As Single
    Private pHighOutlier As Single
    Private pLowHistPeak As Single
    Private pLOTestType As String
    Private pLowOutlier As Single
    Private pGageBaseDischarge As Single
    Private pSESkew As Single
    Private pLat As Single
    Private pLng As Single
    Private pPlotName As String
    Private pPlotMade As Boolean
    Public Thresholds As Generic.List(Of ThresholdType)
    Private pPeakDataOrig As Generic.List(Of PeakDataType)
    Private pPeakData As Generic.List(Of PeakDataType)
    Private pFirstSystematic As Integer
    Private pLastSystematic As Integer
    Private pFirstPeak As Integer
    Private pLastPeak As Integer
    'the following are for storing comments for various specification records
    Private pComment As String
    Private pCAnalysisOption As String
    Private pCGenSkew As String
    Private pCSESkew As String
    Private pCBegYear As String
    Private pCEndYear As String
    Private pCHistoric As String
    Private pCSkewOpt As String
    Private pCUrban As String
    Private pCLowOutlier As String
    Private pCHighOutlier As String
    Private pCGageBase As String
    Private pCLat As String
    Private pCLong As String
    Private pCPlotName As String
    Private pCThresholds As String
    Private pCIntervals As String
    Private pCLOTestType As String

    'UPGRADE_ISSUE: Declaration type not supported: Array with lower bound less than zero. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    'Private SOText(-1 To 1) As String
    Private SOText(2) As String

    Public Property id() As String
        Get
            id = pID
        End Get
        Set(ByVal Value As String)
            pID = Value
        End Set
    End Property

    Public Property Name() As String
        Get
            Name = pName
        End Get
        Set(ByVal Value As String)
            pName = Value
        End Set
    End Property

    Public Property AnalysisOption() As String
        Get
            AnalysisOption = pAnalysisOption
        End Get
        Set(ByVal Value As String)
            pAnalysisOption = Value
        End Set
    End Property

    Public Property BegYear() As Integer
        Get
            BegYear = pBegYear
        End Get
        Set(ByVal Value As Integer)
            pBegYear = Value
        End Set
    End Property

    Public Property EndYear() As Integer
        Get
            EndYear = pEndYear
        End Get
        Set(ByVal Value As Integer)
            pEndYear = Value
        End Set
    End Property

    Public Property SkewOpt() As Integer
        Get
            SkewOpt = pSkewOpt
        End Get
        Set(ByVal Value As Integer)
            pSkewOpt = Value
        End Set
    End Property

    Public Property UrbanRegPeaks() As Boolean
        Get
            UrbanRegPeaks = pUrbanRegPeaks
        End Get
        Set(ByVal Value As Boolean)
            pUrbanRegPeaks = Value
        End Set
    End Property

    Public Property HistoricPeriod() As Boolean
        Get
            HistoricPeriod = pHistoricPeriod
        End Get
        Set(ByVal Value As Boolean)
            pHistoricPeriod = Value
        End Set
    End Property

    Public Property GenSkew() As Single
        Get
            GenSkew = pGenSkew
        End Get
        Set(ByVal Value As Single)
            pGenSkew = Value
        End Set
    End Property

    Public Property HighSysPeak() As Single
        Get
            HighSysPeak = pHighSysPeak
        End Get
        Set(ByVal Value As Single)
            pHighSysPeak = Value
        End Set
    End Property

    Public Property HighOutlier() As Single
        Get
            HighOutlier = pHighOutlier
        End Get
        Set(ByVal Value As Single)
            pHighOutlier = Value
        End Set
    End Property

    Public Property LowHistPeak() As Single
        Get
            LowHistPeak = pLowHistPeak
        End Get
        Set(ByVal Value As Single)
            pLowHistPeak = Value
        End Set
    End Property

    Public Property LowOutlier() As Single
        Get
            LowOutlier = pLowOutlier
        End Get
        Set(ByVal Value As Single)
            pLowOutlier = Value
        End Set
    End Property

    Public Property GageBaseDischarge() As Single
        Get
            GageBaseDischarge = pGageBaseDischarge
        End Get
        Set(ByVal Value As Single)
            pGageBaseDischarge = Value
        End Set
    End Property

    Public Property SESkew() As Single
        Get
            SESkew = pSESkew
        End Get
        Set(ByVal Value As Single)
            pSESkew = Value
        End Set
    End Property

    Public Property Lat() As Single
        Get
            Lat = pLat
        End Get
        Set(ByVal Value As Single)
            pLat = Value
        End Set
    End Property

    Public Property Lng() As Single
        Get
            Lng = pLng
        End Get
        Set(ByVal Value As Single)
            pLng = Value
        End Set
    End Property

    Public Property PlotName() As String
        Get
            PlotName = pPlotName
        End Get
        Set(ByVal Value As String)
            pPlotName = Value
        End Set
    End Property

    Public Property PlotMade() As Boolean
        Get
            PlotMade = pPlotMade
        End Get
        Set(ByVal Value As Boolean)
            pPlotMade = Value
        End Set
    End Property

    'Public Property Thresholds() As Generic.List(Of pfqStation.ThresholdType)
    '    Get
    '        If pThresholds Is Nothing Then pThresholds = New Generic.List(Of pfqStation.ThresholdType)
    '        Thresholds = pThresholds
    '    End Get
    '    Set(ByVal Value As Generic.List(Of pfqStation.ThresholdType))
    '        pThresholds = Value
    '    End Set
    'End Property

    Public Property PeakDataOrig() As Generic.List(Of pfqStation.PeakDataType)
        Get
            If pPeakDataOrig Is Nothing Then pPeakDataOrig = New Generic.List(Of pfqStation.PeakDataType)
            Return pPeakDataOrig
        End Get
        Set(ByVal Value As Generic.List(Of pfqStation.PeakDataType))
            pPeakDataOrig = Value
        End Set
    End Property

    Public Property PeakData() As Generic.List(Of pfqStation.PeakDataType)
        Get
            If pPeakData Is Nothing Then pPeakData = New Generic.List(Of pfqStation.PeakDataType)
            Return pPeakData
        End Get
        Set(ByVal Value As Generic.List(Of pfqStation.PeakDataType))
            pPeakData = Value
        End Set
    End Property

    Public Property Comment() As String
        Get
            Comment = pComment
        End Get
        Set(ByVal Value As String)
            pComment = Value
        End Set
    End Property

    Public Property CAnalysisOption() As String
        Get
            CAnalysisOption = pCAnalysisOption
        End Get
        Set(ByVal Value As String)
            pCAnalysisOption = Value
        End Set
    End Property

    Public Property CGenSkew() As String
        Get
            CGenSkew = pCGenSkew
        End Get
        Set(ByVal Value As String)
            pCGenSkew = Value
        End Set
    End Property

    Public Property CSESkew() As String
        Get
            CSESkew = pCSESkew
        End Get
        Set(ByVal Value As String)
            pCSESkew = Value
        End Set
    End Property

    Public Property CBegYear() As String
        Get
            CBegYear = pCBegYear
        End Get
        Set(ByVal Value As String)
            pCBegYear = Value
        End Set
    End Property

    Public Property CEndYear() As String
        Get
            CEndYear = pCEndYear
        End Get
        Set(ByVal Value As String)
            pCEndYear = Value
        End Set
    End Property

    Public Property CHistoric() As String
        Get
            CHistoric = pCHistoric
        End Get
        Set(ByVal Value As String)
            pCHistoric = Value
        End Set
    End Property

    Public Property CSkewOpt() As String
        Get
            CSkewOpt = pCSkewOpt
        End Get
        Set(ByVal Value As String)
            pCSkewOpt = Value
        End Set
    End Property

    Public Property CUrban() As String
        Get
            CUrban = pCUrban
        End Get
        Set(ByVal Value As String)
            pCUrban = Value
        End Set
    End Property

    Public Property CLowOutlier() As String
        Get
            CLowOutlier = pCLowOutlier
        End Get
        Set(ByVal Value As String)
            pCLowOutlier = Value
        End Set
    End Property

    Public Property CHighOutlier() As String
        Get
            CHighOutlier = pCHighOutlier
        End Get
        Set(ByVal Value As String)
            pCHighOutlier = Value
        End Set
    End Property

    Public Property CGageBase() As String
        Get
            CGageBase = pCGageBase
        End Get
        Set(ByVal Value As String)
            pCGageBase = Value
        End Set
    End Property

    Public Property CLat() As String
        Get
            CLat = pCLat
        End Get
        Set(ByVal Value As String)
            pCLat = Value
        End Set
    End Property

    Public Property CLong() As String
        Get
            CLong = pCLong
        End Get
        Set(ByVal Value As String)
            pCLong = Value
        End Set
    End Property

    Public Property CPlotName() As String
        Get
            CPlotName = pCPlotName
        End Get
        Set(ByVal Value As String)
            pCPlotName = Value
        End Set
    End Property

    Public Property CThresholds() As String
        Get
            CThresholds = pCThresholds
        End Get
        Set(ByVal Value As String)
            pCThresholds = Value
        End Set
    End Property

    Public Property CIntervals() As String
        Get
            CIntervals = pCIntervals
        End Get
        Set(ByVal Value As String)
            pCIntervals = Value
        End Set
    End Property

    Public Property LOTestType() As String
        Get
            LOTestType = pLOTestType
        End Get
        Set(ByVal Value As String)
            pLOTestType = Value
        End Set
    End Property

    Public Property CLOTestType() As String
        Get
            CLOTestType = pCLOTestType
        End Get
        Set(ByVal Value As String)
            pCLOTestType = Value
        End Set
    End Property

    Public Property FirstSystematic() As Integer
        Get
            FirstSystematic = pFirstSystematic
        End Get
        Set(ByVal Value As Integer)
            pFirstSystematic = Value
        End Set
    End Property

    Public Property LastSystematic() As Integer
        Get
            LastSystematic = pLastSystematic
        End Get
        Set(ByVal Value As Integer)
            pLastSystematic = Value
        End Set
    End Property

    Public Property FirstPeak() As Integer
        Get
            FirstPeak = pFirstPeak
        End Get
        Set(ByVal Value As Integer)
            pFirstPeak = Value
        End Set
    End Property

    Public Property LastPeak() As Integer
        Get
            LastPeak = pLastPeak
        End Get
        Set(ByVal Value As Integer)
            pLastPeak = Value
        End Set
    End Property

    Public Function WriteSpecsVerbose() As String

        Dim s As String
        Const pad As String = "     "

        If Len(pComment) > 0 Then
            s = pComment & vbCrLf & "Station " & pID & vbCrLf
        Else
            s = "Station " & pID & vbCrLf
        End If
        If Len(pCAnalysisOption) > 0 Then
            s = s & pad & pCAnalysisOption & vbCrLf & pad & "Analyze " & pAnalysisOption & vbCrLf
        Else
            s = s & pad & "Analyze " & pAnalysisOption & vbCrLf
        End If
        If Thresholds.Count > 0 AndAlso pAnalysisOption.ToUpper = "EMA" Then 'using perception threshholds, not beg/end years and hist. period
            For Each vPT As ThresholdType In Thresholds
                s = s & pad & "PCPT_Thresh " & vPT.SYear & " " & vPT.EYear & " " & vPT.LowerLimit & " " & vPT.UpperLimit & " " & vPT.Comment & vbCrLf
            Next
        End If
        If Len(pCBegYear) > 0 Then s = s & pad & pCBegYear & vbCrLf
        If pBegYear > 0 Then s = s & pad & "BegYear " & CStr(pBegYear) & vbCrLf
        If Len(pCEndYear) > 0 Then s = s & pad & pCEndYear & vbCrLf
        If pEndYear > 0 Then s = s & pad & "EndYear " & CStr(pEndYear) & vbCrLf
        If Len(pCHistoric) > 0 Then s = s & pad & pCHistoric & vbCrLf
        If pHistoricPeriod Then
            s = s & pad & "HistPeriod " & CStr(pEndYear - pBegYear + 1) & vbCrLf
        Else
            s = s & pad & "'NO Historic Period in use" & vbCrLf
        End If
        'write any interval data or updated peak data
        For Each vData As PeakDataType In pPeakData
            If Not PeakDataOrigContains(vData) Then 'new or revised peak
                If vData.Year > 0 AndAlso vData.LowerLimit >= 0 AndAlso vData.UpperLimit > 0 AndAlso _
                    Math.Abs(vData.UpperLimit - vData.LowerLimit) > 0.001 Then 'interval data
                    s = s & pad & "Interval " & vData.Year & " " & vData.LowerLimit & " " & vData.UpperLimit & " " & vData.Comment & vbCrLf
                Else 'just revised peak data
                    s = s & pad & "Peak " & vData.Year & " " & vData.Value & " " & vData.Code
                    If vData.Comment.Length > 0 Then s = s & "  '" & vData.Comment & vbCrLf Else s = s & vbCrLf
                End If
            End If
        Next
        If Len(pCSkewOpt) > 0 Then s = s & pad & pCSkewOpt & vbCrLf
        s = s & pad & "SkewOpt " & SOText(pSkewOpt) & vbCrLf
        If Len(pCGenSkew) > 0 Then s = s & pad & pCGenSkew & vbCrLf
        s = s & pad & "GenSkew " & pGenSkew & vbCrLf
        If Len(pCSESkew) > 0 Then s = s & pad & pCSESkew & vbCrLf
        s = s & pad & "SkewSE " & pSESkew & vbCrLf
        If Len(pCUrban) > 0 Then s = s & pad & pCUrban & vbCrLf
        If pUrbanRegPeaks Then s = s & pad & "Urb/Reg YES" & vbCrLf
        If Len(pCLowOutlier) > 0 Then s = s & pad & pCLowOutlier & vbCrLf
        If pLowOutlier > 0 Then 'write record showing specified low outlier
            s = s & pad & "LoThresh " & CStr(pLowOutlier) & vbCrLf
            'when LO specified there's no need for LO Test type
            s = s & pad & "LOType FIXED" & vbCrLf
        Else 'need a low outlier test type
            If Len(pCLOTestType) > 0 Then s = s & pad & pCLOTestType & vbCrLf
            If pLOTestType.StartsWith("Multiple") Then
                s = s & pad & "LOType MGBT" & vbCrLf
            Else
                s = s & pad & "LOType GBT" & vbCrLf
            End If
        End If
        If Len(pCHighOutlier) > 0 Then s = s & pad & pCHighOutlier & vbCrLf
        If pHighOutlier > 0 Then s = s & pad & "HiThresh " & CStr(pHighOutlier) & vbCrLf
        If Len(pCGageBase) > 0 Then s = s & pad & pCGageBase & vbCrLf
        If pGageBaseDischarge > 0 Then s = s & pad & "GageBase " & CStr(pGageBaseDischarge) & vbCrLf
        If Len(pCLat) > 0 Then s = s & pad & pCLat & vbCrLf
        If pLat > 0 Then s = s & pad & "Latitude " & CStr(pLat) & vbCrLf
        If Len(pCLong) > 0 Then s = s & pad & pCLong & vbCrLf
        If pLng > 0 Then s = s & pad & "Longitude " & CStr(pLng) & vbCrLf
        If Len(pCLowOutlier) > 0 Then s = s & pad & pCLowOutlier & vbCrLf
        If Len(pCPlotName) > 0 Then s = s & pad & pCPlotName & vbCrLf
        If Len(pPlotName) > 0 Then s = s & pad & "PlotName " & pPlotName & vbCrLf
        WriteSpecsVerbose = s

    End Function

    Public Function WriteSpecsNonDefault(ByRef defsta As pfqStation) As String

        Dim s As String
        Const pad As String = "     "

        '!!! KLUGE WARNING: Station comments get lost in active project,
        'due to batch program not preserving comments, so comments are
        'extracted from default project
        If Len(defsta.Comment) > 0 Then
            s = defsta.Comment & vbCrLf & "Station " & pID & vbCrLf
        Else
            s = "Station " & pID & vbCrLf
        End If
        If Len(defsta.CAnalysisOption) > 0 Then s = s & pad & defsta.CAnalysisOption & vbCrLf
        'If pAnalysisOption <> defsta.AnalysisOption Then s = s & pad & "Analyze " & pAnalysisOption & vbCrLf
        'always write analysis option
        s = s & pad & "Analyze " & pAnalysisOption & vbCrLf
        If Thresholds.Count > 0 AndAlso pAnalysisOption.ToUpper = "EMA" Then 'using perception threshholds
            For Each vPT As ThresholdType In Thresholds
                s = s & pad & "PCPT_Thresh " & vPT.SYear & " " & vPT.EYear & " " & vPT.LowerLimit & " " & vPT.UpperLimit & " " & vPT.Comment & vbCrLf
            Next
        End If
        'write any interval data or updated peak data
        For Each vData As PeakDataType In pPeakData
            If Not PeakDataOrigContains(vData) Then 'new or revised peak/interval
                If vData.Year > 0 AndAlso vData.LowerLimit >= 0 AndAlso vData.UpperLimit > 0 AndAlso _
                    Math.Abs(vData.UpperLimit - vData.LowerLimit) > 0.001 Then 'interval data
                    s = s & pad & "Interval " & vData.Year & " " & vData.LowerLimit & " " & vData.UpperLimit & " " & vData.Comment & vbCrLf
                Else 'just revised peak data
                    s = s & pad & "Peak " & vData.Year & " " & vData.Value & " " & vData.Code
                    If vData.Comment.Length > 0 Then s = s & "  '" & vData.Comment & vbCrLf Else s = s & vbCrLf
                End If
            End If
        Next
        'always output begin/end year since Historic record being eliminated (9/2012)
        If Len(defsta.CBegYear) > 0 Then s = s & pad & defsta.CBegYear & vbCrLf
        'If pBegYear <> defsta.BegYear Then s = s & pad & "BegYear " & CStr(pBegYear) & vbCrLf
        If pBegYear > 0 Then s = s & pad & "BegYear " & CStr(pBegYear) & vbCrLf
        If Len(defsta.CEndYear) > 0 Then s = s & pad & defsta.CEndYear & vbCrLf
        'If pEndYear <> defsta.EndYear Then s = s & pad & "EndYear " & CStr(pEndYear) & vbCrLf
        If pEndYear > 0 Then s = s & pad & "EndYear " & CStr(pEndYear) & vbCrLf
        If Len(defsta.CHistoric) > 0 Then s = s & pad & defsta.CHistoric & vbCrLf
        'If pHistoricPeriod AndAlso pHistoricPeriod <> defsta.HistoricPeriod Then s = s & pad & "HistPeriod " & CStr(pEndYear - pBegYear + 1) & vbCrLf
        If pHistoricPeriod Then
            s = s & pad & "HistPeriod " & CStr(pEndYear - pBegYear + 1) & vbCrLf
        Else
            s = s & pad & "'NO Historic Period in use" & vbCrLf
        End If
        If Len(defsta.CSkewOpt) > 0 Then s = s & pad & defsta.CSkewOpt & vbCrLf
        If pSkewOpt <> defsta.SkewOpt Then s = s & pad & "SkewOpt " & SOText(pSkewOpt) & vbCrLf
        If Len(defsta.CGenSkew) > 0 Then s = s & pad & defsta.CGenSkew & vbCrLf
        If pGenSkew <> defsta.GenSkew Then s = s & pad & "GenSkew " & pGenSkew & vbCrLf
        If Len(defsta.CSESkew) > 0 Then s = s & pad & defsta.CSESkew & vbCrLf
        If pSESkew <> defsta.SESkew Then s = s & pad & "SkewSE " & pSESkew & vbCrLf
        If Len(defsta.CUrban) > 0 Then s = s & pad & defsta.CUrban & vbCrLf
        If pUrbanRegPeaks <> defsta.UrbanRegPeaks Then s = s & pad & "Urb/Reg YES" & vbCrLf
        If Len(pCLowOutlier) > 0 Then s = s & pad & pCLowOutlier & vbCrLf
        If pLowOutlier <> defsta.LowOutlier Then
            s = s & pad & "LoThresh " & CStr(pLowOutlier) & vbCrLf
            'when LO specified there's no need for LO Test type
            s = s & pad & "LOType FIXED" & vbCrLf
        Else 'need a low outlier test type
            If Len(pCLOTestType) > 0 Then s = s & pad & pCLOTestType & vbCrLf
            If pLOTestType.StartsWith("Multiple") Then
                s = s & pad & "LOType MGBT" & vbCrLf
            Else 'assume Single GB
                s = s & pad & "LOType GBT" & vbCrLf
            End If
        End If
        If Len(defsta.CHighOutlier) > 0 Then s = s & pad & defsta.CHighOutlier & vbCrLf
        If pHighOutlier <> defsta.HighOutlier Then s = s & pad & "HiThresh " & CStr(pHighOutlier) & vbCrLf
        If Len(defsta.CGageBase) > 0 Then s = s & pad & defsta.CGageBase & vbCrLf
        If pGageBaseDischarge <> defsta.GageBaseDischarge Then s = s & pad & "GageBase " & CStr(pGageBaseDischarge) & vbCrLf
        If Len(defsta.CLat) > 0 Then s = s & pad & defsta.CLat & vbCrLf
        If pLat <> defsta.Lat Then s = s & pad & "Latitude " & CStr(pLat) & vbCrLf
        If Len(defsta.CLong) > 0 Then s = s & pad & defsta.CLong & vbCrLf
        If pLng <> defsta.Lng Then s = s & pad & "Longitude " & CStr(pLng) & vbCrLf
        If Len(defsta.CPlotName) > 0 Then s = s & pad & defsta.CPlotName & vbCrLf
        If pPlotName <> defsta.PlotName Then s = s & pad & "PlotName " & pPlotName & vbCrLf
        WriteSpecsNonDefault = s

    End Function

    Private Function PeakDataOrigContains(ByVal aPeak As PeakDataType) As Boolean
        For Each lPeak As PeakDataType In pPeakDataOrig
            If (lPeak.Year = aPeak.Year AndAlso Math.Abs(Math.Abs(lPeak.Value) - Math.Abs(aPeak.Value)) < 0.1 AndAlso _
                lPeak.Code = aPeak.Code AndAlso lPeak.Comment = aPeak.Comment AndAlso _
                (lPeak.LowerLimit = aPeak.LowerLimit Or aPeak.LowerLimit = -999) AndAlso _
                (lPeak.UpperLimit = aPeak.UpperLimit Or aPeak.UpperLimit = -999)) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub SetDefaultThresholds(Optional ByRef aSYear As Integer = 0, Optional ByRef aEYear As Integer = 0, _
                                    Optional ByRef aIncludeHistoricPeaks As Boolean = True)
        'sets initial default thresholds for a station that has just read its peaks
        Dim lThresh As ThresholdType
        Dim inHistoric As Boolean = False
        Dim lSYear As Integer
        Dim lEYear As Integer

        Thresholds = New Generic.List(Of ThresholdType)
        'set default for all peaks
        lThresh = New ThresholdType
        If aSYear > 0 Then
            lSYear = aSYear
        Else
            lSYear = PeakData(0).Year
        End If
        If aEYear > 0 Then
            lEYear = aEYear
        Else
            lEYear = PeakData(PeakData.Count - 1).Year
        End If
        lThresh.SYear = lSYear
        lThresh.EYear = lEYear
        lThresh.LowerLimit = 0.0
        lThresh.UpperLimit = 1.0E+20
        lThresh.Comment = "Default"
        Thresholds.Add(lThresh)

        lThresh = New ThresholdType
        For Each lPk As PeakDataType In PeakData
            If lPk.Year >= lSYear AndAlso lPk.Year <= lEYear Then
                If lPk.Code = "H" AndAlso aIncludeHistoricPeaks Then
                    If inHistoric Then 'continuing historic period
                        lThresh.EYear = lPk.Year
                        If Math.Abs(lPk.Value) < lThresh.LowerLimit AndAlso lPk.Value <> -8888 Then
                            lThresh.LowerLimit = Math.Abs(lPk.Value)
                        End If
                    Else 'start of historic period
                        lThresh = New ThresholdType
                        lThresh.SYear = lPk.Year
                        lThresh.EYear = lPk.Year
                        lThresh.Comment = "Historic " & Thresholds.Count
                        If lPk.Value <> -8888 Then
                            lThresh.LowerLimit = Math.Abs(lPk.Value)
                        Else
                            lThresh.LowerLimit = 1.0E+20
                        End If
                        lThresh.UpperLimit = 1.0E+20
                        inHistoric = True
                    End If
                Else
                    If inHistoric Then 'end of historic
                        lThresh.EYear = lPk.Year - 1
                        Thresholds.Add(lThresh)
                        lThresh = New ThresholdType
                        inHistoric = False
                    End If
                    If Not lPk.Code Is Nothing Then
                        If lPk.Code.Contains("L") Or lPk.Code.Contains("4") Then 'peak less than state, create a threshold
                            lThresh.SYear = lPk.Year
                            lThresh.EYear = lPk.Year
                            lThresh.LowerLimit = Math.Abs(lPk.Value)
                            lThresh.UpperLimit = 1.0E+20
                            lThresh.Comment = "Peak < stated value"
                            Thresholds.Add(lThresh)
                            lThresh.SYear = 0
                            'also set interval range
                            lPk.LowerLimit = 0
                            lPk.UpperLimit = Math.Abs(lPk.Value)
                            lPk.Comment = "Peak < stated value"
                        ElseIf lPk.Code.Contains("G") Or lPk.Code = "X" Or lPk.Code.Contains("8") Then
                            lThresh.SYear = lPk.Year
                            lThresh.EYear = lPk.Year
                            lThresh.LowerLimit = 0
                            lThresh.UpperLimit = Math.Abs(lPk.Value)
                            lThresh.Comment = "Peak > stated value"
                            Thresholds.Add(lThresh)
                            lThresh.SYear = 0
                            'peak greater than stated value, set interval range
                            lPk.LowerLimit = Math.Abs(lPk.Value)
                            lPk.UpperLimit = 1.0E+20
                            lPk.Comment = "Peak > stated value"
                        End If
                    End If
                End If
            End If
        Next
        If lThresh.SYear > 0 Then
            'start of historic period found, but didn't reach end so need to add to collection
            Thresholds.Add(lThresh)
        End If
    End Sub

    Public Function FindMissingYears() As Generic.List(Of Integer)
        Dim lMissingYears As New Generic.List(Of Integer)
        Dim lPrevYear As Integer = PeakData(0).Year - 1
        Dim inHistoric As Boolean = False
        Dim lYearMissing As Boolean
        Dim lThresh As ThresholdType
        Dim lThresholds As New Generic.List(Of ThresholdType)

        For Each lThresh In Thresholds
            If lThresh.LowerLimit <> 0 OrElse lThresh.UpperLimit < 1.0E+19 Then
                'not just the default threshold, use it to track missing years
                lThresholds.Add(lThresh)
            End If
        Next

        For lYr As Integer = BegYear To EndYear
            lYearMissing = True
            For Each lThresh In lThresholds
                If lYr >= lThresh.SYear AndAlso lYr <= lThresh.EYear Then
                    lYearMissing = False
                    Exit For
                End If
            Next
            If lYearMissing Then 'see if there is a systematic peak for this year
                For Each lPk As PeakDataType In PeakData
                    If (lPk.Year = lYr AndAlso (Not lPk.Code.Contains("3") And Not lPk.Code.Contains("D")) AndAlso (lPk.Value <> -8888 OrElse _
                        (lPk.LowerLimit >= 0 AndAlso lPk.UpperLimit > 0 AndAlso lPk.Comment.Length > 0))) Then
                        lYearMissing = False
                        Exit For
                    End If
                Next
            End If
            If lYearMissing Then
                lMissingYears.Add(lYr)
            End If
        Next

        'For Each lPk As PeakDataType In PeakData
        '    If lPk.Code = "H" Then
        '        inHistoric = True
        '    Else
        '        If inHistoric Then 'leaving historic period
        '            inHistoric = False
        '        ElseIf lPk.Year > lPrevYear + 1 Then 'missing years
        '            For i As Integer = lPrevYear + 1 To lPk.Year - 1
        '                lMissingYears.Add(i)
        '            Next
        '        End If
        '        lPrevYear = lPk.Year
        '    End If
        'Next
        Return lMissingYears
    End Function

    Public Function CheckThreshSpecs() As Boolean
        Dim lThreshDefined As Boolean = True
        For Each i As Integer In FindMissingYears()
            lThreshDefined = False
            For Each lThresh As ThresholdType In Thresholds
                If i >= lThresh.SYear AndAlso i <= lThresh.EYear AndAlso _
                    (lThresh.LowerLimit <> 0 Or lThresh.UpperLimit < 1.0E+20) Then
                    'valid threshold for this missing year
                    lThreshDefined = True
                    Exit For
                End If
            Next
        Next
        Return lThreshDefined

    End Function

    Public Sub New()
        MyBase.New()

        pAnalysisOption = "EMA" 'init all stations to use EMA analysis
        'pSkewOpt = 0 'Weighted skew option (middle of -1, 0, 1)
        pSkewOpt = 1  'TODO: Need to determine if this should be assigned differently (middle of 0, 1, 2)
        pUrbanRegPeaks = False
        pBegYear = 0
        pEndYear = 0
        pHistoricPeriod = False
        pGenSkew = -0.5
        pHighOutlier = 0.0#
        pLowOutlier = 0.0#
        pLOTestType = "Multiple"
        pGageBaseDischarge = 0.0#
        pSESkew = 0.55
        pLat = 0.0#
        pLng = 0.0#
        SOText(0) = "Station"
        SOText(1) = "Weighted"
        SOText(2) = "Generalized"

        Thresholds = New Generic.List(Of ThresholdType)
        pPeakData = New Generic.List(Of PeakDataType)
        pFirstSystematic = 0
        pLastSystematic = 0
        pFirstPeak = 0
        pLastPeak = 0
    End Sub
End Class
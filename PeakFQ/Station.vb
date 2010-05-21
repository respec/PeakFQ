Option Strict Off
Option Explicit On

Imports atcUtility

Friend Class pfqStation

    Public Structure ThresholdType
        Dim SYear As Integer
        Dim EYear As Integer
        Dim LowerLimit As Single
        Dim UpperLimit As Single
    End Structure

    Public Structure IntervalType
        Dim Year As Integer
        Dim LowerLimit As Single
        Dim UpperLimit As Single
    End Structure

    Private pID As String
    Private pName As String
    Private pActive As Boolean
    Private pBegYear As Integer
    Private pEndYear As Integer
    Private pSkewOpt As Integer '0 - Station, 1 - Weighted, 2 - Generalized
    Private pUrbanRegPeaks As Boolean
    Private pHistoricPeriod As Single
    Private pGenSkew As Single
    Private pHighSysPeak As Single
    Private pHighOutlier As Single
    Private pLowHistPeak As Single
    Private pLowOutlier As Single
    Private pGageBaseDischarge As Single
    Private pSESkew As Single
    Private pLat As Single
    Private pLng As Single
    Private pPlotName As String
    Private pPlotMade As Boolean
    Private pThresholds As FColl.FastCollection 'of type ThresholdType
    Private pIntervals As FColl.FastCollection 'of type IntervalType
    'the following are for storing comments for various specification records
    Private pComment As String
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

    Public Property Active() As Boolean
        Get
            Active = pActive
        End Get
        Set(ByVal Value As Boolean)
            pActive = Value
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

    Public Property HistoricPeriod() As Single
        Get
            HistoricPeriod = pHistoricPeriod
        End Get
        Set(ByVal Value As Single)
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

    Public Property Comment() As String
        Get
            Comment = pComment
        End Get
        Set(ByVal Value As String)
            pComment = Value
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

    Public Property Thresholds() As FColl.FastCollection
        Get
            If pThresholds Is Nothing Then pThresholds = New FColl.FastCollection
            Thresholds = pThresholds
        End Get
        Set(ByVal Value As FColl.FastCollection)
            pThresholds = Value
        End Set
    End Property

    Public Property Intervals() As FColl.FastCollection
        Get
            If pIntervals Is Nothing Then pIntervals = New FColl.FastCollection
            Intervals = pIntervals
        End Get
        Set(ByVal Value As FColl.FastCollection)
            pIntervals = Value
        End Set
    End Property

    Public Function WriteSpecsVerbose() As String

        Dim s As String
        Dim vPT As ThresholdType
        Const pad As String = "     "

        If Len(pComment) > 0 Then
            s = pComment & vbCrLf & "Station " & pID & vbCrLf
        Else
            s = "Station " & pID & vbCrLf
        End If
        If pThresholds.Count > 0 Then 'using perception threshholds, not beg/end years and hist. period
            For Each vPT In pThresholds
                s = s & "PCPT_THRESH " & vPT.SYear & " " & vPT.EYear & " " & vPT.LowerLimit & " " & vPT.UpperLimit & vbCrLf
            Next
        Else 'using beg/end years and hist. period
            If Len(pCBegYear) > 0 Then s = s & pad & pCBegYear & vbCrLf
            If pBegYear > 0 Then s = s & pad & "BegYear " & CStr(pBegYear) & vbCrLf
            If Len(pCEndYear) > 0 Then s = s & pad & pCEndYear & vbCrLf
            If pEndYear > 0 Then s = s & pad & "EndYear " & CStr(pEndYear) & vbCrLf
            If Len(pCHistoric) > 0 Then s = s & pad & pCHistoric & vbCrLf
            If pHistoricPeriod > 0 Then s = s & pad & "HistPeriod " & CStr(pHistoricPeriod) & vbCrLf
        End If
        If Len(pCSkewOpt) > 0 Then s = s & pad & pCSkewOpt & vbCrLf
        s = s & pad & "SkewOpt " & SOText(pSkewOpt) & vbCrLf
        If Len(pCGenSkew) > 0 Then s = s & pad & pCGenSkew & vbCrLf
        s = s & pad & "GenSkew " & pGenSkew & vbCrLf
        If Len(pCSESkew) > 0 Then s = s & pad & pCSESkew & vbCrLf
        s = s & pad & "SkewSE " & pSESkew & vbCrLf
        If Len(pCUrban) > 0 Then s = s & pad & pCUrban & vbCrLf
        If pUrbanRegPeaks Then s = s & pad & "Urb/Reg YES" & vbCrLf
        If Len(pCLowOutlier) > 0 Then s = s & pad & pCLowOutlier & vbCrLf
        If pLowOutlier > 0 Then s = s & pad & "LoThresh " & CStr(pLowOutlier) & vbCrLf
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
        Dim vPT As ThresholdType
        Const pad As String = "     "

        '!!! KLUGE WARNING: Station comments get lost in active project,
        'due to batch program not preserving comments, so comments are
        'extracted from default project
        If Len(defsta.Comment) > 0 Then
            s = defsta.Comment & vbCrLf & "Station " & pID & vbCrLf
        Else
            s = "Station " & pID & vbCrLf
        End If
        If pThresholds.Count > 0 Then 'using perception threshholds
            For Each vPT In pThresholds
                s = s & "PCPT_THRESH " & vPT.SYear & " " & vPT.EYear & " " & vPT.LowerLimit & " " & vPT.UpperLimit & vbCrLf
            Next
        End If
        If Len(defsta.CBegYear) > 0 Then s = s & pad & defsta.CBegYear & vbCrLf
        If pBegYear <> defsta.BegYear Then s = s & pad & "BegYear " & CStr(pBegYear) & vbCrLf
        If Len(defsta.CEndYear) > 0 Then s = s & pad & defsta.CEndYear & vbCrLf
        If pEndYear <> defsta.EndYear Then s = s & pad & "EndYear " & CStr(pEndYear) & vbCrLf
        If Len(defsta.CHistoric) > 0 Then s = s & pad & defsta.CHistoric & vbCrLf
        If pHistoricPeriod <> defsta.HistoricPeriod Then s = s & pad & "HistPeriod " & CStr(pHistoricPeriod) & vbCrLf
        If Len(defsta.CSkewOpt) > 0 Then s = s & pad & defsta.CSkewOpt & vbCrLf
        If pSkewOpt <> defsta.SkewOpt Then s = s & pad & "SkewOpt " & SOText(pSkewOpt) & vbCrLf
        If Len(defsta.CGenSkew) > 0 Then s = s & pad & defsta.CGenSkew & vbCrLf
        If pGenSkew <> defsta.GenSkew Then s = s & pad & "GenSkew " & pGenSkew & vbCrLf
        If Len(defsta.CSESkew) > 0 Then s = s & pad & defsta.CSESkew & vbCrLf
        If pSESkew <> defsta.SESkew Then s = s & pad & "SkewSE " & pSESkew & vbCrLf
        If Len(defsta.CUrban) > 0 Then s = s & pad & defsta.CUrban & vbCrLf
        If pUrbanRegPeaks <> defsta.UrbanRegPeaks Then s = s & pad & "Urb/Reg YES" & vbCrLf
        If Len(defsta.CLowOutlier) > 0 Then s = s & pad & defsta.CLowOutlier & vbCrLf
        If pLowOutlier <> defsta.LowOutlier Then s = s & pad & "LoThresh " & CStr(pLowOutlier) & vbCrLf
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

    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()

        pActive = True 'init all stations to be analyzed
        'pSkewOpt = 0 'Weighted skew option (middle of -1, 0, 1)
        pSkewOpt = 1  'TODO: Need to determine if this should be assigned differently (middle of 0, 1, 2)
        pUrbanRegPeaks = False
        pBegYear = 0
        pEndYear = 0
        pHistoricPeriod = 0.0#
        pGenSkew = -0.5
        pHighOutlier = 0.0#
        pLowOutlier = 0.0#
        pGageBaseDischarge = 0.0#
        pSESkew = 0.55
        pLat = 0.0#
        pLng = 0.0#
        'SOText(-1) = "Station"
        'SOText(0) = "Weighted"
        'SOText(1) = "Generalized"
        SOText(0) = "Station"
        SOText(1) = "Weighted"
        SOText(2) = "Generalized"

        pThresholds = New FColl.FastCollection
        pIntervals = New FColl.FastCollection

    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
End Class
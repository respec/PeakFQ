<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPeakfq
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSaveSpecs As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFeedback As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelpMain As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents cmdRun As System.Windows.Forms.Button
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents fraButtons As System.Windows.Forms.Panel
    Public WithEvents tabStationSpecs As System.Windows.Forms.TabPage
    Public WithEvents _cmdOpenOut_0 As System.Windows.Forms.Button
    Public WithEvents _lblOutFile_0 As System.Windows.Forms.Label
    Public WithEvents fraOutFile As System.Windows.Forms.GroupBox
    Public WithEvents _optAddFormat_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optAddFormat_0 As System.Windows.Forms.RadioButton
    Public WithEvents _chkAddOut_0 As System.Windows.Forms.CheckBox
    Public WithEvents _chkAddOut_1 As System.Windows.Forms.CheckBox
    Public WithEvents _cmdOpenOut_1 As System.Windows.Forms.Button
    Public WithEvents _lblOutFile_1 As System.Windows.Forms.Label
    Public WithEvents fraAddOut As System.Windows.Forms.GroupBox
    Public WithEvents chkPlotPos As System.Windows.Forms.CheckBox
    Public WithEvents chkLinePrinter As System.Windows.Forms.CheckBox
    Public WithEvents chkIntRes As System.Windows.Forms.CheckBox
    Public WithEvents lblGraphics As System.Windows.Forms.Label
    Public WithEvents lblPlotPos As System.Windows.Forms.Label
    Public WithEvents lblCL As System.Windows.Forms.Label
    Public WithEvents fraOutRight As System.Windows.Forms.Panel
    Public WithEvents tabOutput As System.Windows.Forms.TabPage
    Public WithEvents _cmdOutFileView_1 As System.Windows.Forms.Button
    Public WithEvents _lblOutFileView_1 As System.Windows.Forms.Label
    Public WithEvents _fraOutFileRes_1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdGraph As System.Windows.Forms.Button
    Public WithEvents lstGraphs As System.Windows.Forms.ListBox
    Public WithEvents fraGraphics As System.Windows.Forms.GroupBox
    Public WithEvents _cmdOutFileView_0 As System.Windows.Forms.Button
    Public WithEvents _lblOutFileView_0 As System.Windows.Forms.Label
    Public WithEvents _fraOutFileRes_0 As System.Windows.Forms.GroupBox
    Public WithEvents tabResults As System.Windows.Forms.TabPage
    Public WithEvents sstPfq As System.Windows.Forms.TabControl
    Public cdlOpenOpen As System.Windows.Forms.OpenFileDialog
    Public cdlOpenSave As System.Windows.Forms.SaveFileDialog
    Public WithEvents lblInstruct As System.Windows.Forms.Label
    Public WithEvents lblSpec As System.Windows.Forms.Label
    Public WithEvents lblData As System.Windows.Forms.Label
    Public WithEvents chkAddOut As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    Public WithEvents cmdOpenOut As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents cmdOutFileView As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents fraOutFileRes As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    Public WithEvents lblOutFile As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblOutFileView As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents optAddFormat As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    Public WithEvents optGraphFormat As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    Friend WithEvents grdSpecs As atcControls.atcGrid
    Friend WithEvents txtCL As atcControls.atcText
    Friend WithEvents txtPlotPos As atcControls.atcText

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeakfq))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveSpecs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFeedback = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpMain = New System.Windows.Forms.ToolStripMenuItem()
        Me.fraButtons = New System.Windows.Forms.Panel()
        Me.cmdCodeLookup = New System.Windows.Forms.Button()
        Me.cmdRun = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.sstPfq = New System.Windows.Forms.TabControl()
        Me.tabStationSpecs = New System.Windows.Forms.TabPage()
        Me.lblLOTest = New System.Windows.Forms.Label()
        Me.cboLOTest = New System.Windows.Forms.ComboBox()
        Me.cboAnalysisOption = New System.Windows.Forms.ComboBox()
        Me.lblGlobalAnalysis = New System.Windows.Forms.Label()
        Me.grdSpecs = New atcControls.atcGrid()
        Me.tabThresholds = New System.Windows.Forms.TabPage()
        Me.spltInputViewTab = New System.Windows.Forms.SplitContainer()
        Me.spltThreshIntervalGrids = New System.Windows.Forms.SplitContainer()
        Me.lblThresholds = New System.Windows.Forms.Label()
        Me.grdThresh = New atcControls.atcGrid()
        Me.lblIntervals = New System.Windows.Forms.Label()
        Me.grdInterval = New atcControls.atcGrid()
        Me.lblB17BWarning = New System.Windows.Forms.Label()
        Me.lblLegendMove = New System.Windows.Forms.Label()
        Me.zgcThresh = New ZedGraph.ZedGraphControl()
        Me.cboDataGraphFormat = New System.Windows.Forms.ComboBox()
        Me.lblDataGraphFormat = New System.Windows.Forms.Label()
        Me.cmdAddInt = New System.Windows.Forms.Button()
        Me.cmdAddThr = New System.Windows.Forms.Button()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cboStation = New System.Windows.Forms.ComboBox()
        Me.tabOutput = New System.Windows.Forms.TabPage()
        Me.fraOutFile = New System.Windows.Forms.GroupBox()
        Me._cmdOpenOut_0 = New System.Windows.Forms.Button()
        Me._lblOutFile_0 = New System.Windows.Forms.Label()
        Me.fraAddOut = New System.Windows.Forms.GroupBox()
        Me.lblEmpirical = New System.Windows.Forms.Label()
        Me.cmdOpenEmpirical = New System.Windows.Forms.Button()
        Me.chkEmpirical = New System.Windows.Forms.CheckBox()
        Me.lblExportFile = New System.Windows.Forms.Label()
        Me.cmdOpenExport = New System.Windows.Forms.Button()
        Me.chkExport = New System.Windows.Forms.CheckBox()
        Me._optAddFormat_1 = New System.Windows.Forms.RadioButton()
        Me._optAddFormat_0 = New System.Windows.Forms.RadioButton()
        Me._chkAddOut_0 = New System.Windows.Forms.CheckBox()
        Me._chkAddOut_1 = New System.Windows.Forms.CheckBox()
        Me._cmdOpenOut_1 = New System.Windows.Forms.Button()
        Me._lblOutFile_1 = New System.Windows.Forms.Label()
        Me.fraOutRight = New System.Windows.Forms.Panel()
        Me.cboGraphFormat = New System.Windows.Forms.ComboBox()
        Me.txtCL = New atcControls.atcText()
        Me.txtPlotPos = New atcControls.atcText()
        Me.chkPlotPos = New System.Windows.Forms.CheckBox()
        Me.chkLinePrinter = New System.Windows.Forms.CheckBox()
        Me.chkIntRes = New System.Windows.Forms.CheckBox()
        Me.lblGraphics = New System.Windows.Forms.Label()
        Me.lblPlotPos = New System.Windows.Forms.Label()
        Me.lblCL = New System.Windows.Forms.Label()
        Me.tabResults = New System.Windows.Forms.TabPage()
        Me._fraOutFileRes_1 = New System.Windows.Forms.GroupBox()
        Me.cmdEmpiricalFileView = New System.Windows.Forms.Button()
        Me.lblEmpiricalFileView = New System.Windows.Forms.Label()
        Me.cmdExportFileView = New System.Windows.Forms.Button()
        Me.lblExportFileView = New System.Windows.Forms.Label()
        Me._cmdOutFileView_1 = New System.Windows.Forms.Button()
        Me._lblOutFileView_1 = New System.Windows.Forms.Label()
        Me.fraGraphics = New System.Windows.Forms.GroupBox()
        Me.cmdGraph = New System.Windows.Forms.Button()
        Me.lstGraphs = New System.Windows.Forms.ListBox()
        Me._fraOutFileRes_0 = New System.Windows.Forms.GroupBox()
        Me._cmdOutFileView_0 = New System.Windows.Forms.Button()
        Me._lblOutFileView_0 = New System.Windows.Forms.Label()
        Me.cdlOpenOpen = New System.Windows.Forms.OpenFileDialog()
        Me.cdlOpenSave = New System.Windows.Forms.SaveFileDialog()
        Me.lblInstruct = New System.Windows.Forms.Label()
        Me.lblSpec = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.chkAddOut = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
        Me.cmdOpenOut = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.cmdOutFileView = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.fraOutFileRes = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(Me.components)
        Me.lblOutFile = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblOutFileView = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.optAddFormat = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.optGraphFormat = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.MainMenu1.SuspendLayout()
        Me.fraButtons.SuspendLayout()
        Me.sstPfq.SuspendLayout()
        Me.tabStationSpecs.SuspendLayout()
        Me.tabThresholds.SuspendLayout()
        CType(Me.spltInputViewTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spltInputViewTab.Panel1.SuspendLayout()
        Me.spltInputViewTab.Panel2.SuspendLayout()
        Me.spltInputViewTab.SuspendLayout()
        CType(Me.spltThreshIntervalGrids, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spltThreshIntervalGrids.Panel1.SuspendLayout()
        Me.spltThreshIntervalGrids.Panel2.SuspendLayout()
        Me.spltThreshIntervalGrids.SuspendLayout()
        Me.tabOutput.SuspendLayout()
        Me.fraOutFile.SuspendLayout()
        Me.fraAddOut.SuspendLayout()
        Me.fraOutRight.SuspendLayout()
        Me.tabResults.SuspendLayout()
        Me._fraOutFileRes_1.SuspendLayout()
        Me.fraGraphics.SuspendLayout()
        Me._fraOutFileRes_0.SuspendLayout()
        CType(Me.chkAddOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOpenOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOutFileView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fraOutFileRes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOutFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOutFileView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optAddFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optGraphFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuHelp})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(1141, 24)
        Me.MainMenu1.TabIndex = 30
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpen, Me.mnuSaveSpecs, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuOpen
        '
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(131, 22)
        Me.mnuOpen.Text = "&Open"
        '
        'mnuSaveSpecs
        '
        Me.mnuSaveSpecs.Enabled = False
        Me.mnuSaveSpecs.Name = "mnuSaveSpecs"
        Me.mnuSaveSpecs.Size = New System.Drawing.Size(131, 22)
        Me.mnuSaveSpecs.Text = "&Save Specs"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(131, 22)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbout, Me.mnuFeedback, Me.mnuHelpMain})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(153, 22)
        Me.mnuAbout.Text = "&About"
        '
        'mnuFeedback
        '
        Me.mnuFeedback.Name = "mnuFeedback"
        Me.mnuFeedback.Size = New System.Drawing.Size(153, 22)
        Me.mnuFeedback.Text = "Send &Feedback"
        '
        'mnuHelpMain
        '
        Me.mnuHelpMain.Name = "mnuHelpMain"
        Me.mnuHelpMain.Size = New System.Drawing.Size(153, 22)
        Me.mnuHelpMain.Text = "PeakFQ Help"
        '
        'fraButtons
        '
        Me.fraButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraButtons.BackColor = System.Drawing.SystemColors.Control
        Me.fraButtons.Controls.Add(Me.cmdCodeLookup)
        Me.fraButtons.Controls.Add(Me.cmdRun)
        Me.fraButtons.Controls.Add(Me.cmdSave)
        Me.fraButtons.Controls.Add(Me.cmdExit)
        Me.fraButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraButtons.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraButtons.Location = New System.Drawing.Point(309, 502)
        Me.fraButtons.Name = "fraButtons"
        Me.fraButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraButtons.Size = New System.Drawing.Size(820, 25)
        Me.fraButtons.TabIndex = 29
        '
        'cmdCodeLookup
        '
        Me.cmdCodeLookup.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCodeLookup.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCodeLookup.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCodeLookup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCodeLookup.Location = New System.Drawing.Point(3, 0)
        Me.cmdCodeLookup.Name = "cmdCodeLookup"
        Me.cmdCodeLookup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCodeLookup.Size = New System.Drawing.Size(97, 25)
        Me.cmdCodeLookup.TabIndex = 34
        Me.cmdCodeLookup.Text = "&Code Lookup"
        Me.cmdCodeLookup.UseVisualStyleBackColor = False
        '
        'cmdRun
        '
        Me.cmdRun.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRun.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRun.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRun.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRun.Location = New System.Drawing.Point(484, 0)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRun.Size = New System.Drawing.Size(97, 25)
        Me.cmdRun.TabIndex = 32
        Me.cmdRun.Text = "&Run PEAKFQ"
        Me.cmdRun.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(599, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(97, 25)
        Me.cmdSave.TabIndex = 31
        Me.cmdSave.Text = "&Save Specs"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(750, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(57, 25)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'sstPfq
        '
        Me.sstPfq.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sstPfq.Controls.Add(Me.tabStationSpecs)
        Me.sstPfq.Controls.Add(Me.tabThresholds)
        Me.sstPfq.Controls.Add(Me.tabOutput)
        Me.sstPfq.Controls.Add(Me.tabResults)
        Me.sstPfq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sstPfq.ItemSize = New System.Drawing.Size(42, 18)
        Me.sstPfq.Location = New System.Drawing.Point(8, 88)
        Me.sstPfq.Name = "sstPfq"
        Me.sstPfq.SelectedIndex = 1
        Me.sstPfq.Size = New System.Drawing.Size(1121, 399)
        Me.sstPfq.TabIndex = 0
        '
        'tabStationSpecs
        '
        Me.tabStationSpecs.Controls.Add(Me.lblLOTest)
        Me.tabStationSpecs.Controls.Add(Me.cboLOTest)
        Me.tabStationSpecs.Controls.Add(Me.cboAnalysisOption)
        Me.tabStationSpecs.Controls.Add(Me.lblGlobalAnalysis)
        Me.tabStationSpecs.Controls.Add(Me.grdSpecs)
        Me.tabStationSpecs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabStationSpecs.Location = New System.Drawing.Point(4, 22)
        Me.tabStationSpecs.Name = "tabStationSpecs"
        Me.tabStationSpecs.Size = New System.Drawing.Size(1113, 373)
        Me.tabStationSpecs.TabIndex = 0
        Me.tabStationSpecs.Text = "Station Specifications"
        Me.tabStationSpecs.UseVisualStyleBackColor = True
        '
        'lblLOTest
        '
        Me.lblLOTest.AutoSize = True
        Me.lblLOTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLOTest.Location = New System.Drawing.Point(495, 23)
        Me.lblLOTest.Name = "lblLOTest"
        Me.lblLOTest.Size = New System.Drawing.Size(146, 13)
        Me.lblLOTest.TabIndex = 8
        Me.lblLOTest.Text = "Global PILF (LO) Test Option:"
        '
        'cboLOTest
        '
        Me.cboLOTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLOTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLOTest.FormattingEnabled = True
        Me.cboLOTest.Items.AddRange(New Object() {"Single Grubbs-Beck", "Multiple Grubbs-Beck"})
        Me.cboLOTest.Location = New System.Drawing.Point(655, 20)
        Me.cboLOTest.Name = "cboLOTest"
        Me.cboLOTest.Size = New System.Drawing.Size(145, 21)
        Me.cboLOTest.TabIndex = 7
        '
        'cboAnalysisOption
        '
        Me.cboAnalysisOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnalysisOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnalysisOption.FormattingEnabled = True
        Me.cboAnalysisOption.Items.AddRange(New Object() {"Skip", "B17B", "EMA"})
        Me.cboAnalysisOption.Location = New System.Drawing.Point(61, 20)
        Me.cboAnalysisOption.Name = "cboAnalysisOption"
        Me.cboAnalysisOption.Size = New System.Drawing.Size(69, 21)
        Me.cboAnalysisOption.TabIndex = 5
        '
        'lblGlobalAnalysis
        '
        Me.lblGlobalAnalysis.AutoSize = True
        Me.lblGlobalAnalysis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGlobalAnalysis.Location = New System.Drawing.Point(3, 0)
        Me.lblGlobalAnalysis.Name = "lblGlobalAnalysis"
        Me.lblGlobalAnalysis.Size = New System.Drawing.Size(48, 39)
        Me.lblGlobalAnalysis.TabIndex = 3
        Me.lblGlobalAnalysis.Text = "Global " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Analysis " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Option:"
        '
        'grdSpecs
        '
        Me.grdSpecs.AllowHorizontalScrolling = True
        Me.grdSpecs.AllowNewValidValues = False
        Me.grdSpecs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdSpecs.CellBackColor = System.Drawing.SystemColors.Window
        Me.grdSpecs.Fixed3D = False
        Me.grdSpecs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdSpecs.LineColor = System.Drawing.SystemColors.Control
        Me.grdSpecs.LineWidth = 1.0!
        Me.grdSpecs.Location = New System.Drawing.Point(0, 44)
        Me.grdSpecs.Name = "grdSpecs"
        Me.grdSpecs.Size = New System.Drawing.Size(1110, 326)
        Me.grdSpecs.Source = Nothing
        Me.grdSpecs.TabIndex = 2
        '
        'tabThresholds
        '
        Me.tabThresholds.Controls.Add(Me.spltInputViewTab)
        Me.tabThresholds.Controls.Add(Me.cboDataGraphFormat)
        Me.tabThresholds.Controls.Add(Me.lblDataGraphFormat)
        Me.tabThresholds.Controls.Add(Me.cmdAddInt)
        Me.tabThresholds.Controls.Add(Me.cmdAddThr)
        Me.tabThresholds.Controls.Add(Me.lblStation)
        Me.tabThresholds.Controls.Add(Me.cboStation)
        Me.tabThresholds.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabThresholds.Location = New System.Drawing.Point(4, 22)
        Me.tabThresholds.Name = "tabThresholds"
        Me.tabThresholds.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThresholds.Size = New System.Drawing.Size(1113, 373)
        Me.tabThresholds.TabIndex = 3
        Me.tabThresholds.Text = "Input/View"
        Me.tabThresholds.UseVisualStyleBackColor = True
        '
        'spltInputViewTab
        '
        Me.spltInputViewTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spltInputViewTab.Location = New System.Drawing.Point(6, 30)
        Me.spltInputViewTab.Name = "spltInputViewTab"
        '
        'spltInputViewTab.Panel1
        '
        Me.spltInputViewTab.Panel1.Controls.Add(Me.spltThreshIntervalGrids)
        '
        'spltInputViewTab.Panel2
        '
        Me.spltInputViewTab.Panel2.Controls.Add(Me.lblB17BWarning)
        Me.spltInputViewTab.Panel2.Controls.Add(Me.lblLegendMove)
        Me.spltInputViewTab.Panel2.Controls.Add(Me.zgcThresh)
        Me.spltInputViewTab.Size = New System.Drawing.Size(1098, 335)
        Me.spltInputViewTab.SplitterDistance = 672
        Me.spltInputViewTab.TabIndex = 45
        '
        'spltThreshIntervalGrids
        '
        Me.spltThreshIntervalGrids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spltThreshIntervalGrids.Location = New System.Drawing.Point(0, 0)
        Me.spltThreshIntervalGrids.Name = "spltThreshIntervalGrids"
        Me.spltThreshIntervalGrids.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spltThreshIntervalGrids.Panel1
        '
        Me.spltThreshIntervalGrids.Panel1.Controls.Add(Me.lblThresholds)
        Me.spltThreshIntervalGrids.Panel1.Controls.Add(Me.grdThresh)
        '
        'spltThreshIntervalGrids.Panel2
        '
        Me.spltThreshIntervalGrids.Panel2.Controls.Add(Me.lblIntervals)
        Me.spltThreshIntervalGrids.Panel2.Controls.Add(Me.grdInterval)
        Me.spltThreshIntervalGrids.Size = New System.Drawing.Size(672, 335)
        Me.spltThreshIntervalGrids.SplitterDistance = 108
        Me.spltThreshIntervalGrids.TabIndex = 45
        '
        'lblThresholds
        '
        Me.lblThresholds.AutoSize = True
        Me.lblThresholds.Location = New System.Drawing.Point(178, 0)
        Me.lblThresholds.Name = "lblThresholds"
        Me.lblThresholds.Size = New System.Drawing.Size(115, 14)
        Me.lblThresholds.TabIndex = 12
        Me.lblThresholds.Text = "Perception Thresholds"
        '
        'grdThresh
        '
        Me.grdThresh.AllowHorizontalScrolling = False
        Me.grdThresh.AllowNewValidValues = False
        Me.grdThresh.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdThresh.CellBackColor = System.Drawing.SystemColors.Window
        Me.grdThresh.Fixed3D = False
        Me.grdThresh.LineColor = System.Drawing.SystemColors.Control
        Me.grdThresh.LineWidth = 1.0!
        Me.grdThresh.Location = New System.Drawing.Point(3, 17)
        Me.grdThresh.Name = "grdThresh"
        Me.grdThresh.Size = New System.Drawing.Size(666, 91)
        Me.grdThresh.Source = Nothing
        Me.grdThresh.TabIndex = 11
        '
        'lblIntervals
        '
        Me.lblIntervals.AutoSize = True
        Me.lblIntervals.Location = New System.Drawing.Point(219, 0)
        Me.lblIntervals.Name = "lblIntervals"
        Me.lblIntervals.Size = New System.Drawing.Size(29, 14)
        Me.lblIntervals.TabIndex = 13
        Me.lblIntervals.Text = "Data"
        '
        'grdInterval
        '
        Me.grdInterval.AllowHorizontalScrolling = False
        Me.grdInterval.AllowNewValidValues = False
        Me.grdInterval.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdInterval.CellBackColor = System.Drawing.SystemColors.Window
        Me.grdInterval.Fixed3D = False
        Me.grdInterval.LineColor = System.Drawing.SystemColors.Control
        Me.grdInterval.LineWidth = 1.0!
        Me.grdInterval.Location = New System.Drawing.Point(3, 17)
        Me.grdInterval.Name = "grdInterval"
        Me.grdInterval.Size = New System.Drawing.Size(666, 206)
        Me.grdInterval.Source = Nothing
        Me.grdInterval.TabIndex = 12
        '
        'lblB17BWarning
        '
        Me.lblB17BWarning.AutoSize = True
        Me.lblB17BWarning.Location = New System.Drawing.Point(-3, 0)
        Me.lblB17BWarning.Name = "lblB17BWarning"
        Me.lblB17BWarning.Size = New System.Drawing.Size(349, 14)
        Me.lblB17BWarning.TabIndex = 48
        Me.lblB17BWarning.Text = "NOTE: Threshold and Interval Data are not used in Bulletin 17B analysis"
        '
        'lblLegendMove
        '
        Me.lblLegendMove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLegendMove.AutoSize = True
        Me.lblLegendMove.Location = New System.Drawing.Point(-3, 321)
        Me.lblLegendMove.Name = "lblLegendMove"
        Me.lblLegendMove.Size = New System.Drawing.Size(197, 14)
        Me.lblLegendMove.TabIndex = 47
        Me.lblLegendMove.Text = "NOTE: Click on graph to relocate legend"
        '
        'zgcThresh
        '
        Me.zgcThresh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zgcThresh.Location = New System.Drawing.Point(0, 0)
        Me.zgcThresh.Name = "zgcThresh"
        Me.zgcThresh.ScrollGrace = 0.0R
        Me.zgcThresh.ScrollMaxX = 0.0R
        Me.zgcThresh.ScrollMaxY = 0.0R
        Me.zgcThresh.ScrollMaxY2 = 0.0R
        Me.zgcThresh.ScrollMinX = 0.0R
        Me.zgcThresh.ScrollMinY = 0.0R
        Me.zgcThresh.ScrollMinY2 = 0.0R
        Me.zgcThresh.Size = New System.Drawing.Size(422, 335)
        Me.zgcThresh.TabIndex = 13
        '
        'cboDataGraphFormat
        '
        Me.cboDataGraphFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataGraphFormat.FormattingEnabled = True
        Me.cboDataGraphFormat.Items.AddRange(New Object() {"None", "EMF - Enhanced Windows Metafile", "PNG - Portable Network Graphics", "GIF - Graphic Interchange Format", "JPEG", "TIFF", "BMP - Bitmap"})
        Me.cboDataGraphFormat.Location = New System.Drawing.Point(405, 9)
        Me.cboDataGraphFormat.Name = "cboDataGraphFormat"
        Me.cboDataGraphFormat.Size = New System.Drawing.Size(75, 22)
        Me.cboDataGraphFormat.TabIndex = 43
        '
        'lblDataGraphFormat
        '
        Me.lblDataGraphFormat.AutoSize = True
        Me.lblDataGraphFormat.Location = New System.Drawing.Point(267, 9)
        Me.lblDataGraphFormat.Name = "lblDataGraphFormat"
        Me.lblDataGraphFormat.Size = New System.Drawing.Size(141, 14)
        Me.lblDataGraphFormat.TabIndex = 13
        Me.lblDataGraphFormat.Text = "Save Input Peaks Graph as:"
        '
        'cmdAddInt
        '
        Me.cmdAddInt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAddInt.Location = New System.Drawing.Point(329, 350)
        Me.cmdAddInt.Name = "cmdAddInt"
        Me.cmdAddInt.Size = New System.Drawing.Size(57, 21)
        Me.cmdAddInt.TabIndex = 9
        Me.cmdAddInt.Text = "Add"
        Me.cmdAddInt.UseVisualStyleBackColor = True
        Me.cmdAddInt.Visible = False
        '
        'cmdAddThr
        '
        Me.cmdAddThr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAddThr.Location = New System.Drawing.Point(94, 350)
        Me.cmdAddThr.Name = "cmdAddThr"
        Me.cmdAddThr.Size = New System.Drawing.Size(57, 21)
        Me.cmdAddThr.TabIndex = 7
        Me.cmdAddThr.Text = "Add"
        Me.cmdAddThr.UseVisualStyleBackColor = True
        Me.cmdAddThr.Visible = False
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(29, 9)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(43, 14)
        Me.lblStation.TabIndex = 6
        Me.lblStation.Text = "Station:"
        '
        'cboStation
        '
        Me.cboStation.FormattingEnabled = True
        Me.cboStation.ItemHeight = 14
        Me.cboStation.Location = New System.Drawing.Point(74, 6)
        Me.cboStation.MaxDropDownItems = 20
        Me.cboStation.Name = "cboStation"
        Me.cboStation.Size = New System.Drawing.Size(155, 22)
        Me.cboStation.TabIndex = 5
        '
        'tabOutput
        '
        Me.tabOutput.Controls.Add(Me.fraOutFile)
        Me.tabOutput.Controls.Add(Me.fraAddOut)
        Me.tabOutput.Controls.Add(Me.fraOutRight)
        Me.tabOutput.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabOutput.Location = New System.Drawing.Point(4, 22)
        Me.tabOutput.Name = "tabOutput"
        Me.tabOutput.Size = New System.Drawing.Size(1113, 373)
        Me.tabOutput.TabIndex = 1
        Me.tabOutput.Text = "Output Options"
        Me.tabOutput.UseVisualStyleBackColor = True
        '
        'fraOutFile
        '
        Me.fraOutFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraOutFile.BackColor = System.Drawing.SystemColors.Control
        Me.fraOutFile.Controls.Add(Me._cmdOpenOut_0)
        Me.fraOutFile.Controls.Add(Me._lblOutFile_0)
        Me.fraOutFile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraOutFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOutFile.Location = New System.Drawing.Point(8, 8)
        Me.fraOutFile.Name = "fraOutFile"
        Me.fraOutFile.Padding = New System.Windows.Forms.Padding(0)
        Me.fraOutFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOutFile.Size = New System.Drawing.Size(505, 81)
        Me.fraOutFile.TabIndex = 2
        Me.fraOutFile.TabStop = False
        Me.fraOutFile.Text = "Output File"
        '
        '_cmdOpenOut_0
        '
        Me._cmdOpenOut_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdOpenOut_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdOpenOut_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdOpenOut_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOpenOut.SetIndex(Me._cmdOpenOut_0, CType(0, Short))
        Me._cmdOpenOut_0.Location = New System.Drawing.Point(8, 16)
        Me._cmdOpenOut_0.Name = "_cmdOpenOut_0"
        Me._cmdOpenOut_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdOpenOut_0.Size = New System.Drawing.Size(57, 25)
        Me._cmdOpenOut_0.TabIndex = 3
        Me._cmdOpenOut_0.Text = "Select"
        Me._cmdOpenOut_0.UseVisualStyleBackColor = False
        '
        '_lblOutFile_0
        '
        Me._lblOutFile_0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblOutFile_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblOutFile_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblOutFile_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblOutFile_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOutFile.SetIndex(Me._lblOutFile_0, CType(0, Short))
        Me._lblOutFile_0.Location = New System.Drawing.Point(72, 16)
        Me._lblOutFile_0.Name = "_lblOutFile_0"
        Me._lblOutFile_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblOutFile_0.Size = New System.Drawing.Size(430, 57)
        Me._lblOutFile_0.TabIndex = 4
        Me._lblOutFile_0.Text = "(none)"
        '
        'fraAddOut
        '
        Me.fraAddOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraAddOut.BackColor = System.Drawing.SystemColors.Control
        Me.fraAddOut.Controls.Add(Me.lblEmpirical)
        Me.fraAddOut.Controls.Add(Me.cmdOpenEmpirical)
        Me.fraAddOut.Controls.Add(Me.chkEmpirical)
        Me.fraAddOut.Controls.Add(Me.lblExportFile)
        Me.fraAddOut.Controls.Add(Me.cmdOpenExport)
        Me.fraAddOut.Controls.Add(Me.chkExport)
        Me.fraAddOut.Controls.Add(Me._optAddFormat_1)
        Me.fraAddOut.Controls.Add(Me._optAddFormat_0)
        Me.fraAddOut.Controls.Add(Me._chkAddOut_0)
        Me.fraAddOut.Controls.Add(Me._chkAddOut_1)
        Me.fraAddOut.Controls.Add(Me._cmdOpenOut_1)
        Me.fraAddOut.Controls.Add(Me._lblOutFile_1)
        Me.fraAddOut.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraAddOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAddOut.Location = New System.Drawing.Point(8, 95)
        Me.fraAddOut.Name = "fraAddOut"
        Me.fraAddOut.Padding = New System.Windows.Forms.Padding(0)
        Me.fraAddOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAddOut.Size = New System.Drawing.Size(505, 254)
        Me.fraAddOut.TabIndex = 5
        Me.fraAddOut.TabStop = False
        Me.fraAddOut.Text = "Additional Output"
        '
        'lblEmpirical
        '
        Me.lblEmpirical.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmpirical.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmpirical.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEmpirical.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpirical.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmpirical.Location = New System.Drawing.Point(72, 209)
        Me.lblEmpirical.Name = "lblEmpirical"
        Me.lblEmpirical.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEmpirical.Size = New System.Drawing.Size(430, 45)
        Me.lblEmpirical.TabIndex = 48
        Me.lblEmpirical.Text = "(none)"
        '
        'cmdOpenEmpirical
        '
        Me.cmdOpenEmpirical.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOpenEmpirical.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOpenEmpirical.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpenEmpirical.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOpenEmpirical.Location = New System.Drawing.Point(8, 212)
        Me.cmdOpenEmpirical.Name = "cmdOpenEmpirical"
        Me.cmdOpenEmpirical.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOpenEmpirical.Size = New System.Drawing.Size(57, 25)
        Me.cmdOpenEmpirical.TabIndex = 47
        Me.cmdOpenEmpirical.Text = "Select"
        Me.cmdOpenEmpirical.UseVisualStyleBackColor = False
        '
        'chkEmpirical
        '
        Me.chkEmpirical.BackColor = System.Drawing.SystemColors.Control
        Me.chkEmpirical.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkEmpirical.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmpirical.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkEmpirical.Location = New System.Drawing.Point(8, 189)
        Me.chkEmpirical.Name = "chkEmpirical"
        Me.chkEmpirical.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkEmpirical.Size = New System.Drawing.Size(201, 17)
        Me.chkEmpirical.TabIndex = 46
        Me.chkEmpirical.Text = "Empirical Frequency Curve Table"
        Me.chkEmpirical.UseVisualStyleBackColor = False
        '
        'lblExportFile
        '
        Me.lblExportFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExportFile.BackColor = System.Drawing.SystemColors.Control
        Me.lblExportFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExportFile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExportFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExportFile.Location = New System.Drawing.Point(72, 124)
        Me.lblExportFile.Name = "lblExportFile"
        Me.lblExportFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExportFile.Size = New System.Drawing.Size(430, 38)
        Me.lblExportFile.TabIndex = 45
        Me.lblExportFile.Text = "(none)"
        '
        'cmdOpenExport
        '
        Me.cmdOpenExport.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOpenExport.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOpenExport.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpenExport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOpenExport.Location = New System.Drawing.Point(8, 127)
        Me.cmdOpenExport.Name = "cmdOpenExport"
        Me.cmdOpenExport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOpenExport.Size = New System.Drawing.Size(57, 25)
        Me.cmdOpenExport.TabIndex = 44
        Me.cmdOpenExport.Text = "Select"
        Me.cmdOpenExport.UseVisualStyleBackColor = False
        '
        'chkExport
        '
        Me.chkExport.BackColor = System.Drawing.SystemColors.Control
        Me.chkExport.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkExport.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkExport.Location = New System.Drawing.Point(8, 104)
        Me.chkExport.Name = "chkExport"
        Me.chkExport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkExport.Size = New System.Drawing.Size(86, 17)
        Me.chkExport.TabIndex = 43
        Me.chkExport.Text = "Export File"
        Me.chkExport.UseVisualStyleBackColor = False
        '
        '_optAddFormat_1
        '
        Me._optAddFormat_1.BackColor = System.Drawing.SystemColors.Control
        Me._optAddFormat_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAddFormat_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._optAddFormat_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAddFormat.SetIndex(Me._optAddFormat_1, CType(1, Short))
        Me._optAddFormat_1.Location = New System.Drawing.Point(192, 32)
        Me._optAddFormat_1.Name = "_optAddFormat_1"
        Me._optAddFormat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAddFormat_1.Size = New System.Drawing.Size(145, 17)
        Me._optAddFormat_1.TabIndex = 42
        Me._optAddFormat_1.TabStop = True
        Me._optAddFormat_1.Text = "Tab-Delimited"
        Me._optAddFormat_1.UseVisualStyleBackColor = False
        Me._optAddFormat_1.Visible = False
        '
        '_optAddFormat_0
        '
        Me._optAddFormat_0.BackColor = System.Drawing.SystemColors.Control
        Me._optAddFormat_0.Checked = True
        Me._optAddFormat_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAddFormat_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._optAddFormat_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAddFormat.SetIndex(Me._optAddFormat_0, CType(0, Short))
        Me._optAddFormat_0.Location = New System.Drawing.Point(192, 16)
        Me._optAddFormat_0.Name = "_optAddFormat_0"
        Me._optAddFormat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAddFormat_0.Size = New System.Drawing.Size(145, 17)
        Me._optAddFormat_0.TabIndex = 41
        Me._optAddFormat_0.TabStop = True
        Me._optAddFormat_0.Text = "Watstore"
        Me._optAddFormat_0.UseVisualStyleBackColor = False
        Me._optAddFormat_0.Visible = False
        '
        '_chkAddOut_0
        '
        Me._chkAddOut_0.BackColor = System.Drawing.SystemColors.Control
        Me._chkAddOut_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkAddOut_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._chkAddOut_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAddOut.SetIndex(Me._chkAddOut_0, CType(0, Short))
        Me._chkAddOut_0.Location = New System.Drawing.Point(8, 24)
        Me._chkAddOut_0.Name = "_chkAddOut_0"
        Me._chkAddOut_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkAddOut_0.Size = New System.Drawing.Size(65, 17)
        Me._chkAddOut_0.TabIndex = 8
        Me._chkAddOut_0.Text = "WDM"
        Me._chkAddOut_0.UseVisualStyleBackColor = False
        '
        '_chkAddOut_1
        '
        Me._chkAddOut_1.BackColor = System.Drawing.SystemColors.Control
        Me._chkAddOut_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkAddOut_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._chkAddOut_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAddOut.SetIndex(Me._chkAddOut_1, CType(1, Short))
        Me._chkAddOut_1.Location = New System.Drawing.Point(88, 24)
        Me._chkAddOut_1.Name = "_chkAddOut_1"
        Me._chkAddOut_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkAddOut_1.Size = New System.Drawing.Size(81, 17)
        Me._chkAddOut_1.TabIndex = 7
        Me._chkAddOut_1.Text = "Text File"
        Me._chkAddOut_1.UseVisualStyleBackColor = False
        '
        '_cmdOpenOut_1
        '
        Me._cmdOpenOut_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdOpenOut_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdOpenOut_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdOpenOut_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOpenOut.SetIndex(Me._cmdOpenOut_1, CType(1, Short))
        Me._cmdOpenOut_1.Location = New System.Drawing.Point(8, 48)
        Me._cmdOpenOut_1.Name = "_cmdOpenOut_1"
        Me._cmdOpenOut_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdOpenOut_1.Size = New System.Drawing.Size(57, 25)
        Me._cmdOpenOut_1.TabIndex = 6
        Me._cmdOpenOut_1.Text = "Select"
        Me._cmdOpenOut_1.UseVisualStyleBackColor = False
        '
        '_lblOutFile_1
        '
        Me._lblOutFile_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblOutFile_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblOutFile_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblOutFile_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblOutFile_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOutFile.SetIndex(Me._lblOutFile_1, CType(1, Short))
        Me._lblOutFile_1.Location = New System.Drawing.Point(72, 48)
        Me._lblOutFile_1.Name = "_lblOutFile_1"
        Me._lblOutFile_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblOutFile_1.Size = New System.Drawing.Size(430, 40)
        Me._lblOutFile_1.TabIndex = 9
        Me._lblOutFile_1.Text = "(none)"
        '
        'fraOutRight
        '
        Me.fraOutRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraOutRight.BackColor = System.Drawing.SystemColors.Control
        Me.fraOutRight.Controls.Add(Me.cboGraphFormat)
        Me.fraOutRight.Controls.Add(Me.txtCL)
        Me.fraOutRight.Controls.Add(Me.txtPlotPos)
        Me.fraOutRight.Controls.Add(Me.chkPlotPos)
        Me.fraOutRight.Controls.Add(Me.chkLinePrinter)
        Me.fraOutRight.Controls.Add(Me.chkIntRes)
        Me.fraOutRight.Controls.Add(Me.lblGraphics)
        Me.fraOutRight.Controls.Add(Me.lblPlotPos)
        Me.fraOutRight.Controls.Add(Me.lblCL)
        Me.fraOutRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraOutRight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraOutRight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOutRight.Location = New System.Drawing.Point(533, 12)
        Me.fraOutRight.Name = "fraOutRight"
        Me.fraOutRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOutRight.Size = New System.Drawing.Size(193, 185)
        Me.fraOutRight.TabIndex = 21
        '
        'cboGraphFormat
        '
        Me.cboGraphFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGraphFormat.FormattingEnabled = True
        Me.cboGraphFormat.Items.AddRange(New Object() {"None", "EMF - Enhanced Windows Metafile", "PNG - Portable Network Graphics", "GIF - Graphic Interchange Format", "JPEG", "TIFF", "BMP - Bitmap"})
        Me.cboGraphFormat.Location = New System.Drawing.Point(3, 94)
        Me.cboGraphFormat.Name = "cboGraphFormat"
        Me.cboGraphFormat.Size = New System.Drawing.Size(187, 22)
        Me.cboGraphFormat.TabIndex = 42
        '
        'txtCL
        '
        Me.txtCL.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCL.DataType = atcControls.atcText.ATCoDataType.ATCoDbl
        Me.txtCL.DefaultValue = ""
        Me.txtCL.HardMax = 0.995R
        Me.txtCL.HardMin = 0.5R
        Me.txtCL.InsideLimitsBackground = System.Drawing.Color.White
        Me.txtCL.Location = New System.Drawing.Point(120, 157)
        Me.txtCL.MaxWidth = 20
        Me.txtCL.Name = "txtCL"
        Me.txtCL.NumericFormat = "0.#####"
        Me.txtCL.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.txtCL.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.txtCL.SelLength = 0
        Me.txtCL.SelStart = 0
        Me.txtCL.Size = New System.Drawing.Size(49, 20)
        Me.txtCL.SoftMax = -999.0R
        Me.txtCL.SoftMin = -999.0R
        Me.txtCL.TabIndex = 41
        Me.txtCL.ValueDouble = 0.995R
        Me.txtCL.ValueInteger = 0
        '
        'txtPlotPos
        '
        Me.txtPlotPos.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPlotPos.DataType = atcControls.atcText.ATCoDataType.ATCoDbl
        Me.txtPlotPos.DefaultValue = ""
        Me.txtPlotPos.HardMax = 0.5R
        Me.txtPlotPos.HardMin = 0.0R
        Me.txtPlotPos.InsideLimitsBackground = System.Drawing.Color.White
        Me.txtPlotPos.Location = New System.Drawing.Point(120, 134)
        Me.txtPlotPos.MaxWidth = 20
        Me.txtPlotPos.Name = "txtPlotPos"
        Me.txtPlotPos.NumericFormat = "0.#####"
        Me.txtPlotPos.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.txtPlotPos.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.txtPlotPos.SelLength = 0
        Me.txtPlotPos.SelStart = 0
        Me.txtPlotPos.Size = New System.Drawing.Size(49, 20)
        Me.txtPlotPos.SoftMax = -999.0R
        Me.txtPlotPos.SoftMin = -999.0R
        Me.txtPlotPos.TabIndex = 40
        Me.txtPlotPos.ValueDouble = 0.0R
        Me.txtPlotPos.ValueInteger = 0
        '
        'chkPlotPos
        '
        Me.chkPlotPos.AutoSize = True
        Me.chkPlotPos.BackColor = System.Drawing.SystemColors.Control
        Me.chkPlotPos.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlotPos.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPlotPos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlotPos.Location = New System.Drawing.Point(0, 24)
        Me.chkPlotPos.Name = "chkPlotPos"
        Me.chkPlotPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlotPos.Size = New System.Drawing.Size(130, 18)
        Me.chkPlotPos.TabIndex = 24
        Me.chkPlotPos.Text = "Print Plotting Positions"
        Me.chkPlotPos.UseVisualStyleBackColor = False
        '
        'chkLinePrinter
        '
        Me.chkLinePrinter.AutoSize = True
        Me.chkLinePrinter.BackColor = System.Drawing.SystemColors.Control
        Me.chkLinePrinter.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkLinePrinter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLinePrinter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkLinePrinter.Location = New System.Drawing.Point(0, 48)
        Me.chkLinePrinter.Name = "chkLinePrinter"
        Me.chkLinePrinter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkLinePrinter.Size = New System.Drawing.Size(106, 18)
        Me.chkLinePrinter.TabIndex = 23
        Me.chkLinePrinter.Text = "Line Printer Plots"
        Me.chkLinePrinter.UseVisualStyleBackColor = False
        '
        'chkIntRes
        '
        Me.chkIntRes.AutoSize = True
        Me.chkIntRes.BackColor = System.Drawing.SystemColors.Control
        Me.chkIntRes.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIntRes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIntRes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkIntRes.Location = New System.Drawing.Point(0, 0)
        Me.chkIntRes.Name = "chkIntRes"
        Me.chkIntRes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIntRes.Size = New System.Drawing.Size(158, 18)
        Me.chkIntRes.TabIndex = 22
        Me.chkIntRes.Text = "Output Intermediate Results"
        Me.chkIntRes.UseVisualStyleBackColor = False
        Me.chkIntRes.Visible = False
        '
        'lblGraphics
        '
        Me.lblGraphics.BackColor = System.Drawing.SystemColors.Control
        Me.lblGraphics.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGraphics.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGraphics.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGraphics.Location = New System.Drawing.Point(3, 74)
        Me.lblGraphics.Name = "lblGraphics"
        Me.lblGraphics.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGraphics.Size = New System.Drawing.Size(137, 17)
        Me.lblGraphics.TabIndex = 34
        Me.lblGraphics.Text = "Graphic Plot Format"
        '
        'lblPlotPos
        '
        Me.lblPlotPos.AutoSize = True
        Me.lblPlotPos.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlotPos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlotPos.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlotPos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlotPos.Location = New System.Drawing.Point(3, 136)
        Me.lblPlotPos.Name = "lblPlotPos"
        Me.lblPlotPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlotPos.Size = New System.Drawing.Size(84, 14)
        Me.lblPlotPos.TabIndex = 28
        Me.lblPlotPos.Text = "Plotting Position:"
        '
        'lblCL
        '
        Me.lblCL.AutoSize = True
        Me.lblCL.BackColor = System.Drawing.SystemColors.Control
        Me.lblCL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCL.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCL.Location = New System.Drawing.Point(3, 157)
        Me.lblCL.Name = "lblCL"
        Me.lblCL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCL.Size = New System.Drawing.Size(109, 14)
        Me.lblCL.TabIndex = 27
        Me.lblCL.Text = "Confidence Intervals:"
        '
        'tabResults
        '
        Me.tabResults.Controls.Add(Me._fraOutFileRes_1)
        Me.tabResults.Controls.Add(Me.fraGraphics)
        Me.tabResults.Controls.Add(Me._fraOutFileRes_0)
        Me.tabResults.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabResults.Location = New System.Drawing.Point(4, 22)
        Me.tabResults.Name = "tabResults"
        Me.tabResults.Size = New System.Drawing.Size(1113, 373)
        Me.tabResults.TabIndex = 2
        Me.tabResults.Text = "Results"
        Me.tabResults.UseVisualStyleBackColor = True
        '
        '_fraOutFileRes_1
        '
        Me._fraOutFileRes_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._fraOutFileRes_1.BackColor = System.Drawing.SystemColors.Control
        Me._fraOutFileRes_1.Controls.Add(Me.cmdEmpiricalFileView)
        Me._fraOutFileRes_1.Controls.Add(Me.lblEmpiricalFileView)
        Me._fraOutFileRes_1.Controls.Add(Me.cmdExportFileView)
        Me._fraOutFileRes_1.Controls.Add(Me.lblExportFileView)
        Me._fraOutFileRes_1.Controls.Add(Me._cmdOutFileView_1)
        Me._fraOutFileRes_1.Controls.Add(Me._lblOutFileView_1)
        Me._fraOutFileRes_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._fraOutFileRes_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOutFileRes.SetIndex(Me._fraOutFileRes_1, CType(1, Short))
        Me._fraOutFileRes_1.Location = New System.Drawing.Point(8, 95)
        Me._fraOutFileRes_1.Name = "_fraOutFileRes_1"
        Me._fraOutFileRes_1.Padding = New System.Windows.Forms.Padding(0)
        Me._fraOutFileRes_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraOutFileRes_1.Size = New System.Drawing.Size(505, 245)
        Me._fraOutFileRes_1.TabIndex = 10
        Me._fraOutFileRes_1.TabStop = False
        Me._fraOutFileRes_1.Text = "Additional Output"
        '
        'cmdEmpiricalFileView
        '
        Me.cmdEmpiricalFileView.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEmpiricalFileView.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEmpiricalFileView.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEmpiricalFileView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEmpiricalFileView.Location = New System.Drawing.Point(8, 180)
        Me.cmdEmpiricalFileView.Name = "cmdEmpiricalFileView"
        Me.cmdEmpiricalFileView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEmpiricalFileView.Size = New System.Drawing.Size(57, 25)
        Me.cmdEmpiricalFileView.TabIndex = 15
        Me.cmdEmpiricalFileView.Text = "View"
        Me.cmdEmpiricalFileView.UseVisualStyleBackColor = False
        '
        'lblEmpiricalFileView
        '
        Me.lblEmpiricalFileView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmpiricalFileView.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmpiricalFileView.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEmpiricalFileView.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpiricalFileView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmpiricalFileView.Location = New System.Drawing.Point(72, 180)
        Me.lblEmpiricalFileView.Name = "lblEmpiricalFileView"
        Me.lblEmpiricalFileView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEmpiricalFileView.Size = New System.Drawing.Size(430, 48)
        Me.lblEmpiricalFileView.TabIndex = 16
        Me.lblEmpiricalFileView.Text = "(none)"
        '
        'cmdExportFileView
        '
        Me.cmdExportFileView.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportFileView.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExportFileView.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportFileView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportFileView.Location = New System.Drawing.Point(8, 97)
        Me.cmdExportFileView.Name = "cmdExportFileView"
        Me.cmdExportFileView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExportFileView.Size = New System.Drawing.Size(57, 25)
        Me.cmdExportFileView.TabIndex = 13
        Me.cmdExportFileView.Text = "View"
        Me.cmdExportFileView.UseVisualStyleBackColor = False
        '
        'lblExportFileView
        '
        Me.lblExportFileView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExportFileView.BackColor = System.Drawing.SystemColors.Control
        Me.lblExportFileView.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExportFileView.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExportFileView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExportFileView.Location = New System.Drawing.Point(72, 97)
        Me.lblExportFileView.Name = "lblExportFileView"
        Me.lblExportFileView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExportFileView.Size = New System.Drawing.Size(430, 44)
        Me.lblExportFileView.TabIndex = 14
        Me.lblExportFileView.Text = "(none)"
        '
        '_cmdOutFileView_1
        '
        Me._cmdOutFileView_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdOutFileView_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdOutFileView_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdOutFileView_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOutFileView.SetIndex(Me._cmdOutFileView_1, CType(1, Short))
        Me._cmdOutFileView_1.Location = New System.Drawing.Point(8, 16)
        Me._cmdOutFileView_1.Name = "_cmdOutFileView_1"
        Me._cmdOutFileView_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdOutFileView_1.Size = New System.Drawing.Size(57, 25)
        Me._cmdOutFileView_1.TabIndex = 11
        Me._cmdOutFileView_1.Text = "View"
        Me._cmdOutFileView_1.UseVisualStyleBackColor = False
        '
        '_lblOutFileView_1
        '
        Me._lblOutFileView_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblOutFileView_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblOutFileView_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblOutFileView_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblOutFileView_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOutFileView.SetIndex(Me._lblOutFileView_1, CType(1, Short))
        Me._lblOutFileView_1.Location = New System.Drawing.Point(72, 16)
        Me._lblOutFileView_1.Name = "_lblOutFileView_1"
        Me._lblOutFileView_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblOutFileView_1.Size = New System.Drawing.Size(430, 45)
        Me._lblOutFileView_1.TabIndex = 12
        Me._lblOutFileView_1.Text = "(none)"
        '
        'fraGraphics
        '
        Me.fraGraphics.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraGraphics.BackColor = System.Drawing.SystemColors.Control
        Me.fraGraphics.Controls.Add(Me.cmdGraph)
        Me.fraGraphics.Controls.Add(Me.lstGraphs)
        Me.fraGraphics.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraGraphics.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraGraphics.Location = New System.Drawing.Point(541, 8)
        Me.fraGraphics.Name = "fraGraphics"
        Me.fraGraphics.Padding = New System.Windows.Forms.Padding(0)
        Me.fraGraphics.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraGraphics.Size = New System.Drawing.Size(185, 332)
        Me.fraGraphics.TabIndex = 13
        Me.fraGraphics.TabStop = False
        Me.fraGraphics.Text = "Graphs"
        '
        'cmdGraph
        '
        Me.cmdGraph.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGraph.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGraph.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGraph.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGraph.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGraph.Location = New System.Drawing.Point(120, 304)
        Me.cmdGraph.Name = "cmdGraph"
        Me.cmdGraph.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGraph.Size = New System.Drawing.Size(57, 25)
        Me.cmdGraph.TabIndex = 40
        Me.cmdGraph.Text = "View"
        Me.cmdGraph.UseVisualStyleBackColor = False
        '
        'lstGraphs
        '
        Me.lstGraphs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstGraphs.BackColor = System.Drawing.SystemColors.Window
        Me.lstGraphs.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstGraphs.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGraphs.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstGraphs.IntegralHeight = False
        Me.lstGraphs.ItemHeight = 14
        Me.lstGraphs.Location = New System.Drawing.Point(8, 16)
        Me.lstGraphs.Name = "lstGraphs"
        Me.lstGraphs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstGraphs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstGraphs.Size = New System.Drawing.Size(169, 282)
        Me.lstGraphs.TabIndex = 14
        '
        '_fraOutFileRes_0
        '
        Me._fraOutFileRes_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._fraOutFileRes_0.BackColor = System.Drawing.SystemColors.Control
        Me._fraOutFileRes_0.Controls.Add(Me._cmdOutFileView_0)
        Me._fraOutFileRes_0.Controls.Add(Me._lblOutFileView_0)
        Me._fraOutFileRes_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._fraOutFileRes_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOutFileRes.SetIndex(Me._fraOutFileRes_0, CType(0, Short))
        Me._fraOutFileRes_0.Location = New System.Drawing.Point(8, 8)
        Me._fraOutFileRes_0.Name = "_fraOutFileRes_0"
        Me._fraOutFileRes_0.Padding = New System.Windows.Forms.Padding(0)
        Me._fraOutFileRes_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraOutFileRes_0.Size = New System.Drawing.Size(505, 81)
        Me._fraOutFileRes_0.TabIndex = 15
        Me._fraOutFileRes_0.TabStop = False
        Me._fraOutFileRes_0.Text = "Output File"
        '
        '_cmdOutFileView_0
        '
        Me._cmdOutFileView_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdOutFileView_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdOutFileView_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdOutFileView_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOutFileView.SetIndex(Me._cmdOutFileView_0, CType(0, Short))
        Me._cmdOutFileView_0.Location = New System.Drawing.Point(8, 16)
        Me._cmdOutFileView_0.Name = "_cmdOutFileView_0"
        Me._cmdOutFileView_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdOutFileView_0.Size = New System.Drawing.Size(57, 25)
        Me._cmdOutFileView_0.TabIndex = 16
        Me._cmdOutFileView_0.Text = "View"
        Me._cmdOutFileView_0.UseVisualStyleBackColor = False
        '
        '_lblOutFileView_0
        '
        Me._lblOutFileView_0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblOutFileView_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblOutFileView_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblOutFileView_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblOutFileView_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOutFileView.SetIndex(Me._lblOutFileView_0, CType(0, Short))
        Me._lblOutFileView_0.Location = New System.Drawing.Point(72, 16)
        Me._lblOutFileView_0.Name = "_lblOutFileView_0"
        Me._lblOutFileView_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblOutFileView_0.Size = New System.Drawing.Size(430, 57)
        Me._lblOutFileView_0.TabIndex = 17
        Me._lblOutFileView_0.Text = "(none)"
        '
        'lblInstruct
        '
        Me.lblInstruct.BackColor = System.Drawing.SystemColors.Control
        Me.lblInstruct.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInstruct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstruct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInstruct.Location = New System.Drawing.Point(8, 32)
        Me.lblInstruct.Name = "lblInstruct"
        Me.lblInstruct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInstruct.Size = New System.Drawing.Size(322, 53)
        Me.lblInstruct.TabIndex = 20
        '
        'lblSpec
        '
        Me.lblSpec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSpec.AutoSize = True
        Me.lblSpec.BackColor = System.Drawing.SystemColors.Control
        Me.lblSpec.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSpec.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpec.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSpec.Location = New System.Drawing.Point(336, 56)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSpec.Size = New System.Drawing.Size(94, 14)
        Me.lblSpec.TabIndex = 19
        Me.lblSpec.Text = "PeakFQ Spec File:"
        '
        'lblData
        '
        Me.lblData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblData.AutoSize = True
        Me.lblData.BackColor = System.Drawing.SystemColors.Control
        Me.lblData.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblData.Location = New System.Drawing.Point(336, 32)
        Me.lblData.Name = "lblData"
        Me.lblData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblData.Size = New System.Drawing.Size(95, 14)
        Me.lblData.TabIndex = 18
        Me.lblData.Text = "PEAKFQ Data File:"
        '
        'chkAddOut
        '
        '
        'cmdOpenOut
        '
        '
        'cmdOutFileView
        '
        '
        'frmPeakfq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1141, 536)
        Me.Controls.Add(Me.fraButtons)
        Me.Controls.Add(Me.sstPfq)
        Me.Controls.Add(Me.lblInstruct)
        Me.Controls.Add(Me.lblSpec)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(11, 49)
        Me.Name = "frmPeakfq"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "PeakFQ Version 7.1"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.fraButtons.ResumeLayout(False)
        Me.sstPfq.ResumeLayout(False)
        Me.tabStationSpecs.ResumeLayout(False)
        Me.tabStationSpecs.PerformLayout()
        Me.tabThresholds.ResumeLayout(False)
        Me.tabThresholds.PerformLayout()
        Me.spltInputViewTab.Panel1.ResumeLayout(False)
        Me.spltInputViewTab.Panel2.ResumeLayout(False)
        Me.spltInputViewTab.Panel2.PerformLayout()
        CType(Me.spltInputViewTab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spltInputViewTab.ResumeLayout(False)
        Me.spltThreshIntervalGrids.Panel1.ResumeLayout(False)
        Me.spltThreshIntervalGrids.Panel1.PerformLayout()
        Me.spltThreshIntervalGrids.Panel2.ResumeLayout(False)
        Me.spltThreshIntervalGrids.Panel2.PerformLayout()
        CType(Me.spltThreshIntervalGrids, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spltThreshIntervalGrids.ResumeLayout(False)
        Me.tabOutput.ResumeLayout(False)
        Me.fraOutFile.ResumeLayout(False)
        Me.fraAddOut.ResumeLayout(False)
        Me.fraOutRight.ResumeLayout(False)
        Me.fraOutRight.PerformLayout()
        Me.tabResults.ResumeLayout(False)
        Me._fraOutFileRes_1.ResumeLayout(False)
        Me.fraGraphics.ResumeLayout(False)
        Me._fraOutFileRes_0.ResumeLayout(False)
        CType(Me.chkAddOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOpenOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOutFileView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fraOutFileRes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOutFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOutFileView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optAddFormat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optGraphFormat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabThresholds As System.Windows.Forms.TabPage
    Friend WithEvents cboStation As System.Windows.Forms.ComboBox
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents cmdAddInt As System.Windows.Forms.Button
    Friend WithEvents cmdAddThr As System.Windows.Forms.Button
    Friend WithEvents lblGlobalAnalysis As System.Windows.Forms.Label
    Friend WithEvents cboAnalysisOption As System.Windows.Forms.ComboBox
    Friend WithEvents cboGraphFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblLOTest As System.Windows.Forms.Label
    Friend WithEvents cboLOTest As System.Windows.Forms.ComboBox
    Public WithEvents lblEmpirical As System.Windows.Forms.Label
    Public WithEvents cmdOpenEmpirical As System.Windows.Forms.Button
    Public WithEvents chkEmpirical As System.Windows.Forms.CheckBox
    Public WithEvents lblExportFile As System.Windows.Forms.Label
    Public WithEvents cmdOpenExport As System.Windows.Forms.Button
    Public WithEvents chkExport As System.Windows.Forms.CheckBox
    Public WithEvents cmdEmpiricalFileView As System.Windows.Forms.Button
    Public WithEvents lblEmpiricalFileView As System.Windows.Forms.Label
    Public WithEvents cmdExportFileView As System.Windows.Forms.Button
    Public WithEvents lblExportFileView As System.Windows.Forms.Label
    Friend WithEvents cboDataGraphFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblDataGraphFormat As System.Windows.Forms.Label
    Friend WithEvents spltInputViewTab As System.Windows.Forms.SplitContainer
    Friend WithEvents spltThreshIntervalGrids As System.Windows.Forms.SplitContainer
    Friend WithEvents lblThresholds As System.Windows.Forms.Label
    Friend WithEvents grdThresh As atcControls.atcGrid
    Friend WithEvents lblIntervals As System.Windows.Forms.Label
    Friend WithEvents grdInterval As atcControls.atcGrid
    Friend WithEvents zgcThresh As ZedGraph.ZedGraphControl
    Public WithEvents cmdCodeLookup As System.Windows.Forms.Button
    Friend WithEvents lblLegendMove As System.Windows.Forms.Label
    Friend WithEvents lblB17BWarning As System.Windows.Forms.Label
#End Region
End Class
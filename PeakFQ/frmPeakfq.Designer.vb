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
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeakfq))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSaveSpecs = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFeedback = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelpMain = New System.Windows.Forms.ToolStripMenuItem
        Me.fraButtons = New System.Windows.Forms.Panel
        Me.cmdRun = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cdlOpenOpen = New System.Windows.Forms.OpenFileDialog
        Me.cdlOpenSave = New System.Windows.Forms.SaveFileDialog
        Me.lblInstruct = New System.Windows.Forms.Label
        Me.lblSpec = New System.Windows.Forms.Label
        Me.lblData = New System.Windows.Forms.Label
        Me.chkAddOut = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
        Me.cmdOpenOut = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.cmdOutFileView = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.fraOutFileRes = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(Me.components)
        Me.lblOutFile = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblOutFileView = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.optAddFormat = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.optGraphFormat = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.MainTabs = New System.Windows.Forms.TabControl
        Me.TabStationSpecifications = New System.Windows.Forms.TabPage
        Me.grdSpecs = New AxATCoCtl.AxATCoGrid
        Me.TabOutputOptions = New System.Windows.Forms.TabPage
        Me.fraOutFile = New System.Windows.Forms.GroupBox
        Me._cmdOpenOut_0 = New System.Windows.Forms.Button
        Me._lblOutFile_0 = New System.Windows.Forms.Label
        Me.fraAddOut = New System.Windows.Forms.GroupBox
        Me._optAddFormat_1 = New System.Windows.Forms.RadioButton
        Me._optAddFormat_0 = New System.Windows.Forms.RadioButton
        Me._chkAddOut_0 = New System.Windows.Forms.CheckBox
        Me._chkAddOut_1 = New System.Windows.Forms.CheckBox
        Me._cmdOpenOut_1 = New System.Windows.Forms.Button
        Me._lblOutFile_1 = New System.Windows.Forms.Label
        Me.fraOutRight = New System.Windows.Forms.Panel
        Me._optGraphFormat_4 = New System.Windows.Forms.RadioButton
        Me._optGraphFormat_3 = New System.Windows.Forms.RadioButton
        Me._optGraphFormat_2 = New System.Windows.Forms.RadioButton
        Me._optGraphFormat_1 = New System.Windows.Forms.RadioButton
        Me._optGraphFormat_0 = New System.Windows.Forms.RadioButton
        Me.chkPlotPos = New System.Windows.Forms.CheckBox
        Me.chkLinePrinter = New System.Windows.Forms.CheckBox
        Me.chkIntRes = New System.Windows.Forms.CheckBox
        Me.txtCL = New AxATCoCtl.AxATCoText
        Me.txtPlotPos = New AxATCoCtl.AxATCoText
        Me.lblGraphics = New System.Windows.Forms.Label
        Me.lblPlotPos = New System.Windows.Forms.Label
        Me.lblCL = New System.Windows.Forms.Label
        Me.TabResults = New System.Windows.Forms.TabPage
        Me.grdGraphs = New AxATCoCtl.AxATCoGrid
        Me._fraOutFileRes_0 = New System.Windows.Forms.GroupBox
        Me._cmdOutFileView_0 = New System.Windows.Forms.Button
        Me._lblOutFileView_0 = New System.Windows.Forms.Label
        Me.fraGraphics = New System.Windows.Forms.GroupBox
        Me.cmdGraph = New System.Windows.Forms.Button
        Me.lstGraphs = New System.Windows.Forms.ListBox
        Me._fraOutFileRes_1 = New System.Windows.Forms.GroupBox
        Me._cmdOutFileView_1 = New System.Windows.Forms.Button
        Me._lblOutFileView_1 = New System.Windows.Forms.Label
        Me.MainMenu1.SuspendLayout()
        Me.fraButtons.SuspendLayout()
        CType(Me.chkAddOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOpenOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOutFileView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fraOutFileRes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOutFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOutFileView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optAddFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optGraphFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainTabs.SuspendLayout()
        Me.TabStationSpecifications.SuspendLayout()
        CType(Me.grdSpecs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabOutputOptions.SuspendLayout()
        Me.fraOutFile.SuspendLayout()
        Me.fraAddOut.SuspendLayout()
        Me.fraOutRight.SuspendLayout()
        CType(Me.txtCL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotPos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabResults.SuspendLayout()
        CType(Me.grdGraphs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._fraOutFileRes_0.SuspendLayout()
        Me.fraGraphics.SuspendLayout()
        Me._fraOutFileRes_1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuHelp})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(766, 27)
        Me.MainMenu1.TabIndex = 30
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpen, Me.mnuSaveSpecs, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(45, 23)
        Me.mnuFile.Text = "&File"
        '
        'mnuOpen
        '
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(172, 24)
        Me.mnuOpen.Text = "&Open"
        '
        'mnuSaveSpecs
        '
        Me.mnuSaveSpecs.Enabled = False
        Me.mnuSaveSpecs.Name = "mnuSaveSpecs"
        Me.mnuSaveSpecs.Size = New System.Drawing.Size(172, 24)
        Me.mnuSaveSpecs.Text = "&Save Specs"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(172, 24)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbout, Me.mnuFeedback, Me.mnuHelpMain})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(53, 23)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(199, 24)
        Me.mnuAbout.Text = "&About"
        '
        'mnuFeedback
        '
        Me.mnuFeedback.Name = "mnuFeedback"
        Me.mnuFeedback.Size = New System.Drawing.Size(199, 24)
        Me.mnuFeedback.Text = "Send &Feedback"
        '
        'mnuHelpMain
        '
        Me.mnuHelpMain.Name = "mnuHelpMain"
        Me.mnuHelpMain.Size = New System.Drawing.Size(199, 24)
        Me.mnuHelpMain.Text = "PKFQWin Help"
        '
        'fraButtons
        '
        Me.fraButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraButtons.BackColor = System.Drawing.SystemColors.Control
        Me.fraButtons.Controls.Add(Me.cmdRun)
        Me.fraButtons.Controls.Add(Me.cmdSave)
        Me.fraButtons.Controls.Add(Me.cmdExit)
        Me.fraButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraButtons.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraButtons.Location = New System.Drawing.Point(409, 398)
        Me.fraButtons.Name = "fraButtons"
        Me.fraButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraButtons.Size = New System.Drawing.Size(345, 25)
        Me.fraButtons.TabIndex = 29
        '
        'cmdRun
        '
        Me.cmdRun.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRun.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRun.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRun.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRun.Location = New System.Drawing.Point(0, 0)
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
        Me.cmdSave.Location = New System.Drawing.Point(120, 0)
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
        Me.cmdExit.Location = New System.Drawing.Point(288, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(57, 25)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
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
        Me.lblInstruct.Size = New System.Drawing.Size(305, 57)
        Me.lblInstruct.TabIndex = 20
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.BackColor = System.Drawing.SystemColors.Control
        Me.lblSpec.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSpec.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpec.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSpec.Location = New System.Drawing.Point(336, 56)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSpec.Size = New System.Drawing.Size(102, 14)
        Me.lblSpec.TabIndex = 19
        Me.lblSpec.Text = "PKFQWin Spec File:"
        '
        'lblData
        '
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
        'MainTabs
        '
        Me.MainTabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTabs.Controls.Add(Me.TabStationSpecifications)
        Me.MainTabs.Controls.Add(Me.TabOutputOptions)
        Me.MainTabs.Controls.Add(Me.TabResults)
        Me.MainTabs.Location = New System.Drawing.Point(12, 92)
        Me.MainTabs.Name = "MainTabs"
        Me.MainTabs.SelectedIndex = 0
        Me.MainTabs.Size = New System.Drawing.Size(742, 300)
        Me.MainTabs.TabIndex = 31
        '
        'TabStationSpecifications
        '
        Me.TabStationSpecifications.Controls.Add(Me.grdSpecs)
        Me.TabStationSpecifications.Location = New System.Drawing.Point(4, 23)
        Me.TabStationSpecifications.Name = "TabStationSpecifications"
        Me.TabStationSpecifications.Padding = New System.Windows.Forms.Padding(3)
        Me.TabStationSpecifications.Size = New System.Drawing.Size(734, 273)
        Me.TabStationSpecifications.TabIndex = 0
        Me.TabStationSpecifications.Text = "Station Specifications"
        Me.TabStationSpecifications.UseVisualStyleBackColor = True
        '
        'grdSpecs
        '
        Me.grdSpecs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdSpecs.Enabled = True
        Me.grdSpecs.Location = New System.Drawing.Point(8, 6)
        Me.grdSpecs.Name = "grdSpecs"
        Me.grdSpecs.OcxState = CType(resources.GetObject("grdSpecs.OcxState"), System.Windows.Forms.AxHost.State)
        Me.grdSpecs.Size = New System.Drawing.Size(720, 261)
        Me.grdSpecs.TabIndex = 2
        '
        'TabOutputOptions
        '
        Me.TabOutputOptions.Controls.Add(Me.fraOutFile)
        Me.TabOutputOptions.Controls.Add(Me.fraAddOut)
        Me.TabOutputOptions.Controls.Add(Me.fraOutRight)
        Me.TabOutputOptions.Location = New System.Drawing.Point(4, 23)
        Me.TabOutputOptions.Name = "TabOutputOptions"
        Me.TabOutputOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.TabOutputOptions.Size = New System.Drawing.Size(734, 273)
        Me.TabOutputOptions.TabIndex = 1
        Me.TabOutputOptions.Text = "Output Options"
        Me.TabOutputOptions.UseVisualStyleBackColor = True
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
        Me.fraOutFile.Location = New System.Drawing.Point(6, 6)
        Me.fraOutFile.Name = "fraOutFile"
        Me.fraOutFile.Padding = New System.Windows.Forms.Padding(0)
        Me.fraOutFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOutFile.Size = New System.Drawing.Size(497, 81)
        Me.fraOutFile.TabIndex = 22
        Me.fraOutFile.TabStop = False
        Me.fraOutFile.Text = "Output File"
        '
        '_cmdOpenOut_0
        '
        Me._cmdOpenOut_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdOpenOut_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdOpenOut_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdOpenOut_0.ForeColor = System.Drawing.SystemColors.ControlText
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
        Me._lblOutFile_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblOutFile_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblOutFile_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblOutFile_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblOutFile_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblOutFile_0.Location = New System.Drawing.Point(72, 16)
        Me._lblOutFile_0.Name = "_lblOutFile_0"
        Me._lblOutFile_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblOutFile_0.Size = New System.Drawing.Size(412, 49)
        Me._lblOutFile_0.TabIndex = 4
        Me._lblOutFile_0.Text = "(none)"
        '
        'fraAddOut
        '
        Me.fraAddOut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraAddOut.BackColor = System.Drawing.SystemColors.Control
        Me.fraAddOut.Controls.Add(Me._optAddFormat_1)
        Me.fraAddOut.Controls.Add(Me._optAddFormat_0)
        Me.fraAddOut.Controls.Add(Me._chkAddOut_0)
        Me.fraAddOut.Controls.Add(Me._chkAddOut_1)
        Me.fraAddOut.Controls.Add(Me._cmdOpenOut_1)
        Me.fraAddOut.Controls.Add(Me._lblOutFile_1)
        Me.fraAddOut.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraAddOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAddOut.Location = New System.Drawing.Point(6, 94)
        Me.fraAddOut.Name = "fraAddOut"
        Me.fraAddOut.Padding = New System.Windows.Forms.Padding(0)
        Me.fraAddOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAddOut.Size = New System.Drawing.Size(497, 105)
        Me.fraAddOut.TabIndex = 23
        Me.fraAddOut.TabStop = False
        Me.fraAddOut.Text = "Additional Output"
        '
        '_optAddFormat_1
        '
        Me._optAddFormat_1.BackColor = System.Drawing.SystemColors.Control
        Me._optAddFormat_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAddFormat_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._optAddFormat_1.ForeColor = System.Drawing.SystemColors.ControlText
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
        Me._lblOutFile_1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblOutFile_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblOutFile_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblOutFile_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblOutFile_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblOutFile_1.Location = New System.Drawing.Point(72, 48)
        Me._lblOutFile_1.Name = "_lblOutFile_1"
        Me._lblOutFile_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblOutFile_1.Size = New System.Drawing.Size(412, 49)
        Me._lblOutFile_1.TabIndex = 9
        Me._lblOutFile_1.Text = "(none)"
        '
        'fraOutRight
        '
        Me.fraOutRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraOutRight.BackColor = System.Drawing.SystemColors.Control
        Me.fraOutRight.Controls.Add(Me._optGraphFormat_4)
        Me.fraOutRight.Controls.Add(Me._optGraphFormat_3)
        Me.fraOutRight.Controls.Add(Me._optGraphFormat_2)
        Me.fraOutRight.Controls.Add(Me._optGraphFormat_1)
        Me.fraOutRight.Controls.Add(Me._optGraphFormat_0)
        Me.fraOutRight.Controls.Add(Me.chkPlotPos)
        Me.fraOutRight.Controls.Add(Me.chkLinePrinter)
        Me.fraOutRight.Controls.Add(Me.chkIntRes)
        Me.fraOutRight.Controls.Add(Me.txtCL)
        Me.fraOutRight.Controls.Add(Me.txtPlotPos)
        Me.fraOutRight.Controls.Add(Me.lblGraphics)
        Me.fraOutRight.Controls.Add(Me.lblPlotPos)
        Me.fraOutRight.Controls.Add(Me.lblCL)
        Me.fraOutRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraOutRight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraOutRight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOutRight.Location = New System.Drawing.Point(526, 14)
        Me.fraOutRight.Name = "fraOutRight"
        Me.fraOutRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOutRight.Size = New System.Drawing.Size(193, 185)
        Me.fraOutRight.TabIndex = 24
        '
        '_optGraphFormat_4
        '
        Me._optGraphFormat_4.BackColor = System.Drawing.SystemColors.Control
        Me._optGraphFormat_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._optGraphFormat_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._optGraphFormat_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optGraphFormat_4.Location = New System.Drawing.Point(80, 107)
        Me._optGraphFormat_4.Name = "_optGraphFormat_4"
        Me._optGraphFormat_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optGraphFormat_4.Size = New System.Drawing.Size(65, 17)
        Me._optGraphFormat_4.TabIndex = 39
        Me._optGraphFormat_4.TabStop = True
        Me._optGraphFormat_4.Text = "WMF"
        Me._optGraphFormat_4.UseVisualStyleBackColor = False
        '
        '_optGraphFormat_3
        '
        Me._optGraphFormat_3.BackColor = System.Drawing.SystemColors.Control
        Me._optGraphFormat_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._optGraphFormat_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._optGraphFormat_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optGraphFormat_3.Location = New System.Drawing.Point(144, 88)
        Me._optGraphFormat_3.Name = "_optGraphFormat_3"
        Me._optGraphFormat_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optGraphFormat_3.Size = New System.Drawing.Size(49, 17)
        Me._optGraphFormat_3.TabIndex = 38
        Me._optGraphFormat_3.TabStop = True
        Me._optGraphFormat_3.Text = "PS"
        Me._optGraphFormat_3.UseVisualStyleBackColor = False
        '
        '_optGraphFormat_2
        '
        Me._optGraphFormat_2.BackColor = System.Drawing.SystemColors.Control
        Me._optGraphFormat_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optGraphFormat_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._optGraphFormat_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optGraphFormat_2.Location = New System.Drawing.Point(80, 88)
        Me._optGraphFormat_2.Name = "_optGraphFormat_2"
        Me._optGraphFormat_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optGraphFormat_2.Size = New System.Drawing.Size(65, 17)
        Me._optGraphFormat_2.TabIndex = 37
        Me._optGraphFormat_2.TabStop = True
        Me._optGraphFormat_2.Text = "CGM"
        Me._optGraphFormat_2.UseVisualStyleBackColor = False
        '
        '_optGraphFormat_1
        '
        Me._optGraphFormat_1.BackColor = System.Drawing.SystemColors.Control
        Me._optGraphFormat_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optGraphFormat_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._optGraphFormat_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optGraphFormat_1.Location = New System.Drawing.Point(16, 107)
        Me._optGraphFormat_1.Name = "_optGraphFormat_1"
        Me._optGraphFormat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optGraphFormat_1.Size = New System.Drawing.Size(65, 17)
        Me._optGraphFormat_1.TabIndex = 36
        Me._optGraphFormat_1.TabStop = True
        Me._optGraphFormat_1.Text = "BMP"
        Me._optGraphFormat_1.UseVisualStyleBackColor = False
        '
        '_optGraphFormat_0
        '
        Me._optGraphFormat_0.BackColor = System.Drawing.SystemColors.Control
        Me._optGraphFormat_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optGraphFormat_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._optGraphFormat_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optGraphFormat_0.Location = New System.Drawing.Point(16, 88)
        Me._optGraphFormat_0.Name = "_optGraphFormat_0"
        Me._optGraphFormat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optGraphFormat_0.Size = New System.Drawing.Size(65, 17)
        Me._optGraphFormat_0.TabIndex = 35
        Me._optGraphFormat_0.TabStop = True
        Me._optGraphFormat_0.Text = "None"
        Me._optGraphFormat_0.UseVisualStyleBackColor = False
        '
        'chkPlotPos
        '
        Me.chkPlotPos.BackColor = System.Drawing.SystemColors.Control
        Me.chkPlotPos.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlotPos.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPlotPos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlotPos.Location = New System.Drawing.Point(0, 24)
        Me.chkPlotPos.Name = "chkPlotPos"
        Me.chkPlotPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlotPos.Size = New System.Drawing.Size(169, 17)
        Me.chkPlotPos.TabIndex = 24
        Me.chkPlotPos.Text = "Print Plotting Positions"
        Me.chkPlotPos.UseVisualStyleBackColor = False
        '
        'chkLinePrinter
        '
        Me.chkLinePrinter.BackColor = System.Drawing.SystemColors.Control
        Me.chkLinePrinter.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkLinePrinter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLinePrinter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkLinePrinter.Location = New System.Drawing.Point(0, 48)
        Me.chkLinePrinter.Name = "chkLinePrinter"
        Me.chkLinePrinter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkLinePrinter.Size = New System.Drawing.Size(185, 17)
        Me.chkLinePrinter.TabIndex = 23
        Me.chkLinePrinter.Text = "Line Printer Plots"
        Me.chkLinePrinter.UseVisualStyleBackColor = False
        '
        'chkIntRes
        '
        Me.chkIntRes.BackColor = System.Drawing.SystemColors.Control
        Me.chkIntRes.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIntRes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIntRes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkIntRes.Location = New System.Drawing.Point(0, 0)
        Me.chkIntRes.Name = "chkIntRes"
        Me.chkIntRes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIntRes.Size = New System.Drawing.Size(193, 17)
        Me.chkIntRes.TabIndex = 22
        Me.chkIntRes.Text = "Output Intermediate Results"
        Me.chkIntRes.UseVisualStyleBackColor = False
        '
        'txtCL
        '
        Me.txtCL.Enabled = True
        Me.txtCL.Location = New System.Drawing.Point(120, 160)
        Me.txtCL.Name = "txtCL"
        Me.txtCL.OcxState = CType(resources.GetObject("txtCL.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtCL.Size = New System.Drawing.Size(49, 17)
        Me.txtCL.TabIndex = 25
        '
        'txtPlotPos
        '
        Me.txtPlotPos.Enabled = True
        Me.txtPlotPos.Location = New System.Drawing.Point(120, 136)
        Me.txtPlotPos.Name = "txtPlotPos"
        Me.txtPlotPos.OcxState = CType(resources.GetObject("txtPlotPos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtPlotPos.Size = New System.Drawing.Size(49, 17)
        Me.txtPlotPos.TabIndex = 26
        '
        'lblGraphics
        '
        Me.lblGraphics.BackColor = System.Drawing.SystemColors.Control
        Me.lblGraphics.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGraphics.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGraphics.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGraphics.Location = New System.Drawing.Point(0, 72)
        Me.lblGraphics.Name = "lblGraphics"
        Me.lblGraphics.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGraphics.Size = New System.Drawing.Size(137, 17)
        Me.lblGraphics.TabIndex = 34
        Me.lblGraphics.Text = "Graphic Plot Format"
        '
        'lblPlotPos
        '
        Me.lblPlotPos.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlotPos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlotPos.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlotPos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlotPos.Location = New System.Drawing.Point(0, 136)
        Me.lblPlotPos.Name = "lblPlotPos"
        Me.lblPlotPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlotPos.Size = New System.Drawing.Size(121, 17)
        Me.lblPlotPos.TabIndex = 28
        Me.lblPlotPos.Text = "Plotting Position:"
        '
        'lblCL
        '
        Me.lblCL.BackColor = System.Drawing.SystemColors.Control
        Me.lblCL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCL.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCL.Location = New System.Drawing.Point(0, 160)
        Me.lblCL.Name = "lblCL"
        Me.lblCL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCL.Size = New System.Drawing.Size(121, 17)
        Me.lblCL.TabIndex = 27
        Me.lblCL.Text = "Confidence Limits:"
        '
        'TabResults
        '
        Me.TabResults.Controls.Add(Me._fraOutFileRes_0)
        Me.TabResults.Controls.Add(Me.fraGraphics)
        Me.TabResults.Controls.Add(Me._fraOutFileRes_1)
        Me.TabResults.Location = New System.Drawing.Point(4, 23)
        Me.TabResults.Name = "TabResults"
        Me.TabResults.Size = New System.Drawing.Size(734, 273)
        Me.TabResults.TabIndex = 2
        Me.TabResults.Text = "Results"
        Me.TabResults.UseVisualStyleBackColor = True
        '
        'grdGraphs
        '
        Me.grdGraphs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdGraphs.Enabled = True
        Me.grdGraphs.Location = New System.Drawing.Point(8, 16)
        Me.grdGraphs.Name = "grdGraphs"
        Me.grdGraphs.OcxState = CType(resources.GetObject("grdGraphs.OcxState"), System.Windows.Forms.AxHost.State)
        Me.grdGraphs.Size = New System.Drawing.Size(169, 212)
        Me.grdGraphs.TabIndex = 37
        Me.grdGraphs.Visible = False
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
        Me._fraOutFileRes_0.Location = New System.Drawing.Point(3, 3)
        Me._fraOutFileRes_0.Name = "_fraOutFileRes_0"
        Me._fraOutFileRes_0.Padding = New System.Windows.Forms.Padding(0)
        Me._fraOutFileRes_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraOutFileRes_0.Size = New System.Drawing.Size(537, 81)
        Me._fraOutFileRes_0.TabIndex = 36
        Me._fraOutFileRes_0.TabStop = False
        Me._fraOutFileRes_0.Text = "Output File"
        '
        '_cmdOutFileView_0
        '
        Me._cmdOutFileView_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdOutFileView_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdOutFileView_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdOutFileView_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdOutFileView_0.Location = New System.Drawing.Point(16, 24)
        Me._cmdOutFileView_0.Name = "_cmdOutFileView_0"
        Me._cmdOutFileView_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdOutFileView_0.Size = New System.Drawing.Size(57, 25)
        Me._cmdOutFileView_0.TabIndex = 16
        Me._cmdOutFileView_0.Text = "View"
        Me._cmdOutFileView_0.UseVisualStyleBackColor = False
        '
        '_lblOutFileView_0
        '
        Me._lblOutFileView_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblOutFileView_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblOutFileView_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblOutFileView_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblOutFileView_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblOutFileView_0.Location = New System.Drawing.Point(80, 24)
        Me._lblOutFileView_0.Name = "_lblOutFileView_0"
        Me._lblOutFileView_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblOutFileView_0.Size = New System.Drawing.Size(440, 41)
        Me._lblOutFileView_0.TabIndex = 17
        Me._lblOutFileView_0.Text = "(none)"
        '
        'fraGraphics
        '
        Me.fraGraphics.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraGraphics.BackColor = System.Drawing.SystemColors.Control
        Me.fraGraphics.Controls.Add(Me.cmdGraph)
        Me.fraGraphics.Controls.Add(Me.grdGraphs)
        Me.fraGraphics.Controls.Add(Me.lstGraphs)
        Me.fraGraphics.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraGraphics.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraGraphics.Location = New System.Drawing.Point(546, 3)
        Me.fraGraphics.Name = "fraGraphics"
        Me.fraGraphics.Padding = New System.Windows.Forms.Padding(0)
        Me.fraGraphics.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraGraphics.Size = New System.Drawing.Size(185, 267)
        Me.fraGraphics.TabIndex = 35
        Me.fraGraphics.TabStop = False
        Me.fraGraphics.Text = "Graphs"
        '
        'cmdGraph
        '
        Me.cmdGraph.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGraph.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGraph.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGraph.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGraph.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGraph.Location = New System.Drawing.Point(66, 234)
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
        Me.lstGraphs.ItemHeight = 14
        Me.lstGraphs.Location = New System.Drawing.Point(8, 16)
        Me.lstGraphs.Name = "lstGraphs"
        Me.lstGraphs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstGraphs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstGraphs.Size = New System.Drawing.Size(169, 200)
        Me.lstGraphs.TabIndex = 14
        '
        '_fraOutFileRes_1
        '
        Me._fraOutFileRes_1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._fraOutFileRes_1.BackColor = System.Drawing.SystemColors.Control
        Me._fraOutFileRes_1.Controls.Add(Me._cmdOutFileView_1)
        Me._fraOutFileRes_1.Controls.Add(Me._lblOutFileView_1)
        Me._fraOutFileRes_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._fraOutFileRes_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraOutFileRes_1.Location = New System.Drawing.Point(3, 107)
        Me._fraOutFileRes_1.Name = "_fraOutFileRes_1"
        Me._fraOutFileRes_1.Padding = New System.Windows.Forms.Padding(0)
        Me._fraOutFileRes_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraOutFileRes_1.Size = New System.Drawing.Size(537, 81)
        Me._fraOutFileRes_1.TabIndex = 34
        Me._fraOutFileRes_1.TabStop = False
        Me._fraOutFileRes_1.Text = "Additional Output"
        '
        '_cmdOutFileView_1
        '
        Me._cmdOutFileView_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdOutFileView_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdOutFileView_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdOutFileView_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdOutFileView_1.Location = New System.Drawing.Point(16, 24)
        Me._cmdOutFileView_1.Name = "_cmdOutFileView_1"
        Me._cmdOutFileView_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdOutFileView_1.Size = New System.Drawing.Size(57, 25)
        Me._cmdOutFileView_1.TabIndex = 11
        Me._cmdOutFileView_1.Text = "View"
        Me._cmdOutFileView_1.UseVisualStyleBackColor = False
        '
        '_lblOutFileView_1
        '
        Me._lblOutFileView_1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblOutFileView_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblOutFileView_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblOutFileView_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblOutFileView_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblOutFileView_1.Location = New System.Drawing.Point(80, 24)
        Me._lblOutFileView_1.Name = "_lblOutFileView_1"
        Me._lblOutFileView_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblOutFileView_1.Size = New System.Drawing.Size(440, 41)
        Me._lblOutFileView_1.TabIndex = 12
        Me._lblOutFileView_1.Text = "(none)"
        '
        'frmPeakfq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(766, 435)
        Me.Controls.Add(Me.MainTabs)
        Me.Controls.Add(Me.fraButtons)
        Me.Controls.Add(Me.lblInstruct)
        Me.Controls.Add(Me.lblSpec)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(11, 59)
        Me.Name = "frmPeakfq"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "PKFQWin"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.fraButtons.ResumeLayout(False)
        CType(Me.chkAddOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOpenOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOutFileView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fraOutFileRes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOutFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOutFileView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optAddFormat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optGraphFormat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainTabs.ResumeLayout(False)
        Me.TabStationSpecifications.ResumeLayout(False)
        CType(Me.grdSpecs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabOutputOptions.ResumeLayout(False)
        Me.fraOutFile.ResumeLayout(False)
        Me.fraAddOut.ResumeLayout(False)
        Me.fraOutRight.ResumeLayout(False)
        CType(Me.txtCL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabResults.ResumeLayout(False)
        CType(Me.grdGraphs, System.ComponentModel.ISupportInitialize).EndInit()
        Me._fraOutFileRes_0.ResumeLayout(False)
        Me.fraGraphics.ResumeLayout(False)
        Me._fraOutFileRes_1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainTabs As System.Windows.Forms.TabControl
    Friend WithEvents TabStationSpecifications As System.Windows.Forms.TabPage
    Friend WithEvents TabOutputOptions As System.Windows.Forms.TabPage
    Public WithEvents grdSpecs As AxATCoCtl.AxATCoGrid
    Public WithEvents fraOutFile As System.Windows.Forms.GroupBox
    Public WithEvents _cmdOpenOut_0 As System.Windows.Forms.Button
    Public WithEvents _lblOutFile_0 As System.Windows.Forms.Label
    Public WithEvents fraAddOut As System.Windows.Forms.GroupBox
    Public WithEvents _optAddFormat_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optAddFormat_0 As System.Windows.Forms.RadioButton
    Public WithEvents _chkAddOut_0 As System.Windows.Forms.CheckBox
    Public WithEvents _chkAddOut_1 As System.Windows.Forms.CheckBox
    Public WithEvents _cmdOpenOut_1 As System.Windows.Forms.Button
    Public WithEvents _lblOutFile_1 As System.Windows.Forms.Label
    Public WithEvents fraOutRight As System.Windows.Forms.Panel
    Public WithEvents _optGraphFormat_4 As System.Windows.Forms.RadioButton
    Public WithEvents _optGraphFormat_3 As System.Windows.Forms.RadioButton
    Public WithEvents _optGraphFormat_2 As System.Windows.Forms.RadioButton
    Public WithEvents _optGraphFormat_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optGraphFormat_0 As System.Windows.Forms.RadioButton
    Public WithEvents chkPlotPos As System.Windows.Forms.CheckBox
    Public WithEvents chkLinePrinter As System.Windows.Forms.CheckBox
    Public WithEvents chkIntRes As System.Windows.Forms.CheckBox
    Public WithEvents txtCL As AxATCoCtl.AxATCoText
    Public WithEvents txtPlotPos As AxATCoCtl.AxATCoText
    Public WithEvents lblGraphics As System.Windows.Forms.Label
    Public WithEvents lblPlotPos As System.Windows.Forms.Label
    Public WithEvents lblCL As System.Windows.Forms.Label
    Friend WithEvents TabResults As System.Windows.Forms.TabPage
    Public WithEvents grdGraphs As AxATCoCtl.AxATCoGrid
    Public WithEvents _fraOutFileRes_0 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdOutFileView_0 As System.Windows.Forms.Button
    Public WithEvents _lblOutFileView_0 As System.Windows.Forms.Label
    Public WithEvents fraGraphics As System.Windows.Forms.GroupBox
    Public WithEvents cmdGraph As System.Windows.Forms.Button
    Public WithEvents lstGraphs As System.Windows.Forms.ListBox
    Public WithEvents _fraOutFileRes_1 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdOutFileView_1 As System.Windows.Forms.Button
    Public WithEvents _lblOutFileView_1 As System.Windows.Forms.Label
#End Region 
End Class
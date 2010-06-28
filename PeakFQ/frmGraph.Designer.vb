<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGraph
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
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGraph))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.zgcResults = New ZedGraph.ZedGraphControl
        Me.SuspendLayout()
        '
        'zgcResults
        '
        Me.zgcResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zgcResults.Location = New System.Drawing.Point(0, 0)
        Me.zgcResults.Name = "zgcResults"
        Me.zgcResults.ScrollGrace = 0
        Me.zgcResults.ScrollMaxX = 0
        Me.zgcResults.ScrollMaxY = 0
        Me.zgcResults.ScrollMaxY2 = 0
        Me.zgcResults.ScrollMinX = 0
        Me.zgcResults.ScrollMinY = 0
        Me.zgcResults.ScrollMinY2 = 0
        Me.zgcResults.Size = New System.Drawing.Size(639, 480)
        Me.zgcResults.TabIndex = 0
        '
        'frmGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(639, 480)
        Me.Controls.Add(Me.zgcResults)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.Name = "frmGraph"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "PEAKFQ Graph"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents zgcResults As ZedGraph.ZedGraphControl
#End Region 
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.txtTestPath = New System.Windows.Forms.TextBox()
        Me.lblTestPath = New System.Windows.Forms.Label()
        Me.lblOutputPath = New System.Windows.Forms.Label()
        Me.txtOutputPath = New System.Windows.Forms.TextBox()
        Me.cmdTestAll = New System.Windows.Forms.Button()
        Me.cdlSave = New System.Windows.Forms.SaveFileDialog()
        Me.lblHelpFAQ = New System.Windows.Forms.Label()
        Me.lblFAQLink = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(16, 13)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 0
        Me.lblVersion.Text = "Version"
        '
        'txtTestPath
        '
        Me.txtTestPath.Location = New System.Drawing.Point(83, 140)
        Me.txtTestPath.Name = "txtTestPath"
        Me.txtTestPath.Size = New System.Drawing.Size(325, 20)
        Me.txtTestPath.TabIndex = 1
        '
        'lblTestPath
        '
        Me.lblTestPath.AutoSize = True
        Me.lblTestPath.Location = New System.Drawing.Point(16, 140)
        Me.lblTestPath.Name = "lblTestPath"
        Me.lblTestPath.Size = New System.Drawing.Size(56, 13)
        Me.lblTestPath.TabIndex = 2
        Me.lblTestPath.Text = "Test Path:"
        '
        'lblOutputPath
        '
        Me.lblOutputPath.AutoSize = True
        Me.lblOutputPath.Location = New System.Drawing.Point(16, 166)
        Me.lblOutputPath.Name = "lblOutputPath"
        Me.lblOutputPath.Size = New System.Drawing.Size(67, 13)
        Me.lblOutputPath.TabIndex = 4
        Me.lblOutputPath.Text = "Output Path:"
        '
        'txtOutputPath
        '
        Me.txtOutputPath.Location = New System.Drawing.Point(83, 166)
        Me.txtOutputPath.Name = "txtOutputPath"
        Me.txtOutputPath.Size = New System.Drawing.Size(325, 20)
        Me.txtOutputPath.TabIndex = 3
        '
        'cmdTestAll
        '
        Me.cmdTestAll.Location = New System.Drawing.Point(172, 194)
        Me.cmdTestAll.Name = "cmdTestAll"
        Me.cmdTestAll.Size = New System.Drawing.Size(83, 19)
        Me.cmdTestAll.TabIndex = 5
        Me.cmdTestAll.Text = "Run Tests"
        Me.cmdTestAll.UseVisualStyleBackColor = True
        '
        'lblHelpFAQ
        '
        Me.lblHelpFAQ.AutoSize = True
        Me.lblHelpFAQ.Location = New System.Drawing.Point(16, 55)
        Me.lblHelpFAQ.Name = "lblHelpFAQ"
        Me.lblHelpFAQ.Size = New System.Drawing.Size(89, 13)
        Me.lblHelpFAQ.TabIndex = 6
        Me.lblHelpFAQ.Text = "Help available at:"
        '
        'lblFAQLink
        '
        Me.lblFAQLink.AutoSize = True
        Me.lblFAQLink.Location = New System.Drawing.Point(111, 55)
        Me.lblFAQLink.Name = "lblFAQLink"
        Me.lblFAQLink.Size = New System.Drawing.Size(314, 13)
        Me.lblFAQLink.TabIndex = 7
        Me.lblFAQLink.TabStop = True
        Me.lblFAQLink.Text = "http://acwi.gov/hydrology/Frequency/b17_swfaq/EMAFAQ.html"
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 99)
        Me.Controls.Add(Me.lblFAQLink)
        Me.Controls.Add(Me.lblHelpFAQ)
        Me.Controls.Add(Me.cmdTestAll)
        Me.Controls.Add(Me.lblOutputPath)
        Me.Controls.Add(Me.txtOutputPath)
        Me.Controls.Add(Me.lblTestPath)
        Me.Controls.Add(Me.txtTestPath)
        Me.Controls.Add(Me.lblVersion)
        Me.Name = "frmAbout"
        Me.Text = "PeakFQ About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents txtTestPath As System.Windows.Forms.TextBox
    Friend WithEvents lblTestPath As System.Windows.Forms.Label
    Friend WithEvents lblOutputPath As System.Windows.Forms.Label
    Friend WithEvents txtOutputPath As System.Windows.Forms.TextBox
    Friend WithEvents cmdTestAll As System.Windows.Forms.Button
    Friend WithEvents cdlSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblHelpFAQ As System.Windows.Forms.Label
    Friend WithEvents lblFAQLink As System.Windows.Forms.LinkLabel
End Class

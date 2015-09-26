<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cboSelSvc = New System.Windows.Forms.ComboBox()
        Me.lblStats = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboSelSvc
        '
        Me.cboSelSvc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSelSvc.FormattingEnabled = True
        Me.cboSelSvc.Location = New System.Drawing.Point(12, 24)
        Me.cboSelSvc.Name = "cboSelSvc"
        Me.cboSelSvc.Size = New System.Drawing.Size(570, 20)
        Me.cboSelSvc.TabIndex = 0
        '
        'lblStats
        '
        Me.lblStats.AutoSize = True
        Me.lblStats.Location = New System.Drawing.Point(12, 9)
        Me.lblStats.Name = "lblStats"
        Me.lblStats.Size = New System.Drawing.Size(23, 12)
        Me.lblStats.TabIndex = 1
        Me.lblStats.Text = "***"
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(124, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "***"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 131)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblStats)
        Me.Controls.Add(Me.cboSelSvc)
        Me.Name = "Form1"
        Me.Text = "Check to Windows Service"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboSelSvc As System.Windows.Forms.ComboBox
    Friend WithEvents lblStats As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class

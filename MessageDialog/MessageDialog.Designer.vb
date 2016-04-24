<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageDialog
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.lblExpand = New System.Windows.Forms.Label()
        Me.txtDetail = New System.Windows.Forms.TextBox()
        Me.MainContainer = New System.Windows.Forms.SplitContainer()
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainContainer.Panel1.SuspendLayout()
        Me.MainContainer.Panel2.SuspendLayout()
        Me.MainContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbIcon
        '
        Me.pbIcon.Location = New System.Drawing.Point(12, 12)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(32, 32)
        Me.pbIcon.TabIndex = 0
        Me.pbIcon.TabStop = False
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.Location = New System.Drawing.Point(50, 12)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessage.Size = New System.Drawing.Size(345, 118)
        Me.txtMessage.TabIndex = 100
        '
        'lblExpand
        '
        Me.lblExpand.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpand.AutoSize = True
        Me.lblExpand.Location = New System.Drawing.Point(3, 147)
        Me.lblExpand.Name = "lblExpand"
        Me.lblExpand.Size = New System.Drawing.Size(17, 12)
        Me.lblExpand.TabIndex = 101
        Me.lblExpand.Text = "▲"
        '
        'txtDetail
        '
        Me.txtDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetail.Location = New System.Drawing.Point(50, 3)
        Me.txtDetail.Multiline = True
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.ReadOnly = True
        Me.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDetail.Size = New System.Drawing.Size(345, 136)
        Me.txtDetail.TabIndex = 102
        '
        'MainContainer
        '
        Me.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainContainer.Location = New System.Drawing.Point(0, 0)
        Me.MainContainer.Name = "MainContainer"
        Me.MainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'MainContainer.Panel1
        '
        Me.MainContainer.Panel1.Controls.Add(Me.ButtonPanel)
        Me.MainContainer.Panel1.Controls.Add(Me.pbIcon)
        Me.MainContainer.Panel1.Controls.Add(Me.lblExpand)
        Me.MainContainer.Panel1.Controls.Add(Me.txtMessage)
        '
        'MainContainer.Panel2
        '
        Me.MainContainer.Panel2.Controls.Add(Me.txtDetail)
        Me.MainContainer.Panel2MinSize = 0
        Me.MainContainer.Size = New System.Drawing.Size(407, 317)
        Me.MainContainer.SplitterDistance = 162
        Me.MainContainer.TabIndex = 103
        '
        'ButtonPanel
        '
        Me.ButtonPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPanel.Location = New System.Drawing.Point(50, 136)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(345, 23)
        Me.ButtonPanel.TabIndex = 102
        '
        'MessageDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 317)
        Me.Controls.Add(Me.MainContainer)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MessageDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainContainer.Panel1.ResumeLayout(False)
        Me.MainContainer.Panel1.PerformLayout()
        Me.MainContainer.Panel2.ResumeLayout(False)
        Me.MainContainer.Panel2.PerformLayout()
        CType(Me.MainContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pbIcon As System.Windows.Forms.PictureBox
    Private WithEvents txtMessage As System.Windows.Forms.TextBox
    Private WithEvents lblExpand As System.Windows.Forms.Label
    Private WithEvents txtDetail As System.Windows.Forms.TextBox
    Private WithEvents MainContainer As System.Windows.Forms.SplitContainer
    Private WithEvents ButtonPanel As System.Windows.Forms.Panel
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageDialogTest
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
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.txtCaption = New System.Windows.Forms.TextBox()
        Me.cmbButtons = New System.Windows.Forms.ComboBox()
        Me.cmbIcon = New System.Windows.Forms.ComboBox()
        Me.cmbDefaultButton = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnShowDialog = New System.Windows.Forms.Button()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnException = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtText
        '
        Me.txtText.Location = New System.Drawing.Point(94, 12)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(330, 99)
        Me.txtText.TabIndex = 0
        '
        'txtCaption
        '
        Me.txtCaption.Location = New System.Drawing.Point(94, 117)
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(330, 19)
        Me.txtCaption.TabIndex = 1
        '
        'cmbButtons
        '
        Me.cmbButtons.FormattingEnabled = True
        Me.cmbButtons.Location = New System.Drawing.Point(94, 142)
        Me.cmbButtons.Name = "cmbButtons"
        Me.cmbButtons.Size = New System.Drawing.Size(330, 20)
        Me.cmbButtons.TabIndex = 2
        '
        'cmbIcon
        '
        Me.cmbIcon.FormattingEnabled = True
        Me.cmbIcon.Location = New System.Drawing.Point(94, 168)
        Me.cmbIcon.Name = "cmbIcon"
        Me.cmbIcon.Size = New System.Drawing.Size(330, 20)
        Me.cmbIcon.TabIndex = 3
        '
        'cmbDefaultButton
        '
        Me.cmbDefaultButton.FormattingEnabled = True
        Me.cmbDefaultButton.Location = New System.Drawing.Point(94, 194)
        Me.cmbDefaultButton.Name = "cmbDefaultButton"
        Me.cmbDefaultButton.Size = New System.Drawing.Size(330, 20)
        Me.cmbDefaultButton.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Text"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Caption"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Buttons"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Icon"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "DefaultButton"
        '
        'btnShowDialog
        '
        Me.btnShowDialog.AutoSize = True
        Me.btnShowDialog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnShowDialog.Location = New System.Drawing.Point(188, 220)
        Me.btnShowDialog.Name = "btnShowDialog"
        Me.btnShowDialog.Size = New System.Drawing.Size(74, 22)
        Me.btnShowDialog.TabIndex = 10
        Me.btnShowDialog.Text = "ShowDialog"
        Me.btnShowDialog.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(324, 223)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.Size = New System.Drawing.Size(100, 19)
        Me.txtResult.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(268, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Result→"
        '
        'btnException
        '
        Me.btnException.AutoSize = True
        Me.btnException.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnException.Location = New System.Drawing.Point(188, 248)
        Me.btnException.Name = "btnException"
        Me.btnException.Size = New System.Drawing.Size(132, 22)
        Me.btnException.TabIndex = 13
        Me.btnException.Text = "ShowDialog(Exception)"
        Me.btnException.UseVisualStyleBackColor = True
        '
        'MessageDialogTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 282)
        Me.Controls.Add(Me.btnException)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.btnShowDialog)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbDefaultButton)
        Me.Controls.Add(Me.cmbIcon)
        Me.Controls.Add(Me.cmbButtons)
        Me.Controls.Add(Me.txtCaption)
        Me.Controls.Add(Me.txtText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "MessageDialogTest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents txtCaption As System.Windows.Forms.TextBox
    Friend WithEvents cmbButtons As System.Windows.Forms.ComboBox
    Friend WithEvents cmbIcon As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDefaultButton As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnShowDialog As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnException As System.Windows.Forms.Button

End Class

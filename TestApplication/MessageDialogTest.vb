Public Class MessageDialogTest

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        EnumToComboBox(GetType(System.Windows.Forms.MessageBoxButtons), Me.cmbButtons)
        EnumToComboBox(GetType(System.Windows.Forms.MessageBoxIcon), Me.cmbIcon)
        EnumToComboBox(GetType(System.Windows.Forms.MessageBoxDefaultButton), Me.cmbDefaultButton)
    End Sub

    Private Sub EnumToComboBox(ByVal enumType As Type, ByRef cmb As ComboBox)
        Dim defineTable As DataTable = New DataTable()
        defineTable.Columns.Add("display", GetType(String))
        defineTable.Columns.Add("value", enumType)

        For Each enumName As String In [Enum].GetNames(enumType)
            Dim row As DataRow = defineTable.NewRow()
            row("display") = enumName
            row("value") = [Enum].Parse(enumType, enumName)
            defineTable.Rows.Add(row)
        Next
        defineTable.AcceptChanges()

        cmb.DataSource = defineTable
        cmb.DisplayMember = "display"
        cmb.ValueMember = "value"
        cmb.DropDownStyle = ComboBoxStyle.DropDownList  'ユーザーのテキスト編集を許可しない
    End Sub

    Private Sub btnShowDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowDialog.Click
        Me.txtResult.Text = MessageDialog.MessageDialog.Show(Me, _
                                                             Me.txtText.Text, _
                                                             Me.txtCaption.Text, _
                                                             Me.cmbButtons.SelectedValue, _
                                                             Me.cmbIcon.SelectedValue, _
                                                             Me.cmbDefaultButton.SelectedValue).ToString()
    End Sub

    Private Sub btnException_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnException.Click
        Try
            Throw New Exception(Me.txtText.Text)
        Catch ex As Exception
            Me.txtResult.Text = MessageDialog.MessageDialog.Show(Me, _
                                                                 ex, _
                                                                 Me.txtCaption.Text, _
                                                                 Me.cmbButtons.SelectedValue, _
                                                                 Me.cmbIcon.SelectedValue, _
                                                                 Me.cmbDefaultButton.SelectedValue).ToString()
        End Try
    End Sub
End Class

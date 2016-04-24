''' <summary>
''' System.Windows.Forms.MessageBoxを置き換えるメッセージダイアログです。
''' メッセージ部のコピーが可能です。
''' また、Exeptionを渡すと、JITのエラーダイアログのようなダイアログを表示します。
''' </summary>
''' <remarks>
''' </remarks>
Public Class MessageDialog

    Private Const BUTTONS_MARGIN As Integer = 12
    Private Const BUTTONS_INTERVAL As Integer = 6
    Private Const BUTTON_HEIGHT As Integer = 23
    Private Const BUTTON_WIDTH As Integer = 75
    Private _Buttons As List(Of System.Windows.Forms.Button)

#Region " コンストラクタ "
    ''' <summary>
    ''' MessageDialog クラスの新しいインスタンスを初期化します。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        _Buttons = New List(Of System.Windows.Forms.Button)
        _DetailCollapsed = False
        _ShowDetail = True
    End Sub
#End Region

#Region " プロパティ "
    Private Shared _MyInstance As New MessageDialog
    ''' <summary>
    ''' このクラスのシングルトンインスタンスを返します。
    ''' </summary>
    ''' <returns>MessageDialog のインスタンス</returns>
    ''' <remarks></remarks>
    Private Shared ReadOnly Property MyInstance() As MessageDialog
        Get
            Return _MyInstance
        End Get
    End Property

    Private _DetailCollapsed As Boolean
    ''' <summary>
    ''' 詳細部を縮小または展開するかどうかを決定する値を取得または設定します。
    ''' </summary>
    ''' <value>縮小時はTrue、展開時はFalse</value>
    ''' <returns>縮小時はTrue、展開時はFalse</returns>
    ''' <remarks></remarks>
    Private Property DetailCollapsed As Boolean
        Get
            Return _DetailCollapsed
        End Get
        Set(ByVal value As Boolean)
            DetailCollapse(value)
            _DetailCollapsed = value
        End Set
    End Property

    Private _ShowDetail As Boolean
    ''' <summary>
    ''' 詳細部を表示するかどうかを決定する値を取得または設定します。
    ''' </summary>
    ''' <value>表示する場合はTrue、非表示はFalse</value>
    ''' <returns>表示する場合はTrue、非表示はFalse</returns>
    ''' <remarks></remarks>
    Private Property ShowDetail As Boolean
        Get
            Return _ShowDetail
        End Get
        Set(ByVal value As Boolean)
            DetailCollapsed = True
            Me.lblExpand.Visible = value
            _ShowDetail = value
        End Set
    End Property
#End Region

#Region " インスタンスメソッド "
    ''' <summary>
    ''' MessageDialog をクリアします。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Clear()
        Me.txtMessage.Clear()
        Me.Text = String.Empty
        Me.AcceptButton = Nothing
        For Each btn As System.Windows.Forms.Button In _Buttons
            If (Me.MainContainer.Panel1.Controls.Contains(btn)) Then
                Me.MainContainer.Panel1.Controls.Remove(btn)
            End If
        Next
        _Buttons.Clear()
        Me.SetIcon(Windows.Forms.MessageBoxIcon.None)
        Me.DetailCollapsed = True
        Me.ShowDetail = False
    End Sub

    ''' <summary>
    ''' 詳細部を縮小または展開します。
    ''' </summary>
    ''' <param name="collapse">縮小時はTrue、展開時はFalse</param>
    ''' <remarks></remarks>
    Private Sub DetailCollapse(ByVal collapse As Boolean)
        If (collapse = True AndAlso Me.MainContainer.Panel2Collapsed = False) Then
            ' Collapse
            Me.lblExpand.Text = "▼"
            Me.Height -= (Me.MainContainer.Height - Me.MainContainer.Panel1.Height)
            Me.MainContainer.Panel2Collapsed = True
            Me.MainContainer.IsSplitterFixed = True

        ElseIf (collapse = False AndAlso Me.MainContainer.Panel2Collapsed = True) Then
            ' Expand
            Me.lblExpand.Text = "▲"
            Dim i As Integer = Me.MainContainer.Panel1.Height
            Me.MainContainer.Panel2Collapsed = False
            Me.Height += CInt((Me.MainContainer.Panel2.Height + Me.MainContainer.SplitterWidth) * i / Me.MainContainer.Panel1.Height)
            Me.MainContainer.IsSplitterFixed = False

        End If
    End Sub

    ''' <summary>
    ''' MessageDialogにボタンを設定します。
    ''' </summary>
    ''' <param name="buttons">表示するボタンを定義する定数を指定します。</param>
    ''' <remarks></remarks>
    Private Sub SetButtons(ByVal buttons As System.Windows.Forms.MessageBoxButtons)
        Select Case buttons
            Case Windows.Forms.MessageBoxButtons.AbortRetryIgnore
                AddButton(System.Windows.Forms.DialogResult.Abort)
                AddButton(System.Windows.Forms.DialogResult.Retry)
                AddButton(System.Windows.Forms.DialogResult.Ignore)

            Case Windows.Forms.MessageBoxButtons.OK
                AddButton(System.Windows.Forms.DialogResult.OK)

            Case Windows.Forms.MessageBoxButtons.OKCancel
                AddButton(System.Windows.Forms.DialogResult.OK)
                AddButton(System.Windows.Forms.DialogResult.Cancel)

            Case Windows.Forms.MessageBoxButtons.RetryCancel
                AddButton(System.Windows.Forms.DialogResult.Retry)
                AddButton(System.Windows.Forms.DialogResult.Cancel)

            Case Windows.Forms.MessageBoxButtons.YesNo
                AddButton(System.Windows.Forms.DialogResult.Yes)
                AddButton(System.Windows.Forms.DialogResult.No)

            Case Windows.Forms.MessageBoxButtons.YesNoCancel
                AddButton(System.Windows.Forms.DialogResult.Yes)
                AddButton(System.Windows.Forms.DialogResult.No)
                AddButton(System.Windows.Forms.DialogResult.Cancel)

            Case Else
                ' なにもしない

        End Select

    End Sub

    ''' <summary>
    ''' MessageDialogにボタンを追加します。
    ''' 既存のボタンがある場合は、左側にシフトします。
    ''' 新しいボタンは常に画面の一番右に追加されます。
    ''' </summary>
    ''' <param name="dialogResult">
    ''' 追加するボタンに設定する System.Windows.Forms.DialogResult 値のいずれか。
    ''' </param>
    ''' <remarks>
    ''' 引数:<paramref name="dialogResult">dialogResult</paramref>によってボタンの表示文字列が自動設定されます。
    ''' </remarks>
    Private Sub AddButton(ByVal dialogResult As System.Windows.Forms.DialogResult)
        Dim button As New System.Windows.Forms.Button()
        button.Size = New System.Drawing.Size(BUTTON_WIDTH, BUTTON_HEIGHT)
        button.Location = New System.Drawing.Point(Me.ButtonPanel.Size.Width - BUTTON_WIDTH - BUTTONS_MARGIN, 0)
        button.Anchor = Windows.Forms.AnchorStyles.Bottom Or Windows.Forms.AnchorStyles.Right

        ' 既存のボタンを移動
        For Each btn As System.Windows.Forms.Button In _Buttons
            btn.Location = New System.Drawing.Point(btn.Location.X - BUTTON_WIDTH - BUTTONS_INTERVAL, btn.Location.Y)
        Next

        Select Case dialogResult
            Case Windows.Forms.DialogResult.OK
                button.Text = "OK"

            Case Windows.Forms.DialogResult.Cancel
                button.Text = "キャンセル"

            Case Windows.Forms.DialogResult.Abort
                button.Text = "中止"

            Case Windows.Forms.DialogResult.Retry
                button.Text = "再試行"

            Case Windows.Forms.DialogResult.Ignore
                button.Text = "無視"

            Case Windows.Forms.DialogResult.Yes
                button.Text = "はい"

            Case Windows.Forms.DialogResult.No
                button.Text = "いいえ"

            Case Else
                Return
        End Select

        button.DialogResult = dialogResult
        _Buttons.Add(button)
        Me.ButtonPanel.Controls.Add(button)
        button.BringToFront()
    End Sub

    ''' <summary>
    ''' MessageDialogの既定のボタンを設定します。
    ''' </summary>
    ''' <param name="defaultButton">表示する既定のボタンを定義する定数を指定します。</param>
    ''' <remarks></remarks>
    Private Sub SetDefaultButton(ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton)
        Me.AcceptButton = Nothing

        Dim max As Integer = 0
        Select Case defaultButton
            Case Windows.Forms.MessageBoxDefaultButton.Button1
                max = 0
            Case Windows.Forms.MessageBoxDefaultButton.Button2
                max = 1
            Case Windows.Forms.MessageBoxDefaultButton.Button3
                max = 2
            Case Else
                Return
        End Select
        If (max >= _Buttons.Count) Then max = _Buttons.Count - 1

        For i As Integer = max To 0 Step -1
            If (_Buttons(i) IsNot Nothing) Then
                Me.AcceptButton = _Buttons(i)
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' MessageDialogにアイコンを設定します。
    ''' </summary>
    ''' <param name="icon">表示する情報を定義する定数を指定します。</param>
    ''' <remarks></remarks>
    Private Sub SetIcon(ByVal icon As System.Windows.Forms.MessageBoxIcon)
        Dim bmp As New System.Drawing.Bitmap(pbIcon.Width, pbIcon.Height)
        Using g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmp)
            Select Case icon
                Case Windows.Forms.MessageBoxIcon.Asterisk
                    g.DrawIcon(System.Drawing.SystemIcons.Asterisk, 0, 0)

                Case Windows.Forms.MessageBoxIcon.Error
                    g.DrawIcon(System.Drawing.SystemIcons.Error, 0, 0)

                Case Windows.Forms.MessageBoxIcon.Exclamation
                    g.DrawIcon(System.Drawing.SystemIcons.Exclamation, 0, 0)

                Case Windows.Forms.MessageBoxIcon.Hand
                    g.DrawIcon(System.Drawing.SystemIcons.Hand, 0, 0)

                Case Windows.Forms.MessageBoxIcon.Information
                    g.DrawIcon(System.Drawing.SystemIcons.Information, 0, 0)

                Case Windows.Forms.MessageBoxIcon.None
                    g.Clear(pbIcon.BackColor)

                Case Windows.Forms.MessageBoxIcon.Question
                    g.DrawIcon(System.Drawing.SystemIcons.Question, 0, 0)

                Case Windows.Forms.MessageBoxIcon.Stop
                    g.DrawIcon(System.Drawing.SystemIcons.Shield, 0, 0)

                Case Windows.Forms.MessageBoxIcon.Warning
                    g.DrawIcon(System.Drawing.SystemIcons.Warning, 0, 0)

                Case Else
                    g.Clear(pbIcon.BackColor)

            End Select
        End Using

        Me.pbIcon.Image = bmp
    End Sub
#End Region

#Region " イベントハンドラ "
    Private Sub lblExpand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExpand.Click
        Me.DetailCollapsed = Not Me.DetailCollapsed
    End Sub

    Private Sub lblExpand_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExpand.MouseHover
        lblExpand.ForeColor = System.Drawing.SystemColors.GrayText
    End Sub

    Private Sub lblExpand_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExpand.MouseLeave
        lblExpand.ForeColor = System.Drawing.SystemColors.ControlText
    End Sub
#End Region

#Region " Show "

#Region " Text "
    ''' <summary>
    ''' 指定したオブジェクトの前に、指定したテキストを表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="text">メッセージ ボックスに表示するテキスト。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal text As String) As System.Windows.Forms.DialogResult
        Return Show(owner, text, String.Empty)
    End Function

    ''' <summary>
    ''' 指定したオブジェクトの前に、指定したテキストを表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="text">メッセージ ボックスに表示するテキスト。</param>
    ''' <param name="caption">メッセージ ボックスのタイトル バーに表示するテキスト。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal text As String, ByVal caption As String) As System.Windows.Forms.DialogResult
        Return Show(owner, text, caption, System.Windows.Forms.MessageBoxButtons.OK)
    End Function

    ''' <summary>
    ''' 指定したオブジェクトの前に、指定したテキストを表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="text">メッセージ ボックスに表示するテキスト。</param>
    ''' <param name="caption">メッセージ ボックスのタイトル バーに表示するテキスト。</param>
    ''' <param name="buttons">メッセージ ボックスに表示されるボタンを指定する System.Windows.Forms.MessageBoxButtons 値の 1 つ。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As System.Windows.Forms.MessageBoxButtons) As System.Windows.Forms.DialogResult
        Return Show(owner, text, caption, buttons, System.Windows.Forms.MessageBoxIcon.None)
    End Function

    ''' <summary>
    ''' 指定したオブジェクトの前に、指定したテキストを表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="text">メッセージ ボックスに表示するテキスト。</param>
    ''' <param name="caption">メッセージ ボックスのタイトル バーに表示するテキスト。</param>
    ''' <param name="buttons">メッセージ ボックスに表示されるボタンを指定する System.Windows.Forms.MessageBoxButtons 値の 1 つ。</param>
    ''' <param name="icon">メッセージ ボックスに表示されるアイコンを指定する System.Windows.Forms.MessageBoxIcon 値の 1 つ。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As System.Windows.Forms.MessageBoxButtons, ByVal icon As System.Windows.Forms.MessageBoxIcon) As System.Windows.Forms.DialogResult
        Return Show(owner, text, caption, buttons, icon, Windows.Forms.MessageBoxDefaultButton.Button1)
    End Function

    ''' <summary>
    ''' 指定したオブジェクトの前に、指定したテキストを表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="text">メッセージ ボックスに表示するテキスト。</param>
    ''' <param name="caption">メッセージ ボックスのタイトル バーに表示するテキスト。</param>
    ''' <param name="buttons">メッセージ ボックスに表示されるボタンを指定する System.Windows.Forms.MessageBoxButtons 値の 1 つ。</param>
    ''' <param name="icon">メッセージ ボックスに表示されるアイコンを指定する System.Windows.Forms.MessageBoxIcon 値の 1 つ。</param>
    ''' <param name="defaultButton">メッセージ ボックスの既定のボタンを指定する System.Windows.Forms.MessageBoxDefaultButton 値の 1 つ。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As System.Windows.Forms.MessageBoxButtons, ByVal icon As System.Windows.Forms.MessageBoxIcon, ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        With MyInstance
            .Clear()
            .txtMessage.Text = text
            .Text = caption
            .SetButtons(buttons)
            .SetIcon(icon)
            .SetDefaultButton(defaultButton)

            If (.AcceptButton IsNot Nothing) Then
                DirectCast(.AcceptButton, System.Windows.Forms.Button).Select()
                DirectCast(.AcceptButton, System.Windows.Forms.Button).Focus()
            End If
        End With

        Return MyInstance.ShowDialog(owner)
    End Function
#End Region

#Region " Exception "
    ''' <summary>
    ''' 指定したオブジェクトの前に、指定した例外情報を表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="ex">メッセージ ボックスに表示する例外情報。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal ex As Exception) As System.Windows.Forms.DialogResult
        Return Show(owner, ex, String.Empty)
    End Function

    ''' <summary>
    ''' 指定したオブジェクトの前に、指定した例外情報を表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="ex">メッセージ ボックスに表示する例外情報。</param>
    ''' <param name="caption">メッセージ ボックスのタイトル バーに表示するテキスト。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal ex As Exception, ByVal caption As String) As System.Windows.Forms.DialogResult
        Return Show(owner, ex, caption, System.Windows.Forms.MessageBoxButtons.OK)
    End Function

    ''' <summary>
    ''' 指定したオブジェクトの前に、指定した例外情報を表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="ex">メッセージ ボックスに表示する例外情報。</param>
    ''' <param name="caption">メッセージ ボックスのタイトル バーに表示するテキスト。</param>
    ''' <param name="buttons">メッセージ ボックスに表示されるボタンを指定する System.Windows.Forms.MessageBoxButtons 値の 1 つ。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal ex As Exception, ByVal caption As String, ByVal buttons As System.Windows.Forms.MessageBoxButtons) As System.Windows.Forms.DialogResult
        Return Show(owner, ex, caption, buttons, System.Windows.Forms.MessageBoxIcon.None)
    End Function

    ''' <summary>
    ''' 指定したオブジェクトの前に、指定した例外情報を表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="ex">メッセージ ボックスに表示する例外情報。</param>
    ''' <param name="caption">メッセージ ボックスのタイトル バーに表示するテキスト。</param>
    ''' <param name="buttons">メッセージ ボックスに表示されるボタンを指定する System.Windows.Forms.MessageBoxButtons 値の 1 つ。</param>
    ''' <param name="icon">メッセージ ボックスに表示されるアイコンを指定する System.Windows.Forms.MessageBoxIcon 値の 1 つ。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal ex As Exception, ByVal caption As String, ByVal buttons As System.Windows.Forms.MessageBoxButtons, ByVal icon As System.Windows.Forms.MessageBoxIcon) As System.Windows.Forms.DialogResult
        Return Show(owner, ex, caption, buttons, icon, Windows.Forms.MessageBoxDefaultButton.Button1)
    End Function

    ''' <summary>
    ''' 指定したオブジェクトの前に、指定した例外情報を表示するメッセージ ボックスを表示します。
    ''' </summary>
    ''' <param name="owner">モーダル ダイアログ ボックスを所有する System.Windows.Forms.IWin32Window の実装。</param>
    ''' <param name="ex">メッセージ ボックスに表示する例外情報。</param>
    ''' <param name="caption">メッセージ ボックスのタイトル バーに表示するテキスト。</param>
    ''' <param name="buttons">メッセージ ボックスに表示されるボタンを指定する System.Windows.Forms.MessageBoxButtons 値の 1 つ。</param>
    ''' <param name="icon">メッセージ ボックスに表示されるアイコンを指定する System.Windows.Forms.MessageBoxIcon 値の 1 つ。</param>
    ''' <param name="defaultButton">メッセージ ボックスの既定のボタンを指定する System.Windows.Forms.MessageBoxDefaultButton 値の 1 つ。</param>
    ''' <returns>System.Windows.Forms.DialogResult 値のいずれか。</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show(ByVal owner As System.Windows.Forms.IWin32Window, ByVal ex As Exception, ByVal caption As String, ByVal buttons As System.Windows.Forms.MessageBoxButtons, ByVal icon As System.Windows.Forms.MessageBoxIcon, ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        With MyInstance
            .Clear()
            .txtMessage.Text = ex.Message
            .txtDetail.Text = ex.StackTrace
            .Text = caption
            .SetButtons(buttons)
            .SetIcon(icon)
            .SetDefaultButton(defaultButton)

            If (.AcceptButton IsNot Nothing) Then
                DirectCast(.AcceptButton, System.Windows.Forms.Button).Select()
                DirectCast(.AcceptButton, System.Windows.Forms.Button).Focus()
            End If
            .ShowDetail = True
            .DetailCollapsed = True
        End With

        Return MyInstance.ShowDialog(owner)
    End Function
#End Region

#End Region

End Class
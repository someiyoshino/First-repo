''' <summary>
''' サービスの状態を確認
''' http://codezine.jp/article/detail/157
''' 
''' </summary>
''' <remarks></remarks>
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Clist As New ArrayList() 'コレクションArrayListを宣言 '配列でもOKかな

        Dim Svcs() As ServiceProcess.ServiceController 'WindowsService取得用
        Svcs = ServiceProcess.ServiceController.GetServices '返値はServiceController型の配列です。

        'ServiceController→String
        For Each Svc As ServiceProcess.ServiceController In Svcs '配列を1つずつ処理します。1つずつやるしかないようです。
            cboSelSvc.Items.Add(Svc.DisplayName) 'DisplayNameはString
            Clist.Add(Svc.DisplayName)
        Next

        'cboSelSvc.Items.AddRange(Svcs.ToArray) '←このやり方はNGでした。
        'cboSelSvc.Text = cboSelSvc.Items.Item(0)←これもNGになります。結果StringでないよとNGになります。

        Clist.Sort() '整列

        ComboBox1.Items.AddRange(Clist.ToArray) 'コンボボックスに追加

        '基本の機能で目的は達成するがこちらも頑張ってみよう →OK
        'For Each cs As String In Clist
        '    ComboBox1.Items.Add(cs)
        'Next

        cboSelSvc.Text = cboSelSvc.Items.Item(0) '最初の行を表示させておく
        'cboSelSvc.Text = "avast! Antivirus" '指名して表示させておくのもOK

        ComboBox1.Text = ComboBox1.Items.Item(0)

        Timer1.Start()
        GetStatus() '追加

    End Sub

    Private Sub GetStatus()
        Dim ServiceStat As New ServiceProcess.ServiceController
        ServiceStat.DisplayName = cboSelSvc.Text

        Try
            'Label1.Text = ServiceStat.Status 'これだと数値が表示されますが
            Label1.Text = ServiceStat.Status.ToString 'ToStringで意味のある文字列が表示されます。便利だね。

        Catch ex As Exception
            Label1.Text = "***"

        End Try

        Try
            Select Case ServiceStat.Status
                Case ServiceProcess.ServiceControllerStatus.ContinuePending
                    lblStats.Text = "再開中"
                Case ServiceProcess.ServiceControllerStatus.Paused
                    lblStats.Text = "一時停止中"
                Case ServiceProcess.ServiceControllerStatus.PausePending
                    lblStats.Text = "一時停止状態に移行中"
                Case ServiceProcess.ServiceControllerStatus.Running
                    lblStats.Text = "動作中"
                Case ServiceProcess.ServiceControllerStatus.StartPending
                    lblStats.Text = "開始中"
                Case ServiceProcess.ServiceControllerStatus.Stopped
                    lblStats.Text = "停止中"
                Case ServiceProcess.ServiceControllerStatus.StopPending
                    lblStats.Text = "停止状態に移行中"
            End Select
        Catch ex As Exception
            lblStats.Text = "サービス名エラーです"
        End Try
    End Sub

    ''' <summary>
    ''' Serviceの状態を返す
    ''' </summary>
    ''' <param name="Stext"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetStatus2(Stext As String)

        Dim ServiceStat As New ServiceProcess.ServiceController
        ServiceStat.DisplayName = Stext

        Try
            Select Case ServiceStat.Status
                Case ServiceProcess.ServiceControllerStatus.ContinuePending
                    lblStats.Text = "再開中"
                Case ServiceProcess.ServiceControllerStatus.Paused
                    lblStats.Text = "一時停止中"
                Case ServiceProcess.ServiceControllerStatus.PausePending
                    lblStats.Text = "一時停止状態に移行中"
                Case ServiceProcess.ServiceControllerStatus.Running
                    lblStats.Text = "動作中"
                Case ServiceProcess.ServiceControllerStatus.StartPending
                    lblStats.Text = "開始中"
                Case ServiceProcess.ServiceControllerStatus.Stopped
                    lblStats.Text = "停止中"
                Case ServiceProcess.ServiceControllerStatus.StopPending
                    lblStats.Text = "停止状態に移行中"
            End Select
        Catch ex As Exception
            lblStats.Text = "サービス名エラー"
        End Try


    End Function



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetStatus()
    End Sub

    Private Sub cboSelSvc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSelSvc.SelectedValueChanged
        GetStatus()
    End Sub
End Class

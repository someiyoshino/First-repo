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

        'サービスリストのリフレッシュの必要があるかもしれませんね。

        'ServiceController→String
        For Each Svc As ServiceProcess.ServiceController In Svcs '配列を1つずつ処理します。1つずつやるしかないようです。
            Clist.Add(Svc.DisplayName)
        Next

        'cboSelSvc.Items.AddRange(Svcs.ToArray) '←このやり方はNGでした。
        'cboSelSvc.Text = cboSelSvc.Items.Item(0)←これもNGになります。結果StringでないよとNGになります。

        Clist.Sort()
        cboSelSvc.Items.AddRange(Clist.ToArray) 'コンボボックスに追加

        '基本の機能で目的は達成するがこちらも頑張ってみよう →OK
        'For Each cs As String In Clist
        '    cboSelSvc.Items.Add(cs)
        'Next

        cboSelSvc.Text = cboSelSvc.Items.Item(0) '最初の行を表示させておく
        'cboSelSvc.Text = "avast! Antivirus" '指名して表示させておくのもOK

        Timer1.Start()
        GetStatus()

    End Sub

    ''' <summary>
    ''' コンボボックスの値をもとにラベルの値を変更する
    ''' この書き方は副作用なのかな？
    ''' </summary>
    Private Sub GetStatus()
        Dim ServiceStat As New ServiceProcess.ServiceController
        ServiceStat.DisplayName = cboSelSvc.Text

        Try
            Select Case ServiceStat.Status
                Case ServiceProcess.ServiceControllerStatus.ContinuePending
                    lblStats.Text = "再開中(" + ServiceStat.Status.ToString + ")"
                Case ServiceProcess.ServiceControllerStatus.Paused
                    lblStats.Text = "一時停止中(" + ServiceStat.Status.ToString + ")"
                Case ServiceProcess.ServiceControllerStatus.PausePending
                    lblStats.Text = "一時停止状態に移行中(" + ServiceStat.Status.ToString + ")"
                Case ServiceProcess.ServiceControllerStatus.Running
                    lblStats.Text = "動作中(" + ServiceStat.Status.ToString + ")"
                Case ServiceProcess.ServiceControllerStatus.StartPending
                    lblStats.Text = "開始中(" + ServiceStat.Status.ToString + ")"
                Case ServiceProcess.ServiceControllerStatus.Stopped
                    lblStats.Text = "停止中(" + ServiceStat.Status.ToString + ")"
                Case ServiceProcess.ServiceControllerStatus.StopPending
                    lblStats.Text = "停止状態に移行中(" + ServiceStat.Status.ToString + ")"
            End Select
        Catch ex As Exception
            lblStats.Text = "サービス名エラーです"
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetStatus()
    End Sub

    Private Sub cboSelSvc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSelSvc.SelectedValueChanged
        GetStatus()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Dim ServiceStat As New ServiceProcess.ServiceController

        Try
            ServiceStat.DisplayName = cboSelSvc.Text
            ServiceStat.Stop()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim ServiceStat As New ServiceProcess.ServiceController

        Try
            ServiceStat.DisplayName = cboSelSvc.Text
            ServiceStat.Start()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        Dim ServiceStat As New ServiceProcess.ServiceController

        Try
            ServiceStat.DisplayName = cboSelSvc.Text
            ServiceStat.Continue()
        Catch ex As Exception

        End Try

    End Sub
End Class

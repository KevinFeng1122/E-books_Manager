Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class Change_Class_Batch

    Dim form2_View_information As New frmView_Information(Nothing, Nothing)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        '
        If lbl_Class1.Text.Contains("'") Then
            lbl_Class1.Text = lbl_Class1.Text.Replace("'", "’")
            MsgBox("输入的内容不可含有英文单引号（'），否则将引发错误，软件已经自动用中文引号（’）进行替换")
        End If
        If lbl_Class2.Text.Contains("'") Then
            lbl_Class2.Text = lbl_Class2.Text.Replace("'", "’")
            MsgBox("输入的内容不可含有英文单引号（'），否则将引发错误，软件已经自动用中文引号（’）进行替换")
        End If
        '
        Dim myListviewItem As ListViewItem
        For Each myListviewItem In form2_View_information.ListView_Checked_Items
            Dim myConnection As New OleDbConnection
            myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"
            Dim Sql_update As String = "Update 总目录 Set  分类一 = '" & lbl_Class1.Text & _
            "', 分类二 = '" & lbl_Class2.Text & "' Where 存储路径 = '" & myListviewItem.SubItems(4).Text & "'"
            Dim myCommand As New OleDbCommand
            myCommand.CommandText = Sql_update
            myConnection.Open()
            myCommand.Connection = myConnection
            myCommand.ExecuteNonQuery()
            myConnection.Close()
        Next
        '
        form2_View_information.Form4_Back_ReShow_Listview()
        '
        Me.Close() '该语句必须放在最后，否则会有变量的值为空！！
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByRef pForm As Form)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        form2_View_information = pForm
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Change_class1.Click
        Dim form_Change_Class1_Batch As New Change_Class1_Batch(Me)
        form_Change_Class1_Batch.Show()
    End Sub

    Friend Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Change_class2.Click
        Dim form_Change_Class2_Batch As New Change_Class2_Batch(Me)
        form_Change_Class2_Batch.Show()
    End Sub

End Class

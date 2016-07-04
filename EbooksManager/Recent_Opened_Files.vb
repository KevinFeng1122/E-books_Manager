Imports System.Data.OleDb
Public Class class_form_Recent_Opened_Files
    Dim form_Start_Window As frmStart_Window

    Private Sub Recent_Opened_Files_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mySql As String
        mySql = "Select 总目录.书名,总目录.作者," _
        & "最近打开文档.打开时间,最近打开文档.存储路径 from 最近打开文档, 总目录 where " & _
         "最近打开文档.存储路径 = 总目录.存储路径 Order by 最近打开文档.打开时间 Desc"

        Dim myConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"

        '根据要求得到DataTable
        Dim Data_Adapter As New OleDbDataAdapter(mySql, myConnectionString)
        Dim Data_Set As New DataSet()
        Dim Data_Table As DataTable
        Data_Adapter.Fill(Data_Set, "Data")
        Data_Table = Data_Set.Tables("Data")

        '将DataTable的内容填入listview中
        Dim i As Short
        Dim j As Short
        For i = 0 To Data_Table.Rows.Count - 1
            ListView1.Items.Add(Data_Table.Rows(i).Item(0))
            For j = 1 To Data_Table.Columns.Count - 1
                ListView1.Items(i).SubItems.Add(Data_Table.Rows(i).Item(j))
            Next
        Next
    End Sub

    Public Sub New(ByVal pForm As frmStart_Window)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        form_Start_Window = pForm
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(MousePosition)
        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        打开ToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub 打开ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 打开ToolStripMenuItem.Click
        '打开
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = ListView1.SelectedItems(0).SubItems(3).Text
        myProcess.StartInfo.Verb = "open"
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.Start()

        '修改“最近打开文档”的记录
        '(0)查找是否已经有该书，如有则只更新时间信息，不再新添加一条
        Dim BookPath_now As String = ListView1.SelectedItems(0).SubItems(3).Text
        Dim str_Sql0 As String
        str_Sql0 = "SELECT Count(*) FROM 最近打开文档 where 存储路径 = '" & BookPath_now & "'"
        Using myConnection0 As New OleDbConnection
            myConnection0.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"
            Dim myCommand0 As New OleDbCommand
            myCommand0.CommandText = str_Sql0
            myConnection0.Open()
            myCommand0.Connection = myConnection0
            Dim number0 As Short = myCommand0.ExecuteScalar
            If number0 <> 0 Then
                Dim myConnection_0 As New OleDbConnection
                myConnection_0.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                My.Application.Info.DirectoryPath & "\BookInformation.mdb"
                Dim Sql_update As String = "Update 最近打开文档 Set 打开时间 = #" & Date.Now & "# Where 存储路径 = '" & BookPath_now & "'"
                Dim myCommand_0 As New OleDbCommand
                myCommand_0.CommandText = Sql_update
                myConnection_0.Open()
                myCommand_0.Connection = myConnection_0
                myCommand_0.ExecuteNonQuery()
                myConnection_0.Close()
                Exit Sub
            End If
        End Using

        '(1)获得记录总数
        Dim str_Sql As String
        str_Sql = "SELECT COUNT(*) FROM 最近打开文档"
        Dim myConnection As New OleDbConnection
        myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
        My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim myCommand As New OleDbCommand
        myCommand.CommandText = str_Sql
        myConnection.Open()
        myCommand.Connection = myConnection
        Dim number As Short = myCommand.ExecuteScalar
        myConnection.Close()
        ' 
        If number = 10 Then
            '获取第一个记录（升序排列时，它是最早打开的）的存储路径字段
            Dim str_Sql2 As String
            str_Sql2 = "SELECT * FROM 最近打开文档 Order by 打开时间 Asc"
            Dim myConnection2 As New OleDbConnection
            myConnection2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"
            Dim myCommand2 As New OleDbCommand
            myCommand2.CommandText = str_Sql2
            myConnection2.Open()
            myCommand2.Connection = myConnection2
            Dim dataReader2 As OleDbDataReader = myCommand2.ExecuteReader
            Dim BookPath As String = ""
            If dataReader2.Read Then
                BookPath = dataReader2.Item("存储路径")
            End If
            myConnection2.Close()
            '删掉第一个记录
            str_Sql2 = "delete from 最近打开文档 where 存储路径 = '" & BookPath & "'"
            myCommand2.CommandText = str_Sql2
            myConnection2.Open()
            myCommand2.Connection = myConnection2
            myCommand2.ExecuteNonQuery()
            myConnection2.Close()
            '添加一个记录
            BookPath = ListView1.SelectedItems(0).SubItems(3).Text
            str_Sql2 = "Insert Into 最近打开文档(存储路径,打开时间) Values('" & BookPath & "',#" _
            & Date.Now & "#)"
            myCommand2.CommandText = str_Sql2
            myConnection2.Open()
            myCommand2.Connection = myConnection2
            myCommand2.ExecuteNonQuery()
            myConnection2.Close()
        Else
            '总数<10,则仅添加一个记录
            Dim BookPath As String = ListView1.SelectedItems(0).SubItems(3).Text
            Dim str_Sql2 As String = "Insert Into 最近打开文档(存储路径,打开时间) Values('" & _
            BookPath & "',#" & Date.Now & "#)"
            Dim myConnection2 As New OleDbConnection
            myConnection2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"
            Dim myCommand2 As New OleDbCommand
            myCommand2.CommandText = str_Sql2
            myConnection2.Open()
            myCommand2.Connection = myConnection2
            myCommand2.ExecuteNonQuery()
            myConnection2.Close()
        End If
    End Sub

    Private Sub 在信息浏览窗口中查看ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 在信息浏览窗口中查看ToolStripMenuItem.Click
        Dim form_View_Information As New frmView_Information(Me, 1)
        With form_View_Information
            .Show()
            .TreeView1.Enabled = False
            .ToolStripTextBox1.Text = ListView1.SelectedItems(0).Text
            .ToolStripButton1.Text = "返回自定义书单窗口"
            .ToolStripLabel1.Width = 130
            .ToolStripSplitButton2_Click(Nothing, Nothing)
            .ToolStripTextBox1.Enabled = False
            .ToolStripSplitButton2.Enabled = False
        End With
        Me.Hide()
    End Sub

    Private Sub class_form_Recent_Opened_Files_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        form_Start_Window.Show()
    End Sub
End Class
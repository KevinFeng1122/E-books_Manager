Imports System.Data.OleDb
Public Class class_form_add_into_booklist_batch
    Dim form_View_Information As New frmView_Information(Nothing, Nothing)

    Private Sub class_form_add_into_booklist_batch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim mySchemaTable As New DataTable
        mySchemaTable = GetSchemaTable(myConnectionString)
        Dim i As Short
        Dim BookListName As String
        For i = 0 To mySchemaTable.Rows.Count - 1
            BookListName = mySchemaTable.Rows(i).Item(2) '只有item参数给2的时候才出现表名！！
            ListBox1.Items.Add(BookListName)
        Next
        Dim index As Short = ListBox1.FindStringExact("总目录")
        ListBox1.Items.RemoveAt(index)
        Dim index2 As Short = ListBox1.FindStringExact("最近打开文档")
        ListBox1.Items.RemoveAt(index2)
    End Sub

    Public Sub New(ByVal pForm As Form)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        form_View_Information = pForm
    End Sub

    Private Sub btn_New_booklist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_New_booklist.Click
        Dim str_New_Booklist_Name As String
        str_New_Booklist_Name = InputBox("请输入新建的书单名称")
        If str_New_Booklist_Name = "" Then
            Exit Sub
        ElseIf ListBox1.Items.Contains(str_New_Booklist_Name) Or str_New_Booklist_Name = "总目录" Or str_New_Booklist_Name = "最近打开文档" Then
            MsgBox("名称不可为总目录或最近打开文档，也不可与已有名称重复。")
            btn_New_booklist_Click(Nothing, Nothing)
        ElseIf CheckSpecialChar(str_New_Booklist_Name) = False Then
            MsgBox("输入的内容不可含有英文字符和空格，且不可以数字开头。")
            btn_New_booklist_Click(Nothing, Nothing)
        Else
            '增加到Listbox中
            Dim index As Short
            ListBox1.Items.Add(str_New_Booklist_Name)
            index = ListBox1.FindStringExact(str_New_Booklist_Name)
            ListBox1.SelectedIndex = index
            '增加到数据库中
            Dim str_Sql As String
            str_Sql = "create table " & str_New_Booklist_Name & "(存储路径 varchar,说明 varchar)"
            Dim myConnection As New OleDbConnection
            myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"
            Dim myCommand As New OleDbCommand
            myCommand.CommandText = str_Sql
            myConnection.Open()
            myCommand.Connection = myConnection
            myCommand.ExecuteNonQuery()
            myConnection.Close()
        End If
    End Sub

    Private Sub btn_Cancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancle.Click
        Me.Close()
    End Sub

    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Dim myListViewItem As ListViewItem
        Dim myFilePath As String
        Dim myconnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        For Each myListViewItem In form_View_Information.ListView_Checked_Items

            '先判断文档是否已经在书单里了
            Dim Sql_1 As String
            myFilePath = myListViewItem.SubItems(4).Text
            Sql_1 = "Select * From " & ListBox1.Text & " Where 存储路径 = '" & myFilePath & "'"
            Dim Data_Adapter As New OleDbDataAdapter(Sql_1, myConnectionString)
            Dim Data_Set As New DataSet()
            Dim Data_Table As DataTable
            Data_Adapter.Fill(Data_Set, "Data")
            Data_Table = Data_Set.Tables("Data")

            '若不在书单里，则添加进去，否则不添加。
            If Data_Table.Rows.Count = 0 Then
                Dim Sql_2 As String
                Sql_2 = "Insert into " & ListBox1.Text & "(存储路径,说明) Values('" & myFilePath & "','')"
                Dim myConnection As New OleDbConnection
                myConnection.ConnectionString = myconnectionstring
                Dim myCommand As New OleDbCommand
                myCommand.CommandText = Sql_2
                myConnection.Open()
                myCommand.Connection = myConnection
                myCommand.ExecuteNonQuery()
                myConnection.Close()
            End If
        Next
        Me.Close()
    End Sub

End Class
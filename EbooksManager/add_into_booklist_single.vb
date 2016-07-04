Imports System.Data.OleDb
Public Class class_form_Add_into_booklist_single
    Dim form_View_Information As New frmView_Information(Nothing, Nothing)
    Dim str_File_Path As String

    Private Sub class_form_Add_into_booklist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        str_File_Path = form_View_Information.ListView_Items(form_View_Information.Listview_SelectedItem_Index).SubItems(4).Text
        Dim myConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim mySchemaTable As New DataTable
        mySchemaTable = GetSchemaTable(myConnectionString)
        Dim i As Short
        Dim BookListName As String
        For i = 0 To mySchemaTable.Rows.Count - 1
            BookListName = mySchemaTable.Rows(i).Item(2) '只有item参数给2的时候才出现表名！！
            If BookListName <> "最近打开文档" Then
                Dim Sql As String
                Sql = "Select * From " & BookListName & " Where 存储路径 = '" & str_File_Path & "'"
                Dim Data_Adapter As New OleDbDataAdapter(Sql, myConnectionString)
                Dim Data_Set As New DataSet()
                Dim Data_Table As DataTable
                Data_Adapter.Fill(Data_Set, "Data")
                Data_Table = Data_Set.Tables("Data")
                If Data_Table.Rows.Count = 0 Then
                    ListBox1.Items.Add(BookListName)
                End If
            End If
        Next
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
            '
            Dim index As Short
            ListBox1.Items.Add(str_New_Booklist_Name)
            index = ListBox1.FindStringExact(str_New_Booklist_Name)
            ListBox1.SelectedIndex = index
            '
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

    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Dim str_Sql As String
        str_Sql = "Insert into " & ListBox1.Text & "(存储路径,说明) Values('" & str_File_Path & "','')"
        Dim myConnection As New OleDbConnection
        myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
        My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim myCommand As New OleDbCommand
        myCommand.CommandText = str_Sql
        myConnection.Open()
        myCommand.Connection = myConnection
        myCommand.ExecuteNonQuery()
        myConnection.Close()
        '
        Me.Close()
    End Sub

    Private Sub btn_Cancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancle.Click
        Me.Close()
    End Sub

End Class
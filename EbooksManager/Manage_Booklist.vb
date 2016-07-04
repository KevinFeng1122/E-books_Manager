Imports System.Data.OleDb
Imports System.String
Imports Excel = Microsoft.Office.Interop.Excel

Public Class class_form_Manage_Booklist
    Dim form_Start_Window As frmStart_Window
    Dim bln_Rename As Boolean = False
    Dim myConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"

    Public Sub New(ByVal pForm As Form)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        form_Start_Window = pForm
    End Sub

    Private Sub class_form_Manage_Booklist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
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

    Public Sub btn_Show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Show.Click
        If ListBox1.Text = "" Then
            MsgBox("请先选择一个书单！")
            Exit Sub
        End If

        Dim mySql As String
        mySql = "select 总目录.书名,总目录.作者," & ListBox1.Text & ".说明," & ListBox1.Text & ".存储路径 from 总目录," & ListBox1.Text _
         & " where " & ListBox1.Text & ".存储路径=总目录.存储路径"

        Dim myConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"

        '清除先前的内容
        ListView1.Items.Clear()

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

    Private Sub btn_Add_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add_new.Click
        Dim str_New_Booklist_Name As String
        str_New_Booklist_Name = InputBox("请输入书单名称")
        If str_New_Booklist_Name = "" Then
            Exit Sub
        Else
            Dim firstLetter As Short = Asc(str_New_Booklist_Name.First)
            If ListBox1.Items.Contains(str_New_Booklist_Name) Or str_New_Booklist_Name = "总目录" Or str_New_Booklist_Name = "最近打开文档" Then
                MsgBox("名称不可为总目录或最近打开文档，也不可与已有名称重复。")
                btn_Add_new_Click(Nothing, Nothing)
            ElseIf CheckSpecialChar(str_New_Booklist_Name) = False Then
                MsgBox("输入的内容不可含有英文字符和空格，且不可以数字开头。")
                btn_Add_new_Click(Nothing, Nothing)
            Else
                If str_New_Booklist_Name.Contains("'") Then
                    str_New_Booklist_Name = str_New_Booklist_Name.Replace("'", "’")
                    MsgBox("输入的内容不可含有英文单引号（'），否则将引发错误，软件已经自动用中文引号（’）进行替换")
                End If
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
                '
                ListBox1.Text = str_New_Booklist_Name
            End If
        End If
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If ListBox1.Text = "" Then
            MsgBox("请先选择一个书单！")
            Exit Sub
        End If

        If bln_Rename = False Then
            If MsgBox("您确认删除" & ListBox1.Text & "吗？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        '
        Dim str_Sql As String
        str_Sql = "drop table " & ListBox1.Text
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
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        ListView1.Items.Clear()
    End Sub

    Private Sub btn_Rename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Rename.Click
        If ListBox1.Text = "" Then
            MsgBox("请先选择一个书单！")
            Exit Sub
        End If
        '先新建书单
        Dim OldName As String = ListBox1.Text
        btn_Add_new_Click(Nothing, Nothing)
        Dim NewName As String = ListBox1.Text
        '然后将旧书单内容复制到新书单
        Dim str_Sql As String
        str_Sql = "insert into " & NewName & " select * from " & OldName
        Dim myConnection As New OleDbConnection
        myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
        My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim myCommand As New OleDbCommand
        myCommand.CommandText = str_Sql
        myConnection.Open()
        myCommand.Connection = myConnection
        myCommand.ExecuteNonQuery()
        myConnection.Close()
        '最后删除旧书单，从而完成重命名
        bln_Rename = True
        ListBox1.Text = OldName
        btn_Delete_Click(Nothing, Nothing)
        ListBox1.Text = NewName
        bln_Rename = False

    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(MousePosition)
        End If
    End Sub

    Private Sub 在信息浏览窗口中查看ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 在信息浏览窗口中查看ToolStripMenuItem.Click
        Dim form_View_Information As New frmView_Information(Me, 2)
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

    Private Sub btn_To_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_To_Excel.Click
        btn_Show_Click(Nothing, Nothing)

        If ListView1.Items.Count = 0 Then
            MsgBox("未显示书单内容或书单为空！")
            Exit Sub
        End If

        With SaveFileDialog1
            .DefaultExt = "xlsx"
            .FileName = "【书单】" & ListBox1.Text
            .Filter = "Excel97-2003工作簿（*.xls）|*.xls|Excel2007工作簿（*.xlsx）|*.xlsx"
            .FilterIndex = 1
            .OverwritePrompt = True
            .Title = "请选择保存的位置"
        End With
        Dim ExcelName As String = ""
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            ExcelName = SaveFileDialog1.FileName
        Else
            Exit Sub
        End If

        '没有按下“取消”键的情况
        Dim vbExcel As Excel.Application
        vbExcel = CreateObject("Excel.Application")
        With vbExcel
            .Workbooks.Add()
            .Sheets.Add()
            '【标题】
            .ActiveSheet.Range("A1:C1").Merge(True) 'Cells(1, 1), Cells(1, 3)
            .Cells(1, 1) = "书单：" & ListBox1.Text
            .Cells(1, 1).Font.Size = 16
            .Cells(1, 1).HorizontalAlignment = HorizontalAlignment.Center
            '【项目名】
            .Cells(2, 1) = "书名"
            .Cells(2, 1).Font.Bold = True
            .Cells(2, 1).HorizontalAlignment = HorizontalAlignment.Center
            .Cells(2, 2) = "作者"
            .Cells(2, 2).Font.Bold = True
            .Cells(2, 2).HorizontalAlignment = HorizontalAlignment.Center
            .Cells(2, 3) = "说明"
            .Cells(2, 3).Font.Bold = True
            .Cells(2, 3).HorizontalAlignment = HorizontalAlignment.Center
            .ActiveSheet.Rows(2).RowHeight = 16
            '【内容】
            With ListView1
                Dim i As Integer '用于循环计数——行号
                For i = 1 To .Items.Count
                    vbExcel.Cells(i + 2, 1) = .Items(i - 1).Text
                    vbExcel.Cells(i + 2, 1).HorizontalAlignment = HorizontalAlignment.Center
                    vbExcel.Cells(i + 2, 2) = .Items(i - 1).SubItems(1).Text
                    vbExcel.Cells(i + 2, 2).HorizontalAlignment = HorizontalAlignment.Center
                    vbExcel.Cells(i + 2, 3) = .Items(i - 1).SubItems(2).Text
                    vbExcel.Cells(i + 2, 3).HorizontalAlignment = HorizontalAlignment.Center
                    vbExcel.ActiveSheet.Rows(i + 2).RowHeight = 16
                Next i
            End With
            .ActiveSheet.Columns(1).ColumnWidth = 35
            .ActiveSheet.Columns(2).ColumnWidth = 25
            .ActiveSheet.Columns(3).ColumnWidth = 60
            .Visible = True
            .Cells.HorizontalAlignment = HorizontalAlignment.Right
            .ActiveWorkbook.SaveAs(ExcelName)
        End With
    End Sub

    Private Sub open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles open.Click
        '打开文件（夹）↓ 
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = ListView1.SelectedItems(0).SubItems(3).Text
        myProcess.StartInfo.Verb = "open"
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.Start()

        '修改“最近打开文档”的记录↓
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

        '(1)获得记录总数↓
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

    Private Sub delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delete.Click
        Delete_File(ListView1.SelectedItems(0))
    End Sub

    Private Sub Delete_File(ByVal myListviewItem As ListViewItem)
        Dim SourcePath As String = myListviewItem.SubItems(3).Text

        '删除数据库记录
        Dim sqlstr_Delete_Path As String
        sqlstr_Delete_Path = "Delete From " & ListBox1.Text & " where 存储路径 = '" & SourcePath & "' "
        Dim oledcmmd As New OleDbCommand(sqlstr_Delete_Path)
        With oledcmmd
            .Connection = New OleDbConnection(myConnectionString)
            .Connection.Open()
            .ExecuteReader()
            .Connection.Close()
        End With

        '删除Listview中的项
        myListviewItem.Remove()
    End Sub

    Private Sub note_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles note.Click
        Dim OldNote As String = ""
        If ListView1.SelectedItems(0).SubItems(2).Text <> "" Then
            OldNote = ListView1.SelectedItems(0).SubItems(2).Text
        End If
        Dim note As String = InputBox("请输入说明", "修改说明", OldNote)

        If CheckSpecialChar_here(note) = False Then
            MsgBox("输入的内容不可含有英文字符和空格。")
            note_Click(Nothing, Nothing)
        Else
            '更改ListView内容↓
            ListView1.SelectedItems(0).SubItems(2).Text = note
            '修改数据库记录↓（此功能尚未调试成功！）
            Dim SourcePath As String = ListView1.SelectedItems(0).SubItems(3).Text
            Dim sql As String
            sql = "Update " & ListBox1.Text & " Set 说明 = '" & note & "' Where 存储路径 = '" & SourcePath & "'"
            Dim myConnection As New OleDbConnection
            myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"
            myConnection.Open()
            Dim myCommand As New OleDbCommand(sql, myConnection)
            Try
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
            myConnection.Close()
        End If
    End Sub

    Private Function CheckSpecialChar_here(ByVal inputString As String) As Boolean
        REM 功能：检测给定字符串是否含有非法字符,有则返回false
        REM 算法：依次获取inputString的每个字符，判断其ASCII码是否在合理范围内，
        REM 若有任意一个不在, 则结束函数, 返回false值
        Dim i As Short
        For i = 0 To inputString.Count - 1
            Dim ele As Char = inputString.ElementAt(i)
            Dim num As Short = Asc(ele)
            If Not (num < 0 Or (num >= 48 And num <= 57) Or (num >= 65 And num <= 90) Or (num >= 97 And num <= 122)) Then
                Return False
                Exit Function
            End If
        Next
        Return True
    End Function

    Private Sub btn_Files_Copyto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Files_Copyto.Click
        btn_Show_Click(Nothing, Nothing)
        If ListView1.Items.Count = 0 Then
            MsgBox("未显示书单内容或书单为空！")
            Exit Sub
        End If
        Dim listviewItem As ListViewItem
        FolderBrowserDialog1.Description = "请选择要输出到的文件夹"
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim DestinationFolder As String = FolderBrowserDialog1.SelectedPath
            For Each listviewItem In ListView1.Items
                File_Copy_to(listviewItem, DestinationFolder)
            Next
        End If
    End Sub

    Private Sub File_Copy_to(ByVal myListviewItem As ListViewItem, ByVal DestinationFolder As String)
        If Microsoft.VisualBasic.Right(DestinationFolder, 1) <> "\" Then
            DestinationFolder = DestinationFolder & "\"
        End If
        Dim DestinationPath As String
        Dim SourcePath As String = myListviewItem.SubItems(3).Text
        If System.IO.Path.HasExtension(SourcePath) Then
            DestinationPath = DestinationFolder & System.IO.Path.GetFileName(SourcePath)
            My.Computer.FileSystem.CopyFile(SourcePath, DestinationPath)
        Else
            DestinationPath = DestinationFolder & GetLastFolderName(SourcePath)
            My.Computer.FileSystem.CopyDirectory(SourcePath, DestinationPath)
        End If
    End Sub

    Private Function GetLastFolderName(ByVal path As String) As String
        Dim b As String = path.Remove(0, System.IO.Path.GetDirectoryName(path).Count)
        GetLastFolderName = b.Replace("\", "")
    End Function

    Private Sub btn_Go_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Go_back.Click
        Me.Close()
    End Sub

    Private Sub class_form_Manage_Booklist_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        form_Start_Window.Show()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        open_Click(Nothing, Nothing)
    End Sub

End Class
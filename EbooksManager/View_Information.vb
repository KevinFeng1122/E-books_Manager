Imports System.Data
Imports System.Data.OleDb
Imports System
Imports System.Diagnostics
Imports System.IO
Public Class frmView_Information
    Private frmPrevious_Form As Form

    '下面几个窗体变量的定义用于工具栏“返回上一级内容”按钮
    Dim blnClass As Boolean = False '按分类浏览时的特殊处理
    Dim strNode_Name As String
    Dim strUp1_Item_Name As String
    Dim shtUp1_Item_Index As Short
    Dim shtUp2_Item_Index As Short
    '
    Dim str_Form4_Back_SQL As String
    Dim str_Seleted_Listview_Item_FilePath As String

    Private enumListView1_what_to_show As ListView_what_to_show '用于listview1接收双击事件时判断执行哪个分支
    Private strConnection_String As String
    Private myOleDbConnection As New OleDbConnection()
    '
    Dim bln_Book_Finding As Boolean = False
    Dim str_Find_Item As String
    '
    Dim bln_Booklist_Manage As Boolean = False
    Dim form_Booklist_manage As class_form_Manage_Booklist

    Public Sub New(ByRef pForm As Form, ByVal Booklist As Short)
        MyBase.New()
        InitializeComponent()
        If Booklist = 2 Then '从自定义书单处过来
            frmPrevious_Form = CType(frmPrevious_Form, class_form_Manage_Booklist)
            bln_Booklist_Manage = True
            form_Booklist_manage = pForm
        ElseIf Booklist = 0 Then '从启动窗体处过来
            frmPrevious_Form = CType(frmPrevious_Form, frmStart_Window)
        ElseIf Booklist = 1 Then '从最近打开文档处过来
            frmPrevious_Form = CType(frmPrevious_Form, class_form_Recent_Opened_Files)
        End If
        frmPrevious_Form = pForm
    End Sub

    Private Enum ListView_what_to_show As Short
        Show_class2 = 0
        Show_Information_of_Class2 = 1
        Show_Information_of_Author = 2
        Show_Information_of_Date = 3
        To_Open = 4
    End Enum

    Private Sub ListView_Show(ByVal Sql As String, ByVal how_to_view As View, _
                              ByVal shtImage_Number As Short, ByVal blnAdd_columns As Boolean, ByVal blnListview_Group As Boolean)
        '清除先前的内容
        With ListView1
            .Columns.Clear()
            .Items.Clear()
            .Groups.Clear()
        End With

        '根据要求得到DataTable
        Dim Data_Adapter As New OleDbDataAdapter(Sql, strConnection_String)
        Dim Data_Set As New DataSet()
        Dim Data_Table As DataTable
        Data_Adapter.Fill(Data_Set, "Data")
        Data_Table = Data_Set.Tables("Data")

        '将DataTable的内容填入listview中
        Dim i As Short
        Dim j As Short
        For i = 0 To Data_Table.Rows.Count - 1

            If shtImage_Number = 19 Then
                ListView1.Items.Add(Data_Table.Rows(i).Item(0), ImageIndex(Data_Table.Rows(i).Item(2)))
            Else
                ListView1.Items.Add(Data_Table.Rows(i).Item(0), shtImage_Number)
            End If

            For j = 1 To Data_Table.Columns.Count - 1
                ListView1.Items(i).SubItems.Add(Data_Table.Rows(i).Item(j))
            Next
        Next

        '工具栏标签显示listview中的项目数
        ToolStripLabel1.Text = "共计有" & ListView1.Items.Count & "项"

        '分情况决定是否设定listview的列标题
        If blnAdd_columns Then
            Dim arrayColumns() As String = New String(3) {"书名或文档名", "作者", "文件类型", "添加时间"}
            Dim arrayWidth() As Integer = New Integer(3) {300, 100, 100, 180}
            Dim k As Short
            For k = 0 To 3
                ListView1.Columns.Add(arrayColumns(k), arrayWidth(k))
            Next
        End If
        'ListView1.Columns.Add("存储路径", 300)

        '设定listview的显示方式
        ListView1.View = how_to_view

        '更改工具栏中“视图方式”的属性
        Select Case how_to_view
            Case View.Details
                ToolStripDropDownButton1.Text = ToolStripMenuItem_details.Text
                ToolStripDropDownButton1.Image = ToolStripMenuItem_details.Image
            Case View.LargeIcon
                ToolStripDropDownButton1.Text = ToolStripMenuItem_large_icon.Text
                ToolStripDropDownButton1.Image = ToolStripMenuItem_large_icon.Image
            Case View.List
                ToolStripDropDownButton1.Text = ToolStripMenuItem_list.Text
                ToolStripDropDownButton1.Image = ToolStripMenuItem_list.Image
            Case View.SmallIcon
                ToolStripDropDownButton1.Text = ToolStripMenuItem_small_icon.Text
                ToolStripDropDownButton1.Image = ToolStripMenuItem_small_icon.Image
        End Select


        '分情况决定是否调用分组程序
        If blnListview_Group Then
            Listview_Group()
        End If

    End Sub

    Private Sub Listview_Group()
        '注意：本子程序成功运行的前提是Listview内容已按照字母顺序排列！！
        Dim strPrevious_First_Letter As String = ""
        Dim strPresent_First_Letter As String
        Dim Listview_Item As ListViewItem
        For Each Listview_Item In ListView1.Items
            strPresent_First_Letter = Microsoft.VisualBasic.Left(Listview_Item.Text, 1)
            If strPresent_First_Letter <> strPrevious_First_Letter Then
                ListView1.Groups.Add(New ListViewGroup(strPresent_First_Letter, strPresent_First_Letter))
            End If
            Listview_Item.Group = ListView1.Groups(strPresent_First_Letter)
            strPrevious_First_Letter = strPresent_First_Letter
        Next
    End Sub

    Private Function ImageIndex(ByVal extendedname As String) As Short
        Select Case extendedname
            Case "文件夹"
                ImageIndex = 3
            Case ".doc", ".docx"
                ImageIndex = 4
            Case ".ppt", ".pptx"
                ImageIndex = 5
            Case ".xls", ".xlsx"
                ImageIndex = 6
            Case ".accdb", ".mdb"
                ImageIndex = 7
            Case ".pdf"
                ImageIndex = 8
            Case ".dwg"
                ImageIndex = 9
            Case ".jpg", ".jpeg", ".bmp", ".png", ".gif", ".tiff"
                ImageIndex = 10
            Case ".rar", ".zip"
                ImageIndex = 11
            Case ".txt"
                ImageIndex = 12
            Case ".chm"
                ImageIndex = 13
            Case ".rtf"
                ImageIndex = 14
            Case ".djvu"
                ImageIndex = 15
            Case ".htm", ".html", ".xhm", ".mht"
                ImageIndex = 16
            Case ".exe"
                ImageIndex = 17
            Case Else
                ImageIndex = 18
        End Select
    End Function

    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick
        bln_Book_Finding = False

        '定义变量
        Dim strSql As String = ""
        Dim viewListview_how_to_view As View
        Dim shtListview_Imagelist As Short
        Dim blnListview_Add_Columns As Boolean
        Dim blnListview_Add_Group As Boolean = False

        '根据不同的情况给这些变量赋值
        Select Case TreeView1.SelectedNode.Name
            Case "nodeClass"
                blnListview_Add_Columns = False
                strSql = "Select Distinct 分类一 From 总目录 Order by 分类一 Asc"
                viewListview_how_to_view = View.LargeIcon
                shtListview_Imagelist = 0
                enumListView1_what_to_show = ListView_what_to_show.Show_class2
                ToolStripComboBox1.Enabled = False
            Case "nodeAuthor"
                blnListview_Add_Columns = False
                strSql = "Select Distinct 作者 From 总目录 Order by 作者 Asc"
                viewListview_how_to_view = View.SmallIcon
                shtListview_Imagelist = 1
                blnListview_Add_Group = True
                enumListView1_what_to_show = ListView_what_to_show.Show_Information_of_Author
                ToolStripComboBox1.Enabled = False
            Case "nodeWork_Name"
                blnListview_Add_Columns = True
                strSql = "Select 书名,作者,文件类型,添加时间,存储路径 From 总目录 Order by 书名 Asc"
                viewListview_how_to_view = View.Details
                shtListview_Imagelist = 19
                blnListview_Add_Group = True
                enumListView1_what_to_show = ListView_what_to_show.To_Open
                ToolStripComboBox1.Enabled = True
            Case "nodeAdd_Date"
                blnListview_Add_Columns = False
                strSql = "Select Distinct 添加时间 From 总目录 Order by 添加时间 Desc"
                viewListview_how_to_view = View.SmallIcon
                shtListview_Imagelist = 2
                enumListView1_what_to_show = ListView_what_to_show.Show_Information_of_Date
                ToolStripComboBox1.Enabled = False
        End Select

        '禁用工具栏中“返回上一级内容”按钮
        ToolStripButton2.Enabled = False

        '调用子程序执行：listview显示内容及分组
        ListView_Show(strSql, viewListview_how_to_view, shtListview_Imagelist, blnListview_Add_Columns, blnListview_Add_Group)

    End Sub

    Private Sub frmView_Information_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '连接数据库
        strConnection_String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        myOleDbConnection.ConnectionString = strConnection_String
        myOleDbConnection.Open() '在窗体关闭时调用close方法

        ToolStripComboBox1.Enabled = False
        ToolStripComboBox1.SelectedIndex = 0
        '禁用工具栏中“返回上一级内容”按钮
        ToolStripButton2.Enabled = False

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        '定义变量
        Dim strSql As String = ""
        Dim viewListview_how_to_view As View
        Dim shtListview_Imagelist As Short
        Dim blnListview_Add_Columns As Boolean
        Dim blnListview_Add_Group As Boolean = False
        'Static what_is_class_1 As String '在显示分类二所含的书目信息时使用

        '根据不同的情况给这些变量赋值
        Select Case enumListView1_what_to_show
            Case ListView_what_to_show.Show_class2
                blnListview_Add_Columns = False
                strSql = "Select Distinct 分类二 From 总目录 where 分类一 = '" _
                & ListView1.SelectedItems(0).Text & "' Order by 分类二 Asc"
                viewListview_how_to_view = View.LargeIcon
                shtListview_Imagelist = 0
                enumListView1_what_to_show = ListView_what_to_show.Show_Information_of_Class2
                '
                ToolStripComboBox1.Enabled = False
                ToolStripButton2.Enabled = True
                blnClass = False
                strNode_Name = "nodeClass"
                strUp1_Item_Name = ListView1.SelectedItems(0).Text
                shtUp1_Item_Index = ListView1.SelectedItems(0).Index
            Case ListView_what_to_show.Show_Information_of_Author
                blnListview_Add_Columns = True
                strSql = "Select 书名,作者,文件类型,添加时间,存储路径 From 总目录 where 作者 = '" _
                & ListView1.SelectedItems(0).Text & "' Order by 书名 Asc"
                viewListview_how_to_view = View.Details
                shtListview_Imagelist = 19
                blnListview_Add_Group = True
                enumListView1_what_to_show = ListView_what_to_show.To_Open
                '
                ToolStripComboBox1.Enabled = True
                ToolStripButton2.Enabled = True
                blnClass = False
                strNode_Name = "nodeAuthor"
                shtUp1_Item_Index = ListView1.SelectedItems(0).Index
                str_Form4_Back_SQL = strSql
            Case ListView_what_to_show.Show_Information_of_Class2
                blnListview_Add_Columns = True
                strSql = "Select 书名,作者,文件类型,添加时间,存储路径 From 总目录 where 分类二 = '" _
                & ListView1.SelectedItems(0).Text & "' And 分类一 = '" & strUp1_Item_Name & "' Order by 书名 Asc"
                viewListview_how_to_view = View.Details
                shtListview_Imagelist = 19
                blnListview_Add_Group = True
                enumListView1_what_to_show = ListView_what_to_show.To_Open
                '
                ToolStripComboBox1.Enabled = True
                ToolStripButton2.Enabled = True
                blnClass = True
                shtUp2_Item_Index = ListView1.SelectedItems(0).Index
                str_Form4_Back_SQL = strSql
            Case ListView_what_to_show.Show_Information_of_Date
                blnListview_Add_Columns = True
                strSql = "Select 书名,作者,文件类型,添加时间,存储路径 From 总目录 where 添加时间 = #" _
                & ListView1.SelectedItems(0).Text & "# Order by 书名 Asc"
                viewListview_how_to_view = View.Details
                shtListview_Imagelist = 19
                blnListview_Add_Group = True
                enumListView1_what_to_show = ListView_what_to_show.To_Open
                '
                ToolStripComboBox1.Enabled = True
                ToolStripButton2.Enabled = True
                blnClass = False
                strNode_Name = "nodeAdd_Date"
                shtUp1_Item_Index = ListView1.SelectedItems(0).Index
                str_Form4_Back_SQL = strSql
            Case ListView_what_to_show.To_Open
                '打开文档
                ToolStripMenuItem_Open_Click(Nothing, Nothing)
                Exit Sub
        End Select

        '调用子程序执行：listview显示内容及分组
        ListView_Show(strSql, viewListview_how_to_view, shtListview_Imagelist, blnListview_Add_Columns, blnListview_Add_Group)

    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        '暂时没有用到
        Static blnListview_Item_order As Boolean = True
        ListView1.Groups.Clear()
        If blnListview_Item_order = True Then
            ListView1.Sorting = SortOrder.Descending
        Else
            ListView1.Sorting = SortOrder.Ascending
        End If
        blnListview_Item_order = Not blnListview_Item_order
        Listview_Group()
    End Sub

    Private Sub ToolStripMenuItem_large_icon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_large_icon.Click
        ToolStripDropDownButton1.Text = ToolStripMenuItem_large_icon.Text
        ToolStripDropDownButton1.Image = ToolStripMenuItem_large_icon.Image
        ListView1.View = View.LargeIcon
    End Sub

    Private Sub ToolStripMenuItem_details_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_details.Click
        ToolStripDropDownButton1.Text = ToolStripMenuItem_details.Text
        ToolStripDropDownButton1.Image = ToolStripMenuItem_details.Image
        ListView1.View = View.Details
    End Sub

    Private Sub ToolStripMenuItem_list_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_list.Click
        ToolStripDropDownButton1.Text = ToolStripMenuItem_list.Text
        ToolStripDropDownButton1.Image = ToolStripMenuItem_list.Image
        ListView1.View = View.List
    End Sub

    Private Sub ToolStripMenuItem_small_icon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_small_icon.Click
        ToolStripDropDownButton1.Text = ToolStripMenuItem_small_icon.Text
        ToolStripDropDownButton1.Image = ToolStripMenuItem_small_icon.Image
        ListView1.View = View.SmallIcon
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        '返回上一级内容
        If blnClass Then
            Dim strSql1 As String = "Select Distinct 分类二 From 总目录 where 分类一 = '" _
                & strUp1_Item_Name & "' Order by 分类二 Asc"
            ListView_Show(strSql1, View.LargeIcon, 0, False, False)
            enumListView1_what_to_show = ListView_what_to_show.Show_Information_of_Class2
            '
            ToolStripComboBox1.Enabled = False
            ToolStripButton2.Enabled = True
            blnClass = False
            strNode_Name = "nodeClass"
            '
            Try
                ListView1.Items(shtUp2_Item_Index).Selected = True
            Catch
            End Try
            ListView1.Select()
        Else
            TreeView1.SelectedNode = TreeView1.Nodes(strNode_Name)
            TreeView1_DoubleClick(Nothing, Nothing)
            '
            ListView1.Items(shtUp1_Item_Index).Selected = True
            ListView1.Select()
        End If
    End Sub

    Public Sub ToolStripSplitButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton2.Click
        'If ToolStripTextBox1.Text.Contains("'") Then
        '    ToolStripTextBox1.Text = ToolStripTextBox1.Text.Replace("'", "’")
        '    MsgBox("输入的内容不可含有英文单引号（'），否则将引发错误，软件已经自动用中文引号（’）进行替换")
        'End If

        str_Find_Item = ToolStripTextBox1.Text
        bln_Book_Finding = True

        If ToolStripTextBox1.Text = "" Then
            MsgBox("要检索的内容不可为空！")
            Exit Sub
        End If

        '定义变量
        Dim strSql As String = ""
        Dim viewListview_how_to_view As View
        Dim shtListview_Imagelist As Short
        Dim blnListview_Add_Columns As Boolean
        Dim blnListview_Add_Group As Boolean = False
        '
        blnListview_Add_Columns = True
        strSql = "Select 书名,作者,文件类型,添加时间,存储路径 From 总目录 where 书名 Like '%" _
        & ToolStripTextBox1.Text & "%' Or 作者 Like '%" & ToolStripTextBox1.Text & "%' Order by 书名 Asc"
        viewListview_how_to_view = View.Details
        shtListview_Imagelist = 19
        blnListview_Add_Group = True
        enumListView1_what_to_show = ListView_what_to_show.To_Open
        '
        ToolStripComboBox1.Enabled = True
        ToolStripButton2.Enabled = False
        '
        Try
            ListView_Show(strSql, viewListview_how_to_view, shtListview_Imagelist, blnListview_Add_Columns, blnListview_Add_Group)
        Catch ex As Exception
            MsgBox("请确保要搜索的内容不含特殊字符")
        End Try

        If ListView1.Items.Count = 0 Then
            MsgBox("抱歉，未找到匹配的记录！")
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
        If bln_Booklist_Manage Then
            form_Booklist_manage.btn_Show_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And enumListView1_what_to_show = ListView_what_to_show.To_Open Then
            ContextMenuStrip1.Show(MousePosition)
        End If
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        If ToolStripComboBox1.SelectedIndex = 1 Then
            ListView1.CheckBoxes = True
        Else
            ListView1.CheckBoxes = False
        End If
    End Sub

    Private Sub ToolStripComboBox1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.EnabledChanged
        If ToolStripComboBox1.Enabled = False Then
            ListView1.CheckBoxes = False
        Else
            If ToolStripComboBox1.SelectedIndex = 1 Then
                ListView1.CheckBoxes = True
            End If
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListView1.CheckBoxes = True Then
            ContextMenuStrip1.Items(0).Visible = False '打开
            ContextMenuStrip1.Items(1).Visible = False '打开目录并选中
            ContextMenuStrip1.Items(5).Visible = False '编辑信息
            ContextMenuStrip1.Items(6).Visible = True '更改分类
            ContextMenuStrip1.Items(7).Visible = True '修改作者
            ContextMenuStrip1.Items(9).Visible = False '上网搜索
            ContextMenuStrip1.Items(10).Visible = True
            ContextMenuStrip1.Items(11).Visible = True
        Else
            ContextMenuStrip1.Items(0).Visible = True
            ContextMenuStrip1.Items(1).Visible = True
            ContextMenuStrip1.Items(5).Visible = True
            ContextMenuStrip1.Items(6).Visible = False  '更改分类
            ContextMenuStrip1.Items(7).Visible = False  '修改作者
            ContextMenuStrip1.Items(9).Visible = True '上网搜索
            ContextMenuStrip1.Items(10).Visible = False
            ContextMenuStrip1.Items(11).Visible = False
        End If
    End Sub

    Private Sub ToolStripMenuItem_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Open.Click
        '打开文档
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = ListView1.SelectedItems(0).SubItems(4).Text
        myProcess.StartInfo.Verb = "open"
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.Start()

        '修改“最近打开文档”的记录
        '(0)查找是否已经有该书，如有则只更新时间信息，不再新添加一条
        Dim BookPath_now As String = ListView1.SelectedItems(0).SubItems(4).Text
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
            BookPath = ListView1.SelectedItems(0).SubItems(4).Text
            str_Sql2 = "Insert Into 最近打开文档(存储路径,打开时间) Values('" & BookPath & "',#" _
            & Date.Now & "#)"
            myCommand2.CommandText = str_Sql2
            myConnection2.Open()
            myCommand2.Connection = myConnection2
            myCommand2.ExecuteNonQuery()
            myConnection2.Close()
        Else
            '总数<10,则仅添加一个记录
            Dim BookPath As String = ListView1.SelectedItems(0).SubItems(4).Text
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

    Private Sub ToolStripMenuItem_Open_Directory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Open_Directory.Click
        OpenFolderAndSelectSpecificFile(ListView1.SelectedItems(0).SubItems(4).Text)
    End Sub

    Private Sub ToolStripMenuItem_Send_to_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Send_to.Click

        If ToolStripComboBox1.SelectedIndex = 0 Then
            If FolderBrowserDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If
            Dim DestinationFolder As String = FolderBrowserDialog1.SelectedPath
            File_Copy_to(ListView1.SelectedItems(0), DestinationFolder)
            MsgBox("已经发送到指定位置。")
        End If

        If ToolStripComboBox1.SelectedIndex = 1 Then
            If ListView1.CheckedItems.Count > 0 Then
                If FolderBrowserDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                    Exit Sub
                End If
                Dim DestinationFolder As String = FolderBrowserDialog1.SelectedPath
                Dim Listviewitem_now As New ListViewItem
                For Each Listviewitem_now In ListView1.CheckedItems
                    File_Copy_to(Listviewitem_now, DestinationFolder)
                Next
                MsgBox("已经发送到指定位置。")
            Else
                MsgBox("请先勾选要操作项目！")
            End If
        End If

    End Sub

    Private Sub File_Copy_to(ByVal myListviewItem As ListViewItem, ByVal DestinationFolder As String)
        If Microsoft.VisualBasic.Right(DestinationFolder, 1) <> "\" Then
            DestinationFolder = DestinationFolder & "\"
        End If
        Dim DestinationPath As String
        Dim SourcePath As String = myListviewItem.SubItems(4).Text
        Try
            If System.IO.Path.HasExtension(SourcePath) Then
                DestinationPath = DestinationFolder & System.IO.Path.GetFileName(SourcePath)
                My.Computer.FileSystem.CopyFile(SourcePath, DestinationPath)
            Else
                DestinationPath = DestinationFolder & GetLastFolderName(SourcePath)
                My.Computer.FileSystem.CopyDirectory(SourcePath, DestinationPath)
            End If
        Catch

        End Try
    End Sub

    Private Function GetLastFolderName(ByVal path As String) As String
        Dim b As String = path.Remove(0, System.IO.Path.GetDirectoryName(path).Count)
        GetLastFolderName = b.Replace("\", "")
    End Function

    Private Sub ToolStripMenuItem_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Delete.Click
        
        If ToolStripComboBox1.SelectedIndex = 0 Then
            '是否确认删除
            If MsgBox("程序将连同原文件一起删除，是否继续？", MsgBoxStyle.YesNo, "删除文件") _
            = MsgBoxResult.No Then
                Exit Sub
            End If
            Delete_File(ListView1.SelectedItems(0))
        End If

        If ToolStripComboBox1.SelectedIndex = 1 Then
            If ListView1.CheckedItems.Count > 0 Then
                '是否确认删除
                If MsgBox("程序将连同原文件一起删除，是否继续？", MsgBoxStyle.YesNo, "删除文件") _
                = MsgBoxResult.No Then
                    Exit Sub
                End If
                Dim Listviewitem_now As New ListViewItem
                For Each Listviewitem_now In ListView1.CheckedItems
                    Delete_File(Listviewitem_now)
                Next
            Else
                MsgBox("请先勾选要操作项目！")
            End If
        End If
    End Sub

    Private Sub Delete_File(ByVal myListviewItem As ListViewItem)
        Dim SourcePath As String = myListviewItem.SubItems(4).Text

        '删除原文件
        Try
            If System.IO.Path.HasExtension(SourcePath) Then
                My.Computer.FileSystem.DeleteFile(SourcePath)
            Else
                My.Computer.FileSystem.DeleteDirectory(SourcePath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
        Catch
        End Try

        '删除数据库记录（删除所有表的！）
        Dim mySchemaTable As New DataTable
        mySchemaTable = GetSchemaTable(strConnection_String)
        Dim j0 As Short
        Dim BookListName As String
        For j0 = 0 To mySchemaTable.Rows.Count - 1
            '遍历所有表
            Dim sqlstr_Delete_Path As String
            BookListName = mySchemaTable.Rows(j0).Item(2)
            sqlstr_Delete_Path = "Delete From " & BookListName & " where 存储路径 = '" & SourcePath & "' "
            Using oledcmmd As New OleDbCommand(sqlstr_Delete_Path)
                With oledcmmd
                    .Connection = New OleDbConnection(strConnection_String)
                    .Connection.Open()
                    .ExecuteReader()
                    .Connection.Close()
                End With
            End Using
        Next
        '删除Listview中的项
        myListviewItem.Remove()
    End Sub

    Private Sub ToolStripMenuItem_Search_in_the_internet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Search_in_the_internet.Click
        Dim mySearchDialog As New Search_Internet
        str_pulic_Selected_ListviewItem_Text = ListView1.SelectedItems(0).Text
        mySearchDialog.Show()
    End Sub

    Private Sub ToolStripMenuItem_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Edit.Click
        Dim frmEdit_Information As New frmClass_Edit_Information(Me)
        frmEdit_Information.Show()
    End Sub

    Public Function ListView_Checked_Items() As ListView.CheckedListViewItemCollection
        ListView_Checked_Items = ListView1.CheckedItems
    End Function

    Public Function ListView_Items() As ListView.ListViewItemCollection
        ListView_Items = ListView1.Items
    End Function

    Public Function Listview_SelectedItem_Index() As Short
        Listview_SelectedItem_Index = ListView1.SelectedItems(0).Index
        str_Seleted_Listview_Item_FilePath = ListView1.SelectedItems(0).SubItems(4).Text
    End Function

    Public Sub Form4_Back_ReShow_Listview()

        If bln_Book_Finding Then
            ToolStripTextBox1.Text = str_Find_Item
            ToolStripSplitButton2_Click(Nothing, Nothing)
            Exit Sub
        End If

        '该函数由批量修改分类窗体的“保存”按钮的Click事件处理函数调用
        '该函数也由ToolStripMenuItem_Modify_Author_Click函数调用
        '2、完成/放弃修改后，分情况，重新查询数据库，并重新填充Listview
        Select Case TreeView1.SelectedNode.Name
            Case "nodeClass"
                '第一步：重新显示内容
                ListView_Show(str_Form4_Back_SQL, View.Details, 19, True, True)
                If ListView1.Items.Count <> 0 Then
                    ListView1.Select()
                    Try
                        ListView1.FindItemWithText(str_Seleted_Listview_Item_FilePath, True, 0).Selected = True
                    Catch
                    End Try
                    Exit Select
                Else
                    MsgBox("该分类没有书目，已删除")
                    ToolStripButton2_Click(Nothing, Nothing)
                    If ListView1.Items.Count <> 0 Then
                        Exit Select
                    Else
                        TreeView1_DoubleClick(Nothing, Nothing)
                    End If
                End If
            Case "nodeAuthor"
                '第一步：重新显示内容
                ListView_Show(str_Form4_Back_SQL, View.Details, 19, True, True)
                If ListView1.Items.Count <> 0 Then
                    ListView1.Select()
                    Try
                        ListView1.FindItemWithText(str_Seleted_Listview_Item_FilePath, True, 0).Selected = True
                    Catch
                    End Try
                Else
                    '第二部：若listview是空的，则msgbox说明，然后显示所有作者
                    MsgBox("不存在该作者或该作者的书已被删空")
                    TreeView1_DoubleClick(Nothing, Nothing)
                    ListView1.Select()
                End If
            Case "nodeWork_Name"
                TreeView1_DoubleClick(Nothing, Nothing)
                ListView1.Select()
                Try
                    ListView1.FindItemWithText(str_Seleted_Listview_Item_FilePath, True, 0).Selected = True
                Catch
                End Try
            Case "nodeAdd_Date"
                ListView_Show(str_Form4_Back_SQL, View.Details, 19, True, True)
                ListView1.Select()
                Try
                    ListView1.FindItemWithText(str_Seleted_Listview_Item_FilePath, True, 0).Selected = True
                Catch
                End Try
        End Select
    End Sub

    Private Sub ToolStripMenuItem_Change_Class_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("请先勾选要操作项目！")
            Exit Sub
        End If
        Dim form_Change_Class_For_Batch As New Change_Class_Batch(Me)
        form_Change_Class_For_Batch.Show()

    End Sub

    Private Sub ToolStripMenuItem_Add_into_booklist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Add_into_booklist.Click
        If ToolStripComboBox1.SelectedIndex = 0 Then
            Dim form_Add_into_booklist_single As New class_form_Add_into_booklist_single(Me)
            form_Add_into_booklist_single.Show()
        Else
            If ListView1.CheckedItems.Count <> 0 Then
                Dim form_Add_into_booklist_batch As New class_form_add_into_booklist_batch(Me)
                form_Add_into_booklist_batch.Show()
            Else
                MsgBox("请先勾选要操作项目！")
            End If
        End If
    End Sub

    Private Sub 全部勾选ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全部勾选ToolStripMenuItem.Click
        Dim myListviewItem As ListViewItem
        For Each myListviewItem In ListView1.Items
            myListviewItem.Checked = True
        Next
    End Sub

    Private Sub 取消勾选ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 取消勾选ToolStripMenuItem.Click
        Dim myListviewItem As ListViewItem
        For Each myListviewItem In ListView1.CheckedItems
            myListviewItem.Checked = False
        Next
    End Sub

    Private Sub frmView_Information_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrevious_Form.Show()
    End Sub

    Private Sub ToolStripMenuItem_Modify_Author_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Modify_Author.Click
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("请先勾选要操作项目！")
            Exit Sub
        End If
        Dim author As String = InputBox("请输入修改后的作者名", "修改作者")

        If author = "" Then
            Exit Sub
        Else
            If author.Contains("'") Then
                author = author.Replace("'", "’")
                MsgBox("输入的内容不可含有英文单引号（'），否则将引发错误，软件已经自动用中文引号（’）进行替换")
            End If
            Dim myListviewItem As ListViewItem
            For Each myListviewItem In ListView_Checked_Items()
                Using myConnection As New OleDbConnection
                    myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                    My.Application.Info.DirectoryPath & "\BookInformation.mdb"
                    Dim Sql_update As String = "Update 总目录 Set  作者 = '" & _
                    author & "' Where 存储路径 = '" & myListviewItem.SubItems(4).Text & "'"
                    Dim myCommand As New OleDbCommand
                    myCommand.CommandText = Sql_update
                    myConnection.Open()
                    myCommand.Connection = myConnection
                    myCommand.ExecuteNonQuery()
                    myConnection.Close()
                End Using
            Next
            '
            Form4_Back_ReShow_Listview()
        End If
    End Sub

    '上下文菜单的重命名原文件↓

    Private Sub 名称作者ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 名称作者ToolStripMenuItem.Click
        Book_Rename_0(0)
    End Sub

    Private Sub 作者名称ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 作者名称ToolStripMenuItem.Click
        Book_Rename_0(1)
    End Sub

    Private Sub 名称ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 名称ToolStripMenuItem.Click
        Book_Rename_0(2)
    End Sub

    Private Sub Book_Rename_0(ByVal way As Short)
        Dim Listviewitem_now As New ListViewItem
        If ToolStripComboBox1.SelectedIndex = 0 Then
            BookRename(ListView1.SelectedItems(0), way)
            MsgBox("重命名完成！")
        End If
        If ToolStripComboBox1.SelectedIndex = 1 Then
            If ListView1.CheckedItems.Count > 0 Then
                For Each Listviewitem_now In ListView1.CheckedItems
                    BookRename(Listviewitem_now, way)
                Next
                MsgBox("重命名完成！")
            Else
                MsgBox("请先勾选要操作项目！")
            End If
        End If

    End Sub

    Private Sub BookRename(ByVal myItem As ListViewItem, ByVal which_way As Short)
        '第一步：给原文件重命名
        Dim BookName As String = myItem.Text
        Dim Author As String = myItem.SubItems(1).Text
        Dim strExtend_Name As String = myItem.SubItems(2).Text
        Dim strOld_Path As String = myItem.SubItems(4).Text
        Dim strNew_Path As String
        Dim strParent_Path As String = My.Computer.FileSystem.GetParentPath(strOld_Path)
        Dim NewName As String = "" '不含扩展名，不是路径

        Select Case which_way
            Case 0 '书名-作者
                NewName = BookName & "-" & Author
            Case 1 '作者-书名
                NewName = Author & "-" & BookName
            Case 2 '书名
                NewName = BookName
        End Select

        If Microsoft.VisualBasic.Right(strParent_Path, 1) <> "\" Then
            strParent_Path = strParent_Path & "\"
        End If
        If strExtend_Name <> "文件夹" Then
            strNew_Path = strParent_Path & NewName & strExtend_Name '第二、三步用到
            Try
                My.Computer.FileSystem.RenameFile(strOld_Path, NewName & strExtend_Name)
            Catch

            End Try
        Else
            strNew_Path = strParent_Path & NewName '第二、三步用到
            Try
                My.Computer.FileSystem.RenameDirectory(strOld_Path, NewName)
            Catch
            End Try
        End If

        '第二步：更新listview的subitem(4)
        myItem.SubItems(4).Text = strNew_Path

        '第三步：更新数据库所有表的存储路径、
        '注意是所有的表，包括了书单！！！
        Dim mySchemaTable As New DataTable
        Dim myConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        mySchemaTable = GetSchemaTable(myConnectionString)

        For i = 0 To mySchemaTable.Rows.Count - 1
            Dim TableName As String
            TableName = mySchemaTable.Rows(i).Item(2)
            Dim sqlstr_Update_Path As String
            sqlstr_Update_Path = "Update " & TableName & " Set 存储路径 = '" & strNew_Path & _
            "' Where 存储路径 = '" & strOld_Path & "'"
            Dim oledcmmd As New OleDbCommand(sqlstr_Update_Path)
            With oledcmmd
                .Connection = New OleDbConnection(strConnection_String)
                .Connection.Open()
                .ExecuteReader()
                .Connection.Close()
            End With
        Next
    End Sub

    'Private Sub ToolStripTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.TextChanged
    '    If CheckSpecialChar_here(ToolStripTextBox1.Text) = False Then
    '        MsgBox("输入的内容不可含有英文字符和空格。")
    '    End If
    'End Sub

    'Private Function CheckSpecialChar_here(ByVal inputString As String) As Boolean
    '    REM 功能：检测给定字符串是否含有非法字符,有则返回false
    '    REM 算法：依次获取inputString的每个字符，判断其ASCII码是否在合理范围内，
    '    REM 若有任意一个不在, 则结束函数, 返回false值
    '    Dim i As Short
    '    For i = 0 To inputString.Count - 1
    '        Dim ele As Char = inputString.ElementAt(i)
    '        Dim num As Short = Asc(ele)
    '        If Not (num < 0 Or (num >= 48 And num <= 57) Or (num >= 65 And num <= 90) Or (num >= 97 And num <= 122)) Then
    '            Return False
    '            Exit Function
    '        End If
    '    Next
    '    Return True
    'End Function

End Class
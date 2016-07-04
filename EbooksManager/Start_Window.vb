Imports System.Text
Imports System.IO
Imports System.Data.OleDb
Public Class frmStart_Window
    Private frmRef_frmManage_Directory As Form

    Public Sub New()
        MyBase.New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit_Program.Click
        End
    End Sub

    Private Sub btnSet_Directory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet_Directory.Click
        Me.Hide()
        Dim formManage_Directory = New frmManage_Directory(Me)
        formManage_Directory.Show()
    End Sub

    Private Sub btnView_Information_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView_Information.Click
        Dim formView_Information As New frmView_Information(Me, 0)
        formView_Information.Show()
        Me.Hide()
    End Sub

    Private Sub btnMinimize_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMinimize.MouseHover
        btnMinimize.BackColor = Color.HotPink
        btnMinimize.ForeColor = Color.White
    End Sub

    Private Sub btnMinimize_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMinimize.MouseLeave
        btnMinimize.BackColor = Color.DodgerBlue
        btnMinimize.ForeColor = Color.HotPink
    End Sub

    Private Sub btnExit_Program_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit_Program.MouseHover
        btnExit_Program.BackColor = Color.HotPink
        btnExit_Program.ForeColor = Color.White
    End Sub

    Private Sub btnExit_Program_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit_Program.MouseLeave
        btnExit_Program.BackColor = Color.DodgerBlue
        btnExit_Program.ForeColor = Color.HotPink
    End Sub

    Private Sub frmStart_Window_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ToolTip1.SetToolTip(btnMinimize, "最小化窗口")
        ToolTip2.SetToolTip(btnExit_Program, "退出程序")
    End Sub

    Private Sub btnBooklist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBooklist.Click
        Dim form_Manage_Booklist As New class_form_Manage_Booklist(Me)
        form_Manage_Booklist.Show()
        Me.Hide()
    End Sub

    Private Sub btnView_Recent_Files_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView_Recent_Files.Click
        Dim form_Recent_opened_files As New class_form_Recent_Opened_Files(Me)
        form_Recent_opened_files.Show()
        Me.Hide()
    End Sub

    Public Sub btnUpdate_Information_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate_Information.Click

        '（1）检查:数据库中地址是否有效
        Check_Database_Path()

        '（2）处理选定目录中的子目录
        Dim strConnection_String As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                    My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim strDirectory_File_FullPath As String
        strDirectory_File_FullPath = My.Application.Info.DirectoryPath & "\Directory.txt"
        Dim sr As StreamReader = New StreamReader(strDirectory_File_FullPath, System.Text.Encoding.Unicode)
        Dim time As Date = Date.Now
        Do While sr.Peek() >= 0
            Dim path As String = sr.ReadLine
            Dim i As Short
            For i = 0 To My.Computer.FileSystem.GetDirectories(path).Count - 1
                Dim FolderPath As String = My.Computer.FileSystem.GetDirectories(path)(i)

                '检查目录名中是否含有英文单引号
                If FolderPath.Contains("'") Then
                    Dim OldFolderPath As String = FolderPath
                    FolderPath = FolderPath.Replace("'", "’")
                    My.Computer.FileSystem.RenameDirectory(OldFolderPath, FolderPath)
                    MsgBox("输入的内容不可含有英文单引号（'），否则将引发错误，软件已经自动用中文引号（’）进行替换")
                End If

                '检查数据库中是否已经有记录
                Dim sql3 As String
                sql3 = "Select * From 总目录 Where 存储路径 = '" & FolderPath & "'"
                Dim Data_Adapter1 As New OleDbDataAdapter(sql3, strConnection_String)
                Dim Data_Set1 As New DataSet()
                Dim Data_Table1 As DataTable
                Data_Adapter1.Fill(Data_Set1, "Data")
                Data_Table1 = Data_Set1.Tables("Data")

                '若没有记录则添加进去
                If Data_Table1.Rows.Count = 0 Then
                    Dim FolderName As String = GetLastFolderName(FolderPath)
                    Dim sql_1 As String = " Insert into 总目录(书名,作者,分类一,分类二,文件类型,添加时间,存储路径)" & _
                    " Values('" & FolderName & "','#未填写#','#未分类#','#未分类#','文件夹',#" & time & "#,'" & FolderPath & "')"
                    Using myConnection As New OleDbConnection
                        myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                        My.Application.Info.DirectoryPath & "\BookInformation.mdb"
                        Dim myCommand As New OleDbCommand
                        myCommand.CommandText = sql_1
                        myConnection.Open()
                        myCommand.Connection = myConnection
                        myCommand.ExecuteNonQuery()
                        myConnection.Close()
                    End Using
                End If
            Next


            '（3）处理选定目录中的文件
            Dim j As Short
            For j = 0 To My.Computer.FileSystem.GetFiles(path).Count - 1
                Dim FilePath As String = My.Computer.FileSystem.GetFiles(path)(j)

                '检查文件名中是否含有英文单引号
                If FilePath.Contains("'") Then
                    Dim OldFilePath As String = FilePath
                    FilePath = FilePath.Replace("'", "’")
                    My.Computer.FileSystem.RenameDirectory(OldFilePath, FilePath)
                    MsgBox("输入的内容不可含有英文单引号（'），否则将引发错误，软件已经自动用中文引号（’）进行替换")
                End If

                '检查数据库中是否已经有记录
                Dim sql4 As String
                sql4 = "Select * From 总目录 Where 存储路径 = '" & FilePath & "'"
                Dim Data_Adapter2 As New OleDbDataAdapter(sql4, strConnection_String)
                Dim Data_Set2 As New DataSet()
                Dim Data_Table2 As DataTable
                Data_Adapter2.Fill(Data_Set2, "Data")
                Data_Table2 = Data_Set2.Tables("Data")

                '若没有记录则添加进去
                If Data_Table2.Rows.Count = 0 Then
                    Dim FileName As String = System.IO.Path.GetFileNameWithoutExtension(FilePath)
                    Dim ExtensionName As String = System.IO.Path.GetExtension(FilePath)
                    Dim sql_2 As String = " Insert into 总目录(书名,作者,分类一,分类二,文件类型,添加时间,存储路径)" & _
                    " Values('" & FileName & "','#未填写#','#未分类#','#未分类#','" & ExtensionName & "',#" & time & "#,'" & FilePath & "')"
                    Using myConnection As New OleDbConnection
                        myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                        My.Application.Info.DirectoryPath & "\BookInformation.mdb"
                        Dim myCommand As New OleDbCommand
                        myCommand.CommandText = sql_2
                        myConnection.Open()
                        myCommand.Connection = myConnection
                        myCommand.ExecuteNonQuery()
                        myConnection.Close()
                    End Using
                End If
            Next
        Loop
        sr.Close()

        MsgBox("信息已更新！", Nothing, "信息更新")

    End Sub

    Private Function GetLastFolderName(ByVal path As String) As String
        Dim b As String = path.Remove(0, System.IO.Path.GetDirectoryName(path).Count)
        GetLastFolderName = b.Replace("\", "")
    End Function

    Private Sub Check_Database_Path()
        '获取所有的路径（从总目录中）
        Dim sql As String = "Select 存储路径 From 总目录"
        Dim strConnection_String As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                    My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim Data_Adapter As New OleDbDataAdapter(sql, strConnection_String)
        Dim Data_Set As New DataSet()
        Dim Data_Table As DataTable
        Data_Adapter.Fill(Data_Set, "Data")
        Data_Table = Data_Set.Tables("Data")

        '若数据库中已有的路径在实际中不存在，或者不在管理目录中
        '则删除含有该路径的所有记录
        Dim i0 As Short
        For i0 = 0 To Data_Table.Rows.Count - 1
            Dim path_from_data As String = Data_Table.Rows(i0).Item(0)
            If System.IO.Path.HasExtension(path_from_data) Then '对于文件
                If System.IO.File.Exists(path_from_data) = False Or In_the_directory(path_from_data) = False Then
                    Dim mySchemaTable As New DataTable
                    mySchemaTable = GetSchemaTable(strConnection_String)
                    Dim j0 As Short
                    Dim BookListName As String
                    For j0 = 0 To mySchemaTable.Rows.Count - 1
                        '遍历所有表
                        Dim sqlstr_Delete_Path As String
                        BookListName = mySchemaTable.Rows(j0).Item(2)
                        sqlstr_Delete_Path = "Delete From " & BookListName & " where 存储路径 = '" & path_from_data & "' "
                        Try
                            Using oledcmmd As New OleDbCommand(sqlstr_Delete_Path)
                                With oledcmmd
                                    .Connection = New OleDbConnection(strConnection_String)
                                    .Connection.Open()
                                    .ExecuteReader()
                                    .Connection.Close()
                                End With
                            End Using
                        Catch
                        End Try
                    Next
                End If
            Else '对于文件夹
                If Not System.IO.Directory.Exists(path_from_data) Then
                    Dim mySchemaTable As New DataTable
                    mySchemaTable = GetSchemaTable(strConnection_String)
                    Dim j1 As Short
                    Dim BookListName As String
                    For j1 = 0 To mySchemaTable.Rows.Count - 1
                        '遍历所有表
                        Dim sqlstr_Delete_Path As String
                        BookListName = mySchemaTable.Rows(j1).Item(2)
                        sqlstr_Delete_Path = "Delete From " & BookListName & " where 存储路径 = '" & path_from_data & "' "
                        Using oledcmmd As New OleDbCommand(sqlstr_Delete_Path)
                            With oledcmmd
                                .Connection = New OleDbConnection(strConnection_String)
                                .Connection.Open()
                                .ExecuteReader()
                                .Connection.Close()
                            End With
                        End Using
                    Next
                End If
            End If
        Next
    End Sub

    Private Function In_the_directory(ByVal dataPath As String) As Boolean
        Dim strDirectory_File_FullPath As String
        strDirectory_File_FullPath = My.Application.Info.DirectoryPath & "\Directory.txt"
        Dim sr As StreamReader = New StreamReader(strDirectory_File_FullPath, System.Text.Encoding.Unicode)
        Dim time As Date = Date.Now
        Do While sr.Peek() >= 0
            Dim DirectoryPath As String = sr.ReadLine
            If System.IO.Path.GetDirectoryName(dataPath) = DirectoryPath Then
                In_the_directory = True
                Exit Function
            End If
        Loop
        sr.Close()
        In_the_directory = False
    End Function

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = My.Application.Info.DirectoryPath & "\Helper.pdf"
        myProcess.StartInfo.Verb = "open"
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.Start()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Dim form_statement As New Statement(Me)
        form_statement.Show()
        Me.Hide()
    End Sub
End Class


Imports System.IO
Public Class frmManage_Directory
    Dim blnCancle_Modification As Boolean = True
    Private frmPrevious_Form As frmStart_Window
    Dim blnDirctory_Changed As Boolean '指示管理目录是否修改过（下方有补充说明）
    '其实从最后结果看，即使blnDirectory_Changed值为True，也不代表
    '管理的目录真的修被改过，因为存在如下情况，用户
    '添加了一个目录后又把它删除了或者删除后又添加了
    '这其实是一个不严谨的地方

    Public Sub New(ByRef pForm As Form)
        MyBase.New()
        InitializeComponent()
        frmPrevious_Form = pForm
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        '设定FolderBrowserDialog的属性
        With FolderBrowserDialog1
            .Description = "选择要添加的目录"
            .RootFolder = Environment.SpecialFolder.MyComputer
        End With

        '根据FolderBrowserDialog返回的路径进行操作
        '判断路径是否与已有的项重复，若不重复则加入到lst中，否则不加入
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim folderPath As String = FolderBrowserDialog1.SelectedPath
            If lst.Items.Contains(folderPath) = False Then
                lst.Items.Add(folderPath)
                blnDirctory_Changed = True '指示目录已经修改
            Else
                MsgBox("该目录已经添加了，请勿重复添加")
            End If
        End If

        '使btnDelete有效（其实不加if直接使它有效就行）
        If lst.Items.Count > 0 Then
            btnDelete.Enabled = True
        End If

    End Sub

    Private Sub frmDirectory_Manage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '打开Directory.txt文件，读取被管理目录到lst控件中
        Dim strDirectory_File_FullPath As String
        strDirectory_File_FullPath = My.Application.Info.DirectoryPath & "\Directory.txt"
        Dim sr As StreamReader = New StreamReader(strDirectory_File_FullPath, System.Text.Encoding.Unicode)
        '统一使用Unicode 编码
        Do While sr.Peek() >= 0
            Dim Path As String = sr.ReadLine
            lst.Items.Add(Path)
        Loop
        sr.Close()

        '若lst为空则使btnDelete失效
        If lst.Items.Count = 0 Then
            btnDelete.Enabled = False
        End If

        '目录修改
        blnDirctory_Changed = False '未修改

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        '删除所选的项（每次仅能删一个）
        If lst.Items.Count <> 0 And lst.SelectedIndex <> -1 Then
            lst.Items.RemoveAt(lst.SelectedIndex)
            blnDirctory_Changed = True '指示目录已经修改
        End If

        '若lst被删空了，则使btnDelete失效
        If lst.Items.Count = 0 Then
            btnDelete.Enabled = False
        End If

    End Sub

    Private Sub btnGoBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoBack.Click

        '将lst中的内容覆盖到文件Directory.txt
        Dim strDirectory_File_FullPath As String
        strDirectory_File_FullPath = My.Application.Info.DirectoryPath & "\Directory.txt"
        Dim sw As StreamWriter = New StreamWriter(strDirectory_File_FullPath, False, System.Text.Encoding.Unicode)
        For i = 0 To lst.Items.Count - 1
            sw.WriteLine(lst.Items.Item(i))
        Next i
        sw.Close()

        '关闭然后返回主界面
        blnCancle_Modification = False
        Me.Close()
    End Sub

    Private Sub frmManage_Directory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If blnCancle_Modification Then
            If MsgBox("您点击了关闭按钮，程序将不会保存" _
            & "您对目录所做的任何更改，是否确认？", _
            MsgBoxStyle.OkCancel, "确认放弃修改") = MsgBoxResult.Ok Then
                frmPrevious_Form.Show()
            Else
                e.Cancel = True
            End If
        Else
            frmPrevious_Form.Show()
        End If
    End Sub

    Private Sub frmManage_Directory_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If Not blnCancle_Modification Then
            If blnDirctory_Changed Then
                If MsgBox("目录已经更改，是否现在更新书目信息？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    frmPrevious_Form.btnUpdate_Information_Click(Nothing, Nothing)
                End If
            End If
        End If
    End Sub
End Class

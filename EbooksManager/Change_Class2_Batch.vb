Imports System.Data.OleDb
Public Class Change_Class2_Batch
    Dim dialog_Change_Class_Batch As New Change_Class_Batch(Nothing)

    Private Sub btn_new_Class2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_Class2.Click
        Dim str_New_Class_Name As String = InputBox("请输入新分类")
        If str_New_Class_Name = "" Then
            Exit Sub
        ElseIf ListBox1.Items.Contains(str_New_Class_Name) Then
            MsgBox("新分类名不可与已有的重复！")
            btn_new_Class2_Click(Nothing, Nothing)
        ElseIf CheckSpecialChar(str_New_Class_Name) = False Then
            MsgBox("输入的内容不可含有英文字符和空格，且不可以数字开头。")
            btn_new_Class2_Click(Nothing, Nothing)
        Else
            ListBox1.Items.Insert(0, str_New_Class_Name)
            ListBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        If ListBox1.SelectedIndex = -1 Then
            MsgBox("必须选择一个分类")
        Else
            dialog_Change_Class_Batch.lbl_Class2.Text = ListBox1.Text
            Me.Close()
        End If
    End Sub

    Private Sub btn_Cancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancle.Click
        Me.Close()
    End Sub

    Private Sub class_form_Change_Class2_Batch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "Select Distinct 分类二 From 总目录 where 分类一 = '" _
                & dialog_Change_Class_Batch.lbl_Class1.Text & "' Order by 分类二 Asc"
        Dim strConnection_string As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
        My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim Data_Adapter As New OleDbDataAdapter(Sql, strConnection_string)
        Dim Data_Set As New DataSet()
        Dim Data_Table As DataTable
        Data_Adapter.Fill(Data_Set, "Data")
        Data_Table = Data_Set.Tables("Data")
        '
        Dim i As Short
        For i = 0 To Data_Table.Rows.Count - 1
            ListBox1.Items.Add(Data_Table.Rows(i).Item(0))
        Next
    End Sub

    Public Sub New(ByRef pForm As Form)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        dialog_Change_Class_Batch = pForm
    End Sub
End Class
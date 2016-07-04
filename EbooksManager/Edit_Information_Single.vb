Imports System.Data
Imports System.Data.OleDb
Imports System.String
Imports System.IO
Public Class frmClass_Edit_Information
    Dim form2_View_information As New frmView_Information(Nothing, Nothing)
    Dim ListView_Items_from_frm2 As ListView.ListViewItemCollection
    Dim ListView_Items_Index_Now As Short
    Dim array_str_Special_Punctuation() As Char
    Dim sht_Array_Upbound As Short

    Private Sub btn_Save_and_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save_and_Close.Click
        Save_Data(ListView_Items_Index_Now)
        Me.Close()
        form2_View_information.Form4_Back_ReShow_Listview()
    End Sub

    Public Sub New(ByRef pForm As Form)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        form2_View_information = pForm
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancle.Click
        Me.Close()
    End Sub

    Private Sub Save_Data(ByVal Index_now As Short)
        Dim myConnection As New OleDbConnection
        myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
        My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim Sql_update As String = "Update 总目录 Set 书名 = '" & txt_Book_Name.Text & "', 作者 = '" & txt_Author.Text & "', 分类一 = '" & _
        ComboBox_Class1.Text & "', 分类二 = '" & ComboBox_Class2.Text & "' Where 存储路径 = '" & _
        ListView_Items_from_frm2(Index_now).SubItems(4).Text & "'"
        Dim myCommand As New OleDbCommand
        myCommand.CommandText = Sql_update
        myConnection.Open()
        myCommand.Connection = myConnection
        myCommand.ExecuteNonQuery()
        myConnection.Close()
    End Sub

    Private Sub Show_Data(ByVal Index_now As Short)
        txt_File_Path.Text = ListView_Items_from_frm2(Index_now).SubItems(4).Text
        '
        Dim Sql As String = "Select 书名,作者,分类一,分类二 From 总目录 where 存储路径 = '" _
                & txt_File_Path.Text & "'"
        Dim strConnection_string As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
        My.Application.Info.DirectoryPath & "\BookInformation.mdb"
        Dim Data_Adapter As New OleDbDataAdapter(Sql, strConnection_String)
        Dim Data_Set As New DataSet()
        Dim Data_Table As DataTable
        Data_Adapter.Fill(Data_Set, "Data")
        Data_Table = Data_Set.Tables("Data")
        '
        txt_Book_Name.Text = Data_Table.Rows(0).Item(0)
        txt_Author.Text = Data_Table.Rows(0).Item(1)
        ComboBox_Class1.Items.Clear()
        ComboBox_Class1.Items.Add(Data_Table.Rows(0).Item(2))
        ComboBox_Class1.Items.Add("选择其它分类")
        ComboBox_Class1.SelectedIndex = 0
        ComboBox_Class2.Items.Clear()
        ComboBox_Class2.Items.Add(Data_Table.Rows(0).Item(3))
        ComboBox_Class2.Items.Add("选择其它分类")
        ComboBox_Class2.SelectedIndex = 0
    End Sub

    Private Sub frmClass_Edit_Information_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ListView_Items_from_frm2 = form2_View_information.ListView_Items
        ListView_Items_Index_Now = form2_View_information.Listview_SelectedItem_Index
        Buttons_Enable(ListView_Items_Index_Now)
        Show_Data(ListView_Items_Index_Now)

        array_str_Special_Punctuation = New Char() {"#", "~", "`", "$", "%", "^", "&", "*", "(", ")", "-", "+", "=", "{", "}", "[", "]", "|", ":", ";", ".", ",", "<", ">", "【", "】", "：", "《", "》", "·", "，", "。"}
        sht_Array_Upbound = Microsoft.VisualBasic.UBound(array_str_Special_Punctuation)
    End Sub

    Private Sub Buttons_Enable(ByVal Index_now As Short)
        If Index_now = 0 Then
            btn_Previous.Enabled = False
        Else
            btn_Previous.Enabled = True
        End If
        If Index_now = ListView_Items_from_frm2.Count - 1 Then
            btn_Next.Enabled = False
        Else
            btn_Next.Enabled = True
        End If
    End Sub

    Private Sub ComboBox_Class1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Class1.SelectedIndexChanged
        If ComboBox_Class1.SelectedIndex = 1 Then
            Dim frm_Select_Class1 As New class_from_Select_Class1(Me)
            frm_Select_Class1.Show()
        End If
    End Sub

    Public Sub ComboBox_Class2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Class2.SelectedIndexChanged
        If ComboBox_Class2.SelectedIndex = 1 Then
            Dim frm_Select_Class2 As New class_form_Select_Class2(Me)
            frm_Select_Class2.Show()
        End If
    End Sub

    Public Function Get_Class1() As String
        Get_Class1 = ComboBox_Class1.Text
    End Function

    Private Sub btn_Previous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Previous.Click
        Save_Data(ListView_Items_Index_Now)
        ListView_Items_Index_Now = ListView_Items_Index_Now - 1
        Buttons_Enable(ListView_Items_Index_Now)
        Show_Data(ListView_Items_Index_Now)
    End Sub

    Private Sub btn_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Next.Click
        Save_Data(ListView_Items_Index_Now)
        ListView_Items_Index_Now = ListView_Items_Index_Now + 1
        Buttons_Enable(ListView_Items_Index_Now)
        Show_Data(ListView_Items_Index_Now)
    End Sub

    Private Sub btn_Guess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guess.Click
        If ComboBox_Guess_Method.SelectedIndex = -1 Then
            MsgBox("请先选择一种猜测方式")
            Exit Sub
        End If
        Dim str_Book_Name As String
        If System.IO.Path.HasExtension(txt_File_Path.Text) Then
            str_Book_Name = System.IO.Path.GetFileNameWithoutExtension(txt_File_Path.Text)
        Else
            str_Book_Name = GetLastFolderName(txt_File_Path.Text)
        End If
        str_Book_Name = Modify_First_Char(str_Book_Name)
        Dim index As Short = First_Index(str_Book_Name)
        Dim length As Short = str_Book_Name.Length
        Dim part1 As String = str_Book_Name
        Dim part2 As String = ""
        If index <> -1 Then
            part1 = Microsoft.VisualBasic.Left(str_Book_Name, index)
            part2 = Microsoft.VisualBasic.Right(str_Book_Name, length - 1 - index)
        End If
        part1 = RidAll(part1)
        part2 = RidAll(part2)
        Select Case ComboBox_Guess_Method.SelectedIndex
            Case 0
                txt_Book_Name.Text = part1
                txt_Author.Text = part2
            Case 1
                txt_Author.Text = part1
                txt_Book_Name.Text = part2
            Case 2
                txt_Book_Name.Text = part1
        End Select
    End Sub

    Private Function GetLastFolderName(ByVal path As String) As String
        Dim b As String = path.Remove(0, System.IO.Path.GetDirectoryName(path).Count)
        GetLastFolderName = b.Replace("\", "")
    End Function

    Private Function Modify_First_Char(ByVal mystring As String) As String
        '【功能】若字符串首字符含有不合要求的字符，
        '则去掉该字符，然后返回修改后的字符串；
        '若均符合要求，则返回原字符串
        Dim myAsc As Short
        myAsc = Asc(mystring.First)
        Select Case myAsc
            Case Is < 0, 48 To 57, 65 To 90, 97 To 122
                Return mystring
            Case Else
                Return mystring.Remove(0, 1)
        End Select
    End Function

    Private Function First_Index(ByVal mystring As String) As Short
        Dim i As Short
        For i = 0 To mystring.Count - 1
            Dim ele As Char = mystring.ElementAt(i)
            Dim num As Short = Asc(ele)
            If num <= 47 And num >= 0 Then
                Return i
                Exit Function
            ElseIf num <= 64 And num >= 58 Then
                Return i
                Exit Function
            ElseIf num <= 91 And num >= 96 Then
                Return i
                Exit Function
            ElseIf num >= 123 Then
                Return i
                Exit Function
            End If
        Next
        Return -1
    End Function

    Private Function RidAll(ByVal mystring As String) As String
        Dim i As Short
        Dim result As String = ""
        For i = 0 To mystring.Count - 1
            Dim ele As Char = mystring.ElementAt(i)
            Dim num As Short = Asc(ele)
            Select Case num
                Case Is < -1, 48 To 57, 65 To 90, 97 To 122
                    result = result & ele
                Case Else
                    Exit Select
            End Select
        Next
        Return result
    End Function

End Class
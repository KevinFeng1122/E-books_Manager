Imports System.Data.OleDb
Imports System.String
Module Module1

    Public Function OpenFolderAndSelectSpecificFile(ByVal szSpecialFileForSelect As String) As Boolean
        'http://blog.csdn.net/tanaya/article/details/668527
        On Error GoTo hErr
        Dim szShellSelect As String
        szShellSelect = "Explorer /select, "
        szShellSelect = szShellSelect & szSpecialFileForSelect
        Shell(szShellSelect, vbNormalFocus)
        OpenFolderAndSelectSpecificFile = True
        Exit Function
hErr:
    End Function

    Public str_pulic_Selected_ListviewItem_Text As String '在Form2 To Dialog1中使用过

    Public Function GetSchemaTable(ByVal connectionString As String) As DataTable
        Using connection As New OleDbConnection(connectionString)
            connection.Open()
            Dim schemaTable As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, _
                New Object() {Nothing, Nothing, Nothing, "TABLE"})
            Return schemaTable
        End Using
    End Function

    Public Function CheckSpecialChar(ByVal inputString As String) As Boolean
        REM 功能：检测（1）给定字符串是否含有非法字符或（2）是否已数字开头；有则返回false
        REM 算法：（1）依次获取inputString的每个字符，判断其ASCII码是否在合理范围内，
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
        '（2）检测开头
        If Asc(inputString.First) <= 57 And Asc(inputString.First) >= 48 Then
            Return False
            Exit Function
        End If
        '余下情况
        Return True
    End Function

End Module

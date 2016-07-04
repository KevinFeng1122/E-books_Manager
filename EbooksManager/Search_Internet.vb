Imports System.Windows.Forms

Public Class Search_Internet

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim WebAddress As String = ""
        If RadioButton1.Checked = True Then WebAddress = "http://book.douban.com/subject_search?search_text="
        If RadioButton2.Checked = True Then WebAddress = "http://www.google.com.hk/search?q="
        If RadioButton3.Checked = True Then WebAddress = "http://www.baidu.com/s?bs=lv&f=8&rsv_bp=1&rsv_spt=3&wd="
        If RadioButton4.Checked = True Then WebAddress = "http://zh.wikipedia.org/wiki/"
        If RadioButton5.Checked = True Then WebAddress = "http://wikipedia.jaylee.cn/?cx=012887051613120601641%3A8bppfezikjs&cof=FORID%3A9&ie=UTF-8&q="
        If RadioButton6.Checked = True Then WebAddress = "http://ebook.lib.apabi.com/List.asp?act=SimpleQuery&DocGroupID=23&lang=gb&all="
        If RadioButton7.Checked = True Then WebAddress = "http://ishare.iask.sina.com.cn/search.php?key="
        WebAddress = WebAddress & str_pulic_Selected_ListviewItem_Text
        System.Diagnostics.Process.Start(WebAddress)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class

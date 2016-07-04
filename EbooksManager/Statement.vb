Public Class Statement
    Dim StartForm As frmStart_Window

    Private Sub class_form_statement_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        StartForm.Show()
    End Sub

    Public Sub New(ByVal pform As Form)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        StartForm = pform
    End Sub
End Class
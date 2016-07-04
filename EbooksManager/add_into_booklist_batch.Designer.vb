<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class class_form_add_into_booklist_batch
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.btn_New_booklist = New System.Windows.Forms.Button
        Me.btn_Cancle = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(23, 15)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(123, 172)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 3
        '
        'btn_New_booklist
        '
        Me.btn_New_booklist.Location = New System.Drawing.Point(164, 27)
        Me.btn_New_booklist.Name = "btn_New_booklist"
        Me.btn_New_booklist.Size = New System.Drawing.Size(58, 31)
        Me.btn_New_booklist.TabIndex = 6
        Me.btn_New_booklist.Text = "新建"
        Me.btn_New_booklist.UseVisualStyleBackColor = True
        '
        'btn_Cancle
        '
        Me.btn_Cancle.Location = New System.Drawing.Point(164, 143)
        Me.btn_Cancle.Name = "btn_Cancle"
        Me.btn_Cancle.Size = New System.Drawing.Size(58, 31)
        Me.btn_Cancle.TabIndex = 5
        Me.btn_Cancle.Text = "放弃"
        Me.btn_Cancle.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(164, 85)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(58, 31)
        Me.btn_OK.TabIndex = 4
        Me.btn_OK.Text = "确定"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'class_form_add_into_booklist_batch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(238, 204)
        Me.Controls.Add(Me.btn_New_booklist)
        Me.Controls.Add(Me.btn_Cancle)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "class_form_add_into_booklist_batch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "添加到书单（批量）"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btn_New_booklist As System.Windows.Forms.Button
    Friend WithEvents btn_Cancle As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
End Class

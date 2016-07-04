<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Change_Class2_Batch
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
        Me.btn_new_Class2 = New System.Windows.Forms.Button
        Me.btn_Cancle = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'btn_new_Class2
        '
        Me.btn_new_Class2.Location = New System.Drawing.Point(170, 48)
        Me.btn_new_Class2.Name = "btn_new_Class2"
        Me.btn_new_Class2.Size = New System.Drawing.Size(69, 28)
        Me.btn_new_Class2.TabIndex = 13
        Me.btn_new_Class2.Text = "新增分类"
        Me.btn_new_Class2.UseVisualStyleBackColor = True
        '
        'btn_Cancle
        '
        Me.btn_Cancle.Location = New System.Drawing.Point(170, 156)
        Me.btn_Cancle.Name = "btn_Cancle"
        Me.btn_Cancle.Size = New System.Drawing.Size(69, 28)
        Me.btn_Cancle.TabIndex = 12
        Me.btn_Cancle.Text = "放弃"
        Me.btn_Cancle.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(170, 103)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(69, 28)
        Me.btn_OK.TabIndex = 11
        Me.btn_OK.Text = "确定"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(24, 24)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(131, 184)
        Me.ListBox1.TabIndex = 10
        '
        'Change_Class2_Batch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 232)
        Me.Controls.Add(Me.btn_new_Class2)
        Me.Controls.Add(Me.btn_Cancle)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Change_Class2_Batch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "选择分类二（批量）"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_new_Class2 As System.Windows.Forms.Button
    Friend WithEvents btn_Cancle As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class

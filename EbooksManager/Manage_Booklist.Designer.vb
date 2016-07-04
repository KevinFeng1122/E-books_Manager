<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class class_form_Manage_Booklist
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(class_form_Manage_Booklist))
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.书名 = New System.Windows.Forms.ColumnHeader
        Me.作者 = New System.Windows.Forms.ColumnHeader
        Me.说明 = New System.Windows.Forms.ColumnHeader
        Me.btn_Add_new = New System.Windows.Forms.Button
        Me.btn_Delete = New System.Windows.Forms.Button
        Me.btn_Rename = New System.Windows.Forms.Button
        Me.btn_To_Excel = New System.Windows.Forms.Button
        Me.btn_Files_Copyto = New System.Windows.Forms.Button
        Me.btn_Go_back = New System.Windows.Forms.Button
        Me.btn_Show = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.open = New System.Windows.Forms.ToolStripMenuItem
        Me.delete = New System.Windows.Forms.ToolStripMenuItem
        Me.note = New System.Windows.Forms.ToolStripMenuItem
        Me.在信息浏览窗口中查看ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(21, 21)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(163, 256)
        Me.ListBox1.TabIndex = 0
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.书名, Me.作者, Me.说明})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(201, 21)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(449, 256)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        '书名
        '
        Me.书名.Text = "书名"
        Me.书名.Width = 120
        '
        '作者
        '
        Me.作者.Text = "作者"
        Me.作者.Width = 80
        '
        '说明
        '
        Me.说明.Text = "说明"
        Me.说明.Width = 240
        '
        'btn_Add_new
        '
        Me.btn_Add_new.AutoSize = True
        Me.btn_Add_new.Location = New System.Drawing.Point(109, 302)
        Me.btn_Add_new.Name = "btn_Add_new"
        Me.btn_Add_new.Size = New System.Drawing.Size(75, 34)
        Me.btn_Add_new.TabIndex = 2
        Me.btn_Add_new.Text = "新建书单"
        Me.btn_Add_new.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.AutoSize = True
        Me.btn_Delete.Location = New System.Drawing.Point(201, 302)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(75, 34)
        Me.btn_Delete.TabIndex = 3
        Me.btn_Delete.Text = "删除书单"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Rename
        '
        Me.btn_Rename.AutoSize = True
        Me.btn_Rename.Location = New System.Drawing.Point(293, 302)
        Me.btn_Rename.Name = "btn_Rename"
        Me.btn_Rename.Size = New System.Drawing.Size(75, 34)
        Me.btn_Rename.TabIndex = 4
        Me.btn_Rename.Text = "重命名书单"
        Me.btn_Rename.UseVisualStyleBackColor = True
        '
        'btn_To_Excel
        '
        Me.btn_To_Excel.AutoSize = True
        Me.btn_To_Excel.Location = New System.Drawing.Point(385, 302)
        Me.btn_To_Excel.Name = "btn_To_Excel"
        Me.btn_To_Excel.Size = New System.Drawing.Size(81, 34)
        Me.btn_To_Excel.TabIndex = 5
        Me.btn_To_Excel.Text = "输出到Excel"
        Me.btn_To_Excel.UseVisualStyleBackColor = True
        '
        'btn_Files_Copyto
        '
        Me.btn_Files_Copyto.AutoSize = True
        Me.btn_Files_Copyto.Location = New System.Drawing.Point(483, 302)
        Me.btn_Files_Copyto.Name = "btn_Files_Copyto"
        Me.btn_Files_Copyto.Size = New System.Drawing.Size(75, 34)
        Me.btn_Files_Copyto.TabIndex = 6
        Me.btn_Files_Copyto.Text = "文档打包"
        Me.btn_Files_Copyto.UseVisualStyleBackColor = True
        '
        'btn_Go_back
        '
        Me.btn_Go_back.AutoSize = True
        Me.btn_Go_back.Location = New System.Drawing.Point(575, 302)
        Me.btn_Go_back.Name = "btn_Go_back"
        Me.btn_Go_back.Size = New System.Drawing.Size(75, 34)
        Me.btn_Go_back.TabIndex = 7
        Me.btn_Go_back.Text = "返回上一级"
        Me.btn_Go_back.UseVisualStyleBackColor = True
        '
        'btn_Show
        '
        Me.btn_Show.Location = New System.Drawing.Point(17, 302)
        Me.btn_Show.Name = "btn_Show"
        Me.btn_Show.Size = New System.Drawing.Size(75, 34)
        Me.btn_Show.TabIndex = 8
        Me.btn_Show.Text = "显示书单"
        Me.btn_Show.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.open, Me.delete, Me.note, Me.在信息浏览窗口中查看ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(197, 92)
        '
        'open
        '
        Me.open.Name = "open"
        Me.open.Size = New System.Drawing.Size(196, 22)
        Me.open.Text = "打开"
        '
        'delete
        '
        Me.delete.Name = "delete"
        Me.delete.Size = New System.Drawing.Size(196, 22)
        Me.delete.Text = "从该书单中删除"
        '
        'note
        '
        Me.note.Name = "note"
        Me.note.Size = New System.Drawing.Size(196, 22)
        Me.note.Text = "修改说明"
        '
        '在信息浏览窗口中查看ToolStripMenuItem
        '
        Me.在信息浏览窗口中查看ToolStripMenuItem.Name = "在信息浏览窗口中查看ToolStripMenuItem"
        Me.在信息浏览窗口中查看ToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.在信息浏览窗口中查看ToolStripMenuItem.Text = "在信息浏览窗口中查看"
        '
        'class_form_Manage_Booklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 357)
        Me.Controls.Add(Me.btn_Show)
        Me.Controls.Add(Me.btn_Go_back)
        Me.Controls.Add(Me.btn_Files_Copyto)
        Me.Controls.Add(Me.btn_To_Excel)
        Me.Controls.Add(Me.btn_Rename)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Add_new)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ListBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "class_form_Manage_Booklist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "自定义书单"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btn_Add_new As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Rename As System.Windows.Forms.Button
    Friend WithEvents btn_To_Excel As System.Windows.Forms.Button
    Friend WithEvents btn_Files_Copyto As System.Windows.Forms.Button
    Friend WithEvents btn_Go_back As System.Windows.Forms.Button
    Friend WithEvents btn_Show As System.Windows.Forms.Button
    Friend WithEvents 书名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents 作者 As System.Windows.Forms.ColumnHeader
    Friend WithEvents 说明 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents open As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents note As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 在信息浏览窗口中查看ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class

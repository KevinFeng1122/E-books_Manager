<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class class_form_Recent_Opened_Files
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(class_form_Recent_Opened_Files))
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.书名 = New System.Windows.Forms.ColumnHeader
        Me.作者 = New System.Windows.Forms.ColumnHeader
        Me.打开时间 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.在信息浏览窗口中查看ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.书名, Me.作者, Me.打开时间})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(455, 310)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        '书名
        '
        Me.书名.Text = "书名"
        Me.书名.Width = 141
        '
        '作者
        '
        Me.作者.Text = "作者"
        Me.作者.Width = 108
        '
        '打开时间
        '
        Me.打开时间.Text = "打开时间"
        Me.打开时间.Width = 188
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开ToolStripMenuItem, Me.在信息浏览窗口中查看ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(197, 48)
        '
        '打开ToolStripMenuItem
        '
        Me.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem"
        Me.打开ToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.打开ToolStripMenuItem.Text = "打开"
        '
        '在信息浏览窗口中查看ToolStripMenuItem
        '
        Me.在信息浏览窗口中查看ToolStripMenuItem.Name = "在信息浏览窗口中查看ToolStripMenuItem"
        Me.在信息浏览窗口中查看ToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.在信息浏览窗口中查看ToolStripMenuItem.Text = "在信息浏览窗口中查看"
        '
        'class_form_Recent_Opened_Files
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 310)
        Me.Controls.Add(Me.ListView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "class_form_Recent_Opened_Files"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "最近打开文档"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents 书名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents 作者 As System.Windows.Forms.ColumnHeader
    Friend WithEvents 打开时间 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 打开ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 在信息浏览窗口中查看ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

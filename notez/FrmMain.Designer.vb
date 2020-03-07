Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class FrmMain
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BtnRenew = New System.Windows.Forms.Button()
        Me.TxtMore = New System.Windows.Forms.TextBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnAccept = New System.Windows.Forms.Button()
        Me.LstNotes = New System.Windows.Forms.ListBox()
        Me.CMSave = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AutoCollectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TopMostToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MergeTrashToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClickToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TmrCollect = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.CMSave.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnRenew)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtMore)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnClear)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnAccept)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LstNotes)
        Me.SplitContainer1.Size = New System.Drawing.Size(160, 263)
        Me.SplitContainer1.SplitterDistance = 62
        Me.SplitContainer1.TabIndex = 1
        Me.SplitContainer1.TabStop = False
        '
        'BtnRenew
        '
        Me.BtnRenew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRenew.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnRenew.Location = New System.Drawing.Point(0, 0)
        Me.BtnRenew.Name = "BtnRenew"
        Me.BtnRenew.Size = New System.Drawing.Size(160, 27)
        Me.BtnRenew.TabIndex = 3
        Me.BtnRenew.TabStop = False
        Me.BtnRenew.UseVisualStyleBackColor = False
        '
        'TxtMore
        '
        Me.TxtMore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TxtMore.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtMore.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtMore.Location = New System.Drawing.Point(-37, 33)
        Me.TxtMore.Multiline = True
        Me.TxtMore.Name = "TxtMore"
        Me.TxtMore.Size = New System.Drawing.Size(235, 29)
        Me.TxtMore.TabIndex = 0
        '
        'BtnClear
        '
        Me.BtnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClear.Location = New System.Drawing.Point(160, 2)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(75, 23)
        Me.BtnClear.TabIndex = 2
        Me.BtnClear.TabStop = False
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnAccept
        '
        Me.BtnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAccept.Location = New System.Drawing.Point(157, -56)
        Me.BtnAccept.Name = "BtnAccept"
        Me.BtnAccept.Size = New System.Drawing.Size(75, 23)
        Me.BtnAccept.TabIndex = 1
        Me.BtnAccept.TabStop = False
        Me.BtnAccept.Text = "Accept"
        Me.BtnAccept.UseVisualStyleBackColor = True
        '
        'LstNotes
        '
        Me.LstNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LstNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstNotes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LstNotes.FormattingEnabled = True
        Me.LstNotes.Location = New System.Drawing.Point(0, 0)
        Me.LstNotes.Name = "LstNotes"
        Me.LstNotes.Size = New System.Drawing.Size(160, 197)
        Me.LstNotes.TabIndex = 1
        '
        'CMSave
        '
        Me.CMSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMSave.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoCollectToolStripMenuItem, Me.SplitLinesToolStripMenuItem, Me.CheckListToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.TopMostToolStripMenuItem, Me.AutomateToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.CopyAllToolStripMenuItem, Me.ClearAllToolStripMenuItem})
        Me.CMSave.Name = "CMSave"
        Me.CMSave.Size = New System.Drawing.Size(143, 224)
        '
        'AutoCollectToolStripMenuItem
        '
        Me.AutoCollectToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.AutoCollectToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.AutoCollectToolStripMenuItem.Name = "AutoCollectToolStripMenuItem"
        Me.AutoCollectToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.AutoCollectToolStripMenuItem.Text = "Auto-Collect"
        '
        'SplitLinesToolStripMenuItem
        '
        Me.SplitLinesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SplitLinesToolStripMenuItem.Name = "SplitLinesToolStripMenuItem"
        Me.SplitLinesToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SplitLinesToolStripMenuItem.Text = "Split Lines"
        '
        'CheckListToolStripMenuItem
        '
        Me.CheckListToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.CheckListToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CheckListToolStripMenuItem.Name = "CheckListToolStripMenuItem"
        Me.CheckListToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.CheckListToolStripMenuItem.Text = "Check List"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'TopMostToolStripMenuItem
        '
        Me.TopMostToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TopMostToolStripMenuItem.Name = "TopMostToolStripMenuItem"
        Me.TopMostToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.TopMostToolStripMenuItem.Text = "Top Most"
        '
        'AutomateToolStripMenuItem
        '
        Me.AutomateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MergeTrashToolStripMenuItem, Me.ClickToolStripMenuItem})
        Me.AutomateToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.AutomateToolStripMenuItem.Name = "AutomateToolStripMenuItem"
        Me.AutomateToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.AutomateToolStripMenuItem.Text = "Automate"
        '
        'MergeTrashToolStripMenuItem
        '
        Me.MergeTrashToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MergeTrashToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.MergeTrashToolStripMenuItem.Name = "MergeTrashToolStripMenuItem"
        Me.MergeTrashToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.MergeTrashToolStripMenuItem.Text = "MCK PACS Merge Trash"
        '
        'ClickToolStripMenuItem
        '
        Me.ClickToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClickToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClickToolStripMenuItem.Name = "ClickToolStripMenuItem"
        Me.ClickToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ClickToolStripMenuItem.Text = "Capture2Text"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'CopyAllToolStripMenuItem
        '
        Me.CopyAllToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CopyAllToolStripMenuItem.Name = "CopyAllToolStripMenuItem"
        Me.CopyAllToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.CopyAllToolStripMenuItem.Text = "Copy All"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
        '
        'TmrCollect
        '
        Me.TmrCollect.Interval = 2500
        '
        'FrmMain
        '
        Me.AcceptButton = Me.BtnAccept
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CancelButton = Me.BtnClear
        Me.ClientSize = New System.Drawing.Size(160, 263)
        Me.Controls.Add(Me.SplitContainer1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMain"
        Me.Text = "Notez"
        Me.TopMost = True
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.CMSave.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents BtnRenew As Button
    Friend WithEvents LstNotes As ListBox
    Friend WithEvents TxtMore As TextBox
    Friend WithEvents BtnAccept As Button
    Friend WithEvents BtnClear As Button
    Friend WithEvents CMSave As ContextMenuStrip
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TmrCollect As Timer
    Friend WithEvents AutoCollectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TopMostToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutomateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MergeTrashToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClickToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitLinesToolStripMenuItem As ToolStripMenuItem
End Class

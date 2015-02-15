<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rubiks_cube
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.white_button = New System.Windows.Forms.Button()
        Me.red_button = New System.Windows.Forms.Button()
        Me.blue_button = New System.Windows.Forms.Button()
        Me.green_button = New System.Windows.Forms.Button()
        Me.orange_button = New System.Windows.Forms.Button()
        Me.yellow_button = New System.Windows.Forms.Button()
        Me.invalidator = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Reset_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPlay_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Scramble_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CubeRotate_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.X_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.XPrime_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Y_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.YPrime_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Z_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZPrime_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Help_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Scramble_output = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'white_button
        '
        Me.white_button.BackColor = System.Drawing.Color.White
        Me.white_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.white_button.Location = New System.Drawing.Point(12, 97)
        Me.white_button.Name = "white_button"
        Me.white_button.Size = New System.Drawing.Size(50, 50)
        Me.white_button.TabIndex = 0
        Me.white_button.UseVisualStyleBackColor = False
        '
        'red_button
        '
        Me.red_button.BackColor = System.Drawing.Color.Red
        Me.red_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.red_button.Location = New System.Drawing.Point(12, 153)
        Me.red_button.Name = "red_button"
        Me.red_button.Size = New System.Drawing.Size(50, 50)
        Me.red_button.TabIndex = 1
        Me.red_button.UseVisualStyleBackColor = False
        '
        'blue_button
        '
        Me.blue_button.BackColor = System.Drawing.Color.Blue
        Me.blue_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.blue_button.Location = New System.Drawing.Point(12, 209)
        Me.blue_button.Name = "blue_button"
        Me.blue_button.Size = New System.Drawing.Size(50, 50)
        Me.blue_button.TabIndex = 2
        Me.blue_button.UseVisualStyleBackColor = False
        '
        'green_button
        '
        Me.green_button.BackColor = System.Drawing.Color.Green
        Me.green_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.green_button.Location = New System.Drawing.Point(12, 265)
        Me.green_button.Name = "green_button"
        Me.green_button.Size = New System.Drawing.Size(50, 50)
        Me.green_button.TabIndex = 3
        Me.green_button.UseVisualStyleBackColor = False
        '
        'orange_button
        '
        Me.orange_button.BackColor = System.Drawing.Color.Orange
        Me.orange_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.orange_button.Location = New System.Drawing.Point(12, 323)
        Me.orange_button.Name = "orange_button"
        Me.orange_button.Size = New System.Drawing.Size(50, 50)
        Me.orange_button.TabIndex = 4
        Me.orange_button.UseVisualStyleBackColor = False
        '
        'yellow_button
        '
        Me.yellow_button.BackColor = System.Drawing.Color.Yellow
        Me.yellow_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.yellow_button.Location = New System.Drawing.Point(12, 379)
        Me.yellow_button.Name = "yellow_button"
        Me.yellow_button.Size = New System.Drawing.Size(50, 50)
        Me.yellow_button.TabIndex = 5
        Me.yellow_button.UseVisualStyleBackColor = False
        '
        'invalidator
        '
        Me.invalidator.Enabled = True
        Me.invalidator.Interval = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Reset_Menu, Me.EditPlay_Menu, Me.Scramble_Menu, Me.CubeRotate_Menu, Me.Help_Menu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(734, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Reset_Menu
        '
        Me.Reset_Menu.Name = "Reset_Menu"
        Me.Reset_Menu.Size = New System.Drawing.Size(47, 20)
        Me.Reset_Menu.Text = "Reset"
        '
        'EditPlay_Menu
        '
        Me.EditPlay_Menu.Name = "EditPlay_Menu"
        Me.EditPlay_Menu.Size = New System.Drawing.Size(73, 20)
        Me.EditPlay_Menu.Text = "Edit Mode"
        '
        'Scramble_Menu
        '
        Me.Scramble_Menu.Name = "Scramble_Menu"
        Me.Scramble_Menu.Size = New System.Drawing.Size(68, 20)
        Me.Scramble_Menu.Text = "Scramble"
        '
        'CubeRotate_Menu
        '
        Me.CubeRotate_Menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.X_Menu, Me.XPrime_Menu, Me.Y_Menu, Me.YPrime_Menu, Me.Z_Menu, Me.ZPrime_Menu})
        Me.CubeRotate_Menu.Name = "CubeRotate_Menu"
        Me.CubeRotate_Menu.Size = New System.Drawing.Size(84, 20)
        Me.CubeRotate_Menu.Text = "Cube Rotate"
        '
        'X_Menu
        '
        Me.X_Menu.Name = "X_Menu"
        Me.X_Menu.Size = New System.Drawing.Size(84, 22)
        Me.X_Menu.Text = "X"
        '
        'XPrime_Menu
        '
        Me.XPrime_Menu.Name = "XPrime_Menu"
        Me.XPrime_Menu.Size = New System.Drawing.Size(84, 22)
        Me.XPrime_Menu.Text = "X'"
        '
        'Y_Menu
        '
        Me.Y_Menu.Name = "Y_Menu"
        Me.Y_Menu.Size = New System.Drawing.Size(84, 22)
        Me.Y_Menu.Text = "Y"
        '
        'YPrime_Menu
        '
        Me.YPrime_Menu.Name = "YPrime_Menu"
        Me.YPrime_Menu.Size = New System.Drawing.Size(84, 22)
        Me.YPrime_Menu.Text = "Y'"
        '
        'Z_Menu
        '
        Me.Z_Menu.Name = "Z_Menu"
        Me.Z_Menu.Size = New System.Drawing.Size(84, 22)
        Me.Z_Menu.Text = "Z"
        '
        'ZPrime_Menu
        '
        Me.ZPrime_Menu.Name = "ZPrime_Menu"
        Me.ZPrime_Menu.Size = New System.Drawing.Size(84, 22)
        Me.ZPrime_Menu.Text = "Z'"
        '
        'Help_Menu
        '
        Me.Help_Menu.Name = "Help_Menu"
        Me.Help_Menu.Size = New System.Drawing.Size(44, 20)
        Me.Help_Menu.Text = "Help"
        '
        'Scramble_output
        '
        Me.Scramble_output.ForeColor = System.Drawing.Color.White
        Me.Scramble_output.Location = New System.Drawing.Point(12, 498)
        Me.Scramble_output.Name = "Scramble_output"
        Me.Scramble_output.Size = New System.Drawing.Size(710, 23)
        Me.Scramble_output.TabIndex = 13
        Me.Scramble_output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rubiks_cube
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(734, 530)
        Me.Controls.Add(Me.Scramble_output)
        Me.Controls.Add(Me.yellow_button)
        Me.Controls.Add(Me.orange_button)
        Me.Controls.Add(Me.green_button)
        Me.Controls.Add(Me.blue_button)
        Me.Controls.Add(Me.red_button)
        Me.Controls.Add(Me.white_button)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "rubiks_cube"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rubik's Cube"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents white_button As System.Windows.Forms.Button
    Friend WithEvents red_button As System.Windows.Forms.Button
    Friend WithEvents blue_button As System.Windows.Forms.Button
    Friend WithEvents green_button As System.Windows.Forms.Button
    Friend WithEvents orange_button As System.Windows.Forms.Button
    Friend WithEvents yellow_button As System.Windows.Forms.Button
    Friend WithEvents invalidator As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Reset_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Help_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditPlay_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Scramble_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CubeRotate_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents X_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XPrime_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Y_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YPrime_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Z_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZPrime_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Scramble_output As System.Windows.Forms.Label

End Class

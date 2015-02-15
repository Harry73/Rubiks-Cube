Public Class rubiks_cube
    Dim squarecolors(54) As Brush 'saves the color of each square
    Dim squarepoints(54, 4) As Point 'insane array of all the points used for each square
    Dim selectedcolor As Brush = Brushes.Gray 'records the color the user clicked last so that squares may change color
    Dim clockwise As Boolean = True
    Dim mode As String = "play"
    Dim shifter As Integer = 20 'i added the menu strip later and then had to move everything down, so just in case i made it a variable to shift everything
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim helper(4) As Point 'used to convert the 2d array of squarepoints into a 1d array so it can be drawn
        For i As Integer = 1 To 54
            For j As Integer = 0 To 4
                helper(j) = squarepoints(i, j) 'creating the 1d array
            Next
            g.FillPolygon(squarecolors(i), helper) 'drawing the "squares" since theyre not squares
        Next
        g.DrawLine(Pens.Black, 400, 200 + shifter, 280, 140 + shifter)
        g.DrawLine(Pens.Black, 400, 200 + shifter, 400, 335 + shifter)
        g.DrawLine(Pens.Black, 400, 200 + shifter, 520, 140 + shifter)
    End Sub
    Private Sub yellow_button_Click(sender As Object, e As EventArgs) Handles yellow_button.Click
        selectedcolor = New SolidBrush(Color.Yellow)
    End Sub
    Private Sub red_button_Click(sender As Object, e As EventArgs) Handles red_button.Click
        selectedcolor = New SolidBrush(Color.Red)
    End Sub
    Private Sub blue_button_Click(sender As Object, e As EventArgs) Handles blue_button.Click
        selectedcolor = New SolidBrush(Color.Blue)
    End Sub
    Private Sub green_button_Click(sender As Object, e As EventArgs) Handles green_button.Click
        selectedcolor = New SolidBrush(Color.Green)
    End Sub
    Private Sub orange_button_Click(sender As Object, e As EventArgs) Handles orange_button.Click
        selectedcolor = New SolidBrush(Color.Orange)
    End Sub
    Private Sub white_button_Click(sender As Object, e As EventArgs) Handles white_button.Click
        selectedcolor = New SolidBrush(Color.White)
    End Sub
    Private Sub rubiks_cube_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If mode = "play" Then
            If e.KeyCode = Keys.R Then
                If clockwise = True Then
                    rightrotate("clock")
                ElseIf clockwise = False Then
                    rightrotate("counterclock")
                End If
            ElseIf e.KeyCode = Keys.L Then
                If clockwise = True Then
                    leftrotate("clock")
                ElseIf clockwise = False Then
                    leftrotate("counterclock")
                End If
            ElseIf e.KeyCode = Keys.D Then
                If clockwise = True Then
                    bottomrotate("clock")
                ElseIf clockwise = False Then
                    bottomrotate("counterclock")
                End If
            ElseIf e.KeyCode = Keys.B Then
                If clockwise = True Then
                    backrotate("clock")
                ElseIf clockwise = False Then
                    backrotate("counterclock")
                End If
            ElseIf e.KeyCode = Keys.F Then
                If clockwise = True Then
                    frontrotate("clock")
                ElseIf clockwise = False Then
                    frontrotate("counterclock")
                End If
            ElseIf e.KeyCode = Keys.U Then
                If clockwise = True Then
                    toprotate("clock")
                ElseIf clockwise = False Then
                    toprotate("counterclock")
                End If
            ElseIf e.KeyCode = Keys.X Then
                If clockwise = True Then
                    xrotate("normal")
                ElseIf clockwise = False Then
                    xrotate("inverted")
                End If
            ElseIf e.KeyCode = Keys.Y Then
                If clockwise = True Then
                    yrotate("normal")
                ElseIf clockwise = False Then
                    yrotate("inverted")
                End If
            ElseIf e.KeyCode = Keys.Z Then
                If clockwise = True Then
                    zrotate("normal")
                ElseIf clockwise = False Then
                    zrotate("inverted")
                End If
            End If
            If e.KeyCode = Keys.Space Then
                clockwise = False
            End If
        ElseIf mode = "edit" Then
            If e.KeyCode = Keys.R Then
                selectedcolor = Brushes.Red
            ElseIf e.KeyCode = Keys.W Then
                selectedcolor = Brushes.White
            ElseIf e.KeyCode = Keys.O Then
                selectedcolor = Brushes.Orange
            ElseIf e.KeyCode = Keys.G Then
                selectedcolor = Brushes.Green
            ElseIf e.KeyCode = Keys.B Then
                selectedcolor = Brushes.Blue
            ElseIf e.KeyCode = Keys.Y Then
                selectedcolor = Brushes.Yellow
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            Help_Menu_Click(sender, e)
        End If
    End Sub
    Private Sub rubiks_cube_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Space Then
            clockwise = True
        End If
    End Sub
    Private Sub rubiks_cube_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'setting the initial brush colors
        For i As Integer = 1 To 9
            squarecolors(i) = Brushes.White
        Next
        For i As Integer = 10 To 18
            squarecolors(i) = Brushes.Red
        Next
        For i As Integer = 19 To 27
            squarecolors(i) = Brushes.Blue
        Next
        For i As Integer = 28 To 36
            squarecolors(i) = Brushes.Green
        Next
        For i As Integer = 37 To 45
            squarecolors(i) = Brushes.Orange
        Next
        For i As Integer = 46 To 54
            squarecolors(i) = Brushes.Yellow
        Next
        'create all the points for the polygons cause i dont know any better way to do it
        'well i do but i was too lazy to think about for loops so i did this madness.  which was stupid really but oh well. 
        'top face
        squarepoints(1, 0) = New Point(400, 80 + shifter)
        squarepoints(1, 1) = New Point(360, 100 + shifter)
        squarepoints(1, 2) = New Point(400, 120 + shifter)
        squarepoints(1, 3) = New Point(440, 100 + shifter)
        squarepoints(1, 4) = New Point(400, 80 + shifter)

        squarepoints(2, 0) = New Point(360, 100 + shifter)
        squarepoints(2, 1) = New Point(320, 120 + shifter)
        squarepoints(2, 2) = New Point(360, 140 + shifter)
        squarepoints(2, 3) = New Point(400, 120 + shifter)
        squarepoints(2, 4) = New Point(360, 100 + shifter)

        squarepoints(3, 0) = New Point(320, 120 + shifter)
        squarepoints(3, 1) = New Point(280, 140 + shifter)
        squarepoints(3, 2) = New Point(320, 160 + shifter)
        squarepoints(3, 3) = New Point(360, 140 + shifter)
        squarepoints(3, 4) = New Point(320, 120 + shifter)

        squarepoints(4, 0) = New Point(440, 100 + shifter)
        squarepoints(4, 1) = New Point(400, 120 + shifter)
        squarepoints(4, 2) = New Point(440, 140 + shifter)
        squarepoints(4, 3) = New Point(480, 120 + shifter)
        squarepoints(4, 4) = New Point(440, 100 + shifter)

        squarepoints(5, 0) = New Point(400, 120 + shifter)
        squarepoints(5, 1) = New Point(360, 140 + shifter)
        squarepoints(5, 2) = New Point(400, 160 + shifter)
        squarepoints(5, 3) = New Point(440, 140 + shifter)
        squarepoints(5, 4) = New Point(400, 120 + shifter)

        squarepoints(6, 0) = New Point(360, 140 + shifter)
        squarepoints(6, 1) = New Point(320, 160 + shifter)
        squarepoints(6, 2) = New Point(360, 180 + shifter)
        squarepoints(6, 3) = New Point(400, 160 + shifter)
        squarepoints(6, 4) = New Point(360, 140 + shifter)

        squarepoints(7, 0) = New Point(480, 120 + shifter)
        squarepoints(7, 1) = New Point(440, 140 + shifter)
        squarepoints(7, 2) = New Point(480, 160 + shifter)
        squarepoints(7, 3) = New Point(520, 140 + shifter)
        squarepoints(7, 4) = New Point(480, 120 + shifter)

        squarepoints(8, 0) = New Point(440, 140 + shifter)
        squarepoints(8, 1) = New Point(400, 160 + shifter)
        squarepoints(8, 2) = New Point(440, 180 + shifter)
        squarepoints(8, 3) = New Point(480, 160 + shifter)
        squarepoints(8, 4) = New Point(440, 140 + shifter)

        squarepoints(9, 0) = New Point(400, 160 + shifter)
        squarepoints(9, 1) = New Point(360, 180 + shifter)
        squarepoints(9, 2) = New Point(400, 200 + shifter)
        squarepoints(9, 3) = New Point(440, 180 + shifter)
        squarepoints(9, 4) = New Point(400, 160 + shifter)

        'front face (kinda left-ish face)
        squarepoints(10, 0) = New Point(280, 140 + shifter)
        squarepoints(10, 1) = New Point(280, 185 + shifter)
        squarepoints(10, 2) = New Point(320, 205 + shifter)
        squarepoints(10, 3) = New Point(320, 160 + shifter)
        squarepoints(10, 4) = New Point(280, 140 + shifter)

        squarepoints(11, 0) = New Point(280, 185 + shifter)
        squarepoints(11, 1) = New Point(280, 230 + shifter)
        squarepoints(11, 2) = New Point(320, 250 + shifter)
        squarepoints(11, 3) = New Point(320, 205 + shifter)
        squarepoints(11, 4) = New Point(280, 185 + shifter)

        squarepoints(12, 0) = New Point(280, 230 + shifter)
        squarepoints(12, 1) = New Point(280, 275 + shifter)
        squarepoints(12, 2) = New Point(320, 295 + shifter)
        squarepoints(12, 3) = New Point(320, 250 + shifter)
        squarepoints(12, 4) = New Point(280, 230 + shifter)

        squarepoints(13, 0) = New Point(320, 160 + shifter)
        squarepoints(13, 1) = New Point(320, 205 + shifter)
        squarepoints(13, 2) = New Point(360, 225 + shifter)
        squarepoints(13, 3) = New Point(360, 180 + shifter)
        squarepoints(13, 4) = New Point(320, 160 + shifter)

        squarepoints(14, 0) = New Point(320, 205 + shifter)
        squarepoints(14, 1) = New Point(320, 250 + shifter)
        squarepoints(14, 2) = New Point(360, 270 + shifter)
        squarepoints(14, 3) = New Point(360, 225 + shifter)
        squarepoints(14, 4) = New Point(320, 205 + shifter)

        squarepoints(15, 0) = New Point(320, 250 + shifter)
        squarepoints(15, 1) = New Point(320, 295 + shifter)
        squarepoints(15, 2) = New Point(360, 315 + shifter)
        squarepoints(15, 3) = New Point(360, 270 + shifter)
        squarepoints(15, 4) = New Point(320, 250 + shifter)

        squarepoints(16, 0) = New Point(360, 180 + shifter)
        squarepoints(16, 1) = New Point(360, 225 + shifter)
        squarepoints(16, 2) = New Point(400, 245 + shifter)
        squarepoints(16, 3) = New Point(400, 200 + shifter)
        squarepoints(16, 4) = New Point(360, 180 + shifter)

        squarepoints(17, 0) = New Point(360, 225 + shifter)
        squarepoints(17, 1) = New Point(360, 270 + shifter)
        squarepoints(17, 2) = New Point(400, 290 + shifter)
        squarepoints(17, 3) = New Point(400, 245 + shifter)
        squarepoints(17, 4) = New Point(360, 225 + shifter)

        squarepoints(18, 0) = New Point(360, 270 + shifter)
        squarepoints(18, 1) = New Point(360, 315 + shifter)
        squarepoints(18, 2) = New Point(400, 335 + shifter)
        squarepoints(18, 3) = New Point(400, 290 + shifter)
        squarepoints(18, 4) = New Point(360, 270 + shifter)

        'right face (kinda right-ish face)
        squarepoints(19, 0) = New Point(400, 200 + shifter)
        squarepoints(19, 1) = New Point(400, 245 + shifter)
        squarepoints(19, 2) = New Point(440, 225 + shifter)
        squarepoints(19, 3) = New Point(440, 180 + shifter)
        squarepoints(19, 4) = New Point(400, 200 + shifter)

        squarepoints(20, 0) = New Point(400, 245 + shifter)
        squarepoints(20, 1) = New Point(400, 290 + shifter)
        squarepoints(20, 2) = New Point(440, 270 + shifter)
        squarepoints(20, 3) = New Point(440, 225 + shifter)
        squarepoints(20, 4) = New Point(400, 245 + shifter)

        squarepoints(21, 0) = New Point(400, 290 + shifter)
        squarepoints(21, 1) = New Point(400, 335 + shifter)
        squarepoints(21, 2) = New Point(440, 315 + shifter)
        squarepoints(21, 3) = New Point(440, 270 + shifter)
        squarepoints(21, 4) = New Point(400, 290 + shifter)

        squarepoints(22, 0) = New Point(440, 180 + shifter)
        squarepoints(22, 1) = New Point(440, 225 + shifter)
        squarepoints(22, 2) = New Point(480, 205 + shifter)
        squarepoints(22, 3) = New Point(480, 160 + shifter)
        squarepoints(22, 4) = New Point(440, 180 + shifter)

        squarepoints(23, 0) = New Point(440, 225 + shifter)
        squarepoints(23, 1) = New Point(440, 270 + shifter)
        squarepoints(23, 2) = New Point(480, 250 + shifter)
        squarepoints(23, 3) = New Point(480, 205 + shifter)
        squarepoints(23, 4) = New Point(440, 225 + shifter)

        squarepoints(24, 0) = New Point(440, 270 + shifter)
        squarepoints(24, 1) = New Point(440, 315 + shifter)
        squarepoints(24, 2) = New Point(480, 295 + shifter)
        squarepoints(24, 3) = New Point(480, 250 + shifter)
        squarepoints(24, 4) = New Point(440, 270 + shifter)

        squarepoints(25, 0) = New Point(480, 160 + shifter)
        squarepoints(25, 1) = New Point(480, 205 + shifter)
        squarepoints(25, 2) = New Point(520, 185 + shifter)
        squarepoints(25, 3) = New Point(520, 140 + shifter)
        squarepoints(25, 4) = New Point(480, 160 + shifter)

        squarepoints(26, 0) = New Point(480, 205 + shifter)
        squarepoints(26, 1) = New Point(480, 250 + shifter)
        squarepoints(26, 2) = New Point(520, 230 + shifter)
        squarepoints(26, 3) = New Point(520, 185 + shifter)
        squarepoints(26, 4) = New Point(480, 205 + shifter)

        squarepoints(27, 0) = New Point(480, 250 + shifter)
        squarepoints(27, 1) = New Point(480, 295 + shifter)
        squarepoints(27, 2) = New Point(520, 275 + shifter)
        squarepoints(27, 3) = New Point(520, 230 + shifter)
        squarepoints(27, 4) = New Point(480, 250 + shifter)

        'left face
        squarepoints(28, 0) = New Point(180, 60 + shifter)
        squarepoints(28, 1) = New Point(180, 105 + shifter)
        squarepoints(28, 2) = New Point(140, 125 + shifter)
        squarepoints(28, 3) = New Point(140, 80 + shifter)
        squarepoints(28, 4) = New Point(180, 60 + shifter)

        squarepoints(29, 0) = New Point(180, 105 + shifter)
        squarepoints(29, 1) = New Point(180, 150 + shifter)
        squarepoints(29, 2) = New Point(140, 170 + shifter)
        squarepoints(29, 3) = New Point(140, 125 + shifter)
        squarepoints(29, 4) = New Point(180, 105 + shifter)

        squarepoints(30, 0) = New Point(180, 150 + shifter)
        squarepoints(30, 1) = New Point(180, 195 + shifter)
        squarepoints(30, 2) = New Point(140, 215 + shifter)
        squarepoints(30, 3) = New Point(140, 170 + shifter)
        squarepoints(30, 4) = New Point(180, 150 + shifter)

        squarepoints(31, 0) = New Point(220, 40 + shifter)
        squarepoints(31, 1) = New Point(220, 85 + shifter)
        squarepoints(31, 2) = New Point(180, 105 + shifter)
        squarepoints(31, 3) = New Point(180, 60 + shifter)
        squarepoints(31, 4) = New Point(220, 40 + shifter)

        squarepoints(32, 0) = New Point(220, 85 + shifter)
        squarepoints(32, 1) = New Point(220, 130 + shifter)
        squarepoints(32, 2) = New Point(180, 150 + shifter)
        squarepoints(32, 3) = New Point(180, 105 + shifter)
        squarepoints(32, 4) = New Point(220, 85 + shifter)

        squarepoints(33, 0) = New Point(220, 130 + shifter)
        squarepoints(33, 1) = New Point(220, 175 + shifter)
        squarepoints(33, 2) = New Point(180, 195 + shifter)
        squarepoints(33, 3) = New Point(180, 150 + shifter)
        squarepoints(33, 4) = New Point(220, 130 + shifter)

        squarepoints(34, 0) = New Point(260, 20 + shifter)
        squarepoints(34, 1) = New Point(260, 65 + shifter)
        squarepoints(34, 2) = New Point(220, 85 + shifter)
        squarepoints(34, 3) = New Point(220, 40 + shifter)
        squarepoints(34, 4) = New Point(260, 20 + shifter)

        squarepoints(35, 0) = New Point(260, 65 + shifter)
        squarepoints(35, 1) = New Point(260, 110 + shifter)
        squarepoints(35, 2) = New Point(220, 130 + shifter)
        squarepoints(35, 3) = New Point(220, 85 + shifter)
        squarepoints(35, 4) = New Point(260, 65 + shifter)

        squarepoints(36, 0) = New Point(260, 110 + shifter)
        squarepoints(36, 1) = New Point(260, 155 + shifter)
        squarepoints(36, 2) = New Point(220, 175 + shifter)
        squarepoints(36, 3) = New Point(220, 130 + shifter)
        squarepoints(36, 4) = New Point(260, 110 + shifter)

        'back face
        squarepoints(37, 0) = New Point(540, 20 + shifter)
        squarepoints(37, 1) = New Point(540, 65 + shifter)
        squarepoints(37, 2) = New Point(580, 85 + shifter)
        squarepoints(37, 3) = New Point(580, 40 + shifter)
        squarepoints(37, 4) = New Point(540, 20 + shifter)

        squarepoints(38, 0) = New Point(540, 65 + shifter)
        squarepoints(38, 1) = New Point(540, 110 + shifter)
        squarepoints(38, 2) = New Point(580, 130 + shifter)
        squarepoints(38, 3) = New Point(580, 85 + shifter)
        squarepoints(38, 4) = New Point(540, 65 + shifter)

        squarepoints(39, 0) = New Point(540, 110 + shifter)
        squarepoints(39, 1) = New Point(540, 155 + shifter)
        squarepoints(39, 2) = New Point(580, 175 + shifter)
        squarepoints(39, 3) = New Point(580, 130 + shifter)
        squarepoints(39, 4) = New Point(540, 110 + shifter)

        squarepoints(40, 0) = New Point(580, 40 + shifter)
        squarepoints(40, 1) = New Point(580, 85 + shifter)
        squarepoints(40, 2) = New Point(620, 105 + shifter)
        squarepoints(40, 3) = New Point(620, 60 + shifter)
        squarepoints(40, 4) = New Point(580, 40 + shifter)

        squarepoints(41, 0) = New Point(580, 85 + shifter)
        squarepoints(41, 1) = New Point(580, 130 + shifter)
        squarepoints(41, 2) = New Point(620, 150 + shifter)
        squarepoints(41, 3) = New Point(620, 105 + shifter)
        squarepoints(41, 4) = New Point(580, 85 + shifter)

        squarepoints(42, 0) = New Point(580, 130 + shifter)
        squarepoints(42, 1) = New Point(580, 175 + shifter)
        squarepoints(42, 2) = New Point(620, 195 + shifter)
        squarepoints(42, 3) = New Point(620, 150 + shifter)
        squarepoints(42, 4) = New Point(580, 130 + shifter)

        squarepoints(43, 0) = New Point(620, 60 + shifter)
        squarepoints(43, 1) = New Point(620, 105 + shifter)
        squarepoints(43, 2) = New Point(660, 125 + shifter)
        squarepoints(43, 3) = New Point(660, 80 + shifter)
        squarepoints(43, 4) = New Point(620, 60 + shifter)

        squarepoints(44, 0) = New Point(620, 105 + shifter)
        squarepoints(44, 1) = New Point(620, 150 + shifter)
        squarepoints(44, 2) = New Point(660, 170 + shifter)
        squarepoints(44, 3) = New Point(660, 125 + shifter)
        squarepoints(44, 4) = New Point(620, 105 + shifter)

        squarepoints(45, 0) = New Point(620, 150 + shifter)
        squarepoints(45, 1) = New Point(620, 195 + shifter)
        squarepoints(45, 2) = New Point(660, 215 + shifter)
        squarepoints(45, 3) = New Point(660, 170 + shifter)
        squarepoints(45, 4) = New Point(620, 150 + shifter)

        'bottom face
        squarepoints(46, 0) = New Point(400, 350 + shifter)
        squarepoints(46, 1) = New Point(360, 370 + shifter)
        squarepoints(46, 2) = New Point(400, 390 + shifter)
        squarepoints(46, 3) = New Point(440, 370 + shifter)
        squarepoints(46, 4) = New Point(400, 350 + shifter)

        squarepoints(47, 0) = New Point(360, 370 + shifter)
        squarepoints(47, 1) = New Point(320, 390 + shifter)
        squarepoints(47, 2) = New Point(360, 410 + shifter)
        squarepoints(47, 3) = New Point(400, 390 + shifter)
        squarepoints(47, 4) = New Point(360, 370 + shifter)

        squarepoints(48, 0) = New Point(320, 390 + shifter)
        squarepoints(48, 1) = New Point(280, 410 + shifter)
        squarepoints(48, 2) = New Point(320, 430 + shifter)
        squarepoints(48, 3) = New Point(360, 410 + shifter)
        squarepoints(48, 4) = New Point(320, 390 + shifter)

        squarepoints(49, 0) = New Point(440, 370 + shifter)
        squarepoints(49, 1) = New Point(400, 390 + shifter)
        squarepoints(49, 2) = New Point(440, 410 + shifter)
        squarepoints(49, 3) = New Point(480, 390 + shifter)
        squarepoints(49, 4) = New Point(440, 370 + shifter)

        squarepoints(50, 0) = New Point(400, 390 + shifter)
        squarepoints(50, 1) = New Point(360, 410 + shifter)
        squarepoints(50, 2) = New Point(400, 430 + shifter)
        squarepoints(50, 3) = New Point(440, 410 + shifter)
        squarepoints(50, 4) = New Point(400, 390 + shifter)

        squarepoints(51, 0) = New Point(360, 410 + shifter)
        squarepoints(51, 1) = New Point(320, 430 + shifter)
        squarepoints(51, 2) = New Point(360, 450 + shifter)
        squarepoints(51, 3) = New Point(400, 430 + shifter)
        squarepoints(51, 4) = New Point(360, 410 + shifter)

        squarepoints(52, 0) = New Point(480, 390 + shifter)
        squarepoints(52, 1) = New Point(440, 410 + shifter)
        squarepoints(52, 2) = New Point(480, 430 + shifter)
        squarepoints(52, 3) = New Point(520, 410 + shifter)
        squarepoints(52, 4) = New Point(480, 390 + shifter)

        squarepoints(53, 0) = New Point(440, 410 + shifter)
        squarepoints(53, 1) = New Point(400, 430 + shifter)
        squarepoints(53, 2) = New Point(440, 450 + shifter)
        squarepoints(53, 3) = New Point(480, 430 + shifter)
        squarepoints(53, 4) = New Point(440, 410 + shifter)

        squarepoints(54, 0) = New Point(400, 430 + shifter)
        squarepoints(54, 1) = New Point(360, 450 + shifter)
        squarepoints(54, 2) = New Point(400, 470 + shifter)
        squarepoints(54, 3) = New Point(440, 450 + shifter)
        squarepoints(54, 4) = New Point(400, 430 + shifter)
    End Sub
    Private Sub rubiks_cube_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'this is where the magic happens that determines which face you are clicking. in theory
        If mode = "play" Then 'only detects the side when the mode is in play
            If (e.X >= 140 And e.X <= 260) And (e.Y >= (150 + shifter - e.X / 2) And e.Y <= (285 + shifter - e.X / 2)) Then 'left face detection
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    leftrotate("clock")
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    leftrotate("counterclock")
                End If
            ElseIf (e.X >= 280 And e.X <= 400) And (e.Y >= (e.X / 2 + shifter) And e.Y <= (e.X / 2 + 135 + shifter)) Then 'front face detection
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    frontrotate("clock")
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    frontrotate("counterclock")
                End If
            ElseIf (e.X >= 400 And e.X <= 520) And (e.Y >= (400 + shifter - e.X / 2) And e.Y <= (535 + shifter - e.X / 2)) Then 'right face detection
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    rightrotate("clock")
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    rightrotate("counterclock")
                End If
            ElseIf (e.X >= 540 And e.X <= 660) And (e.Y >= (e.X / 2 - 250 + shifter) And e.Y <= (e.X / 2 - 115 + shifter)) Then 'back face detection
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    backrotate("clock")
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    backrotate("counterclock")
                End If
            ElseIf ((e.X >= 280 And e.X <= 400) And (e.Y >= (280 + shifter - e.X / 2) And e.Y <= (e.X / 2 + shifter))) Or ((e.X >= 400 And e.X <= 520) And (e.Y >= (e.X / 2 - 120 + shifter) And e.Y <= (400 + shifter - e.X / 2))) Then 'top face detection
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    toprotate("clock")
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    toprotate("counterclock")
                End If
            ElseIf ((e.X >= 280 And e.X <= 400) And (e.Y >= (550 + shifter - e.X / 2) And e.Y <= (e.X / 2 + 270 + shifter))) Or ((e.X >= 400 And e.X <= 520) And (e.Y >= (e.X / 2 + 150 + shifter) And e.Y <= (670 + shifter - e.X / 2))) Then 'bottom face detection
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    bottomrotate("clock")
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    bottomrotate("counterclock")
                End If
            End If
        ElseIf mode = "edit" Then 'when mode is in edit, we can detect each individual square. this section narrows stuff down before going to other methods
            If (e.X >= 140 And e.X <= 260) And (e.Y >= (150 + shifter - e.X / 2) And e.Y <= (285 + shifter - e.X / 2)) Then 'left face detection
                If e.X >= 140 And e.X <= 180 Then
                    leftdetect(e.X, e.Y, 1)
                ElseIf e.X >= 180 And e.X <= 220 Then
                    leftdetect(e.X, e.Y, 2)
                ElseIf e.X >= 220 And e.X <= 260 Then
                    leftdetect(e.X, e.Y, 3)
                End If
            ElseIf (e.X >= 280 And e.X <= 400) And (e.Y >= (e.X / 2 + shifter) And e.Y <= (e.X / 2 + 135 + shifter)) Then 'front face detection
                If e.X >= 280 And e.X <= 320 Then
                    frontdetect(e.X, e.Y, 1)
                ElseIf e.X >= 320 And e.X <= 360 Then
                    frontdetect(e.X, e.Y, 2)
                ElseIf e.X >= 360 And e.X <= 400 Then
                    frontdetect(e.X, e.Y, 3)
                End If
            ElseIf (e.X >= 400 And e.X <= 520) And (e.Y >= (400 + shifter - e.X / 2) And e.Y <= (535 + shifter - e.X / 2)) Then 'right face detection
                If e.X >= 400 And e.X <= 440 Then
                    rightdetect(e.X, e.Y, 1)
                ElseIf e.X >= 440 And e.X <= 480 Then
                    rightdetect(e.X, e.Y, 2)
                ElseIf e.X >= 480 And e.X <= 520 Then
                    rightdetect(e.X, e.Y, 3)
                End If
            ElseIf (e.X >= 540 And e.X <= 660) And (e.Y >= (e.X / 2 - 250 + shifter) And e.Y <= (e.X / 2 - 115 + shifter)) Then 'back face detection
                If e.X >= 540 And e.X <= 580 Then
                    backdetect(e.X, e.Y, 1)
                ElseIf e.X >= 580 And e.X <= 620 Then
                    backdetect(e.X, e.Y, 2)
                ElseIf e.X >= 620 And e.X <= 660 Then
                    backdetect(e.X, e.Y, 3)
                End If
            ElseIf ((e.X >= 280 And e.X <= 400) And (e.Y >= (280 + shifter - e.X / 2) And e.Y <= (e.X / 2 + shifter))) Or ((e.X >= 400 And e.X <= 520) And (e.Y >= (e.X / 2 - 120 + shifter) And e.Y <= (400 + shifter - e.X / 2))) Then 'top face detection
                If e.X >= 280 And e.X <= 320 Then
                    topdetect(e.X, e.Y, 1)
                ElseIf e.X >= 320 And e.X <= 360 Then
                    topdetect(e.X, e.Y, 2)
                ElseIf e.X >= 360 And e.X <= 400 Then
                    topdetect(e.X, e.Y, 3)
                ElseIf e.X >= 400 And e.X <= 440 Then
                    topdetect(e.X, e.Y, 4)
                ElseIf e.X >= 440 And e.X <= 480 Then
                    topdetect(e.X, e.Y, 5)
                ElseIf e.X >= 480 And e.X <= 520 Then
                    topdetect(e.X, e.Y, 6)
                End If
            ElseIf ((e.X >= 280 And e.X <= 400) And (e.Y >= (550 + shifter - e.X / 2) And e.Y <= (e.X / 2 + 270 + shifter))) Or ((e.X >= 400 And e.X <= 520) And (e.Y >= (e.X / 2 + 150 + shifter) And e.Y <= (670 + shifter - e.X / 2))) Then 'bottom face detection
                If e.X >= 280 And e.X <= 320 Then
                    bottomdetect(e.X, e.Y, 1)
                ElseIf e.X >= 320 And e.X <= 360 Then
                    bottomdetect(e.X, e.Y, 2)
                ElseIf e.X >= 360 And e.X <= 400 Then
                    bottomdetect(e.X, e.Y, 3)
                ElseIf e.X >= 400 And e.X <= 440 Then
                    bottomdetect(e.X, e.Y, 4)
                ElseIf e.X >= 440 And e.X <= 480 Then
                    bottomdetect(e.X, e.Y, 5)
                ElseIf e.X >= 480 And e.X <= 520 Then
                    bottomdetect(e.X, e.Y, 6)
                End If
            End If
        End If
    End Sub
    Public Sub leftdetect(x As Integer, y As Integer, section As Integer)
        'these "detection" functions determine which square exactly the mouse was in
        If y >= 150 + shifter - x / 2 And y <= 195 + shifter - x / 2 Then
            If section = 1 Then
                squarecolors(28) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(31) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(34) = selectedcolor
            End If
        ElseIf y >= 195 + shifter - x / 2 And y <= 240 + shifter - x / 2 Then
            If section = 1 Then
                squarecolors(29) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(32) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(35) = selectedcolor
            End If
        ElseIf y >= 240 + shifter - x / 2 And y <= 285 + shifter - x / 2 Then
            If section = 1 Then
                squarecolors(30) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(33) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(36) = selectedcolor
            End If
        End If
    End Sub
    Public Sub rightdetect(x As Integer, y As Integer, section As Integer)
        If y >= 400 + shifter - x / 2 And y <= 445 + shifter - x / 2 Then
            If section = 1 Then
                squarecolors(19) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(22) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(25) = selectedcolor
            End If
        ElseIf y >= 445 + shifter - x / 2 And y <= 490 + shifter - x / 2 Then
            If section = 1 Then
                squarecolors(20) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(23) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(26) = selectedcolor
            End If
        ElseIf y >= 490 + shifter - x / 2 And y <= 535 + shifter - x / 2 Then
            If section = 1 Then
                squarecolors(21) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(24) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(27) = selectedcolor
            End If
        End If
    End Sub
    Public Sub frontdetect(x As Integer, y As Integer, section As Integer)
        If y >= x / 2 + shifter And y <= x / 2 + 45 + shifter Then
            If section = 1 Then
                squarecolors(10) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(13) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(16) = selectedcolor
            End If
        ElseIf y >= x / 2 + 45 + shifter And y <= x / 2 + 90 + shifter Then
            If section = 1 Then
                squarecolors(11) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(14) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(17) = selectedcolor
            End If
        ElseIf y >= x / 2 + 90 + shifter And y <= x / 2 + 135 + shifter Then
            If section = 1 Then
                squarecolors(12) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(15) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(18) = selectedcolor
            End If
        End If
    End Sub
    Public Sub backdetect(x As Integer, y As Integer, section As Integer)
        If y >= x / 2 - 250 + shifter And y <= x / 2 - 205 + shifter Then
            If section = 1 Then
                squarecolors(37) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(40) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(43) = selectedcolor
            End If
        ElseIf y >= x / 2 - 205 + shifter And y <= x / 2 - 160 + shifter Then
            If section = 1 Then
                squarecolors(38) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(41) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(44) = selectedcolor
            End If
        ElseIf y >= x / 2 - 160 + shifter And y <= x / 2 - 115 + shifter Then
            If section = 1 Then
                squarecolors(39) = selectedcolor
            ElseIf section = 2 Then
                squarecolors(42) = selectedcolor
            ElseIf section = 3 Then
                squarecolors(45) = selectedcolor
            End If
        End If
    End Sub
    Public Sub topdetect(x As Integer, y As Integer, section As Integer)
        If section = 1 Then
            squarecolors(3) = selectedcolor
        ElseIf section = 2 Then
            If y <= x / 2 - 40 + shifter Then
                squarecolors(2) = selectedcolor
            ElseIf y >= 320 + shifter - x / 2 Then
                squarecolors(6) = selectedcolor
            Else
                squarecolors(3) = selectedcolor
            End If
        ElseIf section = 3 Then
            If y <= x / 2 - 80 + shifter Then
                squarecolors(1) = selectedcolor
            ElseIf y >= x / 2 - 80 + shifter And y <= 320 + shifter - x / 2 Then
                squarecolors(2) = selectedcolor
            ElseIf y >= 320 + shifter - x / 2 And y <= x / 2 - 40 + shifter Then
                squarecolors(5) = selectedcolor
            ElseIf y >= x / 2 - 40 + shifter And y <= 360 + shifter - x / 2 Then
                squarecolors(6) = selectedcolor
            ElseIf y >= 360 + shifter - x / 2 Then
                squarecolors(9) = selectedcolor
            End If
        ElseIf section = 4 Then
            If y <= 320 + shifter - x / 2 Then
                squarecolors(1) = selectedcolor
            ElseIf y >= 320 + shifter - x / 2 And y <= x / 2 - 80 + shifter Then
                squarecolors(4) = selectedcolor
            ElseIf y >= x / 2 - 80 + shifter And y <= 360 + shifter - x / 2 Then
                squarecolors(5) = selectedcolor
            ElseIf y >= 360 + shifter - x / 2 And y <= x / 2 - 40 + shifter Then
                squarecolors(8) = selectedcolor
            ElseIf y >= x / 2 - 40 + shifter Then
                squarecolors(9) = selectedcolor
            End If
        ElseIf section = 5 Then
            If y <= 360 + shifter - x / 2 Then
                squarecolors(4) = selectedcolor
            ElseIf y >= x / 2 - 80 + shifter Then
                squarecolors(8) = selectedcolor
            Else
                squarecolors(7) = selectedcolor
            End If
        ElseIf section = 6 Then
            squarecolors(7) = selectedcolor
        End If
    End Sub
    Public Sub bottomdetect(x As Integer, y As Integer, section As Integer)
        If section = 1 Then
            squarecolors(48) = selectedcolor
        ElseIf section = 2 Then
            If y <= x / 2 + 230 + shifter Then
                squarecolors(47) = selectedcolor
            ElseIf y >= 590 + shifter - x / 2 Then
                squarecolors(51) = selectedcolor
            Else
                squarecolors(48) = selectedcolor
            End If
        ElseIf section = 3 Then
            If y <= x / 2 + 190 + shifter Then
                squarecolors(46) = selectedcolor
            ElseIf y >= x / 2 + 190 + shifter And y <= 590 + shifter - x / 2 Then
                squarecolors(47) = selectedcolor
            ElseIf y >= 590 + shifter - x / 2 And y <= x / 2 + 230 + shifter Then
                squarecolors(50) = selectedcolor
            ElseIf y >= x / 2 + 230 + shifter And y <= 630 + shifter - x / 2 Then
                squarecolors(51) = selectedcolor
            ElseIf y >= 630 - x / 2 Then
                squarecolors(54) = selectedcolor
            End If
        ElseIf section = 4 Then
            If y <= 590 + shifter - x / 2 Then
                squarecolors(46) = selectedcolor
            ElseIf y >= 590 + shifter - x / 2 And y <= x / 2 + 190 + shifter Then
                squarecolors(49) = selectedcolor
            ElseIf y >= x / 2 + 190 + shifter And y <= 630 + shifter - x / 2 Then
                squarecolors(50) = selectedcolor
            ElseIf y >= 630 + shifter - x / 2 And y <= x / 2 + 230 + shifter Then
                squarecolors(53) = selectedcolor
            ElseIf y >= x / 2 + 230 + shifter Then
                squarecolors(54) = selectedcolor
            End If
        ElseIf section = 5 Then
            If y <= 630 + shifter - x / 2 Then
                squarecolors(49) = selectedcolor
            ElseIf y >= x / 2 + 190 + shifter Then
                squarecolors(53) = selectedcolor
            Else
                squarecolors(52) = selectedcolor
            End If
        ElseIf section = 6 Then
            squarecolors(52) = selectedcolor
        End If
    End Sub
    Public Sub frontrotate(direction As String)
        'these "rotate" functions rotate a side. didn't want to have to put all the code in the mouseclick function and wanted the ability to rotate a side as needed in case i implement anything else.
        Dim helper As Brush
        If direction = "clock" Then
            helper = squarecolors(10) 'save face corner
            squarecolors(10) = squarecolors(12)
            squarecolors(12) = squarecolors(18)
            squarecolors(18) = squarecolors(16)
            squarecolors(16) = helper
            helper = squarecolors(13) 'save face edge
            squarecolors(13) = squarecolors(11)
            squarecolors(11) = squarecolors(15)
            squarecolors(15) = squarecolors(17)
            squarecolors(17) = helper
            helper = squarecolors(6) 'save layer edge
            squarecolors(6) = squarecolors(29)
            squarecolors(29) = squarecolors(51)
            squarecolors(51) = squarecolors(20)
            squarecolors(20) = helper
            helper = squarecolors(9) 'save layer corner part 1
            squarecolors(9) = squarecolors(28)
            squarecolors(28) = squarecolors(48)
            squarecolors(48) = squarecolors(21)
            squarecolors(21) = helper
            helper = squarecolors(3) 'save layer corner part 2
            squarecolors(3) = squarecolors(30)
            squarecolors(30) = squarecolors(54)
            squarecolors(54) = squarecolors(19)
            squarecolors(19) = helper
        ElseIf direction = "counterclock" Then
            helper = squarecolors(10) 'save face corner
            squarecolors(10) = squarecolors(16)
            squarecolors(16) = squarecolors(18)
            squarecolors(18) = squarecolors(12)
            squarecolors(12) = helper
            helper = squarecolors(13) 'save face edge
            squarecolors(13) = squarecolors(17)
            squarecolors(17) = squarecolors(15)
            squarecolors(15) = squarecolors(11)
            squarecolors(11) = helper
            helper = squarecolors(6) 'save layer edge
            squarecolors(6) = squarecolors(20)
            squarecolors(20) = squarecolors(51)
            squarecolors(51) = squarecolors(29)
            squarecolors(29) = helper
            helper = squarecolors(9) 'save layer corner part 1
            squarecolors(9) = squarecolors(21)
            squarecolors(21) = squarecolors(48)
            squarecolors(48) = squarecolors(28)
            squarecolors(28) = helper
            helper = squarecolors(3) 'save layer corner part 2
            squarecolors(3) = squarecolors(19)
            squarecolors(19) = squarecolors(54)
            squarecolors(54) = squarecolors(30)
            squarecolors(30) = helper
        End If
    End Sub
    Public Sub rightrotate(direction As String)
        Dim helper As Brush
        If direction = "clock" Then
            helper = squarecolors(19) 'save face corner
            squarecolors(19) = squarecolors(21)
            squarecolors(21) = squarecolors(27)
            squarecolors(27) = squarecolors(25)
            squarecolors(25) = helper
            helper = squarecolors(22) 'save face edge
            squarecolors(22) = squarecolors(20)
            squarecolors(20) = squarecolors(24)
            squarecolors(24) = squarecolors(26)
            squarecolors(26) = helper
            helper = squarecolors(8) 'save layer edge
            squarecolors(8) = squarecolors(17)
            squarecolors(17) = squarecolors(53)
            squarecolors(53) = squarecolors(44)
            squarecolors(44) = helper
            helper = squarecolors(9) 'save layer corner part 1
            squarecolors(9) = squarecolors(18)
            squarecolors(18) = squarecolors(52)
            squarecolors(52) = squarecolors(43)
            squarecolors(43) = helper
            helper = squarecolors(7) 'save layer corner part 2
            squarecolors(7) = squarecolors(16)
            squarecolors(16) = squarecolors(54)
            squarecolors(54) = squarecolors(45)
            squarecolors(45) = helper
        ElseIf direction = "counterclock" Then
            helper = squarecolors(19) 'save face corner
            squarecolors(19) = squarecolors(25)
            squarecolors(25) = squarecolors(27)
            squarecolors(27) = squarecolors(21)
            squarecolors(21) = helper
            helper = squarecolors(22) 'save face edge
            squarecolors(22) = squarecolors(26)
            squarecolors(26) = squarecolors(24)
            squarecolors(24) = squarecolors(20)
            squarecolors(20) = helper
            helper = squarecolors(8) 'save layer edge
            squarecolors(8) = squarecolors(44)
            squarecolors(44) = squarecolors(53)
            squarecolors(53) = squarecolors(17)
            squarecolors(17) = helper
            helper = squarecolors(9) 'save layer corner part 1
            squarecolors(9) = squarecolors(43)
            squarecolors(43) = squarecolors(52)
            squarecolors(52) = squarecolors(18)
            squarecolors(18) = helper
            helper = squarecolors(7) 'save layer corner part 2
            squarecolors(7) = squarecolors(45)
            squarecolors(45) = squarecolors(54)
            squarecolors(54) = squarecolors(16)
            squarecolors(16) = helper
        End If
    End Sub
    Public Sub toprotate(direction As String)
        Dim helper As Brush
        If direction = "clock" Then
            helper = squarecolors(3) 'save face corner
            squarecolors(3) = squarecolors(9)
            squarecolors(9) = squarecolors(7)
            squarecolors(7) = squarecolors(1)
            squarecolors(1) = helper
            helper = squarecolors(2) 'save face edge
            squarecolors(2) = squarecolors(6)
            squarecolors(6) = squarecolors(8)
            squarecolors(8) = squarecolors(4)
            squarecolors(4) = helper
            helper = squarecolors(13) 'save layer edge
            squarecolors(13) = squarecolors(22)
            squarecolors(22) = squarecolors(40)
            squarecolors(40) = squarecolors(31)
            squarecolors(31) = helper
            helper = squarecolors(10) 'save layer corner part 1
            squarecolors(10) = squarecolors(19)
            squarecolors(19) = squarecolors(43)
            squarecolors(43) = squarecolors(34)
            squarecolors(34) = helper
            helper = squarecolors(16) 'save layer corner part 2
            squarecolors(16) = squarecolors(25)
            squarecolors(25) = squarecolors(37)
            squarecolors(37) = squarecolors(28)
            squarecolors(28) = helper
        ElseIf direction = "counterclock" Then
            helper = squarecolors(3) 'save face corner
            squarecolors(3) = squarecolors(1)
            squarecolors(1) = squarecolors(7)
            squarecolors(7) = squarecolors(9)
            squarecolors(9) = helper
            helper = squarecolors(2) 'save face edge
            squarecolors(2) = squarecolors(4)
            squarecolors(4) = squarecolors(8)
            squarecolors(8) = squarecolors(6)
            squarecolors(6) = helper
            helper = squarecolors(13) 'save layer edge
            squarecolors(13) = squarecolors(31)
            squarecolors(31) = squarecolors(40)
            squarecolors(40) = squarecolors(22)
            squarecolors(22) = helper
            helper = squarecolors(10) 'save layer corner part 1
            squarecolors(10) = squarecolors(34)
            squarecolors(34) = squarecolors(43)
            squarecolors(43) = squarecolors(19)
            squarecolors(19) = helper
            helper = squarecolors(16) 'save layer corner part 2
            squarecolors(16) = squarecolors(28)
            squarecolors(28) = squarecolors(37)
            squarecolors(37) = squarecolors(25)
            squarecolors(25) = helper
        End If
    End Sub
    Public Sub leftrotate(direction As String)
        Dim helper As Brush
        If direction = "clock" Then
            helper = squarecolors(28)
            squarecolors(28) = squarecolors(34)
            squarecolors(34) = squarecolors(36)
            squarecolors(36) = squarecolors(30)
            squarecolors(30) = helper
            helper = squarecolors(31)
            squarecolors(31) = squarecolors(35)
            squarecolors(35) = squarecolors(33)
            squarecolors(33) = squarecolors(29)
            squarecolors(29) = helper
            helper = squarecolors(2)
            squarecolors(2) = squarecolors(38)
            squarecolors(38) = squarecolors(47)
            squarecolors(47) = squarecolors(11)
            squarecolors(11) = helper
            helper = squarecolors(3)
            squarecolors(3) = squarecolors(37)
            squarecolors(37) = squarecolors(46)
            squarecolors(46) = squarecolors(12)
            squarecolors(12) = helper
            helper = squarecolors(1)
            squarecolors(1) = squarecolors(39)
            squarecolors(39) = squarecolors(48)
            squarecolors(48) = squarecolors(10)
            squarecolors(10) = helper
        ElseIf direction = "counterclock" Then
            helper = squarecolors(28)
            squarecolors(28) = squarecolors(30)
            squarecolors(30) = squarecolors(36)
            squarecolors(36) = squarecolors(34)
            squarecolors(34) = helper
            helper = squarecolors(31)
            squarecolors(31) = squarecolors(29)
            squarecolors(29) = squarecolors(33)
            squarecolors(33) = squarecolors(35)
            squarecolors(35) = helper
            helper = squarecolors(2)
            squarecolors(2) = squarecolors(11)
            squarecolors(11) = squarecolors(47)
            squarecolors(47) = squarecolors(38)
            squarecolors(38) = helper
            helper = squarecolors(3)
            squarecolors(3) = squarecolors(12)
            squarecolors(12) = squarecolors(46)
            squarecolors(46) = squarecolors(37)
            squarecolors(37) = helper
            helper = squarecolors(1)
            squarecolors(1) = squarecolors(10)
            squarecolors(10) = squarecolors(48)
            squarecolors(48) = squarecolors(39)
            squarecolors(39) = helper
        End If
    End Sub
    Public Sub backrotate(direction As String)
        Dim helper As Brush
        If direction = "clock" Then
            helper = squarecolors(37)
            squarecolors(37) = squarecolors(43)
            squarecolors(43) = squarecolors(45)
            squarecolors(45) = squarecolors(39)
            squarecolors(39) = helper
            helper = squarecolors(40)
            squarecolors(40) = squarecolors(44)
            squarecolors(44) = squarecolors(42)
            squarecolors(42) = squarecolors(38)
            squarecolors(38) = helper
            helper = squarecolors(4)
            squarecolors(4) = squarecolors(26)
            squarecolors(26) = squarecolors(49)
            squarecolors(49) = squarecolors(35)
            squarecolors(35) = helper
            helper = squarecolors(1)
            squarecolors(1) = squarecolors(25)
            squarecolors(25) = squarecolors(52)
            squarecolors(52) = squarecolors(36)
            squarecolors(36) = helper
            helper = squarecolors(7)
            squarecolors(7) = squarecolors(27)
            squarecolors(27) = squarecolors(46)
            squarecolors(46) = squarecolors(34)
            squarecolors(34) = helper
        ElseIf direction = "counterclock" Then
            helper = squarecolors(37)
            squarecolors(37) = squarecolors(39)
            squarecolors(39) = squarecolors(45)
            squarecolors(45) = squarecolors(43)
            squarecolors(43) = helper
            helper = squarecolors(40)
            squarecolors(40) = squarecolors(38)
            squarecolors(38) = squarecolors(42)
            squarecolors(42) = squarecolors(44)
            squarecolors(44) = helper
            helper = squarecolors(4)
            squarecolors(4) = squarecolors(35)
            squarecolors(35) = squarecolors(49)
            squarecolors(49) = squarecolors(26)
            squarecolors(26) = helper
            helper = squarecolors(1)
            squarecolors(1) = squarecolors(36)
            squarecolors(36) = squarecolors(52)
            squarecolors(52) = squarecolors(25)
            squarecolors(25) = helper
            helper = squarecolors(7)
            squarecolors(7) = squarecolors(34)
            squarecolors(34) = squarecolors(46)
            squarecolors(46) = squarecolors(27)
            squarecolors(27) = helper
        End If
    End Sub
    Public Sub bottomrotate(direction As String)
        Dim helper As Brush
        If direction = "clock" Then
            helper = squarecolors(51)
            squarecolors(51) = squarecolors(47)
            squarecolors(47) = squarecolors(49)
            squarecolors(49) = squarecolors(53)
            squarecolors(53) = helper
            helper = squarecolors(46)
            squarecolors(46) = squarecolors(52)
            squarecolors(52) = squarecolors(54)
            squarecolors(54) = squarecolors(48)
            squarecolors(48) = helper
            helper = squarecolors(15)
            squarecolors(15) = squarecolors(33)
            squarecolors(33) = squarecolors(42)
            squarecolors(42) = squarecolors(24)
            squarecolors(24) = helper
            helper = squarecolors(12)
            squarecolors(12) = squarecolors(36)
            squarecolors(36) = squarecolors(45)
            squarecolors(45) = squarecolors(21)
            squarecolors(21) = helper
            helper = squarecolors(18)
            squarecolors(18) = squarecolors(30)
            squarecolors(30) = squarecolors(39)
            squarecolors(39) = squarecolors(27)
            squarecolors(27) = helper
        ElseIf direction = "counterclock" Then
            helper = squarecolors(51)
            squarecolors(51) = squarecolors(53)
            squarecolors(53) = squarecolors(49)
            squarecolors(49) = squarecolors(47)
            squarecolors(47) = helper
            helper = squarecolors(46)
            squarecolors(46) = squarecolors(48)
            squarecolors(48) = squarecolors(54)
            squarecolors(54) = squarecolors(52)
            squarecolors(52) = helper
            helper = squarecolors(15)
            squarecolors(15) = squarecolors(24)
            squarecolors(24) = squarecolors(42)
            squarecolors(42) = squarecolors(33)
            squarecolors(33) = helper
            helper = squarecolors(12)
            squarecolors(12) = squarecolors(21)
            squarecolors(21) = squarecolors(45)
            squarecolors(45) = squarecolors(36)
            squarecolors(36) = helper
            helper = squarecolors(18)
            squarecolors(18) = squarecolors(27)
            squarecolors(27) = squarecolors(39)
            squarecolors(39) = squarecolors(30)
            squarecolors(30) = helper
        End If
    End Sub
    Public Sub xrotate(direction As String)
        'the x,y,z rotate functions rotate the entire cube
        Dim helper As Brush
        If direction = "normal" Then
            helper = squarecolors(22) 'save face 1 edge
            squarecolors(22) = squarecolors(20)
            squarecolors(20) = squarecolors(24)
            squarecolors(24) = squarecolors(26)
            squarecolors(26) = helper
            helper = squarecolors(19) 'save face 1 corner
            squarecolors(19) = squarecolors(21)
            squarecolors(21) = squarecolors(27)
            squarecolors(27) = squarecolors(25)
            squarecolors(25) = helper
            helper = squarecolors(31) 'save face 2 edge
            squarecolors(31) = squarecolors(29)
            squarecolors(29) = squarecolors(33)
            squarecolors(33) = squarecolors(35)
            squarecolors(35) = helper
            helper = squarecolors(28) 'save face 2 corner
            squarecolors(28) = squarecolors(30)
            squarecolors(30) = squarecolors(36)
            squarecolors(36) = squarecolors(34)
            squarecolors(34) = helper
            helper = squarecolors(11) 'save layer 1 edge
            squarecolors(11) = squarecolors(47)
            squarecolors(47) = squarecolors(38)
            squarecolors(38) = squarecolors(2)
            squarecolors(2) = helper
            helper = squarecolors(10) 'save layer 1 corner 1
            squarecolors(10) = squarecolors(48)
            squarecolors(48) = squarecolors(39)
            squarecolors(39) = squarecolors(1)
            squarecolors(1) = helper
            helper = squarecolors(12) 'save layer 1 corner 2
            squarecolors(12) = squarecolors(46)
            squarecolors(46) = squarecolors(37)
            squarecolors(37) = squarecolors(3)
            squarecolors(3) = helper
            helper = squarecolors(13) 'save layer 2 edge 1
            squarecolors(13) = squarecolors(51)
            squarecolors(51) = squarecolors(42)
            squarecolors(42) = squarecolors(4)
            squarecolors(4) = helper
            helper = squarecolors(15) 'save layer 2 edge 2
            squarecolors(15) = squarecolors(49)
            squarecolors(49) = squarecolors(40)
            squarecolors(40) = squarecolors(6)
            squarecolors(6) = helper
            helper = squarecolors(14) 'save layer 2 center
            squarecolors(14) = squarecolors(50)
            squarecolors(50) = squarecolors(41)
            squarecolors(41) = squarecolors(5)
            squarecolors(5) = helper
            helper = squarecolors(17) 'save layer 3 edge
            squarecolors(17) = squarecolors(53)
            squarecolors(53) = squarecolors(44)
            squarecolors(44) = squarecolors(8)
            squarecolors(8) = helper
            helper = squarecolors(16) 'save layer 3 corner 1
            squarecolors(16) = squarecolors(54)
            squarecolors(54) = squarecolors(45)
            squarecolors(45) = squarecolors(7)
            squarecolors(7) = helper
            helper = squarecolors(18) 'save layer 3 corner 2
            squarecolors(18) = squarecolors(52)
            squarecolors(52) = squarecolors(43)
            squarecolors(43) = squarecolors(9)
            squarecolors(9) = helper
        ElseIf direction = "inverted" Then
            helper = squarecolors(22) 'save face 1 edge
            squarecolors(22) = squarecolors(26)
            squarecolors(26) = squarecolors(24)
            squarecolors(24) = squarecolors(20)
            squarecolors(20) = helper
            helper = squarecolors(19) 'save face 1 corner
            squarecolors(19) = squarecolors(25)
            squarecolors(25) = squarecolors(27)
            squarecolors(27) = squarecolors(21)
            squarecolors(21) = helper
            helper = squarecolors(31) 'save face 2 edge
            squarecolors(31) = squarecolors(35)
            squarecolors(35) = squarecolors(33)
            squarecolors(33) = squarecolors(29)
            squarecolors(29) = helper
            helper = squarecolors(28) 'save face 2 corner
            squarecolors(28) = squarecolors(34)
            squarecolors(34) = squarecolors(36)
            squarecolors(36) = squarecolors(30)
            squarecolors(30) = helper
            helper = squarecolors(11) 'save layer 1 edge
            squarecolors(11) = squarecolors(2)
            squarecolors(2) = squarecolors(38)
            squarecolors(38) = squarecolors(47)
            squarecolors(47) = helper
            helper = squarecolors(10) 'save layer 1 corner 1
            squarecolors(10) = squarecolors(1)
            squarecolors(1) = squarecolors(39)
            squarecolors(39) = squarecolors(48)
            squarecolors(48) = helper
            helper = squarecolors(12) 'save layer 1 corner 2
            squarecolors(12) = squarecolors(3)
            squarecolors(3) = squarecolors(37)
            squarecolors(37) = squarecolors(46)
            squarecolors(46) = helper
            helper = squarecolors(13) 'save layer 2 edge 1
            squarecolors(13) = squarecolors(4)
            squarecolors(4) = squarecolors(42)
            squarecolors(42) = squarecolors(51)
            squarecolors(51) = helper
            helper = squarecolors(15) 'save layer 2 edge 2
            squarecolors(15) = squarecolors(6)
            squarecolors(6) = squarecolors(40)
            squarecolors(40) = squarecolors(49)
            squarecolors(49) = helper
            helper = squarecolors(14) 'save layer 2 center
            squarecolors(14) = squarecolors(5)
            squarecolors(5) = squarecolors(41)
            squarecolors(41) = squarecolors(50)
            squarecolors(50) = helper
            helper = squarecolors(17) 'save layer 3 edge
            squarecolors(17) = squarecolors(8)
            squarecolors(8) = squarecolors(44)
            squarecolors(44) = squarecolors(53)
            squarecolors(53) = helper
            helper = squarecolors(16) 'save layer 3 corner 1
            squarecolors(16) = squarecolors(7)
            squarecolors(7) = squarecolors(45)
            squarecolors(45) = squarecolors(54)
            squarecolors(54) = helper
            helper = squarecolors(18) 'save layer 3 corner 2
            squarecolors(18) = squarecolors(9)
            squarecolors(9) = squarecolors(43)
            squarecolors(43) = squarecolors(52)
            squarecolors(52) = helper
        End If
    End Sub
    Public Sub yrotate(direction As String)
        Dim helper As Brush
        If direction = "normal" Then
            helper = squarecolors(2) 'save face 1 edge
            squarecolors(2) = squarecolors(6)
            squarecolors(6) = squarecolors(8)
            squarecolors(8) = squarecolors(4)
            squarecolors(4) = helper
            helper = squarecolors(3) 'save face 1 corner
            squarecolors(3) = squarecolors(9)
            squarecolors(9) = squarecolors(7)
            squarecolors(7) = squarecolors(1)
            squarecolors(1) = helper
            helper = squarecolors(51) 'save face 2 edge
            squarecolors(51) = squarecolors(53)
            squarecolors(53) = squarecolors(49)
            squarecolors(49) = squarecolors(47)
            squarecolors(47) = helper
            helper = squarecolors(48) 'save face 2 corner
            squarecolors(48) = squarecolors(54)
            squarecolors(54) = squarecolors(52)
            squarecolors(52) = squarecolors(46)
            squarecolors(46) = helper
            helper = squarecolors(10) 'save layer 1 corner 1
            squarecolors(10) = squarecolors(19)
            squarecolors(19) = squarecolors(43)
            squarecolors(43) = squarecolors(34)
            squarecolors(34) = helper
            helper = squarecolors(13) 'save layer 1 edge
            squarecolors(13) = squarecolors(22)
            squarecolors(22) = squarecolors(40)
            squarecolors(40) = squarecolors(31)
            squarecolors(31) = helper
            helper = squarecolors(16) 'save layer 1 corner 2
            squarecolors(16) = squarecolors(25)
            squarecolors(25) = squarecolors(37)
            squarecolors(37) = squarecolors(28)
            squarecolors(28) = helper
            helper = squarecolors(11) 'save layer 2 edge 1
            squarecolors(11) = squarecolors(20)
            squarecolors(20) = squarecolors(44)
            squarecolors(44) = squarecolors(35)
            squarecolors(35) = helper
            helper = squarecolors(17) 'save layer 2 edge 2
            squarecolors(17) = squarecolors(26)
            squarecolors(26) = squarecolors(38)
            squarecolors(38) = squarecolors(29)
            squarecolors(29) = helper
            helper = squarecolors(14) 'save layer 2 center
            squarecolors(14) = squarecolors(23)
            squarecolors(23) = squarecolors(41)
            squarecolors(41) = squarecolors(32)
            squarecolors(32) = helper
            helper = squarecolors(15) 'save layer 3 edge
            squarecolors(15) = squarecolors(24)
            squarecolors(24) = squarecolors(42)
            squarecolors(42) = squarecolors(33)
            squarecolors(33) = helper
            helper = squarecolors(12) 'save layer 3 corner 1
            squarecolors(12) = squarecolors(21)
            squarecolors(21) = squarecolors(45)
            squarecolors(45) = squarecolors(36)
            squarecolors(36) = helper
            helper = squarecolors(18) 'save layer 3 corner 2
            squarecolors(18) = squarecolors(27)
            squarecolors(27) = squarecolors(39)
            squarecolors(39) = squarecolors(30)
            squarecolors(30) = helper
        ElseIf direction = "inverted" Then
            helper = squarecolors(2) 'save face 1 edge
            squarecolors(2) = squarecolors(4)
            squarecolors(4) = squarecolors(8)
            squarecolors(8) = squarecolors(6)
            squarecolors(6) = helper
            helper = squarecolors(3) 'save face 1 corner
            squarecolors(3) = squarecolors(1)
            squarecolors(1) = squarecolors(7)
            squarecolors(7) = squarecolors(9)
            squarecolors(9) = helper
            helper = squarecolors(51) 'save face 2 edge
            squarecolors(51) = squarecolors(47)
            squarecolors(47) = squarecolors(49)
            squarecolors(49) = squarecolors(53)
            squarecolors(53) = helper
            helper = squarecolors(48) 'save face 2 corner
            squarecolors(48) = squarecolors(46)
            squarecolors(46) = squarecolors(52)
            squarecolors(52) = squarecolors(54)
            squarecolors(54) = helper
            helper = squarecolors(10) 'save layer 1 corner 1
            squarecolors(10) = squarecolors(34)
            squarecolors(34) = squarecolors(43)
            squarecolors(43) = squarecolors(19)
            squarecolors(19) = helper
            helper = squarecolors(13) 'save layer 1 edge
            squarecolors(13) = squarecolors(31)
            squarecolors(31) = squarecolors(40)
            squarecolors(40) = squarecolors(22)
            squarecolors(22) = helper
            helper = squarecolors(16) 'save layer 1 corner 2
            squarecolors(16) = squarecolors(28)
            squarecolors(28) = squarecolors(37)
            squarecolors(37) = squarecolors(25)
            squarecolors(25) = helper
            helper = squarecolors(11) 'save layer 2 edge 1
            squarecolors(11) = squarecolors(35)
            squarecolors(35) = squarecolors(44)
            squarecolors(44) = squarecolors(20)
            squarecolors(20) = helper
            helper = squarecolors(17) 'save layer 2 edge 2
            squarecolors(17) = squarecolors(29)
            squarecolors(29) = squarecolors(38)
            squarecolors(38) = squarecolors(26)
            squarecolors(26) = helper
            helper = squarecolors(14) 'save layer 2 center
            squarecolors(14) = squarecolors(32)
            squarecolors(32) = squarecolors(41)
            squarecolors(41) = squarecolors(23)
            squarecolors(23) = helper
            helper = squarecolors(15) 'save layer 3 edge
            squarecolors(15) = squarecolors(33)
            squarecolors(33) = squarecolors(42)
            squarecolors(42) = squarecolors(24)
            squarecolors(24) = helper
            helper = squarecolors(12) 'save layer 3 corner 1
            squarecolors(12) = squarecolors(36)
            squarecolors(36) = squarecolors(45)
            squarecolors(45) = squarecolors(21)
            squarecolors(21) = helper
            helper = squarecolors(18) 'save layer 3 corner 2
            squarecolors(18) = squarecolors(30)
            squarecolors(30) = squarecolors(39)
            squarecolors(39) = squarecolors(27)
            squarecolors(27) = helper
        End If
    End Sub
    Public Sub zrotate(direction As String)
        Dim helper As Brush
        If direction = "normal" Then
            helper = squarecolors(10) 'save face 1 corner
            squarecolors(10) = squarecolors(12)
            squarecolors(12) = squarecolors(18)
            squarecolors(18) = squarecolors(16)
            squarecolors(16) = helper
            helper = squarecolors(13) 'save face 1 edge 
            squarecolors(13) = squarecolors(11)
            squarecolors(11) = squarecolors(15)
            squarecolors(15) = squarecolors(17)
            squarecolors(17) = helper
            helper = squarecolors(37) 'save face 2 corner
            squarecolors(37) = squarecolors(39)
            squarecolors(39) = squarecolors(45)
            squarecolors(45) = squarecolors(43)
            squarecolors(43) = helper
            helper = squarecolors(40) 'save face 2 edge
            squarecolors(40) = squarecolors(38)
            squarecolors(38) = squarecolors(42)
            squarecolors(42) = squarecolors(44)
            squarecolors(44) = helper
            helper = squarecolors(3) 'save layer 1 corner 1
            squarecolors(3) = squarecolors(30)
            squarecolors(30) = squarecolors(54)
            squarecolors(54) = squarecolors(19)
            squarecolors(19) = helper
            helper = squarecolors(9) 'save layer 1 corner 2
            squarecolors(9) = squarecolors(28)
            squarecolors(28) = squarecolors(48)
            squarecolors(48) = squarecolors(21)
            squarecolors(21) = helper
            helper = squarecolors(6) 'save layer 1 edge
            squarecolors(6) = squarecolors(29)
            squarecolors(29) = squarecolors(51)
            squarecolors(51) = squarecolors(20)
            squarecolors(20) = helper
            helper = squarecolors(2) 'save layer 2 edge 1
            squarecolors(2) = squarecolors(33)
            squarecolors(33) = squarecolors(53)
            squarecolors(53) = squarecolors(22)
            squarecolors(22) = helper
            helper = squarecolors(8) 'save layer 2 edge 2
            squarecolors(8) = squarecolors(31)
            squarecolors(31) = squarecolors(47)
            squarecolors(47) = squarecolors(24)
            squarecolors(24) = helper
            helper = squarecolors(5) 'save layer 2 center
            squarecolors(5) = squarecolors(32)
            squarecolors(32) = squarecolors(50)
            squarecolors(50) = squarecolors(23)
            squarecolors(23) = helper
            helper = squarecolors(1) 'save layer 3 corner 1
            squarecolors(1) = squarecolors(36)
            squarecolors(36) = squarecolors(52)
            squarecolors(52) = squarecolors(25)
            squarecolors(25) = helper
            helper = squarecolors(7) 'save layer 3 corner 2
            squarecolors(7) = squarecolors(34)
            squarecolors(34) = squarecolors(46)
            squarecolors(46) = squarecolors(27)
            squarecolors(27) = helper
            helper = squarecolors(4) 'save layer 3 edge
            squarecolors(4) = squarecolors(35)
            squarecolors(35) = squarecolors(49)
            squarecolors(49) = squarecolors(26)
            squarecolors(26) = helper
        ElseIf direction = "inverted" Then
            helper = squarecolors(10) 'save face 1 corner
            squarecolors(10) = squarecolors(16)
            squarecolors(16) = squarecolors(18)
            squarecolors(18) = squarecolors(12)
            squarecolors(12) = helper
            helper = squarecolors(13) 'save face 1 edge 
            squarecolors(13) = squarecolors(17)
            squarecolors(17) = squarecolors(15)
            squarecolors(15) = squarecolors(11)
            squarecolors(11) = helper
            helper = squarecolors(37) 'save face 2 corner
            squarecolors(37) = squarecolors(43)
            squarecolors(43) = squarecolors(45)
            squarecolors(45) = squarecolors(39)
            squarecolors(39) = helper
            helper = squarecolors(40) 'save face 2 edge
            squarecolors(40) = squarecolors(44)
            squarecolors(44) = squarecolors(42)
            squarecolors(42) = squarecolors(38)
            squarecolors(38) = helper
            helper = squarecolors(3) 'save layer 1 corner 1
            squarecolors(3) = squarecolors(19)
            squarecolors(19) = squarecolors(54)
            squarecolors(54) = squarecolors(30)
            squarecolors(30) = helper
            helper = squarecolors(9) 'save layer 1 corner 2
            squarecolors(9) = squarecolors(21)
            squarecolors(21) = squarecolors(48)
            squarecolors(48) = squarecolors(28)
            squarecolors(28) = helper
            helper = squarecolors(6) 'save layer 1 edge
            squarecolors(6) = squarecolors(20)
            squarecolors(20) = squarecolors(51)
            squarecolors(51) = squarecolors(29)
            squarecolors(29) = helper
            helper = squarecolors(2) 'save layer 2 edge 1
            squarecolors(2) = squarecolors(22)
            squarecolors(22) = squarecolors(53)
            squarecolors(53) = squarecolors(33)
            squarecolors(33) = helper
            helper = squarecolors(8) 'save layer 2 edge 2
            squarecolors(8) = squarecolors(24)
            squarecolors(24) = squarecolors(47)
            squarecolors(47) = squarecolors(31)
            squarecolors(31) = helper
            helper = squarecolors(5) 'save layer 2 center
            squarecolors(5) = squarecolors(23)
            squarecolors(23) = squarecolors(50)
            squarecolors(50) = squarecolors(32)
            squarecolors(32) = helper
            helper = squarecolors(1) 'save layer 3 corner 1
            squarecolors(1) = squarecolors(25)
            squarecolors(25) = squarecolors(52)
            squarecolors(52) = squarecolors(36)
            squarecolors(36) = helper
            helper = squarecolors(7) 'save layer 3 corner 2
            squarecolors(7) = squarecolors(27)
            squarecolors(27) = squarecolors(46)
            squarecolors(46) = squarecolors(34)
            squarecolors(34) = helper
            helper = squarecolors(4) 'save layer 3 edge
            squarecolors(4) = squarecolors(26)
            squarecolors(26) = squarecolors(49)
            squarecolors(49) = squarecolors(35)
            squarecolors(35) = helper
        End If
    End Sub
    Private Sub invalidator_Tick(sender As Object, e As EventArgs) Handles invalidator.Tick
        Me.Invalidate() 'mystical all powerful line of code
    End Sub
    Private Sub Scramble_Menu_Click(sender As Object, e As EventArgs) Handles Scramble_Menu.Click
        Reset_Menu_Click(sender, e)
        Randomize()
        Scramble_output.Text = "Scramble:  "
        Dim helper As Integer = 0
        Dim last As Integer = 0
        For i As Integer = 1 To 20
            helper = 0
            While helper = 0
                helper = Int(Rnd() * 18 + 0)
                If ((last = 1 Or last = 2 Or last = 3) And (helper = 1 Or helper = 2 Or helper = 3)) Or ((last = 4 Or last = 5 Or last = 6) And (helper = 4 Or helper = 5 Or helper = 6)) Or ((last = 7 Or last = 8 Or last = 9) And (helper = 7 Or helper = 8 Or helper = 9)) Or ((last = 10 Or last = 11 Or last = 12) And (helper = 10 Or helper = 11 Or helper = 12)) Or ((last = 13 Or last = 14 Or last = 15) And (helper = 13 Or helper = 14 Or helper = 15)) Or ((last = 16 Or last = 17 Or last = 18) And (helper = 16 Or helper = 17 Or helper = 18)) Then
                    helper = 0
                End If
            End While
            last = helper
            If helper = 1 Then
                toprotate("clock")
                Scramble_output.Text = Scramble_output.Text & "U  "
            ElseIf helper = 2 Then
                toprotate("counterclock")
                Scramble_output.Text = Scramble_output.Text & "U'  "
            ElseIf helper = 3 Then
                toprotate("clock")
                toprotate("clock")
                Scramble_output.Text = Scramble_output.Text & "U2  "
            ElseIf helper = 4 Then
                rightrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "R  "
            ElseIf helper = 5 Then
                rightrotate("counterclock")
                Scramble_output.Text = Scramble_output.Text & "R'  "
            ElseIf helper = 6 Then
                rightrotate("clock")
                rightrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "R2  "
            ElseIf helper = 7 Then
                frontrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "F  "
            ElseIf helper = 8 Then
                frontrotate("counterclock")
                Scramble_output.Text = Scramble_output.Text & "F'  "
            ElseIf helper = 9 Then
                frontrotate("clock")
                frontrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "F2  "
            ElseIf helper = 10 Then
                leftrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "L  "
            ElseIf helper = 11 Then
                leftrotate("counterclock")
                Scramble_output.Text = Scramble_output.Text & "L'  "
            ElseIf helper = 12 Then
                leftrotate("clock")
                leftrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "L2  "
            ElseIf helper = 13 Then
                backrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "B  "
            ElseIf helper = 14 Then
                backrotate("counterclock")
                Scramble_output.Text = Scramble_output.Text & "B'  "
            ElseIf helper = 15 Then
                backrotate("clock")
                backrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "B2  "
            ElseIf helper = 16 Then
                bottomrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "D  "
            ElseIf helper = 17 Then
                bottomrotate("counterclock")
                Scramble_output.Text = Scramble_output.Text & "D'  "
            ElseIf helper = 18 Then
                bottomrotate("clock")
                bottomrotate("clock")
                Scramble_output.Text = Scramble_output.Text & "D2  "
            End If
        Next
    End Sub
    Private Sub Reset_Menu_Click(sender As Object, e As EventArgs) Handles Reset_Menu.Click
        'setting back to the initial brush colors
        For i As Integer = 1 To 9
            squarecolors(i) = Brushes.White
        Next
        For i As Integer = 10 To 18
            squarecolors(i) = Brushes.Red
        Next
        For i As Integer = 19 To 27
            squarecolors(i) = Brushes.Blue
        Next
        For i As Integer = 28 To 36
            squarecolors(i) = Brushes.Green
        Next
        For i As Integer = 37 To 45
            squarecolors(i) = Brushes.Orange
        Next
        For i As Integer = 46 To 54
            squarecolors(i) = Brushes.Yellow
        Next
        mode = "play"
    End Sub
    Private Sub Help_Menu_Click(sender As Object, e As EventArgs) Handles Help_Menu.Click
        MessageBox.Show("In 'Play Mode' a side of the cube can be rotated by clicking on that side.  Left-clicking causes a clockwise turn and right-clicking causes a counterclockwise turn." & vbCrLf & "Pressing the keys U, D, R, L, F, B will cause a clockwise turn on the top, bottom, right, left, front, and back sides respectively. " & vbCrLf & "Holding the space bar while pressing these keys will cause a counterclockwise turn." & vbCrLf & "Clicking 'Edit' will allow you to modify the cube colors by clicking on the color buttons and then the square on the cube.  The keys W, R, B, G, O, and Y can also be used to select the colors desired." & vbCrLf & "Clicking 'Reset' will restore the cube's original coloring." & vbCrLf & "Clicking 'Scramble' will set the cube to a random position." & vbCrLf & "Clicking 'Cube Rotate' will rotate the entire cube in the direction of your choosing.  These rotations can also be performed using the X, Y, and Z keys.  Holding space will rotate in the opposite direction.")
    End Sub
    Private Sub EditPlay_Menu_Click(sender As Object, e As EventArgs) Handles EditPlay_Menu.Click
        If mode = "play" Then
            For i As Integer = 1 To 54 'make all da squares gray
                squarecolors(i) = Brushes.Gray
            Next
            mode = "edit"
            EditPlay_Menu.Text = "Play Mode"
        ElseIf mode = "edit" Then
            mode = "play"
            EditPlay_Menu.Text = "Edit Mode"
        End If
    End Sub
    Private Sub X_Menu_Click(sender As Object, e As EventArgs) Handles X_Menu.Click
        xrotate("normal")
    End Sub
    Private Sub XPrime_Menu_Click(sender As Object, e As EventArgs) Handles XPrime_Menu.Click
        xrotate("inverted")
    End Sub
    Private Sub Y_Menu_Click(sender As Object, e As EventArgs) Handles Y_Menu.Click
        yrotate("normal")
    End Sub
    Private Sub YPrime_Menu_Click(sender As Object, e As EventArgs) Handles YPrime_Menu.Click
        yrotate("inverted")
    End Sub
    Private Sub Z_Menu_Click(sender As Object, e As EventArgs) Handles Z_Menu.Click
        zrotate("normal")
    End Sub
    Private Sub ZPrime_Menu_Click(sender As Object, e As EventArgs) Handles ZPrime_Menu.Click
        zrotate("inverted")
    End Sub
End Class
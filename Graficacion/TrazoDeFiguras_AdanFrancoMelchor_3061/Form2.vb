Public Class Form2
    Dim BMP As New Drawing.Bitmap(250, 250)
    Dim GFX As Graphics = Graphics.FromImage(BMP)
    Dim opcion, n As Integer
    Public Sub iniciar(opc As Integer, opc2 As Integer)
        plano()
        opcion = opc
        Form1.Hide()
        If opc = 1 Then
            Label9.Text = "Cuadrado"
            n = 4
        ElseIf opc = 2 Then
            Label9.Text = "Rectangulo"
            n = 4
        ElseIf opc = 3 Then
            Label9.Text = "Triangulo Equilatero"
            Label7.Hide()
            Label5.Hide()
            TextBox7.Hide()
            TextBox8.Hide()
            n = 3
        ElseIf opc = 4 Then
            Label9.Text = "Triangulo Rectabgulo"
            Label7.Hide()
            Label5.Hide()
            TextBox7.Hide()
            TextBox8.Hide()
            n = 3
        End If
        opcion = opc2
        Show()
    End Sub
    Public Sub bresen()
        Dim x1, y1, x2, y2, x3, y3, x4, y4, dx, dy As Integer
        Dim xIn, yIn, x, y, p As Integer

        x1 = TextBox1.Text
        y1 = TextBox2.Text
        x2 = TextBox3.Text
        y2 = TextBox4.Text
        x3 = TextBox5.Text
        y3 = TextBox6.Text
        x4 = 0
        y4 = 0
        If n = 4 Then
            x4 = TextBox7.Text
            y4 = TextBox8.Text
        End If


        Dim xI() As Integer = {x1, x2, x3, x4}
        Dim yI() As Integer = {y1, y2, y3, y4}
        For i = 0 To n - 1
            dx = Asc(xI(n - 1) - xI(i))
            dy = Asc(yI(n - 1) - yI(i))
            p = 2 * dy - dx
            x = x1
            y = y1
            For l = x To x2
                dibujado(x1, y1, x2, y2, x3, y3, x4, y4)
                x += l
                If p > 0 Then
                    p = p + 2 * dy
                Else
                    p = p + (2 * dy) - (2 * dx)
                    y += 1
                End If
                x += xIn
                y += yIn
            Next
        Next

    End Sub
    Public Sub DDA()
        Dim x1, y1, x2, y2, x3, y3, x4, y4, steps, dx, dy As Integer
        Dim xIn, yIn, x, y As Integer

        x1 = TextBox1.Text
        y1 = TextBox2.Text
        x2 = TextBox3.Text
        y2 = TextBox4.Text
        x3 = TextBox5.Text
        y3 = TextBox6.Text
        y4 = 0
        x4 = 0
        If n = 4 Then
            x4 = TextBox7.Text
            y4 = TextBox8.Text
        End If

        Dim xI() As Integer = {x1, x2, x3, x4}
        Dim yI() As Integer = {y1, y2, y3, y4}
        For i = 0 To n - 1
            dx = Asc(xI(n - 1) - xI(i))
            dy = Asc(yI(n - 1) - yI(i))
            steps = 0
            If dx > dy Then
                steps = dx
            Else
                steps = dy
            End If
            xIn = Asc(dx / steps)
            yIn = Asc(dy / steps)
            x = x1
            y = y1

            For l = 1 To steps
                dibujado(x1, y1, x2, y2, x3, y3, x4, y4)
                x += xIn
                y += yIn
            Next l
        Next i


    End Sub
    Public Sub dibujado(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer,
                        x3 As Integer, y3 As Integer, x4 As Integer, y4 As Integer)
        Dim anchura As Integer = PictureBox1.Width
        Dim largo As Integer = PictureBox1.Height
        Dim mitadAnchura As Integer = anchura / 2
        Dim mitadLargo As Integer = largo / 2
        x1 = (x1 * 10) + mitadAnchura
        x2 = (x2 * 10) + mitadAnchura
        x3 = (x3 * 10) + mitadAnchura
        x4 = (x4 * 10) + mitadAnchura
        y1 = mitadLargo - (y1 * 10)
        y2 = mitadLargo - (y2 * 10)
        y3 = mitadLargo - (y3 * 10)
        y4 = mitadLargo - (y4 * 10)

        GFX.DrawLine(Pens.Blue, x1, y1, x2, y2)
        GFX.DrawLine(Pens.Blue, x2, y2, x3, y3)
        If n = 3 Then
            GFX.DrawLine(Pens.Blue, x3, y3, x1, y1)
        ElseIf n = 4 Then
            GFX.DrawLine(Pens.Blue, x3, y3, x4, y4)
            GFX.DrawLine(Pens.Blue, x4, y4, x1, y1)
        End If
        PictureBox1.Image = BMP

    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        plano()
    End Sub
    Public Sub plano()
        Dim anchura As Integer = PictureBox1.Width
        Dim largo As Integer = PictureBox1.Height
        Dim mitadAnchura As Integer = anchura / 2
        Dim mitadLargo As Integer = largo / 2

        GFX.FillRectangle(Brushes.White, 0, 0, PictureBox1.Width, PictureBox1.Height)
        GFX.DrawLine(Pens.Black, mitadAnchura, 0, mitadAnchura, largo)
        GFX.DrawLine(Pens.Black, 0, mitadLargo, anchura, mitadLargo)
        PictureBox1.Image = BMP
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If opcion = 0 Then
            DDA()
        Else
            bresen()
        End If
    End Sub
End Class
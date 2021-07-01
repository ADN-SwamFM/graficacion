Public Class Form2
    Dim BMP As New Drawing.Bitmap(250, 250)
    Dim GFX As Graphics = Graphics.FromImage(BMP)
    Dim opcion, n, lados As Integer
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        plano()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub iniciar(opc As Integer, lado As Integer)
        opcion = opc
        lados = lado
        If opc = 1 Then
            Label1.Text = "DDA"

        Else
            Label1.Text = "Bresenhams"
        End If
        Show()
        plano()
    End Sub
    Public Sub DDA()
        'Dim x1, y1, x2, y2, x3, y3, x4, y4, steps, dx, dy As Integer
        'Dim xIn, yIn, x, y As Integer
        'Dim xI() As Integer = {x1, x2, x3, x4}
        'Dim yI() As Integer = {y1, y2, y3, y4}
        'For i = 0 To n - 1
        '    dx = Asc(xI(n - 1) - xI(i))
        '    dy = Asc(yI(n - 1) - yI(i))
        '    steps = 0
        '    If dx > dy Then
        '        steps = dx
        '    Else
        '        steps = dy
        '    End If
        '    xIn = Asc(dx / steps)
        '    yIn = Asc(dy / steps)
        '    x = x1
        '    y = y1

        '    For l = 1 To steps
        '        dibujado(x1, y1, x2, y2, x3, y3, x4, y4)
        '        x += xIn
        '        y += yIn
        '    Next l
        'Next i
        Dim x1, y1, x2, y2, steps, dx, dy As Integer
        Dim xIn, yIn, x, y As Integer

        'x1 = TextBox1.Text
        'y1 = TextBox3.Text
        'x2 = TextBox2.Text
        'y2 = TextBox4.Text

        dx = Asc(x2 - x1)
        dy = Asc(y2 - y1)
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

        For i = 1 To steps
            'dibujado(x, y, x1, y1, x2, y2)
            dibujado()
            x += xIn
            y += yIn
        Next i

    End Sub
    Public Sub bresen()
        'Dim x1, y1, x2, y2, dx, dy, xIn, yIn As Integer
        'Dim x, y, p As Integer


        'For i = 0 To n - 1
        '    dx = Asc(x2 - x1)
        '    dy = Asc(y2 - y1)
        '    p = 2 * dy - dx
        '    x = x1
        '    y = y1

        '    dibujado(x1, y1)
        '    If p > 0 Then
        '            p = p + 2 * dy
        '        Else
        '            p = p + (2 * dy) - (2 * dx)
        '            y += 1
        '        End If
        '        x += xIn
        '        y += yIn

        'Next
        Dim x1, y1, x2, y2, steps, dx, dy As Integer
        Dim xIn, yIn, x, y, p As Integer

        'x1 = TextBox1.Text
        'y1 = TextBox3.Text
        'x2 = TextBox2.Text
        'y2 = TextBox4.Text

        dx = Asc(x2 - x1)
        dy = Asc(y2 - y1)
        p = 2 * dy - dx
        x = x1
        y = y1
        For i = x To x2
            dibujado()
            x += 1
            If p > 0 Then
                p = p + 2 * dy
            Else
                p = p + (2 * dy) - (2 * dx)
                y += 1
            End If
            x += xIn
            y += yIn
        Next

    End Sub
    Public Sub dibujado()
        Dim anchura As Integer = PictureBox1.Width
        Dim largo As Integer = PictureBox1.Height
        Dim mitadAnchura As Integer = anchura / 2
        Dim mitadLargo As Integer = largo / 2
        Dim x, y, x2, y2, xV, yV, radio As Integer
        radio = 10
        xV = radio * Math.Cos(Math.PI / 180)
        yV = radio * Math.Sin(Math.PI / 180)
        For i = 0 To 360
            x = radio * (Math.Cos(Math.PI / 180 * i))
            y = radio * (Math.Sin(Math.PI / 180 * i))
            GFX.DrawLine(Pens.Blue, ((x * 5) + mitadAnchura), (mitadLargo - (y * 5)), ((x2 * 5) + mitadAnchura), (mitadLargo - (y2 * 5)))
            x2 = x
            y2 = y
            i += 360 / lados
        Next
        GFX.DrawLine(Pens.Red, ((x2 * 5) + mitadAnchura), (mitadLargo - (y2 * 5)), ((xV * 5) + mitadAnchura), (mitadLargo - (yV * 5)))
        PictureBox1.Image = BMP

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If opcion = 0 Then
            DDA()
        Else
            bresen()
        End If
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

End Class
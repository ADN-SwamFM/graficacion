Public Class Form2
    Dim BMP As New Drawing.Bitmap(250, 250)
    Dim GFX As Graphics = Graphics.FromImage(BMP)
    Dim opcion As Integer


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        plano()
    End Sub
    Public Sub iniciar(opc As Integer)
        opcion = opc
        If opc = 1 Then
            Label5.Text = "DDA"

        Else
            Label5.Text = "Bresenhams"
        End If
        Show()
    End Sub
    Public Sub bresen()
        Dim x1, y1, x2, y2, steps, dx, dy As Integer
        Dim xIn, yIn, x, y, p As Integer

        x1 = TextBox1.Text
        y1 = TextBox3.Text
        x2 = TextBox2.Text
        y2 = TextBox4.Text

        dx = Asc(x2 - x1)
        dy = Asc(y2 - y1)
        p = 2 * dy - dx
        x = x1
        y = y1
        For i = x To x2
            dibujado(x, y, x1, y1, x2, y2)
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
    Public Sub DDA()
        Dim x1, y1, x2, y2, steps, dx, dy As Integer
        Dim xIn, yIn, x, y As Integer

        x1 = TextBox1.Text
        y1 = TextBox3.Text
        x2 = TextBox2.Text
        y2 = TextBox4.Text

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
            dibujado(x, y, x1, y1, x2, y2)
            x += xIn
            y += yIn
        Next i

    End Sub
    Public Sub dibujado(x As Integer, y As Integer, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        Dim anchura As Integer = PictureBox1.Width
        Dim largo As Integer = PictureBox1.Height
        Dim mitadAnchura As Integer = anchura / 2
        Dim mitadLargo As Integer = largo / 2
        x1 = (x1) + mitadAnchura
        x2 = (x2) + mitadAnchura

        y1 = mitadLargo - (y1)
        y2 = mitadLargo - (y2)
        x = (x) + mitadAnchura
        y = mitadLargo - (y)
        GFX.DrawLine(Pens.Blue, x1, y1, x2, y2)
        'GFX.setpixel(x, y)
        PictureBox1.Image = BMP

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
        Form1.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        plano()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If opcion = 1 Then
            DDA()
        Else
            bresen()
        End If
    End Sub
End Class
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim algoritmo As Integer
        algoritmo = ComboBox1.SelectedIndex

        If algoritmo = 1 Then
            Form2.iniciar(1)
            Hide()
        ElseIf algoritmo = 2 Then
            Form2.iniciar(2)
            Hide()
        Else
            MessageBox.Show("SELECCIONA UNO")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim algoritmo As Integer
        Dim lados As Integer
        algoritmo = ComboBox1.SelectedIndex
        lados = TextBox1.Text
        If lados > 2 Then
            If algoritmo = 1 Then
                Form2.iniciar(1, lados)
                Hide()
            ElseIf algoritmo = 2 Then
                Form2.iniciar(2, lados)
                Hide()
            Else
                MessageBox.Show("SELECCIONA UNO")
            End If
        Else
            MessageBox.Show("Introduce un valor correctamente")
        End If

    End Sub
End Class

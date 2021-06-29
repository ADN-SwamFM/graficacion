Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim opc, opc2 As Integer

        opc = ComboBox1.SelectedIndex
        opc2 = ComboBox2.SelectedIndex
        If opc2 = 0 Then
            MessageBox.Show("LLena todo")
        Else
            If opc = 1 Then
                Form2.iniciar(1, opc2)
            ElseIf opc = 2 Then
                Form2.iniciar(2, opc2)
            ElseIf opc = 3 Then
                Form2.iniciar(3, opc2)
            ElseIf opc = 4 Then
                Form2.iniciar(4, opc2)
            Else
                MessageBox.Show("LLena todo")
            End If
        End If

    End Sub
End Class

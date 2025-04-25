Public Class DataWindow
    Private Sub DataWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Invoke(Sub() Chart1.Series(0).Points.Clear())
    End Sub
    Public Sub AddPoint(x As Double, y As Double)
        Try
            Invoke(Sub() Chart1.Series(0).Points.AddXY(x, y))
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ClearPoint()
        Invoke(Sub() Chart1.Series(0).Points.Clear())
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ClearPoint()
    End Sub
End Class
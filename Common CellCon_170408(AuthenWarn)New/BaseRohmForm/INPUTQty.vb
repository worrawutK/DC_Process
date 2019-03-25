Public Class INPUTQty

    Protected Overrides ReadOnly Property CreateParams() As CreateParams   'Disable Close(x) Button
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property
    Private Sub K7_Click(sender As System.Object, e As System.EventArgs) Handles K7.Click, K0.Click, K00.Click, K1.Click, K2.Click, K3.Click, K4.Click, K5.Click, K6.Click, K8.Click, K9.Click
        lbResult.Text += CType(sender, Button).Text
    End Sub

  
    Public Function InputQtyShowDialog() As List(Of String)
        Me.ShowDialog()
        Dim Result As New List(Of String)
        Result.Add(CStr(NumCheck))
        If rbnNormalStartTDC.Checked Then

            Result.Add("0")
        ElseIf rbnSeparateStartTDC.Checked Then
            Result.Add("1")

        ElseIf rbnSeparateEndStartTDC.Checked Then
            Result.Add("2")

        End If

        Return Result
    End Function

    Private Sub KBS_Click(sender As System.Object, e As System.EventArgs) Handles KBS.Click
        If lbResult.Text.Length = 0 Then
            Exit Sub
        End If
        lbResult.Text = Microsoft.VisualBasic.Left(lbResult.Text, lbResult.Text.Length - 1)
    End Sub
    Dim NumCheck As Integer
    Private Sub KEnter_Click(sender As System.Object, e As System.EventArgs) Handles KEnter.Click
        'If lbResult.Text = "" Then
        '    Exit Sub
        'End If
        If Not IsNumeric(lbResult.Text) Then
            lbResult.Text = ""
            Exit Sub
        End If
       
        NumCheck = CInt(lbResult.Text)

        If NumCheck = 0 Then
            Exit Sub
        End If

        Me.Close()
    End Sub


    Private Sub KClear_Click(sender As System.Object, e As System.EventArgs) Handles KClear.Click
        lbResult.Text = ""
    End Sub

  
    Private Sub INPUTQty_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        KEnter.Focus()
    End Sub
End Class




Partial Class Payment
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Dim tfee As Double = 0
    Dim totalPay As Double = 0
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (Session("ACC").ToString().Equals("student")) Then
            loadFee(Session("USER").ToString())
            TextBox4.Text = Session("USER").ToString()
        ElseIf (Session("ACC").ToString().Equals("parent")) Then
            Dim par As String = Session("USER").ToString()
            Dim st As String = ts.getParentStudent(par)
            TextBox4.Text = st
            loadFee(st)
        End If

    End Sub
    Public Sub loadFee(ByVal st As String)
        tfee = 0
        Dim tf As Double = ts.getFeebyIntake(ts.getStudentIntake(st))
        tfee += tf
        TextBox1.Text = tf.ToString() + " RM"
        loadOtherCharges(st)
        TextBox2.Text = tfee.ToString() + " RM"
        totalPay = ts.getStudentPayment(st).ToString()
        TextBox3.Text = totalPay.ToString() + " RM"

    End Sub


    Public Sub loadOtherCharges(ByVal st As String)
        Dim ch As List(Of List(Of String)) = ts.getStudentOtherCh(st)
        Table1.Rows.Clear()
        Dim row1 As TableRow = New TableRow
        Dim fcell1 As TableCell = New TableCell
        fcell1.Text = "FEE"
        Dim dcell1 As TableCell = New TableCell
        dcell1.Text = "DESCRIPTION"
        row1.Cells.Add(fcell1)
        row1.Cells.Add(dcell1)
        Table1.Rows.Add(row1)
        For Each e As List(Of String) In ch
            Dim row As TableRow = New TableRow
            Dim fcell As TableCell = New TableCell
            fcell.Text = e.ElementAt(0) + "RM"
            Dim dcell As TableCell = New TableCell
            dcell.Text = e.ElementAt(1)
            tfee += Double.Parse(e.ElementAt(0))
            row.Cells.Add(fcell)
            row.Cells.Add(dcell)
            Table1.Rows.Add(row)
        Next

    End Sub


    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (Session("ACC").ToString().Equals("student")) Then
            Response.Redirect("StudentHome.aspx")
        ElseIf (Session("ACC").ToString().Equals("parent")) Then
            Response.Redirect("ParentHome.aspx")
        End If
    End Sub
End Class


Partial Class Payment
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Dim tfee As Double = 0
    Dim totalPay As Double = 0
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack = False) Then
            loadStudents()
        End If
    End Sub
    Public Sub loadStudents()
        Dim stu As List(Of String) = ts.getStudents()
        DropDownList1.Items.Clear()
        DropDownList1.Items.Add("STUDENTS")
        For Each st As String In stu
            DropDownList1.Items.Add(st)
        Next
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        tfee = 0
        Dim tf As Double = ts.getFeebyIntake(ts.getStudentIntake(DropDownList1.SelectedItem.ToString()))
        tfee += tf
        TextBox1.Text = tf.ToString() + " RM"
        loadOtherCharges()
        TextBox2.Text = tfee.ToString() + " RM"
        totalPay = ts.getStudentPayment(DropDownList1.SelectedItem.ToString()).ToString()
        TextBox3.Text = totalPay.ToString() + " RM"


    End Sub
    Public Sub loadOtherCharges()
        Dim ch As List(Of List(Of String)) = ts.getStudentOtherCh(DropDownList1.SelectedItem.ToString())
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

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pay As Double
        Dim res As Boolean = Double.TryParse(TextBox4.Text, pay)
        If (res = False Or DropDownList1.SelectedItem.ToString().Equals("STUDENT")) Then
            Label4.Text = "Please select the student and enter the valid amount."
            Label4.Visible = True
        End If
        pay += totalPay
        ts.updateStudentPay(DropDownList1.SelectedItem.ToString(), pay)
        Label4.Text = "The payment made successfully."
        Label4.Visible = True
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim charg As Double
        Dim res As Boolean = Double.TryParse(TextBox5.Text, charg)
        If (res = False Or TextBox6.Text.Length < 1) Then
            Label3.Text = "Please insert the description and enter the valid amount."
            Label3.Visible = True
        End If
        ts.addOtherCharge(DropDownList1.SelectedItem.ToString(), charg, TextBox6.Text)
        Label3.Text = "The charge added successfully."
        Label3.Visible = True
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("AdminHome.aspx")
    End Sub
End Class

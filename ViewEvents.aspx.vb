
Partial Class ViewEvents
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (Session("ACC").ToString().Equals("admin")) Then
            Response.Redirect("AdminHome.aspx")
        ElseIf (Session("ACC").ToString().Equals("lecturer")) Then
            Response.Redirect("LecturerHome.aspx")
        ElseIf (Session("ACC").ToString().Equals("student")) Then
            Response.Redirect("StudentHome.aspx")
        ElseIf (Session("ACC").ToString().Equals("parent")) Then
            Response.Redirect("ParentHome.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim eve As List(Of List(Of String)) = ts.ViewEvent()

        Dim row1 As TableRow = New TableRow
        Dim tcell1 As TableCell = New TableCell()
        tcell1.Text = "TITLE"

        Dim dcell1 As TableCell = New TableCell()
        dcell1.Text = "DESCRIPTION"

        Dim dacell1 As TableCell = New TableCell()
        dacell1.Text = "DATE"

        row1.Cells.Add(tcell1)
        row1.Cells.Add(dcell1)
        row1.Cells.Add(dacell1)

        Table1.Rows.Add(row1)


        For Each temo As List(Of String) In eve

            Dim row As TableRow = New TableRow
            Dim tcell As TableCell = New TableCell()
            tcell.Text = temo.ElementAt(0)

            Dim dcell As TableCell = New TableCell()
            dcell.Text = temo.ElementAt(1)

            Dim dacell As TableCell = New TableCell()
            dacell.Text = temo.ElementAt(2)

            row.Cells.Add(tcell)
            row.Cells.Add(dcell)
            row.Cells.Add(dacell)

            Table1.Rows.Add(row)

        Next
    End Sub
End Class

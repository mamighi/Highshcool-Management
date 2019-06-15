
Partial Class StudentTimeTabel
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (Session("ACC").ToString().Equals("student")) Then
            loadtimetabel(Session("USER").ToString())
        ElseIf (Session("ACC").ToString().Equals("parent")) Then
            Dim par As String = Session("USER").ToString()
            Dim st As String = ts.getParentStudent(par)
            loadtimetabel(st)
        End If

    End Sub
    Public Sub loadtimetabel(ByVal st As String)
        Dim modul As List(Of String) = ts.getModuleByIntake(ts.getStudentIntake(st))

        Dim row1 As TableRow = New TableRow()
        Dim codcell1 As TableCell = New TableCell()
        codcell1.Text = "CODE"
        Dim namecell1 As TableCell = New TableCell()
        namecell1.Text = "NAME"

        Dim lecell1 As TableCell = New TableCell()
        lecell1.Text = "LECTURER"

        Dim daycell1 As TableCell = New TableCell()
        daycell1.Text = "DAY"

        Dim durcell1 As TableCell = New TableCell()
        durcell1.Text = "DURATION"

        row1.Cells.Add(codcell1)
        row1.Cells.Add(namecell1)
        row1.Cells.Add(lecell1)
        row1.Cells.Add(daycell1)
        row1.Cells.Add(durcell1)

        Table1.Rows.Add(row1)


        For Each md As String In modul
            Dim det As List(Of String) = ts.getModuleDetails(md)
            Dim row As TableRow = New TableRow()
            Dim codcell As TableCell = New TableCell()
            codcell.Text = md
            Dim namecell As TableCell = New TableCell()
            namecell.Text = det.ElementAt(0)

            Dim lecell As TableCell = New TableCell()
            lecell.Text = det.ElementAt(1)

            Dim daycell As TableCell = New TableCell()
            daycell.Text = det.ElementAt(2)

            Dim durcell As TableCell = New TableCell()
            durcell.Text = det.ElementAt(3)

            row.Cells.Add(codcell)
            row.Cells.Add(namecell)
            row.Cells.Add(lecell)
            row.Cells.Add(daycell)
            row.Cells.Add(durcell)

            Table1.Rows.Add(row)
        Next
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Session("ACC").ToString().Equals("student")) Then
            Response.Redirect("StudentHome.aspx")
        ElseIf (Session("ACC").ToString().Equals("parent")) Then
            Response.Redirect("ParentHome.aspx")
        End If
    End Sub
End Class

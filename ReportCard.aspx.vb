
Partial Class ReportCard
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (Session("ACC").ToString().Equals("student")) Then
            loadRC(Session("USER").ToString())
            TextBox1.Text = Session("USER").ToString()
        ElseIf (Session("ACC").ToString().Equals("parent")) Then
            Dim par As String = Session("USER").ToString()
            Dim st As String = ts.getParentStudent(par)
            TextBox1.Text = st
            loadRC(st)
        End If
    End Sub
    Public Sub loadRC(ByVal st As String)

        Dim att As List(Of List(Of String)) = ts.loadStudentAttendence(st)
        Dim res As List(Of List(Of String)) = ts.loadStudentExamResult(st)

        Dim ids As Integer = 0
        Table1.Rows.Clear()
        Table1.BackColor = System.Drawing.Color.LightBlue
        Dim tbrow1 As TableRow = New TableRow()
        Dim cellId1 As TableCell = New TableCell()
        cellId1.Text = "NUMBER"
        cellId1.Width = 50
        Dim cellSt1 As TableCell = New TableCell()
        cellSt1.Text = "MODULE"
        cellSt1.Width = 150
        Dim cellatt1 = New TableCell()
        cellatt1.Text = "ATTENDENCE"
        cellatt1.Width = 250
        tbrow1.Cells.Add(cellId1)
        tbrow1.Cells.Add(cellSt1)
        tbrow1.Cells.Add(cellatt1)
        Table1.Rows.Add(tbrow1)
        For Each at As List(Of String) In att
            ids = ids + 1
            Dim tbrow As TableRow = New TableRow()
            Dim cellId As TableCell = New TableCell()
            cellId.Text = ids.ToString() + ""
            Dim cellSt As TableCell = New TableCell()
            cellSt.Text = at.ElementAt(0)
            Dim cellatt = New TableCell()
            cellatt.Text = at.ElementAt(1)
            tbrow.Cells.Add(cellId)
            tbrow.Cells.Add(cellSt)
            tbrow.Cells.Add(cellatt)
            Table1.Rows.Add(tbrow)
        Next


        ids = 0
        Table2.Rows.Clear()
        Table2.BackColor = System.Drawing.Color.LightBlue
        tbrow1 = New TableRow()
        cellId1 = New TableCell()
        cellId1.Text = "NUMBER"
        cellId1.Width = 50
        cellSt1 = New TableCell()
        cellSt1.Text = "MODULE"
        cellSt1.Width = 150
        cellatt1 = New TableCell()
        cellatt1.Text = "RESULT"
        cellatt1.Width = 250
        tbrow1.Cells.Add(cellId1)
        tbrow1.Cells.Add(cellSt1)
        tbrow1.Cells.Add(cellatt1)
        Table2.Rows.Add(tbrow1)
        For Each at As List(Of String) In res
            ids = ids + 1
            Dim tbrow As TableRow = New TableRow()
            Dim cellId As TableCell = New TableCell()
            cellId.Text = ids.ToString() + ""
            Dim cellSt As TableCell = New TableCell()
            cellSt.Text = at.ElementAt(0)
            Dim cellatt = New TableCell()
            cellatt.Text = at.ElementAt(1)
            tbrow.Cells.Add(cellId)
            tbrow.Cells.Add(cellSt)
            tbrow.Cells.Add(cellatt)
            Table2.Rows.Add(tbrow)
        Next

    End Sub




    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Session("ACC").ToString().Equals("student")) Then
            Response.Redirect("StudentHome.aspx")
        ElseIf (Session("ACC").ToString().Equals("parent")) Then
            Response.Redirect("ParentHome.aspx")
        End If
    End Sub
End Class

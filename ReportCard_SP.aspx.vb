
Partial Class ReportCard
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack = False) Then
            loadStudent()
        End If
    End Sub
    Public Sub loadStudent()
        Dim students As List(Of String) = New List(Of String)
        students = ts.getStudents()

        DropDownList1.Items.Clear()
        DropDownList1.Items.Add("STUDENTS")
        For Each student As String In students
            DropDownList1.Items.Add(student)
        Next
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        If (DropDownList1.SelectedItem.ToString().Equals("STUDENTS")) Then
            Return
        End If
        Dim att As List(Of List(Of String)) = ts.loadStudentAttendence(DropDownList1.SelectedItem.ToString())
        Dim res As List(Of List(Of String)) = ts.loadStudentExamResult(DropDownList1.SelectedItem.ToString())

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
        If (Session("ACC").ToString().Equals("admin")) Then
            Response.Redirect("AdminHome.aspx")
        Else
            Response.Redirect("LecturerHome.aspx")
        End If
    End Sub
End Class

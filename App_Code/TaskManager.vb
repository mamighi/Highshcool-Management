Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class TaskManager
    Dim SQLConn As SqlConnection = New SqlConnection("Data Source=MOHAMMAD\MOHAMMAD;Initial Catalog=HSMS;Integrated Security=True;")

    Public Function login(ByVal us As String, ByVal pass As String) As String
        Dim cmd = New SqlCommand("SELECT [ACTYP] FROM [USER] WHERE [ID]='" + us + "' AND [PASS]='" + pass + "'")
        Dim retVal As String = "Wrong"

        cmd.Connection = SQLConn


        SQLConn.Open()

        Dim result = cmd.ExecuteScalar()
        If result IsNot Nothing Then
            retVal = result.ToString().TrimEnd()

        End If

        SQLConn.Close()

        Return retVal
    End Function
    Public Function addUser(ByVal us As String, ByVal pas As String, ByVal fn As String, ByVal ln As String, ByVal typ As String) As Boolean
        Dim cmd = New SqlCommand("INSERT INTO [USER] (ID,FNAME,LNAME,PASS,ACTYP) VALUES('" + us + "','" + fn + "','" + ln + "','" + pas + "','" + typ + "')")
        cmd.Connection = SQLConn

        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()

        Return True
    End Function
    Public Function addStudent(ByVal us As String, ByVal intake As String) As Boolean
        Dim cmd = New SqlCommand("INSERT INTO [STUDENT] (ID,INTAKE,FEE,PAYMENT) VALUES('" + us + "','" + intake + "','0','0')")
        cmd.Connection = SQLConn

        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()

        Return True
    End Function
    Public Function addParent(ByVal us As String, ByVal stu As String) As Boolean
        Dim cmd = New SqlCommand("INSERT INTO [PARENT] (ID,ST_ID) VALUES('" + us + "','" + stu + "')")
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
        Return True
    End Function
    Public Function addModule(ByVal code As String, ByVal name As String, ByVal lec As String, ByVal day As String, ByVal dur As Integer, ByVal int As String) As Boolean
        Dim cmd = New SqlCommand("INSERT INTO [MODULE] (CODE,NAME,LE_ID,DAY,DUR,INTAKE) VALUES ('" + code + "','" + name + "','" + lec + "','" + day + "','" & dur & "','" + int + "')")
        cmd.Connection = SQLConn

        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
        Return True

    End Function
    Public Function updateModule(ByVal code As String, ByVal name As String, ByVal lec As String, ByVal day As String, ByVal dur As Integer, ByVal int As String) As Boolean
        Dim cmd = New SqlCommand("UPDATE [MODULE] SET NAME='" + name + "', LE_ID='" + lec + "', DAY='" + day + "', DUR='" & dur & "', INTAKE='" + int + "' WHERE CODE='" + code + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
        Return True
    End Function
    Public Function addIntake(ByVal code As String, ByVal dec As String, ByVal fee As Double) As Boolean
        Dim retVal As Boolean = True

        Dim cmd = New SqlCommand("INSERT INTO [INTAKE] (CODE,FEE,DESCRIPTION) VALUES('" + code + "','" & fee & "','" + dec + "')")

        cmd.Connection = SQLConn

        SQLConn.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            retVal = False
        End Try
        SQLConn.Close()
        Return retVal
    End Function
    Public Function getStudents() As List(Of String)
        Dim students As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT ID FROM [USER] WHERE ACTYP='student'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While (reader.Read())
            students.Add(reader.GetString(0))
        End While
        SQLConn.Close()
        Return students

    End Function

    Public Function getIntakes() As List(Of String)
        Dim intakes As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT CODE FROM [INTAKE]")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While (reader.Read())
            intakes.Add(reader.GetString(0))
        End While
        SQLConn.Close()
        Return intakes
    End Function
    Public Function getLecturer() As List(Of String)
        Dim lecturer As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT ID FROM [USER] WHERE ACTYP='lecturer'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While (reader.Read())
            lecturer.Add(reader.GetString(0))
        End While
        SQLConn.Close()
        Return lecturer
    End Function
    Public Function getModules() As List(Of String)
        Dim modules As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT CODE FROM [MODULE]")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While (reader.Read())
            modules.Add(reader.GetString(0))
        End While
        SQLConn.Close()
        Return modules
    End Function
    Public Function getModuleByIntake(ByVal intake As String) As List(Of String)
        Dim modules As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT CODE FROM [MODULE] WHERE INTAKE='" + intake + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While (reader.Read())
            modules.Add(reader.GetString(0))
        End While
        SQLConn.Close()
        Return modules
    End Function
    Public Sub addAttendec(ByVal studentlst As List(Of String), ByVal attsts As List(Of String), ByVal modul As String, ByVal today As DateTime)
        SQLConn.Open()
        For value As Integer = 0 To studentlst.Count - 1
            Dim cmd = New SqlCommand("INSERT INTO [ATTENDENCE] (MODULE,ST_ID,ATT,DATE) VALUES('" + modul + "', '" + studentlst.ElementAt(value) + "','" + attsts.ElementAt(value) + "','" & today & "')")
            cmd.Connection = SQLConn
            cmd.ExecuteNonQuery()
        Next
        SQLConn.Close()
    End Sub
    Public Function getModuleDetails(ByVal code As String) As List(Of String)
        Dim Details As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT * FROM [MODULE] WHERE CODE='" + code + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If (reader.Read()) Then
            Details.Add(reader.GetString(1))
            Details.Add(reader.GetString(2))
            Details.Add(reader.GetString(3))
            Details.Add(reader.GetInt32(4).ToString())
            Details.Add(reader.GetString(5))
        End If

        SQLConn.Close()
        Return Details
    End Function
    Public Function getStudentByIntake(ByVal intake As String) As List(Of String)
        Dim students As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT ID FROM [STUDENT] WHERE INTAKE='" + intake + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While (reader.Read())
            students.Add(reader.GetString(0))
        End While
        SQLConn.Close()
        Return students
    End Function
    Public Function getUserNames() As List(Of String)
        Dim Users As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT ID FROM [USER]")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While (reader.Read())
            Users.Add(reader.GetString(0))
        End While
        SQLConn.Close()
        Return Users
    End Function
    Public Function getUserDetails(ByVal userName As String) As List(Of String)
        Dim Details As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT * FROM [USER] WHERE ID='" + userName + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If (reader.Read()) Then
            Details.Add(reader.GetString(1))
            Details.Add(reader.GetString(2))
            Details.Add(reader.GetString(3))
            Details.Add(reader.GetString(4))

        End If

        SQLConn.Close()
        Return Details
    End Function
    Public Function getStudentIntake(ByVal userName As String) As String
        Dim Intake As String = ""
        Dim cmd = New SqlCommand("SELECT INTAKE FROM [STUDENT] WHERE ID='" + userName + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If (reader.Read()) Then
            Intake = reader.GetString(0)
        End If

        SQLConn.Close()
        Return Intake
    End Function
    Public Function getParentStudent(ByVal userName As String) As String
        Dim student As String = ""
        Dim cmd = New SqlCommand("SELECT ST_ID FROM [PARENT] WHERE ID='" + userName + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If (reader.Read()) Then
            student = reader.GetString(0)
        End If

        SQLConn.Close()
        Return student
    End Function
    Public Sub updateUser(ByVal un As String, fn As String, ln As String, pas As String)
        Dim cmd = New SqlCommand("UPDATE [USER] SET FNAME='" + fn + "',LNAME='" + ln + "',PASS='" + pas + "' WHERE ID='" + un + "' ")
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub
    Public Sub updateStudentIntake(ByVal un As String, intake As String)
        Dim cmd = New SqlCommand("UPDATE [STUDENT] SET INTAKE='" + intake + "' WHERE ID='" + un + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()

    End Sub
    Public Sub updateParentStudent(ByVal un As String, stid As String)
        Dim cmd = New SqlCommand("UPDATE [PARENT] SET ST_ID='" + stid + "' WHERE ID='" + un + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub

    Public Function getIntakeDetails(ByVal intake As String) As List(Of String)
        Dim details As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT * FROM [INTAKE] WHERE CODE='" + intake + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()

        Dim read As SqlDataReader = cmd.ExecuteReader()
        If (read.Read()) Then
            details.Add(read.GetString(2))
            details.Add(read.GetDouble(1).ToString())
        End If
        SQLConn.Close()
        Return details
    End Function
    Public Function getFeebyIntake(ByVal intake As String) As Double
        Dim cmd = New SqlCommand("SELECT FEE FROM [INTAKE] WHERE CODE='" + intake + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim fee As Double = 0
        Dim read As SqlDataReader = cmd.ExecuteReader()
        If (read.Read()) Then
            fee = read.GetDouble(0)
        End If
        SQLConn.Close()
        Return fee
    End Function
    Public Sub updateIntake(ByVal intake As String, des As String, fee As Double)
        Dim cmd = New SqlCommand("UPDATE [INTAKE] SET FEE='" & fee & "', DESCRIPTION='" + des + "' WHERE CODE='" + intake + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub
    Public Function getStudentOtherCh(ByVal st As String) As List(Of List(Of String))
        Dim retVal As List(Of List(Of String)) = New List(Of List(Of String))
        Dim eachRow As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT * FROM CHARGES WHERE ST_ID='" + st + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim read As SqlDataReader = cmd.ExecuteReader()
        While (read.Read())
            eachRow = New List(Of String)
            eachRow.Add(read.GetDouble(1).ToString())
            eachRow.Add(read.GetString(2))
            retVal.Add(eachRow)
        End While
        SQLConn.Close()
        Return retVal
    End Function
    Public Function getStudentPayment(ByVal st As String) As Double
        Dim payed As Double = 0
        Dim cmd = New SqlCommand("SELECT PAYMENT FROM [STUDENT] WHERE ID='" + st + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim read As SqlDataReader = cmd.ExecuteReader()
        If (read.Read()) Then
            payed = read.GetDouble(0)

        End If
        SQLConn.Close()
        Return payed
    End Function
    Public Sub updateStudentPay(ByVal st As String, amount As Double)
        Dim cmd = New SqlCommand("UPDATE [STUDENT] SET PAYMENT='" & amount & "' WHERE ID='" + st + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub
    Public Sub addOtherCharge(ByVal st As String, amount As Double, des As String)
        Dim cmd = New SqlCommand("INSERT INTO [CHARGES] (ST_ID,FEE,DESCRIPTION) VALUES('" + st + "','" & amount & "','" + des + "')")
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub
    Public Sub PublishResult(ByVal modul As String, ByVal studentlst As List(Of String), ByVal rests As List(Of String))
        SQLConn.Open()
        For value As Integer = 0 To studentlst.Count - 1
            Dim cmd = New SqlCommand("INSERT INTO [RESULT] (MODULE,ST_ID,RESULT) VALUES('" + modul + "', '" + studentlst.ElementAt(value) + "','" + rests.ElementAt(value) + "')")
            cmd.Connection = SQLConn
            cmd.ExecuteNonQuery()
        Next
        SQLConn.Close()
    End Sub
    Public Function isResultPublished(ByVal modul As String) As Boolean
        Dim ret As Boolean = False
        Dim cmd = New SqlCommand("SELECT * FROM [RESULT] WHERE MODULE='" + modul + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim read As SqlDataReader = cmd.ExecuteReader()
        If read.Read() Then
            ret = True
        End If
        SQLConn.Close()
        Return ret

    End Function
    Public Sub AddEvent(ByVal tit As String, des As String, da As DateTime)
        Dim cmd = New SqlCommand("INSERT INTO [EVENT] (TIT,DES,DATE) VALUES('" + tit + "','" + des + "','" & da & "')")
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub
    Public Function ViewEvent() As List(Of List(Of String))
        Dim retVal As List(Of List(Of String)) = New List(Of List(Of String))
        Dim cmd = New SqlCommand("SELECT * FROM [EVENT]")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim read As SqlDataReader = cmd.ExecuteReader
        While read.Read()
            Dim temp As List(Of String) = New List(Of String)
            temp.Add(read.GetString(0))
            temp.Add(read.GetString(1))
            temp.Add(read.GetDateTime(2).ToString())
            retVal.Add(temp)
        End While
        Return retVal
    End Function
    Public Function loadStudentAttendence(ByVal st As String) As List(Of List(Of String))
        Dim att As List(Of List(Of String)) = New List(Of List(Of String))
        Dim at As List(Of String) = New List(Of String)
        Dim moduls As List(Of String) = getModuleByIntake(getStudentIntake(st))
        For Each mo In moduls
            at = New List(Of String)
            Dim tt As Integer = 0
            Dim ta As Integer = 0
            Dim cmd = New SqlCommand("SELECT ATT FROM [ATTENDENCE] WHERE ST_ID='" + st + "' AND MODULE='" + mo + "'")
            cmd.Connection = SQLConn
            SQLConn.Open()
            Dim read As SqlDataReader = cmd.ExecuteReader()
            While (read.Read)
                If (read.GetString(0).Equals("PRESENT") Or read.GetString(0).Equals("ABSENT WITH REASON")) Then
                    ta += 1
                End If
                tt += 1
            End While
            at.Add(mo)
            at.Add((ta / tt * 100).ToString() + "%")
            att.Add(at)
            SQLConn.Close()
        Next
        Return att
    End Function
    Public Function loadClassAttendence(ByVal md As String, intake As String) As List(Of List(Of String))
        Dim st As List(Of String) = getStudentByIntake(intake)
        Dim retVal As List(Of List(Of String)) = New List(Of List(Of String))
        For Each s As String In st
            Dim at As List(Of String) = New List(Of String)
            Dim tt As Integer = 0
            Dim ta As Integer = 0
            Dim cmd = New SqlCommand("SELECT ATT FROM [ATTENDENCE] WHERE ST_ID='" + s + "' AND MODULE='" + md + "'")
            cmd.Connection = SQLConn
            SQLConn.Open()
            Dim read As SqlDataReader = cmd.ExecuteReader()
            While (read.Read)
                If (read.GetString(0).Equals("PRESENT") Or read.GetString(0).Equals("ABSENT WITH REASON")) Then
                    ta += 1
                End If
                tt += 1
            End While
            at.Add(s)
            at.Add((ta / tt * 100).ToString() + "%")
            retVal.Add(at)
            SQLConn.Close()


        Next

        Return retVal

    End Function
    Public Function loadStudentExamResult(ByVal st As String) As List(Of List(Of String))
        Dim att As List(Of List(Of String)) = New List(Of List(Of String))
        Dim at As List(Of String) = New List(Of String)
        Dim cmd = New SqlCommand("SELECT * FROM [RESULT] WHERE ST_ID='" + st + "'")
        cmd.Connection = SQLConn
        SQLConn.Open()
        Dim read As SqlDataReader = cmd.ExecuteReader()
        While (read.Read())
            at = New List(Of String)
            at.Add(read.GetString(0))
            at.Add(read.GetString(2))
            att.Add(at)
        End While
        SQLConn.Close()
        Return att
    End Function
End Class

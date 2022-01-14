Imports System.Data.OleDb
Public Class Form2
    Dim con As New OleDbConnection
    Dim adapter1 As OleDbDataAdapter
    Dim adapter2 As OleDbDataAdapter
    Dim myDataSet1 As New DataSet
    Dim myDataSet2 As New DataSet
    Dim command As New OleDbCommand
    Dim mycount As Integer = 0
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\phili\source\repos\Projektarbeit-2021\IFB_DB.accdb"
        con.Open()
        command.Connection = con
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        adapter1 = New OleDbDataAdapter("SELECT * FROM Benutzer;", con)
        adapter2 = New OleDbDataAdapter("SELECT * FROM Arbeitsvorräte;", con)
        adapter1.Fill(myDataSet1)
        adapter2.Fill(myDataSet2)
        Me.DataGridView1.DataSource = myDataSet1.Tables(0)

        Try

            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                If myDataSet1.Tables(0).Rows(i).ItemArray(0) = txtUsername.Text Then
                    mycount = i
                    MsgBox(mycount)
                    myDataSet2.Tables(0).Rows(mycount).ItemArray(11) = txtUsername.Text


                    Exit For

                End If


            Next i
        Catch ex As Exception

        End Try
    End Sub

End Class
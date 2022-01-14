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
        Form1.Hide()
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Info2.R1PC05\source\repos\Projektarbeit-2021\Projektarbeit-2021\IFB_DB.accdb"
        con.Open()
        command.Connection = con
        adapter2 = New OleDbDataAdapter("SELECT Benutzername FROM Benutzer;", con)
        adapter2.Fill(myDataSet2)
        Me.DataGridView2.DataSource = myDataSet2.Tables(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            adapter1 = New OleDbDataAdapter("SELECT * FROM Arbeitsvorräte;", con)
            adapter1.Fill(myDataSet1)
            Me.DataGridView1.DataSource = myDataSet1.Tables(0)

            myDataSet1.Tables.Clear()
            command.CommandText = "UPDATE Arbeitsvorräte SET GeplanterFertiger = '" + txtUsername.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
            command.ExecuteNonQuery()

            command.CommandText = "UPDATE Arbeitsvorräte SET Starttermin = '" + txtStart.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
            command.ExecuteNonQuery()

            command.CommandText = "UPDATE Arbeitsvorräte SET Endtermin = '" + txtEnd.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
            command.ExecuteNonQuery()




        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Close()
    End Sub

End Class

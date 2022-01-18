Imports System.Data.OleDb

Public Class Form2
    Dim con As New OleDbConnection
    Dim adapter1 As OleDbDataAdapter
    Dim adapter2 As OleDbDataAdapter
    Dim adapter3 As OleDbDataAdapter
    Dim adapter4 As OleDbDataAdapter
    Dim adapter5 As OleDbDataAdapter
    Dim adapter6 As OleDbDataAdapter
    Dim myDataSet1 As New DataSet
    Dim myDataSet2 As New DataSet
    Dim myDataSet3 As New DataSet
    Dim myDataSet4 As New DataSet
    Dim myDataSet5 As New DataSet
    Dim myDataSet6 As New DataSet
    Dim command As New OleDbCommand
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Hide()

        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Info2.R1PC05\source\repos\Projektarbeit-2021\IFB_DB.accdb"
        con.Open()
        command.Connection = con

        adapter1 = New OleDbDataAdapter("SELECT Benutzername FROM Benutzer;", con)
        adapter1.Fill(myDataSet1)
        Me.DataGridView1.DataSource = myDataSet1.Tables(0)
        adapter2 = New OleDbDataAdapter("SELECT Auftragsnummer, Fertiger, Artikelnr, Bezeichnung, Menge, BereitsGefertigt, Bereitgestellt, Starttermin, Endtermin FROM Arbeitsvorräte;", con)
        adapter2.Fill(myDataSet2)
        Me.DataGridView2.DataSource = myDataSet2.Tables(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If txtUsername.Text = String.Empty Or txtNr.Text = String.Empty Or txtStart.Text = String.Empty Or txtEnd.Text = String.Empty Then
            MsgBox("Bitte geben sie Daten an")
        End If
        Try

            Me.myDataSet2.Tables.Clear()
            command.CommandText = "UPDATE Arbeitsvorräte SET Fertiger = '" + txtUsername.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
            command.ExecuteNonQuery()

            command.CommandText = "UPDATE Arbeitsvorräte SET Starttermin = '" + txtStart.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
            command.ExecuteNonQuery()

            command.CommandText = "UPDATE Arbeitsvorräte SET Endtermin = '" + txtEnd.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
            command.ExecuteNonQuery()


            adapter1 = New OleDbDataAdapter("SELECT Benutzername FROM Benutzer;", con)
            adapter1.Fill(myDataSet1)
            Me.DataGridView1.DataSource = myDataSet1.Tables(0)

            adapter2 = New OleDbDataAdapter("SELECT Auftragsnummer, Fertiger, Artikelnr, Bezeichnung, Menge, BereitsGefertigt, Bereitgestellt, Starttermin, Endtermin FROM Arbeitsvorräte;", con)
            adapter2.Fill(myDataSet2)
            Me.DataGridView2.DataSource = myDataSet2.Tables(0)
            MsgBox("Daten wurden gelesen")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.myDataSet3.Tables.Clear()
        adapter3 = New OleDbDataAdapter("SELECT Benutzername FROM Benutzer WHERE Benutzername = '" + txtSuchen.Text + "';", con)
        adapter3.Fill(myDataSet3)
        Me.DataGridView1.DataSource = myDataSet3.Tables(0)

        myDataSet4.Tables.Clear()
        adapter4 = New OleDbDataAdapter("SELECT * FROM Arbeitsvorräte WHERE Fertiger = '" + txtSuchen.Text + "';", con)
        adapter4.Fill(myDataSet4)
        Me.DataGridView2.DataSource = myDataSet4.Tables(0)

    End Sub




End Class

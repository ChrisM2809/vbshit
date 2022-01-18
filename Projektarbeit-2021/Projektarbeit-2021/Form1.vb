Imports System.Data.OleDb

Public Class Form1
    Dim con As New OleDbConnection
    Dim adapter1 As OleDbDataAdapter
    Dim adapter2 As OleDbDataAdapter
    Dim adapter3 As OleDbDataAdapter
    Dim myDataSet1 As New DataSet
    Dim myDataSet2 As New DataSet
    Dim myDataSet3 As New DataSet
    Dim command As New OleDbCommand
    Dim mycheck As Boolean = False
    Dim mystop As Boolean = False


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Info2.R1PC05\source\repos\Projektarbeit-2021\IFB_DB.accdb"
        con.Open()
        command.Connection = con
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mycheck = True
        adapter1 = New OleDbDataAdapter("SELECT * FROM Benutzer;", con)
        adapter2 = New OleDbDataAdapter("SELECT Auftragsnummer, Fertiger, Artikelnr, Bezeichnung, Menge, BereitsGefertigt, Bereitgestellt, Starttermin, Endtermin FROM Arbeitsvorräte;", con)
        adapter3 = New OleDbDataAdapter("SELECT * FROM Arbeitsvorräte WHERE Fertiger = '" + txtUsername.Text + "';", con)
        adapter1.Fill(myDataSet1)
        adapter2.Fill(myDataSet2)
        adapter3.Fill(myDataSet3)
        Form2.DataGridView2.DataSource = myDataSet1.Tables(0)
        For i As Integer = 0 To Form2.DataGridView2.Rows.Count - 1
            Try
                If myDataSet1.Tables(0).Rows(i).ItemArray(0) = txtUsername.Text And myDataSet1.Tables(0).Rows(i).ItemArray(1) = txtPassword.Text Then
                    mystop = True
                    If myDataSet1.Tables(0).Rows(i).ItemArray(2) = mycheck Then         'Produktionsleiter
                        Form2.DataGridView2.DataSource = myDataSet2.Tables(0)
                        Form2.Show()
                    End If
                    If myDataSet1.Tables(0).Rows(i).ItemArray(3) = mycheck Then         'Teamleiter
                        Form2.DataGridView2.DataSource = myDataSet2.Tables(0)
                        Form4.Show()
                    End If
                    If myDataSet1.Tables(0).Rows(i).ItemArray(4) = mycheck Then         'Fertiger
                        Form3.DataGridView1.DataSource = myDataSet3.Tables(0)
                        Form3.Show()
                    End If
                    If myDataSet1.Tables(0).Rows(i).ItemArray(5) = mycheck Then         'User
                        Form3.DataGridView1.DataSource = myDataSet3.Tables(0)
                        Form3.Show()
                    End If
                    If myDataSet1.Tables(0).Rows(i).ItemArray(6) = mycheck Then         'User
                        Form3.DataGridView1.DataSource = myDataSet3.Tables(0)
                        Form3.Show()
                    End If
                    If myDataSet1.Tables(0).Rows(i).ItemArray(7) = mycheck Then         'User
                        Form3.DataGridView1.DataSource = myDataSet3.Tables(0)
                        Form3.Show()
                    End If
                    If myDataSet1.Tables(0).Rows(i).ItemArray(8) = mycheck Then         'User
                        Form3.DataGridView1.DataSource = myDataSet3.Tables(0)
                        Form3.Show()
                    End If
                    Exit For
                End If
            Catch ex As Exception

            End Try
        Next i

        If mystop = False Then
            txtUsername.Text = " "
            txtPassword.Text = " "
            MsgBox("falsche Eingabe!")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub



End Class
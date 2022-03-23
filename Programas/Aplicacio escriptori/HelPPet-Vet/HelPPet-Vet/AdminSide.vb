Imports MySql.Data.MySqlClient
Public Class AdminSide




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub VeterinarioToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub



    Private Sub tp2_2_Click(sender As Object, e As EventArgs) Handles tp2_2.Click

    End Sub

    Private Sub cliv_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub clv_TextChanged(sender As Object, e As EventArgs) Handles clv.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim no As Boolean = True ''Evitara la insercion de datos sin tener todos los campos llenos
        Dim MySQLDA As MySqlDataAdapter
        Dim DT As New DataTable
        Dim reg As MySqlDataReader
        Dim pk As MySqlDataReader
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
        Dim Query As String
        Dim comando As New MySqlCommand(Query, Connection)
        Dim MySQLCMD As New MySqlCommand
        If (uv.Text = "") Or (pv.Text = "") Or (cv.Text = "") Or (nv.Text = "") Or (clv.Text = "") Then
            MsgBox("¡Inserte valores en los campos vacios!")
        Else
            ''mirar usuari
            Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
            Connection.Open()
            MySQLCMD.CommandText = "SELECT * FROM veterinari WHERE Usuari LIKE '" & uv.Text & "'"
            MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
            Data1 = MySQLDA.Fill(DT)
            Connection.Close()
            ''mirar Primary key
            Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
            Connection.Open()
            MySQLCMD.CommandText = "SELECT * FROM veterinari WHERE codi= " & cv.Text
            MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
            Data2 = MySQLDA.Fill(DT)
            Connection.Close()
            no = False
        End If
        ''si los datos no se han insertado no realizara el registro de estos
        If no = False Then
            ''si no exist lo crea
            If (Data1 <= 0) And (Data2 <= 0) Then
                Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
                comando.CommandText = "INSERT INTO `veterinari`(`codi`, `nom`, `clinica`, `Usuari`, `password`) VALUES(@codi,@nom,@clinica,@Usuari,@password)"
                comando.Parameters.AddWithValue("@codi", cv.Text)
                comando.Parameters.AddWithValue("@nom", nv.Text)
                comando.Parameters.AddWithValue("@clinica", clv.Text)
                comando.Parameters.AddWithValue("@Usuari", uv.Text)
                comando.Parameters.AddWithValue("@password", pv.Text)
                Connection.Open()
                comando.ExecuteNonQuery()
                Connection.Close()
                MsgBox("¡Veterinario Registrado!")
                ''pondra los textbox vacios
                cv.Text = ""
                nv.Text = ""
                clv.Text = ""
                uv.Text = ""
                pv.Text = ""
            Else
                MsgBox("¡Datos invalidos(Puede ser que ya exista el usuario de " + uv.Text + " , o que el Veterinario " + cv.Text + " ya este registrado)!")
            End If
        End If



    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles pv.TextChanged

    End Sub

    Private Sub s_Click(sender As Object, e As EventArgs) Handles s.Click

    End Sub

    Private Sub n_Click(sender As Object, e As EventArgs) Handles n.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles idv.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim MySQLDA As MySqlDataAdapter
        Dim DT As New DataTable
        Dim reg As MySqlDataReader
        Dim Data1 As Integer
        Dim Connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
        Dim Query As String
        Dim comando As New MySqlCommand(Query, Connection)
        Dim MySQLCMD As New MySqlCommand
        ''valida que el textbox este lleno
        If idv.Text = "" Then
            MsgBox("Inserta una id")

        Else
            ''busca la id insertada por el usuario en la base de datos
            Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
            Connection.Open()
            MySQLCMD.CommandText = "SELECT codi FROM veterinari WHERE codi = '" & idv.Text & "'"
            MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
            Data1 = MySQLDA.Fill(DT)
            Connection.Close()
        End If
        ''si exist lo elimina
        If (Data1 > 0) Then
            Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
            comando.CommandText = "DELETE FROM `veterinari` WHERE codi =" & idv.Text
            Connection.Open()
            comando.ExecuteNonQuery()
            Connection.Close()
            n.Visible = False
            s.Visible = True
            idv.Text = ""
        Else
            s.Visible = False
            n.Visible = True
            idv.Text = ""

        End If
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        '' cotnador para saber si el usuario esta compuesto de letras unicamente
        Dim c As String = 0
        ''
        Dim c2 As Integer = 0
        ''fecha
        Dim fecha As String = DateAndTime.Day(Now).ToString + "\" + DateAndTime.Month(Now).ToString + "\" + DateAndTime.Year(Now).ToString
        ''comprobar que los campos estan llenos
        If (uno.Text = "") And (uad.Text = "") And (upas.Text = "") Then
            MsgBox("¡Faltan campos por rellenar!")
            ''si el texto i la contraseña son iguales al tamaño maximo permitido por el textbox,realizara las comprobaciones
        ElseIf (uad.TextLength = 3) And (upas.TextLength = 4) Then

            uno1.Text = uno.Text
            c2 += 1
            ''comprueba que la informacion de la contraseña sea numerica (unicamente)
            If IsNumeric(upas.Text) Then
                upas.Text = upas.Text
                AP.Text = upas.Text
                c2 += 1
            Else
                ''si no lo es dara error
                MsgBox("¡Solo se pueden realizar contraseñas de caracter Numericas!")
                upas.Text = ""
            End If
            ''comprueba letra por letra, que sean de caracter alfabetico
            For i As Integer = 0 To 2
                If Char.IsLetter(uad.Text(i)) Then

                Else
                    c += 1

                End If
            Next
            If c = 0 Then
                uad.Text = uad.Text
                AU.Text = uad.Text
                c2 += 1
            Else
                MsgBox("¡Solo se pueden realizar usuarios de caracter Alfabético!")
                uad.Text = ""
                ''si no lo es dara error
            End If
            '' si todos los campos son correctos se realizara el cambio
            If c2 = 3 Then
                Dim path As String = My.Computer.FileSystem.CurrentDirectory + "\\admin.txt"
                Dim File As System.IO.StreamWriter
                System.IO.File.WriteAllText(path, "")
                If My.Computer.FileSystem.FileExists(path) Then
                    File = My.Computer.FileSystem.OpenTextFileWriter(path, True)
                    File.WriteLine(uno1.Text + " " + uad.Text + " " + AP.Text + " " + fecha)
                    File.Close()
                    MsgBox("¡Usuario Modificado con exito!")
                    user.Text = "Administrador"
                    uad.Text = ""
                    upas.Text = ""
                    uno.Text = ""
                    uac.Text = "ModifIcado"
                Else
                    System.IO.File.Create(path).Dispose()
                    File = My.Computer.FileSystem.OpenTextFileWriter(path, False)
                    File.WriteLine(uno1.Text + " " + uad.Text + " " + AP.Text + " " + DateAndTime.Day(Now) + "\" + DateAndTime.Month(Now) + "\" + DateAndTime.Year(Now))
                    File.Close()
                    MsgBox("¡Usuario Modificado con exito!")
                    uad.Text = ""
                    upas.Text = ""
                    uno.Text = ""
                    uac.Text = "ModifIcado"
                End If
            End If

            Else
            MsgBox("¡Es posible que los campos esten completos de forma incompleta(el usuario tiene de contener 3 letras y la contraseña 4 digitos)!")

        End If
    End Sub

    Private Sub uad_TextChanged(sender As Object, e As EventArgs) Handles uad.TextChanged

    End Sub

    Private Sub upas_TextChanged(sender As Object, e As EventArgs) Handles upas.TextChanged



    End Sub

    Private Sub cv_TextChanged(sender As Object, e As EventArgs) Handles cv.TextChanged

    End Sub

    Private Sub Update(sender As Object, e As EventArgs) Handles TabControl1.Click
        Dim fileReader As String
        Dim path As String = ".\\\\admin\\admin.txt"
        If My.Computer.FileSystem.FileExists(path) Then
            fileReader = My.Computer.FileSystem.ReadAllText(path)
            Dim dades() As String = Split(fileReader)
            uno1.Text = dades(0).ToString
            AU.Text = dades(1).ToString
            AP.Text = dades(2).ToString
            uac.Text = dades(3).ToString
        End If
    End Sub
End Class

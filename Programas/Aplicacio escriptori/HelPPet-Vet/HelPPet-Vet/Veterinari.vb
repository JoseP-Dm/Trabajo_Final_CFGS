Imports MySql.Data.MySqlClient

Public Class Veterinari
    Dim revision As Boolean = False

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mascota.SelectedIndexChanged


    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Veterinari_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) 
        If p1.Text = "" Then
            MsgBox("Indique datos para realizar una busqueda")
        Else
            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT br6yuhxjtf6d9t43hrii.propietari.DNI,br6yuhxjtf6d9t43hrii.propietari.nom From br6yuhxjtf6d9t43hrii.propietari Where br6yuhxjtf6d9t43hrii.propietari.nom Like '%" & p1.Text & "%'", connection)


            Dim table As New DataTable()
            adapter.Fill(table)

            clientcombo.DataSource = table
            clientcombo.ValueMember = "DNI"
            clientcombo.DisplayMember = "nom"
        End If

    End Sub

    Private Sub p2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub registrar_mascota_Click(sender As Object, e As EventArgs) Handles registrar_mascota.Click
        Dim prope As String = ""
        Dim data As String = fecha_nacimiento.Value.ToString("yyyy-M-d")
        ''conexion sql
        Dim no As Boolean = True ''Evitara la insercion de datos sin tener todos los campos llenos
        Dim MySQLDA As MySqlDataAdapter
        Dim DT As New DataTable
        Dim reg As MySqlDataReader
        Dim pk As MySqlDataReader
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
        Dim Query As String
        Dim comando As New MySqlCommand(Query, Connection)
        Dim MySQLCMD As New MySqlCommand
        ''variables para los campos
        Dim c As Integer = 0
        Dim c1 As Integer = 0
        Dim c2 As Integer = 0
        Dim c3 As Integer = 0
        Dim c4 As Integer = 0
        Dim c5 As Integer = 0
        Dim c6 As Integer = 0
        Dim tipo As String
        Dim sexo As String
        Dim tamaño As String
        Dim castrado As String
        Dim pelo As String

        If (propietarioc.Text = "") Then

        Else
            prope = propietarioc.SelectedValue.ToString()

            If (nombre_mascota.Text = "") Then
            Else
                If (raza_mascota.Text = "") Then
                Else
                    If (color_mascota.Text = "") Then
                    Else
                        If ((microxip.Text = "") Or (microxip.TextLength < 15)) Then
                        Else
                            For i As Integer = 0 To 14
                                If Char.IsNumber(microxip.Text(i)) Then
                                    c += 1
                                Else


                                End If
                            Next
                            If (c = 15) Then
                                If (perro.Checked = True) Then
                                    c1 = 1
                                    tipo = "Perro"
                                End If
                                If (roedor.Checked = True) Then
                                    c1 = 1
                                    tipo = "Roedor"
                                End If
                                If (gato.Checked = True) Then
                                    c1 = 1
                                    tipo = "Gato"
                                End If
                                If (ave.Checked = True) Then
                                    c1 = 1
                                    tipo = "Ave"
                                End If
                                If (reptil.Checked = True) Then
                                    c1 = 1
                                    tipo = "Reptil"
                                End If
                                If c1 = 1 Then
                                    If (macho.Checked = True) Then
                                        c2 = 1
                                        sexo = "Macho"
                                    End If
                                    If (hembra.Checked = True) Then
                                        c2 = 1
                                        sexo = "Hembra"
                                    End If
                                    If c2 = 1 Then
                                        If (grande.Checked = True) Then
                                            c3 = 1
                                            tamaño = "Grande"
                                        End If
                                        If (mediano.Checked = True) Then
                                            c3 = 1
                                            tamaño = "mediano"
                                        End If
                                        If (pequeño.Checked = True) Then
                                            c3 = 1
                                            tamaño = "Pequeño"
                                        End If

                                        If c3 = 1 Then
                                            If csi.Checked = True Then
                                                c4 = 1
                                                castrado = "Castrado"
                                            End If
                                            If cno.Checked = True Then
                                                c4 = 1
                                                castrado = "Sin Castrar"
                                            End If

                                        End If
                                        If c4 = 1 Then
                                            If pl.Checked = True Then
                                                c5 = 1
                                                pelo = "Largo"
                                            End If
                                            If psl.Checked = True Then
                                                c5 = 1
                                                pelo = "Semi Largo"
                                            End If
                                            If plc.Checked = True Then
                                                c5 = 1
                                                pelo = "Corto"
                                            End If
                                        Else

                                        End If
                                        If peso.Text = "" Then
                                        Else

                                            c6 = 1
                                        End If
                                    Else
                                    End If

                                    If c6 = 1 Then
                                        Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
                                        Connection.Open()
                                        MySQLCMD.CommandText = "SELECT * FROM `mascota` WHERE codi ='" & microxip.Text & "'"
                                        MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
                                        Data1 = MySQLDA.Fill(DT)
                                        Connection.Close()
                                        ''insertar mascota
                                        If Data1 <= 0 Then

                                            Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
                                            comando.CommandText = "INSERT INTO `mascota`(`codi`, `Propietari`, `nom`, `edat`, `Especie`, `raza`, `sexo`, `color`, `Tamaño`,`pelo`,`castrado`,`peso`) VALUES (@codi,@Propietari,@nom,@edat,@Especie,@raza,@sexo,@color,@Tamaño,@pelo,@castrado,@peso)"
                                            comando.Parameters.AddWithValue("@codi", microxip.Text)
                                            comando.Parameters.AddWithValue("@Propietari", prope)
                                            comando.Parameters.AddWithValue("@nom", nombre_mascota.Text)
                                            comando.Parameters.AddWithValue("@edat", data)
                                            comando.Parameters.AddWithValue("@Especie", tipo)
                                            comando.Parameters.AddWithValue("@raza", raza_mascota.Text)
                                            comando.Parameters.AddWithValue("@sexo", sexo)
                                            comando.Parameters.AddWithValue("@color", color_mascota.Text)
                                            comando.Parameters.AddWithValue("@Tamaño", tamaño)
                                            comando.Parameters.AddWithValue("@pelo", pelo)
                                            comando.Parameters.AddWithValue("@castrado", castrado)
                                            comando.Parameters.AddWithValue("@peso", peso.Text)
                                            ''activar comanda
                                            Connection.Open()
                                            comando.ExecuteNonQuery()
                                            Connection.Close()
                                            MsgBox("¡Mascota Registrada!")
                                            ''pondra los textbox vacios

                                            nombre_mascota.Text = ""
                                            raza_mascota.Text = ""
                                            color_mascota.Text = ""
                                            microxip.Text = ""
                                            peso.Text = ""
                                            prop1.Text = ""
                                            propietarioc.Text = ""
                                            ''desselecionar los radiobuttons
                                            pequeño.Checked = False
                                            mediano.Checked = False
                                            grande.Checked = False
                                            hembra.Checked = False
                                            macho.Checked = False
                                            reptil.Checked = False
                                            ave.Checked = False
                                            gato.Checked = False
                                            roedor.Checked = False
                                            perro.Checked = False
                                            pl.Checked = False
                                            psl.Checked = False
                                            plc.Checked = False
                                            csi.Checked = False
                                            cno.Checked = False
                                        Else
                                        End If
                                    Else

                                    End If







                                Else
                                End If



                            Else
                            End If




                        End If


                    End If

                End If

            End If
        End If





    End Sub

    Private Sub fecha_nacimiento_ValueChanged(sender As Object, e As EventArgs) Handles fecha_nacimiento.ValueChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles propietarioc.SelectedIndexChanged

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

        Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
        ''(SELECT mascota.codi ,mascota.nom from helppet.mascota INNER JOIN helppet.propietari ON helppet.mascota.Propietari = helppet.propietari.DNI WHERE helppet.mascota.Propietari =(SELECT DNI FROM helppet.propietari WHERE helppet.propietari.nom Like "'" & p1.Text & "')", connection)
        Dim adapter As New MySqlDataAdapter("SELECT propietari.nom,propietari.DNI FROM br6yuhxjtf6d9t43hrii.propietari", connection)

        Dim table As New DataTable()
        adapter.Fill(table)

        propietarioc.DataSource = table
        propietarioc.ValueMember = "DNI"
        propietarioc.DisplayMember = "nom"
    End Sub

    Private Sub observacion_TextChanged(sender As Object, e As EventArgs) Handles observacion.TextChanged

    End Sub



    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim data As String = fecha_revision.Value.ToString("yyyy-M-d")
        ''variables locales
        Dim noucas As Integer
        Dim mascotat As String
        Dim lista As Byte
        Dim veterinario As String = Login.veterinario.Text
        ''conexion sql
        Dim no As Boolean = True ''Evitara la insercion de datos sin tener todos los campos llenos
        Dim MySQLDA As MySqlDataAdapter
        Dim DT As New DataTable
        Dim reg As MySqlDataReader
        Dim pk As MySqlDataReader
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim data3 As DataSet
        Dim Connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
        Dim Query As String
        Dim comando As New MySqlCommand(Query, Connection)
        Dim MySQLCMD As New MySqlCommand
        Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
        MySQLCMD.CommandText = "SELECT `codi_cas` FROM `casos` ORDER BY codi_cas DESC limit 1"
        MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
        data3 = New DataSet
        MySQLDA.Fill(data3, "casos")
        lista = data3.Tables("casos").Rows.Count

        noucas = data3.Tables("casos").Rows(0).Item("codi_cas")
            noucas = noucas + 1
        Connection.Close()




        mascotat = mascota.SelectedValue.ToString()
        If observacion.Text = "" Then
            MsgBox("Escriba una observación")
        Else
            If tratamiento.Text = "" Then
                MsgBox("Indique un tratamiento")
            Else
                If enfermedad.Text = "" Then
                    MsgBox("Indique una enfermedad")
                Else
                    If TextBox1.Text = "" Then
                        MsgBox("Indique un peso")

                    Else



                        If medicamentos.Text = "" Then
                            MsgBox("Indique los medicamentos")
                        Else
                            ''insertar caso con fecha de revision
                            If revision = True Then
                                If data = "0000-00-00" Then
                                    MsgBox("Indique una fecha para la revision")
                                Else



                                    Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
                                    comando.CommandText = "INSERT INTO `casos`(`codi_cas`, `codi_veterinari`, `codi_mascota`, `Data_Revisio`, `Observacio`, `tractament`, `medicaments`, `enfermetats`,`pes`) VALUES (@codi_cas,@codi_Veterinari,@codi_mascota, @Data_Revisio, @observació, @Tractament,@medicaments,@enfermetat,@pes )"
                                    comando.Parameters.AddWithValue("@codi_cas", noucas)
                                    comando.Parameters.AddWithValue("@codi_Veterinari", veterinario)
                                    comando.Parameters.AddWithValue("@codi_mascota", mascotat)
                                    comando.Parameters.AddWithValue("@Data_Revisio", data)
                                    comando.Parameters.AddWithValue("@observació", observacion.Text)
                                    comando.Parameters.AddWithValue("@Tractament", tratamiento.Text)
                                    comando.Parameters.AddWithValue("@medicaments", medicamentos.Text)
                                    comando.Parameters.AddWithValue("@enfermetat", enfermedad.Text)
                                    comando.Parameters.AddWithValue("@pes", TextBox1.Text)
                                    ''activar comanda
                                    Connection.Open()
                                    comando.ExecuteNonQuery()
                                    Connection.Close()
                                    MsgBox("¡Caso registrado!")
                                    veterinario = ""
                                    mascotat = ""
                                    observacion.Text = ""
                                    tratamiento.Text = ""
                                    medicamentos.Text = ""
                                    enfermedad.Text = ""
                                    clientcombo.Text = ""
                                    TextBox1.Text = ""
                                    propietarioc.Text = ""
                                    mascota.Text = ""

                                    p1.Text = ""
                                End If
                                ''insertar caso sin fecha de revision

                            End If
                            If revision = False Then
                                Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
                                comando.CommandText = "INSERT INTO `casos`(`codi_cas`, `codi_veterinari`, `codi_mascota`, `Observacio`, `tractament`, `medicaments`, `enfermetats`,`pes`) VALUES (@codi_cas,@codi_Veterinari,@codi_mascota, @observació, @Tractament,@medicaments,@enfermetat,@pes )"
                                comando.Parameters.AddWithValue("@codi_cas", noucas)
                                comando.Parameters.AddWithValue("@codi_Veterinari", veterinario)
                                comando.Parameters.AddWithValue("@codi_mascota", mascotat)
                                comando.Parameters.AddWithValue("@observació", observacion.Text)
                                comando.Parameters.AddWithValue("@Tractament", tratamiento.Text)
                                comando.Parameters.AddWithValue("@medicaments", medicamentos.Text)
                                comando.Parameters.AddWithValue("@enfermetat", enfermedad.Text)
                                comando.Parameters.AddWithValue("@pes", TextBox1.Text)

                                ''activar comanda
                                Connection.Open()
                                comando.ExecuteNonQuery()
                                Connection.Close()
                                MsgBox("¡Caso registrado!")
                                veterinario = ""
                                mascotat = ""
                                veterinario = ""
                                mascotat = ""
                                observacion.Text = ""
                                tratamiento.Text = ""
                                medicamentos.Text = ""
                                enfermedad.Text = ""
                                clientcombo.Text = ""
                                TextBox1.Text = ""
                                peso.Text = ""
                                propietarioc.Text = ""
                                mascota.Text = ""

                            End If

                        End If
                    End If

                End If

            End If

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fecha_revision.Visible = True
        Label10.Visible = True
        revision = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fecha_revision.Visible = False
        Label10.Visible = False
        revision = False
    End Sub

    Private Sub fecha_revision_ValueChanged(sender As Object, e As EventArgs) Handles fecha_revision.ValueChanged

    End Sub

    Private Sub enfermedad_TextChanged(sender As Object, e As EventArgs) Handles enfermedad.TextChanged

    End Sub

    Private Sub p1_TextChanged(sender As Object, e As EventArgs) Handles p1.TextChanged

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub color_mascota_TextChanged(sender As Object, e As EventArgs) Handles color_mascota.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles plc.CheckedChanged

    End Sub

    Private Sub microxip_TextChanged(sender As Object, e As EventArgs) Handles microxip.TextChanged

    End Sub

    Private Sub peso_TextChanged(sender As Object, e As EventArgs) Handles peso.TextChanged

    End Sub

    Private Sub peso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles peso.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not peso.Text.IndexOf(",") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        If clientcombo.Text = "" Then
            MsgBox("Indique Selecione un cliente")
        Else

            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT mascota.codi , mascota.nom from br6yuhxjtf6d9t43hrii.mascota INNER JOIN br6yuhxjtf6d9t43hrii.propietari On br6yuhxjtf6d9t43hrii.mascota.Propietari = br6yuhxjtf6d9t43hrii.propietari.DNI WHERE br6yuhxjtf6d9t43hrii.mascota.Propietari =(Select DNI FROM br6yuhxjtf6d9t43hrii.propietari WHERE br6yuhxjtf6d9t43hrii.propietari.nom Like '" & clientcombo.Text & "')", connection)

            Dim table As New DataTable()
            adapter.Fill(table)

            mascota.DataSource = table
            mascota.ValueMember = "codi"
            mascota.DisplayMember = "nom"
        End If
    End Sub

    Private Sub clientcombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clientcombo.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not peso.Text.IndexOf(",") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub clientcombo_Click(sender As Object, e As EventArgs) Handles clientcombo.Click
        If clientcombo.Text = "" Then
            MsgBox("Indique o selecione un cliente")
        Else

            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT mascota.codi , mascota.nom from br6yuhxjtf6d9t43hrii.mascota INNER JOIN br6yuhxjtf6d9t43hrii.propietari On br6yuhxjtf6d9t43hrii.mascota.Propietari = br6yuhxjtf6d9t43hrii.propietari.DNI WHERE br6yuhxjtf6d9t43hrii.mascota.Propietari =(Select DNI FROM br6yuhxjtf6d9t43hrii.propietari WHERE br6yuhxjtf6d9t43hrii.propietari.nom Like '" & clientcombo.Text & "')", connection)

            Dim table As New DataTable()
            adapter.Fill(table)

            mascota.DataSource = table
            mascota.ValueMember = "codi"
            mascota.DisplayMember = "nom"
        End If
    End Sub

    Private Sub p1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles p1.KeyPress

    End Sub

    Private Sub clientcombo_KeyDown(sender As Object, e As KeyEventArgs) Handles clientcombo.KeyDown

    End Sub

    Private Sub p1_KeyDown(sender As Object, e As KeyEventArgs) Handles p1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If p1.Text = "" Then
                    MsgBox("Indique datos para realizar una busqueda")
                Else
                    Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
                    Dim adapter As New MySqlDataAdapter("SELECT br6yuhxjtf6d9t43hrii.propietari.DNI,br6yuhxjtf6d9t43hrii.propietari.nom From br6yuhxjtf6d9t43hrii.propietari Where br6yuhxjtf6d9t43hrii.propietari.nom Like '%" & p1.Text & "%'", connection)


                    Dim table As New DataTable()
                    adapter.Fill(table)

                    clientcombo.DataSource = table
                    clientcombo.ValueMember = "DNI"
                    clientcombo.DisplayMember = "nom"
                End If
        End Select
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cp.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles cp.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If p1.Text = "" Then
            MsgBox("Indique datos para realizar una busqueda")
        Else
            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT br6yuhxjtf6d9t43hrii.propietari.DNI,br6yuhxjtf6d9t43hrii.propietari.nom From br6yuhxjtf6d9t43hrii.propietari Where br6yuhxjtf6d9t43hrii.propietari.nom Like '%" & p1.Text & "%'", connection)


            Dim table As New DataTable()
            adapter.Fill(table)

            clientcombo.DataSource = table
            clientcombo.ValueMember = "DNI"
            clientcombo.DisplayMember = "nom"
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If clientcombo.Text = "" Then
            MsgBox("Indique o selecione un cliente")
        Else

            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT mascota.codi , mascota.nom from br6yuhxjtf6d9t43hrii.mascota INNER JOIN br6yuhxjtf6d9t43hrii.propietari On br6yuhxjtf6d9t43hrii.mascota.Propietari = br6yuhxjtf6d9t43hrii.propietari.DNI WHERE br6yuhxjtf6d9t43hrii.mascota.Propietari =(Select DNI FROM br6yuhxjtf6d9t43hrii.propietari WHERE br6yuhxjtf6d9t43hrii.propietari.nom Like '" & clientcombo.Text & "')", connection)

            Dim table As New DataTable()
            adapter.Fill(table)

            mascota.DataSource = table
            mascota.ValueMember = "codi"
            mascota.DisplayMember = "nom"
        End If
    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles prop1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If prop1.Text = "" Then
                    MsgBox("Indique datos para realizar una busqueda")
                Else
                    Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
                    Dim adapter As New MySqlDataAdapter("SELECT br6yuhxjtf6d9t43hrii.propietari.DNI,br6yuhxjtf6d9t43hrii.propietari.nom From br6yuhxjtf6d9t43hrii.propietari Where br6yuhxjtf6d9t43hrii.propietari.nom Like '%" & prop1.Text & "%'", connection)


                    Dim table As New DataTable()
                    adapter.Fill(table)

                    propietarioc.DataSource = table
                    propietarioc.ValueMember = "DNI"
                    propietarioc.DisplayMember = "nom"
                End If
        End Select
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If prop1.Text = "" Then
            MsgBox("Indique datos para realizar una busqueda")
        Else
            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT br6yuhxjtf6d9t43hrii.propietari.DNI,br6yuhxjtf6d9t43hrii.propietari.nom From br6yuhxjtf6d9t43hrii.propietari Where br6yuhxjtf6d9t43hrii.propietari.nom Like '%" & prop1.Text & "%'", connection)


            Dim table As New DataTable()
            adapter.Fill(table)

            propietarioc.DataSource = table
            propietarioc.ValueMember = "DNI"
            propietarioc.DisplayMember = "nom"
        End If
    End Sub

    Private Sub prop1_TextChanged(sender As Object, e As EventArgs) Handles prop1.TextChanged

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub



    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nomp.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles t1.TextChanged

    End Sub

    Private Sub dni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dni.KeyPress
        If dni.Text.Length > 7 Then

            If Not (Asc(e.KeyChar) = 8) Then
                Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz"
                If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                    e.KeyChar = ChrW(0)
                    e.Handled = True
                End If
            End If
        End If
        If dni.Text.Length <= 7 Then
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles ap.TextChanged

    End Sub

    Private Sub ap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ap.KeyPress

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        nomp.Text = ""
        dni.Text = ""
        t1.Text = ""
        t2.Text = ""
        ap.Text = ""
        cp.Text = ""
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        ''conexion mysql
        Dim no As Boolean = True ''Evitara la insercion de datos sin tener todos los campos llenos
        Dim MySQLDA As MySqlDataAdapter
        Dim DT As New DataTable
        Dim Data1 As Integer
        Dim pk As MySqlDataReader
        Dim Connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
        Dim Query As String
        Dim comando As New MySqlCommand(Query, Connection)
        Dim MySQLCMD As New MySqlCommand
        If nomp.Text = "" Then

        Else
            If dni.Text = "" Then

            Else
                If t1.Text = "" Then

                Else
                    If t2.Text = "" Then

                    Else
                        If ap.Text = "" Then

                        Else
                            If cp.Text = "" Then

                            Else
                                no = False
                                If no = False Then
                                    ''comprobar que el dni no existe
                                    Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
                                    Connection.Open()
                                    MySQLCMD.CommandText = "SELECT * FROM `propietari` WHERE `DNI` ='" & dni.Text & "'"
                                    MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
                                    Data1 = MySQLDA.Fill(DT)
                                    Connection.Close()
                                    ''si no existe
                                    If Data1 <= 0 Then
                                        Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
                                        comando.CommandText = "INSERT INTO `propietari`(`nom`, `DNI`, `t1`, `t2`, `Adreça`, `CP`) VALUES (@nom,@dni,@t1,@t2,@adreça,@CP)"
                                        comando.Parameters.AddWithValue("@nom", nomp.Text)
                                        comando.Parameters.AddWithValue("@dni", dni.Text)
                                        comando.Parameters.AddWithValue("@t1", t1.Text)
                                        comando.Parameters.AddWithValue("@t2", t2.Text)
                                        comando.Parameters.AddWithValue("@adreça", ap.Text)
                                        comando.Parameters.AddWithValue("@CP", cp.Text)
                                        ''activar comanda
                                        Connection.Open()
                                        comando.ExecuteNonQuery()
                                        Connection.Close()
                                        ''mensaje de registro correcto
                                        MsgBox("¡El propietario " + nomp.Text + " se a registrado con exito!")
                                        ''restablecer textbox
                                        nomp.Text = ""
                                        dni.Text = ""
                                        t1.Text = ""
                                        t2.Text = ""
                                        ap.Text = ""
                                        cp.Text = ""

                                    Else
                                        MsgBox("¡El DNI " + dni.Text + " indicado ya esta registrado en la base de datos!")
                                    End If
                                End If
                                ''if cp
                            End If
                            ''if ap
                        End If
                        ''if t2
                    End If
                    ''if t1
                End If
                ''if dni
            End If
            ''if nombre
        End If
    End Sub

    Private Sub dni_TextChanged(sender As Object, e As EventArgs) Handles dni.TextChanged

    End Sub

    Private Sub TabPage5_Click(sender As Object, e As EventArgs) Handles TabPage5.Click

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub TabPage6_Click(sender As Object, e As EventArgs) Handles TabPage6.Click

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        If cbc.Text = "" Then
            MsgBox("Indique datos para realizar una busqueda")
        Else
            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT br6yuhxjtf6d9t43hrii.propietari.DNI,br6yuhxjtf6d9t43hrii.propietari.nom From br6yuhxjtf6d9t43hrii.propietari Where br6yuhxjtf6d9t43hrii.propietari.nom Like '%" & cbc.Text & "%'", connection)


            Dim table As New DataTable()
            adapter.Fill(table)

            cprop.DataSource = table
            cprop.ValueMember = "DNI"
            cprop.DisplayMember = "nom"
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbc.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If cbc.Text = "" Then
                    MsgBox("Indique datos para realizar una busqueda")
                Else
                    Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
                    Dim adapter As New MySqlDataAdapter("SELECT br6yuhxjtf6d9t43hrii.propietari.DNI,br6yuhxjtf6d9t43hrii.propietari.nom From br6yuhxjtf6d9t43hrii.propietari Where br6yuhxjtf6d9t43hrii.propietari.nom Like '%" & cbc.Text & "%'", connection)


                    Dim table As New DataTable()
                    adapter.Fill(table)

                    cprop.DataSource = table
                    cprop.ValueMember = "DNI"
                    cprop.DisplayMember = "nom"
                End If
        End Select
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        If cprop.Text = "" Then
            MsgBox("Indique Selecione un cliente")
        Else

            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT mascota.codi , mascota.nom from br6yuhxjtf6d9t43hrii.mascota INNER JOIN br6yuhxjtf6d9t43hrii.propietari On br6yuhxjtf6d9t43hrii.mascota.Propietari = br6yuhxjtf6d9t43hrii.propietari.DNI WHERE br6yuhxjtf6d9t43hrii.mascota.Propietari =(Select DNI FROM br6yuhxjtf6d9t43hrii.propietari WHERE br6yuhxjtf6d9t43hrii.propietari.nom Like '" & cprop.Text & "')", connection)

            Dim table As New DataTable()
            adapter.Fill(table)

            cmasc.DataSource = table
            cmasc.ValueMember = "codi"
            cmasc.DisplayMember = "nom"
        End If
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles cprop.Click
        If cprop.Text = "" Then
            MsgBox("Indique o selecione un cliente")
        Else

            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT mascota.codi , mascota.nom from br6yuhxjtf6d9t43hrii.mascota INNER JOIN br6yuhxjtf6d9t43hrii.propietari On br6yuhxjtf6d9t43hrii.mascota.Propietari = br6yuhxjtf6d9t43hrii.propietari.DNI WHERE br6yuhxjtf6d9t43hrii.mascota.Propietari =(Select DNI FROM br6yuhxjtf6d9t43hrii.propietari WHERE br6yuhxjtf6d9t43hrii.propietari.nom Like '" & cprop.Text & "')", connection)

            Dim table As New DataTable()
            adapter.Fill(table)

            cmasc.DataSource = table
            cmasc.ValueMember = "codi"
            cmasc.DisplayMember = "nom"
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_2(sender As Object, e As EventArgs) Handles cprop.SelectedIndexChanged

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If cmasc.Text = "" Then
            MsgBox("Indique o selecione una mascota")
        Else

            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT casos.codi_cas, casos.enfermetats FROM br6yuhxjtf6d9t43hrii.casos INNER JOIN br6yuhxjtf6d9t43hrii.mascota 
On br6yuhxjtf6d9t43hrii.mascota.codi = br6yuhxjtf6d9t43hrii.casos.codi_mascota 
WHERE br6yuhxjtf6d9t43hrii.casos.codi_mascota = (SELECT br6yuhxjtf6d9t43hrii.mascota.codi from br6yuhxjtf6d9t43hrii.mascota inner join br6yuhxjtf6d9t43hrii.propietari on br6yuhxjtf6d9t43hrii.propietari.DNI = br6yuhxjtf6d9t43hrii.mascota.propietari WHERE br6yuhxjtf6d9t43hrii.mascota.nom ='" & cmasc.Text & "' And br6yuhxjtf6d9t43hrii.propietari.nom like '" & cprop.Text & "')", connection)

            Dim table As New DataTable()
            adapter.Fill(table)

            ccaso.DataSource = table
            ccaso.ValueMember = "codi_cas"
            ccaso.DisplayMember = "enfermetats"
        End If
    End Sub

    Private Sub TextBox4_TextChanged_1(sender As Object, e As EventArgs) Handles cpes.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles crevisio.TextChanged

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub cmasc_Click(sender As Object, e As EventArgs) Handles cmasc.Click

    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click



        If ccaso.Text = "" Then
            MsgBox("Indique o selecione un caso")
        Else

            Dim connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii;Convert Zero Datetime=True")
            Dim adapter As New MySqlDataAdapter("SELECT br6yuhxjtf6d9t43hrii.veterinari.nom,br6yuhxjtf6d9t43hrii.casos.enfermetats,br6yuhxjtf6d9t43hrii.casos.pes,br6yuhxjtf6d9t43hrii.casos.Observacio,br6yuhxjtf6d9t43hrii.casos.medicaments,
            br6yuhxjtf6d9t43hrii.casos.tractament,br6yuhxjtf6d9t43hrii.casos.Data_Registre,br6yuhxjtf6d9t43hrii.casos.Data_Revisio FROM br6yuhxjtf6d9t43hrii.casos inner join br6yuhxjtf6d9t43hrii.veterinari on
            br6yuhxjtf6d9t43hrii.veterinari.codi= br6yuhxjtf6d9t43hrii.casos.codi_veterinari WHERE br6yuhxjtf6d9t43hrii.casos.codi_cas=" + ccaso.SelectedValue.ToString, connection)
            Dim data1 As New DataSet
            adapter.Fill(data1, "veter")
            vcas.Text = data1.Tables("veter").Rows(0).Item("nom")
            recas.Text = data1.Tables("veter").Rows(0).Item("Data_Registre")
            cenfermetat.Text = data1.Tables("veter").Rows(0).Item("enfermetats")
            cpes.Text = data1.Tables("veter").Rows(0).Item("pes")
            canamnesis.Text = data1.Tables("veter").Rows(0).Item("Observacio")
            cmedicaments.Text = data1.Tables("veter").Rows(0).Item("medicaments")
            ctratament.Text = data1.Tables("veter").Rows(0).Item("tractament")
            If data1.Tables("veter").Rows(0).Item("Data_Revisio").Equals(DBNull.Value) = True Then

                crevisio.Text = "Sin revision"

            Else
                crevisio.Text = data1.Tables("veter").Rows(0).Item("Data_Revisio")
            End If

        End If




    End Sub

    Private Sub cmasc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmasc.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click_2(sender As Object, e As EventArgs)
        Application.Exit()

    End Sub

    Private Sub nomp_TextChanged(sender As Object, e As EventArgs) Handles nomp.TextChanged

    End Sub
End Class
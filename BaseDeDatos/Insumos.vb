


Imports MySql.Data.MySqlClient

Public Class Insumos
    Dim pro As New MySqlConnection("server=localhost;user=root;password=19982017;database= grupoexposicion_3;port=3306")
    Private Sub Btn_guardar_Click(sender As Object, e As EventArgs) Handles Btn_guardar.Click
        Try
            Dim cadena As String
            cadena = String.Format("INSERT INTO insumo(codigo_insumo, nombre, descripcion, cantidad) values ('{0}','{1}','{2}','{3}')", TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
            Dim insertar As New MySqlCommand(cadena, pro)
            pro.Open()
            insertar.ExecuteNonQuery()
            pro.Close()
            MsgBox("El registro fue ingresado de forma satisfactoria", MsgBoxStyle.Information, " Insumos")
        Catch ex As Exception
            MsgBox("Error al ingresar los datos, verifique por favor", MsgBoxStyle.Information, "IngresoInsumos")
            pro.Close()
        End Try
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub Insumos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox2.CharacterCasing = CharacterCasing.Upper
        TextBox3.CharacterCasing = CharacterCasing.Upper
        TextBox4.CharacterCasing = CharacterCasing.Upper

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Dim x As Integer
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
            x = x + 1
        Else
            If e.KeyChar = ChrW(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
            If x = 3 Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            pro.Open()
            MsgBox("exito de coneccion")
        Catch ex As Exception
            pro.Close()
            MsgBox(" fallo de coneccion")

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Ingresos.Show()
    End Sub




End Class
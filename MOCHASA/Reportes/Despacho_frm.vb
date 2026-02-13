Imports System.Data.OleDb
Public Class Despacho_frm

    Private Sub EgresoSaleFRM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dspc As New datosreportes
        Dim con As OleDbConnection
        Dim cmd As OleDbCommand
        Dim adapter As OleDbDataAdapter
        Try
            con = New OleDbConnection(sConnString)
            Dim stringcomando As String = "SELECT CabeceraTransacciones.*, Mixers.Placa, Mixers.NombreMixer, Clientes.Nombre as NomCliente, Clientes.Direccion as DirCliente, Productos.Descripcion as NomProducto, Operadores.nomOperador, Choferes.Nombre as NomChofer
FROM Mixers INNER JOIN ((((Clientes INNER JOIN CabeceraTransacciones ON Clientes.CodCliente = CabeceraTransacciones.CodCliente) INNER JOIN Productos ON CabeceraTransacciones.CodProducto = Productos.Id_Producto) INNER JOIN Choferes ON CabeceraTransacciones.CodChofer = Choferes.CodChofer) INNER JOIN Operadores ON CabeceraTransacciones.CodOperador = Operadores.codOperador) ON Mixers.Id = CabeceraTransacciones.idMixer
WHERE (((CabeceraTransacciones.Id)='" & idDespacho & "'));"
            cmd = New OleDbCommand(stringcomando, con)
            adapter = New OleDbDataAdapter(cmd)
            adapter.Fill(dspc.Tables("CabeceraTransacciones"))

            'logo
            Try
                'cmd = New OleDb.OleDbCommand
                'con.Open()
                'cmd.Connection = con
                'cmd.CommandText = "select LogoEmpresa from Configuracion Where Id = 1"
                'Dim dr As DataRow
                'dr = dspc.Tables("DatosEmpresa").NewRow
                'If IsDBNull(cmd.ExecuteScalar) = False Then
                '    dr(0) = cmd.ExecuteScalar
                'End If
                'cmd.CommandText = "select NombreEmpresa from Configuracion Where Id = 1"
                'If IsDBNull(cmd.ExecuteScalar) = False Then
                '    dr(1) = cmd.ExecuteScalar
                'End If
                'dspc.Tables("DatosEmpresa").Rows.Add(dr)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
            'Poblar el informe con el dataSet y mostrarlo
            Dim info As New Despacho
            info.SetDataSource(dspc)
                crv.ReportSource = info

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class
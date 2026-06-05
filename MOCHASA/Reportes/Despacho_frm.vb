Imports System.Data.OleDb
Public Class Despacho_frm

    Private Sub EgresoSaleFRM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dspc As New datosreportes
        Dim con As OleDbConnection
        Dim cmd As OleDbCommand
        Dim adapter As OleDbDataAdapter

        Try
            con = New OleDbConnection(sConnString)
            Dim stringcomando As String = "SELECT CabeceraTransacciones.*, Mixers.Placa, Mixers.NombreMixer, Clientes.Nombre as NomCliente, Clientes.Direccion as DirCliente, Productos.Descripcion as NomProducto, Operadores.nomOperador, Choferes.Nombre as NomChofer, 0.001 as VolumenTotal
                                            FROM Mixers INNER JOIN ((((Clientes INNER JOIN CabeceraTransacciones ON Clientes.CodCliente = CabeceraTransacciones.CodCliente) INNER JOIN Productos ON CabeceraTransacciones.CodProducto = Productos.Id_Producto) INNER JOIN Choferes ON CabeceraTransacciones.CodChofer = Choferes.CodChofer) INNER JOIN Operadores ON CabeceraTransacciones.CodOperador = Operadores.codOperador) ON Mixers.Id = CabeceraTransacciones.idMixer
                                            WHERE (((CabeceraTransacciones.Id)='" & idDespacho & "'));"
            cmd = New OleDbCommand(stringcomando, con)
            adapter = New OleDbDataAdapter(cmd)
            adapter.Fill(dspc.Tables("CabeceraTransacciones"))


            stringcomando = "SELECT Sum([Peso_Real]/[Densidad]) AS VolumenTotal
                            FROM CabeceraTransacciones INNER JOIN (Ingredientes INNER JOIN Transacciones ON Ingredientes.Id_ingrediente = Transacciones.Cod_Ingrediente) ON CabeceraTransacciones.Id = Transacciones.Id_Cabecera
                            WHERE (((Transacciones.Id_Cabecera)='" & idDespacho & "'));"
            cmd = New OleDbCommand(stringcomando, con)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = stringcomando

            'Dim dr As DataRow
            'dr = dspc.Tables("DatosEmpresa").NewRow

            If IsDBNull(cmd.ExecuteScalar) = False Then
                dspc.Tables("CabeceraTransacciones").Rows(0).Item("VolumenTotal") = cmd.ExecuteScalar
            End If

            'Llenar información de encabezado
            Dim dr As DataRow
            dr = dspc.Tables("Encabezado").NewRow
            dr("Fecha") = ""
            dr("Operador") = Variables.nomOperador
            dr("Producto") = ""
            dr("Ingrediente") = ""
            dr("NomProducto") = ""
            dr("NomIngrediente") = ""
            dr("OrdenDespacho") = ""
            dr("NombreEmpresa") = Variables.nombreEmpresa
            dr("RUC") = Variables.RUCEmpresa
            dr("ImagenEmpresa") = Variables.imagenEmpresa
            dspc.Tables("Encabezado").Rows.Add(dr)

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
            Dim reporteFormato As New Despacho_Formato
            info.SetDataSource(dspc)
            reporteFormato.SetDataSource(dspc)

            crv.ReportSource = info
            crv2.ReportSource = reporteFormato
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class
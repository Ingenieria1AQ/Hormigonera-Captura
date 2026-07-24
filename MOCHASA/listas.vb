Imports System.Data
Imports System.Data.OleDb

Public Class listas

   Dim da As OleDbDataAdapter
   Dim ds As New DataSet
   Dim campoCodigo As String
    Dim campoNombre As String
    Dim campoRUC As String
    'tipoLista tiene el nombre de la tabla
    Private bindingSource1 As New BindingSource()
   Private AdaptadorDeDatos As New OleDb.OleDbDataAdapter

    Private Sub listas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case tipoLista
            Case "CHOFERES"
                Call cargarDatos("SELECT * FROM Choferes WHERE HABILITADO=1 order by nombre")
                RadioButton1.Visible = True
                campoCodigo = "CodChofer"
                campoNombre = "Nombre"
                campoRUC = "Cedula"
            Case "CLIENTES"
                Call cargarDatos("SELECT * FROM Clientes")
                RadioButton1.Visible = True
                campoCodigo = "CodCliente"
                campoNombre = "Nombre"
                campoRUC = "CedulaRUC"
            Case "PROVEEDORES"
                Call cargarDatos("SELECT * FROM PROVEEDORES")
                RadioButton1.Visible = True
                campoCodigo = "CodProveedor"
                campoNombre = "Nombre"
                campoRUC = "CedulaRUC"
            Case "PRODUCTOS"
                Call cargarDatos("SELECT * FROM Productos")
                campoCodigo = "Id_Producto"
                campoNombre = "Descripcion"
            Case "OBRAS"
                Call cargarDatos("SELECT * FROM Obras")
                campoCodigo = "CodObra"
                campoNombre = "Nombre"
                ' hoy 05/04/2013
            Case "TRANSACCIONES"
                Call cargarDatos("SELECT Clave, Tipo, Id, Fecha, Placas, Transacciones.CodCliente as CodProveedor, " &
                                 "Proveedores.Nombre, transacciones.CodProducto, productos.nombre, transacciones.codChofer, Choferes.nombre, Transacciones.Densidad, Observaciones, documento, PesoEntra" &
                                 " FROM Transacciones, Proveedores, Productos, Choferes" &
                                 " WHERE Clave <> ' ' and Tipo = 'INGRESO' and Transacciones.CodCliente = Proveedores.CodProveedor and transacciones.CodProducto = Productos.codProducto and transacciones.codChofer = Choferes.codChofer ORDER by Fecha DESC")
                campoCodigo = "Id"
                campoNombre = "Tipo"
            Case "TRANSACCIONES1"
                Call cargarDatos("SELECT Clave, Tipo, Id, Fecha, Placas, Transacciones.CodCliente, " &
                                 "Clientes.Nombre, transacciones.CodProducto, productos.nombre, transacciones.codChofer, Choferes.nombre, Transacciones.Densidad, Observaciones, documento, PesoEntra" &
                                 " FROM Transacciones, Clientes, Productos, Choferes" &
                                 " WHERE Clave <> ' ' and Tipo = 'EGRESO' and Transacciones.CodCliente = Clientes.CodCliente and transacciones.CodProducto = Productos.codProducto and transacciones.codChofer = Choferes.codChofer  ORDER by Fecha DESC")
                campoCodigo = "Id"
                campoNombre = "Tipo"

            Case "MIXERS"
                Call cargarDatos("SELECT * FROM Mixers")
                campoCodigo = "Id"
                campoNombre = "NombreMixer"
            Case "ORDEN_DESPACHO"
                Call cargarDatos("SELECT * FROM CabeceraTransacciones ORDER BY Hora DESC;")
                campoCodigo = "Id"
                campoNombre = "Id"
            Case "OD_PROCESO"
                Call cargarDatos("SELECT
                                Cb.Id,
                                Cb.Fecha,
                                Cb.Hora,
                                Cb.CodProducto,
                                Pr.Descripcion AS NomProducto,
                                Cb.idMixer AS IdMixer,
                                Mx.NombreMixer AS NomMixer,
                                Mx.Placa AS PlacaMixer,
                                Cb.Observaciones
                            FROM
                                (
                                    CabeceraTransacciones AS Cb
                                    LEFT JOIN Productos AS Pr ON Cb.CodProducto = Pr.Id_Producto
                                )
                                LEFT JOIN Mixers AS Mx ON Cb.idMixer = Mx.Id
                            WHERE
                                NOT EXISTS (
                                    SELECT
                                        *
                                    FROM
                                        Transacciones AS T
                                    WHERE
                                        T.Id_Cabecera = Cb.Id
                                )
                            ORDER BY Cb.Hora DESC;")
                campoCodigo = "Cb.Id"
                campoNombre = "Cb.Id"
        End Select
        'Call cargarproductos("SELECT * FROM Productos")

        DataGridView1.ReadOnly = False

    End Sub

    Private Sub Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Me.DataGridView1.Rows.Remove(Me.DataGridView1.CurrentRow)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub cargarDatos(ByVal cmdtxt As String)
        Try
            ' Especificar un 'connection string' valido
            ' En este caso origen de la carpeta de la aplicacion BD1.mdb
            'Dim cmdtxt As String = "SELECT * FROM Productos" ' where descripcion like '%ANULADO%' order by Descripcion"
            ' Crear un nuevo adaptador de datos basado en el 'query' especificado
            If sConnString.IndexOf(".mdb") >= 0 Then
                cmdtxt = cmdtxt.Replace("HABILITADO=1", "HABILITADO=True")
            Else
                cmdtxt = cmdtxt.Replace("HABILITADO=True", "HABILITADO=1")
            End If
            Me.AdaptadorDeDatos = New OleDb.OleDbDataAdapter(cmdtxt, sConnString)
            Me.DataGridView1.DataSource = Me.bindingSource1
            ' Crear un 'commandbuilder' que genere el SQL Update/Insert/Delete
            ' segun el 'selectcommand', usado para actualizar la BD
            Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.AdaptadorDeDatos)

            ' Llenar la tabla con los datos y enlazarza con el 'bindingsource'
            Dim tabla As New DataTable()
            Me.AdaptadorDeDatos.Fill(tabla)
            Me.bindingSource1.DataSource = tabla
            DataGridView1.AutoResizeColumns()
            'DataGridView1.Columns(2).DefaultCellStyle
            ' Dimensionar las columnas del DataGrid para ajustalarlas al contenido cargado
            'Me.DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)
        Catch ex As Exception
            MessageBox.Show("Excepcion al leer los datos:" & ex.Message)
        End Try
    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call actualizardatos()
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        Dim respuesta As Integer
        If tipoOperador = "ADMINISTRADOR" Then
            respuesta = MsgBox("Desea guardar los cambios antes de salir?", MsgBoxStyle.YesNo)
            If respuesta = 6 Then
                Call actualizardatos()
            End If
        End If
        Me.Close()
    End Sub

    Private Sub actualizardatos()
        Try
            Me.AdaptadorDeDatos.Update(CType(Me.bindingSource1.DataSource, DataTable))
        Catch ex As Exception
            MsgBox("Error al actualizar " & ex.Message)
        End Try
    End Sub

    ' ''Private Sub seleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ' ''   'frmimprimir.TextBox2.Text = DataGridView1.CurrentRow.Cells(0).Value
    ' ''   'frmimprimir.txtproducto.Text = DataGridView1.CurrentRow.Cells(0).Value
    ' ''   'frmimprimir.txtnomproducto.Text = DataGridView1.CurrentRow.Cells(1).Value

    ' ''   frmReporteSIE.TextBox2.Text = DataGridView1.CurrentRow.Cells(0).Value
    ' ''   frmReporteSIE.txtproducto.Text = DataGridView1.CurrentRow.Cells(0).Value
    ' ''   frmReporteSIE.txtnomproducto.Text = DataGridView1.CurrentRow.Cells(1).Value

    ' ''   Me.Close()
    ' ''End Sub


    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click

        If destinoLista = "TransaccionesVarias" Then
            DatosDespacho.codChofer.Text = DataGridView1.CurrentRow.Cells(0).Value
            DatosDespacho.nomChofer.Text = DataGridView1.CurrentRow.Cells(1).Value
        End If
        If destinoLista = "TransaccionesVariasC" Then
            DatosDespacho.codCliente.Text = DataGridView1.CurrentRow.Cells(0).Value
            DatosDespacho.nomCliente.Text = DataGridView1.CurrentRow.Cells(1).Value
        End If
        If destinoLista = "TransaccionesVariasP" Then
            DatosDespacho.codProducto.Text = DataGridView1.CurrentRow.Cells(0).Value
            DatosDespacho.nomProducto.Text = DataGridView1.CurrentRow.Cells(1).Value
            'DatosDespacho.txtdensidad.Text = DataGridView1.CurrentRow.Cells(4).Value
        End If

        If destinoLista = "DatosDespacho1" Then
            DatosDespacho.txtidMixer.Text = DataGridView1.CurrentRow.Cells(0).Value
            DatosDespacho.txtNomMixer.Text = DataGridView1.CurrentRow.Cells(2).Value
            DatosDespacho.txtPlaca.Text = DataGridView1.CurrentRow.Cells(1).Value
            'DatosDespacho.txtdensidad.Text = DataGridView1.CurrentRow.Cells(4).Value
        End If
        ' hoy 05/04/2013
        If destinoLista = "TransaccionesVariasT" Then
            DatosDespacho.lblcomprobante.Text = DataGridView1.CurrentRow.Cells(2).Value
            DatosDespacho.txtPlaca.Text = DataGridView1.CurrentRow.Cells(4).Value
            ' DatosDespacho.txtclave.Text = DataGridView1.CurrentRow.Cells(0).Value
            DatosDespacho.codCliente.Text = DataGridView1.CurrentRow.Cells(5).Value
            DatosDespacho.nomCliente.Text = DataGridView1.CurrentRow.Cells(6).Value
            DatosDespacho.codProducto.Text = DataGridView1.CurrentRow.Cells(7).Value
            DatosDespacho.nomProducto.Text = DataGridView1.CurrentRow.Cells(8).Value
            DatosDespacho.codChofer.Text = DataGridView1.CurrentRow.Cells(9).Value
            DatosDespacho.nomChofer.Text = DataGridView1.CurrentRow.Cells(10).Value
            DatosDespacho.txtobservaciones.Text = DataGridView1.CurrentRow.Cells(12).Value
            'DatosDespacho.txtdensidad.Text = DataGridView1.CurrentRow.Cells(11).Value
            DatosDespacho.txtdocumento.Text = DataGridView1.CurrentRow.Cells(13).Value
            'DatosDespacho.txtpesoentra.Text = DataGridView1.CurrentRow.Cells(14).Value
        End If
        If destinoLista = "FReportesOrdenDespacho" Then
            frmReportes.txtOrdenDespacho.Text = DataGridView1.CurrentRow.Cells(0).Value
        End If
        If destinoLista = "FReportesMixers" Then
            frmReportes.txtMixer.Text = DataGridView1.CurrentRow.Cells(0).Value
            frmReportes.Txt_NomMixer.Text = DataGridView1.CurrentRow.Cells(2).Value
        End If
        'Andina de Hormigones ---------------------------------------------------------
        If destinoLista = "Proceso_Pr" Then
            Proceso_Andina.codProducto.Text = DataGridView1.CurrentRow.Cells(0).Value
            Proceso_Andina.nomProducto.Text = DataGridView1.CurrentRow.Cells(1).Value
        End If
        If destinoLista = "Proceso_Mx" Then
            Proceso_Andina.txtidMixer.Text = DataGridView1.CurrentRow.Cells(0).Value
            Proceso_Andina.txtNomMixer.Text = DataGridView1.CurrentRow.Cells(2).Value
            Proceso_Andina.txtPlaca.Text = DataGridView1.CurrentRow.Cells(1).Value
        End If
        If destinoLista = "Proceso_Od" Then
            Try
                Proceso_Andina.lblcomprobante.Text = DataGridView1.CurrentRow.Cells("Id").Value
                Proceso_Andina.codProducto.Text = DataGridView1.CurrentRow.Cells("CodProducto").Value
                Proceso_Andina.nomProducto.Text = DataGridView1.CurrentRow.Cells("NomProducto").Value
                Proceso_Andina.txtidMixer.Text = DataGridView1.CurrentRow.Cells("IdMixer").Value
                Proceso_Andina.txtNomMixer.Text = DataGridView1.CurrentRow.Cells("NomMixer").Value
                Proceso_Andina.txtPlaca.Text = DataGridView1.CurrentRow.Cells("PlacaMixer").Value
                Proceso_Andina.txtobservaciones.Text = DataGridView1.CurrentRow.Cells("Observaciones").Value
                Proceso_Andina.Gb_OrdenDespacho.Enabled = True
                Variables.TipoOD = "Editar"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Excepcion: Proceso_Od", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        '-------------------------------------------------------------------------------

        'If destinoLista = "TransaccionesVariasT1" Then
        '    EgresoSalida.lblcomprobante.Text = DataGridView1.CurrentRow.Cells(2).Value
        '    EgresoSalida.txtplaca.Text = DataGridView1.CurrentRow.Cells(4).Value
        '    EgresoSalida.txtclave.Text = DataGridView1.CurrentRow.Cells(0).Value
        '    EgresoSalida.codCliente.Text = DataGridView1.CurrentRow.Cells(5).Value
        '    EgresoSalida.nomCliente.Text = DataGridView1.CurrentRow.Cells(6).Value
        '    EgresoSalida.codProducto.Text = DataGridView1.CurrentRow.Cells(7).Value
        '    EgresoSalida.nomProducto.Text = DataGridView1.CurrentRow.Cells(8).Value
        '    EgresoSalida.codChofer.Text = DataGridView1.CurrentRow.Cells(9).Value
        '    EgresoSalida.nomChofer.Text = DataGridView1.CurrentRow.Cells(10).Value
        '    EgresoSalida.txtobservaciones.Text = DataGridView1.CurrentRow.Cells(12).Value
        '    EgresoSalida.txtdensidad.Text = DataGridView1.CurrentRow.Cells(11).Value
        '    EgresoSalida.txtdocumento.Text = DataGridView1.CurrentRow.Cells(13).Value
        '    EgresoSalida.txtpesoentra.Text = DataGridView1.CurrentRow.Cells(14).Value
        'End If

        'If destinoLista = "TransaccionesVariasO" Then
        '   TransaccionesVarias.codObra.Text = DataGridView1.CurrentRow.Cells(0).Value
        '   TransaccionesVarias.nomObra.Text = DataGridView1.CurrentRow.Cells(1).Value
        'End If

        'If destinoLista = "EgresoSalida" Then
        '    EgresoSalida.codChofer.Text = DataGridView1.CurrentRow.Cells(0).Value
        '    EgresoSalida.nomChofer.Text = DataGridView1.CurrentRow.Cells(1).Value
        'End If
        'If destinoLista = "EgresoSalidaC" Then
        '    EgresoSalida.codCliente.Text = DataGridView1.CurrentRow.Cells(0).Value
        '    EgresoSalida.nomCliente.Text = DataGridView1.CurrentRow.Cells(1).Value
        'End If
        'If destinoLista = "EgresoSalidaP" Then
        '    EgresoSalida.codProducto.Text = DataGridView1.CurrentRow.Cells(0).Value
        '    EgresoSalida.nomProducto.Text = DataGridView1.CurrentRow.Cells(1).Value
        '    EgresoSalida.txtdensidad.Text = DataGridView1.CurrentRow.Cells(4).Value
        'End If
        ''If destinoLista = "RepTransaccionesCliDesde" Then
        '    ReportesTransacciones.txtClienteDesde.Text = DataGridView1.CurrentRow.Cells(1).Value
        'End If
        'If destinoLista = "RepTransaccionesCliHasta" Then
        '    ReportesTransacciones.txtClienteHasta.Text = DataGridView1.CurrentRow.Cells(1).Value
        'End If
        'If destinoLista = "RepTransaccionesProdDesde" Then
        '    ReportesTransacciones.txtProdDesde.Text = DataGridView1.CurrentRow.Cells(1).Value
        'End If
        'If destinoLista = "RepTransaccionesProdHasta" Then
        '    ReportesTransacciones.txtProdHasta.Text = DataGridView1.CurrentRow.Cells(1).Value
        'End If
        'If destinoLista = "RepTransaccionesChoferDesde" Then
        '    ReportesTransacciones.txtChoferDesde.Text = DataGridView1.CurrentRow.Cells(1).Value
        'End If
        'If destinoLista = "RepTransaccionesChoferHasta" Then
        '    ReportesTransacciones.txtChoferHasta.Text = DataGridView1.CurrentRow.Cells(1).Value
        'End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim respuesta As Integer
        respuesta = MsgBox("Desea guardar los cambios antes de salir?", MsgBoxStyle.YesNo)
        If respuesta = 6 Then
            Call actualizardatos()
        End If
        Me.Close()
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "Filtrar" Then
            Panel1.Visible = True
            Button4.Text = "Ver Todos"
        Else
            'Panel1.Visible = True
            Button4.Text = "Filtrar"
            Select Case tipoLista
                Case "CHOFERES"
                    Call cargarDatos("SELECT * FROM Choferes WHERE HABILITADO=1 order by nombre")
                    campoCodigo = "CodChofer"
                    campoNombre = "Nombre"
                    campoRUC = "Cedula"
                Case "CLIENTES"
                    Call cargarDatos("SELECT * FROM Clientes")
                    campoCodigo = "CodCliente"
                    campoNombre = "Nombre"
                    campoRUC = "CedulaRUC"
                Case "PRODUCTOS"
                    Call cargarDatos("SELECT * FROM Productos")
                    campoCodigo = "Id_Producto"
                    campoNombre = "Descripcion"
                Case "OBRAS"
                    Call cargarDatos("SELECT * FROM Obras")
                    campoCodigo = "CodObra"
                    campoNombre = "Nombre"
                Case "ORDEN_DESPACHO"
                    Call cargarDatos("SELECT * FROM CabeceraTransacciones")
                    campoCodigo = "Id"
                    campoNombre = "Id"
                Case "MIXERS"
                    Call cargarDatos("SELECT * FROM Mixers")
                    campoCodigo = "Id"
                    campoNombre = "NombreMixer"
                Case "OD_PROCESO"
                    Call cargarDatos("SELECT
                                Cb.Id,
                                Cb.Fecha,
                                Cb.Hora,
                                Cb.CodProducto,
                                Pr.Descripcion AS NomProducto,
                                Cb.idMixer AS IdMixer,
                                Mx.NombreMixer AS NomMixer,
                                Mx.Placa AS PlacaMixer,
                                Cb.Observaciones
                            FROM
                                (
                                    CabeceraTransacciones AS Cb
                                    LEFT JOIN Productos AS Pr ON Cb.CodProducto = Pr.Id_Producto
                                )
                                LEFT JOIN Mixers AS Mx ON Cb.idMixer = Mx.Id
                            WHERE
                                NOT EXISTS (
                                    SELECT
                                        *
                                    FROM
                                        Transacciones AS T
                                    WHERE
                                        T.Id_Cabecera = Cb.Id
                                )
                            ORDER BY Cb.Hora DESC;")
                    campoCodigo = "Cb.Id"
                    campoNombre = "Cb.Id"
            End Select

        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Panel1.Visible = False
        If TextBox1.Text.Trim = "" Then
            Button4.Text = "Filtrar"
            If tipoLista = "CHOFERES" Then
                Call cargarDatos("SELECT * FROM " & tipoLista & " WHERE HABILITADO=1 order by nombre")
            ElseIf tipoLista = "ORDEN_DESPACHO" Then
                Call cargarDatos("SELECT * FROM CabeceraTransacciones ORDER BY Hora DESC;")
            ElseIf tipoLista = "PRODUCTOS" Then
                Call cargarDatos("SELECT * FROM Productos")
            ElseIf tipoLista = "MIXERS" Then
                Call cargarDatos("SELECT * FROM Mixers")
            ElseIf tipoLista = "OD_PROCESO" Then
                Call cargarDatos("SELECT
                                Cb.Id,
                                Cb.Fecha,
                                Cb.Hora,
                                Cb.CodProducto,
                                Pr.Descripcion AS NomProducto,
                                Cb.idMixer AS IdMixer,
                                Mx.NombreMixer AS NomMixer,
                                Mx.Placa AS PlacaMixer,
                                Cb.Observaciones
                            FROM
                                (
                                    CabeceraTransacciones AS Cb
                                    LEFT JOIN Productos AS Pr ON Cb.CodProducto = Pr.Id_Producto
                                )
                                LEFT JOIN Mixers AS Mx ON Cb.idMixer = Mx.Id
                            WHERE
                                NOT EXISTS (
                                    SELECT
                                        *
                                    FROM
                                        Transacciones AS T
                                    WHERE
                                        T.Id_Cabecera = Cb.Id
                                )
                            ORDER BY Cb.Hora DESC;")
            Else
                Call cargarDatos("SELECT * FROM " & tipoLista & " order by nombre")
            End If
        Else
            Button4.Text = "Ver Todos"
            If RadioButton4.Checked = True Then
                If tipoLista = "choferes" Then
                    Call cargarDatos("SELECT * FROM " & tipoLista & " where HABILITADO=1 and " & campoCodigo & " like '%" & TextBox1.Text & "%' order by nombre")
                ElseIf tipoLista = "ORDEN_DESPACHO" Then
                    Call cargarDatos("SELECT * FROM CabeceraTransacciones where " & campoCodigo & " like '%" & TextBox1.Text & "%' ORDER BY Hora DESC;")
                ElseIf tipoLista = "PRODUCTOS" Then
                    Call cargarDatos("SELECT * FROM Productos where " & campoCodigo & " like '%" & TextBox1.Text & "%';")
                ElseIf tipoLista = "MIXERS" Then
                    Call cargarDatos("SELECT * FROM Mixers where " & campoCodigo & " like '%" & TextBox1.Text & "%';")
                ElseIf tipoLista = "OD_PROCESO" Then
                    'Call cargarDatos("SELECT * FROM CabeceraTransacciones where " & campoCodigo & " like '%" & TextBox1.Text & "%' ORDER BY Hora DESC;")
                    Call cargarDatos("SELECT
                                Cb.Id,
                                Cb.Fecha,
                                Cb.Hora,
                                Cb.CodProducto,
                                Pr.Descripcion AS NomProducto,
                                Cb.idMixer AS IdMixer,
                                Mx.NombreMixer AS NomMixer,
                                Mx.Placa AS PlacaMixer,
                                Cb.Observaciones
                            FROM
                                (
                                    CabeceraTransacciones AS Cb
                                    LEFT JOIN Productos AS Pr ON Cb.CodProducto = Pr.Id_Producto
                                )
                                LEFT JOIN Mixers AS Mx ON Cb.idMixer = Mx.Id
                            WHERE
                                NOT EXISTS (
                                    SELECT
                                        *
                                    FROM
                                        Transacciones AS T
                                    WHERE
                                        T.Id_Cabecera = Cb.Id
                                ) AND " & campoCodigo & " like '%" & TextBox1.Text & "%' 
                            ORDER BY Cb.Hora DESC;")
                Else
                    Call cargarDatos("SELECT * FROM " & tipoLista & " where " & campoCodigo & " like '%" & TextBox1.Text & "%' order by nombre")
                End If

            ElseIf RadioButton6.Checked = True Then
                If tipoLista = "choferes" Then
                    Call cargarDatos("SELECT * FROM " & tipoLista & " where HABILITADO=1 and " & campoNombre & " like '%" & TextBox1.Text & "%' order by nombre")
                ElseIf tipoLista = "ORDEN_DESPACHO" Then
                    Call cargarDatos("SELECT * FROM CabeceraTransacciones where " & campoNombre & " like '%" & TextBox1.Text & "%' ORDER BY Hora DESC;")
                ElseIf tipoLista = "PRODUCTOS" Then
                    Call cargarDatos("SELECT * FROM Productos where " & campoNombre & " like '%" & TextBox1.Text & "%';")
                ElseIf tipoLista = "MIXERS" Then
                    Call cargarDatos("SELECT * FROM Mixers where " & campoNombre & " like '%" & TextBox1.Text & "%';")
                ElseIf tipoLista = "OD_PROCESO" Then
                    'Call cargarDatos("SELECT * FROM CabeceraTransacciones where " & campoNombre & " like '%" & TextBox1.Text & "%' ORDER BY Hora DESC;")
                    Call cargarDatos("SELECT
                                Cb.Id,
                                Cb.Fecha,
                                Cb.Hora,
                                Cb.CodProducto,
                                Pr.Descripcion AS NomProducto,
                                Cb.idMixer AS IdMixer,
                                Mx.NombreMixer AS NomMixer,
                                Mx.Placa AS PlacaMixer,
                                Cb.Observaciones
                            FROM
                                (
                                    CabeceraTransacciones AS Cb
                                    LEFT JOIN Productos AS Pr ON Cb.CodProducto = Pr.Id_Producto
                                )
                                LEFT JOIN Mixers AS Mx ON Cb.idMixer = Mx.Id
                            WHERE
                                NOT EXISTS (
                                    SELECT
                                        *
                                    FROM
                                        Transacciones AS T
                                    WHERE
                                        T.Id_Cabecera = Cb.Id
                                ) AND " & campoNombre & " like '%" & TextBox1.Text & "%' 
                            ORDER BY Cb.Hora DESC;")
                Else
                    Call cargarDatos("SELECT * FROM " & tipoLista & " where " & campoNombre & " like '%" & TextBox1.Text & "%' order by nombre")
                End If
            ElseIf RadioButton1.Checked = True Then
                If tipoLista = "choferes" Then
                    Call cargarDatos("SELECT * FROM " & tipoLista & " where HABILITADO=1 and " & campoRUC & " like '%" & TextBox1.Text & "%' order by nombre")
                ElseIf tipoLista = "ORDEN_DESPACHO" Then
                    Call cargarDatos("SELECT * FROM CabeceraTransacciones where " & campoRUC & " like '%" & TextBox1.Text & "%' ORDER BY Hora DESC;")
                ElseIf tipoLista = "OD_PROCESO" Then
                    'Call cargarDatos("SELECT * FROM CabeceraTransacciones where " & campoRUC & " like '%" & TextBox1.Text & "%' ORDER BY Hora DESC;")
                    Call cargarDatos("SELECT
                                Cb.Id,
                                Cb.Fecha,
                                Cb.Hora,
                                Cb.CodProducto,
                                Pr.Descripcion AS NomProducto,
                                Cb.idMixer AS IdMixer,
                                Mx.NombreMixer AS NomMixer,
                                Mx.Placa AS PlacaMixer,
                                Cb.Observaciones
                            FROM
                                (
                                    CabeceraTransacciones AS Cb
                                    LEFT JOIN Productos AS Pr ON Cb.CodProducto = Pr.Id_Producto
                                )
                                LEFT JOIN Mixers AS Mx ON Cb.idMixer = Mx.Id
                            WHERE
                                NOT EXISTS (
                                    SELECT
                                        *
                                    FROM
                                        Transacciones AS T
                                    WHERE
                                        T.Id_Cabecera = Cb.Id
                                ) AND " & campoRUC & " like '%" & TextBox1.Text & "%' 
                            ORDER BY Cb.Hora DESC;")
                Else
                    Call cargarDatos("SELECT * FROM " & tipoLista & " where " & campoRUC & " like '%" & TextBox1.Text & "%' order by nombre")
                End If
            Else
                If tipoLista = "choferes" Then
                    Call cargarDatos("SELECT * FROM " & tipoLista & " where HABILITADO=1 and " & campoNombre & " like '%" & TextBox1.Text & "%' order by nombre")
                Else
                    Call cargarDatos("SELECT * FROM " & tipoLista & " where " & "CedulaRUC" & " like '%" & TextBox1.Text & "%' order by nombre")
                End If
            End If
        End If

    End Sub

End Class
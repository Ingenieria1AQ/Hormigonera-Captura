Imports System.Data
Imports System.Data.OleDb
Public Class frmPorOperador

    Private Sub frmPorOperador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrystalReportViewer1.DisplayGroupTree = False
        Dim oOleDbConnection As New OleDb.OleDbConnection(sConnString)
        Dim sqlDaCate As OleDb.OleDbDataAdapter
        Dim dspc As New datosreportes

        Try
            Dim dr As DataRow
            dr = dspc.Tables("Encabezado").NewRow
            dr("Fecha") = filtrofechasr
            dr("Operador") = filtrooperadorr
            dr("Producto") = filtroproductor
            dr("Ingrediente") = filtroingredienter
            dr("NomProducto") = NomProducto1
            dr("NomIngrediente") = NomIngrediente1
            dspc.Tables("Encabezado").Rows.Add(dr)

            'Crear los DataAdapters
            sqlDaCate = New OleDbDataAdapter(cadenaseleccion, oOleDbConnection)

            'Poblar las tablas del dataset desde los dataAdaperts
            sqlDaCate.Fill(dspc, "Transacciones")

            'Poblar el informe con el dataSet y mostrarlo
            Dim info As New crPorOperador
            info.SetDataSource(dspc)
            CrystalReportViewer1.ReportSource = info
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class
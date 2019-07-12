
Imports Microsoft.Practices.Unity
Imports System.IO

Namespace Ladisac.Planillas.Views
    Public Class frmBuscarFecha
        Private sBuscar As String()
        Private sbusco As String


        <Dependency()> _
        Public Property BCProduccion As BL.IBCProduccion
        <Dependency()> _
        Public Property BCCalendarioDias As BL.IBCCalendarioDias

        <Dependency()> _
        Public Property BCGrupoTrabajo As BL.IBCGrupoTrabajo

        <Dependency()> _
        Public Property BCReparoTrabajador As BL.IBCReparoTrabajador

        <Dependency()> _
        Public Property BCTrabajadorHoras As BL.IBCTrabajadorHoras

        <Dependency()> _
        Public Property BCComedor As BL.IBCComedor
        <Dependency()> _
        Public Property BCGrupoMantenimiento As BL.IBCGrupoMantenimiento
        <Dependency()> _
        Public Property BCGrupoEmpleado As BL.IBCGrupoEmpleado
        
        Public Sub inicio(ByVal queBusco As String)
            sbusco = queBusco
            llenarCombo()

        End Sub
      
        Public Property campo1() As String = Nothing
        Public Property campo2() As String = Nothing
        Public Property campo3() As String = Nothing
        Public Property BusquedaAutomatica As Boolean = False


        Public Sub llenarCombo()
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoProduccion) Then
                cboBuscar.Items.Add("ID Proudccion")
                cboBuscar.Items.Add("Numero Proudccion")
                cboBuscar.Items.Add("ID Articulo")
                cboBuscar.Items.Add("Descripcion Articulo")

                cboBuscar.SelectedIndex = 0

                ' en produccion se busca solo por una fecha
                dateHasta.Visible = False
                Label3.Visible = False
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoSinFechaProduccion) Then
                cboBuscar.Items.Add("ID Proudccion")
                cboBuscar.Items.Add("Numero Proudccion")
                cboBuscar.Items.Add("ID Articulo")
                cboBuscar.Items.Add("Descripcion Articulo")

                cboBuscar.SelectedIndex = 0

                ' en produccion se busca solo por una fecha
                Label2.Text = "Fecha Mayor a "
                dateHasta.Visible = False
                Label3.Visible = False
            End If
            'GrupoTrabajoConteoCargaProduccion
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoConteoCargaProduccion) Then
                cboBuscar.Items.Add("ID Proudccion")
                cboBuscar.Items.Add("Numero Proudccion")
                cboBuscar.Items.Add("ID Articulo")
                cboBuscar.Items.Add("Descripcion Articulo")

                cboBuscar.SelectedIndex = 0

                ' en produccion se busca solo por una fecha
                dateHasta.Visible = False
            End If


            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.CalendarioDias) Then
                cboBuscar.Items.Add("(Todo)")

                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoHoras) Then
                cboBuscar.Items.Add("Observaciones")
                cboBuscar.SelectedIndex = 0
            End If


            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReparoTrabajador) Then
                cboBuscar.Items.Add("Numero")
                cboBuscar.Items.Add("Observaciones")

                cboBuscar.SelectedIndex = 0
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TrabajadorHoras) Then
                cboBuscar.Items.Add("Numero")
                cboBuscar.Items.Add("Observaciones")

                cboBuscar.SelectedIndex = 0
            End If

            'If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TareaTrabajo) Then
            '    Dim result = Me.BCTiposTareaTrabajo.TiposTareaTrabajoQuery(Nothing, Nothing)
            '    Dim ds As New DataSet
            '    Dim sr As New StringReader(result)
            '    ds.ReadXml(sr)
            '    Me.cboBuscar.DataSource = ds.Tables(0)
            '    Me.cboBuscar.DisplayMember = "Descripcion"
            '    Me.cboBuscar.ValueMember = "Id"

            'End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Comedor) Then
                cboBuscar.Items.Add("Numero")
                cboBuscar.Items.Add("Observaciones")

                cboBuscar.SelectedIndex = 0

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoMantenimiento) Then
                cboBuscar.Items.Add("Observaciones")
                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoEmpleado) Then
                cboBuscar.Items.Add("Observaciones")
                cboBuscar.SelectedIndex = 0
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.OrdenTrabajo) Then
                cboBuscar.Items.Add("ID Oden")
                cboBuscar.Items.Add("Entidad Descripcion")
                cboBuscar.Items.Add("Descrpcion O.T.")

                cboBuscar.SelectedIndex = 0

                ' en produccion se busca solo por una fecha
                dateHasta.Visible = True
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoQuemaSecadeo) Then
                cboBuscar.Items.Add("Codigo OP")
                cboBuscar.Items.Add("Cosido Persona")
                cboBuscar.Items.Add("Nombre Persona")

                cboBuscar.SelectedIndex = 0

                ' en produccion se busca solo por una fecha
                dateHasta.Visible = False
            End If



        End Sub
        Private Sub ocultarColumnas()

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoProduccion) Then

                dgbRegistro.Columns("Codigo_Ladrillo").Visible = False
                dgbRegistro.Columns("Codigo_planta").Visible = False
                dgbRegistro.Columns("ART_ID").Visible = False
                dgbRegistro.Columns("Codigo_Ladrillo").Visible = False
                dgbRegistro.Columns("Observaciones").Width = dgbRegistro.Columns("Observaciones").Width + 100


            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoSinFechaProduccion) Then
                dgbRegistro.Columns("ID").Visible = False
                dgbRegistro.Columns("Codigo_planta").Visible = False
                dgbRegistro.Columns("ART_ID").Visible = False
                dgbRegistro.Columns("Codigo_Ladrillo").Visible = False
                dgbRegistro.Columns("Observaciones").Width = dgbRegistro.Columns("Observaciones").Width + 100
                dgbRegistro.Columns("Ladrillo").Width = dgbRegistro.Columns("Ladrillo").Width + 70

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoQuemaSecadeo) Then
                dgbRegistro.Columns("Tipo").Visible = False
                dgbRegistro.Columns("CodigoOP").Visible = False
                dgbRegistro.Columns("Per_id").Visible = False
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoConteoCargaProduccion) Then
                dgbRegistro.Columns("ID").Visible = False
                dgbRegistro.Columns("Codigo_Ladrillo").Visible = False
                dgbRegistro.Columns("Codigo_planta").Visible = False
                dgbRegistro.Columns("Ladrillo").Width = dgbRegistro.Columns("Ladrillo").Width + 120

            End If

            'TrabajadorHoras
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TrabajadorHoras) Then

                dgbRegistro.Columns(0).Visible = False
                dgbRegistro.Columns(0).Visible = False
                dgbRegistro.Columns(1).Width = 50
                dgbRegistro.Columns(2).Width = 50
                dgbRegistro.Columns(3).Width = 50
                dgbRegistro.Columns(4).Width = 50
                dgbRegistro.Columns(5).Width = 50

                dgbRegistro.Columns(6).Width = dgbRegistro.Columns(6).Width + 250

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Comedor) Then
                dgbRegistro.Columns("Observaciones").Width = 300
            End If



        End Sub
        Public Sub cargarDatos()

            Dim query As String = Nothing
            dgbRegistro.DataSource = Nothing
            'If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoProduccion) Then
            '    query = Me.BCConceptos.ConceptosQuery(Nothing, cboBuscar.SelectedValue, txtBuscar.Text.Trim)
            'End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoProduccion) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCProduccion.ProduccionGrupoTrabajoQuery(Val(txtBuscar.Text), Nothing, Nothing, Nothing, CDate(IIf(dateDesde.Text = "", Today.AddMonths(-5), dateDesde.Text)), CDate(IIf(dateDesde.Text = "", Today, dateDesde.Text)))
                    Case 1
                        query = Me.BCProduccion.ProduccionGrupoTrabajoQuery(Nothing, txtBuscar.Text, Nothing, Nothing, CDate(IIf(dateDesde.Text = "", Today.AddMonths(-5), dateDesde.Text)), CDate(IIf(dateDesde.Text = "", Today, dateDesde.Text)))
                    Case 2
                        query = Me.BCProduccion.ProduccionGrupoTrabajoQuery(Nothing, Nothing, txtBuscar.Text, Nothing, CDate(dateDesde.Text), CDate(dateDesde.Text))
                    Case 3
                        query = Me.BCProduccion.ProduccionGrupoTrabajoQuery(Nothing, Nothing, Nothing, txtBuscar.Text, CDate(dateDesde.Text), CDate(dateDesde.Text))
                End Select

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoSinFechaProduccion) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCProduccion.ProduccionGrupoTrabajoSinFechaQuery(Val(txtBuscar.Text), Nothing, Nothing, Nothing, CDate(IIf(dateDesde.Text = "", Today.AddMonths(-5), dateDesde.Text)), True)
                    Case 1
                        query = Me.BCProduccion.ProduccionGrupoTrabajoSinFechaQuery(Nothing, txtBuscar.Text, Nothing, Nothing, CDate(IIf(dateDesde.Text = "", Today.AddMonths(-5), dateDesde.Text)), True)
                    Case 2
                        query = Me.BCProduccion.ProduccionGrupoTrabajoSinFechaQuery(Nothing, Nothing, txtBuscar.Text, Nothing, CDate(dateDesde.Text), True)
                    Case 3
                        query = Me.BCProduccion.ProduccionGrupoTrabajoSinFechaQuery(Nothing, Nothing, Nothing, txtBuscar.Text, CDate(dateDesde.Text), True)
                End Select
            End If

            'GrupoTrabajoConteoCargaProduccion
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoConteoCargaProduccion) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCProduccion.ProduccionCargaConteoSelectXML(Val(txtBuscar.Text), Nothing, Nothing, Nothing, CDate(IIf(dateDesde.Text = "", Today, dateDesde.Text)), CDate(IIf(dateDesde.Text = "", Today, dateDesde.Text)), CDate(campo1))
                    Case 1
                        query = Me.BCProduccion.ProduccionCargaConteoSelectXML(Nothing, txtBuscar.Text, Nothing, Nothing, CDate(IIf(dateDesde.Text = "", Today, dateDesde.Text)), CDate(IIf(dateDesde.Text = "", Today, dateDesde.Text)), CDate(campo1))
                    Case 2
                        query = Me.BCProduccion.ProduccionCargaConteoSelectXML(Nothing, Nothing, txtBuscar.Text, Nothing, CDate(dateDesde.Text), CDate(dateDesde.Text), CDate(campo1))
                    Case 3
                        query = Me.BCProduccion.ProduccionCargaConteoSelectXML(Nothing, Nothing, Nothing, txtBuscar.Text, CDate(dateDesde.Text), CDate(dateDesde.Text), CDate(campo1))
                End Select

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.CalendarioDias) Then

                query = Me.BCCalendarioDias.CalendarioDiasQuery(CDate(dateDesde.Text), CDate(dateHasta.Text))

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoHoras) Then
                query = Me.BCGrupoTrabajo.GrupoTrabajoQuery(CDate(dateDesde.Text), CDate(dateHasta.Text), txtBuscar.Text)

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReparoTrabajador) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCReparoTrabajador.ReparoTrabajadorQuery(txtBuscar.Text, Nothing, CDate(dateDesde.Text), CDate(dateHasta.Text))
                    Case 1
                        query = Me.BCReparoTrabajador.ReparoTrabajadorQuery(Nothing, txtBuscar.Text, CDate(dateDesde.Text), CDate(dateHasta.Text))
                End Select


            End If


            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TrabajadorHoras) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCTrabajadorHoras.TrabajadorHorasQuery(txtBuscar.Text, CDate(dateDesde.Text), CDate(dateHasta.Text), Nothing)
                    Case 1
                        query = Me.BCTrabajadorHoras.TrabajadorHorasQuery(Nothing, CDate(dateDesde.Text), CDate(dateHasta.Text), txtBuscar.Text)
                End Select


            End If


            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Comedor) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCComedor.ComedorQuery(txtBuscar.Text, Nothing, CDate(dateDesde.Text), CDate(dateHasta.Text))
                    Case 1
                        query = Me.BCComedor.ComedorQuery(Nothing, txtBuscar.Text, CDate(dateDesde.Text), CDate(dateHasta.Text))
                End Select


            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoMantenimiento) Then
                query = BCGrupoMantenimiento.GrupoMantenimientoQuery(CDate(dateDesde.Text), CDate(dateHasta.Text), txtBuscar.Text)

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoEmpleado) Then
                query = BCGrupoEmpleado.GrupoEmpleadoQuery(CDate(dateDesde.Text), CDate(dateHasta.Text), txtBuscar.Text)

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.OrdenTrabajo) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = BCGrupoMantenimiento.SPGrupoMantenimientoOrdenTrabajoSelectXML((txtBuscar.Text), Nothing, Nothing, CDate(dateDesde.Value), CDate(dateHasta.Value))
                    Case 1
                        query = BCGrupoMantenimiento.SPGrupoMantenimientoOrdenTrabajoSelectXML(Nothing, txtBuscar.Text, Nothing, CDate(dateDesde.Value), CDate(dateHasta.Value))
                    Case 2
                        query = BCGrupoMantenimiento.SPGrupoMantenimientoOrdenTrabajoSelectXML(Nothing, Nothing, txtBuscar.Text, CDate(dateDesde.Value), CDate(dateHasta.Value))

                End Select

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoQuemaSecadeo) Then
                ' en campo1 pondremos si es de Quema 01 , Secadero 02
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = BCGrupoTrabajo.spGrupoTrabajoQuemaSecaderoSelectXML(campo1, CDate(dateDesde.Value), txtBuscar.Text, Nothing, Nothing)
                    Case 1
                        query = BCGrupoTrabajo.spGrupoTrabajoQuemaSecaderoSelectXML(campo1, CDate(dateDesde.Value), Nothing, txtBuscar.Text, Nothing)
                    Case 2
                        query = BCGrupoTrabajo.spGrupoTrabajoQuemaSecaderoSelectXML(campo1, CDate(dateDesde.Value), Nothing, Nothing, txtBuscar.Text)

                End Select

            End If

            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgbRegistro.DataSource = ds.Tables(0)

                   
                    If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Comedor) Then
                        If (dgbRegistro.Columns(0).HeaderText <> "ok") Then

                            dgbRegistro.Columns.Insert(0, New DataGridViewCheckBoxColumn())
                            dgbRegistro.Columns(0).ReadOnly = False
                            dgbRegistro.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                            dgbRegistro.ReadOnly = False
                            dgbRegistro.Columns(0).HeaderText = "ok"
                        End If

                    End If

                    ocultarColumnas()
                Else
                    dgbRegistro.DataSource = Nothing
                End If
            End If

        End Sub
        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            cargarDatos()
        End Sub

        Private Sub dgbRegistro_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbRegistro.CellDoubleClick

            If e.RowIndex >= 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        End Sub
        Private Sub frmBuscarFecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoProduccion) Then
                ' dateDesde.Text = Today.AddMonths(-5)
                dateHasta.Text = Today.AddMonths(2)
            End If
        End Sub


        Private Sub frmBuscarSimple_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
            txtBuscar.Focus()
        End Sub

        Private Sub frmBuscarSimple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtBuscar.Focus()
        End Sub

        Private Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
  Handles txtBuscar.KeyDown, cboBuscar.KeyDown

            Select Case e.KeyValue
                Case 13
                    If dgbRegistro.SelectedRows.Count >= 0 Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()
                Case 40 : dgbRegistro.Focus()
            End Select



        End Sub

        Private Sub dataRegistros_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgbRegistro.KeyDown

            Select Case e.KeyValue
                Case 13
                    If dgbRegistro.SelectedRows.Count >= 0 Then

                        e.SuppressKeyPress = True

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()
            End Select


        End Sub

        Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
            If (txtBuscar.Text.Length >= 3) Then
                cargarDatos()
            End If
        End Sub



        Private Sub dateDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateDesde.ValueChanged
            If (BusquedaAutomatica) Then
                cargarDatos()
            End If

        End Sub
    End Class
End Namespace



Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Namespace Ladisac.Produccion.Views

    Public Class frmBuscar

        <Dependency()> _
        Public Property BCTipoParada As Ladisac.BL.IBCTipoParada
        <Dependency()> _
        Public Property BCParada As Ladisac.BL.IBCParada
        <Dependency()> _
        Public Property BCCancha As Ladisac.BL.IBCCancha
        <Dependency()> _
        Public Property BCCortadora As Ladisac.BL.IBCCortadora
        <Dependency()> _
        Public Property BCSecadero As Ladisac.BL.IBCSecadero
        <Dependency()> _
        Public Property BCTipoProduccion As Ladisac.BL.IBCTipoProduccion
        <Dependency()> _
        Public Property BCPlanta As Ladisac.BL.IBCPlanta
        <Dependency()> _
        Public Property BCProduccion As Ladisac.BL.IBCProduccion
        <Dependency()> _
        Public Property BCPersona As Ladisac.BL.IBCPersona
        <Dependency()> _
        Public Property BCControlConteo As Ladisac.BL.IBCControlConteo
        <Dependency()> _
        Public Property BCControlParada As Ladisac.BL.IBCControlParada
        <Dependency()> _
        Public Property BCControlCanchero As Ladisac.BL.IBCControlCanchero
        <Dependency()> _
        Public Property BCControlPeso As Ladisac.BL.IBCControlPeso
        <Dependency()> _
        Public Property BCControlExtrusora As Ladisac.BL.IBCControlExtrusora
        <Dependency()> _
        Public Property BCSalidaSecadero As Ladisac.BL.IBCSalidaSecadero
        <Dependency()> _
        Public Property BCControlInspeccion As Ladisac.BL.IBCControlInspeccion
        <Dependency()> _
        Public Property BCControlMezcla As Ladisac.BL.IBCControlMezcla
        <Dependency()> _
        Public Property BCArticulo As Ladisac.BL.IBCArticulo
        <Dependency()> _
        Public Property BCHorno As Ladisac.BL.IBCHorno
        <Dependency()> _
        Public Property BCMolde As Ladisac.BL.IBCMolde
        <Dependency()> _
        Public Property BCPuertaHorno As Ladisac.BL.IBCPuertaHorno
        <Dependency()> _
        Public Property BCMaleconPuerta As Ladisac.BL.IBCMaleconPuerta
        <Dependency()> _
        Public Property BCLadrilloMalecon As Ladisac.BL.IBCLadrilloMalecon
        <Dependency()> _
        Public Property BCAlmacen As Ladisac.BL.IBCAlmacen
        <Dependency()> _
        Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen
        <Dependency()> _
        Public Property BCConsumoCombustible As Ladisac.BL.IBCConsumoCombustible
        <Dependency()> _
        Public Property BCControlDescargaRuma As Ladisac.BL.IBCControlDescargaRuma
        <Dependency()> _
        Public Property BCEntidad As Ladisac.BL.IBCEntidad
        <Dependency()> _
        Public Property BCCats As Ladisac.BL.IBCCats
        <Dependency()> _
        Public Property BCLadrillo As Ladisac.BL.IBCLadrillo
        <Dependency()> _
        Public Property BCExtrusora As Ladisac.BL.IBCExtrusora
        <Dependency()> _
        Public Property BCControlCarga As Ladisac.BL.IBCControlCarga
        <Dependency()> _
        Public Property BCControlQuema As Ladisac.BL.IBCControlQuema
        <Dependency()> _
        Public Property BCControlEnergia As Ladisac.BL.IBCControlEnergia
        <Dependency()> _
        Public Property BCControlplanta As Ladisac.BL.IBCControlPlanta
        <Dependency()> _
        Public Property BCUnidadesTransporte As Ladisac.BL.IBCUnidadesTransporte
        <Dependency()> _
        Public Property BCPlanCargaDescargaHorno As Ladisac.BL.IBCPlanCargaDescargaHorno
        <Dependency()> _
        Public Property BCControlPaqueteo As Ladisac.BL.IBCControlPaqueteo

        Public Property Tabla() As String
            Get
                Return mTabla
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mTabla = Nothing
                Else
                    mTabla = value
                End If
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return mTipo
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mTipo = Nothing
                Else
                    mTipo = value
                End If
            End Set
        End Property

        Public Property Tipo2() As String
            Get
                Return mTipo2
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mTipo2 = Nothing
                Else
                    mTipo2 = value
                End If
            End Set
        End Property

        Public Property Arti_Id() As String
            Get
                Return mArti_Id
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mArti_Id = Nothing
                Else
                    mArti_Id = value
                End If
            End Set
        End Property

        Dim mTabla As String
        Dim mTipo As String
        Dim mTipo2 As String
        Dim query As String = ""
        Dim mArti_Id As String

        Dim ds As New DataSet
        Dim col As Integer = 0

        Private Sub frmBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, txtBuscar.KeyDown, dgvLista.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Dispose()
            End If
        End Sub


        '<Microsoft.Practices.Unity.InjectionConstructor()> _ 'Para decirle a unity con que constructor empezar
        'Public Sub New(ByVal mTabla As String)
        '    ' This call is required by the designer.
        '    InitializeComponent()
        '    ' Add any initialization after the InitializeComponent() call.
        '    Tabla = mTabla
        'End Sub

        Private Sub frmBuscarTipoParada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Select Case Tabla
                Case "Entidad"
                    Me.lblTitle.Text = "Busqueda Entidad"
                    query = Me.BCEntidad.ListaEntidad
                Case "TipoParada"
                    Me.lblTitle.Text = "Busqueda Tipo Parada"
                    query = Me.BCTipoParada.ListaTipoParada(0)
                Case "Parada"
                    Me.lblTitle.Text = "Busqueda Parada"
                    query = Me.BCParada.ListaParada(0)
                Case "Cancha"
                    Me.lblTitle.Text = "Busqueda Cancha"
                    query = Me.BCCancha.ListaCancha
                Case "Cortadora"
                    Me.lblTitle.Text = "Busqueda Cortadora"
                    query = Me.BCCortadora.ListaCortadora
                Case "Extrusora"
                    Me.lblTitle.Text = "Busqueda Extrusora"
                    query = Me.BCExtrusora.ListaExtrusora
                Case "Secadero"
                    Me.lblTitle.Text = "Busqueda Secadero"
                    query = Me.BCSecadero.ListaSecadero
                Case "TipoProduccion"
                    Me.lblTitle.Text = "Busqueda Tipo Produccion"
                    query = Me.BCTipoProduccion.ListaTipoProduccion
                Case "Planta"
                    Me.lblTitle.Text = "Busqueda Planta"
                    query = Me.BCPlanta.ListaPlanta
                Case "Produccion"
                    Me.lblTitle.Text = "Busqueda Produccion"
                    query = Me.BCProduccion.ListaProduccion
                Case "ProduccionParaSecadero"
                    Me.lblTitle.Text = "Busqueda Produccion para Secadero"
                    query = Me.BCProduccion.ListaProduccionParaSecadero
                Case "Persona"
                    Me.lblTitle.Text = "Busqueda"
                    query = Me.BCPersona.ListaPersona(Tipo)
                Case "ControlConteo"
                    Me.lblTitle.Text = "Busqueda Control Conteo"
                    query = Me.BCControlConteo.ListaControlConteo
                Case "ControlParada"
                    Me.lblTitle.Text = "Busqueda Control Parada"
                    query = Me.BCControlParada.ListaControlParada
                Case "ControlCanchero"
                    Me.lblTitle.Text = "Busqueda Control Canchero"
                    query = Me.BCControlCanchero.ListaControlCanchero
                Case "ControlPeso"
                    Me.lblTitle.Text = "Busqueda Control Peso"
                    query = Me.BCControlPeso.ListaControlPeso
                Case "ControlExtrusora"
                    Me.lblTitle.Text = "Busqueda Control Extrusora"
                    query = Me.BCControlExtrusora.ListaControlExtrusora
                Case "SalidaSecadero"
                    Me.lblTitle.Text = "Busqueda Salida Secadero"
                    query = Me.BCSalidaSecadero.ListaSalidaSecadero
                Case "SalidaSecaderoCombustible"
                    Me.lblTitle.Text = "Busqueda Salida Secadero"
                    query = Me.BCSalidaSecadero.ListaSalidaSecaderoCombustible
                Case "ControlInspeccion"
                    Me.lblTitle.Text = "Busqueda Control Inspeccion"
                    query = Me.BCControlInspeccion.ListaControlInspeccion
                Case "ControlMezcla"
                    Me.lblTitle.Text = "Busqueda Control Mezcla"
                    query = Me.BCControlMezcla.ListaControlMezcla
                Case "Articulo"
                    Me.lblTitle.Text = "Busqueda Articulo"
                    query = Me.BCArticulo.ListaArticulo
                Case "ArticuloMateriaPrima"
                    Me.lblTitle.Text = "Busqueda Articulo Materia Prima"
                    query = Me.BCArticulo.ListaArticuloMateriaPrima
                Case "ArticuloMateriaPrimaMezcla"
                    Me.lblTitle.Text = "Busqueda Articulo Materia Prima"
                    query = Me.BCArticulo.ListaArticuloMateriaPrimaMezcla
                Case "ArticuloControlParada"
                    Me.lblTitle.Text = "Busqueda Articulos de Control Parada"
                    query = Me.BCArticulo.ListaArticuloControlParada
                Case "Horno"
                    Me.lblTitle.Text = "Busqueda Horno"
                    query = Me.BCHorno.ListaHorno
                Case "Ladrillo"
                    Me.lblTitle.Text = "Busqueda Ladrillo"
                    query = Me.BCLadrillo.ListaLadrillo
                Case "Molde"
                    Me.lblTitle.Text = "Busqueda Molde"
                    query = Me.BCMolde.ListaMolde
                Case "Cats"
                    Me.lblTitle.Text = "Busqueda Cats"
                    query = Me.BCCats.ListaCats
                Case "CatsMezcla"
                    Me.lblTitle.Text = "Busqueda Cats"
                    query = Me.BCCats.ListaCatsMezcla
                Case "PuertaHorno"
                    Me.lblTitle.Text = "Busqueda Puerta Horno"
                    query = Me.BCPuertaHorno.ListaPuertaHorno
                Case "MaleconPuerta"
                    Me.lblTitle.Text = "Busqueda Malecon Puerta"
                    query = Me.BCMaleconPuerta.ListaMaleconPuerta
                Case "LadrilloMalecon"
                    Me.lblTitle.Text = "Busqueda Ladrillo Malecon"
                    query = Me.BCLadrilloMalecon.ListaLadrilloMalecon
                Case "Almacen"
                    Me.lblTitle.Text = "Busqueda Almacen"
                    query = Me.BCAlmacen.ListaAlmacen
                Case "ArticuloAlmacen"
                    Me.lblTitle.Text = "Busqueda Articulo Almacen"
                    query = Me.BCArticuloAlmacen.ListaArticuloAlmacen(Arti_Id, Nothing)
                Case "ConsumoCombustible"
                    Me.lblTitle.Text = "Busqueda Consumo Combustible"
                    query = Me.BCConsumoCombustible.ListaConsumoCombustible
                Case "ListaDesHorProcesar"
                    Me.lblTitle.Text = "Busqueda Descarga de Hornos"
                    query = Me.BCControlDescargaRuma.ListaDesHorProcesar
                Case "ControlDescargaRuma"
                    Me.lblTitle.Text = "Busqueda Control Descarga Ruma"
                    query = Me.BCControlDescargaRuma.ListaControlDescargaRuma
                Case "ControlCarga"
                    Me.lblTitle.Text = "Busqueda Control Carga"
                    query = Me.BCControlCarga.ListaControlCarga(Tipo)
                Case "ControlQuema"
                    Me.lblTitle.Text = "Busqueda Control Quema"
                    query = Me.BCControlQuema.ListaControlQuema
                Case "ControlQuemaCombustible"
                    Me.lblTitle.Text = "Busqueda Control Quema"
                    query = Me.BCControlQuema.ListaControlQuemaCombustible
                Case "PesoQuema"
                    Me.lblTitle.Text = "Busqueda Peso Quema"
                    query = Me.BCProduccion.PesoQuema(Tipo)
                Case "AreaConsumoEnergia"
                    Me.lblTitle.Text = "Busqueda Area Consumo Energia"
                    query = Me.BCControlEnergia.ListadoAreaConsumoEnergia
                Case "ArConEne"
                    Me.lblTitle.Text = "Busqueda Consumo Energia por Area"
                    query = Me.BCControlEnergia.ListaArConEne(CInt(Tipo))
                Case "ControlPlanta"
                    Me.lblTitle.Text = "Busqueda Control Planta"
                    query = Me.BCControlplanta.ListaControlPlanta
                Case "CanchaSecadero"
                    Me.lblTitle.Text = "Busqueda Cancha y Secadero"
                    query = Me.BCHorno.ListaCanchaSecadero(Tipo)
                Case "UnidadesTransporte"
                    Me.lblTitle.Text = "Busqueda Unidades Transporte"
                    query = Me.BCUnidadesTransporte.ListaUnidadesTransporteXPlaca(Tipo)
                Case "PlanCargaDescargaHorno"
                    Me.lblTitle.Text = "Busqueda Plan Carga Descarga Horno"
                    query = Me.BCPlanCargaDescargaHorno.ListaPlanCargaDescargaHorno
                Case "Placa"
                    Me.lblTitle.Text = "Busqueda Placas"
                    query = Me.BCUnidadesTransporte.ListaUnidadesTransporteEmpresa(Tipo)
                Case "ProduccionVagones"
                    Me.lblTitle.Text = "Busqueda Produccion Vagones"
                    query = Me.BCProduccion.ListaProduccionVagones(Tipo)
                Case "ControlPaqueteo"
                    Me.lblTitle.Text = "Busqueda Control Paqueteo"
                    query = Me.BCControlPaqueteo.ListaControlPaqueteo(Tipo, Tipo2)
            End Select

            Try
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                dgvLista.DataSource = ds.Tables(0)
                Select Case Tabla
                    Case "Persona", Tipo = "Trabajador"
                        dgvLista.Columns(0).Visible = False
                End Select

                col = 1 'para que se valla a la decripcion y no al codigo
                dgvLista.CurrentCell = dgvLista.Rows(0).Cells(col)
            Catch ex As Exception
                dgvLista.DataSource = Nothing
            End Try
            txtBuscar.Focus()
        End Sub

        Private Sub dgvLista_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellClick
            col = e.ColumnIndex
        End Sub

        Private Sub dgvLista_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellDoubleClick
            If dgvLista.RowCount > 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End Sub

        Function ColumVisible(ByVal col As Integer, ByVal signo As Integer) As Integer
            Dim mCol As Integer
            If col = -1 Or col > dgvLista.Columns.Count - 1 Then
                mCol = 700
            Else
                If Not dgvLista.Columns(col).Visible Then
                    If signo = -1 Then
                        mCol = ColumVisible(col - 1, -1)
                    Else
                        mCol = ColumVisible(col + 1, 1)
                    End If
                Else
                    mCol = col
                End If
            End If
            Return mCol
        End Function

        Private Sub txtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyDown
            If dgvLista.CurrentRow Is Nothing Then dgvLista.DataSource = ds.Tables(0) : Exit Sub
            If col = -1 Then col = 0
            If e.KeyCode = Keys.Down Then
                If dgvLista.CurrentRow.Index < dgvLista.Rows.Count - 1 Then If dgvLista.Columns(col).Visible Then dgvLista.CurrentCell = dgvLista.Rows(dgvLista.CurrentRow.Index + 1).Cells(col)
            ElseIf e.KeyCode = Keys.Up Then
                If dgvLista.CurrentRow.Index > 0 Then If dgvLista.Columns(col).Visible Then dgvLista.CurrentCell = dgvLista.Rows(dgvLista.CurrentRow.Index - 1).Cells(col)
            ElseIf e.KeyCode = Keys.Enter Then
                dgvLista_CellDoubleClick(Nothing, Nothing)
            ElseIf e.KeyCode = Keys.Left Then
                If ColumVisible(col - 1, -1) <> 700 Then
                    col = ColumVisible(col - 1, -1)
                    dgvLista.CurrentCell = dgvLista.CurrentRow.Cells(col)
                End If
            ElseIf e.KeyCode = Keys.Right Then
                If ColumVisible(col + 1, 1) <> 700 Then
                    col = ColumVisible(col + 1, 1)
                    dgvLista.CurrentCell = dgvLista.CurrentRow.Cells(col)
                End If
            ElseIf e.KeyCode = Keys.Back Then
                dgvLista.DataSource = ds.Tables(0)
            End If
        End Sub

        Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
            If col = -1 Then col = 0
            dgvLista.DataSource = SelectDataTable(CType(dgvLista.DataSource, DataTable), dgvLista.Columns(col).Name & " like '%" & txtBuscar.Text & "%'")
            If txtBuscar.Text = "" Then dgvLista.DataSource = ds.Tables(0)
            If dgvLista.Rows.Count > 0 Then dgvLista.CurrentCell = dgvLista.Rows(0).Cells(col)
        End Sub

        Public Shared Function SelectDataTable(ByVal dt As DataTable, ByVal filter As String) As DataTable
            Dim dtNew As DataTable
            Try
                dtNew = dt.Clone()
                dtNew = dt.Select(filter).CopyToDataTable
            Catch ex As Exception

            End Try
            Return dtNew
        End Function

        Private Sub dgvLista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLista.KeyDown
            If e.KeyCode = Keys.Enter Then
                dgvLista_CellDoubleClick(Nothing, Nothing)
                e.SuppressKeyPress = True
            End If
        End Sub

        Public Sub Ajustar_Columna_DataGrid(ByVal DataGrid As DataGridView, ByVal Dt As DataTable, Optional ByVal AccForHeaders As Boolean = False)
            Dim TempCol() As Integer
            Dim Nregistros As Integer, NCampos As Integer
            Dim Fila As Integer, Col As Integer, width As Single
            Dim maxWidth As Single
            'Variables para la cantidad de registros y columnas  
            Nregistros = Dt.Rows.Count
            NCampos = Dt.Columns.Count
            'Array para almacenar el ancho de cada columna  
            ReDim TempCol(NCampos)
            ' Si el número de registros es igual a 0 salimos  
            If Nregistros = 0 Then Exit Sub
            maxWidth = 0
            'Recorremos las columnas  
            For Col = 0 To NCampos - 1
                If AccForHeaders Then
                    'Almacenamos el Ancho del texto de la columna  
                    maxWidth = DataGrid.Columns(Col).HeaderText.Length + 65
                End If
                'Recorremos los registros de esta columna  
                For Fila = 0 To Nregistros - 1
                    'Almacena el Ancho del texto de la celda del Datagrid  
                    width = DataGrid.Rows(Fila).Cells(Col).Value.ToString.Length + 65

                    'Si el ancho de la celda es mayor se actualiza la variable maxWidth y se establece el ancho de la columna  
                    If width > maxWidth Then
                        maxWidth = width
                        DataGrid.Columns(Col).Width = maxWidth
                    End If
                Next
                'Almacenamos el ancho de la columna  
                TempCol(Col) = maxWidth
            Next
            'Recorremos cada columna y le asignamos el ancho  
            For Col = 0 To NCampos - 1
                DataGrid.Columns(Col).Width = TempCol(Col)
            Next
        End Sub
    End Class
End Namespace

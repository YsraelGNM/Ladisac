
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmConceptos

        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()>
        Public Property BCConceptos As Ladisac.BL.IBCConceptos

        <Dependency()>
        Public Property BCTiposConceptosQueries As Ladisac.BL.IBCTiposConceptosQueries

        <Dependency()> _
        Public Property BC As Ladisac.BL.IBCConceptos

        Protected oConceptos As New Conceptos

        Private Function validar()
            Dim result As Boolean = True

            If (chkCrearFunction.Checked) Then
                If (chkCrearFunctionSecundario.Checked) Then
                    ErrorProvider1.SetError(chkCrearFunctionSecundario, "Solo se puede crear una  de las funciones de acumulados")
                    result = False
                    ' result
                Else
                    ErrorProvider1.SetError(chkCrearFunctionSecundario, Nothing)
                End If
            End If


            If (txtConcepto.Text.Trim = "") Then
                ErrorProvider1.SetError(txtConcepto, "Concepto")
                result = False
                ' result
            Else
                ErrorProvider1.SetError(txtConcepto, Nothing)
            End If
            If (txtDescripcion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtDescripcion, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcion, Nothing)
            End If
            Return result
        End Function

        Private Sub buscarTipos()
            Try

                Dim result = Me.BCTiposConceptosQueries.TiposDocumentosQuery()

                Dim ds As New DataSet
                Dim sr As New StringReader(result)

                ds.ReadXml(sr)
                Me.cboTipoConcepto.DataSource = ds.Tables(0)
                Me.cboTipoConcepto.DisplayMember = "tic_Descripcion"
                Me.cboTipoConcepto.ValueMember = "tic_TipoConcep_Id"
            Catch ex As Exception
                MsgBox("No se Pudo cargar los datos")
            End Try


        End Sub
        Sub CargarConceptos(ByVal tipo As String, ByVal codigoConcepto As String)

            limpiar()
            cboTipoConcepto.Enabled = False
            oConceptos = BCConceptos.ConceptosSeek(tipo, codigoConcepto)
            oConceptos.MarkAsModified()

            txtCodigo.Text = oConceptos.con_Conceptos_Id
            cboTipoConcepto.SelectedValue = oConceptos.tic_TipoConcep_Id
            txtConcepto.Text = oConceptos.con_Concepto

            chkEsFijo.Checked = oConceptos.con_EsFijoTrabajador
            txtCodigoSunat.Text = oConceptos.con_CodigoSunat
            chkEsCalculo.Checked = oConceptos.con_Escalculo
            chkEsCalculoHoras.Checked = oConceptos.con_EsTareoHoras
            txtDescripcion.Text = oConceptos.con_Descripcion
            chkEsJuridico.Checked = oConceptos.con_EsConceptoDscJudi
            chkEsPrestamo.Checked = oConceptos.con_EsConceptoPrestamo
            chkCrearFunction.Checked = oConceptos.con_EsformulaAcumulado
            chkCrearFunctionSecundario.Checked = oConceptos.con_EsformulaAcumuladoSecundario
            cboNivelCalculo.SelectedIndex = oConceptos.con_NivelDeCalculo

        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Conceptos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                CargarConceptos(frm.dgbRegistro.CurrentRow.Cells(1).Value, frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If

            frm.Dispose()
            Pan.Enabled = False

        End Sub
        Public Overrides Sub OnManGuardar()
            If (validar()) Then
                Try
                    oConceptos.con_Conceptos_Id = IIf(txtCodigo.Text = "", Nothing, txtCodigo.Text)
                    oConceptos.TiposConceptos = Me.BCTiposConceptosQueries.TiposDocumentosSeek(cboTipoConcepto.SelectedValue)
                    oConceptos.con_Concepto = txtConcepto.Text
                    oConceptos.con_EsFijoTrabajador = chkEsFijo.Checked
                    oConceptos.con_CodigoSunat = txtCodigoSunat.Text
                    oConceptos.con_Escalculo = chkEsCalculo.Checked
                    oConceptos.con_EsTareoHoras = chkEsCalculoHoras.Checked
                    oConceptos.con_Descripcion = txtDescripcion.Text
                    oConceptos.con_EsConceptoDscJudi = chkEsJuridico.Checked
                    oConceptos.con_EsConceptoPrestamo = chkEsPrestamo.Checked
                    oConceptos.Usu_Id = SessionService.UserId
                    oConceptos.con_FECGRAB = Now
                    oConceptos.con_EsformulaAcumulado = chkCrearFunction.Checked
                    oConceptos.con_EsformulaAcumuladoSecundario = chkCrearFunctionSecundario.Checked
                    oConceptos.con_NivelDeCalculo = cboNivelCalculo.SelectedIndex


                    BCConceptos.Maintenance(oConceptos)
                    ' verificar si se guardo o se edito
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Pan.Enabled = False
                    limpiar()
                    'finde verificar
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    If (rethrow) Then
                        Throw
                    End If
                End Try

            End If

        End Sub

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            txtConcepto.ReadOnly = False
            oConceptos = New Conceptos
            oConceptos.MarkAsAdded()

            Pan.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub
        Public Overrides Sub OnManEliminar()
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    oConceptos.MarkAsDeleted()
                    oConceptos.con_Conceptos_Id = IIf(txtCodigo.Text = "", Nothing, txtCodigo.Text)
                    oConceptos.tic_TipoConcep_Id = cboTipoConcepto.SelectedValue
                    oConceptos.con_Concepto = txtConcepto.Text
                    oConceptos.con_EsFijoTrabajador = chkEsFijo.Checked
                    oConceptos.con_CodigoSunat = txtCodigoSunat.Text
                    oConceptos.con_Escalculo = chkEsCalculo.Checked
                    oConceptos.con_EsTareoHoras = chkEsCalculoHoras.Checked
                    oConceptos.con_Descripcion = txtDescripcion.Text
                    oConceptos.con_EsConceptoDscJudi = chkEsJuridico.Checked
                    oConceptos.con_EsConceptoPrestamo = chkEsPrestamo.Checked
                    oConceptos.Usu_Id = SessionService.UserId
                    oConceptos.con_FECGRAB = Now

                    oConceptos.con_EsformulaAcumulado = chkCrearFunction.Checked

                    BCConceptos.Maintenance(oConceptos)
                    MsgBox("Datos Eliminados")
                    ' verificar si se elimino
                    Pan.Enabled = False
                    limpiar()
                    ' fin de  verificar
                End If
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub
        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            Pan.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManEditar()
            menuEditar()
            txtConcepto.ReadOnly = True
            Pan.Enabled = True
        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Pan.Enabled = False
            limpiar()
        End Sub

        Private Sub frmConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()
            buscarTipos()
            Pan.Enabled = False
            cboNivelCalculo.SelectedIndex = 0
        End Sub

        Private Sub limpiar()

            txtCodigo.Text = ""
            txtCodigoSunat.Text = ""
            txtConcepto.Text = ""
            txtDescripcion.Text = ""
            chkEsCalculo.Checked = False
            chkEsCalculoHoras.Checked = False
            chkEsFijo.Checked = False
            chkEsJuridico.Checked = False
            chkEsPrestamo.Checked = False
            cboTipoConcepto.Enabled = True
            cboNivelCalculo.SelectedIndex = 0

        End Sub
       
    End Class
End Namespace


'<Dependency()> _
'Public Property BC As Ladisac.BL.IBCTipoParada
'<Dependency()> _
'Public Property HE As Ladisac.BL.IBCHerramientas

'Protected mTipoParada As TipoParada


'Private Sub frmTipoParada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

'End Sub

'Public Overrides Sub OnManBuscar()
'    Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscarTipoParada)()
'    If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
'        Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
'        CargarTipoParada(key)
'    End If
'    frm.Dispose()
'End Sub

'Sub CargarTipoParada(ByVal TPA_Id As Integer)
'    mTipoParada = BC.TipoParadaGetById(TPA_Id)
'    mTipoParada.MarkAsModified()
'    txtDescripcion.Text = mTipoParada.TPA_DESCRIPCION
'End Sub


'Public Overrides Sub OnManGuardar()
'    If mTipoParada IsNot Nothing Then
'        mTipoParada.TPA_DESCRIPCION = txtDescripcion.Text
'        mTipoParada.TPA_ESTADO = True
'        mTipoParada.TPA_FEC_GRAB = Now
'        mTipoParada.USU_ID = 1
'        BC.MantenimientoTipoParada(mTipoParada)
'    End If
'End Sub
'Public Overrides Sub OnManNuevo()
'    mTipoParada = New TipoParada
'    mTipoParada.MarkAsAdded()
'    mTipoParada.TPA_ID = HE.Get_Id("TipoParada")
'End Sub

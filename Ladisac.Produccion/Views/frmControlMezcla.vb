Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmControlMezcla
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCControlMezcla As Ladisac.BL.IBCControlMezcla
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCArticulo As Ladisac.BL.IBCArticulo
    <Dependency()> _
    Public Property BCControlPeso As Ladisac.BL.IBCControlPeso
    <Dependency()> _
    Public Property BCControlConteo As Ladisac.BL.IBCControlConteo
    <Dependency()> _
    Public Property BCControlCanchero As Ladisac.BL.IBCControlCanchero
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro

    Protected mCME As ControlMezcla
    Protected mCPE As ControlPeso

    'ingreso de codigo
    Private Sub frmControlMezcla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Dim mDt As DataTable = BCControlMezcla.MezclaxFecha()
        'For Each mRow As DataRow In mDt.Rows
        '    mCME = BCControlMezcla.ControlMezclaGetById(mRow("CME_ID"))
        '    mCME.MarkAsModified()
        '    BCControlMezcla.MantenimientoControlMezcla(mCME)
        'Next




        LimpiarControles()

        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.

        'txtProduccion.TabIndex = 0
        Call validacion_desactivacion(False, 1)


        txtCodigo.TabIndex = 3
        txtProduccion.TabIndex = 0
        dgvDetalle.TabIndex = 1
        dgvDetalle2.TabIndex = 2
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mCME = Nothing
        txtCodigo.Text = String.Empty
        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        dgvDetalle.Rows.Clear()
        dgvDetalle2.Rows.Clear()


        '------------------------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
            txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Sub CargarMateriaPrima()
        Dim query As String
        Dim ds As New DataSet
        Try
            query = Me.BCArticulo.ListaArticuloMateriaPrimaMezcla
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            For Each mItem In ds.Tables(0).Rows
                If mItem.Item(2).ToString.Contains("004") Then
                    mItem.Item(2) = "99_" & mItem.Item(1) & "Greda 7 Toldos"

                ElseIf mItem.Item(2).ToString.Contains("007") Then
                    mItem.Item(2) = "05_" & mItem.Item(1) & "Puzolana"

                ElseIf mItem.Item(2).ToString.Contains("008") Then
                    mItem.Item(2) = "03_" & mItem.Item(1) & "Tierra Vitor"

                ElseIf mItem.Item(2).ToString.Contains("010") Then
                    mItem.Item(2) = "07_" & mItem.Item(1) & "Tierra Yura"

                ElseIf mItem.Item(2).ToString.Contains("012") Then
                    mItem.Item(2) = "99_" & mItem.Item(1) & "Tierra Neya (Polob - Diam)"

                ElseIf mItem.Item(2).ToString.Contains("014") Then
                    mItem.Item(2) = "99_" & mItem.Item(1) & "Tierra Ampato (H)"

                ElseIf mItem.Item(2).ToString.Contains("016") Then
                    mItem.Item(2) = "10_" & mItem.Item(1) & "Tierra DIAT (Ch)"

                ElseIf mItem.Item(2).ToString.Contains("017") Then
                    mItem.Item(2) = "11_" & mItem.Item(1) & "Tierra Vitor (Pitay)"

                ElseIf mItem.Item(2).ToString.Contains("018") Then
                    mItem.Item(2) = "08_" & mItem.Item(1) & "Tierra Joyas"

                ElseIf mItem.Item(2).ToString.Contains("019") Then
                    mItem.Item(2) = "99_" & mItem.Item(1) & "Arcilla Caolita (Yura)"

                ElseIf mItem.Item(2).ToString.Contains("020") Then
                    mItem.Item(2) = "99_" & mItem.Item(1) & "Greda de 7 Toldos (M)"

                ElseIf mItem.Item(2).ToString.Contains("022") Then
                    mItem.Item(2) = "99_" & mItem.Item(1) & "Greda de Chilata (M)"

                ElseIf mItem.Item(2).ToString.Contains("024") Then
                    mItem.Item(2) = "02_" & mItem.Item(1) & "Rotura Cruda"

                ElseIf mItem.Item(2).ToString.Contains("025") Then
                    mItem.Item(2) = "01_" & mItem.Item(1) & "Rotura Cocida"

                ElseIf mItem.Item(2).ToString.Contains("026") Then
                    mItem.Item(2) = "12_" & mItem.Item(1) & "Blanca (Polobaya - Diamante)"

                ElseIf mItem.Item(2).ToString.Contains("029") Then
                    mItem.Item(2) = "09_" & mItem.Item(1) & "Tierra Cachios (Polobaya-Diamante) Chapi"

                ElseIf mItem.Item(2).ToString.Contains("032") Then
                    mItem.Item(2) = "06_" & mItem.Item(1) & "Gredilla"

                ElseIf mItem.Item(2).ToString.Contains("033") Then
                    mItem.Item(2) = "04_" & mItem.Item(1) & "Tierra Neya Condabaya"

                ElseIf mItem.Item(2).ToString.Contains("035") Then
                    mItem.Item(2) = "13_" & mItem.Item(1) & "Chara"
                ElseIf mItem.Item(2).ToString.Contains("Antra") Then
                    mItem.Item(2) = "14_" & mItem.Item(2)
                ElseIf mItem.Item(2).ToString.Contains("CISCO") Then
                    mItem.Item(2) = "15_" & mItem.Item(2)
                End If
                    
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ART_ID_MP").Value = mItem.Item(2)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ART_ID_MP").Tag = mItem.Item(0)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMR_M3").Value = 0
            Next
        Catch ex As Exception
            MessageBox.Show("No hay Materia Prima")
        End Try
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "ArticuloMateriaPrima"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value  'ART_Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ART_Id
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle2_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle2.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case dgvDetalle2.CurrentCell.ColumnIndex
            Case 1
                frm.Tabla = "CatsMezcla"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle2.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'CAT_Descripcion
                    dgvDetalle2.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'CAT_Id
                    dgvDetalle2.CurrentRow.Cells("CAT_VOL_PALA_M").Value = frm.dgvLista.CurrentRow.Cells(2).Value  'CAT_VOL_PALA
                End If
            Case 2
                frm.Tabla = "Persona"
                frm.Tipo = "Trabajador"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle2.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                    dgvDetalle2.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
                End If
                frm.Dispose()
            Case 8

                Dim Total = (From mGrid As DataGridViewRow In dgvDetalle2.Rows Select mGrid).Sum(Function(mgrid) CDec(mgrid.Cells("DMM_TOTAL_LADRILLO").Value))

                Dim mOtrosTotales As List(Of ControlMezcla)
                mOtrosTotales = BCControlMezcla.ControlMezclaGetByIdPRO(txtProduccion.Tag)
                For Each mCab In mOtrosTotales
                    If mCab.CME_ID <> mCME.CME_ID Then
                        For Each mDet In mCab.ControlMezclaMezclaDetalle
                            If mDet.DMM_TOTAL_LADRILLO IsNot Nothing Then Total = Total + mDet.DMM_TOTAL_LADRILLO
                        Next
                    End If
                Next

                Dim mConteo As ControlConteo
                mConteo = BCControlConteo.ControlConteoGetByIdPRO(txtProduccion.Tag)

                Dim mCCanchero As List(Of ControlCanchero)
                mCCanchero = BCControlCanchero.GetByPro_Id(txtProduccion.Tag)
                Dim TCanchero As Integer
                For Each mFila In mCCanchero
                    TCanchero = TCanchero + mFila.CCA_TOTAL
                Next

                If mConteo IsNot Nothing Then
                    MessageBox.Show("Total Producido : " & Math.Round(Total, 2) & Chr(13) & "Total Conteo + Rec.Canchero : " & mConteo.CCO_TOTAL_CONTEO + TCanchero & Chr(13) & "Diferencia : " & Total - (mConteo.CCO_TOTAL_CONTEO + TCanchero), "Verificar Cantidad Producida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("La Produccion no tiene Registro de Conteo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
        End Select
        frm.Dispose()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '---------------------------------------------
        Dim Flag As Boolean = False

        If mCME IsNot Nothing Then
            For Each mItem In mCME.ControlMezclaRecetaDetalle 'PARA QUE VUELVA A CONTAR
                mItem.DMR_M3 = 0
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dgvDetalle.EndEdit()
            mCME.PRO_ID = CInt(txtProduccion.Tag)
            mCME.CME_ESTADO = True
            mCME.CME_FEC_GRAB = Now
            mCME.USU_ID = SessionServer.UserId

            For Each mNroMezclaCat As DataGridViewRow In dgvDetalle2.Rows
                If Not mNroMezclaCat.Cells("DMM_ID").Value Is Nothing Then
                    With CType(mNroMezclaCat.Cells("DMM_ID").Tag, ControlMezclaMezclaDetalle)
                        .CAT_ID = CInt(mNroMezclaCat.Cells("CAT_ID_M").Tag)
                        .PER_ID_OPERADOR = mNroMezclaCat.Cells("PER_ID_OPERADOR").Tag
                        .DMM_CANTIDAD = CDbl(mNroMezclaCat.Cells("DMM_CANTIDAD").Value)
                        .DMM_HORA_INICIO = CDbl(mNroMezclaCat.Cells("DMM_HORA_INICIO").Value)
                        .DMM_HORA_FINAL = CDbl(mNroMezclaCat.Cells("DMM_HORA_FINAL").Value)
                        .CAT_VOL_PALA = CDbl(mNroMezclaCat.Cells("CAT_VOL_PALA_M").Value)
                        .DMM_TOTAL_LADRILLO = CInt(mNroMezclaCat.Cells("DMM_TOTAL_LADRILLO").Value)
                        .DMM_CANTIDAD_BRUTA = CDbl(mNroMezclaCat.Cells("DMM_CANTIDAD_BRUTA").Value)
                        .MarkAsModified()
                    End With
                    Flag = True
                ElseIf Not mNroMezclaCat.Cells("CAT_ID_M").Value Is Nothing Then
                    Dim nDMM As New ControlMezclaMezclaDetalle
                    With nDMM
                        .CAT_ID = CInt(mNroMezclaCat.Cells("CAT_ID_M").Tag)
                        .PER_ID_OPERADOR = mNroMezclaCat.Cells("PER_ID_OPERADOR").Tag
                        .DMM_CANTIDAD = CDbl(mNroMezclaCat.Cells("DMM_CANTIDAD").Value)
                        .DMM_HORA_INICIO = CDbl(mNroMezclaCat.Cells("DMM_HORA_INICIO").Value)
                        .DMM_HORA_FINAL = CDbl(mNroMezclaCat.Cells("DMM_HORA_FINAL").Value)
                        .CAT_VOL_PALA = CDbl(mNroMezclaCat.Cells("CAT_VOL_PALA_M").Value)
                        .DMM_TOTAL_LADRILLO = CInt(mNroMezclaCat.Cells("DMM_TOTAL_LADRILLO").Value)
                        .DMM_CANTIDAD_BRUTA = CDbl(mNroMezclaCat.Cells("DMM_CANTIDAD_BRUTA").Value)
                        .MarkAsAdded()
                    End With
                    mCME.ControlMezclaMezclaDetalle.Add(nDMM)
                    Flag = True
                End If

                If Flag = True Then
                    For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                        If Not mDetalle.Cells("DMR_ID").Value Is Nothing Then
                            With CType(mDetalle.Cells("DMR_ID").Tag, ControlMezclaRecetaDetalle)
                                .ART_ID_MP = mDetalle.Cells("ART_ID_MP").Tag
                                .DMR_CANTIDAD = CDbl(mDetalle.Cells("DMR_CANTIDAD").Value)
                                .CAT_ID = CInt(mNroMezclaCat.Cells("CAT_ID_M").Tag)
                                .CAT_VOL_PALA = CDbl(mNroMezclaCat.Cells("CAT_VOL_PALA_M").Value)
                                'If BCParametro.ParametroGetById("carbon").PAR_VALOR2.Contains("/" & .ART_ID_MP.ToString.Trim & "/") Then
                                '    Try
                                '        .DMR_M3 = .DMR_M3 + (.DMR_CANTIDAD * BCParametro.ParametroGetById("Vol." & .ART_ID_MP).PAR_VALOR1) * CDbl(mNroMezclaCat.Cells("DMM_CANTIDAD").Value)
                                '    Catch ex As Exception
                                '        MessageBox.Show("No hay parametro de conversión.") : Exit Sub
                                '    End Try

                                'Else
                                '    .DMR_M3 = .DMR_M3 + (.DMR_CANTIDAD * .CAT_VOL_PALA) * CDbl(mNroMezclaCat.Cells("DMM_CANTIDAD").Value)
                                'End If
                                .DMR_M3 = CDbl(mDetalle.Cells("DMR_M3").Value)
                                .DMR_M3_BRUTO = CDbl(mDetalle.Cells("DMR_M3_BRUTO").Value)
                                'If .DMR_CANTIDAD > 0 And .DMR_M3 <= 0 Then MessageBox.Show("El M3 da cero.") : Exit Sub
                                .MarkAsModified()
                            End With
                            Flag = False
                        ElseIf Not mDetalle.Cells("ART_ID_MP").Value Is Nothing Then
                            Dim nDMR As New ControlMezclaRecetaDetalle
                            nDMR.DMR_CANTIDAD = 0
                            nDMR.DMR_M3 = 0
                            With nDMR
                                .ART_ID_MP = mDetalle.Cells("ART_ID_MP").Tag
                                .DMR_CANTIDAD = CDbl(mDetalle.Cells("DMR_CANTIDAD").Value)
                                .CAT_ID = CInt(mNroMezclaCat.Cells("CAT_ID_M").Tag)
                                .CAT_VOL_PALA = CDbl(mNroMezclaCat.Cells("CAT_VOL_PALA_M").Value)
                                'If BCParametro.ParametroGetById("carbon").PAR_VALOR2.Contains("/" & .ART_ID_MP.ToString.Trim & "/") Then
                                '    Try
                                '        .DMR_M3 = .DMR_M3 + (.DMR_CANTIDAD * BCParametro.ParametroGetById("Vol." & .ART_ID_MP).PAR_VALOR1) * CDbl(mNroMezclaCat.Cells("DMM_CANTIDAD").Value)
                                '    Catch ex As Exception
                                '        MessageBox.Show("No hay parametro de conversión.") : Exit Sub
                                '    End Try

                                'Else
                                '    .DMR_M3 = .DMR_M3 + (.DMR_CANTIDAD * .CAT_VOL_PALA) * CDbl(mNroMezclaCat.Cells("DMM_CANTIDAD").Value)
                                'End If
                                .DMR_M3 = CDbl(mDetalle.Cells("DMR_M3").Value)
                                .DMR_M3_BRUTO = CDbl(mDetalle.Cells("DMR_M3_BRUTO").Value)
                                'If (.DMR_CANTIDAD > 0 And .DMR_M3 <= 0) OrElse .DMR_M3 Is Nothing Then MessageBox.Show("El M3 da cero.") : Exit Sub
                                .MarkAsAdded()
                            End With
                            mCME.ControlMezclaRecetaDetalle.Add(nDMR)
                            Flag = False
                        End If
                    Next
                End If

            Next

            BCControlMezcla.MantenimientoControlMezcla(mCME)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mCME = New ControlMezcla
        mCME.MarkAsAdded()
        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtProduccion.Focus()
        CargarMateriaPrima()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ControlMezcla"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarControlMezcla(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarControlMezcla(ByVal CME_Id As Integer)
        mCME = BCControlMezcla.ControlMezclaGetById(CME_Id)
        mCME.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mCME.CME_ID
        txtProduccion.Text = mCME.Produccion.PRO_ID & " " & mCME.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
        txtProduccion.Tag = mCME.Produccion.PRO_ID

        For Each mItem In mCME.ControlMezclaRecetaDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMR_ID").Value = mItem.DMR_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMR_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ART_ID_MP").Value = mItem.Articulos.ART_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ART_ID_MP").Tag = mItem.ART_ID_MP
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMR_CANTIDAD").Value = mItem.DMR_CANTIDAD
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAT_ID").Value = mItem.CAT_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAT_VOL_PALA").Value = mItem.CAT_VOL_PALA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMR_M3").Value = mItem.DMR_M3
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMR_M3_BRUTO").Value = mItem.DMR_M3_BRUTO
        Next

        For Each mItem In mCME.ControlMezclaMezclaDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle2.Rows.Add(nRow)
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DMM_ID").Value = mItem.DMM_ID
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DMM_ID").Tag = mItem
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CAT_ID_M").Value = mItem.Cats.CAT_DESCRIPCION
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CAT_ID_M").Tag = mItem.CAT_ID
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("PER_ID_OPERADOR").Value = mItem.Personas.PER_APE_PAT & " " & mItem.Personas.PER_APE_MAT & " " & mItem.Personas.PER_NOMBRES
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("PER_ID_OPERADOR").Tag = mItem.PER_ID_OPERADOR
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DMM_CANTIDAD").Value = mItem.DMM_CANTIDAD
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DMM_CANTIDAD_BRUTA").Value = mItem.DMM_CANTIDAD_BRUTA
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DMM_HORA_INICIO").Value = mItem.DMM_HORA_INICIO
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DMM_HORA_FINAL").Value = mItem.DMM_HORA_FINAL
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CAT_VOL_PALA_M").Value = mItem.CAT_VOL_PALA
            dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DMM_TOTAL_LADRILLO").Value = mItem.DMM_TOTAL_LADRILLO
        Next

    End Sub




    '===================================================================================================================
    '----procedimiento de validaciones

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtProduccion.Text.Trim) = 0 Then Error_validacion.SetError(txtProduccion, "Ingrese datos de Produccion") : txtProduccion.Focus() : flag = False

        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows

        Next

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'codigos agregados===================================================
    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub
    Public Overrides Sub OnManEditar()
        Call validacion_desactivacion(True, 6)
    End Sub
    Public Overrides Sub OnManCancelarEdicion()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub
    Public Overrides Sub OnManEliminar()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub
    Public Overrides Sub OnManSalir()
        Me.Dispose()
    End Sub

    'valida controles desactivacion
    Sub validacion_desactivacion(ByVal op As Boolean, ByVal flag As Integer)
        'datos a tener en cuenta
        '1=load
        '2=nuevo
        '3=guardar
        '4=DeshacerCambios
        '5=buscar
        '6=editar
        '7=deshacer,eliminar

        If flag = 1 Or flag = 3 Or flag = 4 Or flag = 7 Then

            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbBuscar.Enabled = Not op
            Me.tsbSalir.Enabled = Not op
            Me.tscPosicion.Enabled = Not op
            Me.tsbReportes.Enabled = Not op


        ElseIf flag = 2 Or flag = 6 Then 'evento nuevo registro
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = Not op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbGrabar.Enabled = op
            Me.TsbGrabarNuevo.Enabled = op
            Me.tsbDeshacer.Enabled = op
            Me.tsbAgregar.Enabled = op
            Me.tsbQuitar.Enabled = op


        ElseIf flag = 5 Then 'evento buscar/editar
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbEditar.Enabled = Not op
            Me.tsbCancelarEditar.Enabled = Not op
            Me.tsbReportes.Enabled = Not op

        End If
    End Sub

    Private Sub txtProduccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduccion.KeyDown
        If e.KeyCode = Keys.Enter Then txtProduccion_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle2.CellEndEdit
        If dgvDetalle2.Columns(e.ColumnIndex).Name = "DMM_CANTIDAD" Or dgvDetalle2.Columns(e.ColumnIndex).Name = "DMM_CANTIDAD_BRUTA" Then

            Dim TotalLampadas = (From mGrid As DataGridViewRow In dgvDetalle.Rows Select mGrid).Sum(Function(mgrid) CDec(mgrid.Cells("DMR_CANTIDAD").Value))
            Dim TotalBaldes, TotalBaldesTN As Decimal

            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.IsNewRow Then
                    If BCParametro.ParametroGetById("carbon").PAR_VALOR2.Contains("/" & mDetalle.Cells("ART_ID_MP").Tag.ToString.Trim & "/") Then
                        TotalBaldes = TotalBaldes + mDetalle.Cells("DMR_CANTIDAD").Value
                        TotalBaldesTN = TotalBaldesTN + mDetalle.Cells("DMR_CANTIDAD").Value * BCParametro.ParametroGetById("Vol." & mDetalle.Cells("ART_ID_MP").Tag.ToString.Trim).PAR_VALOR1
                    End If
                End If
            Next


            TotalLampadas = Math.Abs(TotalLampadas - TotalBaldes)
            Dim Tonelaje As Double = (TotalLampadas * dgvDetalle2.CurrentRow.Cells("CAT_VOL_PALA_M").Value) * 1.05 'Se cambio a 1.05 cuando era 1.1 por Paul con informe 2/10/12
            Tonelaje = Tonelaje + (Tonelaje * 0.1)

            Dim TotalPeso As Double = (Tonelaje + TotalBaldesTN) * 1000
            ''''''''''''
            mCPE = BCControlPeso.ControlPesoGetByIdPRO(txtProduccion.Tag)
            Dim PesoLadrillo = (From mItem In mCPE.ControlPesoDetalle Where mItem.DPE_TIPO = "HU" Select mItem.DPE_PESO).Average
            '''''''''''
            Dim CantLadrillos As Double
            If PesoLadrillo > 0 Then
                CantLadrillos = TotalPeso / PesoLadrillo
                CantLadrillos = CantLadrillos * dgvDetalle2.CurrentCell.Value


                If dgvDetalle2.Columns(e.ColumnIndex).Name = "DMM_CANTIDAD" Then
                    'Obtener los M3 al momento de ingresar las mezclas
                    For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                        mDetalle.Cells("DMR_M3").Value = 0
                        If mDetalle.Cells("ART_ID_MP").Value IsNot Nothing Then
                            If BCParametro.ParametroGetById("carbon").PAR_VALOR2.Contains("/" & mDetalle.Cells("ART_ID_MP").Tag.ToString.Trim & "/") Then
                                Try
                                    mDetalle.Cells("DMR_M3").Value = mDetalle.Cells("DMR_M3").Value + (mDetalle.Cells("DMR_CANTIDAD").Value * BCParametro.ParametroGetById("Vol." & mDetalle.Cells("ART_ID_MP").Tag.ToString.Trim).PAR_VALOR1) * CDbl(dgvDetalle2.CurrentCell.Value)
                                Catch ex As Exception
                                    MessageBox.Show("No hay parametro de conversión.") : Exit Sub
                                End Try
                            Else
                                mDetalle.Cells("DMR_M3").Value = mDetalle.Cells("DMR_M3").Value + (mDetalle.Cells("DMR_CANTIDAD").Value * dgvDetalle2.CurrentRow.Cells("CAT_VOL_PALA_M").Value) * CDbl(dgvDetalle2.CurrentCell.Value)
                            End If
                        End If
                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf dgvDetalle2.Columns(e.ColumnIndex).Name = "DMM_CANTIDAD_BRUTA" Then
                    'Obtener los M3 al momento de ingresar las mezclas
                    For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                        mDetalle.Cells("DMR_M3_BRUTO").Value = 0
                        If mDetalle.Cells("ART_ID_MP").Value IsNot Nothing Then
                            If BCParametro.ParametroGetById("carbon").PAR_VALOR2.Contains("/" & mDetalle.Cells("ART_ID_MP").Tag.ToString.Trim & "/") Then
                                Try
                                    mDetalle.Cells("DMR_M3_BRUTO").Value = mDetalle.Cells("DMR_M3_BRUTO").Value + (mDetalle.Cells("DMR_CANTIDAD").Value * BCParametro.ParametroGetById("Vol." & mDetalle.Cells("ART_ID_MP").Tag.ToString.Trim).PAR_VALOR1) * CDbl(dgvDetalle2.CurrentCell.Value)
                                Catch ex As Exception
                                    MessageBox.Show("No hay parametro de conversión.") : Exit Sub
                                End Try
                            Else
                                mDetalle.Cells("DMR_M3_BRUTO").Value = mDetalle.Cells("DMR_M3_BRUTO").Value + (mDetalle.Cells("DMR_CANTIDAD").Value * dgvDetalle2.CurrentRow.Cells("CAT_VOL_PALA_M").Value) * CDbl(dgvDetalle2.CurrentCell.Value)
                            End If
                        End If
                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If

            Else
                MessageBox.Show("No tiene peso la produccion.")
            End If
            dgvDetalle2.CurrentRow.Cells("DMM_TOTAL_LADRILLO").Value = Math.Round(CantLadrillos, 2)
        End If
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("DMR_ID").Value Is Nothing Then
            CType(e.Row.Cells("DMR_ID").Tag, ControlMezclaRecetaDetalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvDetalle2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle2_CellDoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub dgvDetalle2_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle2.UserDeletingRow
        If Not e.Row.Cells("DMM_ID").Value Is Nothing Then
            CType(e.Row.Cells("DMM_ID").Tag, ControlMezclaMezclaDetalle).MarkAsDeleted()
        End If
    End Sub
End Class


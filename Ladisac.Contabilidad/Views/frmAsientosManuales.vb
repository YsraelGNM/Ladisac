Imports System.Data.OleDb
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views

    Public Class frmAsientosManuales
        <Dependency()> _
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCAsientosManuales As Ladisac.BL.IBCAsientosManuales
        <Dependency()> _
        Public Property BCDetalleAsientosManuales As Ladisac.BL.IBCDetalleAsientosManuales
        Protected oAsientosManuales As New BE.AsientosManuales
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtPeriodo.Text.Trim = "") Then
                ErrorProvider1.SetError(txtPeriodo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtPeriodo, Nothing)
            End If

            If (txtLibro.Text.Trim = "") Then
                ErrorProvider1.SetError(txtLibro, "Libro")
                result = False
            Else
                ErrorProvider1.SetError(txtLibro, Nothing)
            End If

            If (dgvDetalle.Rows.Count <= 0) Then
                ErrorProvider1.SetError(dgvDetalle, "Detalle")
                result = False
            Else
                ErrorProvider1.SetError(dgvDetalle, Nothing)
            End If

            If Not (IsNumeric(txtCArgo.Text)) Then
                ErrorProvider1.SetError(txtCArgo, "No cuadran los valores (Cargo Abono)")
                result = False
            ElseIf Not (IsNumeric(txtAbono.Text)) Then
                ErrorProvider1.SetError(txtCArgo, "No cuadran los valores (Cargo Abono)")
                result = False
            ElseIf Val(txtCArgo.Text) <> Val(txtAbono.Text) Then
                ErrorProvider1.SetError(txtCArgo, "No cuadran los valores (Cargo Abono)")
                result = False
            ElseIf Val(txtCArgo.Text) <= 0 Then
                ErrorProvider1.SetError(txtCArgo, "No cuadran los valores (Cargo Abono)")
                result = False
            Else
                ErrorProvider1.SetError(txtCArgo, Nothing)
            End If
            Return result
        End Function
        Private Sub limpiar()
            txtPeriodo.Text = ""
            txtNumero.Text = ""
            txtGlosa.Text = ""
            txtLibro.Text = ""
            dgvDetalle.Rows.Clear()

        End Sub

        Sub sumar()
            Dim x As Integer = 0
            Dim dCargo, dAbono As Double
            Try
                While (dgvDetalle.Rows.Count > x)

                    dCargo += Val(dgvDetalle.Rows(x).Cells("CargoMN").Value) + Val(dgvDetalle.Rows(x).Cells("CargoME").Value)
                    dAbono += Val(dgvDetalle.Rows(x).Cells("AbonoMN").Value) + Val(dgvDetalle.Rows(x).Cells("AbonoME").Value)
                    x += 1
                End While
                txtCArgo.Text = dCargo.ToString
                txtAbono.Text = dAbono.ToString
                txtResta.Text = (dCargo - dAbono)
                If IsNumeric(txtResta.Text) Then txtResta.Text = Format(CDbl(txtResta.Text), "##,###.#0")
            Catch ex As Exception

                txtCArgo.Text = "0.00"
                txtAbono.Text = "0.00"
                txtResta.Text = "0.00"

            End Try
        End Sub

        Sub cargar(ByVal libro As String, ByVal periodo As String, ByVal numero As String)
            limpiar()
            oAsientosManuales = BCAsientosManuales.AsientosManualesSeek(libro, periodo, numero)
            oAsientosManuales.MarkAsModified()

            txtPeriodo.Text = oAsientosManuales.prd_Periodo_id
            txtNumero.Text = oAsientosManuales.asm_NumeroVoucher
            dateFecha.Value = oAsientosManuales.asm_Fecha
            txtGlosa.Text = oAsientosManuales.asm_Glosa
            txtLibro.Text = oAsientosManuales.LibrosContables.lib_Descripcion
            txtLibro.Tag = oAsientosManuales.lib_Id

            For Each mItem In oAsientosManuales.DetalleAsientosManuales

                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)

                If Not (IsDBNull(mItem.cuc_Id) OrElse mItem.cuc_Id Is Nothing OrElse mItem.cuc_Id = "") Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cuc_Id").Tag = mItem.cuc_Id
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cuc_Id").Value = mItem.cuc_Id
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DescripcionCuenta").Value = mItem.CuentasContables.CUC_DESCRIPCION

                End If

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CargoMN").Value = mItem.dam_ImporteCargoMN
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("AbonoMN").Value = mItem.dam_ImporteAbonoMN

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CargoME").Value = mItem.dam_ImporteCargoME
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("AbonoME").Value = mItem.dam_ImporteAbonoME

                Try
                    If (Not IsDBNull(mItem.mon_Id) OrElse mItem.mon_Id <> "") Then
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Tag = mItem.mon_Id
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Moneda").Value = mItem.Moneda.MON_DESCRIPCION
                    Else
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Tag = Nothing
                    End If
                Catch ex As Exception
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Tag = Nothing
                End Try


                Try
                    If (Not IsDBNull(mItem.cco_Id) OrElse mItem.cco_Id <> "") Then
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cco_Id").Tag = mItem.cco_Id
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CentroCosto").Value = mItem.CentroCostos.CCO_DESCRIPCION
                    Else
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cco_Id").Tag = Nothing
                    End If
                Catch ex As Exception

                End Try


                Try
                    If (Not IsDBNull(mItem.per_Id) OrElse mItem.per_Id <> "") Then
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = mItem.per_Id
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = IIf(IsNothing(mItem.Personas.PER_APE_PAT), "", mItem.Personas.PER_APE_PAT) & " " & _
                      IIf(IsNothing(mItem.Personas.PER_APE_MAT), "", mItem.Personas.PER_APE_MAT) & " " & _
                      IIf(IsNothing(mItem.Personas.PER_NOMBRES), "", mItem.Personas.PER_NOMBRES)

                    Else
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = ""
                    End If
                Catch ex As Exception
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = ""
                End Try


                Try
                    If (Not IsDBNull(mItem.cct_Id) OrElse mItem.cct_Id <> "") Then
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cls_Id").Tag = mItem.cls_Id
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cct_Id").Tag = mItem.cct_Id
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CuentaCorriente").Value = mItem.CuentasContables.CUC_DESCRIPCION
                    Else
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cls_Id").Tag = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cct_Id").Tag = Nothing
                    End If
                Catch ex As Exception
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cls_Id").Tag = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cct_Id").Tag = Nothing
                End Try

                Try
                    If (Not IsNumeric(mItem.dtd_IdDoc) OrElse mItem.dtd_IdDoc <> "") Then
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_Id").Tag = mItem.tdo_IdDoc
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_Id").Tag = mItem.dtd_IdDoc

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoDocumento").Value = mItem.DetalleTipoDocumentos1.DTD_DESCRIPCION
                    Else
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_Id").Tag = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_Id").Tag = Nothing
                    End If
                Catch ex As Exception
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_Id").Tag = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_Id").Tag = Nothing
                End Try


                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Serie").Value = mItem.dam_SerieDoc
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = mItem.dam_NumeroDoc
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = mItem.dam_ItemDoc

                Try
                    If (Not IsNumeric(mItem.dtd_IdRef) OrElse mItem.dtd_IdRef <> "") Then
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Tag = mItem.tdo_IdRef
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_IdRef").Tag = mItem.dtd_IdRef

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoDocumentoRef").Value = mItem.DetalleTipoDocumentos.DTD_DESCRIPCION
                    Else
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Tag = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_IdRef").Tag = Nothing
                    End If

                Catch ex As Exception
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Tag = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_IdRef").Tag = Nothing
                End Try
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SerieRef").Value = mItem.dam_SerieRef
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("NumeroRef").Value = mItem.dam_NumeroRef
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ItemRef").Value = mItem.dam_ItemRef


                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dam_Item").Value = mItem.dam_Item
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dam_Item").Tag = mItem

            Next
            sumar()
        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()

            Dim iRow As Integer = 0

            If (dgvDetalle.SelectedRows.Count > 0) Then
                dgvDetalle.Rows.Add()

            Else
                dgvDetalle.Rows.Add()

                iRow = dgvDetalle.RowCount - 1

                dgvDetalle.Rows(iRow).Cells("CargoMN").Value = "0.00"
                dgvDetalle.Rows(iRow).Cells("AbonoMN").Value = "0.00"
                dgvDetalle.Rows(iRow).Cells("CargoME").Value = "0.00"
                dgvDetalle.Rows(iRow).Cells("AbonoME").Value = "0.00"


            End If
        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()
            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    If Not mDetalle.Cells("dam_Item").Value Is Nothing Then
                        With CType(mDetalle.Cells("dam_Item").Tag, BE.DetalleAsientosManuales)
                            .MarkAsDeleted()
                            .lib_Id = txtLibro.Tag
                            .prd_Periodo_id = txtPeriodo.Text
                            .asm_NumeroVoucher = txtNumero.Text
                            .cuc_Id = mDetalle.Cells("cuc_Id").Tag
                            .dam_ImporteCargoMN = CDec(mDetalle.Cells("CargoMN").Value)
                            .dam_ImporteAbonoMN = CDec(mDetalle.Cells("AbonoMN").Value)
                            .dam_ImporteCargoME = CDec(mDetalle.Cells("CargoME").Value)
                            .dam_ImporteAbonoME = CDec(mDetalle.Cells("AbonoME").Value)

                            .mon_Id = mDetalle.Cells("mon_Id").Tag
                            .cco_Id = mDetalle.Cells("cco_Id").Tag

                            .cct_Id = mDetalle.Cells("cct_Id").Tag
                            .tdo_IdDoc = mDetalle.Cells("tdo_Id").Tag
                            .dtd_IdDoc = mDetalle.Cells("dtd_Id").Tag
                            .dam_SerieDoc = mDetalle.Cells("Serie").Value
                            .dam_NumeroDoc = mDetalle.Cells("Numero").Value
                            .dam_ItemDoc = mDetalle.Cells("Item").Value()
                            .per_Id = mDetalle.Cells("per_Id").Tag
                            .dam_Glosa = txtGlosa.Text

                            .cls_Id = mDetalle.Cells("cls_Id").Tag

                            .Usu_Id = SessionService.UserId
                            .dam_FECGRAB = Now
                            .dam_Item = mDetalle.Cells("dam_Item").Value()

                            .tdo_IdRef = mDetalle.Cells("tdo_IdRef").Tag
                            .dtd_IdRef = mDetalle.Cells("dtd_IdRef").Tag
                            .dam_SerieRef = mDetalle.Cells("SerieRef").Value
                            .dam_NumeroRef = mDetalle.Cells("NumeroRef").Value
                            .dam_ItemRef = mDetalle.Cells("ItemRef").Value()


                        End With

                    End If
                    dgvDetalle.Rows.Remove(mDetalle)
                    sumar()
                Next

            Else
                MsgBox("Seleccione un registro")
            End If
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarPeriodoNumero)()
            frm.inicio(Constants.BuscadoresNames.AsientosManuales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value, frm.dgbRegistro.CurrentRow.Cells(2).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub
        Public Overrides Sub OnManGuardar()

            If (txtNumero.Text.Trim = "") Then
                oAsientosManuales = New BE.AsientosManuales
                oAsientosManuales.MarkAsAdded()

            End If

            If (validar() AndAlso validarCeldas()) Then
                Try
                    If oAsientosManuales IsNot Nothing Then
                        dgvDetalle.EndEdit()

                        oAsientosManuales.Periodo = Nothing
                        oAsientosManuales.LibrosContables = Nothing
                        oAsientosManuales.asm_Fecha = dateFecha.Value

                        oAsientosManuales.prd_Periodo_id = txtPeriodo.Text
                        oAsientosManuales.lib_Id = txtLibro.Tag

                        oAsientosManuales.asm_NumeroVoucher = txtNumero.Text

                        oAsientosManuales.Usu_Id = SessionService.UserId
                        oAsientosManuales.asm_FECGRAB = Now
                        oAsientosManuales.asm_Glosa = txtGlosa.Text
                        'Rompiendo relaciones 

                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows

                            If Not mDetalle.Cells("dam_Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("dam_Item").Tag, BE.DetalleAsientosManuales)

                                    .Personas = Nothing
                                    .CuentasContables = Nothing
                                    .Moneda = Nothing
                                    .CentroCostos = Nothing
                                    .ClaseCuenta = Nothing
                                    '.RolOpeCtaCte = Nothing
                                    .Usuarios = Nothing

                                    .lib_Id = txtLibro.Tag
                                    .prd_Periodo_id = txtPeriodo.Text
                                    .asm_NumeroVoucher = txtNumero.Text
                                    If (IsDBNull(mDetalle.Cells("cuc_Id").Tag)) Then
                                        .cuc_Id = Nothing
                                    Else
                                        .cuc_Id = mDetalle.Cells("cuc_Id").Tag
                                    End If

                                    .dam_ImporteCargoMN = CDec(mDetalle.Cells("CargoMN").Value)
                                    .dam_ImporteAbonoMN = CDec(mDetalle.Cells("AbonoMN").Value)
                                    .dam_ImporteCargoME = CDec(mDetalle.Cells("CargoME").Value)
                                    .dam_ImporteAbonoME = CDec(mDetalle.Cells("AbonoME").Value)

                                    If (IsDBNull(mDetalle.Cells("mon_Id").Tag)) Then

                                        .mon_Id = Nothing
                                    Else
                                        .mon_Id = mDetalle.Cells("mon_Id").Tag
                                    End If

                                    If (IsDBNull(mDetalle.Cells("cco_Id").Tag)) Then
                                        .cco_Id = Nothing
                                    Else
                                        .cco_Id = mDetalle.Cells("cco_Id").Tag
                                    End If

                                    If (IsDBNull(mDetalle.Cells("cct_Id").Tag)) Then
                                        .cct_Id = Nothing
                                    Else
                                        .cct_Id = mDetalle.Cells("cct_Id").Tag

                                    End If

                                    If (IsDBNull(mDetalle.Cells("tdo_Id").Tag)) Then
                                        .tdo_IdDoc = Nothing
                                    Else
                                        .tdo_IdDoc = mDetalle.Cells("tdo_Id").Tag
                                    End If

                                    If (IsDBNull(mDetalle.Cells("dtd_Id").Tag)) Then

                                        .dtd_IdDoc = Nothing
                                    Else
                                        .dtd_IdDoc = mDetalle.Cells("dtd_Id").Tag
                                    End If

                                    .dam_SerieDoc = mDetalle.Cells("Serie").Value
                                    .dam_NumeroDoc = mDetalle.Cells("Numero").Value
                                    .dam_ItemDoc = mDetalle.Cells("Item").Value()
                                    .per_Id = mDetalle.Cells("per_Id").Tag
                                    .dam_Glosa = txtGlosa.Text

                                    If (IsDBNull(mDetalle.Cells("cls_Id").Tag)) Then
                                        .cls_Id = Nothing
                                    Else
                                        .cls_Id = mDetalle.Cells("cls_Id").Tag
                                    End If


                                    .Usu_Id = SessionService.UserId
                                    .dam_FECGRAB = Now
                                    .dam_Item = mDetalle.Cells("dam_Item").Value()

                                    If (IsDBNull(mDetalle.Cells("tdo_IdRef").Tag)) Then
                                        .tdo_IdRef = Nothing
                                    Else
                                        .tdo_IdRef = mDetalle.Cells("tdo_IdRef").Tag

                                    End If

                                    If (IsDBNull(mDetalle.Cells("dtd_IdRef").Tag)) Then
                                        .dtd_IdRef = Nothing
                                    Else
                                        .dtd_IdRef = mDetalle.Cells("dtd_IdRef").Tag
                                    End If

                                    .dam_SerieRef = mDetalle.Cells("SerieRef").Value
                                    .dam_NumeroRef = mDetalle.Cells("NumeroRef").Value
                                    .dam_ItemRef = mDetalle.Cells("ItemRef").Value()

                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetalleAsientosManuales
                                With nOSD

                                    .Personas = Nothing
                                    .CuentasContables = Nothing
                                    .Moneda = Nothing
                                    .CentroCostos = Nothing
                                    .ClaseCuenta = Nothing
                                    '.RolOpeCtaCte = Nothing
                                    .Usuarios = Nothing

                                    .lib_Id = txtLibro.Tag
                                    .prd_Periodo_id = txtPeriodo.Text
                                    .asm_NumeroVoucher = txtNumero.Text
                                    If (IsDBNull(mDetalle.Cells("cuc_Id").Tag)) Then
                                        .cuc_Id = Nothing
                                    Else
                                        .cuc_Id = mDetalle.Cells("cuc_Id").Tag
                                    End If

                                    .dam_ImporteCargoMN = CDec(mDetalle.Cells("CargoMN").Value)
                                    .dam_ImporteAbonoMN = CDec(mDetalle.Cells("AbonoMN").Value)
                                    .dam_ImporteCargoME = CDec(mDetalle.Cells("CargoME").Value)
                                    .dam_ImporteAbonoME = CDec(mDetalle.Cells("AbonoME").Value)

                                    If (IsDBNull(mDetalle.Cells("mon_Id").Tag)) Then

                                        .mon_Id = Nothing
                                    Else
                                        .mon_Id = mDetalle.Cells("mon_Id").Tag
                                    End If

                                    If (IsDBNull(mDetalle.Cells("cco_Id").Tag)) Then
                                        .cco_Id = Nothing
                                    Else
                                        .cco_Id = mDetalle.Cells("cco_Id").Tag
                                    End If

                                    If (IsDBNull(mDetalle.Cells("cct_Id").Tag)) Then
                                        .cct_Id = Nothing
                                    Else
                                        .cct_Id = mDetalle.Cells("cct_Id").Tag

                                    End If

                                    If (IsDBNull(mDetalle.Cells("tdo_Id").Tag)) Then
                                        .tdo_IdDoc = Nothing
                                    Else
                                        .tdo_IdDoc = mDetalle.Cells("tdo_Id").Tag
                                    End If

                                    If (IsDBNull(mDetalle.Cells("dtd_Id").Tag)) Then

                                        .dtd_IdDoc = Nothing
                                    Else
                                        .dtd_IdDoc = mDetalle.Cells("dtd_Id").Tag
                                    End If

                                    .dam_SerieDoc = mDetalle.Cells("Serie").Value
                                    .dam_NumeroDoc = mDetalle.Cells("Numero").Value
                                    .dam_ItemDoc = mDetalle.Cells("Item").Value()
                                    .per_Id = mDetalle.Cells("per_Id").Tag
                                    .dam_Glosa = txtGlosa.Text

                                    If (IsDBNull(mDetalle.Cells("cls_Id").Tag)) Then
                                        .cls_Id = Nothing
                                    Else
                                        .cls_Id = mDetalle.Cells("cls_Id").Tag
                                    End If


                                    .Usu_Id = SessionService.UserId
                                    .dam_FECGRAB = Now
                                    .dam_Item = mDetalle.Cells("dam_Item").Value()

                                    If (IsDBNull(mDetalle.Cells("tdo_IdRef").Tag)) Then
                                        .tdo_IdRef = Nothing
                                    Else
                                        .tdo_IdRef = mDetalle.Cells("tdo_IdRef").Tag

                                    End If

                                    If (IsDBNull(mDetalle.Cells("dtd_IdRef").Tag)) Then
                                        .dtd_IdRef = Nothing
                                    Else
                                        .dtd_IdRef = mDetalle.Cells("dtd_IdRef").Tag
                                    End If

                                    .dam_SerieRef = mDetalle.Cells("SerieRef").Value
                                    .dam_NumeroRef = mDetalle.Cells("NumeroRef").Value
                                    .dam_ItemRef = mDetalle.Cells("ItemRef").Value()
                                    .MarkAsAdded()

                                End With
                                oAsientosManuales.DetalleAsientosManuales.Add(nOSD)
                            End If
                        Next

                        Try
                            BCAsientosManuales.Maintenance(oAsientosManuales)
                            MsgBox("Datos Guardados")
                            menuInicio()
                            Panel1.Enabled = False
                            limpiar()
                            DeshabilitarElementoGrid()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If

        End Sub

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oAsientosManuales = New BE.AsientosManuales
            oAsientosManuales.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()

                oAsientosManuales.prd_Periodo_id = txtPeriodo.Text
                oAsientosManuales.lib_Id = txtLibro.Tag
                oAsientosManuales.asm_NumeroVoucher = txtNumero.Text

                If ((MsgBox("Esta Seguro de Relizar los cambio", vbYesNo) = MsgBoxResult.Yes)) Then
                    If (BCAsientosManuales.MaintenanceDelete(oAsientosManuales)) Then
                        MsgBox("Cambios Realizados")
                        limpiar()
                    Else
                        MsgBox("No se pudo realizar los cambios ", vbExclamation)
                    End If
                End If

        End Sub
        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManEditar()
            menuEditar()
            Panel1.Enabled = True
            HabilitarElementoGrid()
        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub



        Private Sub frmAsientosManuales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()
            Panel1.Enabled = False
        End Sub
        Private Sub dgvDetalle_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
            Try
                Select Case dgvDetalle.Columns(e.ColumnIndex).Name
                    Case "per_Id"
                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                        frm.inicio(Constants.BuscadoresNames.BuscarPersona)
                        If (frm.ShowDialog = DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow

                                dgvDetalle.Rows(e.RowIndex).Cells("Persona").Value = .Cells(1).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("per_Id").Tag = .Cells(0).Value
                            End With
                        End If
                        frm.Dispose()


                    Case "cuc_Id"

                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                        frm.inicio(Constants.BuscadoresNames.CuentasContables)

                        If (frm.ShowDialog = DialogResult.OK) Then
                            dgvDetalle.Rows(e.RowIndex).Cells("cuc_id").Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("cuc_id").Value = frm.dgbRegistro.CurrentRow.Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("DescripcionCuenta").Value = frm.dgbRegistro.CurrentRow.Cells(1).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("cls_Id").Tag = frm.dgbRegistro.CurrentRow.Cells(5).Value
                        End If
                        frm.Dispose()

                    Case "mon_Id"

                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                        frm.inicio(Constants.BuscadoresNames.Moneda)
                        If (frm.ShowDialog = DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow
                                dgvDetalle.Rows(e.RowIndex).Cells("mon_Id").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("Moneda").Value = .Cells(1).Value

                            End With
                        End If
                        frm.Dispose()

                    Case "cco_Id"
                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto)
                        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow
                                dgvDetalle.Rows(e.RowIndex).Cells("cco_Id").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("CentroCosto").Value = .Cells(1).Value
                            End With
                        End If
                        frm.Dispose()

                    Case "cct_Id"

                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CtaCte)
                        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow
                                dgvDetalle.Rows(e.RowIndex).Cells("cct_Id").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("CuentaCorriente").Value = .Cells(1).Value
                            End With
                        End If
                        frm.Dispose()
                    Case "tdo_Id"

                        If (dgvDetalle.Rows(e.RowIndex).Cells("cct_Id").Tag <> "") Then

                            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.RolOpeCtaCte)
                            frm.campo1 = dgvDetalle.Rows(e.RowIndex).Cells("cct_Id").Tag

                            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                                With frm.dgbRegistro.CurrentRow
                                    dgvDetalle.Rows(e.RowIndex).Cells("tdo_Id").Tag = .Cells(2).Value
                                    dgvDetalle.Rows(e.RowIndex).Cells("dtd_Id").Tag = .Cells(4).Value
                                    dgvDetalle.Rows(e.RowIndex).Cells("TipoDocumento").Value = .Cells(5).Value
                                End With
                            End If
                            frm.Dispose()
                        Else
                            MessageBox.Show("Debe Ingresar antes la Cuenta Corriente")
                        End If
                    Case "tdo_IdRef"

                        If (dgvDetalle.Rows(e.RowIndex).Cells("cct_Id").Tag <> "") Then

                            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.RolOpeCtaCte)
                            frm.campo1 = dgvDetalle.Rows(e.RowIndex).Cells("cct_Id").Tag

                            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                                With frm.dgbRegistro.CurrentRow
                                    dgvDetalle.Rows(e.RowIndex).Cells("tdo_IdRef").Tag = .Cells(2).Value
                                    dgvDetalle.Rows(e.RowIndex).Cells("dtd_IdRef").Tag = .Cells(4).Value
                                    dgvDetalle.Rows(e.RowIndex).Cells("TipoDocumentoRef").Value = .Cells(5).Value
                                End With
                            End If
                            frm.Dispose()
                        Else
                            MessageBox.Show("Debe Ingresar antes la Cuenta Corriente")
                        End If

                End Select
            Catch ex As Exception

            End Try

        End Sub
        Function validarCeldas() As Boolean

            Dim result As Boolean = True
            Dim iRow As Integer = 0

            While (dgvDetalle.Rows.Count > iRow)

                If (IsNothing(dgvDetalle.Rows(iRow).Cells("cuc_Id").Tag) OrElse dgvDetalle.Rows(iRow).Cells("cuc_Id").Tag = "") Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Cuenta contable")
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If (Not IsNumeric(dgvDetalle.Rows(iRow).Cells("CargoMN").Value)) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Cargo valor numerico")

                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If Not IsNumeric(dgvDetalle.Rows(iRow).Cells("AbonoMN").Value) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Abono valor numerico")
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If dgvDetalle.Rows(iRow).Cells("CargoMN").Value <> 0 And
                   dgvDetalle.Rows(iRow).Cells("AbonoMN").Value <> 0 Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Cargo y Abono no pueden tener montos al mismo tiempo")
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If


                If (dgvDetalle.Rows(iRow).Cells("Item").Value <> "" AndAlso dgvDetalle.Rows(iRow).Cells("Item").Value.ToString.Length <> 4) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Item Doc")
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                ' documento relacionado directamente 
                If (dgvDetalle.Rows(iRow).Cells("dtd_Id").Tag <> "") Then
                    If dgvDetalle.Rows(iRow).Cells("Serie").Value = "" Then
                        result = False
                        ErrorProvider1.SetError(dgvDetalle, "Serie y Numero ")
                        Return result
                    Else
                        ErrorProvider1.SetError(dgvDetalle, Nothing)

                    End If
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If dgvDetalle.Rows(iRow).Cells("Serie").Value <> "" Then
                    If (dgvDetalle.Rows(iRow).Cells("Serie").Value.ToString.Length <> 3) Then
                        result = False
                        ErrorProvider1.SetError(dgvDetalle, "Serie ")
                        Return result
                    Else
                        ErrorProvider1.SetError(dgvDetalle, Nothing)
                    End If
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If


                If dgvDetalle.Rows(iRow).Cells("Numero").Value <> "" Then
                    If (dgvDetalle.Rows(iRow).Cells("Numero").Value.ToString.Length <> 10) Then
                        result = False
                        ErrorProvider1.SetError(dgvDetalle, "Numero")
                        Return result
                    Else
                        ErrorProvider1.SetError(dgvDetalle, Nothing)
                    End If
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                ' documento referencia
                If (dgvDetalle.Rows(iRow).Cells("dtd_IdRef").Tag <> "") Then
                    If dgvDetalle.Rows(iRow).Cells("SerieRef").Value = "" Then
                        result = False
                        ErrorProvider1.SetError(dgvDetalle, "Serie y Numero ")
                        Return result
                    Else
                        ErrorProvider1.SetError(dgvDetalle, Nothing)

                    End If
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If dgvDetalle.Rows(iRow).Cells("dtd_IdRef").Value <> "" Then
                    If (dgvDetalle.Rows(iRow).Cells("SerieRef").Value.ToString.Length <> 3) Then
                        result = False
                        ErrorProvider1.SetError(dgvDetalle, "Serie ")
                        Return result
                    Else
                        ErrorProvider1.SetError(dgvDetalle, Nothing)
                    End If
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If


                If dgvDetalle.Rows(iRow).Cells("NumeroRef").Value <> "" Then
                    If (dgvDetalle.Rows(iRow).Cells("NumeroRef").Value.ToString.Length <> 10) Then
                        result = False
                        ErrorProvider1.SetError(dgvDetalle, "Numero")
                        Return result
                    Else
                        ErrorProvider1.SetError(dgvDetalle, Nothing)
                    End If
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If (dgvDetalle.Rows(iRow).Cells("ItemRef").Value <> "" AndAlso dgvDetalle.Rows(iRow).Cells("ItemRef").Value.ToString.Length <> 4) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Item Doc")
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If


                iRow += 1

            End While

            If (result) Then
                sumar()
            End If

            Return result
        End Function


        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPeriodo.Text = .Cells(0).Value

                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnLibroContable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLibroContable.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContables)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtLibro.Tag = .Cells(0).Value
                    txtLibro.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellValidated
            sumar()
        End Sub

        Private Sub dgvDetalle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDetalle.KeyPress
            'key =+
            If (Asc(e.KeyChar) = 43) Then
                OnManAgregarFilaGrid()
            End If
            'key  = -
            If (Asc(e.KeyChar) = 45) Then
                OnManQuitarFilaGrid()
            End If
        End Sub

        Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
            If Not e.Row.Cells("dam_Item").Tag Is Nothing Then
                CType(e.Row.Cells("dam_Item").Tag, BE.DetalleAsientosManuales).MarkAsDeleted()
            End If
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click, btnImportar.Click
            dgvDetalle.Rows.Clear()
            Dim OpenFileDialog1 As New OpenFileDialog
            OpenFileDialog1.ShowDialog()
            Dim ruta As String = OpenFileDialog1.FileName
            Try
                Dim Conexion As New OleDb.OleDbConnection
                Dim Adaptador As New OleDbDataAdapter
                Dim CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                       "Data Source=" + ruta + ";" + "Extended Properties='Excel 12.0 Xml;HDR=Yes;IMEX=1'"

                'Dim CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                '        "Data Source=" + ruta + ";" + "Extended Properties='Excel 12.0 Xml;HDR=Yes;IMEX=1'"


                'Dim CadenaConexion = "Provider=Microsoft.Jet.OLEDB.12.0;Data Source=" & ruta & "; Extended Properties= ""Excel 8.0;HDR=YES; IMEX=1"""

                Conexion = New OleDb.OleDbConnection(CadenaConexion)
                Adaptador = New OleDb.OleDbDataAdapter("SELECT * FROM [Plantilla$]", Conexion)
                Dim Sdataset As New DataSet()
                Adaptador.Fill(Sdataset, "Plantilla$")
                For Each mRow As DataRow In Sdataset.Tables(0).Rows

                    Dim nRow As New DataGridViewRow
                    dgvDetalle.Rows.Add(nRow)

                    If Not (IsDBNull(mRow.Item("cuc_id")) OrElse mRow.Item("cuc_id") Is Nothing OrElse mRow.Item("cuc_id").ToString = "") Then
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cuc_id").Tag = mRow.Item("cuc_id").ToString.Trim
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cuc_id").Value = mRow.Item("cuc_id").ToString.Trim
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DescripcionCuenta").Value = mRow.Item("descripcioncuenta")

                    End If

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CargoMN").Value = mRow.Item("cargomn")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("AbonoMN").Value = mRow.Item("abonomn")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CargoME").Value = mRow.Item("cargome")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("AbonoME").Value = mRow.Item("abonome")

                    Try
                        If (mRow.Item("mon_id").ToString <> "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Tag = mRow.Item("mon_id")
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Moneda").Value = mRow.Item("moneda")
                        Else
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Tag = Nothing
                        End If
                    Catch ex As Exception
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Tag = Nothing
                    End Try


                    Try
                        If (mRow.Item("cco_id").ToString <> "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cco_Id").Tag = mRow.Item("cco_id")
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CentroCosto").Value = mRow.Item("centrocosto")
                        Else
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cco_Id").Tag = Nothing
                        End If
                    Catch ex As Exception

                    End Try


                    Try
                        If (mRow.Item("per_id").ToString <> "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = mRow.Item("per_id")
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = mRow.Item("persona")

                        Else
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = Nothing
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = ""
                        End If
                    Catch ex As Exception
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = ""
                    End Try


                    Try
                        If (mRow.Item("cct_id").ToString <> "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cls_Id").Tag = mRow.Item("cls_id")
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cct_Id").Tag = mRow.Item("cct_id")
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CuentaCorriente").Value = mRow.Item("cct_id")
                        Else
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cls_Id").Tag = Nothing
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cct_Id").Tag = Nothing
                        End If
                    Catch ex As Exception
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cls_Id").Tag = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cct_Id").Tag = Nothing
                    End Try

                    Try
                        If (mRow.Item("tdo_id").ToString <> "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_Id").Tag = mRow.Item("tdo_id")
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_Id").Tag = mRow.Item("dtd_id")

                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoDocumento").Value = mRow.Item("tipodocumento")
                        Else
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_Id").Tag = Nothing
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_Id").Tag = Nothing
                        End If
                    Catch ex As Exception
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_Id").Tag = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_Id").Tag = Nothing
                    End Try


                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Serie").Value = mRow.Item("serie").ToString
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = mRow.Item("numero").ToString
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = mRow.Item("item").ToString

                    Try
                        If (mRow.Item("tdo_idref").ToString <> "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Tag = mRow.Item("tdo_idref")
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_IdRef").Tag = mRow.Item("dtd_idref")

                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoDocumentoRef").Value = mRow.Item("tipodocumentoref")
                        Else
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Tag = Nothing
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_IdRef").Tag = Nothing
                        End If

                    Catch ex As Exception
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Tag = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_IdRef").Tag = Nothing
                    End Try
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SerieRef").Value = mRow.Item("serieref")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("NumeroRef").Value = mRow.Item("numeroref")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ItemRef").Value = mRow.Item("itemref")

                Next
                sumar()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            'Dim dir As String
            'Dim fileOpen As New OpenFileDialog
            'fileOpen.ShowDialog()
            'dir = fileOpen.FileName
            'Dim objConn As OleDbConnection
            'Dim oleDA As OleDbDataAdapter
            'Dim ds As DataSet
            'Dim FileName As String
            'FileName = fileOpen.FileName ''"C:\ejemplo.xlsx"
            'Try
            '    Dim connectionString As String = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1"""
            '    objConn = New OleDbConnection(connectionString)
            '    oleDA = New OleDbDataAdapter("select * from [Hoja1$]", objConn)
            '    ds = New DataSet()
            '    oleDA.Fill(ds)
            '    DataGridView1.DataSource = ds.Tables(0)
            '    ds.Dispose()
            '    oleDA.Dispose()
            '    objConn.Dispose()
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'End Try

        End Sub
    End Class
End Namespace

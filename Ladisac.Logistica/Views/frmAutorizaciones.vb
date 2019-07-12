Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Net.Mail

Public Class frmAutorizaciones
    <Dependency()> _
    Public Property BCProcesoCompra As Ladisac.BL.IBCProcesoCompra
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCOrdenRequerimiento As Ladisac.BL.IBCOrdenRequerimiento
    <Dependency()> _
    Public Property BCOrdenCompra As Ladisac.BL.IBCOrdenCompra
    <Dependency()> _
    Public Property BCOrdenServicio As Ladisac.BL.IBCOrdenServicio
    <Dependency()> _
    Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCusuario As Ladisac.BL.IBCPermisoUsuario
    <Dependency()> _
    Public Property BCPersona As Ladisac.BL.IBCPersona
    <Dependency()> _
    Public Property BCRendicionGastos As Ladisac.BL.IBCRendicionGastos
    <Dependency()> _
    Public Property BCCuentaRendir As Ladisac.BL.IBCCuentaRendir

    Private Sub frmAutorizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarAutorizaciones()
    End Sub

    Sub CargarAutorizaciones()
        dgvDetalle.Rows.Clear()
        Dim ds1 As New DataSet
        Dim query1 = BCProcesoCompra.ListaAutorizar(SessionServer.UserId)
        ds1.Merge(query1)
        For Each mFila As DataRow In ds1.Tables(0).Rows
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = mFila.Item("Codigo")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Tipo").Value = mFila.Item("Tipo")
            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo_Articulo").Value = mFila.Item("Codigo_Articulo")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descripcion").Value = mFila.Item("Descripcion")
            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM").Value = mFila.Item("UM")
            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mFila.Item("Cantidad")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total").Value = mFila.Item("Total")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observacion").Value = mFila.Item("Observacion")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Aprobado").Value = False
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CodInt").Value = mFila.Item("CodInt")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Solicitado_Por").Value = mFila.Item("Solicitado_Por")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importancia").Value = mFila.Item("Importancia")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Ruta").Value = mFila.Item("Ruta")
        Next
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Dim mORD As OrdenRequerimientoDetalle
        Dim mOC As OrdenCompra
        Dim mOS As OrdenServicio
        Dim mRGA As RendicionGastos
        Dim mCRE As CuentaRendir

        Try
            For Each mFila As DataGridViewRow In dgvDetalle.Rows
                If mFila.Cells("Aprobado").Value Then
                    If mFila.Cells("Tipo").Value = "OR" Then
                        mORD = New OrdenRequerimientoDetalle
                        mORD = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mFila.Cells("CodInt").Value)

                        mORD.USU_ID_AUT = SessionServer.UserId
                        mORD.ORD_FEC_AUT = Now

                        If mORD.Articulos.GLI_ID <> "056" Then
                            'Cant OR para comprar 
                            Dim cantOC As Double = BCOrdenRequerimiento.CantidadPorComprar(mORD.ART_ID)
                            'Cant OR aprobadas no atendidas
                            Dim cantOR As Double = BCOrdenRequerimiento.CantidadPorAtender(mORD.ART_ID)

                            If cantOC = Nothing Then cantOC = 0
                            If cantOR = Nothing Then cantOR = 0

                            If ((BCArticuloAlmacen.TotalStock(mORD.ART_ID) + cantOC) - (CDec(mORD.ORD_CANTIDAD) + cantOR)) < 0 Then
                                If BCArticuloAlmacen.ArticuloAlmacenGetById(mORD.ART_ID, BCParametro.ParametroGetById("AlmSum").PAR_VALOR1) Is Nothing Then
                                    mORD.ORD_ESTADO_COMPRA = "PC"
                                    mORD.ORD_OBS_COMPRA = "Automatico"

                                    mORD.ORD_CANTIDAD_COMPRA = Math.Abs((BCArticuloAlmacen.TotalStock(mORD.ART_ID) + cantOC) - (CDec(mORD.ORD_CANTIDAD) + cantOR))
                                Else
                                    If Not BCArticuloAlmacen.ArticuloAlmacenGetById(mORD.ART_ID, BCParametro.ParametroGetById("AlmSum").PAR_VALOR1).ARA_STOCK_MINIMO > 0 Then 'Si tiene stock minimo no se compra en Alm Suministro
                                        mORD.ORD_ESTADO_COMPRA = "PC"
                                        mORD.ORD_OBS_COMPRA = "Automatico"
                                        'Cant OR para comprar 
                                        cantOC = BCOrdenRequerimiento.CantidadPorComprar(mORD.ART_ID)
                                        'Cant OR aprobadas no atendidas
                                        cantOR = BCOrdenRequerimiento.CantidadPorAtender(mORD.ART_ID)
                                        mORD.ORD_CANTIDAD_COMPRA = Math.Abs((BCArticuloAlmacen.TotalStock(mORD.ART_ID) + cantOC) - (CDec(mORD.ORD_CANTIDAD) + cantOR))
                                    End If
                                End If
                            End If
                        End If

                        mORD.MarkAsModified()
                        BCOrdenRequerimiento.MantenimientoOrdenRequerimientoDetalle(mORD)


                    ElseIf mFila.Cells("Tipo").Value = "OC" Then
                        mOC = New OrdenCompra
                        mOC = BCOrdenCompra.OrdenCompraGetById(mFila.Cells("Codigo").Value)

                        For Each mOCD In mOC.OrdenCompraDetalle
                            If mOCD.USU_ID_AUT_2 Is Nothing Then
                                mOCD.USU_ID_AUT_2 = SessionServer.UserId
                                mOCD.OCD_FEC_AUT_2 = Now

                                'PARA COMBUSTIBLES
                                If mOCD.ART_ID = BCParametro.ParametroGetById("Diesel").PAR_VALOR1 Or mOCD.ART_ID = BCParametro.ParametroGetById("R500").PAR_VALOR1 Then
                                    mOCD.USU_ID_AUT_3 = "RBERRIOS"
                                    mOCD.OCD_FEC_AUT_3 = Now
                                End If

                            ElseIf mOCD.USU_ID_AUT_3 Is Nothing Then
                                mOCD.USU_ID_AUT_3 = SessionServer.UserId
                                mOCD.OCD_FEC_AUT_3 = Now
                            ElseIf mOCD.USU_ID_AUT_4 Is Nothing Then
                                mOCD.USU_ID_AUT_4 = SessionServer.UserId
                                mOCD.OCD_FEC_AUT_4 = Now
                            End If

                            mOCD.MarkAsModified()
                            BCOrdenCompra.MantenimientoOrdenCompraDetalle(mOCD)
                        Next

                        'mandar Correo a Finanzas si se pasa
                        If mFila.Cells("Total").Value > BCParametro.ParametroGetById("MontoOrdenCompra").PAR_VALOR1 Then
                            Dim cuerpo As String
                            cuerpo = "IMPORTE ALTO" & vbCrLf & _
                                      "Proveedor: " & mOC.Personas.PER_APE_PAT & " " & mOC.Personas.PER_APE_MAT & " " & mOC.Personas.PER_NOMBRES & vbCrLf
                            For Each mDoc In mOC.Personas.DocPersonas
                                If mDoc.TDP_ID = "04" Then
                                    cuerpo = cuerpo & "RUC: " & mDoc.DOP_NUMERO & vbCrLf
                                End If
                            Next
                            cuerpo = cuerpo & "Condiciones de Venta: " & mOC.TipoVenta.TIV_DESCRIPCION & vbCrLf & _
                                    "Detalle:" & vbCrLf
                            For Each mOCD In mOC.OrdenCompraDetalle
                                cuerpo = cuerpo & Math.Round(CDec(mOCD.OCD_CANTIDAD), 2) & " " & mOCD.Articulos.ART_DESCRIPCION & " S/. " & Math.Round(CDec(mOCD.OCD_CONTRAVALOR), 2) & vbCrLf
                            Next
                            cuerpo = cuerpo & "TOTAL S/. " & Math.Round(CDec(mFila.Cells("Total").Value))

                            'EnviarEmail("ORDEN DE COMPRA IMPORTE ALTO", mOC.OCO_ID.ToString, "rlinaresa@ladrilleraeldiamante.com", cuerpo)
                            EnviarEmail("ORDEN DE COMPRA IMPORTE ALTO", mOC.OCO_ID.ToString, "rventura@ladrilleraeldiamante.com", cuerpo)
                            EnviarEmail("ORDEN DE COMPRA IMPORTE ALTO", mOC.OCO_ID.ToString, "mzambrano@ladrilleraeldiamante.com", cuerpo)
                        End If


                    ElseIf mFila.Cells("Tipo").Value = "OS" Then
                        mOS = New OrdenServicio
                        mOS = BCOrdenServicio.OrdenServicioGetById(mFila.Cells("Codigo").Value)

                        For Each mOSD In mOS.OrdenServicioDetalle
                            If mOSD.USU_ID_AUT_2 Is Nothing Then
                                mOSD.USU_ID_AUT_2 = SessionServer.UserId
                                mOSD.OSD_FEC_AUT_2 = Now
                            ElseIf mOSD.USU_ID_AUT_3 Is Nothing Then
                                mOSD.USU_ID_AUT_3 = SessionServer.UserId
                                mOSD.OSD_FEC_AUT_3 = Now
                            ElseIf mOSD.USU_ID_AUT_4 Is Nothing Then
                                mOSD.USU_ID_AUT_4 = SessionServer.UserId
                                mOSD.OSD_FEC_AUT_4 = Now
                            End If

                            'Para cuentas contables de servicios
                            Select Case EntidadReversa(mOSD.ENO_ID)
                                Case "1"
                                    mOSD.CUC_ID = mOSD.Articulos.CUC_ID_1
                                Case "2"
                                    mOSD.CUC_ID = mOSD.Articulos.CUC_ID_2
                                Case "3"
                                    mOSD.CUC_ID = mOSD.Articulos.CUC_ID_3
                                Case "4"
                                    mOSD.CUC_ID = mOSD.Articulos.CUC_ID_4
                                Case Else
                                    mOSD.CUC_ID = Nothing
                            End Select

                            mOSD.MarkAsModified()
                            BCOrdenServicio.MantenimientoOrdenServicioDetalle(mOSD)
                        Next

                        'mandar Correo a Finanzas si se pasa
                        If mFila.Cells("Total").Value > BCParametro.ParametroGetById("MontoOrdenCompra").PAR_VALOR1 Then
                            Dim cuerpo As String
                            cuerpo = "IMPORTE ALTO" & vbCrLf & _
                                      "Proveedor: " & mOS.Personas.PER_APE_PAT & " " & mOS.Personas.PER_APE_MAT & " " & mOS.Personas.PER_NOMBRES & vbCrLf
                            For Each mDoc In mOS.Personas.DocPersonas
                                If mDoc.TDP_ID = "04" Then
                                    cuerpo = cuerpo & "RUC: " & mDoc.DOP_NUMERO & vbCrLf
                                End If
                            Next
                            cuerpo = cuerpo & "Condiciones de Venta: " & mOS.TipoVenta.TIV_DESCRIPCION & vbCrLf & _
                                    "Detalle:" & vbCrLf
                            For Each mOSD In mOS.OrdenServicioDetalle
                                cuerpo = cuerpo & Math.Round(CDec(mOSD.OSD_CANTIDAD), 2) & " " & mOSD.Articulos.ART_DESCRIPCION & " S/. " & Math.Round(CDec(mOSD.OSD_CONTRAVALOR), 2) & vbCrLf
                            Next
                            cuerpo = cuerpo & "TOTAL S/. " & Math.Round(CDec(mFila.Cells("Total").Value))

                            'EnviarEmail("ORDEN DE SERVICIO IMPORTE ALTO", mOS.OSE_ID.ToString, "rlinaresa@ladrilleraeldiamante.com", cuerpo)
                            EnviarEmail("ORDEN DE SERVICIO IMPORTE ALTO", mOS.OSE_ID.ToString, "rventura@ladrilleraeldiamante.com", cuerpo)
                            EnviarEmail("ORDEN DE COMPRA IMPORTE ALTO", mOC.OCO_ID.ToString, "mzambrano@ladrilleraeldiamante.com", cuerpo)
                        End If



                    ElseIf mFila.Cells("Tipo").Value = "GM" Then
                        mRGA = New RendicionGastos
                        mRGA = BCRendicionGastos.RendicionGastosGetById(mFila.Cells("Codigo").Value)
                        mRGA.MarkAsModified()
                        For Each mRGD In mRGA.RendicionGastosDetalle
                            If mRGD.USU_ID_AUT_2 Is Nothing Then
                                mRGD.USU_ID_AUT_2 = SessionServer.UserId
                                mRGD.RGD_FEC_AUT_2 = Now
                            ElseIf mRGD.USU_ID_AUT_3 Is Nothing Then
                                mRGD.USU_ID_AUT_3 = SessionServer.UserId
                                mRGD.RGD_FEC_AUT_3 = Now
                            ElseIf mRGD.USU_ID_AUT_4 Is Nothing Then
                                mRGD.USU_ID_AUT_4 = SessionServer.UserId
                                mRGD.RGD_FEC_AUT_4 = Now
                            End If
                            mRGD.MarkAsModified()
                        Next

                        BCRendicionGastos.MantenimientoRendicionGastos(mRGA)

                    ElseIf mFila.Cells("Tipo").Value = "CR" Then
                        mCRE = New CuentaRendir
                        mCRE = BCCuentaRendir.CuentaRendirGetById(mFila.Cells("Codigo").Value)
                        mCRE.MarkAsModified()
                        For Each mCRD In mCRE.cuentarendirDetalle
                            If mCRD.USU_ID_AUT_2 Is Nothing Then
                                mCRD.USU_ID_AUT_2 = SessionServer.UserId
                                mCRD.CRD_FEC_AUT_2 = Now
                            ElseIf mCRD.USU_ID_AUT_3 Is Nothing Then
                                mCRD.USU_ID_AUT_3 = SessionServer.UserId
                                mCRD.CRD_FEC_AUT_3 = Now
                            ElseIf mCRD.USU_ID_AUT_4 Is Nothing Then
                                mCRD.USU_ID_AUT_4 = SessionServer.UserId
                                mCRD.CRD_FEC_AUT_4 = Now
                            End If
                            mCRD.MarkAsModified()
                        Next

                        BCCuentaRendir.MantenimientoCuentaRendir(mCRE)
                    End If


                ElseIf mFila.Cells("Rechazar").Value Then  'Cuando se Rechaza
                    If mFila.Cells("Tipo").Value = "OR" Then
                        mORD = New OrdenRequerimientoDetalle
                        mORD = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mFila.Cells("CodInt").Value)

                        mORD.ORD_RECHAZADO = 1
                        mORD.ORD_FEC_AUT = Now
                        mORD.MarkAsModified()
                        BCOrdenRequerimiento.MantenimientoOrdenRequerimientoDetalle(mORD)

                        'Mandar Correo
                        Dim USU = BCusuario.UsuarioGetById(BCOrdenRequerimiento.OrdenRequerimientoGetById(mORD.ORR_ID).USU_ID)
                        Dim PER = BCPersona.PersonaGetById(USU.PER_ID)
                        EnviarEmail("ORDEN DE REQUERIMIENTO", mORD.ORR_ID.ToString, PER.PER_EMAIL.ToString, "RECHAZADO")

                    ElseIf mFila.Cells("Tipo").Value = "OC" Then
                        mOC = New OrdenCompra
                        mOC = BCOrdenCompra.OrdenCompraGetById(mFila.Cells("Codigo").Value)

                        mOC.OCO_CERRADA = 1
                        mOC.OCO_FEC_GRAB = Now
                        mOC.MarkAsModified()
                        BCOrdenCompra.MantenimientoOrdenCompra(mOC)


                        'Mandar Correo
                        Dim USU = BCusuario.UsuarioGetById(mOC.USU_ID)
                        Dim PER = BCPersona.PersonaGetById(USU.PER_ID)
                        EnviarEmail("ORDEN DE COMPRA", mOC.OCO_ID.ToString, PER.PER_EMAIL.ToString, "RECHAZADO")

                        For Each mDet In mOC.OrdenCompraDetalle
                            If mDet.ORD_ID IsNot Nothing Then
                                mORD = New OrdenRequerimientoDetalle
                                mORD = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mDet.ORD_ID)

                                mORD.ORD_RECHAZADO = 1
                                mORD.ORD_FEC_AUT = Now
                                mORD.MarkAsModified()
                                BCOrdenRequerimiento.MantenimientoOrdenRequerimientoDetalle(mORD)

                                'Mandar Correo
                                USU = BCusuario.UsuarioGetById(BCOrdenRequerimiento.OrdenRequerimientoGetById(mORD.ORR_ID).USU_ID)
                                PER = BCPersona.PersonaGetById(USU.PER_ID)
                                EnviarEmail("ORDEN DE REQUERIMIENTO", mORD.ORR_ID.ToString, PER.PER_EMAIL.ToString, "RECHAZADO")
                            End If

                        Next

                    ElseIf mFila.Cells("Tipo").Value = "OS" Then
                        mOS = New OrdenServicio
                        mOS = BCOrdenServicio.OrdenServicioGetById(mFila.Cells("Codigo").Value)

                        mOS.OSE_CERRADA = 1
                        mOS.OSE_FEC_GRAB = Now
                        mOS.MarkAsModified()
                        BCOrdenServicio.MantenimientoOrdenServicio(mOS)

                        'Mandar Correo
                        Dim USU = BCusuario.UsuarioGetById(mOS.USU_ID)
                        Dim PER = BCPersona.PersonaGetById(USU.PER_ID)
                        EnviarEmail("ORDEN DE SERVICIO", mOS.OSE_ID.ToString, PER.PER_EMAIL.ToString, "RECHAZADO")

                        For Each mDet In mOS.OrdenServicioDetalle
                            If mDet.ORD_ID IsNot Nothing Then
                                mORD = New OrdenRequerimientoDetalle
                                mORD = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mDet.ORD_ID)

                                mORD.ORD_RECHAZADO = 1
                                mORD.ORD_FEC_AUT = Now
                                mORD.MarkAsModified()
                                BCOrdenRequerimiento.MantenimientoOrdenRequerimientoDetalle(mORD)

                                'Mandar Correo
                                USU = BCusuario.UsuarioGetById(BCOrdenRequerimiento.OrdenRequerimientoGetById(mORD.ORR_ID).USU_ID)
                                PER = BCPersona.PersonaGetById(USU.PER_ID)
                                EnviarEmail("ORDEN DE REQUERIMIENTO", mORD.ORR_ID.ToString, PER.PER_EMAIL.ToString, "RECHAZADO")
                            End If

                        Next


                    ElseIf mFila.Cells("Tipo").Value = "GM" Then
                        mRGA = New RendicionGastos
                        mRGA = BCRendicionGastos.RendicionGastosGetById(mFila.Cells("Codigo").Value)

                        mRGA.RGA_ESTADO = 0
                        mRGA.USU_ID = SessionServer.UserId
                        mRGA.RGA_FEC_GRAB = Now
                        mRGA.MarkAsModified()
                        BCRendicionGastos.MantenimientoRendicionGastos(mRGA)

                    ElseIf mFila.Cells("Tipo").Value = "CR" Then
                        mCRE = New CuentaRendir
                        mCRE = BCCuentaRendir.CuentaRendirGetById(mFila.Cells("Codigo").Value)

                        mCRE.CRE_ESTADO = 0
                        mCRE.USU_ID = SessionServer.UserId
                        mCRE.CRE_FEC_GRAB = Now
                        mCRE.MarkAsModified()
                        BCCuentaRendir.MantenimientoCuentaRendir(mCRE)
                    End If
                End If
            Next
            CargarAutorizaciones()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Function EntidadReversa(ByVal EnoId As Integer) As String
        If EnoId = -1 Then Return ""
        Dim Eno As Entidad
        Dim mFlag As Boolean = False
        Eno = BCEntidad.EntidadGetById(EnoId)
        For Each mItem In BCEntidad.ListaEntidadCuentaContable
            If Eno.ENO_ID = mItem.ENO_ID Then
                Return BCParametro.ParametroGetById("EntidadCuentaContable" & Eno.ENO_ID.ToString).PAR_VALOR1
            End If
        Next
        If mFlag = False Then
            Return EntidadReversa(Eno.ENO_ID_PADRE)
        End If
    End Function

    Private Sub chkMarcar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMarcar.CheckedChanged
        For Each mFila As DataGridViewRow In dgvDetalle.Rows
            If mFila.Selected Then
                mFila.Cells("Aprobado").Value = chkMarcar.Checked
            End If
        Next
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        CargarAutorizaciones()
    End Sub


    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Select Case dgvDetalle.CurrentRow.Cells("Tipo").Value
            Case "OR"
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenRequerimiento)()
                Dim ORR As OrdenRequerimiento
                ORR = BCOrdenRequerimiento.OrdenRequerimientoGetById(dgvDetalle.CurrentRow.Cells("Codigo").Value)
                frm.mOR = ORR
                frm.FlagOT = True

                frm.Show()
            Case "OC"
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenCompra)()
                Dim OC As OrdenCompra
                OC = BCOrdenCompra.OrdenCompraGetById(dgvDetalle.CurrentRow.Cells("Codigo").Value)
                frm.mOC = OC

                frm.Show()
            Case "OS"
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenServicio)()
                Dim OS As OrdenServicio
                OS = BCOrdenServicio.OrdenServicioGetById(dgvDetalle.CurrentRow.Cells("Codigo").Value)
                frm.mOS = OS

                frm.Show()

            Case "GM"
                Dim frm = Me.ContainerService.Resolve(Of frmRendicionGastos)()
                Dim GM As RendicionGastos
                GM = BCRendicionGastos.RendicionGastosGetById(dgvDetalle.CurrentRow.Cells("Codigo").Value)
                frm.mRGA = GM

                frm.Show()

            Case Else
                Dim frm = Me.ContainerService.Resolve(Of frmCuentaRendir)()
                Dim CR As CuentaRendir
                CR = BCCuentaRendir.CuentaRendirGetById(dgvDetalle.CurrentRow.Cells("Codigo").Value)
                frm.mCRE = CR

                frm.Show()
        End Select
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        If dgvDetalle.Columns(e.ColumnIndex).Name = "Rechazar" Then
            If dgvDetalle.CurrentCell.Value = True Then
                dgvDetalle.CurrentRow.Cells("Aprobado").Value = False
            End If
        ElseIf dgvDetalle.Columns(e.ColumnIndex).Name = "Aprobado" Then
            If dgvDetalle.CurrentCell.Value = True Then
                dgvDetalle.CurrentRow.Cells("Rechazar").Value = False
            End If
        End If
    End Sub

    Private Sub dgvDetalle_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle.CurrentCellChanged
        Try
            If dgvDetalle.CurrentRow.Cells("Ruta").Value.ToString.Length > 0 Then
                lblView.Text = dgvDetalle.CurrentRow.Cells("Ruta").Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EnviarEmail(ByVal Tipo As String, ByVal Numero As String, ByVal correo As String, ByVal motivo As String)
        Dim SmtpServer As New SmtpClient()
        Dim mail As New MailMessage()
        Dim eTo, eNuestroCorreo, eNuestraContraseña As String

        Try
            eNuestroCorreo = "sistemas@ladrilleraeldiamante.com"
            eNuestraContraseña = "Sistemas1"
            SmtpServer.Port = 25
            SmtpServer.Host = "mail.ladrilleraeldiamante.com"
            SmtpServer.EnableSsl = False
            SmtpServer.Credentials = New Net.NetworkCredential(eNuestroCorreo, eNuestraContraseña)
            mail = New MailMessage()
            mail.From = New MailAddress(eNuestroCorreo)
            mail.Subject = Tipo
            mail.Body = Tipo & vbCrLf & " Nro.: " & Numero & vbCrLf & _
                        motivo

            mail.IsBodyHtml = False

            'For Each mDestinatario In gridDestinatarios.Rows
            mail.To.Clear()
            'Destinatario del Mensaje
            'eTo = "ynunez@ladrilleraeldiamante.com"
            'Destinatarios del correo
            'mail.To.Add(eTo)
            mail.To.Add(correo)
            'Le decimos que envíe el correo
            SmtpServer.Send(mail)
            'Next

            'Msgbox dando el Ok del envío
            MsgBox("Correo enviado")
        Catch ex As Exception
            'Msgbox informandonos si existiera algún error
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick

    End Sub
End Class

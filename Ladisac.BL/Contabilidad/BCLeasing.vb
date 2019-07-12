Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCLeasing
        Implements IBCLeasing

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil


        Public Function LeasingQuery(ByVal serie As String, ByVal numero As String, ByVal Nombre As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As Object Implements IBCLeasing.LeasingQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPLeasingSelectXML, serie, numero, Nombre, FechaDesde, FechaHasta)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function LeasingSeek(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal lea_Serie As String, ByVal lea_Numero As String) As Object Implements IBCLeasing.LeasingSeek
            Dim result As Leasing = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILeasingRepositorio)()
                result = rep.GetById(cct_Id, tdo_Id, dtd_Id, lea_Serie, lea_Numero)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.Leasing) As Object Implements IBCLeasing.Maintenance
            Dim x As Integer = 0
            Dim y As Integer = 0
            Try
                Dim repCAB = ContainerService.Resolve(Of DA.ILeasingRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleLeasingRepositorio)()
                Dim repDETActivo = ContainerService.Resolve(Of DA.IDetalleLeasingActivosFijosRepositorio)()

                Dim sCorrelativo As String = Nothing

                ' Using Scope As New System.Transactions.TransactionScope

                'Estos codigos estan en controller - para retenciones y para  renta de cuarta



                ' contrato leasing Leasig - modificar tambien en el menu, y provision compras
                item.cct_Id = "018"
                item.tdo_Id = "048"
                item.dtd_Id = "114"


                If (item.ChangeTracker.State = ObjectState.Added) Then
                    If (item.lea_Numero.Trim = "") Then
                        sCorrelativo = BCUtil.GetId("Con.Leasing", "lea_Numero", 10, " where cct_Id='" & item.cct_Id & "' and tdo_Id='" & item.tdo_Id & "' and   dtd_Id='" & item.dtd_Id & "'  and  lea_Serie='" & item.lea_Serie & "'")
                        item.lea_Numero = sCorrelativo

                    Else
                        item.lea_Numero = Right("0000000000" & Trim(item.lea_Numero.ToString), 10)
                    End If

                End If

                'detalle leasing
                Dim listaDET As New List(Of DetalleLeasing)

                For Each RowDET In item.DetalleLeasing
                    Dim NewDET As New BE.DetalleLeasing

                    NewDET = RowDET.Clone

                    NewDET.lea_Numero = item.lea_Numero

                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.dele_item) > x) Then
                            x = Val(NewDET.dele_item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If
                    listaDET.Add(NewDET)

                Next
                ' detalle activos del leasing
                Dim listaDETActivos As New List(Of DetalleLeasingActivosFijos)

                For Each RowDET In item.DetalleLeasingActivosFijos
                    Dim NewDET As New BE.DetalleLeasingActivosFijos

                    NewDET = RowDET.Clone

                    NewDET.lea_Numero = item.lea_Numero

                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.lea_Item) > y) Then
                            y = Val(NewDET.lea_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If
                    listaDETActivos.Add(NewDET)

                Next

                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleLeasing = Nothing
                item.DetalleLeasingActivosFijos = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 10, 0))

                    repCAB.Maintenance(item)
                    'Dim i As Integer = 0
                    For Each mItemIngreso As BE.DetalleLeasing In listaDET

                        x += 1
                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngreso.dele_item = Right("0000000" & x.ToString(), 4)
                        End If

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False

                        mItemIngreso.lea_Numero = item.lea_Numero
                        mItemIngreso.dtd_Id = item.dtd_Id
                        mItemIngreso.tdo_Id = item.tdo_Id
                        mItemIngreso.cct_Id = item.cct_Id

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True




                        repDET.Maintenance(mItemIngreso)

                    Next

                    For Each mItemIngreso As BE.DetalleLeasingActivosFijos In listaDETActivos

                        y += 1
                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngreso.lea_Item = Right("0000000" & y.ToString(), 4)
                        End If

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False

                        mItemIngreso.Leasing = Nothing
                        mItemIngreso.lea_Numero = item.lea_Numero
                        mItemIngreso.dtd_Id = item.dtd_Id
                        mItemIngreso.tdo_Id = item.tdo_Id
                        mItemIngreso.cct_Id = item.cct_Id

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True




                        repDETActivo.Maintenance(mItemIngreso)

                    Next


                    Scope.Complete()
                End Using

                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return False

        End Function

        Public Function MAintenanceDelete(ByVal item As BE.Leasing) As Object Implements IBCLeasing.MAintenanceDelete
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILeasingRepositorio)()
                Return rep.MaintenanceDelete(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function

        Public Function LeasingListaQuery(ByVal serie As String, ByVal numero As String, ByVal per_id As String) As Object Implements IBCLeasing.LeasingListaQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPLeasingListaSelectXML, serie, numero, per_id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
    End Class
End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Class BCComprobantes
'        Implements IBCComprobantes

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil

'        Public Function ComprobantesQuery(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal Nombre As String) As Object Implements IBCComprobantes.ComprobantesQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.spComprobantesSelectXML, fechaDesde, fechaHasta, tdo_Id, dtd_Id, cob_Serie, cob_Numero, Nombre)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function ComprobantesSeek(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String) As Object Implements IBCComprobantes.ComprobantesSeek
'            Dim result As BE.Comprobantes = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IComprobantesRepositorio)()
'                result = rep.GetById(cct_Id, tdo_Id, dtd_Id, cob_Serie, cob_Numero)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByRef item As BE.Comprobantes) As Object Implements IBCComprobantes.Maintenance
'            Dim x As Integer = 0
'            Try
'                Dim repCAB = ContainerService.Resolve(Of DA.IComprobantesRepositorio)()
'                Dim repDET = ContainerService.Resolve(Of DA.IDetalleComprobantesRepositorio)()
'                Dim sCorrelativo As String = Nothing
'                ' Using Scope As New System.Transactions.TransactionScope

'                'Estos codigos estan en controller - para retenciones y para  renta de cuarta

'                'retenciones
'                'item.cct_Id = "012"
'                'item.tdo_Id = "025"
'                'item.dtd_Id = "049"

'                ' retntab de cuarta
'                'item.cct_Id = "012"
'                'item.tdo_Id = "031"
'                'item.dtd_Id = "048"


'                If (item.ChangeTracker.State = ObjectState.Added) Then
'                    If (item.cob_Numero.Trim = "") Then

'                        sCorrelativo = BCUtil.GetId("Con.Comprobantes", "cob_Numero", 10, " where cct_Id='" & item.cct_Id & "' and tdo_Id='" & item.tdo_Id & "' and   dtd_Id='" & item.dtd_Id & "'  and  cob_Serie='" & item.cob_Serie & "'")
'                        item.cob_Numero = sCorrelativo

'                    Else
'                        item.cob_Numero = Right("0000000000" & Trim(item.cob_Numero.ToString), 6)
'                    End If

'                End If






'                Dim listaDET As New List(Of DetalleComprobantes)

'                For Each RowDET In item.DetalleComprobantes
'                    Dim NewDET As New BE.DetalleComprobantes

'                    NewDET = RowDET.Clone

'                    NewDET.cob_Numero = item.cob_Numero

'                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
'                        If (Val(NewDET.dco_Item) > x) Then
'                            x = Val(NewDET.dco_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
'                        End If

'                    End If
'                    listaDET.Add(NewDET)

'                Next
'                item.ChangeTracker.ChangeTrackingEnabled = False
'                item.DetalleComprobantes = Nothing
'                item.ChangeTracker.ChangeTrackingEnabled = True

'                repCAB.Maintenance(item)
'                'Dim i As Integer = 0
'                For Each mItemIngreso As BE.DetalleComprobantes In listaDET

'                    x += 1
'                    If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
'                        mItemIngreso.dco_Item = Right("0000000" & x.ToString(), 6)
'                    End If

'                    mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False

'                    mItemIngreso.cob_Numero = item.cob_Numero
'                    mItemIngreso.dtd_Id = item.dtd_Id
'                    mItemIngreso.tdo_Id = item.tdo_Id
'                    mItemIngreso.cct_Id = item.cct_Id

'                    mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True




'                    repDET.Maintenance(mItemIngreso)

'                Next

'                '  Scope.Complete()
'                ' End Using

'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return False
'        End Function

'        Public Function ComprobantesListaQuery(ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal idpersona As String, ByVal desde As Date, ByVal hasta As Date, ByVal tdo_IdBuscar As String, ByVal dtd_IdBuscar As String) As Object Implements IBCComprobantes.ComprobantesListaQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPDetalleComprobantesListaXML, tdo_Id, dtd_Id, cob_Serie, cob_Numero, idpersona, desde, hasta, tdo_IdBuscar, dtd_IdBuscar)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function MaintenanceDelete(ByVal item As BE.Comprobantes) As Object Implements IBCComprobantes.MaintenanceDelete
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IComprobantesRepositorio)()
'                Return rep.MaintenanceDelete(item)
'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return False
'        End Function
'    End Class

'End Namespace

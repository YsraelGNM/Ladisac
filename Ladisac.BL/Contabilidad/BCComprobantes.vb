Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCComprobantes
        Implements IBCComprobantes


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Public Function ComprobantesQuery(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal Nombre As String) As Object Implements IBCComprobantes.ComprobantesQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spComprobantesSelectXML, fechaDesde, fechaHasta, tdo_Id, dtd_Id, cob_Serie, cob_Numero, Nombre)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ComprobantesSeek(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String) As Object Implements IBCComprobantes.ComprobantesSeek
            Dim result As BE.Comprobantes = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IComprobantesRepositorio)()
                result = rep.GetById(cct_Id, tdo_Id, dtd_Id, cob_Serie, cob_Numero)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByRef item As BE.Comprobantes) As Object Implements IBCComprobantes.Maintenance
            Dim x As Integer = 0
            Try
                Dim repCAB = ContainerService.Resolve(Of DA.IComprobantesRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleComprobantesRepositorio)()
                Dim sCorrelativo As String = Nothing


                'Estos codigos estan en controller - para retenciones y para  renta de cuarta

                'retenciones
                'item.cct_Id = "012"
                'item.tdo_Id = "025"
                'item.dtd_Id = "049"

                ' retntab de cuarta
                'item.cct_Id = "012"
                'item.tdo_Id = "031"
                'item.dtd_Id = "048"


                If (item.ChangeTracker.State = ObjectState.Added) Then
                    If (item.cob_Numero.Trim = "") Then

                        sCorrelativo = BCUtil.GetId("Con.Comprobantes", "cob_Numero", 10, " where cct_Id='" & item.cct_Id & "' and tdo_Id='" & item.tdo_Id & "' and   dtd_Id='" & item.dtd_Id & "'  and  cob_Serie='" & item.cob_Serie & "'")
                        item.cob_Numero = sCorrelativo

                    Else
                        item.cob_Numero = Right("0000000000" & Trim(item.cob_Numero.ToString), 10)
                    End If

                End If






                Dim listaDET As New List(Of DetalleComprobantes)

                For Each RowDET In item.DetalleComprobantes
                    Dim NewDET As New BE.DetalleComprobantes

                    NewDET = RowDET.Clone

                    NewDET.cob_Numero = item.cob_Numero

                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.dco_Item) > x) Then
                            x = Val(NewDET.dco_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If
                    listaDET.Add(NewDET)

                Next
                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleComprobantes = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True
                Using Scope As New System.Transactions.TransactionScope
                    repCAB.Maintenance(item)
                    'Dim i As Integer = 0
                    For Each mItemIngreso As BE.DetalleComprobantes In listaDET

                        x += 1
                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngreso.dco_Item = Right("0000000" & x.ToString(), 4)
                        End If

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False

                        mItemIngreso.cob_Numero = item.cob_Numero
                        mItemIngreso.dtd_Id = item.dtd_Id
                        mItemIngreso.tdo_Id = item.tdo_Id
                        mItemIngreso.cct_Id = item.cct_Id

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True
                        repDET.Maintenance(mItemIngreso)
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

        Public Function ComprobantesListaQuery(ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal idpersona As String, ByVal desde As Date, ByVal hasta As Date, ByVal tdo_IdBuscar As String, ByVal dtd_IdBuscar As String) As Object Implements IBCComprobantes.ComprobantesListaQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleComprobantesListaXML, tdo_Id, dtd_Id, cob_Serie, cob_Numero, idpersona, desde, hasta, tdo_IdBuscar, dtd_IdBuscar)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function ComprobantesListaQuery1(ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal idpersona As String, ByVal desde As Date, ByVal hasta As Date, ByVal tdo_IdBuscar As String, ByVal dtd_IdBuscar As String, Optional ByVal fecha As Date = #1/1/2000#) As Object Implements IBCComprobantes.ComprobantesListaQuery1
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleComprobantesListaXML, tdo_Id, dtd_Id, cob_Serie, cob_Numero, idpersona, desde, hasta, tdo_IdBuscar, dtd_IdBuscar, fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MaintenanceDelete(ByVal item As BE.Comprobantes) As Object Implements IBCComprobantes.MaintenanceDelete
            Try
                Dim rep = ContainerService.Resolve(Of DA.IComprobantesRepositorio)()
                Return rep.MaintenanceDelete(item)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function SPDetalleComprobantes(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String) As Object Implements IBCComprobantes.SPDetalleComprobantes

            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPDetalleComprobantes, cct_Id, tdo_Id, dtd_Id, cob_Serie, cob_Numero)
                    Scope.Complete()

                End Using

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
'    Public Class BCAsientosManuales
'        Implements IBCAsientosManuales

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil

'        Public Function AsientosManualesQuery(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String) As Object Implements IBCAsientosManuales.AsientosManualesQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPAsientosManualesSelectXML, lib_Id, prd_Periodo_id, asm_NumeroVoucher)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function AsientosManualesSeek(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String) As Object Implements IBCAsientosManuales.AsientosManualesSeek
'            Dim result As BE.AsientosManuales = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IAsientosManualesRepositorio)()
'                result = rep.GetById(lib_Id, prd_Periodo_id, asm_NumeroVoucher)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.AsientosManuales) As Object Implements IBCAsientosManuales.Maintenance
'            Dim x As Integer = 0
'            Try
'                Dim repCAB = ContainerService.Resolve(Of DA.IAsientosManualesRepositorio)()
'                Dim repDET = ContainerService.Resolve(Of DA.IDetalleAsientosManualesRepositorio)()
'                Dim sCorrelativo As String = Nothing
'                ' Using Scope As New System.Transactions.TransactionScope

'                If (item.ChangeTracker.State = ObjectState.Added) Then
'                    sCorrelativo = BCUtil.GetId("Con.AsientosManuales", "asm_NumeroVoucher", 6, " where lib_Id='" & item.lib_Id & "' and prd_Periodo_id='" & item.prd_Periodo_id & "' ")
'                    item.asm_NumeroVoucher = sCorrelativo
'                End If
'                Dim listaDET As New List(Of DetalleAsientosManuales)

'                For Each RowDET In item.DetalleAsientosManuales
'                    Dim NewDET As New BE.DetalleAsientosManuales

'                    NewDET = RowDET.Clone

'                    NewDET.asm_NumeroVoucher = item.asm_NumeroVoucher

'                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
'                        If (Val(NewDET.dam_Item) > x) Then
'                            x = Val(NewDET.dam_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
'                        End If

'                    End If
'                    listaDET.Add(NewDET)

'                Next
'                item.ChangeTracker.ChangeTrackingEnabled = False
'                item.DetalleAsientosManuales = Nothing
'                item.ChangeTracker.ChangeTrackingEnabled = True

'                repCAB.Maintenance(item)
'                'Dim i As Integer = 0
'                For Each mItemIngreso As BE.DetalleAsientosManuales In listaDET

'                    x += 1
'                    If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
'                        mItemIngreso.dam_Item = Right("0000" & x.ToString(), 3)
'                    End If

'                    mItemIngreso.asm_NumeroVoucher = item.asm_NumeroVoucher
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
'    End Class

'End Namespace

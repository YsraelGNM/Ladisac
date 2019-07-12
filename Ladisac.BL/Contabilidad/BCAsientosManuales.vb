Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCAsientosManuales
        Implements IBCAsientosManuales


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Public Function AsientosManualesQuery(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String) As Object Implements IBCAsientosManuales.AsientosManualesQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPAsientosManualesSelectXML, lib_Id, prd_Periodo_id, asm_NumeroVoucher)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function AsientosManualesSeek(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String) As Object Implements IBCAsientosManuales.AsientosManualesSeek
            Dim result As BE.AsientosManuales = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IAsientosManualesRepositorio)()
                result = rep.GetById(lib_Id, prd_Periodo_id, asm_NumeroVoucher)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.AsientosManuales) As Object Implements IBCAsientosManuales.Maintenance
            Dim x As Integer = 0
            Try
                Dim repCAB = ContainerService.Resolve(Of DA.IAsientosManualesRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleAsientosManualesRepositorio)()
                Dim sCorrelativo As String = Nothing
                ' Using Scope As New System.Transactions.TransactionScope

                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("Con.AsientosManuales", "asm_NumeroVoucher", 6, " where lib_Id='" & item.lib_Id & "' and prd_Periodo_id='" & item.prd_Periodo_id & "' ")
                    item.asm_NumeroVoucher = sCorrelativo
                End If

                Dim listaDET As New List(Of DetalleAsientosManuales)

                For Each RowDET In item.DetalleAsientosManuales
                    Dim NewDET As New BE.DetalleAsientosManuales

                    NewDET = RowDET.Clone

                    NewDET.asm_NumeroVoucher = item.asm_NumeroVoucher

                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.dam_Item) > x) Then
                            x = Val(NewDET.dam_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If
                    listaDET.Add(NewDET)

                Next
                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleAsientosManuales = Nothing
                item.LibrosContables = Nothing
                item.Periodo = Nothing

                item.ChangeTracker.ChangeTrackingEnabled = True
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 20, 0))



                    repCAB.Maintenance(item)
                    Dim dtd_idRef, tdo_idRef As String
                    Dim dtd_id, tdo_id, cct_Id As String
                    For Each mItemIngreso As BE.DetalleAsientosManuales In listaDET


                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                       
                        dtd_idRef = mItemIngreso.dtd_IdRef
                        tdo_idRef = mItemIngreso.tdo_IdRef
                        dtd_id = mItemIngreso.dtd_IdDoc
                        tdo_id = mItemIngreso.tdo_IdDoc
                        cct_Id = mItemIngreso.cct_Id
                        mItemIngreso.DetalleTipoDocumentos = Nothing

                        mItemIngreso.CentroCostos = Nothing
                        mItemIngreso.ClaseCuenta = Nothing
                        mItemIngreso.CuentasContables = Nothing
                        mItemIngreso.DetalleTipoDocumentos1 = Nothing
                        mItemIngreso.CtaCte = Nothing

                        ' mItemIngreso.RolOpeCtaCte = Nothing


                        mItemIngreso.Personas = Nothing
                        mItemIngreso.Moneda = Nothing
                        mItemIngreso.Usuarios = Nothing

                        mItemIngreso.dtd_IdRef = dtd_idRef
                        mItemIngreso.tdo_IdRef = tdo_idRef
                        mItemIngreso.dtd_IdDoc = dtd_id
                        mItemIngreso.tdo_IdDoc = tdo_id

                        mItemIngreso.cct_Id = cct_Id

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True

                        x += 1
                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngreso.dam_Item = Right("0000" & x.ToString(), 3)
                        End If

                        mItemIngreso.asm_NumeroVoucher = item.asm_NumeroVoucher
                        repDET.Maintenance(mItemIngreso)

                    Next


                    Scope.Complete()
                End Using

                Return True
            Catch ex As Exception

                '    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                '    If (rethrow) Then
                '        Throw
                '    End If

                MsgBox(ex.Message)
            End Try

            Return False
        End Function

        Public Function MaintenanceDelete(ByVal item As BE.AsientosManuales) As Object Implements IBCAsientosManuales.MaintenanceDelete
            Try
                Dim rep = ContainerService.Resolve(Of DA.IAsientosManualesRepositorio)()
                Return rep.MaintenanceDelete(item)
            Catch ex As Exception
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
                MsgBox(ex.Message)
            End Try
            Return False
        End Function
    End Class

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Class BCGrupoTrabajo
'        Implements IBCGrupoTrabajo
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil

'        Public Function GrupoTrabajoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal usuario As String = Nothing) As Object Implements IBCGrupoTrabajo.GrupoTrabajoQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPGrupoTrabajoSelectXML, desde, hasta, usuario)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result

'        End Function

'        Public Function GrupoTrabajoSeek(ByVal numero As String, ByVal periodo As String) As Object Implements IBCGrupoTrabajo.GrupoTrabajoSeek
'            Dim result As BE.GrupoTrabajo = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IGrupoTrabajoRepositorio)()
'                result = rep.GetById(periodo, numero)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.GrupoTrabajo) As Object Implements IBCGrupoTrabajo.Maintenance
'            Dim x As Integer = 0
'            Try
'                Dim repCAB = ContainerService.Resolve(Of DA.GrupoTrabajoRepositorio)()
'                Dim repDET = ContainerService.Resolve(Of DA.IDetalleGrupoTrabajoRepositorio)()
'                Dim sCorrelativo As String = Nothing
'                ' Using Scope As New System.Transactions.TransactionScope

'                If (item.ChangeTracker.State = ObjectState.Added) Then
'                    sCorrelativo = BCUtil.GetId("pla.GrupoTrabajo", "grt_NumeroProd", 10, " where prd_Periodo_id='" & item.prd_Periodo_id & "'")
'                    item.grt_NumeroProd = sCorrelativo
'                End If
'                Dim listaDET As New List(Of DetalleGrupoTrabajo)

'                For Each RowDET In item.DetalleGrupoTrabajo
'                    Dim NewDET As New DetalleGrupoTrabajo
'                    NewDET = RowDET.Close
'                    NewDET.grt_NumeroProd = item.grt_NumeroProd
'                    NewDET.prd_Periodo_id = item.prd_Periodo_id
'                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
'                        If (Val(NewDET.dgt_Item) > x) Then
'                            x = Val(NewDET.dgt_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
'                        End If

'                    End If
'                    listaDET.Add(NewDET)


'                Next
'                item.ChangeTracker.ChangeTrackingEnabled = False
'                item.DetalleGrupoTrabajo = Nothing
'                item.ChangeTracker.ChangeTrackingEnabled = True
'                repCAB.Maintenance(item)
'                For Each mItemIngreso In listaDET
'                    x += 1
'                    If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
'                        mItemIngreso.dgt_Item = Right("0000" & x.ToString(), 3)
'                    End If

'                    mItemIngreso.grt_NumeroProd = item.grt_NumeroProd
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


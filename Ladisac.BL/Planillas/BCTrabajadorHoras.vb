Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCTrabajadorHoras
        Implements IBCTrabajadorHoras

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil


        Public Function Maintenance(ByVal item As BE.TrabajadorHoras) As Object Implements IBCTrabajadorHoras.Maintenance

            Dim x As Integer = 0

            Try
                Dim repCAB = ContainerService.Resolve(Of DA.ITrabajadorHorasRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleTrabajadorHorasRepositorio)()
                Dim sCorrelativo As String = Nothing


                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.TrabajadorHoras", "trh_Numero", 10, " where tit_TipoTrab_Id='" & item.tit_TipoTrab_Id & "' ")
                    item.trh_Numero = sCorrelativo
                End If
                Dim listaDET As New List(Of BE.DetalleTrabajadorHoras)

                For Each RowDET In item.DetalleTrabajadorHoras
                    Dim NewDET As New BE.DetalleTrabajadorHoras
                    NewDET = RowDET.Clone
                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.trh_Item) > x) Then
                            x = Val(NewDET.trh_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If
                    listaDET.Add(NewDET)

                Next
                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleTrabajadorHoras = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True

                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 10, 0))

                    repCAB.Maintenance(item)

                    For Each mItemIngreso In listaDET
                        x += 1
                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngreso.trh_Item = Right("0000" & x.ToString(), 4)
                        End If
                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                        '  mItemIngreso.TrabajadorHoras = Nothing
                        mItemIngreso.Personas = Nothing
                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True

                        mItemIngreso.trh_Numero = item.trh_Numero
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

        Public Function TrabajadorHorasQuery(ByVal numero As String, ByVal desdesFecha As Date, ByVal hastaFecha As Date, ByVal observaciones As String) As Object Implements IBCTrabajadorHoras.TrabajadorHorasQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTrabajadorHorasSelectXML, numero, desdesFecha, hastaFecha, observaciones)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result


        End Function

        Public Function TrabajadorHorasSeek(ByVal tipoTrabajador As String, ByVal numero As String) As BE.TrabajadorHoras Implements IBCTrabajadorHoras.TrabajadorHorasSeek
            Dim result As BE.TrabajadorHoras = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITrabajadorHorasRepositorio)()
                result = rep.GetById(tipoTrabajador, numero)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SPDetalleTrabajadorHorasMaintenanceSelect(ByVal tipoTrabajador As String, ByVal numero As String) As System.Data.DataTable Implements IBCTrabajadorHoras.SPDetalleTrabajadorHorasMaintenanceSelect
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleTrabajadorHorasMaintenanceSelect, tipoTrabajador, numero)

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
'    Public Class BCPermisosTrabajador
'        Implements IBCPermisosTrabajador

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil

'        Public Function Maintenance(ByVal item As BE.PermisosTrabajador) As Object Implements IBCPermisosTrabajador.Maintenance
'            Dim x As Integer = 0
'            Try
'                Dim repCAB = ContainerService.Resolve(Of DA.IPermisosTrabajadorRepositorio)()
'                Dim repDET = ContainerService.Resolve(Of DA.IDetallePermisosTrabajadorRepositorio)()
'                Dim sCorrelativo As String = Nothing
'                ' Using Scope As New System.Transactions.TransactionScope

'                If (item.ChangeTracker.State = ObjectState.Added) Then
'                    sCorrelativo = BCUtil.GetId("pla.PermisosTrabajador", "prm_Numero", 10)
'                    item.prm_Numero = sCorrelativo
'                End If
'                Dim listaDET As New List(Of DetallePermisosTrabajador)

'                For Each RowDET In item.DetallePermisosTrabajador
'                    Dim NewDET As New DetallePermisosTrabajador
'                    NewDET = RowDET.Clone
'                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
'                        If (Val(NewDET.dper_Item) > x) Then
'                            x = Val(NewDET.dper_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
'                        End If

'                    End If
'                    listaDET.Add(NewDET)


'                Next
'                item.ChangeTracker.ChangeTrackingEnabled = False
'                item.DetallePermisosTrabajador = Nothing
'                item.ChangeTracker.ChangeTrackingEnabled = True
'                repCAB.Maintenance(item)

'                For Each mItemIngreso In listaDET
'                    x += 1
'                    If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
'                        mItemIngreso.dper_Item = Right("0000" & x.ToString(), 3)
'                    End If

'                    mItemIngreso.prm_Numero = item.prm_Numero
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

'        Public Function PermisosTrabajadorQuery(ByVal numero As String, ByVal persona As String, ByVal codigo As String) As Object Implements IBCPermisosTrabajador.PermisosTrabajadorQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPPermisosTrabajadorSelectXML, numero, persona, codigo)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function PermisosTrabajadorSeek(ByVal numero As String) As Object Implements IBCPermisosTrabajador.PermisosTrabajadorSeek
'            Dim result As BE.PermisosTrabajador = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IPermisosTrabajadorRepositorio)()
'                result = rep.GetbyId(numero)

'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function
'    End Class


'End Namespace

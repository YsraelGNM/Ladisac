Imports Ladisac.BE


Namespace Ladisac.BL

    Public Class BCComedor
        Implements IBCComedor

        'ff
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil



        Public Function ComedorSeek(ByVal numero As String) As Object Implements IBCComedor.ComedorSeek
            Dim result As BE.ComedorPLL = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IComedorRepositorio)()
                result = rep.getById(numero)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.ComedorPLL) As Object Implements IBCComedor.Maintenance
            Dim iper As String = 0
            Dim x As Integer
            Try
                Dim repCAB = ContainerService.Resolve(Of DA.IComedorRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleComedorRepositorio)()
                Dim sCorrelativo As String = Nothing


                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.ComedorPLL", "com_Numero", 10)
                    item.com_Numero = sCorrelativo
                End If

                Dim listaDET As New List(Of DetalleComedorPLL)

                For Each RowDET In item.DetalleComedorPLL
                    Dim NewDET As New DetalleComedorPLL
                    NewDET = RowDET.Clone

                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.deco_Item) > x) Then
                            x = Val(NewDET.deco_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If


                    listaDET.Add(NewDET)


                Next
                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleComedorPLL = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True

                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 10, 0))

                    repCAB.Maintenance(item)

                    For Each mItemIngreso In listaDET

                        x += 1
                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngreso.deco_Item = Right("0000" & x.ToString(), 4)
                        End If

                        mItemIngreso.com_Numero = item.com_Numero
                        iper = mItemIngreso.per_id


                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                        ' mItemIngreso.ComedorPLL = Nothing
                        mItemIngreso.Personas = Nothing

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True
                        mItemIngreso.per_id = iper

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

        Public Function ComedorQuery(ByVal numero As String, ByVal observaciones As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCComedor.ComedorQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPComedorPLLSelectXML, numero, observaciones, fechaDesde, fechaHasta)
            Catch ex As Exception
                Dim rethorw = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethorw) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MaintenanceDelete(ByVal item As BE.ComedorPLL) As Object Implements IBCComedor.MaintenanceDelete
            Try
                Dim rep = ContainerService.Resolve(Of DA.IComedorRepositorio)()
                Return rep.MaintenanceDelete(item)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function spDetalleComedorMaintenanceSelect(ByVal numero As String) As Object Implements IBCComedor.spDetalleComedorMaintenanceSelect
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spDetalleComedorMaintenanceSelect, numero)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function spDetallePrestamoSelect(ByVal FechaFin As Date) As Object Implements IBCComedor.spDetallePrestamoSelect
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spDetallePrestamoSelect, FechaFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub ImportarDescuentoComedor() Implements IBCComedor.ImportarDescuentoComedor
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                rep.EjecutarReporte("pla.spDetalleComedorDescuento")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function spListaDetalleComedorDescuento(ByVal FecIni As Date, ByVal FecFin As Date) As System.Data.DataTable Implements IBCComedor.spListaDetalleComedorDescuento
            Dim result As New DataTable
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("pla.spListaDetalleComedorDescuento", FecIni, FecFin)
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

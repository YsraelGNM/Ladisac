Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetalleDespachos
        Implements IBCDetalleDespachos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro
        Public Function Mantenimiento(ByVal Item As BE.DetalleDespachos) As Short Implements IBCDetalleDespachos.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleDespachosRepositorio)()
                'Using Scope As New System.Transactions.TransactionScope()
                If Item.ChangeTracker.State <> ObjectState.Deleted Then
                    If Item.ProcesarVerificarDatos() = 0 Then
                        Mantenimiento = 0
                        Exit Function
                    End If
                End If
                Mantenimiento = rep.Maintenance(Item)
                '    Scope.Complete()
                'End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Item.vMensajeError = ex.Message
                Else
                    Item.vMensajeError = ex.InnerException.Message
                End If
                Mantenimiento = 0
            End Try
        End Function

        Public Function DeleteRegistro(ByVal item As BE.DetalleDespachos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDE_SERIE As String, ByVal cDDE_NUMERO As String, ByVal cDDE_ITEM As Int16) As Short Implements IBCDetalleDespachos.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleDespachosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cTDO_ID, cDTD_ID, cDDE_SERIE, cDDE_NUMERO, cDDE_ITEM)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    item.vMensajeError = ex.Message
                Else
                    item.vMensajeError = ex.InnerException.Message
                End If
                DeleteRegistro = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal Orm As DetalleDespachos) As Short Implements IBCDetalleDespachos.spActualizarRegistro
            'Using Scope As New System.Transactions.TransactionScope()
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleDespachosRepositorio)()
                rep.spActualizarRegistro(Orm)
                'Scope.Complete()
                spActualizarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If

                'Scope.Dispose()
                spActualizarRegistro = 0
            End Try
            'End Using
        End Function

        Public Function spEliminarRegistro(ByVal Orm As DetalleDespachos) As Short Implements IBCDetalleDespachos.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleDespachosRepositorio)()
                    rep.spEliminarRegistro(Orm)
                    Scope.Complete()
                    spEliminarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        Orm.vMensajeError = ex.Message
                    Else
                        Orm.vMensajeError = ex.InnerException.Message
                    End If

                    Scope.Dispose()
                    spEliminarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spinsertarRegistro(ByVal Orm As DetalleDespachos) As Short Implements IBCDetalleDespachos.spinsertarRegistro
            'Using Scope As New System.Transactions.TransactionScope()
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleDespachosRepositorio)()
                rep.spInsertarRegistro(Orm)
                'Scope.Complete()
                spinsertarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If

                'Scope.Dispose()
                spinsertarRegistro = 0
            End Try
            'End Using
        End Function

        Public Function ItemDetalleDespachos(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDde_Serie As String, ByVal cDde_Numero As String) As Integer Implements IBCDetalleDespachos.ItemDetalleDespachos
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spItemDetalleDespachosXML, cTdo_Id, cDtd_Id, cDde_Serie, cDde_Numero))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEnteroXML(sr, "item")
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

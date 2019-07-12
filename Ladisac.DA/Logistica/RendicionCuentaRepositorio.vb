Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class RendicionCuentaRepositorio
        Implements IRendicionCuentaRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function GetById(ByVal REC_ID As Integer) As BE.RendicionCuenta Implements IRendicionCuentaRepositorio.GetById
            Dim result As RendicionCuenta = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.RendicionCuenta.Include("RendicionCuentaDetalle.Articulos.UnidadMedidaArticulos").Include("RendicionCuentaDetalle.Personas.DocPersonas").Include("RendicionCuentaDetalle.Moneda").Include("RendicionCuentaDetalle.Almacen").Include("RendicionCuentaDetalle.DetalleTipoDocumentos") Where c.REC_ID = REC_ID Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaRendicionCuenta() As String Implements IRendicionCuentaRepositorio.ListaRendicionCuenta
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaRendicionCuenta")
                Dim reader = context.ExecuteReader(cmd)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                result = sb.ToString()

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal RendicionCuenta As BE.RendicionCuenta) Implements IRendicionCuentaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                If RendicionCuenta.ChangeTracker.State = ObjectState.Deleted Then
                    For Each mRemov In RendicionCuenta.ChangeTracker.ObjectsRemovedFromCollectionProperties
                        For Each mRem In mRemov.Value
                            Dim mP As Integer = mRem.PCD_ID
                            Dim mPCD As ProcesoCompraDetalle = Nothing
                            mPCD = (From c In context.ProcesoCompraDetalle Where c.PCD_ID = mP Select c).FirstOrDefault
                            mPCD.MarkAsDeleted()
                            context.ProcesoCompraDetalle.ApplyChanges(mPCD)
                            mPCD.AcceptChanges()
                        Next
                    Next
                End If
                context.RendicionCuenta.ApplyChanges(RendicionCuenta)
                context.SaveChanges()
                RendicionCuenta.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



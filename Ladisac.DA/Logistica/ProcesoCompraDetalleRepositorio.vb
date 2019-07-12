Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ProcesoCompraDetalleRepositorio
        Implements IProcesoCompraDetalleRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal PCD_ID As Integer) As BE.ProcesoCompraDetalle Implements IProcesoCompraDetalleRepositorio.GetById
            Dim result As ProcesoCompraDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ProcesoCompraDetalle.Include("Articulos.UnidadMedidaArticulos") Where c.PCD_ID = PCD_ID Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaProcesoCompraDetalle() As String Implements IProcesoCompraDetalleRepositorio.ListaProcesoCompraDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaProcesoCompraDetalle")
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

        Public Sub Maintenance(ByVal ProcesoCompraDetalle As BE.ProcesoCompraDetalle) Implements IProcesoCompraDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ProcesoCompraDetalle.ApplyChanges(ProcesoCompraDetalle)
                context.SaveChanges()
                ProcesoCompraDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetById2(ByVal OCD_ID As Integer) As BE.ProcesoCompraDetalle Implements IProcesoCompraDetalleRepositorio.GetById2
            Dim result As ProcesoCompraDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ProcesoCompraDetalle.Include("Articulos.UnidadMedidaArticulos") Where c.OCD_ID = OCD_ID Select c).FirstOrDefault
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



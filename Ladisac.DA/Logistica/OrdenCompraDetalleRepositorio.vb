Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class OrdenCompraDetalleRepositorio
        Implements IOrdenCompraDetalleRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal OCD_Id As Integer) As OrdenCompraDetalle Implements IOrdenCompraDetalleRepositorio.GetById
            Dim result As OrdenCompraDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.OrdenCompraDetalle.Include("Articulos.UnidadMedidaArticulos") Where c.OCD_ID = OCD_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal OrdenCompraDetalle As BE.OrdenCompraDetalle) Implements IOrdenCompraDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.OrdenCompraDetalle.ApplyChanges(OrdenCompraDetalle)
                context.SaveChanges()
                OrdenCompraDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaOrdenCompraDetalle() As String Implements IOrdenCompraDetalleRepositorio.ListaOrdenCompraDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenCompraDetalle")
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
    End Class

End Namespace



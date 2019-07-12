Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class OrdenRequerimientoDetalleRepositorio
        Implements IOrdenRequerimientoDetalleRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal ORD_Id As Integer) As OrdenRequerimientoDetalle Implements IOrdenRequerimientoDetalleRepositorio.GetById
            Dim result As OrdenRequerimientoDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.OrdenRequerimientoDetalle.Include("Articulos.UnidadMedidaArticulos").Include("Entidad.UnidadesTransporte.Personas").Include("OrdenTrabajo.Mantto") Where c.ORD_ID = ORD_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal OrdenRequerimientoDetalle As BE.OrdenRequerimientoDetalle) Implements IOrdenRequerimientoDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.OrdenRequerimientoDetalle.ApplyChanges(OrdenRequerimientoDetalle)
                context.SaveChanges()
                OrdenRequerimientoDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaOrdenRequerimientoDetalle() As String Implements IOrdenRequerimientoDetalleRepositorio.ListaOrdenRequerimientoDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenRequerimientoDetalle")
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



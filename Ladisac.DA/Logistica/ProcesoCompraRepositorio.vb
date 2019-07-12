Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ProcesoCompraRepositorio
        Implements IProcesoCompraRepositorio

        <Dependency()> _
                Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal PRC_ID As Integer) As BE.ProcesoCompra Implements IProcesoCompraRepositorio.GetById
            Dim result As ProcesoCompra = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ProcesoCompra.Include("ProcesoCompraDetalle.PCDCotizacionDetalle.Personas").Include("ProcesoCompraDetalle.Articulos.UnidadMedidaArticulos") Where c.PRC_ID = PRC_ID Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaProcesoCompra(ByVal USU_ID As String) As String Implements IProcesoCompraRepositorio.ListaProcesoCompra
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaORSCAComprar", USU_ID)

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

        Public Sub Maintenance(ByVal ProcesoCompra As BE.ProcesoCompra) Implements IProcesoCompraRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ProcesoCompra.ApplyChanges(ProcesoCompra)
                context.SaveChanges()
                ProcesoCompra.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

    End Class

End Namespace



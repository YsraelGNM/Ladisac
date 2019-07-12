Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class SolicitudCompraDetalleRepositorio
        Implements ISolicitudCompraDetalleRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        
        Public Function GetById(ByVal SCD_ID As Integer) As BE.SolicitudCompraDetalle Implements ISolicitudCompraDetalleRepositorio.GetById
            Dim result As SolicitudCompraDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.SolicitudCompraDetalle.Include("Articulos.UnidadMedidaArticulos") Where c.SCD_ID = SCD_ID Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSolicitudCompraDetalle() As String Implements ISolicitudCompraDetalleRepositorio.ListaSolicitudCompraDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaSolicitudCompraDetalle")
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

        Public Sub Maintenance(ByVal SolicitudCompraDetalle As BE.SolicitudCompraDetalle) Implements ISolicitudCompraDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.SolicitudCompraDetalle.ApplyChanges(SolicitudCompraDetalle)
                context.SaveChanges()
                SolicitudCompraDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



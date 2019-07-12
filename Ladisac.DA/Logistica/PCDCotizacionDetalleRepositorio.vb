Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class PCDCotizacionDetalleRepositorio
        Implements IPCDCotizacionDetalleRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal CCD_ID As Integer) As BE.PCDCotizacionDetalle Implements IPCDCotizacionDetalleRepositorio.GetById
            Dim result As PCDCotizacionDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.PCDCotizacionDetalle.Include("Personas") Where c.CCD_ID = CCD_ID Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaPCDCotizacionDetalle() As String Implements IPCDCotizacionDetalleRepositorio.ListaPCDCotizacionDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaPCDCotizacionDetalle")
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

        Public Sub Maintenance(ByVal PCDCotizacionDetalle As BE.PCDCotizacionDetalle) Implements IPCDCotizacionDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.PCDCotizacionDetalle.ApplyChanges(PCDCotizacionDetalle)
                context.SaveChanges()
                PCDCotizacionDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



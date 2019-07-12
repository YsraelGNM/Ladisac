Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ControlDescargaRumaDetalleRepositorio
        Implements IControlDescargaRumaDetalleRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal DRD_Id As Integer) As BE.ControlDescargaRumaDetalle Implements IControlDescargaRumaDetalleRepositorio.GetById
            Dim result As ControlDescargaRumaDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlDescargaRumaDetalle Where c.DRD_ID = DRD_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlDescargaRumaDetalle() As String Implements IControlDescargaRumaDetalleRepositorio.ListaControlDescargaRumaDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlDescargaRumaDetalle")
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

        Public Sub Maintenance(ByVal ControlDescargaRumaDetalle As BE.ControlDescargaRumaDetalle) Implements IControlDescargaRumaDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlDescargaRumaDetalle.ApplyChanges(ControlDescargaRumaDetalle)
                context.SaveChanges()
                ControlDescargaRumaDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



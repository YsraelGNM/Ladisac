Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ControlParadamoldeDetalleRepositorio
        Implements IControlParadaMoldeDetalleRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal DPM_Id As Integer) As BE.ControlParadaMoldeDetalle Implements IControlParadaMoldeDetalleRepositorio.GetById
            Dim result As ControlParadaMoldeDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlParadaMoldeDetalle Where c.DPM_ID = DPM_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlParadaMoldeDetalle() As String Implements IControlParadaMoldeDetalleRepositorio.ListaControlParadaMoldeDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlParadaMoldeDetalle")
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

        Public Sub Maintenance(ByVal ControlParadaMoldeDetalle As BE.ControlParadaMoldeDetalle) Implements IControlParadaMoldeDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlParadaMoldeDetalle.ApplyChanges(ControlParadaMoldeDetalle)
                context.SaveChanges()
                ControlParadaMoldeDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



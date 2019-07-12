Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class RegistroEquipoRepositorio
        Implements IRegistroEquipoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal REQ_Id As Integer) As BE.RegistroEquipo Implements IRegistroEquipoRepositorio.GetById
            Dim result As RegistroEquipo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.RegistroEquipo.Include("UbicacionTrabajo").Include("SalidaCombustible").Include("Personas").Include("Entidad").Include("RegistroEquipoDetalle.Area").Include("RegistroEquipoDetalle.Tarea").Include("Produccion.Ladrillo.Articulos").Include("RegistroEquipoDetalle.Cancha") Where c.REQ_ID = REQ_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaRegistroEquipo() As String Implements IRegistroEquipoRepositorio.ListaRegistroEquipo
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaRegistroEquipo")
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

        Public Sub Maintenance(ByVal RegistroEquipo As BE.RegistroEquipo) Implements IRegistroEquipoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.RegistroEquipo.ApplyChanges(RegistroEquipo)
                context.SaveChanges()
                RegistroEquipo.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



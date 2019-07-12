Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class OrdensalidaRepositorio
        Implements IOrdenSalidaRepositorio

        <Dependency()> _
Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal OSA_Id As Integer) As BE.OrdenSalida Implements IOrdenSalidaRepositorio.GetById
            Dim result As OrdenSalida = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.OrdenSalida.Include("OrdenSalidaDetalle.Articulos.UnidadMedidaArticulos").Include("Personas.DocPersonas").Include("Personas.DireccionesPersonas").Include("Personas1.DocPersonas").Include("OrdenSalidaDetalle.Entidad") Where c.OSA_ID = OSA_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenSalida() As String Implements IOrdenSalidaRepositorio.ListaOrdenSalida
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenSalida")
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

        Public Sub Maintenance(ByVal OrdenSalida As BE.OrdenSalida) Implements IOrdenSalidaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.OrdenSalida.ApplyChanges(OrdenSalida)
                context.SaveChanges()
                OrdenSalida.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



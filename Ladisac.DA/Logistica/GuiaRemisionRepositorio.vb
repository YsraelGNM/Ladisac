Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class GuiaRemisionRepositorio
        Implements IGuiaRemisionRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal GUI_Id As Integer) As BE.GuiaRemision Implements IGuiaRemisionRepositorio.GetById
            Dim result As GuiaRemision = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.GuiaRemision.Include("GuiaRemisionDetalle.Articulos.UnidadMedidaArticulos").Include("Personas.DireccionesPersonas").Include("Personas.DocPersonas").Include("Personas1.DocPersonas").Include("Personas2").Include("Placas") Where c.GUI_ID = GUI_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaGuiaRemision() As String Implements IGuiaRemisionRepositorio.ListaGuiaRemision
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaGuiaRemision")
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

        Public Sub Maintenance(ByVal GuiaRemision As BE.GuiaRemision) Implements IGuiaRemisionRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.GuiaRemision.ApplyChanges(GuiaRemision)
                context.SaveChanges()
                GuiaRemision.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class FichaInspeccionRepositorio
        Implements IFichaInspeccionRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(FIN_Id As Integer) As BE.FichaInspeccion Implements IFichaInspeccionRepositorio.GetById
            Dim result As FichaInspeccion = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.FichaInspeccion.Include("EntidadInspeccion.Entidad").Include("EntidadInspeccion.Inspeccion.ComponenteInspeccion").Include("EntidadInspeccion.ParametroEntidad").Include("Personas").Include("FichaInspeccionDetalle") Where c.FIN_ID = FIN_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaFichaInspeccion() As String Implements IFichaInspeccionRepositorio.ListaFichaInspeccion
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaFichaInspeccion")
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

        Public Sub Maintenance(FichaInspeccion As BE.FichaInspeccion) Implements IFichaInspeccionRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.FichaInspeccion.ApplyChanges(FichaInspeccion)
                context.SaveChanges()
                FichaInspeccion.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



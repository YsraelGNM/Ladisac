Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class FichaInspeccionDetalleRepositorio
        Implements IFichaInspeccionDetalleRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(FID_Id As Integer) As BE.FichaInspeccionDetalle Implements IFichaInspeccionDetalleRepositorio.GetById
            Dim result As FichaInspeccionDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.FichaInspeccionDetalle Where c.FID_ID = FID_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaFichaInspeccionDetalle() As String Implements IFichaInspeccionDetalleRepositorio.ListaFichaInspeccionDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaFichaInspeccionDetalle")
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

        Public Sub Maintenance(FichaInspeccionDetalle As BE.FichaInspeccionDetalle) Implements IFichaInspeccionDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.FichaInspeccionDetalle.ApplyChanges(FichaInspeccionDetalle)
                context.SaveChanges()
                FichaInspeccionDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



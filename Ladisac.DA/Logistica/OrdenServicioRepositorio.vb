Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class OrdenServicioRepositorio
        Implements IOrdenServicioRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal OSE_Id As Integer) As OrdenServicio Implements IOrdenServicioRepositorio.GetById
            Dim result As OrdenServicio = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.OrdenServicio.Include("OrdenServicioDetalle.Articulos.UnidadMedidaArticulos").Include("Personas").Include("TipoVenta").Include("DetalleTipoDocumentos") Where c.OSE_ID = OSE_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenServicio() As String Implements IOrdenServicioRepositorio.ListaOrdenServicio
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenServicio")
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

        Public Sub Maintenance(ByVal OrdenServicio As OrdenServicio) Implements IOrdenServicioRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.OrdenServicio.ApplyChanges(OrdenServicio)
                context.SaveChanges()
                OrdenServicio.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaOrdenServicioID(ByVal OSE_ID As Integer?) As System.Data.DataSet Implements IOrdenServicioRepositorio.ListaOrdenServicioID
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenServicioID", OSE_ID)
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
    End Class

End Namespace



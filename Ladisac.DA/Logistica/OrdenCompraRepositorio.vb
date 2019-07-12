Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class OrdenCompraRepositorio
        Implements IOrdenCompraRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal OCO_Id As Integer) As OrdenCompra Implements IOrdenCompraRepositorio.GetById
            Dim result As OrdenCompra = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.OrdenCompra.Include("OrdenCompraDetalle.Articulos.UnidadMedidaArticulos").Include("Personas").Include("TipoVenta").Include("DetalleTipoDocumentos") Where c.OCO_ID = OCO_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenCompra() As String Implements IOrdenCompraRepositorio.ListaOrdenCompra
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenCompra")
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

        Public Sub Maintenance(ByVal OrdenCompra As OrdenCompra) Implements IOrdenCompraRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.OrdenCompra.ApplyChanges(OrdenCompra)
                context.SaveChanges()
                OrdenCompra.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaOrdenCompraID(ByVal OCO_ID As Integer?) As System.Data.DataSet Implements IOrdenCompraRepositorio.ListaOrdenCompraID
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenCompraID", OCO_ID)
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



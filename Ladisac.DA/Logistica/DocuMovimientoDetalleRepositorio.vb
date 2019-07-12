Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class DocuMovimientoDetalleRepositorio
        Implements IDocuMovimientoDetalleRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal DMD_Id As Integer) As DocuMovimientoDetalle Implements IDocuMovimientoDetalleRepositorio.GetById
            Dim result As DocuMovimientoDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DocuMovimientoDetalle.Include("Kardex").Include("Articulos.UnidadMedidaArticulos").Include("Almacen") Where c.DMD_ID = DMD_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal DocuMovimientoDetalle As BE.DocuMovimientoDetalle) Implements IDocuMovimientoDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DocuMovimientoDetalle.ApplyChanges(DocuMovimientoDetalle)
                context.SaveChanges()
                DocuMovimientoDetalle.AcceptChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaDocuMovimientoDetalle() As String Implements IDocuMovimientoDetalleRepositorio.ListaDocuMovimientoDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaDocuMovimientoDetalle")
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
    End Class

End Namespace



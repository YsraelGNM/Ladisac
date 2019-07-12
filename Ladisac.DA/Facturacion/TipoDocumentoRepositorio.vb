Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class TipoDocumentoRepositorio
        Implements ITipoDocumentoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal TDO_Id As String) As BE.TipoDocumentos Implements ITipoDocumentoRepositorio.GetById

        End Function

        Public Function ListaTipoDocumento() As String Implements ITipoDocumentoRepositorio.ListaTipoDocumento

        End Function

        Public Function Maintenance(ByVal item As BE.TipoDocumentos) As Short Implements ITipoDocumentoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.TipoDocumentos.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Maintenance = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Maintenance = 0
            End Try
        End Function
    End Class
End Namespace



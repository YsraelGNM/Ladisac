Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class DocumentoGuiasRepositorio
        Implements IDocumentoGuiasRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal DGU_Id As Integer) As BE.DocumentoGuias Implements IDocumentoGuiasRepositorio.GetById
            Dim result As DocumentoGuias = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DocumentoGuias.Include("DocumentoGuiasDetalle").Include("Personas") Where c.DGU_ID = DGU_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDocumentoGuias() As String Implements IDocumentoGuiasRepositorio.ListaDocumentoGuias
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaDocumentoGuias")
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

        Public Sub Maintenance(ByVal DocumentoGuias As BE.DocumentoGuias) Implements IDocumentoGuiasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DocumentoGuias.ApplyChanges(DocumentoGuias)
                context.SaveChanges()
                DocumentoGuias.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



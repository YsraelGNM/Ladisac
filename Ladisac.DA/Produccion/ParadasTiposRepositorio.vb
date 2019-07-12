Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ParadasTiposRepositorio
        Implements IParadasTiposRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub Maintenance(ByVal ParadasTipos As BE.ParadasTipos) Implements IParadasTiposRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ParadasTipos.ApplyChanges(ParadasTipos)
                context.SaveChanges()
                ParadasTipos.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

    End Class

End Namespace



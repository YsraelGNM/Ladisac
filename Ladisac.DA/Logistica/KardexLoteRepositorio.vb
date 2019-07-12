Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class KardexLoteRepositorio
        Implements IKardexLoteRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal KAL_Id As Integer) As BE.KardexLote Implements IKardexLoteRepositorio.GetById
            Dim result As KardexLote = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.KardexLote Where c.KAL_ID = KAL_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal KardexLote As BE.KardexLote) Implements IKardexLoteRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.KardexLote.ApplyChanges(KardexLote)
                context.SaveChanges()
                KardexLote.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetByIdDRU_ID(ByVal DRU_Id As Integer) As System.Collections.Generic.List(Of BE.KardexLote) Implements IKardexLoteRepositorio.GetByIdDRU_ID
            Dim result As List(Of KardexLote) = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.KardexLote Where c.DRU_ID = DRU_Id Select c).ToList
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



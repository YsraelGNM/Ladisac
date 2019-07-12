Imports Ladisac.BE
Imports Microsoft.Practices.Unity

Namespace Ladisac.DA

    Public Class TiposCargosRepositorio
        Implements ITiposCargosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal id As String) As BE.TiposCargos Implements ITiposCargosRepositorio.GetById
            Dim result As TiposCargos = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.TiposCargos Where c.tis_TipCargo_Id = id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal item As BE.TiposCargos) Implements ITiposCargosRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.TiposCargos.ApplyChanges(item)
                context.SaveChanges()

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub
    End Class

End Namespace

'Namespace Ladisac.DA
'    Public Class TiposContratosRepositorio
'        Implements ITiposContratosRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function GetById(ByVal id As String) As TiposContratos Implements ITiposContratosRepositorio.GetById
'            Dim result As TiposContratos = Nothing

'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.TiposContratos Where c.tic_TipoCont_Id = id Select c).FirstOrDefault
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try

'            Return result
'        End Function

'        Public Sub Mantenance(ByVal item As TiposContratos) Implements ITiposContratosRepositorio.Mantenance
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                context.TiposContratos.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'        End Sub
'    End Class

'End Namespace

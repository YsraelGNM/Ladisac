Imports Ladisac.BE
Imports Microsoft.Practices.Unity

Namespace Ladisac.DA

    Public Class TiposTrabajadorRepositorio
        Implements ITiposTrabajadorRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal id As String) As BE.TiposTrabajador Implements ITiposTrabajadorRepositorio.GetById
            Dim result As TiposTrabajador = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.TiposTrabajador Where c.tit_TipoTrab_Id = id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance1(ByVal item As BE.TiposTrabajador) As Boolean Implements ITiposTrabajadorRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.TiposTrabajador.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function

      
    End Class

End Namespace

'Imports Ladisac.BE
'Imports Microsoft.Practices.Unity

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
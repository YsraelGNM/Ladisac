Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA

    Public Class ConvenioDobleTributacionRepositorio
        Implements IConvenioDobleTributacionRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal id As String) As BE.ConvenioDobleTributacion Implements IConvenioDobleTributacionRepositorio.GetById
            Dim result As ConvenioDobleTributacion = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ConvenioDobleTributacion Where c.cod_DobleTribu_Id = id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.ConvenioDobleTributacion) As Boolean Implements IConvenioDobleTributacionRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ConvenioDobleTributacion.ApplyChanges(item)
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


'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Class NivelEducacionRepositorio
'        Implements INivelEducacionRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal id As String) As BE.NivelEducacion Implements INivelEducacionRepositorio.GetById
'            Dim result As NivelEducacion = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.NivelEducacion Where c.nie_NiveEduc_Id Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Mantenance(ByVal item As BE.NivelEducacion) As Boolean Implements INivelEducacionRepositorio.Mantenance
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                context.NivelEducacion.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()
'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return False
'        End Function
'    End Class

'End Namespace

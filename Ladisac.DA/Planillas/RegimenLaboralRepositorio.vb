Imports Ladisac.BE
Imports Microsoft.Practices.Unity
Namespace Ladisac.DA

    Public Class RegimenLaboralRepositorio
        Implements IRegimenLaboralRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal id As String) As BE.RegimenLaboral Implements IRegimenLaboralRepositorio.GetById
            Dim result As RegimenLaboral = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.RegimenLaboral Where c.rel_RegLaboral_Id = id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.RegimenLaboral) As Boolean Implements IRegimenLaboralRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.RegimenLaboral.ApplyChanges(item)
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

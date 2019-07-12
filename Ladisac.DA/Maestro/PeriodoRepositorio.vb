Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class PeriodoRepositorio
        Implements IPeriodoRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal id As String) As BE.Periodo Implements IPeriodoRepositorio.GetById
            Dim result As Periodo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of BE.LadisacEntities)()
                result = (From c In context.Periodo Where c.prd_Periodo_id = id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.Periodo) As Boolean Implements IPeriodoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of BE.LadisacEntities)()
                context.Periodo.ApplyChanges(item)
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



Imports Ladisac.BE
Imports Microsoft.Practices.Unity
Namespace Ladisac.DA

    Public Class CalendarioDiasRespositorio
        Implements ICalendarioDiasRespositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetbyId(ByVal id As Date) As BE.CalendarioDias Implements ICalendarioDiasRespositorio.GetbyId
            Dim result As CalendarioDias = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.CalendarioDias Where c.cadi_Fecha = id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.CalendarioDias) As Boolean Implements ICalendarioDiasRespositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.CalendarioDias.ApplyChanges(item)
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

'    Public Class AreaTrabajosRepositorio
'        Implements IAreaTrabajosRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal id As String) As BE.AreaTrabajos Implements IAreaTrabajosRepositorio.GetById
'            Dim result As AreaTrabajos = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From i In context.AreaTrabajos Where i.art_AreaTrab_Id = id Select i).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Mantenance(ByVal item As BE.AreaTrabajos) As Boolean Implements IAreaTrabajosRepositorio.Mantenance
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                context.AreaTrabajos.ApplyChanges(item)
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

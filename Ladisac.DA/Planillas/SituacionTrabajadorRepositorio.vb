Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Namespace Ladisac.DA


    Public Class SituacionTrabajadorRepositorio
        Implements ISituacionTrabajadorRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer



        Public Function GetById(ByVal id As String) As BE.SituacionTrabajador Implements ISituacionTrabajadorRepositorio.GetById
            Dim result As SituacionTrabajador = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.SituacionTrabajador Where c.sit_SituaTrab_Id = id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function ManTenance(ByVal item As BE.SituacionTrabajador) As Boolean Implements ISituacionTrabajadorRepositorio.ManTenance
            Try
                Dim Context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Context.SituacionTrabajador.ApplyChanges(item)
                Context.SaveChanges()
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


'    Public Class SituacionEspecialTrabajadorRepositorio
'        Implements ISituacionEspecialTrabajadorRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal id As String) As BE.SituacionEspecialTrabajador Implements ISituacionEspecialTrabajadorRepositorio.GetById
'            Dim result As SituacionEspecialTrabajador = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.SituacionEspecialTrabajador Where c.set_SituEspe_Id = id Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Mantenance(ByVal item As BE.SituacionEspecialTrabajador) As Boolean Implements ISituacionEspecialTrabajadorRepositorio.Mantenance
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                context.SituacionEspecialTrabajador.ApplyChanges(item)
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

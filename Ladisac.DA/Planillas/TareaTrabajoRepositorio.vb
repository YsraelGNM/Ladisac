Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Namespace Ladisac.DA

    Public Class TareaTrabajoRepositorio
        Implements DA.ITareaTrabajoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal tit_TipTarea_Id As String, ByVal ttr_TareaTrab_Id As String) As Object Implements ITareaTrabajoRepositorio.GetById

            Dim result As BE.TareaTrabajo = Nothing

            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.TareaTrabajo.Include("TiposTareaTrabajo").Include("Articulos") _
                          Where c.tit_TipTarea_Id = tit_TipTarea_Id _
                          And c.ttr_TareaTrab_Id = ttr_TareaTrab_Id _
                          Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function Mantenance(ByVal item As BE.TareaTrabajo) As Boolean Implements ITareaTrabajoRepositorio.Mantenance

            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                item.Articulos = Nothing
                item.TiposTareaTrabajo = Nothing
                context.TareaTrabajo.ApplyChanges(item)
                context.SaveChanges()
                context.AcceptAllChanges()
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


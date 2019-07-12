Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA

    Public Class ConceptosPlanillaRepositorio
        Implements IConceptosPlanillaRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String) As BE.ConceptosPlanilla Implements IConceptosPlanillaRepositorio.GetById

            Dim result As ConceptosPlanilla = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ConceptosPlanilla _
                          Where c.tit_TipoTrab_Id = tit_TipoTrab_Id And _
                          c.tip_TipoPlan_Id = tip_TipoPlan_Id And _
                          c.ItemConceptoPlanilla = ItemConceptoPlanilla).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.ConceptosPlanilla) As Boolean Implements IConceptosPlanillaRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ConceptosPlanilla.ApplyChanges(item)
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


'    Public Class SituacionTrabajadorRepositorio
'        Implements ISituacionTrabajadorRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer



'        Public Function GetById(ByVal id As String) As BE.SituacionTrabajador Implements ISituacionTrabajadorRepositorio.GetById
'            Dim result As SituacionTrabajador = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.SituacionTrabajador Where c.sit_SituaTrab_Id = id Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result

'        End Function

'        Public Function ManTenance(ByVal item As BE.SituacionTrabajador) As Boolean Implements ISituacionTrabajadorRepositorio.ManTenance
'            Try
'                Dim Context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                Context.SituacionTrabajador.ApplyChanges(item)
'                Context.SaveChanges()
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



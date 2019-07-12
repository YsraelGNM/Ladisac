Imports Ladisac.BE
Imports Microsoft.Practices.Unity

Namespace Ladisac.DA

    Public Class ConceptosTrabajadorRepositorio
        Implements IConceptosTrabajadorRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal per_Id As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String) As BE.ConceptosTrabajador Implements IConceptosTrabajadorRepositorio.GetById
            Dim result As ConceptosTrabajador = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.ConceptosTrabajador _
                         Where c.per_Id = per_Id _
                         And c.tic_TipoConcep_Id = tic_TipoConcep_Id _
                         And c.con_Conceptos_Id = con_Conceptos_Id).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.ConceptosTrabajador) As Object Implements IConceptosTrabajadorRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.ConceptosTrabajador.ApplyChanges(item)
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
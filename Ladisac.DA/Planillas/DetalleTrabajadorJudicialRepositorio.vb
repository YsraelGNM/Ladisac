Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class DetalleTrabajadorJudicialRepositorio
        Implements IDetalleTrabajadorJudicialRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String) As Object Implements IDetalleTrabajadorJudicialRepositorio.GetById
            Dim result As DetalleTrabajadorJudicial = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetalleTrabajadorJudicial _
                         Where c.tip_TipoPlan_Id = tip_TipoPlan_Id And _
                         c.dtj_SerieJudi = dtj_SerieJudi And _
                         c.dtj_NumeroJudi = dtj_NumeroJudi).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial) As Object Implements IDetalleTrabajadorJudicialRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetalleTrabajadorJudicial.ApplyChanges(item)
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
'Imports System.Text

'Namespace Ladisac.DA
'    Public Class DatosTrabajadorJudicialRepositorio
'        Implements IDatosTrabajadorJudicialRepositorio

'        <Dependency()> _
'        Public Property ContainserService As IUnityContainer


'        Public Function GetById(ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String) As BE.DatosTrabajadorJudicial Implements IDatosTrabajadorJudicialRepositorio.GetById
'            Dim result As DatosTrabajadorJudicial = Nothing
'            Try
'                Dim context = ContainserService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DatosTrabajadorJudicial _
'                          Where c.dtj_SerieJudi = dtj_SerieJudi And _
'                          c.dtj_NumeroJudi = dtj_NumeroJudi)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result


'        End Function

'        Public Function Maintenance(ByVal item As BE.DatosTrabajadorJudicial) As Object Implements IDatosTrabajadorJudicialRepositorio.Maintenance
'            Try
'                Dim context = ContainserService.Resolve(Of LadisacEntities)()
'                context.DatosTrabajadorJudicial.ApplyChanges(item)
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



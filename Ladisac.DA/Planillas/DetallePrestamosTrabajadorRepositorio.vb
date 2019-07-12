Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class DetallePrestamosTrabajadorRepositorio
        Implements IDetallePrestamosTrabajadorRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal serie As String, ByVal numero As String, ByVal item As String) As BE.DetallePrestamosTrabajador Implements IDetallePrestamosTrabajadorRepositorio.GetById
            Dim result As DetallePrestamosTrabajador = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetallePrestamosTrabajador _
                           Where c.prt_SeriePres = serie And c.prt_NumeroPres = numero And c.dpt_ItemPresta = item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.DetallePrestamosTrabajador) As Boolean Implements IDetallePrestamosTrabajadorRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetallePrestamosTrabajador.ApplyChanges(item)
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
'    Public Class DetalleTrabajadorJudicialRepositorio
'        Implements IDetalleTrabajadorJudicialRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function GetById(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String) As Object Implements IDetalleTrabajadorJudicialRepositorio.GetById
'            Dim result As DetalleTrabajadorJudicial = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DetalleTrabajadorJudicial _
'                         Where c.tip_TipoPlan_Id = tip_TipoPlan_Id And _
'                         c.dtj_SerieJudi = dtj_SerieJudi And _
'                         c.dtj_NumeroJudi = dtj_NumeroJudi).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial) As Object Implements IDetalleTrabajadorJudicialRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetalleTrabajadorJudicial.ApplyChanges(item)
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

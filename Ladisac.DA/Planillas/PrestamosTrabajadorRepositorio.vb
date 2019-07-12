Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text


Namespace Ladisac.DA
    Public Class PrestamosTrabajadorRepositorio
        Implements IPrestamosTrabajadorRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal serie As String, ByVal numero As String) As BE.PrestamosTrabajador Implements IPrestamosTrabajadorRepositorio.GetById
            Dim result As PrestamosTrabajador = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.PrestamosTrabajador.Include("Personas"). _
                          Include("Personas1"). _
                          Include("DetallePrestamosTrabajador"). _
                          Include("DetallePrestamosTrabajador.Conceptos"). _
                          Include("PuntoVenta").Include("Moneda") _
                          Where c.prt_SeriePres = serie And c.prt_NumeroPres = numero _
                          Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.PrestamosTrabajador) As Object Implements IPrestamosTrabajadorRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.PrestamosTrabajador.ApplyChanges(item)
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
'                result = (From c In context.DatosTrabajadorJudicial.Include("Personas").Include("Personas1").Include("DetalleTrabajadorJudicial.Conceptos").Include("DetalleTrabajadorJudicial.TiposPlanillas") _
'                           Where c.dtj_SerieJudi = dtj_SerieJudi And _
'                          c.dtj_NumeroJudi = dtj_NumeroJudi Select c).FirstOrDefault()

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


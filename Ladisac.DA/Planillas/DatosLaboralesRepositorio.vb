
Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Namespace Ladisac.DA

    Public Class DatosLaboralesRepositorio
        Implements IDatosLaboralesRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal per_Id As String) As BE.DatosLaborales Implements IDatosLaboralesRepositorio.GetById
            Dim result As BE.DatosLaborales = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DatosLaborales _
                          .Include("CronogramaVacaciones") _
                          .Include("CentroRiesgo") _
                          .Include("PeriodoLaboral") _
                          .Include("DatosLaboralesHorario") _
                          .Include("PeriodoLaboral.TiposContratos") _
                          .Include("AreaTrabajos") Where c.per_Id = per_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.DatosLaborales) As Boolean Implements IDatosLaboralesRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DatosLaborales.ApplyChanges(item)
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

        Public Function GetByCodTrabajador(ByVal Codigo As String) As BE.DatosLaborales Implements IDatosLaboralesRepositorio.GetByCodTrabajador
            Dim result As BE.DatosLaborales = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DatosLaborales _
                          .Include("CronogramaVacaciones") _
                          .Include("CentroRiesgo") _
                          .Include("PeriodoLaboral") _
                          .Include("DatosLaboralesHorario") _
                          .Include("PeriodoLaboral.TiposContratos") _
                          .Include("RegimenPensionario.DetalleConceptosPensionarios") _
                          .Include("Personas") Where c.dal_CodigoTrabajador = Codigo Select c).FirstOrDefault

                result.Personas = (From c In context.Personas Where c.PER_ID = result.per_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
    End Class
End Namespace


'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE

'Namespace Ladisac.DA

'    Public Class ConceptosPlanillaRepositorio
'        Implements IConceptosPlanillaRepositorio


'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String) As BE.ConceptosPlanilla Implements IConceptosPlanillaRepositorio.GetById

'            Dim result As ConceptosPlanilla = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.ConceptosPlanilla _
'                          Where c.tit_TipoTrab_Id = tit_TipoTrab_Id And _
'                          c.tip_TipoPlan_Id = tip_TipoPlan_Id And _
'                          c.ItemConceptoPlanilla = ItemConceptoPlanilla).FirstOrDefault
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Mantenance(ByVal item As BE.ConceptosPlanilla) As Boolean Implements IConceptosPlanillaRepositorio.Mantenance
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                context.ConceptosPlanilla.ApplyChanges(item)
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
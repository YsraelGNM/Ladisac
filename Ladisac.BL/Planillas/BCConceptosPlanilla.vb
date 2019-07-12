Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCConceptosPlanilla
        Implements IBCConceptosPlanilla

        <Dependency()> _
        Public Property ContainerService As IUnityContainer



        Public Function ConceptosPlanillasQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String) As Object Implements IBCConceptosPlanilla.ConceptosPlanillasQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPConceptosPlanillaSelectXML, tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla, cop_Descripcion)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.ConceptosPlanilla) As Object Implements IBCConceptosPlanilla.Mantenance
            Try
                Dim rep = ContainerService.Resolve(Of Ladisac.DA.IConceptosPlanillaRepositorio)()
                Return rep.Mantenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function ConceptosPlanillasDetalleQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String) As Object Implements IBCConceptosPlanilla.ConceptosPlanillasDetalleQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPConceptosPlanillaDetalleSelectXML, tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla, cop_Descripcion)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ConceptosPlanillaSeek(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String) As BE.ConceptosPlanilla Implements IBCConceptosPlanilla.ConceptosPlanillaSeek
            Dim result As ConceptosPlanilla = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IConceptosPlanillaRepositorio)()
                result = rep.GetById(tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function ConceptosXTipoPlanillaSelectXML(Optional ByVal tit_TipoTrab_Id As String = Nothing, Optional ByVal tip_TipoPlan_Id As String = Nothing, Optional ByVal ItemConceptoPlanilla As String = Nothing) As Object Implements IBCConceptosPlanilla.ConceptosXTipoPlanillaSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPConceptosXTipoPlanillaSelectXML, tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla)

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
'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Class BCSituacionTrabajador
'        Implements IBCSituacionTrabajador
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function Mantenance(ByVal item As BE.SituacionTrabajador) As Object Implements IBCSituacionTrabajador.Mantenance

'            Try
'                Dim rep = ContainerService.Resolve(Of Ladisac.DA.ISituacionTrabajadorRepositorio)()
'                Return rep.ManTenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function

'        Public Function SituacionTrabajadorQuery(ByVal sit_SituaTrab_Id As String, ByVal sit_Descripcion As String) As Object Implements IBCSituacionTrabajador.SituacionTrabajadorQuery
'            Dim result As String = Nothing

'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPSituacionTrabajadorSelectXML, sit_SituaTrab_Id, sit_Descripcion)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function SituacionTrabajadorSeek(ByVal id As String) As BE.SituacionTrabajador Implements IBCSituacionTrabajador.SituacionTrabajadorSeek
'            Dim result As SituacionTrabajador = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ISituacionTrabajadorRepositorio)()
'                result = rep.GetById(id)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'    End Class

'End Namespace
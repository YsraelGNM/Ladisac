Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCTiposContratos

        Implements IBCTiposContratos
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Sub Maintenance(ByVal item As BE.TiposContratos) Implements BL.IBCTiposContratos.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposContratosRepositorio)()
                rep.Mantenance(item)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TiposContratosQuery(ByVal tic_TipoCont_Id As String, ByVal tico_Descripcion As String) As Object Implements BL.IBCTiposContratos.TiposContratosQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTiposContratosSelectXML, tic_TipoCont_Id, tico_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function TiposContratosSeek(ByVal id As String) As BE.TiposContratos Implements BL.IBCTiposContratos.TiposContratosSeek
            Dim resault As TiposContratos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposContratosRepositorio)()
                resault = rep.GetById(id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return resault
        End Function
    End Class

End Namespace

'Option Strict On
'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Class BCConceptos
'        Implements IBCConceptos  
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function ConceptosQuery(Optional ByVal con_Conceptos_Id As String = Nothing, Optional ByVal tic_TipoConcep_Id As String = Nothing, Optional ByVal con_Conceptoas As String = Nothing, Optional ByVal con_Descripcion As String = Nothing) As String Implements IBCConceptos.ConceptosQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPConceptosSelectXML, con_Conceptos_Id, tic_TipoConcep_Id, con_Conceptoas, con_Descripcion)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function ConceptosSeek(ByVal conId As String) As BE.Conceptos Implements IBCConceptos.ConceptosSeek
'            Dim result As Conceptos = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IConceptosRepositorio)()
'                result = rep.GetById(conId)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Sub Maintenance(ByVal item As BE.Conceptos) Implements IBCConceptos.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IConceptosRepositorio)()

'                'rep.Load(New BE.Conceptos, DA.ConceptosExtend.TiposConcepto Or DA.ConceptosExtend.Otro)

'                rep.Maintenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'        End Sub


'    End Class
'End Namespace
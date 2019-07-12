Option Strict On
Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCConceptos
        Implements IBCConceptos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function ConceptosQuery(Optional ByVal con_Conceptos_Id As String = Nothing, Optional ByVal tic_TipoConcep_Id As String = Nothing, Optional ByVal con_Conceptoas As String = Nothing, Optional ByVal con_Descripcion As String = Nothing) As String Implements IBCConceptos.ConceptosQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPConceptosSelectXML, con_Conceptos_Id, tic_TipoConcep_Id, con_Conceptoas, con_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ConceptosSeek(ByVal tipo As String, ByVal codigoConcepto As String) As BE.Conceptos Implements IBCConceptos.ConceptosSeek
            Dim result As Conceptos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConceptosRepositorio)()
                result = rep.GetById(tipo, codigoConcepto)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal item As BE.Conceptos) Implements IBCConceptos.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConceptosRepositorio)()

                'rep.Load(New BE.Conceptos, DA.ConceptosExtend.TiposConcepto Or DA.ConceptosExtend.Otro)

                rep.Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub


        Public Sub spCrearFunctionAcumuladoConcepto(ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String, ByVal nombre As String) Implements IBCConceptos.spCrearFunctionAcumuladoConcepto
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spCrearFunctionAcumuladoConcepton, tic_TipoConcep_Id, con_Conceptos_Id, nombre)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub
    End Class
End Namespace

'Imports Ladisac.BE

'Namespace Ladisac.BL
'    Partial Public Class BCMaestro
'        Implements IBCMaestro

'        Implements IBCMaestroQueries


'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function MonedasQuery(Optional ByVal monId As String = Nothing) As String Implements IBCMaestroQueries.MonedasQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.MonedasQuery, monId)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function MonedasSeek(ByVal monId As String) As BE.Moneda Implements IBCMaestroQueries.MonedasSeek
'            Dim result As Moneda = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IMonedasRepositorio)()
'                result = rep.GetById(monId)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Sub MantenimientoMonedas(ByVal Item As BE.Moneda) Implements IBCMaestro.MantenimientoMonedas
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IMonedasRepositorio)()
'                rep.Maintenance(Item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'        End Sub

'        Public Sub MantenimientoMonedasDescripcion(ByVal id As String, ByVal descripcion As String) Implements IBCMaestro.MantenimientoMonedasDescripcion
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IMonedasRepositorio)()
'                rep.ModificarDescription(id, descripcion)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try

'        End Sub
'    End Class
'End Namespace


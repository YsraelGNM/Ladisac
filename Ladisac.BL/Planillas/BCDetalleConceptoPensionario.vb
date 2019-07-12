Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCDetalleConceptoPensionario
        Implements IBCDetalleConceptoPensionario

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function DetalleConceptosPensionariosQuery(ByVal rep_RegiPension_id As String) As Object Implements IBCDetalleConceptoPensionario.DetalleConceptosPensionariosQuery
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.ReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleConceptosPensionariosSelectXML, rep_RegiPension_id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function DetalleConceptosPensionariosSeek(ByVal rep_RegiPension_id As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String) As BE.DetalleConceptosPensionarios Implements IBCDetalleConceptoPensionario.DetalleConceptosPensionariosSeek
            Dim result As DetalleConceptosPensionarios = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.DetalleConceptoPensionarioRepositorio)()
                result = rep.GetById(rep_RegiPension_id, tic_TipoConcep_Id, con_Conceptos_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.DetalleConceptosPensionarios) As Object Implements IBCDetalleConceptoPensionario.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.DetalleConceptoPensionarioRepositorio)()
                Return rep.Mantenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function DetalleConceptosPensionariosDetalleQuery(ByVal rep_RegiPension_id As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String) As Object Implements IBCDetalleConceptoPensionario.DetalleConceptosPensionariosDetalleQuery
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.ReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleConceptosPensionariosDetalleSelectXML, rep_RegiPension_id, tic_TipoConcep_Id, con_Conceptos_Id)
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
'    Public Class BCNivelEducacion
'        Implements IBCNivelEducacion

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function Maintenance(ByVal item As BE.NivelEducacion) As Object Implements IBCNivelEducacion.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.INivelEducacionRepositorio)()
'                Return rep.Mantenance(item)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function

'        Public Function NivelEducacionQuery(ByVal nie_NiveEduc_Id As String, ByVal nie_Descipcion As String) As Object Implements IBCNivelEducacion.NivelEducacionQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPNivelEducacionSelectXML, nie_NiveEduc_Id, nie_Descipcion)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function NivelEducacionSeek(ByVal id As String) As BE.NivelEducacion Implements IBCNivelEducacion.NivelEducacionSeek
'            Dim result As NivelEducacion = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.INivelEducacionRepositorio)()
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

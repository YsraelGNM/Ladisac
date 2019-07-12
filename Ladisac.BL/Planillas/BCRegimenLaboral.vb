
Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCRegimenLaboral
        Implements IBCRegimenLaboral
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function MAintenance(ByVal item As BE.RegimenLaboral) As Object Implements IBCRegimenLaboral.MAintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRegimenLaboralRepositorio)()
                Return rep.Mantenance(item)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function

        Public Function RegimenLaboralQuery(ByVal rel_RegLaboral_Id As String, ByVal rel_Descripcioren As String) As Object Implements IBCRegimenLaboral.RegimenLaboralQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPRegimenLaboralSelectXML, rel_RegLaboral_Id, rel_Descripcioren)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function RegimenLaboralSeek(ByVal id As String) As BE.RegimenLaboral Implements IBCRegimenLaboral.RegimenLaboralSeek
            Dim result As RegimenLaboral = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRegimenLaboralRepositorio)()
                result = rep.GetById(id)
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

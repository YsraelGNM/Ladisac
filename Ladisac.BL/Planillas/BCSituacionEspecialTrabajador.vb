Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCSituacionEspecialTrabajador
        Implements IBCSituacionEspecialTrabajador

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Mantenance(ByVal item As BE.SituacionEspecialTrabajador) As Object Implements IBCSituacionEspecialTrabajador.Mantenance

            Try
                Dim rep = ContainerService.Resolve(Of DA.ISituacionEspecialTrabajadorRepositorio)()
                Return rep.Mantenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function SituacionEspecialTrabajadorQuery(ByVal set_SituEspe_Id As String, ByVal set_Descripcion As String) As Object Implements IBCSituacionEspecialTrabajador.SituacionEspecialTrabajadorQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPSituacionEspecialTrabajadorSelectXML, set_SituEspe_Id, set_Descripcion)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SituacionEspecialTrabajadorSeek(ByVal id As String) As BE.SituacionEspecialTrabajador Implements IBCSituacionEspecialTrabajador.SituacionEspecialTrabajadorSeek
            Dim result As SituacionEspecialTrabajador = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISituacionEspecialTrabajadorRepositorio)()
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

'    Public Class BCRegimenPensionario
'        Implements IBCRegimenPensionario

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function Mantenance(ByVal item As BE.RegimenPensionario) As Object Implements IBCRegimenPensionario.Mantenance

'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IRegimenPensionarioRepositorio)()
'                Return rep.Mantenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return False
'        End Function

'        Public Function RegimenPensionarioQuery(ByVal rep_RegiPension_id As String, ByVal rep_Descripcion As String) As Object Implements IBCRegimenPensionario.RegimenPensionarioQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPRegimenPensionarioXML, rep_RegiPension_id, rep_Descripcion)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return result

'        End Function

'        Public Function RegimenPensionarioSeek(ByVal id As String) As BE.RegimenPensionario Implements IBCRegimenPensionario.RegimenPensionarioSeek
'            Dim result As RegimenPensionario = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IRegimenPensionarioRepositorio)()
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
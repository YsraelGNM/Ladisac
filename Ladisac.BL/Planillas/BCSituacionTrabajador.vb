Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCSituacionTrabajador
        Implements IBCSituacionTrabajador
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Mantenance(ByVal item As BE.SituacionTrabajador) As Object Implements IBCSituacionTrabajador.Mantenance

            Try
                Dim rep = ContainerService.Resolve(Of Ladisac.DA.ISituacionTrabajadorRepositorio)()
                Return rep.ManTenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function

        Public Function SituacionTrabajadorQuery(ByVal sit_SituaTrab_Id As String, ByVal sit_Descripcion As String) As Object Implements IBCSituacionTrabajador.SituacionTrabajadorQuery
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPSituacionTrabajadorSelectXML, sit_SituaTrab_Id, sit_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            
            Return result
        End Function

        Public Function SituacionTrabajadorSeek(ByVal id As String) As BE.SituacionTrabajador Implements IBCSituacionTrabajador.SituacionTrabajadorSeek
            Dim result As SituacionTrabajador = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISituacionTrabajadorRepositorio)()
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
'    Public Class BCSituacionEspecialTrabajador
'        Implements IBCSituacionEspecialTrabajador

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function Mantenance(ByVal item As BE.SituacionEspecialTrabajador) As Object Implements IBCSituacionEspecialTrabajador.Mantenance

'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ISituacionEspecialTrabajadorRepositorio)()
'                Return rep.Mantenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return False
'        End Function

'        Public Function SituacionEspecialTrabajadorQuery(ByVal set_SituEspe_Id As String, ByVal set_Descripcion As String) As Object Implements IBCSituacionEspecialTrabajador.SituacionEspecialTrabajadorQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPSituacionEspecialTrabajadorSelectXML, set_SituEspe_Id, set_Descripcion)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function SituacionEspecialTrabajadorSeek(ByVal id As String) As BE.SituacionEspecialTrabajador Implements IBCSituacionEspecialTrabajador.SituacionEspecialTrabajadorSeek
'            Dim result As SituacionEspecialTrabajador = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ISituacionEspecialTrabajadorRepositorio)()
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

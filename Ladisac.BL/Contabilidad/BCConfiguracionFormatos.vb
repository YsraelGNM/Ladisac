Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCConfiguracionFormatos
        Implements IBCConfiguracionFormatos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ConfiguracionFormatosQuery(ByVal descripcion As String) As Object Implements IBCConfiguracionFormatos.ConfiguracionFormatosQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPConfiguracionFormatosSelectXML, descripcion)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ConfiguracionFormatosSeek(ByVal id As String) As Object Implements IBCConfiguracionFormatos.ConfiguracionFormatosSeek
            Dim result As BE.ConfiguracionFormatos = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IConfiguracionFormatosRepositorio)()
                result = rep.GetById(id)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.ConfiguracionFormatos) As Object Implements IBCConfiguracionFormatos.Maintenance

            Try
                Dim rep = ContainerService.Resolve(Of DA.IConfiguracionFormatosRepositorio)()
                Return rep.Mantenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function
    End Class

End Namespace


'Imports Ladisac.BL
'Namespace Ladisac.BL

'    Public Class BCCtaCte
'        Implements IBCCtaCte
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function CtaCteQuery(ByVal CCT_ID As String, ByVal CCT_DESCRIPCION As String) As Object Implements IBCCtaCte.CtaCteQuery

'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPCtaCteSelectXML, CCT_ID, CCT_DESCRIPCION)
'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return result

'        End Function

'        Public Function CtaCteSeek(ByVal id As String) As BE.CtaCte Implements IBCCtaCte.CtaCteSeek
'            Dim result As BE.CtaCte = Nothing

'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ICtaCteRepositorio)()
'                result = rep.GetById(id)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.CtaCte) As Object Implements IBCCtaCte.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ICtaCteRepositorio)()
'                Return rep.Mantenance(item)
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

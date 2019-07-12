Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCMarcacion
        Implements IBCMarcacion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub maintenance(ByVal item As List(Of BE.Marcaciones)) Implements IBCMarcacion.maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMarcacionRepositorio)()

                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))


                    For Each newRow In item
                        rep.Maintenance(newRow)
                    Next
                    Scope.Complete()

                End Using


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub

        Public Function MarcacionQuery(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal per_id As String) As Object Implements IBCMarcacion.MarcacionQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPMarcacionSelectXML, CDate(fechaDesde), CDate(fechaHasta), per_id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MarcacionSeek(ByVal fech As Date, ByVal per_id As String) As Object Implements IBCMarcacion.MarcacionSeek
            Dim result As List(Of BE.Marcaciones) = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMarcacionRepositorio)()
                result = rep.GetId(fech, per_id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function SPDetalleMarcacionSelect(ByVal persona As String, ByVal fecha As Date) As Object Implements IBCMarcacion.SPDetalleMarcacionSelect
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleMarcacionSelect, persona, fecha)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function SPMarcacionColtronSelectXML(ByVal personas As String, ByVal fecha As Date) As Object Implements IBCMarcacion.SPMarcacionColtronSelectXML

            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPMarcacionColtronSelectXML, personas, fecha)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function ReporteTardanzaXMes(ByVal FecIni As Date, ByVal FecFin As Date) As System.Data.DataTable Implements IBCMarcacion.ReporteTardanzaXMes
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spReporteTardanzaXMes", FecIni, FecFin)
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
'    Public Class BCPeriodisidad
'        Implements IBCPeriodisidad

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Sub Maintenance(ByVal item As BE.Periodisidad) Implements IBCPeriodisidad.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IPeriodisidadRepositorio)()
'                rep.Mantenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'        End Sub

'        Public Function PeriodisidadQuery(ByVal pec_Periodisidad_Id As String, ByVal pec_Descripcion As String) As Object Implements IBCPeriodisidad.PeriodisidadQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPPeriodisidadSelectXML, pec_Periodisidad_Id, pec_Descripcion)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function PeriodisidadSeek(ByVal id As String) As BE.Periodisidad Implements IBCPeriodisidad.PeriodisidadSeek
'            Dim result As Periodisidad
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IPeriodisidadRepositorio)()
'                result = rep.GetId(id)
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
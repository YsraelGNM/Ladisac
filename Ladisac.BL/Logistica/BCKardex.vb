Imports Microsoft.VisualBasic.FileIO
Imports System.IO

Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCKardex
        Implements IBCKardex

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function KardexGetById(ByVal KAR_ID As Integer) As BE.Kardex Implements IBCKardex.KardexGetById
            Dim result As Kardex = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                result = rep.GetById(KAR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoKardex(ByVal mKardex As BE.Kardex) Implements IBCKardex.MantenimientoKardex
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mKardex.ChangeTracker.State = ObjectState.Added) Then
                        mKardex.KAR_ID = bcherramientas.Get_Id("Kardex")
                    ElseIf (mKardex.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mKardex)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaKardex(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String Implements IBCKardex.ListaKardex
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                result = rep.ListaKardex(FecIni, FecFin, Alm_Id, ART_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub RehacerKardex(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date) Implements IBCKardex.RehacerKardex
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                rep.RehacerKardex(ART_Id, Alm_Id, Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaStockMinimo() As String Implements IBCKardex.ListaStockMinimo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaStockMinimo")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDocOperacion(ByVal IngresoSalida As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal ALM_ID As Nullable(Of Integer), ByVal ART_ID As String) As String Implements IBCKardex.ListaDocOperacion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                result = rep.ListaDocOperacion(IngresoSalida, FecIni, FecFin, ALM_ID, ART_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSaldoXAlmacen(ByVal Art_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date) As String Implements IBCKardex.ListaSaldoXAlmacen
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaSaldoXAlmacen", Art_Id, Alm_Id, Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaKardexConsolidado(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String Implements IBCKardex.ListaKardexConsolidado
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaKardexConsolidado", FecIni, FecFin, Alm_Id, ART_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function ListaKardexContabilidad(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Nullable(Of Integer), ByVal ART_Id As String, ByVal Anual As Boolean, ByVal Mensual As Boolean, ByVal Tipo As String, Optional ByVal DetRes As Boolean = False) As String Implements IBCKardex.ListaKardexContabilidad
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                If Anual Then
                    If DetRes Then
                        result = rep.EjecutarReporte("spListaKardexContabilidadAnual", FecIni, FecFin, Alm_Id, ART_Id, Tipo)
                    Else
                        result = rep.EjecutarReporte("spListaKardexContabilidadAnualResumen", FecIni, FecFin, Alm_Id, ART_Id, Tipo)
                    End If

                ElseIf Mensual Then
                    result = rep.EjecutarReporte("spListaKardexContabilidadMensual", FecIni, FecFin, Alm_Id, ART_Id, Tipo)
                Else
                    result = rep.EjecutarReporte("spListaKardexContabilidad", FecIni, FecFin, Alm_Id, ART_Id, Tipo)
                End If

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaConsumoCombustible(ByVal Per_Id_Empresa As String, ByVal Unt_Id As String, ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCKardex.ListaConsumoCombustible
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaConsumoCombustibleUnidades", Per_Id_Empresa, Unt_Id, FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaReporteTickets(ByVal Per_Id_Empresa As String, ByVal Tipo As String, ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCKardex.ListaReporteTickets
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spReporteTickets", Per_Id_Empresa, Tipo, FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spSaldoAlmaReparableSuministro(ByVal fechaInicio As Date, ByVal fechaHasta As Date) As Object Implements IBCKardex.spSaldoAlmaReparableSuministro

            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte("ALM.spSaldoAlmaReparableSuministro", fechaInicio, fechaHasta)
                    Scope.Complete()

                End Using



            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function StockCostoPromedio(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date, ByVal Flag As Integer) As Decimal Implements IBCKardex.StockCostoPromedio
            Dim result As Decimal = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                result = rep.StockCostoPromedio(ART_Id, Alm_Id, Fecha, Flag)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaKardexLote(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String) As String Implements IBCKardex.ListaKardexLote
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaKardexLote", FecIni, FecFin, Alm_Id, ART_Id, DES_SERIE, DES_NUMERO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaKardexLadrillo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String Implements IBCKardex.ListaKardexLadrillo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaKardexLadrillo", FecIni, FecFin, Alm_Id, ART_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteAnticuamiento(ByVal FecIni As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String Implements IBCKardex.ReporteAnticuamiento
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spReporteAnticuamiento", FecIni, Alm_Id, ART_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTiempoAtencionOR(ByVal FecIni As Date, ByVal FecFin As Date) As System.Data.DataTable Implements IBCKardex.ListaTiempoAtencionOR
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spListaTiempoAtencionOR", FecIni, FecFin)
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

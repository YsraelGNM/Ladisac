Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class DocuMovimientoRepositorio
        Implements IDocuMovimientoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal DMO_Id As Integer) As BE.DocuMovimiento Implements IDocuMovimientoRepositorio.GetById
            Dim result As DocuMovimiento = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.CommandTimeout = 900
                result = (From c In context.DocuMovimiento.Include("DocuMovimientoDetalle.Articulos.UnidadMedidaArticulos").Include("Personas.DocPersonas").Include("DocuMovimientoDetalle.Almacen").Include("DetalleTipoDocumentos.TipoDocumentos").Include("DocuMovimientoDetalle.Kardex").Include("Moneda") Where c.DMO_ID = DMO_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDocuMovimiento(ByVal Filtro As String) As DataSet Implements IDocuMovimientoRepositorio.ListaDocuMovimiento
            Dim result As DataSet = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaDocuMovimiento2", IIf(Filtro = "", "", "WHERE " & Filtro))
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal DocuMovimiento As BE.DocuMovimiento) Implements IDocuMovimientoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DocuMovimiento.ApplyChanges(DocuMovimiento)
                context.SaveChanges()
                DocuMovimiento.AcceptChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaSalidaXReqXDocu(ByVal DMO_ID As Integer?) As System.Data.DataSet Implements IDocuMovimientoRepositorio.ListaSalidaXReqXDocu
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaSalidaXReqXDocu", DMO_ID)
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetByIdSCO(ByVal SCO_Id As Integer) As BE.DocuMovimiento Implements IDocuMovimientoRepositorio.GetByIdSCO
            Dim result As DocuMovimiento = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DocuMovimiento.Include("DocuMovimientoDetalle.Articulos.UnidadMedidaArticulos").Include("Personas.DocPersonas").Include("DocuMovimientoDetalle.Almacen").Include("DetalleTipoDocumentos.TipoDocumentos").Include("DocuMovimientoDetalle.Kardex").Include("Moneda") Where c.SCO_ID = SCO_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaIngresoXFacXDocu(ByVal DMO_ID As Integer?, ByVal ART_ID As String) As System.Data.DataSet Implements IDocuMovimientoRepositorio.ListaIngresoXFacXDocu
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaIngresoXFacXDocu", DMO_ID, ART_ID)
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetByIdDRU(ByVal DRU_Id As Integer) As BE.DocuMovimiento Implements IDocuMovimientoRepositorio.GetByIdDRU
            Dim result As DocuMovimiento = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DocuMovimiento.Include("DocuMovimientoDetalle.Articulos.UnidadMedidaArticulos").Include("Personas.DocPersonas").Include("DocuMovimientoDetalle.Almacen").Include("DetalleTipoDocumentos.TipoDocumentos").Include("DocuMovimientoDetalle.Kardex").Include("Moneda") Where c.DRU_ID = DRU_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetByIdCCO(ByVal CCO_Id As Integer) As BE.DocuMovimiento Implements IDocuMovimientoRepositorio.GetByIdCCO
            Dim result As DocuMovimiento = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DocuMovimiento.Include("DocuMovimientoDetalle.Articulos.UnidadMedidaArticulos").Include("Personas.DocPersonas").Include("DocuMovimientoDetalle.Almacen").Include("DetalleTipoDocumentos.TipoDocumentos").Include("DocuMovimientoDetalle.Kardex").Include("Moneda") Where c.CCO_ID = CCO_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub ActualizarIngresoTransformacion(ByVal TFO_ID As Integer?) Implements IDocuMovimientoRepositorio.ActualizarIngresoTransformacion
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spActualizarIngresoTransformacion", TFO_ID)
                context.ExecuteNonQuery(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetByIdCME(ByVal CME_Id As Integer) As BE.DocuMovimiento Implements IDocuMovimientoRepositorio.GetByIdCME
            Dim result As DocuMovimiento = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DocuMovimiento.Include("DocuMovimientoDetalle.Articulos.UnidadMedidaArticulos").Include("Personas.DocPersonas").Include("DocuMovimientoDetalle.Almacen").Include("DetalleTipoDocumentos.TipoDocumentos").Include("DocuMovimientoDetalle.Kardex").Include("Moneda") Where c.CME_ID = CME_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetColByIdCME(ByVal CME_Id As Integer) As System.Collections.Generic.List(Of BE.DocuMovimiento) Implements IDocuMovimientoRepositorio.GetColByIdCME
            Dim result As New List(Of DocuMovimiento)
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim col = (From c In context.DocuMovimiento.Include("DocuMovimientoDetalle.Articulos.UnidadMedidaArticulos").Include("Personas.DocPersonas").Include("DocuMovimientoDetalle.Almacen").Include("DetalleTipoDocumentos.TipoDocumentos").Include("DocuMovimientoDetalle.Kardex").Include("Moneda") Where c.CME_ID = CME_Id Order By c.DMO_ID Select c)
                For Each mItem In col.ToList
                    result.Add(mItem)
                Next
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetColByIdCCO_CONTEO(ByVal CCO_Id As Integer) As System.Collections.Generic.List(Of BE.DocuMovimiento) Implements IDocuMovimientoRepositorio.GetColByIdCCO_CONTEO
            Dim result As New List(Of DocuMovimiento)
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim col = (From c In context.DocuMovimiento.Include("DocuMovimientoDetalle.Articulos.UnidadMedidaArticulos").Include("Personas.DocPersonas").Include("DocuMovimientoDetalle.Almacen").Include("DetalleTipoDocumentos.TipoDocumentos").Include("DocuMovimientoDetalle.Kardex").Include("Moneda") Where c.CCO_ID_CONTEO = CCO_Id Select c)
                For Each mItem In col.ToList
                    result.Add(mItem)
                Next
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetColRecicladoCrudoByIdPRO_ID(ByVal PRO_ID As Integer) As System.Collections.Generic.List(Of BE.DocuMovimiento) Implements IDocuMovimientoRepositorio.GetColRecicladoCrudoByIdPRO_ID
            Dim result As New List(Of DocuMovimiento)
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim col = (From c In context.DocuMovimiento.Include("DocuMovimientoDetalle.Articulos.UnidadMedidaArticulos").Include("DocuMovimientoDetalle.Almacen").Include("DetalleTipoDocumentos.TipoDocumentos").Include("DocuMovimientoDetalle.Kardex").Include("Moneda") Where c.PRO_ID = PRO_ID And c.DMO_SERIE = "AMPR" And c.DTD_ID = "015" Select c)
                For Each mItem In col.ToList
                    result.Add(mItem)
                Next
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



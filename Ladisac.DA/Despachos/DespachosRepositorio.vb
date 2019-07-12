Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DespachosRepositorio
        Implements IDespachosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.Despachos) As Short Implements IDespachosRepositorio.Maintenance
            'Try
            Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
            context.Despachos.ApplyChanges(item)
            context.SaveChanges()
            item.AcceptChanges()
            Maintenance = 1
            'Catch ex As Exception
            'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
            'If (rethrow) Then
            'Throw
            'End If
            'Maintenance = 0
            'End Try
        End Function
        Public Function DeleteRegistro(ByVal item As BE.Despachos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDES_SERIE As String, ByVal cDES_NUMERO As String) As Short Implements IDespachosRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.Despachos Where c.TDO_ID = cTDO_ID And c.DTD_ID = cDTD_ID And c.DES_SERIE = cDES_SERIE And c.DES_NUMERO = cDES_NUMERO Select c).FirstOrDefault()
                item.MarkAsDeleted()
                DeleteRegistro = Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                DeleteRegistro = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal Orm As Despachos) As Short Implements IDespachosRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDespachos)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.CCT_ID, DbType.String, Orm.CCT_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_EMI, DbType.DateTime, Orm.DES_FEC_EMI)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_TRA, DbType.DateTime, Orm.DES_FEC_TRA)
                context.AddInParameter(cmd, Despachos.PropertyNames.PVE_ID, DbType.String, Orm.PVE_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.ALM_ID, DbType.Int16, Orm.ALM_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.ALM_ID_LLEGADA, DbType.Int16, Orm.ALM_ID_LLEGADA)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID_DOC, DbType.String, Orm.TDO_ID_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID_DOC, DbType.String, Orm.DTD_ID_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE_DOC, DbType.String, Orm.DES_SERIE_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO_DOC, DbType.String, Orm.DES_NUMERO_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.PER_ID_REC, DbType.String, Orm.PER_ID_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDP_ID_REC, DbType.String, Orm.TDP_ID_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DIR_ID_ENT_REC, DbType.String, Orm.DIR_ID_ENT_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DIR_ID_ENT, DbType.String, Orm.DIR_ID_ENT)
                context.AddInParameter(cmd, Despachos.PropertyNames.PLA_ID, DbType.String, Orm.PLA_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.FLE_ID, DbType.String, Orm.FLE_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.MON_ID, DbType.String, Orm.MON_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_MONTO_FLETE, DbType.Double, Orm.DES_MONTO_FLETE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_CONTRAVALOR, DbType.Double, Orm.DES_CONTRAVALOR)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_OBSERVACIONES, DbType.String, Orm.DES_OBSERVACIONES)
                context.AddInParameter(cmd, Despachos.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_GRAB, DbType.DateTime, Orm.DES_FEC_GRAB)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_ESTADO, DbType.Int16, Orm.DES_ESTADO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_TIPO_GUIA, DbType.Int16, Orm.DES_TIPO_GUIA)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_PRO_CRO, DbType.DateTime, Orm.DES_FEC_PRO_CRO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_CAR_DES, DbType.DateTime, Orm.DES_FEC_CAR_DES)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_SAL_PLA, DbType.DateTime, Orm.DES_FEC_SAL_PLA)
                context.ExecuteNonQuery(cmd)
                spActualizarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarRegistro = 0
            End Try
        End Function

        Public Function spInsertarRegistro(ByVal Orm As Despachos) As Short Implements IDespachosRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDespachos)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.CCT_ID, DbType.String, Orm.CCT_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_EMI, DbType.DateTime, Orm.DES_FEC_EMI)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_TRA, DbType.DateTime, Orm.DES_FEC_TRA)
                context.AddInParameter(cmd, Despachos.PropertyNames.PVE_ID, DbType.String, Orm.PVE_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.ALM_ID, DbType.Int16, Orm.ALM_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.ALM_ID_LLEGADA, DbType.Int16, Orm.ALM_ID_LLEGADA)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID_DOC, DbType.String, Orm.TDO_ID_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID_DOC, DbType.String, Orm.DTD_ID_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE_DOC, DbType.String, Orm.DES_SERIE_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO_DOC, DbType.String, Orm.DES_NUMERO_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.PER_ID_REC, DbType.String, Orm.PER_ID_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDP_ID_REC, DbType.String, Orm.TDP_ID_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DIR_ID_ENT_REC, DbType.String, Orm.DIR_ID_ENT_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DIR_ID_ENT, DbType.String, Orm.DIR_ID_ENT)
                context.AddInParameter(cmd, Despachos.PropertyNames.PLA_ID, DbType.String, Orm.PLA_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.FLE_ID, DbType.String, Orm.FLE_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.MON_ID, DbType.String, Orm.MON_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_MONTO_FLETE, DbType.Double, Orm.DES_MONTO_FLETE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_CONTRAVALOR, DbType.Double, Orm.DES_CONTRAVALOR)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_OBSERVACIONES, DbType.String, Orm.DES_OBSERVACIONES)
                context.AddInParameter(cmd, Despachos.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_GRAB, DbType.DateTime, Orm.DES_FEC_GRAB)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_ESTADO, DbType.Int16, Orm.DES_ESTADO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_TIPO_GUIA, DbType.Int16, Orm.DES_TIPO_GUIA)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_PRO_CRO, DbType.DateTime, Orm.DES_FEC_PRO_CRO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_CAR_DES, DbType.DateTime, Orm.DES_FEC_CAR_DES)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_SAL_PLA, DbType.DateTime, Orm.DES_FEC_SAL_PLA)
                context.ExecuteNonQuery(cmd)
                spInsertarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spInsertarRegistro = 0
            End Try
        End Function

        Public Function spEliminarRegistro(ByVal Orm As Despachos) As Short Implements IDespachosRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDespachos)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistro = 0
            End Try
        End Function

        Public Function spActualizarDespachosDES_ESTADO(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String, ByVal DES_ESTADO As Short) As Short Implements IDespachosRepositorio.spActualizarDespachosDES_ESTADO
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spDespachosESTADO)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, DES_NUMERO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_ESTADO, DbType.Int16, DES_ESTADO)
                context.ExecuteNonQuery(cmd)
                spActualizarDespachosDES_ESTADO = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarDespachosDES_ESTADO = 0
            End Try
        End Function

        Public Function spActualizarDocuMovimiento(ByVal Orm As Despachos) As Short Implements IDespachosRepositorio.spActualizarDocuMovimiento
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarDocuMovimiento)
                cmd.CommandTimeout = 2000
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.ExecuteNonQuery(cmd)
                spActualizarDocuMovimiento = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarDocuMovimiento = 0
            End Try
        End Function

        Public Function spActualizarRegistroNullALM_ID_LLEGADA(ByVal Orm As Despachos) As Short Implements IDespachosRepositorio.spActualizarRegistroNullALM_ID_LLEGADA
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDespachosNullALM_ID_LLEGADA)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.CCT_ID, DbType.String, Orm.CCT_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_EMI, DbType.DateTime, Orm.DES_FEC_EMI)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_TRA, DbType.DateTime, Orm.DES_FEC_TRA)
                context.AddInParameter(cmd, Despachos.PropertyNames.PVE_ID, DbType.String, Orm.PVE_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.ALM_ID, DbType.Int16, Orm.ALM_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID_DOC, DbType.String, Orm.TDO_ID_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID_DOC, DbType.String, Orm.DTD_ID_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE_DOC, DbType.String, Orm.DES_SERIE_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO_DOC, DbType.String, Orm.DES_NUMERO_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.PER_ID_REC, DbType.String, Orm.PER_ID_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDP_ID_REC, DbType.String, Orm.TDP_ID_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DIR_ID_ENT_REC, DbType.String, Orm.DIR_ID_ENT_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DIR_ID_ENT, DbType.String, Orm.DIR_ID_ENT)
                context.AddInParameter(cmd, Despachos.PropertyNames.PLA_ID, DbType.String, Orm.PLA_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.FLE_ID, DbType.String, Orm.FLE_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.MON_ID, DbType.String, Orm.MON_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_MONTO_FLETE, DbType.Double, Orm.DES_MONTO_FLETE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_CONTRAVALOR, DbType.Double, Orm.DES_CONTRAVALOR)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_OBSERVACIONES, DbType.String, Orm.DES_OBSERVACIONES)
                context.AddInParameter(cmd, Despachos.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_GRAB, DbType.DateTime, Orm.DES_FEC_GRAB)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_ESTADO, DbType.Int16, Orm.DES_ESTADO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_TIPO_GUIA, DbType.Int16, Orm.DES_TIPO_GUIA)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_PRO_CRO, DbType.DateTime, Orm.DES_FEC_PRO_CRO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_CAR_DES, DbType.DateTime, Orm.DES_FEC_CAR_DES)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_SAL_PLA, DbType.DateTime, Orm.DES_FEC_SAL_PLA)
                context.ExecuteNonQuery(cmd)
                spActualizarRegistroNullALM_ID_LLEGADA = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarRegistroNullALM_ID_LLEGADA = 0
            End Try
        End Function

        Public Function spInsertarRegistroNullALM_ID_LLEGADA(ByVal Orm As Despachos) As Short Implements IDespachosRepositorio.spInsertarRegistroNullALM_ID_LLEGADA
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDespachosNullALM_ID_LLEGADA)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.CCT_ID, DbType.String, Orm.CCT_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_EMI, DbType.DateTime, Orm.DES_FEC_EMI)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_TRA, DbType.DateTime, Orm.DES_FEC_TRA)
                context.AddInParameter(cmd, Despachos.PropertyNames.PVE_ID, DbType.String, Orm.PVE_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.ALM_ID, DbType.Int16, Orm.ALM_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID_DOC, DbType.String, Orm.TDO_ID_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID_DOC, DbType.String, Orm.DTD_ID_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE_DOC, DbType.String, Orm.DES_SERIE_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO_DOC, DbType.String, Orm.DES_NUMERO_DOC)
                context.AddInParameter(cmd, Despachos.PropertyNames.PER_ID_REC, DbType.String, Orm.PER_ID_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDP_ID_REC, DbType.String, Orm.TDP_ID_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DIR_ID_ENT_REC, DbType.String, Orm.DIR_ID_ENT_REC)
                context.AddInParameter(cmd, Despachos.PropertyNames.DIR_ID_ENT, DbType.String, Orm.DIR_ID_ENT)
                context.AddInParameter(cmd, Despachos.PropertyNames.PLA_ID, DbType.String, Orm.PLA_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.FLE_ID, DbType.String, Orm.FLE_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.MON_ID, DbType.String, Orm.MON_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_MONTO_FLETE, DbType.Double, Orm.DES_MONTO_FLETE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_CONTRAVALOR, DbType.Double, Orm.DES_CONTRAVALOR)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_OBSERVACIONES, DbType.String, Orm.DES_OBSERVACIONES)
                context.AddInParameter(cmd, Despachos.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_GRAB, DbType.DateTime, Orm.DES_FEC_GRAB)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_ESTADO, DbType.Int16, Orm.DES_ESTADO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_TIPO_GUIA, DbType.Int16, Orm.DES_TIPO_GUIA)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_PRO_CRO, DbType.DateTime, Orm.DES_FEC_PRO_CRO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_CAR_DES, DbType.DateTime, Orm.DES_FEC_CAR_DES)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_SAL_PLA, DbType.DateTime, Orm.DES_FEC_SAL_PLA)
                context.ExecuteNonQuery(cmd)
                spInsertarRegistroNullALM_ID_LLEGADA = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spInsertarRegistroNullALM_ID_LLEGADA = 0
            End Try
        End Function

        Public Function spActualizarDespachosDES_FEC_SAL_PLA(ByVal Orm As BE.Despachos) As Short Implements IDespachosRepositorio.spActualizarDespachosDES_FEC_SAL_PLA
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spDespachosDES_FEC_SAL_PLA)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_SAL_PLA, DbType.DateTime, Orm.DES_FEC_SAL_PLA)
                context.ExecuteNonQuery(cmd)
                spActualizarDespachosDES_FEC_SAL_PLA = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarDespachosDES_FEC_SAL_PLA = 0
            End Try
        End Function

        Public Function spActualizarDespachosDES_FEC_CAR_DES(ByVal Orm As BE.Despachos) As Short Implements IDespachosRepositorio.spActualizarDespachosDES_FEC_CAR_DES
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spDespachosDES_FEC_CAR_DES)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_FEC_CAR_DES, DbType.DateTime, Orm.DES_FEC_CAR_DES)
                context.ExecuteNonQuery(cmd)
                spActualizarDespachosDES_FEC_CAR_DES = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarDespachosDES_FEC_CAR_DES = 0
            End Try
        End Function

        Public Function spActualizarDespachosDES_ESTADOEnDistribuidora(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String, ByVal DES_ESTADO As Short) As Short Implements IDespachosRepositorio.spActualizarDespachosDES_ESTADOEnDistribuidora
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spDespachosESTADOEnDistribuidora)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, DES_NUMERO)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_ESTADO, DbType.Int16, DES_ESTADO)
                context.ExecuteNonQuery(cmd)
                spActualizarDespachosDES_ESTADOEnDistribuidora = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarDespachosDES_ESTADOEnDistribuidora = 0
            End Try
        End Function

        Public Function EjecutarReporte(ByVal report As String, ByVal ParamArray params() As Object) As System.Data.DataTable Implements IDespachosRepositorio.EjecutarReporte
            Dim result As DataTable = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                'Dim oDAtaSet = context.ExecuteDataSet(report, params)

                Dim cmd = context.GetStoredProcCommand(report, params)
                cmd.CommandTimeout = 2000
                Dim oDAtaSet = context.ExecuteDataSet(cmd)

                result = oDAtaSet.Tables(0)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spInsertarProgramacion(ByVal TDO_ID_CRO As String, ByVal DTD_ID_CRO As String, ByVal DES_SERIE_CRO As String, ByVal DES_NUMERO_CRO As String, ByVal TDO_ID_DES As String, ByVal DTD_ID_DES As String, ByVal DES_SERIE_DES As String, ByVal DES_NUMERO_DES As String, ByVal USU_ID As String, ByVal PRO_ESTADO As Short) As Short Implements IDespachosRepositorio.spInsertarProgramacion
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarProgramacion)
                context.AddInParameter(cmd, "TDO_ID_CRO", DbType.String, TDO_ID_CRO)
                context.AddInParameter(cmd, "DTD_ID_CRO", DbType.String, DTD_ID_CRO)
                context.AddInParameter(cmd, "DES_SERIE_CRO", DbType.String, DES_SERIE_CRO)
                context.AddInParameter(cmd, "DES_NUMERO_CRO", DbType.String, DES_NUMERO_CRO)
                context.AddInParameter(cmd, "TDO_ID_DES", DbType.String, TDO_ID_DES)
                context.AddInParameter(cmd, "DTD_ID_DES", DbType.String, DTD_ID_DES)
                context.AddInParameter(cmd, "DES_SERIE_DES", DbType.String, DES_SERIE_DES)
                context.AddInParameter(cmd, "DES_NUMERO_DES", DbType.String, DES_NUMERO_DES)
                context.AddInParameter(cmd, "USU_ID", DbType.String, USU_ID)
                context.AddInParameter(cmd, "PRO_ESTADO", DbType.String, PRO_ESTADO)
                context.ExecuteNonQuery(cmd)
                spInsertarProgramacion = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spInsertarProgramacion = 0
            End Try
        End Function

        Public Function spEnviarCorreoDespacho(ByVal Orm As BE.Despachos) As Short Implements IDespachosRepositorio.spEnviarCorreoDespacho
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEnviarCorreoDespacho)
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.ExecuteNonQuery(cmd)
                spEnviarCorreoDespacho = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEnviarCorreoDespacho = 0
            End Try
        End Function

        Public Function spValidarSalidaVigilancia(ByVal Orm As BE.Despachos) As Short Implements IDespachosRepositorio.spValidarSalidaVigilancia
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spValidarSalidaVigilancia")
                context.AddInParameter(cmd, Despachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_SERIE, DbType.String, Orm.DES_SERIE)
                context.AddInParameter(cmd, Despachos.PropertyNames.DES_NUMERO, DbType.String, Orm.DES_NUMERO)
                context.ExecuteNonQuery(cmd)
                spValidarSalidaVigilancia = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spValidarSalidaVigilancia = 0
            End Try
        End Function


        Public Function GetById(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String) As BE.Despachos Implements IDespachosRepositorio.GetById
            Dim result As Despachos = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Despachos Where c.TDO_ID = TDO_ID And c.DTD_ID = DTD_ID And c.DES_SERIE = DES_SERIE And c.DES_NUMERO = DES_NUMERO Select c).FirstOrDefault
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

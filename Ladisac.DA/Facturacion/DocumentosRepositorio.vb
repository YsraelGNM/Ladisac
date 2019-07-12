Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DocumentosRepositorio
        Implements IDocumentosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.Documentos) As Short Implements IDocumentosRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Documentos.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Maintenance = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Maintenance = 0
            End Try
        End Function

        Public Function spActualizarDocumentosDOC_ESTADO(ByVal TDO_ID As String, _
                                                         ByVal DTD_ID As String,
                                                         ByVal DOC_SERIE As String,
                                                         ByVal DOC_NUMERO As String,
                                                         ByVal DOC_ESTADO As Int16) As Short Implements IDocumentosRepositorio.spActualizarDocumentosDOC_ESTADO
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spDocumentosESTADO)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDO_ID, DbType.String, TDO_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DTD_ID, DbType.String, DTD_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_SERIE, DbType.String, DOC_SERIE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NUMERO, DbType.String, DOC_NUMERO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ESTADO, DbType.Int16, DOC_ESTADO)
                context.ExecuteNonQuery(cmd)
                spActualizarDocumentosDOC_ESTADO = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarDocumentosDOC_ESTADO = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCT_ID As String, ByVal cDOC_SERIE As String, ByVal cDOC_NUMERO As String, ByVal cDOC_ORDEN_COMPRA As String, ByVal cDOC_TIPO_ORDEN_COMPRA As Short, ByVal cPER_ID_REC As String, ByVal cTDP_ID_REC As String, ByVal cDIR_ID_ENT_REC As String, ByVal cPVE_ID As String, ByVal cPVE_ID_DES As String, ByVal cMON_ID As String, ByVal cTIV_ID As String, ByVal cPER_ID_CLI As String, ByVal cTDP_ID_CLI As String, ByVal cPER_ID_CON As String, ByVal cDOC_FECHA_EMI As Date, ByVal cDOC_FECHA_ENT As Date, ByVal cDOC_FECHA_EXP As Date, ByVal cDIR_ID_FIS As String, ByVal cDIR_ID_DOM As String, ByVal cDIR_ID_ENT As String, ByVal cDIR_ID_COB As String, ByVal cPER_ID_VEN As String, ByVal cPER_ID_COB As String, ByVal cPER_ID_PRO As String, ByVal cPER_ID_GRU As String, ByVal cDOC_TIPO_LISTA As Short, ByVal cDOC_MONTO_TOTAL As Double, ByVal cDOC_CONTRAVALOR As Double, ByVal cDOC_IGV_POR As Double, ByVal cDOC_ASIENTO As Boolean, ByVal cDOC_CIERRE As Short, ByVal cFLE_ID As String, ByVal cDOC_MONTO_FLE As Double, ByVal cDOC_REQUIERE_GUIA As Boolean, ByVal cTDO_ID_AFE As String, ByVal cDTD_ID_AFE As String, ByVal cCCT_ID_AFE As String, ByVal cDOC_SERIE_AFE As String, ByVal cDOC_NUMERO_AFE As String, ByVal cDOC_MOT_EMI As Short, ByVal cDOC_NOMBRE_RECEP As String, ByVal cDOC_DNI_RECEP As String, ByVal cDOC_FEC_RECEP As Date, ByVal cDOC_ENTREGADO As Boolean, ByVal cCAF_IX_NUMERO_PRO As String, ByVal cCAF_IX_ORDEN_COM As String, ByVal cLPR_ID As String, ByVal cUSU_ID As String, ByVal cDOC_FEC_GRAB As Date, ByVal cDOC_ESTADO As Short, ByVal cDOC_MONTO_PERCEPCION As Double, ByVal cTDO_ID_GEN As String, ByVal cDTD_ID_GEN As String, ByVal cCCT_ID_GEN As String, ByVal cDOC_SERIE_GEN As String, ByVal cDOC_NUMERO_GEN As String, ByVal cDOC_OBSERVACIONES As String, ByVal cDOC_ATENCION As String, ByVal cDOC_HORA_INICIO As DateTime, ByVal cDOC_HORA_FIN As DateTime) As Short Implements IDocumentosRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDocumentos)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_SERIE, DbType.String, cDOC_SERIE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NUMERO, DbType.String, cDOC_NUMERO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ORDEN_COMPRA, DbType.String, cDOC_ORDEN_COMPRA)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_TIPO_ORDEN_COMPRA, DbType.Int16, cDOC_TIPO_ORDEN_COMPRA)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_REC, DbType.String, cPER_ID_REC)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDP_ID_REC, DbType.String, cTDP_ID_REC)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_ENT_REC, DbType.String, cDIR_ID_ENT_REC)
                context.AddInParameter(cmd, Documentos.PropertyNames.PVE_ID, DbType.String, cPVE_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.PVE_ID_DES, DbType.String, cPVE_ID_DES)
                context.AddInParameter(cmd, Documentos.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.TIV_ID, DbType.String, cTIV_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDP_ID_CLI, DbType.String, cTDP_ID_CLI)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_CON, DbType.String, cPER_ID_CON)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FECHA_EMI, DbType.DateTime, cDOC_FECHA_EMI)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FECHA_ENT, DbType.DateTime, cDOC_FECHA_ENT)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FECHA_EXP, DbType.DateTime, cDOC_FECHA_EXP)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_FIS, DbType.String, cDIR_ID_FIS)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_DOM, DbType.String, cDIR_ID_DOM)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_ENT, DbType.String, cDIR_ID_ENT)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_COB, DbType.String, cDIR_ID_COB)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_VEN, DbType.String, cPER_ID_VEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_COB, DbType.String, cPER_ID_COB)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_PRO, DbType.String, cPER_ID_PRO)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_GRU, DbType.String, cPER_ID_GRU)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_TIPO_LISTA, DbType.Int16, cDOC_TIPO_LISTA)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_MONTO_TOTAL, DbType.Double, cDOC_MONTO_TOTAL)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_CONTRAVALOR, DbType.Double, cDOC_CONTRAVALOR)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_IGV_POR, DbType.Double, cDOC_IGV_POR)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ASIENTO, DbType.Boolean, cDOC_ASIENTO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_CIERRE, DbType.Int16, cDOC_CIERRE)
                context.AddInParameter(cmd, Documentos.PropertyNames.FLE_ID, DbType.String, cFLE_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_MONTO_FLE, DbType.Double, cDOC_MONTO_FLE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_REQUIERE_GUIA, DbType.Boolean, cDOC_REQUIERE_GUIA)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDO_ID_AFE, DbType.String, cTDO_ID_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DTD_ID_AFE, DbType.String, cDTD_ID_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.CCT_ID_AFE, DbType.String, cCCT_ID_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_SERIE_AFE, DbType.String, cDOC_SERIE_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NUMERO_AFE, DbType.String, cDOC_NUMERO_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_MOT_EMI, DbType.Int16, cDOC_MOT_EMI)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NOMBRE_RECEP, DbType.String, cDOC_NOMBRE_RECEP)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_DNI_RECEP, DbType.String, cDOC_DNI_RECEP)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FEC_RECEP, DbType.DateTime, cDOC_FEC_RECEP)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ENTREGADO, DbType.Boolean, cDOC_ENTREGADO)
                context.AddInParameter(cmd, Documentos.PropertyNames.CAF_IX_NUMERO_PRO, DbType.String, cCAF_IX_NUMERO_PRO)
                context.AddInParameter(cmd, Documentos.PropertyNames.CAF_IX_ORDEN_COM, DbType.String, cCAF_IX_ORDEN_COM)
                context.AddInParameter(cmd, Documentos.PropertyNames.LPR_ID, DbType.String, cLPR_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FEC_GRAB, DbType.DateTime, cDOC_FEC_GRAB)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ESTADO, DbType.Int16, cDOC_ESTADO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_MONTO_PERCEPCION, DbType.Double, cDOC_MONTO_PERCEPCION)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDO_ID_GEN, DbType.String, cTDO_ID_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.DTD_ID_GEN, DbType.String, cDTD_ID_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.CCT_ID_GEN, DbType.String, cCCT_ID_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_SERIE_GEN, DbType.String, cDOC_SERIE_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NUMERO_GEN, DbType.String, cDOC_NUMERO_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_OBSERVACIONES, DbType.String, cDOC_OBSERVACIONES)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ATENCION, DbType.String, cDOC_ATENCION)

                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_HORA_INICIO, DbType.DateTime, cDOC_HORA_INICIO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_HORA_FIN, DbType.DateTime, cDOC_HORA_FIN)

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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDOC_SERIE As String, ByVal cDOC_NUMERO As String) As Short Implements IDocumentosRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDocumentos)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_SERIE, DbType.String, cDOC_SERIE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NUMERO, DbType.String, cDOC_NUMERO)
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

        Public Function spInsertarRegistro(ByVal Orm As Documentos) As Short Implements IDocumentosRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDocumentos)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.CCT_ID, DbType.String, Orm.CCT_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_SERIE, DbType.String, Orm.DOC_SERIE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NUMERO, DbType.String, Orm.DOC_NUMERO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ORDEN_COMPRA, DbType.String, Orm.DOC_ORDEN_COMPRA)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_TIPO_ORDEN_COMPRA, DbType.Int16, Orm.DOC_TIPO_ORDEN_COMPRA)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_REC, DbType.String, Orm.PER_ID_REC)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDP_ID_REC, DbType.String, Orm.TDP_ID_REC)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_ENT_REC, DbType.String, Orm.DIR_ID_ENT_REC)
                context.AddInParameter(cmd, Documentos.PropertyNames.PVE_ID, DbType.String, Orm.PVE_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.PVE_ID_DES, DbType.String, Orm.PVE_ID_DES)
                context.AddInParameter(cmd, Documentos.PropertyNames.MON_ID, DbType.String, Orm.MON_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.TIV_ID, DbType.String, Orm.TIV_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_CLI, DbType.String, Orm.PER_ID_CLI)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDP_ID_CLI, DbType.String, Orm.TDP_ID_CLI)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_CON, DbType.String, Orm.PER_ID_CON)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FECHA_EMI, DbType.DateTime, Orm.DOC_FECHA_EMI)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FECHA_ENT, DbType.DateTime, Orm.DOC_FECHA_ENT)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FECHA_EXP, DbType.DateTime, Orm.DOC_FECHA_EXP)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_FIS, DbType.String, Orm.DIR_ID_FIS)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_DOM, DbType.String, Orm.DIR_ID_DOM)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_ENT, DbType.String, Orm.DIR_ID_ENT)
                context.AddInParameter(cmd, Documentos.PropertyNames.DIR_ID_COB, DbType.String, Orm.DIR_ID_COB)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_VEN, DbType.String, Orm.PER_ID_VEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_COB, DbType.String, Orm.PER_ID_COB)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_PRO, DbType.String, Orm.PER_ID_PRO)
                context.AddInParameter(cmd, Documentos.PropertyNames.PER_ID_GRU, DbType.String, Orm.PER_ID_GRU)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_TIPO_LISTA, DbType.Int16, Orm.DOC_TIPO_LISTA)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_MONTO_TOTAL, DbType.Double, Orm.DOC_MONTO_TOTAL)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_CONTRAVALOR, DbType.Double, Orm.DOC_CONTRAVALOR)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_IGV_POR, DbType.Double, Orm.DOC_IGV_POR)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ASIENTO, DbType.Boolean, Orm.DOC_ASIENTO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_CIERRE, DbType.Int16, Orm.DOC_CIERRE)
                context.AddInParameter(cmd, Documentos.PropertyNames.FLE_ID, DbType.String, Orm.FLE_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_MONTO_FLE, DbType.Double, Orm.DOC_MONTO_FLE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_REQUIERE_GUIA, DbType.Boolean, Orm.DOC_REQUIERE_GUIA)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDO_ID_AFE, DbType.String, Orm.TDO_ID_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DTD_ID_AFE, DbType.String, Orm.DTD_ID_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.CCT_ID_AFE, DbType.String, Orm.CCT_ID_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_SERIE_AFE, DbType.String, Orm.DOC_SERIE_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NUMERO_AFE, DbType.String, Orm.DOC_NUMERO_AFE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_MOT_EMI, DbType.Int16, Orm.DOC_MOT_EMI)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NOMBRE_RECEP, DbType.String, Orm.DOC_NOMBRE_RECEP)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_DNI_RECEP, DbType.String, Orm.DOC_DNI_RECEP)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FEC_RECEP, DbType.DateTime, Orm.DOC_FEC_RECEP)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ENTREGADO, DbType.Boolean, Orm.DOC_ENTREGADO)
                context.AddInParameter(cmd, Documentos.PropertyNames.CAF_IX_NUMERO_PRO, DbType.String, Orm.CAF_IX_NUMERO_PRO)
                context.AddInParameter(cmd, Documentos.PropertyNames.CAF_IX_ORDEN_COM, DbType.String, Orm.CAF_IX_ORDEN_COM)
                context.AddInParameter(cmd, Documentos.PropertyNames.LPR_ID, DbType.String, Orm.LPR_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FEC_GRAB, DbType.DateTime, Orm.DOC_FEC_GRAB)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ESTADO, DbType.Int16, Orm.DOC_ESTADO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_MONTO_PERCEPCION, DbType.Double, Orm.DOC_MONTO_PERCEPCION)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDO_ID_GEN, DbType.String, Orm.TDO_ID_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.DTD_ID_GEN, DbType.String, Orm.DTD_ID_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.CCT_ID_GEN, DbType.String, Orm.CCT_ID_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_SERIE_GEN, DbType.String, Orm.DOC_SERIE_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NUMERO_GEN, DbType.String, Orm.DOC_NUMERO_GEN)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_OBSERVACIONES, DbType.String, Orm.DOC_OBSERVACIONES)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ATENCION, DbType.String, Orm.DOC_ATENCION)

                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_HORA_INICIO, DbType.DateTime, Orm.DOC_HORA_INICIO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_HORA_FIN, DbType.DateTime, Orm.DOC_HORA_FIN)

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

        Public Function spActualizarDocumentosTIV_ID(ByVal item As BE.Documentos) As Short Implements IDocumentosRepositorio.spActualizarDocumentosTIV_ID
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarTIV_IDDocumentos)
                context.AddInParameter(cmd, Documentos.PropertyNames.TDO_ID, DbType.String, item.TDO_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DTD_ID, DbType.String, item.DTD_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_SERIE, DbType.String, item.DOC_SERIE)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_NUMERO, DbType.String, item.DOC_NUMERO)
                context.AddInParameter(cmd, Documentos.PropertyNames.TIV_ID, DbType.String, item.TIV_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.USU_ID, DbType.String, item.USU_ID)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_FEC_GRAB, DbType.DateTime, item.DOC_FEC_GRAB)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_ESTADO, DbType.Int16, item.DOC_ESTADO)
                context.AddInParameter(cmd, Documentos.PropertyNames.DOC_OBSERVACIONES, DbType.String, item.DOC_OBSERVACIONES)
                context.ExecuteNonQuery(cmd)
                spActualizarDocumentosTIV_ID = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarDocumentosTIV_ID = 0
            End Try
        End Function

        Public Function GetById(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DOC_SERIE As String, ByVal DOC_NUMERO As String) As BE.Documentos Implements IDocumentosRepositorio.GetById
            Dim result As Documentos = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.CommandTimeout = 900
                result = (From c In context.Documentos.Include("Personas3.DireccionesPersonas") Where c.TDO_ID = TDO_ID And c.DTD_ID = DTD_ID And c.DOC_SERIE = DOC_SERIE And c.DOC_NUMERO = DOC_NUMERO Select c).FirstOrDefault

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

Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class KardexCtaCteRepositorio
        Implements IKardexCtaCteRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.KardexCtaCte) As Short Implements IKardexCtaCteRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.KardexCtaCte.ApplyChanges(item)
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

        Public Function DeleteRegistro(ByVal item As BE.KardexCtaCte, ByVal cDocumento As String, ByVal cITEM As Short) As Short Implements IKardexCtaCteRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.KardexCtaCte Where c.DOCUMENTO = cDocumento And c.ITEM = cITEM Select c).FirstOrDefault()
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

        Public Function spActualizarRegistro(ByVal cDOC_FECHA_EMI_REF As Date, ByVal cDOC_FECHA_VEN_REF As Date, ByVal cCUC_ID_REF As String, ByVal cCCO_ID_REF As String, ByVal cCCC_ID_REF As String, ByVal cCCT_ID_REF As String, ByVal cTDO_ID_REF As String, ByVal cDTD_ID_REF As String, ByVal cDOC_SERIE_REF As String, ByVal cDOC_NUMERO_REF As String, ByVal cITEM_REF As Short, ByVal cMON_ID_CCC As String, ByVal cCCC_ID As String, ByVal cCCT_ID As String, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDOC_SERIE As String, ByVal cDOC_NUMERO As String, ByVal cITEM As Short, ByVal cMON_ID As String, ByVal cPER_ID_CLI As String, ByVal cCARGO As Double, ByVal cABONO As Double, ByVal cDTE_CONTRAVALOR_DOC As Double, ByVal cMPT_MEDIO_PAGO As Short, ByVal cMPT_NUMERO_MEDIO As String, ByVal cPER_ID_BAN As String, ByVal cDOCUMENTO As String) As Short Implements IKardexCtaCteRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroKardexCtaCte)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_FECHA_EMI_REF, DbType.DateTime, cDOC_FECHA_EMI_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_FECHA_VEN_REF, DbType.DateTime, cDOC_FECHA_VEN_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CUC_ID_REF, DbType.String, cCUC_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCO_ID_REF, DbType.String, cCCO_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCC_ID_REF, DbType.String, cCCC_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCT_ID_REF, DbType.String, cCCT_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.TDO_ID_REF, DbType.String, cTDO_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DTD_ID_REF, DbType.String, cDTD_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_SERIE_REF, DbType.String, cDOC_SERIE_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_NUMERO_REF, DbType.String, cDOC_NUMERO_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ITEM_REF, DbType.Int16, cITEM_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.MON_ID_CCC, DbType.String, cMON_ID_CCC)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_SERIE, DbType.String, cDOC_SERIE)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_NUMERO, DbType.String, cDOC_NUMERO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ITEM, DbType.Int16, cITEM)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CARGO, DbType.Double, cCARGO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ABONO, DbType.Double, cABONO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DTE_CONTRAVALOR_DOC, DbType.Double, cDTE_CONTRAVALOR_DOC)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.MPT_MEDIO_PAGO, DbType.Int16, cMPT_MEDIO_PAGO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.MPT_NUMERO_MEDIO, DbType.String, cMPT_NUMERO_MEDIO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.PER_ID_BAN, DbType.String, cPER_ID_BAN)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
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

        Public Function spEliminarRegistro(ByVal cITEM As Short, ByVal cDOCUMENTO As String) As Short Implements IKardexCtaCteRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroKardexCtaCte)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ITEM, DbType.Int16, cITEM)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
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

        Public Function spEliminarRegistroExtorno(ByVal cITEM As Short, ByVal cDOCUMENTO As String) As Short Implements IKardexCtaCteRepositorio.spEliminarRegistroExtorno
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroKardexCtaCteExtorno)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ITEM, DbType.Int16, cITEM)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistroExtorno = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistroExtorno = 0
            End Try
        End Function

        Public Function spEliminarRegistroCobranza(ByVal cITEM As Short, ByVal cDOCUMENTO As String, ByVal cPER_ID_CLI As String) As Short Implements IKardexCtaCteRepositorio.spEliminarRegistroCobranza
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroKardexCtaCteCobranza)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ITEM, DbType.Int16, cITEM)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistroCobranza = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistroCobranza = 0
            End Try
        End Function

        Public Function spEliminarRegistroLegal(ByVal cITEM As Short, ByVal cDOCUMENTO As String, ByVal cPER_ID_CLI As String) As Short Implements IKardexCtaCteRepositorio.spEliminarRegistroLegal
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroKardexCtaCteLegal)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ITEM, DbType.Int16, cITEM)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistroLegal = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistroLegal = 0
            End Try
        End Function

        Public Function spInsertarRegistro(ByVal cDOC_FECHA_EMI_REF As Date, ByVal cDOC_FECHA_VEN_REF As Date, ByVal cCUC_ID_REF As String, ByVal cCCO_ID_REF As String, ByVal cCCC_ID_REF As String, ByVal cCCT_ID_REF As String, ByVal cTDO_ID_REF As String, ByVal cDTD_ID_REF As String, ByVal cDOC_SERIE_REF As String, ByVal cDOC_NUMERO_REF As String, ByVal cITEM_REF As Short, ByVal cMON_ID_CCC As String, ByVal cCCC_ID As String, ByVal cCCT_ID As String, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDOC_SERIE As String, ByVal cDOC_NUMERO As String, ByVal cITEM As Short, ByVal cMON_ID As String, ByVal cPER_ID_CLI As String, ByVal cCARGO As Double, ByVal cABONO As Double, ByVal cDTE_CONTRAVALOR_DOC As Double, ByVal cMPT_MEDIO_PAGO As Short, ByVal cMPT_NUMERO_MEDIO As String, ByVal cPER_ID_BAN As String, ByVal cDOCUMENTO As String) As Short Implements IKardexCtaCteRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroKardexCtaCte)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_FECHA_EMI_REF, DbType.DateTime, cDOC_FECHA_EMI_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_FECHA_VEN_REF, DbType.DateTime, cDOC_FECHA_VEN_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CUC_ID_REF, DbType.String, cCUC_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCO_ID_REF, DbType.String, cCCO_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCC_ID_REF, DbType.String, cCCC_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCT_ID_REF, DbType.String, cCCT_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.TDO_ID_REF, DbType.String, cTDO_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DTD_ID_REF, DbType.String, cDTD_ID_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_SERIE_REF, DbType.String, cDOC_SERIE_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_NUMERO_REF, DbType.String, cDOC_NUMERO_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ITEM_REF, DbType.Int16, cITEM_REF)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.MON_ID_CCC, DbType.String, cMON_ID_CCC)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_SERIE, DbType.String, cDOC_SERIE)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOC_NUMERO, DbType.String, cDOC_NUMERO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ITEM, DbType.Int16, cITEM)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CARGO, DbType.Double, cCARGO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ABONO, DbType.Double, cABONO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DTE_CONTRAVALOR_DOC, DbType.Double, cDTE_CONTRAVALOR_DOC)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.MPT_MEDIO_PAGO, DbType.Int16, cMPT_MEDIO_PAGO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.MPT_NUMERO_MEDIO, DbType.String, cMPT_NUMERO_MEDIO)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.PER_ID_BAN, DbType.String, cPER_ID_BAN)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                ''
                ''cmd.CommandTimeout = 0
                context.ExecuteNonQuery(cmd)
                ''
                spInsertarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spInsertarRegistro = 0
            End Try
        End Function

        Public Function spEliminarRegistroVoucher(ByVal cITEM As Short, ByVal cCCC_ID As String, ByVal cDOCUMENTO As String) As Short Implements IKardexCtaCteRepositorio.spEliminarRegistroVoucher
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroKardexCtaCteVoucher)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.ITEM, DbType.Int16, cITEM)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, KardexCtaCte.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistroVoucher = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistroVoucher = 0
            End Try
        End Function
    End Class
End Namespace

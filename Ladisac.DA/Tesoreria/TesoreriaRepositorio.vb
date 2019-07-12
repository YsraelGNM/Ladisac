Imports Microsoft.Practices.UnityImports Ladisac.BEImports System.TextNamespace Ladisac.DAPublic Class TesoreriaRepositorio        Implements ITesoreriaRepositorio        <Dependency()> _        Public Property ContainerService As IUnityContainer        Public Function Maintenance(ByVal item As BE.Tesoreria) As Short Implements ITesoreriaRepositorio.Maintenance            Try                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()                context.Tesoreria.ApplyChanges(item)                context.SaveChanges()                item.AcceptChanges()                Maintenance = 1            Catch ex As Exception                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)                If (rethrow) Then                    Throw                End If                Maintenance = 0            End Try        End Function        Public Function DeleteRegistro(ByVal item As BE.Tesoreria, ByVal cTDO_ID As String, ByVal cCCC_ID As String, ByVal cTES_SERIE As String, ByVal cTES_NUMERO As String, ByVal cDTD_ID As String) As Short Implements ITesoreriaRepositorio.DeleteRegistro            Try                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()                item = (From c In context.Tesoreria Where c.TDO_ID = cTDO_ID And c.CCC_ID = cCCC_ID And c.TES_SERIE = cTES_SERIE And c.TES_NUMERO = cTES_NUMERO And c.DTD_ID = cDTD_ID Select c).FirstOrDefault()                item.MarkAsDeleted()                DeleteRegistro = Maintenance(item)            Catch ex As Exception                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)                If (rethrow) Then                    Throw                End If                DeleteRegistro = 0            End Try        End Function
        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTES_SERIE As String, ByVal cTES_NUMERO As String, ByVal cTES_FECHA_EMI As Date, ByVal cPVE_ID As String, ByVal cPER_ID_CAJ As String, ByVal cTES_MONTO_TOTAL As Double, ByVal cTES_ASIENTO As Boolean, ByVal cTES_CIERRE As Short, ByVal cUSU_ID As String, ByVal cTES_FEC_GRAB As Date, ByVal cTES_ESTADO As Boolean) As Short Implements ITesoreriaRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroTesoreria)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_SERIE, DbType.String, cTES_SERIE)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_NUMERO, DbType.String, cTES_NUMERO)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_FECHA_EMI, DbType.DateTime, cTES_FECHA_EMI)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.PVE_ID, DbType.String, cPVE_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.PER_ID_CAJ, DbType.String, cPER_ID_CAJ)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_MONTO_TOTAL, DbType.Double, cTES_MONTO_TOTAL)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_ASIENTO, DbType.Boolean, cTES_ASIENTO)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_CIERRE, DbType.Int16, cTES_CIERRE)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_FEC_GRAB, DbType.DateTime, cTES_FEC_GRAB)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_ESTADO, DbType.Boolean, cTES_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTES_SERIE As String, ByVal cTES_NUMERO As String) As Short Implements ITesoreriaRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroTesoreria)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_SERIE, DbType.String, cTES_SERIE)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_NUMERO, DbType.String, cTES_NUMERO)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTES_SERIE As String, ByVal cTES_NUMERO As String, ByVal cTES_FECHA_EMI As Date, ByVal cPVE_ID As String, ByVal cPER_ID_CAJ As String, ByVal cTES_MONTO_TOTAL As Double, ByVal cTES_ASIENTO As Boolean, ByVal cTES_CIERRE As Short, ByVal cUSU_ID As String, ByVal cTES_FEC_GRAB As Date, ByVal cTES_ESTADO As Boolean) As Short Implements ITesoreriaRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroTesoreria)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_SERIE, DbType.String, cTES_SERIE)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_NUMERO, DbType.String, cTES_NUMERO)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_FECHA_EMI, DbType.DateTime, cTES_FECHA_EMI)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.PVE_ID, DbType.String, cPVE_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.PER_ID_CAJ, DbType.String, cPER_ID_CAJ)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_MONTO_TOTAL, DbType.Double, cTES_MONTO_TOTAL)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_ASIENTO, DbType.Boolean, cTES_ASIENTO)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_CIERRE, DbType.Int16, cTES_CIERRE)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_FEC_GRAB, DbType.DateTime, cTES_FEC_GRAB)
                context.AddInParameter(cmd, Tesoreria.PropertyNames.TES_ESTADO, DbType.Boolean, cTES_ESTADO)
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
    End ClassEnd Namespace
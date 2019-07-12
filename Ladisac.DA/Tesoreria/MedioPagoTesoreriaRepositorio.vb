Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class MedioPagoTesoreriaRepositorio
        Implements IMedioPagoTesoreriaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.MedioPagoTesoreria) As Short Implements IMedioPagoTesoreriaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.MedioPagoTesoreria.ApplyChanges(item)
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
        Public Function DeleteRegistro(ByVal item As BE.MedioPagoTesoreria, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String, ByVal cMPT_ITEM As String) As Short Implements IMedioPagoTesoreriaRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.MedioPagoTesoreria Where c.TDO_ID = cTDO_ID And c.DTD_ID = cDTD_ID And c.CCC_ID = cCCC_ID And c.MPT_SERIE = cMPT_SERIE And c.MPT_NUMERO = cMPT_NUMERO And c.MPT_ITEM = cMPT_ITEM Select c).FirstOrDefault()
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String, ByVal cMPT_ITEM As Short, ByVal cMPT_IMPORTE_AFECTO As Double, ByVal cMPT_PORCENTAJE As Double, ByVal cCHE_ID As String, ByVal cMPT_MEDIO_PAGO As Short, ByVal cMPT_SERIE_MEDIO As String, ByVal cMPT_NUMERO_MEDIO As String, ByVal cMPT_GIRADO_A As String, ByVal cMPT_CONCEPTO As String, ByVal cMPT_UBICACION As Short, ByVal cPER_ID_BAN As String, ByVal cMPT_DIFERIDO As Boolean, ByVal cMPT_FECHA_DIFERIDO As Date, ByVal cMPT_RECEPCION As Short, ByVal cUSU_ID As String, ByVal cMPT_FEC_GRAB As Date, ByVal cMPT_ESTADO As Boolean) As Short Implements IMedioPagoTesoreriaRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroMedioPagoTesoreria)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_SERIE, DbType.String, cMPT_SERIE)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_NUMERO, DbType.String, cMPT_NUMERO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_ITEM, DbType.Int16, cMPT_ITEM)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_IMPORTE_AFECTO, DbType.Double, cMPT_IMPORTE_AFECTO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_PORCENTAJE, DbType.Double, cMPT_PORCENTAJE)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.CHE_ID, DbType.String, cCHE_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_MEDIO_PAGO, DbType.Int16, cMPT_MEDIO_PAGO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_SERIE_MEDIO, DbType.String, cMPT_SERIE_MEDIO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_NUMERO_MEDIO, DbType.String, cMPT_NUMERO_MEDIO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_GIRADO_A, DbType.String, cMPT_GIRADO_A)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_CONCEPTO, DbType.String, cMPT_CONCEPTO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_UBICACION, DbType.Int16, cMPT_UBICACION)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.PER_ID_BAN, DbType.String, cPER_ID_BAN)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_DIFERIDO, DbType.Boolean, cMPT_DIFERIDO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_FECHA_DIFERIDO, DbType.DateTime, cMPT_FECHA_DIFERIDO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_RECEPCION, DbType.Int16, cMPT_RECEPCION)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_FEC_GRAB, DbType.DateTime, cMPT_FEC_GRAB)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_ESTADO, DbType.Boolean, cMPT_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String, ByVal cMPT_ITEM As Short) As Short Implements IMedioPagoTesoreriaRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroMedioPagoTesoreria)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_SERIE, DbType.String, cMPT_SERIE)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_NUMERO, DbType.String, cMPT_NUMERO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_ITEM, DbType.Int16, cMPT_ITEM)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String, ByVal cMPT_ITEM As Short, ByVal cMPT_IMPORTE_AFECTO As Double, ByVal cMPT_PORCENTAJE As Double, ByVal cCHE_ID As String, ByVal cMPT_MEDIO_PAGO As Short, ByVal cMPT_SERIE_MEDIO As String, ByVal cMPT_NUMERO_MEDIO As String, ByVal cMPT_GIRADO_A As String, ByVal cMPT_CONCEPTO As String, ByVal cMPT_UBICACION As Short, ByVal cPER_ID_BAN As String, ByVal cMPT_DIFERIDO As Boolean, ByVal cMPT_FECHA_DIFERIDO As Date, ByVal cMPT_RECEPCION As Short, ByVal cUSU_ID As String, ByVal cMPT_FEC_GRAB As Date, ByVal cMPT_ESTADO As Boolean) As Short Implements IMedioPagoTesoreriaRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroMedioPagoTesoreria)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_SERIE, DbType.String, cMPT_SERIE)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_NUMERO, DbType.String, cMPT_NUMERO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_ITEM, DbType.Int16, cMPT_ITEM)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_IMPORTE_AFECTO, DbType.Double, cMPT_IMPORTE_AFECTO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_PORCENTAJE, DbType.Double, cMPT_PORCENTAJE)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.CHE_ID, DbType.String, cCHE_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_MEDIO_PAGO, DbType.Int16, cMPT_MEDIO_PAGO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_SERIE_MEDIO, DbType.String, cMPT_SERIE_MEDIO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_NUMERO_MEDIO, DbType.String, cMPT_NUMERO_MEDIO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_GIRADO_A, DbType.String, cMPT_GIRADO_A)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_CONCEPTO, DbType.String, cMPT_CONCEPTO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_UBICACION, DbType.Int16, cMPT_UBICACION)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.PER_ID_BAN, DbType.String, cPER_ID_BAN)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_DIFERIDO, DbType.Boolean, cMPT_DIFERIDO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_FECHA_DIFERIDO, DbType.DateTime, cMPT_FECHA_DIFERIDO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_RECEPCION, DbType.Int16, cMPT_RECEPCION)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_FEC_GRAB, DbType.DateTime, cMPT_FEC_GRAB)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_ESTADO, DbType.Boolean, cMPT_ESTADO)
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

        Public Function spEliminarRegistroGeneral(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String) As Short Implements IMedioPagoTesoreriaRepositorio.spEliminarRegistroGeneral
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroGeneralMedioPagoTesoreria)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_SERIE, DbType.String, cMPT_SERIE)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_NUMERO, DbType.String, cMPT_NUMERO)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistroGeneral = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistroGeneral = 0
            End Try
        End Function

        Public Function spActualizarMPT_UBICACION(ByVal cTDO_ID As String, ByVal cCCC_ID As String, ByVal cPER_ID_BAN As String, ByVal cMPT_SERIE_MEDIO As String, ByVal cMPT_NUMERO_MEDIO As String, ByVal cMPT_UBICACION As Int16) As Short Implements IMedioPagoTesoreriaRepositorio.spActualizarMPT_UBICACION
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarMPT_UBICACION)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.PER_ID_BAN, DbType.String, cPER_ID_BAN)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_SERIE_MEDIO, DbType.String, cMPT_SERIE_MEDIO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_NUMERO_MEDIO, DbType.String, cMPT_NUMERO_MEDIO)
                context.AddInParameter(cmd, MedioPagoTesoreria.PropertyNames.MPT_UBICACION, DbType.Int16, cMPT_UBICACION)
                context.ExecuteNonQuery(cmd)
                spActualizarMPT_UBICACION = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarMPT_UBICACION = 0
            End Try

        End Function
    End Class
End Namespace

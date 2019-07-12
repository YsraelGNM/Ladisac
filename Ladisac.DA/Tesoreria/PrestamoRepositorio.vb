Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class PrestamoRepositorio
        Implements IPrestamoRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.Prestamo) As Short Implements IPrestamoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Prestamo.ApplyChanges(item)
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
        Public Function DeleteRegistro(ByVal item As BE.Prestamo, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cPRE_SERIE As String, ByVal cPRE_NUMERO As String) As Short Implements IPrestamoRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.Prestamo Where c.TDO_ID = cTDO_ID And c.DTD_ID = cDTD_ID And c.CCC_ID = cCCC_ID And c.PRE_SERIE = cPRE_SERIE And c.PRE_NUMERO = cPRE_NUMERO Select c).FirstOrDefault()
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cPRE_SERIE As String, ByVal cPRE_NUMERO As String, ByVal cPRE_FECHA_EMI As DateTime, ByVal cPVE_ID As String, ByVal cPER_ID_CAJ As String, ByVal cPRE_MONTO_TOTAL As Double, ByVal cPRE_TIPO As Boolean, ByVal cUSU_ID As String, ByVal cPRE_FEC_GRAB As DateTime, ByVal cPRE_ESTADO As Boolean) As Short Implements IPrestamoRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroPrestamo)
                context.AddInParameter(cmd, Prestamo.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_SERIE, DbType.String, cPRE_SERIE)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_NUMERO, DbType.String, cPRE_NUMERO)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_FECHA_EMI, DbType.DateTime, cPRE_FECHA_EMI)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PVE_ID, DbType.String, cPVE_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PER_ID_CAJ, DbType.String, cPER_ID_CAJ)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_MONTO_TOTAL, DbType.Double, cPRE_MONTO_TOTAL)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_TIPO, DbType.Boolean, cPRE_TIPO)
                context.AddInParameter(cmd, Prestamo.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_FEC_GRAB, DbType.DateTime, cPRE_FEC_GRAB)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_ESTADO, DbType.Boolean, cPRE_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cPRE_SERIE As String, ByVal cPRE_NUMERO As String) As Short Implements IPrestamoRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroPrestamo)
                context.AddInParameter(cmd, Prestamo.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_SERIE, DbType.String, cPRE_SERIE)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_NUMERO, DbType.String, cPRE_NUMERO)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cPRE_SERIE As String, ByVal cPRE_NUMERO As String, ByVal cPRE_FECHA_EMI As DateTime, ByVal cPVE_ID As String, ByVal cPER_ID_CAJ As String, ByVal cPRE_MONTO_TOTAL As Double, ByVal cPRE_TIPO As Boolean, ByVal cUSU_ID As String, ByVal cPRE_FEC_GRAB As DateTime, ByVal cPRE_ESTADO As Boolean) As Short Implements IPrestamoRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroPrestamo)
                context.AddInParameter(cmd, Prestamo.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_SERIE, DbType.String, cPRE_SERIE)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_NUMERO, DbType.String, cPRE_NUMERO)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_FECHA_EMI, DbType.DateTime, cPRE_FECHA_EMI)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PVE_ID, DbType.String, cPVE_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PER_ID_CAJ, DbType.String, cPER_ID_CAJ)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_MONTO_TOTAL, DbType.Double, cPRE_MONTO_TOTAL)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_TIPO, DbType.Boolean, cPRE_TIPO)
                context.AddInParameter(cmd, Prestamo.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_FEC_GRAB, DbType.DateTime, cPRE_FEC_GRAB)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_ESTADO, DbType.Boolean, cPRE_ESTADO)
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

        Public Function spActualizarEnlace(ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String, ByVal CCT_IDe As String, ByVal Orm As BE.Tesoreria) As Short Implements IPrestamoRepositorio.spActualizarEnlace
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarEnlacePrestamo)
                context.AddInParameter(cmd, Prestamo.PropertyNames.TDO_ID, DbType.String, "035")
                context.AddInParameter(cmd, Prestamo.PropertyNames.DTD_ID, DbType.String, "288")
                context.AddInParameter(cmd, Prestamo.PropertyNames.CCC_ID, DbType.String, "001")
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_SERIE, DbType.String, PRE_SERIE)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_NUMERO, DbType.String, PRE_NUMERO)
                context.AddInParameter(cmd, Prestamo.PropertyNames.TDO_ID_ENL, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.DTD_ID_ENL, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.CCC_ID_ENL, DbType.String, Orm.CCC_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_SERIE_ENL, DbType.String, Orm.TES_SERIE)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_NUMERO_ENL, DbType.String, Orm.TES_NUMERO)
                context.AddInParameter(cmd, Prestamo.PropertyNames.CCT_ID_ENL, DbType.String, CCT_IDe)

                context.ExecuteNonQuery(cmd)
                spActualizarEnlace = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarEnlace = 0
            End Try
        End Function

        Public Function spEliminarEnlace(ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String, ByVal CCT_IDe As String, ByVal Orm As BE.Tesoreria) As Short Implements IPrestamoRepositorio.spEliminarEnlace
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarEnlacePrestamo)
                ''context.AddInParameter(cmd, Prestamo.PropertyNames.TDO_ID, DbType.String, "035")
                ''context.AddInParameter(cmd, Prestamo.PropertyNames.DTD_ID, DbType.String, "288")
                ''context.AddInParameter(cmd, Prestamo.PropertyNames.CCC_ID, DbType.String, "001")
                ''context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_SERIE, DbType.String, PRE_SERIE)
                ''context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_NUMERO, DbType.String, PRE_NUMERO)
                context.AddInParameter(cmd, Prestamo.PropertyNames.TDO_ID_ENL, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.DTD_ID_ENL, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.CCC_ID_ENL, DbType.String, Orm.CCC_ID)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_SERIE_ENL, DbType.String, Orm.TES_SERIE)
                context.AddInParameter(cmd, Prestamo.PropertyNames.PRE_NUMERO_ENL, DbType.String, Orm.TES_NUMERO)
                context.AddInParameter(cmd, Prestamo.PropertyNames.CCT_ID_ENL, DbType.String, CCT_IDe)

                context.ExecuteNonQuery(cmd)
                spEliminarEnlace = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarEnlace = 0
            End Try
        End Function
    End Class
End Namespace

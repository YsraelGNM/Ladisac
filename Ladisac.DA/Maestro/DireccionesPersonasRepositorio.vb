Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class DireccionesPersonasRepositorio
        Implements DA.IDireccionesPersonasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.DireccionesPersonas) As Short Implements IDireccionesPersonasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DireccionesPersonas.ApplyChanges(item)
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

        Public Function spEliminarDireccionesPersonasPER_ID(ByVal PER_ID As String) As Short Implements IDireccionesPersonasRepositorio.spEliminarDireccionesPersonasPER_ID
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarDireccionesPersonasPER_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID, DbType.String, PER_ID)
                context.ExecuteNonQuery(cmd)
                spEliminarDireccionesPersonasPER_ID = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarDireccionesPersonasPER_ID = 0
            End Try
        End Function

        Public Function DeleteRegistro(ByVal item As BE.DireccionesPersonas, ByVal cPER_ID As String, ByVal cDIR_ID As String) As Short Implements IDireccionesPersonasRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.DireccionesPersonas Where c.PER_ID = cPER_ID And _
                                                                    c.DIR_ID = cDIR_ID Select c).FirstOrDefault()
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

        Public Function spActualizarRegistro(ByVal cDIR_ID As String, ByVal cPER_ID As String, ByVal cDIR_DESCRIPCION As String, ByVal cDIR_TIPO As Short, ByVal cDIR_REFERENCIA As String, ByVal cDIS_ID As String, ByVal cUSU_ID As String, ByVal cDIR_FEC_GRAB As Date, ByVal cDIR_ESTADO As Boolean) As Short Implements IDireccionesPersonasRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDireccionesPersonas)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_ID, DbType.String, cDIR_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_DESCRIPCION, DbType.String, cDIR_DESCRIPCION)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_TIPO, DbType.Int16, cDIR_TIPO)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_REFERENCIA, DbType.String, cDIR_REFERENCIA)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIS_ID, DbType.String, cDIS_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_FEC_GRAB, DbType.DateTime, cDIR_FEC_GRAB)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_ESTADO, DbType.Boolean, cDIR_ESTADO)
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

        Public Function spInsertarRegistro(ByVal cDIR_ID As String, ByVal cPER_ID As String, ByVal cDIR_DESCRIPCION As String, ByVal cDIR_TIPO As Short, ByVal cDIR_REFERENCIA As String, ByVal cDIS_ID As String, ByVal cUSU_ID As String, ByVal cDIR_FEC_GRAB As Date, ByVal cDIR_ESTADO As Boolean) As Short Implements IDireccionesPersonasRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDireccionesPersonas)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_ID, DbType.String, cDIR_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_DESCRIPCION, DbType.String, cDIR_DESCRIPCION)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_TIPO, DbType.Int16, cDIR_TIPO)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_REFERENCIA, DbType.String, cDIR_REFERENCIA)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIS_ID, DbType.String, cDIS_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_FEC_GRAB, DbType.DateTime, cDIR_FEC_GRAB)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_ESTADO, DbType.Boolean, cDIR_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cDIR_ID As String, ByVal cPER_ID As String) As Short Implements IDireccionesPersonasRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDireccionesPersonas)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_ID, DbType.String, cDIR_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.PER_ID, DbType.String, cPER_ID)
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

        Public Function spEliminarRegistroNuevo(ByVal cDIR_ID As String, ByVal cPER_ID As String, ByVal cUSU_ID As String) As Short Implements IDireccionesPersonasRepositorio.spEliminarRegistroNuevo
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDireccionesPersonasNuevo)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.DIR_ID, DbType.String, cDIR_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, DireccionesPersonas.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistroNuevo = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistroNuevo = 0
            End Try
        End Function
    End Class
End Namespace

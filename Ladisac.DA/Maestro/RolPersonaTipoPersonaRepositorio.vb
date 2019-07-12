Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class RolPersonaTipoPersonaRepositorio
        Implements DA.IRolPersonaTipoPersonaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.RolPersonaTipoPersona) As Short Implements IRolPersonaTipoPersonaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.RolPersonaTipoPersona.ApplyChanges(item)
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

        Public Function spEliminarRolPersonaTipoPersonaPER_ID(ByVal PER_ID As String) As Short Implements IRolPersonaTipoPersonaRepositorio.spEliminarRolPersonaTipoPersonaPER_ID
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRolPersonaTipoPersonaPER_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID, DbType.String, PER_ID)
                context.ExecuteNonQuery(cmd)
                spEliminarRolPersonaTipoPersonaPER_ID = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRolPersonaTipoPersonaPER_ID = 0
            End Try
        End Function

        'Public Function DeleteRegistro(ByVal item As BE.RolPersonaTipoPersona, ByVal cPER_ID As String, ByVal cTPE_ID As String) As Short Implements IRolPersonaTipoPersonaRepositorio.DeleteRegistro
        '    Try
        '        Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
        '        item = (From c In context.RolPersonaTipoPersona Where c.PER_ID = cPER_ID And _
        '                                                              c.TPE_ID = cTPE_ID Select c).FirstOrDefault()
        '        item.MarkAsDeleted()
        '        DeleteRegistro = Maintenance(item)
        '    Catch ex As Exception
        '        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
        '        If (rethrow) Then
        '            Throw
        '        End If
        '        DeleteRegistro = 0
        '    End Try
        'End Function

        Public Function spActualizarRegistro(ByVal cPER_ID As String, ByVal cTPE_ID As String, ByVal cUSU_ID As String, ByVal cRTP_FEC_GRAB As Date, ByVal cRTP_ESTADO As Boolean) As Short Implements IRolPersonaTipoPersonaRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroRolPersonaTipoPersona)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.TPE_ID, DbType.String, cTPE_ID)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.RTP_FEC_GRAB, DbType.DateTime, cRTP_FEC_GRAB)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.RTP_ESTADO, DbType.Boolean, cRTP_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cPER_ID As String, ByVal cTPE_ID As String) As Short Implements IRolPersonaTipoPersonaRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroRolPersonaTipoPersona)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.TPE_ID, DbType.String, cTPE_ID)
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

        Public Function spInsertarRegistro(ByVal cPER_ID As String, ByVal cTPE_ID As String, ByVal cUSU_ID As String, ByVal cRTP_FEC_GRAB As Date, ByVal cRTP_ESTADO As Boolean) As Short Implements IRolPersonaTipoPersonaRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroRolPersonaTipoPersona)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.TPE_ID, DbType.String, cTPE_ID)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.RTP_FEC_GRAB, DbType.DateTime, cRTP_FEC_GRAB)
                context.AddInParameter(cmd, RolPersonaTipoPersona.PropertyNames.RTP_ESTADO, DbType.Boolean, cRTP_ESTADO)
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
    End Class
End Namespace

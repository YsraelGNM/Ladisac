Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class ContactoPersonaRepositorio
        Implements IContactoPersonaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.ContactoPersona) As Short Implements IContactoPersonaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ContactoPersona.ApplyChanges(item)
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
        'Public Function DeleteRegistro(ByVal item As BE.ContactoPersona, ByVal cPER_ID As String, ByVal cCOP_ID As String) As Short Implements IContactoPersonaRepositorio.DeleteRegistro
        '    Try
        '        Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
        '        item = (From c In context.ContactoPersona Where c.PER_ID = cPER_ID And _
        '                                                        c.COP_ID = cCOP_ID Select c).FirstOrDefault()
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

        Public Function ActualizarRegistro(ByVal cPER_ID As String, ByVal cCOP_ID As String, ByVal cCOP_TIPO As Short, ByVal cCOP_DESCRIPCION As String, ByVal cCOP_DIRECCION As String, ByVal cCOP_TELEFONO As String, ByVal cCOP_EMAIL As String, ByVal cUSU_ID As String, ByVal cCOP_FEC_GRAB As Date, ByVal cCOP_ESTADO As Boolean) As Short Implements IContactoPersonaRepositorio.ActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroContactoPersona)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_ID, DbType.String, cCOP_ID)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_TIPO, DbType.Int16, cCOP_TIPO)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_DESCRIPCION, DbType.String, cCOP_DESCRIPCION)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_DIRECCION, DbType.String, cCOP_DIRECCION)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_TELEFONO, DbType.String, cCOP_TELEFONO)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_EMAIL, DbType.String, cCOP_EMAIL)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_FEC_GRAB, DbType.DateTime, cCOP_FEC_GRAB)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_ESTADO, DbType.Boolean, cCOP_ESTADO)
                context.ExecuteNonQuery(cmd)
                ActualizarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                ActualizarRegistro = 0
            End Try
        End Function

        Public Function EliminarRegistro(ByVal cPER_ID As String, ByVal cCOP_ID As String) As Short Implements IContactoPersonaRepositorio.EliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroContactoPersona)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_ID, DbType.String, cCOP_ID)
                context.ExecuteNonQuery(cmd)
                EliminarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                EliminarRegistro = 0
            End Try
        End Function

        Public Function InsertarRegistro(ByVal cPER_ID As String, ByVal cCOP_ID As String, ByVal cCOP_TIPO As Short, ByVal cCOP_DESCRIPCION As String, ByVal cCOP_DIRECCION As String, ByVal cCOP_TELEFONO As String, ByVal cCOP_EMAIL As String, ByVal cUSU_ID As String, ByVal cCOP_FEC_GRAB As Date, ByVal cCOP_ESTADO As Boolean) As Short Implements IContactoPersonaRepositorio.InsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroContactoPersona)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_ID, DbType.String, cCOP_ID)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_TIPO, DbType.Int16, cCOP_TIPO)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_DESCRIPCION, DbType.String, cCOP_DESCRIPCION)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_DIRECCION, DbType.String, cCOP_DIRECCION)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_TELEFONO, DbType.String, cCOP_TELEFONO)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_EMAIL, DbType.String, cCOP_EMAIL)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_FEC_GRAB, DbType.DateTime, cCOP_FEC_GRAB)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.COP_ESTADO, DbType.Boolean, cCOP_ESTADO)
                context.ExecuteNonQuery(cmd)
                InsertarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                InsertarRegistro = 0
            End Try
        End Function

        Public Function spEliminarContactoPersonaPER_ID(ByVal PER_ID As String) As Short Implements IContactoPersonaRepositorio.spEliminarContactoPersonaPER_ID
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarContactoPersonaPER_ID)
                context.AddInParameter(cmd, ContactoPersona.PropertyNames.PER_ID, DbType.String, PER_ID)
                context.ExecuteNonQuery(cmd)
                spEliminarContactoPersonaPER_ID = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarContactoPersonaPER_ID = 0
            End Try
        End Function
    End Class
End Namespace

Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class DocPersonasRepositorio
        Implements DA.IDocPersonasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.DocPersonas) As Short Implements IDocPersonasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DocPersonas.ApplyChanges(item)
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

        Public Function spEliminarDocPersonasPER_ID(ByVal PER_ID As String) As Short Implements IDocPersonasRepositorio.spEliminarDocPersonasPER_ID
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarDocPersonasPER_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID, DbType.String, PER_ID)
                context.ExecuteNonQuery(cmd)
                spEliminarDocPersonasPER_ID = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarDocPersonasPER_ID = 0
            End Try
        End Function

        'Public Function DeleteRegistro(ByVal item As BE.DocPersonas, ByVal cPER_ID As String, ByVal cTDP_ID As String) As Short Implements IDocPersonasRepositorio.DeleteRegistro
        '    Try
        '        Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
        '        item = (From c In context.DocPersonas Where c.PER_ID = cPER_ID And _
        '                                                    c.TDP_ID = cTDP_ID Select c).FirstOrDefault()
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

        Public Function EliminarRegistro(ByVal cPER_ID As String, ByVal cTDP_ID As String) As Short Implements IDocPersonasRepositorio.EliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDocPersonas)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.TDP_ID, DbType.String, cTDP_ID)
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

        Public Function ActualizarRegistro(ByVal cPER_ID As String, ByVal cTDP_ID As String, ByVal cDOP_NUMERO As String, ByVal cUSU_ID As String, ByVal cDOP_FEC_GRAB As Date, ByVal cDOP_ESTADO As Boolean) As Short Implements IDocPersonasRepositorio.ActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDocPersonas)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.TDP_ID, DbType.String, cTDP_ID)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.DOP_NUMERO, DbType.String, cDOP_NUMERO)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.DOP_FEC_GRAB, DbType.DateTime, cDOP_FEC_GRAB)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.DOP_ESTADO, DbType.Boolean, cDOP_ESTADO)
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

        Public Function InsertarRegistro(ByVal cPER_ID As String, ByVal cTDP_ID As String, ByVal cDOP_NUMERO As String, ByVal cUSU_ID As String, ByVal cDOP_FEC_GRAB As Date, ByVal cDOP_ESTADO As Boolean) As Short Implements IDocPersonasRepositorio.InsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDocPersonas)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.TDP_ID, DbType.String, cTDP_ID)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.DOP_NUMERO, DbType.String, cDOP_NUMERO)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.DOP_FEC_GRAB, DbType.DateTime, cDOP_FEC_GRAB)
                context.AddInParameter(cmd, DocPersonas.PropertyNames.DOP_ESTADO, DbType.Boolean, cDOP_ESTADO)
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

        Public Function DocPersonaGetById_Numero(ByVal DOP_Numero As String) As BE.DocPersonas Implements IDocPersonasRepositorio.DocPersonaGetById_Numero
            Dim result As DocPersonas = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DocPersonas Where c.DOP_NUMERO = DOP_Numero Select c).FirstOrDefault

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

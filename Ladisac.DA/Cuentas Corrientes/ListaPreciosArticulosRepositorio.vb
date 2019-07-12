Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class ListaPreciosArticulosRepositorio
        Implements DA.IListaPreciosArticulosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.ListaPreciosArticulos) As Short Implements IListaPreciosArticulosRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ListaPreciosArticulos.ApplyChanges(item)
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

        Public Function spActualizarRegistro(ByVal cLPR_ID As String, ByVal cLPR_DESCRIPCION As String, ByVal cLPR_PRINCIPAL As Boolean, ByVal cPER_ID As String, ByVal cMON_ID As String, ByVal cUSU_ID As String, ByVal cLPR_FEC_GRAB As Date, ByVal cLPR_ESTADO As Boolean, ByVal cLPR_CONTROL As Boolean, ByVal cLPR_ID_ADJ As String) As Short Implements IListaPreciosArticulosRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroListaPreciosArticulos)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_ID, DbType.String, cLPR_ID)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_DESCRIPCION, DbType.String, cLPR_DESCRIPCION)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_PRINCIPAL, DbType.Boolean, cLPR_PRINCIPAL)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_FEC_GRAB, DbType.DateTime, cLPR_FEC_GRAB)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_ESTADO, DbType.Boolean, cLPR_ESTADO)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_CONTROL, DbType.Boolean, cLPR_CONTROL)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_ID_ADJ, DbType.String, cLPR_ID_ADJ)
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

        Public Function spEliminarRegistro(ByVal cLPR_ID As String) As Short Implements IListaPreciosArticulosRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroListaPreciosArticulos)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_ID, DbType.String, cLPR_ID)
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

        Public Function spInsertarRegistro(ByVal cLPR_ID As String, ByVal cLPR_DESCRIPCION As String, ByVal cLPR_PRINCIPAL As Boolean, ByVal cPER_ID As String, ByVal cMON_ID As String, ByVal cUSU_ID As String, ByVal cLPR_FEC_GRAB As Date, ByVal cLPR_ESTADO As Boolean, ByVal cLPR_CONTROL As Boolean, ByVal cLPR_ID_ADJ As String) As Short Implements IListaPreciosArticulosRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroListaPreciosArticulos)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_ID, DbType.String, cLPR_ID)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_DESCRIPCION, DbType.String, cLPR_DESCRIPCION)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_PRINCIPAL, DbType.Boolean, cLPR_PRINCIPAL)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_FEC_GRAB, DbType.DateTime, cLPR_FEC_GRAB)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_ESTADO, DbType.Boolean, cLPR_ESTADO)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_CONTROL, DbType.Boolean, cLPR_CONTROL)
                context.AddInParameter(cmd, ListaPreciosArticulos.PropertyNames.LPR_ID_ADJ, DbType.String, cLPR_ID_ADJ)
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

        Public Function spDetalleListaPreciosUpdate(ByVal registroxm As String, ByVal art_id As String, ByVal precio As Double) As Object Implements IListaPreciosArticulosRepositorio.spDetalleListaPreciosUpdate



            Try


                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spDetalleListaPreciosUpdate)
                context.AddInParameter(cmd, "@CabeceraXML", DbType.Xml, registroxm)
                context.AddInParameter(cmd, "@art_id", DbType.String, (art_id))
                context.AddInParameter(cmd, "@precio", DbType.Decimal, CDec(precio))

                Return context.ExecuteNonQuery(cmd)


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return 0


        End Function
        'spDetalleListaPreciosRecargaUpdate

        Public Function spDetalleListaPreciosRecargaUpdate(ByVal registroxm As String, ByVal art_id As String, ByVal precio As Double) As Object Implements IListaPreciosArticulosRepositorio.spDetalleListaPreciosRecargaUpdate

            Try


                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spDetalleListaPreciosRecargaUpdate)
                context.AddInParameter(cmd, "@CabeceraXML", DbType.Xml, registroxm)
                context.AddInParameter(cmd, "@art_id", DbType.String, (art_id))
                context.AddInParameter(cmd, "@precio", DbType.Decimal, CDec(precio))

                Return context.ExecuteNonQuery(cmd)


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return 0
        End Function

        Public Function spDetalleListaPreciosUpdateInsert(ByVal DatosModeloXml As String, ByVal DatosListaXml As String, ByVal cUSU_ID As String) As Object Implements IListaPreciosArticulosRepositorio.spDetalleListaPreciosUpdateInsert
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spDetalleListaPreciosUpdateInsert)
                context.AddInParameter(cmd, "@DatosModeloXML", DbType.Xml, DatosModeloXml)
                context.AddInParameter(cmd, "@DatosListaXML", DbType.Xml, DatosListaXml)
                context.AddInParameter(cmd, "@USU_ID", DbType.String, cUSU_ID)
                context.ExecuteNonQuery(cmd)
                spDetalleListaPreciosUpdateInsert = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spDetalleListaPreciosUpdateInsert = 0
            End Try
        End Function
    End Class
End Namespace

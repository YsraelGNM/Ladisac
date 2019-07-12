Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class PersonaRepositorio

        Implements IPersonaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal PER_Id As String) As BE.Personas Implements IPersonaRepositorio.GetById
            Dim result As Personas = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Personas.Include("DocPersonas").Include("DireccionesPersonas").Include("ContactoPersona").Include("RubroPersona.Rubro").Include("FotoPersonas").Include("DatosLaborales.AreaTrabajos") Where c.PER_ID = PER_Id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaPersona(ByVal Tipo As String, ByVal Filtro As String) As String Implements IPersonaRepositorio.ListaPersona
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd As System.Data.Common.DbCommand
                Select Case Tipo
                    Case "Trabajador"
                        cmd = context.GetStoredProcCommand("spListaPersonaTrabajador")
                    Case "Proveedor"
                        cmd = context.GetStoredProcCommand("spListaPersonaProveedor")
                    Case "Chofer"
                        cmd = context.GetStoredProcCommand("spListaPersonaChofer")
                    Case "Compras"
                        cmd = context.GetStoredProcCommand("spListaPersonaCompras")
                    Case "Cliente"
                        cmd = context.GetStoredProcCommand("spListaPersonaCliente2", IIf(Filtro = "", "", "and " & Filtro))
                    Case "Todo"
                        cmd = context.GetStoredProcCommand("spListaPersonaTodo")
                    Case "Usuario"
                        cmd = context.GetStoredProcCommand("spListaPersonaUsuario")
                End Select
                Dim reader = context.ExecuteReader(cmd)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                result = sb.ToString()

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.Personas) Implements IPersonaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Personas.ApplyChanges(item)
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

        Public Function spActualizarPersonasDIR_ID(ByVal PER_ID As String, ByVal DIR_ID As String) As Short Implements IPersonaRepositorio.spActualizarPersonasDIR_ID
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarPersonasDIR_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID, DbType.String, PER_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.DIR_ID, DbType.String, DIR_ID)
                context.ExecuteNonQuery(cmd)
                spActualizarPersonasDIR_ID = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarPersonasDIR_ID = 0
            End Try
        End Function

        Public Function spActualizarPersonasPER_LINEA_CREDITO(ByVal PER_ID As String, ByVal USU_ID As String) As Short Implements IPersonaRepositorio.spActualizarPersonasPER_LINEA_CREDITO
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarPersonasPER_LINEA_CREDITO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID, DbType.String, PER_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.USU_ID, DbType.String, USU_ID)
                context.ExecuteNonQuery(cmd)
                spActualizarPersonasPER_LINEA_CREDITO = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarPersonasPER_LINEA_CREDITO = 0
            End Try
        End Function

        'Public Function spEliminarPersonas(ByVal PER_ID As String) As Short Implements IPersonaRepositorio.spEliminarPersonas
        '    Try
        '        Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
        '        Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarPersonas)
        '        context.AddInParameter(cmd, Personas.PropertyNames.PER_ID, DbType.String, PER_ID)
        '        context.ExecuteNonQuery(cmd)
        '        spEliminarPersonas = 1
        '    Catch ex As Exception
        '        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
        '        If (rethrow) Then
        '            Throw
        '        End If
        '        spEliminarPersonas = 0
        '    End Try
        'End Function

        Public Function spActualizarRegistro(ByVal cPER_ID As String, ByVal cPER_CLIENTE As Boolean, ByVal cPER_CLIENTE_OP_CON As Short, ByVal cPER_PROVEEDOR As Boolean, ByVal cPER_PROVEEDOR_OP_CON As Short, ByVal cPER_TRANSPORTISTA As Boolean, ByVal cPER_TRANSPORTISTA_OP_CON As Short, ByVal cPER_TRABAJADOR As Boolean, ByVal cPER_TRABAJADOR_OP_CON As Short, ByVal cPER_BANCO As Boolean, ByVal cPER_BANCO_OP_CON As Short, ByVal cPER_GRUPO As Boolean, ByVal cPER_GRUPO_OP_CON As Short, ByVal cPER_CONTACTO As Boolean, ByVal cPER_CONTACTO_OP_CON As Short, ByVal cPER_TRANSP_PROPIO As Short, ByVal cPER_NOMBRES As String, ByVal cPER_APE_PAT As String, ByVal cPER_APE_MAT As String, ByVal cPER_BREVETE As String, ByVal cPER_FORMA_VENTA As Short, ByVal cDIR_ID As String, ByVal cPER_TELEFONOS As String, ByVal cPER_EMAIL As String, ByVal cPER_PAGINA_WEB As String, ByVal cPER_LINEA_CREDITO As Double, ByVal cPER_DIAS_CREDITO As Short, ByVal cPER_ID_VEN As String, ByVal cPER_ID_COB As String, ByVal cPER_ID_TRA As String, ByVal cPER_ID_BAN As String, ByVal cPER_ID_GRU As String, ByVal cPER_DIASEM_PAGO As Short, ByVal cPER_COND_DIASEM As Short, ByVal cPER_DIAMES_PAGO As Short, ByVal cPER_DOC_PAGO As Short, ByVal cPER_HORA_PAGO As String, ByVal cPER_OBSERVACIONES As String, ByVal cPER_PROMOCIONES As Boolean, ByVal cPER_CARTA_FIANZA As Short, ByVal cPER_CUOTA_MENSUAL As Double, ByVal cPER_CUOTA_OBJETIVO As Double, ByVal cPER_BONO As Double, ByVal cCCC_ID As String, ByVal cPER_CARGO As String, ByVal cPER_REP_LEGAL As Boolean, ByVal cPER_FIRMA_AUT As Boolean, ByVal cPER_PROCESAR_DESCUENTO As Boolean, ByVal cPER_ALIAS As String, ByVal cPER_LINEA_CREDITO_ESTADO As Boolean, ByVal cUSU_ID As String, ByVal cPER_FEC_GRAB As Date, ByVal cPER_ESTADO As Boolean, ByVal cPER_FECHA_ALTA As Date, ByVal cPER_FECHA_VENC As Date, ByVal cPER_GARANTIA As String, ByVal cPER_EXCESO_LINEA As Double) As Short Implements IPersonaRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroPersonas)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CLIENTE, DbType.Boolean, cPER_CLIENTE)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CLIENTE_OP_CON, DbType.Int16, cPER_CLIENTE_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PROVEEDOR, DbType.Boolean, cPER_PROVEEDOR)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PROVEEDOR_OP_CON, DbType.Int16, cPER_PROVEEDOR_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRANSPORTISTA, DbType.Boolean, cPER_TRANSPORTISTA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRANSPORTISTA_OP_CON, DbType.Int16, cPER_TRANSPORTISTA_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRABAJADOR, DbType.Boolean, cPER_TRABAJADOR)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRABAJADOR_OP_CON, DbType.Int16, cPER_TRABAJADOR_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_BANCO, DbType.Boolean, cPER_BANCO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_BANCO_OP_CON, DbType.Int16, cPER_BANCO_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_GRUPO, DbType.Boolean, cPER_GRUPO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_GRUPO_OP_CON, DbType.Int16, cPER_GRUPO_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CONTACTO, DbType.Boolean, cPER_CONTACTO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CONTACTO_OP_CON, DbType.Int16, cPER_CONTACTO_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRANSP_PROPIO, DbType.Int16, cPER_TRANSP_PROPIO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_NOMBRES, DbType.String, cPER_NOMBRES)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_APE_PAT, DbType.String, cPER_APE_PAT)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_APE_MAT, DbType.String, cPER_APE_MAT)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_BREVETE, DbType.String, cPER_BREVETE)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FORMA_VENTA, DbType.Int16, cPER_FORMA_VENTA)
                context.AddInParameter(cmd, Personas.PropertyNames.DIR_ID, DbType.String, cDIR_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TELEFONOS, DbType.String, cPER_TELEFONOS)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_EMAIL, DbType.String, cPER_EMAIL)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PAGINA_WEB, DbType.String, cPER_PAGINA_WEB)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_LINEA_CREDITO, DbType.Double, cPER_LINEA_CREDITO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_DIAS_CREDITO, DbType.Int16, cPER_DIAS_CREDITO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_VEN, DbType.String, cPER_ID_VEN)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_COB, DbType.String, cPER_ID_COB)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_TRA, DbType.String, cPER_ID_TRA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_BAN, DbType.String, cPER_ID_BAN)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_GRU, DbType.String, cPER_ID_GRU)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_DIASEM_PAGO, DbType.Int16, cPER_DIASEM_PAGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_COND_DIASEM, DbType.Int16, cPER_COND_DIASEM)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_DIAMES_PAGO, DbType.Int16, cPER_DIAMES_PAGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_DOC_PAGO, DbType.Int16, cPER_DOC_PAGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_HORA_PAGO, DbType.String, cPER_HORA_PAGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_OBSERVACIONES, DbType.String, cPER_OBSERVACIONES)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PROMOCIONES, DbType.Boolean, cPER_PROMOCIONES)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CARTA_FIANZA, DbType.Int16, cPER_CARTA_FIANZA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CUOTA_MENSUAL, DbType.Double, cPER_CUOTA_MENSUAL)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CUOTA_OBJETIVO, DbType.Double, cPER_CUOTA_OBJETIVO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_BONO, DbType.Double, cPER_BONO)
                context.AddInParameter(cmd, Personas.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CARGO, DbType.String, cPER_CARGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_REP_LEGAL, DbType.Boolean, cPER_REP_LEGAL)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FIRMA_AUT, DbType.Boolean, cPER_FIRMA_AUT)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PROCESAR_DESCUENTO, DbType.Boolean, cPER_PROCESAR_DESCUENTO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ALIAS, DbType.String, cPER_ALIAS)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_LINEA_CREDITO_ESTADO, DbType.Boolean, cPER_LINEA_CREDITO_ESTADO)
                context.AddInParameter(cmd, Personas.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FEC_GRAB, DbType.DateTime, cPER_FEC_GRAB)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ESTADO, DbType.Boolean, cPER_ESTADO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FECHA_ALTA, DbType.Date, cPER_FECHA_ALTA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FECHA_VENC, DbType.Date, cPER_FECHA_VENC)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_GARANTIA, DbType.String, cPER_GARANTIA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_EXCESO_LINEA, DbType.Double, cPER_EXCESO_LINEA)

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

        Public Function spEliminarRegistro(ByVal cPER_ID As String) As Short Implements IPersonaRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroPersonas)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID, DbType.String, cPER_ID)
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

        Public Function spInsertarRegistro(ByVal cPER_ID As String, ByVal cPER_CLIENTE As Boolean, ByVal cPER_CLIENTE_OP_CON As Short, ByVal cPER_PROVEEDOR As Boolean, ByVal cPER_PROVEEDOR_OP_CON As Short, ByVal cPER_TRANSPORTISTA As Boolean, ByVal cPER_TRANSPORTISTA_OP_CON As Short, ByVal cPER_TRABAJADOR As Boolean, ByVal cPER_TRABAJADOR_OP_CON As Short, ByVal cPER_BANCO As Boolean, ByVal cPER_BANCO_OP_CON As Short, ByVal cPER_GRUPO As Boolean, ByVal cPER_GRUPO_OP_CON As Short, ByVal cPER_CONTACTO As Boolean, ByVal cPER_CONTACTO_OP_CON As Short, ByVal cPER_TRANSP_PROPIO As Short, ByVal cPER_NOMBRES As String, ByVal cPER_APE_PAT As String, ByVal cPER_APE_MAT As String, ByVal cPER_BREVETE As String, ByVal cPER_FORMA_VENTA As Short, ByVal cDIR_ID As String, ByVal cPER_TELEFONOS As String, ByVal cPER_EMAIL As String, ByVal cPER_PAGINA_WEB As String, ByVal cPER_LINEA_CREDITO As Double, ByVal cPER_DIAS_CREDITO As Short, ByVal cPER_ID_VEN As String, ByVal cPER_ID_COB As String, ByVal cPER_ID_TRA As String, ByVal cPER_ID_BAN As String, ByVal cPER_ID_GRU As String, ByVal cPER_DIASEM_PAGO As Short, ByVal cPER_COND_DIASEM As Short, ByVal cPER_DIAMES_PAGO As Short, ByVal cPER_DOC_PAGO As Short, ByVal cPER_HORA_PAGO As String, ByVal cPER_OBSERVACIONES As String, ByVal cPER_PROMOCIONES As Boolean, ByVal cPER_CARTA_FIANZA As Short, ByVal cPER_CUOTA_MENSUAL As Double, ByVal cPER_CUOTA_OBJETIVO As Double, ByVal cPER_BONO As Double, ByVal cCCC_ID As String, ByVal cPER_CARGO As String, ByVal cPER_REP_LEGAL As Boolean, ByVal cPER_FIRMA_AUT As Boolean, ByVal cPER_PROCESAR_DESCUENTO As Boolean, ByVal cPER_ALIAS As String, ByVal cPER_LINEA_CREDITO_ESTADO As Boolean, ByVal cUSU_ID As String, ByVal cPER_FEC_GRAB As Date, ByVal cPER_ESTADO As Boolean, ByVal cPER_FECHA_ALTA As Date, ByVal cPER_FECHA_VENC As Date, ByVal cPER_GARANTIA As String, ByVal cPER_EXCESO_LINEA As Double) As Short Implements IPersonaRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroPersonas)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CLIENTE, DbType.Boolean, cPER_CLIENTE)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CLIENTE_OP_CON, DbType.Int16, cPER_CLIENTE_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PROVEEDOR, DbType.Boolean, cPER_PROVEEDOR)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PROVEEDOR_OP_CON, DbType.Int16, cPER_PROVEEDOR_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRANSPORTISTA, DbType.Boolean, cPER_TRANSPORTISTA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRANSPORTISTA_OP_CON, DbType.Int16, cPER_TRANSPORTISTA_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRABAJADOR, DbType.Boolean, cPER_TRABAJADOR)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRABAJADOR_OP_CON, DbType.Int16, cPER_TRABAJADOR_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_BANCO, DbType.Boolean, cPER_BANCO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_BANCO_OP_CON, DbType.Int16, cPER_BANCO_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_GRUPO, DbType.Boolean, cPER_GRUPO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_GRUPO_OP_CON, DbType.Int16, cPER_GRUPO_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CONTACTO, DbType.Boolean, cPER_CONTACTO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CONTACTO_OP_CON, DbType.Int16, cPER_CONTACTO_OP_CON)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TRANSP_PROPIO, DbType.Int16, cPER_TRANSP_PROPIO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_NOMBRES, DbType.String, cPER_NOMBRES)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_APE_PAT, DbType.String, cPER_APE_PAT)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_APE_MAT, DbType.String, cPER_APE_MAT)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_BREVETE, DbType.String, cPER_BREVETE)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FORMA_VENTA, DbType.Int16, cPER_FORMA_VENTA)
                context.AddInParameter(cmd, Personas.PropertyNames.DIR_ID, DbType.String, cDIR_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_TELEFONOS, DbType.String, cPER_TELEFONOS)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_EMAIL, DbType.String, cPER_EMAIL)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PAGINA_WEB, DbType.String, cPER_PAGINA_WEB)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_LINEA_CREDITO, DbType.Double, cPER_LINEA_CREDITO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_DIAS_CREDITO, DbType.Int16, cPER_DIAS_CREDITO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_VEN, DbType.String, cPER_ID_VEN)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_COB, DbType.String, cPER_ID_COB)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_TRA, DbType.String, cPER_ID_TRA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_BAN, DbType.String, cPER_ID_BAN)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ID_GRU, DbType.String, cPER_ID_GRU)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_DIASEM_PAGO, DbType.Int16, cPER_DIASEM_PAGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_COND_DIASEM, DbType.Int16, cPER_COND_DIASEM)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_DIAMES_PAGO, DbType.Int16, cPER_DIAMES_PAGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_DOC_PAGO, DbType.Int16, cPER_DOC_PAGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_HORA_PAGO, DbType.String, cPER_HORA_PAGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_OBSERVACIONES, DbType.String, cPER_OBSERVACIONES)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PROMOCIONES, DbType.Boolean, cPER_PROMOCIONES)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CARTA_FIANZA, DbType.Int16, cPER_CARTA_FIANZA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CUOTA_MENSUAL, DbType.Double, cPER_CUOTA_MENSUAL)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CUOTA_OBJETIVO, DbType.Double, cPER_CUOTA_OBJETIVO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_BONO, DbType.Double, cPER_BONO)
                context.AddInParameter(cmd, Personas.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_CARGO, DbType.String, cPER_CARGO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_REP_LEGAL, DbType.Boolean, cPER_REP_LEGAL)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FIRMA_AUT, DbType.Boolean, cPER_FIRMA_AUT)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_PROCESAR_DESCUENTO, DbType.Boolean, cPER_PROCESAR_DESCUENTO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ALIAS, DbType.String, cPER_ALIAS)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_LINEA_CREDITO_ESTADO, DbType.Boolean, cPER_LINEA_CREDITO_ESTADO)
                context.AddInParameter(cmd, Personas.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FEC_GRAB, DbType.DateTime, cPER_FEC_GRAB)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_ESTADO, DbType.Boolean, cPER_ESTADO)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FECHA_ALTA, DbType.Date, cPER_FECHA_ALTA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_FECHA_VENC, DbType.Date, cPER_FECHA_VENC)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_GARANTIA, DbType.String, cPER_GARANTIA)
                context.AddInParameter(cmd, Personas.PropertyNames.PER_EXCESO_LINEA, DbType.Double, cPER_EXCESO_LINEA)

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



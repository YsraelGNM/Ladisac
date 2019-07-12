Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCPersona
        Implements IBCPersona
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public MensajeError As String = ""

        Public Function ListaPersona(ByVal Tipo As String, Optional ByVal Filtro As String = "") As String Implements IBCPersona.ListaPersona
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPersonaRepositorio)()
                result = rep.ListaPersona(Tipo, Filtro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MantenimientoPersonas(ByVal Item As BE.Personas) Implements IBCPersona.MantenimientoPersonas
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPersonaRepositorio)()
                'Using Scope As New System.Transactions.TransactionScope()
                If Item.ChangeTracker.State <> ObjectState.Deleted Then
                    If Item.ProcesarVerificarDatos() = 0 Then
                        MantenimientoPersonas = 0
                        Exit Function
                    End If
                End If
                MantenimientoPersonas = rep.Maintenance(Item)
                'Scope.Complete()
                'End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Item.vMensajeError = ex.Message
                Else
                    Item.vMensajeError = ex.InnerException.Message
                End If
                MantenimientoPersonas = 0
            End Try
        End Function

        Public Function PersonaGetById(ByVal PER_ID As String) As BE.Personas Implements IBCPersona.PersonaGetById
            Dim result As Personas = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPersonaRepositorio)()
                result = rep.GetById(PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spActualizarPersonasDIR_ID(ByVal PER_ID As String, _
                                                   ByVal DIR_ID As String) As Object Implements IBCPersona.spActualizarPersonasDIR_ID
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPersonaRepositorio)()
                    rep.spActualizarPersonasDIR_ID(PER_ID, DIR_ID)
                    Scope.Complete()
                    spActualizarPersonasDIR_ID = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        MensajeError &= ex.Message
                    Else
                        MensajeError &= ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spActualizarPersonasDIR_ID = 0
                End Try
            End Using
        End Function

        Public Function spActualizarPersonasPER_LINEA_CREDITO(ByVal PER_ID As String, ByVal USU_ID As String) As Object Implements IBCPersona.spActualizarPersonasPER_LINEA_CREDITO
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPersonaRepositorio)()
                    rep.spActualizarPersonasPER_LINEA_CREDITO(PER_ID, USU_ID)
                    Scope.Complete()
                    spActualizarPersonasPER_LINEA_CREDITO = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        MensajeError &= ex.Message
                    Else
                        MensajeError &= ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spActualizarPersonasPER_LINEA_CREDITO = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistro(ByVal cPER_ID As String) As Short Implements IBCPersona.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPersonaRepositorio)()
                    rep.spEliminarRegistro(cPER_ID)
                    Scope.Complete()
                    spEliminarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        MensajeError &= ex.Message
                    Else
                        MensajeError &= ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spEliminarRegistro = 0
                End Try
            End Using
        End Function

        Public Property pMensajeError As String Implements IBCPersona.pMensajeError
            Get
                Return MensajeError
            End Get
            Set(ByVal value As String)
                MensajeError = value
            End Set
        End Property

        Public Function spActualizarRegistro(ByVal cPER_ID As String, ByVal cPER_CLIENTE As Boolean, ByVal cPER_CLIENTE_OP_CON As Short, ByVal cPER_PROVEEDOR As Boolean, ByVal cPER_PROVEEDOR_OP_CON As Short, ByVal cPER_TRANSPORTISTA As Boolean, ByVal cPER_TRANSPORTISTA_OP_CON As Short, ByVal cPER_TRABAJADOR As Boolean, ByVal cPER_TRABAJADOR_OP_CON As Short, ByVal cPER_BANCO As Boolean, ByVal cPER_BANCO_OP_CON As Short, ByVal cPER_GRUPO As Boolean, ByVal cPER_GRUPO_OP_CON As Short, ByVal cPER_CONTACTO As Boolean, ByVal cPER_CONTACTO_OP_CON As Short, ByVal cPER_TRANSP_PROPIO As Short, ByVal cPER_NOMBRES As String, ByVal cPER_APE_PAT As String, ByVal cPER_APE_MAT As String, ByVal cPER_BREVETE As String, ByVal cPER_FORMA_VENTA As Short, ByVal cDIR_ID As String, ByVal cPER_TELEFONOS As String, ByVal cPER_EMAIL As String, ByVal cPER_PAGINA_WEB As String, ByVal cPER_LINEA_CREDITO As Double, ByVal cPER_DIAS_CREDITO As Short, ByVal cPER_ID_VEN As String, ByVal cPER_ID_COB As String, ByVal cPER_ID_TRA As String, ByVal cPER_ID_BAN As String, ByVal cPER_ID_GRU As String, ByVal cPER_DIASEM_PAGO As Short, ByVal cPER_COND_DIASEM As Short, ByVal cPER_DIAMES_PAGO As Short, ByVal cPER_DOC_PAGO As Short, ByVal cPER_HORA_PAGO As String, ByVal cPER_OBSERVACIONES As String, ByVal cPER_PROMOCIONES As Boolean, ByVal cPER_CARTA_FIANZA As Short, ByVal cPER_CUOTA_MENSUAL As Double, ByVal cPER_CUOTA_OBJETIVO As Double, ByVal cPER_BONO As Double, ByVal cCCC_ID As String, ByVal cPER_CARGO As String, ByVal cPER_REP_LEGAL As Boolean, ByVal cPER_FIRMA_AUT As Boolean, ByVal cPER_PROCESAR_DESCUENTO As Boolean, ByVal cPER_ALIAS As String, ByVal cPER_LINEA_CREDITO_ESTADO As Boolean, ByVal cUSU_ID As String, ByVal cPER_FEC_GRAB As Date, ByVal cPER_ESTADO As Boolean, ByVal cPER_FECHA_ALTA As Date, ByVal cPER_FECHA_VENC As Date, ByVal cPER_GARANTIA As String, ByVal cPER_EXCESO_LINEA As Double) As Short Implements IBCPersona.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPersonaRepositorio)()
                    rep.spActualizarRegistro(cPER_ID, cPER_CLIENTE, cPER_CLIENTE_OP_CON, cPER_PROVEEDOR, cPER_PROVEEDOR_OP_CON, cPER_TRANSPORTISTA, cPER_TRANSPORTISTA_OP_CON, cPER_TRABAJADOR, cPER_TRABAJADOR_OP_CON, cPER_BANCO, cPER_BANCO_OP_CON, cPER_GRUPO, cPER_GRUPO_OP_CON, cPER_CONTACTO, cPER_CONTACTO_OP_CON, cPER_TRANSP_PROPIO, cPER_NOMBRES, cPER_APE_PAT, cPER_APE_MAT, cPER_BREVETE, cPER_FORMA_VENTA, cDIR_ID, cPER_TELEFONOS, cPER_EMAIL, cPER_PAGINA_WEB, cPER_LINEA_CREDITO, cPER_DIAS_CREDITO, cPER_ID_VEN, cPER_ID_COB, cPER_ID_TRA, cPER_ID_BAN, cPER_ID_GRU, cPER_DIASEM_PAGO, cPER_COND_DIASEM, cPER_DIAMES_PAGO, cPER_DOC_PAGO, cPER_HORA_PAGO, cPER_OBSERVACIONES, cPER_PROMOCIONES, cPER_CARTA_FIANZA, cPER_CUOTA_MENSUAL, cPER_CUOTA_OBJETIVO, cPER_BONO, cCCC_ID, cPER_CARGO, cPER_REP_LEGAL, cPER_FIRMA_AUT, cPER_PROCESAR_DESCUENTO, cPER_ALIAS, cPER_LINEA_CREDITO_ESTADO, cUSU_ID, cPER_FEC_GRAB, cPER_ESTADO, cPER_FECHA_ALTA, cPER_FECHA_VENC, cPER_GARANTIA, cPER_EXCESO_LINEA)
                    Scope.Complete()
                    spActualizarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        MensajeError &= ex.Message
                    Else
                        MensajeError &= ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spActualizarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spInsertarRegistro(ByVal cPER_ID As String, ByVal cPER_CLIENTE As Boolean, ByVal cPER_CLIENTE_OP_CON As Short, ByVal cPER_PROVEEDOR As Boolean, ByVal cPER_PROVEEDOR_OP_CON As Short, ByVal cPER_TRANSPORTISTA As Boolean, ByVal cPER_TRANSPORTISTA_OP_CON As Short, ByVal cPER_TRABAJADOR As Boolean, ByVal cPER_TRABAJADOR_OP_CON As Short, ByVal cPER_BANCO As Boolean, ByVal cPER_BANCO_OP_CON As Short, ByVal cPER_GRUPO As Boolean, ByVal cPER_GRUPO_OP_CON As Short, ByVal cPER_CONTACTO As Boolean, ByVal cPER_CONTACTO_OP_CON As Short, ByVal cPER_TRANSP_PROPIO As Short, ByVal cPER_NOMBRES As String, ByVal cPER_APE_PAT As String, ByVal cPER_APE_MAT As String, ByVal cPER_BREVETE As String, ByVal cPER_FORMA_VENTA As Short, ByVal cDIR_ID As String, ByVal cPER_TELEFONOS As String, ByVal cPER_EMAIL As String, ByVal cPER_PAGINA_WEB As String, ByVal cPER_LINEA_CREDITO As Double, ByVal cPER_DIAS_CREDITO As Short, ByVal cPER_ID_VEN As String, ByVal cPER_ID_COB As String, ByVal cPER_ID_TRA As String, ByVal cPER_ID_BAN As String, ByVal cPER_ID_GRU As String, ByVal cPER_DIASEM_PAGO As Short, ByVal cPER_COND_DIASEM As Short, ByVal cPER_DIAMES_PAGO As Short, ByVal cPER_DOC_PAGO As Short, ByVal cPER_HORA_PAGO As String, ByVal cPER_OBSERVACIONES As String, ByVal cPER_PROMOCIONES As Boolean, ByVal cPER_CARTA_FIANZA As Short, ByVal cPER_CUOTA_MENSUAL As Double, ByVal cPER_CUOTA_OBJETIVO As Double, ByVal cPER_BONO As Double, ByVal cCCC_ID As String, ByVal cPER_CARGO As String, ByVal cPER_REP_LEGAL As Boolean, ByVal cPER_FIRMA_AUT As Boolean, ByVal cPER_PROCESAR_DESCUENTO As Boolean, ByVal cPER_ALIAS As String, ByVal cPER_LINEA_CREDITO_ESTADO As Boolean, ByVal cUSU_ID As String, ByVal cPER_FEC_GRAB As Date, ByVal cPER_ESTADO As Boolean, ByVal cPER_FECHA_ALTA As Date, ByVal cPER_FECHA_VENC As Date, ByVal cPER_GARANTIA As String, ByVal cPER_EXCESO_LINEA As Double) As Short Implements IBCPersona.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPersonaRepositorio)()
                    rep.spInsertarRegistro(cPER_ID, cPER_CLIENTE, cPER_CLIENTE_OP_CON, cPER_PROVEEDOR, cPER_PROVEEDOR_OP_CON, cPER_TRANSPORTISTA, cPER_TRANSPORTISTA_OP_CON, cPER_TRABAJADOR, cPER_TRABAJADOR_OP_CON, cPER_BANCO, cPER_BANCO_OP_CON, cPER_GRUPO, cPER_GRUPO_OP_CON, cPER_CONTACTO, cPER_CONTACTO_OP_CON, cPER_TRANSP_PROPIO, cPER_NOMBRES, cPER_APE_PAT, cPER_APE_MAT, cPER_BREVETE, cPER_FORMA_VENTA, cDIR_ID, cPER_TELEFONOS, cPER_EMAIL, cPER_PAGINA_WEB, cPER_LINEA_CREDITO, cPER_DIAS_CREDITO, cPER_ID_VEN, cPER_ID_COB, cPER_ID_TRA, cPER_ID_BAN, cPER_ID_GRU, cPER_DIASEM_PAGO, cPER_COND_DIASEM, cPER_DIAMES_PAGO, cPER_DOC_PAGO, cPER_HORA_PAGO, cPER_OBSERVACIONES, cPER_PROMOCIONES, cPER_CARTA_FIANZA, cPER_CUOTA_MENSUAL, cPER_CUOTA_OBJETIVO, cPER_BONO, cCCC_ID, cPER_CARGO, cPER_REP_LEGAL, cPER_FIRMA_AUT, cPER_PROCESAR_DESCUENTO, cPER_ALIAS, cPER_LINEA_CREDITO_ESTADO, cUSU_ID, cPER_FEC_GRAB, cPER_ESTADO, cPER_FECHA_ALTA, cPER_FECHA_VENC, cPER_GARANTIA, cPER_EXCESO_LINEA)
                    Scope.Complete()
                    spInsertarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        MensajeError &= ex.Message
                    Else
                        MensajeError &= ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spInsertarRegistro = 0
                End Try
            End Using
        End Function

        Public Function MantenimientoPersonas2(ByVal Item As BE.Personas) As Object Implements IBCPersona.MantenimientoPersonas2
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPersonaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (Item.ChangeTracker.State = ObjectState.Added) Then
                        Item.PER_ID = bcherramientas.Get_IdTx("Personas")
                    ElseIf (Item.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim CodDir As String = bcherramientas.Get_IdTx("DireccionesPersonas")
                    For Each mDir In Item.DireccionesPersonas
                        If (mDir.ChangeTracker.State = ObjectState.Added) Then
                            mDir.DIR_ID = CodDir
                        ElseIf (mDir.ChangeTracker.State = ObjectState.Modified) Then
                        End If
                        CodDir = String.Format("{0:00000000}", CInt(CodDir) + 1)
                    Next

                    Dim Cont As Integer
                    Dim Idx = (From mDet In Item.ContactoPersona Where mDet.ChangeTracker.State = ObjectState.Modified Select mDet).Count
                    Cont = Idx
                    For Each mContacto In Item.ContactoPersona
                        If (mContacto.ChangeTracker.State = ObjectState.Added) Then
                            Cont += 1
                            mContacto.COP_ID = String.Format("{0:00}", Cont)
                        ElseIf (mContacto.ChangeTracker.State = ObjectState.Modified) Then
                        End If
                    Next

                    Dim CodRuP As Integer = bcherramientas.Get_Id("RubroPersona")
                    For Each mRub In Item.RubroPersona
                        If (mRub.ChangeTracker.State = ObjectState.Added) Then
                            mRub.RUP_ID = CodRuP
                        ElseIf (mRub.ChangeTracker.State = ObjectState.Modified) Then
                        End If
                        CodRuP += 1
                    Next

                    rep.Maintenance(Item)

                    Scope.Complete()

                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Function

        Public Function ListaProveedor(ByVal Per_Id As String, ByVal Per_Calificacion As String, ByVal Rub_Id As Integer?) As String Implements IBCPersona.ListaProveedor
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaProveedor", Per_Id, Per_Calificacion, Rub_Id)
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

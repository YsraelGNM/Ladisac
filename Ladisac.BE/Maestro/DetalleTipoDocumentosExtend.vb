Imports Ladisac.BE
Partial Public Class DetalleTipoDocumentos
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public vFila As Int16 = 0
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 1
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "DTD_ID"
    Public CampoPrincipalValor = DTD_ID
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.DetalleTipoDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetalleTipoDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetalleTipoDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetalleTipoDocumentos"
            End Get
        End Property
    End Structure
    Private Shared Tabla As sTabla
    Public ReadOnly Property cTabla As Object
        Get
            Return Tabla
        End Get
    End Property
    Public Sub New()
        MyBase.New()
        ConfigurarDatosCampos()
    End Sub
    Private Sub ConfigurarDatosCampos()
        vElementosDatosComboBox = 15
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "TDO_ID"
        vArrayCamposBusqueda(1) = "TDO_DESCRIPCION"
        vArrayCamposBusqueda(2) = "DTD_ID"
        vArrayCamposBusqueda(3) = "DTD_DESCRIPCION"
        vArrayCamposBusqueda(4) = "DTD_CARGO_ABONO"
        vArrayCamposBusqueda(5) = "DTD_SIGNO"
        vArrayCamposBusqueda(6) = "DTD_SIGNO_D"
        vArrayCamposBusqueda(7) = "DTD_SIGNO_D_1"
        vArrayCamposBusqueda(8) = "DTD_MOVIMIENTO"
        vArrayCamposBusqueda(9) = "TDO_UBICACION"
        vArrayCamposBusqueda(10) = "DTD_PROCESO"
        vArrayCamposBusqueda(11) = "DTD_ESTADO"
        vArrayCamposBusqueda(12) = "DTD_CONTROL"
        vArrayCamposBusqueda(13) = "TDO_ESTADO"
        vArrayCamposBusqueda(14) = "TDO_CONTROL"
        vArrayCamposBusqueda(15) = "TDO_TABLA"

        vArrayDatosComboBox(0).NombreCampo = "TDO_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "TDO_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 45
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 485
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "DTD_ID"
        vArrayDatosComboBox(2).Longitud = 3
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 36
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "DTD_DESCRIPCION"
        vArrayDatosComboBox(3).Longitud = 45
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 485
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "DTD_CARGO_ABONO"
        vArrayDatosComboBox(4).Longitud = 5
        vArrayDatosComboBox(4).Tipo = "smallint"
        vArrayDatosComboBox(4).ParteEntera = 5
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(2, 1)
        vArrayDatosComboBox(4).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(4).Valores(0, 1) = "0"
        vArrayDatosComboBox(4).Valores(1, 0) = "CARGO"
        vArrayDatosComboBox(4).Valores(1, 1) = "1"
        vArrayDatosComboBox(4).Valores(2, 0) = "ABONO"
        vArrayDatosComboBox(4).Valores(2, 1) = "2"
        vArrayDatosComboBox(4).Ancho = 77
        vArrayDatosComboBox(4).Flag = True

        vArrayDatosComboBox(5).NombreCampo = "DTD_SIGNO"
        vArrayDatosComboBox(5).Longitud = 0
        vArrayDatosComboBox(5).Tipo = "bit"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(1, 1)
        vArrayDatosComboBox(5).Valores(0, 0) = "+"
        vArrayDatosComboBox(5).Valores(0, 1) = "0"
        vArrayDatosComboBox(5).Valores(1, 0) = "-"
        vArrayDatosComboBox(5).Valores(1, 1) = "1"
        vArrayDatosComboBox(5).Ancho = 30
        vArrayDatosComboBox(5).Flag = True

        vArrayDatosComboBox(6).NombreCampo = "DTD_SIGNO_D"
        vArrayDatosComboBox(6).Longitud = 0
        vArrayDatosComboBox(6).Tipo = "bit"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(1, 1)
        vArrayDatosComboBox(6).Valores(0, 0) = "+"
        vArrayDatosComboBox(6).Valores(0, 1) = "0"
        vArrayDatosComboBox(6).Valores(1, 0) = "-"
        vArrayDatosComboBox(6).Valores(1, 1) = "1"
        vArrayDatosComboBox(6).Ancho = 30
        vArrayDatosComboBox(6).Flag = True

        vArrayDatosComboBox(7).NombreCampo = "DTD_SIGNO_D_1"
        vArrayDatosComboBox(7).Longitud = 0
        vArrayDatosComboBox(7).Tipo = "bit"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(1, 1)
        vArrayDatosComboBox(7).Valores(0, 0) = "+"
        vArrayDatosComboBox(7).Valores(0, 1) = "0"
        vArrayDatosComboBox(7).Valores(1, 0) = "-"
        vArrayDatosComboBox(7).Valores(1, 1) = "1"
        vArrayDatosComboBox(7).Ancho = 30
        vArrayDatosComboBox(7).Flag = True

        vArrayDatosComboBox(8).NombreCampo = "DTD_MOVIMIENTO"
        vArrayDatosComboBox(8).Longitud = 5
        vArrayDatosComboBox(8).Tipo = "smallint"
        vArrayDatosComboBox(8).ParteEntera = 5
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(7, 1)
        vArrayDatosComboBox(8).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(8).Valores(0, 1) = "0"
        vArrayDatosComboBox(8).Valores(1, 0) = "ANTICIPO RECIBIDO"
        vArrayDatosComboBox(8).Valores(1, 1) = "1"
        vArrayDatosComboBox(8).Valores(2, 0) = "LIQUIDACION DE DOCUMENTOS"
        vArrayDatosComboBox(8).Valores(2, 1) = "2"
        vArrayDatosComboBox(8).Valores(3, 0) = "PLANILLA DE RENDICION DE CUENTAS"
        vArrayDatosComboBox(8).Valores(3, 1) = "3"
        vArrayDatosComboBox(8).Valores(4, 0) = "SOLO RETIRO - DEPOSITO"
        vArrayDatosComboBox(8).Valores(4, 1) = "4"
        vArrayDatosComboBox(8).Valores(5, 0) = "PRESTAMO POR COBRAR"
        vArrayDatosComboBox(8).Valores(5, 1) = "5"
        vArrayDatosComboBox(8).Valores(6, 0) = "NINGUNO CON CARGO A DOCUMENTO"
        vArrayDatosComboBox(8).Valores(6, 1) = "6"
        vArrayDatosComboBox(8).Valores(7, 0) = "VENTA POR DESPACHAR"
        vArrayDatosComboBox(8).Valores(7, 1) = "7"
        vArrayDatosComboBox(8).Ancho = 237
        vArrayDatosComboBox(8).Flag = True

        vArrayDatosComboBox(9).NombreCampo = "TDO_UBICACION"
        vArrayDatosComboBox(9).Longitud = 16
        vArrayDatosComboBox(9).Tipo = "varchar"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(2, 1)
        vArrayDatosComboBox(9).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(9).Valores(0, 1) = "0"
        vArrayDatosComboBox(9).Valores(1, 0) = "EN CAJA"
        vArrayDatosComboBox(9).Valores(1, 1) = "1"
        vArrayDatosComboBox(9).Valores(2, 0) = "EN CTA. DE BANCO"
        vArrayDatosComboBox(9).Valores(2, 1) = "2"
        vArrayDatosComboBox(9).Ancho = 130
        vArrayDatosComboBox(9).Flag = True

        vArrayDatosComboBox(10).NombreCampo = "DTD_PROCESO"
        vArrayDatosComboBox(10).Longitud = 5
        vArrayDatosComboBox(10).Tipo = "smallint"
        vArrayDatosComboBox(10).ParteEntera = 5
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(1, 1)
        vArrayDatosComboBox(10).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(10).Valores(0, 1) = "0"
        vArrayDatosComboBox(10).Valores(1, 0) = "DOCUMENTOS"
        vArrayDatosComboBox(10).Valores(1, 1) = "1"
        vArrayDatosComboBox(10).Ancho = 105
        vArrayDatosComboBox(10).Flag = True

        vArrayDatosComboBox(11).NombreCampo = "DTD_ESTADO"
        vArrayDatosComboBox(11).Longitud = 0
        vArrayDatosComboBox(11).Tipo = "bit"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(1, 1)
        vArrayDatosComboBox(11).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(11).Valores(0, 1) = "0"
        vArrayDatosComboBox(11).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(11).Valores(1, 1) = "1"
        vArrayDatosComboBox(11).Ancho = 85
        vArrayDatosComboBox(11).Flag = True

        vArrayDatosComboBox(12).NombreCampo = "DTD_CONTROL"
        vArrayDatosComboBox(12).Longitud = 0
        vArrayDatosComboBox(12).Tipo = "bit"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(1, 1)
        vArrayDatosComboBox(12).Valores(0, 0) = "SISTEMA"
        vArrayDatosComboBox(12).Valores(0, 1) = "0"
        vArrayDatosComboBox(12).Valores(1, 0) = "USUARIO"
        vArrayDatosComboBox(12).Valores(1, 1) = "1"
        vArrayDatosComboBox(12).Ancho = 75
        vArrayDatosComboBox(12).Flag = True

        vArrayDatosComboBox(13).NombreCampo = "TDO_ESTADO"
        vArrayDatosComboBox(13).Longitud = 9
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(1, 1)
        vArrayDatosComboBox(13).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(13).Valores(0, 1) = "0"
        vArrayDatosComboBox(13).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(13).Valores(1, 1) = "1"
        vArrayDatosComboBox(13).Ancho = 85
        vArrayDatosComboBox(13).Flag = True

        vArrayDatosComboBox(14).NombreCampo = "TDO_CONTROL"
        vArrayDatosComboBox(14).Longitud = 7
        vArrayDatosComboBox(14).Tipo = "varchar"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(1, 1)
        vArrayDatosComboBox(14).Valores(0, 0) = "SISTEMA"
        vArrayDatosComboBox(14).Valores(0, 1) = "0"
        vArrayDatosComboBox(14).Valores(1, 0) = "USUARIO"
        vArrayDatosComboBox(14).Valores(1, 1) = "1"
        vArrayDatosComboBox(14).Ancho = 75
        vArrayDatosComboBox(14).Flag = True

        vArrayDatosComboBox(15).NombreCampo = "TDO_TABLA"
        vArrayDatosComboBox(15).Longitud = 45
        vArrayDatosComboBox(15).Tipo = "varchar"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 485
        vArrayDatosComboBox(15).Flag = False

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As String) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "DTD_ID"
                    If Not IsNothing(DTD_ID) Then
                        If Len(DTD_ID.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TDO_ID"
                    If Len(TDO_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "DTD_DESCRIPCION"
                    If IsNothing(DTD_DESCRIPCION) Then
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    ElseIf Len(DTD_DESCRIPCION.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "DTD_CARGO_ABONO"
                    If DTD_CARGO_ABONO.GetType = GetType(Int16) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError =
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_SIGNO"
                    If DTD_SIGNO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_SIGNO_D"
                    If DTD_SIGNO_D.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_SIGNO_D_1"
                    If DTD_SIGNO_D_1.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_MOVIMIENTO"
                    If DTD_MOVIMIENTO.GetType = GetType(Int16) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError =
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_PROCESO"
                    If DTD_PROCESO.GetType = GetType(Int16) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError =
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_FEC_GRAB"
                    If DTD_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_ESTADO"
                    If DTD_ESTADO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_CONTROL"
                    If DTD_CONTROL.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

            End Select
            If VerificarDatos.NumeroError = 0 Then
                If VerificarDatos.MensajeError <> "" Then VerificarDatos.MensajeGeneral += VerificarDatos.MensajeError & Chr(13)
            End If
        Next
        If vFila <> 0 Then VerificarDatos.MensajeGeneral += "En la fila: " & vFila & Chr(13)
        Return VerificarDatos
    End Function
    Public Function SentenciaSqlBusqueda() As String
        SentenciaSqlBusqueda = ""
        If Vista = "BuscarRegistros" Then
            SentenciaSqlBusqueda = "spVistaDetalleTipoDocumentosXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetalleTipoDocumentosXML"
        End If
    End Function
    Public Function DevolverTiposCampos() As String
        DevolverTiposCampos = ""
        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)
            If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) Then
                For vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)
                    If vArrayDatosComboBox(vFila).Valores(vSubFila, 0) = Dato Then
                        DevolverTiposCampos = vArrayDatosComboBox(vFila).Valores(vSubFila, 1)
                        Exit Function
                    End If
                Next
            End If
        Next
        Return DevolverTiposCampos
    End Function
    Public Function TipoCampoEspecifico() As String
        TipoCampoEspecifico = ""
        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)
            If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) Then
                For vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)
                    If vArrayDatosComboBox(vFila).Valores(vSubFila, 1) = Dato Then
                        TipoCampoEspecifico = vArrayDatosComboBox(vFila).Valores(vSubFila, 0)
                        Exit Function
                    End If
                Next
            End If
        Next
        Return TipoCampoEspecifico
    End Function
    Public Function BuscarFormatos()
        BuscarFormatos = Nothing
        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)
            If UCase(Strings.Trim(vArrayDatosComboBox(vFila).NombreCampo)) = UCase(Strings.Trim(CampoId)) Then
                BuscarFormatos = vArrayDatosComboBox(vFila).Valores
                Exit Function
            End If
        Next
        Return BuscarFormatos
    End Function
    Public Function ProcesarVerificarDatos(ByVal ParamArray Parametros() As String) As Integer
        Try
            Dim oVerificarDatos As New ErrorData
            If Parametros Is Nothing Then
                oVerificarDatos = VerificarDatos(Parametros)
            Else
                oVerificarDatos = VerificarDatos("DTD_ID", "TDO_ID", "DTD_DESCRIPCION", "DTD_CARGO_ABONO", "DTD_SIGNO", "DTD_SIGNO_D", "DTD_SIGNO_D_1", "DTD_MOVIMIENTO", "DTD_PROCESO", "USU_ID", "DTD_FEC_GRAB", "DTD_ESTADO", "DTD_CONTROL")
            End If
            If oVerificarDatos.NumeroError = 0 Then
                vMensajeError = oVerificarDatos.MensajeGeneral
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            vMensajeError = ex.Message
            Return 0
        End Try
    End Function
End Class

Imports Ladisac.BE

Partial Public Class RolPersonaTipoPersona
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public CampoPrincipal = "PER_ID"
    Public CampoPrincipalSecundario = "TPE_ID"
    Public CampoPrincipalValor = PER_ID
    Public CampoPrincipalSecundarioValor = TPE_ID
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 2
    Public CadenaFiltrado As String = ""

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.RolPersonaTipoPersona"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "RolPersonaTipoPersona"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwRolPersonaTipoPersona"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaRolPersonaTipoPersona"
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
        vElementosDatosComboBox = 24
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "PER_ID"
        vArrayCamposBusqueda(1) = "PER_DESCRIPCION"
        vArrayCamposBusqueda(2) = "PER_PROVEEDOR"
        vArrayCamposBusqueda(3) = "PER_CLIENTE"
        vArrayCamposBusqueda(4) = "PER_TRANSPORTISTA"
        vArrayCamposBusqueda(5) = "PER_TRABAJADOR"
        vArrayCamposBusqueda(6) = "PER_BANCO"
        vArrayCamposBusqueda(7) = "PER_GRUPO"
        vArrayCamposBusqueda(8) = "PER_CONTACTO"
        vArrayCamposBusqueda(9) = "PER_ESTADO"
        vArrayCamposBusqueda(10) = "TPE_ID"
        vArrayCamposBusqueda(11) = "TPE_DESCRIPCION"
        vArrayCamposBusqueda(12) = "COM_ID"
        vArrayCamposBusqueda(13) = "COM_DESCRIPCION"
        vArrayCamposBusqueda(14) = "COM_VENTA_CAN"
        vArrayCamposBusqueda(15) = "TPE_CLIENTE"
        vArrayCamposBusqueda(16) = "TPE_PROVEEDOR"
        vArrayCamposBusqueda(17) = "TPE_TRANSPORTISTA"
        vArrayCamposBusqueda(18) = "TPE_TRABAJADOR"
        vArrayCamposBusqueda(19) = "TPE_BANCO"
        vArrayCamposBusqueda(20) = "TPE_GRUPO"
        vArrayCamposBusqueda(21) = "TPE_CONTACTO"
        vArrayCamposBusqueda(22) = "TPE_ESTADO"
        vArrayCamposBusqueda(23) = "TPE_CONTROL"
        vArrayCamposBusqueda(24) = "RTP_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "PER_ID"
        vArrayDatosComboBox(0).Longitud = 6
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 68
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "PER_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 77
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 828
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "PER_PROVEEDOR"
        vArrayDatosComboBox(2).Longitud = 2
        vArrayDatosComboBox(2).Tipo = "varchar"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(1, 1)
        vArrayDatosComboBox(2).Valores(0, 0) = "NO"
        vArrayDatosComboBox(2).Valores(0, 1) = "0"
        vArrayDatosComboBox(2).Valores(1, 0) = "SI"
        vArrayDatosComboBox(2).Valores(1, 1) = "1"
        vArrayDatosComboBox(2).Ancho = 40
        vArrayDatosComboBox(2).Flag = True

        vArrayDatosComboBox(3).NombreCampo = "PER_CLIENTE"
        vArrayDatosComboBox(3).Longitud = 2
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(1, 1)
        vArrayDatosComboBox(3).Valores(0, 0) = "NO"
        vArrayDatosComboBox(3).Valores(0, 1) = "0"
        vArrayDatosComboBox(3).Valores(1, 0) = "SI"
        vArrayDatosComboBox(3).Valores(1, 1) = "1"
        vArrayDatosComboBox(3).Ancho = 40
        vArrayDatosComboBox(3).Flag = True

        vArrayDatosComboBox(4).NombreCampo = "PER_TRANSPORTISTA"
        vArrayDatosComboBox(4).Longitud = 2
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(1, 1)
        vArrayDatosComboBox(4).Valores(0, 0) = "NO"
        vArrayDatosComboBox(4).Valores(0, 1) = "0"
        vArrayDatosComboBox(4).Valores(1, 0) = "SI"
        vArrayDatosComboBox(4).Valores(1, 1) = "1"
        vArrayDatosComboBox(4).Ancho = 40
        vArrayDatosComboBox(4).Flag = True

        vArrayDatosComboBox(5).NombreCampo = "PER_TRABAJADOR"
        vArrayDatosComboBox(5).Longitud = 2
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(1, 1)
        vArrayDatosComboBox(5).Valores(0, 0) = "NO"
        vArrayDatosComboBox(5).Valores(0, 1) = "0"
        vArrayDatosComboBox(5).Valores(1, 0) = "SI"
        vArrayDatosComboBox(5).Valores(1, 1) = "1"
        vArrayDatosComboBox(5).Ancho = 40
        vArrayDatosComboBox(5).Flag = True

        vArrayDatosComboBox(6).NombreCampo = "PER_BANCO"
        vArrayDatosComboBox(6).Longitud = 2
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(1, 1)
        vArrayDatosComboBox(6).Valores(0, 0) = "NO"
        vArrayDatosComboBox(6).Valores(0, 1) = "0"
        vArrayDatosComboBox(6).Valores(1, 0) = "SI"
        vArrayDatosComboBox(6).Valores(1, 1) = "1"
        vArrayDatosComboBox(6).Ancho = 40
        vArrayDatosComboBox(6).Flag = True

        vArrayDatosComboBox(7).NombreCampo = "PER_GRUPO"
        vArrayDatosComboBox(7).Longitud = 2
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(1, 1)
        vArrayDatosComboBox(7).Valores(0, 0) = "NO"
        vArrayDatosComboBox(7).Valores(0, 1) = "0"
        vArrayDatosComboBox(7).Valores(1, 0) = "SI"
        vArrayDatosComboBox(7).Valores(1, 1) = "1"
        vArrayDatosComboBox(7).Ancho = 40
        vArrayDatosComboBox(7).Flag = True

        vArrayDatosComboBox(8).NombreCampo = "PER_CONTACTO"
        vArrayDatosComboBox(8).Longitud = 2
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(1, 1)
        vArrayDatosComboBox(8).Valores(0, 0) = "NO"
        vArrayDatosComboBox(8).Valores(0, 1) = "0"
        vArrayDatosComboBox(8).Valores(1, 0) = "SI"
        vArrayDatosComboBox(8).Valores(1, 1) = "1"
        vArrayDatosComboBox(8).Ancho = 40
        vArrayDatosComboBox(8).Flag = True

        vArrayDatosComboBox(9).NombreCampo = "PER_ESTADO"
        vArrayDatosComboBox(9).Longitud = 9
        vArrayDatosComboBox(9).Tipo = "varchar"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(1, 1)
        vArrayDatosComboBox(9).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(9).Valores(0, 1) = "0"
        vArrayDatosComboBox(9).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(9).Valores(1, 1) = "1"
        vArrayDatosComboBox(9).Ancho = 85
        vArrayDatosComboBox(9).Flag = True

        vArrayDatosComboBox(10).NombreCampo = "TPE_ID"
        vArrayDatosComboBox(10).Longitud = 3
        vArrayDatosComboBox(10).Tipo = "char"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 36
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "TPE_DESCRIPCION"
        vArrayDatosComboBox(11).Longitud = 45
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 485
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "COM_ID"
        vArrayDatosComboBox(12).Longitud = 3
        vArrayDatosComboBox(12).Tipo = "char"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 36
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "COM_DESCRIPCION"
        vArrayDatosComboBox(13).Longitud = 45
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 485
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "COM_VENTA_CAN"
        vArrayDatosComboBox(14).Longitud = 51
        vArrayDatosComboBox(14).Tipo = "varchar"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 550
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "TPE_CLIENTE"
        vArrayDatosComboBox(15).Longitud = 2
        vArrayDatosComboBox(15).Tipo = "varchar"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(1, 1)
        vArrayDatosComboBox(15).Valores(0, 0) = "NO"
        vArrayDatosComboBox(15).Valores(0, 1) = "0"
        vArrayDatosComboBox(15).Valores(1, 0) = "SI"
        vArrayDatosComboBox(15).Valores(1, 1) = "1"
        vArrayDatosComboBox(15).Ancho = 40
        vArrayDatosComboBox(15).Flag = True

        vArrayDatosComboBox(16).NombreCampo = "TPE_PROVEEDOR"
        vArrayDatosComboBox(16).Longitud = 2
        vArrayDatosComboBox(16).Tipo = "varchar"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(1, 1)
        vArrayDatosComboBox(16).Valores(0, 0) = "NO"
        vArrayDatosComboBox(16).Valores(0, 1) = "0"
        vArrayDatosComboBox(16).Valores(1, 0) = "SI"
        vArrayDatosComboBox(16).Valores(1, 1) = "1"
        vArrayDatosComboBox(16).Ancho = 40
        vArrayDatosComboBox(16).Flag = True

        vArrayDatosComboBox(17).NombreCampo = "TPE_TRANSPORTISTA"
        vArrayDatosComboBox(17).Longitud = 2
        vArrayDatosComboBox(17).Tipo = "varchar"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(1, 1)
        vArrayDatosComboBox(17).Valores(0, 0) = "NO"
        vArrayDatosComboBox(17).Valores(0, 1) = "0"
        vArrayDatosComboBox(17).Valores(1, 0) = "SI"
        vArrayDatosComboBox(17).Valores(1, 1) = "1"
        vArrayDatosComboBox(17).Ancho = 40
        vArrayDatosComboBox(17).Flag = True

        vArrayDatosComboBox(18).NombreCampo = "TPE_TRABAJADOR"
        vArrayDatosComboBox(18).Longitud = 2
        vArrayDatosComboBox(18).Tipo = "varchar"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(1, 1)
        vArrayDatosComboBox(18).Valores(0, 0) = "NO"
        vArrayDatosComboBox(18).Valores(0, 1) = "0"
        vArrayDatosComboBox(18).Valores(1, 0) = "SI"
        vArrayDatosComboBox(18).Valores(1, 1) = "1"
        vArrayDatosComboBox(18).Ancho = 40
        vArrayDatosComboBox(18).Flag = True

        vArrayDatosComboBox(19).NombreCampo = "TPE_BANCO"
        vArrayDatosComboBox(19).Longitud = 2
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(1, 1)
        vArrayDatosComboBox(19).Valores(0, 0) = "NO"
        vArrayDatosComboBox(19).Valores(0, 1) = "0"
        vArrayDatosComboBox(19).Valores(1, 0) = "SI"
        vArrayDatosComboBox(19).Valores(1, 1) = "1"
        vArrayDatosComboBox(19).Ancho = 40
        vArrayDatosComboBox(19).Flag = True

        vArrayDatosComboBox(20).NombreCampo = "TPE_GRUPO"
        vArrayDatosComboBox(20).Longitud = 2
        vArrayDatosComboBox(20).Tipo = "varchar"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(1, 1)
        vArrayDatosComboBox(20).Valores(0, 0) = "NO"
        vArrayDatosComboBox(20).Valores(0, 1) = "0"
        vArrayDatosComboBox(20).Valores(1, 0) = "SI"
        vArrayDatosComboBox(20).Valores(1, 1) = "1"
        vArrayDatosComboBox(20).Ancho = 40
        vArrayDatosComboBox(20).Flag = True

        vArrayDatosComboBox(21).NombreCampo = "TPE_CONTACTO"
        vArrayDatosComboBox(21).Longitud = 2
        vArrayDatosComboBox(21).Tipo = "varchar"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(1, 1)
        vArrayDatosComboBox(21).Valores(0, 0) = "NO"
        vArrayDatosComboBox(21).Valores(0, 1) = "0"
        vArrayDatosComboBox(21).Valores(1, 0) = "SI"
        vArrayDatosComboBox(21).Valores(1, 1) = "1"
        vArrayDatosComboBox(21).Ancho = 40
        vArrayDatosComboBox(21).Flag = True

        vArrayDatosComboBox(22).NombreCampo = "TPE_ESTADO"
        vArrayDatosComboBox(22).Longitud = 9
        vArrayDatosComboBox(22).Tipo = "varchar"
        vArrayDatosComboBox(22).ParteEntera = 0
        vArrayDatosComboBox(22).ParteDecimal = 0
        ReDim vArrayDatosComboBox(22).Valores(1, 1)
        vArrayDatosComboBox(22).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(22).Valores(0, 1) = "0"
        vArrayDatosComboBox(22).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(22).Valores(1, 1) = "1"
        vArrayDatosComboBox(22).Ancho = 85
        vArrayDatosComboBox(22).Flag = True

        vArrayDatosComboBox(23).NombreCampo = "TPE_CONTROL"
        vArrayDatosComboBox(23).Longitud = 7
        vArrayDatosComboBox(23).Tipo = "varchar"
        vArrayDatosComboBox(23).ParteEntera = 0
        vArrayDatosComboBox(23).ParteDecimal = 0
        ReDim vArrayDatosComboBox(23).Valores(1, 1)
        vArrayDatosComboBox(23).Valores(0, 0) = "SISTEMA"
        vArrayDatosComboBox(23).Valores(0, 1) = "0"
        vArrayDatosComboBox(23).Valores(1, 0) = "TABLA"
        vArrayDatosComboBox(23).Valores(1, 1) = "1"
        vArrayDatosComboBox(23).Ancho = 73
        vArrayDatosComboBox(23).Flag = True

        vArrayDatosComboBox(24).NombreCampo = "RTP_ESTADO"
        vArrayDatosComboBox(24).Longitud = 9
        vArrayDatosComboBox(24).Tipo = "varchar"
        vArrayDatosComboBox(24).ParteEntera = 0
        vArrayDatosComboBox(24).ParteDecimal = 0
        ReDim vArrayDatosComboBox(24).Valores(1, 1)
        vArrayDatosComboBox(24).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(24).Valores(0, 1) = "0"
        vArrayDatosComboBox(24).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(24).Valores(1, 1) = "1"
        vArrayDatosComboBox(24).Ancho = 85
        vArrayDatosComboBox(24).Flag = True
    End Sub

    Public Function VerificarDatos(ByVal ParamArray vCampos() As String) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            Select Case vCampos(elemento)
                Case "PER_ID"
                    If Len(PER_ID.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TPE_ID"
                    If Len(TPE_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "RTP_FEC_GRAB"
                    If RTP_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "RTP_ESTADO"
                    If RTP_ESTADO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

            End Select
            If VerificarDatos.NumeroError = 0 Then
                VerificarDatos.MensajeGeneral += VerificarDatos.MensajeError & Chr(13)
            End If
        Next
        Return VerificarDatos
    End Function

    Public Function SentenciaSqlBusqueda() As String
        SentenciaSqlBusqueda = ""
        If Vista = "BuscarRegistros" Then
            SentenciaSqlBusqueda = "spVistaRolPersonaTipoPersonaXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarRolesPersonaTipoPersonaXML"
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
            oVerificarDatos = VerificarDatos(Parametros)
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

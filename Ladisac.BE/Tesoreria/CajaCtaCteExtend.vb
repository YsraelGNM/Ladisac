Imports Ladisac.BE

Partial Public Class CajaCtaCte
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public CampoPrincipal = "CCC_ID"
    Public CampoPrincipalValor = CCC_ID
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 1
    Public CadenaFiltrado As String = ""

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Tes.CajaCtaCte"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "CajaCtaCte"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwCajaCtaCte"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaCajaCtaCte"
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
        vElementosDatosComboBox = 21
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "CCC_ID"
        vArrayCamposBusqueda(1) = "CCC_TIPO"
        vArrayCamposBusqueda(2) = "PER_ID_BAN"
        vArrayCamposBusqueda(3) = "PER_DESCRIPCION_BAN"
        vArrayCamposBusqueda(4) = "PER_ESTADO_BAN"
        vArrayCamposBusqueda(5) = "CCC_DESCRIPCION"
        vArrayCamposBusqueda(6) = "CCC_CUENTA_BANCARIA"
        vArrayCamposBusqueda(7) = "PER_ID_CAJ"
        vArrayCamposBusqueda(8) = "PER_DESCRIPCION_CAJ"
        vArrayCamposBusqueda(9) = "PER_ESTADO_CAJ"
        vArrayCamposBusqueda(10) = "PVE_ID"
        vArrayCamposBusqueda(11) = "PVE_DESCRIPCION"
        vArrayCamposBusqueda(12) = "PVE_ESTADO"
        vArrayCamposBusqueda(13) = "CCC_FECHA_SAL_INI"
        vArrayCamposBusqueda(14) = "CCC_MONTO_SAL_INI"
        vArrayCamposBusqueda(15) = "MON_ID"
        vArrayCamposBusqueda(16) = "MON_DESCRIPCION"
        vArrayCamposBusqueda(17) = "MON_ESTADO"
        vArrayCamposBusqueda(18) = "CUC_ID"
        vArrayCamposBusqueda(19) = "CUC_DESCRIPCION"
        vArrayCamposBusqueda(20) = "CUC_ESTADO"
        vArrayCamposBusqueda(21) = "CCC_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "CCC_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "CCC_TIPO"
        vArrayDatosComboBox(1).Longitud = 29
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(5, 1)
        vArrayDatosComboBox(1).Valores(0, 0) = "CAJA"
        vArrayDatosComboBox(1).Valores(0, 1) = "0"
        vArrayDatosComboBox(1).Valores(1, 0) = "CUENTA DE BANCO"
        vArrayDatosComboBox(1).Valores(1, 1) = "1"
        vArrayDatosComboBox(1).Valores(2, 0) = "LIQUIDACION DE DOCUMENTOS"
        vArrayDatosComboBox(1).Valores(2, 1) = "2"
        vArrayDatosComboBox(1).Valores(3, 0) = "CUENTA DE BANCO DE DETRACCION"
        vArrayDatosComboBox(1).Valores(3, 1) = "3"
        vArrayDatosComboBox(1).Valores(4, 0) = "RETENCIONES/PERCEPCIONES"
        vArrayDatosComboBox(1).Valores(4, 1) = "4"
        vArrayDatosComboBox(1).Valores(5, 0) = "RENDICION DE CUENTAS"
        vArrayDatosComboBox(1).Valores(5, 1) = "5"
        vArrayDatosComboBox(1).Ancho = 228
        vArrayDatosComboBox(1).Flag = True

        vArrayDatosComboBox(2).NombreCampo = "PER_ID_BAN"
        vArrayDatosComboBox(2).Longitud = 6
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 68
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PER_DESCRIPCION_BAN"
        vArrayDatosComboBox(3).Longitud = 77
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 828
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PER_ESTADO_BAN"
        vArrayDatosComboBox(4).Longitud = 9
        vArrayDatosComboBox(4).Tipo = "bit"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(1, 1)
        vArrayDatosComboBox(4).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(4).Valores(0, 1) = "0"
        vArrayDatosComboBox(4).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(4).Valores(1, 1) = "1"
        vArrayDatosComboBox(4).Ancho = 85
        vArrayDatosComboBox(4).Flag = True

        vArrayDatosComboBox(5).NombreCampo = "CCC_DESCRIPCION"
        vArrayDatosComboBox(5).Longitud = 65
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 699
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "CCC_CUENTA_BANCARIA"
        vArrayDatosComboBox(6).Longitud = 45
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 485
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "PER_ID_CAJ"
        vArrayDatosComboBox(7).Longitud = 6
        vArrayDatosComboBox(7).Tipo = "char"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 68
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "PER_DESCRIPCION_CAJ"
        vArrayDatosComboBox(8).Longitud = 77
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 828
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "PER_ESTADO_CAJ"
        vArrayDatosComboBox(9).Longitud = 9
        vArrayDatosComboBox(9).Tipo = "bit"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(1, 1)
        vArrayDatosComboBox(9).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(9).Valores(0, 1) = "0"
        vArrayDatosComboBox(9).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(9).Valores(1, 1) = "1"
        vArrayDatosComboBox(9).Ancho = 85
        vArrayDatosComboBox(9).Flag = True

        vArrayDatosComboBox(10).NombreCampo = "PVE_ID"
        vArrayDatosComboBox(10).Longitud = 3
        vArrayDatosComboBox(10).Tipo = "char"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 36
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "PVE_DESCRIPCION"
        vArrayDatosComboBox(11).Longitud = 45
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 485
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "PVE_ESTADO"
        vArrayDatosComboBox(12).Longitud = 9
        vArrayDatosComboBox(12).Tipo = "bit"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(1, 1)
        vArrayDatosComboBox(12).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(12).Valores(0, 1) = "0"
        vArrayDatosComboBox(12).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(12).Valores(1, 1) = "1"
        vArrayDatosComboBox(12).Ancho = 85
        vArrayDatosComboBox(12).Flag = True

        vArrayDatosComboBox(13).NombreCampo = "CCC_FECHA_SAL_INI"
        vArrayDatosComboBox(13).Longitud = 0
        vArrayDatosComboBox(13).Tipo = "smalldatetime"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 15
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "CCC_MONTO_SAL_INI"
        vArrayDatosComboBox(14).Longitud = 18
        vArrayDatosComboBox(14).Tipo = "numeric"
        vArrayDatosComboBox(14).ParteEntera = 14
        vArrayDatosComboBox(14).ParteDecimal = 4
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 197
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "MON_ID"
        vArrayDatosComboBox(15).Longitud = 3
        vArrayDatosComboBox(15).Tipo = "char"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 36
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "MON_DESCRIPCION"
        vArrayDatosComboBox(16).Longitud = 45
        vArrayDatosComboBox(16).Tipo = "varchar"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 485
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "MON_ESTADO"
        vArrayDatosComboBox(17).Longitud = 9
        vArrayDatosComboBox(17).Tipo = "bit"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(1, 1)
        vArrayDatosComboBox(17).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(17).Valores(0, 1) = "0"
        vArrayDatosComboBox(17).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(17).Valores(1, 1) = "1"
        vArrayDatosComboBox(17).Ancho = 85
        vArrayDatosComboBox(17).Flag = True

        vArrayDatosComboBox(18).NombreCampo = "CUC_ID"
        vArrayDatosComboBox(18).Longitud = 14
        vArrayDatosComboBox(18).Tipo = "char"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(0, 0)
        vArrayDatosComboBox(18).Ancho = 154
        vArrayDatosComboBox(18).Flag = False

        vArrayDatosComboBox(19).NombreCampo = "CUC_DESCRIPCION"
        vArrayDatosComboBox(19).Longitud = 45
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(0, 0)
        vArrayDatosComboBox(19).Ancho = 485
        vArrayDatosComboBox(19).Flag = False

        vArrayDatosComboBox(20).NombreCampo = "CUC_ESTADO"
        vArrayDatosComboBox(20).Longitud = 9
        vArrayDatosComboBox(20).Tipo = "bit"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(1, 1)
        vArrayDatosComboBox(20).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(20).Valores(0, 1) = "0"
        vArrayDatosComboBox(20).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(20).Valores(1, 1) = "1"
        vArrayDatosComboBox(20).Ancho = 85
        vArrayDatosComboBox(20).Flag = True

        vArrayDatosComboBox(21).NombreCampo = "CCC_ESTADO"
        vArrayDatosComboBox(21).Longitud = 9
        vArrayDatosComboBox(21).Tipo = "bit"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(1, 1)
        vArrayDatosComboBox(21).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(21).Valores(0, 1) = "0"
        vArrayDatosComboBox(21).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(21).Valores(1, 1) = "1"
        vArrayDatosComboBox(21).Ancho = 85
        vArrayDatosComboBox(21).Flag = True
    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As String) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            Select Case vCampos(elemento)
                Case "CCC_ID"
                    If Len(CCC_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCC_TIPO"
                    If CCC_TIPO >= 0 And CCC_TIPO <= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCC_DESCRIPCION"
                    If Len(CCC_DESCRIPCION.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCC_FECHA_SAL_INI"
                    If CCC_FECHA_SAL_INI.GetType = GetType(Date) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCC_MONTO_SAL_INI"
                    If IsNumeric(CCC_MONTO_SAL_INI) And _
                        CCC_MONTO_SAL_INI >= 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "MON_ID"
                    If Len(MON_ID.Trim) = 3 Then
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

                Case "CCC_FEC_GRAB"
                    If CCC_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCC_ESTADO"
                    If CCC_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaCajaCtaCteXML"
        End If
        If Vista = "BuscarRegistrosCajero" Then
            SentenciaSqlBusqueda = "spVistaCajaCtaCteCajeroXML"
        End If
        If Vista = "BuscarRegistrosCajeroResumen" Then
            SentenciaSqlBusqueda = "spVistaCajaCtaCteCajeroResumenXML"
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

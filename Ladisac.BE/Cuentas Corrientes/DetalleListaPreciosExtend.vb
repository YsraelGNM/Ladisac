Imports Ladisac.BE

Partial Public Class DetalleListaPrecios
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public CampoPrincipal = "LPR_ID"
    Public CampoPrincipalSecundario = "ART_ID"
    Public CampoPrincipalValor = LPR_ID
    Public CampoPrincipalSecundarioValor = ART_ID
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 2
    Public CadenaFiltrado As String = ""
    Public vFLagBuscarRegistros As Boolean = True
    Public vLPR_ID1 As String
    Public vLPR_ID2 As String
    Public vTIP_ID As String

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Fin.DetalleListaPrecios"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetalleListaPrecios"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetalleListaPrecios"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetalleListaPrecios"
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
        vElementosDatosComboBox = 20
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "LPR_ID"
        vArrayCamposBusqueda(1) = "LPR_DESCRIPCION"
        vArrayCamposBusqueda(2) = "LPR_PRINCIPAL"
        vArrayCamposBusqueda(3) = "PER_ID"
        vArrayCamposBusqueda(4) = "PER_DESCRIPCION"
        vArrayCamposBusqueda(5) = "PER_ESTADO"
        vArrayCamposBusqueda(6) = "MON_ID"
        vArrayCamposBusqueda(7) = "MON_DESCRIPCION"
        vArrayCamposBusqueda(8) = "MON_ESTADO"
        vArrayCamposBusqueda(9) = "ART_ID"
        vArrayCamposBusqueda(10) = "ART_DESCRIPCION"
        vArrayCamposBusqueda(11) = "UM_DESCRIPCION"
        vArrayCamposBusqueda(12) = "ART_FACTOR"
        vArrayCamposBusqueda(13) = "ART_INC_IGV"
        vArrayCamposBusqueda(14) = "ART_ESTADO"
        vArrayCamposBusqueda(15) = "DLP_PRECIO_MINIMO"
        vArrayCamposBusqueda(16) = "DLP_PRECIO_UNITARIO"
        vArrayCamposBusqueda(17) = "DLP_RECARGO_ENVIO"
        vArrayCamposBusqueda(18) = "DLP_ESTADO"
        vArrayCamposBusqueda(19) = "LPR_ESTADO"
        vArrayCamposBusqueda(20) = "LPR_CONTROL"

        vArrayDatosComboBox(0).NombreCampo = "LPR_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "LPR_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 45
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 485
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "LPR_PRINCIPAL"
        vArrayDatosComboBox(2).Longitud = 14
        vArrayDatosComboBox(2).Tipo = "varchar"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(1, 1)
        vArrayDatosComboBox(2).Valores(0, 0) = "PLANTA"
        vArrayDatosComboBox(2).Valores(0, 1) = "0"
        vArrayDatosComboBox(2).Valores(1, 0) = "PUNTO DE VENTA"
        vArrayDatosComboBox(2).Valores(1, 1) = "1"
        vArrayDatosComboBox(2).Ancho = 122
        vArrayDatosComboBox(2).Flag = True

        vArrayDatosComboBox(3).NombreCampo = "PER_ID"
        vArrayDatosComboBox(3).Longitud = 6
        vArrayDatosComboBox(3).Tipo = "char"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 68
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PER_DESCRIPCION"
        vArrayDatosComboBox(4).Longitud = 77
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 828
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "PER_ESTADO"
        vArrayDatosComboBox(5).Longitud = 9
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(1, 1)
        vArrayDatosComboBox(5).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(5).Valores(0, 1) = "0"
        vArrayDatosComboBox(5).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(5).Valores(1, 1) = "1"
        vArrayDatosComboBox(5).Ancho = 85
        vArrayDatosComboBox(5).Flag = True

        vArrayDatosComboBox(6).NombreCampo = "MON_ID"
        vArrayDatosComboBox(6).Longitud = 3
        vArrayDatosComboBox(6).Tipo = "char"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 36
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "MON_DESCRIPCION"
        vArrayDatosComboBox(7).Longitud = 45
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 485
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "MON_ESTADO"
        vArrayDatosComboBox(8).Longitud = 9
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(1, 1)
        vArrayDatosComboBox(8).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(8).Valores(0, 1) = "0"
        vArrayDatosComboBox(8).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(8).Valores(1, 1) = "1"
        vArrayDatosComboBox(8).Ancho = 85
        vArrayDatosComboBox(8).Flag = True

        vArrayDatosComboBox(9).NombreCampo = "ART_ID"
        vArrayDatosComboBox(9).Longitud = 6
        vArrayDatosComboBox(9).Tipo = "char"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 68
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "ART_DESCRIPCION"
        vArrayDatosComboBox(10).Longitud = 45
        vArrayDatosComboBox(10).Tipo = "varchar"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 485
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "UM_DESCRIPCION"
        vArrayDatosComboBox(11).Longitud = 45
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 485
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "ART_FACTOR"
        vArrayDatosComboBox(12).Longitud = 4
        vArrayDatosComboBox(12).Tipo = "numeric"
        vArrayDatosComboBox(12).ParteEntera = 2
        vArrayDatosComboBox(12).ParteDecimal = 2
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 47
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "ART_INC_IGV"
        vArrayDatosComboBox(13).Longitud = 18
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(2, 1)
        vArrayDatosComboBox(13).Valores(0, 0) = "NO INCLUYE IGV"
        vArrayDatosComboBox(13).Valores(0, 1) = "0"
        vArrayDatosComboBox(13).Valores(1, 0) = "SI INCLUYE IGV"
        vArrayDatosComboBox(13).Valores(1, 1) = "1"
        vArrayDatosComboBox(13).Valores(2, 0) = "NO GRABADO CON IGV"
        vArrayDatosComboBox(13).Valores(2, 1) = "2"
        vArrayDatosComboBox(13).Ancho = 151
        vArrayDatosComboBox(13).Flag = True

        vArrayDatosComboBox(14).NombreCampo = "ART_ESTADO"
        vArrayDatosComboBox(14).Longitud = 9
        vArrayDatosComboBox(14).Tipo = "varchar"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(1, 1)
        vArrayDatosComboBox(14).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(14).Valores(0, 1) = "0"
        vArrayDatosComboBox(14).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(14).Valores(1, 1) = "1"
        vArrayDatosComboBox(14).Ancho = 85
        vArrayDatosComboBox(14).Flag = True

        vArrayDatosComboBox(15).NombreCampo = "DLP_PRECIO_MINIMO"
        vArrayDatosComboBox(15).Longitud = 18
        vArrayDatosComboBox(15).Tipo = "numeric"
        vArrayDatosComboBox(15).ParteEntera = 14
        vArrayDatosComboBox(15).ParteDecimal = 4
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 197
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "DLP_PRECIO_UNITARIO"
        vArrayDatosComboBox(16).Longitud = 18
        vArrayDatosComboBox(16).Tipo = "numeric"
        vArrayDatosComboBox(16).ParteEntera = 14
        vArrayDatosComboBox(16).ParteDecimal = 4
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 197
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "DLP_RECARGO_ENVIO"
        vArrayDatosComboBox(17).Longitud = 18
        vArrayDatosComboBox(17).Tipo = "numeric"
        vArrayDatosComboBox(17).ParteEntera = 14
        vArrayDatosComboBox(17).ParteDecimal = 4
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 197
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "DLP_ESTADO"
        vArrayDatosComboBox(18).Longitud = 0
        vArrayDatosComboBox(18).Tipo = "bit"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(1, 1)
        vArrayDatosComboBox(18).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(18).Valores(0, 1) = "0"
        vArrayDatosComboBox(18).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(18).Valores(1, 1) = "1"
        vArrayDatosComboBox(18).Ancho = 85
        vArrayDatosComboBox(18).Flag = True

        vArrayDatosComboBox(19).NombreCampo = "LPR_ESTADO"
        vArrayDatosComboBox(19).Longitud = 9
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(1, 1)
        vArrayDatosComboBox(19).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(19).Valores(0, 1) = "0"
        vArrayDatosComboBox(19).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(19).Valores(1, 1) = "1"
        vArrayDatosComboBox(19).Ancho = 85
        vArrayDatosComboBox(19).Flag = True

        vArrayDatosComboBox(20).NombreCampo = "LPR_CONTROL"
        vArrayDatosComboBox(20).Longitud = 7
        vArrayDatosComboBox(20).Tipo = "varchar"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(1, 1)
        vArrayDatosComboBox(20).Valores(0, 0) = "SISTEMA"
        vArrayDatosComboBox(20).Valores(0, 1) = "0"
        vArrayDatosComboBox(20).Valores(1, 0) = "USUARIO"
        vArrayDatosComboBox(20).Valores(1, 1) = "1"
        vArrayDatosComboBox(20).Ancho = 75
        vArrayDatosComboBox(20).Flag = True

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As String) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "LPR_ID"
                    If Len(LPR_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "ART_ID"
                    If Len(ART_ID.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DLP_PRECIO_MINIMO"
                    If DLP_PRECIO_MINIMO.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DLP_PRECIO_UNITARIO"
                    If IsNothing(DLP_PRECIO_UNITARIO) Then
                    Else
                        If DLP_PRECIO_UNITARIO.GetType = GetType(Decimal) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DLP_RECARGO_ENVIO"
                    If IsNothing(DLP_RECARGO_ENVIO) Then
                    Else
                        If DLP_RECARGO_ENVIO.GetType = GetType(Decimal) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DLP_FEC_GRAB"
                    If DLP_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DLP_ESTADO"
                    If DLP_ESTADO.GetType = GetType(Boolean) Then
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
        Return VerificarDatos
    End Function
    Public Function SentenciaSqlBusqueda() As String
        SentenciaSqlBusqueda = ""
        If Vista = "BuscarRegistros" Then
            SentenciaSqlBusqueda = "spVistaDetalleListaPreciosXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetalleListaPreciosXML"
        End If
        If Vista = "ListaPreciosEspecialPuntoVentaPlanta" Then
            SentenciaSqlBusqueda = "spListaPreciosEspecialPuntoVentaPlantaXML"
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
                oVerificarDatos = VerificarDatos("LPR_ID", "ART_ID", "DLP_PRECIO_MINIMO", "DLP_PRECIO_UNITARIO", "DLP_RECARGO_ENVIO", "USU_ID", "DLP_FEC_GRAB", "DLP_ESTADO")
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

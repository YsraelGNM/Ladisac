Imports Ladisac.BE
Partial Public Class DetalleDocumentosPromocion
    Inherits Ladisac.BE.Maestro.Datos.Orm


    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 3
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "DDP_NUMERO"
    Public CampoPrincipalSecundario = "DDP_TIPO_PROMOCION"
    Public CampoPrincipalTercero = "DDP_ITEM"
    Public CampoPrincipalValor = DDP_NUMERO
    Public CampoPrincipalSecundarioValor = DDP_TIPO_PROMOCION
    Public CampoPrincipalTerceroValor = DDP_ITEM
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Fac.DetalleDocumentosPromocion"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetalleDocumentosPromocion"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetalleDocumentosPromocion"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetalleDocumentosPromocion"
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
        vElementosDatosComboBox = 19
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "DDR_NUMERO"
        vArrayCamposBusqueda(1) = "ddp_tipo_promocion"
        vArrayCamposBusqueda(2) = "dpr_fecha"
        vArrayCamposBusqueda(3) = "PER_ID_PRO"
        vArrayCamposBusqueda(4) = "per_descripcion_pro"
        vArrayCamposBusqueda(5) = "DDP_ITEM"
        vArrayCamposBusqueda(6) = "TDO_ID_DOC"
        vArrayCamposBusqueda(7) = "TDO_DESCRIPCION_DOC"
        vArrayCamposBusqueda(8) = "DTD_ID_DOC"
        vArrayCamposBusqueda(9) = "DTD_DESCRIPCION_DOC"
        vArrayCamposBusqueda(10) = "CCT_ID_DOC"
        vArrayCamposBusqueda(11) = "CCT_DESCRIPCION_DOC"
        vArrayCamposBusqueda(12) = "DDP_SERIE_DOC"
        vArrayCamposBusqueda(13) = "DDP_NUMERO_DOC"
        vArrayCamposBusqueda(14) = "ART_ID"
        vArrayCamposBusqueda(15) = "ART_DESCRIPCION"
        vArrayCamposBusqueda(16) = "DDP_PUNTOS"
        vArrayCamposBusqueda(17) = "DDP_PUNTOS_CONTROL"
        vArrayCamposBusqueda(18) = "ddp_estado"
        vArrayCamposBusqueda(19) = "dpr_estado"

        vArrayDatosComboBox(0).NombreCampo = "DPR_NUMERO"
        vArrayDatosComboBox(0).Longitud = 10
        vArrayDatosComboBox(0).Tipo = "varchar"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 111
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "dpr_tipo_promocion"
        vArrayDatosComboBox(1).Longitud = 19
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(1, 1)
        vArrayDatosComboBox(1).Valores(0, 0) = "MAESTRO CONSTRUCTOR"
        vArrayDatosComboBox(1).Valores(0, 1) = "0"
        vArrayDatosComboBox(1).Valores(1, 0) = "PROMOCION ECO DIAMANTE"
        vArrayDatosComboBox(1).Valores(1, 1) = "1"
        vArrayDatosComboBox(1).Ancho = 196
        vArrayDatosComboBox(1).Flag = True

        vArrayDatosComboBox(2).NombreCampo = "dpr_fecha"
        vArrayDatosComboBox(2).Longitud = 0
        vArrayDatosComboBox(2).Tipo = "smalldatetime"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 15
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PER_ID_PRO"
        vArrayDatosComboBox(3).Longitud = 6
        vArrayDatosComboBox(3).Tipo = "char"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 68
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "per_descripcion_pro"
        vArrayDatosComboBox(4).Longitud = 77
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 828
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "DDP_ITEM"
        vArrayDatosComboBox(5).Longitud = 3
        vArrayDatosComboBox(5).Tipo = "numeric"
        vArrayDatosComboBox(5).ParteEntera = 3
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 36
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "TDO_ID_DOC"
        vArrayDatosComboBox(6).Longitud = 3
        vArrayDatosComboBox(6).Tipo = "char"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 36
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "TDO_DESCRIPCION_DOC"
        vArrayDatosComboBox(7).Longitud = 45
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 485
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "DTD_ID_DOC"
        vArrayDatosComboBox(8).Longitud = 3
        vArrayDatosComboBox(8).Tipo = "char"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 36
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "DTD_DESCRIPCION_DOC"
        vArrayDatosComboBox(9).Longitud = 45
        vArrayDatosComboBox(9).Tipo = "varchar"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 485
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "CCT_ID_DOC"
        vArrayDatosComboBox(10).Longitud = 3
        vArrayDatosComboBox(10).Tipo = "char"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 36
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "CCT_DESCRIPCION_DOC"
        vArrayDatosComboBox(11).Longitud = 45
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 485
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "DDP_SERIE_DOC"
        vArrayDatosComboBox(12).Longitud = 3
        vArrayDatosComboBox(12).Tipo = "char"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 36
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "DDP_NUMERO_DOC"
        vArrayDatosComboBox(13).Longitud = 10
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 111
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "ART_ID"
        vArrayDatosComboBox(14).Longitud = 6
        vArrayDatosComboBox(14).Tipo = "char"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 68
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "ART_DESCRIPCION"
        vArrayDatosComboBox(15).Longitud = 45
        vArrayDatosComboBox(15).Tipo = "varchar"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 485
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "DDP_PUNTOS"
        vArrayDatosComboBox(16).Longitud = 18
        vArrayDatosComboBox(16).Tipo = "numeric"
        vArrayDatosComboBox(16).ParteEntera = 14
        vArrayDatosComboBox(16).ParteDecimal = 4
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 197
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "DDP_PUNTOS_CONTROL"
        vArrayDatosComboBox(17).Longitud = 18
        vArrayDatosComboBox(17).Tipo = "numeric"
        vArrayDatosComboBox(17).ParteEntera = 14
        vArrayDatosComboBox(17).ParteDecimal = 4
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 197
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "ddp_estado"
        vArrayDatosComboBox(18).Longitud = 9
        vArrayDatosComboBox(18).Tipo = "varchar"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(1, 1)
        vArrayDatosComboBox(18).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(18).Valores(0, 1) = "0"
        vArrayDatosComboBox(18).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(18).Valores(1, 1) = "1"
        vArrayDatosComboBox(18).Ancho = 85
        vArrayDatosComboBox(18).Flag = True

        vArrayDatosComboBox(19).NombreCampo = "dpr_estado"
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

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "DDP_NUMERO"
                    If Len(DDP_NUMERO.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDP_TIPO_PROMOCION"
                    If DDP_TIPO_PROMOCION >= 0 And DDP_TIPO_PROMOCION <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDP_ITEM"
                    If DDP_ITEM.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TDO_ID_DOC"
                    If Len(TDO_ID_DOC.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_ID_DOC"
                    If Len(DTD_ID_DOC.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCT_ID_DOC"
                    If IsNothing(CCT_ID_DOC) Then
                    Else
                        If Len(CCT_ID_DOC.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "DDP_SERIE_DOC"
                    If Len(DDP_SERIE_DOC.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDP_NUMERO_DOC"
                    If Len(DDP_NUMERO_DOC.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "ART_ID"
                    If Len(ART_ID.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDP_PUNTOS"
                    If DDP_PUNTOS <> 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDP_PUNTOS_CONTROL"
                    If DDP_PUNTOS_CONTROL <> 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDP_FEC_GRAB"
                    If DDP_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDP_ESTADO"
                    'If DDP_ESTADO.GetType = GetType(Boolean) Then
                    If DDP_ESTADO >= 0 And DDP_ESTADO <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
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
            SentenciaSqlBusqueda = "spVistaDetalleDocumentosPromocionXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetalleDocumentosPromocionXML"
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
                oVerificarDatos = VerificarDatos("DDP_NUMERO", "DDP_TIPO_PROMOCION", "DDP_ITEM", "TDO_ID_DOC", "DTD_ID_DOC", "CCT_ID_DOC", "DDP_SERIE_DOC", "DDP_NUMERO_DOC", "ART_ID", "DDP_PUNTOS", "USU_ID", "DDP_FEC_GRAB", "DDP_ESTADO")
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

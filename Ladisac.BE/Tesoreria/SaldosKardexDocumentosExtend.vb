Imports Ladisac.BE
Public Class SaldosKardexDocumentos
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 4
    Public CadenaFiltrado As String = ""
    Public CadenaFiltrado1 As String = ""

    Public CampoPrincipal = "TDO_ID_REF"
    Public CampoPrincipalSecundario = "DTD_ID_REF"
    Public CampoPrincipalTercero = "DOC_SERIE_REF"
    Public CampoPrincipalCuarto = "DOC_NUMERO_REF"
    'Public CampoPrincipalValor = TDO_ID_REF
    'Public CampoPrincipalSecundarioValor = DTD_ID
    'Public CampoPrincipalTerceroValor = DOC_SERIE
    'Public CampoPrincipalCuartoValor = DOC_NUMERO

    Public vCCT_ID As Object = DBNull.Value
    Public vCCC_ID As Object = DBNull.Value
    Public vPER_ID_CLI As Object = DBNull.Value
    Public vCCT_ID_REF As Object = DBNull.Value
    Public vTDO_ID As Object = DBNull.Value
    Public vDTD_ID As Object = DBNull.Value
    Public vDOC_SERIE As Object = DBNull.Value
    Public vDOC_NUMERO As Object = DBNull.Value
    Public vDOCUMENTO As Object = DBNull.Value
    Public vProcesarAnticipoPorCobrar As Boolean = False
    'Public vDTD_ID_REF As String

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "SaldosKardexDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "SaldosKardexDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwSaldosKardexDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaSaldosKardexDocumentos"
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
        'pFiltradoWhere = False
        ConfigurarDatosCampos()
    End Sub
    Private Sub ConfigurarDatosCampos()
        vElementosDatosComboBox = 14
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "DOC_FECHA_EMI_REF"
        vArrayCamposBusqueda(1) = "DOC_FECHA_VEN_REF"
        vArrayCamposBusqueda(2) = "CCT_ID_REF"
        vArrayCamposBusqueda(3) = "CCT_DESCRIPCION_REF"
        vArrayCamposBusqueda(4) = "PER_ID_CLI"
        vArrayCamposBusqueda(5) = "PER_DESCRIPCION_CLI"
        vArrayCamposBusqueda(6) = "TDO_ID_REF"
        vArrayCamposBusqueda(7) = "TDO_DESCRIPCION_REF"
        vArrayCamposBusqueda(8) = "DTD_ID_REF"
        vArrayCamposBusqueda(9) = "DTD_DESCRIPCION_REF"
        vArrayCamposBusqueda(10) = "DOC_SERIE_REF"
        vArrayCamposBusqueda(11) = "DOC_NUMERO_REF"
        vArrayCamposBusqueda(12) = "SALDO"
        vArrayCamposBusqueda(13) = "MON_ID"
        vArrayCamposBusqueda(14) = "MON_DESCRIPCION"

        vArrayDatosComboBox(0).NombreCampo = "DOC_FECHA_EMI_REF"
        vArrayDatosComboBox(0).Longitud = 0
        vArrayDatosComboBox(0).Tipo = "smalldatetime"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 15
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "DOC_FECHA_VEN_REF"
        vArrayDatosComboBox(1).Longitud = 0
        vArrayDatosComboBox(1).Tipo = "smalldatetime"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 15
        vArrayDatosComboBox(1).Flag = False


        vArrayDatosComboBox(2).NombreCampo = "CCT_ID_REF"
        vArrayDatosComboBox(2).Longitud = 3
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 36
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "CCT_DESCRIPCION_REF"
        vArrayDatosComboBox(3).Longitud = 45
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 485
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PER_ID_CLI"
        vArrayDatosComboBox(4).Longitud = 6
        vArrayDatosComboBox(4).Tipo = "char"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 68
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "PER_DESCRIPCION_CLI"
        vArrayDatosComboBox(5).Longitud = 77
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 828
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "TDO_ID_REF"
        vArrayDatosComboBox(6).Longitud = 3
        vArrayDatosComboBox(6).Tipo = "char"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 36
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "TDO_DESCRIPCION_REF"
        vArrayDatosComboBox(7).Longitud = 45
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 485
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "DTD_ID_REF"
        vArrayDatosComboBox(8).Longitud = 3
        vArrayDatosComboBox(8).Tipo = "char"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 36
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "DTD_DESCRIPCION_REF"
        vArrayDatosComboBox(9).Longitud = 45
        vArrayDatosComboBox(9).Tipo = "varchar"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 485
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "DOC_SERIE_REF"
        vArrayDatosComboBox(10).Longitud = 3
        vArrayDatosComboBox(10).Tipo = "char"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 36
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "DOC_NUMERO_REF"
        vArrayDatosComboBox(11).Longitud = 10
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 111
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "SALDO"
        vArrayDatosComboBox(12).Longitud = 18
        vArrayDatosComboBox(12).Tipo = "numeric"
        vArrayDatosComboBox(12).ParteEntera = 14
        vArrayDatosComboBox(12).ParteDecimal = 4
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 197
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "MON_ID"
        vArrayDatosComboBox(13).Longitud = 3
        vArrayDatosComboBox(13).Tipo = "char"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 36
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "MON_DESCRIPCION"
        vArrayDatosComboBox(14).Longitud = 45
        vArrayDatosComboBox(14).Tipo = "varchar"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 485
        vArrayDatosComboBox(14).Flag = False
    End Sub

    Public Function SentenciaSqlBusqueda() As String
        SentenciaSqlBusqueda = ""
        If Vista = "BuscarRegistros" Then
            SentenciaSqlBusqueda = "spSaldosKardexDocumentosXML"
        End If
        If Vista = "VistaSaldoDTD" Then
            SentenciaSqlBusqueda = "spVistaSaldosDTDXML"
        End If
        If Vista = "VistaSaldoDTDNuevo" Then
            SentenciaSqlBusqueda = "spVistaSaldosDTDXML"
        End If
        If Vista = "spSaldoDocumentoMontoNoCero" Then
            SentenciaSqlBusqueda = "spSaldoDocumentoMontoNoCeroXML"
        End If
        If Vista = "spSaldoDocumentoMontoNoCeroConCheck" Then
            SentenciaSqlBusqueda = "spSaldoDocumentoMontoNoCeroConCheckXML"
        End If

        If Vista = "spSaldoDocumentoMontoNoCeroDetracciones" Then
            SentenciaSqlBusqueda = "spSaldoDocumentoMontoNoCeroDetraccionesXML"
        End If
        If Vista = "spSaldoDocumentoMontoNoCeroDetraccionesConCheck" Then
            SentenciaSqlBusqueda = "spSaldoDocumentoMontoNoCeroDetraccionesConCheckXML"
        End If
        If Vista = "spSaldoDocumentoMontoNoCeroDetraccionesCopiaXML" Then
            SentenciaSqlBusqueda = "spSaldoDocumentoMontoNoCeroDetraccionesCopiaXML"
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
End Class


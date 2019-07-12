Imports Ladisac.BE
Partial Public Class DetalleAfectaProductoDocumentos
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 5
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "TDO_ID"
    Public CampoPrincipalSecundario = "DTD_ID"
    Public CampoPrincipalTercero = "DAP_SERIE"
    Public CampoPrincipalCuarto = "DAP_NUMERO"
    Public CampoPrincipalQuinto = "DAP_ITEM"
    Public CampoPrincipalValor = TDO_ID
    Public CampoPrincipalSecundarioValor = DTD_ID
    Public CampoPrincipalTerceroValor = DAP_SERIE
    Public CampoPrincipalCuartoValor = DAP_NUMERO
    Public CampoPrincipalQuintoValor = DAP_ITEM

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Fac.DetalleAfectaProductoDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetalleAfectaProductoDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetalleAfectaProductoDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetalleAfectaProductoDocumentos"
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
        vElementosDatosComboBox = 52
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "TDO_ID"
        vArrayCamposBusqueda(1) = "TDO_DESCRIPCION"
        vArrayCamposBusqueda(2) = "DTD_ID"
        vArrayCamposBusqueda(3) = "DTD_DESCRIPCION"
        vArrayCamposBusqueda(4) = "CCT_ID"
        vArrayCamposBusqueda(5) = "CCT_DESCRIPCION"
        vArrayCamposBusqueda(6) = "DOC_SERIE"
        vArrayCamposBusqueda(7) = "DOC_NUMERO"
        vArrayCamposBusqueda(8) = "PVE_ID"
        vArrayCamposBusqueda(9) = "PVE_DESCRIPCION"
        vArrayCamposBusqueda(10) = "MON_ID"
        vArrayCamposBusqueda(11) = "MON_SIMBOLO"
        vArrayCamposBusqueda(12) = "MON_DESCRIPCION"
        vArrayCamposBusqueda(13) = "PER_ID_CLI"
        vArrayCamposBusqueda(14) = "PER_DESCRIPCION_CLI"
        vArrayCamposBusqueda(15) = "DOC_FECHA_EMI"
        vArrayCamposBusqueda(16) = "DOC_MONTO_TOTAL"
        vArrayCamposBusqueda(17) = "DOC_CONTRAVALOR"
        vArrayCamposBusqueda(18) = "DOC_IGV_POR"
        vArrayCamposBusqueda(19) = "TDO_ID_AFE"
        vArrayCamposBusqueda(20) = "TDO_DESCRIPCION_AFE"
        vArrayCamposBusqueda(21) = "DTD_ID_AFE"
        vArrayCamposBusqueda(22) = "DTD_DESCRIPCION_AFE"
        vArrayCamposBusqueda(23) = "CCT_ID_AFE"
        vArrayCamposBusqueda(24) = "CCT_DESCRIPCION_AFE"
        vArrayCamposBusqueda(25) = "DOC_SERIE_AFE"
        vArrayCamposBusqueda(26) = "DOC_NUMERO_AFE"
        vArrayCamposBusqueda(27) = "DOC_MOT_EMI"
        vArrayCamposBusqueda(28) = "DOC_ESTADO"
        vArrayCamposBusqueda(29) = "TDO_ID_AFP_D"
        vArrayCamposBusqueda(30) = "TDO_DESCRIPCION_AFP_D"
        vArrayCamposBusqueda(31) = "DTD_ID_AFP_D"
        vArrayCamposBusqueda(32) = "DTD_DESCRIPCION_AFP_D"
        vArrayCamposBusqueda(33) = "CCT_ID_AFP_D"
        vArrayCamposBusqueda(34) = "CCT_DESCRIPCION_AFP_D"
        vArrayCamposBusqueda(35) = "DOC_SERIE_AFP_D"
        vArrayCamposBusqueda(36) = "DOC_NUMERO_AFP_D"
        vArrayCamposBusqueda(37) = "DAP_ITEM"
        vArrayCamposBusqueda(38) = "ART_ID"
        vArrayCamposBusqueda(39) = "DAP_CANTIDAD"
        vArrayCamposBusqueda(40) = "DDA_OBS"
        vArrayCamposBusqueda(41) = "TDO_ID_DEV"
        vArrayCamposBusqueda(42) = "TDO_DESCRIPCION_DEV"
        vArrayCamposBusqueda(43) = "DTD_ID_DEV"
        vArrayCamposBusqueda(44) = "DTD_DESCRIPCION_DEV"
        vArrayCamposBusqueda(45) = "CCT_ID_DEV"
        vArrayCamposBusqueda(46) = "CCT_DESCRIPCION_DEV"
        vArrayCamposBusqueda(47) = "DES_SERIE_DEV"
        vArrayCamposBusqueda(48) = "DES_NUMERO_DEV"
        vArrayCamposBusqueda(49) = "ART_ID_DEV"
        vArrayCamposBusqueda(50) = "ART_DESCRIPCION_DEV"
        vArrayCamposBusqueda(51) = "DDE_CANTIDAD_DEV"
        vArrayCamposBusqueda(52) = "DDA_ESTADO"

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

        vArrayDatosComboBox(4).NombreCampo = "CCT_ID"
        vArrayDatosComboBox(4).Longitud = 3
        vArrayDatosComboBox(4).Tipo = "char"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 36
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "CCT_DESCRIPCION"
        vArrayDatosComboBox(5).Longitud = 45
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 485
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "DOC_SERIE"
        vArrayDatosComboBox(6).Longitud = 3
        vArrayDatosComboBox(6).Tipo = "char"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 36
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "DOC_NUMERO"
        vArrayDatosComboBox(7).Longitud = 10
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 111
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "PVE_ID"
        vArrayDatosComboBox(8).Longitud = 3
        vArrayDatosComboBox(8).Tipo = "char"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 36
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "PVE_DESCRIPCION"
        vArrayDatosComboBox(9).Longitud = 45
        vArrayDatosComboBox(9).Tipo = "varchar"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 485
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "MON_ID"
        vArrayDatosComboBox(10).Longitud = 3
        vArrayDatosComboBox(10).Tipo = "char"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 36
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "MON_SIMBOLO"
        vArrayDatosComboBox(11).Longitud = 10
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 111
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "MON_DESCRIPCION"
        vArrayDatosComboBox(12).Longitud = 45
        vArrayDatosComboBox(12).Tipo = "varchar"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 485
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "PER_ID_CLI"
        vArrayDatosComboBox(13).Longitud = 6
        vArrayDatosComboBox(13).Tipo = "char"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 68
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "PER_DESCRIPCION_CLI"
        vArrayDatosComboBox(14).Longitud = 482
        vArrayDatosComboBox(14).Tipo = "varchar"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 5159
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "DOC_FECHA_EMI"
        vArrayDatosComboBox(15).Longitud = 0
        vArrayDatosComboBox(15).Tipo = "smalldatetime"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 15
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "DOC_MONTO_TOTAL"
        vArrayDatosComboBox(16).Longitud = 18
        vArrayDatosComboBox(16).Tipo = "numeric"
        vArrayDatosComboBox(16).ParteEntera = 14
        vArrayDatosComboBox(16).ParteDecimal = 4
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 197
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "DOC_CONTRAVALOR"
        vArrayDatosComboBox(17).Longitud = 18
        vArrayDatosComboBox(17).Tipo = "numeric"
        vArrayDatosComboBox(17).ParteEntera = 14
        vArrayDatosComboBox(17).ParteDecimal = 4
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 197
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "DOC_IGV_POR"
        vArrayDatosComboBox(18).Longitud = 4
        vArrayDatosComboBox(18).Tipo = "numeric"
        vArrayDatosComboBox(18).ParteEntera = 2
        vArrayDatosComboBox(18).ParteDecimal = 2
        ReDim vArrayDatosComboBox(18).Valores(0, 0)
        vArrayDatosComboBox(18).Ancho = 47
        vArrayDatosComboBox(18).Flag = False

        vArrayDatosComboBox(19).NombreCampo = "TDO_ID_AFE"
        vArrayDatosComboBox(19).Longitud = 3
        vArrayDatosComboBox(19).Tipo = "char"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(0, 0)
        vArrayDatosComboBox(19).Ancho = 36
        vArrayDatosComboBox(19).Flag = False

        vArrayDatosComboBox(20).NombreCampo = "TDO_DESCRIPCION_AFE"
        vArrayDatosComboBox(20).Longitud = 45
        vArrayDatosComboBox(20).Tipo = "varchar"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(0, 0)
        vArrayDatosComboBox(20).Ancho = 485
        vArrayDatosComboBox(20).Flag = False

        vArrayDatosComboBox(21).NombreCampo = "DTD_ID_AFE"
        vArrayDatosComboBox(21).Longitud = 3
        vArrayDatosComboBox(21).Tipo = "char"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(0, 0)
        vArrayDatosComboBox(21).Ancho = 36
        vArrayDatosComboBox(21).Flag = False

        vArrayDatosComboBox(22).NombreCampo = "DTD_DESCRIPCION_AFE"
        vArrayDatosComboBox(22).Longitud = 45
        vArrayDatosComboBox(22).Tipo = "varchar"
        vArrayDatosComboBox(22).ParteEntera = 0
        vArrayDatosComboBox(22).ParteDecimal = 0
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 485
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "CCT_ID_AFE"
        vArrayDatosComboBox(23).Longitud = 3
        vArrayDatosComboBox(23).Tipo = "char"
        vArrayDatosComboBox(23).ParteEntera = 0
        vArrayDatosComboBox(23).ParteDecimal = 0
        ReDim vArrayDatosComboBox(23).Valores(0, 0)
        vArrayDatosComboBox(23).Ancho = 36
        vArrayDatosComboBox(23).Flag = False

        vArrayDatosComboBox(24).NombreCampo = "CCT_DESCRIPCION_AFE"
        vArrayDatosComboBox(24).Longitud = 45
        vArrayDatosComboBox(24).Tipo = "varchar"
        vArrayDatosComboBox(24).ParteEntera = 0
        vArrayDatosComboBox(24).ParteDecimal = 0
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 485
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "DOC_SERIE_AFE"
        vArrayDatosComboBox(25).Longitud = 3
        vArrayDatosComboBox(25).Tipo = "char"
        vArrayDatosComboBox(25).ParteEntera = 0
        vArrayDatosComboBox(25).ParteDecimal = 0
        ReDim vArrayDatosComboBox(25).Valores(0, 0)
        vArrayDatosComboBox(25).Ancho = 36
        vArrayDatosComboBox(25).Flag = False

        vArrayDatosComboBox(26).NombreCampo = "DOC_NUMERO_AFE"
        vArrayDatosComboBox(26).Longitud = 10
        vArrayDatosComboBox(26).Tipo = "varchar"
        vArrayDatosComboBox(26).ParteEntera = 0
        vArrayDatosComboBox(26).ParteDecimal = 0
        ReDim vArrayDatosComboBox(26).Valores(0, 0)
        vArrayDatosComboBox(26).Ancho = 111
        vArrayDatosComboBox(26).Flag = False

        vArrayDatosComboBox(27).NombreCampo = "DOC_MOT_EMI"
        vArrayDatosComboBox(27).Longitud = 12
        vArrayDatosComboBox(27).Tipo = "varchar"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(5, 1)
        vArrayDatosComboBox(27).Valores(0, 0) = "ANULACION"
        vArrayDatosComboBox(27).Valores(0, 1) = "0"
        vArrayDatosComboBox(27).Valores(1, 0) = "BONIFICACION"
        vArrayDatosComboBox(27).Valores(1, 1) = "1"
        vArrayDatosComboBox(27).Valores(2, 0) = "DESCUENTO"
        vArrayDatosComboBox(27).Valores(2, 1) = "2"
        vArrayDatosComboBox(27).Valores(3, 0) = "DEVOLUCIONES"
        vArrayDatosComboBox(27).Valores(3, 1) = "3"
        vArrayDatosComboBox(27).Valores(4, 0) = "OTROS"
        vArrayDatosComboBox(27).Valores(4, 1) = "4"
        vArrayDatosComboBox(27).Valores(5, 0) = "DESC. ESPEC."
        vArrayDatosComboBox(27).Valores(5, 1) = "5"
        vArrayDatosComboBox(27).Ancho = 113
        vArrayDatosComboBox(27).Flag = True

        vArrayDatosComboBox(28).NombreCampo = "DOC_ESTADO"
        vArrayDatosComboBox(28).Longitud = 12
        vArrayDatosComboBox(28).Tipo = "varchar"
        vArrayDatosComboBox(28).ParteEntera = 0
        vArrayDatosComboBox(28).ParteDecimal = 0
        ReDim vArrayDatosComboBox(28).Valores(1, 1)
        vArrayDatosComboBox(28).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(28).Valores(0, 1) = "0"
        vArrayDatosComboBox(28).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(28).Valores(1, 1) = "1"
        vArrayDatosComboBox(28).Ancho = 85
        vArrayDatosComboBox(28).Flag = True

        vArrayDatosComboBox(29).NombreCampo = "TDO_ID_AFP_D"
        vArrayDatosComboBox(29).Longitud = 3
        vArrayDatosComboBox(29).Tipo = "char"
        vArrayDatosComboBox(29).ParteEntera = 0
        vArrayDatosComboBox(29).ParteDecimal = 0
        ReDim vArrayDatosComboBox(29).Valores(0, 0)
        vArrayDatosComboBox(29).Ancho = 36
        vArrayDatosComboBox(29).Flag = False

        vArrayDatosComboBox(30).NombreCampo = "TDO_DESCRIPCION_AFP_D"
        vArrayDatosComboBox(30).Longitud = 45
        vArrayDatosComboBox(30).Tipo = "varchar"
        vArrayDatosComboBox(30).ParteEntera = 0
        vArrayDatosComboBox(30).ParteDecimal = 0
        ReDim vArrayDatosComboBox(30).Valores(0, 0)
        vArrayDatosComboBox(30).Ancho = 485
        vArrayDatosComboBox(30).Flag = False

        vArrayDatosComboBox(31).NombreCampo = "DTD_ID_AFP_D"
        vArrayDatosComboBox(31).Longitud = 3
        vArrayDatosComboBox(31).Tipo = "char"
        vArrayDatosComboBox(31).ParteEntera = 0
        vArrayDatosComboBox(31).ParteDecimal = 0
        ReDim vArrayDatosComboBox(31).Valores(0, 0)
        vArrayDatosComboBox(31).Ancho = 36
        vArrayDatosComboBox(31).Flag = False

        vArrayDatosComboBox(32).NombreCampo = "DTD_DESCRIPCION_AFP_D"
        vArrayDatosComboBox(32).Longitud = 45
        vArrayDatosComboBox(32).Tipo = "varchar"
        vArrayDatosComboBox(32).ParteEntera = 0
        vArrayDatosComboBox(32).ParteDecimal = 0
        ReDim vArrayDatosComboBox(32).Valores(0, 0)
        vArrayDatosComboBox(32).Ancho = 485
        vArrayDatosComboBox(32).Flag = False

        vArrayDatosComboBox(33).NombreCampo = "CCT_ID_AFP_D"
        vArrayDatosComboBox(33).Longitud = 3
        vArrayDatosComboBox(33).Tipo = "char"
        vArrayDatosComboBox(33).ParteEntera = 0
        vArrayDatosComboBox(33).ParteDecimal = 0
        ReDim vArrayDatosComboBox(33).Valores(0, 0)
        vArrayDatosComboBox(33).Ancho = 36
        vArrayDatosComboBox(33).Flag = False

        vArrayDatosComboBox(34).NombreCampo = "CCT_DESCRIPCION_AFP_D"
        vArrayDatosComboBox(34).Longitud = 45
        vArrayDatosComboBox(34).Tipo = "varchar"
        vArrayDatosComboBox(34).ParteEntera = 0
        vArrayDatosComboBox(34).ParteDecimal = 0
        ReDim vArrayDatosComboBox(34).Valores(0, 0)
        vArrayDatosComboBox(34).Ancho = 485
        vArrayDatosComboBox(34).Flag = False

        vArrayDatosComboBox(35).NombreCampo = "DOC_SERIE_AFP_D"
        vArrayDatosComboBox(35).Longitud = 3
        vArrayDatosComboBox(35).Tipo = "char"
        vArrayDatosComboBox(35).ParteEntera = 0
        vArrayDatosComboBox(35).ParteDecimal = 0
        ReDim vArrayDatosComboBox(35).Valores(0, 0)
        vArrayDatosComboBox(35).Ancho = 36
        vArrayDatosComboBox(35).Flag = False

        vArrayDatosComboBox(36).NombreCampo = "DOC_NUMERO_AFP_D"
        vArrayDatosComboBox(36).Longitud = 10
        vArrayDatosComboBox(36).Tipo = "varchar"
        vArrayDatosComboBox(36).ParteEntera = 0
        vArrayDatosComboBox(36).ParteDecimal = 0
        ReDim vArrayDatosComboBox(36).Valores(0, 0)
        vArrayDatosComboBox(36).Ancho = 111
        vArrayDatosComboBox(36).Flag = False

        vArrayDatosComboBox(37).NombreCampo = "DAP_ITEM"
        vArrayDatosComboBox(37).Longitud = 3
        vArrayDatosComboBox(37).Tipo = "numeric"
        vArrayDatosComboBox(37).ParteEntera = 3
        vArrayDatosComboBox(37).ParteDecimal = 0
        ReDim vArrayDatosComboBox(37).Valores(0, 0)
        vArrayDatosComboBox(37).Ancho = 36
        vArrayDatosComboBox(37).Flag = False

        vArrayDatosComboBox(38).NombreCampo = "ART_ID"
        vArrayDatosComboBox(38).Longitud = 6
        vArrayDatosComboBox(38).Tipo = "char"
        vArrayDatosComboBox(38).ParteEntera = 0
        vArrayDatosComboBox(38).ParteDecimal = 0
        ReDim vArrayDatosComboBox(38).Valores(0, 0)
        vArrayDatosComboBox(38).Ancho = 68
        vArrayDatosComboBox(38).Flag = False

        vArrayDatosComboBox(39).NombreCampo = "DAP_CANTIDAD"
        vArrayDatosComboBox(39).Longitud = 18
        vArrayDatosComboBox(39).Tipo = "numeric"
        vArrayDatosComboBox(39).ParteEntera = 15
        vArrayDatosComboBox(39).ParteDecimal = 3
        ReDim vArrayDatosComboBox(39).Valores(0, 0)
        vArrayDatosComboBox(39).Ancho = 197
        vArrayDatosComboBox(39).Flag = False

        vArrayDatosComboBox(40).NombreCampo = "DDA_OBS"
        vArrayDatosComboBox(40).Longitud = 50
        vArrayDatosComboBox(40).Tipo = "varchar"
        vArrayDatosComboBox(40).ParteEntera = 0
        vArrayDatosComboBox(40).ParteDecimal = 0
        ReDim vArrayDatosComboBox(40).Valores(0, 0)
        vArrayDatosComboBox(40).Ancho = 539
        vArrayDatosComboBox(40).Flag = False

        vArrayDatosComboBox(41).NombreCampo = "TDO_ID_DEV"
        vArrayDatosComboBox(41).Longitud = 3
        vArrayDatosComboBox(41).Tipo = "char"
        vArrayDatosComboBox(41).ParteEntera = 0
        vArrayDatosComboBox(41).ParteDecimal = 0
        ReDim vArrayDatosComboBox(41).Valores(0, 0)
        vArrayDatosComboBox(41).Ancho = 36
        vArrayDatosComboBox(41).Flag = False

        vArrayDatosComboBox(42).NombreCampo = "TDO_DESCRIPCION_DEV"
        vArrayDatosComboBox(42).Longitud = 45
        vArrayDatosComboBox(42).Tipo = "varchar"
        vArrayDatosComboBox(42).ParteEntera = 0
        vArrayDatosComboBox(42).ParteDecimal = 0
        ReDim vArrayDatosComboBox(42).Valores(0, 0)
        vArrayDatosComboBox(42).Ancho = 485
        vArrayDatosComboBox(42).Flag = False

        vArrayDatosComboBox(43).NombreCampo = "DTD_ID_DEV"
        vArrayDatosComboBox(43).Longitud = 3
        vArrayDatosComboBox(43).Tipo = "char"
        vArrayDatosComboBox(43).ParteEntera = 0
        vArrayDatosComboBox(43).ParteDecimal = 0
        ReDim vArrayDatosComboBox(43).Valores(0, 0)
        vArrayDatosComboBox(43).Ancho = 36
        vArrayDatosComboBox(43).Flag = False

        vArrayDatosComboBox(44).NombreCampo = "DTD_DESCRIPCION_DEV"
        vArrayDatosComboBox(44).Longitud = 45
        vArrayDatosComboBox(44).Tipo = "varchar"
        vArrayDatosComboBox(44).ParteEntera = 0
        vArrayDatosComboBox(44).ParteDecimal = 0
        ReDim vArrayDatosComboBox(44).Valores(0, 0)
        vArrayDatosComboBox(44).Ancho = 485
        vArrayDatosComboBox(44).Flag = False

        vArrayDatosComboBox(45).NombreCampo = "CCT_ID_DEV"
        vArrayDatosComboBox(45).Longitud = 3
        vArrayDatosComboBox(45).Tipo = "char"
        vArrayDatosComboBox(45).ParteEntera = 0
        vArrayDatosComboBox(45).ParteDecimal = 0
        ReDim vArrayDatosComboBox(45).Valores(0, 0)
        vArrayDatosComboBox(45).Ancho = 36
        vArrayDatosComboBox(45).Flag = False

        vArrayDatosComboBox(46).NombreCampo = "CCT_DESCRIPCION_DEV"
        vArrayDatosComboBox(46).Longitud = 45
        vArrayDatosComboBox(46).Tipo = "varchar"
        vArrayDatosComboBox(46).ParteEntera = 0
        vArrayDatosComboBox(46).ParteDecimal = 0
        ReDim vArrayDatosComboBox(46).Valores(0, 0)
        vArrayDatosComboBox(46).Ancho = 485
        vArrayDatosComboBox(46).Flag = False

        vArrayDatosComboBox(47).NombreCampo = "DES_SERIE_DEV"
        vArrayDatosComboBox(47).Longitud = 3
        vArrayDatosComboBox(47).Tipo = "char"
        vArrayDatosComboBox(47).ParteEntera = 0
        vArrayDatosComboBox(47).ParteDecimal = 0
        ReDim vArrayDatosComboBox(47).Valores(0, 0)
        vArrayDatosComboBox(47).Ancho = 36
        vArrayDatosComboBox(47).Flag = False

        vArrayDatosComboBox(48).NombreCampo = "DES_NUMERO_DEV"
        vArrayDatosComboBox(48).Longitud = 10
        vArrayDatosComboBox(48).Tipo = "varchar"
        vArrayDatosComboBox(48).ParteEntera = 0
        vArrayDatosComboBox(48).ParteDecimal = 0
        ReDim vArrayDatosComboBox(48).Valores(0, 0)
        vArrayDatosComboBox(48).Ancho = 111
        vArrayDatosComboBox(48).Flag = False

        vArrayDatosComboBox(49).NombreCampo = "ART_ID_DEV"
        vArrayDatosComboBox(49).Longitud = 6
        vArrayDatosComboBox(49).Tipo = "char"
        vArrayDatosComboBox(49).ParteEntera = 0
        vArrayDatosComboBox(49).ParteDecimal = 0
        ReDim vArrayDatosComboBox(49).Valores(0, 0)
        vArrayDatosComboBox(49).Ancho = 68
        vArrayDatosComboBox(49).Flag = False

        vArrayDatosComboBox(51).NombreCampo = "ART_DESCRIPCION_DEV"
        vArrayDatosComboBox(51).Longitud = 45
        vArrayDatosComboBox(51).Tipo = "varchar"
        vArrayDatosComboBox(51).ParteEntera = 0
        vArrayDatosComboBox(51).ParteDecimal = 0
        ReDim vArrayDatosComboBox(51).Valores(0, 0)
        vArrayDatosComboBox(51).Ancho = 485
        vArrayDatosComboBox(51).Flag = False

        vArrayDatosComboBox(51).NombreCampo = "DDE_CANTIDAD_DEV"
        vArrayDatosComboBox(51).Longitud = 18
        vArrayDatosComboBox(51).Tipo = "numeric"
        vArrayDatosComboBox(51).ParteEntera = 15
        vArrayDatosComboBox(51).ParteDecimal = 3
        ReDim vArrayDatosComboBox(51).Valores(0, 0)
        vArrayDatosComboBox(51).Ancho = 197
        vArrayDatosComboBox(51).Flag = False

        vArrayDatosComboBox(52).NombreCampo = "DDA_ESTADO"
        vArrayDatosComboBox(52).Longitud = 9
        vArrayDatosComboBox(52).Tipo = "varchar"
        vArrayDatosComboBox(52).ParteEntera = 0
        vArrayDatosComboBox(52).ParteDecimal = 0
        ReDim vArrayDatosComboBox(52).Valores(1, 1)
        vArrayDatosComboBox(52).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(52).Valores(0, 1) = "0"
        vArrayDatosComboBox(52).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(52).Valores(1, 1) = "1"
        vArrayDatosComboBox(52).Ancho = 85
        vArrayDatosComboBox(52).Flag = True
    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "TDO_ID"
                    If Len(TDO_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_ID"
                    If Len(DTD_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DAP_SERIE"
                    If Len(DAP_SERIE.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DAP_NUMERO"
                    If Len(DAP_NUMERO.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DAP_ITEM"
                    If DAP_ITEM >= 0 And DAP_ITEM <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TDO_ID_AFP"
                    If Len(TDO_ID_AFP.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_ID_AFP"
                    If Len(DTD_ID_AFP.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCT_ID_AFP"
                    If Len(CCT_ID_AFP.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DOC_SERIE_AFP"
                    If Len(DOC_SERIE_AFP.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DOC_NUMERO_AFP"
                    If Len(DOC_NUMERO_AFP.Trim) > 0 Then
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

                Case "DAP_CANTIDAD"
                    If DAP_CANTIDAD.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DAP_OBS"
                    If IsNothing(DAP_OBS) Then
                    Else
                        If DAP_OBS.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "TDO_ID_DEV"
                    If IsNothing(TDO_ID_DEV) Then
                    Else
                        If Len(TDO_ID_DEV.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "DTD_ID_DEV"
                    If IsNothing(DTD_ID_DEV) Then
                    Else
                        If Len(DTD_ID_DEV.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "CCT_ID_DEV"
                    If IsNothing(CCT_ID_DEV) Then
                    Else
                        If Len(CCT_ID_DEV.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "DES_SERIE_DEV"
                    If IsNothing(DES_SERIE_DEV) Then
                    Else
                        If Len(DES_SERIE_DEV.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "DES_NUMERO_DEV"
                    If IsNothing(DES_NUMERO_DEV) Then
                    Else
                        If Len(DES_NUMERO_DEV.Trim) > 0 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDescripcion
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "ART_ID_DEV"
                    If IsNothing(ART_ID_DEV) Then
                    Else
                        If Len(ART_ID_DEV.Trim) = 6 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo6
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "DDE_CANTIDAD_DEV"
                    If DDE_CANTIDAD_DEV.GetType = GetType(Decimal) Then
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

                Case "DAP_FEC_GRAB"
                    If DAP_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DAP_ESTADO"
                    If DAP_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaDetalleAfectaProductoDocumentosXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetalleAfectaProductoDocumentosNuevoXML"
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
                oVerificarDatos = VerificarDatos("TDO_ID", "DTD_ID", "DAP_SERIE", "DAP_NUMERO", "DAP_ITEM", "TDO_ID_AFP", "DTD_ID_AFP", "CCT_ID_AFP", "DOC_SERIE_AFP", "DOC_NUMERO_AFP", "ART_ID", "DAP_CANTIDAD", "DAP_OBS", "TDO_ID_DEV", "DTD_ID_DEV", "CCT_ID_DEV", "DES_SERIE_DEV", "DES_NUMERO_DEV", "ART_ID_DEV", "DDE_CANTIDAD_DEV", "USU_ID", "DAP_FEC_GRAB", "DAP_ESTADO")
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

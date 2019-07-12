Imports Ladisac.BE
Partial Public Class Despachos
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
    Public CampoPrincipal = "TDO_ID"
    Public CampoPrincipalSecundario = "DTD_ID"
    Public CampoPrincipalTercero = "DES_SERIE"
    Public CampoPrincipalCuarto = "DES_NUMERO"
    Public CampoPrincipalValor = TDO_ID
    Public CampoPrincipalSecundarioValor = DTD_ID
    Public CampoPrincipalTerceroValor = DES_SERIE
    Public CampoPrincipalCuartoValor = DES_NUMERO
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Des.Despachos"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "Despachos"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDespachos"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDespachos"
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
        vElementosDatosComboBox = 120
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "TDO_ID"
        vArrayCamposBusqueda(1) = "TDO_DESCRIPCION"
        vArrayCamposBusqueda(2) = "DTD_ID"
        vArrayCamposBusqueda(3) = "DTD_DESCRIPCION"
        vArrayCamposBusqueda(4) = "CCT_ID"
        vArrayCamposBusqueda(5) = "CCT_DESCRIPCION"
        vArrayCamposBusqueda(6) = "DES_FEC_EMI"
        vArrayCamposBusqueda(7) = "DES_FEC_TRA"
        vArrayCamposBusqueda(8) = "PVE_ID"
        vArrayCamposBusqueda(9) = "PVE_DESCRIPCION"
        vArrayCamposBusqueda(10) = "PVE_DIRECCION"
        vArrayCamposBusqueda(11) = "DIS_ID_PVE"
        vArrayCamposBusqueda(12) = "DIS_DESCRIPCION_PVE"
        vArrayCamposBusqueda(13) = "DIS_ESTADO_PVE"
        vArrayCamposBusqueda(14) = "PRO_ID_PVE"
        vArrayCamposBusqueda(15) = "PRO_DESCRIPCION_PVE"
        vArrayCamposBusqueda(16) = "PRO_ESTADO_PVE"
        vArrayCamposBusqueda(17) = "DEP_ID_PVE"
        vArrayCamposBusqueda(18) = "DEP_DESCRIPCION_PVE"
        vArrayCamposBusqueda(19) = "DEP_ESTADO_PVE"
        vArrayCamposBusqueda(20) = "PAI_ID_PVE"
        vArrayCamposBusqueda(21) = "PAI_DESCRIPCION_PVE"
        vArrayCamposBusqueda(22) = "PAI_ESTADO_PVE"
        vArrayCamposBusqueda(23) = "ALM_ID"
        vArrayCamposBusqueda(24) = "ALM_DESCRIPCION"
        vArrayCamposBusqueda(25) = "ALM_DIRECCION"
        vArrayCamposBusqueda(26) = "DIS_ID_ALM"
        vArrayCamposBusqueda(27) = "DIS_DESCRIPCION_ALM"
        vArrayCamposBusqueda(28) = "DIS_ESTADO_ALM"
        vArrayCamposBusqueda(29) = "PRO_ID_ALM"
        vArrayCamposBusqueda(30) = "PRO_DESCRIPCION_ALM"
        vArrayCamposBusqueda(31) = "PRO_ESTADO_ALM"
        vArrayCamposBusqueda(32) = "DEP_ID_ALM"
        vArrayCamposBusqueda(33) = "DEP_DESCRIPCION_ALM"
        vArrayCamposBusqueda(34) = "DEP_ESTADO_ALM"
        vArrayCamposBusqueda(35) = "PAI_ID_ALM"
        vArrayCamposBusqueda(36) = "PAI_DESCRIPCION_ALM"
        vArrayCamposBusqueda(37) = "PAI_ESTADO_ALM"
        vArrayCamposBusqueda(38) = "ALM_ESTADO"
        vArrayCamposBusqueda(39) = "DES_SERIE"
        vArrayCamposBusqueda(40) = "DES_NUMERO"
        vArrayCamposBusqueda(41) = "PER_ID_CLI"
        vArrayCamposBusqueda(42) = "PER_DESCRIPCION_CLI"
        vArrayCamposBusqueda(43) = "TDP_ID_CLI"
        vArrayCamposBusqueda(44) = "TDP_DESCRIPCION_CLI"
        vArrayCamposBusqueda(45) = "DOP_NUMERO_CLI"
        vArrayCamposBusqueda(46) = "PER_ID_VEN"
        vArrayCamposBusqueda(47) = "PER_DESCRIPCION_VEN"
        vArrayCamposBusqueda(48) = "TDO_ID_DOC"
        vArrayCamposBusqueda(49) = "TDO_DESCRIPCION_DOC"
        vArrayCamposBusqueda(50) = "DTD_ID_DOC"
        vArrayCamposBusqueda(51) = "DTD_DESCRIPCION_DOC"
        vArrayCamposBusqueda(52) = "CCT_ID_DOC"
        vArrayCamposBusqueda(53) = "CCT_DESCRIPCION_DOC"
        vArrayCamposBusqueda(54) = "DOC_ORDEN_COMPRA"
        vArrayCamposBusqueda(55) = "TIV_ID_DOC"
        vArrayCamposBusqueda(56) = "TIV_DESCRIPCION_DOC"
        vArrayCamposBusqueda(57) = "MON_ID_DOC"
        vArrayCamposBusqueda(58) = "MON_DESCRIPCION_DOC"
        vArrayCamposBusqueda(59) = "DES_SERIE_DOC"
        vArrayCamposBusqueda(60) = "DES_NUMERO_DOC"
        vArrayCamposBusqueda(61) = "PER_ID_REC"
        vArrayCamposBusqueda(62) = "PER_DESCRIPCION_REC"
        vArrayCamposBusqueda(63) = "TDP_ID_REC"
        vArrayCamposBusqueda(64) = "TDP_DESCRIPCION_REC"
        vArrayCamposBusqueda(65) = "DOP_NUMERO_REC"
        vArrayCamposBusqueda(66) = "DIR_ID_ENT_REC"
        vArrayCamposBusqueda(67) = "DIR_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(68) = "DIR_TIPO_ENT_REC"
        vArrayCamposBusqueda(69) = "DIR_REFERENCIA_ENT_REC"
        vArrayCamposBusqueda(70) = "DIS_ID_ENT_REC"
        vArrayCamposBusqueda(71) = "DIS_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(72) = "PRO_ID_ENT_REC"
        vArrayCamposBusqueda(73) = "PRO_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(74) = "DEP_ID_ENT_REC"
        vArrayCamposBusqueda(75) = "DEP_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(76) = "PAI_ID_ENT_REC"
        vArrayCamposBusqueda(77) = "PAI_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(78) = "DIR_ESTADO_ENT_REC"
        vArrayCamposBusqueda(79) = "DIR_ID_ENT"
        vArrayCamposBusqueda(80) = "DIR_DESCRIPCION_ENT"
        vArrayCamposBusqueda(81) = "DIS_ID_ENT"
        vArrayCamposBusqueda(82) = "DIS_DESCRIPCION_ENT"
        vArrayCamposBusqueda(83) = "DIS_ESTADO_ENT"
        vArrayCamposBusqueda(84) = "PRO_ID_ENT"
        vArrayCamposBusqueda(85) = "PRO_DESCRIPCION_ENT"
        vArrayCamposBusqueda(86) = "PRO_ESTADO_ENT"
        vArrayCamposBusqueda(87) = "DEP_ID_ENT"
        vArrayCamposBusqueda(88) = "DEP_DESCRIPCION_ENT"
        vArrayCamposBusqueda(89) = "DEP_ESTADO_ENT"
        vArrayCamposBusqueda(90) = "PAI_ID_ENT"
        vArrayCamposBusqueda(91) = "PAI_DESCRIPCION_ENT"
        vArrayCamposBusqueda(92) = "PAIS_ESTADO_ENT"
        vArrayCamposBusqueda(93) = "DIR_REFERENCIA_ENT"
        vArrayCamposBusqueda(94) = "FLE_ID"
        vArrayCamposBusqueda(95) = "FLE_DESCRIPCION"
        vArrayCamposBusqueda(96) = "FLE_TIPO"
        vArrayCamposBusqueda(97) = "FLE_ESTADO"
        vArrayCamposBusqueda(98) = "MON_ID"
        vArrayCamposBusqueda(99) = "MON_DESCRIPCION"
        vArrayCamposBusqueda(100) = "DES_MONTO_FLETE"
        vArrayCamposBusqueda(101) = "DES_CONTRAVALOR"
        vArrayCamposBusqueda(102) = "PLA_ID"
        vArrayCamposBusqueda(103) = "PER_ID_TRA1"
        vArrayCamposBusqueda(104) = "PER_DESCRIPCION_TRA1"
        vArrayCamposBusqueda(105) = "RUC_TRA1"
        vArrayCamposBusqueda(106) = "PER_ESTADO_TRA1"
        vArrayCamposBusqueda(107) = "UNT_ID_1"
        vArrayCamposBusqueda(108) = "MAR_DESCRIPCION_TRA1"
        vArrayCamposBusqueda(109) = "MOD_DESCRIPCION_TRA1"
        vArrayCamposBusqueda(110) = "UNT_NRO_INS_TRA1"
        vArrayCamposBusqueda(111) = "UNT_ID_2"
        vArrayCamposBusqueda(112) = "MAR_DESCRIPCION_TRA2"
        vArrayCamposBusqueda(113) = "MOD_DESCRIPCION_TRA2"
        vArrayCamposBusqueda(114) = "UNT_NRO_INS_TRA2"
        vArrayCamposBusqueda(115) = "PER_ID_CHO"
        vArrayCamposBusqueda(116) = "PER_DESCRIPCION_CHO"
        vArrayCamposBusqueda(117) = "PER_BREVETE_CHO"
        vArrayCamposBusqueda(118) = "PER_ESTADO_CHO"
        vArrayCamposBusqueda(119) = "DES_TIPO_GUIA"
        vArrayCamposBusqueda(120) = "DES_ESTADO"

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

        vArrayDatosComboBox(6).NombreCampo = "DES_FEC_EMI"
        vArrayDatosComboBox(6).Longitud = 0
        vArrayDatosComboBox(6).Tipo = "smalldatetime"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 15
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "DES_FEC_TRA"
        vArrayDatosComboBox(7).Longitud = 0
        vArrayDatosComboBox(7).Tipo = "smalldatetime"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 15
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

        vArrayDatosComboBox(10).NombreCampo = "PVE_DIRECCION"
        vArrayDatosComboBox(10).Longitud = 65
        vArrayDatosComboBox(10).Tipo = "varchar"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 699
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "DIS_ID_PVE"
        vArrayDatosComboBox(11).Longitud = 3
        vArrayDatosComboBox(11).Tipo = "char"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 36
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "DIS_DESCRIPCION_PVE"
        vArrayDatosComboBox(12).Longitud = 45
        vArrayDatosComboBox(12).Tipo = "varchar"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 485
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "DIS_ESTADO_PVE"
        vArrayDatosComboBox(13).Longitud = 9
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 100
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "PRO_ID_PVE"
        vArrayDatosComboBox(14).Longitud = 3
        vArrayDatosComboBox(14).Tipo = "char"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 36
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "PRO_DESCRIPCION_PVE"
        vArrayDatosComboBox(15).Longitud = 45
        vArrayDatosComboBox(15).Tipo = "varchar"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 485
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "PRO_ESTADO_PVE"
        vArrayDatosComboBox(16).Longitud = 9
        vArrayDatosComboBox(16).Tipo = "varchar"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 100
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "DEP_ID_PVE"
        vArrayDatosComboBox(17).Longitud = 3
        vArrayDatosComboBox(17).Tipo = "char"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 36
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "DEP_DESCRIPCION_PVE"
        vArrayDatosComboBox(18).Longitud = 45
        vArrayDatosComboBox(18).Tipo = "varchar"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(0, 0)
        vArrayDatosComboBox(18).Ancho = 485
        vArrayDatosComboBox(18).Flag = False

        vArrayDatosComboBox(19).NombreCampo = "DEP_ESTADO_PVE"
        vArrayDatosComboBox(19).Longitud = 9
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(0, 0)
        vArrayDatosComboBox(19).Ancho = 100
        vArrayDatosComboBox(19).Flag = False

        vArrayDatosComboBox(20).NombreCampo = "PAI_ID_PVE"
        vArrayDatosComboBox(20).Longitud = 3
        vArrayDatosComboBox(20).Tipo = "char"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(0, 0)
        vArrayDatosComboBox(20).Ancho = 36
        vArrayDatosComboBox(20).Flag = False

        vArrayDatosComboBox(21).NombreCampo = "PAI_DESCRIPCION_PVE"
        vArrayDatosComboBox(21).Longitud = 45
        vArrayDatosComboBox(21).Tipo = "varchar"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(0, 0)
        vArrayDatosComboBox(21).Ancho = 485
        vArrayDatosComboBox(21).Flag = False

        vArrayDatosComboBox(22).NombreCampo = "PAI_ESTADO_PVE"
        vArrayDatosComboBox(22).Longitud = 9
        vArrayDatosComboBox(22).Tipo = "varchar"
        vArrayDatosComboBox(22).ParteEntera = 0
        vArrayDatosComboBox(22).ParteDecimal = 0
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 100
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "ALM_ID"
        vArrayDatosComboBox(23).Longitud = 10
        vArrayDatosComboBox(23).Tipo = "int"
        vArrayDatosComboBox(23).ParteEntera = 10
        vArrayDatosComboBox(23).ParteDecimal = 0
        ReDim vArrayDatosComboBox(23).Valores(0, 0)
        vArrayDatosComboBox(23).Ancho = 111
        vArrayDatosComboBox(23).Flag = False

        vArrayDatosComboBox(24).NombreCampo = "ALM_DESCRIPCION"
        vArrayDatosComboBox(24).Longitud = 45
        vArrayDatosComboBox(24).Tipo = "varchar"
        vArrayDatosComboBox(24).ParteEntera = 0
        vArrayDatosComboBox(24).ParteDecimal = 0
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 485
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "ALM_DIRECCION"
        vArrayDatosComboBox(25).Longitud = 65
        vArrayDatosComboBox(25).Tipo = "varchar"
        vArrayDatosComboBox(25).ParteEntera = 0
        vArrayDatosComboBox(25).ParteDecimal = 0
        ReDim vArrayDatosComboBox(25).Valores(0, 0)
        vArrayDatosComboBox(25).Ancho = 699
        vArrayDatosComboBox(25).Flag = False

        vArrayDatosComboBox(26).NombreCampo = "DIS_ID_ALM"
        vArrayDatosComboBox(26).Longitud = 3
        vArrayDatosComboBox(26).Tipo = "char"
        vArrayDatosComboBox(26).ParteEntera = 0
        vArrayDatosComboBox(26).ParteDecimal = 0
        ReDim vArrayDatosComboBox(26).Valores(0, 0)
        vArrayDatosComboBox(26).Ancho = 36
        vArrayDatosComboBox(26).Flag = False

        vArrayDatosComboBox(27).NombreCampo = "DIS_DESCRIPCION_ALM"
        vArrayDatosComboBox(27).Longitud = 45
        vArrayDatosComboBox(27).Tipo = "varchar"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(0, 0)
        vArrayDatosComboBox(27).Ancho = 485
        vArrayDatosComboBox(27).Flag = False

        vArrayDatosComboBox(28).NombreCampo = "DIS_ESTADO_ALM"
        vArrayDatosComboBox(28).Longitud = 9
        vArrayDatosComboBox(28).Tipo = "varchar"
        vArrayDatosComboBox(28).ParteEntera = 0
        vArrayDatosComboBox(28).ParteDecimal = 0
        ReDim vArrayDatosComboBox(28).Valores(0, 0)
        vArrayDatosComboBox(28).Ancho = 100
        vArrayDatosComboBox(28).Flag = False

        vArrayDatosComboBox(29).NombreCampo = "PRO_ID_ALM"
        vArrayDatosComboBox(29).Longitud = 3
        vArrayDatosComboBox(29).Tipo = "char"
        vArrayDatosComboBox(29).ParteEntera = 0
        vArrayDatosComboBox(29).ParteDecimal = 0
        ReDim vArrayDatosComboBox(29).Valores(0, 0)
        vArrayDatosComboBox(29).Ancho = 36
        vArrayDatosComboBox(29).Flag = False

        vArrayDatosComboBox(30).NombreCampo = "PRO_DESCRIPCION_ALM"
        vArrayDatosComboBox(30).Longitud = 45
        vArrayDatosComboBox(30).Tipo = "varchar"
        vArrayDatosComboBox(30).ParteEntera = 0
        vArrayDatosComboBox(30).ParteDecimal = 0
        ReDim vArrayDatosComboBox(30).Valores(0, 0)
        vArrayDatosComboBox(30).Ancho = 485
        vArrayDatosComboBox(30).Flag = False

        vArrayDatosComboBox(31).NombreCampo = "PRO_ESTADO_ALM"
        vArrayDatosComboBox(31).Longitud = 9
        vArrayDatosComboBox(31).Tipo = "varchar"
        vArrayDatosComboBox(31).ParteEntera = 0
        vArrayDatosComboBox(31).ParteDecimal = 0
        ReDim vArrayDatosComboBox(31).Valores(0, 0)
        vArrayDatosComboBox(31).Ancho = 100
        vArrayDatosComboBox(31).Flag = False

        vArrayDatosComboBox(32).NombreCampo = "DEP_ID_ALM"
        vArrayDatosComboBox(32).Longitud = 3
        vArrayDatosComboBox(32).Tipo = "char"
        vArrayDatosComboBox(32).ParteEntera = 0
        vArrayDatosComboBox(32).ParteDecimal = 0
        ReDim vArrayDatosComboBox(32).Valores(0, 0)
        vArrayDatosComboBox(32).Ancho = 36
        vArrayDatosComboBox(32).Flag = False

        vArrayDatosComboBox(33).NombreCampo = "DEP_DESCRIPCION_ALM"
        vArrayDatosComboBox(33).Longitud = 45
        vArrayDatosComboBox(33).Tipo = "varchar"
        vArrayDatosComboBox(33).ParteEntera = 0
        vArrayDatosComboBox(33).ParteDecimal = 0
        ReDim vArrayDatosComboBox(33).Valores(0, 0)
        vArrayDatosComboBox(33).Ancho = 485
        vArrayDatosComboBox(33).Flag = False

        vArrayDatosComboBox(34).NombreCampo = "DEP_ESTADO_ALM"
        vArrayDatosComboBox(34).Longitud = 9
        vArrayDatosComboBox(34).Tipo = "varchar"
        vArrayDatosComboBox(34).ParteEntera = 0
        vArrayDatosComboBox(34).ParteDecimal = 0
        ReDim vArrayDatosComboBox(34).Valores(0, 0)
        vArrayDatosComboBox(34).Ancho = 100
        vArrayDatosComboBox(34).Flag = False

        vArrayDatosComboBox(35).NombreCampo = "PAI_ID_ALM"
        vArrayDatosComboBox(35).Longitud = 3
        vArrayDatosComboBox(35).Tipo = "char"
        vArrayDatosComboBox(35).ParteEntera = 0
        vArrayDatosComboBox(35).ParteDecimal = 0
        ReDim vArrayDatosComboBox(35).Valores(0, 0)
        vArrayDatosComboBox(35).Ancho = 36
        vArrayDatosComboBox(35).Flag = False

        vArrayDatosComboBox(36).NombreCampo = "PAI_DESCRIPCION_ALM"
        vArrayDatosComboBox(36).Longitud = 45
        vArrayDatosComboBox(36).Tipo = "varchar"
        vArrayDatosComboBox(36).ParteEntera = 0
        vArrayDatosComboBox(36).ParteDecimal = 0
        ReDim vArrayDatosComboBox(36).Valores(0, 0)
        vArrayDatosComboBox(36).Ancho = 485
        vArrayDatosComboBox(36).Flag = False

        vArrayDatosComboBox(37).NombreCampo = "PAI_ESTADO_ALM"
        vArrayDatosComboBox(37).Longitud = 9
        vArrayDatosComboBox(37).Tipo = "varchar"
        vArrayDatosComboBox(37).ParteEntera = 0
        vArrayDatosComboBox(37).ParteDecimal = 0
        ReDim vArrayDatosComboBox(37).Valores(0, 0)
        vArrayDatosComboBox(37).Ancho = 100
        vArrayDatosComboBox(37).Flag = False

        vArrayDatosComboBox(38).NombreCampo = "ALM_ESTADO"
        vArrayDatosComboBox(38).Longitud = 9
        vArrayDatosComboBox(38).Tipo = "varchar"
        vArrayDatosComboBox(38).ParteEntera = 0
        vArrayDatosComboBox(38).ParteDecimal = 0
        ReDim vArrayDatosComboBox(38).Valores(1, 1)
        vArrayDatosComboBox(38).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(38).Valores(0, 1) = "0"
        vArrayDatosComboBox(38).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(38).Valores(1, 1) = "1"
        vArrayDatosComboBox(38).Ancho = 85
        vArrayDatosComboBox(38).Flag = True

        vArrayDatosComboBox(39).NombreCampo = "DES_SERIE"
        vArrayDatosComboBox(39).Longitud = 3
        vArrayDatosComboBox(39).Tipo = "char"
        vArrayDatosComboBox(39).ParteEntera = 0
        vArrayDatosComboBox(39).ParteDecimal = 0
        ReDim vArrayDatosComboBox(39).Valores(0, 0)
        vArrayDatosComboBox(39).Ancho = 36
        vArrayDatosComboBox(39).Flag = False

        vArrayDatosComboBox(40).NombreCampo = "DES_NUMERO"
        vArrayDatosComboBox(40).Longitud = 10
        vArrayDatosComboBox(40).Tipo = "char"
        vArrayDatosComboBox(40).ParteEntera = 0
        vArrayDatosComboBox(40).ParteDecimal = 0
        ReDim vArrayDatosComboBox(40).Valores(0, 0)
        vArrayDatosComboBox(40).Ancho = 111
        vArrayDatosComboBox(40).Flag = False

        vArrayDatosComboBox(41).NombreCampo = "PER_ID_CLI"
        vArrayDatosComboBox(41).Longitud = 6
        vArrayDatosComboBox(41).Tipo = "char"
        vArrayDatosComboBox(41).ParteEntera = 0
        vArrayDatosComboBox(41).ParteDecimal = 0
        ReDim vArrayDatosComboBox(41).Valores(0, 0)
        vArrayDatosComboBox(41).Ancho = 68
        vArrayDatosComboBox(41).Flag = False

        vArrayDatosComboBox(42).NombreCampo = "PER_DESCRIPCION_CLI"
        vArrayDatosComboBox(42).Longitud = 77
        vArrayDatosComboBox(42).Tipo = "varchar"
        vArrayDatosComboBox(42).ParteEntera = 0
        vArrayDatosComboBox(42).ParteDecimal = 0
        ReDim vArrayDatosComboBox(42).Valores(0, 0)
        vArrayDatosComboBox(42).Ancho = 828
        vArrayDatosComboBox(42).Flag = False

        vArrayDatosComboBox(43).NombreCampo = "TDP_ID_CLI"
        vArrayDatosComboBox(43).Longitud = 2
        vArrayDatosComboBox(43).Tipo = "char"
        vArrayDatosComboBox(43).ParteEntera = 0
        vArrayDatosComboBox(43).ParteDecimal = 0
        ReDim vArrayDatosComboBox(43).Valores(0, 0)
        vArrayDatosComboBox(43).Ancho = 26
        vArrayDatosComboBox(43).Flag = False

        vArrayDatosComboBox(44).NombreCampo = "TDP_DESCRIPCION_CLI"
        vArrayDatosComboBox(44).Longitud = 45
        vArrayDatosComboBox(44).Tipo = "varchar"
        vArrayDatosComboBox(44).ParteEntera = 0
        vArrayDatosComboBox(44).ParteDecimal = 0
        ReDim vArrayDatosComboBox(44).Valores(0, 0)
        vArrayDatosComboBox(44).Ancho = 485
        vArrayDatosComboBox(44).Flag = False

        vArrayDatosComboBox(45).NombreCampo = "DOP_NUMERO_CLI"
        vArrayDatosComboBox(45).Longitud = 25
        vArrayDatosComboBox(45).Tipo = "varchar"
        vArrayDatosComboBox(45).ParteEntera = 0
        vArrayDatosComboBox(45).ParteDecimal = 0
        ReDim vArrayDatosComboBox(45).Valores(0, 0)
        vArrayDatosComboBox(45).Ancho = 272
        vArrayDatosComboBox(45).Flag = False

        vArrayDatosComboBox(46).NombreCampo = "PER_ID_VEN"
        vArrayDatosComboBox(46).Longitud = 6
        vArrayDatosComboBox(46).Tipo = "char"
        vArrayDatosComboBox(46).ParteEntera = 0
        vArrayDatosComboBox(46).ParteDecimal = 0
        ReDim vArrayDatosComboBox(46).Valores(0, 0)
        vArrayDatosComboBox(46).Ancho = 68
        vArrayDatosComboBox(46).Flag = False

        vArrayDatosComboBox(47).NombreCampo = "PER_DESCRIPCION_VEN"
        vArrayDatosComboBox(47).Longitud = 77
        vArrayDatosComboBox(47).Tipo = "varchar"
        vArrayDatosComboBox(47).ParteEntera = 0
        vArrayDatosComboBox(47).ParteDecimal = 0
        ReDim vArrayDatosComboBox(47).Valores(0, 0)
        vArrayDatosComboBox(47).Ancho = 828
        vArrayDatosComboBox(47).Flag = False

        vArrayDatosComboBox(48).NombreCampo = "TDO_ID_DOC"
        vArrayDatosComboBox(48).Longitud = 3
        vArrayDatosComboBox(48).Tipo = "char"
        vArrayDatosComboBox(48).ParteEntera = 0
        vArrayDatosComboBox(48).ParteDecimal = 0
        ReDim vArrayDatosComboBox(48).Valores(0, 0)
        vArrayDatosComboBox(48).Ancho = 36
        vArrayDatosComboBox(48).Flag = False

        vArrayDatosComboBox(49).NombreCampo = "TDO_DESCRIPCION_DOC"
        vArrayDatosComboBox(49).Longitud = 45
        vArrayDatosComboBox(49).Tipo = "varchar"
        vArrayDatosComboBox(49).ParteEntera = 0
        vArrayDatosComboBox(49).ParteDecimal = 0
        ReDim vArrayDatosComboBox(49).Valores(0, 0)
        vArrayDatosComboBox(49).Ancho = 485
        vArrayDatosComboBox(49).Flag = False

        vArrayDatosComboBox(50).NombreCampo = "DTD_ID_DOC"
        vArrayDatosComboBox(50).Longitud = 3
        vArrayDatosComboBox(50).Tipo = "char"
        vArrayDatosComboBox(50).ParteEntera = 0
        vArrayDatosComboBox(50).ParteDecimal = 0
        ReDim vArrayDatosComboBox(50).Valores(0, 0)
        vArrayDatosComboBox(50).Ancho = 36
        vArrayDatosComboBox(50).Flag = False

        vArrayDatosComboBox(51).NombreCampo = "DTD_DESCRIPCION_DOC"
        vArrayDatosComboBox(51).Longitud = 45
        vArrayDatosComboBox(51).Tipo = "varchar"
        vArrayDatosComboBox(51).ParteEntera = 0
        vArrayDatosComboBox(51).ParteDecimal = 0
        ReDim vArrayDatosComboBox(51).Valores(0, 0)
        vArrayDatosComboBox(51).Ancho = 485
        vArrayDatosComboBox(51).Flag = False

        vArrayDatosComboBox(52).NombreCampo = "CCT_ID_DOC"
        vArrayDatosComboBox(52).Longitud = 3
        vArrayDatosComboBox(52).Tipo = "char"
        vArrayDatosComboBox(52).ParteEntera = 0
        vArrayDatosComboBox(52).ParteDecimal = 0
        ReDim vArrayDatosComboBox(52).Valores(0, 0)
        vArrayDatosComboBox(52).Ancho = 36
        vArrayDatosComboBox(52).Flag = False

        vArrayDatosComboBox(53).NombreCampo = "CCT_DESCRIPCION_DOC"
        vArrayDatosComboBox(53).Longitud = 45
        vArrayDatosComboBox(53).Tipo = "varchar"
        vArrayDatosComboBox(53).ParteEntera = 0
        vArrayDatosComboBox(53).ParteDecimal = 0
        ReDim vArrayDatosComboBox(53).Valores(0, 0)
        vArrayDatosComboBox(53).Ancho = 485
        vArrayDatosComboBox(53).Flag = False

        vArrayDatosComboBox(54).NombreCampo = "DOC_ORDEN_COMPRA"
        vArrayDatosComboBox(54).Longitud = 20
        vArrayDatosComboBox(54).Tipo = "varchar"
        vArrayDatosComboBox(54).ParteEntera = 0
        vArrayDatosComboBox(54).ParteDecimal = 0
        ReDim vArrayDatosComboBox(54).Valores(0, 0)
        vArrayDatosComboBox(54).Ancho = 218
        vArrayDatosComboBox(54).Flag = False

        vArrayDatosComboBox(55).NombreCampo = "TIV_ID_DOC"
        vArrayDatosComboBox(55).Longitud = 3
        vArrayDatosComboBox(55).Tipo = "char"
        vArrayDatosComboBox(55).ParteEntera = 0
        vArrayDatosComboBox(55).ParteDecimal = 0
        ReDim vArrayDatosComboBox(55).Valores(0, 0)
        vArrayDatosComboBox(55).Ancho = 36
        vArrayDatosComboBox(55).Flag = False

        vArrayDatosComboBox(56).NombreCampo = "TIV_DESCRIPCION_DOC"
        vArrayDatosComboBox(56).Longitud = 45
        vArrayDatosComboBox(56).Tipo = "varchar"
        vArrayDatosComboBox(56).ParteEntera = 0
        vArrayDatosComboBox(56).ParteDecimal = 0
        ReDim vArrayDatosComboBox(56).Valores(0, 0)
        vArrayDatosComboBox(56).Ancho = 485
        vArrayDatosComboBox(56).Flag = False

        vArrayDatosComboBox(57).NombreCampo = "MON_ID_DOC"
        vArrayDatosComboBox(57).Longitud = 3
        vArrayDatosComboBox(57).Tipo = "char"
        vArrayDatosComboBox(57).ParteEntera = 0
        vArrayDatosComboBox(57).ParteDecimal = 0
        ReDim vArrayDatosComboBox(57).Valores(0, 0)
        vArrayDatosComboBox(57).Ancho = 36
        vArrayDatosComboBox(57).Flag = False

        vArrayDatosComboBox(58).NombreCampo = "MON_DESCRIPCION_DOC"
        vArrayDatosComboBox(58).Longitud = 45
        vArrayDatosComboBox(58).Tipo = "varchar"
        vArrayDatosComboBox(58).ParteEntera = 0
        vArrayDatosComboBox(58).ParteDecimal = 0
        ReDim vArrayDatosComboBox(58).Valores(0, 0)
        vArrayDatosComboBox(58).Ancho = 485
        vArrayDatosComboBox(58).Flag = False

        vArrayDatosComboBox(59).NombreCampo = "DES_SERIE_DOC"
        vArrayDatosComboBox(59).Longitud = 3
        vArrayDatosComboBox(59).Tipo = "char"
        vArrayDatosComboBox(59).ParteEntera = 0
        vArrayDatosComboBox(59).ParteDecimal = 0
        ReDim vArrayDatosComboBox(59).Valores(0, 0)
        vArrayDatosComboBox(59).Ancho = 36
        vArrayDatosComboBox(59).Flag = False

        vArrayDatosComboBox(60).NombreCampo = "DES_NUMERO_DOC"
        vArrayDatosComboBox(60).Longitud = 10
        vArrayDatosComboBox(60).Tipo = "char"
        vArrayDatosComboBox(60).ParteEntera = 0
        vArrayDatosComboBox(60).ParteDecimal = 0
        ReDim vArrayDatosComboBox(60).Valores(0, 0)
        vArrayDatosComboBox(60).Ancho = 111
        vArrayDatosComboBox(60).Flag = False

        vArrayDatosComboBox(61).NombreCampo = "PER_ID_REC"
        vArrayDatosComboBox(61).Longitud = 6
        vArrayDatosComboBox(61).Tipo = "char"
        vArrayDatosComboBox(61).ParteEntera = 0
        vArrayDatosComboBox(61).ParteDecimal = 0
        ReDim vArrayDatosComboBox(61).Valores(0, 0)
        vArrayDatosComboBox(61).Ancho = 68
        vArrayDatosComboBox(61).Flag = False

        vArrayDatosComboBox(62).NombreCampo = "PER_DESCRIPCION_REC"
        vArrayDatosComboBox(62).Longitud = 77
        vArrayDatosComboBox(62).Tipo = "varchar"
        vArrayDatosComboBox(62).ParteEntera = 0
        vArrayDatosComboBox(62).ParteDecimal = 0
        ReDim vArrayDatosComboBox(62).Valores(0, 0)
        vArrayDatosComboBox(62).Ancho = 828
        vArrayDatosComboBox(62).Flag = False

        vArrayDatosComboBox(63).NombreCampo = "TDP_ID_REC"
        vArrayDatosComboBox(63).Longitud = 2
        vArrayDatosComboBox(63).Tipo = "char"
        vArrayDatosComboBox(63).ParteEntera = 0
        vArrayDatosComboBox(63).ParteDecimal = 0
        ReDim vArrayDatosComboBox(63).Valores(0, 0)
        vArrayDatosComboBox(63).Ancho = 26
        vArrayDatosComboBox(63).Flag = False

        vArrayDatosComboBox(64).NombreCampo = "TDP_DESCRIPCION_REC"
        vArrayDatosComboBox(64).Longitud = 45
        vArrayDatosComboBox(64).Tipo = "varchar"
        vArrayDatosComboBox(64).ParteEntera = 0
        vArrayDatosComboBox(64).ParteDecimal = 0
        ReDim vArrayDatosComboBox(64).Valores(0, 0)
        vArrayDatosComboBox(64).Ancho = 485
        vArrayDatosComboBox(64).Flag = False

        vArrayDatosComboBox(65).NombreCampo = "DOP_NUMERO_REC"
        vArrayDatosComboBox(65).Longitud = 25
        vArrayDatosComboBox(65).Tipo = "varchar"
        vArrayDatosComboBox(65).ParteEntera = 0
        vArrayDatosComboBox(65).ParteDecimal = 0
        ReDim vArrayDatosComboBox(65).Valores(0, 0)
        vArrayDatosComboBox(65).Ancho = 272
        vArrayDatosComboBox(65).Flag = False

        vArrayDatosComboBox(66).NombreCampo = "DIR_ID_ENT_REC"
        vArrayDatosComboBox(66).Longitud = 8
        vArrayDatosComboBox(66).Tipo = "char"
        vArrayDatosComboBox(66).ParteEntera = 0
        vArrayDatosComboBox(66).ParteDecimal = 0
        ReDim vArrayDatosComboBox(66).Valores(0, 0)
        vArrayDatosComboBox(66).Ancho = 96
        vArrayDatosComboBox(66).Flag = False

        vArrayDatosComboBox(67).NombreCampo = "DIR_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(67).Longitud = 65
        vArrayDatosComboBox(67).Tipo = "varchar"
        vArrayDatosComboBox(67).ParteEntera = 0
        vArrayDatosComboBox(67).ParteDecimal = 0
        ReDim vArrayDatosComboBox(67).Valores(0, 0)
        vArrayDatosComboBox(67).Ancho = 699
        vArrayDatosComboBox(67).Flag = False

        vArrayDatosComboBox(68).NombreCampo = "DIR_TIPO_ENT_REC"
        vArrayDatosComboBox(68).Longitud = 9
        vArrayDatosComboBox(68).Tipo = "varchar"
        vArrayDatosComboBox(68).ParteEntera = 0
        vArrayDatosComboBox(68).ParteDecimal = 0
        ReDim vArrayDatosComboBox(68).Valores(0, 0)
        vArrayDatosComboBox(68).Ancho = 100
        vArrayDatosComboBox(68).Flag = False

        vArrayDatosComboBox(69).NombreCampo = "DIR_REFERENCIA_ENT_REC"
        vArrayDatosComboBox(69).Longitud = 65
        vArrayDatosComboBox(69).Tipo = "varchar"
        vArrayDatosComboBox(69).ParteEntera = 0
        vArrayDatosComboBox(69).ParteDecimal = 0
        ReDim vArrayDatosComboBox(69).Valores(0, 0)
        vArrayDatosComboBox(69).Ancho = 699
        vArrayDatosComboBox(69).Flag = False

        vArrayDatosComboBox(70).NombreCampo = "DIS_ID_ENT_REC"
        vArrayDatosComboBox(70).Longitud = 3
        vArrayDatosComboBox(70).Tipo = "char"
        vArrayDatosComboBox(70).ParteEntera = 0
        vArrayDatosComboBox(70).ParteDecimal = 0
        ReDim vArrayDatosComboBox(70).Valores(0, 0)
        vArrayDatosComboBox(70).Ancho = 36
        vArrayDatosComboBox(70).Flag = False

        vArrayDatosComboBox(71).NombreCampo = "DIS_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(71).Longitud = 45
        vArrayDatosComboBox(71).Tipo = "varchar"
        vArrayDatosComboBox(71).ParteEntera = 0
        vArrayDatosComboBox(71).ParteDecimal = 0
        ReDim vArrayDatosComboBox(71).Valores(0, 0)
        vArrayDatosComboBox(71).Ancho = 485
        vArrayDatosComboBox(71).Flag = False

        vArrayDatosComboBox(72).NombreCampo = "PRO_ID_ENT_REC"
        vArrayDatosComboBox(72).Longitud = 3
        vArrayDatosComboBox(72).Tipo = "char"
        vArrayDatosComboBox(72).ParteEntera = 0
        vArrayDatosComboBox(72).ParteDecimal = 0
        ReDim vArrayDatosComboBox(72).Valores(0, 0)
        vArrayDatosComboBox(72).Ancho = 36
        vArrayDatosComboBox(72).Flag = False

        vArrayDatosComboBox(73).NombreCampo = "PRO_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(73).Longitud = 45
        vArrayDatosComboBox(73).Tipo = "varchar"
        vArrayDatosComboBox(73).ParteEntera = 0
        vArrayDatosComboBox(73).ParteDecimal = 0
        ReDim vArrayDatosComboBox(73).Valores(0, 0)
        vArrayDatosComboBox(73).Ancho = 485
        vArrayDatosComboBox(73).Flag = False

        vArrayDatosComboBox(74).NombreCampo = "DEP_ID_ENT_REC"
        vArrayDatosComboBox(74).Longitud = 3
        vArrayDatosComboBox(74).Tipo = "char"
        vArrayDatosComboBox(74).ParteEntera = 0
        vArrayDatosComboBox(74).ParteDecimal = 0
        ReDim vArrayDatosComboBox(74).Valores(0, 0)
        vArrayDatosComboBox(74).Ancho = 36
        vArrayDatosComboBox(74).Flag = False

        vArrayDatosComboBox(75).NombreCampo = "DEP_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(75).Longitud = 45
        vArrayDatosComboBox(75).Tipo = "varchar"
        vArrayDatosComboBox(75).ParteEntera = 0
        vArrayDatosComboBox(75).ParteDecimal = 0
        ReDim vArrayDatosComboBox(75).Valores(0, 0)
        vArrayDatosComboBox(75).Ancho = 485
        vArrayDatosComboBox(75).Flag = False

        vArrayDatosComboBox(76).NombreCampo = "PAI_ID_ENT_REC"
        vArrayDatosComboBox(76).Longitud = 3
        vArrayDatosComboBox(76).Tipo = "char"
        vArrayDatosComboBox(76).ParteEntera = 0
        vArrayDatosComboBox(76).ParteDecimal = 0
        ReDim vArrayDatosComboBox(76).Valores(0, 0)
        vArrayDatosComboBox(76).Ancho = 36
        vArrayDatosComboBox(76).Flag = False

        vArrayDatosComboBox(77).NombreCampo = "PAI_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(77).Longitud = 45
        vArrayDatosComboBox(77).Tipo = "varchar"
        vArrayDatosComboBox(77).ParteEntera = 0
        vArrayDatosComboBox(77).ParteDecimal = 0
        ReDim vArrayDatosComboBox(77).Valores(0, 0)
        vArrayDatosComboBox(77).Ancho = 485
        vArrayDatosComboBox(77).Flag = False

        vArrayDatosComboBox(78).NombreCampo = "DIR_ESTADO_ENT_REC"
        vArrayDatosComboBox(78).Longitud = 9
        vArrayDatosComboBox(78).Tipo = "varchar"
        vArrayDatosComboBox(78).ParteEntera = 0
        vArrayDatosComboBox(78).ParteDecimal = 0
        ReDim vArrayDatosComboBox(78).Valores(0, 0)
        vArrayDatosComboBox(78).Ancho = 100
        vArrayDatosComboBox(78).Flag = False

        vArrayDatosComboBox(79).NombreCampo = "DIR_ID_ENT"
        vArrayDatosComboBox(79).Longitud = 8
        vArrayDatosComboBox(79).Tipo = "char"
        vArrayDatosComboBox(79).ParteEntera = 0
        vArrayDatosComboBox(79).ParteDecimal = 0
        ReDim vArrayDatosComboBox(79).Valores(0, 0)
        vArrayDatosComboBox(79).Ancho = 96
        vArrayDatosComboBox(79).Flag = False

        vArrayDatosComboBox(80).NombreCampo = "DIR_DESCRIPCION_ENT"
        vArrayDatosComboBox(80).Longitud = 65
        vArrayDatosComboBox(80).Tipo = "varchar"
        vArrayDatosComboBox(80).ParteEntera = 0
        vArrayDatosComboBox(80).ParteDecimal = 0
        ReDim vArrayDatosComboBox(80).Valores(0, 0)
        vArrayDatosComboBox(80).Ancho = 699
        vArrayDatosComboBox(80).Flag = False

        vArrayDatosComboBox(81).NombreCampo = "DIS_ID_ENT"
        vArrayDatosComboBox(81).Longitud = 3
        vArrayDatosComboBox(81).Tipo = "char"
        vArrayDatosComboBox(81).ParteEntera = 0
        vArrayDatosComboBox(81).ParteDecimal = 0
        ReDim vArrayDatosComboBox(81).Valores(0, 0)
        vArrayDatosComboBox(81).Ancho = 36
        vArrayDatosComboBox(81).Flag = False

        vArrayDatosComboBox(82).NombreCampo = "DIS_DESCRIPCION_ENT"
        vArrayDatosComboBox(82).Longitud = 45
        vArrayDatosComboBox(82).Tipo = "varchar"
        vArrayDatosComboBox(82).ParteEntera = 0
        vArrayDatosComboBox(82).ParteDecimal = 0
        ReDim vArrayDatosComboBox(82).Valores(0, 0)
        vArrayDatosComboBox(82).Ancho = 485
        vArrayDatosComboBox(82).Flag = False

        vArrayDatosComboBox(83).NombreCampo = "DIS_ESTADO_ENT"
        vArrayDatosComboBox(83).Longitud = 9
        vArrayDatosComboBox(83).Tipo = "varchar"
        vArrayDatosComboBox(83).ParteEntera = 0
        vArrayDatosComboBox(83).ParteDecimal = 0
        ReDim vArrayDatosComboBox(83).Valores(0, 0)
        vArrayDatosComboBox(83).Ancho = 100
        vArrayDatosComboBox(83).Flag = False

        vArrayDatosComboBox(84).NombreCampo = "PRO_ID_ENT"
        vArrayDatosComboBox(84).Longitud = 3
        vArrayDatosComboBox(84).Tipo = "char"
        vArrayDatosComboBox(84).ParteEntera = 0
        vArrayDatosComboBox(84).ParteDecimal = 0
        ReDim vArrayDatosComboBox(84).Valores(0, 0)
        vArrayDatosComboBox(84).Ancho = 36
        vArrayDatosComboBox(84).Flag = False

        vArrayDatosComboBox(85).NombreCampo = "PRO_DESCRIPCION_ENT"
        vArrayDatosComboBox(85).Longitud = 45
        vArrayDatosComboBox(85).Tipo = "varchar"
        vArrayDatosComboBox(85).ParteEntera = 0
        vArrayDatosComboBox(85).ParteDecimal = 0
        ReDim vArrayDatosComboBox(85).Valores(0, 0)
        vArrayDatosComboBox(85).Ancho = 485
        vArrayDatosComboBox(85).Flag = False

        vArrayDatosComboBox(86).NombreCampo = "PRO_ESTADO_ENT"
        vArrayDatosComboBox(86).Longitud = 9
        vArrayDatosComboBox(86).Tipo = "varchar"
        vArrayDatosComboBox(86).ParteEntera = 0
        vArrayDatosComboBox(86).ParteDecimal = 0
        ReDim vArrayDatosComboBox(86).Valores(0, 0)
        vArrayDatosComboBox(86).Ancho = 100
        vArrayDatosComboBox(86).Flag = False

        vArrayDatosComboBox(87).NombreCampo = "DEP_ID_ENT"
        vArrayDatosComboBox(87).Longitud = 3
        vArrayDatosComboBox(87).Tipo = "char"
        vArrayDatosComboBox(87).ParteEntera = 0
        vArrayDatosComboBox(87).ParteDecimal = 0
        ReDim vArrayDatosComboBox(87).Valores(0, 0)
        vArrayDatosComboBox(87).Ancho = 36
        vArrayDatosComboBox(87).Flag = False

        vArrayDatosComboBox(88).NombreCampo = "DEP_DESCRIPCION_ENT"
        vArrayDatosComboBox(88).Longitud = 45
        vArrayDatosComboBox(88).Tipo = "varchar"
        vArrayDatosComboBox(88).ParteEntera = 0
        vArrayDatosComboBox(88).ParteDecimal = 0
        ReDim vArrayDatosComboBox(88).Valores(0, 0)
        vArrayDatosComboBox(88).Ancho = 485
        vArrayDatosComboBox(88).Flag = False

        vArrayDatosComboBox(89).NombreCampo = "DEP_ESTADO_ENT"
        vArrayDatosComboBox(89).Longitud = 9
        vArrayDatosComboBox(89).Tipo = "varchar"
        vArrayDatosComboBox(89).ParteEntera = 0
        vArrayDatosComboBox(89).ParteDecimal = 0
        ReDim vArrayDatosComboBox(89).Valores(0, 0)
        vArrayDatosComboBox(89).Ancho = 100
        vArrayDatosComboBox(89).Flag = False

        vArrayDatosComboBox(90).NombreCampo = "PAI_ID_ENT"
        vArrayDatosComboBox(90).Longitud = 3
        vArrayDatosComboBox(90).Tipo = "char"
        vArrayDatosComboBox(90).ParteEntera = 0
        vArrayDatosComboBox(90).ParteDecimal = 0
        ReDim vArrayDatosComboBox(90).Valores(0, 0)
        vArrayDatosComboBox(90).Ancho = 36
        vArrayDatosComboBox(90).Flag = False

        vArrayDatosComboBox(91).NombreCampo = "PAI_DESCRIPCION_ENT"
        vArrayDatosComboBox(91).Longitud = 45
        vArrayDatosComboBox(91).Tipo = "varchar"
        vArrayDatosComboBox(91).ParteEntera = 0
        vArrayDatosComboBox(91).ParteDecimal = 0
        ReDim vArrayDatosComboBox(91).Valores(0, 0)
        vArrayDatosComboBox(91).Ancho = 485
        vArrayDatosComboBox(91).Flag = False

        vArrayDatosComboBox(92).NombreCampo = "PAIS_ESTADO_ENT"
        vArrayDatosComboBox(92).Longitud = 9
        vArrayDatosComboBox(92).Tipo = "varchar"
        vArrayDatosComboBox(92).ParteEntera = 0
        vArrayDatosComboBox(92).ParteDecimal = 0
        ReDim vArrayDatosComboBox(92).Valores(0, 0)
        vArrayDatosComboBox(92).Ancho = 100
        vArrayDatosComboBox(92).Flag = False

        vArrayDatosComboBox(93).NombreCampo = "DIR_REFERENCIA_ENT"
        vArrayDatosComboBox(93).Longitud = 65
        vArrayDatosComboBox(93).Tipo = "varchar"
        vArrayDatosComboBox(93).ParteEntera = 0
        vArrayDatosComboBox(93).ParteDecimal = 0
        ReDim vArrayDatosComboBox(93).Valores(0, 0)
        vArrayDatosComboBox(93).Ancho = 699
        vArrayDatosComboBox(93).Flag = False

        vArrayDatosComboBox(94).NombreCampo = "FLE_ID"
        vArrayDatosComboBox(94).Longitud = 3
        vArrayDatosComboBox(94).Tipo = "char"
        vArrayDatosComboBox(94).ParteEntera = 0
        vArrayDatosComboBox(94).ParteDecimal = 0
        ReDim vArrayDatosComboBox(94).Valores(0, 0)
        vArrayDatosComboBox(94).Ancho = 36
        vArrayDatosComboBox(94).Flag = False

        vArrayDatosComboBox(95).NombreCampo = "FLE_DESCRIPCION"
        vArrayDatosComboBox(95).Longitud = 45
        vArrayDatosComboBox(95).Tipo = "varchar"
        vArrayDatosComboBox(95).ParteEntera = 0
        vArrayDatosComboBox(95).ParteDecimal = 0
        ReDim vArrayDatosComboBox(95).Valores(0, 0)
        vArrayDatosComboBox(95).Ancho = 485
        vArrayDatosComboBox(95).Flag = False

        vArrayDatosComboBox(96).NombreCampo = "FLE_TIPO"
        vArrayDatosComboBox(96).Longitud = 18
        vArrayDatosComboBox(96).Tipo = "varchar"
        vArrayDatosComboBox(96).ParteEntera = 0
        vArrayDatosComboBox(96).ParteDecimal = 0
        ReDim vArrayDatosComboBox(96).Valores(1, 1)
        vArrayDatosComboBox(96).Valores(0, 0) = "TRANSPORTE EMPRESA"
        vArrayDatosComboBox(96).Valores(0, 1) = "0"
        vArrayDatosComboBox(96).Valores(1, 0) = "TRANSPORTE CLIENTE"
        vArrayDatosComboBox(96).Valores(1, 1) = "1"
        vArrayDatosComboBox(96).Ancho = 159
        vArrayDatosComboBox(96).Flag = True

        vArrayDatosComboBox(97).NombreCampo = "FLE_ESTADO"
        vArrayDatosComboBox(97).Longitud = 9
        vArrayDatosComboBox(97).Tipo = "varchar"
        vArrayDatosComboBox(97).ParteEntera = 0
        vArrayDatosComboBox(97).ParteDecimal = 0
        ReDim vArrayDatosComboBox(97).Valores(1, 1)
        vArrayDatosComboBox(97).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(97).Valores(0, 1) = "0"
        vArrayDatosComboBox(97).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(97).Valores(1, 1) = "1"
        vArrayDatosComboBox(97).Ancho = 85
        vArrayDatosComboBox(97).Flag = True

        vArrayDatosComboBox(98).NombreCampo = "MON_ID"
        vArrayDatosComboBox(98).Longitud = 3
        vArrayDatosComboBox(98).Tipo = "char"
        vArrayDatosComboBox(98).ParteEntera = 0
        vArrayDatosComboBox(98).ParteDecimal = 0
        ReDim vArrayDatosComboBox(98).Valores(0, 0)
        vArrayDatosComboBox(98).Ancho = 36
        vArrayDatosComboBox(98).Flag = False

        vArrayDatosComboBox(99).NombreCampo = "MON_DESCRIPCION"
        vArrayDatosComboBox(99).Longitud = 45
        vArrayDatosComboBox(99).Tipo = "varchar"
        vArrayDatosComboBox(99).ParteEntera = 0
        vArrayDatosComboBox(99).ParteDecimal = 0
        ReDim vArrayDatosComboBox(99).Valores(0, 0)
        vArrayDatosComboBox(99).Ancho = 485
        vArrayDatosComboBox(99).Flag = False

        vArrayDatosComboBox(100).NombreCampo = "DES_MONTO_FLETE"
        vArrayDatosComboBox(100).Longitud = 18
        vArrayDatosComboBox(100).Tipo = "numeric"
        vArrayDatosComboBox(100).ParteEntera = 14
        vArrayDatosComboBox(100).ParteDecimal = 4
        ReDim vArrayDatosComboBox(100).Valores(0, 0)
        vArrayDatosComboBox(100).Ancho = 197
        vArrayDatosComboBox(100).Flag = False

        vArrayDatosComboBox(101).NombreCampo = "DES_CONTRAVALOR"
        vArrayDatosComboBox(101).Longitud = 18
        vArrayDatosComboBox(101).Tipo = "numeric"
        vArrayDatosComboBox(101).ParteEntera = 14
        vArrayDatosComboBox(101).ParteDecimal = 4
        ReDim vArrayDatosComboBox(101).Valores(0, 0)
        vArrayDatosComboBox(101).Ancho = 197
        vArrayDatosComboBox(101).Flag = False

        vArrayDatosComboBox(102).NombreCampo = "PLA_ID"
        vArrayDatosComboBox(102).Longitud = 3
        vArrayDatosComboBox(102).Tipo = "char"
        vArrayDatosComboBox(102).ParteEntera = 0
        vArrayDatosComboBox(102).ParteDecimal = 0
        ReDim vArrayDatosComboBox(102).Valores(0, 0)
        vArrayDatosComboBox(102).Ancho = 36
        vArrayDatosComboBox(102).Flag = False

        vArrayDatosComboBox(103).NombreCampo = "PER_ID_TRA1"
        vArrayDatosComboBox(103).Longitud = 6
        vArrayDatosComboBox(103).Tipo = "char"
        vArrayDatosComboBox(103).ParteEntera = 0
        vArrayDatosComboBox(103).ParteDecimal = 0
        ReDim vArrayDatosComboBox(103).Valores(0, 0)
        vArrayDatosComboBox(103).Ancho = 68
        vArrayDatosComboBox(103).Flag = False

        vArrayDatosComboBox(104).NombreCampo = "PER_DESCRIPCION_TRA1"
        vArrayDatosComboBox(104).Longitud = 77
        vArrayDatosComboBox(104).Tipo = "varchar"
        vArrayDatosComboBox(104).ParteEntera = 0
        vArrayDatosComboBox(104).ParteDecimal = 0
        ReDim vArrayDatosComboBox(104).Valores(0, 0)
        vArrayDatosComboBox(104).Ancho = 828
        vArrayDatosComboBox(104).Flag = False

        vArrayDatosComboBox(105).NombreCampo = "RUC_TRA1"
        vArrayDatosComboBox(105).Longitud = 25
        vArrayDatosComboBox(105).Tipo = "varchar"
        vArrayDatosComboBox(105).ParteEntera = 0
        vArrayDatosComboBox(105).ParteDecimal = 0
        ReDim vArrayDatosComboBox(105).Valores(0, 0)
        vArrayDatosComboBox(105).Ancho = 272
        vArrayDatosComboBox(105).Flag = False

        vArrayDatosComboBox(106).NombreCampo = "PER_ESTADO_TRA1"
        vArrayDatosComboBox(106).Longitud = 9
        vArrayDatosComboBox(106).Tipo = "varchar"
        vArrayDatosComboBox(106).ParteEntera = 0
        vArrayDatosComboBox(106).ParteDecimal = 0
        ReDim vArrayDatosComboBox(106).Valores(1, 1)
        vArrayDatosComboBox(106).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(106).Valores(0, 1) = "0"
        vArrayDatosComboBox(106).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(106).Valores(1, 1) = "1"
        vArrayDatosComboBox(106).Ancho = 85
        vArrayDatosComboBox(106).Flag = True

        vArrayDatosComboBox(107).NombreCampo = "UNT_ID_1"
        vArrayDatosComboBox(107).Longitud = 10
        vArrayDatosComboBox(107).Tipo = "char"
        vArrayDatosComboBox(107).ParteEntera = 0
        vArrayDatosComboBox(107).ParteDecimal = 0
        ReDim vArrayDatosComboBox(107).Valores(0, 0)
        vArrayDatosComboBox(107).Ancho = 111
        vArrayDatosComboBox(107).Flag = False

        vArrayDatosComboBox(108).NombreCampo = "MAR_DESCRIPCION_TRA1"
        vArrayDatosComboBox(108).Longitud = 45
        vArrayDatosComboBox(108).Tipo = "varchar"
        vArrayDatosComboBox(108).ParteEntera = 0
        vArrayDatosComboBox(108).ParteDecimal = 0
        ReDim vArrayDatosComboBox(108).Valores(0, 0)
        vArrayDatosComboBox(108).Ancho = 485
        vArrayDatosComboBox(108).Flag = False

        vArrayDatosComboBox(109).NombreCampo = "MOD_DESCRIPCION_TRA1"
        vArrayDatosComboBox(109).Longitud = 45
        vArrayDatosComboBox(109).Tipo = "varchar"
        vArrayDatosComboBox(109).ParteEntera = 0
        vArrayDatosComboBox(109).ParteDecimal = 0
        ReDim vArrayDatosComboBox(109).Valores(0, 0)
        vArrayDatosComboBox(109).Ancho = 485
        vArrayDatosComboBox(109).Flag = False

        vArrayDatosComboBox(110).NombreCampo = "UNT_NRO_INS_TRA1"
        vArrayDatosComboBox(110).Longitud = 25
        vArrayDatosComboBox(110).Tipo = "varchar"
        vArrayDatosComboBox(110).ParteEntera = 0
        vArrayDatosComboBox(110).ParteDecimal = 0
        ReDim vArrayDatosComboBox(110).Valores(0, 0)
        vArrayDatosComboBox(110).Ancho = 272
        vArrayDatosComboBox(110).Flag = False

        vArrayDatosComboBox(111).NombreCampo = "UNT_ID_2"
        vArrayDatosComboBox(111).Longitud = 10
        vArrayDatosComboBox(111).Tipo = "char"
        vArrayDatosComboBox(111).ParteEntera = 0
        vArrayDatosComboBox(111).ParteDecimal = 0
        ReDim vArrayDatosComboBox(111).Valores(0, 0)
        vArrayDatosComboBox(111).Ancho = 111
        vArrayDatosComboBox(111).Flag = False

        vArrayDatosComboBox(112).NombreCampo = "MAR_DESCRIPCION_TRA2"
        vArrayDatosComboBox(112).Longitud = 45
        vArrayDatosComboBox(112).Tipo = "varchar"
        vArrayDatosComboBox(112).ParteEntera = 0
        vArrayDatosComboBox(112).ParteDecimal = 0
        ReDim vArrayDatosComboBox(112).Valores(0, 0)
        vArrayDatosComboBox(112).Ancho = 485
        vArrayDatosComboBox(112).Flag = False

        vArrayDatosComboBox(113).NombreCampo = "MOD_DESCRIPCION_TRA2"
        vArrayDatosComboBox(113).Longitud = 45
        vArrayDatosComboBox(113).Tipo = "varchar"
        vArrayDatosComboBox(113).ParteEntera = 0
        vArrayDatosComboBox(113).ParteDecimal = 0
        ReDim vArrayDatosComboBox(113).Valores(0, 0)
        vArrayDatosComboBox(113).Ancho = 485
        vArrayDatosComboBox(113).Flag = False

        vArrayDatosComboBox(114).NombreCampo = "UNT_NRO_INS_TRA2"
        vArrayDatosComboBox(114).Longitud = 25
        vArrayDatosComboBox(114).Tipo = "varchar"
        vArrayDatosComboBox(114).ParteEntera = 0
        vArrayDatosComboBox(114).ParteDecimal = 0
        ReDim vArrayDatosComboBox(114).Valores(0, 0)
        vArrayDatosComboBox(114).Ancho = 272
        vArrayDatosComboBox(114).Flag = False

        vArrayDatosComboBox(115).NombreCampo = "PER_ID_CHO"
        vArrayDatosComboBox(115).Longitud = 6
        vArrayDatosComboBox(115).Tipo = "char"
        vArrayDatosComboBox(115).ParteEntera = 0
        vArrayDatosComboBox(115).ParteDecimal = 0
        ReDim vArrayDatosComboBox(115).Valores(0, 0)
        vArrayDatosComboBox(115).Ancho = 68
        vArrayDatosComboBox(115).Flag = False

        vArrayDatosComboBox(116).NombreCampo = "PER_DESCRIPCION_CHO"
        vArrayDatosComboBox(116).Longitud = 77
        vArrayDatosComboBox(116).Tipo = "varchar"
        vArrayDatosComboBox(116).ParteEntera = 0
        vArrayDatosComboBox(116).ParteDecimal = 0
        ReDim vArrayDatosComboBox(116).Valores(0, 0)
        vArrayDatosComboBox(116).Ancho = 828
        vArrayDatosComboBox(116).Flag = False

        vArrayDatosComboBox(117).NombreCampo = "PER_BREVETE_CHO"
        vArrayDatosComboBox(117).Longitud = 9
        vArrayDatosComboBox(117).Tipo = "char"
        vArrayDatosComboBox(117).ParteEntera = 0
        vArrayDatosComboBox(117).ParteDecimal = 0
        ReDim vArrayDatosComboBox(117).Valores(0, 0)
        vArrayDatosComboBox(117).Ancho = 100
        vArrayDatosComboBox(117).Flag = False

        vArrayDatosComboBox(118).NombreCampo = "PER_ESTADO_CHO"
        vArrayDatosComboBox(118).Longitud = 9
        vArrayDatosComboBox(118).Tipo = "varchar"
        vArrayDatosComboBox(118).ParteEntera = 0
        vArrayDatosComboBox(118).ParteDecimal = 0
        ReDim vArrayDatosComboBox(118).Valores(1, 1)
        vArrayDatosComboBox(118).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(118).Valores(0, 1) = "0"
        vArrayDatosComboBox(118).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(118).Valores(1, 1) = "1"
        vArrayDatosComboBox(118).Ancho = 85
        vArrayDatosComboBox(118).Flag = True

        vArrayDatosComboBox(119).NombreCampo = "DES_TIPO_GUIA"
        vArrayDatosComboBox(119).Longitud = 5
        vArrayDatosComboBox(119).Tipo = "smallint"
        vArrayDatosComboBox(119).ParteEntera = 5
        vArrayDatosComboBox(119).ParteDecimal = 0
        ReDim vArrayDatosComboBox(119).Valores(12, 1)
        vArrayDatosComboBox(119).Valores(0, 0) = "VENTA"
        vArrayDatosComboBox(119).Valores(0, 1) = "1"
        vArrayDatosComboBox(119).Valores(1, 0) = "VENTA SUJETA A CONFIRMACION DEL COMPRADOR"
        vArrayDatosComboBox(119).Valores(1, 1) = "2"
        vArrayDatosComboBox(119).Valores(2, 0) = "COMPRA"
        vArrayDatosComboBox(119).Valores(2, 1) = "3"
        vArrayDatosComboBox(119).Valores(3, 0) = "CONSIGNACION"
        vArrayDatosComboBox(119).Valores(3, 1) = "4"
        vArrayDatosComboBox(119).Valores(4, 0) = "DEVOLUCION"
        vArrayDatosComboBox(119).Valores(4, 1) = "5"
        vArrayDatosComboBox(119).Valores(5, 0) = "TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA"
        vArrayDatosComboBox(119).Valores(5, 1) = "6"
        vArrayDatosComboBox(119).Valores(6, 0) = "TRASLADO DE BIENES PARA TRANSFORMACION"
        vArrayDatosComboBox(119).Valores(6, 1) = "7"
        vArrayDatosComboBox(119).Valores(7, 0) = "RECOJO DE BIENES TRANSFORMADOS"
        vArrayDatosComboBox(119).Valores(7, 1) = "8"
        vArrayDatosComboBox(119).Valores(8, 0) = "TRASLADO POR EMISOR ITINERANTE DE COMPROBANTE DE PAGO"
        vArrayDatosComboBox(119).Valores(8, 1) = "9"
        vArrayDatosComboBox(119).Valores(9, 0) = "TRASLADO ZONA PRIMARIA"
        vArrayDatosComboBox(119).Valores(9, 1) = "10"
        vArrayDatosComboBox(119).Valores(10, 0) = "IMPORTACION"
        vArrayDatosComboBox(119).Valores(10, 1) = "11"
        vArrayDatosComboBox(119).Valores(11, 0) = "EXPORTACION"
        vArrayDatosComboBox(119).Valores(11, 1) = "12"
        vArrayDatosComboBox(119).Valores(12, 0) = "OTROS"
        vArrayDatosComboBox(119).Valores(12, 1) = "13"

        vArrayDatosComboBox(119).Ancho = 170
        vArrayDatosComboBox(119).Flag = True


        vArrayDatosComboBox(120).NombreCampo = "DES_ESTADO"
        vArrayDatosComboBox(120).Longitud = 5
        vArrayDatosComboBox(120).Tipo = "smallint"
        vArrayDatosComboBox(120).ParteEntera = 5
        vArrayDatosComboBox(120).ParteDecimal = 0
        ReDim vArrayDatosComboBox(120).Valores(3, 1)
        vArrayDatosComboBox(120).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(120).Valores(0, 1) = "0"
        vArrayDatosComboBox(120).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(120).Valores(1, 1) = "1"
        vArrayDatosComboBox(120).Valores(2, 0) = "POR PROCESAR"
        vArrayDatosComboBox(120).Valores(2, 1) = "2"
        vArrayDatosComboBox(120).Valores(3, 0) = "PROCESADO"
        vArrayDatosComboBox(120).Valores(3, 1) = "3"
        vArrayDatosComboBox(120).Ancho = 85
        vArrayDatosComboBox(120).Flag = True
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

                Case "CCT_ID"
                    If Len(CCT_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DES_FEC_EMI"
                    If DES_FEC_EMI.GetType = GetType(Date) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DES_FEC_TRA"
                    If DES_FEC_TRA.GetType = GetType(Date) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PVE_ID"
                    If Len(PVE_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "ALM_ID"
                    If ALM_ID.GetType = GetType(Int32) And
                        ALM_ID > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DES_SERIE"
                    If Len(DES_SERIE.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DES_NUMERO"
                    If Len(DES_NUMERO.Trim) = 10 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo10
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TDO_ID_DOC"
                    If IsNothing(TDO_ID_DOC) Then
                    Else
                        If Len(TDO_ID_DOC.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTD_ID_DOC"
                    If IsNothing(DTD_ID_DOC) Then
                    Else
                        If Len(DTD_ID_DOC.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DES_SERIE_DOC"
                    If IsNothing(DES_SERIE_DOC) Then
                    Else
                        If Len(DES_SERIE_DOC.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DES_NUMERO_DOC"
                    If IsNothing(DES_NUMERO_DOC) Then
                    Else
                        If Len(DES_NUMERO_DOC.Trim) = 10 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo10
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "PER_ID_REC"
                    If IsNothing(PER_ID_REC) Then
                    Else
                        If Len(PER_ID_REC.Trim) = 6 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo6
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "TDP_ID_REC"
                    If IsNothing(TDP_ID_REC) Then
                    Else
                        If Len(TDP_ID_REC.Trim) = 2 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo2
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DIR_ID_ENT_REC"
                    If IsNothing(DIR_ID_ENT_REC) Then
                    Else
                        If Len(DIR_ID_ENT_REC.Trim) = 8 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo8
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DIR_ID_ENT"
                    If IsNothing(DIR_ID_ENT) Then
                    Else
                        If Len(DIR_ID_ENT.Trim) = 8 Or Len(DIR_ID_ENT.Trim) = 0 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo8
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "PLA_ID"
                    If Len(PLA_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "FLE_ID"
                    If IsNothing(FLE_ID) Then
                    Else
                        If Len(FLE_ID.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "MON_ID"
                    If IsNothing(MON_ID) Then
                    Else
                        If Len(MON_ID.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DES_MONTO_FLETE"
                    If DES_MONTO_FLETE.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DES_CONTRAVALOR"
                    If DES_CONTRAVALOR.GetType = GetType(Decimal) Then
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

                Case "DES_FEC_GRAB"
                    If DES_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DES_TIPO_GUIA"
                    If DES_ESTADO >= 1 And DES_ESTADO <= 13 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DES_ESTADO"
                    If DES_ESTADO >= 0 And DES_ESTADO <= 3 Then
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
        If Vista = "BuscarCronograma" Then
            SentenciaSqlBusqueda = "spVistaDetallePedidoDespachosXML"
        End If
        If Vista = "BuscarCronogramaDistribuidora" Then
            SentenciaSqlBusqueda = "spVistaDetallePedidoDespachosDistribuidoraXML"
        End If
        If Vista = "BuscarRegistros" Then
            SentenciaSqlBusqueda = "spVistaDespachosXML"
        End If
        If Vista = "BuscarRegistrosDocumentoDesdeDistribuidora" Then
            SentenciaSqlBusqueda = "spVistaDespachosDocumentoDesdeDistribuidoraXML"
        End If
        If Vista = "BuscarRegistrosDesdeDistribuidora" Then
            SentenciaSqlBusqueda = "spVistaDespachosDesdeDistribuidoraXML"
        End If
        If Vista = "BuscarRegistrosParaControl" Then
            SentenciaSqlBusqueda = "spVistaDespachosParaControlXML"
        End If
        If Vista = "BuscarRegistrosParaCarguio" Then
            SentenciaSqlBusqueda = "spVistaDespachosParaCarguioXML"
        End If
        If Vista = "BuscarRegistrosParaHabilitarCronograma" Then
            SentenciaSqlBusqueda = "spVistaDespachosParaCronogramaXML"
        End If
        If Vista = "BuscarRegistrosParaVisualizarCronograma" Then
            SentenciaSqlBusqueda = "spVistaDespachosParaVisualizarCronogramaProcesadoXML"
        End If
        If Vista = "BuscarOrdenDespacho" Then
            SentenciaSqlBusqueda = "spVistaDetalleOrdenDespachosXML"
        End If
        If Vista = "BuscarOrdenDespachoDistribuidora" Then
            SentenciaSqlBusqueda = "spVistaDetalleOrdenDespachosDistribuidoraXML"
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
                oVerificarDatos = VerificarDatos("TDO_ID", "DTD_ID", "CCT_ID", "DES_FEC_EMI", "DES_FEC_TRA", "PVE_ID", "ALM_ID", "DES_SERIE", "DES_NUMERO", "TDO_ID_DOC", "DTD_ID_DOC", "DES_SERIE_DOC", "DES_NUMERO_DOC", "PER_ID_REC", "TDP_ID_REC", "DIR_ID_ENT_REC", "DIR_ID_ENT", "PLA_ID", "FLE_ID", "MON_ID", "DES_MONTO_FLETE", "DES_CONTRAVALOR", "USU_ID", "DES_FEC_GRAB", "DES_ESTADO")
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


Imports Ladisac.BE
Partial Public Class DetalleDocumentos
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 1
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "TDO_ID"
    Public CampoPrincipalValor = TDO_ID
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Fac.DetalleDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetalleDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetalleDocumentos"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetalleDocumentos"
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
        vElementosDatosComboBox = 163
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "TDO_ID"
        vArrayCamposBusqueda(1) = "TDO_DESCRIPCION"
        vArrayCamposBusqueda(2) = "DTD_ID"
        vArrayCamposBusqueda(3) = "DTD_DESCRIPCION"
        vArrayCamposBusqueda(4) = "CCT_ID"
        vArrayCamposBusqueda(5) = "CCT_DESCRIPCION"
        vArrayCamposBusqueda(6) = "DTD_CARGO_ABONO"
        vArrayCamposBusqueda(7) = "DTD_SIGNO"
        vArrayCamposBusqueda(8) = "DTD_SIGNO_D"
        vArrayCamposBusqueda(9) = "DOC_SERIE"
        vArrayCamposBusqueda(10) = "DOC_NUMERO"
        vArrayCamposBusqueda(11) = "DOC_ORDEN_COMPRA"
        vArrayCamposBusqueda(12) = "DOC_TIPO_ORDEN_COMPRA"
        vArrayCamposBusqueda(13) = "PER_ID_REC"
        vArrayCamposBusqueda(14) = "PER_DESCRIPCION_REC"
        vArrayCamposBusqueda(15) = "TDP_ID_REC"
        vArrayCamposBusqueda(16) = "TDP_DESCRIPCION_REC"
        vArrayCamposBusqueda(17) = "DOP_NUMERO_REC"
        vArrayCamposBusqueda(18) = "DIR_ID_ENT_REC"
        vArrayCamposBusqueda(19) = "DIR_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(20) = "DIR_TIPO_ENT_REC"
        vArrayCamposBusqueda(21) = "DIS_ID_ENT_REC"
        vArrayCamposBusqueda(22) = "DIS_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(23) = "PRO_ID_ENT_REC"
        vArrayCamposBusqueda(24) = "PRO_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(25) = "DEP_ID_ENT_REC"
        vArrayCamposBusqueda(26) = "DEP_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(27) = "PAI_ID_ENT_REC"
        vArrayCamposBusqueda(28) = "PAI_DESCRIPCION_ENT_REC"
        vArrayCamposBusqueda(29) = "DIR_ESTADO_ENT_REC"
        vArrayCamposBusqueda(30) = "PVE_ID"
        vArrayCamposBusqueda(31) = "PVE_DESCRIPCION"
        vArrayCamposBusqueda(32) = "MON_ID"
        vArrayCamposBusqueda(33) = "MON_SIMBOLO"
        vArrayCamposBusqueda(34) = "MON_DESCRIPCION"
        vArrayCamposBusqueda(35) = "TIV_ID"
        vArrayCamposBusqueda(36) = "TIV_DESCRIPCION"
        vArrayCamposBusqueda(37) = "PER_ID_CON"
        vArrayCamposBusqueda(38) = "PER_DESCRIPCION_CON"
        vArrayCamposBusqueda(39) = "PER_ID_CLI"
        vArrayCamposBusqueda(40) = "PER_DESCRIPCION_CLI"
        vArrayCamposBusqueda(41) = "TDP_ID_CLI"
        vArrayCamposBusqueda(42) = "TDP_DESCRIPCION_CLI"
        vArrayCamposBusqueda(43) = "DOP_NUMERO_CLI"
        vArrayCamposBusqueda(44) = "DIR_ID_FIS"
        vArrayCamposBusqueda(45) = "DIR_DESCRIPCION_FIS"
        vArrayCamposBusqueda(46) = "DIR_TIPO_FIS"
        vArrayCamposBusqueda(47) = "DIS_ID_FIS"
        vArrayCamposBusqueda(48) = "DIS_DESCRIPCION_FIS"
        vArrayCamposBusqueda(49) = "PRO_ID_FIS"
        vArrayCamposBusqueda(50) = "PRO_DESCRIPCION_FIS"
        vArrayCamposBusqueda(51) = "DEP_ID_FIS"
        vArrayCamposBusqueda(52) = "DEP_DESCRIPCION_FIS"
        vArrayCamposBusqueda(53) = "PAI_ID_FIS"
        vArrayCamposBusqueda(54) = "PAI_DESCRIPCION_FIS"
        vArrayCamposBusqueda(55) = "DIR_ESTADO_FIS"
        vArrayCamposBusqueda(56) = "DIR_ID_DOM"
        vArrayCamposBusqueda(57) = "DIR_DESCRIPCION_DOM"
        vArrayCamposBusqueda(58) = "DIR_TIPO_DOM"
        vArrayCamposBusqueda(59) = "DIS_ID_DOM"
        vArrayCamposBusqueda(60) = "DIS_DESCRIPCION_DOM"
        vArrayCamposBusqueda(61) = "PRO_ID_DOM"
        vArrayCamposBusqueda(62) = "PRO_DESCRIPCION_DOM"
        vArrayCamposBusqueda(63) = "DEP_ID_DOM"
        vArrayCamposBusqueda(64) = "DEP_DESCRIPCION_DOM"
        vArrayCamposBusqueda(65) = "PAI_ID_DOM"
        vArrayCamposBusqueda(66) = "PAI_DESCRIPCION_DOM"
        vArrayCamposBusqueda(67) = "DIR_ESTADO_DOM"
        vArrayCamposBusqueda(68) = "DIR_ID_ENT"
        vArrayCamposBusqueda(69) = "DIR_DESCRIPCION_ENT"
        vArrayCamposBusqueda(70) = "DIR_TIPO_ENT"
        vArrayCamposBusqueda(71) = "DIS_ID_ENT"
        vArrayCamposBusqueda(72) = "DIS_DESCRIPCION_ENT"
        vArrayCamposBusqueda(73) = "PRO_ID_ENT"
        vArrayCamposBusqueda(74) = "PRO_DESCRIPCION_ENT"
        vArrayCamposBusqueda(75) = "DEP_ID_ENT"
        vArrayCamposBusqueda(76) = "DEP_DESCRIPCION_ENT"
        vArrayCamposBusqueda(77) = "PAI_ID_ENT"
        vArrayCamposBusqueda(78) = "PAI_DESCRIPCION_ENT"
        vArrayCamposBusqueda(79) = "DIR_ESTADO_ENT"
        vArrayCamposBusqueda(80) = "DIR_ID_COB"
        vArrayCamposBusqueda(81) = "DIR_DESCRIPCION_COB"
        vArrayCamposBusqueda(82) = "DIR_TIPO_COB"
        vArrayCamposBusqueda(83) = "DIS_ID_COB"
        vArrayCamposBusqueda(84) = "DIS_DESCRIPCION_COB"
        vArrayCamposBusqueda(85) = "PRO_ID_COB"
        vArrayCamposBusqueda(86) = "PRO_DESCRIPCION_COB"
        vArrayCamposBusqueda(87) = "DEP_ID_COB"
        vArrayCamposBusqueda(88) = "DEP_DESCRIPCION_COB"
        vArrayCamposBusqueda(89) = "PAI_ID_COB"
        vArrayCamposBusqueda(90) = "PAI_DESCRIPCION_COB"
        vArrayCamposBusqueda(91) = "DIR_ESTADO_COB"
        vArrayCamposBusqueda(92) = "DOC_FECHA_EMI"
        vArrayCamposBusqueda(93) = "DOC_FECHA_ENT"
        vArrayCamposBusqueda(94) = "DOC_FECHA_EXP"
        vArrayCamposBusqueda(95) = "PER_ID_VEN"
        vArrayCamposBusqueda(96) = "PER_DESCRIPCION_VEN"
        vArrayCamposBusqueda(97) = "PER_ID_COB"
        vArrayCamposBusqueda(98) = "PER_DESCRIPCION_COB"
        vArrayCamposBusqueda(99) = "PER_ID_PRO"
        vArrayCamposBusqueda(100) = "PER_DESCRIPCION_PRO"
        vArrayCamposBusqueda(101) = "PER_ID_GRU"
        vArrayCamposBusqueda(102) = "PER_DESCRIPCION_GRU"
        vArrayCamposBusqueda(103) = "DOC_TIPO_LISTA"
        vArrayCamposBusqueda(104) = "DOC_MONTO_TOTAL"
        vArrayCamposBusqueda(105) = "DOC_CONTRAVALOR"
        vArrayCamposBusqueda(106) = "DOC_IGV_POR"
        vArrayCamposBusqueda(107) = "DOC_ASIENTO"
        vArrayCamposBusqueda(108) = "DOC_CIERRE"
        vArrayCamposBusqueda(109) = "FLE_ID"
        vArrayCamposBusqueda(110) = "FLE_DESCRIPCION"
        vArrayCamposBusqueda(111) = "DOC_MONTO_FLE"
        vArrayCamposBusqueda(112) = "DOC_REQUIERE_GUIA"
        vArrayCamposBusqueda(113) = "TDO_ID_AFE"
        vArrayCamposBusqueda(114) = "TDO_DESCRIPCION_AFE"
        vArrayCamposBusqueda(115) = "DTD_ID_AFE"
        vArrayCamposBusqueda(116) = "DTD_DESCRIPCION_AFE"
        vArrayCamposBusqueda(117) = "CCT_ID_AFE"
        vArrayCamposBusqueda(118) = "CCT_DESCRIPCION_AFE"
        vArrayCamposBusqueda(119) = "DTD_CARGO_ABONO_AFE"
        vArrayCamposBusqueda(120) = "DTD_SIGNO_AFE"
        vArrayCamposBusqueda(121) = "DTD_SIGNO_D_AFE"
        vArrayCamposBusqueda(122) = "DOC_SERIE_AFE"
        vArrayCamposBusqueda(123) = "DOC_NUMERO_AFE"
        vArrayCamposBusqueda(124) = "DOC_MOT_EMI"
        vArrayCamposBusqueda(125) = "DOC_NOMBRE_RECEP"
        vArrayCamposBusqueda(126) = "DOC_DNI_RECEP"
        vArrayCamposBusqueda(127) = "DOC_FEC_RECEP"
        vArrayCamposBusqueda(128) = "DOC_ENTREGADO"
        vArrayCamposBusqueda(129) = "CAF_IX_NUMERO_PRO"
        vArrayCamposBusqueda(130) = "CAF_IX_ORDEN_COM"
        vArrayCamposBusqueda(131) = "LPR_ID"
        vArrayCamposBusqueda(132) = "LPR_DESCRIPCION"
        vArrayCamposBusqueda(133) = "DOC_ESTADO"
        vArrayCamposBusqueda(134) = "DDO_ITEM"
        vArrayCamposBusqueda(135) = "ART_ID_IMP"
        vArrayCamposBusqueda(136) = "ART_DESCRIPCION_IMP"
        vArrayCamposBusqueda(137) = "UM_DESCRIPCION_IMP"
        vArrayCamposBusqueda(138) = "ART_ID_KAR"
        vArrayCamposBusqueda(139) = "ART_DESCRIPCION_KAR"
        vArrayCamposBusqueda(140) = "UM_DESCRIPCION_KAR"
        vArrayCamposBusqueda(141) = "DDO_ART_FACTOR"
        vArrayCamposBusqueda(142) = "DDO_CANTIDAD"
        vArrayCamposBusqueda(143) = "DDO_PRE_UNI"
        vArrayCamposBusqueda(144) = "DDO_DES_INC_PRE"
        vArrayCamposBusqueda(145) = "DDO_INC_IGV"
        vArrayCamposBusqueda(146) = "DDO_IGV_POR"
        vArrayCamposBusqueda(147) = "DDO_MONTO_IGV"
        vArrayCamposBusqueda(148) = "DDO_PRE_TOTAL"
        vArrayCamposBusqueda(149) = "DDO_OBS_DSC_ART"
        vArrayCamposBusqueda(150) = "TDO_ID_ANT"
        vArrayCamposBusqueda(151) = "TDO_DESCRIPCION_ANT"
        vArrayCamposBusqueda(152) = "DTD_ID_ANT"
        vArrayCamposBusqueda(153) = "DTD_DESCRIPCION_ANT"
        vArrayCamposBusqueda(154) = "CCT_ID_ANT"
        vArrayCamposBusqueda(155) = "CCT_DESCRIPCION_ANT"
        vArrayCamposBusqueda(156) = "DTD_CARGO_ABONO_ANT"
        vArrayCamposBusqueda(157) = "DTD_SIGNO_ANT"
        vArrayCamposBusqueda(158) = "DTD_SIGNO_D_ANT"
        vArrayCamposBusqueda(159) = "DDO_SERIE_ANT"
        vArrayCamposBusqueda(160) = "DDO_NUMERO_ANT"
        vArrayCamposBusqueda(161) = "TIV_DIAS"
        vArrayCamposBusqueda(162) = "ART_AFE_PER"
        vArrayCamposBusqueda(163) = "DDO_ESTADO"

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

        vArrayDatosComboBox(6).NombreCampo = "DTD_CARGO_ABONO"
        vArrayDatosComboBox(6).Longitud = 7
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(2, 1)
        vArrayDatosComboBox(6).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(6).Valores(0, 1) = "0"
        vArrayDatosComboBox(6).Valores(1, 0) = "CARGO"
        vArrayDatosComboBox(6).Valores(1, 1) = "1"
        vArrayDatosComboBox(6).Valores(2, 0) = "ABONO"
        vArrayDatosComboBox(6).Valores(2, 1) = "2"
        vArrayDatosComboBox(6).Ancho = 77
        vArrayDatosComboBox(6).Flag = True

        vArrayDatosComboBox(7).NombreCampo = "DTD_SIGNO"
        vArrayDatosComboBox(7).Longitud = 1
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(1, 1)
        vArrayDatosComboBox(7).Valores(0, 0) = "+"
        vArrayDatosComboBox(7).Valores(0, 1) = "0"
        vArrayDatosComboBox(7).Valores(1, 0) = "-"
        vArrayDatosComboBox(7).Valores(1, 1) = "1"
        vArrayDatosComboBox(7).Ancho = 30
        vArrayDatosComboBox(7).Flag = True

        vArrayDatosComboBox(8).NombreCampo = "DTD_SIGNO_D"
        vArrayDatosComboBox(8).Longitud = 1
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(1, 1)
        vArrayDatosComboBox(8).Valores(0, 0) = "+"
        vArrayDatosComboBox(8).Valores(0, 1) = "0"
        vArrayDatosComboBox(8).Valores(1, 0) = "-"
        vArrayDatosComboBox(8).Valores(1, 1) = "1"
        vArrayDatosComboBox(8).Ancho = 30
        vArrayDatosComboBox(8).Flag = True

        vArrayDatosComboBox(9).NombreCampo = "DOC_SERIE"
        vArrayDatosComboBox(9).Longitud = 3
        vArrayDatosComboBox(9).Tipo = "char"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 36
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "DOC_NUMERO"
        vArrayDatosComboBox(10).Longitud = 10
        vArrayDatosComboBox(10).Tipo = "varchar"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 111
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "DOC_ORDEN_COMPRA"
        vArrayDatosComboBox(11).Longitud = 20
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 218
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "DOC_TIPO_ORDEN_COMPRA"
        vArrayDatosComboBox(12).Longitud = 16
        vArrayDatosComboBox(12).Tipo = "varchar"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(2, 1)
        vArrayDatosComboBox(12).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(12).Valores(0, 1) = "0"
        vArrayDatosComboBox(12).Valores(1, 0) = "REPOSICION"
        vArrayDatosComboBox(12).Valores(1, 1) = "1"
        vArrayDatosComboBox(12).Valores(2, 0) = "DESPACHO CLIENTE"
        vArrayDatosComboBox(12).Valores(2, 1) = "2"
        vArrayDatosComboBox(12).Ancho = 138
        vArrayDatosComboBox(12).Flag = True

        vArrayDatosComboBox(13).NombreCampo = "PER_ID_REC"
        vArrayDatosComboBox(13).Longitud = 6
        vArrayDatosComboBox(13).Tipo = "char"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 68
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "PER_DESCRIPCION_REC"
        vArrayDatosComboBox(14).Longitud = 77
        vArrayDatosComboBox(14).Tipo = "varchar"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 828
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "TDP_ID_REC"
        vArrayDatosComboBox(15).Longitud = 2
        vArrayDatosComboBox(15).Tipo = "char"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 26
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "TDP_DESCRIPCION_REC"
        vArrayDatosComboBox(16).Longitud = 45
        vArrayDatosComboBox(16).Tipo = "varchar"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 485
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "DOP_NUMERO_REC"
        vArrayDatosComboBox(17).Longitud = 25
        vArrayDatosComboBox(17).Tipo = "varchar"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 272
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "DIR_ID_ENT_REC"
        vArrayDatosComboBox(18).Longitud = 8
        vArrayDatosComboBox(18).Tipo = "char"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(0, 0)
        vArrayDatosComboBox(18).Ancho = 96
        vArrayDatosComboBox(18).Flag = False

        vArrayDatosComboBox(19).NombreCampo = "DIR_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(19).Longitud = 65
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(0, 0)
        vArrayDatosComboBox(19).Ancho = 699
        vArrayDatosComboBox(19).Flag = False

        vArrayDatosComboBox(20).NombreCampo = "DIR_TIPO_ENT_REC"
        vArrayDatosComboBox(20).Longitud = 9
        vArrayDatosComboBox(20).Tipo = "varchar"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(0, 0)
        vArrayDatosComboBox(20).Ancho = 100
        vArrayDatosComboBox(20).Flag = False

        vArrayDatosComboBox(21).NombreCampo = "DIS_ID_ENT_REC"
        vArrayDatosComboBox(21).Longitud = 3
        vArrayDatosComboBox(21).Tipo = "char"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(0, 0)
        vArrayDatosComboBox(21).Ancho = 36
        vArrayDatosComboBox(21).Flag = False

        vArrayDatosComboBox(22).NombreCampo = "DIS_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(22).Longitud = 45
        vArrayDatosComboBox(22).Tipo = "varchar"
        vArrayDatosComboBox(22).ParteEntera = 0
        vArrayDatosComboBox(22).ParteDecimal = 0
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 485
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "PRO_ID_ENT_REC"
        vArrayDatosComboBox(23).Longitud = 3
        vArrayDatosComboBox(23).Tipo = "char"
        vArrayDatosComboBox(23).ParteEntera = 0
        vArrayDatosComboBox(23).ParteDecimal = 0
        ReDim vArrayDatosComboBox(23).Valores(0, 0)
        vArrayDatosComboBox(23).Ancho = 36
        vArrayDatosComboBox(23).Flag = False

        vArrayDatosComboBox(24).NombreCampo = "PRO_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(24).Longitud = 45
        vArrayDatosComboBox(24).Tipo = "varchar"
        vArrayDatosComboBox(24).ParteEntera = 0
        vArrayDatosComboBox(24).ParteDecimal = 0
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 485
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "DEP_ID_ENT_REC"
        vArrayDatosComboBox(25).Longitud = 3
        vArrayDatosComboBox(25).Tipo = "char"
        vArrayDatosComboBox(25).ParteEntera = 0
        vArrayDatosComboBox(25).ParteDecimal = 0
        ReDim vArrayDatosComboBox(25).Valores(0, 0)
        vArrayDatosComboBox(25).Ancho = 36
        vArrayDatosComboBox(25).Flag = False

        vArrayDatosComboBox(26).NombreCampo = "DEP_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(26).Longitud = 45
        vArrayDatosComboBox(26).Tipo = "varchar"
        vArrayDatosComboBox(26).ParteEntera = 0
        vArrayDatosComboBox(26).ParteDecimal = 0
        ReDim vArrayDatosComboBox(26).Valores(0, 0)
        vArrayDatosComboBox(26).Ancho = 485
        vArrayDatosComboBox(26).Flag = False

        vArrayDatosComboBox(27).NombreCampo = "PAI_ID_ENT_REC"
        vArrayDatosComboBox(27).Longitud = 3
        vArrayDatosComboBox(27).Tipo = "char"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(0, 0)
        vArrayDatosComboBox(27).Ancho = 36
        vArrayDatosComboBox(27).Flag = False

        vArrayDatosComboBox(28).NombreCampo = "PAI_DESCRIPCION_ENT_REC"
        vArrayDatosComboBox(28).Longitud = 45
        vArrayDatosComboBox(28).Tipo = "varchar"
        vArrayDatosComboBox(28).ParteEntera = 0
        vArrayDatosComboBox(28).ParteDecimal = 0
        ReDim vArrayDatosComboBox(28).Valores(0, 0)
        vArrayDatosComboBox(28).Ancho = 485
        vArrayDatosComboBox(28).Flag = False

        vArrayDatosComboBox(29).NombreCampo = "DIR_ESTADO_ENT_REC"
        vArrayDatosComboBox(29).Longitud = 9
        vArrayDatosComboBox(29).Tipo = "varchar"
        vArrayDatosComboBox(29).ParteEntera = 0
        vArrayDatosComboBox(29).ParteDecimal = 0
        ReDim vArrayDatosComboBox(29).Valores(0, 0)
        vArrayDatosComboBox(29).Ancho = 100
        vArrayDatosComboBox(29).Flag = False

        vArrayDatosComboBox(30).NombreCampo = "PVE_ID"
        vArrayDatosComboBox(30).Longitud = 3
        vArrayDatosComboBox(30).Tipo = "char"
        vArrayDatosComboBox(30).ParteEntera = 0
        vArrayDatosComboBox(30).ParteDecimal = 0
        ReDim vArrayDatosComboBox(30).Valores(0, 0)
        vArrayDatosComboBox(30).Ancho = 36
        vArrayDatosComboBox(30).Flag = False

        vArrayDatosComboBox(31).NombreCampo = "PVE_DESCRIPCION"
        vArrayDatosComboBox(31).Longitud = 45
        vArrayDatosComboBox(31).Tipo = "varchar"
        vArrayDatosComboBox(31).ParteEntera = 0
        vArrayDatosComboBox(31).ParteDecimal = 0
        ReDim vArrayDatosComboBox(31).Valores(0, 0)
        vArrayDatosComboBox(31).Ancho = 485
        vArrayDatosComboBox(31).Flag = False

        vArrayDatosComboBox(32).NombreCampo = "MON_ID"
        vArrayDatosComboBox(32).Longitud = 3
        vArrayDatosComboBox(32).Tipo = "char"
        vArrayDatosComboBox(32).ParteEntera = 0
        vArrayDatosComboBox(32).ParteDecimal = 0
        ReDim vArrayDatosComboBox(32).Valores(0, 0)
        vArrayDatosComboBox(32).Ancho = 36
        vArrayDatosComboBox(32).Flag = False

        vArrayDatosComboBox(33).NombreCampo = "MON_SIMBOLO"
        vArrayDatosComboBox(33).Longitud = 10
        vArrayDatosComboBox(33).Tipo = "varchar"
        vArrayDatosComboBox(33).ParteEntera = 0
        vArrayDatosComboBox(33).ParteDecimal = 0
        ReDim vArrayDatosComboBox(33).Valores(0, 0)
        vArrayDatosComboBox(33).Ancho = 111
        vArrayDatosComboBox(33).Flag = False

        vArrayDatosComboBox(34).NombreCampo = "MON_DESCRIPCION"
        vArrayDatosComboBox(34).Longitud = 45
        vArrayDatosComboBox(34).Tipo = "varchar"
        vArrayDatosComboBox(34).ParteEntera = 0
        vArrayDatosComboBox(34).ParteDecimal = 0
        ReDim vArrayDatosComboBox(34).Valores(0, 0)
        vArrayDatosComboBox(34).Ancho = 485
        vArrayDatosComboBox(34).Flag = False

        vArrayDatosComboBox(35).NombreCampo = "TIV_ID"
        vArrayDatosComboBox(35).Longitud = 3
        vArrayDatosComboBox(35).Tipo = "char"
        vArrayDatosComboBox(35).ParteEntera = 0
        vArrayDatosComboBox(35).ParteDecimal = 0
        ReDim vArrayDatosComboBox(35).Valores(0, 0)
        vArrayDatosComboBox(35).Ancho = 36
        vArrayDatosComboBox(35).Flag = False

        vArrayDatosComboBox(36).NombreCampo = "TIV_DESCRIPCION"
        vArrayDatosComboBox(36).Longitud = 45
        vArrayDatosComboBox(36).Tipo = "varchar"
        vArrayDatosComboBox(36).ParteEntera = 0
        vArrayDatosComboBox(36).ParteDecimal = 0
        ReDim vArrayDatosComboBox(36).Valores(0, 0)
        vArrayDatosComboBox(36).Ancho = 485
        vArrayDatosComboBox(36).Flag = False

        vArrayDatosComboBox(37).NombreCampo = "PER_ID_CON"
        vArrayDatosComboBox(37).Longitud = 6
        vArrayDatosComboBox(37).Tipo = "char"
        vArrayDatosComboBox(37).ParteEntera = 0
        vArrayDatosComboBox(37).ParteDecimal = 0
        ReDim vArrayDatosComboBox(37).Valores(0, 0)
        vArrayDatosComboBox(37).Ancho = 68
        vArrayDatosComboBox(37).Flag = False

        vArrayDatosComboBox(38).NombreCampo = "PER_DESCRIPCION_CON"
        vArrayDatosComboBox(38).Longitud = 77
        vArrayDatosComboBox(38).Tipo = "varchar"
        vArrayDatosComboBox(38).ParteEntera = 0
        vArrayDatosComboBox(38).ParteDecimal = 0
        ReDim vArrayDatosComboBox(38).Valores(0, 0)
        vArrayDatosComboBox(38).Ancho = 828
        vArrayDatosComboBox(38).Flag = False

        vArrayDatosComboBox(39).NombreCampo = "PER_ID_CLI"
        vArrayDatosComboBox(39).Longitud = 6
        vArrayDatosComboBox(39).Tipo = "char"
        vArrayDatosComboBox(39).ParteEntera = 0
        vArrayDatosComboBox(39).ParteDecimal = 0
        ReDim vArrayDatosComboBox(39).Valores(0, 0)
        vArrayDatosComboBox(39).Ancho = 68
        vArrayDatosComboBox(39).Flag = False

        vArrayDatosComboBox(40).NombreCampo = "PER_DESCRIPCION_CLI"
        vArrayDatosComboBox(40).Longitud = 77
        vArrayDatosComboBox(40).Tipo = "varchar"
        vArrayDatosComboBox(40).ParteEntera = 0
        vArrayDatosComboBox(40).ParteDecimal = 0
        ReDim vArrayDatosComboBox(40).Valores(0, 0)
        vArrayDatosComboBox(40).Ancho = 828
        vArrayDatosComboBox(40).Flag = False

        vArrayDatosComboBox(41).NombreCampo = "TDP_ID_CLI"
        vArrayDatosComboBox(41).Longitud = 2
        vArrayDatosComboBox(41).Tipo = "char"
        vArrayDatosComboBox(41).ParteEntera = 0
        vArrayDatosComboBox(41).ParteDecimal = 0
        ReDim vArrayDatosComboBox(41).Valores(0, 0)
        vArrayDatosComboBox(41).Ancho = 26
        vArrayDatosComboBox(41).Flag = False

        vArrayDatosComboBox(42).NombreCampo = "TDP_DESCRIPCION_CLI"
        vArrayDatosComboBox(42).Longitud = 45
        vArrayDatosComboBox(42).Tipo = "varchar"
        vArrayDatosComboBox(42).ParteEntera = 0
        vArrayDatosComboBox(42).ParteDecimal = 0
        ReDim vArrayDatosComboBox(42).Valores(0, 0)
        vArrayDatosComboBox(42).Ancho = 485
        vArrayDatosComboBox(42).Flag = False

        vArrayDatosComboBox(43).NombreCampo = "DOP_NUMERO_CLI"
        vArrayDatosComboBox(43).Longitud = 25
        vArrayDatosComboBox(43).Tipo = "varchar"
        vArrayDatosComboBox(43).ParteEntera = 0
        vArrayDatosComboBox(43).ParteDecimal = 0
        ReDim vArrayDatosComboBox(43).Valores(0, 0)
        vArrayDatosComboBox(43).Ancho = 272
        vArrayDatosComboBox(43).Flag = False

        vArrayDatosComboBox(44).NombreCampo = "DIR_ID_FIS"
        vArrayDatosComboBox(44).Longitud = 8
        vArrayDatosComboBox(44).Tipo = "char"
        vArrayDatosComboBox(44).ParteEntera = 0
        vArrayDatosComboBox(44).ParteDecimal = 0
        ReDim vArrayDatosComboBox(44).Valores(0, 0)
        vArrayDatosComboBox(44).Ancho = 96
        vArrayDatosComboBox(44).Flag = False

        vArrayDatosComboBox(45).NombreCampo = "DIR_DESCRIPCION_FIS"
        vArrayDatosComboBox(45).Longitud = 65
        vArrayDatosComboBox(45).Tipo = "varchar"
        vArrayDatosComboBox(45).ParteEntera = 0
        vArrayDatosComboBox(45).ParteDecimal = 0
        ReDim vArrayDatosComboBox(45).Valores(0, 0)
        vArrayDatosComboBox(45).Ancho = 699
        vArrayDatosComboBox(45).Flag = False

        vArrayDatosComboBox(46).NombreCampo = "DIR_TIPO_FIS"
        vArrayDatosComboBox(46).Longitud = 9
        vArrayDatosComboBox(46).Tipo = "varchar"
        vArrayDatosComboBox(46).ParteEntera = 0
        vArrayDatosComboBox(46).ParteDecimal = 0
        ReDim vArrayDatosComboBox(46).Valores(0, 0)
        vArrayDatosComboBox(46).Ancho = 100
        vArrayDatosComboBox(46).Flag = False

        vArrayDatosComboBox(47).NombreCampo = "DIS_ID_FIS"
        vArrayDatosComboBox(47).Longitud = 3
        vArrayDatosComboBox(47).Tipo = "char"
        vArrayDatosComboBox(47).ParteEntera = 0
        vArrayDatosComboBox(47).ParteDecimal = 0
        ReDim vArrayDatosComboBox(47).Valores(0, 0)
        vArrayDatosComboBox(47).Ancho = 36
        vArrayDatosComboBox(47).Flag = False

        vArrayDatosComboBox(48).NombreCampo = "DIS_DESCRIPCION_FIS"
        vArrayDatosComboBox(48).Longitud = 45
        vArrayDatosComboBox(48).Tipo = "varchar"
        vArrayDatosComboBox(48).ParteEntera = 0
        vArrayDatosComboBox(48).ParteDecimal = 0
        ReDim vArrayDatosComboBox(48).Valores(0, 0)
        vArrayDatosComboBox(48).Ancho = 485
        vArrayDatosComboBox(48).Flag = False

        vArrayDatosComboBox(49).NombreCampo = "PRO_ID_FIS"
        vArrayDatosComboBox(49).Longitud = 3
        vArrayDatosComboBox(49).Tipo = "char"
        vArrayDatosComboBox(49).ParteEntera = 0
        vArrayDatosComboBox(49).ParteDecimal = 0
        ReDim vArrayDatosComboBox(49).Valores(0, 0)
        vArrayDatosComboBox(49).Ancho = 36
        vArrayDatosComboBox(49).Flag = False

        vArrayDatosComboBox(50).NombreCampo = "PRO_DESCRIPCION_FIS"
        vArrayDatosComboBox(50).Longitud = 45
        vArrayDatosComboBox(50).Tipo = "varchar"
        vArrayDatosComboBox(50).ParteEntera = 0
        vArrayDatosComboBox(50).ParteDecimal = 0
        ReDim vArrayDatosComboBox(50).Valores(0, 0)
        vArrayDatosComboBox(50).Ancho = 485
        vArrayDatosComboBox(50).Flag = False

        vArrayDatosComboBox(51).NombreCampo = "DEP_ID_FIS"
        vArrayDatosComboBox(51).Longitud = 3
        vArrayDatosComboBox(51).Tipo = "char"
        vArrayDatosComboBox(51).ParteEntera = 0
        vArrayDatosComboBox(51).ParteDecimal = 0
        ReDim vArrayDatosComboBox(51).Valores(0, 0)
        vArrayDatosComboBox(51).Ancho = 36
        vArrayDatosComboBox(51).Flag = False

        vArrayDatosComboBox(52).NombreCampo = "DEP_DESCRIPCION_FIS"
        vArrayDatosComboBox(52).Longitud = 45
        vArrayDatosComboBox(52).Tipo = "varchar"
        vArrayDatosComboBox(52).ParteEntera = 0
        vArrayDatosComboBox(52).ParteDecimal = 0
        ReDim vArrayDatosComboBox(52).Valores(0, 0)
        vArrayDatosComboBox(52).Ancho = 485
        vArrayDatosComboBox(52).Flag = False

        vArrayDatosComboBox(53).NombreCampo = "PAI_ID_FIS"
        vArrayDatosComboBox(53).Longitud = 3
        vArrayDatosComboBox(53).Tipo = "char"
        vArrayDatosComboBox(53).ParteEntera = 0
        vArrayDatosComboBox(53).ParteDecimal = 0
        ReDim vArrayDatosComboBox(53).Valores(0, 0)
        vArrayDatosComboBox(53).Ancho = 36
        vArrayDatosComboBox(53).Flag = False

        vArrayDatosComboBox(54).NombreCampo = "PAI_DESCRIPCION_FIS"
        vArrayDatosComboBox(54).Longitud = 45
        vArrayDatosComboBox(54).Tipo = "varchar"
        vArrayDatosComboBox(54).ParteEntera = 0
        vArrayDatosComboBox(54).ParteDecimal = 0
        ReDim vArrayDatosComboBox(54).Valores(0, 0)
        vArrayDatosComboBox(54).Ancho = 485
        vArrayDatosComboBox(54).Flag = False

        vArrayDatosComboBox(55).NombreCampo = "DIR_ESTADO_FIS"
        vArrayDatosComboBox(55).Longitud = 9
        vArrayDatosComboBox(55).Tipo = "varchar"
        vArrayDatosComboBox(55).ParteEntera = 0
        vArrayDatosComboBox(55).ParteDecimal = 0
        ReDim vArrayDatosComboBox(55).Valores(0, 0)
        vArrayDatosComboBox(55).Ancho = 100
        vArrayDatosComboBox(55).Flag = False

        vArrayDatosComboBox(56).NombreCampo = "DIR_ID_DOM"
        vArrayDatosComboBox(56).Longitud = 8
        vArrayDatosComboBox(56).Tipo = "char"
        vArrayDatosComboBox(56).ParteEntera = 0
        vArrayDatosComboBox(56).ParteDecimal = 0
        ReDim vArrayDatosComboBox(56).Valores(0, 0)
        vArrayDatosComboBox(56).Ancho = 96
        vArrayDatosComboBox(56).Flag = False

        vArrayDatosComboBox(57).NombreCampo = "DIR_DESCRIPCION_DOM"
        vArrayDatosComboBox(57).Longitud = 65
        vArrayDatosComboBox(57).Tipo = "varchar"
        vArrayDatosComboBox(57).ParteEntera = 0
        vArrayDatosComboBox(57).ParteDecimal = 0
        ReDim vArrayDatosComboBox(57).Valores(0, 0)
        vArrayDatosComboBox(57).Ancho = 699
        vArrayDatosComboBox(57).Flag = False

        vArrayDatosComboBox(58).NombreCampo = "DIR_TIPO_DOM"
        vArrayDatosComboBox(58).Longitud = 9
        vArrayDatosComboBox(58).Tipo = "varchar"
        vArrayDatosComboBox(58).ParteEntera = 0
        vArrayDatosComboBox(58).ParteDecimal = 0
        ReDim vArrayDatosComboBox(58).Valores(0, 0)
        vArrayDatosComboBox(58).Ancho = 100
        vArrayDatosComboBox(58).Flag = False

        vArrayDatosComboBox(59).NombreCampo = "DIS_ID_DOM"
        vArrayDatosComboBox(59).Longitud = 3
        vArrayDatosComboBox(59).Tipo = "char"
        vArrayDatosComboBox(59).ParteEntera = 0
        vArrayDatosComboBox(59).ParteDecimal = 0
        ReDim vArrayDatosComboBox(59).Valores(0, 0)
        vArrayDatosComboBox(59).Ancho = 36
        vArrayDatosComboBox(59).Flag = False

        vArrayDatosComboBox(60).NombreCampo = "DIS_DESCRIPCION_DOM"
        vArrayDatosComboBox(60).Longitud = 45
        vArrayDatosComboBox(60).Tipo = "varchar"
        vArrayDatosComboBox(60).ParteEntera = 0
        vArrayDatosComboBox(60).ParteDecimal = 0
        ReDim vArrayDatosComboBox(60).Valores(0, 0)
        vArrayDatosComboBox(60).Ancho = 485
        vArrayDatosComboBox(60).Flag = False

        vArrayDatosComboBox(61).NombreCampo = "PRO_ID_DOM"
        vArrayDatosComboBox(61).Longitud = 3
        vArrayDatosComboBox(61).Tipo = "char"
        vArrayDatosComboBox(61).ParteEntera = 0
        vArrayDatosComboBox(61).ParteDecimal = 0
        ReDim vArrayDatosComboBox(61).Valores(0, 0)
        vArrayDatosComboBox(61).Ancho = 36
        vArrayDatosComboBox(61).Flag = False

        vArrayDatosComboBox(62).NombreCampo = "PRO_DESCRIPCION_DOM"
        vArrayDatosComboBox(62).Longitud = 45
        vArrayDatosComboBox(62).Tipo = "varchar"
        vArrayDatosComboBox(62).ParteEntera = 0
        vArrayDatosComboBox(62).ParteDecimal = 0
        ReDim vArrayDatosComboBox(62).Valores(0, 0)
        vArrayDatosComboBox(62).Ancho = 485
        vArrayDatosComboBox(62).Flag = False

        vArrayDatosComboBox(63).NombreCampo = "DEP_ID_DOM"
        vArrayDatosComboBox(63).Longitud = 3
        vArrayDatosComboBox(63).Tipo = "char"
        vArrayDatosComboBox(63).ParteEntera = 0
        vArrayDatosComboBox(63).ParteDecimal = 0
        ReDim vArrayDatosComboBox(63).Valores(0, 0)
        vArrayDatosComboBox(63).Ancho = 36
        vArrayDatosComboBox(63).Flag = False

        vArrayDatosComboBox(64).NombreCampo = "DEP_DESCRIPCION_DOM"
        vArrayDatosComboBox(64).Longitud = 45
        vArrayDatosComboBox(64).Tipo = "varchar"
        vArrayDatosComboBox(64).ParteEntera = 0
        vArrayDatosComboBox(64).ParteDecimal = 0
        ReDim vArrayDatosComboBox(64).Valores(0, 0)
        vArrayDatosComboBox(64).Ancho = 485
        vArrayDatosComboBox(64).Flag = False

        vArrayDatosComboBox(65).NombreCampo = "PAI_ID_DOM"
        vArrayDatosComboBox(65).Longitud = 3
        vArrayDatosComboBox(65).Tipo = "char"
        vArrayDatosComboBox(65).ParteEntera = 0
        vArrayDatosComboBox(65).ParteDecimal = 0
        ReDim vArrayDatosComboBox(65).Valores(0, 0)
        vArrayDatosComboBox(65).Ancho = 36
        vArrayDatosComboBox(65).Flag = False

        vArrayDatosComboBox(66).NombreCampo = "PAI_DESCRIPCION_DOM"
        vArrayDatosComboBox(66).Longitud = 45
        vArrayDatosComboBox(66).Tipo = "varchar"
        vArrayDatosComboBox(66).ParteEntera = 0
        vArrayDatosComboBox(66).ParteDecimal = 0
        ReDim vArrayDatosComboBox(66).Valores(0, 0)
        vArrayDatosComboBox(66).Ancho = 485
        vArrayDatosComboBox(66).Flag = False

        vArrayDatosComboBox(67).NombreCampo = "DIR_ESTADO_DOM"
        vArrayDatosComboBox(67).Longitud = 9
        vArrayDatosComboBox(67).Tipo = "varchar"
        vArrayDatosComboBox(67).ParteEntera = 0
        vArrayDatosComboBox(67).ParteDecimal = 0
        ReDim vArrayDatosComboBox(67).Valores(0, 0)
        vArrayDatosComboBox(67).Ancho = 100
        vArrayDatosComboBox(67).Flag = False

        vArrayDatosComboBox(68).NombreCampo = "DIR_ID_ENT"
        vArrayDatosComboBox(68).Longitud = 8
        vArrayDatosComboBox(68).Tipo = "char"
        vArrayDatosComboBox(68).ParteEntera = 0
        vArrayDatosComboBox(68).ParteDecimal = 0
        ReDim vArrayDatosComboBox(68).Valores(0, 0)
        vArrayDatosComboBox(68).Ancho = 96
        vArrayDatosComboBox(68).Flag = False

        vArrayDatosComboBox(69).NombreCampo = "DIR_DESCRIPCION_ENT"
        vArrayDatosComboBox(69).Longitud = 65
        vArrayDatosComboBox(69).Tipo = "varchar"
        vArrayDatosComboBox(69).ParteEntera = 0
        vArrayDatosComboBox(69).ParteDecimal = 0
        ReDim vArrayDatosComboBox(69).Valores(0, 0)
        vArrayDatosComboBox(69).Ancho = 699
        vArrayDatosComboBox(69).Flag = False

        vArrayDatosComboBox(70).NombreCampo = "DIR_TIPO_ENT"
        vArrayDatosComboBox(70).Longitud = 9
        vArrayDatosComboBox(70).Tipo = "varchar"
        vArrayDatosComboBox(70).ParteEntera = 0
        vArrayDatosComboBox(70).ParteDecimal = 0
        ReDim vArrayDatosComboBox(70).Valores(0, 0)
        vArrayDatosComboBox(70).Ancho = 100
        vArrayDatosComboBox(70).Flag = False

        vArrayDatosComboBox(71).NombreCampo = "DIS_ID_ENT"
        vArrayDatosComboBox(71).Longitud = 3
        vArrayDatosComboBox(71).Tipo = "char"
        vArrayDatosComboBox(71).ParteEntera = 0
        vArrayDatosComboBox(71).ParteDecimal = 0
        ReDim vArrayDatosComboBox(71).Valores(0, 0)
        vArrayDatosComboBox(71).Ancho = 36
        vArrayDatosComboBox(71).Flag = False

        vArrayDatosComboBox(72).NombreCampo = "DIS_DESCRIPCION_ENT"
        vArrayDatosComboBox(72).Longitud = 45
        vArrayDatosComboBox(72).Tipo = "varchar"
        vArrayDatosComboBox(72).ParteEntera = 0
        vArrayDatosComboBox(72).ParteDecimal = 0
        ReDim vArrayDatosComboBox(72).Valores(0, 0)
        vArrayDatosComboBox(72).Ancho = 485
        vArrayDatosComboBox(72).Flag = False

        vArrayDatosComboBox(73).NombreCampo = "PRO_ID_ENT"
        vArrayDatosComboBox(73).Longitud = 3
        vArrayDatosComboBox(73).Tipo = "char"
        vArrayDatosComboBox(73).ParteEntera = 0
        vArrayDatosComboBox(73).ParteDecimal = 0
        ReDim vArrayDatosComboBox(73).Valores(0, 0)
        vArrayDatosComboBox(73).Ancho = 36
        vArrayDatosComboBox(73).Flag = False

        vArrayDatosComboBox(74).NombreCampo = "PRO_DESCRIPCION_ENT"
        vArrayDatosComboBox(74).Longitud = 45
        vArrayDatosComboBox(74).Tipo = "varchar"
        vArrayDatosComboBox(74).ParteEntera = 0
        vArrayDatosComboBox(74).ParteDecimal = 0
        ReDim vArrayDatosComboBox(74).Valores(0, 0)
        vArrayDatosComboBox(74).Ancho = 485
        vArrayDatosComboBox(74).Flag = False

        vArrayDatosComboBox(75).NombreCampo = "DEP_ID_ENT"
        vArrayDatosComboBox(75).Longitud = 3
        vArrayDatosComboBox(75).Tipo = "char"
        vArrayDatosComboBox(75).ParteEntera = 0
        vArrayDatosComboBox(75).ParteDecimal = 0
        ReDim vArrayDatosComboBox(75).Valores(0, 0)
        vArrayDatosComboBox(75).Ancho = 36
        vArrayDatosComboBox(75).Flag = False

        vArrayDatosComboBox(76).NombreCampo = "DEP_DESCRIPCION_ENT"
        vArrayDatosComboBox(76).Longitud = 45
        vArrayDatosComboBox(76).Tipo = "varchar"
        vArrayDatosComboBox(76).ParteEntera = 0
        vArrayDatosComboBox(76).ParteDecimal = 0
        ReDim vArrayDatosComboBox(76).Valores(0, 0)
        vArrayDatosComboBox(76).Ancho = 485
        vArrayDatosComboBox(76).Flag = False

        vArrayDatosComboBox(77).NombreCampo = "PAI_ID_ENT"
        vArrayDatosComboBox(77).Longitud = 3
        vArrayDatosComboBox(77).Tipo = "char"
        vArrayDatosComboBox(77).ParteEntera = 0
        vArrayDatosComboBox(77).ParteDecimal = 0
        ReDim vArrayDatosComboBox(77).Valores(0, 0)
        vArrayDatosComboBox(77).Ancho = 36
        vArrayDatosComboBox(77).Flag = False

        vArrayDatosComboBox(78).NombreCampo = "PAI_DESCRIPCION_ENT"
        vArrayDatosComboBox(78).Longitud = 45
        vArrayDatosComboBox(78).Tipo = "varchar"
        vArrayDatosComboBox(78).ParteEntera = 0
        vArrayDatosComboBox(78).ParteDecimal = 0
        ReDim vArrayDatosComboBox(78).Valores(0, 0)
        vArrayDatosComboBox(78).Ancho = 485
        vArrayDatosComboBox(78).Flag = False

        vArrayDatosComboBox(79).NombreCampo = "DIR_ESTADO_ENT"
        vArrayDatosComboBox(79).Longitud = 9
        vArrayDatosComboBox(79).Tipo = "varchar"
        vArrayDatosComboBox(79).ParteEntera = 0
        vArrayDatosComboBox(79).ParteDecimal = 0
        ReDim vArrayDatosComboBox(79).Valores(0, 0)
        vArrayDatosComboBox(79).Ancho = 100
        vArrayDatosComboBox(79).Flag = False

        vArrayDatosComboBox(80).NombreCampo = "DIR_ID_COB"
        vArrayDatosComboBox(80).Longitud = 8
        vArrayDatosComboBox(80).Tipo = "char"
        vArrayDatosComboBox(80).ParteEntera = 0
        vArrayDatosComboBox(80).ParteDecimal = 0
        ReDim vArrayDatosComboBox(80).Valores(0, 0)
        vArrayDatosComboBox(80).Ancho = 96
        vArrayDatosComboBox(80).Flag = False

        vArrayDatosComboBox(81).NombreCampo = "DIR_DESCRIPCION_COB"
        vArrayDatosComboBox(81).Longitud = 65
        vArrayDatosComboBox(81).Tipo = "varchar"
        vArrayDatosComboBox(81).ParteEntera = 0
        vArrayDatosComboBox(81).ParteDecimal = 0
        ReDim vArrayDatosComboBox(81).Valores(0, 0)
        vArrayDatosComboBox(81).Ancho = 699
        vArrayDatosComboBox(81).Flag = False

        vArrayDatosComboBox(82).NombreCampo = "DIR_TIPO_COB"
        vArrayDatosComboBox(82).Longitud = 9
        vArrayDatosComboBox(82).Tipo = "varchar"
        vArrayDatosComboBox(82).ParteEntera = 0
        vArrayDatosComboBox(82).ParteDecimal = 0
        ReDim vArrayDatosComboBox(82).Valores(0, 0)
        vArrayDatosComboBox(82).Ancho = 100
        vArrayDatosComboBox(82).Flag = False

        vArrayDatosComboBox(83).NombreCampo = "DIS_ID_COB"
        vArrayDatosComboBox(83).Longitud = 3
        vArrayDatosComboBox(83).Tipo = "char"
        vArrayDatosComboBox(83).ParteEntera = 0
        vArrayDatosComboBox(83).ParteDecimal = 0
        ReDim vArrayDatosComboBox(83).Valores(0, 0)
        vArrayDatosComboBox(83).Ancho = 36
        vArrayDatosComboBox(83).Flag = False

        vArrayDatosComboBox(84).NombreCampo = "DIS_DESCRIPCION_COB"
        vArrayDatosComboBox(84).Longitud = 45
        vArrayDatosComboBox(84).Tipo = "varchar"
        vArrayDatosComboBox(84).ParteEntera = 0
        vArrayDatosComboBox(84).ParteDecimal = 0
        ReDim vArrayDatosComboBox(84).Valores(0, 0)
        vArrayDatosComboBox(84).Ancho = 485
        vArrayDatosComboBox(84).Flag = False

        vArrayDatosComboBox(85).NombreCampo = "PRO_ID_COB"
        vArrayDatosComboBox(85).Longitud = 3
        vArrayDatosComboBox(85).Tipo = "char"
        vArrayDatosComboBox(85).ParteEntera = 0
        vArrayDatosComboBox(85).ParteDecimal = 0
        ReDim vArrayDatosComboBox(85).Valores(0, 0)
        vArrayDatosComboBox(85).Ancho = 36
        vArrayDatosComboBox(85).Flag = False

        vArrayDatosComboBox(86).NombreCampo = "PRO_DESCRIPCION_COB"
        vArrayDatosComboBox(86).Longitud = 45
        vArrayDatosComboBox(86).Tipo = "varchar"
        vArrayDatosComboBox(86).ParteEntera = 0
        vArrayDatosComboBox(86).ParteDecimal = 0
        ReDim vArrayDatosComboBox(86).Valores(0, 0)
        vArrayDatosComboBox(86).Ancho = 485
        vArrayDatosComboBox(86).Flag = False

        vArrayDatosComboBox(87).NombreCampo = "DEP_ID_COB"
        vArrayDatosComboBox(87).Longitud = 3
        vArrayDatosComboBox(87).Tipo = "char"
        vArrayDatosComboBox(87).ParteEntera = 0
        vArrayDatosComboBox(87).ParteDecimal = 0
        ReDim vArrayDatosComboBox(87).Valores(0, 0)
        vArrayDatosComboBox(87).Ancho = 36
        vArrayDatosComboBox(87).Flag = False

        vArrayDatosComboBox(88).NombreCampo = "DEP_DESCRIPCION_COB"
        vArrayDatosComboBox(88).Longitud = 45
        vArrayDatosComboBox(88).Tipo = "varchar"
        vArrayDatosComboBox(88).ParteEntera = 0
        vArrayDatosComboBox(88).ParteDecimal = 0
        ReDim vArrayDatosComboBox(88).Valores(0, 0)
        vArrayDatosComboBox(88).Ancho = 485
        vArrayDatosComboBox(88).Flag = False

        vArrayDatosComboBox(89).NombreCampo = "PAI_ID_COB"
        vArrayDatosComboBox(89).Longitud = 3
        vArrayDatosComboBox(89).Tipo = "char"
        vArrayDatosComboBox(89).ParteEntera = 0
        vArrayDatosComboBox(89).ParteDecimal = 0
        ReDim vArrayDatosComboBox(89).Valores(0, 0)
        vArrayDatosComboBox(89).Ancho = 36
        vArrayDatosComboBox(89).Flag = False

        vArrayDatosComboBox(90).NombreCampo = "PAI_DESCRIPCION_COB"
        vArrayDatosComboBox(90).Longitud = 45
        vArrayDatosComboBox(90).Tipo = "varchar"
        vArrayDatosComboBox(90).ParteEntera = 0
        vArrayDatosComboBox(90).ParteDecimal = 0
        ReDim vArrayDatosComboBox(90).Valores(0, 0)
        vArrayDatosComboBox(90).Ancho = 485
        vArrayDatosComboBox(90).Flag = False

        vArrayDatosComboBox(91).NombreCampo = "DIR_ESTADO_COB"
        vArrayDatosComboBox(91).Longitud = 9
        vArrayDatosComboBox(91).Tipo = "varchar"
        vArrayDatosComboBox(91).ParteEntera = 0
        vArrayDatosComboBox(91).ParteDecimal = 0
        ReDim vArrayDatosComboBox(91).Valores(0, 0)
        vArrayDatosComboBox(91).Ancho = 100
        vArrayDatosComboBox(91).Flag = False

        vArrayDatosComboBox(92).NombreCampo = "DOC_FECHA_EMI"
        vArrayDatosComboBox(92).Longitud = 0
        vArrayDatosComboBox(92).Tipo = "smalldatetime"
        vArrayDatosComboBox(92).ParteEntera = 0
        vArrayDatosComboBox(92).ParteDecimal = 0
        ReDim vArrayDatosComboBox(92).Valores(0, 0)
        vArrayDatosComboBox(92).Ancho = 15
        vArrayDatosComboBox(92).Flag = False

        vArrayDatosComboBox(93).NombreCampo = "DOC_FECHA_ENT"
        vArrayDatosComboBox(93).Longitud = 0
        vArrayDatosComboBox(93).Tipo = "smalldatetime"
        vArrayDatosComboBox(93).ParteEntera = 0
        vArrayDatosComboBox(93).ParteDecimal = 0
        ReDim vArrayDatosComboBox(93).Valores(0, 0)
        vArrayDatosComboBox(93).Ancho = 15
        vArrayDatosComboBox(93).Flag = False

        vArrayDatosComboBox(94).NombreCampo = "DOC_FECHA_EXP"
        vArrayDatosComboBox(94).Longitud = 0
        vArrayDatosComboBox(94).Tipo = "smalldatetime"
        vArrayDatosComboBox(94).ParteEntera = 0
        vArrayDatosComboBox(94).ParteDecimal = 0
        ReDim vArrayDatosComboBox(94).Valores(0, 0)
        vArrayDatosComboBox(94).Ancho = 15
        vArrayDatosComboBox(94).Flag = False

        vArrayDatosComboBox(95).NombreCampo = "PER_ID_VEN"
        vArrayDatosComboBox(95).Longitud = 6
        vArrayDatosComboBox(95).Tipo = "char"
        vArrayDatosComboBox(95).ParteEntera = 0
        vArrayDatosComboBox(95).ParteDecimal = 0
        ReDim vArrayDatosComboBox(95).Valores(0, 0)
        vArrayDatosComboBox(95).Ancho = 68
        vArrayDatosComboBox(95).Flag = False

        vArrayDatosComboBox(96).NombreCampo = "PER_DESCRIPCION_VEN"
        vArrayDatosComboBox(96).Longitud = 77
        vArrayDatosComboBox(96).Tipo = "varchar"
        vArrayDatosComboBox(96).ParteEntera = 0
        vArrayDatosComboBox(96).ParteDecimal = 0
        ReDim vArrayDatosComboBox(96).Valores(0, 0)
        vArrayDatosComboBox(96).Ancho = 828
        vArrayDatosComboBox(96).Flag = False

        vArrayDatosComboBox(97).NombreCampo = "PER_ID_COB"
        vArrayDatosComboBox(97).Longitud = 6
        vArrayDatosComboBox(97).Tipo = "char"
        vArrayDatosComboBox(97).ParteEntera = 0
        vArrayDatosComboBox(97).ParteDecimal = 0
        ReDim vArrayDatosComboBox(97).Valores(0, 0)
        vArrayDatosComboBox(97).Ancho = 68
        vArrayDatosComboBox(97).Flag = False

        vArrayDatosComboBox(98).NombreCampo = "PER_DESCRIPCION_COB"
        vArrayDatosComboBox(98).Longitud = 77
        vArrayDatosComboBox(98).Tipo = "varchar"
        vArrayDatosComboBox(98).ParteEntera = 0
        vArrayDatosComboBox(98).ParteDecimal = 0
        ReDim vArrayDatosComboBox(98).Valores(0, 0)
        vArrayDatosComboBox(98).Ancho = 828
        vArrayDatosComboBox(98).Flag = False

        vArrayDatosComboBox(99).NombreCampo = "PER_ID_PRO"
        vArrayDatosComboBox(99).Longitud = 6
        vArrayDatosComboBox(99).Tipo = "char"
        vArrayDatosComboBox(99).ParteEntera = 0
        vArrayDatosComboBox(99).ParteDecimal = 0
        ReDim vArrayDatosComboBox(99).Valores(0, 0)
        vArrayDatosComboBox(99).Ancho = 68
        vArrayDatosComboBox(99).Flag = False

        vArrayDatosComboBox(100).NombreCampo = "PER_DESCRIPCION_PRO"
        vArrayDatosComboBox(100).Longitud = 77
        vArrayDatosComboBox(100).Tipo = "varchar"
        vArrayDatosComboBox(100).ParteEntera = 0
        vArrayDatosComboBox(100).ParteDecimal = 0
        ReDim vArrayDatosComboBox(100).Valores(0, 0)
        vArrayDatosComboBox(100).Ancho = 828
        vArrayDatosComboBox(100).Flag = False

        vArrayDatosComboBox(101).NombreCampo = "PER_ID_GRU"
        vArrayDatosComboBox(101).Longitud = 6
        vArrayDatosComboBox(101).Tipo = "char"
        vArrayDatosComboBox(101).ParteEntera = 0
        vArrayDatosComboBox(101).ParteDecimal = 0
        ReDim vArrayDatosComboBox(101).Valores(0, 0)
        vArrayDatosComboBox(101).Ancho = 68
        vArrayDatosComboBox(101).Flag = False

        vArrayDatosComboBox(102).NombreCampo = "PER_DESCRIPCION_GRU"
        vArrayDatosComboBox(102).Longitud = 77
        vArrayDatosComboBox(102).Tipo = "varchar"
        vArrayDatosComboBox(102).ParteEntera = 0
        vArrayDatosComboBox(102).ParteDecimal = 0
        ReDim vArrayDatosComboBox(102).Valores(0, 0)
        vArrayDatosComboBox(102).Ancho = 828
        vArrayDatosComboBox(102).Flag = False

        vArrayDatosComboBox(103).NombreCampo = "DOC_TIPO_LISTA"
        vArrayDatosComboBox(103).Longitud = 21
        vArrayDatosComboBox(103).Tipo = "varchar"
        vArrayDatosComboBox(103).ParteEntera = 0
        vArrayDatosComboBox(103).ParteDecimal = 0
        ReDim vArrayDatosComboBox(103).Valores(3, 1)
        vArrayDatosComboBox(103).Valores(0, 0) = "PLANTA"
        vArrayDatosComboBox(103).Valores(0, 1) = "0"
        vArrayDatosComboBox(103).Valores(1, 0) = "PLANTA - OBRA"
        vArrayDatosComboBox(103).Valores(1, 1) = "1"
        vArrayDatosComboBox(103).Valores(2, 0) = "PUNTO DE VENTA"
        vArrayDatosComboBox(103).Valores(2, 1) = "2"
        vArrayDatosComboBox(103).Valores(3, 0) = "PUNTO DE VENTA - OBRA"
        vArrayDatosComboBox(103).Valores(3, 1) = "3"
        vArrayDatosComboBox(103).Ancho = 164
        vArrayDatosComboBox(103).Flag = True

        vArrayDatosComboBox(104).NombreCampo = "DOC_MONTO_TOTAL"
        vArrayDatosComboBox(104).Longitud = 18
        vArrayDatosComboBox(104).Tipo = "numeric"
        vArrayDatosComboBox(104).ParteEntera = 14
        vArrayDatosComboBox(104).ParteDecimal = 4
        ReDim vArrayDatosComboBox(104).Valores(0, 0)
        vArrayDatosComboBox(104).Ancho = 197
        vArrayDatosComboBox(104).Flag = False

        vArrayDatosComboBox(105).NombreCampo = "DOC_CONTRAVALOR"
        vArrayDatosComboBox(105).Longitud = 18
        vArrayDatosComboBox(105).Tipo = "numeric"
        vArrayDatosComboBox(105).ParteEntera = 14
        vArrayDatosComboBox(105).ParteDecimal = 4
        ReDim vArrayDatosComboBox(105).Valores(0, 0)
        vArrayDatosComboBox(105).Ancho = 197
        vArrayDatosComboBox(105).Flag = False

        vArrayDatosComboBox(106).NombreCampo = "DOC_IGV_POR"
        vArrayDatosComboBox(106).Longitud = 4
        vArrayDatosComboBox(106).Tipo = "numeric"
        vArrayDatosComboBox(106).ParteEntera = 2
        vArrayDatosComboBox(106).ParteDecimal = 2
        ReDim vArrayDatosComboBox(106).Valores(0, 0)
        vArrayDatosComboBox(106).Ancho = 47
        vArrayDatosComboBox(106).Flag = False

        vArrayDatosComboBox(107).NombreCampo = "DOC_ASIENTO"
        vArrayDatosComboBox(107).Longitud = 19
        vArrayDatosComboBox(107).Tipo = "varchar"
        vArrayDatosComboBox(107).ParteEntera = 0
        vArrayDatosComboBox(107).ParteDecimal = 0
        ReDim vArrayDatosComboBox(107).Valores(1, 1)
        vArrayDatosComboBox(107).Valores(0, 0) = "NO ASIENTO CONTABLE"
        vArrayDatosComboBox(107).Valores(0, 1) = "0"
        vArrayDatosComboBox(107).Valores(1, 0) = "SI ASIENTO CONTABLE"
        vArrayDatosComboBox(107).Valores(1, 1) = "1"
        vArrayDatosComboBox(107).Ancho = 157
        vArrayDatosComboBox(107).Flag = True

        vArrayDatosComboBox(108).NombreCampo = "DOC_CIERRE"
        vArrayDatosComboBox(108).Longitud = 7
        vArrayDatosComboBox(108).Tipo = "varchar"
        vArrayDatosComboBox(108).ParteEntera = 0
        vArrayDatosComboBox(108).ParteDecimal = 0
        ReDim vArrayDatosComboBox(108).Valores(2, 1)
        vArrayDatosComboBox(108).Valores(0, 0) = "ABIERTO"
        vArrayDatosComboBox(108).Valores(0, 1) = "0"
        vArrayDatosComboBox(108).Valores(1, 0) = "CERRADO"
        vArrayDatosComboBox(108).Valores(1, 1) = "1"
        vArrayDatosComboBox(108).Valores(2, 0) = "ATENDER"
        vArrayDatosComboBox(108).Valores(2, 1) = "2"
        vArrayDatosComboBox(108).Ancho = 80
        vArrayDatosComboBox(108).Flag = True

        vArrayDatosComboBox(109).NombreCampo = "FLE_ID"
        vArrayDatosComboBox(109).Longitud = 3
        vArrayDatosComboBox(109).Tipo = "char"
        vArrayDatosComboBox(109).ParteEntera = 0
        vArrayDatosComboBox(109).ParteDecimal = 0
        ReDim vArrayDatosComboBox(109).Valores(0, 0)
        vArrayDatosComboBox(109).Ancho = 36
        vArrayDatosComboBox(109).Flag = False

        vArrayDatosComboBox(110).NombreCampo = "FLE_DESCRIPCION"
        vArrayDatosComboBox(110).Longitud = 45
        vArrayDatosComboBox(110).Tipo = "varchar"
        vArrayDatosComboBox(110).ParteEntera = 0
        vArrayDatosComboBox(110).ParteDecimal = 0
        ReDim vArrayDatosComboBox(110).Valores(0, 0)
        vArrayDatosComboBox(110).Ancho = 485
        vArrayDatosComboBox(110).Flag = False

        vArrayDatosComboBox(111).NombreCampo = "DOC_MONTO_FLE"
        vArrayDatosComboBox(111).Longitud = 18
        vArrayDatosComboBox(111).Tipo = "numeric"
        vArrayDatosComboBox(111).ParteEntera = 14
        vArrayDatosComboBox(111).ParteDecimal = 4
        ReDim vArrayDatosComboBox(111).Valores(0, 0)
        vArrayDatosComboBox(111).Ancho = 197
        vArrayDatosComboBox(111).Flag = False

        vArrayDatosComboBox(112).NombreCampo = "DOC_REQUIERE_GUIA"
        vArrayDatosComboBox(112).Longitud = 16
        vArrayDatosComboBox(112).Tipo = "varchar"
        vArrayDatosComboBox(112).ParteEntera = 0
        vArrayDatosComboBox(112).ParteDecimal = 0
        ReDim vArrayDatosComboBox(112).Valores(1, 1)
        vArrayDatosComboBox(112).Valores(0, 0) = "NO REQUIERE GUIA"
        vArrayDatosComboBox(112).Valores(0, 1) = "0"
        vArrayDatosComboBox(112).Valores(1, 0) = "REQUIERE GUIA"
        vArrayDatosComboBox(112).Valores(1, 1) = "1"
        vArrayDatosComboBox(112).Ancho = 133
        vArrayDatosComboBox(112).Flag = True

        vArrayDatosComboBox(113).NombreCampo = "TDO_ID_AFE"
        vArrayDatosComboBox(113).Longitud = 3
        vArrayDatosComboBox(113).Tipo = "char"
        vArrayDatosComboBox(113).ParteEntera = 0
        vArrayDatosComboBox(113).ParteDecimal = 0
        ReDim vArrayDatosComboBox(113).Valores(0, 0)
        vArrayDatosComboBox(113).Ancho = 36
        vArrayDatosComboBox(113).Flag = False

        vArrayDatosComboBox(114).NombreCampo = "TDO_DESCRIPCION_AFE"
        vArrayDatosComboBox(114).Longitud = 45
        vArrayDatosComboBox(114).Tipo = "varchar"
        vArrayDatosComboBox(114).ParteEntera = 0
        vArrayDatosComboBox(114).ParteDecimal = 0
        ReDim vArrayDatosComboBox(114).Valores(0, 0)
        vArrayDatosComboBox(114).Ancho = 485
        vArrayDatosComboBox(114).Flag = False

        vArrayDatosComboBox(115).NombreCampo = "DTD_ID_AFE"
        vArrayDatosComboBox(115).Longitud = 3
        vArrayDatosComboBox(115).Tipo = "char"
        vArrayDatosComboBox(115).ParteEntera = 0
        vArrayDatosComboBox(115).ParteDecimal = 0
        ReDim vArrayDatosComboBox(115).Valores(0, 0)
        vArrayDatosComboBox(115).Ancho = 36
        vArrayDatosComboBox(115).Flag = False

        vArrayDatosComboBox(116).NombreCampo = "DTD_DESCRIPCION_AFE"
        vArrayDatosComboBox(116).Longitud = 45
        vArrayDatosComboBox(116).Tipo = "varchar"
        vArrayDatosComboBox(116).ParteEntera = 0
        vArrayDatosComboBox(116).ParteDecimal = 0
        ReDim vArrayDatosComboBox(116).Valores(0, 0)
        vArrayDatosComboBox(116).Ancho = 485
        vArrayDatosComboBox(116).Flag = False

        vArrayDatosComboBox(117).NombreCampo = "CCT_ID_AFE"
        vArrayDatosComboBox(117).Longitud = 3
        vArrayDatosComboBox(117).Tipo = "char"
        vArrayDatosComboBox(117).ParteEntera = 0
        vArrayDatosComboBox(117).ParteDecimal = 0
        ReDim vArrayDatosComboBox(117).Valores(0, 0)
        vArrayDatosComboBox(117).Ancho = 36
        vArrayDatosComboBox(117).Flag = False

        vArrayDatosComboBox(118).NombreCampo = "CCT_DESCRIPCION_AFE"
        vArrayDatosComboBox(118).Longitud = 45
        vArrayDatosComboBox(118).Tipo = "varchar"
        vArrayDatosComboBox(118).ParteEntera = 0
        vArrayDatosComboBox(118).ParteDecimal = 0
        ReDim vArrayDatosComboBox(118).Valores(0, 0)
        vArrayDatosComboBox(118).Ancho = 485
        vArrayDatosComboBox(118).Flag = False

        vArrayDatosComboBox(119).NombreCampo = "DTD_CARGO_ABONO_AFE"
        vArrayDatosComboBox(119).Longitud = 7
        vArrayDatosComboBox(119).Tipo = "varchar"
        vArrayDatosComboBox(119).ParteEntera = 0
        vArrayDatosComboBox(119).ParteDecimal = 0
        ReDim vArrayDatosComboBox(119).Valores(0, 0)
        vArrayDatosComboBox(119).Ancho = 79
        vArrayDatosComboBox(119).Flag = False

        vArrayDatosComboBox(120).NombreCampo = "DTD_SIGNO_AFE"
        vArrayDatosComboBox(120).Longitud = 1
        vArrayDatosComboBox(120).Tipo = "varchar"
        vArrayDatosComboBox(120).ParteEntera = 0
        vArrayDatosComboBox(120).ParteDecimal = 0
        ReDim vArrayDatosComboBox(120).Valores(0, 0)
        vArrayDatosComboBox(120).Ancho = 15
        vArrayDatosComboBox(120).Flag = False

        vArrayDatosComboBox(121).NombreCampo = "DTD_SIGNO_D_AFE"
        vArrayDatosComboBox(121).Longitud = 1
        vArrayDatosComboBox(121).Tipo = "varchar"
        vArrayDatosComboBox(121).ParteEntera = 0
        vArrayDatosComboBox(121).ParteDecimal = 0
        ReDim vArrayDatosComboBox(121).Valores(0, 0)
        vArrayDatosComboBox(121).Ancho = 15
        vArrayDatosComboBox(121).Flag = False

        vArrayDatosComboBox(122).NombreCampo = "DOC_SERIE_AFE"
        vArrayDatosComboBox(122).Longitud = 3
        vArrayDatosComboBox(122).Tipo = "char"
        vArrayDatosComboBox(122).ParteEntera = 0
        vArrayDatosComboBox(122).ParteDecimal = 0
        ReDim vArrayDatosComboBox(122).Valores(0, 0)
        vArrayDatosComboBox(122).Ancho = 36
        vArrayDatosComboBox(122).Flag = False

        vArrayDatosComboBox(123).NombreCampo = "DOC_NUMERO_AFE"
        vArrayDatosComboBox(123).Longitud = 10
        vArrayDatosComboBox(123).Tipo = "varchar"
        vArrayDatosComboBox(123).ParteEntera = 0
        vArrayDatosComboBox(123).ParteDecimal = 0
        ReDim vArrayDatosComboBox(123).Valores(0, 0)
        vArrayDatosComboBox(123).Ancho = 111
        vArrayDatosComboBox(123).Flag = False

        vArrayDatosComboBox(124).NombreCampo = "DOC_MOT_EMI"
        vArrayDatosComboBox(124).Longitud = 12
        vArrayDatosComboBox(124).Tipo = "varchar"
        vArrayDatosComboBox(124).ParteEntera = 0
        vArrayDatosComboBox(124).ParteDecimal = 0
        ReDim vArrayDatosComboBox(124).Valores(5, 1)
        vArrayDatosComboBox(124).Valores(0, 0) = "ANULACION"
        vArrayDatosComboBox(124).Valores(0, 1) = "0"
        vArrayDatosComboBox(124).Valores(1, 0) = "BONIFICACION"
        vArrayDatosComboBox(124).Valores(1, 1) = "1"
        vArrayDatosComboBox(124).Valores(2, 0) = "DESCUENTO"
        vArrayDatosComboBox(124).Valores(2, 1) = "2"
        vArrayDatosComboBox(124).Valores(3, 0) = "DEVOLUCIONES"
        vArrayDatosComboBox(124).Valores(3, 1) = "3"
        vArrayDatosComboBox(124).Valores(4, 0) = "OTROS"
        vArrayDatosComboBox(124).Valores(4, 1) = "4"
        vArrayDatosComboBox(124).Valores(5, 0) = "DESC. ESPEC."
        vArrayDatosComboBox(124).Valores(5, 1) = "5"
        vArrayDatosComboBox(124).Ancho = 113
        vArrayDatosComboBox(124).Flag = True

        vArrayDatosComboBox(125).NombreCampo = "DOC_NOMBRE_RECEP"
        vArrayDatosComboBox(125).Longitud = 25
        vArrayDatosComboBox(125).Tipo = "varchar"
        vArrayDatosComboBox(125).ParteEntera = 0
        vArrayDatosComboBox(125).ParteDecimal = 0
        ReDim vArrayDatosComboBox(125).Valores(0, 0)
        vArrayDatosComboBox(125).Ancho = 272
        vArrayDatosComboBox(125).Flag = False

        vArrayDatosComboBox(126).NombreCampo = "DOC_DNI_RECEP"
        vArrayDatosComboBox(126).Longitud = 8
        vArrayDatosComboBox(126).Tipo = "char"
        vArrayDatosComboBox(126).ParteEntera = 0
        vArrayDatosComboBox(126).ParteDecimal = 0
        ReDim vArrayDatosComboBox(126).Valores(0, 0)
        vArrayDatosComboBox(126).Ancho = 90
        vArrayDatosComboBox(126).Flag = False

        vArrayDatosComboBox(127).NombreCampo = "DOC_FEC_RECEP"
        vArrayDatosComboBox(127).Longitud = 0
        vArrayDatosComboBox(127).Tipo = "smalldatetime"
        vArrayDatosComboBox(127).ParteEntera = 0
        vArrayDatosComboBox(127).ParteDecimal = 0
        ReDim vArrayDatosComboBox(127).Valores(0, 0)
        vArrayDatosComboBox(127).Ancho = 15
        vArrayDatosComboBox(127).Flag = False

        vArrayDatosComboBox(128).NombreCampo = "DOC_ENTREGADO"
        vArrayDatosComboBox(128).Longitud = 2
        vArrayDatosComboBox(128).Tipo = "varchar"
        vArrayDatosComboBox(128).ParteEntera = 0
        vArrayDatosComboBox(128).ParteDecimal = 0
        ReDim vArrayDatosComboBox(128).Valores(1, 1)
        vArrayDatosComboBox(128).Valores(0, 0) = "NO"
        vArrayDatosComboBox(128).Valores(0, 1) = "0"
        vArrayDatosComboBox(128).Valores(1, 0) = "SI"
        vArrayDatosComboBox(128).Valores(1, 1) = "1"
        vArrayDatosComboBox(128).Ancho = 40
        vArrayDatosComboBox(128).Flag = True

        vArrayDatosComboBox(129).NombreCampo = "CAF_IX_NUMERO_PRO"
        vArrayDatosComboBox(129).Longitud = 25
        vArrayDatosComboBox(129).Tipo = "varchar"
        vArrayDatosComboBox(129).ParteEntera = 0
        vArrayDatosComboBox(129).ParteDecimal = 0
        ReDim vArrayDatosComboBox(129).Valores(0, 0)
        vArrayDatosComboBox(129).Ancho = 272
        vArrayDatosComboBox(129).Flag = False

        vArrayDatosComboBox(130).NombreCampo = "CAF_IX_ORDEN_COM"
        vArrayDatosComboBox(130).Longitud = 25
        vArrayDatosComboBox(130).Tipo = "varchar"
        vArrayDatosComboBox(130).ParteEntera = 0
        vArrayDatosComboBox(130).ParteDecimal = 0
        ReDim vArrayDatosComboBox(130).Valores(0, 0)
        vArrayDatosComboBox(130).Ancho = 272
        vArrayDatosComboBox(130).Flag = False

        vArrayDatosComboBox(131).NombreCampo = "LPR_ID"
        vArrayDatosComboBox(131).Longitud = 3
        vArrayDatosComboBox(131).Tipo = "char"
        vArrayDatosComboBox(131).ParteEntera = 0
        vArrayDatosComboBox(131).ParteDecimal = 0
        ReDim vArrayDatosComboBox(131).Valores(0, 0)
        vArrayDatosComboBox(131).Ancho = 36
        vArrayDatosComboBox(131).Flag = False

        vArrayDatosComboBox(132).NombreCampo = "LPR_DESCRIPCION"
        vArrayDatosComboBox(132).Longitud = 45
        vArrayDatosComboBox(132).Tipo = "varchar"
        vArrayDatosComboBox(132).ParteEntera = 0
        vArrayDatosComboBox(132).ParteDecimal = 0
        ReDim vArrayDatosComboBox(132).Valores(0, 0)
        vArrayDatosComboBox(132).Ancho = 485
        vArrayDatosComboBox(132).Flag = False

        vArrayDatosComboBox(133).NombreCampo = "DOC_ESTADO"
        vArrayDatosComboBox(133).Longitud = 12
        vArrayDatosComboBox(133).Tipo = "varchar"
        vArrayDatosComboBox(133).ParteEntera = 0
        vArrayDatosComboBox(133).ParteDecimal = 0
        ReDim vArrayDatosComboBox(133).Valores(1, 1)
        vArrayDatosComboBox(133).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(133).Valores(0, 1) = "0"
        vArrayDatosComboBox(133).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(133).Valores(1, 1) = "1"
        vArrayDatosComboBox(133).Ancho = 85
        vArrayDatosComboBox(133).Flag = True

        vArrayDatosComboBox(134).NombreCampo = "DDO_ITEM"
        vArrayDatosComboBox(134).Longitud = 3
        vArrayDatosComboBox(134).Tipo = "numeric"
        vArrayDatosComboBox(134).ParteEntera = 3
        vArrayDatosComboBox(134).ParteDecimal = 0
        ReDim vArrayDatosComboBox(134).Valores(0, 0)
        vArrayDatosComboBox(134).Ancho = 36
        vArrayDatosComboBox(134).Flag = False

        vArrayDatosComboBox(135).NombreCampo = "ART_ID_IMP"
        vArrayDatosComboBox(135).Longitud = 6
        vArrayDatosComboBox(135).Tipo = "char"
        vArrayDatosComboBox(135).ParteEntera = 0
        vArrayDatosComboBox(135).ParteDecimal = 0
        ReDim vArrayDatosComboBox(135).Valores(0, 0)
        vArrayDatosComboBox(135).Ancho = 68
        vArrayDatosComboBox(135).Flag = False

        vArrayDatosComboBox(136).NombreCampo = "ART_DESCRIPCION_IMP"
        vArrayDatosComboBox(136).Longitud = 45
        vArrayDatosComboBox(136).Tipo = "varchar"
        vArrayDatosComboBox(136).ParteEntera = 0
        vArrayDatosComboBox(136).ParteDecimal = 0
        ReDim vArrayDatosComboBox(136).Valores(0, 0)
        vArrayDatosComboBox(136).Ancho = 485
        vArrayDatosComboBox(136).Flag = False

        vArrayDatosComboBox(137).NombreCampo = "UM_DESCRIPCION_IMP"
        vArrayDatosComboBox(137).Longitud = 45
        vArrayDatosComboBox(137).Tipo = "varchar"
        vArrayDatosComboBox(137).ParteEntera = 0
        vArrayDatosComboBox(137).ParteDecimal = 0
        ReDim vArrayDatosComboBox(137).Valores(0, 0)
        vArrayDatosComboBox(137).Ancho = 485
        vArrayDatosComboBox(137).Flag = False

        vArrayDatosComboBox(138).NombreCampo = "ART_ID_KAR"
        vArrayDatosComboBox(138).Longitud = 6
        vArrayDatosComboBox(138).Tipo = "char"
        vArrayDatosComboBox(138).ParteEntera = 0
        vArrayDatosComboBox(138).ParteDecimal = 0
        ReDim vArrayDatosComboBox(138).Valores(0, 0)
        vArrayDatosComboBox(138).Ancho = 68
        vArrayDatosComboBox(138).Flag = False

        vArrayDatosComboBox(139).NombreCampo = "ART_DESCRIPCION_KAR"
        vArrayDatosComboBox(139).Longitud = 45
        vArrayDatosComboBox(139).Tipo = "varchar"
        vArrayDatosComboBox(139).ParteEntera = 0
        vArrayDatosComboBox(139).ParteDecimal = 0
        ReDim vArrayDatosComboBox(139).Valores(0, 0)
        vArrayDatosComboBox(139).Ancho = 485
        vArrayDatosComboBox(139).Flag = False

        vArrayDatosComboBox(140).NombreCampo = "UM_DESCRIPCION_KAR"
        vArrayDatosComboBox(140).Longitud = 45
        vArrayDatosComboBox(140).Tipo = "varchar"
        vArrayDatosComboBox(140).ParteEntera = 0
        vArrayDatosComboBox(140).ParteDecimal = 0
        ReDim vArrayDatosComboBox(140).Valores(0, 0)
        vArrayDatosComboBox(140).Ancho = 485
        vArrayDatosComboBox(140).Flag = False

        vArrayDatosComboBox(141).NombreCampo = "DDO_ART_FACTOR"
        vArrayDatosComboBox(141).Longitud = 4
        vArrayDatosComboBox(141).Tipo = "numeric"
        vArrayDatosComboBox(141).ParteEntera = 2
        vArrayDatosComboBox(141).ParteDecimal = 2
        ReDim vArrayDatosComboBox(141).Valores(0, 0)
        vArrayDatosComboBox(141).Ancho = 47
        vArrayDatosComboBox(141).Flag = False

        vArrayDatosComboBox(142).NombreCampo = "DDO_CANTIDAD"
        vArrayDatosComboBox(142).Longitud = 18
        vArrayDatosComboBox(142).Tipo = "numeric"
        vArrayDatosComboBox(142).ParteEntera = 15
        vArrayDatosComboBox(142).ParteDecimal = 3
        ReDim vArrayDatosComboBox(142).Valores(0, 0)
        vArrayDatosComboBox(142).Ancho = 197
        vArrayDatosComboBox(142).Flag = False

        vArrayDatosComboBox(143).NombreCampo = "DDO_PRE_UNI"
        vArrayDatosComboBox(143).Longitud = 18
        vArrayDatosComboBox(143).Tipo = "numeric"
        vArrayDatosComboBox(143).ParteEntera = 14
        vArrayDatosComboBox(143).ParteDecimal = 4
        ReDim vArrayDatosComboBox(143).Valores(0, 0)
        vArrayDatosComboBox(143).Ancho = 197
        vArrayDatosComboBox(143).Flag = False

        vArrayDatosComboBox(144).NombreCampo = "DDO_DES_INC_PRE"
        vArrayDatosComboBox(144).Longitud = 18
        vArrayDatosComboBox(144).Tipo = "numeric"
        vArrayDatosComboBox(144).ParteEntera = 14
        vArrayDatosComboBox(144).ParteDecimal = 4
        ReDim vArrayDatosComboBox(144).Valores(0, 0)
        vArrayDatosComboBox(144).Ancho = 197
        vArrayDatosComboBox(144).Flag = False

        vArrayDatosComboBox(145).NombreCampo = "DDO_INC_IGV"
        vArrayDatosComboBox(145).Longitud = 5
        vArrayDatosComboBox(145).Tipo = "smallint"
        vArrayDatosComboBox(145).ParteEntera = 5
        vArrayDatosComboBox(145).ParteDecimal = 0
        ReDim vArrayDatosComboBox(145).Valores(2, 1)
        vArrayDatosComboBox(145).Valores(0, 0) = "NO INCLUYE IGV"
        vArrayDatosComboBox(145).Valores(0, 1) = "0"
        vArrayDatosComboBox(145).Valores(1, 0) = "SI INCLUYE IGV"
        vArrayDatosComboBox(145).Valores(1, 1) = "1"
        vArrayDatosComboBox(145).Valores(2, 0) = "NO GRABADO CON IGV"
        vArrayDatosComboBox(145).Valores(2, 1) = "2"
        vArrayDatosComboBox(145).Ancho = 151
        vArrayDatosComboBox(145).Flag = True

        vArrayDatosComboBox(146).NombreCampo = "DDO_IGV_POR"
        vArrayDatosComboBox(146).Longitud = 18
        vArrayDatosComboBox(146).Tipo = "numeric"
        vArrayDatosComboBox(146).ParteEntera = 14
        vArrayDatosComboBox(146).ParteDecimal = 4
        ReDim vArrayDatosComboBox(146).Valores(0, 0)
        vArrayDatosComboBox(146).Ancho = 197
        vArrayDatosComboBox(146).Flag = False

        vArrayDatosComboBox(147).NombreCampo = "DDO_MONTO_IGV"
        vArrayDatosComboBox(147).Longitud = 18
        vArrayDatosComboBox(147).Tipo = "numeric"
        vArrayDatosComboBox(147).ParteEntera = 14
        vArrayDatosComboBox(147).ParteDecimal = 4
        ReDim vArrayDatosComboBox(147).Valores(0, 0)
        vArrayDatosComboBox(147).Ancho = 197
        vArrayDatosComboBox(147).Flag = False

        vArrayDatosComboBox(148).NombreCampo = "DDO_PRE_TOTAL"
        vArrayDatosComboBox(148).Longitud = 18
        vArrayDatosComboBox(148).Tipo = "numeric"
        vArrayDatosComboBox(148).ParteEntera = 14
        vArrayDatosComboBox(148).ParteDecimal = 4
        ReDim vArrayDatosComboBox(148).Valores(0, 0)
        vArrayDatosComboBox(148).Ancho = 197
        vArrayDatosComboBox(148).Flag = False

        vArrayDatosComboBox(149).NombreCampo = "DDO_OBS_DSC_ART"
        vArrayDatosComboBox(149).Longitud = 50
        vArrayDatosComboBox(149).Tipo = "varchar"
        vArrayDatosComboBox(149).ParteEntera = 0
        vArrayDatosComboBox(149).ParteDecimal = 0
        ReDim vArrayDatosComboBox(149).Valores(0, 0)
        vArrayDatosComboBox(149).Ancho = 539
        vArrayDatosComboBox(149).Flag = False

        vArrayDatosComboBox(150).NombreCampo = "TDO_ID_ANT"
        vArrayDatosComboBox(150).Longitud = 3
        vArrayDatosComboBox(150).Tipo = "char"
        vArrayDatosComboBox(150).ParteEntera = 0
        vArrayDatosComboBox(150).ParteDecimal = 0
        ReDim vArrayDatosComboBox(150).Valores(0, 0)
        vArrayDatosComboBox(150).Ancho = 36
        vArrayDatosComboBox(150).Flag = False

        vArrayDatosComboBox(151).NombreCampo = "TDO_DESCRIPCION_ANT"
        vArrayDatosComboBox(151).Longitud = 45
        vArrayDatosComboBox(151).Tipo = "varchar"
        vArrayDatosComboBox(151).ParteEntera = 0
        vArrayDatosComboBox(151).ParteDecimal = 0
        ReDim vArrayDatosComboBox(151).Valores(0, 0)
        vArrayDatosComboBox(151).Ancho = 485
        vArrayDatosComboBox(151).Flag = False

        vArrayDatosComboBox(152).NombreCampo = "DTD_ID_ANT"
        vArrayDatosComboBox(152).Longitud = 3
        vArrayDatosComboBox(152).Tipo = "char"
        vArrayDatosComboBox(152).ParteEntera = 0
        vArrayDatosComboBox(152).ParteDecimal = 0
        ReDim vArrayDatosComboBox(152).Valores(0, 0)
        vArrayDatosComboBox(152).Ancho = 36
        vArrayDatosComboBox(152).Flag = False

        vArrayDatosComboBox(153).NombreCampo = "DTD_DESCRIPCION_ANT"
        vArrayDatosComboBox(153).Longitud = 45
        vArrayDatosComboBox(153).Tipo = "varchar"
        vArrayDatosComboBox(153).ParteEntera = 0
        vArrayDatosComboBox(153).ParteDecimal = 0
        ReDim vArrayDatosComboBox(153).Valores(0, 0)
        vArrayDatosComboBox(153).Ancho = 485
        vArrayDatosComboBox(153).Flag = False

        vArrayDatosComboBox(154).NombreCampo = "CCT_ID_ANT"
        vArrayDatosComboBox(154).Longitud = 3
        vArrayDatosComboBox(154).Tipo = "char"
        vArrayDatosComboBox(154).ParteEntera = 0
        vArrayDatosComboBox(154).ParteDecimal = 0
        ReDim vArrayDatosComboBox(154).Valores(0, 0)
        vArrayDatosComboBox(154).Ancho = 36
        vArrayDatosComboBox(154).Flag = False

        vArrayDatosComboBox(155).NombreCampo = "CCT_DESCRIPCION_ANT"
        vArrayDatosComboBox(155).Longitud = 45
        vArrayDatosComboBox(155).Tipo = "varchar"
        vArrayDatosComboBox(155).ParteEntera = 0
        vArrayDatosComboBox(155).ParteDecimal = 0
        ReDim vArrayDatosComboBox(155).Valores(0, 0)
        vArrayDatosComboBox(155).Ancho = 485
        vArrayDatosComboBox(155).Flag = False

        vArrayDatosComboBox(156).NombreCampo = "DTD_CARGO_ABONO_ANT"
        vArrayDatosComboBox(156).Longitud = 7
        vArrayDatosComboBox(156).Tipo = "varchar"
        vArrayDatosComboBox(156).ParteEntera = 0
        vArrayDatosComboBox(156).ParteDecimal = 0
        ReDim vArrayDatosComboBox(156).Valores(0, 0)
        vArrayDatosComboBox(156).Ancho = 79
        vArrayDatosComboBox(156).Flag = False

        vArrayDatosComboBox(157).NombreCampo = "DTD_SIGNO_ANT"
        vArrayDatosComboBox(157).Longitud = 1
        vArrayDatosComboBox(157).Tipo = "varchar"
        vArrayDatosComboBox(157).ParteEntera = 0
        vArrayDatosComboBox(157).ParteDecimal = 0
        ReDim vArrayDatosComboBox(157).Valores(0, 0)
        vArrayDatosComboBox(157).Ancho = 15
        vArrayDatosComboBox(157).Flag = False

        vArrayDatosComboBox(158).NombreCampo = "DTD_SIGNO_D_ANT"
        vArrayDatosComboBox(158).Longitud = 1
        vArrayDatosComboBox(158).Tipo = "varchar"
        vArrayDatosComboBox(158).ParteEntera = 0
        vArrayDatosComboBox(158).ParteDecimal = 0
        ReDim vArrayDatosComboBox(158).Valores(0, 0)
        vArrayDatosComboBox(158).Ancho = 15
        vArrayDatosComboBox(158).Flag = False

        vArrayDatosComboBox(159).NombreCampo = "DDO_SERIE_ANT"
        vArrayDatosComboBox(159).Longitud = 3
        vArrayDatosComboBox(159).Tipo = "char"
        vArrayDatosComboBox(159).ParteEntera = 0
        vArrayDatosComboBox(159).ParteDecimal = 0
        ReDim vArrayDatosComboBox(159).Valores(0, 0)
        vArrayDatosComboBox(159).Ancho = 36
        vArrayDatosComboBox(159).Flag = False

        vArrayDatosComboBox(160).NombreCampo = "DDO_NUMERO_ANT"
        vArrayDatosComboBox(160).Longitud = 10
        vArrayDatosComboBox(160).Tipo = "varchar"
        vArrayDatosComboBox(160).ParteEntera = 0
        vArrayDatosComboBox(160).ParteDecimal = 0
        ReDim vArrayDatosComboBox(160).Valores(0, 0)
        vArrayDatosComboBox(160).Ancho = 111
        vArrayDatosComboBox(160).Flag = False

        vArrayDatosComboBox(161).NombreCampo = "TIV_DIAS"
        vArrayDatosComboBox(161).Longitud = 5
        vArrayDatosComboBox(161).Tipo = "smallint"
        vArrayDatosComboBox(161).ParteEntera = 5
        vArrayDatosComboBox(161).ParteDecimal = 0
        ReDim vArrayDatosComboBox(161).Valores(0, 0)
        vArrayDatosComboBox(161).Ancho = 58
        vArrayDatosComboBox(161).Flag = False

        vArrayDatosComboBox(162).NombreCampo = "ART_AFE_PER"
        vArrayDatosComboBox(162).Longitud = 0
        vArrayDatosComboBox(162).Tipo = "bit"
        vArrayDatosComboBox(162).ParteEntera = 0
        vArrayDatosComboBox(162).ParteDecimal = 0
        ReDim vArrayDatosComboBox(162).Valores(1, 1)
        vArrayDatosComboBox(162).Valores(0, 0) = "NO PERCEPCION"
        vArrayDatosComboBox(162).Valores(0, 1) = "0"
        vArrayDatosComboBox(162).Valores(1, 0) = "SI PERCEPCION"
        vArrayDatosComboBox(162).Valores(1, 1) = "1"
        vArrayDatosComboBox(162).Ancho = 85
        vArrayDatosComboBox(162).Flag = True

        vArrayDatosComboBox(163).NombreCampo = "DDO_ESTADO"
        vArrayDatosComboBox(163).Longitud = 0
        vArrayDatosComboBox(163).Tipo = "bit"
        vArrayDatosComboBox(163).ParteEntera = 0
        vArrayDatosComboBox(163).ParteDecimal = 0
        ReDim vArrayDatosComboBox(163).Valores(1, 1)
        vArrayDatosComboBox(163).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(163).Valores(0, 1) = "0"
        vArrayDatosComboBox(163).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(163).Valores(1, 1) = "1"
        vArrayDatosComboBox(163).Ancho = 85
        vArrayDatosComboBox(163).Flag = True
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

                Case "DDO_SERIE"
                    If Len(DDO_SERIE.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_NUMERO"
                    If Len(DDO_NUMERO.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_ITEM"
                    If DDO_ITEM.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & ", Item"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "ART_ID_IMP"
                    If Len(ART_ID_IMP.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "ART_ID_KAR"
                    If Len(ART_ID_KAR.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_ART_FACTOR"
                    If DDO_ART_FACTOR.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & ", Factor del artículo"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_CANTIDAD"
                    If DDO_CANTIDAD <> 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & ", Cantidad"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_INC_IGV"
                    If DDO_INC_IGV >= 0 And DDO_INC_IGV <= 2 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & ", Incluye IGV"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_DES_INC_PRE"
                    If DDO_DES_INC_PRE.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & ", Desc./Inc."
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_PRE_UNI"
                    If DDO_PRE_UNI.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & ", Precio unitario"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_IGV_POR"
                    If DDO_IGV_POR.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & ", Porcentaj IGV"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_MONTO_IGV"
                    If DDO_MONTO_IGV.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & ", Monto Igv"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_PRE_TOTAL"
                    If DDO_PRE_TOTAL.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & ", Precio total"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDO_OBS_DSC_ART"
                    If IsNothing(DDO_OBS_DSC_ART) Then
                    Else
                        If DDO_OBS_DSC_ART.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato & ", Obervaciones"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "TDO_ID_ANT"
                    If IsNothing(TDO_ID_ANT) Then
                    Else
                        If Len(TDO_ID_ANT.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTD_ID_ANT"
                    If IsNothing(DTD_ID_ANT) Then
                    Else
                        If Len(DTD_ID_ANT.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "CCT_ID_ANT"
                    If IsNothing(CCT_ID_ANT) Then
                    Else
                        If Len(CCT_ID_ANT.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DDO_SERIE_ANT"
                    If IsNothing(DDO_SERIE_ANT) Then
                    Else
                        If Len(DDO_SERIE_ANT.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DDO_NUMERO_ANT"
                    If IsNothing(DDO_NUMERO_ANT) Then
                    Else
                        If DDO_NUMERO_ANT.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato & ",  Número de anticipo"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "ART_AFE_PER"
                    If ART_AFE_PER.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "DDO_FEC_GRAB"
                    If DDO_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "DDO_ESTADO"
                    If DDO_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaDetalleDocumentosXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetalleDocumentosXML"
        End If
        If Vista = "BuscarCorrelativos" Then
            SentenciaSqlBusqueda = "spVistaCorrelativoSerieXML"
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
                oVerificarDatos = VerificarDatos("TDO_ID", "DTD_ID", "DDO_SERIE", "DDO_NUMERO", "DDO_ITEM", "ART_ID_IMP", "ART_ID_KAR", "DDO_ART_FACTOR", "DDO_CANTIDAD", "DDO_INC_IGV", "DDO_DES_INC_PRE", "DDO_PRE_UNI", "DDO_IGV_POR", "DDO_MONTO_IGV", "DDO_PRE_TOTAL", "DDO_OBS_DSC_ART", "TDO_ID_ANT", "DTD_ID_ANT", "CCT_ID_ANT", "DDO_SERIE_ANT", "DDO_NUMERO_ANT", "ART_AFE_PER", "USU_ID", "DDO_FEC_GRAB", "DDO_ESTADO")
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

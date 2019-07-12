Imports Ladisac.BE
Partial Public Class DetalleTesoreria
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 6
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "TDO_ID"
    Public CampoPrincipalSecundario = "CCC_ID"
    Public CampoPrincipalTercero = "DTE_SERIE"
    Public CampoPrincipalCuarto = "DTE_NUMERO"
    Public CampoPrincipalQuinto = "DTD_ID"
    Public CampoPrincipalSexto = "DTE_ITEM"
    Public CampoPrincipalValor = TDO_ID
    Public CampoPrincipalSecundarioValor = CCC_ID
    Public CampoPrincipalTerceroValor = DTE_SERIE
    Public CampoPrincipalCuartoValor = DTE_NUMERO
    Public CampoPrincipalQuintoValor = DTD_ID
    Public CampoPrincipalSextoValor = DTE_ITEM
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Tes.DetalleTesoreria"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetalleTesoreria"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetalleTesoreria"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetalleTesoreria"
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
        vElementosDatosComboBox = 88
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "DTE_ITEM"
        vArrayCamposBusqueda(1) = "CCC_ID"
        vArrayCamposBusqueda(2) = "CCC_DESCRIPCION"
        vArrayCamposBusqueda(3) = "PER_ID_CAJ"
        vArrayCamposBusqueda(4) = "PER_DESCRIPCION_CAJ"
        vArrayCamposBusqueda(5) = "PVE_ID"
        vArrayCamposBusqueda(6) = "PVE_DESCRIPCION"
        vArrayCamposBusqueda(7) = "TES_FECHA_EMI"
        vArrayCamposBusqueda(8) = "CCT_ID"
        vArrayCamposBusqueda(9) = "CCT_DESCRIPCION"
        vArrayCamposBusqueda(10) = "TDO_ID"
        vArrayCamposBusqueda(11) = "TDO_DESCRIPCION"
        vArrayCamposBusqueda(12) = "DTD_ID"
        vArrayCamposBusqueda(13) = "DTD_DESCRIPCION"
        vArrayCamposBusqueda(14) = "TES_SERIE"
        vArrayCamposBusqueda(15) = "TES_NUMERO"
        vArrayCamposBusqueda(16) = "DTD_CARGO_ABONO"
        vArrayCamposBusqueda(17) = "DTD_SIGNO"
        vArrayCamposBusqueda(18) = "DTD_SIGNO_D"
        vArrayCamposBusqueda(19) = "DTD_SIGNO_D_1"
        vArrayCamposBusqueda(20) = "TES_MONTO_TOTAL"
        vArrayCamposBusqueda(21) = "MON_ID_CCC"
        vArrayCamposBusqueda(22) = "MON_DESCRIPCION_CCC"
        vArrayCamposBusqueda(23) = "CCC_ID_CLI"
        vArrayCamposBusqueda(24) = "CCC_DESCRIPCION_CLI"
        vArrayCamposBusqueda(25) = "PER_ID_CLI"
        vArrayCamposBusqueda(26) = "PER_DESCRIPCION_CLI"
        vArrayCamposBusqueda(27) = "DTE_FEC_VEN"
        vArrayCamposBusqueda(28) = "DTD_MOVIMIENTO_DOC"
        vArrayCamposBusqueda(29) = "CCT_ID_DOC"
        vArrayCamposBusqueda(30) = "CCT_DESCRIPCION_DOC"
        vArrayCamposBusqueda(31) = "TDO_ID_DOC"
        vArrayCamposBusqueda(32) = "TDO_DESCRIPCION_DOC"
        vArrayCamposBusqueda(33) = "DTD_ID_DOC"
        vArrayCamposBusqueda(34) = "DTD_DESCRIPCION_DOC"
        vArrayCamposBusqueda(35) = "DTE_SERIE_DOC"
        vArrayCamposBusqueda(36) = "DTE_NUMERO_DOC"
        vArrayCamposBusqueda(37) = "DTD_CARGO_ABONO_DOC"
        vArrayCamposBusqueda(38) = "DTD_SIGNO_DOC"
        vArrayCamposBusqueda(39) = "DTD_SIGNO_D_DOC"
        vArrayCamposBusqueda(40) = "DTD_SIGNO_D_1_DOC"
        vArrayCamposBusqueda(41) = "DTE_IMPORTE_DOC"
        vArrayCamposBusqueda(42) = "DTE_CONTRAVALOR_DOC"
        vArrayCamposBusqueda(43) = "MON_ID_DOC"
        vArrayCamposBusqueda(44) = "MON_DESCRIPCION_DOC"
        vArrayCamposBusqueda(45) = "DTE_DESTINO"
        vArrayCamposBusqueda(46) = "CHE_ID"
        vArrayCamposBusqueda(47) = "MPT_MEDIO_PAGO"
        vArrayCamposBusqueda(48) = "MPT_IMPORTE_AFECTO"
        vArrayCamposBusqueda(49) = "MPT_PORCENTAJE"
        vArrayCamposBusqueda(50) = "MPT_SERIE_MEDIO"
        vArrayCamposBusqueda(51) = "MPT_NUMERO_MEDIO"
        vArrayCamposBusqueda(52) = "MPT_GIRADO_A"
        vArrayCamposBusqueda(53) = "MPT_CONCEPTO"
        vArrayCamposBusqueda(54) = "PER_ID_BAN"
        vArrayCamposBusqueda(55) = "PER_DESCRIPCION_BAN"
        vArrayCamposBusqueda(56) = "MPT_DIFERIDO"
        vArrayCamposBusqueda(57) = "MPT_FECHA_DIFERIDO"
        vArrayCamposBusqueda(58) = "MPT_RECEPCION"
        vArrayCamposBusqueda(59) = "MPT_UBICACION"
        vArrayCamposBusqueda(60) = "PER_ID_CLI_1"
        vArrayCamposBusqueda(61) = "PER_DESCRIPCION_CLI_1"
        vArrayCamposBusqueda(62) = "DTE_FEC_VEN_1"
        vArrayCamposBusqueda(63) = "CCT_ID_DOC_1"
        vArrayCamposBusqueda(64) = "CCT_DESCRIPCION_DOC_1"
        vArrayCamposBusqueda(65) = "TDO_ID_DOC_1"
        vArrayCamposBusqueda(66) = "TDO_DESCRIPCION_DOC_1"
        vArrayCamposBusqueda(67) = "DTD_ID_DOC_1"
        vArrayCamposBusqueda(68) = "DTD_DESCRIPCION_DOC_1"
        vArrayCamposBusqueda(69) = "DTE_SERIE_DOC_1"
        vArrayCamposBusqueda(70) = "DTE_NUMERO_DOC_1"
        vArrayCamposBusqueda(71) = "DTD_CARGO_ABONO_DOC_1"
        vArrayCamposBusqueda(72) = "DTD_SIGNO_DOC_1"
        vArrayCamposBusqueda(73) = "DTD_SIGNO_D_DOC_1"
        vArrayCamposBusqueda(74) = "DTD_SIGNO_D_1_DOC_1"
        vArrayCamposBusqueda(75) = "DTE_IMPORTE_DOC_1"
        vArrayCamposBusqueda(76) = "DTE_CONTRAVALOR_DOC_1"
        vArrayCamposBusqueda(77) = "MON_ID_DOC_1"
        vArrayCamposBusqueda(78) = "MON_DESCRIPCION_DOC_1"
        vArrayCamposBusqueda(79) = "CCO_ID"
        vArrayCamposBusqueda(80) = "CCO_DESCRIPCION"
        vArrayCamposBusqueda(81) = "CUC_ID"
        vArrayCamposBusqueda(82) = "CUC_DESCRIPCION"
        vArrayCamposBusqueda(83) = "DTE_OPE_CONTABLE"
        vArrayCamposBusqueda(84) = "DTE_OBSERVACIONES"
        vArrayCamposBusqueda(85) = "DTE_MOVIMIENTO"
        vArrayCamposBusqueda(86) = "MPT_ESTADO"
        vArrayCamposBusqueda(87) = "DTE_ESTADO"
        vArrayCamposBusqueda(88) = "TES_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "DTE_ITEM"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "numeric"
        vArrayDatosComboBox(0).ParteEntera = 3
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "CCC_ID"
        vArrayDatosComboBox(1).Longitud = 3
        vArrayDatosComboBox(1).Tipo = "char"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 36
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "CCC_DESCRIPCION"
        vArrayDatosComboBox(2).Longitud = 189
        vArrayDatosComboBox(2).Tipo = "varchar"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 2025
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PER_ID_CAJ"
        vArrayDatosComboBox(3).Longitud = 6
        vArrayDatosComboBox(3).Tipo = "char"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 68
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PER_DESCRIPCION_CAJ"
        vArrayDatosComboBox(4).Longitud = 77
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 828
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "PVE_ID"
        vArrayDatosComboBox(5).Longitud = 3
        vArrayDatosComboBox(5).Tipo = "char"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 36
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "PVE_DESCRIPCION"
        vArrayDatosComboBox(6).Longitud = 45
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 485
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "TES_FECHA_EMI"
        vArrayDatosComboBox(7).Longitud = 0
        vArrayDatosComboBox(7).Tipo = "smalldatetime"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 15
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "CCT_ID"
        vArrayDatosComboBox(8).Longitud = 3
        vArrayDatosComboBox(8).Tipo = "char"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 36
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "CCT_DESCRIPCION"
        vArrayDatosComboBox(9).Longitud = 45
        vArrayDatosComboBox(9).Tipo = "varchar"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 485
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "TDO_ID"
        vArrayDatosComboBox(10).Longitud = 3
        vArrayDatosComboBox(10).Tipo = "char"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 36
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "TDO_DESCRIPCION"
        vArrayDatosComboBox(11).Longitud = 45
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 485
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "DTD_ID"
        vArrayDatosComboBox(12).Longitud = 3
        vArrayDatosComboBox(12).Tipo = "char"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 36
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "DTD_DESCRIPCION"
        vArrayDatosComboBox(13).Longitud = 45
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 485
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "TES_SERIE"
        vArrayDatosComboBox(14).Longitud = 3
        vArrayDatosComboBox(14).Tipo = "char"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 36
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "TES_NUMERO"
        vArrayDatosComboBox(15).Longitud = 10
        vArrayDatosComboBox(15).Tipo = "char"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 111
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "DTD_CARGO_ABONO"
        vArrayDatosComboBox(16).Longitud = 7
        vArrayDatosComboBox(16).Tipo = "varchar"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(2, 1)
        vArrayDatosComboBox(16).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(16).Valores(0, 1) = "0"
        vArrayDatosComboBox(16).Valores(1, 0) = "CARGO"
        vArrayDatosComboBox(16).Valores(1, 1) = "1"
        vArrayDatosComboBox(16).Valores(2, 0) = "ABONO"
        vArrayDatosComboBox(16).Valores(2, 1) = "2"
        vArrayDatosComboBox(16).Ancho = 77
        vArrayDatosComboBox(16).Flag = True

        vArrayDatosComboBox(17).NombreCampo = "DTD_SIGNO"
        vArrayDatosComboBox(17).Longitud = 1
        vArrayDatosComboBox(17).Tipo = "varchar"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(1, 1)
        vArrayDatosComboBox(17).Valores(0, 0) = "+"
        vArrayDatosComboBox(17).Valores(0, 1) = "0"
        vArrayDatosComboBox(17).Valores(1, 0) = "-"
        vArrayDatosComboBox(17).Valores(1, 1) = "1"
        vArrayDatosComboBox(17).Ancho = 30
        vArrayDatosComboBox(17).Flag = True

        vArrayDatosComboBox(18).NombreCampo = "DTD_SIGNO_D"
        vArrayDatosComboBox(18).Longitud = 1
        vArrayDatosComboBox(18).Tipo = "varchar"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(1, 1)
        vArrayDatosComboBox(18).Valores(0, 0) = "+"
        vArrayDatosComboBox(18).Valores(0, 1) = "0"
        vArrayDatosComboBox(18).Valores(1, 0) = "-"
        vArrayDatosComboBox(18).Valores(1, 1) = "1"
        vArrayDatosComboBox(18).Ancho = 30
        vArrayDatosComboBox(18).Flag = True

        vArrayDatosComboBox(19).NombreCampo = "DTD_SIGNO_D_1"
        vArrayDatosComboBox(19).Longitud = 1
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(1, 1)
        vArrayDatosComboBox(19).Valores(0, 0) = "+"
        vArrayDatosComboBox(19).Valores(0, 1) = "0"
        vArrayDatosComboBox(19).Valores(1, 0) = "-"
        vArrayDatosComboBox(19).Valores(1, 1) = "1"
        vArrayDatosComboBox(19).Ancho = 30
        vArrayDatosComboBox(19).Flag = True

        vArrayDatosComboBox(20).NombreCampo = "TES_MONTO_TOTAL"
        vArrayDatosComboBox(20).Longitud = 18
        vArrayDatosComboBox(20).Tipo = "numeric"
        vArrayDatosComboBox(20).ParteEntera = 14
        vArrayDatosComboBox(20).ParteDecimal = 4
        ReDim vArrayDatosComboBox(20).Valores(0, 0)
        vArrayDatosComboBox(20).Ancho = 197
        vArrayDatosComboBox(20).Flag = False

        vArrayDatosComboBox(21).NombreCampo = "MON_ID_CCC"
        vArrayDatosComboBox(21).Longitud = 3
        vArrayDatosComboBox(21).Tipo = "char"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(0, 0)
        vArrayDatosComboBox(21).Ancho = 36
        vArrayDatosComboBox(21).Flag = False

        vArrayDatosComboBox(22).NombreCampo = "MON_DESCRIPCION_CCC"
        vArrayDatosComboBox(22).Longitud = 45
        vArrayDatosComboBox(22).Tipo = "varchar"
        vArrayDatosComboBox(22).ParteEntera = 0
        vArrayDatosComboBox(22).ParteDecimal = 0
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 485
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "CCC_ID_CLI"
        vArrayDatosComboBox(23).Longitud = 3
        vArrayDatosComboBox(23).Tipo = "char"
        vArrayDatosComboBox(23).ParteEntera = 0
        vArrayDatosComboBox(23).ParteDecimal = 0
        ReDim vArrayDatosComboBox(23).Valores(0, 0)
        vArrayDatosComboBox(23).Ancho = 36
        vArrayDatosComboBox(23).Flag = False

        vArrayDatosComboBox(24).NombreCampo = "CCC_DESCRIPCION_CLI"
        vArrayDatosComboBox(24).Longitud = 189
        vArrayDatosComboBox(24).Tipo = "varchar"
        vArrayDatosComboBox(24).ParteEntera = 0
        vArrayDatosComboBox(24).ParteDecimal = 0
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 2025
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "PER_ID_CLI"
        vArrayDatosComboBox(25).Longitud = 6
        vArrayDatosComboBox(25).Tipo = "char"
        vArrayDatosComboBox(25).ParteEntera = 0
        vArrayDatosComboBox(25).ParteDecimal = 0
        ReDim vArrayDatosComboBox(25).Valores(0, 0)
        vArrayDatosComboBox(25).Ancho = 68
        vArrayDatosComboBox(25).Flag = False

        vArrayDatosComboBox(26).NombreCampo = "PER_DESCRIPCION_CLI"
        vArrayDatosComboBox(26).Longitud = 77
        vArrayDatosComboBox(26).Tipo = "varchar"
        vArrayDatosComboBox(26).ParteEntera = 0
        vArrayDatosComboBox(26).ParteDecimal = 0
        ReDim vArrayDatosComboBox(26).Valores(0, 0)
        vArrayDatosComboBox(26).Ancho = 828
        vArrayDatosComboBox(26).Flag = False

        vArrayDatosComboBox(27).NombreCampo = "DTE_FEC_VEN"
        vArrayDatosComboBox(27).Longitud = 0
        vArrayDatosComboBox(27).Tipo = "smalldatetime"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(0, 0)
        vArrayDatosComboBox(27).Ancho = 15
        vArrayDatosComboBox(27).Flag = False

        vArrayDatosComboBox(28).NombreCampo = "DTD_MOVIMIENTO_DOC"
        vArrayDatosComboBox(28).Longitud = 32
        vArrayDatosComboBox(28).Tipo = "varchar"
        vArrayDatosComboBox(28).ParteEntera = 0
        vArrayDatosComboBox(28).ParteDecimal = 0
        ReDim vArrayDatosComboBox(28).Valores(0, 0)
        vArrayDatosComboBox(28).Ancho = 346
        vArrayDatosComboBox(28).Flag = False

        vArrayDatosComboBox(29).NombreCampo = "CCT_ID_DOC"
        vArrayDatosComboBox(29).Longitud = 3
        vArrayDatosComboBox(29).Tipo = "char"
        vArrayDatosComboBox(29).ParteEntera = 0
        vArrayDatosComboBox(29).ParteDecimal = 0
        ReDim vArrayDatosComboBox(29).Valores(0, 0)
        vArrayDatosComboBox(29).Ancho = 36
        vArrayDatosComboBox(29).Flag = False

        vArrayDatosComboBox(30).NombreCampo = "CCT_DESCRIPCION_DOC"
        vArrayDatosComboBox(30).Longitud = 45
        vArrayDatosComboBox(30).Tipo = "varchar"
        vArrayDatosComboBox(30).ParteEntera = 0
        vArrayDatosComboBox(30).ParteDecimal = 0
        ReDim vArrayDatosComboBox(30).Valores(0, 0)
        vArrayDatosComboBox(30).Ancho = 485
        vArrayDatosComboBox(30).Flag = False

        vArrayDatosComboBox(31).NombreCampo = "TDO_ID_DOC"
        vArrayDatosComboBox(31).Longitud = 3
        vArrayDatosComboBox(31).Tipo = "char"
        vArrayDatosComboBox(31).ParteEntera = 0
        vArrayDatosComboBox(31).ParteDecimal = 0
        ReDim vArrayDatosComboBox(31).Valores(0, 0)
        vArrayDatosComboBox(31).Ancho = 36
        vArrayDatosComboBox(31).Flag = False

        vArrayDatosComboBox(32).NombreCampo = "TDO_DESCRIPCION_DOC"
        vArrayDatosComboBox(32).Longitud = 45
        vArrayDatosComboBox(32).Tipo = "varchar"
        vArrayDatosComboBox(32).ParteEntera = 0
        vArrayDatosComboBox(32).ParteDecimal = 0
        ReDim vArrayDatosComboBox(32).Valores(0, 0)
        vArrayDatosComboBox(32).Ancho = 485
        vArrayDatosComboBox(32).Flag = False

        vArrayDatosComboBox(33).NombreCampo = "DTD_ID_DOC"
        vArrayDatosComboBox(33).Longitud = 3
        vArrayDatosComboBox(33).Tipo = "char"
        vArrayDatosComboBox(33).ParteEntera = 0
        vArrayDatosComboBox(33).ParteDecimal = 0
        ReDim vArrayDatosComboBox(33).Valores(0, 0)
        vArrayDatosComboBox(33).Ancho = 36
        vArrayDatosComboBox(33).Flag = False

        vArrayDatosComboBox(34).NombreCampo = "DTD_DESCRIPCION_DOC"
        vArrayDatosComboBox(34).Longitud = 45
        vArrayDatosComboBox(34).Tipo = "varchar"
        vArrayDatosComboBox(34).ParteEntera = 0
        vArrayDatosComboBox(34).ParteDecimal = 0
        ReDim vArrayDatosComboBox(34).Valores(0, 0)
        vArrayDatosComboBox(34).Ancho = 485
        vArrayDatosComboBox(34).Flag = False

        vArrayDatosComboBox(35).NombreCampo = "DTE_SERIE_DOC"
        vArrayDatosComboBox(35).Longitud = 3
        vArrayDatosComboBox(35).Tipo = "char"
        vArrayDatosComboBox(35).ParteEntera = 0
        vArrayDatosComboBox(35).ParteDecimal = 0
        ReDim vArrayDatosComboBox(35).Valores(0, 0)
        vArrayDatosComboBox(35).Ancho = 36
        vArrayDatosComboBox(35).Flag = False

        vArrayDatosComboBox(36).NombreCampo = "DTE_NUMERO_DOC"
        vArrayDatosComboBox(36).Longitud = 10
        vArrayDatosComboBox(36).Tipo = "char"
        vArrayDatosComboBox(36).ParteEntera = 0
        vArrayDatosComboBox(36).ParteDecimal = 0
        ReDim vArrayDatosComboBox(36).Valores(0, 0)
        vArrayDatosComboBox(36).Ancho = 111
        vArrayDatosComboBox(36).Flag = False

        vArrayDatosComboBox(37).NombreCampo = "DTD_CARGO_ABONO_DOC"
        vArrayDatosComboBox(37).Longitud = 7
        vArrayDatosComboBox(37).Tipo = "varchar"
        vArrayDatosComboBox(37).ParteEntera = 0
        vArrayDatosComboBox(37).ParteDecimal = 0
        ReDim vArrayDatosComboBox(37).Valores(2, 1)
        vArrayDatosComboBox(37).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(37).Valores(0, 1) = "0"
        vArrayDatosComboBox(37).Valores(1, 0) = "CARGO"
        vArrayDatosComboBox(37).Valores(1, 1) = "1"
        vArrayDatosComboBox(37).Valores(2, 0) = "ABONO"
        vArrayDatosComboBox(37).Valores(2, 1) = "2"
        vArrayDatosComboBox(37).Ancho = 77
        vArrayDatosComboBox(37).Flag = True

        vArrayDatosComboBox(38).NombreCampo = "DTD_SIGNO_DOC"
        vArrayDatosComboBox(38).Longitud = 1
        vArrayDatosComboBox(38).Tipo = "varchar"
        vArrayDatosComboBox(38).ParteEntera = 0
        vArrayDatosComboBox(38).ParteDecimal = 0
        ReDim vArrayDatosComboBox(38).Valores(1, 1)
        vArrayDatosComboBox(38).Valores(0, 0) = "+"
        vArrayDatosComboBox(38).Valores(0, 1) = "0"
        vArrayDatosComboBox(38).Valores(1, 0) = "-"
        vArrayDatosComboBox(38).Valores(1, 1) = "1"
        vArrayDatosComboBox(38).Ancho = 30
        vArrayDatosComboBox(38).Flag = True

        vArrayDatosComboBox(39).NombreCampo = "DTD_SIGNO_D_DOC"
        vArrayDatosComboBox(39).Longitud = 1
        vArrayDatosComboBox(39).Tipo = "varchar"
        vArrayDatosComboBox(39).ParteEntera = 0
        vArrayDatosComboBox(39).ParteDecimal = 0
        ReDim vArrayDatosComboBox(39).Valores(1, 1)
        vArrayDatosComboBox(39).Valores(0, 0) = "+"
        vArrayDatosComboBox(39).Valores(0, 1) = "0"
        vArrayDatosComboBox(39).Valores(1, 0) = "-"
        vArrayDatosComboBox(39).Valores(1, 1) = "1"
        vArrayDatosComboBox(39).Ancho = 30
        vArrayDatosComboBox(39).Flag = True

        vArrayDatosComboBox(40).NombreCampo = "DTD_SIGNO_D_1_DOC"
        vArrayDatosComboBox(40).Longitud = 1
        vArrayDatosComboBox(40).Tipo = "varchar"
        vArrayDatosComboBox(40).ParteEntera = 0
        vArrayDatosComboBox(40).ParteDecimal = 0
        ReDim vArrayDatosComboBox(40).Valores(1, 1)
        vArrayDatosComboBox(40).Valores(0, 0) = "+"
        vArrayDatosComboBox(40).Valores(0, 1) = "0"
        vArrayDatosComboBox(40).Valores(1, 0) = "-"
        vArrayDatosComboBox(40).Valores(1, 1) = "1"
        vArrayDatosComboBox(40).Ancho = 30
        vArrayDatosComboBox(40).Flag = True

        vArrayDatosComboBox(41).NombreCampo = "DTE_IMPORTE_DOC"
        vArrayDatosComboBox(41).Longitud = 18
        vArrayDatosComboBox(41).Tipo = "numeric"
        vArrayDatosComboBox(41).ParteEntera = 14
        vArrayDatosComboBox(41).ParteDecimal = 4
        ReDim vArrayDatosComboBox(41).Valores(0, 0)
        vArrayDatosComboBox(41).Ancho = 197
        vArrayDatosComboBox(41).Flag = False

        vArrayDatosComboBox(42).NombreCampo = "DTE_CONTRAVALOR_DOC"
        vArrayDatosComboBox(42).Longitud = 18
        vArrayDatosComboBox(42).Tipo = "numeric"
        vArrayDatosComboBox(42).ParteEntera = 14
        vArrayDatosComboBox(42).ParteDecimal = 4
        ReDim vArrayDatosComboBox(42).Valores(0, 0)
        vArrayDatosComboBox(42).Ancho = 197
        vArrayDatosComboBox(42).Flag = False

        vArrayDatosComboBox(43).NombreCampo = "MON_ID_DOC"
        vArrayDatosComboBox(43).Longitud = 3
        vArrayDatosComboBox(43).Tipo = "char"
        vArrayDatosComboBox(43).ParteEntera = 0
        vArrayDatosComboBox(43).ParteDecimal = 0
        ReDim vArrayDatosComboBox(43).Valores(0, 0)
        vArrayDatosComboBox(43).Ancho = 36
        vArrayDatosComboBox(43).Flag = False

        vArrayDatosComboBox(44).NombreCampo = "MON_DESCRIPCION_DOC"
        vArrayDatosComboBox(44).Longitud = 45
        vArrayDatosComboBox(44).Tipo = "varchar"
        vArrayDatosComboBox(44).ParteEntera = 0
        vArrayDatosComboBox(44).ParteDecimal = 0
        ReDim vArrayDatosComboBox(44).Valores(0, 0)
        vArrayDatosComboBox(44).Ancho = 485
        vArrayDatosComboBox(44).Flag = False

        vArrayDatosComboBox(45).NombreCampo = "DTE_DESTINO"
        vArrayDatosComboBox(45).Longitud = 5
        vArrayDatosComboBox(45).Tipo = "smallint"
        vArrayDatosComboBox(45).ParteEntera = 5
        vArrayDatosComboBox(45).ParteDecimal = 0
        ReDim vArrayDatosComboBox(45).Valores(3, 1)
        vArrayDatosComboBox(45).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(45).Valores(0, 1) = "0"
        vArrayDatosComboBox(45).Valores(1, 0) = "A TERCERA PERSONA"
        vArrayDatosComboBox(45).Valores(1, 1) = "1"
        vArrayDatosComboBox(45).Valores(2, 0) = "A CAJA"
        vArrayDatosComboBox(45).Valores(2, 1) = "2"
        vArrayDatosComboBox(45).Valores(3, 0) = "A CUENTA CORRIENTE DE BANCO"
        vArrayDatosComboBox(45).Valores(3, 1) = "3"
        vArrayDatosComboBox(45).Ancho = 212
        vArrayDatosComboBox(45).Flag = True

        vArrayDatosComboBox(46).NombreCampo = "CHE_ID"
        vArrayDatosComboBox(46).Longitud = 3
        vArrayDatosComboBox(46).Tipo = "char"
        vArrayDatosComboBox(46).ParteEntera = 0
        vArrayDatosComboBox(46).ParteDecimal = 0
        ReDim vArrayDatosComboBox(46).Valores(0, 0)
        vArrayDatosComboBox(46).Ancho = 36
        vArrayDatosComboBox(46).Flag = False

        vArrayDatosComboBox(47).NombreCampo = "MPT_MEDIO_PAGO"
        vArrayDatosComboBox(47).Longitud = 22
        vArrayDatosComboBox(47).Tipo = "varchar"
        vArrayDatosComboBox(47).ParteEntera = 0
        vArrayDatosComboBox(47).ParteDecimal = 0
        ReDim vArrayDatosComboBox(47).Valores(6, 1)
        vArrayDatosComboBox(47).Valores(0, 0) = "EFECTIVO"
        vArrayDatosComboBox(47).Valores(0, 1) = "0"
        vArrayDatosComboBox(47).Valores(1, 0) = "CHEQUE"
        vArrayDatosComboBox(47).Valores(1, 1) = "1"
        vArrayDatosComboBox(47).Valores(2, 0) = "TARJETA DE CREDITO"
        vArrayDatosComboBox(47).Valores(2, 1) = "2"
        vArrayDatosComboBox(47).Valores(3, 0) = "DEPOSITO BANCARIO"
        vArrayDatosComboBox(47).Valores(3, 1) = "3"
        vArrayDatosComboBox(47).Valores(4, 0) = "DOCUMENTO"
        vArrayDatosComboBox(47).Valores(4, 1) = "4"
        vArrayDatosComboBox(47).Valores(5, 0) = "TRANSFERENCIA BANCARIA"
        vArrayDatosComboBox(47).Valores(5, 1) = "5"
        vArrayDatosComboBox(47).Valores(6, 0) = "RETENCION DE IGV"
        vArrayDatosComboBox(47).Valores(6, 1) = "6"
        vArrayDatosComboBox(47).Ancho = 180
        vArrayDatosComboBox(47).Flag = True

        vArrayDatosComboBox(48).NombreCampo = "MPT_IMPORTE_AFECTO"
        vArrayDatosComboBox(48).Longitud = 18
        vArrayDatosComboBox(48).Tipo = "numeric"
        vArrayDatosComboBox(48).ParteEntera = 14
        vArrayDatosComboBox(48).ParteDecimal = 4
        ReDim vArrayDatosComboBox(48).Valores(0, 0)
        vArrayDatosComboBox(48).Ancho = 197
        vArrayDatosComboBox(48).Flag = False

        vArrayDatosComboBox(49).NombreCampo = "MPT_PORCENTAJE"
        vArrayDatosComboBox(49).Longitud = 18
        vArrayDatosComboBox(49).Tipo = "numeric"
        vArrayDatosComboBox(49).ParteEntera = 14
        vArrayDatosComboBox(49).ParteDecimal = 4
        ReDim vArrayDatosComboBox(49).Valores(0, 0)
        vArrayDatosComboBox(49).Ancho = 197
        vArrayDatosComboBox(49).Flag = False

        vArrayDatosComboBox(50).NombreCampo = "MPT_SERIE_MEDIO"
        vArrayDatosComboBox(50).Longitud = 3
        vArrayDatosComboBox(50).Tipo = "char"
        vArrayDatosComboBox(50).ParteEntera = 0
        vArrayDatosComboBox(50).ParteDecimal = 0
        ReDim vArrayDatosComboBox(50).Valores(0, 0)
        vArrayDatosComboBox(50).Ancho = 36
        vArrayDatosComboBox(50).Flag = False

        vArrayDatosComboBox(51).NombreCampo = "MPT_NUMERO_MEDIO"
        vArrayDatosComboBox(51).Longitud = 25
        vArrayDatosComboBox(51).Tipo = "varchar"
        vArrayDatosComboBox(51).ParteEntera = 0
        vArrayDatosComboBox(51).ParteDecimal = 0
        ReDim vArrayDatosComboBox(51).Valores(0, 0)
        vArrayDatosComboBox(51).Ancho = 272
        vArrayDatosComboBox(51).Flag = False

        vArrayDatosComboBox(52).NombreCampo = "MPT_GIRADO_A"
        vArrayDatosComboBox(52).Longitud = 50
        vArrayDatosComboBox(52).Tipo = "varchar"
        vArrayDatosComboBox(52).ParteEntera = 0
        vArrayDatosComboBox(52).ParteDecimal = 0
        ReDim vArrayDatosComboBox(52).Valores(0, 0)
        vArrayDatosComboBox(52).Ancho = 539
        vArrayDatosComboBox(52).Flag = False

        vArrayDatosComboBox(53).NombreCampo = "MPT_CONCEPTO"
        vArrayDatosComboBox(53).Longitud = 25
        vArrayDatosComboBox(53).Tipo = "varchar"
        vArrayDatosComboBox(53).ParteEntera = 0
        vArrayDatosComboBox(53).ParteDecimal = 0
        ReDim vArrayDatosComboBox(53).Valores(0, 0)
        vArrayDatosComboBox(53).Ancho = 272
        vArrayDatosComboBox(53).Flag = False

        vArrayDatosComboBox(54).NombreCampo = "PER_ID_BAN"
        vArrayDatosComboBox(54).Longitud = 6
        vArrayDatosComboBox(54).Tipo = "char"
        vArrayDatosComboBox(54).ParteEntera = 0
        vArrayDatosComboBox(54).ParteDecimal = 0
        ReDim vArrayDatosComboBox(54).Valores(0, 0)
        vArrayDatosComboBox(54).Ancho = 68
        vArrayDatosComboBox(54).Flag = False

        vArrayDatosComboBox(55).NombreCampo = "PER_DESCRIPCION_BAN"
        vArrayDatosComboBox(55).Longitud = 77
        vArrayDatosComboBox(55).Tipo = "varchar"
        vArrayDatosComboBox(55).ParteEntera = 0
        vArrayDatosComboBox(55).ParteDecimal = 0
        ReDim vArrayDatosComboBox(55).Valores(0, 0)
        vArrayDatosComboBox(55).Ancho = 828
        vArrayDatosComboBox(55).Flag = False

        vArrayDatosComboBox(56).NombreCampo = "MPT_DIFERIDO"
        vArrayDatosComboBox(56).Longitud = 2
        vArrayDatosComboBox(56).Tipo = "varchar"
        vArrayDatosComboBox(56).ParteEntera = 0
        vArrayDatosComboBox(56).ParteDecimal = 0
        ReDim vArrayDatosComboBox(56).Valores(0, 0)
        vArrayDatosComboBox(56).Ancho = 26
        vArrayDatosComboBox(56).Flag = False

        vArrayDatosComboBox(57).NombreCampo = "MPT_FECHA_DIFERIDO"
        vArrayDatosComboBox(57).Longitud = 0
        vArrayDatosComboBox(57).Tipo = "smalldatetime"
        vArrayDatosComboBox(57).ParteEntera = 0
        vArrayDatosComboBox(57).ParteDecimal = 0
        ReDim vArrayDatosComboBox(57).Valores(0, 0)
        vArrayDatosComboBox(57).Ancho = 15
        vArrayDatosComboBox(57).Flag = False

        vArrayDatosComboBox(58).NombreCampo = "MPT_RECEPCION"
        vArrayDatosComboBox(58).Longitud = 15
        vArrayDatosComboBox(58).Tipo = "varchar"
        vArrayDatosComboBox(58).ParteEntera = 0
        vArrayDatosComboBox(58).ParteDecimal = 0
        ReDim vArrayDatosComboBox(58).Valores(2, 1)
        vArrayDatosComboBox(58).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(58).Valores(0, 1) = "0"
        vArrayDatosComboBox(58).Valores(1, 0) = "NO RECEPCIONADO"
        vArrayDatosComboBox(58).Valores(1, 1) = "1"
        vArrayDatosComboBox(58).Valores(2, 0) = "RECEPCIONADO"
        vArrayDatosComboBox(58).Valores(2, 1) = "2"
        vArrayDatosComboBox(58).Ancho = 135
        vArrayDatosComboBox(58).Flag = True

        vArrayDatosComboBox(59).NombreCampo = "MPT_UBICACION"
        vArrayDatosComboBox(59).Longitud = 16
        vArrayDatosComboBox(59).Tipo = "varchar"
        vArrayDatosComboBox(59).ParteEntera = 0
        vArrayDatosComboBox(59).ParteDecimal = 0
        ReDim vArrayDatosComboBox(59).Valores(2, 1)
        vArrayDatosComboBox(59).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(59).Valores(0, 1) = "0"
        vArrayDatosComboBox(59).Valores(1, 0) = "EN CAJA"
        vArrayDatosComboBox(59).Valores(1, 1) = "1"
        vArrayDatosComboBox(59).Valores(2, 0) = "EN CUENTA DE BANCO"
        vArrayDatosComboBox(59).Valores(2, 1) = "2"
        vArrayDatosComboBox(59).Ancho = 151
        vArrayDatosComboBox(59).Flag = True

        vArrayDatosComboBox(60).NombreCampo = "PER_ID_CLI_1"
        vArrayDatosComboBox(60).Longitud = 6
        vArrayDatosComboBox(60).Tipo = "char"
        vArrayDatosComboBox(60).ParteEntera = 0
        vArrayDatosComboBox(60).ParteDecimal = 0
        ReDim vArrayDatosComboBox(60).Valores(0, 0)
        vArrayDatosComboBox(60).Ancho = 68
        vArrayDatosComboBox(60).Flag = False

        vArrayDatosComboBox(61).NombreCampo = "PER_DESCRIPCION_CLI_1"
        vArrayDatosComboBox(61).Longitud = 77
        vArrayDatosComboBox(61).Tipo = "varchar"
        vArrayDatosComboBox(61).ParteEntera = 0
        vArrayDatosComboBox(61).ParteDecimal = 0
        ReDim vArrayDatosComboBox(61).Valores(0, 0)
        vArrayDatosComboBox(61).Ancho = 828
        vArrayDatosComboBox(61).Flag = False

        vArrayDatosComboBox(62).NombreCampo = "DTE_FEC_VEN_1"
        vArrayDatosComboBox(62).Longitud = 0
        vArrayDatosComboBox(62).Tipo = "smalldatetime"
        vArrayDatosComboBox(62).ParteEntera = 0
        vArrayDatosComboBox(62).ParteDecimal = 0
        ReDim vArrayDatosComboBox(62).Valores(0, 0)
        vArrayDatosComboBox(62).Ancho = 15
        vArrayDatosComboBox(62).Flag = False

        vArrayDatosComboBox(63).NombreCampo = "CCT_ID_DOC_1"
        vArrayDatosComboBox(63).Longitud = 3
        vArrayDatosComboBox(63).Tipo = "char"
        vArrayDatosComboBox(63).ParteEntera = 0
        vArrayDatosComboBox(63).ParteDecimal = 0
        ReDim vArrayDatosComboBox(63).Valores(0, 0)
        vArrayDatosComboBox(63).Ancho = 36
        vArrayDatosComboBox(63).Flag = False

        vArrayDatosComboBox(64).NombreCampo = "CCT_DESCRIPCION_DOC_1"
        vArrayDatosComboBox(64).Longitud = 45
        vArrayDatosComboBox(64).Tipo = "varchar"
        vArrayDatosComboBox(64).ParteEntera = 0
        vArrayDatosComboBox(64).ParteDecimal = 0
        ReDim vArrayDatosComboBox(64).Valores(0, 0)
        vArrayDatosComboBox(64).Ancho = 485
        vArrayDatosComboBox(64).Flag = False

        vArrayDatosComboBox(65).NombreCampo = "TDO_ID_DOC_1"
        vArrayDatosComboBox(65).Longitud = 3
        vArrayDatosComboBox(65).Tipo = "char"
        vArrayDatosComboBox(65).ParteEntera = 0
        vArrayDatosComboBox(65).ParteDecimal = 0
        ReDim vArrayDatosComboBox(65).Valores(0, 0)
        vArrayDatosComboBox(65).Ancho = 36
        vArrayDatosComboBox(65).Flag = False

        vArrayDatosComboBox(66).NombreCampo = "TDO_DESCRIPCION_DOC_1"
        vArrayDatosComboBox(66).Longitud = 45
        vArrayDatosComboBox(66).Tipo = "varchar"
        vArrayDatosComboBox(66).ParteEntera = 0
        vArrayDatosComboBox(66).ParteDecimal = 0
        ReDim vArrayDatosComboBox(66).Valores(0, 0)
        vArrayDatosComboBox(66).Ancho = 485
        vArrayDatosComboBox(66).Flag = False

        vArrayDatosComboBox(67).NombreCampo = "DTD_ID_DOC_1"
        vArrayDatosComboBox(67).Longitud = 3
        vArrayDatosComboBox(67).Tipo = "char"
        vArrayDatosComboBox(67).ParteEntera = 0
        vArrayDatosComboBox(67).ParteDecimal = 0
        ReDim vArrayDatosComboBox(67).Valores(0, 0)
        vArrayDatosComboBox(67).Ancho = 36
        vArrayDatosComboBox(67).Flag = False

        vArrayDatosComboBox(68).NombreCampo = "DTD_DESCRIPCION_DOC_1"
        vArrayDatosComboBox(68).Longitud = 45
        vArrayDatosComboBox(68).Tipo = "varchar"
        vArrayDatosComboBox(68).ParteEntera = 0
        vArrayDatosComboBox(68).ParteDecimal = 0
        ReDim vArrayDatosComboBox(68).Valores(0, 0)
        vArrayDatosComboBox(68).Ancho = 485
        vArrayDatosComboBox(68).Flag = False

        vArrayDatosComboBox(69).NombreCampo = "DTE_SERIE_DOC_1"
        vArrayDatosComboBox(69).Longitud = 3
        vArrayDatosComboBox(69).Tipo = "char"
        vArrayDatosComboBox(69).ParteEntera = 0
        vArrayDatosComboBox(69).ParteDecimal = 0
        ReDim vArrayDatosComboBox(69).Valores(0, 0)
        vArrayDatosComboBox(69).Ancho = 36
        vArrayDatosComboBox(69).Flag = False

        vArrayDatosComboBox(70).NombreCampo = "DTE_NUMERO_DOC_1"
        vArrayDatosComboBox(70).Longitud = 10
        vArrayDatosComboBox(70).Tipo = "char"
        vArrayDatosComboBox(70).ParteEntera = 0
        vArrayDatosComboBox(70).ParteDecimal = 0
        ReDim vArrayDatosComboBox(70).Valores(0, 0)
        vArrayDatosComboBox(70).Ancho = 111
        vArrayDatosComboBox(70).Flag = False

        vArrayDatosComboBox(71).NombreCampo = "DTD_CARGO_ABONO_DOC_1"
        vArrayDatosComboBox(71).Longitud = 7
        vArrayDatosComboBox(71).Tipo = "varchar"
        vArrayDatosComboBox(71).ParteEntera = 0
        vArrayDatosComboBox(71).ParteDecimal = 0
        ReDim vArrayDatosComboBox(71).Valores(0, 0)
        vArrayDatosComboBox(71).Ancho = 79
        vArrayDatosComboBox(71).Flag = False

        vArrayDatosComboBox(72).NombreCampo = "DTD_SIGNO_DOC_1"
        vArrayDatosComboBox(72).Longitud = 1
        vArrayDatosComboBox(72).Tipo = "varchar"
        vArrayDatosComboBox(72).ParteEntera = 0
        vArrayDatosComboBox(72).ParteDecimal = 0
        ReDim vArrayDatosComboBox(72).Valores(1, 1)
        vArrayDatosComboBox(72).Valores(0, 0) = "+"
        vArrayDatosComboBox(72).Valores(0, 1) = "0"
        vArrayDatosComboBox(72).Valores(1, 0) = "-"
        vArrayDatosComboBox(72).Valores(1, 1) = "1"
        vArrayDatosComboBox(72).Ancho = 30
        vArrayDatosComboBox(72).Flag = True

        vArrayDatosComboBox(73).NombreCampo = "DTD_SIGNO_D_DOC_1"
        vArrayDatosComboBox(73).Longitud = 1
        vArrayDatosComboBox(73).Tipo = "varchar"
        vArrayDatosComboBox(73).ParteEntera = 0
        vArrayDatosComboBox(73).ParteDecimal = 0
        ReDim vArrayDatosComboBox(73).Valores(1, 1)
        vArrayDatosComboBox(73).Valores(0, 0) = "+"
        vArrayDatosComboBox(73).Valores(0, 1) = "0"
        vArrayDatosComboBox(73).Valores(1, 0) = "-"
        vArrayDatosComboBox(73).Valores(1, 1) = "1"
        vArrayDatosComboBox(73).Ancho = 30
        vArrayDatosComboBox(73).Flag = True

        vArrayDatosComboBox(74).NombreCampo = "DTD_SIGNO_D_1_DOC_1"
        vArrayDatosComboBox(74).Longitud = 1
        vArrayDatosComboBox(74).Tipo = "varchar"
        vArrayDatosComboBox(74).ParteEntera = 0
        vArrayDatosComboBox(74).ParteDecimal = 0
        ReDim vArrayDatosComboBox(74).Valores(1, 1)
        vArrayDatosComboBox(74).Valores(0, 0) = "+"
        vArrayDatosComboBox(74).Valores(0, 1) = "0"
        vArrayDatosComboBox(74).Valores(1, 0) = "-"
        vArrayDatosComboBox(74).Valores(1, 1) = "1"
        vArrayDatosComboBox(74).Ancho = 30
        vArrayDatosComboBox(74).Flag = True

        vArrayDatosComboBox(75).NombreCampo = "DTE_IMPORTE_DOC_1"
        vArrayDatosComboBox(75).Longitud = 18
        vArrayDatosComboBox(75).Tipo = "numeric"
        vArrayDatosComboBox(75).ParteEntera = 14
        vArrayDatosComboBox(75).ParteDecimal = 4
        ReDim vArrayDatosComboBox(75).Valores(0, 0)
        vArrayDatosComboBox(75).Ancho = 197
        vArrayDatosComboBox(75).Flag = False

        vArrayDatosComboBox(76).NombreCampo = "DTE_CONTRAVALOR_DOC_1"
        vArrayDatosComboBox(76).Longitud = 18
        vArrayDatosComboBox(76).Tipo = "numeric"
        vArrayDatosComboBox(76).ParteEntera = 14
        vArrayDatosComboBox(76).ParteDecimal = 4
        ReDim vArrayDatosComboBox(76).Valores(0, 0)
        vArrayDatosComboBox(76).Ancho = 197
        vArrayDatosComboBox(76).Flag = False

        vArrayDatosComboBox(77).NombreCampo = "MON_ID_DOC_1"
        vArrayDatosComboBox(77).Longitud = 3
        vArrayDatosComboBox(77).Tipo = "char"
        vArrayDatosComboBox(77).ParteEntera = 0
        vArrayDatosComboBox(77).ParteDecimal = 0
        ReDim vArrayDatosComboBox(77).Valores(0, 0)
        vArrayDatosComboBox(77).Ancho = 36
        vArrayDatosComboBox(77).Flag = False

        vArrayDatosComboBox(78).NombreCampo = "MON_DESCRIPCION_DOC_1"
        vArrayDatosComboBox(78).Longitud = 45
        vArrayDatosComboBox(78).Tipo = "varchar"
        vArrayDatosComboBox(78).ParteEntera = 0
        vArrayDatosComboBox(78).ParteDecimal = 0
        ReDim vArrayDatosComboBox(78).Valores(0, 0)
        vArrayDatosComboBox(78).Ancho = 485
        vArrayDatosComboBox(78).Flag = False

        vArrayDatosComboBox(79).NombreCampo = "CCO_ID"
        vArrayDatosComboBox(79).Longitud = 6
        vArrayDatosComboBox(79).Tipo = "char"
        vArrayDatosComboBox(79).ParteEntera = 0
        vArrayDatosComboBox(79).ParteDecimal = 0
        ReDim vArrayDatosComboBox(79).Valores(0, 0)
        vArrayDatosComboBox(79).Ancho = 68
        vArrayDatosComboBox(79).Flag = False

        vArrayDatosComboBox(80).NombreCampo = "CCO_DESCRIPCION"
        vArrayDatosComboBox(80).Longitud = 45
        vArrayDatosComboBox(80).Tipo = "varchar"
        vArrayDatosComboBox(80).ParteEntera = 0
        vArrayDatosComboBox(80).ParteDecimal = 0
        ReDim vArrayDatosComboBox(80).Valores(0, 0)
        vArrayDatosComboBox(80).Ancho = 485
        vArrayDatosComboBox(80).Flag = False

        vArrayDatosComboBox(81).NombreCampo = "CUC_ID"
        vArrayDatosComboBox(81).Longitud = 14
        vArrayDatosComboBox(81).Tipo = "char"
        vArrayDatosComboBox(81).ParteEntera = 0
        vArrayDatosComboBox(81).ParteDecimal = 0
        ReDim vArrayDatosComboBox(81).Valores(0, 0)
        vArrayDatosComboBox(81).Ancho = 154
        vArrayDatosComboBox(81).Flag = False

        vArrayDatosComboBox(82).NombreCampo = "CUC_DESCRIPCION"
        vArrayDatosComboBox(82).Longitud = 45
        vArrayDatosComboBox(82).Tipo = "varchar"
        vArrayDatosComboBox(82).ParteEntera = 0
        vArrayDatosComboBox(82).ParteDecimal = 0
        ReDim vArrayDatosComboBox(82).Valores(0, 0)
        vArrayDatosComboBox(82).Ancho = 485
        vArrayDatosComboBox(82).Flag = False

        vArrayDatosComboBox(83).NombreCampo = "DTE_OPE_CONTABLE"
        vArrayDatosComboBox(83).Longitud = 5
        vArrayDatosComboBox(83).Tipo = "smallint"
        vArrayDatosComboBox(83).ParteEntera = 5
        vArrayDatosComboBox(83).ParteDecimal = 0
        ReDim vArrayDatosComboBox(83).Valores(1, 1)
        vArrayDatosComboBox(83).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(83).Valores(0, 1) = "0"
        vArrayDatosComboBox(83).Valores(1, 0) = "PAGO DETRACCION"
        vArrayDatosComboBox(83).Valores(1, 1) = "1"
        vArrayDatosComboBox(83).Ancho = 134
        vArrayDatosComboBox(83).Flag = True

        vArrayDatosComboBox(84).NombreCampo = "DTE_OBSERVACIONES"
        vArrayDatosComboBox(84).Longitud = 50
        vArrayDatosComboBox(84).Tipo = "varchar"
        vArrayDatosComboBox(84).ParteEntera = 0
        vArrayDatosComboBox(84).ParteDecimal = 0
        ReDim vArrayDatosComboBox(84).Valores(0, 0)
        vArrayDatosComboBox(84).Ancho = 539
        vArrayDatosComboBox(84).Flag = False

        vArrayDatosComboBox(85).NombreCampo = "DTE_MOVIMIENTO"
        vArrayDatosComboBox(85).Longitud = 5
        vArrayDatosComboBox(85).Tipo = "smallint"
        vArrayDatosComboBox(85).ParteEntera = 5
        vArrayDatosComboBox(85).ParteDecimal = 0
        ReDim vArrayDatosComboBox(85).Valores(4, 1)
        vArrayDatosComboBox(85).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(85).Valores(0, 1) = "0"
        vArrayDatosComboBox(85).Valores(1, 0) = "ANTICIPO RECIBIDO"
        vArrayDatosComboBox(85).Valores(1, 1) = "1"
        vArrayDatosComboBox(85).Valores(2, 0) = "LIQUIDACION DE DOCUMENTOS"
        vArrayDatosComboBox(85).Valores(2, 1) = "2"
        vArrayDatosComboBox(85).Valores(3, 0) = "PLANILLA DE RENDICION DE CUENTAS"
        vArrayDatosComboBox(85).Valores(3, 1) = "3"
        vArrayDatosComboBox(85).Valores(4, 0) = "SOLO RETIRO - DEPOSITO"
        vArrayDatosComboBox(85).Valores(4, 1) = "4"
        vArrayDatosComboBox(85).Ancho = 237
        vArrayDatosComboBox(85).Flag = True

        vArrayDatosComboBox(86).NombreCampo = "MPT_ESTADO"
        vArrayDatosComboBox(86).Longitud = 9
        vArrayDatosComboBox(86).Tipo = "varchar"
        vArrayDatosComboBox(86).ParteEntera = 0
        vArrayDatosComboBox(86).ParteDecimal = 0
        ReDim vArrayDatosComboBox(86).Valores(1, 1)
        vArrayDatosComboBox(86).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(86).Valores(0, 1) = "0"
        vArrayDatosComboBox(86).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(86).Valores(1, 1) = "1"
        vArrayDatosComboBox(86).Ancho = 85
        vArrayDatosComboBox(86).Flag = True

        vArrayDatosComboBox(87).NombreCampo = "DTE_ESTADO"
        vArrayDatosComboBox(87).Longitud = 0
        vArrayDatosComboBox(87).Tipo = "bit"
        vArrayDatosComboBox(87).ParteEntera = 0
        vArrayDatosComboBox(87).ParteDecimal = 0
        ReDim vArrayDatosComboBox(87).Valores(1, 1)
        vArrayDatosComboBox(87).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(87).Valores(0, 1) = "0"
        vArrayDatosComboBox(87).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(87).Valores(1, 1) = "1"
        vArrayDatosComboBox(87).Ancho = 85
        vArrayDatosComboBox(87).Flag = True

        vArrayDatosComboBox(88).NombreCampo = "TES_ESTADO"
        vArrayDatosComboBox(88).Longitud = 9
        vArrayDatosComboBox(88).Tipo = "varchar"
        vArrayDatosComboBox(88).ParteEntera = 0
        vArrayDatosComboBox(88).ParteDecimal = 0
        ReDim vArrayDatosComboBox(88).Valores(1, 1)
        vArrayDatosComboBox(88).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(88).Valores(0, 1) = "0"
        vArrayDatosComboBox(88).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(88).Valores(1, 1) = "1"
        vArrayDatosComboBox(88).Ancho = 85
        vArrayDatosComboBox(88).Flag = True

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
                        VerificarDatos.MensajeError = mCodigo3 & " - TDO_ID"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_ID"
                    If Len(DTD_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3 & " - DTD_ID"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCC_ID"
                    If Len(CCC_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3 & " - CCC_ID"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCT_ID"
                    If IsNothing(CCT_ID) Then
                    Else
                        If Len(CCT_ID.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Cta. Cte."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_SERIE"
                    If Len(DTE_SERIE.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3 & " - DTE_SERIE"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTE_NUMERO"
                    If Len(DTE_NUMERO.Trim) = 10 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo10 & " - DTE_NUMERO"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTE_ITEM"
                    If DTE_ITEM.GetType = GetType(System.Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - DTE_ITEM"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCC_ID_CLI"
                    If IsNothing(CCC_ID_CLI) Then
                    Else
                        If Len(CCC_ID_CLI.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Caja Cta. Cte."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_DESTINO"
                    If DTE_DESTINO >= 0 And DTE_DESTINO <= 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Destino"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCO_ID"
                    If IsNothing(CCO_ID) Then
                    Else
                        If Len(CCO_ID.Trim) = 6 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo6 & " - Cód. Centro costos"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "CUC_ID"
                    If IsNothing(CUC_ID) Then
                    Else
                        If Len(CUC_ID.Trim) >= 1 And Len(CUC_ID.Trim) <= 14 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo14 & " - Cód. Cta. contable"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "PER_ID_CLI"
                    If IsNothing(PER_ID_CLI) Then
                    Else
                        If Len(PER_ID_CLI.Trim) = 6 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo6 & " - Cód. Cliente"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "TDO_ID_DOC"
                    If IsNothing(TDO_ID_DOC) Then
                    Else
                        If Len(TDO_ID_DOC.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Cód. Doc."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTD_ID_DOC"
                    If IsNothing(DTD_ID_DOC) Then
                    Else
                        If Len(DTD_ID_DOC.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Cód. Tip. Doc."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "CCT_ID_DOC"
                    If IsNothing(CCT_ID_DOC) Then
                    Else
                        If Len(CCT_ID_DOC.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Cta. Cte. Doc."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_SERIE_DOC"
                    If IsNothing(DTE_SERIE_DOC) Then
                    Else
                        If Len(DTE_SERIE_DOC.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Serie Doc."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_NUMERO_DOC"
                    If IsNothing(DTE_NUMERO_DOC) Then
                    Else
                        If Len(DTE_NUMERO_DOC.Trim) = 10 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo10 & " - Número Doc."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_FEC_VEN"
                    If DTE_FEC_VEN.GetType = GetType(Date) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha & " - Fec. Venc."
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "MON_ID_DOC"
                    If Len(MON_ID_DOC.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3 & " - Cód. Mon. Doc."
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTE_IMPORTE_DOC"
                    If DTE_IMPORTE_DOC > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Importe"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTE_CONTRAVALOR_DOC"
                    If DTE_CONTRAVALOR_DOC >= 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Contravalor"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_ID_CLI_1"
                    If IsNothing(PER_ID_CLI_1) Then
                    Else
                        If Len(PER_ID_CLI_1.Trim) = 6 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo6 & " - Cód. Cliente 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "TDO_ID_DOC_1"
                    If IsNothing(TDO_ID_DOC_1) Then
                    Else
                        If Len(TDO_ID_DOC_1.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Cód. Doc. 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTD_ID_DOC_1"
                    If IsNothing(DTD_ID_DOC_1) Then
                    Else
                        If Len(DTD_ID_DOC_1.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Cód. Tip. Doc. 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "CCT_ID_DOC_1"
                    If IsNothing(CCT_ID_DOC_1) Then
                    Else
                        If Len(CCT_ID_DOC_1.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Cta. Cte. Doc. 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_SERIE_DOC_1"
                    If IsNothing(DTE_SERIE_DOC_1) Then
                    Else
                        If Len(DTE_SERIE_DOC_1.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Serie Doc. 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_NUMERO_DOC_1"
                    If IsNothing(DTE_NUMERO_DOC_1) Then
                    Else
                        If Len(DTE_NUMERO_DOC_1.Trim) = 10 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo10 & " - Número Doc. 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_FEC_VEN_1"
                    If IsNothing(DTE_FEC_VEN_1) Then
                    Else
                        If DTE_FEC_VEN_1.GetType = GetType(Date) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mFecha & " - Fec. Venc. 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "MON_ID_DOC_1"
                    If IsNothing(MON_ID_DOC_1) Then
                    Else
                        If Len(MON_ID_DOC_1.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Cód. Mon. Doc. 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_IMPORTE_DOC_1"
                    If IsNothing(DTE_IMPORTE_DOC_1) Then
                    Else
                        If DTE_IMPORTE_DOC_1.GetType = GetType(Decimal) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato & " - Importe 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_CONTRAVALOR_DOC_1"
                    If IsNothing(DTE_CONTRAVALOR_DOC_1) Then
                    Else
                        If DTE_CONTRAVALOR_DOC_1.GetType = GetType(Decimal) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato & " - Contravalor 1"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_OBSERVACIONES"
                    If IsNothing(DTE_OBSERVACIONES) Then
                    Else
                        If DTE_OBSERVACIONES.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato & " - Observaciones"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTE_OPE_CONTABLE"
                    If DTE_OPE_CONTABLE >= 0 And DTE_OPE_CONTABLE <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Operación contable"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTE_MOVIMIENTO"
                    If DTE_MOVIMIENTO >= 0 And DTE_MOVIMIENTO <= 4 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Movimiento"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario & " - Cód. Usuario"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTE_FEC_GRAB"
                    If DTE_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha & " - Fecha y hora de grabación"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTE_ESTADO"
                    If DTE_ESTADO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado & " - Estado detalle"
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
            SentenciaSqlBusqueda = "spVistaDetalleTesoreriaXML"
        End If
        If Vista = "VistaDetalleTesoreriaNuevo" Then
            SentenciaSqlBusqueda = "spVistaDetalleTesoreriaNuevoXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetalleTesoreriaXML"
        End If
        If Vista = "ListarRegistrosTransferencias" Then
            SentenciaSqlBusqueda = "spListarDetalleTesoreriaTransferenciasXML"
        End If
        If Vista = "ListarRegistrosTipoRecibo" Then
            SentenciaSqlBusqueda = "spListarDetalleTesoreriaTipoReciboNuevoXML"
        End If
        If Vista = "ListarRegistrosTipoReciboEntregas" Then
            SentenciaSqlBusqueda = "spListarDetalleTesoreriaTipoReciboEntregasNuevoXML"
        End If
        If Vista = "ListarRegistrosTipoReciboOtros" Then
            SentenciaSqlBusqueda = "spListarDetalleTesoreriaTipoReciboOtrosNuevoXML"
        End If
        If Vista = "ListarRegistrosTipoReciboTransferencias" Then
            SentenciaSqlBusqueda = "spListarDetalleTesoreriaTipoReciboTransferenciasNuevoXML"
        End If
        If Vista = "BuscarCorrelativos" Then
            SentenciaSqlBusqueda = "spVistaCorrelativoSerieXML"
        End If
        If Vista = "BuscarCorrelativosCheque" Then
            SentenciaSqlBusqueda = "spVistaCorrelativoSerieChequeXML"
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
                oVerificarDatos = VerificarDatos("TDO_ID", "DTD_ID", "CCC_ID", "CCT_ID", "DTE_SERIE", "DTE_NUMERO", "DTE_ITEM", "CCC_ID_CLI", "DTE_DESTINO", "CCO_ID", "CUC_ID", "PER_ID_CLI", "TDO_ID_DOC", "DTD_ID_DOC", "CCT_ID_DOC", "DTE_SERIE_DOC", "DTE_NUMERO_DOC", "DTE_FEC_VEN", "MON_ID_DOC", "DTE_IMPORTE_DOC", "DTE_CONTRAVALOR_DOC", "PER_ID_CLI_1", "TDO_ID_DOC_1", "DTD_ID_DOC_1", "CCT_ID_DOC_1", "DTE_SERIE_DOC_1", "DTE_NUMERO_DOC_1", "DTE_FEC_VEN_1", "MON_ID_DOC_1", "DTE_IMPORTE_DOC_1", "DTE_CONTRAVALOR_DOC_1", "DTE_OBSERVACIONES", "DTE_OPE_CONTABLE", "DTE_MOVIMIENTO", "USU_ID", "DTE_FEC_GRAB", "DTE_ESTADO")
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

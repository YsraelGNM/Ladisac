Imports Ladisac.BE

Partial Public Class Personas
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public CampoPrincipal = "PER_ID"
    Public CampoPrincipalValor = PER_ID
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 1
    Public CadenaFiltrado As String = ""

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.Personas"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "Personas"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwPersonas"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaPersonas"
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
        vElementosDatosComboBox = 71
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "PER_ID"
        vArrayCamposBusqueda(1) = "PER_APE_PAT"
        vArrayCamposBusqueda(2) = "PER_APE_MAT"
        vArrayCamposBusqueda(3) = "PER_NOMBRES"
        vArrayCamposBusqueda(4) = "PER_DESCRIPCION"
        vArrayCamposBusqueda(5) = "PER_CLIENTE"
        vArrayCamposBusqueda(6) = "PER_CLIENTE_OP_CON"
        vArrayCamposBusqueda(7) = "PER_PROVEEDOR"
        vArrayCamposBusqueda(8) = "PER_PROVEEDOR_OP_CON"
        vArrayCamposBusqueda(9) = "PER_TRANSPORTISTA"
        vArrayCamposBusqueda(10) = "PER_TRANSPORTISTA_OP_CON"
        vArrayCamposBusqueda(11) = "PER_TRABAJADOR"
        vArrayCamposBusqueda(12) = "PER_TRABAJADOR_OP_CON"
        vArrayCamposBusqueda(13) = "PER_BANCO"
        vArrayCamposBusqueda(14) = "PER_BANCO_OP_CON"
        vArrayCamposBusqueda(15) = "PER_GRUPO"
        vArrayCamposBusqueda(16) = "PER_GRUPO_OP_CON"
        vArrayCamposBusqueda(17) = "PER_CONTACTO"
        vArrayCamposBusqueda(18) = "PER_CONTACTO_OP_CON"
        vArrayCamposBusqueda(19) = "PER_TRANSP_PROPIO"
        vArrayCamposBusqueda(20) = "PER_BREVETE"
        vArrayCamposBusqueda(21) = "PER_FORMA_VENTA"
        vArrayCamposBusqueda(22) = "DIR_ID"
        vArrayCamposBusqueda(23) = "DIR_DESCRIPCION"
        vArrayCamposBusqueda(24) = "DIR_REFERENCIA"
        vArrayCamposBusqueda(25) = "DIR_TIPO"
        vArrayCamposBusqueda(26) = "DIS_ID"
        vArrayCamposBusqueda(27) = "DIS_DESCRIPCION"
        vArrayCamposBusqueda(28) = "PRO_ID"
        vArrayCamposBusqueda(29) = "PRO_DESCRIPCION"
        vArrayCamposBusqueda(30) = "DEP_ID"
        vArrayCamposBusqueda(31) = "DEP_DESCRIPCION"
        vArrayCamposBusqueda(32) = "PAI_ID"
        vArrayCamposBusqueda(33) = "PAI_DESCRIPCION"
        vArrayCamposBusqueda(34) = "PER_TELEFONOS"
        vArrayCamposBusqueda(35) = "PER_EMAIL"
        vArrayCamposBusqueda(36) = "PER_PAGINA_WEB"
        vArrayCamposBusqueda(37) = "PER_LINEA_CREDITO"
        vArrayCamposBusqueda(38) = "PER_DIAS_CREDITO"
        vArrayCamposBusqueda(39) = "PER_ID_VEN"
        vArrayCamposBusqueda(40) = "PER_DESCRIPCION_VEN"
        vArrayCamposBusqueda(41) = "PER_ID_COB"
        vArrayCamposBusqueda(42) = "PER_DESCRIPCION_COB"
        vArrayCamposBusqueda(43) = "PER_ID_TRA"
        vArrayCamposBusqueda(44) = "PER_DESCRIPCION_TRA"
        vArrayCamposBusqueda(45) = "PER_ID_BAN"
        vArrayCamposBusqueda(46) = "PER_DESCRIPCION_BAN"
        vArrayCamposBusqueda(47) = "PER_ID_GRU"
        vArrayCamposBusqueda(48) = "PER_DESCRIPCION_GRU"
        vArrayCamposBusqueda(49) = "PER_DIASEM_PAGO"
        vArrayCamposBusqueda(50) = "PER_COND_DIASEM"
        vArrayCamposBusqueda(51) = "PER_DIAMES_PAGO"
        vArrayCamposBusqueda(52) = "PER_DOC_PAGO"
        vArrayCamposBusqueda(53) = "PER_HORA_PAGO"
        vArrayCamposBusqueda(54) = "PER_OBSERVACIONES"
        vArrayCamposBusqueda(55) = "PER_PROMOCIONES"
        vArrayCamposBusqueda(56) = "PER_CARTA_FIANZA"
        vArrayCamposBusqueda(57) = "PER_CUOTA_MENSUAL"
        vArrayCamposBusqueda(58) = "PER_CUOTA_OBJETIVO"
        vArrayCamposBusqueda(59) = "PER_BONO"
        vArrayCamposBusqueda(60) = "CCC_ID_CLI"
        vArrayCamposBusqueda(61) = "CCC_DESCRIPCION_CLI"
        vArrayCamposBusqueda(62) = "CCC_CUENTA_BANCARIA_CLI"
        vArrayCamposBusqueda(63) = "PER_ID_BAN_CLI"
        vArrayCamposBusqueda(64) = "PER_DESCRIPCION_BAN_CLI"
        vArrayCamposBusqueda(65) = "PER_CARGO"
        vArrayCamposBusqueda(66) = "PER_REP_LEGAL"
        vArrayCamposBusqueda(67) = "PER_FIRMA_AUT"
        vArrayCamposBusqueda(68) = "PER_PROCESAR_DESCUENTO"
        vArrayCamposBusqueda(69) = "PER_ALIAS"
        vArrayCamposBusqueda(70) = "PER_LINEA_CREDITO_ESTADO"
        vArrayCamposBusqueda(71) = "PER_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "PER_ID"
        vArrayDatosComboBox(0).Longitud = 6
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 68
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "PER_APE_PAT"
        vArrayDatosComboBox(1).Longitud = 25
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 272
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "PER_APE_MAT"
        vArrayDatosComboBox(2).Longitud = 25
        vArrayDatosComboBox(2).Tipo = "varchar"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 272
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PER_NOMBRES"
        vArrayDatosComboBox(3).Longitud = 25
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 272
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PER_DESCRIPCION"
        vArrayDatosComboBox(4).Longitud = 77
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 828
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "PER_CLIENTE"
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

        vArrayDatosComboBox(6).NombreCampo = "PER_CLIENTE_OP_CON"
        vArrayDatosComboBox(6).Longitud = 19
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(1, 1)
        vArrayDatosComboBox(6).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(6).Valores(0, 1) = "0"
        vArrayDatosComboBox(6).Valores(1, 0) = "AGENTE DE RETENCION"
        vArrayDatosComboBox(6).Valores(1, 1) = "1"
        vArrayDatosComboBox(6).Ancho = 158
        vArrayDatosComboBox(6).Flag = True

        vArrayDatosComboBox(7).NombreCampo = "PER_PROVEEDOR"
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

        vArrayDatosComboBox(8).NombreCampo = "PER_PROVEEDOR_OP_CON"
        vArrayDatosComboBox(8).Longitud = 20
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(1, 1)
        vArrayDatosComboBox(8).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(8).Valores(0, 1) = "0"
        vArrayDatosComboBox(8).Valores(1, 0) = "AGENTE DE PERCEPCION"
        vArrayDatosComboBox(8).Valores(1, 1) = "1"
        vArrayDatosComboBox(8).Ancho = 166
        vArrayDatosComboBox(8).Flag = True

        vArrayDatosComboBox(9).NombreCampo = "PER_TRANSPORTISTA"
        vArrayDatosComboBox(9).Longitud = 2
        vArrayDatosComboBox(9).Tipo = "varchar"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(1, 1)
        vArrayDatosComboBox(9).Valores(0, 0) = "NO"
        vArrayDatosComboBox(9).Valores(0, 1) = "0"
        vArrayDatosComboBox(9).Valores(1, 0) = "SI"
        vArrayDatosComboBox(9).Valores(1, 1) = "1"
        vArrayDatosComboBox(9).Ancho = 40
        vArrayDatosComboBox(9).Flag = True

        vArrayDatosComboBox(10).NombreCampo = "PER_TRANSPORTISTA_OP_CON"
        vArrayDatosComboBox(10).Longitud = 7
        vArrayDatosComboBox(10).Tipo = "varchar"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(1, 1)
        vArrayDatosComboBox(10).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(10).Valores(0, 1) = "0"
        vArrayDatosComboBox(10).Valores(1, 0) = "OTRO"
        vArrayDatosComboBox(10).Valores(1, 1) = "1"
        vArrayDatosComboBox(10).Ancho = 77
        vArrayDatosComboBox(10).Flag = True

        vArrayDatosComboBox(11).NombreCampo = "PER_TRABAJADOR"
        vArrayDatosComboBox(11).Longitud = 2
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(1, 1)
        vArrayDatosComboBox(11).Valores(0, 0) = "NO"
        vArrayDatosComboBox(11).Valores(0, 1) = "0"
        vArrayDatosComboBox(11).Valores(1, 0) = "SI"
        vArrayDatosComboBox(11).Valores(1, 1) = "1"
        vArrayDatosComboBox(11).Ancho = 40
        vArrayDatosComboBox(11).Flag = True

        vArrayDatosComboBox(12).NombreCampo = "PER_TRABAJADOR_OP_CON"
        vArrayDatosComboBox(12).Longitud = 7
        vArrayDatosComboBox(12).Tipo = "varchar"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(1, 1)
        vArrayDatosComboBox(12).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(12).Valores(0, 1) = "0"
        vArrayDatosComboBox(12).Valores(1, 0) = "OTRO"
        vArrayDatosComboBox(12).Valores(1, 1) = "1"
        vArrayDatosComboBox(12).Ancho = 77
        vArrayDatosComboBox(12).Flag = True

        vArrayDatosComboBox(13).NombreCampo = "PER_BANCO"
        vArrayDatosComboBox(13).Longitud = 2
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(1, 1)
        vArrayDatosComboBox(13).Valores(0, 0) = "NO"
        vArrayDatosComboBox(13).Valores(0, 1) = "0"
        vArrayDatosComboBox(13).Valores(1, 0) = "SI"
        vArrayDatosComboBox(13).Valores(1, 1) = "1"
        vArrayDatosComboBox(13).Ancho = 40
        vArrayDatosComboBox(13).Flag = True

        vArrayDatosComboBox(14).NombreCampo = "PER_BANCO_OP_CON"
        vArrayDatosComboBox(14).Longitud = 7
        vArrayDatosComboBox(14).Tipo = "varchar"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(1, 1)
        vArrayDatosComboBox(14).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(14).Valores(0, 1) = "0"
        vArrayDatosComboBox(14).Valores(1, 0) = "OTRO"
        vArrayDatosComboBox(14).Valores(1, 1) = "1"
        vArrayDatosComboBox(14).Ancho = 77
        vArrayDatosComboBox(14).Flag = True

        vArrayDatosComboBox(15).NombreCampo = "PER_GRUPO"
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

        vArrayDatosComboBox(16).NombreCampo = "PER_GRUPO_OP_CON"
        vArrayDatosComboBox(16).Longitud = 7
        vArrayDatosComboBox(16).Tipo = "varchar"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(1, 1)
        vArrayDatosComboBox(16).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(16).Valores(0, 1) = "0"
        vArrayDatosComboBox(16).Valores(1, 0) = "OTRO"
        vArrayDatosComboBox(16).Valores(1, 1) = "1"
        vArrayDatosComboBox(16).Ancho = 77
        vArrayDatosComboBox(16).Flag = True

        vArrayDatosComboBox(17).NombreCampo = "PER_CONTACTO"
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

        vArrayDatosComboBox(18).NombreCampo = "PER_CONTACTO_OP_CON"
        vArrayDatosComboBox(18).Longitud = 7
        vArrayDatosComboBox(18).Tipo = "varchar"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(1, 1)
        vArrayDatosComboBox(18).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(18).Valores(0, 1) = "0"
        vArrayDatosComboBox(18).Valores(1, 0) = "OTRO"
        vArrayDatosComboBox(18).Valores(1, 1) = "1"
        vArrayDatosComboBox(18).Ancho = 77
        vArrayDatosComboBox(18).Flag = True

        vArrayDatosComboBox(19).NombreCampo = "PER_TRANSP_PROPIO"
        vArrayDatosComboBox(19).Longitud = 23
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(1, 1)
        vArrayDatosComboBox(19).Valores(0, 0) = "NO TRANSPORTISTA PROPIO"
        vArrayDatosComboBox(19).Valores(0, 1) = "0"
        vArrayDatosComboBox(19).Valores(1, 0) = "SI TRANSPORTISTA PROPIO"
        vArrayDatosComboBox(19).Valores(1, 1) = "1"
        vArrayDatosComboBox(19).Ancho = 185
        vArrayDatosComboBox(19).Flag = True

        vArrayDatosComboBox(20).NombreCampo = "PER_BREVETE"
        vArrayDatosComboBox(20).Longitud = 9
        vArrayDatosComboBox(20).Tipo = "char"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(0, 0)
        vArrayDatosComboBox(20).Ancho = 100
        vArrayDatosComboBox(20).Flag = False

        vArrayDatosComboBox(21).NombreCampo = "PER_FORMA_VENTA"
        vArrayDatosComboBox(21).Longitud = 13
        vArrayDatosComboBox(21).Tipo = "varchar"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(4, 1)
        vArrayDatosComboBox(21).Valores(0, 0) = "TODAS"
        vArrayDatosComboBox(21).Valores(0, 1) = "0"
        vArrayDatosComboBox(21).Valores(1, 0) = "NINGUNO"
        vArrayDatosComboBox(21).Valores(1, 1) = "1"
        vArrayDatosComboBox(21).Valores(2, 0) = "CONTADO"
        vArrayDatosComboBox(21).Valores(2, 1) = "2"
        vArrayDatosComboBox(21).Valores(3, 0) = "CONTRAENTREGA"
        vArrayDatosComboBox(21).Valores(3, 1) = "3"
        vArrayDatosComboBox(21).Valores(4, 0) = "CREDITO"
        vArrayDatosComboBox(21).Valores(4, 1) = "4"
        vArrayDatosComboBox(21).Ancho = 126
        vArrayDatosComboBox(21).Flag = True

        vArrayDatosComboBox(22).NombreCampo = "DIR_ID"
        vArrayDatosComboBox(22).Longitud = 8
        vArrayDatosComboBox(22).Tipo = "char"
        vArrayDatosComboBox(22).ParteEntera = 0
        vArrayDatosComboBox(22).ParteDecimal = 0
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 96
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "DIR_DESCRIPCION"
        vArrayDatosComboBox(23).Longitud = 65
        vArrayDatosComboBox(23).Tipo = "varchar"
        vArrayDatosComboBox(23).ParteEntera = 0
        vArrayDatosComboBox(23).ParteDecimal = 0
        ReDim vArrayDatosComboBox(23).Valores(0, 0)
        vArrayDatosComboBox(23).Ancho = 699
        vArrayDatosComboBox(23).Flag = False

        vArrayDatosComboBox(24).NombreCampo = "DIR_REFERENCIA"
        vArrayDatosComboBox(24).Longitud = 65
        vArrayDatosComboBox(24).Tipo = "varchar"
        vArrayDatosComboBox(24).ParteEntera = 0
        vArrayDatosComboBox(24).ParteDecimal = 0
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 699
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "DIR_TIPO"
        vArrayDatosComboBox(25).Longitud = 9
        vArrayDatosComboBox(25).Tipo = "varchar"
        vArrayDatosComboBox(25).ParteEntera = 0
        vArrayDatosComboBox(25).ParteDecimal = 0
        ReDim vArrayDatosComboBox(25).Valores(3, 1)
        vArrayDatosComboBox(25).Valores(0, 0) = "DOMICILIO"
        vArrayDatosComboBox(25).Valores(0, 1) = "0"
        vArrayDatosComboBox(25).Valores(1, 0) = "ENTREGA"
        vArrayDatosComboBox(25).Valores(1, 1) = "1"
        vArrayDatosComboBox(25).Valores(2, 0) = "COBRANZA"
        vArrayDatosComboBox(25).Valores(2, 1) = "2"
        vArrayDatosComboBox(25).Valores(3, 0) = "FISCAL"
        vArrayDatosComboBox(25).Valores(3, 1) = "3"
        vArrayDatosComboBox(25).Ancho = 86
        vArrayDatosComboBox(25).Flag = True

        vArrayDatosComboBox(26).NombreCampo = "DIS_ID"
        vArrayDatosComboBox(26).Longitud = 3
        vArrayDatosComboBox(26).Tipo = "char"
        vArrayDatosComboBox(26).ParteEntera = 0
        vArrayDatosComboBox(26).ParteDecimal = 0
        ReDim vArrayDatosComboBox(26).Valores(0, 0)
        vArrayDatosComboBox(26).Ancho = 36
        vArrayDatosComboBox(26).Flag = False

        vArrayDatosComboBox(27).NombreCampo = "DIS_DESCRIPCION"
        vArrayDatosComboBox(27).Longitud = 45
        vArrayDatosComboBox(27).Tipo = "varchar"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(0, 0)
        vArrayDatosComboBox(27).Ancho = 485
        vArrayDatosComboBox(27).Flag = False

        vArrayDatosComboBox(28).NombreCampo = "PRO_ID"
        vArrayDatosComboBox(28).Longitud = 3
        vArrayDatosComboBox(28).Tipo = "char"
        vArrayDatosComboBox(28).ParteEntera = 0
        vArrayDatosComboBox(28).ParteDecimal = 0
        ReDim vArrayDatosComboBox(28).Valores(0, 0)
        vArrayDatosComboBox(28).Ancho = 36
        vArrayDatosComboBox(28).Flag = False

        vArrayDatosComboBox(29).NombreCampo = "PRO_DESCRIPCION"
        vArrayDatosComboBox(29).Longitud = 45
        vArrayDatosComboBox(29).Tipo = "varchar"
        vArrayDatosComboBox(29).ParteEntera = 0
        vArrayDatosComboBox(29).ParteDecimal = 0
        ReDim vArrayDatosComboBox(29).Valores(0, 0)
        vArrayDatosComboBox(29).Ancho = 485
        vArrayDatosComboBox(29).Flag = False

        vArrayDatosComboBox(30).NombreCampo = "DEP_ID"
        vArrayDatosComboBox(30).Longitud = 3
        vArrayDatosComboBox(30).Tipo = "char"
        vArrayDatosComboBox(30).ParteEntera = 0
        vArrayDatosComboBox(30).ParteDecimal = 0
        ReDim vArrayDatosComboBox(30).Valores(0, 0)
        vArrayDatosComboBox(30).Ancho = 36
        vArrayDatosComboBox(30).Flag = False

        vArrayDatosComboBox(31).NombreCampo = "DEP_DESCRIPCION"
        vArrayDatosComboBox(31).Longitud = 45
        vArrayDatosComboBox(31).Tipo = "varchar"
        vArrayDatosComboBox(31).ParteEntera = 0
        vArrayDatosComboBox(31).ParteDecimal = 0
        ReDim vArrayDatosComboBox(31).Valores(0, 0)
        vArrayDatosComboBox(31).Ancho = 485
        vArrayDatosComboBox(31).Flag = False

        vArrayDatosComboBox(32).NombreCampo = "PAI_ID"
        vArrayDatosComboBox(32).Longitud = 3
        vArrayDatosComboBox(32).Tipo = "char"
        vArrayDatosComboBox(32).ParteEntera = 0
        vArrayDatosComboBox(32).ParteDecimal = 0
        ReDim vArrayDatosComboBox(32).Valores(0, 0)
        vArrayDatosComboBox(32).Ancho = 36
        vArrayDatosComboBox(32).Flag = False

        vArrayDatosComboBox(33).NombreCampo = "PAI_DESCRIPCION"
        vArrayDatosComboBox(33).Longitud = 45
        vArrayDatosComboBox(33).Tipo = "varchar"
        vArrayDatosComboBox(33).ParteEntera = 0
        vArrayDatosComboBox(33).ParteDecimal = 0
        ReDim vArrayDatosComboBox(33).Valores(0, 0)
        vArrayDatosComboBox(33).Ancho = 485
        vArrayDatosComboBox(33).Flag = False

        vArrayDatosComboBox(34).NombreCampo = "PER_TELEFONOS"
        vArrayDatosComboBox(34).Longitud = 90
        vArrayDatosComboBox(34).Tipo = "varchar"
        vArrayDatosComboBox(34).ParteEntera = 0
        vArrayDatosComboBox(34).ParteDecimal = 0
        ReDim vArrayDatosComboBox(34).Valores(0, 0)
        vArrayDatosComboBox(34).Ancho = 975
        vArrayDatosComboBox(34).Flag = False

        vArrayDatosComboBox(35).NombreCampo = "PER_EMAIL"
        vArrayDatosComboBox(35).Longitud = 50
        vArrayDatosComboBox(35).Tipo = "varchar"
        vArrayDatosComboBox(35).ParteEntera = 0
        vArrayDatosComboBox(35).ParteDecimal = 0
        ReDim vArrayDatosComboBox(35).Valores(0, 0)
        vArrayDatosComboBox(35).Ancho = 539
        vArrayDatosComboBox(35).Flag = False

        vArrayDatosComboBox(36).NombreCampo = "PER_PAGINA_WEB"
        vArrayDatosComboBox(36).Longitud = 50
        vArrayDatosComboBox(36).Tipo = "varchar"
        vArrayDatosComboBox(36).ParteEntera = 0
        vArrayDatosComboBox(36).ParteDecimal = 0
        ReDim vArrayDatosComboBox(36).Valores(0, 0)
        vArrayDatosComboBox(36).Ancho = 539
        vArrayDatosComboBox(36).Flag = False

        vArrayDatosComboBox(37).NombreCampo = "PER_LINEA_CREDITO"
        vArrayDatosComboBox(37).Longitud = 18
        vArrayDatosComboBox(37).Tipo = "numeric"
        vArrayDatosComboBox(37).ParteEntera = 14
        vArrayDatosComboBox(37).ParteDecimal = 4
        ReDim vArrayDatosComboBox(37).Valores(0, 0)
        vArrayDatosComboBox(37).Ancho = 197
        vArrayDatosComboBox(37).Flag = False

        vArrayDatosComboBox(38).NombreCampo = "PER_DIAS_CREDITO"
        vArrayDatosComboBox(38).Longitud = 10
        vArrayDatosComboBox(38).Tipo = "int"
        vArrayDatosComboBox(38).ParteEntera = 10
        vArrayDatosComboBox(38).ParteDecimal = 0
        ReDim vArrayDatosComboBox(38).Valores(0, 0)
        vArrayDatosComboBox(38).Ancho = 111
        vArrayDatosComboBox(38).Flag = False

        vArrayDatosComboBox(39).NombreCampo = "PER_ID_VEN"
        vArrayDatosComboBox(39).Longitud = 6
        vArrayDatosComboBox(39).Tipo = "char"
        vArrayDatosComboBox(39).ParteEntera = 0
        vArrayDatosComboBox(39).ParteDecimal = 0
        ReDim vArrayDatosComboBox(39).Valores(0, 0)
        vArrayDatosComboBox(39).Ancho = 68
        vArrayDatosComboBox(39).Flag = False

        vArrayDatosComboBox(40).NombreCampo = "PER_DESCRIPCION_VEN"
        vArrayDatosComboBox(40).Longitud = 77
        vArrayDatosComboBox(40).Tipo = "varchar"
        vArrayDatosComboBox(40).ParteEntera = 0
        vArrayDatosComboBox(40).ParteDecimal = 0
        ReDim vArrayDatosComboBox(40).Valores(0, 0)
        vArrayDatosComboBox(40).Ancho = 828
        vArrayDatosComboBox(40).Flag = False

        vArrayDatosComboBox(41).NombreCampo = "PER_ID_COB"
        vArrayDatosComboBox(41).Longitud = 6
        vArrayDatosComboBox(41).Tipo = "char"
        vArrayDatosComboBox(41).ParteEntera = 0
        vArrayDatosComboBox(41).ParteDecimal = 0
        ReDim vArrayDatosComboBox(41).Valores(0, 0)
        vArrayDatosComboBox(41).Ancho = 68
        vArrayDatosComboBox(41).Flag = False

        vArrayDatosComboBox(42).NombreCampo = "PER_DESCRIPCION_COB"
        vArrayDatosComboBox(42).Longitud = 77
        vArrayDatosComboBox(42).Tipo = "varchar"
        vArrayDatosComboBox(42).ParteEntera = 0
        vArrayDatosComboBox(42).ParteDecimal = 0
        ReDim vArrayDatosComboBox(42).Valores(0, 0)
        vArrayDatosComboBox(42).Ancho = 828
        vArrayDatosComboBox(42).Flag = False

        vArrayDatosComboBox(43).NombreCampo = "PER_ID_TRA"
        vArrayDatosComboBox(43).Longitud = 6
        vArrayDatosComboBox(43).Tipo = "char"
        vArrayDatosComboBox(43).ParteEntera = 0
        vArrayDatosComboBox(43).ParteDecimal = 0
        ReDim vArrayDatosComboBox(43).Valores(0, 0)
        vArrayDatosComboBox(43).Ancho = 68
        vArrayDatosComboBox(43).Flag = False

        vArrayDatosComboBox(44).NombreCampo = "PER_DESCRIPCION_TRA"
        vArrayDatosComboBox(44).Longitud = 77
        vArrayDatosComboBox(44).Tipo = "varchar"
        vArrayDatosComboBox(44).ParteEntera = 0
        vArrayDatosComboBox(44).ParteDecimal = 0
        ReDim vArrayDatosComboBox(44).Valores(0, 0)
        vArrayDatosComboBox(44).Ancho = 828
        vArrayDatosComboBox(44).Flag = False

        vArrayDatosComboBox(45).NombreCampo = "PER_ID_BAN"
        vArrayDatosComboBox(45).Longitud = 6
        vArrayDatosComboBox(45).Tipo = "char"
        vArrayDatosComboBox(45).ParteEntera = 0
        vArrayDatosComboBox(45).ParteDecimal = 0
        ReDim vArrayDatosComboBox(45).Valores(0, 0)
        vArrayDatosComboBox(45).Ancho = 68
        vArrayDatosComboBox(45).Flag = False

        vArrayDatosComboBox(46).NombreCampo = "PER_DESCRIPCION_BAN"
        vArrayDatosComboBox(46).Longitud = 77
        vArrayDatosComboBox(46).Tipo = "varchar"
        vArrayDatosComboBox(46).ParteEntera = 0
        vArrayDatosComboBox(46).ParteDecimal = 0
        ReDim vArrayDatosComboBox(46).Valores(0, 0)
        vArrayDatosComboBox(46).Ancho = 828
        vArrayDatosComboBox(46).Flag = False

        vArrayDatosComboBox(47).NombreCampo = "PER_ID_GRU"
        vArrayDatosComboBox(47).Longitud = 6
        vArrayDatosComboBox(47).Tipo = "char"
        vArrayDatosComboBox(47).ParteEntera = 0
        vArrayDatosComboBox(47).ParteDecimal = 0
        ReDim vArrayDatosComboBox(47).Valores(0, 0)
        vArrayDatosComboBox(47).Ancho = 68
        vArrayDatosComboBox(47).Flag = False

        vArrayDatosComboBox(48).NombreCampo = "PER_DESCRIPCION_GRU"
        vArrayDatosComboBox(48).Longitud = 77
        vArrayDatosComboBox(48).Tipo = "varchar"
        vArrayDatosComboBox(48).ParteEntera = 0
        vArrayDatosComboBox(48).ParteDecimal = 0
        ReDim vArrayDatosComboBox(48).Valores(0, 0)
        vArrayDatosComboBox(48).Ancho = 828
        vArrayDatosComboBox(48).Flag = False

        vArrayDatosComboBox(49).NombreCampo = "PER_DIASEM_PAGO"
        vArrayDatosComboBox(49).Longitud = 9
        vArrayDatosComboBox(49).Tipo = "varchar"
        vArrayDatosComboBox(49).ParteEntera = 0
        vArrayDatosComboBox(49).ParteDecimal = 0
        ReDim vArrayDatosComboBox(49).Valores(7, 1)
        vArrayDatosComboBox(49).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(49).Valores(0, 1) = "0"
        vArrayDatosComboBox(49).Valores(1, 0) = "LUNES"
        vArrayDatosComboBox(49).Valores(1, 1) = "1"
        vArrayDatosComboBox(49).Valores(2, 0) = "MARTES"
        vArrayDatosComboBox(49).Valores(2, 1) = "2"
        vArrayDatosComboBox(49).Valores(3, 0) = "MIERCOLES"
        vArrayDatosComboBox(49).Valores(3, 1) = "3"
        vArrayDatosComboBox(49).Valores(4, 0) = "JUEVES"
        vArrayDatosComboBox(49).Valores(4, 1) = "4"
        vArrayDatosComboBox(49).Valores(5, 0) = "VIERNES"
        vArrayDatosComboBox(49).Valores(5, 1) = "5"
        vArrayDatosComboBox(49).Valores(6, 0) = "SABADO"
        vArrayDatosComboBox(49).Valores(6, 1) = "6"
        vArrayDatosComboBox(49).Valores(7, 0) = "DOMINGO"
        vArrayDatosComboBox(49).Valores(7, 1) = "7"
        vArrayDatosComboBox(49).Ancho = 90
        vArrayDatosComboBox(49).Flag = True

        vArrayDatosComboBox(50).NombreCampo = "PER_COND_DIASEM"
        vArrayDatosComboBox(50).Longitud = 18
        vArrayDatosComboBox(50).Tipo = "varchar"
        vArrayDatosComboBox(50).ParteEntera = 0
        vArrayDatosComboBox(50).ParteDecimal = 0
        ReDim vArrayDatosComboBox(50).Valores(2, 1)
        vArrayDatosComboBox(50).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(50).Valores(0, 1) = "0"
        vArrayDatosComboBox(50).Valores(1, 0) = "CADA SEMANA"
        vArrayDatosComboBox(50).Valores(1, 1) = "1"
        vArrayDatosComboBox(50).Valores(2, 0) = "ULTIMO DE CADA MES"
        vArrayDatosComboBox(50).Valores(2, 1) = "2"
        vArrayDatosComboBox(50).Ancho = 147
        vArrayDatosComboBox(50).Flag = True

        vArrayDatosComboBox(51).NombreCampo = "PER_DIAMES_PAGO"
        vArrayDatosComboBox(51).Longitud = 5
        vArrayDatosComboBox(51).Tipo = "smallint"
        vArrayDatosComboBox(51).ParteEntera = 5
        vArrayDatosComboBox(51).ParteDecimal = 0
        ReDim vArrayDatosComboBox(51).Valores(0, 0)
        vArrayDatosComboBox(51).Ancho = 58
        vArrayDatosComboBox(51).Flag = False

        vArrayDatosComboBox(52).NombreCampo = "PER_DOC_PAGO"
        vArrayDatosComboBox(52).Longitud = 29
        vArrayDatosComboBox(52).Tipo = "varchar"
        vArrayDatosComboBox(52).ParteEntera = 0
        vArrayDatosComboBox(52).ParteDecimal = 0
        ReDim vArrayDatosComboBox(52).Valores(3, 1)
        vArrayDatosComboBox(52).Valores(0, 0) = "NINGUNO"
        vArrayDatosComboBox(52).Valores(0, 1) = "0"
        vArrayDatosComboBox(52).Valores(1, 0) = "DOCUMENTO VENTA"
        vArrayDatosComboBox(52).Valores(1, 1) = "1"
        vArrayDatosComboBox(52).Valores(2, 0) = "DOCUMENTO DE DESPACHO"
        vArrayDatosComboBox(52).Valores(2, 1) = "2"
        vArrayDatosComboBox(52).Valores(3, 0) = "DOCUMENTO DE VENTA Y DESPACHO"
        vArrayDatosComboBox(52).Valores(3, 1) = "3"
        vArrayDatosComboBox(52).Ancho = 234
        vArrayDatosComboBox(52).Flag = True

        vArrayDatosComboBox(53).NombreCampo = "PER_HORA_PAGO"
        vArrayDatosComboBox(53).Longitud = 25
        vArrayDatosComboBox(53).Tipo = "varchar"
        vArrayDatosComboBox(53).ParteEntera = 0
        vArrayDatosComboBox(53).ParteDecimal = 0
        ReDim vArrayDatosComboBox(53).Valores(0, 0)
        vArrayDatosComboBox(53).Ancho = 272
        vArrayDatosComboBox(53).Flag = False

        vArrayDatosComboBox(54).NombreCampo = "PER_OBSERVACIONES"
        vArrayDatosComboBox(54).Longitud = 255
        vArrayDatosComboBox(54).Tipo = "varchar"
        vArrayDatosComboBox(54).ParteEntera = 0
        vArrayDatosComboBox(54).ParteDecimal = 0
        ReDim vArrayDatosComboBox(54).Valores(0, 0)
        vArrayDatosComboBox(54).Ancho = 2731
        vArrayDatosComboBox(54).Flag = False

        vArrayDatosComboBox(55).NombreCampo = "PER_PROMOCIONES"
        vArrayDatosComboBox(55).Longitud = 21
        vArrayDatosComboBox(55).Tipo = "varchar"
        vArrayDatosComboBox(55).ParteEntera = 0
        vArrayDatosComboBox(55).ParteDecimal = 0
        ReDim vArrayDatosComboBox(55).Valores(1, 1)
        vArrayDatosComboBox(55).Valores(0, 0) = "NO ACEPTA PROMOCIONES"
        vArrayDatosComboBox(55).Valores(0, 1) = "0"
        vArrayDatosComboBox(55).Valores(1, 0) = "ACEPTA PROMOCIONES"
        vArrayDatosComboBox(55).Valores(1, 1) = "1"
        vArrayDatosComboBox(55).Ancho = 178
        vArrayDatosComboBox(55).Flag = True

        vArrayDatosComboBox(56).NombreCampo = "PER_CARTA_FIANZA"
        vArrayDatosComboBox(56).Longitud = 27
        vArrayDatosComboBox(56).Tipo = "varchar"
        vArrayDatosComboBox(56).ParteEntera = 0
        vArrayDatosComboBox(56).ParteDecimal = 0
        ReDim vArrayDatosComboBox(56).Valores(1, 1)
        vArrayDatosComboBox(56).Valores(0, 0) = "NO TRABAJA CON CARTA FIANZA"
        vArrayDatosComboBox(56).Valores(0, 1) = "0"
        vArrayDatosComboBox(56).Valores(1, 0) = "TRABAJA CON CARTA FIANZA"
        vArrayDatosComboBox(56).Valores(1, 1) = "1"
        vArrayDatosComboBox(56).Ancho = 207
        vArrayDatosComboBox(56).Flag = True

        vArrayDatosComboBox(57).NombreCampo = "PER_CUOTA_MENSUAL"
        vArrayDatosComboBox(57).Longitud = 18
        vArrayDatosComboBox(57).Tipo = "numeric"
        vArrayDatosComboBox(57).ParteEntera = 15
        vArrayDatosComboBox(57).ParteDecimal = 3
        ReDim vArrayDatosComboBox(57).Valores(0, 0)
        vArrayDatosComboBox(57).Ancho = 197
        vArrayDatosComboBox(57).Flag = False

        vArrayDatosComboBox(58).NombreCampo = "PER_CUOTA_OBJETIVO"
        vArrayDatosComboBox(58).Longitud = 18
        vArrayDatosComboBox(58).Tipo = "numeric"
        vArrayDatosComboBox(58).ParteEntera = 15
        vArrayDatosComboBox(58).ParteDecimal = 3
        ReDim vArrayDatosComboBox(58).Valores(0, 0)
        vArrayDatosComboBox(58).Ancho = 197
        vArrayDatosComboBox(58).Flag = False

        vArrayDatosComboBox(59).NombreCampo = "PER_BONO"
        vArrayDatosComboBox(59).Longitud = 18
        vArrayDatosComboBox(59).Tipo = "numeric"
        vArrayDatosComboBox(59).ParteEntera = 14
        vArrayDatosComboBox(59).ParteDecimal = 4
        ReDim vArrayDatosComboBox(59).Valores(0, 0)
        vArrayDatosComboBox(59).Ancho = 197
        vArrayDatosComboBox(59).Flag = False

        vArrayDatosComboBox(60).NombreCampo = "CCC_ID_CLI"
        vArrayDatosComboBox(60).Longitud = 3
        vArrayDatosComboBox(60).Tipo = "char"
        vArrayDatosComboBox(60).ParteEntera = 0
        vArrayDatosComboBox(60).ParteDecimal = 0
        ReDim vArrayDatosComboBox(60).Valores(0, 0)
        vArrayDatosComboBox(60).Ancho = 36
        vArrayDatosComboBox(60).Flag = False

        vArrayDatosComboBox(61).NombreCampo = "CCC_DESCRIPCION_CLI"
        vArrayDatosComboBox(61).Longitud = 65
        vArrayDatosComboBox(61).Tipo = "varchar"
        vArrayDatosComboBox(61).ParteEntera = 0
        vArrayDatosComboBox(61).ParteDecimal = 0
        ReDim vArrayDatosComboBox(61).Valores(0, 0)
        vArrayDatosComboBox(61).Ancho = 699
        vArrayDatosComboBox(61).Flag = False

        vArrayDatosComboBox(62).NombreCampo = "CCC_CUENTA_BANCARIA_CLI"
        vArrayDatosComboBox(62).Longitud = 45
        vArrayDatosComboBox(62).Tipo = "varchar"
        vArrayDatosComboBox(62).ParteEntera = 0
        vArrayDatosComboBox(62).ParteDecimal = 0
        ReDim vArrayDatosComboBox(62).Valores(0, 0)
        vArrayDatosComboBox(62).Ancho = 485
        vArrayDatosComboBox(62).Flag = False

        vArrayDatosComboBox(63).NombreCampo = "PER_ID_BAN_CLI"
        vArrayDatosComboBox(63).Longitud = 6
        vArrayDatosComboBox(63).Tipo = "char"
        vArrayDatosComboBox(63).ParteEntera = 0
        vArrayDatosComboBox(63).ParteDecimal = 0
        ReDim vArrayDatosComboBox(63).Valores(0, 0)
        vArrayDatosComboBox(63).Ancho = 68
        vArrayDatosComboBox(63).Flag = False

        vArrayDatosComboBox(64).NombreCampo = "PER_DESCRIPCION_BAN_CLI"
        vArrayDatosComboBox(64).Longitud = 77
        vArrayDatosComboBox(64).Tipo = "varchar"
        vArrayDatosComboBox(64).ParteEntera = 0
        vArrayDatosComboBox(64).ParteDecimal = 0
        ReDim vArrayDatosComboBox(64).Valores(0, 0)
        vArrayDatosComboBox(64).Ancho = 828
        vArrayDatosComboBox(64).Flag = False

        vArrayDatosComboBox(65).NombreCampo = "PER_CARGO"
        vArrayDatosComboBox(65).Longitud = 50
        vArrayDatosComboBox(65).Tipo = "varchar"
        vArrayDatosComboBox(65).ParteEntera = 0
        vArrayDatosComboBox(65).ParteDecimal = 0
        ReDim vArrayDatosComboBox(65).Valores(0, 0)
        vArrayDatosComboBox(65).Ancho = 544
        vArrayDatosComboBox(65).Flag = False

        vArrayDatosComboBox(66).NombreCampo = "PER_REP_LEGAL"
        vArrayDatosComboBox(66).Longitud = 22
        vArrayDatosComboBox(66).Tipo = "varchar"
        vArrayDatosComboBox(66).ParteEntera = 0
        vArrayDatosComboBox(66).ParteDecimal = 0
        ReDim vArrayDatosComboBox(66).Valores(1, 1)
        vArrayDatosComboBox(66).Valores(0, 0) = "NO REPRESENTANTE LEGAL"
        vArrayDatosComboBox(66).Valores(0, 1) = "0"
        vArrayDatosComboBox(66).Valores(1, 0) = "SI REPRESENTANTE LEGAL"
        vArrayDatosComboBox(66).Valores(1, 1) = "1"
        vArrayDatosComboBox(66).Ancho = 182
        vArrayDatosComboBox(66).Flag = True

        vArrayDatosComboBox(67).NombreCampo = "PER_FIRMA_AUT"
        vArrayDatosComboBox(67).Longitud = 25
        vArrayDatosComboBox(67).Tipo = "varchar"
        vArrayDatosComboBox(67).ParteEntera = 0
        vArrayDatosComboBox(67).ParteDecimal = 0
        ReDim vArrayDatosComboBox(67).Valores(1, 1)
        vArrayDatosComboBox(67).Valores(0, 0) = "NO TIENE FIRMA AUTORIZADA"
        vArrayDatosComboBox(67).Valores(0, 1) = "0"
        vArrayDatosComboBox(67).Valores(1, 0) = "SI TIENE FIRMA AUTORIZADA"
        vArrayDatosComboBox(67).Valores(1, 1) = "1"
        vArrayDatosComboBox(67).Ancho = 191
        vArrayDatosComboBox(67).Flag = True

        vArrayDatosComboBox(68).NombreCampo = "PER_PROCESAR_DESCUENTO"
        vArrayDatosComboBox(68).Longitud = 21
        vArrayDatosComboBox(68).Tipo = "varchar"
        vArrayDatosComboBox(68).ParteEntera = 0
        vArrayDatosComboBox(68).ParteDecimal = 0
        ReDim vArrayDatosComboBox(68).Valores(1, 1)
        vArrayDatosComboBox(68).Valores(0, 0) = "NO PROCESA DESCUENTOS"
        vArrayDatosComboBox(68).Valores(0, 1) = "0"
        vArrayDatosComboBox(68).Valores(1, 0) = "SI PROCESA DESCUENTOS"
        vArrayDatosComboBox(68).Valores(1, 1) = "1"
        vArrayDatosComboBox(68).Ancho = 225
        vArrayDatosComboBox(68).Flag = False

        vArrayDatosComboBox(69).NombreCampo = "PER_ALIAS"
        vArrayDatosComboBox(69).Longitud = 255
        vArrayDatosComboBox(69).Tipo = "varchar"
        vArrayDatosComboBox(69).ParteEntera = 0
        vArrayDatosComboBox(69).ParteDecimal = 0
        ReDim vArrayDatosComboBox(69).Valores(0, 0)
        vArrayDatosComboBox(69).Ancho = 2731
        vArrayDatosComboBox(69).Flag = False

        vArrayDatosComboBox(70).NombreCampo = "PER_LINEA_CREDITO_ESTADO"
        vArrayDatosComboBox(70).Longitud = 9
        vArrayDatosComboBox(70).Tipo = "varchar"
        vArrayDatosComboBox(70).ParteEntera = 0
        vArrayDatosComboBox(70).ParteDecimal = 0
        ReDim vArrayDatosComboBox(70).Valores(1, 1)
        vArrayDatosComboBox(70).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(70).Valores(0, 1) = "0"
        vArrayDatosComboBox(70).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(70).Valores(1, 1) = "1"
        vArrayDatosComboBox(70).Ancho = 85
        vArrayDatosComboBox(70).Flag = True

        vArrayDatosComboBox(71).NombreCampo = "PER_ESTADO"
        vArrayDatosComboBox(71).Longitud = 9
        vArrayDatosComboBox(71).Tipo = "varchar"
        vArrayDatosComboBox(71).ParteEntera = 0
        vArrayDatosComboBox(71).ParteDecimal = 0
        ReDim vArrayDatosComboBox(71).Valores(1, 1)
        vArrayDatosComboBox(71).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(71).Valores(0, 1) = "0"
        vArrayDatosComboBox(71).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(71).Valores(1, 1) = "1"
        vArrayDatosComboBox(71).Ancho = 85
        vArrayDatosComboBox(71).Flag = True
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

                Case "PER_CLIENTE"
                    If PER_CLIENTE.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_CLIENTE_OP_CON"
                    If PER_CLIENTE_OP_CON >= 0 And PER_CLIENTE_OP_CON <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_PROVEEDOR"
                    If PER_PROVEEDOR.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_PROVEEDOR_OP_CON"
                    If PER_PROVEEDOR_OP_CON >= 0 And PER_PROVEEDOR_OP_CON <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_TRANSPORTISTA"
                    If PER_TRANSPORTISTA.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_TRANSPORTISTA_OP_CON"
                    If PER_TRANSPORTISTA_OP_CON >= 0 And PER_TRANSPORTISTA_OP_CON <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_TRABAJADOR"
                    If PER_TRABAJADOR.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_TRABAJADOR_OP_CON"
                    If PER_TRABAJADOR_OP_CON >= 0 And PER_TRABAJADOR_OP_CON <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_BANCO"
                    If PER_BANCO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_BANCO_OP_CON"
                    If PER_BANCO_OP_CON >= 0 And PER_BANCO_OP_CON <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_GRUPO"
                    If PER_GRUPO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_GRUPO_OP_CON"
                    If PER_GRUPO_OP_CON >= 0 And PER_GRUPO_OP_CON <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_CONTACTO"
                    If PER_CONTACTO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_CONTACTO_OP_CON"
                    If PER_CONTACTO_OP_CON >= 0 And PER_CONTACTO_OP_CON <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_TRANSP_PROPIO"
                    If PER_TRANSP_PROPIO >= 0 And PER_TRANSP_PROPIO <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_APE_PAT"
                    If Len(PER_APE_PAT.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_FORMA_VENTA"
                    If PER_FORMA_VENTA >= 0 And PER_FORMA_VENTA <= 4 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_LINEA_CREDITO"
                    If PER_LINEA_CREDITO.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_DIAS_CREDITO"
                    If PER_DIAS_CREDITO.GetType = GetType(Int16) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_DIASEM_PAGO"
                    If PER_DIASEM_PAGO >= 0 And PER_DIASEM_PAGO <= 7 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_COND_DIASEM"
                    If PER_COND_DIASEM >= 0 And PER_COND_DIASEM <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_DIAMES_PAGO"
                    If PER_DIAMES_PAGO >= 0 And PER_DIAMES_PAGO <= 31 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_DOC_PAGO"
                    If PER_DOC_PAGO >= 0 And PER_DOC_PAGO <= 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_PROMOCIONES"
                    If PER_PROMOCIONES.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_CARTA_FIANZA"
                    If PER_CARTA_FIANZA >= 0 And PER_CARTA_FIANZA <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_CUOTA_MENSUAL"
                    If PER_CUOTA_MENSUAL.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_BONO"
                    If PER_BONO.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_REP_LEGAL"
                    If PER_REP_LEGAL.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_FIRMA_AUT"
                    If PER_FIRMA_AUT.GetType = GetType(Boolean) Then
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

                Case "PER_PROCESAR_DESCUENTO"
                    If PER_ESTADO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_FEC_GRAB"
                    If PER_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_LINEA_CREDITO_ESTADO"
                    If PER_LINEA_CREDITO_ESTADO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_ESTADO"
                    If PER_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaPersonasXML"
        End If
        If Vista = "BuscarRegistrosPersonal" Then
            SentenciaSqlBusqueda = "spVistaPersonasPrestamoXML"
        End If
        If Vista = "BuscarRegistroConDocumento" Then
            SentenciaSqlBusqueda = "spVistaPersonaConDocumentoXML"
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

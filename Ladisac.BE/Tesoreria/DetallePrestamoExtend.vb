Imports Ladisac.BE
Partial Public Class DetallePrestamo
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
    Public CampoPrincipalSecundario = "DTD_ID"
    Public CampoPrincipalTercero = "CCC_ID"
    Public CampoPrincipalCuarto = "DPR_SERIE"
    Public CampoPrincipalQuinto = "DPR_NUMERO"
    Public CampoPrincipalSexto = "DPR_ITEM"
    Public CampoPrincipalValor = TDO_ID
    Public CampoPrincipalSecundarioValor = DTD_ID
    Public CampoPrincipalTerceroValor = CCC_ID
    Public CampoPrincipalCuartoValor = DPR_SERIE
    Public CampoPrincipalQuintoValor = DPR_NUMERO
    Public CampoPrincipalSextoValor = DPR_ITEM
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Tes.DetallePrestamo"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetallePrestamo"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetallePrestamo"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetallePrestamo"
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
        vElementosDatosComboBox = 39
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "DPR_ITEM"
        vArrayCamposBusqueda(1) = "PRE_FECHA_EMI"
        vArrayCamposBusqueda(2) = "PER_ID_CAJ"
        vArrayCamposBusqueda(3) = "PER_DESCRIPCION_CAJ"
        vArrayCamposBusqueda(4) = "PVE_ID"
        vArrayCamposBusqueda(5) = "PVE_DESCRIPCION"
        vArrayCamposBusqueda(6) = "PRE_MONTO_TOTAL"
        vArrayCamposBusqueda(7) = "TDO_ID"
        vArrayCamposBusqueda(8) = "TDO_DESCRIPCION"
        vArrayCamposBusqueda(9) = "DTD_ID"
        vArrayCamposBusqueda(10) = "DTD_DESCRIPCION"
        vArrayCamposBusqueda(11) = "CCC_ID"
        vArrayCamposBusqueda(12) = "CCC_DESCRIPCION"
        vArrayCamposBusqueda(13) = "PRE_SERIE"
        vArrayCamposBusqueda(14) = "PRE_NUMERO"
        vArrayCamposBusqueda(15) = "CCT_ID"
        vArrayCamposBusqueda(16) = "CCT_DESCRIPCION"
        vArrayCamposBusqueda(17) = "MON_ID"
        vArrayCamposBusqueda(18) = "MON_DESCRIPCION"
        vArrayCamposBusqueda(19) = "PER_ID_CLI"
        vArrayCamposBusqueda(20) = "PER_DESCRIPCION_CLI"
        vArrayCamposBusqueda(21) = "DPR_FEC_VEN"
        vArrayCamposBusqueda(22) = "DPR_CAPITAL"
        vArrayCamposBusqueda(23) = "DPR_INTERES"
        vArrayCamposBusqueda(24) = "DPR_GASTOS"
        vArrayCamposBusqueda(25) = "DPR_IMPORTE"
        vArrayCamposBusqueda(26) = "DPR_CONTRAVALOR"
        vArrayCamposBusqueda(27) = "TDO_ID_DOC"
        vArrayCamposBusqueda(28) = "TDO_DESCRIPCION_DOC"
        vArrayCamposBusqueda(29) = "DTD_ID_DOC"
        vArrayCamposBusqueda(30) = "DTD_DESCRIPCION_DOC"
        vArrayCamposBusqueda(31) = "CCT_ID_DOC"
        vArrayCamposBusqueda(32) = "CCT_DESCRIPCION_DOC"
        vArrayCamposBusqueda(33) = "DPR_SERIE_DOC"
        vArrayCamposBusqueda(34) = "DPR_NUMERO_DOC"
        vArrayCamposBusqueda(35) = "PER_ID_CLI_DOC"
        vArrayCamposBusqueda(36) = "PER_DESCRIPCION_CLI_DOC"
        vArrayCamposBusqueda(37) = "DPR_OBSERVACIONES"
        vArrayCamposBusqueda(38) = "DPR_ESTADO"
        vArrayCamposBusqueda(39) = "PRE_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "DPR_ITEM"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "numeric"
        vArrayDatosComboBox(0).ParteEntera = 3
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "PRE_FECHA_EMI"
        vArrayDatosComboBox(1).Longitud = 0
        vArrayDatosComboBox(1).Tipo = "smalldatetime"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 15
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "PER_ID_CAJ"
        vArrayDatosComboBox(2).Longitud = 6
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 68
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PER_DESCRIPCION_CAJ"
        vArrayDatosComboBox(3).Longitud = 77
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 828
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PVE_ID"
        vArrayDatosComboBox(4).Longitud = 3
        vArrayDatosComboBox(4).Tipo = "char"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 36
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "PVE_DESCRIPCION"
        vArrayDatosComboBox(5).Longitud = 45
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 485
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "PRE_MONTO_TOTAL"
        vArrayDatosComboBox(6).Longitud = 18
        vArrayDatosComboBox(6).Tipo = "numeric"
        vArrayDatosComboBox(6).ParteEntera = 14
        vArrayDatosComboBox(6).ParteDecimal = 4
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 197
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "TDO_ID"
        vArrayDatosComboBox(7).Longitud = 3
        vArrayDatosComboBox(7).Tipo = "char"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 36
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "TDO_DESCRIPCION"
        vArrayDatosComboBox(8).Longitud = 45
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 485
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "DTD_ID"
        vArrayDatosComboBox(9).Longitud = 3
        vArrayDatosComboBox(9).Tipo = "char"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 36
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "DTD_DESCRIPCION"
        vArrayDatosComboBox(10).Longitud = 45
        vArrayDatosComboBox(10).Tipo = "varchar"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 485
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "CCC_ID"
        vArrayDatosComboBox(11).Longitud = 3
        vArrayDatosComboBox(11).Tipo = "char"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 36
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "CCC_DESCRIPCION"
        vArrayDatosComboBox(12).Longitud = 189
        vArrayDatosComboBox(12).Tipo = "varchar"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 2025
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "PRE_SERIE"
        vArrayDatosComboBox(13).Longitud = 3
        vArrayDatosComboBox(13).Tipo = "char"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 36
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "PRE_NUMERO"
        vArrayDatosComboBox(14).Longitud = 10
        vArrayDatosComboBox(14).Tipo = "char"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 111
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "CCT_ID"
        vArrayDatosComboBox(15).Longitud = 3
        vArrayDatosComboBox(15).Tipo = "char"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 36
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "CCT_DESCRIPCION"
        vArrayDatosComboBox(16).Longitud = 45
        vArrayDatosComboBox(16).Tipo = "varchar"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 485
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "MON_ID"
        vArrayDatosComboBox(17).Longitud = 3
        vArrayDatosComboBox(17).Tipo = "char"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 36
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "MON_DESCRIPCION"
        vArrayDatosComboBox(18).Longitud = 45
        vArrayDatosComboBox(18).Tipo = "varchar"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(0, 0)
        vArrayDatosComboBox(18).Ancho = 485
        vArrayDatosComboBox(18).Flag = False

        vArrayDatosComboBox(19).NombreCampo = "PER_ID_CLI"
        vArrayDatosComboBox(19).Longitud = 6
        vArrayDatosComboBox(19).Tipo = "char"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(0, 0)
        vArrayDatosComboBox(19).Ancho = 68
        vArrayDatosComboBox(19).Flag = False

        vArrayDatosComboBox(20).NombreCampo = "PER_DESCRIPCION_CLI"
        vArrayDatosComboBox(20).Longitud = 77
        vArrayDatosComboBox(20).Tipo = "varchar"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(0, 0)
        vArrayDatosComboBox(20).Ancho = 828
        vArrayDatosComboBox(20).Flag = False

        vArrayDatosComboBox(21).NombreCampo = "DPR_FEC_VEN"
        vArrayDatosComboBox(21).Longitud = 0
        vArrayDatosComboBox(21).Tipo = "smalldatetime"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(0, 0)
        vArrayDatosComboBox(21).Ancho = 15
        vArrayDatosComboBox(21).Flag = False

        vArrayDatosComboBox(22).NombreCampo = "DPR_CAPITAL"
        vArrayDatosComboBox(22).Longitud = 18
        vArrayDatosComboBox(22).Tipo = "numeric"
        vArrayDatosComboBox(22).ParteEntera = 14
        vArrayDatosComboBox(22).ParteDecimal = 4
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 197
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "DPR_INTERES"
        vArrayDatosComboBox(23).Longitud = 18
        vArrayDatosComboBox(23).Tipo = "numeric"
        vArrayDatosComboBox(23).ParteEntera = 14
        vArrayDatosComboBox(23).ParteDecimal = 4
        ReDim vArrayDatosComboBox(23).Valores(0, 0)
        vArrayDatosComboBox(23).Ancho = 197
        vArrayDatosComboBox(23).Flag = False

        vArrayDatosComboBox(24).NombreCampo = "DPR_GASTOS"
        vArrayDatosComboBox(24).Longitud = 18
        vArrayDatosComboBox(24).Tipo = "numeric"
        vArrayDatosComboBox(24).ParteEntera = 14
        vArrayDatosComboBox(24).ParteDecimal = 4
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 197
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "DPR_IMPORTE_DOC"
        vArrayDatosComboBox(25).Longitud = 18
        vArrayDatosComboBox(25).Tipo = "numeric"
        vArrayDatosComboBox(25).ParteEntera = 14
        vArrayDatosComboBox(25).ParteDecimal = 4
        ReDim vArrayDatosComboBox(25).Valores(0, 0)
        vArrayDatosComboBox(25).Ancho = 197
        vArrayDatosComboBox(25).Flag = False

        vArrayDatosComboBox(26).NombreCampo = "DPR_CONTRAVALOR_DOC"
        vArrayDatosComboBox(26).Longitud = 18
        vArrayDatosComboBox(26).Tipo = "numeric"
        vArrayDatosComboBox(26).ParteEntera = 14
        vArrayDatosComboBox(26).ParteDecimal = 4
        ReDim vArrayDatosComboBox(26).Valores(0, 0)
        vArrayDatosComboBox(26).Ancho = 197
        vArrayDatosComboBox(26).Flag = False

        vArrayDatosComboBox(27).NombreCampo = "TDO_ID_DOC"
        vArrayDatosComboBox(27).Longitud = 3
        vArrayDatosComboBox(27).Tipo = "char"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(0, 0)
        vArrayDatosComboBox(27).Ancho = 36
        vArrayDatosComboBox(27).Flag = False

        vArrayDatosComboBox(28).NombreCampo = "TDO_DESCRIPCION_DOC"
        vArrayDatosComboBox(28).Longitud = 45
        vArrayDatosComboBox(28).Tipo = "varchar"
        vArrayDatosComboBox(28).ParteEntera = 0
        vArrayDatosComboBox(28).ParteDecimal = 0
        ReDim vArrayDatosComboBox(28).Valores(0, 0)
        vArrayDatosComboBox(28).Ancho = 485
        vArrayDatosComboBox(28).Flag = False

        vArrayDatosComboBox(29).NombreCampo = "DTD_ID_DOC"
        vArrayDatosComboBox(29).Longitud = 3
        vArrayDatosComboBox(29).Tipo = "char"
        vArrayDatosComboBox(29).ParteEntera = 0
        vArrayDatosComboBox(29).ParteDecimal = 0
        ReDim vArrayDatosComboBox(29).Valores(0, 0)
        vArrayDatosComboBox(29).Ancho = 36
        vArrayDatosComboBox(29).Flag = False

        vArrayDatosComboBox(30).NombreCampo = "DTD_DESCRIPCION_DOC"
        vArrayDatosComboBox(30).Longitud = 45
        vArrayDatosComboBox(30).Tipo = "varchar"
        vArrayDatosComboBox(30).ParteEntera = 0
        vArrayDatosComboBox(30).ParteDecimal = 0
        ReDim vArrayDatosComboBox(30).Valores(0, 0)
        vArrayDatosComboBox(30).Ancho = 485
        vArrayDatosComboBox(30).Flag = False

        vArrayDatosComboBox(31).NombreCampo = "CCT_ID_DOC"
        vArrayDatosComboBox(31).Longitud = 3
        vArrayDatosComboBox(31).Tipo = "char"
        vArrayDatosComboBox(31).ParteEntera = 0
        vArrayDatosComboBox(31).ParteDecimal = 0
        ReDim vArrayDatosComboBox(31).Valores(0, 0)
        vArrayDatosComboBox(31).Ancho = 36
        vArrayDatosComboBox(31).Flag = False

        vArrayDatosComboBox(32).NombreCampo = "CCT_DESCRIPCION_DOC"
        vArrayDatosComboBox(32).Longitud = 45
        vArrayDatosComboBox(32).Tipo = "varchar"
        vArrayDatosComboBox(32).ParteEntera = 0
        vArrayDatosComboBox(32).ParteDecimal = 0
        ReDim vArrayDatosComboBox(32).Valores(0, 0)
        vArrayDatosComboBox(32).Ancho = 485
        vArrayDatosComboBox(32).Flag = False

        vArrayDatosComboBox(33).NombreCampo = "DPR_SERIE_DOC"
        vArrayDatosComboBox(33).Longitud = 3
        vArrayDatosComboBox(33).Tipo = "char"
        vArrayDatosComboBox(33).ParteEntera = 0
        vArrayDatosComboBox(33).ParteDecimal = 0
        ReDim vArrayDatosComboBox(33).Valores(0, 0)
        vArrayDatosComboBox(33).Ancho = 36
        vArrayDatosComboBox(33).Flag = False

        vArrayDatosComboBox(34).NombreCampo = "DPR_NUMERO_DOC"
        vArrayDatosComboBox(34).Longitud = 10
        vArrayDatosComboBox(34).Tipo = "char"
        vArrayDatosComboBox(34).ParteEntera = 0
        vArrayDatosComboBox(34).ParteDecimal = 0
        ReDim vArrayDatosComboBox(34).Valores(0, 0)
        vArrayDatosComboBox(34).Ancho = 111
        vArrayDatosComboBox(34).Flag = False

        vArrayDatosComboBox(35).NombreCampo = "PER_ID_CLI_DOC"
        vArrayDatosComboBox(35).Longitud = 6
        vArrayDatosComboBox(35).Tipo = "char"
        vArrayDatosComboBox(35).ParteEntera = 0
        vArrayDatosComboBox(35).ParteDecimal = 0
        ReDim vArrayDatosComboBox(35).Valores(0, 0)
        vArrayDatosComboBox(35).Ancho = 68
        vArrayDatosComboBox(35).Flag = False

        vArrayDatosComboBox(36).NombreCampo = "PER_DESCRIPCION_CLI_DOC"
        vArrayDatosComboBox(36).Longitud = 77
        vArrayDatosComboBox(36).Tipo = "varchar"
        vArrayDatosComboBox(36).ParteEntera = 0
        vArrayDatosComboBox(36).ParteDecimal = 0
        ReDim vArrayDatosComboBox(36).Valores(0, 0)
        vArrayDatosComboBox(36).Ancho = 828
        vArrayDatosComboBox(36).Flag = False

        vArrayDatosComboBox(37).NombreCampo = "DPR_OBSERVACIONES"
        vArrayDatosComboBox(37).Longitud = 50
        vArrayDatosComboBox(37).Tipo = "varchar"
        vArrayDatosComboBox(37).ParteEntera = 0
        vArrayDatosComboBox(37).ParteDecimal = 0
        ReDim vArrayDatosComboBox(37).Valores(0, 0)
        vArrayDatosComboBox(37).Ancho = 539
        vArrayDatosComboBox(37).Flag = False


        vArrayDatosComboBox(38).NombreCampo = "DPR_ESTADO"
        vArrayDatosComboBox(38).Longitud = 0
        vArrayDatosComboBox(38).Tipo = "bit"
        vArrayDatosComboBox(38).ParteEntera = 0
        vArrayDatosComboBox(38).ParteDecimal = 0
        ReDim vArrayDatosComboBox(38).Valores(1, 1)
        vArrayDatosComboBox(38).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(38).Valores(0, 1) = "0"
        vArrayDatosComboBox(38).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(38).Valores(1, 1) = "1"
        vArrayDatosComboBox(38).Ancho = 85
        vArrayDatosComboBox(38).Flag = True

        vArrayDatosComboBox(39).NombreCampo = "PRE_ESTADO"
        vArrayDatosComboBox(39).Longitud = 9
        vArrayDatosComboBox(39).Tipo = "varchar"
        vArrayDatosComboBox(39).ParteEntera = 0
        vArrayDatosComboBox(39).ParteDecimal = 0
        ReDim vArrayDatosComboBox(39).Valores(1, 1)
        vArrayDatosComboBox(39).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(39).Valores(0, 1) = "0"
        vArrayDatosComboBox(39).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(39).Valores(1, 1) = "1"
        vArrayDatosComboBox(39).Ancho = 85
        vArrayDatosComboBox(39).Flag = True
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

                Case "DPR_SERIE"
                    If Len(DPR_SERIE.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3 & " - DPR_SERIE"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_NUMERO"
                    If Len(DPR_NUMERO.Trim) = 10 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo10 & " - DPR_NUMERO"
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

                Case "MON_ID"
                    If Len(MON_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3 & " - Cód. Mon. Doc."
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_ITEM"
                    If DPR_ITEM.GetType = GetType(System.Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - DPR_ITEM"
                        VerificarDatos.Objeto = vCampos(elemento)
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

                Case "DPR_FEC_VEN"
                    If DPR_FEC_VEN.GetType = GetType(Date) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha & " - Fec. Venc."
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_CAPITAL"
                    If DPR_CAPITAL >= 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Capital"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If


                Case "DPR_INTERES"
                    If DPR_INTERES >= 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Interes"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_GASTOS"
                    If DPR_GASTOS >= 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Gastos"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_IMPORTE"
                    If DPR_IMPORTE > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Importe"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_CONTRAVALOR"
                    If DPR_CONTRAVALOR >= 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato & " - Contravalor"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_OBSERVACIONES"
                    If IsNothing(DPR_OBSERVACIONES) Then
                    Else
                        If DPR_OBSERVACIONES.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato & " - Observaciones"
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

                Case "DPR_SERIE_DOC"
                    If IsNothing(DPR_SERIE_DOC) Then
                    Else
                        If Len(DPR_SERIE_DOC.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3 & " - Serie Doc."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "DPR_NUMERO_DOC"
                    If IsNothing(DPR_NUMERO_DOC) Then
                    Else
                        If Len(DPR_NUMERO_DOC.Trim) = 10 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo10 & " - Número Doc."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "PER_ID_CLI_DOC"
                    If IsNothing(PER_ID_CLI_DOC) Then
                    Else
                        If Len(PER_ID_CLI_DOC.Trim) = 6 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo6 & " - Cód. Cliente Doc."
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario & " - Cód. Usuario"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_FEC_GRAB"
                    If DPR_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha & " - Fecha y hora de grabación"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_ESTADO"
                    If DPR_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaDetallePrestamoXML"
        End If
        If Vista = "VistaDetallePrestamoNuevo" Then
            SentenciaSqlBusqueda = "spVistaDetallePrestamoNuevoXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetallePrestamoXML"
        End If
        If Vista = "ListarRegistrosTransferencias" Then
            SentenciaSqlBusqueda = "spListarDetallePrestamoTransferenciasXML"
        End If
        If Vista = "ListarRegistrosTipoRecibo" Then
            SentenciaSqlBusqueda = "spListarDetallePrestamoTipoReciboNuevoXML"
        End If
        If Vista = "ListarRegistrosTipoReciboEntregas" Then
            SentenciaSqlBusqueda = "spListarDetallePrestamoTipoReciboEntregasNuevoXML"
        End If
        If Vista = "ListarRegistrosTipoReciboOtros" Then
            SentenciaSqlBusqueda = "spListarDetallePrestamoTipoReciboOtrosNuevoXML"
        End If
        If Vista = "ListarRegistrosTipoReciboTransferencias" Then
            SentenciaSqlBusqueda = "spListarDetallePrestamoTipoReciboTransferenciasNuevoXML"
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
                oVerificarDatos = VerificarDatos("TDO_ID", "DTD_ID", "CCC_ID", "DPR_SERIE", "DPR_NUMERO", "CCT_ID", "MON_ID", "DPR_ITEM", "PER_ID_CLI", "DPR_FEC_VEN", "DPR_CAPITAL", "DPR_INTERES", "DPR_GASTOS", "DPR_IMPORTE", "DPR_CONTRAVALOR", "DPR_OBSERVACIONES", "TDO_ID_DOC", "DTD_ID_DOC", "CCT_ID_DOC", "DPR_SERIE_DOC", "DPR_NUMERO_DOC", "PER_ID_CLI_DOC", "USU_ID", "DPR_FEC_GRAB", "DPR_ESTADO")
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

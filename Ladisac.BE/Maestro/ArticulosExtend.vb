Imports Ladisac.BE

Partial Public Class Articulos
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public CampoPrincipal = "ART_ID"
    Public CampoPrincipalValor = ART_ID
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 1
    Public CadenaFiltrado As String = ""

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.Articulos"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "Articulos"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwArticulos"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaArticulos"
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

    Public Sub ConfigurarDatosCampos()
        vElementosDatosComboBox = 34
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "ART_ID"
        vArrayCamposBusqueda(1) = "ART_DESCRIPCION"
        vArrayCamposBusqueda(2) = "ART_COD_FAB"
        vArrayCamposBusqueda(3) = "ART_DESC_FAB"
        vArrayCamposBusqueda(4) = "ART_ORIGEN"
        vArrayCamposBusqueda(5) = "UM_ID"
        vArrayCamposBusqueda(6) = "UM_DESCRIPCION"
        vArrayCamposBusqueda(7) = "UM_TIPO"
        vArrayCamposBusqueda(8) = "UM_CANT_ELEM"
        vArrayCamposBusqueda(9) = "UM_SUB_DESCRIP"
        vArrayCamposBusqueda(10) = "UM_ESTADO"
        vArrayCamposBusqueda(11) = "MAR_ID"
        vArrayCamposBusqueda(12) = "MAR_DESCRIPCION"
        vArrayCamposBusqueda(13) = "MAR_ESTADO"
        vArrayCamposBusqueda(14) = "MOD_ID"
        vArrayCamposBusqueda(15) = "MOD_DESCRIPCION"
        vArrayCamposBusqueda(16) = "MOD_ESTADO"
        vArrayCamposBusqueda(17) = "ART_COLOR"
        vArrayCamposBusqueda(18) = "FAM_ID"
        vArrayCamposBusqueda(19) = "FAM_DESCRIPCION"
        vArrayCamposBusqueda(20) = "FAM_ESTADO"
        vArrayCamposBusqueda(21) = "LIN_ID"
        vArrayCamposBusqueda(22) = "LIN_DESCRIPCION"
        vArrayCamposBusqueda(23) = "LIN_ESTADO"
        vArrayCamposBusqueda(24) = "GLI_ID"
        vArrayCamposBusqueda(25) = "GLI_DESCRIPCION"
        vArrayCamposBusqueda(26) = "GLI_ESTADO"
        vArrayCamposBusqueda(27) = "ART_CONT_STOCK"
        vArrayCamposBusqueda(28) = "ART_FICHA_TEC"
        vArrayCamposBusqueda(29) = "ART_FACTOR"
        vArrayCamposBusqueda(30) = "ART_INC_IGV"
        vArrayCamposBusqueda(31) = "ART_AFE_PER"
        vArrayCamposBusqueda(32) = "ART_AFE_RET"
        vArrayCamposBusqueda(33) = "ART_PRE_NEG"
        vArrayCamposBusqueda(34) = "ART_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "ART_ID"
        vArrayDatosComboBox(0).Longitud = 6
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 68
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "ART_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 45
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 485
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "ART_COD_FAB"
        vArrayDatosComboBox(2).Longitud = 45
        vArrayDatosComboBox(2).Tipo = "varchar"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 485
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "ART_DESC_FAB"
        vArrayDatosComboBox(3).Longitud = 45
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 485
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "ART_ORIGEN"
        vArrayDatosComboBox(4).Longitud = 10
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(1, 1)
        vArrayDatosComboBox(4).Valores(0, 0) = "NACIONAL"
        vArrayDatosComboBox(4).Valores(0, 1) = "0"
        vArrayDatosComboBox(4).Valores(1, 0) = "EXTRANGERO"
        vArrayDatosComboBox(4).Valores(1, 1) = "1"
        vArrayDatosComboBox(4).Ancho = 102
        vArrayDatosComboBox(4).Flag = True

        vArrayDatosComboBox(5).NombreCampo = "UM_ID"
        vArrayDatosComboBox(5).Longitud = 3
        vArrayDatosComboBox(5).Tipo = "char"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 36
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "UM_DESCRIPCION"
        vArrayDatosComboBox(6).Longitud = 45
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 485
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "UM_TIPO"
        vArrayDatosComboBox(7).Longitud = 15
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(3, 1)
        vArrayDatosComboBox(7).Valores(0, 0) = "CANTIDAD"
        vArrayDatosComboBox(7).Valores(0, 1) = "0"
        vArrayDatosComboBox(7).Valores(1, 0) = "PESO"
        vArrayDatosComboBox(7).Valores(1, 1) = "1"
        vArrayDatosComboBox(7).Valores(2, 0) = "CANTIDAD - PESO"
        vArrayDatosComboBox(7).Valores(2, 1) = "2"
        vArrayDatosComboBox(7).Valores(3, 0) = "ELEMENTO"
        vArrayDatosComboBox(7).Valores(3, 1) = "3"
        vArrayDatosComboBox(7).Ancho = 122
        vArrayDatosComboBox(7).Flag = True

        vArrayDatosComboBox(8).NombreCampo = "UM_CANT_ELEM"
        vArrayDatosComboBox(8).Longitud = 10
        vArrayDatosComboBox(8).Tipo = "int"
        vArrayDatosComboBox(8).ParteEntera = 10
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 111
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "UM_SUB_DESCRIP"
        vArrayDatosComboBox(9).Longitud = 45
        vArrayDatosComboBox(9).Tipo = "varchar"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 485
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "UM_ESTADO"
        vArrayDatosComboBox(10).Longitud = 9
        vArrayDatosComboBox(10).Tipo = "varchar"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(1, 1)
        vArrayDatosComboBox(10).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(10).Valores(0, 1) = "0"
        vArrayDatosComboBox(10).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(10).Valores(1, 1) = "1"
        vArrayDatosComboBox(10).Ancho = 85
        vArrayDatosComboBox(10).Flag = True

        vArrayDatosComboBox(11).NombreCampo = "MAR_ID"
        vArrayDatosComboBox(11).Longitud = 3
        vArrayDatosComboBox(11).Tipo = "char"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 36
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "MAR_DESCRIPCION"
        vArrayDatosComboBox(12).Longitud = 45
        vArrayDatosComboBox(12).Tipo = "varchar"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 485
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "MAR_ESTADO"
        vArrayDatosComboBox(13).Longitud = 9
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(1, 1)
        vArrayDatosComboBox(13).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(13).Valores(0, 1) = "0"
        vArrayDatosComboBox(13).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(13).Valores(1, 1) = "1"
        vArrayDatosComboBox(13).Ancho = 85
        vArrayDatosComboBox(13).Flag = True

        vArrayDatosComboBox(14).NombreCampo = "MOD_ID"
        vArrayDatosComboBox(14).Longitud = 3
        vArrayDatosComboBox(14).Tipo = "char"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 36
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "MOD_DESCRIPCION"
        vArrayDatosComboBox(15).Longitud = 45
        vArrayDatosComboBox(15).Tipo = "varchar"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 485
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "MOD_ESTADO"
        vArrayDatosComboBox(16).Longitud = 9
        vArrayDatosComboBox(16).Tipo = "varchar"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(1, 1)
        vArrayDatosComboBox(16).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(16).Valores(0, 1) = "0"
        vArrayDatosComboBox(16).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(16).Valores(1, 1) = "1"
        vArrayDatosComboBox(16).Ancho = 85
        vArrayDatosComboBox(16).Flag = True

        vArrayDatosComboBox(17).NombreCampo = "ART_COLOR"
        vArrayDatosComboBox(17).Longitud = 15
        vArrayDatosComboBox(17).Tipo = "varchar"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 165
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "FAM_ID"
        vArrayDatosComboBox(18).Longitud = 3
        vArrayDatosComboBox(18).Tipo = "varchar"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(0, 0)
        vArrayDatosComboBox(18).Ancho = 36
        vArrayDatosComboBox(18).Flag = False

        vArrayDatosComboBox(19).NombreCampo = "FAM_DESCRIPCION"
        vArrayDatosComboBox(19).Longitud = 45
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(0, 0)
        vArrayDatosComboBox(19).Ancho = 485
        vArrayDatosComboBox(19).Flag = False

        vArrayDatosComboBox(20).NombreCampo = "FAM_ESTADO"
        vArrayDatosComboBox(20).Longitud = 9
        vArrayDatosComboBox(20).Tipo = "varchar"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(1, 1)
        vArrayDatosComboBox(20).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(20).Valores(0, 1) = "0"
        vArrayDatosComboBox(20).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(20).Valores(1, 1) = "1"
        vArrayDatosComboBox(20).Ancho = 85
        vArrayDatosComboBox(20).Flag = True

        vArrayDatosComboBox(21).NombreCampo = "LIN_ID"
        vArrayDatosComboBox(21).Longitud = 3
        vArrayDatosComboBox(21).Tipo = "varchar"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(0, 0)
        vArrayDatosComboBox(21).Ancho = 36
        vArrayDatosComboBox(21).Flag = False

        vArrayDatosComboBox(22).NombreCampo = "LIN_DESCRIPCION"
        vArrayDatosComboBox(22).Longitud = 45
        vArrayDatosComboBox(22).Tipo = "varchar"
        vArrayDatosComboBox(22).ParteEntera = 0
        vArrayDatosComboBox(22).ParteDecimal = 0
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 485
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "LIN_ESTADO"
        vArrayDatosComboBox(23).Longitud = 9
        vArrayDatosComboBox(23).Tipo = "varchar"
        vArrayDatosComboBox(23).ParteEntera = 0
        vArrayDatosComboBox(23).ParteDecimal = 0
        ReDim vArrayDatosComboBox(23).Valores(1, 1)
        vArrayDatosComboBox(23).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(23).Valores(0, 1) = "0"
        vArrayDatosComboBox(23).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(23).Valores(1, 1) = "1"
        vArrayDatosComboBox(23).Ancho = 85
        vArrayDatosComboBox(23).Flag = True

        vArrayDatosComboBox(24).NombreCampo = "GLI_ID"
        vArrayDatosComboBox(24).Longitud = 3
        vArrayDatosComboBox(24).Tipo = "char"
        vArrayDatosComboBox(24).ParteEntera = 0
        vArrayDatosComboBox(24).ParteDecimal = 0
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 36
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "GLI_DESCRIPCION"
        vArrayDatosComboBox(25).Longitud = 45
        vArrayDatosComboBox(25).Tipo = "varchar"
        vArrayDatosComboBox(25).ParteEntera = 0
        vArrayDatosComboBox(25).ParteDecimal = 0
        ReDim vArrayDatosComboBox(25).Valores(0, 0)
        vArrayDatosComboBox(25).Ancho = 485
        vArrayDatosComboBox(25).Flag = False

        vArrayDatosComboBox(26).NombreCampo = "GLI_ESTADO"
        vArrayDatosComboBox(26).Longitud = 9
        vArrayDatosComboBox(26).Tipo = "varchar"
        vArrayDatosComboBox(26).ParteEntera = 0
        vArrayDatosComboBox(26).ParteDecimal = 0
        ReDim vArrayDatosComboBox(26).Valores(1, 1)
        vArrayDatosComboBox(26).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(26).Valores(0, 1) = "0"
        vArrayDatosComboBox(26).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(26).Valores(1, 1) = "1"
        vArrayDatosComboBox(26).Ancho = 85
        vArrayDatosComboBox(26).Flag = True

        vArrayDatosComboBox(27).NombreCampo = "ART_CONT_STOCK"
        vArrayDatosComboBox(27).Longitud = 8
        vArrayDatosComboBox(27).Tipo = "varchar"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(1, 1)
        vArrayDatosComboBox(27).Valores(0, 0) = "NO STOCK"
        vArrayDatosComboBox(27).Valores(0, 1) = "0"
        vArrayDatosComboBox(27).Valores(1, 0) = "SI STOCK"
        vArrayDatosComboBox(27).Valores(1, 1) = "1"
        vArrayDatosComboBox(27).Ancho = 82
        vArrayDatosComboBox(27).Flag = True

        vArrayDatosComboBox(28).NombreCampo = "ART_FICHA_TEC"
        vArrayDatosComboBox(28).Longitud = 255
        vArrayDatosComboBox(28).Tipo = "varchar"
        vArrayDatosComboBox(28).ParteEntera = 0
        vArrayDatosComboBox(28).ParteDecimal = 0
        ReDim vArrayDatosComboBox(28).Valores(0, 0)
        vArrayDatosComboBox(28).Ancho = 2731
        vArrayDatosComboBox(28).Flag = False

        vArrayDatosComboBox(29).NombreCampo = "ART_FACTOR"
        vArrayDatosComboBox(29).Longitud = 10
        vArrayDatosComboBox(29).Tipo = "int"
        vArrayDatosComboBox(29).ParteEntera = 10
        vArrayDatosComboBox(29).ParteDecimal = 0
        ReDim vArrayDatosComboBox(29).Valores(0, 0)
        vArrayDatosComboBox(29).Ancho = 111
        vArrayDatosComboBox(29).Flag = False

        vArrayDatosComboBox(30).NombreCampo = "ART_INC_IGV"
        vArrayDatosComboBox(30).Longitud = 18
        vArrayDatosComboBox(30).Tipo = "varchar"
        vArrayDatosComboBox(30).ParteEntera = 0
        vArrayDatosComboBox(30).ParteDecimal = 0
        ReDim vArrayDatosComboBox(30).Valores(2, 1)
        vArrayDatosComboBox(30).Valores(0, 0) = "NO INCLUYE IGV"
        vArrayDatosComboBox(30).Valores(0, 1) = "0"
        vArrayDatosComboBox(30).Valores(1, 0) = "SI INCLUYE IGV"
        vArrayDatosComboBox(30).Valores(1, 1) = "1"
        vArrayDatosComboBox(30).Valores(2, 0) = "NO GRABADO CON IGV"
        vArrayDatosComboBox(30).Valores(2, 1) = "2"
        vArrayDatosComboBox(30).Ancho = 151
        vArrayDatosComboBox(30).Flag = True

        vArrayDatosComboBox(31).NombreCampo = "ART_AFE_PER"
        vArrayDatosComboBox(31).Longitud = 13
        vArrayDatosComboBox(31).Tipo = "varchar"
        vArrayDatosComboBox(31).ParteEntera = 0
        vArrayDatosComboBox(31).ParteDecimal = 0
        ReDim vArrayDatosComboBox(31).Valores(0, 0)
        vArrayDatosComboBox(31).Ancho = 143
        vArrayDatosComboBox(31).Flag = False

        vArrayDatosComboBox(32).NombreCampo = "ART_AFE_RET"
        vArrayDatosComboBox(32).Longitud = 12
        vArrayDatosComboBox(32).Tipo = "varchar"
        vArrayDatosComboBox(32).ParteEntera = 0
        vArrayDatosComboBox(32).ParteDecimal = 0
        ReDim vArrayDatosComboBox(32).Valores(0, 0)
        vArrayDatosComboBox(32).Ancho = 132
        vArrayDatosComboBox(32).Flag = False

        vArrayDatosComboBox(33).NombreCampo = "ART_PRE_NEG"
        vArrayDatosComboBox(33).Longitud = 18
        vArrayDatosComboBox(33).Tipo = "varchar"
        vArrayDatosComboBox(33).ParteEntera = 0
        vArrayDatosComboBox(33).ParteDecimal = 0
        ReDim vArrayDatosComboBox(33).Valores(1, 1)
        vArrayDatosComboBox(33).Valores(0, 0) = "NO PRECIO NEGATIVO"
        vArrayDatosComboBox(33).Valores(0, 1) = "0"
        vArrayDatosComboBox(33).Valores(1, 0) = "SI PRECIO NEGATIVO"
        vArrayDatosComboBox(33).Valores(1, 1) = "1"
        vArrayDatosComboBox(33).Ancho = 148
        vArrayDatosComboBox(33).Flag = True

        vArrayDatosComboBox(34).NombreCampo = "ART_ESTADO"
        vArrayDatosComboBox(34).Longitud = 9
        vArrayDatosComboBox(34).Tipo = "varchar"
        vArrayDatosComboBox(34).ParteEntera = 0
        vArrayDatosComboBox(34).ParteDecimal = 0
        ReDim vArrayDatosComboBox(34).Valores(1, 1)
        vArrayDatosComboBox(34).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(34).Valores(0, 1) = "0"
        vArrayDatosComboBox(34).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(34).Valores(1, 1) = "1"
        vArrayDatosComboBox(34).Ancho = 85
        vArrayDatosComboBox(34).Flag = True
    End Sub

    Public Function SentenciaSqlBusqueda() As String
        SentenciaSqlBusqueda = ""
        If Vista = "BuscarRegistros" Then
            SentenciaSqlBusqueda = "spVistaArticulosXML"
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




Imports Ladisac.BE
Partial Public Class DetalleDescuentoIncrementoTipoVentaPersonas
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
    Public CampoPrincipal = "DTP_ID"
    Public CampoPrincipalSecundario = "ART_ID"
    Public CampoPrincipalTercero = "DDT_ITEM"
    Public CampoPrincipalValor = DTP_ID
    Public CampoPrincipalSecundarioValor = ART_ID
    Public CampoPrincipalTerceroValor = DDT_ITEM

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Fin.DetalleDescuentoIncrementoTipoVentaPersonas"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetalleDescuentoIncrementoTipoVentaPersonas"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetalleDescuentoIncrementoTipoVentaPersonas"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetalleDescuentoIncrementoTipoVentaPersonas"
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
        vElementosDatosComboBox = 31
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "DTP_ID"
        vArrayCamposBusqueda(1) = "DTP_DESCRIPCION"
        vArrayCamposBusqueda(2) = "LPR_ID"
        vArrayCamposBusqueda(3) = "LPR_DESCRIPCION"
        vArrayCamposBusqueda(4) = "DLP_PRECIO_MINIMO"
        vArrayCamposBusqueda(5) = "DLP_PRECIO_UNITARIO"
        vArrayCamposBusqueda(6) = "DLP_RECARGO_ENVIO"
        vArrayCamposBusqueda(7) = "TIV_ID"
        vArrayCamposBusqueda(8) = "TIV_DESCRIPCION"
        vArrayCamposBusqueda(9) = "TIV_DIAS"
        vArrayCamposBusqueda(10) = "TIV_ESTADO"
        vArrayCamposBusqueda(11) = "DTP_MONTO_TIV"
        vArrayCamposBusqueda(12) = "PER_ID"
        vArrayCamposBusqueda(13) = "PER_DESCRIPCION"
        vArrayCamposBusqueda(14) = "DTP_MONTO_PER"
        vArrayCamposBusqueda(15) = "DTP_TIPO_DESC_INC"
        vArrayCamposBusqueda(16) = "DTP_CRITERIO"
        vArrayCamposBusqueda(17) = "DTP_SUB_CRITERIO"
        vArrayCamposBusqueda(18) = "DTP_MONTO_MINIMO"
        vArrayCamposBusqueda(19) = "DTP_MONTO_MAXIMO"
        vArrayCamposBusqueda(20) = "DTP_CANT_MINIMA"
        vArrayCamposBusqueda(21) = "DTP_CANT_MAXIMA"
        vArrayCamposBusqueda(22) = "DTP_FEC_INI"
        vArrayCamposBusqueda(23) = "DTP_FEC_FIN"
        vArrayCamposBusqueda(24) = "DDT_ITEM"
        vArrayCamposBusqueda(25) = "ART_ID"
        vArrayCamposBusqueda(26) = "ART_DESCRIPCION"
        vArrayCamposBusqueda(27) = "ART_ESTADO"
        vArrayCamposBusqueda(28) = "DDT_ESTADO"
        vArrayCamposBusqueda(29) = "DLP_ESTADO"
        vArrayCamposBusqueda(30) = "LPR_ESTADO"
        vArrayCamposBusqueda(31) = "DTP_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "DTP_ID"
        vArrayDatosComboBox(0).Longitud = 10
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 111
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "DTP_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 45
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 485
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "LPR_ID"
        vArrayDatosComboBox(2).Longitud = 3
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 36
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "LPR_DESCRIPCION"
        vArrayDatosComboBox(3).Longitud = 45
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 485
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "DLP_PRECIO_MINIMO"
        vArrayDatosComboBox(4).Longitud = 18
        vArrayDatosComboBox(4).Tipo = "numeric"
        vArrayDatosComboBox(4).ParteEntera = 14
        vArrayDatosComboBox(4).ParteDecimal = 4
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 197
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "DLP_PRECIO_UNITARIO"
        vArrayDatosComboBox(5).Longitud = 18
        vArrayDatosComboBox(5).Tipo = "numeric"
        vArrayDatosComboBox(5).ParteEntera = 14
        vArrayDatosComboBox(5).ParteDecimal = 4
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 197
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "DLP_RECARGO_ENVIO"
        vArrayDatosComboBox(6).Longitud = 18
        vArrayDatosComboBox(6).Tipo = "numeric"
        vArrayDatosComboBox(6).ParteEntera = 14
        vArrayDatosComboBox(6).ParteDecimal = 4
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 197
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "TIV_ID"
        vArrayDatosComboBox(7).Longitud = 3
        vArrayDatosComboBox(7).Tipo = "char"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 36
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "TIV_DESCRIPCION"
        vArrayDatosComboBox(8).Longitud = 45
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 485
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "TIV_DIAS"
        vArrayDatosComboBox(9).Longitud = 5
        vArrayDatosComboBox(9).Tipo = "smallint"
        vArrayDatosComboBox(9).ParteEntera = 5
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 58
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "TIV_ESTADO"
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

        vArrayDatosComboBox(11).NombreCampo = "DTP_MONTO_TIV"
        vArrayDatosComboBox(11).Longitud = 18
        vArrayDatosComboBox(11).Tipo = "numeric"
        vArrayDatosComboBox(11).ParteEntera = 14
        vArrayDatosComboBox(11).ParteDecimal = 4
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 197
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "PER_ID"
        vArrayDatosComboBox(12).Longitud = 6
        vArrayDatosComboBox(12).Tipo = "char"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 68
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "PER_DESCRIPCION"
        vArrayDatosComboBox(13).Longitud = 77
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 828
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "DTP_MONTO_PER"
        vArrayDatosComboBox(14).Longitud = 18
        vArrayDatosComboBox(14).Tipo = "numeric"
        vArrayDatosComboBox(14).ParteEntera = 14
        vArrayDatosComboBox(14).ParteDecimal = 4
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 197
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "DTP_TIPO_DESC_INC"
        vArrayDatosComboBox(15).Longitud = 0
        vArrayDatosComboBox(15).Tipo = "smallint"
        vArrayDatosComboBox(15).ParteEntera = 5
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(2, 1)
        vArrayDatosComboBox(15).Valores(0, 0) = "DESCUENTO POR VOLUMEN"
        vArrayDatosComboBox(15).Valores(0, 1) = "0"
        vArrayDatosComboBox(15).Valores(1, 0) = "DESCUENTO AUTOMATICO"
        vArrayDatosComboBox(15).Valores(1, 1) = "1"
        vArrayDatosComboBox(15).Valores(2, 0) = "OTROS"
        vArrayDatosComboBox(15).Valores(2, 1) = "2"
        vArrayDatosComboBox(15).Ancho = 222
        vArrayDatosComboBox(15).Flag = True

        vArrayDatosComboBox(16).NombreCampo = "DTP_CRITERIO"
        vArrayDatosComboBox(16).Longitud = 13
        vArrayDatosComboBox(16).Tipo = "varchar"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(1, 1)
        vArrayDatosComboBox(16).Valores(0, 0) = "POR VENTA"
        vArrayDatosComboBox(16).Valores(0, 1) = "0"
        vArrayDatosComboBox(16).Valores(1, 0) = "POR PROMOCION"
        vArrayDatosComboBox(16).Valores(1, 1) = "1"
        vArrayDatosComboBox(16).Ancho = 122
        vArrayDatosComboBox(16).Flag = True

        vArrayDatosComboBox(17).NombreCampo = "DTP_SUB_CRITERIO"
        vArrayDatosComboBox(17).Longitud = 13
        vArrayDatosComboBox(17).Tipo = "varchar"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(1, 1)
        vArrayDatosComboBox(17).Valores(0, 0) = "POR SIEMPRE"
        vArrayDatosComboBox(17).Valores(0, 1) = "0"
        vArrayDatosComboBox(17).Valores(1, 0) = "POR UNA VENTA"
        vArrayDatosComboBox(17).Valores(1, 1) = "1"
        vArrayDatosComboBox(17).Ancho = 115
        vArrayDatosComboBox(17).Flag = True

        vArrayDatosComboBox(18).NombreCampo = "DTP_MONTO_MINIMO"
        vArrayDatosComboBox(18).Longitud = 18
        vArrayDatosComboBox(18).Tipo = "numeric"
        vArrayDatosComboBox(18).ParteEntera = 14
        vArrayDatosComboBox(18).ParteDecimal = 4
        ReDim vArrayDatosComboBox(18).Valores(0, 0)
        vArrayDatosComboBox(18).Ancho = 197
        vArrayDatosComboBox(18).Flag = False

        vArrayDatosComboBox(19).NombreCampo = "DTP_MONTO_MAXIMO"
        vArrayDatosComboBox(19).Longitud = 18
        vArrayDatosComboBox(19).Tipo = "numeric"
        vArrayDatosComboBox(19).ParteEntera = 14
        vArrayDatosComboBox(19).ParteDecimal = 4
        ReDim vArrayDatosComboBox(19).Valores(0, 0)
        vArrayDatosComboBox(19).Ancho = 197
        vArrayDatosComboBox(19).Flag = False

        vArrayDatosComboBox(20).NombreCampo = "DTP_CANT_MINIMA"
        vArrayDatosComboBox(20).Longitud = 18
        vArrayDatosComboBox(20).Tipo = "numeric"
        vArrayDatosComboBox(20).ParteEntera = 15
        vArrayDatosComboBox(20).ParteDecimal = 3
        ReDim vArrayDatosComboBox(20).Valores(0, 0)
        vArrayDatosComboBox(20).Ancho = 197
        vArrayDatosComboBox(20).Flag = False

        vArrayDatosComboBox(21).NombreCampo = "DTP_CANT_MAXIMA"
        vArrayDatosComboBox(21).Longitud = 18
        vArrayDatosComboBox(21).Tipo = "numeric"
        vArrayDatosComboBox(21).ParteEntera = 15
        vArrayDatosComboBox(21).ParteDecimal = 3
        ReDim vArrayDatosComboBox(21).Valores(0, 0)
        vArrayDatosComboBox(21).Ancho = 197
        vArrayDatosComboBox(21).Flag = False

        vArrayDatosComboBox(22).NombreCampo = "DTP_FEC_INI"
        vArrayDatosComboBox(22).Longitud = 0
        vArrayDatosComboBox(22).Tipo = "smalldatetime"
        vArrayDatosComboBox(22).ParteEntera = 0
        vArrayDatosComboBox(22).ParteDecimal = 0
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 15
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "DTP_FEC_FIN"
        vArrayDatosComboBox(23).Longitud = 0
        vArrayDatosComboBox(23).Tipo = "smalldatetime"
        vArrayDatosComboBox(23).ParteEntera = 0
        vArrayDatosComboBox(23).ParteDecimal = 0
        ReDim vArrayDatosComboBox(23).Valores(0, 0)
        vArrayDatosComboBox(23).Ancho = 15
        vArrayDatosComboBox(23).Flag = False

        vArrayDatosComboBox(24).NombreCampo = "DDT_ITEM"
        vArrayDatosComboBox(24).Longitud = 3
        vArrayDatosComboBox(24).Tipo = "numeric"
        vArrayDatosComboBox(24).ParteEntera = 3
        vArrayDatosComboBox(24).ParteDecimal = 0
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 36
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "ART_ID"
        vArrayDatosComboBox(25).Longitud = 6
        vArrayDatosComboBox(25).Tipo = "char"
        vArrayDatosComboBox(25).ParteEntera = 0
        vArrayDatosComboBox(25).ParteDecimal = 0
        ReDim vArrayDatosComboBox(25).Valores(0, 0)
        vArrayDatosComboBox(25).Ancho = 68
        vArrayDatosComboBox(25).Flag = False

        vArrayDatosComboBox(26).NombreCampo = "ART_DESCRIPCION"
        vArrayDatosComboBox(26).Longitud = 45
        vArrayDatosComboBox(26).Tipo = "varchar"
        vArrayDatosComboBox(26).ParteEntera = 0
        vArrayDatosComboBox(26).ParteDecimal = 0
        ReDim vArrayDatosComboBox(26).Valores(0, 0)
        vArrayDatosComboBox(26).Ancho = 485
        vArrayDatosComboBox(26).Flag = False

        vArrayDatosComboBox(27).NombreCampo = "ART_ESTADO"
        vArrayDatosComboBox(27).Longitud = 9
        vArrayDatosComboBox(27).Tipo = "varchar"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(1, 1)
        vArrayDatosComboBox(27).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(27).Valores(0, 1) = "0"
        vArrayDatosComboBox(27).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(27).Valores(1, 1) = "1"
        vArrayDatosComboBox(27).Ancho = 85
        vArrayDatosComboBox(27).Flag = True

        vArrayDatosComboBox(28).NombreCampo = "DDT_ESTADO"
        vArrayDatosComboBox(28).Longitud = 0
        vArrayDatosComboBox(28).Tipo = "bit"
        vArrayDatosComboBox(28).ParteEntera = 0
        vArrayDatosComboBox(28).ParteDecimal = 0
        ReDim vArrayDatosComboBox(28).Valores(1, 1)
        vArrayDatosComboBox(28).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(28).Valores(0, 1) = "0"
        vArrayDatosComboBox(28).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(28).Valores(1, 1) = "1"
        vArrayDatosComboBox(28).Ancho = 85
        vArrayDatosComboBox(28).Flag = True

        vArrayDatosComboBox(29).NombreCampo = "DLP_ESTADO"
        vArrayDatosComboBox(29).Longitud = 9
        vArrayDatosComboBox(29).Tipo = "varchar"
        vArrayDatosComboBox(29).ParteEntera = 0
        vArrayDatosComboBox(29).ParteDecimal = 0
        ReDim vArrayDatosComboBox(29).Valores(1, 1)
        vArrayDatosComboBox(29).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(29).Valores(0, 1) = "0"
        vArrayDatosComboBox(29).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(29).Valores(1, 1) = "1"
        vArrayDatosComboBox(29).Ancho = 85
        vArrayDatosComboBox(29).Flag = True

        vArrayDatosComboBox(30).NombreCampo = "LPR_ESTADO"
        vArrayDatosComboBox(30).Longitud = 9
        vArrayDatosComboBox(30).Tipo = "varchar"
        vArrayDatosComboBox(30).ParteEntera = 0
        vArrayDatosComboBox(30).ParteDecimal = 0
        ReDim vArrayDatosComboBox(30).Valores(1, 1)
        vArrayDatosComboBox(30).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(30).Valores(0, 1) = "0"
        vArrayDatosComboBox(30).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(30).Valores(1, 1) = "1"
        vArrayDatosComboBox(30).Ancho = 85
        vArrayDatosComboBox(30).Flag = True

        vArrayDatosComboBox(31).NombreCampo = "DTP_ESTADO"
        vArrayDatosComboBox(31).Longitud = 9
        vArrayDatosComboBox(31).Tipo = "varchar"
        vArrayDatosComboBox(31).ParteEntera = 0
        vArrayDatosComboBox(31).ParteDecimal = 0
        ReDim vArrayDatosComboBox(31).Valores(1, 1)
        vArrayDatosComboBox(31).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(31).Valores(0, 1) = "0"
        vArrayDatosComboBox(31).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(31).Valores(1, 1) = "1"
        vArrayDatosComboBox(31).Ancho = 85
        vArrayDatosComboBox(31).Flag = True

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "DTP_ID"
                    If Len(DTP_ID.Trim) = 10 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo10
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "ART_ID"
                    If Len(ART_ID.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDT_ITEM"
                    If DDT_ITEM.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDT_MONTO_MINIMO"
                    If DDT_MONTO_MINIMO.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDT_MONTO_MAXIMO"
                    If DDT_MONTO_MAXIMO.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDT_MONTO_TIV"
                    If DDT_MONTO_TIV.GetType = GetType(Decimal) Then
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

                Case "DDT_FEC_GRAB"
                    If DDT_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DDT_ESTADO"
                    If DDT_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaDetalleDescuentoIncrementoTipoVentaPersonasXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetalleDescuentoIncrementoTipoVentaPersonasXML"
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
                oVerificarDatos = VerificarDatos("DTP_ID", "ART_ID", "DDT_ITEM", "DDT_MONTO_MINIMO", "DDT_MONTO_MAXIMO", "DDT_MONTO_TIV", "USU_ID", "DDT_FEC_GRAB", "DDT_ESTADO")
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

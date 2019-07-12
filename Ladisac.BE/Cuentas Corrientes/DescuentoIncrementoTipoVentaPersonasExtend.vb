Imports Ladisac.BE
Partial Public Class DescuentoIncrementoTipoVentaPersonas

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
    Public CampoPrincipal = "LPR_ID"
    Public CampoPrincipalSecundario = "ART_ID"
    Public CampoPrincipalTercero = "TIV_ID"
    Public CampoPrincipalCuarto = "PER_ID"
    Public CampoPrincipalValor = LPR_ID
    Public CampoPrincipalSecundarioValor = ART_ID
    Public CampoPrincipalTerceroValor = TIV_ID
    Public CampoPrincipalCuartoValor = PER_ID
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Fin.DescuentoIncrementoTipoVentaPersonas"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DescuentoIncrementoTipoVentaPersonas"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDescuentoIncrementoTipoVentaPersonas"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDescuentoIncrementoTipoVentaPersonas"
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
        vElementosDatosComboBox = 30
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "LPR_ID"
        vArrayCamposBusqueda(1) = "LPR_DESCRIPCION"
        vArrayCamposBusqueda(2) = "ART_ID"
        vArrayCamposBusqueda(3) = "ART_DESCRIPCION"
        vArrayCamposBusqueda(4) = "UM_DESCRIPCION"
        vArrayCamposBusqueda(5) = "ART_FACTOR"
        vArrayCamposBusqueda(6) = "ART_ESTADO"
        vArrayCamposBusqueda(7) = "DLP_PRECIO_MINIMO"
        vArrayCamposBusqueda(8) = "DLP_PRECIO_UNITARIO"
        vArrayCamposBusqueda(9) = "DLP_RECARGO_ENVIO"
        vArrayCamposBusqueda(10) = "DTP_DESCRIPCION"
        vArrayCamposBusqueda(11) = "TIV_ID"
        vArrayCamposBusqueda(12) = "TIV_DESCRIPCION"
        vArrayCamposBusqueda(13) = "TIV_DIAS"
        vArrayCamposBusqueda(14) = "TIV_ESTADO"
        vArrayCamposBusqueda(15) = "DTP_MONTO_TIV"
        vArrayCamposBusqueda(16) = "PER_ID"
        vArrayCamposBusqueda(17) = "PER_DESCRIPCION"
        vArrayCamposBusqueda(18) = "DTP_MONTO_PER"
        vArrayCamposBusqueda(19) = "DTP_TIPO_DESC_INC"
        vArrayCamposBusqueda(20) = "DTP_CRITERIO"
        vArrayCamposBusqueda(21) = "DTP_SUB_CRITERIO"
        vArrayCamposBusqueda(22) = "DTP_MONTO_MINIMO"
        vArrayCamposBusqueda(23) = "DTP_MONTO_MAXIMO"
        vArrayCamposBusqueda(24) = "DTP_CANT_MINIMA"
        vArrayCamposBusqueda(25) = "DTP_CANT_MAXIMA"
        vArrayCamposBusqueda(26) = "DTP_FEC_INI"
        vArrayCamposBusqueda(27) = "DTP_FEC_FIN"
        vArrayCamposBusqueda(28) = "DLP_ESTADO"
        vArrayCamposBusqueda(29) = "LPR_ESTADO"
        vArrayCamposBusqueda(30) = "DTP_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "LPR_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "LPR_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 45
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 485
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "ART_ID"
        vArrayDatosComboBox(2).Longitud = 6
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 68
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "ART_DESCRIPCION"
        vArrayDatosComboBox(3).Longitud = 45
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 485
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "UM_DESCRIPCION"
        vArrayDatosComboBox(4).Longitud = 45
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 485
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "ART_FACTOR"
        vArrayDatosComboBox(5).Longitud = 10
        vArrayDatosComboBox(5).Tipo = "int"
        vArrayDatosComboBox(5).ParteEntera = 10
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 111
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "ART_ESTADO"
        vArrayDatosComboBox(6).Longitud = 9
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(1, 1)
        vArrayDatosComboBox(6).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(6).Valores(0, 1) = "0"
        vArrayDatosComboBox(6).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(6).Valores(1, 1) = "1"
        vArrayDatosComboBox(6).Ancho = 85
        vArrayDatosComboBox(6).Flag = True

        vArrayDatosComboBox(7).NombreCampo = "DLP_PRECIO_MINIMO"
        vArrayDatosComboBox(7).Longitud = 18
        vArrayDatosComboBox(7).Tipo = "numeric"
        vArrayDatosComboBox(7).ParteEntera = 14
        vArrayDatosComboBox(7).ParteDecimal = 4
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 197
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "DLP_PRECIO_UNITARIO"
        vArrayDatosComboBox(8).Longitud = 18
        vArrayDatosComboBox(8).Tipo = "numeric"
        vArrayDatosComboBox(8).ParteEntera = 14
        vArrayDatosComboBox(8).ParteDecimal = 4
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 197
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "DLP_RECARGO_ENVIO"
        vArrayDatosComboBox(9).Longitud = 18
        vArrayDatosComboBox(9).Tipo = "numeric"
        vArrayDatosComboBox(9).ParteEntera = 14
        vArrayDatosComboBox(9).ParteDecimal = 4
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 197
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "DTP_DESCRIPCION"
        vArrayDatosComboBox(10).Longitud = 45
        vArrayDatosComboBox(10).Tipo = "varchar"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 485
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "TIV_ID"
        vArrayDatosComboBox(11).Longitud = 3
        vArrayDatosComboBox(11).Tipo = "char"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 36
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "TIV_DESCRIPCION"
        vArrayDatosComboBox(12).Longitud = 45
        vArrayDatosComboBox(12).Tipo = "varchar"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 485
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "TIV_DIAS"
        vArrayDatosComboBox(13).Longitud = 3
        vArrayDatosComboBox(13).Tipo = "numeric"
        vArrayDatosComboBox(13).ParteEntera = 3
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 36
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "TIV_ESTADO"
        vArrayDatosComboBox(14).Longitud = 9
        vArrayDatosComboBox(14).Tipo = "varchar"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(1, 1)
        vArrayDatosComboBox(14).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(14).Valores(0, 1) = "0"
        vArrayDatosComboBox(14).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(14).Valores(1, 1) = "1"
        vArrayDatosComboBox(14).Ancho = 85
        vArrayDatosComboBox(14).Flag = True

        vArrayDatosComboBox(15).NombreCampo = "DTP_MONTO_TIV"
        vArrayDatosComboBox(15).Longitud = 18
        vArrayDatosComboBox(15).Tipo = "numeric"
        vArrayDatosComboBox(15).ParteEntera = 14
        vArrayDatosComboBox(15).ParteDecimal = 4
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 197
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "PER_ID"
        vArrayDatosComboBox(16).Longitud = 6
        vArrayDatosComboBox(16).Tipo = "char"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 68
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "PER_DESCRIPCION"
        vArrayDatosComboBox(17).Longitud = 77
        vArrayDatosComboBox(17).Tipo = "varchar"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 828
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "DTP_MONTO_PER"
        vArrayDatosComboBox(18).Longitud = 18
        vArrayDatosComboBox(18).Tipo = "numeric"
        vArrayDatosComboBox(18).ParteEntera = 14
        vArrayDatosComboBox(18).ParteDecimal = 4
        ReDim vArrayDatosComboBox(18).Valores(0, 0)
        vArrayDatosComboBox(18).Ancho = 197
        vArrayDatosComboBox(18).Flag = False

        vArrayDatosComboBox(19).NombreCampo = "DTP_TIPO_DESC_INC"
        vArrayDatosComboBox(19).Longitud = 0
        vArrayDatosComboBox(19).Tipo = "smallint"
        vArrayDatosComboBox(19).ParteEntera = 5
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(2, 1)
        vArrayDatosComboBox(19).Valores(0, 0) = "DESCUENTO POR VOLUMEN"
        vArrayDatosComboBox(19).Valores(0, 1) = "0"
        vArrayDatosComboBox(19).Valores(1, 0) = "DESCUENTO AUTOMATICO"
        vArrayDatosComboBox(19).Valores(1, 1) = "1"
        vArrayDatosComboBox(19).Valores(2, 0) = "OTROS"
        vArrayDatosComboBox(19).Valores(2, 1) = "2"
        vArrayDatosComboBox(19).Ancho = 220
        vArrayDatosComboBox(19).Flag = True

        vArrayDatosComboBox(20).NombreCampo = "DTP_CRITERIO"
        vArrayDatosComboBox(20).Longitud = 0
        vArrayDatosComboBox(20).Tipo = "bit"
        vArrayDatosComboBox(20).ParteEntera = 0
        vArrayDatosComboBox(20).ParteDecimal = 0
        ReDim vArrayDatosComboBox(20).Valores(1, 1)
        vArrayDatosComboBox(20).Valores(0, 0) = "POR VENTA"
        vArrayDatosComboBox(20).Valores(0, 1) = "0"
        vArrayDatosComboBox(20).Valores(1, 0) = "POR PROMOCION"
        vArrayDatosComboBox(20).Valores(1, 1) = "1"
        vArrayDatosComboBox(20).Ancho = 122
        vArrayDatosComboBox(20).Flag = True

        vArrayDatosComboBox(21).NombreCampo = "DTP_SUB_CRITERIO"
        vArrayDatosComboBox(21).Longitud = 0
        vArrayDatosComboBox(21).Tipo = "bit"
        vArrayDatosComboBox(21).ParteEntera = 0
        vArrayDatosComboBox(21).ParteDecimal = 0
        ReDim vArrayDatosComboBox(21).Valores(1, 1)
        vArrayDatosComboBox(21).Valores(0, 0) = "POR SIEMPRE"
        vArrayDatosComboBox(21).Valores(0, 1) = "0"
        vArrayDatosComboBox(21).Valores(1, 0) = "POR UNA VENTA"
        vArrayDatosComboBox(21).Valores(1, 1) = "1"
        vArrayDatosComboBox(21).Ancho = 122
        vArrayDatosComboBox(21).Flag = True

        vArrayDatosComboBox(22).NombreCampo = "DTP_MONTO_MINIMO"
        vArrayDatosComboBox(22).Longitud = 18
        vArrayDatosComboBox(22).Tipo = "numeric"
        vArrayDatosComboBox(22).ParteEntera = 14
        vArrayDatosComboBox(22).ParteDecimal = 4
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 197
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "DTP_MONTO_MAXIMO"
        vArrayDatosComboBox(23).Longitud = 18
        vArrayDatosComboBox(23).Tipo = "numeric"
        vArrayDatosComboBox(23).ParteEntera = 14
        vArrayDatosComboBox(23).ParteDecimal = 4
        ReDim vArrayDatosComboBox(23).Valores(0, 0)
        vArrayDatosComboBox(23).Ancho = 197
        vArrayDatosComboBox(23).Flag = False

        vArrayDatosComboBox(24).NombreCampo = "DTP_CANT_MINIMA"
        vArrayDatosComboBox(24).Longitud = 18
        vArrayDatosComboBox(24).Tipo = "numeric"
        vArrayDatosComboBox(24).ParteEntera = 15
        vArrayDatosComboBox(24).ParteDecimal = 3
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 197
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "DTP_CANT_MAXIMA"
        vArrayDatosComboBox(25).Longitud = 18
        vArrayDatosComboBox(25).Tipo = "numeric"
        vArrayDatosComboBox(25).ParteEntera = 15
        vArrayDatosComboBox(25).ParteDecimal = 3
        ReDim vArrayDatosComboBox(25).Valores(0, 0)
        vArrayDatosComboBox(25).Ancho = 197
        vArrayDatosComboBox(25).Flag = False

        vArrayDatosComboBox(26).NombreCampo = "DTP_FEC_INI"
        vArrayDatosComboBox(26).Longitud = 0
        vArrayDatosComboBox(26).Tipo = "smalldatetime"
        vArrayDatosComboBox(26).ParteEntera = 0
        vArrayDatosComboBox(26).ParteDecimal = 0
        ReDim vArrayDatosComboBox(26).Valores(0, 0)
        vArrayDatosComboBox(26).Ancho = 15
        vArrayDatosComboBox(26).Flag = False

        vArrayDatosComboBox(27).NombreCampo = "DTP_FEC_FIN"
        vArrayDatosComboBox(27).Longitud = 0
        vArrayDatosComboBox(27).Tipo = "smalldatetime"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(0, 0)
        vArrayDatosComboBox(27).Ancho = 15
        vArrayDatosComboBox(27).Flag = False

        vArrayDatosComboBox(28).NombreCampo = "DLP_ESTADO"
        vArrayDatosComboBox(28).Longitud = 9
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

        vArrayDatosComboBox(29).NombreCampo = "LPR_ESTADO"
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

        vArrayDatosComboBox(30).NombreCampo = "DTP_ESTADO"
        vArrayDatosComboBox(30).Longitud = 0
        vArrayDatosComboBox(30).Tipo = "bit"
        vArrayDatosComboBox(30).ParteEntera = 0
        vArrayDatosComboBox(30).ParteDecimal = 0
        ReDim vArrayDatosComboBox(30).Valores(1, 1)
        vArrayDatosComboBox(30).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(30).Valores(0, 1) = "0"
        vArrayDatosComboBox(30).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(30).Valores(1, 1) = "1"
        vArrayDatosComboBox(30).Ancho = 85
        vArrayDatosComboBox(30).Flag = True

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            Select Case vCampos(elemento)
                Case "DTP_DESCRIPCION"
                    If Len(DTP_DESCRIPCION.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "LPR_ID"
                    If Len(LPR_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "ART_ID"
                    If IsNothing(ART_ID) Then
                        If DTP_MONTO_MINIMO <> 0 And DTP_MONTO_MINIMO < DTP_MONTO_MAXIMO Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = "Error en los montos"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    Else
                        If Len(ART_ID.Trim) = 6 Then
                            If DTP_CANT_MINIMA <> 0 And DTP_CANT_MINIMA < DTP_CANT_MAXIMA Then
                            Else
                                VerificarDatos.NumeroError = 0
                                VerificarDatos.MensajeError = "Error en las cantidades"
                                VerificarDatos.Objeto = vCampos(elemento)
                            End If
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo6
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "TIV_ID"
                    If Len(TIV_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_MONTO_TIV"
                    If DTP_MONTO_TIV.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_ID"
                    If IsNothing(PER_ID) Then
                        If DTP_MONTO_TIV <> 0 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = "Error en el Dscto./Inc. del tipo de venta"
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    Else
                        If Len(PER_ID.Trim) = 6 Then
                            If DTP_MONTO_PER <> 0 Then
                            Else
                                VerificarDatos.NumeroError = 0
                                VerificarDatos.MensajeError = "Error en el Dscto./Inc. de la persona"
                                VerificarDatos.Objeto = vCampos(elemento)
                            End If
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo6
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "DTP_MONTO_PER"
                    If IsNothing(DTP_MONTO_PER) Then
                    Else
                        If DTP_MONTO_PER.GetType = GetType(Decimal) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "DTP_TIPO_DESC_INC"
                    If DTP_TIPO_DESC_INC >= 0 And DTP_TIPO_DESC_INC <= 2 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_CRITERIO"
                    If DTP_CRITERIO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_SUB_CRITERIO"
                    If DTP_SUB_CRITERIO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_MONTO_MINIMO"
                    If DTP_MONTO_MINIMO.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_MONTO_MAXIMO"
                    If DTP_MONTO_MAXIMO.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_CANT_MINIMA"
                    If DTP_CANT_MINIMA.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_CANT_MAXIMA"
                    If DTP_CANT_MAXIMA.GetType = GetType(Decimal) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_FEC_INI"
                    If IsNothing(DTP_FEC_INI) Then
                    Else
                        If DTP_FEC_INI.GetType = GetType(Date) Then
                            If DTP_FEC_INI > DTP_FEC_FIN Then
                                VerificarDatos.NumeroError = 0
                                VerificarDatos.MensajeError = mFecha
                                VerificarDatos.Objeto = vCampos(elemento)
                            End If
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mFecha
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "DTP_FEC_FIN"
                    If IsNothing(DTP_FEC_FIN) Then
                    Else
                        If DTP_FEC_FIN.GetType = GetType(Date) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mFecha
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_FEC_GRAB"
                    If DTP_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTP_ESTADO"
                    If DTP_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaDescuentoIncrementoTipoVentaPersonasXML"
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
                oVerificarDatos = VerificarDatos("DTP_DESCRIPCION", "LPR_ID", "ART_ID", "TIV_ID", "DTP_MONTO_TIV", "PER_ID", "DTP_MONTO_PER", "DTP_TIPO_DESC_INC", "DTP_CRITERIO", "DTP_SUB_CRITERIO", "DTP_MONTO_MINIMO", "DTP_MONTO_MAXIMO", "DTP_CANT_MINIMA", "DTP_CANT_MAXIMA", "DTP_FEC_INI", "DTP_FEC_FIN", "USU_ID", "DTP_FEC_GRAB", "DTP_ESTADO")
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

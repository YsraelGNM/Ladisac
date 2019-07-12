Imports Ladisac.BE

Partial Public Class UnidadesTransporte
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
    Public CampoPrincipal = "UNT_ID"
    Public CampoPrincipalValor = UNT_ID



    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.UnidadesTransporte"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "UnidadesTransporte"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwUnidadesTransporte"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaUnidadesTransporte"
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
        vElementosDatosComboBox = 27
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "UNT_ID"
        vArrayCamposBusqueda(1) = "UNT_COMPORTAMIENTO"
        vArrayCamposBusqueda(2) = "UNT_TIPO"
        vArrayCamposBusqueda(3) = "TUN_ID"
        vArrayCamposBusqueda(4) = "TUN_DESCRIPCION"
        vArrayCamposBusqueda(5) = "TUN_ESTADO"
        vArrayCamposBusqueda(6) = "MAR_ID"
        vArrayCamposBusqueda(7) = "MAR_DESCRIPCION"
        vArrayCamposBusqueda(8) = "MAR_ESTADO"
        vArrayCamposBusqueda(9) = "MOD_ID"
        vArrayCamposBusqueda(10) = "MOD_DESCRIPCION"
        vArrayCamposBusqueda(11) = "MOD_ESTADO"
        vArrayCamposBusqueda(12) = "UNT_TARA"
        vArrayCamposBusqueda(13) = "UNT_NRO_INS"
        vArrayCamposBusqueda(14) = "PER_ID"
        vArrayCamposBusqueda(15) = "PER_DESCRIPCION"
        vArrayCamposBusqueda(16) = "TDP_ID"
        vArrayCamposBusqueda(17) = "TDP_DESCRIPCION"
        vArrayCamposBusqueda(18) = "DOP_NUMERO"
        vArrayCamposBusqueda(19) = "DOP_ESTADO"
        vArrayCamposBusqueda(20) = "PER_ESTADO"
        vArrayCamposBusqueda(21) = "UNT_KILOMETRAJE"
        vArrayCamposBusqueda(22) = "UNT_HOROMETRO"
        vArrayCamposBusqueda(23) = "UNT_NRO_SERIE"
        vArrayCamposBusqueda(24) = "UNT_NRO_MOTOR"
        vArrayCamposBusqueda(25) = "UNT_ANIO_FABRICACION"
        vArrayCamposBusqueda(26) = "UNT_FECHA_ADQUISICION"
        vArrayCamposBusqueda(27) = "UNT_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "UNT_ID"
        vArrayDatosComboBox(0).Longitud = 10
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 111
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "UNT_COMPORTAMIENTO"
        vArrayDatosComboBox(1).Longitud = 5
        vArrayDatosComboBox(1).Tipo = "smallint"
        vArrayDatosComboBox(1).ParteEntera = 5
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(1, 1)
        vArrayDatosComboBox(1).Valores(0, 0) = "TRANSPORTISTA"
        vArrayDatosComboBox(1).Valores(0, 1) = "0"
        vArrayDatosComboBox(1).Valores(1, 0) = "ACTIVO FIJO"
        vArrayDatosComboBox(1).Valores(1, 1) = "1"
        vArrayDatosComboBox(1).Ancho = 118
        vArrayDatosComboBox(1).Flag = True

        vArrayDatosComboBox(2).NombreCampo = "UNT_TIPO"
        vArrayDatosComboBox(2).Longitud = 5
        vArrayDatosComboBox(2).Tipo = "smallint"
        vArrayDatosComboBox(2).ParteEntera = 5
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(10, 1)
        vArrayDatosComboBox(2).Valores(0, 0) = "TRACTO"
        vArrayDatosComboBox(2).Valores(0, 1) = "0"
        vArrayDatosComboBox(2).Valores(1, 0) = "SEMIREMOLQUE"
        vArrayDatosComboBox(2).Valores(1, 1) = "1"
        vArrayDatosComboBox(2).Valores(2, 0) = "CAMION"
        vArrayDatosComboBox(2).Valores(2, 1) = "2"
        vArrayDatosComboBox(2).Valores(3, 0) = "REMOLQUE"
        vArrayDatosComboBox(2).Valores(3, 1) = "3"
        vArrayDatosComboBox(2).Valores(4, 0) = "AUTOBUS"
        vArrayDatosComboBox(2).Valores(4, 1) = "4"
        vArrayDatosComboBox(2).Valores(5, 0) = "CAMIONETA"
        vArrayDatosComboBox(2).Valores(5, 1) = "5"
        vArrayDatosComboBox(2).Valores(6, 0) = "VEHICULO"
        vArrayDatosComboBox(2).Valores(6, 1) = "6"
        vArrayDatosComboBox(2).Valores(7, 0) = "MONTACARGA"
        vArrayDatosComboBox(2).Valores(7, 1) = "7"
        vArrayDatosComboBox(2).Valores(8, 0) = "TRACTOR"
        vArrayDatosComboBox(2).Valores(8, 1) = "8"
        vArrayDatosComboBox(2).Valores(9, 0) = "MOTO"
        vArrayDatosComboBox(2).Valores(9, 1) = "9"
        vArrayDatosComboBox(2).Valores(10, 0) = "OTRO"
        vArrayDatosComboBox(2).Valores(10, 1) = "10"
        vArrayDatosComboBox(2).Ancho = 116
        vArrayDatosComboBox(2).Flag = True

        vArrayDatosComboBox(3).NombreCampo = "TUN_ID"
        vArrayDatosComboBox(3).Longitud = 3
        vArrayDatosComboBox(3).Tipo = "char"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 36
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "TUN_DESCRIPCION"
        vArrayDatosComboBox(4).Longitud = 45
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 485
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "TUN_ESTADO"
        vArrayDatosComboBox(5).Longitud = 9
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(1, 1)
        vArrayDatosComboBox(5).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(5).Valores(0, 1) = "0"
        vArrayDatosComboBox(5).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(5).Valores(1, 1) = "1"
        vArrayDatosComboBox(5).Ancho = 85
        vArrayDatosComboBox(5).Flag = True

        vArrayDatosComboBox(6).NombreCampo = "MAR_ID"
        vArrayDatosComboBox(6).Longitud = 3
        vArrayDatosComboBox(6).Tipo = "char"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 36
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "MAR_DESCRIPCION"
        vArrayDatosComboBox(7).Longitud = 45
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 485
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "MAR_ESTADO"
        vArrayDatosComboBox(8).Longitud = 9
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(1, 1)
        vArrayDatosComboBox(8).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(8).Valores(0, 1) = "0"
        vArrayDatosComboBox(8).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(8).Valores(1, 1) = "1"
        vArrayDatosComboBox(8).Ancho = 85
        vArrayDatosComboBox(8).Flag = True

        vArrayDatosComboBox(9).NombreCampo = "MOD_ID"
        vArrayDatosComboBox(9).Longitud = 3
        vArrayDatosComboBox(9).Tipo = "char"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 36
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "MOD_DESCRIPCION"
        vArrayDatosComboBox(10).Longitud = 45
        vArrayDatosComboBox(10).Tipo = "varchar"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 485
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "MOD_ESTADO"
        vArrayDatosComboBox(11).Longitud = 9
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(1, 1)
        vArrayDatosComboBox(11).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(11).Valores(0, 1) = "0"
        vArrayDatosComboBox(11).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(11).Valores(1, 1) = "1"
        vArrayDatosComboBox(11).Ancho = 85
        vArrayDatosComboBox(11).Flag = True

        vArrayDatosComboBox(12).NombreCampo = "UNT_TARA"
        vArrayDatosComboBox(12).Longitud = 18
        vArrayDatosComboBox(12).Tipo = "numeric"
        vArrayDatosComboBox(12).ParteEntera = 14
        vArrayDatosComboBox(12).ParteDecimal = 4
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 197
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "UNT_NRO_INS"
        vArrayDatosComboBox(13).Longitud = 25
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 272
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "PER_ID"
        vArrayDatosComboBox(14).Longitud = 6
        vArrayDatosComboBox(14).Tipo = "char"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 68
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "PER_DESCRIPCION"
        vArrayDatosComboBox(15).Longitud = 77
        vArrayDatosComboBox(15).Tipo = "varchar"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(0, 0)
        vArrayDatosComboBox(15).Ancho = 828
        vArrayDatosComboBox(15).Flag = False

        vArrayDatosComboBox(16).NombreCampo = "TDP_ID"
        vArrayDatosComboBox(16).Longitud = 2
        vArrayDatosComboBox(16).Tipo = "char"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 26
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "TDP_DESCRIPCION"
        vArrayDatosComboBox(17).Longitud = 45
        vArrayDatosComboBox(17).Tipo = "varchar"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 485
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "DOP_NUMERO"
        vArrayDatosComboBox(18).Longitud = 25
        vArrayDatosComboBox(18).Tipo = "varchar"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(0, 0)
        vArrayDatosComboBox(18).Ancho = 272
        vArrayDatosComboBox(18).Flag = False

        vArrayDatosComboBox(19).NombreCampo = "DOP_ESTADO"
        vArrayDatosComboBox(19).Longitud = 9
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(1, 1)
        vArrayDatosComboBox(19).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(19).Valores(0, 1) = "0"
        vArrayDatosComboBox(19).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(19).Valores(1, 1) = "1"
        vArrayDatosComboBox(19).Ancho = 85
        vArrayDatosComboBox(19).Flag = True

        vArrayDatosComboBox(20).NombreCampo = "PER_ESTADO"
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

        vArrayDatosComboBox(21).NombreCampo = "UNT_KILOMETRAJE"
        vArrayDatosComboBox(21).Longitud = 18
        vArrayDatosComboBox(21).Tipo = "numeric"
        vArrayDatosComboBox(21).ParteEntera = 15
        vArrayDatosComboBox(21).ParteDecimal = 3
        ReDim vArrayDatosComboBox(21).Valores(0, 0)
        vArrayDatosComboBox(21).Ancho = 197
        vArrayDatosComboBox(21).Flag = False

        vArrayDatosComboBox(22).NombreCampo = "UNT_HOROMETRO"
        vArrayDatosComboBox(22).Longitud = 18
        vArrayDatosComboBox(22).Tipo = "numeric"
        vArrayDatosComboBox(22).ParteEntera = 15
        vArrayDatosComboBox(22).ParteDecimal = 3
        ReDim vArrayDatosComboBox(22).Valores(0, 0)
        vArrayDatosComboBox(22).Ancho = 197
        vArrayDatosComboBox(22).Flag = False

        vArrayDatosComboBox(23).NombreCampo = "UNT_NRO_SERIE"
        vArrayDatosComboBox(23).Longitud = 50
        vArrayDatosComboBox(23).Tipo = "varchar"
        vArrayDatosComboBox(23).ParteEntera = 0
        vArrayDatosComboBox(23).ParteDecimal = 0
        ReDim vArrayDatosComboBox(23).Valores(0, 0)
        vArrayDatosComboBox(23).Ancho = 539
        vArrayDatosComboBox(23).Flag = False

        vArrayDatosComboBox(24).NombreCampo = "UNT_NRO_MOTOR"
        vArrayDatosComboBox(24).Longitud = 50
        vArrayDatosComboBox(24).Tipo = "varchar"
        vArrayDatosComboBox(24).ParteEntera = 0
        vArrayDatosComboBox(24).ParteDecimal = 0
        ReDim vArrayDatosComboBox(24).Valores(0, 0)
        vArrayDatosComboBox(24).Ancho = 539
        vArrayDatosComboBox(24).Flag = False

        vArrayDatosComboBox(25).NombreCampo = "UNT_ANIO_FABRICACION"
        vArrayDatosComboBox(25).Longitud = 4
        vArrayDatosComboBox(25).Tipo = "numeric"
        vArrayDatosComboBox(25).ParteEntera = 4
        vArrayDatosComboBox(25).ParteDecimal = 0
        ReDim vArrayDatosComboBox(25).Valores(0, 0)
        vArrayDatosComboBox(25).Ancho = 47
        vArrayDatosComboBox(25).Flag = False

        vArrayDatosComboBox(26).NombreCampo = "UNT_FECHA_ADQUISICION"
        vArrayDatosComboBox(26).Longitud = 0
        vArrayDatosComboBox(26).Tipo = "smalldatetime"
        vArrayDatosComboBox(26).ParteEntera = 0
        vArrayDatosComboBox(26).ParteDecimal = 0
        ReDim vArrayDatosComboBox(26).Valores(0, 0)
        vArrayDatosComboBox(26).Ancho = 15
        vArrayDatosComboBox(26).Flag = False

        vArrayDatosComboBox(27).NombreCampo = "UNT_ESTADO"
        vArrayDatosComboBox(27).Longitud = 0
        vArrayDatosComboBox(27).Tipo = "bit"
        vArrayDatosComboBox(27).ParteEntera = 0
        vArrayDatosComboBox(27).ParteDecimal = 0
        ReDim vArrayDatosComboBox(27).Valores(1, 1)
        vArrayDatosComboBox(27).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(27).Valores(0, 1) = "0"
        vArrayDatosComboBox(27).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(27).Valores(1, 1) = "1"
        vArrayDatosComboBox(27).Ancho = 85
        vArrayDatosComboBox(27).Flag = True
    End Sub

    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "UNT_ID"
                    If Len(UNT_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo10_1
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "UNT_COMPORTAMIENTO"
                    If UNT_COMPORTAMIENTO >= 0 And UNT_COMPORTAMIENTO <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "UNT_TIPO"
                    If UNT_TIPO >= 0 And UNT_TIPO <= 10 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TUN_ID"
                    If IsNothing(TUN_ID) Then
                    Else
                        If Len(TUN_ID.Trim) >= 0 And Len(TUN_ID.Trim) <= 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "MAR_ID"
                    If IsNothing(MAR_ID) Then
                    Else
                        If Len(MAR_ID.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "MOD_ID"
                    If IsNothing(MOD_ID) Then
                    Else
                        If Len(MOD_ID.Trim) = 3 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo3
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "UNT_TARA"
                    If IsNothing(UNT_TARA) Then
                    Else
                        If UNT_TARA.GetType = GetType(Decimal) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "UNT_NRO_INS"
                    If IsNothing(UNT_NRO_INS) Then
                    Else
                        If UNT_NRO_INS.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "PER_ID"
                    If IsNothing(PER_ID) Then
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    Else
                        If Len(PER_ID.Trim) = 6 Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mCodigo6
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "UNT_KILOMETRAJE"
                    If IsNothing(UNT_KILOMETRAJE) Then
                    Else
                        If UNT_KILOMETRAJE.GetType = GetType(Decimal) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If

                Case "UNT_HOROMETRO"
                    If IsNothing(UNT_HOROMETRO) Then
                    Else
                        If UNT_HOROMETRO.GetType = GetType(Decimal) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "UNT_NRO_SERIE"
                    If IsNothing(UNT_NRO_SERIE) Then
                    Else
                        If UNT_NRO_SERIE.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "UNT_NRO_MOTOR"
                    If IsNothing(UNT_NRO_MOTOR) Then
                    Else
                        If UNT_NRO_MOTOR.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "UNT_ANIO_FABRICACION"
                    If UNT_ANIO_FABRICACION >= 1900 And UNT_ANIO_FABRICACION <= 3000 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                    'If IsNothing(UNT_ANIO_FABRICACION) Then
                    'Else
                    '    If UNT_ANIO_FABRICACION.GetType = GetType(Decimal) Then
                    '    Else
                    '        VerificarDatos.NumeroError = 0
                    '        VerificarDatos.MensajeError = mDato
                    '        VerificarDatos.Objeto = vCampos(elemento)
                    '    End If
                    'End If
                Case "UNT_FECHA_ADQUISICION"
                    If IsNothing(UNT_FECHA_ADQUISICION) Then
                    Else
                        If UNT_FECHA_ADQUISICION.GetType = GetType(Date) Then
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

                Case "UNT_FEC_GRAB"
                    If UNT_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "UNT_ESTADO"
                    If UNT_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaUnidadesTransporteXML"
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
                oVerificarDatos = VerificarDatos("UNT_ID", "UNT_COMPORTAMIENTO", "UNT_TIPO", "TUN_ID", "MAR_ID", "MOD_ID", "UNT_TARA", "UNT_NRO_INS", "PER_ID", "UNT_KILOMETRAJE", "UNT_HOROMETRO", "UNT_NRO_SERIE", "UNT_NRO_MOTOR", "UNT_ANIO_FABRICACION", "UNT_FECHA_ADQUISICION", "USU_ID", "UNT_FEC_GRAB", "UNT_ESTADO")

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

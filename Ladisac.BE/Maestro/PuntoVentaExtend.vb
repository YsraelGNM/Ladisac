Imports Ladisac.BE

Partial Public Class PuntoVenta
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public CampoPrincipal = "PVE_ID"
    Public CampoPrincipalValor = PVE_ID
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 1
    Public CadenaFiltrado As String = ""

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.PuntoVenta"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "PuntoVenta"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwPuntoVenta"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaPuntoVenta"
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
        vElementosDatosComboBox = 20
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "PVE_ID"
        vArrayCamposBusqueda(1) = "PVE_DESCRIPCION"
        vArrayCamposBusqueda(2) = "PVE_DIRECCION"
        vArrayCamposBusqueda(3) = "PVE_TELEFONOS"
        vArrayCamposBusqueda(4) = "PAI_ID"
        vArrayCamposBusqueda(5) = "PAI_DESCRIPCION"
        vArrayCamposBusqueda(6) = "PAI_ESTADO"
        vArrayCamposBusqueda(7) = "DEP_ID"
        vArrayCamposBusqueda(8) = "DEP_DESCRIPCION"
        vArrayCamposBusqueda(9) = "DEP_ESTADO"
        vArrayCamposBusqueda(10) = "PRO_ID"
        vArrayCamposBusqueda(11) = "PRO_DESCRIPCION"
        vArrayCamposBusqueda(12) = "PRO_ESTADO"
        vArrayCamposBusqueda(13) = "DIS_ID"
        vArrayCamposBusqueda(14) = "DIS_DESCRIPCION"
        vArrayCamposBusqueda(15) = "DIS_ESTADO"
        vArrayCamposBusqueda(16) = "LPR_ID"
        vArrayCamposBusqueda(17) = "LPR_DESCRIPCION"
        vArrayCamposBusqueda(18) = "PVE_TIPO"
        vArrayCamposBusqueda(19) = "LPR_ESTADO"
        vArrayCamposBusqueda(20) = "PVE_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "PVE_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "PVE_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 45
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 485
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "PVE_DIRECCION"
        vArrayDatosComboBox(2).Longitud = 65
        vArrayDatosComboBox(2).Tipo = "varchar"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 699
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PVE_TELEFONOS"
        vArrayDatosComboBox(3).Longitud = 30
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 325
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PAI_ID"
        vArrayDatosComboBox(4).Longitud = 3
        vArrayDatosComboBox(4).Tipo = "char"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 36
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "PAI_DESCRIPCION"
        vArrayDatosComboBox(5).Longitud = 45
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 485
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "PAI_ESTADO"
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

        vArrayDatosComboBox(7).NombreCampo = "DEP_ID"
        vArrayDatosComboBox(7).Longitud = 3
        vArrayDatosComboBox(7).Tipo = "char"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 36
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "DEP_DESCRIPCION"
        vArrayDatosComboBox(8).Longitud = 45
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 485
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "DEP_ESTADO"
        vArrayDatosComboBox(9).Longitud = 9
        vArrayDatosComboBox(9).Tipo = "varchar"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(1, 1)
        vArrayDatosComboBox(9).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(9).Valores(0, 1) = "0"
        vArrayDatosComboBox(9).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(9).Valores(1, 1) = "1"
        vArrayDatosComboBox(9).Ancho = 85
        vArrayDatosComboBox(9).Flag = True

        vArrayDatosComboBox(10).NombreCampo = "PRO_ID"
        vArrayDatosComboBox(10).Longitud = 3
        vArrayDatosComboBox(10).Tipo = "char"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 36
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "PRO_DESCRIPCION"
        vArrayDatosComboBox(11).Longitud = 45
        vArrayDatosComboBox(11).Tipo = "varchar"
        vArrayDatosComboBox(11).ParteEntera = 0
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(0, 0)
        vArrayDatosComboBox(11).Ancho = 485
        vArrayDatosComboBox(11).Flag = False

        vArrayDatosComboBox(12).NombreCampo = "PRO_ESTADO"
        vArrayDatosComboBox(12).Longitud = 9
        vArrayDatosComboBox(12).Tipo = "varchar"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(1, 1)
        vArrayDatosComboBox(12).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(12).Valores(0, 1) = "0"
        vArrayDatosComboBox(12).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(12).Valores(1, 1) = "1"
        vArrayDatosComboBox(12).Ancho = 85
        vArrayDatosComboBox(12).Flag = True

        vArrayDatosComboBox(13).NombreCampo = "DIS_ID"
        vArrayDatosComboBox(13).Longitud = 3
        vArrayDatosComboBox(13).Tipo = "char"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 36
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "DIS_DESCRIPCION"
        vArrayDatosComboBox(14).Longitud = 45
        vArrayDatosComboBox(14).Tipo = "varchar"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(0, 0)
        vArrayDatosComboBox(14).Ancho = 485
        vArrayDatosComboBox(14).Flag = False

        vArrayDatosComboBox(15).NombreCampo = "DIS_ESTADO"
        vArrayDatosComboBox(15).Longitud = 9
        vArrayDatosComboBox(15).Tipo = "varchar"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(1, 1)
        vArrayDatosComboBox(15).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(15).Valores(0, 1) = "0"
        vArrayDatosComboBox(15).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(15).Valores(1, 1) = "1"
        vArrayDatosComboBox(15).Ancho = 85
        vArrayDatosComboBox(15).Flag = True

        vArrayDatosComboBox(16).NombreCampo = "LPR_ID"
        vArrayDatosComboBox(16).Longitud = 3
        vArrayDatosComboBox(16).Tipo = "char"
        vArrayDatosComboBox(16).ParteEntera = 0
        vArrayDatosComboBox(16).ParteDecimal = 0
        ReDim vArrayDatosComboBox(16).Valores(0, 0)
        vArrayDatosComboBox(16).Ancho = 36
        vArrayDatosComboBox(16).Flag = False

        vArrayDatosComboBox(17).NombreCampo = "LPR_DESCRIPCION"
        vArrayDatosComboBox(17).Longitud = 45
        vArrayDatosComboBox(17).Tipo = "varchar"
        vArrayDatosComboBox(17).ParteEntera = 0
        vArrayDatosComboBox(17).ParteDecimal = 0
        ReDim vArrayDatosComboBox(17).Valores(0, 0)
        vArrayDatosComboBox(17).Ancho = 485
        vArrayDatosComboBox(17).Flag = False

        vArrayDatosComboBox(18).NombreCampo = "LPR_ESTADO"
        vArrayDatosComboBox(18).Longitud = 9
        vArrayDatosComboBox(18).Tipo = "varchar"
        vArrayDatosComboBox(18).ParteEntera = 0
        vArrayDatosComboBox(18).ParteDecimal = 0
        ReDim vArrayDatosComboBox(18).Valores(1, 1)
        vArrayDatosComboBox(18).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(18).Valores(0, 1) = "0"
        vArrayDatosComboBox(18).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(18).Valores(1, 1) = "1"
        vArrayDatosComboBox(18).Ancho = 85
        vArrayDatosComboBox(18).Flag = True

        vArrayDatosComboBox(19).NombreCampo = "PVE_TIPO"
        vArrayDatosComboBox(19).Longitud = 14
        vArrayDatosComboBox(19).Tipo = "varchar"
        vArrayDatosComboBox(19).ParteEntera = 0
        vArrayDatosComboBox(19).ParteDecimal = 0
        ReDim vArrayDatosComboBox(19).Valores(1, 1)
        vArrayDatosComboBox(19).Valores(0, 0) = "PLANTA"
        vArrayDatosComboBox(19).Valores(0, 1) = "0"
        vArrayDatosComboBox(19).Valores(1, 0) = "PUNTO DE VENTA"
        vArrayDatosComboBox(19).Valores(1, 1) = "1"
        vArrayDatosComboBox(19).Ancho = 122
        vArrayDatosComboBox(19).Flag = True

        vArrayDatosComboBox(20).NombreCampo = "PVE_ESTADO"
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
    End Sub

    Public Function VerificarDatos(ByVal ParamArray vCampos() As String) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            Select Case vCampos(elemento)
                Case "PVE_ID"
                    If Len(PVE_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PVE_DESCRIPCION"
                    If Len(PVE_DESCRIPCION.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PVE_DIRECCION"
                    If Len(PVE_DIRECCION.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DIS_ID"
                    If Len(DIS_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PVE_TIPO"
                    If PVE_TIPO >= 0 And PVE_TIPO <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError =
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PVE_FEC_GRAB"
                    If PVE_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PVE_ESTADO"
                    If PVE_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaPuntoVentaXML"
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

Imports Ladisac.BE
Partial Public Class DetalleCierre
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato

    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 2
    Public CampoPrincipal = "CIE_ID"
    Public CampoPrincipalSecundario = "DTD_ID"
    Public CampoPrincipalValor = CIE_ID
    Public CampoPrincipalSecundarioValor = "CIE_ID"

    Public CadenaFiltrado As String = ""
    Public vMensajeError As String = ""
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.DetalleCierre"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetalleCierre"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetalleCierre"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetalleCierre"
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
        vElementosDatosComboBox = 8
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "CIE_ID"
        vArrayCamposBusqueda(1) = "CIE_MES"
        vArrayCamposBusqueda(2) = "CIE_ANIO"
        vArrayCamposBusqueda(3) = "PVE_ID"
        vArrayCamposBusqueda(4) = "PVE_DESCRIPCION"
        vArrayCamposBusqueda(5) = "DTD_ID"
        vArrayCamposBusqueda(6) = "DTD_DESCRIPCION"
        vArrayCamposBusqueda(7) = "DCI_COMPORTAMIENTO"
        vArrayCamposBusqueda(8) = "DCI_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "CIE_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "CIE_MES"
        vArrayDatosComboBox(1).Longitud = 10
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(11, 1)
        vArrayDatosComboBox(1).Valores(0, 0) = "ENERO"
        vArrayDatosComboBox(1).Valores(0, 1) = "0"
        vArrayDatosComboBox(1).Valores(1, 0) = "FEBRERO"
        vArrayDatosComboBox(1).Valores(1, 1) = "1"
        vArrayDatosComboBox(1).Valores(2, 0) = "MARZO"
        vArrayDatosComboBox(1).Valores(2, 1) = "2"
        vArrayDatosComboBox(1).Valores(3, 0) = "ABRIL"
        vArrayDatosComboBox(1).Valores(3, 1) = "3"
        vArrayDatosComboBox(1).Valores(4, 0) = "MAYO"
        vArrayDatosComboBox(1).Valores(4, 1) = "4"
        vArrayDatosComboBox(1).Valores(5, 0) = "JUNIO"
        vArrayDatosComboBox(1).Valores(5, 1) = "5"
        vArrayDatosComboBox(1).Valores(6, 0) = "JULIO"
        vArrayDatosComboBox(1).Valores(6, 1) = "6"
        vArrayDatosComboBox(1).Valores(7, 0) = "AGOSTO"
        vArrayDatosComboBox(1).Valores(7, 1) = "7"
        vArrayDatosComboBox(1).Valores(8, 0) = "SEPTIEMBRE"
        vArrayDatosComboBox(1).Valores(8, 1) = "8"
        vArrayDatosComboBox(1).Valores(9, 0) = "OCTUBRE"
        vArrayDatosComboBox(1).Valores(9, 1) = "9"
        vArrayDatosComboBox(1).Valores(10, 0) = "NOVIEMBRE"
        vArrayDatosComboBox(1).Valores(10, 1) = "10"
        vArrayDatosComboBox(1).Valores(11, 0) = "DICIEMBRE"
        vArrayDatosComboBox(1).Valores(11, 1) = "11"
        vArrayDatosComboBox(1).Ancho = 96
        vArrayDatosComboBox(1).Flag = True

        vArrayDatosComboBox(2).NombreCampo = "CIE_ANIO"
        vArrayDatosComboBox(2).Longitud = 4
        vArrayDatosComboBox(2).Tipo = "numeric"
        vArrayDatosComboBox(2).ParteEntera = 4
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 47
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PVE_ID"
        vArrayDatosComboBox(3).Longitud = 3
        vArrayDatosComboBox(3).Tipo = "char"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 36
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PVE_DESCRIPCION"
        vArrayDatosComboBox(4).Longitud = 45
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 485
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "DTD_ID"
        vArrayDatosComboBox(5).Longitud = 3
        vArrayDatosComboBox(5).Tipo = "char"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 36
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "DTD_DESCRIPCION"
        vArrayDatosComboBox(6).Longitud = 45
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 485
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "DCI_COMPORTAMIENTO"
        vArrayDatosComboBox(7).Longitud = 5
        vArrayDatosComboBox(7).Tipo = "smallint"
        vArrayDatosComboBox(7).ParteEntera = 5
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(2, 1)
        vArrayDatosComboBox(7).Valores(0, 0) = "ABIERTO"
        vArrayDatosComboBox(7).Valores(0, 1) = "0"
        vArrayDatosComboBox(7).Valores(1, 0) = "CERRADO"
        vArrayDatosComboBox(7).Valores(1, 1) = "1"
        vArrayDatosComboBox(7).Valores(2, 0) = "ATENDER"
        vArrayDatosComboBox(7).Valores(2, 1) = "2"
        vArrayDatosComboBox(7).Ancho = 80
        vArrayDatosComboBox(7).Flag = True

        vArrayDatosComboBox(8).NombreCampo = "DCI_ESTADO"
        vArrayDatosComboBox(8).Longitud = 0
        vArrayDatosComboBox(8).Tipo = "bit"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(1, 1)
        vArrayDatosComboBox(8).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(8).Valores(0, 1) = "0"
        vArrayDatosComboBox(8).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(8).Valores(1, 1) = "1"
        vArrayDatosComboBox(8).Ancho = 85
        vArrayDatosComboBox(8).Flag = True

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            Select Case vCampos(elemento)
                Case "CIE_ID"
                    If Len(CIE_ID.Trim) = 3 Then
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

                Case "DCI_COMPORTAMIENTO"
                    If DCI_COMPORTAMIENTO >= 0 And DCI_COMPORTAMIENTO <= 2 Then
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

                Case "DCI_FEC_GRAB"
                    If DCI_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DCI_ESTADO"
                    If DCI_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaDetalleCierreXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetalleCierreXML"
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
                oVerificarDatos = VerificarDatos("CIE_ID", "DTD_ID", "DCI_COMPORTAMIENTO", "USU_ID", "DCI_FEC_GRAB", "DCI_ESTADO")
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

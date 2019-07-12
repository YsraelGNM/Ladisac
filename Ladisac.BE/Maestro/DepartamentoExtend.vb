Imports Ladisac.BE

Partial Public Class Departamento
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public CampoPrincipal = "DEP_ID"
    Public CampoPrincipalValor = DEP_ID
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 1
    Public CadenaFiltrado As String = ""

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.Departamento"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "Departamento"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDepartamento"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDepartamento"
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
        vElementosDatosComboBox = 6
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "DEP_ID"
        vArrayCamposBusqueda(1) = "DEP_DESCRIPCION"
        vArrayCamposBusqueda(2) = "PAI_ID"
        vArrayCamposBusqueda(3) = "PAI_DESCRIPCION"
        vArrayCamposBusqueda(4) = "PAI_ESTADO"
        vArrayCamposBusqueda(5) = "DEP_COD_SUNAT"
        vArrayCamposBusqueda(6) = "DEP_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "DEP_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "DEP_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 45
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 485
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "PAI_ID"
        vArrayDatosComboBox(2).Longitud = 3
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 36
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PAI_DESCRIPCION"
        vArrayDatosComboBox(3).Longitud = 45
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 485
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PAI_ESTADO"
        vArrayDatosComboBox(4).Longitud = 0
        vArrayDatosComboBox(4).Tipo = "bit"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(1, 1)
        vArrayDatosComboBox(4).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(4).Valores(0, 1) = "0"
        vArrayDatosComboBox(4).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(4).Valores(1, 1) = "1"
        vArrayDatosComboBox(4).Ancho = 85
        vArrayDatosComboBox(4).Flag = True

        vArrayDatosComboBox(5).NombreCampo = "DEP_COD_SUNAT"
        vArrayDatosComboBox(5).Longitud = 2
        vArrayDatosComboBox(5).Tipo = "char"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 24
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "DEP_ESTADO"
        vArrayDatosComboBox(6).Longitud = 0
        vArrayDatosComboBox(6).Tipo = "bit"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(1, 1)
        vArrayDatosComboBox(6).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(6).Valores(0, 1) = "0"
        vArrayDatosComboBox(6).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(6).Valores(1, 1) = "1"
        vArrayDatosComboBox(6).Ancho = 85
        vArrayDatosComboBox(6).Flag = True
    End Sub

    Public Function VerificarDatos(ByVal ParamArray vCampos() As String) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1

        For elemento = 0 To vCampos.Count - 1
            Select Case vCampos(elemento)
                Case "DEP_ID"
                    If Len(DEP_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3 & " : Código departamento"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "DEP_DESCRIPCION"
                    If Len(DEP_DESCRIPCION.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion & " : Descripcion departamento"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "DEP_COD_SUNAT"
                    If Len(DEP_COD_SUNAT.Trim) = 2 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo2 & " : Código de sunat"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "PAI_ID"
                    If Len(PAI_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3 & " : Código de país"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario & " : Código de usuario"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "DEP_FEC_GRAB"
                    If DEP_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha & " : Fecha de grabación"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "DEP_ESTADO"
                    If DEP_ESTADO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado & " : Estado de departamento"
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
            End Select
            If VerificarDatos.NumeroError = 0 Then
                If (vCampos.Count - 1) = 0 Then
                    VerificarDatos.MensajeGeneral += VerificarDatos.MensajeError & Chr(13)
                Else
                    If VerificarDatos.MensajeError Is Nothing Then
                    Else
                        VerificarDatos.MensajeGeneral += VerificarDatos.MensajeError & Chr(13)
                        VerificarDatos.MensajeError = Nothing
                    End If
                End If
            End If
        Next
        Return VerificarDatos
    End Function

    Public Function SentenciaSqlBusqueda() As String
        SentenciaSqlBusqueda = ""
        If Vista = "BuscarRegistros" Then
            SentenciaSqlBusqueda = "spVistaDepartamentoXML"
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
                oVerificarDatos = VerificarDatos("DEP_ID", "DEP_DESCRIPCION", "PAI_ID", "DEP_COD_SUNAT", "USU_ID", "DEP_FEC_GRAB", "DEP_ESTADO")
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


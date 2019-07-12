Imports Ladisac.BE
Partial Public Class DetallePermisoCuentaCorriente
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 2
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "PEU_ID"
    Public CampoPrincipalSecundario = "CCT_ID"
    Public CampoPrincipalValor = PEU_ID
    Public CampoPrincipalSecundarioValor = CCT_ID
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Fin.DetallePermisoCuentaCorriente"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetallePermisoCuentaCorriente"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetallePermisoCuentaCorriente"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetallePermisoCuentaCorriente"
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
        vElementosDatosComboBox = 10
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "PEU_ID"
        vArrayCamposBusqueda(1) = "USU_ID"
        vArrayCamposBusqueda(2) = "USU_DESCRIPCION"
        vArrayCamposBusqueda(3) = "USU_TIPO"
        vArrayCamposBusqueda(4) = "USU_ESTADO"
        vArrayCamposBusqueda(5) = "PEU_ESTADO"
        vArrayCamposBusqueda(6) = "CCT_ID"
        vArrayCamposBusqueda(7) = "CCT_DESCRIPCION"
        vArrayCamposBusqueda(8) = "CCT_ESTADO"
        vArrayCamposBusqueda(9) = "DPC_ESTADO"
        vArrayCamposBusqueda(10) = "PCC_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "PEU_ID"
        vArrayDatosComboBox(0).Longitud = 6
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 68
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "USU_ID"
        vArrayDatosComboBox(1).Longitud = 10
        vArrayDatosComboBox(1).Tipo = "char"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 111
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "USU_DESCRIPCION"
        vArrayDatosComboBox(2).Longitud = 255
        vArrayDatosComboBox(2).Tipo = "varchar"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 2731
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "USU_TIPO"
        vArrayDatosComboBox(3).Longitud = 255
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(1, 1)
        vArrayDatosComboBox(3).Valores(0, 0) = "ADMINISTRADOR"
        vArrayDatosComboBox(3).Valores(0, 1) = "0"
        vArrayDatosComboBox(3).Valores(1, 0) = "USUARIO"
        vArrayDatosComboBox(3).Valores(1, 1) = "1"
        vArrayDatosComboBox(3).Ancho = 118
        vArrayDatosComboBox(3).Flag = True

        vArrayDatosComboBox(4).NombreCampo = "USU_ESTADO"
        vArrayDatosComboBox(4).Longitud = 9
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(1, 1)
        vArrayDatosComboBox(4).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(4).Valores(0, 1) = "0"
        vArrayDatosComboBox(4).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(4).Valores(1, 1) = "1"
        vArrayDatosComboBox(4).Ancho = 85
        vArrayDatosComboBox(4).Flag = True

        vArrayDatosComboBox(5).NombreCampo = "PEU_ESTADO"
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

        vArrayDatosComboBox(6).NombreCampo = "CCT_ID"
        vArrayDatosComboBox(6).Longitud = 3
        vArrayDatosComboBox(6).Tipo = "char"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 36
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "CCT_DESCRIPCION"
        vArrayDatosComboBox(7).Longitud = 45
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 485
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "CCT_ESTADO"
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

        vArrayDatosComboBox(9).NombreCampo = "DPC_ESTADO"
        vArrayDatosComboBox(9).Longitud = 0
        vArrayDatosComboBox(9).Tipo = "bit"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(1, 1)
        vArrayDatosComboBox(9).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(9).Valores(0, 1) = "0"
        vArrayDatosComboBox(9).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(9).Valores(1, 1) = "1"
        vArrayDatosComboBox(9).Ancho = 85
        vArrayDatosComboBox(9).Flag = True

        vArrayDatosComboBox(10).NombreCampo = "PCC_ESTADO"
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

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As String) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "PEU_ID"
                    If Len(PEU_ID.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCT_ID"
                    If Len(CCT_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPC_FEC_GRAB"
                    If DPC_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPC_ESTADO"
                    If DPC_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaDetallePermisoCuentaCorrienteXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetallePermisoCuentaCorrienteXML"
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
                oVerificarDatos = VerificarDatos("PEU_ID", "CCT_ID", "USU_ID", "DPC_FEC_GRAB", "DPC_ESTADO")
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

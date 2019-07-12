Imports Ladisac.BE
Partial Public Class ContactoPersona
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
    Public CampoPrincipal = "PER_ID"
    Public CampoPrincipalSecundario = "COP_ID"
    Public CampoPrincipalValor = PER_ID
    Public CampoPrincipalSecundarioValor = COP_ID
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.ContactoPersona"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "ContactoPersona"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwContactoPersona"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaContactoPersona"
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
        vElementosDatosComboBox = 9
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "PER_ID"
        vArrayCamposBusqueda(1) = "PER_DESCRIPCION"
        vArrayCamposBusqueda(2) = "PER_ESTADO"
        vArrayCamposBusqueda(3) = "COP_ID"
        vArrayCamposBusqueda(4) = "COP_TIPO"
        vArrayCamposBusqueda(5) = "COP_DESCRIPCION"
        vArrayCamposBusqueda(6) = "COP_DIRECCION"
        vArrayCamposBusqueda(7) = "COP_TELEFONO"
        vArrayCamposBusqueda(8) = "COP_EMAIL"
        vArrayCamposBusqueda(9) = "COP_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "PER_ID"
        vArrayDatosComboBox(0).Longitud = 6
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 68
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "PER_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 482
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 5159
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "PER_ESTADO"
        vArrayDatosComboBox(2).Longitud = 0
        vArrayDatosComboBox(2).Tipo = "bit"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(1, 1)
        vArrayDatosComboBox(2).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(2).Valores(0, 1) = "0"
        vArrayDatosComboBox(2).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(2).Valores(1, 1) = "1"
        vArrayDatosComboBox(2).Ancho = 85
        vArrayDatosComboBox(2).Flag = True

        vArrayDatosComboBox(3).NombreCampo = "COP_ID"
        vArrayDatosComboBox(3).Longitud = 2
        vArrayDatosComboBox(3).Tipo = "char"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 26
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "COP_TIPO"
        vArrayDatosComboBox(4).Longitud = 5
        vArrayDatosComboBox(4).Tipo = "smallint"
        vArrayDatosComboBox(4).ParteEntera = 5
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(27, 1)
        vArrayDatosComboBox(4).Valores(0, 0) = "OTROS"
        vArrayDatosComboBox(4).Valores(0, 1) = "0"
        vArrayDatosComboBox(4).Valores(1, 0) = "INGENIERO(A)"
        vArrayDatosComboBox(4).Valores(1, 1) = "1"
        vArrayDatosComboBox(4).Valores(2, 0) = "ARQUITECTO"
        vArrayDatosComboBox(4).Valores(2, 1) = "2"
        vArrayDatosComboBox(4).Valores(3, 0) = "MAESTRO DE OBRA"
        vArrayDatosComboBox(4).Valores(3, 1) = "3"
        vArrayDatosComboBox(4).Valores(4, 0) = "JEFE DE COMPRAS"
        vArrayDatosComboBox(4).Valores(4, 1) = "4"
        vArrayDatosComboBox(4).Valores(5, 0) = "ADMINISTRADOR"
        vArrayDatosComboBox(4).Valores(5, 1) = "5"
        vArrayDatosComboBox(4).Valores(6, 0) = "ASESOR TECNICO"
        vArrayDatosComboBox(4).Valores(6, 1) = "6"
        vArrayDatosComboBox(4).Valores(7, 0) = "ASISTENTE"
        vArrayDatosComboBox(4).Valores(7, 1) = "7"
        vArrayDatosComboBox(4).Valores(8, 0) = "AUTOMACAO INDUSTRIAL"
        vArrayDatosComboBox(4).Valores(8, 1) = "8"
        vArrayDatosComboBox(4).Valores(9, 0) = "COORDINADOR"
        vArrayDatosComboBox(4).Valores(9, 1) = "9"
        vArrayDatosComboBox(4).Valores(10, 0) = "DPTO. VENTAS"
        vArrayDatosComboBox(4).Valores(10, 1) = "10"
        vArrayDatosComboBox(4).Valores(11, 0) = "DIRECTOR"
        vArrayDatosComboBox(4).Valores(11, 1) = "11"
        vArrayDatosComboBox(4).Valores(12, 0) = "DIV. FLUIDOS"
        vArrayDatosComboBox(4).Valores(12, 1) = "12"
        vArrayDatosComboBox(4).Valores(13, 0) = "DPTO. OPERACIONES"
        vArrayDatosComboBox(4).Valores(13, 1) = "13"
        vArrayDatosComboBox(4).Valores(14, 0) = "DUEÑ0(A)"
        vArrayDatosComboBox(4).Valores(14, 1) = "14"
        vArrayDatosComboBox(4).Valores(15, 0) = "EJECUTIVA DE VENTAS"
        vArrayDatosComboBox(4).Valores(15, 1) = "15"
        vArrayDatosComboBox(4).Valores(16, 0) = "INGENIERIA"
        vArrayDatosComboBox(4).Valores(16, 1) = "16"
        vArrayDatosComboBox(4).Valores(17, 0) = "JEFE DE VENTAS"
        vArrayDatosComboBox(4).Valores(17, 1) = "17"
        vArrayDatosComboBox(4).Valores(18, 0) = "JEFE DE TALLER"
        vArrayDatosComboBox(4).Valores(18, 1) = "18"
        vArrayDatosComboBox(4).Valores(19, 0) = "JEFE DE MAESTRANZA"
        vArrayDatosComboBox(4).Valores(19, 1) = "19"
        vArrayDatosComboBox(4).Valores(20, 0) = "REPRESENTANTE"
        vArrayDatosComboBox(4).Valores(20, 1) = "20"
        vArrayDatosComboBox(4).Valores(21, 0) = "VENDEDOR"
        vArrayDatosComboBox(4).Valores(21, 1) = "21"
        vArrayDatosComboBox(4).Valores(22, 0) = "GERENTE ADMINISTRATIVO"
        vArrayDatosComboBox(4).Valores(22, 1) = "22"
        vArrayDatosComboBox(4).Valores(23, 0) = "GERENTE COMERCIAL"
        vArrayDatosComboBox(4).Valores(23, 1) = "23"
        vArrayDatosComboBox(4).Valores(24, 0) = "GERENTE PRODUCCION"
        vArrayDatosComboBox(4).Valores(24, 1) = "24"
        vArrayDatosComboBox(4).Valores(25, 0) = "GERENTE SUCURSAL"
        vArrayDatosComboBox(4).Valores(25, 1) = "25"
        vArrayDatosComboBox(4).Valores(26, 0) = "GERENTE TECNICO"
        vArrayDatosComboBox(4).Valores(26, 1) = "26"
        vArrayDatosComboBox(4).Valores(27, 0) = "GERENTE GENERAL"
        vArrayDatosComboBox(4).Valores(27, 1) = "27"
        vArrayDatosComboBox(4).Ancho = 133
        vArrayDatosComboBox(4).Flag = True

        vArrayDatosComboBox(5).NombreCampo = "COP_DESCRIPCION"
        vArrayDatosComboBox(5).Longitud = 150
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 699
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "COP_DIRECCION"
        vArrayDatosComboBox(6).Longitud = 150
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 699
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "COP_TELEFONO"
        vArrayDatosComboBox(7).Longitud = 150
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 325
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "COP_EMAIL"
        vArrayDatosComboBox(8).Longitud = 150
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 539
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "COP_ESTADO"
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

    End Sub

    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1

        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""

            Select Case vCampos(elemento)
                Case "PER_ID"
                    If Len(PER_ID.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "COP_ID"
                    If Len(COP_ID.Trim) = 2 Or Len(COP_ID.Trim) = 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo2
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "COP_TIPO"
                    If COP_TIPO >= 0 And COP_TIPO <= 4 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "COP_DESCRIPCION"
                    If Len(COP_DESCRIPCION.Trim) > 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "COP_DIRECCION"
                    If IsNothing(COP_DIRECCION) Then
                    Else
                        If COP_DIRECCION.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "COP_TELEFONO"
                    If IsNothing(COP_TELEFONO) Then
                    Else
                        If COP_TELEFONO.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "COP_EMAIL"
                    If IsNothing(COP_EMAIL) Then
                    Else
                        If COP_EMAIL.GetType = GetType(String) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mDato
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
                Case "COP_FEC_GRAB"
                    If COP_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If
                Case "COP_ESTADO"
                    If COP_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaContactoPersonaXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarContactoPersonaXML"
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

    Public Function DevolverTiposCampos2() As String()
        Dim Lista() As String
        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)
            If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) Then
                Dim cont As Integer = vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)
                ReDim Lista(cont)
                For vSubFila As Integer = 0 To cont
                    Lista(vSubFila) = vArrayDatosComboBox(vFila).Valores(vSubFila, 0)
                Next
            End If
        Next
        Return Lista
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
                oVerificarDatos = VerificarDatos("PER_ID", "COP_ID", "COP_TIPO", "COP_DESCRIPCION", "COP_DIRECCION", "COP_TELEFONO", "COP_EMAIL", "USU_ID", "COP_FEC_GRAB", "COP_ESTADO")
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

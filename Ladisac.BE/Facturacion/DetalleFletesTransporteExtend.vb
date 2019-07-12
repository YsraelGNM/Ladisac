Imports Ladisac.BE
Partial Public Class DetalleFletesTransporte
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public vFila As Int16 = 0
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 2
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "FLE_ID"
    Public CampoPrincipalSecundario = "DIS_ID"
    Public CampoPrincipalTercero = "FDE_ID"
    Public CampoPrincipalValor = FLE_ID
    Public CampoPrincipalSecundarioValor = DIS_ID
    Public CampoPrincipalTerceroValor = FDE_ID
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Fac.DetalleFletesTransporte"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DetalleFletesTransporte"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDetalleFletesTransporte"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDetalleFletesTransporte"
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
        vElementosDatosComboBox = 15
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "FLE_ID"
        vArrayCamposBusqueda(1) = "FDE_ID"
        vArrayCamposBusqueda(2) = "FDE_DESCRIPCION"
        vArrayCamposBusqueda(3) = "DIS_ID"
        vArrayCamposBusqueda(4) = "DIS_DESCRIPCION"
        vArrayCamposBusqueda(5) = "DIS_ESTADO"
        vArrayCamposBusqueda(6) = "PRO_ID"
        vArrayCamposBusqueda(7) = "PRO_DESCRIPCION"
        vArrayCamposBusqueda(8) = "PRO_ESTADO"
        vArrayCamposBusqueda(9) = "DEP_ID"
        vArrayCamposBusqueda(10) = "DEP_DESCRIPCION"
        vArrayCamposBusqueda(11) = "DEP_ESTADO"
        vArrayCamposBusqueda(12) = "PAI_ID"
        vArrayCamposBusqueda(13) = "PAI_DESCRIPCION"
        vArrayCamposBusqueda(14) = "PAI_ESTADO"
        vArrayCamposBusqueda(15) = "FDE_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "FLE_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "FDE_ID"
        vArrayDatosComboBox(1).Longitud = 6
        vArrayDatosComboBox(1).Tipo = "char"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 72
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "FDE_DESCRIPCION"
        vArrayDatosComboBox(2).Longitud = 45
        vArrayDatosComboBox(2).Tipo = "varchar"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 485
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "DIS_ID"
        vArrayDatosComboBox(3).Longitud = 3
        vArrayDatosComboBox(3).Tipo = "char"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 36
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "DIS_DESCRIPCION"
        vArrayDatosComboBox(4).Longitud = 45
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 485
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "DIS_ESTADO"
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

        vArrayDatosComboBox(6).NombreCampo = "PRO_ID"
        vArrayDatosComboBox(6).Longitud = 3
        vArrayDatosComboBox(6).Tipo = "char"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 36
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "PRO_DESCRIPCION"
        vArrayDatosComboBox(7).Longitud = 45
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 485
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "PRO_ESTADO"
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

        vArrayDatosComboBox(9).NombreCampo = "DEP_ID"
        vArrayDatosComboBox(9).Longitud = 3
        vArrayDatosComboBox(9).Tipo = "char"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 36
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "DEP_DESCRIPCION"
        vArrayDatosComboBox(10).Longitud = 45
        vArrayDatosComboBox(10).Tipo = "varchar"
        vArrayDatosComboBox(10).ParteEntera = 0
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(0, 0)
        vArrayDatosComboBox(10).Ancho = 485
        vArrayDatosComboBox(10).Flag = False

        vArrayDatosComboBox(11).NombreCampo = "DEP_ESTADO"
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

        vArrayDatosComboBox(12).NombreCampo = "PAI_ID"
        vArrayDatosComboBox(12).Longitud = 3
        vArrayDatosComboBox(12).Tipo = "char"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 36
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "PAI_DESCRIPCION"
        vArrayDatosComboBox(13).Longitud = 45
        vArrayDatosComboBox(13).Tipo = "varchar"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(0, 0)
        vArrayDatosComboBox(13).Ancho = 485
        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "PAI_ESTADO"
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

        vArrayDatosComboBox(15).NombreCampo = "FDE_ESTADO"
        vArrayDatosComboBox(15).Longitud = 0
        vArrayDatosComboBox(15).Tipo = "bit"
        vArrayDatosComboBox(15).ParteEntera = 0
        vArrayDatosComboBox(15).ParteDecimal = 0
        ReDim vArrayDatosComboBox(15).Valores(1, 1)
        vArrayDatosComboBox(15).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(15).Valores(0, 1) = "0"
        vArrayDatosComboBox(15).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(15).Valores(1, 1) = "1"
        vArrayDatosComboBox(15).Ancho = 85
        vArrayDatosComboBox(15).Flag = True
    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "FLE_ID"
                    If Len(FLE_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "FDE_ID"
                    If Len(FDE_ID.Trim) = 6 Or Len(FDE_ID.Trim) = 0 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "FDE_DESCRIPCION"
                    If Len(FDE_DESCRIPCION.Trim) > 0 Then
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

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "FDE_FEC_GRAB"
                    If FDE_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "FDE_ESTADO"
                    If FDE_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaDetalleFletesTransporteXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarDetalleFletesTransporteXML"
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
                oVerificarDatos = VerificarDatos("FLE_ID", "FDE_ID", "FDE_DESCRIPCION", "DIS_ID", "USU_ID", "FDE_FEC_GRAB", "FDE_ESTADO")
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
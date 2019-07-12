Imports Ladisac.BE

Imports System.Runtime.Serialization

Public Class TesoreriaExtorno
    Inherits Ladisac.BE.Maestro.Datos.Orm

    <DataContract()> Partial Public Structure PropertyNames
        Public Shared TDO_ID As String = "TDO_ID"
        Public Shared DTD_ID As String = "DTD_ID"
        Public Shared CCC_ID As String = "CCC_ID"
        Public Shared TEX_SERIE As String = "TEX_SERIE"
        Public Shared TEX_NUMERO As String = "TEX_NUMERO"
        Public Shared TEX_FECHA_EMI As String = "TEX_FECHA_EMI"
        Public Shared USU_ID As String = "USU_ID"
        Public Shared TEX_FEC_GRAB As String = "TEX_FEC_GRAB"
        Public Shared TEX_ESTADO As String = "TEX_ESTADO"
    End Structure

    Public Property TDO_ID As String
    Public Property CCC_ID As String
    Public Property TEX_SERIE As String
    Public Property TEX_NUMERO As String
    Public Property DTD_ID As String
    Public Property TEX_FECHA_EMI As Date
    Public Property USU_ID As String
    Public Property TEX_FEC_GRAB As Date
    Public Property TEX_ESTADO As Boolean

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 5
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "TDO_ID"
    Public CampoPrincipalSecundario = "DTD_ID"
    Public CampoPrincipalTercero = "CCC_ID"
    Public CampoPrincipalCuarto = "TEX_SERIE"
    Public CampoPrincipalQuinto = "TEX_NUMERO"


    Public CampoPrincipalValor = TDO_ID
    Public CampoPrincipalSecundarioValor = DTD_ID
    Public CampoPrincipalTerceroValor = CCC_ID
    Public CampoPrincipalCuartoValor = TEX_SERIE
    Public CampoPrincipalQuintoValor = TEX_NUMERO
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Tes.TesoreriaExtorno"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "TesoreriaExtorno"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwTesoreriaExtorno"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaTesoreriaExtorno"
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

        vArrayCamposBusqueda(0) = "TDO_ID"
        vArrayCamposBusqueda(1) = "TDO_DESCRIPCION"
        vArrayCamposBusqueda(2) = "DTD_ID"
        vArrayCamposBusqueda(3) = "DTD_DESCRIPCION"
        vArrayCamposBusqueda(4) = "CCC_ID"
        vArrayCamposBusqueda(5) = "CCC_TIPO"
        vArrayCamposBusqueda(6) = "CCC_DESCRIPCION"
        vArrayCamposBusqueda(7) = "TEX_SERIE"
        vArrayCamposBusqueda(8) = "TEX_NUMERO"
        vArrayCamposBusqueda(9) = "TEX_FECHA_EMI"
        vArrayCamposBusqueda(10) = "TEX_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "TDO_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "TDO_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 45
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 485
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "DTD_ID"
        vArrayDatosComboBox(2).Longitud = 3
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 36
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "DTD_DESCRIPCION"
        vArrayDatosComboBox(3).Longitud = 45
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 485
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "CCC_ID"
        vArrayDatosComboBox(4).Longitud = 3
        vArrayDatosComboBox(4).Tipo = "char"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 36
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "CCC_TIPO"
        vArrayDatosComboBox(5).Longitud = 29
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(5, 1)
        vArrayDatosComboBox(5).Valores(0, 0) = "CAJA"
        vArrayDatosComboBox(5).Valores(0, 1) = "0"
        vArrayDatosComboBox(5).Valores(1, 0) = "CUENTA DE BANCO"
        vArrayDatosComboBox(5).Valores(1, 1) = "1"
        vArrayDatosComboBox(5).Valores(2, 0) = "LIQUIDACION DE DOCUMENTOS"
        vArrayDatosComboBox(5).Valores(2, 1) = "2"
        vArrayDatosComboBox(5).Valores(3, 0) = "CUENTA DE BANCO DE DETRACCION"
        vArrayDatosComboBox(5).Valores(3, 1) = "3"
        vArrayDatosComboBox(5).Valores(4, 0) = "RETENCIONES/PERCEPCIONES"
        vArrayDatosComboBox(5).Valores(4, 1) = "4"
        vArrayDatosComboBox(5).Valores(5, 0) = "RENDICION DE CUENTAS"
        vArrayDatosComboBox(5).Valores(5, 1) = "5"
        vArrayDatosComboBox(5).Ancho = 228
        vArrayDatosComboBox(5).Flag = True

        vArrayDatosComboBox(6).NombreCampo = "CCC_DESCRIPCION"
        vArrayDatosComboBox(6).Longitud = 189
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 2025
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "TEX_SERIE"
        vArrayDatosComboBox(7).Longitud = 3
        vArrayDatosComboBox(7).Tipo = "char"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 36
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "TEX_NUMERO"
        vArrayDatosComboBox(8).Longitud = 10
        vArrayDatosComboBox(8).Tipo = "char"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 111
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "TEX_FECHA_EMI"
        vArrayDatosComboBox(9).Longitud = 0
        vArrayDatosComboBox(9).Tipo = "smalldatetime"
        vArrayDatosComboBox(9).ParteEntera = 0
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(0, 0)
        vArrayDatosComboBox(9).Ancho = 15
        vArrayDatosComboBox(9).Flag = False

        vArrayDatosComboBox(10).NombreCampo = "TEX_ESTADO"
        vArrayDatosComboBox(10).Longitud = 0
        vArrayDatosComboBox(10).Tipo = "bit"
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
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "TDO_ID"
                    If Len(TDO_ID.Trim) = 3 Then
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

                Case "CCC_ID"
                    If Len(CCC_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TEX_SERIE"
                    If Len(TEX_SERIE.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TEX_NUMERO"
                    If Len(TEX_NUMERO.Trim) = 10 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo10
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TEX_FECHA_EMI"
                    If TEX_FECHA_EMI.GetType = GetType(Date) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TEX_FEC_GRAB"
                    If TEX_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TEX_ESTADO"
                    If TEX_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaTesoreriaExtornoXML"
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
                oVerificarDatos = VerificarDatos("TDO_ID", "DTD_ID", "CCC_ID", "TEX_SERIE", "TEX_NUMERO", "TEX_FECHA_EMI", "USU_ID", "TEX_FEC_GRAB", "TEX_ESTADO")
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

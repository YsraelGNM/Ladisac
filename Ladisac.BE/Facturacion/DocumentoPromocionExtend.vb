﻿Imports Ladisac.BE
Partial Public Class DocumentosPromocion
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
    Public CampoPrincipal = "DPR_NUMERO"
    Public CampoPrincipalSecundario = "DPR_TIPO_PROMOCION"
    Public CampoPrincipalValor = DPR_NUMERO
    Public CampoPrincipalSecundarioValor = DPR_TIPO_PROMOCION
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Fac.DocumentosPromocion"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "DocumentosPromocion"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwDocumentosPromocion"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaDocumentosPromocion"
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
        vElementosDatosComboBox = 6
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "DPR_NUMERO"
        vArrayCamposBusqueda(1) = "dpr_tipo_promocion"
        vArrayCamposBusqueda(2) = "dpr_fecha"
        vArrayCamposBusqueda(3) = "PER_ID_PRO"
        vArrayCamposBusqueda(4) = "per_descripcion_pro"
        vArrayCamposBusqueda(5) = "per_estado_pro"
        vArrayCamposBusqueda(6) = "dpr_estado"

        vArrayDatosComboBox(0).NombreCampo = "DPR_NUMERO"
        vArrayDatosComboBox(0).Longitud = 10
        vArrayDatosComboBox(0).Tipo = "varchar"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 111
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "dpr_tipo_promocion"
        vArrayDatosComboBox(1).Longitud = 19
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(1, 1)
        vArrayDatosComboBox(1).Valores(0, 0) = "MAESTRO CONSTRUCTOR"
        vArrayDatosComboBox(1).Valores(0, 1) = "0"
        vArrayDatosComboBox(1).Valores(1, 0) = "PROMOCION ECO DIAMANTE"
        vArrayDatosComboBox(1).Valores(1, 1) = "1"
        vArrayDatosComboBox(1).Ancho = 196
        vArrayDatosComboBox(1).Flag = True

        vArrayDatosComboBox(2).NombreCampo = "dpr_fecha"
        vArrayDatosComboBox(2).Longitud = 10
        vArrayDatosComboBox(2).Tipo = "smalldatetime"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 15
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PER_ID_PRO"
        vArrayDatosComboBox(3).Longitud = 6
        vArrayDatosComboBox(3).Tipo = "char"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 68
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "per_descripcion_pro"
        vArrayDatosComboBox(4).Longitud = 77
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 828
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "per_estado_pro"
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

        vArrayDatosComboBox(6).NombreCampo = "dpr_estado"
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

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "DPR_NUMERO"
                    If Len(DPR_NUMERO.Trim) = 10 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDescripcion
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_TIPO_PROMOCION"
                    If DPR_TIPO_PROMOCION >= 0 And DPR_TIPO_PROMOCION <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_FECHA"
                    If IsNothing(DPR_FECHA) Then
                    Else
                        If DPR_FECHA.GetType = GetType(Date) Then
                        Else
                            VerificarDatos.NumeroError = 0
                            VerificarDatos.MensajeError = mFecha
                            VerificarDatos.Objeto = vCampos(elemento)
                        End If
                    End If
                Case "PER_ID_PRO"
                    If Len(PER_ID_PRO.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_FEC_GRAB"
                    If DPR_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DPR_ESTADO"
                    If DPR_ESTADO >= 0 And DPR_ESTADO <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
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
            SentenciaSqlBusqueda = "spVistaDocumentosPromocionXML"
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
                oVerificarDatos = VerificarDatos("DPR_NUMERO", "DPR_TIPO_PROMOCION", "DPR_FECHA", "PER_ID_PRO", "USU_ID", "DPR_FEC_GRAB", "DPR_ESTADO")
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


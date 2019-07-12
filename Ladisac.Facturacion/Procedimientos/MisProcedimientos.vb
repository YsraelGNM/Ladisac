'Imports Microsoft.Practices.Prism.Events
'Imports Microsoft.Practices.Unity
'Imports Microsoft.Practices.Unity
Imports System.IO
'Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing
'Imports Ladisac.Foundation
'Imports Ladisac.BL

Namespace Ladisac
#Region "MisProcedimientos"
    Public Class MisProcedimientos
        Public Function VerificarLongitud(ByVal vTexto As String, ByVal vLongitud As Int16, Optional ByVal vCaracter As String = "0") As String
            VerificarLongitud = ""
            If Len(Trim(vTexto)) < vLongitud And Len(Trim(vTexto)) > 0 Then
                VerificarLongitud = Strings.StrDup(vLongitud - Len(Trim(vTexto)), vCaracter) & Trim(vTexto)
            Else
                VerificarLongitud = vTexto
            End If
            Return VerificarLongitud
        End Function

        '<Dependency()>
        'Public Property ContainerService As IUnityContainer

        '<Dependency()>
        'Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        '<Dependency()> _
        'Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        '***
        Public Structure DatosComboBox
            Public NombreCampo As String
            Public Valores(,) As String
            Public Ancho As Int16
            Public Longitud As Int16
            Public ParteEntera As Int16
            Public ParteDecimal As Int16
            Public Flag As Boolean
            Public Tipo As String
        End Structure

        '***
        Public Sub AdicionarElementoCombosEdicion(ByRef vCombo As System.Windows.Forms.ComboBox, ByVal vArray(,) As String, ByVal vOrdenBusqueda As Integer)
            vCombo.Items.Clear()
            For elemento As Integer = 0 To vArray.GetUpperBound(0) 'vArray.Length - 1
                vCombo.Items.Add(vArray(elemento, 0).ToString)
            Next elemento
            vCombo.SelectedIndex = vOrdenBusqueda
        End Sub

        '***
        Public Sub AdicionarElementoCombosEdicion(ByRef vCombo As System.Windows.Forms.ComboBox, ByVal vArray() As String, ByVal vOrdenBusqueda As Integer)
            vCombo.Items.Clear()
            For elemento As Integer = 0 To vArray.Count - 1
                vCombo.Items.Add(vArray(elemento).ToString)
            Next elemento
            vCombo.SelectedIndex = vOrdenBusqueda
        End Sub

        '***
        Public Function LongitudCampo(ByVal vArray() As String, ByRef eObjeto As Object) As Integer
            LongitudCampo = 10
            Dim vMaxLongitud As Integer = 0
            Dim vGrafico As System.Drawing.Graphics = eObjeto.CreateGraphics()
            Dim offset As Integer = Convert.ToInt32(Math.Ceiling(vGrafico.MeasureString("XX", eObjeto.Font).Width))

            Dim intAux As Integer
            Dim vFilasDataSet As Integer = vArray.Count

            For i = 0 To (vFilasDataSet - 1)
                intAux = Convert.ToInt32(Math.Ceiling(vGrafico.MeasureString(vArray(i).ToString(), eObjeto.Font).Width))
                If (intAux > vMaxLongitud) Then
                    vMaxLongitud = intAux
                End If
            Next
            Return vMaxLongitud + offset
        End Function

        '***
        Public Function LongitudCampo(ByRef eObjeto As Object, ByVal Cadena As String) As Integer
            Dim vGrafico As System.Drawing.Graphics = eObjeto.CreateGraphics()
            Dim intNomColumna As Integer
            intNomColumna = Convert.ToInt32(Math.Ceiling(vGrafico.MeasureString(Cadena, eObjeto.Font).Width))
            Return intNomColumna
        End Function

        '***
        Public Structure ConfigurarDataGrid
            Public Metodo As String
            Public Orm As Object
            Public Array() As Integer
            Public Columna As String
        End Structure

        '***
        Public Sub ColocarDatosGrid(ByRef vObjeto As Object, ByVal vGrid As System.Windows.Forms.DataGridView, ByVal vCelda As Object)
            If vObjeto.GetType = GetType(Object) And vObjeto.GetType = GetType(String) Then
                vObjeto = vGrid.SelectedRows(0).Cells(vCelda).Value.ToString()
                Exit Sub
            End If
            If vObjeto.GetType = GetType(System.String) Then
                vObjeto = vGrid.SelectedRows(0).Cells(vCelda).Value.ToString()
            End If
            If vObjeto.GetType = GetType(System.Windows.Forms.Label) Or _
                vObjeto.GetType = GetType(System.Windows.Forms.TextBox) Or _
                vObjeto.GetType = GetType(System.Windows.Forms.ComboBox) Then
                vObjeto.Text = vGrid.SelectedRows(0).Cells(vCelda).Value.ToString()
                Exit Sub
            End If
            If vObjeto.GetType = GetType(System.Windows.Forms.DateTimePicker) Then
                If vGrid.SelectedRows(0).Cells(vCelda).Value Is Nothing Or
                   vGrid.SelectedRows(0).Cells(vCelda).Value.ToString = "" Then
                    'vObjeto.value = Nothing
                Else
                    vObjeto.value = vGrid.SelectedRows(0).Cells(vCelda).Value.ToString()
                End If
                Exit Sub
            End If
            If vObjeto.GetType = GetType(System.Windows.Forms.PictureBox) Then
                If vGrid.SelectedRows(0).Cells(vCelda).Value IsNot DBNull.Value Then
                    Dim bytBLOBData() As Byte = vGrid.SelectedRows(0).Cells(vCelda).Value
                    Dim stmBLOBData As New IO.MemoryStream(bytBLOBData)
                    vObjeto.Image = System.Drawing.Image.FromStream(stmBLOBData)
                    Exit Sub
                Else
                    vObjeto.Image = Nothing
                    Exit Sub
                End If
            End If
        End Sub

        'Para Despacho
        Public Sub ColocarDatosGrid_Despacho(ByRef vObjeto As Object, ByVal vGrid As System.Windows.Forms.DataGridView, ByVal vCelda As Object)
            If vObjeto.GetType = GetType(Object) And vObjeto.GetType = GetType(String) Then
                vObjeto = vGrid.SelectedRows(0).Cells(vCelda).Value.ToString()
                Exit Sub
            End If
            If vObjeto.GetType = GetType(System.String) Then
                vObjeto = vGrid.SelectedRows(0).Cells(vCelda).Value.ToString()
            End If
            If vObjeto.GetType = GetType(System.Windows.Forms.Label) Or _
                vObjeto.GetType = GetType(System.Windows.Forms.TextBox) Or _
                vObjeto.GetType = GetType(System.Windows.Forms.ComboBox) Then
                vObjeto.Text = vGrid.SelectedRows(0).Cells(vCelda).Value.ToString()
                Exit Sub
            End If
            If vObjeto.GetType = GetType(System.Windows.Forms.DateTimePicker) Then
                If vGrid.SelectedRows(0).Cells(vCelda).Value Is Nothing Or
                   vGrid.SelectedRows(0).Cells(vCelda).Value.ToString = "" Then
                    vObjeto.value = "01/01/1900"
                Else
                    vObjeto.value = vGrid.SelectedRows(0).Cells(vCelda).Value.ToString()
                End If
                Exit Sub
            End If
            If vObjeto.GetType = GetType(System.Windows.Forms.PictureBox) Then
                If vGrid.SelectedRows(0).Cells(vCelda).Value IsNot DBNull.Value Then
                    Dim bytBLOBData() As Byte = vGrid.SelectedRows(0).Cells(vCelda).Value
                    Dim stmBLOBData As New IO.MemoryStream(bytBLOBData)
                    vObjeto.Image = System.Drawing.Image.FromStream(stmBLOBData)
                    Exit Sub
                Else
                    vObjeto.Image = Nothing
                    Exit Sub
                End If
            End If
        End Sub
        '''''''''''''''''
        '***
        Public Function DevolverDatosGrid(ByVal vGrid As System.Windows.Forms.DataGridView, ByVal vCelda As Object)
            Return vGrid.SelectedRows(0).Cells(vCelda).Value.ToString()
        End Function

        '***
        Public Sub PosicionGrid(ByVal Metodo As String, ByRef vGrid As System.Windows.Forms.DataGridView, ByVal NameFormulario As String)
            Try
                If vGrid.Rows.Count <= 1 Then Return

                Dim vPosInicial As Integer = 0
                Dim vPosFinal As Integer = vGrid.Rows.Count - 1
                Dim vPosActual As Integer = vGrid.CurrentRow().Index
                Dim vColCelda As Integer = vGrid.CurrentCell().ColumnIndex
                If Not vGrid.Rows(0).Cells(vColCelda).Visible Then
                    For vCol = 0 To vGrid.RowCount
                        If vGrid.Rows(0).Cells(vCol).Visible Then
                            vColCelda = vCol
                            Exit For
                        End If
                    Next
                End If
                Select Case Metodo
                    Case "PrimerRegistro"
                        vGrid.CurrentCell = vGrid.Rows(0).Cells(vColCelda)
                    Case "RegistroAnterior"
                        If vPosActual <> 0 Then vGrid.CurrentCell = vGrid.Rows(vPosActual - 1).Cells(vColCelda)
                    Case "RegistroSiguiente"
                        If vPosActual <> vPosFinal Then vGrid.CurrentCell = vGrid.Rows(vPosActual + 1).Cells(vColCelda)
                    Case "UltimoRegistro"
                        vGrid.CurrentCell = vGrid.Rows(vPosFinal).Cells(vColCelda)
                End Select
            Catch ex As Exception
                If Err.Number = 91 Then
                    MsgBox("No se encuentra ubicado en nínguna grilla de edición", MsgBoxStyle.Exclamation, NameFormulario)
                End If
            End Try
        End Sub

        '***
        Public Sub AdicionarNumeroColumnaArray(ByRef vArray() As Integer, ByVal vArrayCampos() As String)
            If vArrayCampos.Count > 0 Then
                ReDim vArray(vArrayCampos.Count - 1)
                For elemento As Integer = 0 To vArrayCampos.Count - 1
                    vArray(elemento) = elemento
                Next elemento
            End If
        End Sub

        '***
        Public Function FormatoNumero(ByVal vEntero As Integer, ByVal vDecimal As Integer, ByVal vDato As String) As Decimal
            Try
                If IsNumeric(vDato) Then
                    Dim vNumero As Decimal = vDato
                    Dim vEnteroNumero As String = Fix(vNumero)
                    Dim vDecimalNumero As String = (vNumero - Fix(vNumero))

                    If Len(vEnteroNumero.ToString) > vEntero Then
                        FormatoNumero = -1 ' Desborde de la parte entera
                        Exit Function
                    Else
                        FormatoNumero = Math.Round(vNumero, vDecimal)
                    End If

                    vEnteroNumero = Fix(FormatoNumero)
                    If Len(vEnteroNumero.ToString) > vEntero Then
                        FormatoNumero = -2 ' Desbordo de la parte entera despues de redondearlo
                        Exit Function
                    End If

                    If Len(FormatoNumero.ToString) > (vEntero + vDecimal + 1) Then
                        FormatoNumero = 0 ' Desborde de la parte entera y decimal
                    End If
                Else
                    FormatoNumero = -3 ' Dato no númerico
                End If
            Catch ex As Exception
                FormatoNumero = -4 ' Error no determinado
            End Try
        End Function

        '***
        Public Function FormatoFechaGenerico(ByVal vFecha As Date) As String
            Dim vDia As String = Microsoft.VisualBasic.DateAndTime.Day(vFecha)
            Dim vMes As String = Month(vFecha)
            Dim vAnio As String = Year(vFecha)
            If Len(vDia) < 2 Then vDia = "0" & vDia
            If Len(vMes) < 2 Then vMes = "0" & vMes
            FormatoFechaGenerico = vAnio & vMes & vDia
        End Function

        '***
        Public Sub Ubicacion(ByVal vAncho As Object, ByRef vObjeto As Object)
            Dim vAnchoActual As Int16 = vObjeto.Size.Width
            Dim vAltoAntes As Int16 = vObjeto.Size.Height
            vObjeto.Size = New System.Drawing.Size(vAnchoActual - (vAncho.AnchoDespues - vAncho.AnchoAntes), vAltoAntes)
            Dim vPosActualX As Int16 = vObjeto.Location.X
            Dim vPosActualY As Int16 = vObjeto.Location.Y
            vObjeto.Location = New System.Drawing.Point(vPosActualX + (vAncho.AnchoDespues - vAncho.AnchoAntes), vPosActualY)
        End Sub

        '***
        Public Sub EstablecerValorCheck(ByVal vCadena As String, ByRef vCheck As CheckBox)
            Select Case vCadena
                Case "1"
                    vCheck.Checked = True
                    vCheck.CheckState = System.Windows.Forms.CheckState.Checked
                Case "0"
                    vCheck.Checked = False
                    vCheck.CheckState = System.Windows.Forms.CheckState.Unchecked
                Case Else
                    vCheck.Checked = Nothing
                    vCheck.CheckState = System.Windows.Forms.CheckState.Indeterminate
            End Select
            'vCheck.InicializarTexto()
        End Sub


        Public Function EstablecerCodigoMoneda(ByVal MonedaSistema As String, _
                                               ByVal CodigoMonedaSaldo As String, _
                                               ByVal CodigoMonedaFormulario As String) As String
            EstablecerCodigoMoneda = ""
            If MonedaSistema = CodigoMonedaSaldo Then
                EstablecerCodigoMoneda = CodigoMonedaFormulario
            Else
                EstablecerCodigoMoneda = CodigoMonedaSaldo
            End If
            Return EstablecerCodigoMoneda
        End Function

        Public Function MontoTipoCambioMoneda(ByVal sr As StringReader) As Decimal
            MontoTipoCambioMoneda = 0
            Dim vcontrol As Int16
            Dim ds As New DataSet
            vcontrol = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                MontoTipoCambioMoneda = ds.Tables(0).Rows(0).Item("TCA_VENTA")
            Else
                MontoTipoCambioMoneda = 0
            End If
            Return MontoTipoCambioMoneda
        End Function

        Public Function SolicitarMontoTipoCambioMoneda(ByVal vMonedaSistema As String, _
                                                       ByVal vCodigoMonedaProcesar As String, _
                                                       ByVal vFecha As Date, _
                                                       ByVal IBCMaestro As Object)
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spCambioDiaXML,
                                                                vMonedaSistema,
                                                                vCodigoMonedaProcesar, _
                                                                FormatoFechaGenerico(vFecha)
                                                               )
                                      )
            Return MontoTipoCambioMoneda(sr)
        End Function
        Public Function MontoSegunTipoCambio(ByVal vMontoTipoCambioMoneda As Decimal, _
                                             ByVal vMON_ID As String, _
                                             ByVal vMonedaSistema As String, _
                                             ByVal vSaldo As Decimal)
            'If vMontoTipoCambioMoneda <> 0 Then
            'MsgBox(CDbl(dgvSaldos.Item("Saldo", vfila).Value) & " - " & vMontoTipoCambioMoneda & " - " & (CDbl(dgvSaldos.Item("Saldo", vfila).Value) * 1) / vMontoTipoCambioMoneda)
            'If txtMON_ID.Text.Trim = BCVariablesNames.MonedaSistema Then
            If vMON_ID = vMonedaSistema Then
                'vTotalDeuda += (vSaldo * vMontoTipoCambioMoneda) / 1
                MontoSegunTipoCambio = (vSaldo * vMontoTipoCambioMoneda) / 1
            Else
                'vTotalDeuda += (vSaldo * 1) / vMontoTipoCambioMoneda
                MontoSegunTipoCambio = (vSaldo * 1) / vMontoTipoCambioMoneda
            End If
            'ErrorProvider1.SetError(txtDeuda, Nothing)
            'Else
            'MontoSegunTipoCambio = 999999999.99
            'ErrorProvider1.SetError(txtMON_ID, "No existe tipo de cambio para el saldo de un documento")
            'End If
            Return MontoSegunTipoCambio
        End Function


        Public Function NumeroATexto(ByVal Numero As String, ByVal Moneda As String) As String
            Dim y, num As Integer
            Dim txtnum, entero, dec, flag As String
            txtnum = ""
            entero = ""
            dec = ""
            flag = "N"
            For y = 1 To Len(Numero)
                If Mid(Numero, y, 1) = "." Then
                    flag = "S"
                Else
                    If flag = "N" Then
                        If Mid(Numero, y, 1) = "," Or _
                           Mid(Numero, y, 1) = "'" Then
                        Else
                            entero = entero + Mid(Numero, y, 1)
                        End If
                    Else
                        dec = dec + Mid(Numero, y, 1)
                    End If
                End If
            Next y

            If Len(entero) = 0 Then
                txtnum = txtnum & "CERO "
            End If

            If Len(dec) = 0 Then
                dec = "00"
            ElseIf Len(dec) = 1 Then
                dec = dec & "0"
            End If
            flag = "N"
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**centenas
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    txtnum = txtnum & "CIEN "
                                Else
                                    txtnum = txtnum & "CIENTO "
                                End If
                            Case "2"
                                txtnum = txtnum & "DOSCIENTOS "
                            Case "3"
                                txtnum = txtnum & "TRESCIENTOS "
                            Case "4"
                                txtnum = txtnum & "CUATROCIENTOS "
                            Case "5"
                                txtnum = txtnum & "QUINIENTOS "
                            Case "6"
                                txtnum = txtnum & "SEISCIENTOS "
                            Case "7"
                                txtnum = txtnum & "SETECIENTOS "
                            Case "8"
                                txtnum = txtnum & "OCHOCIENTOS "
                            Case "9"
                                txtnum = txtnum & "NOVECIENTOS "
                        End Select
                    Case 2, 5, 8
                        '**decenas
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    txtnum = txtnum & "DIEZ "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    txtnum = txtnum & "ONCE "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    txtnum = txtnum & "DOCE "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    txtnum = txtnum & "TRECE "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    txtnum = txtnum & "CATORCE "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    txtnum = txtnum & "QUINCE "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    txtnum = txtnum & "DIECI"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    txtnum = txtnum & "VEINTE "
                                    flag = "S"
                                Else
                                    txtnum = txtnum & "VEINTI"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    txtnum = txtnum & "TREINTA "
                                    flag = "S"
                                Else
                                    txtnum = txtnum & "TREINTA Y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    txtnum = txtnum & "CUARENTA "
                                    flag = "S"
                                Else
                                    txtnum = txtnum & "CUARENTA Y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    txtnum = txtnum & "CINCUENTA "
                                    flag = "S"
                                Else
                                    txtnum = txtnum & "CINCUENTA Y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    txtnum = txtnum & "SESENTA "
                                    flag = "S"
                                Else
                                    txtnum = txtnum & "SESENTA Y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    txtnum = txtnum & "SETENTA "
                                    flag = "S"
                                Else
                                    txtnum = txtnum & "SETENTA Y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    txtnum = txtnum & "OCHENTA "
                                    flag = "S"
                                Else
                                    txtnum = txtnum & "OCHENTA Y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    txtnum = txtnum & "NOVENTA "
                                    flag = "S"
                                Else
                                    txtnum = txtnum & "NOVENTA Y "
                                    flag = "N"
                                End If
                            Case Else
                                flag = "N"
                        End Select
                    Case 1, 4, 7
                        '*unidades
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        txtnum = txtnum & "UNO "
                                    Else
                                        txtnum = txtnum & "UN "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then txtnum = txtnum & "DOS "
                            Case "3"
                                If flag = "N" Then txtnum = txtnum & "TRES "
                            Case "4"
                                If flag = "N" Then txtnum = txtnum & "CUATRO "
                            Case "5"
                                If flag = "N" Then txtnum = txtnum & "CINCO "
                            Case "6"
                                If flag = "N" Then txtnum = txtnum & "SEIS "
                            Case "7"
                                If flag = "N" Then txtnum = txtnum & "SIETE "
                            Case "8"
                                If flag = "N" Then txtnum = txtnum & "OCHO "
                            Case "9"
                                If flag = "N" Then txtnum = txtnum & "NUEVE "
                        End Select
                End Select
                '*millares
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                      (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                       Len(entero) <= 6) Then txtnum = txtnum & "MIL "
                End If
                '**millones
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        txtnum = txtnum & "MILLON "
                    Else
                        txtnum = txtnum & "MILLONES "
                    End If
                End If
            Next y
            If Trim(txtnum) = "UN MIL" Then txtnum = "MIL "
            NumeroATexto = txtnum & "CON " & dec & "/100 " & Moneda
        End Function

        Public Sub RemoverTabs(ByRef vTabControl As TabControl, ByRef vTapPage As TabPage)
            vTabControl.TabPages.Remove(vTapPage)
        End Sub

    End Class

    Public Class ClaseDibujar
        Private pAnchoAntes As Int16
        Private pAnchoDespues As Int16
        Private AnchoActual As Int16
        Private AltoActual As Int16

        Public Property AnchoAntes As SizeType
            Set(ByVal value As SizeType)
                pAnchoAntes = value
            End Set
            Get
                Return pAnchoAntes
            End Get
        End Property

        Public Property AnchoDespues As SizeType
            Set(ByVal value As SizeType)
                pAnchoDespues = value
            End Set
            Get
                Return pAnchoDespues
            End Get
        End Property
    End Class
#End Region
End Namespace

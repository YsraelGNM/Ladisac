Imports Microsoft.Practices.Unity
Imports System.Configuration
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.EntityClient
Imports System.Net
Imports System.Text

Public Class frmLogin
    <Dependency()> _
    Public Property EventManager As Microsoft.Practices.Prism.Events.IEventAggregator
    <Dependency()>
    Public Property SessionService As Ladisac.Foundation.Services.ISessionService
    <Dependency()>
    Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames
    <Dependency()> _
    Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda
    <Dependency()> _
    Public Property IBCMaestro As Ladisac.BL.IBCMaestro
    <Dependency()>
    Public Property BCPermisoUsuario As Ladisac.BL.BCPermisoUsuario
    <Dependency()>
    Public Property BCParametro As Ladisac.BL.BCParametro

    Private vVersion As String = "1.1.30.50"
    Private vFechaVersion As String = " del " & Now.ToString

    Private vContador As Integer = 0


    Private Sub btnAcceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim MiAppConfig As Configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)
        Dim MiSeccion As ConnectionStringsSection = DirectCast(MiAppConfig.GetSection("connectionStrings"), ConnectionStringsSection)
        Dim vcontrol As Int16 = 0
        Dim ds As New DataSet

        If cboEmpresa.Text = "Diamante en la principal." Then
            ' informacion de la empresa que usa el sistemal
            Me.SessionService.RUCEmpresa = "20120877055"
            Me.SessionService.NombreEmpresa = "Ladrillera El Diamante SAC"
            Me.SessionService.DireccionEmpresa = "Car. Variante de Uchumayo Nro. 4 Arequipa - Arequipa - Cerro Colorado"
            Me.SessionService.ConectadoDesde = "La principal, Versión: " & vVersion & vFechaVersion
            Me.SessionService.RutaDocumentoImpresion = "\Ladrillera"
        ElseIf cboEmpresa.Text = "Diamante en la agencia." Then
            ' informacion de la empresa que usa el sistema
            Me.SessionService.RUCEmpresa = "20120877055"
            Me.SessionService.NombreEmpresa = "Ladrillera El Diamante SAC"
            Me.SessionService.DireccionEmpresa = "Car. Variante de Uchumayo Nro. 4 Arequipa - Arequipa - Cerro Colorado"
            Me.SessionService.ConectadoDesde = "La agencia, Versión: " & vVersion & vFechaVersion
            Me.SessionService.RutaDocumentoImpresion = "\Ladrillera"
        ElseIf cboEmpresa.Text = "Comercial en la principal." Then
            ' informacion de la empresa que usa el sistema
            Me.SessionService.RUCEmpresa = "20558363291"
            Me.SessionService.NombreEmpresa = "Comercializadora Diamante G.E. SAC"
            Me.SessionService.DireccionEmpresa = "Car. Variante de Uchumayo km. 4 (costado grifo Leon Del Sur) Arequipa - Arequipa - Cerro Colorado"
            Me.SessionService.ConectadoDesde = "La principal, Versión: " & vVersion & vFechaVersion
            Me.SessionService.RutaDocumentoImpresion = "\Comercial"
        ElseIf cboEmpresa.Text = "Comercial en la agencia." Then
            ' informacion de la empresa que usa el sistema
            Me.SessionService.RUCEmpresa = "20558363291"
            Me.SessionService.NombreEmpresa = "Comercializadora Diamante G.E. SAC"
            Me.SessionService.DireccionEmpresa = "Car. Variante de Uchumayo km. 4 (costado grifo Leon Del Sur) Arequipa - Arequipa - Cerro Colorado"
            Me.SessionService.ConectadoDesde = "La agencia, Versión: " & vVersion & vFechaVersion
            Me.SessionService.RutaDocumentoImpresion = "\Comercial"
        ElseIf cboEmpresa.Text = "Diamante copia." Then
            ' informacion de la empresa que usa el sistemal
            Me.SessionService.RUCEmpresa = "20120877055"
            Me.SessionService.NombreEmpresa = "Ladrillera El Diamante S.A.C."
            Me.SessionService.DireccionEmpresa = "Car. Variante de Uchumayo Nro. 4 Arequipa - Arequipa - Cerro Colorado"
            Me.SessionService.ConectadoDesde = "La principal, Versión: " & vVersion & vFechaVersion
            Me.SessionService.RutaDocumentoImpresion = "\Ladrillera"
        ElseIf cboEmpresa.Text = "Comercial copia." Then
            ' informacion de la empresa que usa el sistema
            Me.SessionService.RUCEmpresa = "20558363291"
            Me.SessionService.NombreEmpresa = "Comercializadora Diamante G.E. S.A.C."
            Me.SessionService.DireccionEmpresa = "Car. Variante de Uchumayo km. 4 (costado grifo Leon Del Sur) Arequipa - Arequipa - Cerro Colorado"
            Me.SessionService.ConectadoDesde = "La principal, Versión: " & vVersion & vFechaVersion
            Me.SessionService.RutaDocumentoImpresion = "\Comercial"
        ElseIf cboEmpresa.Text = "Inka." Then
            ' informacion de la empresa que usa el sistemal
            Me.SessionService.RUCEmpresa = "20454884206"
            Me.SessionService.NombreEmpresa = "Ladrillera Inka S.A.C."
            Me.SessionService.DireccionEmpresa = "Calle Francisco Mostajo Nro. 2012 Yanahuara - Arequipa"
            Me.SessionService.ConectadoDesde = "La principal, Versión: " & vVersion & vFechaVersion
            Me.SessionService.RutaDocumentoImpresion = "\Ladrillera"
        End If

        If Trim(txtUsuario.Text) = "" Or Trim(txtContraseña.Text) = "" Then
            Me.SessionService.UserName = ""
            Me.SessionService.UserTipo = ""
            Me.SessionService.UserId = ""
            vContador += 1
            MsgBox("¡Ingrese valores válidos para usuario y contraseña!", MsgBoxStyle.Critical, Me.Text)
            If vContador = 5 Then
                Ladisac.Foundation.MainWindow.ActiveForm.Close()
            End If
            Return
        End If
        'Me.Cursor = Cursors.WaitCursor
        Try
            If cboEmpresa.Text = "Diamante en la principal." Or cboEmpresa.Text = "Comercial en la principal." Then
                If Not vVersion = BCParametro.ParametroGetById("Ver").PAR_VALOR1 Then
                    MessageBox.Show("Tiene una version anterior a la actual. Actualice su Sistema.")
                    Exit Sub
                End If
            ElseIf cboEmpresa.Text = "Diamante copia." Or cboEmpresa.Text = "Comercial copia." Then
            Else
                If Not vVersion = BCParametro.ParametroGetById("Ver").PAR_VALOR1 Then
                    MessageBox.Show("Tiene una version anterior a la actual" & Chr(13) & "Comuniquese con el administrador de sistemas para que lo actualice.")
                    Exit Sub
                End If
            End If
            Dim sr As New StringReader(IBCMaestro.EjecutarVista("dbo.spVistaUsuariosConPermisoXML", txtUsuario.Text))
            vcontrol = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
            End If
        Catch ex As Exception
            MsgBox("¡Error al loguearse a la Base de Datos!", MsgBoxStyle.Critical, Me.Text)
            vContador += 1
            If vContador = 5 Then
                Ladisac.Foundation.MainWindow.ActiveForm.Close()
            End If
            Me.Cursor = Cursors.Default
            Return
        End Try
        Me.Cursor = Cursors.Default

        If vcontrol <> -1 Then
            'If Me.SessionService.Usuario IsNot Nothing Then
            If Not ds.Tables(0).Rows(0).Item("USU_CONTRASENA") = txtContraseña.Text Then
                MsgBox("El usuario o la contraseña son incorrectos.", MsgBoxStyle.Critical, Me.Text)
                Me.SessionService.UserName = ""
                Me.SessionService.UserTipo = ""
                Me.SessionService.UserId = ""
                vContador += 1
                If vContador = 5 Then
                    Ladisac.Foundation.MainWindow.ActiveForm.Close()
                End If
            Else
                Me.SessionService.UserName = ds.Tables(0).Rows(0).Item("USU_DESCRIPCION").ToString.Trim
                Me.SessionService.UserTipo = ds.Tables(0).Rows(0).Item("USU_TIPO").ToString.Trim
                Me.SessionService.UserId = ds.Tables(0).Rows(0).Item("USU_ID").ToString.Trim
                Me.SessionService.PermisoUsuario = ds.Tables(0).Rows(0).Item("PEU_ID").ToString.Trim

                If IBCBusqueda.userMensaje(SessionService.UserId) Then
                    SessionService.userMensaje = True
                Else
                    SessionService.userMensaje = False
                End If
                If IBCBusqueda.userFactura(SessionService.UserId) Then
                    SessionService.userFactura = True
                Else
                    SessionService.userFactura = False
                End If

                ConfigurarDatosEmpresa()

                ''  5
                Me.SessionService.Usuario = BCPermisoUsuario.UsuarioGetById(txtUsuario.Text)
                ''

                Dim login = EventManager.GetEvent(Of Ladisac.Foundation.GlobalEvents.LoginEvent)()
                login.Publish(Me.SessionService.UserId)


                If IBCBusqueda.EditarFechaEmisionDocumento(SessionService.UserId) Then
                    SessionService.ModificarFechaProcesoEnDocumento = True
                Else
                    SessionService.ModificarFechaProcesoEnDocumento = False
                End If
                If IBCBusqueda.EditarFechaEmisionTesoreria(SessionService.UserId) Then
                    SessionService.ModificarFechaProcesoEnTesoreria = True
                Else
                    SessionService.ModificarFechaProcesoEnTesoreria = False
                End If
                If IBCBusqueda.NoCajeroEnTesoreria(SessionService.UserId) Then
                    SessionService.NoCajeroEnTesoreria = True
                Else
                    SessionService.NoCajeroEnTesoreria = False
                End If
                If IBCBusqueda.ReciboEgresoPlanillaTesoreria(SessionService.UserId) Then
                    SessionService.ReciboEgresoPlanilla = True
                Else
                    SessionService.ReciboEgresoPlanilla = False
                End If
                If IBCBusqueda.ReciboIngresoPlanillaTesoreria(SessionService.UserId) Then
                    SessionService.ReciboIngresoPlanilla = True
                Else
                    SessionService.ReciboIngresoPlanilla = False
                End If
                If IBCBusqueda.ModificarNombreEnPersona(SessionService.UserId) Then
                    SessionService.ModificarNombreEnPersona = True
                Else
                    SessionService.ModificarNombreEnPersona = False
                End If
                If IBCBusqueda.ModificarEstadoEnPersona(SessionService.UserId) Then
                    SessionService.ModificarEstadoEnPersona = True
                Else
                    SessionService.ModificarEstadoEnPersona = False
                End If

                If IBCBusqueda.ModificarFormaVentaEnPersona(SessionService.UserId) Then
                    SessionService.ModificarFormaVentaEnPersona = True
                Else
                    SessionService.ModificarFormaVentaEnPersona = False
                End If
                If IBCBusqueda.ModificarEsBancoEnPersona(SessionService.UserId) Then
                    SessionService.ModificarEsBancoEnPersona = True
                Else
                    SessionService.ModificarEsBancoEnPersona = False
                End If
                If IBCBusqueda.ModificarFinanzasEnPersona(SessionService.UserId) Then
                    SessionService.ModificarFinanzasEnPersona = True
                Else
                    SessionService.ModificarFinanzasEnPersona = False
                End If
                If IBCBusqueda.ModificarObservacionesEnPersona(SessionService.UserId) Then
                    SessionService.ModificarObservacionesEnPersona = True
                Else
                    SessionService.ModificarObservacionesEnPersona = False
                End If
                If IBCBusqueda.ModificarContactoEnPersona(SessionService.UserId) Then
                    SessionService.ModificarContactoEnPersona = True
                Else
                    SessionService.ModificarContactoEnPersona = False
                End If

                Me.Close()
            End If
        Else
            MsgBox("El usuario o la contraseña son incorrectos.", MsgBoxStyle.Critical, Me.Text)
            Me.SessionService.UserName = ""
            Me.SessionService.UserTipo = ""
            Me.SessionService.UserId = ""
            vContador += 1
            If vContador = 5 Then
                Ladisac.Foundation.MainWindow.ActiveForm.Close()
            End If
        End If
    End Sub
    Private Sub LoguearseBase()
        MsgBox("¡No se conecto a la Base de Datos seleccionada!" & Chr(13) & "Conectese", MsgBoxStyle.OkOnly, Me.Text)
        btnConectarseA.PerformClick()
    End Sub
    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboEmpresa.Text = "Diamante en la principal."
        'cboEmpresa.Text = "Comercial en la principal."
        'cboEmpresa.Text = "Diamante en la agencia."
        'cboEmpresa.Text = "Comercial en la agencia."
        'cboEmpresa.Text = "Diamante copia."
        'cboEmpresa.Text = "Comercial copia."
        'cboEmpresa.Text = "Inka."

        txtUsuario.Focus()
        Me.Text = Me.Text & " - Version " & vVersion
    End Sub

    Private Sub ConfigurarDatosEmpresa()
        Select Case Me.SessionService.NombreEmpresa
            Case "Ladrillera El Diamante SAC"
                Me.SessionService.EmpresaEsAgenteRetenedorPercepcion = False ' True
                Me.SessionService.PorcentajePercepcionGeneral = 0 '2
                Me.SessionService.PorcentajePercepcionAgentePercepcion = 0 '0.5
                Me.SessionService.MontoEnDocumentoVentaParaPercepcion = 0 '1500
                Me.SessionService.MontoEnDocumentoVentaParaSolicitarDNI = 700
                Me.SessionService.GlosaNoAfectoRetenciones = "NO AFECTO A RETENCIONES DE IGV POR HABER SIDO DESIGNADOS AGENTE DE RETENCION DE ACUERDO A R.S. 228-2012/SUNAT A PARTIR DEL 01-11-2012"
                Me.SessionService.GlosaNuevaDireccion = " "
                Me.SessionService.GlosaNoDevoluciones = " "
                Me.SessionService.PlacaElMismo = BCVariablesNames.PlacaElMismoLadrillera '  "AO1"
            Case "Comercializadora Diamante G.E. SAC"
                Me.SessionService.EmpresaEsAgenteRetenedorPercepcion = False
                Me.SessionService.PorcentajePercepcionGeneral = 0
                Me.SessionService.PorcentajePercepcionAgentePercepcion = 0
                Me.SessionService.MontoEnDocumentoVentaParaPercepcion = 0
                Me.SessionService.MontoEnDocumentoVentaParaSolicitarDNI = 700
                Me.SessionService.GlosaNoAfectoRetenciones = " "
                Me.SessionService.GlosaNuevaDireccion = " "
                Me.SessionService.GlosaNoDevoluciones = " "
                Me.SessionService.PlacaElMismo = BCVariablesNames.PlacaElMismoComercializadora '"AKX"
        End Select

        Me.SessionService.ModificarFechaProcesoEnDocumento = False
        Me.SessionService.PrevisualizarImpresionEnDocumento = False

        Me.SessionService.IGV = BCVariablesNames.PorcentajeIGV
        Me.SessionService.TC = 2.75

        'informacion para planillas
        Me.SessionService.MinimoHoraParaSerDia = 4.5
        Me.SessionService.HoraXDia = 8
        Me.SessionService.DiasXSemana = 6
        Me.SessionService.UIT = 3650.0
    End Sub

    Private Sub txtUsuario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Ladisac.Foundation.MainWindow.ActiveForm.Close()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If btnAceptar.Focused Or _
           btnSalir.Focused Then
            Return (MyBase.ProcessCmdKey(msg, keyData))
        End If
        If keyData <> Keys.Enter Then
            Return (MyBase.ProcessCmdKey(msg, keyData))
        End If
        SendKeys.Send(Chr(Keys.Tab))
        Return True
    End Function

    Private Sub btnCambiarConexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConectarseA.Click
        Dim vCadenaConexion As String = ""
        Dim vServidor As String = ""
        Dim vBD As String = ""

        Dim MiAppConfig As Configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)
        Dim MiSeccion As ConnectionStringsSection = DirectCast(MiAppConfig.GetSection("connectionStrings"), ConnectionStringsSection)

        Try
            MiAppConfig.AppSettings.Settings.Remove("NameEmpresa")
            MiAppConfig.AppSettings.Settings.Remove("RucEmpresa")
            MiAppConfig.AppSettings.Settings.Remove("ConectadoDesde")
        Catch ex As Exception

        End Try

        If cboEmpresa.Text = "Diamante en la principal." Then
            vServidor = "192.168.10.2,1433"
            vBD = "Diamante"
            vCadenaConexion = "Data Source=192.168.10.2,1433;Initial Catalog=Diamante;User ID=DesarrolloDiamante;Password=Di@mante2013;MultipleActiveResultSets=True"
            MiAppConfig.AppSettings.Settings.Add("NameEmpresa", "Ladrillera El Diamante SAC")
            MiAppConfig.AppSettings.Settings.Add("RucEmpresa", "20120877055")
            MiAppConfig.AppSettings.Settings.Add("ConectadoDesde", "La principal")
        ElseIf cboEmpresa.Text = "Diamante en la agencia." Then
            vServidor = "200.24.166.148"
            vBD = "Diamante"
            vCadenaConexion = "Data Source=192.168.10.2,1433;Initial Catalog=Diamante;User ID=DesarrolloDiamante;Password=Di@mante2013"
            MiAppConfig.AppSettings.Settings.Add("NameEmpresa", "Ladrillera El Diamante SAC")
            MiAppConfig.AppSettings.Settings.Add("RucEmpresa", "20120877055")
            MiAppConfig.AppSettings.Settings.Add("ConectadoDesde", "La agencia")
        ElseIf cboEmpresa.Text = "Comercial en la principal." Then
            vServidor = "192.168.10.2,1433"
            vBD = "Distribuidora"
            vCadenaConexion = "Data Source=192.168.10.2,1433;Initial Catalog=Diamante;User ID=DesarrolloDiamante;Password=Di@mante2013"
            MiAppConfig.AppSettings.Settings.Add("NameEmpresa", "Comercializadora Diamante G.E. SAC")
            MiAppConfig.AppSettings.Settings.Add("RucEmpresa", "20558363291")
            MiAppConfig.AppSettings.Settings.Add("ConectadoDesde", "La principal")
        ElseIf cboEmpresa.Text = "Comercial en la agencia." Then
            vServidor = "200.24.166.148"
            vBD = "Distribuidora"
            vCadenaConexion = "Data Source=192.168.10.2,1433;Initial Catalog=Diamante;User ID=DesarrolloDiamante;Password=Di@mante2013"
            MiAppConfig.AppSettings.Settings.Add("NameEmpresa", "Comercializadora Diamante G.E. SAC")
            MiAppConfig.AppSettings.Settings.Add("RucEmpresa", "20558363291")
            MiAppConfig.AppSettings.Settings.Add("ConectadoDesde", "La agencia")
        End If

        MiSeccion.ConnectionStrings("Ladisac").ConnectionString = vCadenaConexion
        MiSeccion.ConnectionStrings("LadisacEntities").ConnectionString = getConStrSQL(vServidor, vBD)
        MiAppConfig.Save()
        Application.Restart()
    End Sub
    Public Shared Function getConStrSQL(ByVal Servidor As String, ByVal BD As String) As String
        Dim connectionString As String = New System.Data.EntityClient.EntityConnectionStringBuilder() _
            With {.Metadata = "res://*", _
                  .Provider = "System.Data.SqlClient", _
                  .ProviderConnectionString = New System.Data.SqlClient.SqlConnectionStringBuilder() _
                    With {.InitialCatalog = BD, _
                          .DataSource = Servidor, _
                          .IntegratedSecurity = False, _
                          .UserID = "DesarrolloDiamante", _
                          .Password = "Di@mante2013"}.ConnectionString}.ConnectionString
        Return connectionString
    End Function

    Private Sub btnDiamante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiamante.Click
        If cboEmpresa.Text = "Diamante copia." Or cboEmpresa.Text = "Comercial copia." Then
            Exit Sub
        End If
        PegarBatDiamante()
        'UpdateDiamante()
        Shell("D:\UpdateSistema\Copiar.BAT", AppWinStyle.NormalFocus, True)
        Me.Dispose()
    End Sub

    Sub PegarBatDiamante()
        Try
            My.Computer.Network.DownloadFile("\\192.168.10.16\Aplicaciones\Ladrillera\Copiar.bat", "D:\UpdateSistema\Copiar.bat", "", "", True, 100, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAgencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgencia.Click
        If cboEmpresa.Text = "Diamante copia." Or cboEmpresa.Text = "Comercial copia." Then
            Exit Sub
        End If
        PegarBatAgencias()
        UpdateAgencias()
        Shell("D:\UpdateSistema\CopiarAgencia.BAT", AppWinStyle.NormalFocus, True)
        Me.Dispose()
    End Sub

    Sub PegarBatAgencias()
        Try
            My.Computer.Network.DownloadFile("ftp://190.116.179.45/AgenciasLadrillera/" & "CopiarAgencia.bat", "D:\UpdateSistema\CopiarAgencia.bat", "User1", "User1", True, 100, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub UpdateDiamante()
        'Primero Ladrillera en Diamante
        Try
            'Dim host As String = "192.168.10.16\UpdateLadisac"
            'Dim ftp As FtpWebRequest = FtpWebRequest.Create("\\" & host & "\Local_Ladrillera")
            'Dim resp As FtpWebResponse = Nothing
            'Dim reader As StreamReader = Nothing
            'ftp.Credentials = New NetworkCredential("Administrador", "Server.2016")
            'ftp.Method = WebRequestMethods.Ftp.ListDirectory
            'ftp.Proxy = Nothing
            'resp = CType(ftp.GetResponse(), FtpWebResponse)
            'reader = New StreamReader(resp.GetResponseStream())
            'While (reader.Peek() > -1)
            '    Dim str As String = reader.ReadLine()
            '    Try
            '        My.Computer.Network.DownloadFile("ftp://192.168.10.16/" & str, "D:\UpdateSistema\" & str, "Administrador", "Server.2016", True, 100, True)
            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message)
            '    End Try
            'End While
            'ftp = Nothing



            Dim di As New IO.DirectoryInfo("\\192.168.10.198\FTP\UpdateLadisac\Local_Ladrillera")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo
            'list the names of all files in the specified directory
            For Each dra In diar1
                My.Computer.Network.DownloadFile(dra.FullName, "D:\UpdateSistema\Local_Ladrillera\" & dra.Name, "", "", True, 100, True)
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        ''Segundo Comercializadora en Diamante
        'Try
        '    Dim host1 As String = "192.168.10.16"
        '    Dim ftp1 As FtpWebRequest = FtpWebRequest.Create("ftp://" & host1 & "/Local_Comercializadora")
        '    Dim resp1 As FtpWebResponse = Nothing
        '    Dim reader1 As StreamReader = Nothing
        '    ftp1.Credentials = New NetworkCredential("User1", "User1")
        '    ftp1.Method = WebRequestMethods.Ftp.ListDirectory
        '    ftp1.Proxy = Nothing
        '    resp1 = CType(ftp1.GetResponse(), FtpWebResponse)
        '    reader1 = New StreamReader(resp1.GetResponseStream())
        '    While (reader1.Peek() > -1)
        '        Dim str As String = reader1.ReadLine()
        '        Try
        '            My.Computer.Network.DownloadFile("ftp://192.168.10.16/" & str, "D:\UpdateSistema\" & str, "User1", "User1", True, 100, True)
        '        Catch ex As Exception
        '            MessageBox.Show(ex.Message)
        '        End Try
        '    End While
        '    ftp1 = Nothing
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Sub UpdateAgencias()
        'Primero Ladrillera en Agencias
        Try
            Dim host As String = "190.116.179.45"
            Dim ftp As FtpWebRequest = FtpWebRequest.Create("ftp://" & host & "/AgenciasLadrillera")
            ftp.Credentials = New NetworkCredential("User1", "User1")
            ftp.Method = WebRequestMethods.Ftp.ListDirectory
            ftp.Proxy = Nothing
            Dim resp As FtpWebResponse = Nothing
            resp = CType(ftp.GetResponse(), FtpWebResponse)
            Dim reader As StreamReader = Nothing
            reader = New StreamReader(resp.GetResponseStream())
            While (reader.Peek() > -1)
                Dim str As String = reader.ReadLine()
                Try
                    My.Computer.Network.DownloadFile("ftp://190.116.179.45/" & str, "D:\UpdateSistema\" & str, "User1", "User1", True, 60000, True)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End While
            ftp = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        ''Segundo Comercializadora en Agencias
        'Try
        '    Dim host As String = "190.223.225.60"
        '    Dim ftp As FtpWebRequest = FtpWebRequest.Create("ftp://" & host & "/Agencias_Comercializadora")
        '    ftp.Credentials = New NetworkCredential("User1", "User1")
        '    ftp.Method = WebRequestMethods.Ftp.ListDirectory
        '    ftp.Proxy = Nothing
        '    Dim resp As FtpWebResponse = Nothing
        '    resp = CType(ftp.GetResponse(), FtpWebResponse)
        '    Dim reader As StreamReader = Nothing
        '    reader = New StreamReader(resp.GetResponseStream())
        '    While (reader.Peek() > -1)
        '        Dim str As String = reader.ReadLine()
        '        Try
        '            My.Computer.Network.DownloadFile("ftp://190.223.225.60/" & str, "D:\UpdateSistema\" & str, "User1", "User1", True, 60000, True)
        '        Catch ex As Exception
        '            MessageBox.Show(ex.Message)
        '        End Try
        '    End While
        '    ftp = Nothing
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
End Class

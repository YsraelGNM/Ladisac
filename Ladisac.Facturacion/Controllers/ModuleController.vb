Imports Microsoft.Practices.Unity
Imports System.Windows.Forms
Imports Ladisac.Foundation
Imports System.Data
Imports System.IO

Namespace Ladisac.Facturacion
    Public Class ModuleController
        <Dependency()> _
        Public Property EventAggregator As Microsoft.Practices.Prism.Events.IEventAggregator

        <Dependency()> _
        Public Property ContainerService As Microsoft.Practices.Unity.IUnityContainer

        <Dependency()> _
        Public Property MenuService As Foundation.Services.IMenuService

        <Dependency()> _
        Public Property SessionService As Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCVariablesNames As BL.BCVariablesNames

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        Public Tempo As New System.Windows.Forms.Timer()
        Public vMUS_CORRELATIVO As Integer
        Private cMisProcedimientos As New Ladisac.MisProcedimientos

        Private Separador11 = New System.Windows.Forms.ToolStripStatusLabel()
        Private Separador12 = New System.Windows.Forms.ToolStripStatusLabel()
        Private Separador13 = New System.Windows.Forms.ToolStripStatusLabel()
        Private Separador14 = New System.Windows.Forms.ToolStripStatusLabel()
        Private Separador15 = New System.Windows.Forms.ToolStripStatusLabel()

        Private Separador21 = New System.Windows.Forms.ToolStripStatusLabel()

        Private MensajeUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Private MensajeGeneral = New System.Windows.Forms.ToolStripStatusLabel()
        Private TipoCambioCompra1 = New System.Windows.Forms.ToolStripStatusLabel()
        Private TipoCambioVenta1 = New System.Windows.Forms.ToolStripStatusLabel()

        Private PorcentajePercepcionGeneral = New System.Windows.Forms.ToolStripStatusLabel()
        Private PorcentajePercepcionAgentePercepcion = New System.Windows.Forms.ToolStripStatusLabel()
        Private MontoEnDocumentoVentaParaPercepcion = New System.Windows.Forms.ToolStripStatusLabel()

        Dim SubMenuNulo As New ToolStripMenuItem("...")
        Dim tsbNulo As New ToolStripButton

#Region "Permisos"
        Private vmB As Boolean = False

        Private vmB01 As Boolean = False

        Private vmB0101 As Boolean = False
        Private vmB0102 As Boolean = False

        Private vmB02 As Boolean = False
        Private vmB0201 As Boolean = False
        Private vmB0202 As Boolean = False
        Private vmB0203 As Boolean = False

        Private vmB03 As Boolean = False
        Private vmB0301 As Boolean = False
        Private vmB0302 As Boolean = False
        Private vmB0303 As Boolean = False
        Private vmB0304 As Boolean = False
        Private vmB0305 As Boolean = False
        Private vmB0306 As Boolean = False

        Private vmB04 As Boolean = False
        Private vmB0401 As Boolean = False
        Private vmB0402 As Boolean = False
        Private vmB0403 As Boolean = False
        Private vmB0404 As Boolean = False
        Private vmB0405 As Boolean = False
        Private vmB0406 As Boolean = False
        Private vmB0407 As Boolean = False
        Private vmB0408 As Boolean = False
        Private vmB0409 As Boolean = False
        Private vmB0410 As Boolean = False
        Private vmB0411 As Boolean = False
        Private vmB0412 As Boolean = False

        Private vmB05 As Boolean = False
        Private vmB0501 As Boolean = False
        Private vmB0502 As Boolean = False
        Private vmB0503 As Boolean = False
        Private vmB0504 As Boolean = False

        Private vmB06 As Boolean = False
        Private vmB0601 As Boolean = False
        Private vmB0602 As Boolean = False

        Private vmB07 As Boolean = False
        Private vmB0701 As Boolean = False
        Private vmB0702 As Boolean = False
        Private vmB0703 As Boolean = False
        Private vmB0704 As Boolean = False
        Private vmB0705 As Boolean = False
        Private vmB0706 As Boolean = False

        Private vmC As Boolean = False

        Private vmC01 As Boolean = False
        Private vmC0101 As Boolean = False

        Private vmC02 As Boolean = False
        Private vmC0201 As Boolean = False
        Private vmC0202 As Boolean = False

        Private vmC03 As Boolean = False
        Private vmC0301 As Boolean = False
        Private vmC0302 As Boolean = False
        Private vmC0303 As Boolean = False
        Private vmC0304 As Boolean = False
        Private vmC0305 As Boolean = False
        Private vmC0306 As Boolean = False
        Private vmC0307 As Boolean = False
        Private vmC0308 As Boolean = False
        Private vmC0309 As Boolean = False

        Private vmC04 As Boolean = False
        Private vmC0401 As Boolean = False
        Private vmC0402 As Boolean = False
        Private vmC0403 As Boolean = False
        Private vmC0404 As Boolean = False

        Private vmC05 As Boolean = False
        Private vmC0501 As Boolean = False
        Private vmC0502 As Boolean = False
        Private vmC0503 As Boolean = False
        Private vmC0504 As Boolean = False
        Private vmC0505 As Boolean = False
        Private vmC0506 As Boolean = False
        Private vmC0507 As Boolean = False
        Private vmC0508 As Boolean = False
        Private vmC0509 As Boolean = False
        Private vmC0510 As Boolean = False
        Private vmC0511 As Boolean = False
        Private vmC0512 As Boolean = False

        Private vmD As Boolean = False

        Private vmD01 As Boolean = False
        Private vmD0101 As Boolean = False
        Private vmD0102 As Boolean = False
        Private vmD0103 As Boolean = False
        Private vmD0104 As Boolean = False
        Private vmD0105 As Boolean = False
        Private vmD0106 As Boolean = False
        Private vmD0107 As Boolean = False
        Private vmD0108 As Boolean = False
        Private vmD0109 As Boolean = False
        Private vmD0110 As Boolean = False
        Private vmD0111 As Boolean = False
        Private vmD0112 As Boolean = False
        Private vmD0113 As Boolean = False
        Private vmD0114 As Boolean = False
        Private vmD0115 As Boolean = False
        Private vmD0116 As Boolean = False

        Private vmD02 As Boolean = False
        Private vmD0201 As Boolean = False
        Private vmD0202 As Boolean = False
        Private vmD0203 As Boolean = False
        Private vmD0204 As Boolean = False
        Private vmD0205 As Boolean = False
        Private vmD0206 As Boolean = False
        Private vmD0207 As Boolean = False
        Private vmD0208 As Boolean = False
        Private vmD0209 As Boolean = False
        Private vmD0210 As Boolean = False
        Private vmD0211 As Boolean = False
        Private vmD0212 As Boolean = False
        Private vmD0213 As Boolean = False

        Private vmE As Boolean = False

        Private vmE01 As Boolean = False
        Private vmE0101 As Boolean = False
        Private vmE0102 As Boolean = False
        Private vmE0103 As Boolean = False
        Private vmE0104 As Boolean = False

        Private vmE02 As Boolean = False

        Private vmE0201 As Boolean = False
        Private vmE020101 As Boolean = False
        Private vmE020102 As Boolean = False
        Private vmE020103 As Boolean = False
        Private vmE020104 As Boolean = False

        Private vmE0202 As Boolean = False
        Private vmE020201 As Boolean = False
        Private vmE020202 As Boolean = False
        Private vmE020203 As Boolean = False
        Private vmE020204 As Boolean = False
        Private vmE020205 As Boolean = False
        Private vmE020206 As Boolean = False


        Private vmE0203 As Boolean = False

        Private vmE0204 As Boolean = False
        Private vmE0205 As Boolean = False
        Private vmE0206 As Boolean = False
        Private vmE0207 As Boolean = False
        Private vmE0208 As Boolean = False

        Private vmE03 As Boolean = False
        Private vmE0301 As Boolean = False
        Private vmE0302 As Boolean = False
        Private vmE0303 As Boolean = False

        Private vmF As Boolean = False

        Private vmF01 As Boolean = False
        Private vmF0101 As Boolean = False
        Private vmF0102 As Boolean = False
        Private vmF0103 As Boolean = False
        Private vmF0104 As Boolean = False


        Private vmF02 As Boolean = False
        Private vmF0201 As Boolean = False
        Private vmF0202 As Boolean = False

        Private vmF03 As Boolean = False
        Private vmF0301 As Boolean = False
        Private vmF0302 As Boolean = False
        Private vmF0303 As Boolean = False

        Private vmF04 As Boolean = False
        Private vmF0401 As Boolean = False
        Private vmF0402 As Boolean = False
        Private vmF0403 As Boolean = False
        Private vmF0404 As Boolean = False
        Private vmF0405 As Boolean = False
        Private vmF0406 As Boolean = False
        Private vmF0407 As Boolean = False
        Private vmF0408 As Boolean = False

        Private vmG As Boolean = False

        Private vmG01 As Boolean = False
        Private vmG0101 As Boolean = False
        Private vmG0102 As Boolean = False
        Private vmG0103 As Boolean = False
        Private vmG0104 As Boolean = False
        Private vmG0105 As Boolean = False

        Private vmBarra(906, 16) As Boolean
        ' actualizar ConfigurarDatosPermisos()
        ' actualizar BloquearPermisos() 
        ' actualizar PermisosMenu() *****
#End Region

        Private Sub ConfigurarDatosPermisos(ByVal dtPermisos As DataTable)
            Dim vFilaGrid As Int16 = 0
            Dim vControl As Boolean = False
            Dim vFilaArray As Int16 = 0
            Dim vBooleanArray As Boolean = False
            If dtPermisos.Rows.Count = 0 Then vControl = True
            While dtPermisos.Rows.Count > vFilaGrid
                With dtPermisos.Rows(vFilaGrid)
                    If .Item("Cadena") = "B" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB = True
                        If .Item("NroRegistro") <> 1 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "B01" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB01 = True
                        If .Item("NroRegistro") <> 2 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0101" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0101 = True
                        If .Item("NroRegistro") <> 3 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0102" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0102 = True
                        If .Item("NroRegistro") <> 4 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "B02" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB02 = True
                        If .Item("NroRegistro") <> 5 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0201" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0201 = True
                        If .Item("NroRegistro") <> 6 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0202" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0202 = True
                        If .Item("NroRegistro") <> 7 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0203" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0203 = True
                        If .Item("NroRegistro") <> 8 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "B03" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB03 = True
                        If .Item("NroRegistro") <> 9 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0301" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0301 = True
                        If .Item("NroRegistro") <> 10 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0302" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0302 = True
                        If .Item("NroRegistro") <> 11 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0303" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0303 = True
                        If .Item("NroRegistro") <> 12 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0304" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0304 = True
                        If .Item("NroRegistro") <> 13 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0305" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0305 = True
                        If .Item("NroRegistro") <> 14 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0306" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0306 = True
                        If .Item("NroRegistro") <> 15 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "B04" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB04 = True
                        If .Item("NroRegistro") <> 16 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0401" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0401 = True
                        If .Item("NroRegistro") <> 17 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0402" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0402 = True
                        If .Item("NroRegistro") <> 18 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0403" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0403 = True
                        If .Item("NroRegistro") <> 19 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0404" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0404 = True
                        If .Item("NroRegistro") <> 20 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0405" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0405 = True
                        If .Item("NroRegistro") <> 21 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0406" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0406 = True
                        If .Item("NroRegistro") <> 22 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0407" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0407 = True
                        If .Item("NroRegistro") <> 23 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0408" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0408 = True
                        If .Item("NroRegistro") <> 464 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0409" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0409 = True
                        If .Item("NroRegistro") <> 525 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0410" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0410 = True
                        If .Item("NroRegistro") <> 526 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0411" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0411 = True
                        If .Item("NroRegistro") <> 532 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0412" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0412 = True
                        If .Item("NroRegistro") <> 482 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If


                    If .Item("Cadena") = "B05" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB05 = True
                        If .Item("NroRegistro") <> 24 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0501" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0501 = True
                        If .Item("NroRegistro") <> 25 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0502" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0502 = True
                        If .Item("NroRegistro") <> 26 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0503" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0503 = True
                        If .Item("NroRegistro") <> 27 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0504" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0504 = True
                        If .Item("NroRegistro") <> 28 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If


                    If .Item("Cadena") = "B06" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB06 = True
                        If .Item("NroRegistro") <> 29 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0601" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0601 = True
                        If .Item("NroRegistro") <> 30 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0602" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0602 = True
                        If .Item("NroRegistro") <> 31 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "B07" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB07 = True
                        If .Item("NroRegistro") <> 32 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0701" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0701 = True
                        If .Item("NroRegistro") <> 33 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0702" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0702 = True
                        If .Item("NroRegistro") <> 34 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0703" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0703 = True
                        If .Item("NroRegistro") <> 35 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0704" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0704 = True
                        If .Item("NroRegistro") <> 36 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0705" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0705 = True
                        If .Item("NroRegistro") <> 37 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "B0706" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmB0706 = True
                        If .Item("NroRegistro") <> 470 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "C" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC = True
                        If .Item("NroRegistro") <> 38 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "C01" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC01 = True
                        If .Item("NroRegistro") <> 39 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0101" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0101 = True
                        If .Item("NroRegistro") <> 40 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "C02" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC02 = True
                        If .Item("NroRegistro") <> 41 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0201" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0201 = True
                        If .Item("NroRegistro") <> 42 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0202" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0202 = True
                        If .Item("NroRegistro") <> 43 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "C03" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC03 = True
                        If .Item("NroRegistro") <> 44 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0301" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0301 = True
                        If .Item("NroRegistro") <> 45 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0302" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0302 = True
                        If .Item("NroRegistro") <> 46 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0303" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0303 = True
                        If .Item("NroRegistro") <> 47 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0304" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0304 = True
                        If .Item("NroRegistro") <> 48 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0305" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0305 = True
                        If .Item("NroRegistro") <> 49 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0306" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0306 = True
                        If .Item("NroRegistro") <> 50 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0307" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0307 = True
                        If .Item("NroRegistro") <> 208 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0308" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0308 = True
                        If .Item("NroRegistro") <> 471 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0309" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0309 = True
                        If .Item("NroRegistro") <> 563 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "C04" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC04 = True
                        If .Item("NroRegistro") <> 51 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0401" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0401 = True
                        If .Item("NroRegistro") <> 52 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0402" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0402 = True
                        If .Item("NroRegistro") <> 53 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0403" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0403 = True
                        If .Item("NroRegistro") <> 488 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0404" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0404 = True
                        If .Item("NroRegistro") <> 489 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "C05" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC05 = True
                        If .Item("NroRegistro") <> 54 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0501" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0501 = True
                        If .Item("NroRegistro") <> 55 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0502" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0502 = True
                        If .Item("NroRegistro") <> 56 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0503" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0503 = True
                        If .Item("NroRegistro") <> 57 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0504" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0504 = True
                        If .Item("NroRegistro") <> 58 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0505" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0505 = True
                        If .Item("NroRegistro") <> 221 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0506" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0506 = True
                        If .Item("NroRegistro") <> 206 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0507" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0507 = True
                        If .Item("NroRegistro") <> 209 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0508" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0508 = True
                        If .Item("NroRegistro") <> 513 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0509" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0509 = True
                        If .Item("NroRegistro") <> 517 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0510" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0510 = True
                        If .Item("NroRegistro") <> 468 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0511" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0511 = True
                        If .Item("NroRegistro") <> 472 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "C0512" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmC0512 = True
                        If .Item("NroRegistro") <> 591 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD = True
                        If .Item("NroRegistro") <> 59 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D01" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD01 = True
                        If .Item("NroRegistro") <> 60 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0101" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0101 = True
                        If .Item("NroRegistro") <> 61 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0102" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0102 = True
                        If .Item("NroRegistro") <> 62 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0103" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0103 = True
                        If .Item("NroRegistro") <> 63 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0104" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0104 = True
                        If .Item("NroRegistro") <> 64 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0105" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0105 = True
                        If .Item("NroRegistro") <> 65 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0106" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0106 = True
                        If .Item("NroRegistro") <> 211 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0107" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0107 = True
                        If .Item("NroRegistro") <> 212 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0108" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0108 = True
                        If .Item("NroRegistro") <> 218 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0109" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0109 = True
                        If .Item("NroRegistro") <> 219 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0110" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0110 = True
                        If .Item("NroRegistro") <> 220 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0111" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0111 = True
                        If .Item("NroRegistro") <> 388 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0112" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0112 = True
                        If .Item("NroRegistro") <> 392 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0113" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0113 = True
                        If .Item("NroRegistro") <> 406 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0114" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0114 = True
                        If .Item("NroRegistro") <> 515 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0115" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0115 = True
                        If .Item("NroRegistro") <> 523 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0116" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0116 = True
                        If .Item("NroRegistro") <> 558 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "D02" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD02 = True
                        If .Item("NroRegistro") <> 66 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0201" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0201 = True
                        If .Item("NroRegistro") <> 67 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0202" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0202 = True
                        If .Item("NroRegistro") <> 68 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0203" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0203 = True
                        If .Item("NroRegistro") <> 217 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0204" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0204 = True
                        If .Item("NroRegistro") <> 389 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0205" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0205 = True
                        If .Item("NroRegistro") <> 390 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0206" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0206 = True
                        If .Item("NroRegistro") <> 205 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0207" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0207 = True
                        If .Item("NroRegistro") <> 412 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0208" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0208 = True
                        If .Item("NroRegistro") <> 514 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0209" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0209 = True
                        If .Item("NroRegistro") <> 518 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0210" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0210 = True
                        If .Item("NroRegistro") <> 524 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0211" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0211 = True
                        If .Item("NroRegistro") <> 527 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0212" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0212 = True
                        If .Item("NroRegistro") <> 536 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "D0213" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmD0213 = True
                        If .Item("NroRegistro") <> 550 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE = True
                        If .Item("NroRegistro") <> 69 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "E01" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE01 = True
                        If .Item("NroRegistro") <> 70 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0101" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0101 = True
                        If .Item("NroRegistro") <> 71 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0102" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0102 = True
                        If .Item("NroRegistro") <> 72 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0103" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0103 = True
                        If .Item("NroRegistro") <> 466 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0104" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0104 = True
                        If .Item("NroRegistro") <> 467 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "E02" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE02 = True
                        If .Item("NroRegistro") <> 73 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0201" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0201 = True
                        If .Item("NroRegistro") <> 74 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020101" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020101 = True
                        If .Item("NroRegistro") <> 75 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020102" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020102 = True
                        If .Item("NroRegistro") <> 76 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020103" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020103 = True
                        If .Item("NroRegistro") <> 77 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020104" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020104 = True
                        If .Item("NroRegistro") <> 490 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0202" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0202 = True
                        If .Item("NroRegistro") <> 78 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020201" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020201 = True
                        If .Item("NroRegistro") <> 79 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020202" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020202 = True
                        If .Item("NroRegistro") <> 80 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020203" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020203 = True
                        If .Item("NroRegistro") <> 81 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020204" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020204 = True
                        If .Item("NroRegistro") <> 82 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020205" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020205 = True
                        If .Item("NroRegistro") <> 83 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E020206" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE020206 = True
                        If .Item("NroRegistro") <> 484 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "E0203" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0203 = True
                        If .Item("NroRegistro") <> 84 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0204" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0204 = True
                        If .Item("NroRegistro") <> 207 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0205" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0205 = True
                        If .Item("NroRegistro") <> 486 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0206" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0206 = True
                        If .Item("NroRegistro") <> 485 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0207" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0207 = True
                        If .Item("NroRegistro") <> 486 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0208" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0208 = True
                        If .Item("NroRegistro") <> 492 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E03" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE03 = True
                        If .Item("NroRegistro") <> 85 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0301" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0301 = True
                        If .Item("NroRegistro") <> 86 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "E0302" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0302 = True
                        If .Item("NroRegistro") <> 414 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "E0303" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmE0303 = True

                        If .Item("NroRegistro") <> 904 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "F" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF = True
                        If .Item("NroRegistro") <> 87 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "F01" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF01 = True
                        If .Item("NroRegistro") <> 88 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0101" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0101 = True
                        If .Item("NroRegistro") <> 89 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0102" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0102 = True
                        If .Item("NroRegistro") <> 90 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0103" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0103 = True
                        If .Item("NroRegistro") <> 901 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0104" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0104 = True
                        If .Item("NroRegistro") <> 469 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "F02" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF02 = True
                        If .Item("NroRegistro") <> 91 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0201" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0201 = True
                        If .Item("NroRegistro") <> 92 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0202" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0202 = True
                        If .Item("NroRegistro") <> 465 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F03" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF03 = True
                        If .Item("NroRegistro") <> 93 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0301" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0301 = True
                        If .Item("NroRegistro") <> 94 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0302" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0302 = True
                        If .Item("NroRegistro") <> 95 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0303" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0303 = True
                        If .Item("NroRegistro") <> 96 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "F04" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF04 = True
                        If .Item("NroRegistro") <> 97 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0401" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0401 = True
                        If .Item("NroRegistro") <> 98 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0402" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0402 = True
                        If .Item("NroRegistro") <> 99 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0403" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0403 = True
                        If .Item("NroRegistro") <> 203 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0404" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0404 = True
                        If .Item("NroRegistro") <> 204 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0405" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0405 = True
                        If .Item("NroRegistro") <> 475 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0406" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0406 = True
                        If .Item("NroRegistro") <> 473 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0407" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0407 = True
                        If .Item("NroRegistro") <> 476 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "F0408" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmF0408 = True
                        If .Item("NroRegistro") <> 479 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "G" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmG = True
                        If .Item("NroRegistro") <> 100 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    If .Item("Cadena") = "G01" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmG01 = True
                        If .Item("NroRegistro") <> 101 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "G0101" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmG0101 = True
                        If .Item("NroRegistro") <> 102 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "G0102" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmG0102 = True
                        If .Item("NroRegistro") <> 103 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "G0103" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmG0103 = True
                        If .Item("NroRegistro") <> 104 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "G0104" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmG0104 = True
                        If .Item("NroRegistro") <> 105 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If
                    If .Item("Cadena") = "G0105" Then
                        If .Item("EstadoDescripción") = "SI FORMA" Then vmG0105 = True
                        If .Item("NroRegistro") <> 106 Then
                            vControl = True
                            Exit While
                        End If
                        vFilaArray = .Item("NroRegistro")
                    End If

                    ''''''''''''''''''

                    If .Item("Nuevo") = "SI NUEVO" Then
                        vBooleanArray = True
                    ElseIf .Item("Nuevo") = "NO NUEVO" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 1, vBooleanArray)

                    If .Item("Editar") = "SI EDITAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Editar") = "NO EDITAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 2, vBooleanArray)

                    If .Item("CancelarEditar") = "SI CANCELAREDITAR" Then
                        vBooleanArray = True
                    ElseIf .Item("CancelarEditar") = "NO CANCELAREDITAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 3, vBooleanArray)

                    If .Item("Grabar") = "SI GRABAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Grabar") = "NO GRABAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 4, vBooleanArray)

                    If .Item("GrabarNuevo") = "SI GRABARNUEVO" Then
                        vBooleanArray = True
                    ElseIf .Item("GrabarNuevo") = "NO GRABARNUEVO" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 5, vBooleanArray)

                    If .Item("Eliminar") = "SI ELIMINAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Eliminar") = "NO ELIMINAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 6, vBooleanArray)

                    If .Item("Deshacer") = "SI DESHACER" Then
                        vBooleanArray = True
                    ElseIf .Item("Deshacer") = "NO DESHACER" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 7, vBooleanArray)

                    If .Item("Agregar") = "SI AGREGAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Agregar") = "NO AGREGAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 8, vBooleanArray)

                    If .Item("Quitar") = "SI QUITAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Quitar") = "NO QUITAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 9, vBooleanArray)

                    If .Item("Buscar") = "SI BUSCAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Buscar") = "NO BUSCAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 10, vBooleanArray)

                    If .Item("OkBusqueda") = "SI OKBUSQUEDA" Then
                        vBooleanArray = True
                    ElseIf .Item("OkBusqueda") = "NO OKBUSQUEDA" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 11, vBooleanArray)

                    If .Item("Inicio") = "SI INICIO" Then
                        vBooleanArray = True
                    ElseIf .Item("Inicio") = "NO INICIO" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 12, vBooleanArray)

                    If .Item("Anterior") = "SI ANTERIOR" Then
                        vBooleanArray = True
                    ElseIf .Item("Anterior") = "NO ANTERIOR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 13, vBooleanArray)

                    If .Item("Siguiente") = "SI SIGUIENTE" Then
                        vBooleanArray = True
                    ElseIf .Item("Siguiente") = "NO SIGUIENTE" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 14, vBooleanArray)

                    If .Item("Final") = "SI FINAL" Then
                        vBooleanArray = True
                    ElseIf .Item("Final") = "NO FINAL" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 15, vBooleanArray)

                    If .Item("Reportes") = "SI REPORTES" Then
                        vBooleanArray = True
                    ElseIf .Item("Reportes") = "NO REPORTES" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 16, vBooleanArray)
                End With
                vFilaGrid += 1
            End While
            If vControl Then
                BloquearPermisos()
                Exit Sub
            End If
            PermisosMenu()
        End Sub

        Private Sub PermisosForms(ByVal vFila As Int16, ByVal vColumna As Int16, ByVal vBoolean As Boolean)
            vmBarra(vFila, vColumna) = vBoolean
        End Sub

        Private Sub BloquearPermisos()
            vmB = False

            vmB01 = False
            vmB0101 = False
            vmB0102 = False

            vmB02 = False
            vmB0201 = False
            vmB0202 = False
            vmB0203 = False

            vmB03 = False
            vmB0301 = False
            vmB0302 = False
            vmB0303 = False
            vmB0304 = False
            vmB0305 = False
            vmB0306 = False

            vmB04 = False
            vmB0401 = False
            vmB0402 = False
            vmB0403 = False
            vmB0404 = False
            vmB0405 = False
            vmB0406 = False
            vmB0407 = False
            vmB0408 = False
            vmB0409 = False
            vmB0410 = False
            vmB0411 = False
            vmB0412 = False

            vmB05 = False
            vmB0501 = False
            vmB0502 = False
            vmB0503 = False
            vmB0504 = False

            vmB06 = False
            vmB0601 = False
            vmB0602 = False

            vmB07 = False
            vmB0701 = False
            vmB0702 = False
            vmB0703 = False
            vmB0704 = False
            vmB0705 = False
            vmB0706 = False

            vmC = False

            vmC01 = False
            vmC0101 = False

            vmC02 = False
            vmC0201 = False
            vmC0202 = False

            vmC03 = False
            vmC0301 = False
            vmC0302 = False
            vmC0303 = False
            vmC0304 = False
            vmC0305 = False
            vmC0306 = False
            vmC0307 = False
            vmC0308 = False
            vmC0309 = False

            vmC04 = False
            vmC0401 = False
            vmC0402 = False
            vmC0403 = False
            vmC0404 = False

            vmC05 = False
            vmC0501 = False
            vmC0502 = False
            vmC0503 = False
            vmC0504 = False
            vmC0505 = False
            vmC0506 = False
            vmC0507 = False
            vmC0508 = False
            vmC0509 = False
            vmC0510 = False
            vmC0511 = False
            vmC0512 = False

            vmD = False

            vmD01 = False
            vmD0101 = False
            vmD0102 = False
            vmD0103 = False
            vmD0104 = False
            vmD0105 = False
            vmD0106 = False
            vmD0107 = False
            vmD0108 = False
            vmD0109 = False
            vmD0110 = False
            vmD0111 = False
            vmD0112 = False
            vmD0113 = False
            vmD0114 = False
            vmD0115 = False
            vmD0116 = False

            vmD02 = False
            vmD0201 = False
            vmD0202 = False
            vmD0203 = False
            vmD0204 = False
            vmD0205 = False
            vmD0206 = False
            vmD0207 = False
            vmD0208 = False
            vmD0209 = False
            vmD0210 = False
            vmD0211 = False
            vmD0212 = False
            vmD0213 = False

            vmE = False

            vmE01 = False
            vmE0101 = False
            vmE0102 = False
            vmE0103 = False
            vmE0104 = False

            vmE02 = False
            vmE0201 = False
            vmE020101 = False
            vmE020102 = False
            vmE020103 = False
            vmE020104 = False
            vmE0202 = False
            vmE020201 = False
            vmE020202 = False
            vmE020203 = False
            vmE020204 = False
            vmE020205 = False
            vmE020206 = False


            vmE0203 = False

            vmE0204 = False
            vmE0205 = False
            vmE0206 = False
            vmE0207 = False
            vmE0208 = False

            vmE03 = False
            vmE0301 = False
            vmE0302 = False

            vmF = False

            vmF01 = False
            vmF0101 = False
            vmF0102 = False
            vmF0103 = False
            vmF0104 = False

            vmF02 = False
            vmF0201 = False
            vmF0202 = False

            vmF03 = False
            vmF0301 = False
            vmF0302 = False
            vmF0303 = False

            vmF04 = False
            vmF0401 = False
            vmF0402 = False
            vmF0403 = False
            vmF0404 = False
            vmF0405 = False
            vmF0406 = False
            vmF0407 = False
            vmF0408 = False

            vmG = False

            vmG01 = False
            vmG0101 = False
            vmG0102 = False
            vmG0103 = False
            vmG0104 = False
            vmG0105 = False

            For vFil = 1 To 906
                For vCol = 1 To 16
                    vmBarra(vFil, vCol) = False
                Next
            Next
        End Sub

        Private Sub ConfigurarPermisos()
            Dim CadenaVista As String = ""
            Dim ds As New DataSet

            If Me.SessionService.UserId Is Nothing Then
                BloquearPermisos()
                PermisosMenu()
            End If

            Dim CadenaPEU_ID As String = ""
            CadenaPEU_ID = Me.IBCBusqueda.ListarIdPermisoUsuario(Me.SessionService.UserId)

            If CadenaPEU_ID Is Nothing Then
                BloquearPermisos()
                PermisosMenu()
            Else
                CadenaVista = IBCMaestro.EjecutarVista("spListarDetallePermisoUsuarioXML", CadenaPEU_ID)
                Dim sr As New StringReader(CadenaVista)
                Dim vcontrol As Int16 = sr.Peek
                If vcontrol <> -1 Then
                    ds.ReadXml(sr)
                    ConfigurarDatosPermisos(ds.Tables(0))
                Else
                    BloquearPermisos()
                    PermisosMenu()
                End If
            End If
        End Sub

        Private Sub PermisosMenu()
        End Sub

        Sub run()
            AddHandler SubMenuNulo.Click, AddressOf OnSubMenuNulo_CLick
            SubMenuNulo.Enabled = False

            AddHandler tsbNulo.Click, AddressOf OnCLick
            tsbNulo.Enabled = False

            RegistrarEventos()

        End Sub

        Private Sub RegistrarVariables(ByVal user As String)
            Dim vDAU_ID As String = ""
            Dim vcontrol As Int16 = 0
            Dim ds As New DataSet
            Dim ds1 As New DataSet

            Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spListarDatosUsuariosUSU_IDXML, user))
            vcontrol = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                vDAU_ID = ds.Tables(0).Rows(0).Item("DAU_ID")
                BCVariablesNames.CajeroDefault = ds.Tables(0).Rows(0).Item("PER_ID")
            Else
                vDAU_ID = ""
                BCVariablesNames.CajeroDefault = ""
            End If

            Dim sr1 As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spListarPuntoVentaDatosUsuariosPVE_IDXML, vDAU_ID))
            vcontrol = sr1.Peek
            If vcontrol <> -1 Then
                ds1.ReadXml(sr1)
                BCVariablesNames.PuntoVentaPrincipal = ds1.Tables(0).Rows(0).Item("PVE_ID")
            Else
                BCVariablesNames.PuntoVentaPrincipal = ""
            End If
            ConfigurarPermisos()
        End Sub

        Public Function BuildSeparator() As ToolStripSeparator
            Dim tss As New System.Windows.Forms.ToolStripSeparator
            tss.Size = New System.Drawing.Size(6, 65)
            Return tss
        End Function

        Public Function BuildLabel(ByVal texto As String) As ToolStripLabel
            Dim tsl As New System.Windows.Forms.ToolStripLabel
            tsl.Enabled = False
            tsl.Font = New System.Drawing.Font("Tahoma", 6.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tsl.Size = New System.Drawing.Size(13, 70)
            tsl.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
            tsl.Text = texto
            Return tsl
        End Function

        Public Function BuildBoton(ByVal id As String, ByVal text As String, ByVal Imagen As System.Drawing.Image) As ToolStripButton
            Dim tsb As New ToolStripButton
            tsb.AutoSize = False
            tsb.BackColor = System.Drawing.Color.Transparent
            tsb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            tsb.Font = New System.Drawing.Font("Tahoma", 6.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tsb.ImageTransparentColor = System.Drawing.Color.Transparent
            tsb.Margin = New System.Windows.Forms.Padding(0)
            tsb.Size = New System.Drawing.Size(73, 57)
            tsb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            tsb.Name = id
            tsb.Text = text
            tsb.ToolTipText = " Datos de : " & text
            tsb.Image = Imagen
            Return tsb
        End Function

        Public Function BuildToolStrip() As ToolStrip
            Dim ts As New ToolStrip

            ts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            ts.AutoSize = False
            ts.Dock = System.Windows.Forms.DockStyle.None
            ts.Enabled = False
            ts.ImageScalingSize = New System.Drawing.Size(63, 62)
            ts.Location = New System.Drawing.Point(0, 24)
            ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
            ts.Size = New System.Drawing.Size(848, 80)
            ts.Stretch = False
            ts.Visible = False
            Return ts
        End Function

        Public Sub RegistrarEventos()
            Dim evento = EventAggregator.GetEvent(Of Ladisac.Foundation.GlobalEvents.LoginEvent)()
            evento.Subscribe(AddressOf onlogin)
        End Sub

        Private Sub onlogin(ByVal user As String)
            RegistrarVariables(user)
            RegistrarNotification()
            RegistrarMenus()
            Dim PorcentajePercepcionGeneral = New System.Windows.Forms.ToolStripStatusLabel()
            Dim PorcentajePercepcionAgentePercepcion = New System.Windows.Forms.ToolStripStatusLabel()
            Dim MontoEnDocumentoVentaParaPercepcion = New System.Windows.Forms.ToolStripStatusLabel()
        End Sub

        Public Sub RegistrarNotification()
            ''If SessionService.UserId = "ALOPEZ" Or SessionService.UserId = "ADMIN" Then
            If SessionService.userMensaje Then
                Tempo.Interval = 5000
                vMUS_CORRELATIVO = 0
            Else
                Tempo.Interval = 600000
                vMUS_CORRELATIVO = -1
            End If

            AddHandler Tempo.Tick, AddressOf OnNotification
            Tempo.Start()
        End Sub

        Public Sub OnNotification()
            Try
                'Dim result As DataTable = Nothing
                'Dim bcutil As New Ladisac.BL.BCUtil
                'Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                'result = rep.EjecutarReporte("spEstadoCuenta")
                'bcutil.excelExportar(result)

                'Dim oReporte As New Ladisac.CuentasCorrientes.Reportes.EstadoCuenta
                'Dim frm = Me.ContainerService.Resolve(Of Ladisac.Reporteador)()
                ''frm.Text = Me.Text
                ''frm.lblTitle.Text = Me.Text
                'frm.Reporte(oReporte)
                'frm.Show()
                'frm.BringToFront()

                If vMUS_CORRELATIVO = -1 Then
                    Dim ds As New DataSet
                    Dim sr As New StringReader(IBCMaestro.EjecutarVista("spCambioDiaXML", BCVariablesNames.MonedaSistema, BCVariablesNames.MonedaExtrangera, cMisProcedimientos.FormatoFechaGenerico(Now.ToShortDateString)))
                    Dim vcontrol As Int16 = sr.Peek
                    If vcontrol <> -1 Then
                        ds.ReadXml(sr)
                        BCVariablesNames.CompraDolar = ds.Tables(0).Rows(0).Item("TCA_COMPRA")
                        BCVariablesNames.VentaDolar = ds.Tables(0).Rows(0).Item("TCA_VENTA")
                        TipoCambioCompra1.Text = "Cambio del día: " & ds.Tables(0).Rows(0).Item("MON_SIMBOLO_0").ToString & " 1.0000  -  " & _
                                                                                          "Compra: " & ds.Tables(0).Rows(0).Item("MON_SIMBOLO_1").ToString & _
                                                                                          ds.Tables(0).Rows(0).Item("TCA_COMPRA").ToString
                        TipoCambioVenta1.Text = " - Venta : " & ds.Tables(0).Rows(0).Item("MON_SIMBOLO_1").ToString & _
                                                                                          ds.Tables(0).Rows(0).Item("TCA_VENTA").ToString
                    End If

                    If Me.SessionService.NombreEmpresa = "Ladrillera El Diamante SAC" Then
                        Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.BackColor = Me.ContainerService.Resolve(Of MainWindow)().BackColor
                    Else
                        Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.BackColor = System.Drawing.Color.CadetBlue
                    End If

                    MensajeUsuario.ForeColor = System.Drawing.Color.Red
                    MensajeGeneral.ForeColor = System.Drawing.Color.Red

                    'Dim ds1 As New DataSet
                    'Dim sr1 As New StringReader(IBCMaestro.EjecutarVista("spMensajeUsuarioXML", SessionService.UserId, cMisProcedimientos.FormatoFechaGenerico(Now.ToShortDateString)))
                    'Dim vcontrol1 As Int16 = sr1.Peek
                    'If vcontrol1 <> -1 Then
                    '    If Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Visible = False Then
                    '        Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Visible = True
                    '    Else
                    '        Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Visible = False
                    '    End If
                    '    ds1.ReadXml(sr1)
                    '    MensajeUsuario.Text = ds1.Tables(0).Rows(0).Item("MUS_DESCRIPCION")
                    'Else
                    '    Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Visible = False
                    '    MensajeUsuario.Text = ""
                    'End If

                    'Dim ds2 As New DataSet
                    'Dim sr2 As New StringReader(IBCMaestro.EjecutarVista("spMensajeGeneralXML", cMisProcedimientos.FormatoFechaGenerico(Now.ToShortDateString)))
                    'Dim vcontrol2 As Int16 = sr2.Peek
                    'If vcontrol2 <> -1 Then
                    '    If MensajeGeneral.Text = "" Then
                    '        ds2.ReadXml(sr2)
                    '        MensajeGeneral.Text = ds2.Tables(0).Rows(0).Item("MUS_DESCRIPCION")
                    '    Else
                    '        MensajeGeneral.Text = ""
                    '    End If
                    'Else
                    '    MensajeGeneral.Text = ""
                    'End If
                Else
                    ''If SessionService.UserId = "ALOPEZ" Or SessionService.UserId = "ADMIN" Then
                    If SessionService.userMensaje Then
                        vMUS_CORRELATIVO = vMUS_CORRELATIVO + 1
                        'Dim ds1 As New DataSet
                        'Dim sr1 As New StringReader(IBCMaestro.EjecutarVista("spMensajeUsuarioNuevoXML", SessionService.UserId, cMisProcedimientos.FormatoFechaGenerico(Now.ToShortDateString), vMUS_CORRELATIVO))
                        'Dim vcontrol1 As Int16 = sr1.Peek
                        'If vcontrol1 <> -1 Then
                        '    If Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Visible = False Then
                        '        Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Visible = True
                        '    Else
                        '        Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Visible = False
                        '    End If
                        '    ds1.ReadXml(sr1)


                        '    My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
                        '    MsgBox(ds1.Tables(0).Rows(0).Item("MUS_DESCRIPCION"), vbSystemModal + vbExclamation, "¡ERROR!")
                        '    MensajeUsuario.Text = ds1.Tables(0).Rows(0).Item("MUS_DESCRIPCION")
                        'Else
                        '    vMUS_CORRELATIVO = vMUS_CORRELATIVO - 1
                        '    Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Visible = False
                        '    MensajeUsuario.Text = ""
                        'End If
                    End If
                End If
            Catch ex As Exception
                MensajeUsuario.Text = ""
                MensajeGeneral.Text = ""
            End Try
        End Sub

        Public Sub RegistrarMenus()
            Dim SubMenuMaestros_ As New Object
            Dim SubMenuFacturacion_ As New Object
            Dim SubMenuDespachos_ As New Object
            Dim SubMenuTesoreria_ As New Object
            Dim SubMenuCuentasCorrientes_ As New Object
            Dim SubMenuActivosFijos_ As New Object

            Separador11.text = " ¦¦¦ "
            Separador12.text = " ¦¦¦ "
            Separador13.text = " ¦¦¦ "
            Separador14.text = " ¦¦¦ "
            Separador15.text = " ¦¦¦ "

            Separador21.text = " ¦¦¦ "

            PorcentajePercepcionGeneral.text = "% Percepción general: " & SessionService.PorcentajePercepcionGeneral
            PorcentajePercepcionAgentePercepcion.text = "% Percepción agente percepción: " & SessionService.PorcentajePercepcionAgentePercepcion
            MontoEnDocumentoVentaParaPercepcion.text = "Monto para la percepción: " & SessionService.MontoEnDocumentoVentaParaPercepcion

            Separador11.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Separador12.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Separador13.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Separador14.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Separador15.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            Separador21.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            TipoCambioCompra1.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            TipoCambioVenta1.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            PorcentajePercepcionGeneral.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            PorcentajePercepcionAgentePercepcion.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            MontoEnDocumentoVentaParaPercepcion.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))


            Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).StatusMensaje.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
                    {Separador21, MensajeUsuario})

            Me.ContainerService.Resolve(Of MainWindow).statusprincipal.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).statusprincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
                    {Separador11, MensajeGeneral, Separador12, TipoCambioCompra1, TipoCambioVenta1, Separador13, PorcentajePercepcionGeneral, Separador14, PorcentajePercepcionAgentePercepcion, Separador15, MontoEnDocumentoVentaParaPercepcion})

            Dim SubMenuMaestros As New ToolStripMenuItem(Facturacion.Constants.MenuNames.Maestros)
            AddHandler SubMenuMaestros.Click, AddressOf OnSubMenuMaestros_CLick

            Dim SubMenuFacturacion As New ToolStripMenuItem(Facturacion.Constants.MenuNames.Facturacion)
            AddHandler SubMenuFacturacion.Click, AddressOf OnSubMenuFacturacion_CLick

            Dim SubMenuDespachos As New ToolStripMenuItem(Facturacion.Constants.MenuNames.Despachos)
            AddHandler SubMenuDespachos.Click, AddressOf OnSubMenuDespachos_CLick

            Dim SubMenuTesoreria As New ToolStripMenuItem(Facturacion.Constants.MenuNames.Tesoreria)
            AddHandler SubMenuTesoreria.Click, AddressOf OnSubMenuTesoreria_CLick

            Dim SubMenuCuentasCorrientes As New ToolStripMenuItem(Facturacion.Constants.MenuNames.CuentasCorrientes)
            AddHandler SubMenuCuentasCorrientes.Click, AddressOf OnSubMenuCuentasCorrientes_CLick

            Dim SubMenuActivosFijos As New ToolStripMenuItem(Facturacion.Constants.MenuNames.ActivosFijos)
            AddHandler SubMenuActivosFijos.Click, AddressOf OnSubMenuActivosFijos_CLick

            'Dim itemUsuarios As New ToolStripMenuItem(Constants.MenuNames.Usuarios)
            'Dim itemArticulos As New ToolStripMenuItem(Constants.MenuNames.Articulos)
            'Dim itemSitios As New ToolStripMenuItem(Constants.MenuNames.Sitios)
            'Dim itemPersonas As New ToolStripMenuItem(Constants.MenuNames.Personas)
            'Dim itemUnidades As New ToolStripMenuItem(Constants.MenuNames.Unidades)
            'Dim itemDivisas As New ToolStripMenuItem(Constants.MenuNames.Divisas)
            'Dim itemDatos As New ToolStripMenuItem(Constants.MenuNames.Datos)

            'AddHandler itemUsuarios.Click, AddressOf OnClick
            'AddHandler itemArticulos.Click, AddressOf OnClick
            'AddHandler itemSitios.Click, AddressOf OnClick
            'AddHandler itemPersonas.Click, AddressOf OnClick
            'AddHandler itemUnidades.Click, AddressOf OnClick
            'AddHandler itemDivisas.Click, AddressOf OnClick
            'AddHandler itemDatos.Click, AddressOf OnClick

            'SubMenuPrincipal.DropDownItems.Add(itemUsuarios)
            'SubMenuPrincipal.DropDownItems.Add(itemArticulos)
            'SubMenuPrincipal.DropDownItems.Add(itemSitios)
            'SubMenuPrincipal.DropDownItems.Add(itemPersonas)
            'SubMenuPrincipal.DropDownItems.Add(itemUnidades)
            'SubMenuPrincipal.DropDownItems.Add(itemDivisas)
            'SubMenuPrincipal.DropDownItems.Add(itemDatos)


            'Me.MenuService.RegistrarMenu(Constants.MenuNames.Mantenimiento, SubMenuPrincipal)

            If Not vmB Then
                SubMenuMaestros_ = SubMenuNulo
            Else
                SubMenuMaestros_ = SubMenuMaestros
            End If

            If Not vmC Then
                SubMenuFacturacion_ = SubMenuNulo
            Else
                SubMenuFacturacion_ = SubMenuFacturacion
            End If

            If Not vmD Then
                SubMenuDespachos_ = SubMenuNulo
            Else
                SubMenuDespachos_ = SubMenuDespachos
            End If

            If Not vmE Then
                SubMenuTesoreria_ = SubMenuNulo
            Else
                SubMenuTesoreria_ = SubMenuTesoreria
            End If

            If Not vmF Then
                SubMenuCuentasCorrientes_ = SubMenuNulo
            Else
                SubMenuCuentasCorrientes_ = SubMenuCuentasCorrientes
            End If

            If Not vmG Then
                SubMenuActivosFijos_ = SubMenuNulo
            Else
                SubMenuActivosFijos_ = SubMenuActivosFijos
            End If

            Me.ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(SubMenuMaestros_)
            Me.ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(SubMenuFacturacion_)
            Me.ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(SubMenuDespachos_)
            Me.ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(SubMenuTesoreria_)
            Me.ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(SubMenuCuentasCorrientes_)
            Me.ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(SubMenuActivosFijos_)

            Me.ContainerService.Resolve(Of MainWindow)().Text = Me.SessionService.NombreEmpresa & ", RUC: " & Me.SessionService.RUCEmpresa & ", Conectado desde: " & Me.SessionService.ConectadoDesde & ", " & Me.SessionService.UserTipo & ": " & Me.SessionService.UserName
            'Me.ContainerService.Resolve(Of MainWindow)().BackColor = System.Drawing.Color.OrangeRed
            'Me.ContainerService.Resolve(Of MainWindow)().menuPrincipal.BackColor = System.Drawing.Color.Orange
            'Me.ContainerService.Resolve(Of MainWindow)().ForeColor = System.Drawing.Color.LightSteelBlue

            If Me.SessionService.NombreEmpresa = "Ladrillera El Diamante SAC" Then
                Dim ctl As Control
                Dim ctlMDI As MdiClient

                For Each ctl In Me.ContainerService.Resolve(Of MainWindow)().Controls
                    Try
                        ctlMDI = CType(ctl, MdiClient)
                        ctlMDI.BackColor = Me.ContainerService.Resolve(Of MainWindow)().BackColor
                        ctlMDI.BackgroundImage = Global.My.Resources.Resources.Background01
                        'ctlMDI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
                    Catch exc As InvalidCastException
                    End Try
                Next
            ElseIf Me.SessionService.NombreEmpresa = "Contabilidad" Then
                Dim ctl As Control
                Dim ctlMDI As MdiClient

                For Each ctl In Me.ContainerService.Resolve(Of MainWindow)().Controls
                    Try
                        ctlMDI = CType(ctl, MdiClient)
                        ctlMDI.BackColor = Me.ContainerService.Resolve(Of MainWindow)().ForeColor
                        'ctlMDI.BackgroundImage = Global.My.Resources.Resources.Background01
                        'ctlMDI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
                    Catch exc As InvalidCastException
                    End Try
                Next
            Else
                Dim ctl As Control
                Dim ctlMDI As MdiClient

                For Each ctl In Me.ContainerService.Resolve(Of MainWindow)().Controls
                    Try
                        ctlMDI = CType(ctl, MdiClient)
                        ctlMDI.BackColor = System.Drawing.Color.CadetBlue
                        ctlMDI.BackgroundImage = Global.My.Resources.Resources.Background02
                        'ctlMDI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
                    Catch exc As InvalidCastException
                    End Try
                Next
            End If

        End Sub
        Private Sub OnSubMenuNulo_CLick(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub OnSubMenuMaestros_CLick(ByVal sender As Object, ByVal e As EventArgs)
            RegistrarBarraMaestros()
        End Sub
        Public Sub RegistrarBarraMaestros()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()

            Dim tslTituloMaestro = BuildLabel("Maestro")

            Dim tsbUsuarios_ As New Object
            Dim tsbArticulos_ As New Object
            Dim tsbSitios_ As New Object
            Dim tsbPersonas_ As New Object
            Dim tsbUnidadesTransporte_ As New Object
            Dim tsbDivisas_ As New Object
            Dim tsbDatos_ As New Object

            Dim tsbUsuarios = BuildBoton("tsbUsuarios", "Usuarios", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbUsuarios.Click, AddressOf OnCLick

            Dim tsbArticulos = BuildBoton("tsbArticulos", "Artículos", Global.My.Resources.Resource1._3DS_MAX2)
            AddHandler tsbArticulos.Click, AddressOf OnCLick

            Dim tsbSitios = BuildBoton("tsbSitios", "Sitios", Global.My.Resources.Resource1.Earth_512x512)
            AddHandler tsbSitios.Click, AddressOf OnCLick

            Dim tsbPersonas = BuildBoton("tsbPersonas", "Personas", Global.My.Resources.Resource1._20086231we9w1221_pc)
            AddHandler tsbPersonas.Click, AddressOf OnCLick

            Dim tsbUnidadesTransporte = BuildBoton("tsbUnidadesTransporte", "Unidades", Global.My.Resources.Resource1.Norton_Sytem_Works_2005)
            AddHandler tsbUnidadesTransporte.Click, AddressOf OnCLick

            Dim tsbDivisas = BuildBoton("tsbDivisas", "Divisas", Global.My.Resources.Resource1.Winamp_256x256)
            AddHandler tsbDivisas.Click, AddressOf OnCLick

            Dim tsbDatos = BuildBoton("tsbDatos", "Datos", Global.My.Resources.Resource1.Cyclop_Photoshop_Works)
            AddHandler tsbDatos.Click, AddressOf OnCLick

            If Not vmB01 Then
                tsbUsuarios_ = tsbNulo
            Else
                tsbUsuarios_ = tsbUsuarios
            End If

            If Not vmB02 Then
                tsbArticulos_ = tsbNulo
            Else
                tsbArticulos_ = tsbArticulos
            End If

            If Not vmB03 Then
                tsbSitios_ = tsbNulo
            Else
                tsbSitios_ = tsbSitios
            End If

            If Not vmB04 Then
                tsbPersonas_ = tsbNulo
            Else
                tsbPersonas_ = tsbPersonas
            End If

            If Not vmB05 Then
                tsbUnidadesTransporte_ = tsbNulo
            Else
                tsbUnidadesTransporte_ = tsbUnidadesTransporte
            End If

            If Not vmB06 Then
                tsbDivisas_ = tsbNulo
            Else
                tsbDivisas_ = tsbDivisas
            End If

            If Not vmB07 Then
                tsbDatos_ = tsbNulo
            Else
                tsbDatos_ = tsbDatos
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloMaestro, tss2, tsbUsuarios_, tsbArticulos_, tsbSitios_, tsbPersonas_, tsbUnidadesTransporte_, tsbDivisas_, tsbDatos_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraUsuarios()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()

            Dim tslTituloUsuarios = BuildLabel("Usuarios")

            Dim tsbDatosUsuarios_ As New Object
            Dim tsbPuntoVentaDatosUsuarios_ As New Object

            Dim tsbDatosUsuarios = BuildBoton("tsbDatosUsuarios", "Puntos de venta" & Chr(13) & "asignados", Global.My.Resources.Resource1.Misc_Icons)
            AddHandler tsbDatosUsuarios.Click, AddressOf OnCLick

            Dim tsbPuntoVentaDatosUsuarios = BuildBoton("tsbPuntoVentaDatosUsuarios", "Series" & Chr(13) & "asignadas", Global.My.Resources.Resource1.Misc_Icons)
            AddHandler tsbPuntoVentaDatosUsuarios.Click, AddressOf OnCLick

            If Not vmB0101 Then
                tsbDatosUsuarios_ = tsbNulo
            Else
                tsbDatosUsuarios_ = tsbDatosUsuarios
            End If

            If Not vmB0102 Then
                tsbPuntoVentaDatosUsuarios_ = tsbNulo
            Else
                tsbPuntoVentaDatosUsuarios_ = tsbPuntoVentaDatosUsuarios
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloUsuarios, tss1, tsbDatosUsuarios_, tsbPuntoVentaDatosUsuarios_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraArticulos()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tss3 = BuildSeparator()

            Dim tslTituloArticulos = BuildLabel("Artículos")

            Dim tsbPesosArticulos_ As New Object
            Dim tsbRolArticulosTipoArticulos_ As New Object
            Dim tsbRolALmacenTipoArticulos_ As New Object

            Dim tsbPesosArticulos = BuildBoton("tsbPesosArticulos", "Pesos" & Chr(13) & "artículos", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbPesosArticulos.Click, AddressOf OnCLick

            Dim tsbRolArticulosTipoArticulos = BuildBoton("tsbRolArticulosTipoArticulos", "Rol artículo" & Chr(13) & "Tipo artículo", Global.My.Resources.Resource1.Misc_Icons)
            AddHandler tsbRolArticulosTipoArticulos.Click, AddressOf OnCLick

            Dim tsbRolALmacenTipoArticulos = BuildBoton("tsbRolAlmacenTipoArticulos", "Rol almacén" & Chr(13) & "Tipo artículo", Global.My.Resources.Resource1.Misc_Icons)
            AddHandler tsbRolALmacenTipoArticulos.Click, AddressOf OnCLick


            If Not vmB0201 Then
                tsbPesosArticulos_ = tsbNulo
            Else
                tsbPesosArticulos_ = tsbPesosArticulos
            End If

            If Not vmB0202 Then
                tsbRolArticulosTipoArticulos_ = tsbNulo
            Else
                tsbRolArticulosTipoArticulos_ = tsbRolArticulosTipoArticulos
            End If

            If Not vmB0203 Then
                tsbRolALmacenTipoArticulos_ = tsbNulo
            Else
                tsbRolALmacenTipoArticulos_ = tsbRolALmacenTipoArticulos
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloArticulos, tss2, tsbPesosArticulos_, tss3, tsbRolArticulosTipoArticulos_, tsbRolALmacenTipoArticulos_})


            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraSitios()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tss3 = BuildSeparator()
            Dim tss4 = BuildSeparator()

            Dim tslTituloSitios = BuildLabel("Sitios")

            Dim tsbPais_ As New Object
            Dim tsbDepartamento_ As New Object
            Dim tsbProvincia_ As New Object
            Dim tsbDistrito_ As New Object
            Dim tsbPuntoVenta_ As New Object
            Dim tsbRolPuntoVentaAlmacen_ As New Object

            Dim tsbPais = BuildBoton("tsbPais", "País", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbPais.Click, AddressOf OnCLick

            Dim tsbDepartamento = BuildBoton("tsbDepartamento", "Departamento", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDepartamento.Click, AddressOf OnCLick

            Dim tsbProvincia = BuildBoton("tsbProvincia", "Provincia", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbProvincia.Click, AddressOf OnCLick

            Dim tsbDistrito = BuildBoton("tsbDistrito", "Distrito", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDistrito.Click, AddressOf OnCLick

            Dim tsbPuntoVenta = BuildBoton("tsbPuntoVenta", "Punto venta", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbPuntoVenta.Click, AddressOf OnCLick

            Dim tsbRolPuntoVentaAlmacen = BuildBoton("tsbRolPuntoVentaAlmacen", "Rol punto de venta" & Chr(13) & "almacén", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbRolPuntoVentaAlmacen.Click, AddressOf OnCLick

            If Not vmB0301 Then
                tsbPais_ = tsbNulo
            Else
                tsbPais_ = tsbPais
            End If

            If Not vmB0302 Then
                tsbDepartamento_ = tsbNulo
            Else
                tsbDepartamento_ = tsbDepartamento
            End If

            If Not vmB0303 Then
                tsbProvincia_ = tsbNulo
            Else
                tsbProvincia_ = tsbProvincia
            End If

            If Not vmB0304 Then
                tsbDistrito_ = tsbNulo
            Else
                tsbDistrito_ = tsbDistrito
            End If

            If Not vmB0305 Then
                tsbPuntoVenta_ = tsbNulo
            Else
                tsbPuntoVenta_ = tsbPuntoVenta
            End If

            If Not vmB0306 Then
                tsbRolPuntoVentaAlmacen_ = tsbNulo
            Else
                tsbRolPuntoVentaAlmacen_ = tsbRolPuntoVentaAlmacen
            End If


            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloSitios, tss2, tsbPais_, tsbDepartamento_, tsbProvincia_, tsbDistrito_, tss3, tsbPuntoVenta_, tss4, tsbRolPuntoVentaAlmacen_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraPersonas()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tss3 = BuildSeparator()

            Dim tslTituloPersonas = BuildLabel("Personas")

            Dim tsbTipoPersonas_ As New Object
            Dim tsbTipoDocPersonas_ As New Object
            Dim tsbPersonas1_ As New Object
            Dim tsbDocPersonas_ As New Object
            Dim tsbDireccionesPersonas_ As New Object
            Dim tsbContactoPersona_ As New Object
            Dim tsbRolPersonasTipoPersona_ As New Object
            Dim tsbBloqueosCodigoPersona_ As New Object
            Dim tsbSancion_ As New Object
            Dim tsbFaltaSancion_ As New Object
            Dim tsbReporteSanciones_ As New Object
            Dim tsbBloqueoVendedor_ As New Object

            Dim tsbTipoPersonas = BuildBoton("tsbTipoPersonas", "Tipo " & Chr(13) & "de persona", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbTipoPersonas.Click, AddressOf OnCLick

            Dim tsbTipoDocPersonas = BuildBoton("tsbTipoDocPersonas", "Tipo de Doc. " & Chr(13) & "de personas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbTipoDocPersonas.Click, AddressOf OnCLick

            Dim tsbPersonas1 = BuildBoton("tsbPersonas1", "Personas ", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbPersonas1.Click, AddressOf OnCLick

            Dim tsbDocPersonas = BuildBoton("tsbDocPersonas", "Documentos " & Chr(13) & "de personas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDocPersonas.Click, AddressOf OnCLick

            Dim tsbDireccionesPersonas = BuildBoton("tsbDireccionesPersonas", "Direcciones " & Chr(13) & "de personas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDireccionesPersonas.Click, AddressOf OnCLick

            Dim tsbContactoPersona = BuildBoton("tsbContactoPersona", "Contacto " & Chr(13) & "de la persona", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbContactoPersona.Click, AddressOf OnCLick

            Dim tsbRolPersonasTipoPersona = BuildBoton("tsbRolPersonaTipoPersona", "Roles de " & Chr(13) & "personas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbRolPersonasTipoPersona.Click, AddressOf OnCLick

            Dim tsbBloqueosCodigoPersona = BuildBoton("tsbBloqueosCodigoPersona", "Bloqueo de " & Chr(13) & "persona", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbBloqueosCodigoPersona.Click, AddressOf OnCLick

            Dim tsbSancion = BuildBoton("tsbSancion", "Sancion de " & Chr(13) & "persona", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbSancion.Click, AddressOf OnCLick

            Dim tsbFaltaSancion = BuildBoton("tsbFaltaSancion", "Falta de Sancion " & Chr(13) & "persona", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbFaltaSancion.Click, AddressOf OnCLick

            Dim tsbReporteSanciones = BuildBoton("tsbReporteSanciones", "Reporte de Sanciones " & Chr(13) & "", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbReporteSanciones.Click, AddressOf OnCLick

            Dim tsbBloqueoVendedor = BuildBoton("tsbBloqueoVendedor", "Bloqueo de " & Chr(13) & "vendedor", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbBloqueoVendedor.Click, AddressOf OnCLick

            If Not vmB0401 Then
                tsbTipoPersonas_ = tsbNulo
            Else
                tsbTipoPersonas_ = tsbTipoPersonas
            End If
            If Not vmB0402 Then
                tsbTipoDocPersonas_ = tsbNulo
            Else
                tsbTipoDocPersonas_ = tsbTipoDocPersonas
            End If
            If Not vmB0403 Then
                tsbPersonas1_ = tsbNulo
            Else
                tsbPersonas1_ = tsbPersonas1
            End If
            If Not vmB0404 Then
                tsbDocPersonas_ = tsbNulo
            Else
                tsbDocPersonas_ = tsbDocPersonas
            End If
            If Not vmB0405 Then
                tsbDireccionesPersonas_ = tsbNulo
            Else
                tsbDireccionesPersonas_ = tsbDireccionesPersonas
            End If
            If Not vmB0406 Then
                tsbContactoPersona_ = tsbNulo
            Else
                tsbContactoPersona_ = tsbContactoPersona
            End If
            If Not vmB0407 Then
                tsbRolPersonasTipoPersona_ = tsbNulo
            Else
                tsbRolPersonasTipoPersona_ = tsbRolPersonasTipoPersona
            End If
            If Not vmB0408 Then
                tsbBloqueosCodigoPersona_ = tsbNulo
            Else
                tsbBloqueosCodigoPersona_ = tsbBloqueosCodigoPersona
            End If
            If Not vmB0409 Then
                tsbSancion_ = tsbNulo
            Else
                tsbSancion_ = tsbSancion
            End If
            If Not vmB0410 Then
                tsbFaltaSancion_ = tsbNulo
            Else
                tsbFaltaSancion_ = tsbFaltaSancion
            End If
            If Not vmB0411 Then
                tsbReporteSanciones_ = tsbNulo
            Else
                tsbReporteSanciones_ = tsbReporteSanciones
            End If
            If Not vmB0412 Then
                tsbBloqueoVendedor_ = tsbNulo
            Else
                tsbBloqueoVendedor_ = tsbBloqueoVendedor
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloPersonas, tss2, tsbTipoPersonas_, tsbTipoDocPersonas_, tss3, tsbPersonas1_, tsbDocPersonas_, tsbDireccionesPersonas_, tsbContactoPersona_, tsbRolPersonasTipoPersona_, tsbBloqueosCodigoPersona_, tsbSancion_, tsbFaltaSancion_, tsbReporteSanciones_, tsbBloqueoVendedor_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraUnidadesTransporte()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tss3 = BuildSeparator()
            Dim tss4 = BuildSeparator()

            Dim tslTituloUnidadesTransporte1 = BuildLabel("Unidades")

            Dim tsbTipoUnidad_ As New Object
            Dim tsbConfiguracionVehicular_ As New Object
            Dim tsbUnidadesTransporte1_ As New Object
            Dim tsbPlacas_ As New Object

            Dim tsbTipoUnidad = BuildBoton("tsbTipoUnidad", "Datos " & Chr(13) & "tipo unidad", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbTipoUnidad.Click, AddressOf OnCLick

            Dim tsbConfiguracionVehicular = BuildBoton("tsbConfiguracionVehicular", "Datos " & Chr(13) & "configuración vehícular", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbConfiguracionVehicular.Click, AddressOf OnCLick

            Dim tsbUnidadesTransporte1 = BuildBoton("tsbUnidadesTransporte1", "Datos " & Chr(13) & "de unidades", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbUnidadesTransporte1.Click, AddressOf OnCLick

            Dim tsbPlacas = BuildBoton("tsbPlacas", "Datos " & Chr(13) & "de placas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbPlacas.Click, AddressOf OnCLick

            If Not vmB0501 Then
                tsbTipoUnidad_ = tsbNulo
            Else
                tsbTipoUnidad_ = tsbTipoUnidad
            End If
            If Not vmB0502 Then
                tsbConfiguracionVehicular_ = tsbNulo
            Else
                tsbConfiguracionVehicular_ = tsbConfiguracionVehicular
            End If
            If Not vmB0503 Then
                tsbUnidadesTransporte1_ = tsbNulo
            Else
                tsbUnidadesTransporte1_ = tsbUnidadesTransporte1
            End If
            If Not vmB0504 Then
                tsbPlacas_ = tsbNulo
            Else
                tsbPlacas_ = tsbPlacas
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloUnidadesTransporte1, tss2, tsbTipoUnidad_, tsbConfiguracionVehicular_, tss3, tsbUnidadesTransporte1_, tsbPlacas_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraDivisas()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()
            Dim tslTituloDivisas = BuildLabel("Divisas")

            Dim tsbMoneda_ As New Object
            Dim tsbTipoCambioMoneda_ As New Object

            Dim tsbMoneda = BuildBoton("tsbMoneda", "Moneda", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbMoneda.Click, AddressOf OnCLick

            Dim tsbTipoCambioMoneda = BuildBoton("tsbTipoCambioMoneda", "Tipo cambio moneda", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbTipoCambioMoneda.Click, AddressOf OnCLick

            If Not vmB0601 Then
                tsbMoneda_ = tsbNulo
            Else
                tsbMoneda_ = tsbMoneda
            End If
            If Not vmB0602 Then
                tsbTipoCambioMoneda_ = tsbNulo
            Else
                tsbTipoCambioMoneda_ = tsbTipoCambioMoneda
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloDivisas, tss1, tsbMoneda_, tsbTipoCambioMoneda_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraDatos()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tss3 = BuildSeparator()
            Dim tslTituloDatos = BuildLabel("Datos")

            Dim tsbTipoDocumentos_ As New Object
            Dim tsbRolOpeCtaCte_ As New Object
            Dim tsbCorrelativoTipoDocumento_ As New Object
            Dim tsbCierre_ As New Object
            Dim tsbCierreDiario_ As New Object
            Dim tsbCentroCostos_ As New Object

            Dim tsbTipoDocumentos = BuildBoton("tsbTipoDocumentos", "Tipos de " & Chr(13) & "documentos", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbTipoDocumentos.Click, AddressOf OnCLick

            Dim tsbRolOpeCtaCte = BuildBoton("tsbRolOpeCtaCte", "Roles de" & Chr(13) & "Cta. Cte.", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbRolOpeCtaCte.Click, AddressOf OnCLick

            Dim tsbCorrelativoTipoDocumento = BuildBoton("tsbCorrelativoTipoDocumento", "Correlativos", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbCorrelativoTipoDocumento.Click, AddressOf OnCLick

            Dim tsbCierre = BuildBoton("tsbCierre", "Cierre de" & Chr(13) & "mes", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbCierre.Click, AddressOf OnCLick

            Dim tsbCierreDiario = BuildBoton("tsbCierreDiario", "Cierre " & Chr(13) & "diario", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbCierreDiario.Click, AddressOf OnCLick

            Dim tsbCentroCostos = BuildBoton("tsbCentroCostos", "Centro " & Chr(13) & "costos", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbCentroCostos.Click, AddressOf OnCLick


            If Not vmB0701 Then
                tsbTipoDocumentos_ = tsbNulo
            Else
                tsbTipoDocumentos_ = tsbTipoDocumentos
            End If
            If Not vmB0702 Then
                tsbRolOpeCtaCte_ = tsbNulo
            Else
                tsbRolOpeCtaCte_ = tsbRolOpeCtaCte
            End If
            If Not vmB0703 Then
                tsbCorrelativoTipoDocumento_ = tsbNulo
            Else
                tsbCorrelativoTipoDocumento_ = tsbCorrelativoTipoDocumento
            End If
            If Not vmB0704 Then
                tsbCierre_ = tsbNulo
            Else
                tsbCierre_ = tsbCierre
            End If
            If Not vmB0705 Then
                tsbCierreDiario_ = tsbNulo
            Else
                tsbCierreDiario_ = tsbCierreDiario
            End If
            If Not vmB0706 Then
                tsbCentroCostos_ = tsbNulo
            Else
                tsbCentroCostos_ = tsbCentroCostos
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloDatos, tss2, tsbTipoDocumentos_, tsbRolOpeCtaCte_, tss3, tsbCorrelativoTipoDocumento_, tsbCierre_, tsbCierreDiario_, tsbCentroCostos})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub

        Private Sub OnSubMenuFacturacion_CLick(ByVal sender As Object, ByVal e As EventArgs)
            RegistrarBarraFacturacion()
        End Sub
        Public Sub RegistrarBarraFacturacion()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()

            Dim tslTituloFacturacion = BuildLabel("Facturación")

            Dim tsbArticulosFacturacion_ As New Object
            Dim tsbDatosFacturacion_ As New Object
            Dim tsbProcesosFacturacion_ As New Object
            Dim tsbNotasFacturacion_ As New Object
            Dim tsbReportesFacturacion_ As New Object

            Dim tsbArticulosFacturacion = BuildBoton("tsbArticulosFacturacion", "Artículos", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbArticulosFacturacion.Click, AddressOf OnCLick

            Dim tsbDatosFacturacion = BuildBoton("tsbDatosFacturacion", "Datos", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbDatosFacturacion.Click, AddressOf OnCLick

            Dim tsbProcesosFacturacion = BuildBoton("tsbProcesosFacturacion", "Procesos", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbProcesosFacturacion.Click, AddressOf OnCLick

            Dim tsbNotasFacturacion = BuildBoton("tsbNotasFacturacion", "Nota C/D", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbNotasFacturacion.Click, AddressOf OnCLick

            Dim tsbReportesFacturacion = BuildBoton("tsbReportesFacturacion", "Reportes", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbReportesFacturacion.Click, AddressOf OnCLick

            If Not vmC01 Then
                tsbArticulosFacturacion_ = tsbNulo
            Else
                tsbArticulosFacturacion_ = tsbArticulosFacturacion
            End If
            If Not vmC02 Then
                tsbDatosFacturacion_ = tsbNulo
            Else
                tsbDatosFacturacion_ = tsbDatosFacturacion
            End If
            If Not vmC03 Then
                tsbProcesosFacturacion_ = tsbNulo
            Else
                tsbProcesosFacturacion_ = tsbProcesosFacturacion
            End If
            If Not vmC04 Then
                tsbNotasFacturacion_ = tsbNulo
            Else
                tsbNotasFacturacion_ = tsbNotasFacturacion
            End If
            If Not vmC05 Then
                tsbReportesFacturacion_ = tsbNulo
            Else
                tsbReportesFacturacion_ = tsbReportesFacturacion
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloFacturacion, tss2, tsbArticulosFacturacion_, tsbDatosFacturacion_, tsbProcesosFacturacion_, tsbNotasFacturacion_, tsbReportesFacturacion_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraArticulosFacturacion()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloArticulosFacturación = BuildLabel("Artículos" & Chr(13) & "facturación")

            Dim tsbRestriccionArticulo_ As New Object

            Dim tsbRestriccionArticulo = BuildBoton("tsbRestriccionArticulo", "Restricción de " & Chr(13) & "artículos", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbRestriccionArticulo.Click, AddressOf OnCLick

            If Not vmC0101 Then
                tsbRestriccionArticulo_ = tsbNulo
            Else
                tsbRestriccionArticulo_ = tsbRestriccionArticulo
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloArticulosFacturación, tss1, tsbRestriccionArticulo_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraDatosFacturacion()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloDatosFacturación = BuildLabel("Datos" & Chr(13) & "facturación")

            Dim tsbComision_ As New Object
            Dim tsbFletesTransportes_ As New Object

            Dim tsbComision = BuildBoton("tsbComision", "Comisión " & Chr(13) & "de persona", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbComision.Click, AddressOf OnCLick

            Dim tsbFletesTransportes = BuildBoton("tsbFletesTransportes", "Fletes de " & Chr(13) & "transportes", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbFletesTransportes.Click, AddressOf OnCLick

            If Not vmC0201 Then
                tsbComision_ = tsbNulo
            Else
                tsbComision_ = tsbComision
            End If
            If Not vmC0202 Then
                tsbFletesTransportes_ = tsbNulo
            Else
                tsbFletesTransportes_ = tsbFletesTransportes
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloDatosFacturación, tss1, tsbComision_, tsbFletesTransportes_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraProcesosFacturacion()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tss3 = BuildSeparator()
            Dim tss4 = BuildSeparator()
            Dim tss5 = BuildSeparator()
            Dim tss6 = BuildSeparator()

            Dim tslTituloProcesosFacturación = BuildLabel("Procesos" & Chr(13) & "facturación")

            Dim tsbCotizacionBoletaFactura_ As New Object
            Dim tsbPedidoBoletaFactura_ As New Object
            Dim tsbTipoVentaBoletaFactura_ As New Object
            'Dim tsbProformaBoletas_ As New Object
            'Dim tsbProformaFacturas_ As New Object
            'Dim tsbOrdenCompraBoletas_ As New Object
            'Dim tsbOrdenCompraFacturas_ As New Object
            Dim tsbBoletas_ As New Object
            Dim tsbFacturas_ As New Object

            Dim tsbDocumentoPromocion_ As New Object
            Dim tsbSolicitudAjustePrecio_ As New Object

            Dim tsbCotizacionBoletaFactura = BuildBoton("tsbCotizacionBoletaFactura", "Cotización " & Chr(13) & "boleta/factura", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbCotizacionBoletaFactura.Click, AddressOf OnCLick

            Dim tsbPedidoBoletaFactura = BuildBoton("tsbPedidoBoletaFactura", "Pedido " & Chr(13) & "boleta/factura", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbPedidoBoletaFactura.Click, AddressOf OnCLick

            Dim tsbTipoVentaBoletaFactura = BuildBoton("tsbTipoVentaBoletaFactura", "Dar pase a" & Chr(13) & "Bol./Fact./Ped.", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbTipoVentaBoletaFactura.Click, AddressOf OnCLick

            'Dim tsbProformaBoletas = BuildBoton("tsbProformaBoletas", "Proforma " & Chr(13) & "de boletas", Global.My.Resources.Resource1.Drawing)
            'AddHandler tsbProformaBoletas.Click, AddressOf OnCLick

            'Dim tsbProformaFacturas = BuildBoton("tsbProformaFacturas", "Proforma " & Chr(13) & "de facturas", Global.My.Resources.Resource1.Drawing)
            'AddHandler tsbProformaFacturas.Click, AddressOf OnCLick

            'Dim tsbOrdenCompraBoletas = BuildBoton("tsbOrdenCompraBoletas", "Orden compra " & Chr(13) & "de boletas", Global.My.Resources.Resource1.Drawing)
            'AddHandler tsbOrdenCompraBoletas.Click, AddressOf OnCLick

            'Dim tsbOrdenCompraFacturas = BuildBoton("tsbOrdenCompraFacturas", "Orden compra " & Chr(13) & "de facturas", Global.My.Resources.Resource1.Drawing)
            'AddHandler tsbOrdenCompraFacturas.Click, AddressOf OnCLick

            Dim tsbBoletas = BuildBoton("tsbBoletas", "Boletas " & Chr(13) & "de ventas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbBoletas.Click, AddressOf OnCLick

            Dim tsbFacturas = BuildBoton("tsbFacturas", "Facturas " & Chr(13) & "de ventas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbFacturas.Click, AddressOf OnCLick

            Dim tsbDocumentoPromocion = BuildBoton("tsbDocumentoPromocion", "Documento " & Chr(13) & "promoción", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDocumentoPromocion.Click, AddressOf OnCLick

            Dim tsbSolicitudAjustePrecio = BuildBoton("tsbSolicitudAjustePrecio", "Solicitud " & Chr(13) & "Ajuste Precio", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbSolicitudAjustePrecio.Click, AddressOf OnCLick

            If Not vmC0301 Then
                tsbPedidoBoletaFactura_ = tsbNulo
            Else
                tsbPedidoBoletaFactura_ = tsbPedidoBoletaFactura
            End If
            If Not vmC0302 Then
                tsbTipoVentaBoletaFactura_ = tsbNulo
            Else
                tsbTipoVentaBoletaFactura_ = tsbTipoVentaBoletaFactura
            End If
            'If Not vmC0303 Then
            'tsbOrdenCompraBoletas_ = tsbNulo
            'Else
            'tsbOrdenCompraBoletas_ = tsbOrdenCompraBoletas
            'tsbOrdenCompraBoletas_ = tsbNulo
            'End If
            'If Not vmC0304 Then
            'tsbOrdenCompraFacturas_ = tsbNulo
            'Else
            'tsbOrdenCompraFacturas_ = tsbOrdenCompraFacturas
            'tsbOrdenCompraFacturas_ = tsbNulo
            'End If
            If Not vmC0305 Then
                tsbBoletas_ = tsbNulo
            Else
                tsbBoletas_ = tsbBoletas
            End If
            If Not vmC0306 Then
                tsbFacturas_ = tsbNulo
            Else
                tsbFacturas_ = tsbFacturas
            End If
            If Not vmC0307 Then
                tsbDocumentoPromocion_ = tsbNulo
            Else
                tsbDocumentoPromocion_ = tsbDocumentoPromocion
            End If
            If Not vmC0308 Then
                tsbCotizacionBoletaFactura_ = tsbNulo
            Else
                tsbCotizacionBoletaFactura_ = tsbCotizacionBoletaFactura
            End If
            If Not vmC0309 Then
                tsbSolicitudAjustePrecio_ = tsbNulo
            Else
                tsbSolicitudAjustePrecio_ = tsbSolicitudAjustePrecio
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloProcesosFacturación, tss2, tsbCotizacionBoletaFactura, tss3, tsbPedidoBoletaFactura_, tsbTipoVentaBoletaFactura_, tss4, tsbBoletas_, tsbFacturas_, tss5, tsbDocumentoPromocion_, tss6, tsbSolicitudAjustePrecio_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraNotasFacturacion()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloNotaFacturación = BuildLabel("Nota C/D" & Chr(13) & "facturación")

            Dim tsbNotaCredito_ As New Object
            Dim tsbNotaDebito_ As New Object

            Dim tsbNotaCreditoConsulta_ As New Object
            Dim tsbNotaDebitoConsulta_ As New Object

            Dim tsbNotaCredito = BuildBoton("tsbNotaCredito", "Nota " & Chr(13) & "de crédito", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbNotaCredito.Click, AddressOf OnCLick

            Dim tsbNotaDebito = BuildBoton("tsbNotaDebito", "Nota " & Chr(13) & "de débito", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbNotaDebito.Click, AddressOf OnCLick

            Dim tsbNotaCreditoConsulta = BuildBoton("tsbNotaCreditoConsulta", "Consulta nota " & Chr(13) & "de crédito", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbNotaCreditoConsulta.Click, AddressOf OnCLick

            Dim tsbNotaDebitoConsulta = BuildBoton("tsbNotaDebitoConsulta", "Consulta nota " & Chr(13) & "de débito", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbNotaDebitoConsulta.Click, AddressOf OnCLick

            If Not vmC0401 Then
                tsbNotaCredito_ = tsbNulo
            Else
                tsbNotaCredito_ = tsbNotaCredito
            End If
            If Not vmC0402 Then
                tsbNotaDebito_ = tsbNulo
            Else
                tsbNotaDebito_ = tsbNotaDebito
            End If
            If Not vmC0403 Then
                tsbNotaCreditoConsulta_ = tsbNulo
            Else
                tsbNotaCreditoConsulta_ = tsbNotaCreditoConsulta
            End If
            If Not vmC0404 Then
                tsbNotaDebitoConsulta_ = tsbNulo
            Else
                tsbNotaDebitoConsulta_ = tsbNotaDebitoConsulta
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloNotaFacturación, tss1, tsbNotaCredito_, tsbNotaDebito_, tsbNotaCreditoConsulta_, tsbNotaDebitoConsulta_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraReportesFacturacion()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloReportesFacturación = BuildLabel("Reportes" & Chr(13) & "facturación")

            Dim tsbDocumentosEmitidos_ As New Object
            Dim tsbPendientesAtencion_ As New Object
            Dim tsbEntregaDespachos_ As New Object
            Dim tsbToneladasMillaresVentas_ As New Object
            Dim tsbDetalleVentaPorArticulo_ As New Object
            Dim tsbDocumentosEmitidosPorPromotor_ As New Object
            Dim tsbReporteAnalisisVentas_ As New Object
            Dim tsbPedidosEmitidos_ As New Object
            Dim tsbEstadoDeDocumentosFechasVentas_ As New Object
            Dim tsbConsultaPedidos_ As New Object
            Dim tsbReporteVentas_ As New Object
            Dim tsbReporteAsistencia_ As New Object

            Dim tsbDocumentosEmitidos = BuildBoton("tsbDocumentosEmitidos", "Documentos " & Chr(13) & "emitidos", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDocumentosEmitidos.Click, AddressOf OnCLick

            Dim tsbPedidosEmitidos = BuildBoton("tsbPedidosEmitidos", "Pedidos " & Chr(13) & "emitidos", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbPedidosEmitidos.Click, AddressOf OnCLick

            Dim tsbEntregaDespachos = BuildBoton("tsbEntregaDespachos", "Guías/NC/ND " & Chr(13) & "emitidas de BV/FT", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbEntregaDespachos.Click, AddressOf OnCLick

            Dim tsbToneladasMillaresVentas = BuildBoton("tsbToneladasMillaresVentas", "Tn./Millar " & Chr(13) & "ventas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbToneladasMillaresVentas.Click, AddressOf OnCLick

            Dim tsbDetalleVentaPorArticulo = BuildBoton("tsbDetalleVentaPorArticulo", "Ventas por" & Chr(13) & "artículo", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDetalleVentaPorArticulo.Click, AddressOf OnCLick

            Dim tsbDocumentosEmitidosPorPromotor = BuildBoton("tsbDocumentosEmitidosPorPromotor", "Ventas por" & Chr(13) & "promotor", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDocumentosEmitidosPorPromotor.Click, AddressOf OnCLick

            Dim tsbReporteAnalisisVentas = BuildBoton("tsbReporteAnalisisVentas", "Analisis de" & Chr(13) & "Ventas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbReporteAnalisisVentas.Click, AddressOf OnCLick

            Dim tsbPendientesAtencion = BuildBoton("tsbPendientesAtencion", "Pendientes " & Chr(13) & "atención", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbPendientesAtencion.Click, AddressOf OnCLick

            Dim tsbEstadoDeDocumentosFechasVentas = BuildBoton("tsbEstadoDeDocumentosFechasVentas", "Estado De Documentos Fechas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbEstadoDeDocumentosFechasVentas.Click, AddressOf OnCLick

            Dim tsbConsultaPedidos = BuildBoton("tsbConsultaPedidos", "Consulta de" & Chr(13) & "pedidos", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbConsultaPedidos.Click, AddressOf OnCLick

            Dim tsbReporteVentas = BuildBoton("tsbReporteVentas", "Reporte" & Chr(13) & "análisis", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbReporteVentas.Click, AddressOf OnCLick

            Dim tsbReporteAsistencia = BuildBoton("tsbReporteAsistencia", "Reporte" & Chr(13) & "asistencia", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbReporteAsistencia.Click, AddressOf OnCLick

            If Not vmC0501 Then
                tsbDocumentosEmitidos_ = tsbNulo
            Else
                tsbDocumentosEmitidos_ = tsbDocumentosEmitidos
            End If
            If Not vmC0502 Then
                tsbPendientesAtencion_ = tsbNulo
            Else
                tsbPendientesAtencion_ = tsbPendientesAtencion
            End If
            If Not vmC0503 Then
                tsbEntregaDespachos_ = tsbNulo
            Else
                tsbEntregaDespachos_ = tsbEntregaDespachos
            End If
            If Not vmC0504 Then
                tsbToneladasMillaresVentas_ = tsbNulo
            Else
                tsbToneladasMillaresVentas_ = tsbToneladasMillaresVentas
            End If
            If Not vmC0505 Then
                tsbDetalleVentaPorArticulo_ = tsbNulo
            Else
                tsbDetalleVentaPorArticulo_ = tsbDetalleVentaPorArticulo
            End If

            If Not vmC0506 Then
                tsbDocumentosEmitidosPorPromotor_ = tsbNulo
            Else
                tsbDocumentosEmitidosPorPromotor_ = tsbDocumentosEmitidosPorPromotor
            End If

            If Not vmC0507 Then
                tsbReporteAnalisisVentas_ = tsbNulo
            Else
                tsbReporteAnalisisVentas_ = tsbReporteAnalisisVentas
            End If

            If Not vmC0508 Then
                tsbPedidosEmitidos_ = tsbNulo
            Else
                tsbPedidosEmitidos_ = tsbPedidosEmitidos
            End If

            If Not vmC0509 Then
                tsbEstadoDeDocumentosFechasVentas_ = tsbNulo
            Else
                tsbEstadoDeDocumentosFechasVentas_ = tsbEstadoDeDocumentosFechasVentas
            End If

            If Not vmC0510 Then
                tsbConsultaPedidos_ = tsbNulo
            Else
                tsbConsultaPedidos_ = tsbConsultaPedidos
            End If

            If Not vmC0511 Then
                tsbReporteVentas_ = tsbNulo
            Else
                tsbReporteVentas_ = tsbReporteVentas
            End If

            If Not vmC0512 Then
                tsbReporteAsistencia_ = tsbNulo
            Else
                tsbReporteAsistencia_ = tsbReporteAsistencia
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloReportesFacturación, tss1, tsbDocumentosEmitidos_, tsbPendientesAtencion_, tsbEntregaDespachos_, tsbToneladasMillaresVentas_, tsbDetalleVentaPorArticulo_, tsbDocumentosEmitidosPorPromotor_, tsbReporteAnalisisVentas_, tsbPedidosEmitidos_, tsbEstadoDeDocumentosFechasVentas_, tsbConsultaPedidos_, tsbReporteVentas_, tsbReporteAsistencia_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub

        Private Sub OnSubMenuDespachos_CLick(ByVal sender As Object, ByVal e As EventArgs)
            RegistrarBarraDespachos()
        End Sub
        Public Sub RegistrarBarraDespachos()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()
            Dim tslTituloDespachos = BuildLabel("Despachos")

            Dim tsbProcesosDespachos_ As New Object
            Dim tsbReportesDespachos_ As New Object

            Dim tsbProcesosDespachos = BuildBoton("tsbProcesosDespachos", "Procesos", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbProcesosDespachos.Click, AddressOf OnCLick

            Dim tsbReportesDespachos = BuildBoton("tsbReportesDespachos", "Reportes", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbReportesDespachos.Click, AddressOf OnCLick

            If Not vmD01 Then
                tsbProcesosDespachos_ = tsbNulo
            Else
                tsbProcesosDespachos_ = tsbProcesosDespachos
            End If
            If Not vmD02 Then
                tsbReportesDespachos_ = tsbNulo
            Else
                tsbReportesDespachos_ = tsbReportesDespachos
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloDespachos, tss1, tsbProcesosDespachos_, tsbReportesDespachos_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraProcesosDespachos()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tss3 = BuildSeparator()
            Dim tss4 = BuildSeparator()
            Dim tss5 = BuildSeparator()
            Dim tss6 = BuildSeparator()
            Dim tss7 = BuildSeparator()

            Dim tslTituloProcesosDespachos = BuildLabel("Procesos" & Chr(13) & "Despachos")

            Dim tsbGuiaDespacho_ As New Object
            Dim tsbGuiaDevolucion_ As New Object
            Dim tsbGuiaIngreso_ As New Object
            Dim tsbGuiaSalida_ As New Object
            Dim tsbGuiaTransferencia_ As New Object
            Dim tsbCronogramaDespacho_ As New Object
            Dim tsbGuiaDespachoDesdeDistribuidora_ As New Object
            Dim tsbControlGarita_ As New Object
            Dim tsbControlCarguio_ As New Object
            Dim tsbHabilitarCronogramaDespacho_ As New Object
            Dim tsbVisualizarCronogramaDespacho_ As New Object
            Dim tsbGuiaDevolucionDesdeDistribuidora_ As New Object
            Dim tsbDespachoSalida_ As New Object
            Dim tsbGuiaTransitoPendiente_ As New Object
            Dim tsbOrdenDespacho_ As New Object
            Dim tsbGuiaAutorizada_ As New Object

            Dim tsbGuiaDespacho = BuildBoton("tsbGuiaDespacho", "Guía " & Chr(13) & "de despacho", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbGuiaDespacho.Click, AddressOf OnCLick

            Dim tsbGuiaDevolucion = BuildBoton("tsbGuiaDevolucion", "Guía " & Chr(13) & "de devolución", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbGuiaDevolucion.Click, AddressOf OnCLick

            Dim tsbGuiaIngreso = BuildBoton("tsbGuiaIngreso", "Guía " & Chr(13) & "de ingreso", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbGuiaIngreso.Click, AddressOf OnCLick

            Dim tsbGuiaSalida = BuildBoton("tsbGuiaSalida", "Guía " & Chr(13) & "de salida", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbGuiaSalida.Click, AddressOf OnCLick

            Dim tsbGuiaTransferencia = BuildBoton("tsbGuiaTransferencia", "Guía " & Chr(13) & "de transferencia", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbGuiaTransferencia.Click, AddressOf OnCLick

            Dim tsbCronogramaDespacho = BuildBoton("tsbCronogramaDespacho", "Cronograma " & Chr(13) & "de despacho", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbCronogramaDespacho.Click, AddressOf OnCLick

            Dim tsbGuiaDespachoDesdeDistribuidora = BuildBoton("tsbGuiaDespachoDesdeDistribuidora", "Guía de" & Chr(13) & "despacho desde" & Chr(13) & "la Distribuidora", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbGuiaDespachoDesdeDistribuidora.Click, AddressOf OnCLick

            Dim tsbControlGarita = BuildBoton("tsbControlGarita", "Marcar" & Chr(13) & "hora de salida", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbControlGarita.Click, AddressOf OnCLick

            Dim tsbControlCarguio = BuildBoton("tsbControlCarguio", "Marcar" & Chr(13) & "hora de carga", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbControlCarguio.Click, AddressOf OnCLick

            Dim tsbHabilitarCronogramaDespacho = BuildBoton("tsbHabilitarCronogramaDespacho", "habilitar" & Chr(13) & "cronograma de " & Chr(13) & "despacho", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbHabilitarCronogramaDespacho.Click, AddressOf OnCLick

            Dim tsbVisualizarCronogramaDespacho = BuildBoton("tsbVisualizarCronogramaDespacho", "Visualizar" & Chr(13) & "cronograma de " & Chr(13) & "despacho", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbVisualizarCronogramaDespacho.Click, AddressOf OnCLick

            Dim tsbGuiaDevolucionDesdeDistribuidora = BuildBoton("tsbGuiaDevolucionDesdeDistribuidora", "Guía de" & Chr(13) & "devolución desde" & Chr(13) & "la Distribuidora", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbGuiaDevolucionDesdeDistribuidora.Click, AddressOf OnCLick

            Dim tsbDespachoSalida = BuildBoton("tsbDespachoSalida", "Despacho" & Chr(13) & "Salida", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDespachoSalida.Click, AddressOf OnCLick

            Dim tsbGuiaTransitoPendiente = BuildBoton("tsbGuiaTransitoPendiente", "Guias Transito" & Chr(13) & "Pendiente", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbGuiaTransitoPendiente.Click, AddressOf OnCLick

            Dim tsbOrdenDespacho = BuildBoton("tsbOrdenDespacho", "Orden de " & Chr(13) & "Despacho", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbOrdenDespacho.Click, AddressOf OnCLick

            Dim tsbGuiaAutorizada = BuildBoton("tsbGuiaAutorizada", "Guia " & Chr(13) & "Autorizada", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbGuiaAutorizada.Click, AddressOf OnCLick


            If Not vmD0101 Then
                tsbGuiaDespacho_ = tsbNulo
            Else
                tsbGuiaDespacho_ = tsbGuiaDespacho
            End If
            If Not vmD0102 Then
                tsbGuiaDevolucion_ = tsbNulo
            Else
                tsbGuiaDevolucion_ = tsbGuiaDevolucion
            End If
            If Not vmD0103 Then
                tsbGuiaIngreso_ = tsbNulo
            Else
                tsbGuiaIngreso_ = tsbGuiaIngreso
                tsbGuiaIngreso_ = tsbNulo
            End If
            If Not vmD0104 Then
                tsbGuiaSalida_ = tsbNulo
            Else
                tsbGuiaSalida_ = tsbGuiaSalida
                'tsbGuiaSalida_ = tsbNulo
            End If
            If Not vmD0105 Then
                tsbGuiaTransferencia_ = tsbNulo
            Else
                tsbGuiaTransferencia_ = tsbGuiaTransferencia
            End If

            If Not vmD0106 Then
                tsbCronogramaDespacho_ = tsbNulo
            Else
                tsbCronogramaDespacho_ = tsbCronogramaDespacho
            End If

            If Not vmD0107 Then
                tsbGuiaDespachoDesdeDistribuidora_ = tsbNulo
            Else
                tsbGuiaDespachoDesdeDistribuidora_ = tsbGuiaDespachoDesdeDistribuidora
            End If

            If Not vmD0108 Then
                tsbControlGarita_ = tsbNulo
            Else
                tsbControlGarita_ = tsbControlGarita
            End If

            If Not vmD0109 Then
                tsbControlCarguio_ = tsbNulo
            Else
                tsbControlCarguio_ = tsbControlCarguio
            End If

            If Not vmD0110 Then
                tsbHabilitarCronogramaDespacho_ = tsbNulo
            Else
                tsbHabilitarCronogramaDespacho_ = tsbHabilitarCronogramaDespacho
            End If

            If Not vmD0111 Then
                tsbVisualizarCronogramaDespacho_ = tsbNulo
            Else
                tsbVisualizarCronogramaDespacho_ = tsbVisualizarCronogramaDespacho
            End If

            If Not vmD0112 Then
                tsbGuiaDevolucionDesdeDistribuidora_ = tsbNulo
            Else
                tsbGuiaDevolucionDesdeDistribuidora_ = tsbGuiaDevolucionDesdeDistribuidora
            End If

            If Not vmD0113 Then
                tsbDespachoSalida_ = tsbNulo
            Else
                tsbDespachoSalida_ = tsbDespachoSalida
            End If

            If Not vmD0114 Then
                tsbGuiaTransitoPendiente_ = tsbNulo
            Else
                tsbGuiaTransitoPendiente_ = tsbGuiaTransitoPendiente
            End If

            If Not vmD0115 Then
                tsbOrdenDespacho_ = tsbNulo
            Else
                tsbOrdenDespacho_ = tsbOrdenDespacho
            End If

            If Not vmD0116 Then
                tsbGuiaAutorizada_ = tsbNulo
            Else
                tsbGuiaAutorizada_ = tsbGuiaAutorizada
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloProcesosDespachos, tss2, tss3, tsbGuiaDespacho_, tsbGuiaDevolucion_, tss4, tsbGuiaIngreso_, tsbGuiaSalida_, tsbGuiaTransferencia_, tss5, tsbCronogramaDespacho_, tss6, tsbGuiaDespachoDesdeDistribuidora_, tss7, tsbControlGarita_, tsbControlCarguio_, tsbHabilitarCronogramaDespacho_, tsbVisualizarCronogramaDespacho_, tsbGuiaDevolucionDesdeDistribuidora_, tsbDespachoSalida_, tsbGuiaTransitoPendiente_, tsbOrdenDespacho_, tsbGuiaAutorizada_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraReportesDespachos()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tslTituloReportesDespachos = BuildLabel("Reportes" & Chr(13) & "Despachos")

            Dim tsbKardexDocumento_ As New Object
            Dim tsbTrasladoEntreAlmacenes_ As New Object
            Dim tsbGuiaRemisionTransportista_ As New Object
            Dim tsbReporteGuias_ As New Object
            Dim tsbReporteGuiasProduccion_ As New Object
            Dim tsbReporteCronogramaDespacho_ As New Object
            Dim tsbReporteGuiasSinDocumento_ As New Object
            Dim tsbReporteGuiaRemisionCliente_ As New Object
            Dim tsbReporteGuiasPorSalir_ As New Object
            Dim tsbReporteTransferenciaLadrillo_ As New Object
            Dim tsbReporteGuiaSaleTarde_ As New Object
            Dim tsbReporteOrdenDespacho_ As New Object
            Dim tsbReporteProyeccion_ As New Object

            Dim tsbKardexDocumento = BuildBoton("tsbKardexDocumento", "Kardex" & Chr(13) & "Documento", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbKardexDocumento.Click, AddressOf OnCLick

            Dim tsbTrasladoEntreAlmacenes = BuildBoton("tsbTrasladoEntreAlmacenes", "Traslado" & Chr(13) & "entre Alm.", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbTrasladoEntreAlmacenes.Click, AddressOf OnCLick

            Dim tsbGuiaRemisionTransportista = BuildBoton("tsbGuiaRemisionTransportista", "Guía remisión" & Chr(13) & "por transp.", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbGuiaRemisionTransportista.Click, AddressOf OnCLick

            Dim tsbReporteGuias = BuildBoton("tsbReporteGuias", "Reporte " & Chr(13) & "de guías", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteGuias.Click, AddressOf OnCLick

            Dim tsbReporteGuiasProduccion = BuildBoton("tsbReporteGuiasProduccion", "Reporte guías" & Chr(13) & "producción", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteGuiasProduccion.Click, AddressOf OnCLick

            Dim tsbReporteCronogramaDespacho = BuildBoton("tsbReporteCronogramaDespacho", "Reporte cronograma" & Chr(13) & "de despacho", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteCronogramaDespacho.Click, AddressOf OnCLick

            Dim tsbReporteGuiasSinDocumento = BuildBoton("tsbReporteGuiasSinDocumento", "Reporte Guias Despacho Sin Documento", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteGuiasSinDocumento.Click, AddressOf OnCLick

            Dim tsbReporteGuiaRemisionCliente = BuildBoton("tsbReporteGuiaRemisionCliente", "Reporte Guias Remision del Cliente", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteGuiaRemisionCliente.Click, AddressOf OnCLick

            Dim tsbReporteGuiasPorSalir = BuildBoton("tsbReporteGuiasPorSalir", "Reporte Guias por Salir", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteGuiasPorSalir.Click, AddressOf OnCLick

            Dim tsbReporteTransferenciaLadrillo = BuildBoton("tsbReporteTransferenciaLadrillo", "Reporte Transferencia Ladrillo", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteTransferenciaLadrillo.Click, AddressOf OnCLick

            Dim tsbReporteGuiaSaleTarde = BuildBoton("tsbReporteGuiaSaleTarde", "Reporte Fecha y Hora Salida Guias", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteGuiaSaleTarde.Click, AddressOf OnCLick

            Dim tsbReporteOrdenDespacho = BuildBoton("tsbReporteOrdenDespacho", "Reporte Orden Despacho", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteOrdenDespacho.Click, AddressOf OnCLick

            Dim tsbReporteProyeccion = BuildBoton("tsbReporteProyeccion", "Reporte Proyeccion", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteProyeccion.Click, AddressOf OnCLick

            If Not vmD0201 Then
                tsbKardexDocumento_ = tsbNulo
            Else
                tsbKardexDocumento_ = tsbKardexDocumento
            End If
            If Not vmD0202 Then
                tsbTrasladoEntreAlmacenes_ = tsbNulo
            Else
                tsbTrasladoEntreAlmacenes_ = tsbTrasladoEntreAlmacenes
            End If
            If Not vmD0203 Then
                tsbGuiaRemisionTransportista_ = tsbNulo
            Else
                tsbGuiaRemisionTransportista_ = tsbGuiaRemisionTransportista
            End If
            If Not vmD0204 Then
                tsbReporteGuias_ = tsbNulo
            Else
                tsbReporteGuias_ = tsbReporteGuias
            End If
            If Not vmD0205 Then
                tsbReporteGuiasProduccion_ = tsbNulo
            Else
                tsbReporteGuiasProduccion_ = tsbReporteGuiasProduccion
            End If
            If Not vmD0206 Then
                tsbReporteCronogramaDespacho_ = tsbNulo
            Else
                tsbReporteCronogramaDespacho_ = tsbReporteCronogramaDespacho
            End If
            If Not vmD0207 Then
                tsbReporteGuiasSinDocumento_ = tsbNulo
            Else
                tsbReporteGuiasSinDocumento_ = tsbReporteGuiasSinDocumento
            End If
            If Not vmD0208 Then
                tsbReporteGuiaRemisionCliente_ = tsbNulo
            Else
                tsbReporteGuiaRemisionCliente_ = tsbReporteGuiaRemisionCliente
            End If
            If Not vmD0209 Then
                tsbReporteGuiasPorSalir_ = tsbNulo
            Else
                tsbReporteGuiasPorSalir_ = tsbReporteGuiasPorSalir
            End If
            If Not vmD0210 Then
                tsbReporteTransferenciaLadrillo_ = tsbNulo
            Else
                tsbReporteTransferencialadrillo_ = tsbReporteTransferenciaLadrillo
            End If
            If Not vmD0211 Then
                tsbReporteGuiaSaleTarde_ = tsbNulo
            Else
                tsbReporteGuiaSaleTarde_ = tsbReporteGuiaSaleTarde
            End If
            If Not vmD0212 Then
                tsbReporteOrdenDespacho_ = tsbNulo
            Else
                tsbReporteOrdenDespacho_ = tsbReporteOrdenDespacho
            End If
            If Not vmD0213 Then
                tsbReporteProyeccion_ = tsbNulo
            Else
                tsbReporteProyeccion_ = tsbReporteProyeccion
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloReportesDespachos, tss2, tsbKardexDocumento_, tsbTrasladoEntreAlmacenes_, tsbGuiaRemisionTransportista_, tsbReporteGuias_, tsbReporteGuiasProduccion_, tsbReporteCronogramaDespacho_, tsbReporteGuiasSinDocumento_, tsbReporteGuiaRemisionCliente_, tsbReporteGuiasPorSalir_, tsbReporteTransferenciaLadrillo_, tsbReporteGuiaSaleTarde_, tsbReporteOrdenDespacho_, tsbReporteProyeccion_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub

        Private Sub OnSubMenuTesoreria_CLick(ByVal sender As Object, ByVal e As EventArgs)
            RegistrarBarraTesoreria()
        End Sub
        Public Sub RegistrarBarraTesoreria()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()

            Dim tslTituloTesoreria = BuildLabel("Tesorería")

            Dim tsbDatosTesoreria_ As New Object
            Dim tsbProcesosTesoreria_ As New Object
            Dim tsbReportesTesoreria_ As New Object

            Dim tsbDatosTesoreria = BuildBoton("tsbDatosTesoreria", "Datos", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbDatosTesoreria.Click, AddressOf OnCLick

            Dim tsbProcesosTesoreria = BuildBoton("tsbProcesosTesoreria", "Procesos", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbProcesosTesoreria.Click, AddressOf OnCLick

            Dim tsbReportesTesoreria = BuildBoton("tsbReportesTesoreria", "Reportes", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbReportesTesoreria.Click, AddressOf OnCLick

            If Not vmE01 Then
                tsbDatosTesoreria_ = tsbNulo
            Else
                tsbDatosTesoreria_ = tsbDatosTesoreria
            End If
            If Not vmE02 Then
                tsbProcesosTesoreria_ = tsbNulo
            Else
                tsbProcesosTesoreria_ = tsbProcesosTesoreria
            End If
            If Not vmE03 Then
                tsbReportesTesoreria_ = tsbNulo
            Else
                tsbReportesTesoreria_ = tsbReportesTesoreria
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloTesoreria, tss2, tsbDatosTesoreria_, tsbProcesosTesoreria_, tsbReportesTesoreria_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraDatosTesoreria()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloDatosTesoreria = BuildLabel("Datos" & Chr(13) & "tesorería")

            Dim tsbCajaCtaCte_ As New Object
            Dim tsbCheques_ As New Object
            Dim tsbTesoreriaEditar_ As New Object
            Dim tsbCajeroAnexo_ As New Object

            Dim tsbCajaCtaCte = BuildBoton("tsbCajaCtaCte", "Cuentas corrientes " & Chr(13) & "de caja", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbCajaCtaCte.Click, AddressOf OnCLick

            Dim tsbCheques = BuildBoton("tsbCheques", "Cheques ", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbCheques.Click, AddressOf OnCLick

            Dim tsbTesoreriaEditar = BuildBoton("tsbTesoreriaEditar", "Tesorería " & Microsoft.VisualBasic.ChrW(13) & "editar", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbTesoreriaEditar.Click, AddressOf OnCLick

            Dim tsbCajeroAnexo = BuildBoton("tsbCajeroAnexo", "Caja - Cta. Banco " & Microsoft.VisualBasic.ChrW(13) & "asignada", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbCajeroAnexo.Click, AddressOf OnCLick

            If Not vmE0101 Then
                tsbCajaCtaCte_ = tsbNulo
            Else
                tsbCajaCtaCte_ = tsbCajaCtaCte
            End If
            If Not vmE0102 Then
                tsbCheques_ = tsbNulo
            Else
                tsbCheques_ = tsbCheques
            End If
            If Not vmE0103 Then
                tsbTesoreriaEditar_ = tsbNulo
            Else
                tsbTesoreriaEditar_ = tsbTesoreriaEditar
            End If
            If Not vmE0104 Then
                tsbCajeroAnexo_ = tsbNulo
            Else
                tsbCajeroAnexo_ = tsbCajeroAnexo
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloDatosTesoreria, tss1, tsbCajaCtaCte_, tsbCheques_, tsbTesoreriaEditar_, tsbCajeroAnexo_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraProcesosTesoreria()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tss3 = BuildSeparator()
            Dim tss4 = BuildSeparator()
            Dim tslTituloProcesosTesoreria = BuildLabel("Procesos" & Chr(13) & "tesorería")

            Dim tsbProcesosCaja_ As New Object
            Dim tsbProcesosBanco_ As New Object
            Dim tsbTransferenciaEntreCajas_ As New Object
            Dim tsbDepositosBancarios_ As New Object
            Dim tsbConsultasTesoreria_ As New Object
            Dim tsbCobranzaDudosa_ As New Object
            Dim tsbCobranzaLegal_ As New Object
            Dim tsbPrestamo_ As New Object

            Dim tsbProcesosCaja = BuildBoton("tsbProcesosCaja", "Movimiento" & Chr(13) & "caja", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbProcesosCaja.Click, AddressOf OnCLick

            Dim tsbProcesosBanco = BuildBoton("tsbProcesosBanco", "Movimiento" & Chr(13) & "banco", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbProcesosBanco.Click, AddressOf OnCLick

            Dim tsbTransferenciaEntreCajas = BuildBoton("tsbTransferenciaEntreCajaBanco", "Transferencia" & Chr(13) & "entre caja/banco", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbTransferenciaEntreCajas.Click, AddressOf OnCLick

            Dim tsbDepositosBancarios = BuildBoton("tsbDepositosBancarios", "Depósitos" & Chr(13) & "bancarios", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDepositosBancarios.Click, AddressOf OnCLick

            Dim tsbConsultasTesoreria = BuildBoton("tsbConsultasTesoreria", "Consultas" & Chr(13) & "documentos", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbConsultasTesoreria.Click, AddressOf OnCLick

            Dim tsbCobranzaDudosa = BuildBoton("tsbCobranzaDudosa", "Cobranza" & Chr(13) & "dudosa", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbCobranzaDudosa.Click, AddressOf OnCLick

            Dim tsbCobranzaLegal = BuildBoton("tsbCobranzaLegal", "Cobranza" & Chr(13) & "legal", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbCobranzaLegal.Click, AddressOf OnCLick

            Dim tsbPrestamo = BuildBoton("tsbPrestamo", "Prestamo" & Chr(13) & "", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbPrestamo.Click, AddressOf OnCLick

            If Not vmE0201 Then
                tsbProcesosCaja_ = tsbNulo
            Else
                tsbProcesosCaja_ = tsbProcesosCaja
            End If
            If Not vmE0202 Then
                tsbProcesosBanco_ = tsbNulo
            Else
                tsbProcesosBanco_ = tsbProcesosBanco
            End If
            If Not vmE0203 Then
                tsbTransferenciaEntreCajas_ = tsbNulo
            Else
                tsbTransferenciaEntreCajas_ = tsbTransferenciaEntreCajas
            End If
            If Not vmE0204 Then
                tsbDepositosBancarios_ = tsbNulo
            Else
                tsbDepositosBancarios_ = tsbDepositosBancarios
            End If
            If Not vmE0205 Then
                tsbConsultasTesoreria_ = tsbNulo
            Else
                tsbConsultasTesoreria_ = tsbConsultasTesoreria
            End If
            If Not vmE0206 Then '20207
                tsbCobranzaDudosa_ = tsbNulo
            Else
                tsbCobranzaDudosa_ = tsbCobranzaDudosa
            End If
            If Not vmE0207 Then '20207
                tsbCobranzaLegal_ = tsbNulo
            Else
                tsbCobranzaLegal_ = tsbCobranzaLegal
            End If
            If Not vmE0208 Then '20207
                tsbPrestamo_ = tsbNulo
            Else
                tsbPrestamo_ = tsbPrestamo
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloProcesosTesoreria, tss2, tsbProcesosCaja_, tsbProcesosBanco_, tss3, tsbTransferenciaEntreCajas_, tsbDepositosBancarios_, tss4, tsbConsultasTesoreria_, tsbCobranzaDudosa_, tsbCobranzaLegal_, tsbPrestamo_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraCajaTesoreria()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tslTituloCajaTesoreria = BuildLabel("Caja" & Chr(13) & "tesorería")

            Dim tsbReciboIngresos_ As New Object
            Dim tsbReciboEgresos_ As New Object
            Dim tsbPlanillaEgresos_ As New Object
            Dim tsbReciboIngresosLegal_ As New Object

            Dim tsbReciboIngresos = BuildBoton("tsbReciboIngresos", "Recibo de" & Chr(13) & "ingreso", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbReciboIngresos.Click, AddressOf OnCLick

            Dim tsbReciboEgresos = BuildBoton("tsbReciboEgresos", "Recibo de" & Chr(13) & "egreso", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbReciboEgresos.Click, AddressOf OnCLick

            Dim tsbPlanillaEgresos = BuildBoton("tsbPlanillaEgresos", "Planilla de" & Chr(13) & "egreso", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbPlanillaEgresos.Click, AddressOf OnCLick

            Dim tsbReciboIngresosLegal = BuildBoton("tsbReciboIngresosLegal", "Recibo de" & Chr(13) & "ingreso", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbReciboIngresosLegal.Click, AddressOf OnCLick


            If Not vmE020101 Then
                tsbReciboIngresos_ = tsbNulo
            Else
                tsbReciboIngresos_ = tsbReciboIngresos
            End If
            If Not vmE020102 Then
                tsbReciboEgresos_ = tsbNulo
            Else
                tsbReciboEgresos_ = tsbReciboEgresos
            End If
            If Not vmE020103 Then
                tsbPlanillaEgresos_ = tsbNulo
            Else
                tsbPlanillaEgresos_ = tsbPlanillaEgresos
            End If
            If Not vmE020104 Then
                tsbReciboIngresosLegal_ = tsbNulo
            Else
                tsbReciboIngresosLegal_ = tsbNulo ''tsbReciboIngresosLegal
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloCajaTesoreria, tss2, tsbReciboIngresos_, tsbReciboEgresos_, tsbPlanillaEgresos_, tsbReciboIngresosLegal_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraBancoTesoreria()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tss3 = BuildSeparator()
            Dim tslTituloBancoTesoreria = BuildLabel("Banco" & Chr(13) & "tesorería")

            Dim tsbDepositoTercero_ As New Object
            Dim tsbNotaAbonoCtaBanco_ As New Object
            Dim tsbDetraccionesNotaCargoCtaBanco_ As New Object
            Dim tsbNotaCargoCtaBanco_ As New Object
            Dim tsbVoucherCheque_ As New Object
            Dim tsbExtornoCheque_ As New Object


            Dim tsbDepositoTercero = BuildBoton("tsbDepositoTercero", "Depósitos" & Chr(13) & "de terceros", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDepositoTercero.Click, AddressOf OnCLick

            Dim tsbNotaAbonoCtaBanco = BuildBoton("tsbNotaAbonoCtaBanco", "Nota de abono" & Chr(13) & "Cta. Banco", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbNotaAbonoCtaBanco.Click, AddressOf OnCLick

            Dim tsbDetraccionesNotaCargoCtaBanco = BuildBoton("tsbDetraccionesNotaCargoCtaBanco", "Detraccciones" & Chr(13) & " Nota de cargo" & Chr(13) & " Cta. Banco", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDetraccionesNotaCargoCtaBanco.Click, AddressOf OnCLick

            Dim tsbNotaCargoCtaBanco = BuildBoton("tsbNotaCargoCtaBanco", "Nota de cargo" & Chr(13) & "Cta. Banco", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbNotaCargoCtaBanco.Click, AddressOf OnCLick

            Dim tsbVoucherCheque = BuildBoton("tsbVoucherCheque", "Voucher" & Chr(13) & "cheque", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbVoucherCheque.Click, AddressOf OnCLick

            Dim tsbExtornoCheque = BuildBoton("tsbExtornoCheque", "Extorno" & Chr(13) & "cheque", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbExtornoCheque.Click, AddressOf OnCLick



            If Not vmE020201 Then
                tsbDepositoTercero_ = tsbNulo
            Else
                tsbDepositoTercero_ = tsbDepositoTercero
            End If
            If Not vmE020202 Then
                tsbNotaAbonoCtaBanco_ = tsbNulo
            Else
                tsbNotaAbonoCtaBanco_ = tsbNotaAbonoCtaBanco
            End If
            If Not vmE020203 Then
                tsbDetraccionesNotaCargoCtaBanco_ = tsbNulo
            Else
                tsbDetraccionesNotaCargoCtaBanco_ = tsbDetraccionesNotaCargoCtaBanco
            End If
            If Not vmE020204 Then
                tsbNotaCargoCtaBanco_ = tsbNulo
            Else
                tsbNotaCargoCtaBanco_ = tsbNotaCargoCtaBanco
            End If
            If Not vmE020205 Then
                tsbVoucherCheque_ = tsbNulo
            Else
                tsbVoucherCheque_ = tsbVoucherCheque
            End If
            If Not vmE020206 Then
                tsbExtornoCheque_ = tsbNulo
            Else
                tsbExtornoCheque_ = tsbExtornoCheque
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloBancoTesoreria, tss2, tsbDepositoTercero_, tsbNotaAbonoCtaBanco_, tss3, tsbDetraccionesNotaCargoCtaBanco_, tsbNotaCargoCtaBanco_, tsbVoucherCheque_, tsbExtornoCheque_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraReportesTesoreria()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloProcesosTesoreria = BuildLabel("Reportes" & Chr(13) & "tesorería")

            Dim tsbMovimientoCajaBancos_ As New Object
            Dim tsbSaldoCajaBanco_ As New Object
            Dim tsbReporteCaja_ As Object


            Dim tsbMovimientoCajaBancos = BuildBoton("tsbMovimientoCajaBancos", "Movimiento" & Chr(13) & "Caja/Bancos", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbMovimientoCajaBancos.Click, AddressOf OnCLick

            Dim tsbSaldoCajaBanco = BuildBoton("tsbSaldoCajaBanco", "Saldos de" & Chr(13) & "Cajas/Bancos", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbSaldoCajaBanco.Click, AddressOf OnCLick

            Dim tsbReporteCaja = BuildBoton("tsbReporteCaja", "caja/bancos " & Chr(13) & "Finanzas", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbReporteCaja.Click, AddressOf OnCLick


            If Not vmE0301 Then
                tsbMovimientoCajaBancos_ = tsbNulo
            Else
                tsbMovimientoCajaBancos_ = tsbMovimientoCajaBancos
            End If

            If Not vmE0302 Then
                tsbSaldoCajaBanco_ = tsbNulo
            Else
                tsbSaldoCajaBanco_ = tsbSaldoCajaBanco
            End If

            If Not vmE0303 Then
                tsbReporteCaja_ = tsbNulo
            Else
                tsbReporteCaja_ = tsbReporteCaja
            End If


            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloProcesosTesoreria, tss1, tsbMovimientoCajaBancos_, tsbSaldoCajaBanco_, tsbReporteCaja_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub

        Private Sub OnSubMenuCuentasCorrientes_CLick(ByVal sender As Object, ByVal e As EventArgs)
            RegistrarBarraCuentasCorrientes()
        End Sub
        Public Sub RegistrarBarraCuentasCorrientes()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()
            Dim tslTituloCuentasCorrientes = BuildLabel("Cuentas" & Chr(13) & "Corrientes")

            Dim tsbArticulosCuentasCorrientes_ As New Object
            Dim tsbDatosCuentasCorrientes_ As New Object
            Dim tsbProcesosCuentasCorrientes_ As New Object
            Dim tsbReportesCuentasCorrientes_ As New Object

            Dim tsbArticulosCuentasCorrientes = BuildBoton("tsbArticulosCuentasCorrientes", "Artículos", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbArticulosCuentasCorrientes.Click, AddressOf OnCLick

            Dim tsbDatosCuentasCorrientes = BuildBoton("tsbDatosCuentasCorrientes", "Datos", Global.My.Resources.Resource1.Cyclop_Photoshop_Works)
            AddHandler tsbDatosCuentasCorrientes.Click, AddressOf OnCLick

            Dim tsbProcesosCuentasCorrientes = BuildBoton("tsbProcesosCuentasCorrientes", "Procesos", Global.My.Resources.Resource1.Cyclop_Photoshop_Works)
            AddHandler tsbProcesosCuentasCorrientes.Click, AddressOf OnCLick

            Dim tsbReportesCuentasCorrientes = BuildBoton("tsbReportesCuentasCorrientes", "Reportes", Global.My.Resources.Resource1.Cyclop_Photoshop_Works)
            AddHandler tsbReportesCuentasCorrientes.Click, AddressOf OnCLick

            If Not vmF01 Then
                tsbArticulosCuentasCorrientes_ = tsbNulo
            Else
                tsbArticulosCuentasCorrientes_ = tsbArticulosCuentasCorrientes
            End If
            If Not vmF02 Then
                tsbDatosCuentasCorrientes_ = tsbNulo
            Else
                tsbDatosCuentasCorrientes_ = tsbDatosCuentasCorrientes
            End If
            If Not vmF03 Then
                tsbProcesosCuentasCorrientes_ = tsbNulo
            Else
                tsbProcesosCuentasCorrientes_ = tsbProcesosCuentasCorrientes
            End If
            If Not vmF04 Then
                tsbReportesCuentasCorrientes_ = tsbNulo
            Else
                tsbReportesCuentasCorrientes_ = tsbReportesCuentasCorrientes
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloCuentasCorrientes, tss1, tsbArticulosCuentasCorrientes_, tsbDatosCuentasCorrientes_, tsbProcesosCuentasCorrientes_, tsbReportesCuentasCorrientes_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraArticulosCuentasCorrientes()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloArticulosCuentasCorrientes = BuildLabel("Artículos" & Chr(13) & "cuentas corrientes")

            Dim tsbListaPrecios_ As New Object
            Dim tsbDescuentoIncremento_ As New Object
            Dim tsbActualizarPrecios_ As New Object
            Dim tsbCopiarPrecios_ As New Object

            Dim tsbListaPrecios = BuildBoton("tsbListaPrecios", "Lista de" & Chr(13) & "precios", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbListaPrecios.Click, AddressOf OnCLick

            Dim tsbDescuentoIncremento = BuildBoton("tsbDescuentoIncremento", "Descuento incremento" & Chr(13) & "lista de precios", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbDescuentoIncremento.Click, AddressOf OnCLick

            '---actualizar precios 
            Dim tsbActualizarPrecios = BuildBoton("tsbActualizarPrecios", "Actualizar precios", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbActualizarPrecios.Click, AddressOf OnCLick

            Dim tsbCopiarPrecios = BuildBoton("tsbCopiarPrecios", "Copiar precios", Global.My.Resources.Resource1.Drawing)
            AddHandler tsbCopiarPrecios.Click, AddressOf OnCLick

            If Not vmF0101 Then
                tsbListaPrecios_ = tsbNulo
            Else
                tsbListaPrecios_ = tsbListaPrecios
            End If
            If Not vmF0102 Then
                tsbDescuentoIncremento_ = tsbNulo
            Else
                tsbDescuentoIncremento_ = tsbDescuentoIncremento
            End If

            If Not vmF0103 Then
                tsbActualizarPrecios_ = tsbNulo
            Else
                tsbActualizarPrecios_ = tsbActualizarPrecios
            End If

            If Not vmF0104 Then
                tsbCopiarPrecios_ = tsbNulo
            Else
                tsbCopiarPrecios_ = tsbCopiarPrecios
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloArticulosCuentasCorrientes, tss1, tsbListaPrecios_, tsbDescuentoIncremento_, tsbActualizarPrecios_, tsbCopiarPrecios_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraDatosCuentasCorrientes()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloDatosCuentasCorrientes = BuildLabel("Datos" & Chr(13) & "cuentas corrientes")

            Dim tsbTipoVenta_ As New Object
            Dim tsbPermisoCuentaCorriente_ As New Object

            Dim tsbTipoVenta = BuildBoton("tsbTipoVenta", "Tipo venta", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbTipoVenta.Click, AddressOf OnCLick

            Dim tsbPermisoCuentaCorriente = BuildBoton("tsbPermisoCuentaCorriente", "Permiso" & Chr(13) & "Cuenta Corriente", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbPermisoCuentaCorriente.Click, AddressOf OnCLick

            If Not vmF0201 Then
                tsbTipoVenta_ = tsbNulo
            Else
                tsbTipoVenta_ = tsbTipoVenta
            End If
            If Not vmF0202 Then
                tsbPermisoCuentaCorriente_ = tsbNulo
            Else
                tsbPermisoCuentaCorriente_ = tsbPermisoCuentaCorriente
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloDatosCuentasCorrientes, tss1, tsbTipoVenta_, tsbPermisoCuentaCorriente_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraProcesosCuentasCorrientes()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tss2 = BuildSeparator()
            Dim tslTituloProcesosCuentasCorrientes = BuildLabel("Procesos" & Chr(13) & "cuentas corrientes")

            Dim tsbCartaFianza_ As New Object
            Dim tsbLiquidacionDocumento_ As New Object
            Dim tsbPlanillaRendicionCuentas_ As New Object

            Dim tsbCartaFianza = BuildBoton("tsbCartaFianza", "Carta fianza", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbCartaFianza.Click, AddressOf OnCLick

            Dim tsbLiquidacionDocumento = BuildBoton("tsbLiquidacionDocumento", "Liquidación" & Chr(13) & " de documento", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbLiquidacionDocumento.Click, AddressOf OnCLick

            Dim tsbPlanillaRendicionCuentas = BuildBoton("tsbPlanillaRendicionCuentas", "Planilla" & Chr(13) & " rendición cuentas", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbPlanillaRendicionCuentas.Click, AddressOf OnCLick

            If Not vmF0301 Then
                tsbCartaFianza_ = tsbNulo
            Else
                tsbCartaFianza_ = tsbCartaFianza
            End If
            If Not vmF0302 Then
                tsbPlanillaRendicionCuentas_ = tsbNulo
            Else
                tsbPlanillaRendicionCuentas_ = tsbPlanillaRendicionCuentas
            End If
            If Not vmF0303 Then
                tsbLiquidacionDocumento_ = tsbNulo
            Else
                tsbLiquidacionDocumento_ = tsbLiquidacionDocumento
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloProcesosCuentasCorrientes, tss2, tsbCartaFianza_, tsbPlanillaRendicionCuentas_, tsbLiquidacionDocumento_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraReportesCuentasCorrientes()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloReportesCuentasCorrientes = BuildLabel("Reportes" & Chr(13) & "Cta. Cte.")

            Dim tsbKardexCtaCte_ As New Object
            Dim tsbReporteListaPrecios_ As New Object
            Dim tsbKardexPorVendedor_ As New Object
            Dim tsbSaldosTipoCliente_ As New Object
            'DEPOSITO DE TERCEROS 
            Dim tsbReporteDepositoTerceros_ As New Object
            Dim tsbReporteCuentas_ As New Object
            Dim tsbReportePeriodo_ As New Object
            Dim tsbKardexContabilidad_ As New Object


            Dim tsbKardexCtaCte = BuildBoton("tsbKardexCtaCte", "Kardex" & Chr(13) & "Cta. Cte.", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbKardexCtaCte.Click, AddressOf OnCLick

            Dim tsbReporteListaPrecios = BuildBoton("tsbReporteListaPrecios", "Lista de" & Chr(13) & "precios", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteListaPrecios.Click, AddressOf OnCLick

            Dim tsbKardexPorVendedor = BuildBoton("tsbKardexPorVendedor", "Kardex" & Chr(13) & "por vendedor", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbKardexPorVendedor.Click, AddressOf OnCLick

            Dim tsbSaldosTipoCliente = BuildBoton("tsbSaldosTipoCliente", "Saldos por" & Chr(13) & "tipo de cliente", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbSaldosTipoCliente.Click, AddressOf OnCLick

            Dim tsbReporteDepositoTerceros = BuildBoton("tsbReporteDepositoTerceros", "Deposito Terceros", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteDepositoTerceros.Click, AddressOf OnCLick

            Dim tsbReporteCuentas = BuildBoton("tsbReporteCuentas", "Reporte" & Chr(13) & "percepciones", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReporteCuentas.Click, AddressOf OnCLick

            Dim tsbReportePeriodo = BuildBoton("tsbReportePeriodo", "Reporte" & Chr(13) & "retenciones", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbReportePeriodo.Click, AddressOf OnCLick

            Dim tsbKardexContabilidad = BuildBoton("tsbKardexContabilidad", "Kardex" & Chr(13) & "Contabilidad", Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions)
            AddHandler tsbKardexContabilidad.Click, AddressOf OnCLick


            'tsbReporteDepositoTerceros

            If Not vmF0401 Then
                tsbKardexCtaCte_ = tsbNulo
            Else
                tsbKardexCtaCte_ = tsbKardexCtaCte
            End If
            If Not vmF0402 Then
                tsbReporteListaPrecios_ = tsbNulo
            Else
                tsbReporteListaPrecios_ = tsbReporteListaPrecios
            End If
            If Not vmF0403 Then
                tsbKardexPorVendedor_ = tsbNulo
            Else
                tsbKardexPorVendedor_ = tsbNulo 'tsbKardexPorVendedor
            End If
            If Not vmF0404 Then
                tsbSaldosTipoCliente_ = tsbNulo
            Else
                tsbSaldosTipoCliente_ = tsbSaldosTipoCliente
            End If
            If Not vmF0405 Then
                tsbReporteDepositoTerceros_ = tsbNulo
            Else
                tsbReporteDepositoTerceros_ = tsbReporteDepositoTerceros
            End If
            If Not vmF0406 Then
                tsbReporteCuentas_ = tsbNulo
            Else
                tsbReporteCuentas_ = tsbReporteCuentas
            End If
            If Not vmF0407 Then
                tsbReportePeriodo_ = tsbNulo
            Else
                tsbReportePeriodo_ = tsbReportePeriodo
            End If
            If Not vmF0408 Then
                tsbKardexContabilidad_ = tsbNulo
            Else
                tsbKardexContabilidad_ = tsbKardexContabilidad
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloReportesCuentasCorrientes, tss1, tsbKardexCtaCte_, tsbReporteListaPrecios_, tsbKardexPorVendedor_, tsbSaldosTipoCliente_, tsbReporteDepositoTerceros_, tsbReporteCuentas_, tsbReportePeriodo_, tsbKardexContabilidad_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub

        Private Sub OnSubMenuActivosFijos_CLick(ByVal sender As Object, ByVal e As EventArgs)
            RegistrarBarraActivosFijos()
        End Sub
        Public Sub RegistrarBarraActivosFijos()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Dim tss1 = BuildSeparator()
            Dim tslTituloActivosFijos = BuildLabel("Activos" & Chr(13) & "Fijos")

            Dim tsbDatosActivosFijos_ As New Object

            Dim tsbDatosActivosFijos = BuildBoton("tsbDatosActivosFijos", "Datos", Global.My.Resources.Resource1.Cyclop_Photoshop_Works)
            AddHandler tsbDatosActivosFijos.Click, AddressOf OnCLick

            If Not vmG01 Then
                tsbDatosActivosFijos_ = tsbNulo
            Else
                tsbDatosActivosFijos_ = tsbDatosActivosFijos
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloActivosFijos, tss1, tsbDatosActivosFijos_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub
        Public Sub RegistrarBarraDatosActivosFijos()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()

            Dim tss1 = BuildSeparator()
            Dim tslTituloDatosActivosFijos = BuildLabel("Datos" & Chr(13) & "activos fijos")

            Dim tsbIncidencias_ As New Object
            Dim tsbCuentasActivos_ As New Object
            Dim tsbEdificios_ As New Object
            Dim tsbOficinas_ As New Object
            Dim tsbDepartamentosAdministrativos_ As New Object

            Dim tsbIncidencias = BuildBoton("tsbIncidencias", "Incidencias", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbIncidencias.Click, AddressOf OnCLick

            Dim tsbCuentasActivos = BuildBoton("tsbCuentasActivos", "Cuentas de" & Chr(13) & "activos fijos", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbCuentasActivos.Click, AddressOf OnCLick

            Dim tsbEdificios = BuildBoton("tsbEdificios", "Edificios", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbEdificios.Click, AddressOf OnCLick

            Dim tsbOficinas = BuildBoton("tsbOficinas", "Oficinas", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbOficinas.Click, AddressOf OnCLick

            Dim tsbDepartamentosAdministrativos = BuildBoton("tsbDepartamentosAdministrativos", "Departamentos" & Chr(13) & "administrativos", Global.My.Resources.Resource1.Vista__35_)
            AddHandler tsbDepartamentosAdministrativos.Click, AddressOf OnCLick

            If Not vmG0101 Then
                tsbIncidencias_ = tsbNulo
            Else
                tsbIncidencias_ = tsbIncidencias
            End If
            If Not vmG0102 Then
                tsbCuentasActivos_ = tsbNulo
            Else
                tsbCuentasActivos_ = tsbCuentasActivos
            End If
            If Not vmG0103 Then
                tsbEdificios_ = tsbNulo
            Else
                tsbEdificios_ = tsbEdificios
            End If
            If Not vmG0104 Then
                tsbOficinas_ = tsbNulo
            Else
                tsbOficinas_ = tsbOficinas
            End If
            If Not vmG0105 Then
                tsbDepartamentosAdministrativos_ = tsbNulo
            Else
                tsbDepartamentosAdministrativos_ = tsbDepartamentosAdministrativos
            End If

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() _
            {tss1, tslTituloDatosActivosFijos, tss1, tsbIncidencias_, tsbCuentasActivos_, tsbEdificios_, tsbOficinas_, tsbDepartamentosAdministrativos_})

            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True
        End Sub

        Private Sub OnCLick(ByVal sender As Object, ByVal e As EventArgs)
            Dim Elementos = System.Windows.Forms.Form.ActiveForm.MdiChildren.Length()
            Select Case sender.name.ToString
                ' Maestros
                Case "tsbUsuarios"
                    RegistrarBarraUsuarios()
                Case "tsbArticulos"
                    RegistrarBarraArticulos()
                Case "tsbUnidadesTransporte"
                    RegistrarBarraUnidadesTransporte()
                Case "tsbPersonas"
                    RegistrarBarraPersonas()
                Case "tsbSitios"
                    RegistrarBarraSitios()
                Case "tsbDivisas"
                    RegistrarBarraDivisas()
                Case "tsbDatos"
                    RegistrarBarraDatos()

                Case "tsbDatosUsuarios"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDatosUsuarios") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmDatosUsuarios)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbPuntoVentaDatosUsuarios"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPuntoVentaDatosUsuarios") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmPuntoVentaDatosUsuarios)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbPesosArticulos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPesosArticulos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmPesosArticulos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbRolArticulosTipoArticulos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmRolArticulosTipoArticulos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmRolArticulosTipoArticulos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbRolAlmacenTipoArticulos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmRolAlmacenTipoArticulos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmRolAlmacenTipoArticulos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbTipoUnidad"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTipoUnidad") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmTipoUnidad)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbConfiguracionVehicular"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmConfiguracionVehicular") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmConfiguracionVehicular)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbUnidadesTransporte1"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmUnidadesTransporte") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmUnidadesTransporte)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbPlacas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPlacas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmPlacas)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbTipoPersonas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTipoPersonas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmTipoPersonas)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbTipoDocPersonas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTipoDocPersonas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmTipoDocPersonas)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbPersonas1"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPersonas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmPersonas)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                    frm.Nuevo = vmBarra(19, 1)
                    frm.vNuevo = vmBarra(19, 1)

                Case "tsbDocPersonas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDocPersonas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmDocPersonas)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDireccionesPersonas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDireccionesPersonas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmDireccionesPersonas)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbContactoPersona"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmContactoPersona") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmContactoPersona)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbRolPersonaTipoPersona"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmRolPersonaTipoPersona") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmRolPersonaTipoPersona)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbBloqueosCodigoPersona"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmBloqueosCodigoPersona") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmBloqueosCodigoPersona)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbSancion"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmSancion") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmSancion)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbFaltaSancion"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmFaltaSancion") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmFaltaSancion)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteSanciones"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteSanciones") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmReporteSanciones)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbBloqueoVendedor"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmBloqueoVendedor") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmBloqueoVendedor)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()


                Case "tsbPais"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPais") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmPais)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDepartamento"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDepartamento") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmDepartamento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbProvincia"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmProvincia") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmProvincia)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDistrito"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDistrito") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmDistrito)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbPuntoVenta"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPuntoventa") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmPuntoVenta)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbRolPuntoVentaAlmacen"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmRolPuntoVentaAlmacen") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmRolPuntoVentaAlmacen)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbMoneda"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmMoneda") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmMoneda)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbTipoCambioMoneda"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTipoCambioMoneda") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmTipoCambioMoneda)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbTipoDocumentos"
                    'HabilitarSubMenu(False)
                    'If VerificarVentana(Elementos, "frmTipoDocumentos") Then Exit Sub
                    'Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmTipoDocumentos)()
                    'frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    'frm.Activate()
                    'frm.Show()
                    'frm.BringToFront()

                Case "tsbCorrelativoTipoDocumento"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCorrelativoTipoDocumento") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmCorrelativoTipoDocumento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbCierre"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCierre") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmCierre)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbCierreDiario"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCierreDiario") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmCierreDiario)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbCentroCostos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCentroCostos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmCentroCostos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()


                Case "tsbRolOpeCtaCte"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmRolOpeCtaCte") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Maestros.Views.frmRolOpeCtaCte)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()


                    ' Facturación
                Case "tsbArticulosFacturacion"
                    RegistrarBarraArticulosFacturacion()
                Case "tsbRestriccionArticulo"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmRestriccionArticulo") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmRestriccionArticulo)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbDatosFacturacion"
                    RegistrarBarraDatosFacturacion()
                Case "tsbComision"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmComision") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmComision)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbFletesTransportes"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmFletesTransportes") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmFletesTransportes)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbProcesosFacturacion"
                    RegistrarBarraProcesosFacturacion()

                Case "tsbCotizacionBoletaFactura"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCotizacionBoletaFactura") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()
                    frm.Name = "frmCotizacionBoletaFactura"
                    frm.Text = "Cotización boleta/factura"

                    frm.pDocumentoProcesandose = 600 ' Cotización boleta/factura Proforma Boleta
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.PedidoBoleta ' "003" ' PROFORMA BOLETA
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.PBBoleta '"007" ' PROFORMA BOLETA
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.Preventas '"022" ' PREVENTAS

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()


                Case "tsbPedidoBoletaFactura"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPedidoBoletaFactura") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()
                    frm.Name = "frmPedidoBoletaFactura"
                    frm.Text = "Pedido boleta/factura"

                    frm.pDocumentoProcesandose = 100 ' Pedido boleta/factura Proforma Boleta
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.PedidoBoleta ' "003" ' PROFORMA BOLETA
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.PBBoleta '"007" ' PROFORMA BOLETA
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.Preventas '"022" ' PREVENTAS

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbTipoVentaBoletaFactura"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTipoVentaBoletaFactura") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()
                    frm.Name = "frmTipoVentaBoletaFactura"
                    frm.Text = "Dar pase a Bol./Fact."

                    frm.pDocumentoProcesandose = 1000 ' Dar pase a Bol./Fact.
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.VentaBoleta
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.Boleta
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContraEntrega '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.Preventas '"022" ' PREVENTAS

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbOrdenCompraBoletas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmOrdenCompraBoletas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()
                    frm.Name = "frmOrdenCompraBoletas"
                    frm.Text = "Orden compra boletas"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.PedidoBoleta ' "003" ' PREVENTA BOLETA
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.OrdCompraBoleta '"189" ' ORDEN DE COMPRA BOLETA
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.Preventas '"022" ' PREVENTAS

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbOrdenCompraFacturas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmOrdenCompraFacturas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()
                    frm.Name = "frmOrdenCompraFacturas"
                    frm.Text = "Orden compra facturas"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.PedidoFactura ' "004" ' PREVENTA FACTURA
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.OrdCompraFactura '"190" ' ORDEN DE COMPRA FACTURA
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"04" ' RUC
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"04" ' RUC
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.Preventas '"022" ' PREVENTAS

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbBoletas"
                    HabilitarSubMenu(False)
                    'If VerificarVentana(Elementos, "frmBoletas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()

                    If VerificarVentana(Elementos, "frmBoletas") Then
                        If VerificarVentana(Elementos, "frmBoletas01") Then
                            If VerificarVentana(Elementos, "frmBoletas02") Then
                                If VerificarVentana(Elementos, "frmBoletas03") Then
                                    If VerificarVentana(Elementos, "frmBoletas04") Then
                                        Exit Sub
                                    Else
                                        frm.Name = "frmBoletas04"
                                        frm.Text = "Boletas04"
                                    End If
                                Else
                                    frm.Name = "frmBoletas03"
                                    frm.Text = "Boletas03"
                                End If
                            Else
                                frm.Name = "frmBoletas02"
                                frm.Text = "Boletas02"
                            End If
                        Else
                            frm.Name = "frmBoletas01"
                            frm.Text = "Boletas01"
                        End If
                    Else
                        frm.Name = "frmBoletas"
                        frm.Text = "Boletas"
                    End If

                    frm.pDocumentoProcesandose = 300 ' Boleta
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.VentaBoleta ' "001" ' Boletas de ventas
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.Boleta '"001" ' Boleta
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbFacturas"
                    HabilitarSubMenu(False)
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()

                    If VerificarVentana(Elementos, "frmFacturas") Then
                        If VerificarVentana(Elementos, "frmFacturas01") Then
                            If VerificarVentana(Elementos, "frmFacturas02") Then
                                If VerificarVentana(Elementos, "frmFacturas03") Then
                                    If VerificarVentana(Elementos, "frmFacturas04") Then
                                        Exit Sub
                                    Else
                                        frm.Name = "frmFacturas04"
                                        frm.Text = "Facturas04"
                                    End If
                                Else
                                    frm.Name = "frmFacturas03"
                                    frm.Text = "Facturas03"
                                End If
                            Else
                                frm.Name = "frmFacturas02"
                                frm.Text = "Facturas02"
                            End If
                        Else
                            frm.Name = "frmFacturas01"
                            frm.Text = "Facturas01"
                        End If
                    Else
                        frm.Name = "frmFacturas"
                        frm.Text = "Facturas"
                    End If

                    frm.pDocumentoProcesandose = 400 ' Proforma Boleta
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.VentaFactura ' "002" ' Ventas Facturas
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.Factura '"004" ' Facturas
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"04" ' RUC
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"04" ' RUC
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDocumentoPromocion"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGenerarDocumentoPromocion") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmGenerarDocumentoPromocion)()
                    frm.Name = "frmGenerarDocumentoPromocion"
                    frm.Text = "Generar documento promoción"

                    'frm.pDocumentoProcesandose = 100 ' Pedido boleta/factura Proforma Boleta
                    'frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    'frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.ProformaBoleta ' "003" ' PROFORMA BOLETA
                    'frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.ProBoleta '"007" ' PROFORMA BOLETA
                    'frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    'frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    'frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    'frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI '"02" ' DNI
                    'frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    'frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    'frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    'frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    'frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    'frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    'frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    'frm.pCCT_ID = BCVariablesNames.CCT_ID.Preventas '"022" ' PREVENTAS

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbSolicitudAjustePrecio"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmSolicitudAjustePrecio") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmSolicitudAjustePrecio)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal
                    frm.Show()
                    frm.BringToFront()

                Case "tsbNotasFacturacion"
                    RegistrarBarraNotasFacturacion()
                Case "tsbNotaCredito"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmNotaCredito") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()
                    frm.Name = "frmNotaCredito"
                    frm.Text = "Nota de crédito"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.NotaCredito ' "008" ' NOTA DE CREDITO
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.NCredito '"017 ' NOTA DE CREDITO
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbNotaDebito"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmNotaDebito") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()
                    frm.Name = "frmNotaDebito"
                    frm.Text = "Nota de débito"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.NotaDebito ' "009" ' NOTA DE DEBITO
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.NDebito '"018 ' NOTA DE DEBITO
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbNotaCreditoConsulta"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmNotaCredito") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()
                    frm.Name = "frmNotaCredito"
                    frm.Text = "Consulta nota de crédito"

                    frm.pDocumentoProcesandose = 3000 ' c nc
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.NotaCredito ' "008" ' NOTA DE CREDITO
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.NCredito '"017 ' NOTA DE CREDITO
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContado '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbReportesFacturacion"
                    RegistrarBarraReportesFacturacion()
                Case "tsbDocumentosEmitidos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDocumentosEmitidos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentosEmitidos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Text = "Documentos de venta emitidos"
                    frm.pComportamientoFormulario = 100
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbPendientesAtencion"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPendientesAtencion") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmKardexDocumento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

                    frm.Name = "frmPendientesAtencion"
                    frm.Text = "Documentos de venta pendientes de atención"
                    frm.pComportamientoFormulario = 200
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbEntregaDespachos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmEntregaDespachos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmKardexDocumento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmEntregaDespachos"
                    frm.Text = "Guías/Nota Crédito/Nota Debito, Emitidas de Facturas/Boletas"
                    frm.pComportamientoFormulario = 300
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbToneladasMillaresVentas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmToneladasMillaresVentas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmKardexDocumento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmToneladasMillaresVentas"
                    frm.Text = "Reporte de toneladas/millares vendidos"
                    frm.pComportamientoFormulario = 400
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDetalleVentaPorArticulo"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDetalleVentaPorArticulo") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmKardexDocumento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmDetalleVentaPorArticulo"
                    frm.Text = "Reporte ventas por artículo"
                    frm.pComportamientoFormulario = 600
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDocumentosEmitidosPorPromotor"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDocumentosEmitidosPorPromotor") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentosEmitidos)()
                    frm.Name = "frmDocumentosEmitidosPorPromotor"
                    frm.Text = "Ventas BV/FT por promotor"

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.pComportamientoFormulario = 200
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteAnalisisVentas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteAnalisisVentas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmReporteAnalisisVentas)()
                    frm.Name = "frmReporteAnalisisVentas"
                    frm.Text = "ReporteAnalisis Ventas"

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    'frm.pComportamientoFormulario = 200
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbPedidosEmitidos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPedidosEmitidos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentosEmitidos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Text = "Pedidos de venta emitidos"
                    frm.pComportamientoFormulario = 300
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbEstadoDeDocumentosFechasVentas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmEstadoDeDocumentosFechasVentas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmEstadoDeDocumentosFechasVentas)()
                    frm.Name = "frmEstadoDeDocumentosFechasVentas"
                    frm.Text = "Estado De Documentos Fechas de Ventas"

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbConsultaPedidos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTipoVentaBoletaFactura") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmDocumentos)()
                    frm.Name = "frmConsultaPedido"
                    frm.Text = "Consulta de pedido"

                    frm.pDocumentoProcesandose = 2000 ' Dar pase a Bol./Fact.
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosFacturación.PedidoBoleta
                    frm.pDTD_ID = BCVariablesNames.ProcesosFacturación.PBBoleta
                    frm.pMON_ID = BCVariablesNames.MonedaSistema '"001" ' Nuevos soles
                    frm.pTIV_ID = BCVariablesNames.TipoVentaContraEntrega '"001" ' Contado
                    frm.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pTDP_ID_REC = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC '"02" ' DNI
                    frm.pDomicilio = BCVariablesNames.TipoDireccion("Domicilio") ' 0
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pCobranza = BCVariablesNames.TipoDireccion("Cobranza") '2
                    frm.pFiscal = BCVariablesNames.TipoDireccion("Fiscal") '3
                    frm.pTPE_ID_VEN = BCVariablesNames.TipoPersonas.Vendedor '"001" ' Vendedor
                    frm.pTPE_ID_COB = BCVariablesNames.TipoPersonas.Cobrador '"002" ' Cobrador
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.Preventas '"022" ' PREVENTAS

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteVentas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmAnalisis") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Facturacion.Views.frmAnalisis)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Text = "Análisis"
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()


                    ' Despachos
                Case "tsbProcesosDespachos"
                    RegistrarBarraProcesosDespachos()
                Case "tsbGuiaDespacho"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGuiaDespacho") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmDespachos)()
                    frm.Name = "frmGuiaDespacho"
                    frm.Text = "Guía de despacho"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.Guia ' "005" ' Guía
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaDespacho '"011 ' Guía de despacho
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbDespachoSalida"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDespachoSalida") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmDespachoSalida)()
                    frm.Name = "frmDespachoSalida"
                    frm.Text = "Despacho Salida"

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbOrdenDespacho"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmOrdenDespacho") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmOrdenDespacho)()
                    frm.Name = "frmOrdenDespacho"
                    frm.Text = "Orden de Despacho"

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbGuiaAutorizada"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGuiaAutorizada") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmGuiasAutorizadas)()
                    frm.Name = "frmGuiasAutorizadas"
                    frm.Text = "Guia Autorizada"

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbGuiaTransitoPendiente"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGuiasTransitoPendiente") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmGuiasTransitoPendiente)()
                    frm.Name = "frmGuiasTransitoPendiente"
                    frm.Text = "Guias en Transito Pendiente"

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbGuiaDevolucion"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGuiaDevolucion") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmDespachos)()
                    frm.Name = "frmGuiaDevolucion"
                    frm.Text = "Guía de devolucion"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.Guia ' "005" ' Guía
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaDevolucion '"014 ' Guía de devolución
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbGuiaSalida"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGuiaSalida") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmDespachos)()
                    frm.Name = "frmGuiaSalida"
                    frm.Text = "Guía Salida"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.Guia ' "005" ' Guía
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaSalida  '"013 ' Guía de transferencia
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbGuiaTransferencia"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGuiaTransferencia") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmDespachos)()
                    frm.Name = "frmGuiaTransferencia"
                    frm.Text = "Guía de transferencia"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.Guia ' "005" ' Guía
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaTransferencia '"013 ' Guía de transferencia
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbCronogramaDespacho"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCronogramaDespacho") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmDespachos)()
                    frm.Name = "frmCronogramaDespacho"
                    frm.Text = "Cronograma de despacho"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.CronogramaDespacho ' "024" ' Guía
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho '"021 ' Guía de transferencia
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbGuiaDespachoDesdeDistribuidora"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGuiaDespachoDesdeDistribuidora") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmDespachos)()
                    frm.Name = "frmGuiaDespachoDesdeDistribuidora"
                    frm.Text = "Guía de despacho desde la distribuidora"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "002" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.Guia ' "005" ' Guía
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora '"207 ' Guía de Salida
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbControlGarita"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmControlGarita") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmMarcarSalidaGuia)()
                    frm.Name = "frmControlGarita"
                    frm.Text = "Marcar hora de salida"

                    frm.pComportamientoFormulario = 100 ' Control garita
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "002" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.Guia ' "005" ' Guía
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaDespacho '"207 ' Guía de Salida
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbControlCarguio"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmControlCarguio") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmMarcarSalidaGuia)()
                    frm.Name = "frmControlCarguio"
                    frm.Text = "Marcar hora de carga"

                    frm.pComportamientoFormulario = 200 ' Control carga
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "002" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.Guia ' "005" ' Guía
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaDespacho '"207 ' Guía de Salida
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbHabilitarCronogramaDespacho"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmHabilitarCronogramDespacho") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmMarcarSalidaGuia)()
                    frm.Name = "frmHabilitarCronogramaDespacho"
                    frm.Text = "Habilitar cronograma de despacho"

                    frm.pComportamientoFormulario = 300 ' Control carga
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbVisualizarCronogramaDespacho"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmVisualizarCronogramDespacho") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmMarcarSalidaGuia)()
                    frm.Name = "frmVisualizarCronogramaDespacho"
                    frm.Text = "Visualizar cronograma de despacho"

                    frm.pComportamientoFormulario = 400 ' Control carga
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbGuiaDevolucionDesdeDistribuidora"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGuiaDevolucionDesdeDistribuidora") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmDespachos)()
                    frm.Name = "frmGuiaDevolucionDesdeDistribuidora"
                    frm.Text = "Guía de devolucion desde la distribuidora"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosDespacho.Guia ' "005" ' Guía
                    frm.pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora '"014 ' Guía de devolución
                    frm.pTIP_ID = BCVariablesNames.TipoArticulo.ProductoTerminado '"001" ' Producto terminado
                    frm.pEntrega = BCVariablesNames.TipoDireccion("Entrega") '1
                    frm.pFLE_TIPO = BCVariablesNames.FleteTransporteCliente '"TRANSPORTE CLIENTE" ' Tipo de flete
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales '"001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbReportesDespachos"
                    RegistrarBarraReportesDespachos()
                Case "tsbKardexDocumento"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmKardexDocumento") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmKardexDocumento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.pComportamientoFormulario = 100
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbTrasladoEntreAlmacenes"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTrasladoEntreAlmacenes") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmKardexDocumento)()
                    frm.Name = "frmTrasladoEntreAlmacenes"
                    frm.Text = "Traslado entre almacenes"
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.pComportamientoFormulario = 500
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbGuiaRemisionTransportista"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmGuiaRemisionTransportista") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmGuiasRemision)()
                    frm.Name = "frmGuiaRemisionTransportista"
                    frm.Text = "Guía remisión por transportista"
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteGuias"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmRepoteGuias") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmKardexDocumento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteGuias"
                    frm.Text = "Reporte de guías"
                    frm.pComportamientoFormulario = 700
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteGuiasProduccion"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmRepoteGuiasProduccion") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmKardexDocumento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteGuiasProduccion"
                    frm.Text = "Reporte guías para producción"
                    frm.pComportamientoFormulario = 800
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteCronogramaDespacho"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteCronogramaDespacho") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Despachos.Views.frmReporteCronogramaDespacho)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteCronogramaDespacho"
                    frm.Text = "Reporte cronograma de despacho"
                    'frm.pComportamientoFormulario = 800
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteGuiasSinDocumento"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteGuiasSinDocumento") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmReporteGuiasSinDocumento)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteGuiasSinDocumento"
                    frm.Text = "Reporte Guias de Despacho Sin Documento"
                    'frm.pComportamientoFormulario = 800
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteGuiasPorSalir"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteGuiasPorSalir") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmReporteGuiasPorSalir)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteGuiasPorSalir"
                    frm.Text = "Reporte Guias por Salir"
                    'frm.pComportamientoFormulario = 800
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteTransferenciaLadrillo"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteTransferenciaLadrillo") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmReporteTransferenciaLadrillo)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteTransferenciaLadrillo"
                    frm.Text = "Reporte Transferencia Ladrillo"
                    'frm.pComportamientoFormulario = 800
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteGuiaRemisionCliente"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteDocumentoGuiaCliente") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmReporteDocumentoGuiaCliente)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteDocumentoGuiaCliente"
                    frm.Text = "Reporte Guias de Remision del Cliente"
                    'frm.pComportamientoFormulario = 800
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteGuiaSaleTarde"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteGuiaSaleTarde") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmReporteGuiaSaleTarde)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteGuiaSaleTarde"
                    frm.Text = "Reporte Fecha y Hora Salida de Guias"
                    'frm.pComportamientoFormulario = 800
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteOrdenDespacho"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteOrdenDespacho") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmReporteOrdenDespacho)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteOrdenDespacho"
                    frm.Text = "Reporte Orden Despacho"
                    'frm.pComportamientoFormulario = 800
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteProyeccion"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteProyeccion") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of frmReporteVentaGuiasProduccion)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Name = "frmReporteVentaGuiasProduccion"
                    frm.Text = "Reporte Proyeccion"
                    'frm.pComportamientoFormulario = 800
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                    ' Tesorería
                Case "tsbDatosTesoreria"
                    RegistrarBarraDatosTesoreria()
                Case "tsbCajaCtaCte"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCajaCtaCte") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmCajaCtaCte)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbCheques"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCheques") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmCheques)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbTesoreriaEditar"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTesoreriaEditar") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreriaEditar)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbCajeroAnexo"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCajeroAnexo") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmCajeroAnexo)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbProcesosTesoreria"
                    RegistrarBarraProcesosTesoreria()
                Case "tsbTransferenciaEntreCajaBanco"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTransferenciaEntreCajas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmTransferenciaEntreCajas"
                    frm.Text = "Transferencia entre caja/banco"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas ' "018" 
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.TECBTransferenciaEntreCajas ' "186" 
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.TransferenciaEntreCajaCtaCteBanco ' "020 ' TRANSFERENCIAS ENTRE CAJAS, CTA. CTE. BANCOS
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CajaDefaul ' "001" ' Caja - Caja de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.Caja ' "CAJA" ' CAJA
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDepositosBancarios"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDepositosBancarios") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmDepositosBancarios"
                    frm.Text = "Depósitos bancarios"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas ' "018" 
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.TECBDepositosBancarios ' "035" 
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.TransferenciaEntreCajaCtaCteBanco ' "020 ' TRANSFERENCIAS ENTRE CAJAS, CTA. CTE. BANCOS
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CajaDefaul ' "001" ' Caja - Caja de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.Caja ' "CAJA" ' CAJA
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbConsultasTesoreria"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmConsultasTesoreria") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmConsultasTesoreria"
                    frm.Text = "Consultas documentos de tesorería"

                    frm.pDocumentoProcesandose = 1000 ' Dar pase a Bol./Fact.
                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.CajaIngreso ' "010" ' Caja - Ingresos
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso ' "019" ' Recibo de ingreso
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales ' "001 ' CUENTAS X COBRAR COMERCIALES (CLIENTES)
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CajaDefaul ' "001" ' Caja - Caja de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.Caja ' "CAJA" ' CAJA
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    'frm.WindowState = FormWindowState.Maximized
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbProcesosCaja"
                    RegistrarBarraCajaTesoreria()
                Case "tsbReciboIngresos"
                    HabilitarSubMenu(False)
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()

                    If VerificarVentana(Elementos, "frmReciboIngresos") Then
                        If VerificarVentana(Elementos, "frmReciboIngresos01") Then
                            If VerificarVentana(Elementos, "frmReciboIngresos02") Then
                                If VerificarVentana(Elementos, "frmReciboIngresos03") Then
                                    If VerificarVentana(Elementos, "frmReciboIngresos04") Then
                                        Exit Sub
                                    Else
                                        frm.Name = "frmReciboIngresos04"
                                        frm.Text = "Recibo de ingresos04"
                                    End If
                                Else
                                    frm.Name = "frmReciboIngresos03"
                                    frm.Text = "Recibo de ingresos03"
                                End If
                            Else
                                frm.Name = "frmReciboIngresos02"
                                frm.Text = "Recibo de ingresos02"
                            End If
                        Else
                            frm.Name = "frmReciboIngresos01"
                            frm.Text = "Recibo de ingresos01"
                        End If
                    Else
                        frm.Name = "frmReciboIngresos"
                        frm.Text = "Recibo de ingresos"
                    End If

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.CajaIngreso ' "010" ' Caja - Ingresos
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso ' "019" ' Recibo de ingreso
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales ' "001 ' CUENTAS X COBRAR COMERCIALES (CLIENTES)
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CajaDefaul ' "001" ' Caja - Caja de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.Caja ' "CAJA" ' CAJA
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReciboEgresos"
                    HabilitarSubMenu(False)
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()

                    If VerificarVentana(Elementos, "frmReciboEgresos") Then
                        If VerificarVentana(Elementos, "frmReciboEgresos01") Then
                            If VerificarVentana(Elementos, "frmReciboEgresos02") Then
                                If VerificarVentana(Elementos, "frmReciboEgresos03") Then
                                    If VerificarVentana(Elementos, "frmReciboEgresos04") Then
                                        Exit Sub
                                    Else
                                        frm.Name = "frmReciboEgresos04"
                                        frm.Text = "Recibo de egresos04"
                                    End If
                                Else
                                    frm.Name = "frmReciboEgresos03"
                                    frm.Text = "Recibo de egresos03"
                                End If
                            Else
                                frm.Name = "frmReciboEgresos02"
                                frm.Text = "Recibo de egresos02"
                            End If
                        Else
                            frm.Name = "frmReciboEgresos01"
                            frm.Text = "Recibo de egresos01"
                        End If
                    Else
                        frm.Name = "frmReciboEgresos"
                        frm.Text = "Recibo de egresos"
                    End If

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.CajaEgreso ' "016" ' Caja - Egresos
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso ' "020" ' Recibo de egresos
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.EaRendirCuentas ' "009 ' ENTREGAS A RENDIR CUENTAS
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CajaDefaul ' "001" ' Caja - Caja de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.Caja ' "CAJA" ' CAJA
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbPlanillaEgresos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPlanillaEgresos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmPlanillaEgresos"
                    frm.Text = "Planilla de egresos"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.PlanillaEgreso ' "054" '  Caja - PlanillaEgreso
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.PlaEgrPlanillaEgreso ' "084" ' Planilla de egreso
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales ' "012 ' CUENTAS X PAGAR COMERCIALES (PROVEEDORES)
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CajaDefaul ' "001" ' Caja - Caja de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.Caja ' "CAJA" ' CAJA
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReciboIngresosLegal"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReciboIngresosLegal") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmReciboIngresosLegal"
                    frm.Text = "Recibo de ingresos Legal"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.CajaIngreso ' "010" ' Caja - Ingresos
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso ' "019" ' Recibo de ingreso
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales ' "001 ' CUENTAS X COBRAR COMERCIALES (CLIENTES)
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CajaDefaul ' "001" ' Caja - Caja de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.Caja ' "CAJA" ' CAJA
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    'frm.WindowState = FormWindowState.Maximized
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbProcesosBanco"
                    RegistrarBarraBancoTesoreria()
                Case "tsbDepositoTercero"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDepositoTercero") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmDepositoTercero"
                    frm.Text = "Depósito tercero"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.DepositoTercero ' "055" ' Bancos - Ingresos
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.DepTerDepositoTercero ' "022" ' Depósito en cuenta de banco
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales ' "001 ' CUENTAS X COBRAR COMERCIALES (CLIENTES)
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CuentaBancoDefault ' "201 ' Caja - Cuenta de banco de la principal 
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.CtaBanco ' "CAJA" ' Cuenta de banco
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento4
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago3
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion2
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbNotaAbonoCtaBanco"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmNotaAbonoCtaBanco") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmNotaAbonoCtaBanco"
                    frm.Text = "Nota de abono de cuenta de banco"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco ' 
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.NABNotaAbonoCtaBanco ' 
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales ' "001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CuentaBancoDefault ' "201" ' Cuenta de banco - Cuenta de banco de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.CtaBanco ' "CUENTA DE BANCO" ' CUENTA DE BANCO
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento4
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago3
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion2
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDetraccionesNotaCargoCtaBanco"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDetraccionesNotaCargoCtaBanco") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmDetraccionesNotaCargoCtaBanco"
                    frm.Text = "Detracciones - Nota de cargo de cuenta de banco"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco ' 059
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.NCBDetraccionesNotaCargoCtaBanco ' 208
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales ' 012
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CuentaBancoDefault ' "201" ' Cuenta de banco - Cuenta de banco de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.CtaBanco ' "CUENTA DE BANCO" ' CUENTA DE BANCO
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbNotaCargoCtaBanco"
                    HabilitarSubMenu(False)
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()

                    If VerificarVentana(Elementos, "frmNotaCargoCtaBanco") Then
                        If VerificarVentana(Elementos, "frmNotaCargoCtaBanco01") Then
                            If VerificarVentana(Elementos, "frmNotaCargoCtaBanco02") Then
                                If VerificarVentana(Elementos, "frmNotaCargoCtaBanco03") Then
                                    If VerificarVentana(Elementos, "frmNotaCargoCtaBanco04") Then
                                        Exit Sub
                                    Else
                                        frm.Name = "frmNotaCargoCtaBanco04"
                                        frm.Text = "Nota de cargo de cuenta de banco04"
                                    End If
                                Else
                                    frm.Name = "frmNotaCargoCtaBanco03"
                                    frm.Text = "Nota de cargo de cuenta de banco03"
                                End If
                            Else
                                frm.Name = "frmNotaCargoCtaBanco02"
                                frm.Text = "Nota de cargo de cuenta de banco02"
                            End If
                        Else
                            frm.Name = "frmNotaCargoCtaBanco01"
                            frm.Text = "Nota de cargo de cuenta de banco01"
                        End If
                    Else
                        frm.Name = "frmNotaCargoCtaBanco"
                        frm.Text = "Nota de cargo de cuenta de banco"
                    End If

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco ' Banco - Egresos "017" ' Nota de cargo de cuenta de banco
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.NCBNotaCargoCtaBanco ' "086" ' Nota de cargo de cuenta de banco
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales ' "001" ' CUENTAS X PAGAR COMERCIALES (PROVEEDORES)
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CuentaBancoDefault ' "201" ' Cuenta de banco - Cuenta de banco de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.CtaBanco ' "CUENTA DE BANCO" ' CUENTA DE BANCO
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbVoucherCheque"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmVoucherCheque") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmVoucherCheque"
                    frm.Text = "Voucher cheque"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.VoucherCheque ' "017" ' Bancos - Egresos
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.VCVoucherCheque ' "143" ' Voucher cheque
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales ' "001 ' CUENTAS X COBRAR COMERCIALES (CLIENTES)
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CuentaBancoDefault ' "201" ' Caja - Cuenta en banco de la principal de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.CtaBanco ' "CAJA" ' Cuenta de banco
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbExtornoCheque"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTesoreriaExtorno") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreriaExtorno)()

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbCobranzaDudosa"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTesoreriaCobranza") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreriaCobranza)()

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbCobranzaLegal"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTesoreriaCobranzaLegal") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreriaCobranzaLegal)()

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbPrestamo"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPrestamo") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmPrestamo)()
                    frm.Name = "frmPrestamo"
                    frm.Text = "Prestamo"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "001" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCaja.PrestamoPersonal ' "035" 
                    frm.pDTD_ID = BCVariablesNames.ProcesosCaja.PrestamoPersonalEntregaRendir ' "288" 
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.PrestamosPersonal ' "002 ' 
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.CajaDefaul ' "001" ' Caja - Caja de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.Caja ' "CAJA" ' CAJA
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero

                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago0
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion1
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbTransferenciaEntreBancos"

                Case "tsbReportesTesoreria"
                    RegistrarBarraReportesTesoreria()
                Case "tsbMovimientoCajaBancos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmMovimientoCajaBancos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmMovimientoCajaBancos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbSaldoCajaBanco"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmSaldoCajaBanco") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmMovimientoCajaBancos)()
                    frm.Name = "frmSaldoCajaBanco"
                    frm.Text = "Saldos de Cajas/Bancos"
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbReporteCaja" ' REPORTE DE CAJA de finanzas
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteCajas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmReporteCajas)()
                    frm.Name = "frmReporteCajas"
                    frm.Text = "Cajas/Bancos Finanzas "
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()


                    'Cuentas Corrientes
                Case "tsbArticulosCuentasCorrientes"
                    RegistrarBarraArticulosCuentasCorrientes()
                Case "tsbListaPrecios"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmListaPreciosArticulos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmListaPreciosArticulos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDescuentoIncremento"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDescuentoIncrementoTipoVentaPersonas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmDescuentoIncrementoTipoVentaPersonas)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbActualizarPrecios"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmActualizarListaPreciosArticulos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmActualizarListaPreciosArticulos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbCopiarPrecios"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCopiarListaPreciosArticulos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmCopiarListaPreciosArticulos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbDatosCuentasCorrientes"
                    RegistrarBarraDatosCuentasCorrientes()
                Case "tsbTipoVenta"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmTipoVenta") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmTipoVenta)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbPermisoCuentaCorriente"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPermisoCuentaCorriente") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmPermisoCuentaCorriente)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()


                Case "tsbProcesosCuentasCorrientes"
                    RegistrarBarraProcesosCuentasCorrientes()
                Case "tsbCartaFianza"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCartaFianza") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmCartaFianza)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbPlanillaRendicionCuentas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmPlanillaRendicionCuentas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmPlanillaRendicionCuentas"
                    frm.Text = "Planilla rendición de cuentas"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "002" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas ' "049" 
                    frm.pDTD_ID = BCVariablesNames.ProcesosCtaCte.EntRenCuePlanillaRendicionCuentas ' "160" 
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.EaRendirCuentas ' "009 
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.PlaRenCtasDefault ' "029" ' Caja planilla rendición de cuentas default
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.LiquidacionDocumento ' "Liquidación de documento" 
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero
                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento3
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago4
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion0
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.WindowState = FormWindowState.Maximized
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()

                Case "tsbLiquidacionDocumento"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmLiquidacionDocumento") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of Tesoreria.Views.frmTesoreria)()
                    frm.Name = "frmLiquidacionDocumento"
                    frm.Text = "Liquidación de documentos"

                    frm.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal '  "002" ' Punto de venta de la principal
                    frm.pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento ' "020" 
                    frm.pDTD_ID = BCVariablesNames.ProcesosCtaCte.LiqDocLiquidacionDocumento ' "028" 
                    frm.pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte ' "000 
                    frm.pCCC_ID = BCVariablesNames.CCC_ID.LiqDocumentoDefault ' "098" ' Banco de la principal
                    frm.pCCC_TIPO = BCVariablesNames.TipoCajaCtaCte.LiquidacionDocumento ' "Liquidación de documento" 
                    frm.pPER_ID_CAJ = BCVariablesNames.CajeroDefault ' "000007" ' Personal - Cajero
                    frm.Movimiento = BCVariablesNames.Movimiento.Movimiento2
                    frm.Destino = BCVariablesNames.Destino.Destino0
                    frm.MedioPago = BCVariablesNames.MedioPago.MedioPago4
                    frm.Diferido = BCVariablesNames.Diferido.Diferido0
                    frm.Recepcion = BCVariablesNames.Recepcion.Recepcion0
                    frm.Ubicacion = BCVariablesNames.Ubicacion.Ubicacion0
                    frm.OperacionContable = BCVariablesNames.OperacionContable.OperacionContable0

                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.WindowState = FormWindowState.Maximized
                    frm.Activate()
                    frm.Show()
                    frm.BringToFront()


                Case "tsbReportesCuentasCorrientes"
                    RegistrarBarraReportesCuentasCorrientes()
                Case "tsbKardexCtaCte"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmKardexCtaCte") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmKardexCtaCte)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteListaPrecios"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteListaPrecios") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmReporteListaPrecios)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbSaldosTipoCliente"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteSaldosTipoCliente") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmReporteSaldosTipoCliente)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteDepositoTerceros"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteDepositoTerceros") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmReporteDepositoTerceros)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReporteCuentas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReporteCuentas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmReporteCuentas)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbReportePeriodo"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmReportePeriodo") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmReportePeriodo)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbKardexContabilidad"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmKardexContabilidad") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of CuentasCorrientes.Views.frmKardexContabilidad)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()

                    ' Activos Fijos
                Case "tsbDatosActivosFijos"
                    RegistrarBarraDatosActivosFijos()
                Case "tsbIncidencias"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmIncidencias") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of ActivosFijos.Views.frmIncidencias)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbCuentasActivos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmCuentasActivos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of ActivosFijos.Views.frmCuentasActivos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbEdificios"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmEdificios") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of ActivosFijos.Views.frmEdificios)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbOficinas"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmOficinas") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of ActivosFijos.Views.frmOficinas)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
                Case "tsbDepartamentosAdministrativos"
                    HabilitarSubMenu(False)
                    If VerificarVentana(Elementos, "frmDepartamentosAdministrativos") Then Exit Sub
                    Dim frm = Me.ContainerService.Resolve(Of ActivosFijos.Views.frmDepartamentosAdministrativos)()
                    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
                    frm.Show()
                    frm.BringToFront()
            End Select
        End Sub

        Private Sub HabilitarSubMenu(ByVal Encendido As Boolean)
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = Encendido
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = Encendido
        End Sub
        Private Function VerificarVentana(ByVal Elementos As Integer, ByVal Formulario As String) As Boolean
            VerificarVentana = False
            For Contador = 0 To Elementos - 1
                If System.Windows.Forms.Form.ActiveForm.MdiChildren.ElementAt(Contador).Name.ToString = Formulario Then
                    System.Windows.Forms.Form.ActiveForm.MdiChildren.ElementAt(Contador).WindowState = FormWindowState.Normal
                    System.Windows.Forms.Form.ActiveForm.MdiChildren.ElementAt(Contador).BringToFront()
                    VerificarVentana = True
                End If
            Next
        End Function
        'Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
        'Dim frm = Me.ContainerService.Resolve(Of frmTiposConceptos)()
        'frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
        'frm.Show()
        'End Sub
    End Class
End Namespace





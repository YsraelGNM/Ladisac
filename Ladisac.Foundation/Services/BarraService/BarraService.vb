Imports System.Windows.Forms

Namespace Ladisac.Foundation.Services
    Public Class BarraService
        Implements IBarraService
        Private _Barra As ToolStrip
        Public Sub RegistrarBarraPrincipal(ByVal Barra As System.Windows.Forms.ToolStrip) Implements IBarraService.RegistrarBarraPrincipal
            Me._Barra = Barra
        End Sub
        Public Sub RegistrarBotonBarra(ByVal Boton As System.Windows.Forms.ToolStripButton) Implements IBarraService.RegistrarBotonesBarra
            Dim ElementoBarra As System.Windows.Forms.ToolStripItem = Boton
            _Barra.Items.Add(ElementoBarra)
        End Sub
    End Class
End Namespace
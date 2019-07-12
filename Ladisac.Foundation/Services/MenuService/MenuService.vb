Imports System.Windows.Forms

Namespace Ladisac.Foundation.Services
    Public Class MenuService
        Implements IMenuService
        Private _Menu As MenuStrip
        Public Sub RegistrarMenu(ByVal grupo As String, ByVal mm As System.Windows.Forms.ToolStripMenuItem) Implements IMenuService.RegistrarMenu
            Dim menu As ToolStripMenuItem = Me._Menu.Items.Find(grupo, False).FirstOrDefault
            Try
                menu.DropDownItems.Add(mm)
            Catch ex As Exception
                MsgBox(ex.Message)
                '" Si ves te este mensaje es que hay error en instanciar un menú ,si en el MainWindow  ya ejecuta no se muestra tu menú verifica esta mal implementado madrony")
            End Try

        End Sub

        Public Sub RegistrarMenuPrincipal(ByVal menu As System.Windows.Forms.MenuStrip) Implements IMenuService.RegistrarMenuPrincipal
            Me._Menu = menu
        End Sub
    End Class

End Namespace


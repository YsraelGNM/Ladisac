Imports System.Windows.Forms

Namespace Ladisac.Foundation
    Public Class MainWindow
        Private Sub EventoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'Dim agg = Me.InternalBootStrapper.Container.Resolve(Of Microsoft.Practices.Prism.Events.IEventAggregator)()
            'Dim evento = agg.GetEvent(Of Ladisac.Foundation.ShowViewEvent)()
            'evento.Publish("frmMonedas")
        End Sub

        Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click

        End Sub

        Private Sub MainWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If MessageBox.Show("Desea Salir del Sistema?", "Atención", MessageBoxButtons.YesNo) = DialogResult.No Then
                e.Cancel = True
            End If
        End Sub

        Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
            Ladisac.Foundation.MainWindow.ActiveForm.Close()
        End Sub
    End Class
End Namespace

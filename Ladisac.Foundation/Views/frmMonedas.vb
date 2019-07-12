Imports Microsoft.Practices.Unity
Imports System.Windows.Forms

Namespace Ladisac.Foundation.Views
    Public Class frmMonedas
        <Dependency()> _
        Public Property BC As Ladisac.BL.IBCMonedaQueries
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            MessageBox.Show(BC.MonedaQuery())
            '''
        End Sub
    End Class

End Namespace

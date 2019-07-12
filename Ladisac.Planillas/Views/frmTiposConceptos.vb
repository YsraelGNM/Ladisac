Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmTiposConceptos

    <Dependency()>
    Public Property SessionService As Ladisac.Foundation.Services.ISessionService
    'gfvjghjghjgh
    <Dependency()>
    Public Property BCTiposConceptosQueries As Ladisac.BL.IBCTiposConceptosQueries


    Private Sub frmTiposConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Button1.Text = SessionService.UserId.ToString
        '---

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim result = Me.BCTiposConceptosQueries.TiposDocumentosQuery(Me.TextBox1.Text)

        Dim ds As New DataSet
        Dim sr As New StringReader(result)
        ds.ReadXml(sr)
        Me.DataGridView1.DataSource = ds.Tables(0)

    End Sub
End Class
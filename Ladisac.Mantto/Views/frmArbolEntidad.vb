Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms
Imports Ladisac.BE
Imports System.Drawing

Public Class frmArbolEntidad

    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    Private CodEntidad As Integer
    Private DesEntidad As String

    Private Sub frmEntidadTV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim nodoPadre As TreeNode

        tviEntidades.Nodes.Clear()

        'Nodo raíz
        nodoPadre = New TreeNode("/", 0, -1)
        tviEntidades.Nodes.Add(nodoPadre)

        'Nodos Hijos
        LlenarNodosHijos(nodoPadre)

        tviEntidades.ExpandAll()
    End Sub

    Private Sub LlenarNodosHijos(ByVal nodoPadre As TreeNode)

        Dim nodoHijo As TreeNode
        Dim lisEntidades As List(Of Entidad)

        lisEntidades = Me.BCEntidad.ListaHijos(nodoPadre.ImageIndex)

        If lisEntidades.Count <> 0 Then
            For Each ent As Entidad In lisEntidades
                nodoHijo = New TreeNode(ent.ENO_DESCRIPCION, ent.ENO_ID, ent.ENO_ID_PADRE)
                nodoPadre.Nodes.Add(nodoHijo)
            Next
        End If
    End Sub

    Private Sub tviEntidades_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tviEntidades.AfterSelect

        If tviEntidades.SelectedNode.ImageIndex <> 0 And tviEntidades.SelectedNode.Nodes.Count = 0 Then

            LlenarNodosHijos(tviEntidades.SelectedNode)
            tviEntidades.ExpandAll()

        End If

    End Sub

    Private Sub tviEntidades_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tviEntidades.NodeMouseClick

        If e.Button = MouseButtons.Right Then

            Dim p As New Point(e.X, e.Y)

            Dim nodo As New TreeNode

            nodo = tviEntidades.GetNodeAt(p)
            CodEntidad = nodo.ImageIndex
            DesEntidad = nodo.Text

            If Not nodo Is Nothing Then
                tviEntidades.SelectedNode = nodo
                cmsNodos.Show(tviEntidades, p)
            End If

        End If

    End Sub

    Private Sub mnuOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOT.Click
        'MessageBox.Show("Nodo seleccionado: " + CodEntidad.ToString + " - " + DesEntidad)
        Dim frmOT = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmOrdenTrabajo)()

        frmOT.IOT_CodEntidad = CodEntidad
        frmOT.IOT_DesEntidad = DesEntidad
        'frmOT.IOT_Observacion = dgvDetalle.CurrentRow.Cells("IOT_DESCRIPCION").Value

        frmOT.ShowDialog()
    End Sub
End Class
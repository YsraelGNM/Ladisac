Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms

Public Class frmCierreAlmacen
    <Dependency()> _
    Public Property BCAlmacen As Ladisac.BL.IBCAlmacen
    <Dependency()> _
    Public Property BCCierreAlmacen As Ladisac.BL.IBCCierreAlmacen
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService


    Protected mCIA As CierreAlmacen

    Private Sub frmCierreAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        CargarAlmacen(-1, treeAlmacen.Nodes(0))
    End Sub

    Sub CargarAlmacen(ByVal ALM_ID_PADRE As Integer, ByVal mNodePadre As TreeNode)
        For Each mAlmHijo In BCAlmacen.GetByIdPadre(ALM_ID_PADRE)
            ''''''''''''''''''''''''''''''''
            Dim mNode As New TreeNode
            mNode.Text = mAlmHijo.ALM_DESCRIPCION
            mNode.Tag = mAlmHijo.ALM_ID
            mNode.ToolTipText = mAlmHijo.ALM_ID

            'Dim NodPadre = (From mN As TreeNode In treeAlmacen.Nodes Where mN.Tag = ALM_ID_PADRE Select mN).FirstOrDefault
            treeAlmacen.SelectedNode = mNodePadre
            treeAlmacen.SelectedNode.Nodes.Add(mNode)
            CargarAlmacen(mAlmHijo.ALM_ID, mNode)
        Next
    End Sub


    Private Sub Procesar(ByVal n As TreeNode)
        If n.Tag <> -1 And n.Tag <> 0 Then

            If n.Checked Then
                mCIA = BCCierreAlmacen.CierreAlmacenGetByCierreAlmacen(numAnio.Value.ToString, numMes.Value.ToString.PadLeft(2, "0"), n.Tag)
                If mCIA Is Nothing Then
                    mCIA = New CierreAlmacen
                    mCIA.MarkAsAdded()
                    mCIA.ANIO = numAnio.Value.ToString
                    mCIA.MES = numMes.Value.ToString.PadLeft(2, "0")
                Else
                    mCIA.MarkAsModified()
                End If
                If rbtCerrar.Checked Then
                    mCIA.ALM_ID = Math.Abs(n.Tag)
                    mCIA.USU_ID = SessionServer.UserId
                    mCIA.CIA_FEC_GRAB = Now
                    mCIA.CIA_ESTADO = True
                    BCCierreAlmacen.MantenimientoCierreAlmacen(mCIA)
                End If
                If rbtAbrir.Checked Then
                    mCIA.ALM_ID = "-" & Str(Math.Abs(n.Tag)).Trim
                    mCIA.USU_ID = SessionServer.UserId
                    mCIA.CIA_FEC_GRAB = Now
                    mCIA.CIA_ESTADO = True
                    BCCierreAlmacen.MantenimientoCierreAlmacen(mCIA)
                End If
            End If

        End If


        For Each nodHijos As TreeNode In n.Nodes
            Procesar(nodHijos)
        Next

    End Sub

    Public Overrides Sub OnManGuardar()
        If Not validar_controles() Then Exit Sub
        Procesar(treeAlmacen.Nodes(0))
        MsgBox("Procesado.")
    End Sub

    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Not IsNumeric(numAnio.Value.ToString) Then Error_validacion.SetError(numAnio, "Ingrese un Año correcto.") : numAnio.Focus() : flag = False
        If Not IsNumeric(numMes.Value.ToString) Then Error_validacion.SetError(numMes, "Ingrese un Mes correcto.") : numMes.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Debe de ingresar datos los campos seleccionados", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'ingreso de codigo
    Sub LimpiarControles()
        mCIA = Nothing
        numAnio.Value = 0
        numMes.Value = 1
        rbtAbrir.Checked = False
        rbtCerrar.Checked = False

        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub treeAlmacen_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeAlmacen.AfterCheck
        SelecNode(e.Node)
    End Sub

    Public Sub SelecNode(ByVal Node As TreeNode)
        For Each mNod As TreeNode In Node.Nodes
            mNod.Checked = Node.Checked
            SelecNode(mNod)
        Next
    End Sub
End Class

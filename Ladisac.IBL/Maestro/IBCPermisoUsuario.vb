Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCPermisoUsuario

#Region "Mantenimientos"
        Sub MantenimientoUsuario(ByVal mUsuario As Usuarios)
#End Region

#Region "Querys"
        Function UsuarioGetById(ByVal USU_ID As String) As Usuarios
        Function ListaUsuarios() As String
#End Region

    End Interface

End Namespace

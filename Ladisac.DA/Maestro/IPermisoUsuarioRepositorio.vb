Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IPermisoUsuarioRepositorio
        Function GetById(ByVal USU_Id As String) As Usuarios
        Sub Maintenance(ByVal Usuario As Usuarios)
        Function ListaUsuarios() As String
    End Interface

End Namespace


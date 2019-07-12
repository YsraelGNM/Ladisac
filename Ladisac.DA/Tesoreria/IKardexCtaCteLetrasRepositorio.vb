Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IKardexCtaCteLetrasRepositorio
        Function Maintenance(ByVal item As KardexCtaCteLetras) As Short
        Function DeleteRegistro(ByVal item As KardexCtaCteLetras) As Short
        Function spActualizarRegistro(ByVal Orm As KardexCtaCteLetras) As Short
        Function spInsertarRegistro(ByVal Orm As KardexCtaCteLetras) As Short
        Function spEliminarRegistro(ByVal Orm As KardexCtaCteLetras) As Short
    End Interface
End Namespace

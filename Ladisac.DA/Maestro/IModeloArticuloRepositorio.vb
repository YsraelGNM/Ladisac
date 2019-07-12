Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IModeloArticuloRepositorio
        Function GetById(ByVal MOD_Id As String) As ModeloArticulos
        Sub Maintenance(ByVal Modelo As ModeloArticulos)
        Function ListaModelo() As String
    End Interface

End Namespace


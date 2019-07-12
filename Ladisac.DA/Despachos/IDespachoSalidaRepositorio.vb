Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IDespachoSalidaRepositorio
        Function GetById(ByVal DSA_ID As String) As DespachoSalida
        Sub Maintenance(ByVal DespachoSalida As DespachoSalida)
        Function ListaDespachoSalida() As String
    End Interface

End Namespace


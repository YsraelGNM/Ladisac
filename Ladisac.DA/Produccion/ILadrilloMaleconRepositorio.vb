Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ILadrilloMaleconRepositorio
        Function GetById(ByVal LMA_Id As Integer) As LadrilloMalecon
        Function GetById2(ByVal HOR_Id As Integer, ByVal Nro_Male As String, ByVal PRO_Id As Integer) As LadrilloMalecon
        Sub Maintenance(ByVal LadrilloMalecon As LadrilloMalecon)
        Function ListaLadrilloMalecon() As String
    End Interface

End Namespace


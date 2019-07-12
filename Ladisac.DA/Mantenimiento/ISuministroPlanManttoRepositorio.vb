Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISuministroPlanManttoRepositorio
        Function GetById(ByVal SPM_Id As Integer) As SuministroPlanMantto
        Sub Maintenance(ByVal SuministroPlanMantto As SuministroPlanMantto)
        Function ListaSuministroPlanMantto() As String
    End Interface

End Namespace


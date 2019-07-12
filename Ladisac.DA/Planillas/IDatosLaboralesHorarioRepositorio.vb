
Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IDatosLaboralesHorarioRepositorio

        Function getById(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As DatosLaboralesHorario
        Function Mantenace(ByVal item As BE.DatosLaboralesHorario) As Boolean

    End Interface

End Namespace


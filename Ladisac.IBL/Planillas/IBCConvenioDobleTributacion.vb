Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCConvenioDobleTributacion
#Region "Mantenimiento"
        Function MAintenance(ByVal item As ConvenioDobleTributacion)

#End Region

#Region "Consulta"
        Function ConvenioDobleTributacionQuery(ByVal cod_DobleTribu_Id As String, ByVal cod_Descripcion As String)
        Function ConvenioDobleTributacionSeek(ByVal id As String) As BE.ConvenioDobleTributacion
#End Region


    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCNivelEducacion
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As NivelEducacion)
'#End Region
'#Region "Consulta"
'        Function NivelEducacionQuery(ByVal nie_NiveEduc_Id As String, ByVal nie_Descipcion As String)
'        Function NivelEducacionSeek(ByVal id As String) As BE.NivelEducacion

'#End Region


'    End Interface

'End Namespace


Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA

    Public Class DetalleConceptosPlanillasRepositorio
        Implements IDetalleConceptosPlanillasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function GetById(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal dcp_ItemDetConcPlan As String) As BE.DetalleConceptosPlanillas Implements IDetalleConceptosPlanillasRepositorio.GetById
            Dim result As BE.DetalleConceptosPlanillas = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetalleConceptosPlanillas.Include("RolOpeCtaCte.CtaCte") _
                          .Include("RolOpeCtaCte.DetalleTipoDocumentos") _
                          Where c.tit_TipoTrab_Id = tit_TipoTrab_Id _
                          And c.tip_TipoPlan_Id = tip_TipoPlan_Id _
                          And c.ItemConceptoPlanilla = ItemConceptoPlanilla).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function Mantenance(ByVal item As BE.DetalleConceptosPlanillas) As Boolean Implements IDetalleConceptosPlanillasRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetalleConceptosPlanillas.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function
    End Class

End Namespace

'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Class NivelEducacionRepositorio
'        Implements INivelEducacionRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal id As String) As BE.NivelEducacion Implements INivelEducacionRepositorio.GetById
'            Dim result As NivelEducacion = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.NivelEducacion Where c.nie_NiveEduc_Id Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Mantenance(ByVal item As BE.NivelEducacion) As Boolean Implements INivelEducacionRepositorio.Mantenance
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                context.NivelEducacion.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()
'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return False
'        End Function
'    End Class

'End Namespace


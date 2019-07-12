Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class DetallePlanillaRepositorio
        Implements IDetallePlanillaRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal tipoDoc As String, ByVal serie As String, ByVal numero As String, ByVal items As String) As BE.DetallePlanillas Implements IDetallePlanillaRepositorio.GetById
            Dim result As BE.DetallePlanillas = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetallePlanillas Where c.tdo_Id = tipoDoc And c.pla_SeriePlani = serie And c.pla_Numero).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.DetallePlanillas) As Object Implements IDetallePlanillaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetallePlanillas.ApplyChanges(item)
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
'Imports System.Text

'Namespace Ladisac.DA
'    Public Class DetallePermisosTrabajadorRepositorio
'        Implements IDetallePermisosTrabajadorRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function GetById(ByVal numero As String, ByVal item As String) As BE.DetallePermisosTrabajador Implements IDetallePermisosTrabajadorRepositorio.GetById
'            Dim result As BE.DetallePermisosTrabajador = Nothing

'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DetallePermisosTrabajador Where c.prm_Numero = numero And c.dper_Item = item Select c)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function


'        Public Function Maintenance(ByVal item As BE.DetallePermisosTrabajador) As Object Implements IDetallePermisosTrabajadorRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetallePermisosTrabajador.ApplyChanges(item)
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

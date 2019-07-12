Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class DetalleTrabajadorHorasRepositorio
        Implements IDetalleTrabajadorHorasRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function GetById(ByVal tipoTrabajadro As String, ByVal numero As String, ByVal item As String) As Object Implements IDetalleTrabajadorHorasRepositorio.GetById
            Dim result As DetalleTrabajadorHoras = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetalleTrabajadorHoras Where c.tit_TipoTrab_Id = tipoTrabajadro And c.trh_Numero = numero Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.DetalleTrabajadorHoras) As Boolean Implements IDetalleTrabajadorHorasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetalleTrabajadorHoras.ApplyChanges(item)
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
'    Public Class DetallePrestamosTrabajadorRepositorio
'        Implements IDetallePrestamosTrabajadorRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function GetById(ByVal serie As String, ByVal numero As String, ByVal item As String) As BE.DetallePrestamosTrabajador Implements IDetallePrestamosTrabajadorRepositorio.GetById
'            Dim result As DetallePrestamosTrabajador = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DetallePrestamosTrabajador _
'                           Where c.prt_SeriePres = serie And c.prt_NumeroPres = numero And c.dpt_ItemPresta = item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.DetallePrestamosTrabajador) As Boolean Implements IDetallePrestamosTrabajadorRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetallePrestamosTrabajador.ApplyChanges(item)
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



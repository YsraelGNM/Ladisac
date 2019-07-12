Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA

    Public Class DetalleProvisionComprasRepositorio
        Implements IDetalleProvisionComprasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function Maintenance(ByVal item As BE.DetalleProvisionCompras) As Object Implements IDetalleProvisionComprasRepositorio.Maintenance
            Dim result As BE.DetalleProvisionCompras = Nothing

            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetalleProvisionCompras.ApplyChanges(item)
                context.SaveChanges()
                context.AcceptAllChanges()
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
'    Public Class DetalleAsientosManualesRepositorio
'        Implements IDetalleAsientosManualesRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String, ByVal dam_Item As String) As BE.DetalleAsientosManuales Implements IDetalleAsientosManualesRepositorio.GetById
'            Dim result As BE.DetalleAsientosManuales = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DetalleAsientosManuales _
'                          Where c.lib_Id = lib_Id And _
'                          c.prd_Periodo_id = prd_Periodo_id And _
'                          c.asm_NumeroVoucher = asm_NumeroVoucher And _
'                          c.dam_Item = dam_Item).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.DetalleAsientosManuales) As Boolean Implements IDetalleAsientosManualesRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetalleAsientosManuales.ApplyChanges(item)
'                context.SaveChanges()
'                context.AcceptAllChanges()
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


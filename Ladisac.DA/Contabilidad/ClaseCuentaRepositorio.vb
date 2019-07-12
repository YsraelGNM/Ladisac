Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Namespace Ladisac.DA

    Public Class ClaseCuentaRepositorio
        Implements IClaseCuentaRepositorio

        <Dependency()> _
        Public Property ContainerService() As IUnityContainer

        Public Function GetById(ByVal id As String) As BE.ClaseCuenta Implements IClaseCuentaRepositorio.GetById
            Dim result As BE.ClaseCuenta = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ClaseCuenta Where c.cls_Id = id Select c).FirstOrDefault


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.ClaseCuenta) As Boolean Implements IClaseCuentaRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.ClaseCuenta.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Return True
            Catch ex As Exception
                Dim rethro = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethro) Then
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

'    Public Class CuentasContablesRepositorio
'        Implements ICuentasContablesRepositorio


'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal id As String) As BE.CuentasContables Implements ICuentasContablesRepositorio.GetById
'            Dim result As CuentasContables = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.CuentasContables Where c.CUC_ID = id Select c)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function Mantenance(ByVal item As BE.CuentasContables) As Boolean Implements ICuentasContablesRepositorio.Mantenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.CuentasContables.ApplyChanges(item)
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

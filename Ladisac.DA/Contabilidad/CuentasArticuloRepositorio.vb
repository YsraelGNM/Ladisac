Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Namespace Ladisac.DA

    Public Class CuentasArticuloRepositorio
        Implements ICuentasArticuloRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal id As String) As BE.CuentasArticulo Implements ICuentasArticuloRepositorio.GetById
            Dim result As BE.CuentasArticulo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.CuentasArticulo Where c.lin_Id = id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.CuentasArticulo) As Boolean Implements ICuentasArticuloRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.CuentasArticulo.ApplyChanges(item)
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


'    Public Class LibrosContablesRepositorio
'        Implements ILibrosContablesRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal id As String) As BE.LibrosContables Implements ILibrosContablesRepositorio.GetById
'            Dim result As BE.LibrosContables = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.LibrosContables Where c.lib_Id = id Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return result

'        End Function

'        Public Function Mantenance(ByVal item As BE.LibrosContables) As Boolean Implements ILibrosContablesRepositorio.Mantenance
'            Try

'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.LibrosContables.ApplyChanges(item)
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


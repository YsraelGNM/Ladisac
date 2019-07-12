Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCLibrosContables
        Implements IBCLibrosContables

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function LibrosContablesQuery(ByVal lib_Id As String, ByVal lib_Libro As String, ByVal lib_Descripcion As String) As Object Implements IBCLibrosContables.LibrosContablesQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPLibrosContablesSelectXML, lib_Id, lib_Libro, lib_Descripcion)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function LibrosContablesDividendosQuery(ByVal lib_Id As String, ByVal lib_Libro As String, ByVal lib_Descripcion As String) As Object Implements IBCLibrosContables.LibrosContablesDividendosQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPLibrosContablesDividendosSelectXML, lib_Id, lib_Libro, lib_Descripcion)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function LibrosContablesSeek(ByVal id As String) As BE.LibrosContables Implements IBCLibrosContables.LibrosContablesSeek
            Dim result As BE.LibrosContables = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.ILibrosContablesRepositorio)()
                result = rep.GetById(id)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.LibrosContables) As Object Implements IBCLibrosContables.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILibrosContablesRepositorio)()
                Return rep.Mantenance(item)
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


'Imports Ladisac.BL
'Namespace Ladisac.BL

'    Public Class BCClaseCuenta
'        Implements IBCClaseCuenta


'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function ClaseCuentaQuery(ByVal cls_Id As String, ByVal cls_Clase As String) As Object Implements IBCClaseCuenta.ClaseCuentaQuery

'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPClaseCuentaSelectXML, cls_Id, cls_Clase)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return result

'        End Function

'        Public Function ClaseCuentaSeek(ByVal id As String) As BE.ClaseCuenta Implements IBCClaseCuenta.ClaseCuentaSeek
'            Dim result As BE.ClaseCuenta = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IClaseCuentaRepositorio)()
'                result = rep.GetById(id)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.ClaseCuenta) As Object Implements IBCClaseCuenta.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IClaseCuentaRepositorio)()
'                Return rep.Mantenance(item)
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
Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCCuentasArticulo
        Implements IBCCuentasArticulo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CuentasArticuloQuery(ByVal id As String) As Object Implements IBCCuentasArticulo.CuentasArticuloQuery
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPCuentasArticuloSelectXML, id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result

        End Function

        Public Function CuentasArticuloSeek(ByVal id As String) As BE.CuentasArticulo Implements IBCCuentasArticulo.CuentasArticuloSeek
            Dim result As BE.CuentasArticulo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuentasArticuloRepositorio)()
                result = rep.GetById(id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.CuentasArticulo) As Object Implements IBCCuentasArticulo.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuentasArticuloRepositorio)()
                Return rep.Mantenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False

        End Function

        Public Function SPArticulosLadrillo(ByVal ART_ID As String, ByVal ART_COD_FAB As String, ByVal ART_DESCRIPCION As String) As Object Implements IBCCuentasArticulo.SPArticulosLadrillo
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPArticulosLadrillo, ART_ID, ART_COD_FAB, ART_DESCRIPCION)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function
    End Class

End Namespace

'Imports Ladisac.BE

'Namespace Ladisac.BL
'    Public Class BCLibrosContables
'        Implements IBCLibrosContables

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function LibrosContablesQuery(ByVal lib_Id As String, ByVal lib_Libro As String, ByVal lib_Descripcion As String) As Object Implements IBCLibrosContables.LibrosContablesQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPLibrosContablesSelectXML, lib_Id, lib_Libro, lib_Descripcion)

'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function LibrosContablesSeek(ByVal id As String) As BE.LibrosContables Implements IBCLibrosContables.LibrosContablesSeek
'            Dim result As BE.LibrosContables = Nothing

'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ILibrosContablesRepositorio)()
'                result = rep.GetById(id)
'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.LibrosContables) As Object Implements IBCLibrosContables.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ILibrosContablesRepositorio)()
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

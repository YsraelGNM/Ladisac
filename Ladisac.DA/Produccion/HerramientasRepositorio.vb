Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class HerramientasRepositorio
        Implements IHerramientasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetId(ByVal Tabla As String) As Integer Implements IHerramientasRepositorio.GetId
            Dim result As Integer
            'Try
            '    Dim context = ContainerService.Resolve(Of LadisacEntities)()
            '    result = context.spGetId(Tabla).FirstOrDefault()
            'Catch ex As Exception
            '    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
            '    If (rethrow) Then
            '        Throw
            '    End If
            'End Try
            'Return result
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spGetId")
                context.AddInParameter(cmd, "Tabla", DbType.String, Tabla)
                result = context.ExecuteScalar(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetIdTx(ByVal Tabla As String) As String Implements IHerramientasRepositorio.GetIdTx
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spGetId")
                context.AddInParameter(cmd, "Tabla", DbType.String, Tabla)
                result = context.ExecuteScalar(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Get_CodSegundaLadrillo(ByVal Art_Id_Ladrillo As String) As String Implements IHerramientasRepositorio.Get_CodSegundaLadrillo
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spGetCodSegundaLadrillo")
                context.AddInParameter(cmd, "Art_Id", DbType.String, Art_Id_Ladrillo)
                result = context.ExecuteScalar(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function


        Public Function GetCodigoArticuloTx(ByVal GLI_ID As String) As String Implements IHerramientasRepositorio.GetCodigoArticuloTx
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spGetCodigoArticulo")
                context.AddInParameter(cmd, "GLI_ID", DbType.String, GLI_ID)
                result = context.ExecuteScalar(cmd)
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

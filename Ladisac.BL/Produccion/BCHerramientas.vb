Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCHerramientas
        Implements IBCHerramientas

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function Get_Id(ByVal Tabla As String) As Integer Implements IBCHerramientas.Get_Id
            Dim result As Integer
            Try
                Dim rep = ContainerService.Resolve(Of DA.IHerramientasRepositorio)()
                result = rep.GetId(Tabla)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Get_IdTx(ByVal Tabla As String) As String Implements IBCHerramientas.Get_IdTx
            Dim result As String
            Try
                Dim rep = ContainerService.Resolve(Of DA.IHerramientasRepositorio)()
                result = rep.GetIdTx(Tabla)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Get_CodSegundaLadrillo(ByVal Art_Id_Ladrillo As String) As String Implements IBCHerramientas.Get_CodSegundaLadrillo
            Dim result As String
            Try
                Dim rep = ContainerService.Resolve(Of DA.IHerramientasRepositorio)()
                result = rep.Get_CodSegundaLadrillo(Art_Id_Ladrillo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Get_CodigoArticuloTx(ByVal GLI_ID As String) As String Implements IBCHerramientas.Get_CodigoArticuloTx
            Dim result As String
            Try
                Dim rep = ContainerService.Resolve(Of DA.IHerramientasRepositorio)()
                result = rep.GetCodigoArticuloTx(GLI_ID)
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

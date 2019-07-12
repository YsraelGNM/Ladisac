Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCSalidaVigilancia
        Implements IBCSalidaVigilancia

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaSalidaVigilancia() As String Implements IBCSalidaVigilancia.ListaSalidaVigilancia

        End Function

        Public Sub MantenimientoSalidaVigilancia(ByVal mSalidaVigilancia As BE.SalidaVigilancia) Implements IBCSalidaVigilancia.MantenimientoSalidaVigilancia

        End Sub

        Public Function SalidaVigilanciaGetByDocumento(ByVal Documento As String) As BE.SalidaVigilancia Implements IBCSalidaVigilancia.SalidaVigilanciaGetByDocumento
            Dim result As SalidaVigilancia = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISalidaVigilanciaRepositorio)()
                result = rep.GetByIdDocumento(Documento)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SalidaVigilanciaGetById(ByVal SVI_ID As Integer) As BE.SalidaVigilancia Implements IBCSalidaVigilancia.SalidaVigilanciaGetById
            Dim result As SalidaVigilancia = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISalidaVigilanciaRepositorio)()
                result = rep.GetById(SVI_ID)
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

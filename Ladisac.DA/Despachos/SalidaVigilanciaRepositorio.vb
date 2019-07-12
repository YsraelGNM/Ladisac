Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class SalidaVigilanciaRepositorio
        Implements ISalidaVigilanciaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal SVI_Id As Integer) As BE.SalidaVigilancia Implements ISalidaVigilanciaRepositorio.GetById
            Dim result As SalidaVigilancia = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.SalidaVigilancia Where c.SVI_ID = SVI_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetByIdDocumento(ByVal Documento As String) As BE.SalidaVigilancia Implements ISalidaVigilanciaRepositorio.GetByIdDocumento
            Dim result As SalidaVigilancia = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.SalidaVigilancia Where c.DOCUMENTO = Documento Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSalidaVigilancia() As String Implements ISalidaVigilanciaRepositorio.ListaSalidaVigilancia

        End Function

        Public Sub Maintenance(ByVal SalidaVigilancia As BE.SalidaVigilancia) Implements ISalidaVigilanciaRepositorio.Maintenance

        End Sub
    End Class

End Namespace



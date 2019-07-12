Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ReciclajeLadrilloVentaRepositorio
        Implements IReciclajeLadrilloVentaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal RCL_Id As Integer) As BE.ReciclajeLadrilloVenta Implements IReciclajeLadrilloVentaRepositorio.GetById
            Dim result As ReciclajeLadrilloVenta = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ReciclajeLadrilloVenta Where c.RCL_ID = RCL_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaReciclajeLadrilloVenta() As String Implements IReciclajeLadrilloVentaRepositorio.ListaReciclajeLadrilloVenta
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaReciclajeLadrilloVenta")
                Dim reader = context.ExecuteReader(cmd)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                result = sb.ToString()

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal ReciclajeLadrilloVenta As BE.ReciclajeLadrilloVenta) Implements IReciclajeLadrilloVentaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ReciclajeLadrilloVenta.ApplyChanges(ReciclajeLadrilloVenta)
                context.SaveChanges()
                ReciclajeLadrilloVenta.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



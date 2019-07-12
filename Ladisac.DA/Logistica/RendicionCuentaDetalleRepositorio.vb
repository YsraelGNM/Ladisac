Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class RendicionCuentaDetalleRepositorio
        Implements IRendicionCuentaDetalleRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
       
        Public Function GetById(ByVal RCD_ID As Integer) As BE.RendicionCuentaDetalle Implements IRendicionCuentaDetalleRepositorio.GetById
            Dim result As RendicionCuentaDetalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.RendicionCuentaDetalle.Include("Articulos").Include("Personas.DocPersonas") Where c.RCD_ID = RCD_ID Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaRendicionCuentaDetalle() As String Implements IRendicionCuentaDetalleRepositorio.ListaRendicionCuentaDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaRendicionCuentaDetalle")
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

        Public Sub Maintenance(ByVal RendicionCuentaDetalle As BE.RendicionCuentaDetalle) Implements IRendicionCuentaDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim mP As Integer = RendicionCuentaDetalle.PCD_ID
                Dim mPCD As ProcesoCompraDetalle = Nothing
                mPCD = (From c In context.ProcesoCompraDetalle Where c.PCD_ID = mP Select c).FirstOrDefault
                mPCD.MarkAsDeleted()
                context.ProcesoCompraDetalle.ApplyChanges(mPCD)
                mPCD.AcceptChanges()

                context.RendicionCuentaDetalle.ApplyChanges(RendicionCuentaDetalle)
                context.SaveChanges()
                RendicionCuentaDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



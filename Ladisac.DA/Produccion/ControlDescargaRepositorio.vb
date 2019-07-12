Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ControlDescargaRepositorio
        Implements IControlDescargaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal DES_Id As Integer) As BE.ControlDescarga Implements IControlDescargaRepositorio.GetById
            Dim result As ControlDescarga = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlDescarga Where c.DES_ID = DES_Id Select c).FirstOrDefault
                Dim Detalle = (From d In context.CaCoDe_Detalle.Include("ControlCarga.Produccion.Ladrillo.Articulos").AsQueryable Where d.DES_ID = result.DES_ID And d.CCD_FECHA = result.DES_FECHA Select d)
                result.CaCoDe_Detalle = New List(Of CaCoDe_Detalle)
                For Each mItem In Detalle.ToList
                    result.CaCoDe_Detalle.Add(mItem)
                Next
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlDescarga() As String Implements IControlDescargaRepositorio.ListaControlDescarga
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlDescarga")
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

        Public Sub Maintenance(ByVal ControlDescarga As BE.ControlDescarga) Implements IControlDescargaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlDescarga.ApplyChanges(ControlDescarga)
                context.SaveChanges()
                ControlDescarga.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



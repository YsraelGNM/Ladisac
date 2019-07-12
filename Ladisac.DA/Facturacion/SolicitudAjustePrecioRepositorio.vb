Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class SolicitudAjustePrecioRepositorio
        Implements ISolicitudAjustePrecioRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal SAP_ID As Integer) As BE.SolicitudAjustePrecio Implements ISolicitudAjustePrecioRepositorio.GetById
            Dim result As SolicitudAjustePrecio = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.SolicitudAjustePrecio.Include("Personas").Include("Personas1").Include("SolicitudAjustePrecioDetalle.Articulos") Where c.SAP_ID = SAP_ID Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSolicitudAjustePrecio() As String Implements ISolicitudAjustePrecioRepositorio.ListaSolicitudAjustePrecio
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaSolicitudAjustePrecio")
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

        Public Sub Maintenance(ByVal SolicitudAjustePrecio As BE.SolicitudAjustePrecio) Implements ISolicitudAjustePrecioRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.SolicitudAjustePrecio.ApplyChanges(SolicitudAjustePrecio)
                context.SaveChanges()
                SolicitudAjustePrecio.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class CuentaRendirRepositorio
        Implements ICuentaRendirRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal CRE_ID As Integer) As BE.CuentaRendir Implements ICuentaRendirRepositorio.GetById
            Dim result As CuentaRendir = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.CuentaRendir.Include("CuentaRendirDetalle.Articulos.UnidadMedidaArticulos").Include("CuentaRendirDetalle.Personas.DocPersonas").Include("CuentaRendirDetalle.Moneda").Include("Tesoreria.DetalleTipoDocumentos").Include("Tesoreria.DetalleTesoreria.Personas") Where c.CRE_ID = CRE_ID Select c).FirstOrDefault
                Dim mper As String = result.Tesoreria.DetalleTesoreria(0).PER_ID_CLI
                Dim dal = (From d In context.DatosLaborales.Include("AreaTrabajos") Where d.per_Id = mper Select d)
                For Each mdal In dal.ToList
                    result.Tesoreria.DetalleTesoreria(0).Personas.DatosLaborales.Add(mdal)
                Next
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCuentaRendir() As String Implements ICuentaRendirRepositorio.ListaCuentaRendir
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaCuentaRendir")
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

        Public Function Maintenance(ByVal CuentaRendir As BE.CuentaRendir) As Integer Implements ICuentaRendirRepositorio.Maintenance
            Dim Result As Integer = 0
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.CuentaRendir.ApplyChanges(CuentaRendir)
                context.SaveChanges()
                CuentaRendir.AcceptChanges()
                Result = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Result = 0
            End Try
            Return Result
        End Function
    End Class

End Namespace



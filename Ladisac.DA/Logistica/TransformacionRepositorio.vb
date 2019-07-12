Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class TransformacionRepositorio

        Implements ITransformacionRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal TFO_ID As Integer) As BE.Transformacion Implements ITransformacionRepositorio.GetById
            Dim result As Transformacion = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Transformacion.Include("TransformacionDetalle.Articulos.UnidadMedidaArticulos").Include("Personas").Include("TransformacionDetalle.Personas") Where c.TFO_ID = TFO_ID Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTransformacion() As String Implements ITransformacionRepositorio.ListaTransformacion
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaTransformacion")
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

        Public Sub Maintenance(ByVal Transformacion As BE.Transformacion) Implements ITransformacionRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Transformacion.ApplyChanges(Transformacion)
                context.SaveChanges()
                Transformacion.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaTransformacionID(ByVal TFO_ID As Integer?) As System.Data.DataSet Implements ITransformacionRepositorio.ListaTransformacionID
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaTransformacionID", TFO_ID)
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub ActualizarPUServicioTransformacion(ByVal TFO_ID As Integer?, ByVal ART_ID As String, ByVal PU As Decimal?, ByVal TRD_NRO_SERVICIO As String, ByVal PER_ID As String) Implements ITransformacionRepositorio.ActualizarPUServicioTransformacion
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spActualizarPUServicioTransformacion", TFO_ID, ART_ID, PU, TRD_NRO_SERVICIO, PER_ID)
                context.ExecuteNonQuery(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace



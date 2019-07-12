Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ControlParadaRepositorio
        Implements IControlParadaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal CPA_Id As Integer) As BE.ControlParada Implements IControlParadaRepositorio.GetById
            Dim result As ControlParada = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlParada.Include("Produccion.Ladrillo.Articulos").Include("Personas").Include("Personas1").Include("Personas2").Include("ControlParadaDetalle.Parada").Include("ControlParadaMoldeDetalle.Molde").Include("ControlParadaArticuloDetalle.Articulos") Where c.CPA_ID = CPA_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlParada() As String Implements IControlParadaRepositorio.ListaControlParada
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlParada")
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

        Public Sub Maintenance(ByVal ControlParada As BE.ControlParada) Implements IControlParadaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlParada.ApplyChanges(ControlParada)
                context.SaveChanges()
                ControlParada.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetByPro_Id(ByVal PRO_Id As Integer) As System.Collections.Generic.List(Of BE.ControlParada) Implements IControlParadaRepositorio.GetByPro_Id
            Dim result As New List(Of ControlParada)
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim result1 = From c In context.ControlParada.Include("Produccion").Include("Personas").Include("Personas1").Include("Personas2").Include("ControlParadaDetalle.Parada").Include("ControlParadaMoldeDetalle.Molde").Include("ControlParadaArticuloDetalle.Articulos") Where c.PRO_ID = PRO_Id Select c
                For Each mItem In result1
                    result.Add(mItem)
                Next
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



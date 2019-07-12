Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ControlCancheroRepositorio
        Implements IControlCancheroRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal CCA_Id As Integer) As BE.ControlCanchero Implements IControlCancheroRepositorio.GetById
            Dim result As ControlCanchero = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlCanchero.Include("Produccion.Ladrillo.Articulos").Include("ControlCancheroDetalle.Cancha").Include("Personas") Where c.CCA_ID = CCA_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlCanchero() As String Implements IControlCancheroRepositorio.ListaControlCanchero
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlCanchero")
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

        Public Sub Maintenance(ByVal ControlCanchero As BE.ControlCanchero) Implements IControlCancheroRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlCanchero.ApplyChanges(ControlCanchero)
                context.SaveChanges()
                ControlCanchero.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetByPro_Id(ByVal PRO_Id As Integer) As System.Collections.Generic.List(Of BE.ControlCanchero) Implements IControlCancheroRepositorio.GetByPro_Id
            Dim result As New List(Of ControlCanchero)
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim result1 = From c In context.ControlCanchero.Include("Produccion").Include("ControlCancheroDetalle.Cancha").Include("Personas") Where c.PRO_ID = PRO_Id Select c
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



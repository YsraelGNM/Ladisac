Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ControlMezclaRepositorio
        Implements IControlMezclaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal CME_Id As Integer) As BE.ControlMezcla Implements IControlMezclaRepositorio.GetById
            Dim result As ControlMezcla = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlMezcla.Include("ControlMezclaRecetaDetalle.Articulos").Include("ControlMezclaMezclaDetalle.Cats").Include("ControlMezclaMezclaDetalle.Personas").Include("Produccion.Ladrillo.Articulos") Where c.CME_ID = CME_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlMezcla() As String Implements IControlMezclaRepositorio.ListaControlMezcla
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlMezcla")
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

        Public Sub Maintenance(ByVal ControlMezcla As BE.ControlMezcla) Implements IControlMezclaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlMezcla.ApplyChanges(ControlMezcla)
                context.SaveChanges()
                ControlMezcla.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetByIdPRO(ByVal PRO_Id As Integer) As System.Collections.Generic.List(Of BE.ControlMezcla) Implements IControlMezclaRepositorio.GetByIdPRO
            Dim result As New List(Of ControlMezcla)
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim result1 = From c In context.ControlMezcla.Include("ControlMezclaRecetaDetalle.Articulos").Include("ControlMezclaMezclaDetalle.Cats").Include("ControlMezclaMezclaDetalle.Personas").Include("Produccion.Ladrillo.Articulos") Where c.PRO_ID = PRO_Id Order By c.CME_ID Select c
                For Each mItem In result1.ToList
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



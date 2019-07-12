Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ControlPesoRepositorio
        Implements IControlPesoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal CPE_Id As Integer) As BE.ControlPeso Implements IControlPesoRepositorio.GetById
            Dim result As ControlPeso = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlPeso.Include("Produccion.Ladrillo.Articulos").Include("ControlPesoDetalle.Personas") Where c.CPE_ID = CPE_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlPeso() As String Implements IControlPesoRepositorio.ListaControlPeso
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlPeso")
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

        Public Sub Maintenance(ByVal ControlPeso As BE.ControlPeso) Implements IControlPesoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlPeso.ApplyChanges(ControlPeso)
                context.SaveChanges()
                ControlPeso.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetByIdPRO(ByVal PRO_Id As Integer) As BE.ControlPeso Implements IControlPesoRepositorio.GetByIdPRO
            Dim result As ControlPeso = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlPeso.Include("Produccion.Ladrillo.Articulos").Include("ControlPesoDetalle.Personas") Where c.PRO_ID = PRO_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetPromPesoByIdPRO(ByVal PRO_Id As Integer) As Decimal Implements IControlPesoRepositorio.GetPromPesoByIdPRO
            Dim result As Decimal = 0
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                Dim Pro = (From c In context.ControlPeso.Include("ControlPesoDetalle") Where c.PRO_ID = PRO_Id Select c).FirstOrDefault
                Try
                    result = (From c In Pro.ControlPesoDetalle Where c.DPE_TIPO = "SE" Select c.DPE_PESO).Average
                Catch ex As Exception
                    result = 0
                End Try


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



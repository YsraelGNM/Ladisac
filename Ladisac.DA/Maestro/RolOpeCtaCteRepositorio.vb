Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class RolOpeCtaCteRepositorio
        Implements IRolOpeCtaCteRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.RolOpeCtaCte) As Short Implements IRolOpeCtaCteRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.RolOpeCtaCte.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Maintenance = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Maintenance = 0
            End Try
        End Function

        Public Function CargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IRolOpeCtaCteRepositorio.CargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spCargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SignoCargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IRolOpeCtaCteRepositorio.SignoCargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spSignoCargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Signo_DCargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IRolOpeCtaCteRepositorio.Signo_DCargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spSigno_DCargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Signo_D_1CargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IRolOpeCtaCteRepositorio.Signo_D_1CargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spSigno_D_1CargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MovimientoCargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IRolOpeCtaCteRepositorio.MovimientoCargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spMovimientoCargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
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

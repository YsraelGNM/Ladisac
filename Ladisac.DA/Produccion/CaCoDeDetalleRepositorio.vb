Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class CaCoDeDetalleRepositorio
        Implements ICaCoDeDetalleRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal CCD_Id As Integer) As BE.CaCoDe_Detalle Implements ICaCoDeDetalleRepositorio.GetById
            Dim result As CaCoDe_Detalle = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.CaCoDe_Detalle.Include("ControlCarga").Include("LadrilloMalecon.Ladrillo.Articulos") Where c.CCD_ID = CCD_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCaCoDeDetalle(ByVal Dia As Date, ByVal HOR_ID As Integer) As String Implements ICaCoDeDetalleRepositorio.ListaCaCoDeDetalle
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaCaCoDeDetalle")
                context.AddInParameter(cmd, "Dia", DbType.Date, Dia)
                context.AddInParameter(cmd, "HOR_ID", DbType.Int32, HOR_ID)
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

        Public Sub Maintenance(ByVal CaCoDeDetalle As BE.CaCoDe_Detalle) Implements ICaCoDeDetalleRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.CaCoDe_Detalle.ApplyChanges(CaCoDeDetalle)
                context.SaveChanges()
                CaCoDeDetalle.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ValidarCarga(ByVal PRO_ID As Integer) As System.Data.DataSet Implements ICaCoDeDetalleRepositorio.ValidarCarga
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spValidarCarga", PRO_ID)
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCaCoDeDetalleObj(ByVal Dia As Date, ByVal HOR_ID As Integer) As System.Collections.Generic.ICollection(Of BE.CaCoDe_Detalle) Implements ICaCoDeDetalleRepositorio.ListaCaCoDeDetalleObj
            Dim result As ICollection(Of CaCoDe_Detalle) = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim Rpta = (From c In context.CaCoDe_Detalle.Include("ControlCarga").Include("LadrilloMalecon.Ladrillo.Articulos") Where c.CCD_FECHA = Dia And c.HOR_ID = HOR_ID Select c)
                result = Rpta.ToList
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



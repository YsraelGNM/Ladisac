Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class RegistroMaquinaRepositorio
        Implements IRegistroMaquinaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal RMA_Id As Integer) As BE.RegistroMaquina Implements IRegistroMaquinaRepositorio.GetById
            Dim result As RegistroMaquina = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.RegistroMaquina.Include("Entidad") Where c.RMA_ID = RMA_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaRegistroMaquina() As String Implements IRegistroMaquinaRepositorio.ListaRegistroMaquina
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaRegistroMaquina")
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

        Public Sub Maintenance(ByVal RegistroMaquina As BE.RegistroMaquina) Implements IRegistroMaquinaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                Dim result As RegistroMaquina = Nothing
                result = (From c In context.RegistroMaquina.Include("Entidad") Where c.ENO_ID = RegistroMaquina.ENO_ID And c.RMA_ID <> RegistroMaquina.RMA_ID Order By c.RMA_FECHA Descending Select c).FirstOrDefault

                Dim Hora As Decimal = 0
                Dim Kilometros As Decimal = 0
                Dim Tn As Decimal = 0
                Dim Dia As Decimal = 0
                Dim Uso As Decimal = 0

                If result IsNot Nothing Then
                    Hora = result.RMA_HOROMETRO - RegistroMaquina.RMA_HOROMETRO
                    Kilometros = result.RMA_KILOMETRAJE - RegistroMaquina.RMA_KILOMETRAJE
                Else
                    Hora = RegistroMaquina.RMA_HOROMETRO
                    Kilometros = RegistroMaquina.RMA_KILOMETRAJE
                End If
                Tn = RegistroMaquina.RMA_TN
                Dia = RegistroMaquina.RMA_DIA
                Uso = RegistroMaquina.RMA_USO

                If RegistroMaquina.Entidad Is Nothing Then
                    RegistroMaquina.Entidad = (From c In context.Entidad Where c.ENO_ID = RegistroMaquina.ENO_ID Select c).FirstOrDefault
                End If

                RegistroMaquina.Entidad.MarkAsModified()
                RegistroMaquina.Entidad.ENO_HORAS += Hora
                RegistroMaquina.Entidad.ENO_KILOMETROS += Kilometros
                RegistroMaquina.Entidad.ENO_TN += Tn
                RegistroMaquina.Entidad.ENO_DIA += Dia
                RegistroMaquina.Entidad.ENO_USO += Uso

                Dim contextSP = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = contextSP.GetStoredProcCommand("UpDate_Trab")
                contextSP.AddInParameter(cmd, "Eno_Id", DbType.Int32, RegistroMaquina.ENO_ID)
                contextSP.AddInParameter(cmd, "Saldo_Horas", DbType.Decimal, Hora)
                contextSP.AddInParameter(cmd, "Saldo_Kilometros", DbType.Decimal, Kilometros)
                contextSP.AddInParameter(cmd, "Saldo_Tn", DbType.Decimal, Tn)
                contextSP.AddInParameter(cmd, "Saldo_Dia", DbType.Decimal, Dia)
                contextSP.AddInParameter(cmd, "Saldo_Uso", DbType.Decimal, Uso)
                contextSP.ExecuteNonQuery(cmd)

                'PlanMantto
                Dim colPmo = (From c In context.PlanMantto Where c.ENO_ID = RegistroMaquina.ENO_ID Select c)
                For Each mPmo In colPmo.ToList
                    mPmo.MarkAsModified()
                    mPmo.PMO_HORA_UTIL += Hora
                    mPmo.PMO_KILOMETRO_UTIL += Kilometros
                    mPmo.PMO_TN_UTIL += Tn
                    mPmo.PMO_DIA_UTIL += Dia
                    mPmo.PMO_USO_UTIL += Uso
                    context.PlanMantto.ApplyChanges(mPmo)
                Next
                context.Entidad.ApplyChanges(RegistroMaquina.Entidad)
                context.RegistroMaquina.ApplyChanges(RegistroMaquina)
                context.SaveChanges()

                RegistroMaquina.Entidad.AcceptChanges()
                RegistroMaquina.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

    End Class

End Namespace



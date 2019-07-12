Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class LadrilloMaleconRepositorio
        Implements ILadrilloMaleconRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal LMA_Id As Integer) As BE.LadrilloMalecon Implements ILadrilloMaleconRepositorio.GetById
            Dim result As LadrilloMalecon = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.LadrilloMalecon Where c.LMA_ID = LMA_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaLadrilloMalecon() As String Implements ILadrilloMaleconRepositorio.ListaLadrilloMalecon
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaLadrilloMalecon")
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

        Public Sub Maintenance(ByVal LadrilloMalecon As BE.LadrilloMalecon) Implements ILadrilloMaleconRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.LadrilloMalecon.ApplyChanges(LadrilloMalecon)
                context.SaveChanges()
                LadrilloMalecon.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetById2(ByVal HOR_Id As Integer, ByVal Nro_Male As String, ByVal PRO_Id As Integer) As BE.LadrilloMalecon Implements ILadrilloMaleconRepositorio.GetById2
            Dim result As LadrilloMalecon = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From lm In context.LadrilloMalecon Join mp In context.MaleconPuerta On lm.MAL_ID Equals mp.MAL_ID _
                                                            Join pu In context.PuertaHorno On mp.PUE_ID Equals pu.PUE_ID _
                                                            Join pr In context.Produccion On lm.LAD_ID Equals pr.LAD_ID
                                                            Where pr.PRO_ID = PRO_Id And pu.HOR_ID = HOR_Id And mp.MAL_DES_CORTA = Nro_Male Select lm).FirstOrDefault
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



Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCDatosLaboralesHorario
        Implements BL.IBCDatosLaboralesHorario
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Public Function DatosLaboralesHorarioQuery(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As Object Implements IBCDatosLaboralesHorario.DatosLaboralesHorarioQuery
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDatosLaboralesHorarioSelectXML, per_Id, crv_ItemCroVaca)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function DatosLaboralesHorarioSeek(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As BE.DatosLaboralesHorario Implements IBCDatosLaboralesHorario.DatosLaboralesHorarioSeek
            Dim result As BE.DatosLaboralesHorario = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.DatosLaboralesHorarioRepositorio)()
                result = rep.getById(per_Id, crv_ItemCroVaca)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal items As System.Collections.Generic.List(Of BE.DatosLaboralesHorario)) As Object Implements IBCDatosLaboralesHorario.Maintenance

            Try
                Dim repDET = ContainerService.Resolve(Of DA.IDatosLaboralesHorarioRepositorio)()
                Using Scope As New System.Transactions.TransactionScope


                    For Each mItemIngreso In items

                        repDET.Mantenace(mItemIngreso)
                    Next
                    Scope.Complete()

                End Using
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function
    End Class
End Namespace


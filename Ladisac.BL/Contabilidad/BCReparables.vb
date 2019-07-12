Imports Ladisac.BE
Namespace Ladisac.BL


    Public Class BCReparables
        Implements IBCReparables
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function spTiposReparablesSelectXML(ByVal rep_Descripcion As String) As Object Implements IBCReparables.spTiposReparablesSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spTiposReparablesSelectXML, rep_Descripcion)

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

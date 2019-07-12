Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCTiposTrabajador
        Implements IBCTiposTrabajador


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.TiposTrabajador) As Boolean Implements IBCTiposTrabajador.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposTrabajadorRepositorio)()
                Return rep.Mantenance(item)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function



        Public Function TiposTrabajadorQuery(ByVal tit_TipoTrab_Id As String, ByVal tit_Descripcion As String) Implements IBCTiposTrabajador.TiposTrabajadorQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTiposTrabajadorSelectXML, tit_TipoTrab_Id, tit_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (result) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function TiposTrabajadorSeek(ByVal id As String) As BE.TiposTrabajador Implements IBCTiposTrabajador.TiposTrabajadorSeek
            Dim result As TiposTrabajador = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposTrabajadorRepositorio)()
                result = rep.GetById(id)

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


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Class BCTiposContratos

'        Implements IBCTiposContratos
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        Public Sub Maintenance(ByVal item As BE.TiposContratos) Implements BL.IBCTiposContratos.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ITiposContratosRepositorio)()
'                rep.Mantenance(item)
'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'        End Sub

'        Public Function TiposContratosQuery(ByVal tic_TipoCont_Id As String, ByVal tico_Descripcion As String) As Object Implements BL.IBCTiposContratos.TiposContratosQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPTiposContratosSelectXML, tic_TipoCont_Id, tico_Descripcion)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function TiposContratosSeek(ByVal id As String) As BE.TiposContratos Implements BL.IBCTiposContratos.TiposContratosSeek
'            Dim resault As TiposContratos = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ITiposContratosRepositorio)()
'                resault = rep.GetById(id)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return resault
'        End Function
'    End Class

'End Namespace

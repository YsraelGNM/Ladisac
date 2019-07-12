Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetalleConceptosPlanillas
        Implements IBCDetalleConceptosPlanillas


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function DetalleConceptosPlanillasQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String) As Object Implements IBCDetalleConceptosPlanillas.DetalleConceptosPlanillasQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleConceptosPlanillasSelectXML, tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla, cop_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DetalleConceptosPlanillasSeek(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String) As BE.DetalleConceptosPlanillas Implements IBCDetalleConceptosPlanillas.DetalleConceptosPlanillasSeek
            Dim result As DetalleConceptosPlanillas = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleConceptosPlanillasRepositorio)()
                result = rep.GetById(tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla, cop_Descripcion)

            Catch ex As Exception
                Dim rethorw = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethorw) Then
                    Throw
                End If
            End Try

            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.DetalleConceptosPlanillas) As Object Implements IBCDetalleConceptosPlanillas.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleConceptosPlanillasRepositorio)()
                Return rep.Mantenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False

        End Function

        Public Function DetalleConceptosPlanillasDetalleQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String) As Object Implements IBCDetalleConceptosPlanillas.DetalleConceptosPlanillasDetalleQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleConceptosPlanillasDetalleSelectXML, tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla, cop_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DetalleConceptosPlanillasListaQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_Descripcion As String, ByVal concepto As String, Optional ByVal Es_judicial As Boolean = Nothing, Optional ByVal Es_Descuento As Boolean = Nothing) As Object Implements IBCDetalleConceptosPlanillas.DetalleConceptosPlanillasListaQuery

            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleConceptosPlanillasListaSelectXML, tit_TipoTrab_Id, tip_Descripcion, concepto, Es_judicial, Es_Descuento)

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
'    Public Class BCNivelEducacion
'        Implements IBCNivelEducacion

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function Maintenance(ByVal item As BE.NivelEducacion) As Object Implements IBCNivelEducacion.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.INivelEducacionRepositorio)()
'                Return rep.Mantenance(item)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function

'        Public Function NivelEducacionQuery(ByVal nie_NiveEduc_Id As String, ByVal nie_Descipcion As String) As Object Implements IBCNivelEducacion.NivelEducacionQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPNivelEducacionSelectXML, nie_NiveEduc_Id, nie_Descipcion)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function NivelEducacionSeek(ByVal id As String) As BE.NivelEducacion Implements IBCNivelEducacion.NivelEducacionSeek
'            Dim result As NivelEducacion = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.INivelEducacionRepositorio)()
'                result = rep.GetById(id)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function
'    End Class

'End Namespace

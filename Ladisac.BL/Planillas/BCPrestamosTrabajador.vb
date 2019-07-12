Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCPrestamosTrabajador
        Implements IBCPrestamosTrabajador
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Public Function Maintenance(ByVal item As BE.PrestamosTrabajador) As Object Implements IBCPrestamosTrabajador.Maintenance

            Try
                Dim repCab = ContainerService.Resolve(Of DA.IPrestamosTrabajadorRepositorio)()
                Dim repDet = ContainerService.Resolve(Of DA.IDetallePrestamosTrabajadorRepositorio)()
                Dim sCorrelativo As String = Nothing

                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.PrestamosTrabajador", "prt_NumeroPres", 10, " where prt_SeriePres='" & item.prt_SeriePres & "'")
                    item.prt_NumeroPres = sCorrelativo
                End If
                ' si se cambian estos valores tambien debes modificarlos en el frm planillas en el metodo guardar

                item.CCT_ID = "002"
                item.DTD_ID = "054"
                item.TDO_ID = "035"

                Dim listaDET As New List(Of DetallePrestamosTrabajador)
                For Each RowDET In item.DetallePrestamosTrabajador
                    Dim newDET As New DetallePrestamosTrabajador

                    RowDET.CCT_ID = item.CCT_ID
                    RowDET.DTD_ID = item.DTD_ID
                    RowDET.TDO_ID = item.TDO_ID


                    newDET = RowDET.Clone
                    newDET.prt_NumeroPres = item.prt_NumeroPres
                    listaDET.Add(newDET)
                Next

                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetallePrestamosTrabajador = Nothing
                item.Personas = Nothing
                item.Personas1 = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 10, 0))

                    repCab.Maintenance(item)

                    For Each mitemIngreso In listaDET
                        mitemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                        mitemIngreso.prt_NumeroPres = item.prt_NumeroPres
                        mitemIngreso.Conceptos = Nothing
                        mitemIngreso.ChangeTracker.ChangeTrackingEnabled = True
                        repDet.Maintenance(mitemIngreso)
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

        Public Function PrestamosTrabajadorQuery(ByVal codigo As String, ByVal nombre As String) As Object Implements IBCPrestamosTrabajador.PrestamosTrabajadorQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPrestamosTrabajadorSelectXML, codigo, nombre)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function PrestamosTrabajadroSeek(ByVal serie As String, ByVal numero As String) As Object Implements IBCPrestamosTrabajador.PrestamosTrabajadroSeek
            Dim result As BE.PrestamosTrabajador = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPrestamosTrabajadorRepositorio)()
                result = rep.GetById(serie, numero)

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

'    Public Class BCDatosTrabajadorJudicial
'        Implements IBCDatosTrabajadorJudicial
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil


'        Public Function DatosTrabajadorJudicialQuery(ByVal codigo As String, ByVal nombre As String) As Object Implements IBCDatosTrabajadorJudicial.DatosTrabajadorJudicialQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPDatosTrabajadorJudicialSelectXML, codigo, nombre)


'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function DatosTrabajadorJudicialSeek(ByVal serie As String, ByVal numero As String) As Object Implements IBCDatosTrabajadorJudicial.DatosTrabajadorJudicialSeek

'            Dim result As DatosTrabajadorJudicial = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDatosTrabajadorJudicialRepositorio)()
'                result = rep.GetById(serie, numero)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.DatosTrabajadorJudicial) As Object Implements IBCDatosTrabajadorJudicial.Maintenance
'            Try
'                Dim repCAB = ContainerService.Resolve(Of DA.DatosTrabajadorJudicialRepositorio)()
'                Dim repDET = ContainerService.Resolve(Of DA.IDetalleTrabajadorJudicialRepositorio)()
'                Dim sCorrelativo As String = Nothing

'                '   Using Scope As New System.Transactions.TransactionScope()

'                If (item.ChangeTracker.State = ObjectState.Added) Then
'                    sCorrelativo = BCUtil.GetId("pla.DatosTrabajadorJudicial", "dtj_NumeroJudi", 10, " where dtj_SerieJudi='" & item.dtj_SerieJudi & "'")
'                    item.dtj_NumeroJudi = sCorrelativo
'                End If

'                Dim listaDET As New List(Of DetalleTrabajadorJudicial)
'                For Each RowDET In item.DetalleTrabajadorJudicial

'                    Dim NewDET As New DetalleTrabajadorJudicial

'                    NewDET = RowDET.Clone
'                    NewDET.dtj_NumeroJudi = item.dtj_NumeroJudi
'                    listaDET.Add(NewDET)
'                Next
'                item.ChangeTracker.ChangeTrackingEnabled = False
'                item.DetalleTrabajadorJudicial = Nothing

'                item.ChangeTracker.ChangeTrackingEnabled = True

'                repCAB.Maintenance(item)

'                For Each mItemIngreso In listaDET
'                    ' If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
'                    mItemIngreso.dtj_NumeroJudi = item.dtj_NumeroJudi

'                    ' End If
'                    repDET.Maintenance(mItemIngreso)
'                Next
'                'Scope.Complete()


'                '   End Using
'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function
'    End Class

'End Namespace

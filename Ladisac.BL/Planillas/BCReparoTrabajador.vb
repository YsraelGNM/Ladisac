Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCReparoTrabajador
        Implements IBCReparoTrabajador

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        Public Function Maintenance(ByVal item As BE.ReparoTrabajador) As Object Implements IBCReparoTrabajador.Maintenance
            Dim x As Integer = 0
            Try
                Dim repCab = ContainerService.Resolve(Of DA.IReparoTrabajadorRepositorio)()
                Dim repDet = ContainerService.Resolve(Of DA.DetalleReparoTrabajadorRepositorio)()
                Dim sCorrelativo As String = Nothing

                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.ReparoTrabajador", "ret_Numero", 10, "")
                    item.ret_Numero = sCorrelativo
                End If


                Dim listaDET As New List(Of DetalleReparoTrabajador)
                For Each RowDET In item.DetalleReparoTrabajador
                    Dim newDET As New DetalleReparoTrabajador

                    'If (newDET.ChangeTracker.State = ObjectState.Modified) Then
                    '    If (Val(newDET.dret_Item) > x) Then
                    '        x = Val(newDET.dret_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                    '    End If

                    'End If

                    newDET = RowDET.Clone
                    newDET.ret_Numero = item.ret_Numero
                    listaDET.Add(newDET)
                Next

                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleReparoTrabajador = Nothing
                item.Personas = Nothing
                item.Personas = Nothing

                item.ChangeTracker.ChangeTrackingEnabled = True

                x = CInt(BCUtil.GetId("pla.DetalleReparoTrabajador", "dret_Item", 3, " where ret_Numero='" & item.ret_Numero & "' "))

                Using Scope As New System.Transactions.TransactionScope
                    repCab.Maintenance(item)

                    For Each mitemIngreso In listaDET


                        If (mitemIngreso.ChangeTracker.State = ObjectState.Added) Then

                            mitemIngreso.dret_Item = Right("0000" & x.ToString(), 3)
                            x += 1
                        End If

                        mitemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                        mitemIngreso.ret_Numero = item.ret_Numero
                        mitemIngreso.Personas = Nothing
                        mitemIngreso.ChangeTracker.ChangeTrackingEnabled = True
                        repDet.maintenance(mitemIngreso)
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

        Public Function ReparoTrabajadorQuery(ByVal numero As String, ByVal observaciones As String, ByVal desdeFecha As DateTime, ByVal hastaFecha As DateTime) As Object Implements IBCReparoTrabajador.ReparoTrabajadorQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPReparoTrabajadorSelectXML, numero, observaciones, desdeFecha, hastaFecha)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function ReparoTrabajadorSeek(ByVal numero As String) As Object Implements IBCReparoTrabajador.ReparoTrabajadorSeek
            Dim result As BE.ReparoTrabajador = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReparoTrabajadorRepositorio)()
                result = rep.GetById(numero)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SPDetalleReparoTrabajadorSelect(ByVal numero As String) As Object Implements IBCReparoTrabajador.SPDetalleReparoTrabajadorSelect

            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleReparoTrabajadorSelect, numero)

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

'    Public Class BCPrestamosTrabajador
'        Implements IBCPrestamosTrabajador
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil

'        Public Function Maintenance(ByVal item As BE.PrestamosTrabajador) As Object Implements IBCPrestamosTrabajador.Maintenance

'            Try
'                Dim repCab = ContainerService.Resolve(Of DA.IPrestamosTrabajadorRepositorio)()
'                Dim repDet = ContainerService.Resolve(Of DA.IDetallePrestamosTrabajadorRepositorio)()
'                Dim sCorrelativo As String = Nothing
'                'Using Scope As New System.Transactions.TransactionScope
'                If (item.ChangeTracker.State = ObjectState.Added) Then
'                    sCorrelativo = BCUtil.GetId("pla.PrestamosTrabajador", "prt_NumeroPres", 10, " where prt_SeriePres='" & item.prt_SeriePres & "'")
'                    item.prt_NumeroPres = sCorrelativo
'                End If

'                item.CCT_ID = "010"
'                item.DTD_ID = "054"
'                item.TDO_ID = "035"

'                Dim listaDET As New List(Of DetallePrestamosTrabajador)
'                For Each RowDET In item.DetallePrestamosTrabajador
'                    Dim newDET As New DetallePrestamosTrabajador

'                    RowDET.CCT_ID = item.CCT_ID
'                    RowDET.DTD_ID = item.DTD_ID
'                    RowDET.TDO_ID = item.TDO_ID


'                    newDET = RowDET.Clone
'                    newDET.prt_NumeroPres = item.prt_NumeroPres
'                    listaDET.Add(newDET)
'                Next

'                item.ChangeTracker.ChangeTrackingEnabled = False
'                item.DetallePrestamosTrabajador = Nothing
'                item.Personas = Nothing
'                item.Personas1 = Nothing
'                item.ChangeTracker.ChangeTrackingEnabled = True

'                repCab.Maintenance(item)

'                For Each mitemIngreso In listaDET
'                    mitemIngreso.ChangeTracker.ChangeTrackingEnabled = False
'                    mitemIngreso.prt_NumeroPres = item.prt_NumeroPres
'                    mitemIngreso.Conceptos = Nothing
'                    mitemIngreso.ChangeTracker.ChangeTrackingEnabled = True
'                    repDet.Maintenance(mitemIngreso)
'                Next
'                '   Scope.Complete()
'                'End Using
'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function

'        Public Function PrestamosTrabajadorQuery(ByVal codigo As String, ByVal nombre As String) As Object Implements IBCPrestamosTrabajador.PrestamosTrabajadorQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPPrestamosTrabajadorSelectXML, codigo, nombre)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return result
'        End Function

'        Public Function PrestamosTrabajadroSeek(ByVal serie As String, ByVal numero As String) As Object Implements IBCPrestamosTrabajador.PrestamosTrabajadroSeek
'            Dim result As BE.PrestamosTrabajador = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IPrestamosTrabajadorRepositorio)()
'                result = rep.GetById(serie, numero)

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


Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCPermisosTrabajador
        Implements IBCPermisosTrabajador

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Public Function Maintenance(ByVal item As BE.PermisosTrabajador) As Object Implements IBCPermisosTrabajador.Maintenance
            Dim x As Integer = 0
            Try
                Dim repCAB = ContainerService.Resolve(Of DA.IPermisosTrabajadorRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetallePermisosTrabajadorRepositorio)()
                Dim sCorrelativo As String = Nothing


                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.PermisosTrabajador", "prm_Numero", 10)
                    item.prm_Numero = sCorrelativo
                End If
                Dim listaDET As New List(Of DetallePermisosTrabajador)

                For Each RowDET In item.DetallePermisosTrabajador
                    Dim NewDET As New DetallePermisosTrabajador
                    NewDET = RowDET.Clone
                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.dper_Item) > x) Then
                            x = Val(NewDET.dper_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If
                    listaDET.Add(NewDET)


                Next
                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetallePermisosTrabajador = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True


                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 10, 0))

                    repCAB.Maintenance(item)

                    For Each mItemIngreso In listaDET
                        x += 1
                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngreso.dper_Item = Right("0000" & x.ToString(), 3)
                        End If

                        mItemIngreso.prm_Numero = item.prm_Numero
                        repDET.Maintenance(mItemIngreso)
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

        Public Function PermisosTrabajadorQuery(ByVal numero As String, ByVal persona As String, ByVal codigo As String) As Object Implements IBCPermisosTrabajador.PermisosTrabajadorQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPermisosTrabajadorSelectXML, numero, persona, codigo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PermisosTrabajadorSeek(ByVal numero As String) As Object Implements IBCPermisosTrabajador.PermisosTrabajadorSeek
            Dim result As BE.PermisosTrabajador = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPermisosTrabajadorRepositorio)()
                result = rep.GetbyId(numero)

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


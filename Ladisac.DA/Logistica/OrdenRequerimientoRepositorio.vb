Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class OrdenRequerimientoRepositorio
        Implements IOrdenRequerimientoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal ORR_Id As Integer) As OrdenRequerimiento Implements IOrdenRequerimientoRepositorio.GetById
            Dim result As OrdenRequerimiento = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                'context.ContextOptions.LazyLoadingEnabled = False
                result = (From c In context.OrdenRequerimiento.Include("OrdenRequerimientoDetalle.Articulos.UnidadMedidaArticulos").Include("Personas1").Include("Personas").Include("OrdenRequerimientoDetalle.OrdenTrabajo.Entidad").Include("OrdenRequerimientoDetalle.OrdenTrabajo.Mantto").Include("OrdenRequerimientoDetalle.Entidad.UnidadesTransporte.Personas") Where c.ORR_ID = ORR_Id Select c).FirstOrDefault
                'For Each mItem In result.OrdenRequerimientoDetalle
                '    Dim rep1 = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                '    Dim ruta As String = rep1.EjecutarReporte("spRuta", mItem.OrdenTrabajo.ENO_ID)
                '    mItem.OrdenTrabajo.Entidad.Ruta = ruta
                'Next
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenRequerimiento(ByVal Filtro As String) As DataSet Implements IOrdenRequerimientoRepositorio.ListaOrdenRequerimiento
            Dim result As DataSet = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenRequerimiento2", IIf(Filtro = "", "", "WHERE " & Filtro))
                result = context.ExecuteDataSet(cmd)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal OrdenRequerimiento As OrdenRequerimiento) Implements IOrdenRequerimientoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.OrdenRequerimiento.ApplyChanges(OrdenRequerimiento)
                context.SaveChanges()
                OrdenRequerimiento.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaORDocumentacion(ByVal ORR_Id As Integer?) As System.Data.DataSet Implements IOrdenRequerimientoRepositorio.ListaORDocumentacion
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenRequerimientoDocumentacion", ORR_Id)
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaORSalidaCombustible(ByVal ORR_Id As Integer?) As System.Data.DataSet Implements IOrdenRequerimientoRepositorio.ListaORSalidaCombustible
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenRequerimientoSalidaCombustible", ORR_Id)
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaORLadrillo(ByVal ORR_Id As Integer?) As System.Data.DataSet Implements IOrdenRequerimientoRepositorio.ListaORLadrillo
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenRequerimientoLadrillo", ORR_Id)
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenRequerimientoServicio(ByVal Filtro As String) As System.Data.DataSet Implements IOrdenRequerimientoRepositorio.ListaOrdenRequerimientoServicio
            Dim result As DataSet = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenRequerimientoServicio", IIf(Filtro = "", "", "WHERE " & Filtro))
                result = context.ExecuteDataSet(cmd)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CantidadPorAtender(ByVal ART_ID As String) As Double Implements IOrdenRequerimientoRepositorio.CantidadPorAtender
            Dim result As Double = 0
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim mCantidadporAtender = From c In context.OrdenRequerimiento Join cd In context.OrdenRequerimientoDetalle On c.ORR_ID Equals cd.ORR_ID Where c.ORR_CERRADA = 0 And cd.ART_ID = ART_ID Group cd By ArtiId = cd.ART_ID Into Gpr = Group Select M1 = Gpr.Sum(Function(cd) CDbl(cd.ORD_CANTIDAD - cd.ORD_CANTIDAD_ATENDIDA))
                If mCantidadporAtender.Count > 0 Then
                    result = CDbl(mCantidadporAtender.Sum())
                End If
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CantidadPorComprar(ByVal ART_ID As String) As Double Implements IOrdenRequerimientoRepositorio.CantidadPorComprar
            Dim result As Double = 0
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                Dim mCantidadPorComprar = From c In context.OrdenRequerimiento Join cd In context.OrdenRequerimientoDetalle On c.ORR_ID Equals cd.ORR_ID Where c.ORR_CERRADA = 0 And cd.ART_ID = ART_ID And cd.ORD_CANTIDAD_COMPRA > 0 Select cd.ORD_CANTIDAD_COMPRA
                If mCantidadPorComprar.Count > 0 Then
                    result = CDbl(mCantidadPorComprar.Sum())
                End If
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



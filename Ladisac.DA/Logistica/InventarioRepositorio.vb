Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class InventarioRepositorio
        Implements IInventarioRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal INV_Id As Integer) As BE.Inventario Implements IInventarioRepositorio.GetById
            Dim result As Inventario = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Inventario.Include("Almacen").Include("Articulos.UnidadMedidaArticulos").Include("UbicacionAlmacen") Where c.INV_ID = INV_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaInventario() As String Implements IInventarioRepositorio.ListaInventario
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaInventario")
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

        Public Sub Maintenance(ByVal Inventario As BE.Inventario) Implements IInventarioRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Inventario.ApplyChanges(Inventario)
                context.SaveChanges()
                Inventario.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetById_Fecha(ByVal Fecha As Date) As System.Linq.IQueryable(Of Inventario) Implements IInventarioRepositorio.GetById_Fecha
            Dim result As System.Linq.IQueryable(Of Inventario) = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = From c In context.Inventario.Include("Almacen").Include("Articulos.UnidadMedidaArticulos").Include("UbicacionAlmacen") Where c.INV_FECHA = Fecha Select c
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaAInventariar(ByVal Fecha As Date, ByVal ALM_ID As Integer, ByVal UBI_ID As Integer) As String Implements IInventarioRepositorio.ListaAInventariar
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaAInventariar", Fecha, ALM_ID, UBI_ID)
                cmd.CommandTimeout = 90
                Dim reader = context.ExecuteReader(cmd)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                result = sb.ToString()

                cmd.Connection.Close()
                cmd.Dispose()
                context = Nothing
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function AddToContext(ByVal context As Object, ByVal mInventario As BE.Inventario, ByRef count As Integer, ByVal commitCount As Integer, ByVal recreateContext As Boolean) As Object Implements IInventarioRepositorio.AddToContext
            'context.Set<Entity>().Add(entity)
            context.Inventario.AddObject(mInventario)
            If count Mod commitCount = 0 Then
                context.SaveChanges()
                If recreateContext Then
                    context.Dispose()
                    context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                    'context.Configuration.AutoDetectChangesEnabled = False
                    count = 0
                End If
            End If
            Return context
        End Function

        Public Sub MaintenanceMassive(ByVal colInventario As System.Collections.Generic.List(Of BE.Inventario)) Implements IInventarioRepositorio.MaintenanceMassive
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                'context.Configuration.AutoDetectChangesEnabled = False
                Dim count As Integer = 0
                For Each mInventario In colInventario.ToList
                    count += 1
                    'context = AddToContext(context, mInventario, count, 5000, True)
                    context = AddToContext(context, mInventario, count, 1, True)
                Next
                context.SaveChanges()
            Catch ex As Exception

            End Try

        End Sub
    End Class

End Namespace



Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ArticuloAlmacenRepositorio
        Implements IArticuloAlmacenRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal ARA_Id As String) As BE.ArticuloAlmacen Implements IArticuloAlmacenRepositorio.GetById
            Dim result As ArticuloAlmacen = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ArticuloAlmacen.Include("Articulos").Include("Almacen").Include("UbicacionAlmacen") Where c.ARA_ID = ARA_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal ArticuloAlmacen As BE.ArticuloAlmacen) Implements IArticuloAlmacenRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ArticuloAlmacen.ApplyChanges(ArticuloAlmacen)
                context.SaveChanges()
                ArticuloAlmacen.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaArticuloAlmacen(ByVal Art_Id As String, ByVal ALM_Id As Integer?) As String Implements IArticuloAlmacenRepositorio.ListaArticuloAlmacen
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaArticuloAlmacen")
                context.AddInParameter(cmd, "Art_Id", DbType.String, Art_Id)
                context.AddInParameter(cmd, "Alm_Id", DbType.Int16, ALM_Id)
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

        Public Function GetById(ByVal Art_Id As String, ByVal ALM_Id As Integer) As BE.ArticuloAlmacen Implements IArticuloAlmacenRepositorio.GetById
            Dim result As ArticuloAlmacen = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ArticuloAlmacen.Include("Articulos").Include("Almacen").Include("UbicacionAlmacen") Where c.ART_ID = Art_Id And c.ALM_ID = ALM_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticuloAlmacenPermitido(ByVal Art_Id As String, ByVal ALM_Id As Integer?) As String Implements IArticuloAlmacenRepositorio.ListaArticuloAlmacenPermitido
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaArticuloAlmacenPermitido")
                context.AddInParameter(cmd, "Art_Id", DbType.String, Art_Id)
                context.AddInParameter(cmd, "Alm_Id", DbType.Int16, ALM_Id)
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

        Public Function TotalStock(ByVal Art_Id As String) As Decimal Implements IArticuloAlmacenRepositorio.TotalStock
            Dim result As Decimal
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ArticuloAlmacen Where c.ART_ID = Art_Id And (c.ALM_ID = 27 Or c.ALM_ID = 57) Select c).Sum(Function(c) c.ARA_STOCK)
            Catch ex As Exception
                result = 0
            End Try
            Return result
        End Function
    End Class

End Namespace



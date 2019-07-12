Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class CierreAlmacenRepositorio
        Implements ICierreAlmacenRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetByCierre(ByVal Anio As String, ByVal Mes As String, ByVal Alm_id As String) As Boolean Implements ICierreAlmacenRepositorio.GetByCierre
            Dim result As CierreAlmacen
            Dim Cerrado As Boolean = False
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.CierreAlmacen Where c.ANIO & c.MES & c.ALM_ID = Anio & Mes & Alm_id And c.ALM_ID <> 0 Select c).FirstOrDefault
                If result IsNot Nothing Then Cerrado = True
            Catch ex As Exception
                Cerrado = False
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return Cerrado
        End Function

        Public Function GetById(ByVal CIA_ID As Integer) As BE.CierreAlmacen Implements ICierreAlmacenRepositorio.GetById
            Dim result As CierreAlmacen = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.CierreAlmacen Where c.CIA_ID = CIA_ID Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCierreAlmacen() As String Implements ICierreAlmacenRepositorio.ListaCierreAlmacen
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaCierreAlmacen")
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

        Public Sub Maintenance(ByVal Cierrealmacen As BE.CierreAlmacen) Implements ICierreAlmacenRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.CierreAlmacen.ApplyChanges(Cierrealmacen)
                context.SaveChanges()
                Cierrealmacen.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetByCierreAlmacen(ByVal Anio As String, ByVal Mes As String, ByVal Alm_id As String) As BE.CierreAlmacen Implements ICierreAlmacenRepositorio.GetByCierreAlmacen
            Dim result As CierreAlmacen = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.CierreAlmacen Where c.ANIO = Anio And c.MES = Mes And Math.Abs(CInt(c.ALM_ID)) = Alm_id And c.ALM_ID <> 0 Select c).FirstOrDefault
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



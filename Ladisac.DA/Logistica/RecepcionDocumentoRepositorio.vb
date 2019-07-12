Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class RecepcionDocumentoRepositorio
        Implements IRecepcionDocumentoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal RDO_Id As Integer) As BE.RecepcionDocumento Implements IRecepcionDocumentoRepositorio.GetById
            Dim result As RecepcionDocumento = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.RecepcionDocumento.Include("Personas").Include("Personas1").Include("DetalleTipoDocumentos") Where c.RDO_ID = RDO_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaRecepcionDocumento() As String Implements IRecepcionDocumentoRepositorio.ListaRecepcionDocumento
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaRecepcionDocumento")
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

        Public Sub Maintenance(ByVal RecepcionDocumento As BE.RecepcionDocumento) Implements IRecepcionDocumentoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.RecepcionDocumento.ApplyChanges(RecepcionDocumento)
                context.SaveChanges()
                RecepcionDocumento.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaDarRecepcion(ByVal PER_ID_RECIBIDO As String) As System.Collections.Generic.List(Of BE.RecepcionDocumento) Implements IRecepcionDocumentoRepositorio.ListaDarRecepcion
            Dim result As List(Of RecepcionDocumento) = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                result = (From c In context.RecepcionDocumento.Include("Personas").Include("Personas1").Include("DetalleTipoDocumentos") Where c.PER_ID_RECIBIDO = PER_ID_RECIBIDO And c.RDO_RECIBIDO = 0 Select c).ToList
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetById2(ByVal Per_Id As String, ByVal Dtd_Id As String, ByVal Serie As String, ByVal Numero As String) As BE.RecepcionDocumento Implements IRecepcionDocumentoRepositorio.GetById2
            Dim result As RecepcionDocumento = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.RecepcionDocumento.Include("Personas").Include("Personas1").Include("DetalleTipoDocumentos") Where c.PER_ID_PROVEEDOR = Per_Id And c.DTD_ID = Dtd_Id And c.RDO_SERIE.Contains(Serie) And c.RDO_NUMERO = Numero Select c).FirstOrDefault
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



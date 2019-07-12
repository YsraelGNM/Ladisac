Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class DocuIsoRepositorio
        Implements IDocuIsoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal DIS_Id As Integer) As BE.DocuIso Implements IDocuIsoRepositorio.GetById
            Dim result As DocuIso = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DocuIso.Include("DocuIsoDetalle").Include("AreaTrabajos").Include("DetalleTipoDocumentos.TipoDocumentos").Include("PlantillaDocuIso").Include("Personas.FotoPersonas").Include("Personas1.FotoPersonas").Include("Personas2.FotoPersonas") Where c.DIS_ID = DIS_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDocuIso() As String Implements IDocuIsoRepositorio.ListaDocuIso
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaDocuIso")
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

        Public Sub Maintenance(ByVal DocuIso As BE.DocuIso) Implements IDocuIsoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DocuIso.ApplyChanges(DocuIso)
                context.SaveChanges()
                DocuIso.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaDocuIsoXAreXDtdXNombre(ByVal ARE_ID As String, ByVal DTD_ID As String, ByVal Nombre As String) As System.Collections.Generic.List(Of BE.DocuIso) Implements IDocuIsoRepositorio.ListaDocuIsoXAreXDtdXNombre
            Dim result As List(Of DocuIso) = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DocuIso.Include("DocuIsoDetalle").Include("AreaTrabajos").Include("DetalleTipoDocumentos.TipoDocumentos").Include("PlantillaDocuIso").Include("Personas").Include("Personas1").Include("Personas2") Where c.ARE_ID = ARE_ID And c.DTD_ID = DTD_ID And c.DIS_ADJUNTO_DESCRI = Nombre And c.DIS_VIGENTE = 1 Select c).ToList
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDocuIsoVigente(ByVal ARE_ID As String, ByVal DTD_ID As String, ByVal PER_ID As String, ByVal ARE_DESCRIPCION As String) As System.Collections.Generic.List(Of BE.DocuIso) Implements IDocuIsoRepositorio.ListaDocuIsoVigente
            Dim result As New List(Of DocuIso)
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                Dim r1 As List(Of DocuIso) = Nothing
                r1 = (From c In context.DocuIso.Include("DocuIsoDetalle").Include("AreaTrabajos").Include("DetalleTipoDocumentos.TipoDocumentos").Include("PlantillaDocuIso").Include("Personas").Include("Personas1").Include("Personas2") Where (c.ARE_ID = ARE_ID Or ARE_ID Is Nothing) And (c.DTD_ID = DTD_ID Or DTD_ID Is Nothing) And c.DIS_VIGENTE = 1 And c.DIS_PU_AR_PR = 0 Select c).ToList

                Dim r2 As List(Of DocuIso) = Nothing
                r2 = (From c In context.DocuIso.Include("DocuIsoDetalle").Include("AreaTrabajos").Include("DetalleTipoDocumentos.TipoDocumentos").Include("PlantillaDocuIso").Include("Personas").Include("Personas1").Include("Personas2") Where (c.ARE_ID = ARE_ID Or ARE_ID Is Nothing) And (c.DTD_ID = DTD_ID Or DTD_ID Is Nothing) And c.DIS_VIGENTE = 1 And c.DIS_PU_AR_PR = 1 And ARE_DESCRIPCION.Contains(c.AreaTrabajos.art_Descripcion) Select c).ToList

                Dim r3 As List(Of DocuIso) = Nothing
                r3 = (From c In context.DocuIso.Include("DocuIsoDetalle").Include("AreaTrabajos").Include("DetalleTipoDocumentos.TipoDocumentos").Include("PlantillaDocuIso").Include("Personas").Include("Personas1").Include("Personas2") Where (c.ARE_ID = ARE_ID Or ARE_ID Is Nothing) And (c.DTD_ID = DTD_ID Or DTD_ID Is Nothing) And c.DIS_VIGENTE = 1 And c.DIS_PU_AR_PR = 2 And c.PER_ID_ELABORACION = PER_ID Select c).ToList

                For Each mItem In r1.ToList
                    result.Add(mItem)
                Next
                For Each mItem In r2.ToList
                    result.Add(mItem)
                Next
                For Each mItem In r3.ToList
                    result.Add(mItem)
                Next

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



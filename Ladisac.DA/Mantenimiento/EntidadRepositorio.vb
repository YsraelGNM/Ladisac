Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class EntidadRepositorio
        Implements IEntidadRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal ENO_Id As Integer) As BE.Entidad Implements IEntidadRepositorio.GetById
            Dim result As Entidad = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Entidad.Include("TipoEntidad").Include("Especificacion.Caracteristica").Include("Imagen") Where c.ENO_ID = ENO_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaEntidad() As String Implements IEntidadRepositorio.ListaEntidad
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaEntidad")
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

        Public Sub Maintenance(ByVal Entidad As BE.Entidad) Implements IEntidadRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Entidad.ApplyChanges(Entidad)
                context.SaveChanges()
                Entidad.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaConsumoEntidad(ByVal Eno_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal Art_Id As String, ByVal OTR_ID As Integer, ByVal MTO_ID As Integer, ByVal TCM_ID As Integer, ByVal GRU_ID As Integer) As DataSet Implements IEntidadRepositorio.ListaConsumoEntidad
            Dim result As DataSet = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaConsumoEntidad")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "Eno_Id", DbType.Int32, Eno_Id)
                context.AddInParameter(cmd, "Art_Id", DbType.String, Art_Id)
                context.AddInParameter(cmd, "OTR_ID", DbType.String, OTR_ID)
                context.AddInParameter(cmd, "MTO_ID", DbType.String, MTO_ID)
                context.AddInParameter(cmd, "TCM_ID", DbType.String, TCM_ID)
                context.AddInParameter(cmd, "GRU_ID", DbType.String, GRU_ID)
                cmd.CommandTimeout = 1900
                result = context.ExecuteDataSet(cmd)

                'Dim context_1 = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                'Dim colEnt = (From mCol In context_1.Entidad Where mCol.ENO_ID_PADRE = Eno_Id Select mCol)
                'For Each mItem In colEnt.ToList
                '    result.Merge(ListaConsumoEntidad(mItem.ENO_ID, FecIni, FecFin, Art_Id, OTR_ID, MTO_ID, TCM_ID, GRU_ID))
                'Next

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaHijos(ByVal ENO_Id As Integer) As List(Of Entidad) Implements IEntidadRepositorio.ListaHijos
            Dim result As List(Of Entidad)
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Entidad.Include("TipoEntidad").Include("Especificacion.Caracteristica").Include("Imagen") Where c.ENO_ID_PADRE = ENO_Id Select c).ToList
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        'Public Function ListaEntidadDescripcion(ByVal ENO_Descripcion As String) As System.Data.DataSet Implements IEntidadRepositorio.ListaEntidadDescripcion
        '    Dim result As New DataSet
        '    Try
        '        Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
        '        Dim cmd = context.GetStoredProcCommand("spListaEntidadDesc", ENO_Descripcion)
        '        result = context.ExecuteDataSet(cmd)
        '    Catch ex As Exception
        '        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
        '        If (rethrow) Then
        '            Throw
        '        End If
        '    End Try
        '    Return result
        'End Function

        'Public Function ListaEntidadDescripcion(ByVal ENO_ID As Integer?) As System.Data.DataSet Implements IEntidadRepositorio.ListaEntidadDescripcion
        '    Dim result As New DataSet
        '    Try
        '        Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
        '        Dim cmd = context.GetStoredProcCommand("spListaEntidadDesc", ENO_ID)
        '        result = context.ExecuteDataSet(cmd)
        '    Catch ex As Exception
        '        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
        '        If (rethrow) Then
        '            Throw
        '        End If
        '    End Try
        '    Return result
        'End Function

        Public Function ListaEntidadID(ByVal ENO_ID As Integer?) As System.Data.DataSet Implements IEntidadRepositorio.ListaEntidadID
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaEntidadID", ENO_ID)
                result = context.ExecuteDataSet(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaEntidadCuentaContable() As System.Collections.Generic.List(Of BE.Entidad) Implements IEntidadRepositorio.ListaEntidadCuentaContable
            Dim result As New List(Of Entidad)
            Dim mPara As Parametro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                mPara = (From c In context.Parametro Where c.PAR_ID = "EntidadCuentaContable" Select c).FirstOrDefault

                Dim mListaEntidad() As String = mPara.PAR_VALOR3.Split("/")
                For Each mItem In mListaEntidad
                    Dim Eno As Entidad
                    Eno = (From c In context.Entidad Where c.ENO_ID = mItem Select c).FirstOrDefault
                    result.Add(Eno)
                Next

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function UltimoHorometro(ByVal ENO_ID As Integer, ByVal Tipo As String) As Decimal Implements IEntidadRepositorio.UltimoHorometro
            Dim result As Decimal
            Try
                Select Case Tipo
                    Case "RegistroEquipo"
                        Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                        result = (From c In context.RegistroEquipo Join d In context.RegistroEquipoDetalle On c.REQ_ID Equals d.REQ_ID Where c.ENO_ID = ENO_ID Order By d.RED_HOROF Descending Select d.RED_HOROF).FirstOrDefault

                End Select

                If result = Nothing Then result = 0

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



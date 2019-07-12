Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class MarcacionRepositorio
        Implements IMarcacionRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetId(ByVal fecha As Date, ByVal spersonas As String) As System.Collections.Generic.List(Of BE.Marcaciones) Implements IMarcacionRepositorio.GetId
            Dim result As IList(Of BE.Marcaciones) = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Marcaciones Where c.mar_marcacion = fecha And c.PER_ID = spersonas Select c)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal item As BE.Marcaciones) Implements IMarcacionRepositorio.Maintenance

            Try
                '  Using Scope As New System.Transactions.TransactionScope()

                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spMarcacionesInsert)
                context.AddInParameter(cmd, Marcaciones.PropertyNames.PER_ID, DbType.String, item.PER_ID)
                context.AddInParameter(cmd, Marcaciones.PropertyNames.mar_marcacion, DbType.DateTime2, item.mar_marcacion)
                context.AddInParameter(cmd, Marcaciones.PropertyNames.mar_estado, DbType.String, item.mar_estado)
                context.AddInParameter(cmd, Marcaciones.PropertyNames.mar_Movimiento, DbType.String, item.mar_Movimiento)
                context.AddInParameter(cmd, Marcaciones.PropertyNames.mar_tipo, DbType.String, item.mar_tipo)
                context.AddInParameter(cmd, Marcaciones.PropertyNames.mar_observaciones, DbType.String, item.mar_observaciones)
                context.AddInParameter(cmd, Marcaciones.PropertyNames.mar_fecGrab, DbType.Date, item.mar_fecGrab)
                context.AddInParameter(cmd, Marcaciones.PropertyNames.USU_ID, DbType.String, item.USU_ID)

                context.ExecuteNonQuery(cmd)



                ' End Using
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub


    End Class

End Namespace



'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE

'Namespace Ladisac.DA
'    Public Class PeriodisidadRepositorio
'        Implements IPeriodisidadRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetId(ByVal id As String) As BE.Periodisidad Implements IPeriodisidadRepositorio.GetId

'            Dim result As Periodisidad = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.Periodisidad Where c.pec_Periodisidad_Id = id Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Sub Mantenance(ByVal item As BE.Periodisidad) Implements IPeriodisidadRepositorio.Mantenance
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                context.Periodisidad.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try

'        End Sub
'    End Class


'End Namespace

Imports Ladisac.BE
Imports Microsoft.Practices.Unity

Namespace Ladisac.DA
    Public Class TiposContratosRepositorio
        Implements ITiposContratosRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal id As String) As TiposContratos Implements ITiposContratosRepositorio.GetById
            Dim result As TiposContratos = Nothing

            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.TiposContratos Where c.tic_TipoCont_Id = id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Sub Mantenance(ByVal item As TiposContratos) Implements ITiposContratosRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.TiposContratos.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
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
'    <Flags()>
'    Public Enum ConceptosExtend
'        None = 0
'        TiposConcepto = 1
'        Otro1 = 2
'        Otro = 4


'    End Enum

'    Public Class ConceptosRepositorio
'        Implements IConceptosRepositorio



'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer



'        Public Function GetById(ByVal id As String) As BE.Conceptos Implements IConceptosRepositorio.GetById

'            Dim result As Conceptos = Nothing

'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                ' para obtenert la sub tabla
'                'result = (From c In context.Conceptos.Include("TiposConceptos") Where c.con_Conceptos_Id = id Select c).FirstOrDefault
'                result = (From c In context.Conceptos Where c.con_Conceptos_Id = id Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Sub Maintenance(ByVal item As BE.Conceptos) Implements IConceptosRepositorio.Maintenance

'            Try
'                '  Using Scope As New System.Transactions.TransactionScope()

'                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()


'                If (item.ChangeTracker.State = ObjectState.Added) Then

'                    Dim cmd = context.GetStoredProcCommand(DA.SPNames.SPConceptosInsert)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.tic_TipoConcep_Id, DbType.String, item.tic_TipoConcep_Id)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_Concepto, DbType.String, item.con_Concepto)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_EsFijoTrabajador, DbType.Boolean, item.con_EsFijoTrabajador)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_CodigoSunat, DbType.String, item.con_CodigoSunat)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_Escalculo, DbType.Byte, item.con_Escalculo)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_EsTareoHoras, DbType.Byte, item.con_EsTareoHoras)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_Descripcion, DbType.String, item.con_Descripcion)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_EsConceptoDscJudi, DbType.Byte, item.con_EsConceptoDscJudi)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.Usu_Id, DbType.String, item.Usu_Id)
'                    ' context.AddInParameter(cmd, Conceptos.PropertyNames.con_FecGrab, DbType.DateTime, item.con_FecGrab)
'                    context.ExecuteNonQuery(cmd)

'                ElseIf (item.ChangeTracker.State = ObjectState.Modified) Then

'                    Dim cmd = context.GetStoredProcCommand(DA.SPNames.SPConceptosUpdate)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_Conceptos_Id, DbType.String, item.con_Conceptos_Id)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.tic_TipoConcep_Id, DbType.String, item.tic_TipoConcep_Id)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_Concepto, DbType.String, item.con_Concepto)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_EsFijoTrabajador, DbType.Boolean, item.con_EsFijoTrabajador)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_CodigoSunat, DbType.String, item.con_CodigoSunat)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_Escalculo, DbType.Byte, item.con_Escalculo)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_EsTareoHoras, DbType.Byte, item.con_EsTareoHoras)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_Descripcion, DbType.String, item.con_Descripcion)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.con_EsConceptoDscJudi, DbType.Byte, item.con_EsConceptoDscJudi)
'                    context.AddInParameter(cmd, Conceptos.PropertyNames.Usu_Id, DbType.String, item.Usu_Id)
'                    ' context.AddInParameter(cmd, Conceptos.PropertyNames.con_FecGrab, DbType.DateTime, item.con_FecGrab)
'                    context.ExecuteNonQuery(cmd)
'                ElseIf (item.ChangeTracker.State = ObjectState.Deleted) Then

'                    Try
'                        Dim context2 = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                        context2.Conceptos.ApplyChanges(item)
'                        context2.SaveChanges()
'                        item.AcceptChanges()
'                    Catch ex As Exception
'                        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                        If (rethrow) Then
'                            Throw
'                        End If
'                    End Try

'                End If

'                ' End Using
'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            'Try
'            '    Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'            '    context.Conceptos.ApplyChanges(item)
'            '    context.SaveChanges()
'            '    item.AcceptChanges()
'            'Catch ex As Exception
'            '    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'            '    If (rethrow) Then
'            '        Throw
'            '    End If
'            'End Try

'        End Sub



'        Public Sub Load(ByVal Item As BE.Conceptos, ByVal extends As ConceptosExtend) Implements IConceptosRepositorio.Load
'            Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

'            If (extends.HasFlag(ConceptosExtend.TiposConcepto)) Then
'                context.LoadProperty(Item, Function(c As BE.Conceptos) c.TiposConceptos)
'            End If
'            If (extends.HasFlag(ConceptosExtend.Otro)) Then

'            End If

'        End Sub


'    End Class
'End Namespace

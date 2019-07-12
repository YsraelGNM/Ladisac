Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class ComedorRepositorio
        Implements IComedorRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function getById(ByVal numero As String) As BE.ComedorPLL Implements IComedorRepositorio.getById
            Dim result As ComedorPLL = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.ComedorPLL.Include("Personas") _
                          .Include("Personas1") _
                          .Include("DetalleComedorPLL") _
                          .Include("DetalleComedorPLL.Personas") _
                          .Include("Conceptos") _
                          .Include("Conceptos.TiposConceptos") Where c.com_Numero = numero Select c).FirstOrDefault

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.ComedorPLL) As Object Implements IComedorRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.ComedorPLL.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False

        End Function

        Public Function MaintenanceDelete(ByVal item As BE.ComedorPLL) As Object Implements IComedorRepositorio.MaintenanceDelete
            Try
                'elimiar
                Dim contextDelete = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = contextDelete.GetStoredProcCommand(DA.SPNames.SPComedorPLLDelete)

                contextDelete.AddInParameter(cmd, BE.ComedorPLL.PropertyNames.com_Numero, DbType.String, item.com_Numero)
                contextDelete.ExecuteNonQuery(cmd)

                Return True

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return False

        End Function
    End Class

End Namespace


'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE
'Imports System.Text
'Namespace Ladisac.DA
'    Public Class PermisosTrabajadorRepositorio
'        Implements IPermisosTrabajadorRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        Public Function GetbyId(ByVal numero As String) As BE.PermisosTrabajador Implements IPermisosTrabajadorRepositorio.GetbyId
'            Dim result As PermisosTrabajador = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.PermisosTrabajador.Include("Personas").Include("Personas1").Include("DetallePermisosTrabajador") Where c.prm_Numero = numero Select c).FirstOrDefault
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function
'        Public Function Maintenance(ByVal item As BE.PermisosTrabajador) As Object Implements IPermisosTrabajadorRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.PermisosTrabajador.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()
'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function
'    End Class
'End Namespace
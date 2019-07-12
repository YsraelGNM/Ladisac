
Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class TrabajadorHorasRepositorio
        Implements ITrabajadorHorasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal tipo As String, ByVal numero As String) As Object Implements ITrabajadorHorasRepositorio.GetById
            Dim result As TrabajadorHoras = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()

                result = (From c In context.TrabajadorHoras.Include("DetalleTrabajadorHoras.Personas").Include("DetalleTrabajadorHoras").Include("DetalleTrabajadorHoras.Personas.DatosLaborales") Where c.trh_Numero = numero And c.tit_TipoTrab_Id = tipo).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.TrabajadorHoras) As Object Implements ITrabajadorHorasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.TrabajadorHoras.ApplyChanges(item)
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

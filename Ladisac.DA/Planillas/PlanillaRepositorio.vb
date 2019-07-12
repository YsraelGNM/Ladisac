Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class PlanillaRepositorio
        Implements IPlanillaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetbyId(ByVal serie As String, ByVal numero As String, ByVal tipoDoc As String) As BE.Planillas Implements IPlanillaRepositorio.GetbyId
            Dim result As BE.Planillas = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.Planillas _
                          .Include("PlanillasComedorHoras") _
                          .Include("PlanillasComedorHoras.TrabajadorHoras") _
                           .Include("PlanillasComedorHoras.ComedorPLL") _
                          Where c.pla_SeriePlani = serie _
                          And c.pla_Numero = numero _
                          And c.tdo_Id = tipoDoc Select c).FirstOrDefault
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.Planillas) As Object Implements IPlanillaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.Planillas.ApplyChanges(item)
                context.SaveChanges(System.Data.Objects.SaveOptions.None)
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

        'Public Sub BulkInsert(Of T)(ByVal tableName As String, ByVal list As IList(Of T))
        '    Dim conection As String = "cadena de conexion"

        '    Dim bulkCopy = New SqlBulkCopy(conection)
        '    bulkCopy.BatchSize = list.Count
        '    bulkCopy.DestinationTableName = tableName

        '    Dim table = New DataTable()
        '    Dim props = TypeDescriptor.GetProperties(GetType(T)).Cast(Of PropertyDescriptor)().Where(Function(propertyInfo) (propertyInfo.PropertyType.[Namespace].Equals("System") OrElse propertyInfo.PropertyType.[Namespace].Equals("Microsoft.SqlServer.Types"))).ToArray()

        '    For Each propertyInfo As var In props
        '        bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name)
        '        table.Columns.Add(propertyInfo.Name, If(Nullable.GetUnderlyingType(propertyInfo.PropertyType), propertyInfo.PropertyType))
        '    Next

        '    Dim values = New Object(props.Length - 1) {}
        '    For Each item As var In list
        '        For i As var = 0 To values.Length - 1
        '            values(i) = props(i).GetValue(item)
        '        Next

        '        table.Rows.Add(values)
        '    Next

        '    bulkCopy.WriteToServer(table)

        'End Sub

       
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


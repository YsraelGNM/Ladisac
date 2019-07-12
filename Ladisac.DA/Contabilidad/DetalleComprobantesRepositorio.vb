Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA

    Public Class DetalleComprobantesRepositorio
        Implements IDetalleComprobantesRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String) As Object Implements IDetalleComprobantesRepositorio.GetById
            Dim result As BE.DetalleComprobantes = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetalleComprobantes Where c.cct_Id = cct_Id _
                           And c.tdo_Id = tdo_Id _
                           And c.dtd_Id = dtd_Id _
                           And c.cob_Serie = cob_Serie _
                           And c.cob_Numero = cob_Numero).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.DetalleComprobantes) As Boolean Implements IDetalleComprobantesRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetalleComprobantes.ApplyChanges(item)
                context.SaveChanges()
                context.AcceptAllChanges()
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
'    Public Class DetalleAsientosManualesRepositorio
'        Implements IDetalleAsientosManualesRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String, ByVal dam_Item As String) As BE.DetalleAsientosManuales Implements IDetalleAsientosManualesRepositorio.GetById
'            Dim result As BE.DetalleAsientosManuales = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DetalleAsientosManuales _
'                          Where c.lib_Id = lib_Id And _
'                          c.prd_Periodo_id = prd_Periodo_id And _
'                          c.asm_NumeroVoucher = asm_NumeroVoucher And _
'                          c.dam_Item = dam_Item).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.DetalleAsientosManuales) As Boolean Implements IDetalleAsientosManualesRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetalleAsientosManuales.ApplyChanges(item)
'                context.SaveChanges()
'                context.AcceptAllChanges()
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

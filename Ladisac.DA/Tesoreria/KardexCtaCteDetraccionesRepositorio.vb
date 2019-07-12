Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class KardexCtaCteDetraccionesRepositorio
        Implements IKardexCtaCteDetraccionesRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function spActualizarEstadoRegistroDetracciones(ByVal cCCT_ID_REF As String, ByVal cTDO_ID_REF As String, ByVal cDTD_ID_REF As String, ByVal cDOC_SERIE_REF As String, ByVal cDOC_NUMERO_REF As String, ByVal cESTADO As Boolean) As Short Implements IKardexCtaCteDetraccionesRepositorio.spActualizarEstadoRegistroDetracciones
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarEstadoRegistroKardexCtaCteDetracciones)
                context.AddInParameter(cmd, KardexCtaCteDetracciones.PropertyNames.CCT_ID_REF, DbType.String, cCCT_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteDetracciones.PropertyNames.TDO_ID_REF, DbType.String, cTDO_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteDetracciones.PropertyNames.DTD_ID_REF, DbType.String, cDTD_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteDetracciones.PropertyNames.DOC_SERIE_REF, DbType.String, cDOC_SERIE_REF)
                context.AddInParameter(cmd, KardexCtaCteDetracciones.PropertyNames.DOC_NUMERO_REF, DbType.String, cDOC_NUMERO_REF)
                context.AddInParameter(cmd, KardexCtaCteDetracciones.PropertyNames.ESTADO, DbType.String, cESTADO)
                context.ExecuteNonQuery(cmd)
                spActualizarEstadoRegistroDetracciones = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarEstadoRegistroDetracciones = 0
            End Try
        End Function

    End Class
End Namespace

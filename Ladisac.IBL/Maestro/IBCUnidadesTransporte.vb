Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCUnidadesTransporte

#Region "Mantenimientos"
        Function Mantenimiento(ByVal Item As UnidadesTransporte) As Short

        Function spActualizarRegistro(ByVal cUNT_ID As String, _
  ByVal cUNT_COMPORTAMIENTO As Int16, _
  ByVal cUNT_TIPO As Int16, _
  ByVal cTUN_ID As String, _
  ByVal cMAR_ID As String, _
  ByVal cMOD_ID As String, _
  ByVal cUNT_TARA As Double, _
  ByVal cUNT_NRO_INS As String, _
  ByVal cPER_ID As String, _
  ByVal cUNT_KILOMETRAJE As Double, _
  ByVal cUNT_HOROMETRO As Double, _
  ByVal cUNT_NRO_SERIE As String, _
  ByVal cUNT_NRO_MOTOR As String, _
  ByVal cUNT_ANIO_FABRICACION As Int16, _
  ByVal cUNT_FECHA_ADQUISICION As DateTime, _
  ByVal cUSU_ID As String, _
  ByVal cUNT_FEC_GRAB As DateTime, _
  ByVal cUNT_ESTADO As Boolean) As Short

        Function spInsertarRegistro(ByVal cUNT_ID As String, _
          ByVal cUNT_COMPORTAMIENTO As Int16, _
          ByVal cUNT_TIPO As Int16, _
          ByVal cTUN_ID As String, _
          ByVal cMAR_ID As String, _
          ByVal cMOD_ID As String, _
          ByVal cUNT_TARA As Double, _
          ByVal cUNT_NRO_INS As String, _
          ByVal cPER_ID As String, _
          ByVal cUNT_KILOMETRAJE As Double, _
          ByVal cUNT_HOROMETRO As Double, _
          ByVal cUNT_NRO_SERIE As String, _
          ByVal cUNT_NRO_MOTOR As String, _
          ByVal cUNT_ANIO_FABRICACION As Int16, _
          ByVal cUNT_FECHA_ADQUISICION As DateTime, _
          ByVal cUSU_ID As String, _
          ByVal cUNT_FEC_GRAB As DateTime, _
          ByVal cUNT_ESTADO As Boolean) As Short

        Function spEliminarRegistro(ByVal cUNT_ID As String) As Short
#End Region

#Region "Querys"
        Function UnidadesTransporteGetById(ByVal UNT_ID As String) As UnidadesTransporte
        Function ListaUnidadesTransporte() As String

        Function ListaUnidadesTransporteSalidaCombustible(ByVal UNT_ID As String) As String
        Function ListaUnidadesTransporteEmpresa(ByVal PER_ID As String) As String
        Function ListaUnidadesTransporteXPlaca(ByVal UNT_ID As String) As String
#End Region

    End Interface

End Namespace

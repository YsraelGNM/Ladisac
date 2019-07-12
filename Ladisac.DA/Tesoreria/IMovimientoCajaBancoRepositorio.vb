Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IMovimientoCajaBancoRepositorio
        Function Maintenance(ByVal item As MovimientoCajaBanco) As Short
        Function spEliminarMovimientoCajaBanco(ByVal cDocumento As String, ByVal cItem As Int16) As Short
        Function DeleteRegistro(ByVal item As MovimientoCajaBanco, ByVal cDocumento As String, ByVal cITEM As Int16) As Short

        Function spActualizarRegistro(ByVal citem As int16, _
           ByVal cTes_Fecha_Emi As DateTime, _
           ByVal cCco_Id As String, _
           ByVal cCuc_Id As String, _
           ByVal cTes_Monto_total As Double, _
           ByVal cCcc_Id As String, _
           ByVal cCct_Id As String, _
           ByVal cTdo_Id As String, _
           ByVal cDtd_Id As String, _
           ByVal cTes_Serie As String, _
           ByVal cTes_Numero As String, _
           ByVal cCargo As Double, _
           ByVal cAbono As Double, _
           ByVal cDte_ContraValor_Doc As Double, _
           ByVal cPer_Id_Ban As String, _
           ByVal cPer_Id_Cli As String, _
           ByVal cCcc_Id_Cli As String, _
           ByVal cCct_Id_Doc As String, _
           ByVal cTdo_Id_Doc As String, _
           ByVal cDtd_Id_Doc As String, _
           ByVal cDte_Serie_Doc As String, _
           ByVal cDte_Numero_Doc As String, _
           ByVal cDte_Observaciones As String, _
           ByVal cDOCUMENTO As String) As Short
        Function spInsertarRegistro(ByVal citem As int16, _
           ByVal cTes_Fecha_Emi As DateTime, _
           ByVal cCco_Id As String, _
           ByVal cCuc_Id As String, _
           ByVal cTes_Monto_total As Double, _
           ByVal cCcc_Id As String, _
           ByVal cCct_Id As String, _
           ByVal cTdo_Id As String, _
           ByVal cDtd_Id As String, _
           ByVal cTes_Serie As String, _
           ByVal cTes_Numero As String, _
           ByVal cCargo As Double, _
           ByVal cAbono As Double, _
           ByVal cDte_ContraValor_Doc As Double, _
           ByVal cPer_Id_Ban As String, _
           ByVal cPer_Id_Cli As String, _
           ByVal cCcc_Id_Cli As String, _
           ByVal cCct_Id_Doc As String, _
           ByVal cTdo_Id_Doc As String, _
           ByVal cDtd_Id_Doc As String, _
           ByVal cDte_Serie_Doc As String, _
           ByVal cDte_Numero_Doc As String, _
           ByVal cDte_Observaciones As String, _
           ByVal cDOCUMENTO As String) As Short
        Function spEliminarRegistro(ByVal cITEM As Int16, _
          ByVal cDOCUMENTO As String) As Short

        Function spEliminarRegistroExtorno(ByVal cITEM As Int16, _
          ByVal cDOCUMENTO As String) As Short
        Function spActualizarRegistroExtorno(ByVal citem As Int16, _
            ByVal cTes_Fecha_Emi As DateTime, _
            ByVal cCco_Id As String, _
            ByVal cCuc_Id As String, _
            ByVal cTes_Monto_total As Double, _
            ByVal cCcc_Id As String, _
            ByVal cCct_Id As String, _
            ByVal cTdo_Id As String, _
            ByVal cDtd_Id As String, _
            ByVal cTes_Serie As String, _
            ByVal cTes_Numero As String, _
            ByVal cCargo As Double, _
            ByVal cAbono As Double, _
            ByVal cDte_ContraValor_Doc As Double, _
            ByVal cPer_Id_Ban As String, _
            ByVal cPer_Id_Cli As String, _
            ByVal cCcc_Id_Cli As String, _
            ByVal cCct_Id_Doc As String, _
            ByVal cTdo_Id_Doc As String, _
            ByVal cDtd_Id_Doc As String, _
            ByVal cDte_Serie_Doc As String, _
            ByVal cDte_Numero_Doc As String, _
            ByVal cDte_Observaciones As String, _
            ByVal cDOCUMENTO As String, _
            ByVal cTipo As String
            ) As Short

    End Interface
End Namespace

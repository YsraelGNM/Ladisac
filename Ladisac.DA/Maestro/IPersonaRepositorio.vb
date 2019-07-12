Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IPersonaRepositorio


        Function GetById(ByVal PER_ID As String) As Personas
        Function Maintenance(ByVal Persona As Personas)
        Function ListaPersona(ByVal Tipo As String, ByVal Filtro As String) As String
        Function spActualizarPersonasDIR_ID(ByVal PER_ID As String, ByVal DIR_ID As String) As Short
        Function spActualizarPersonasPER_LINEA_CREDITO(ByVal PER_ID As String, ByVal USU_ID As String) As Short

        Function spActualizarRegistro(ByVal cPER_ID As String, _
           ByVal cPER_CLIENTE As Boolean, _
           ByVal cPER_CLIENTE_OP_CON As Int16, _
           ByVal cPER_PROVEEDOR As Boolean, _
           ByVal cPER_PROVEEDOR_OP_CON As Int16, _
           ByVal cPER_TRANSPORTISTA As Boolean, _
           ByVal cPER_TRANSPORTISTA_OP_CON As Int16, _
           ByVal cPER_TRABAJADOR As Boolean, _
           ByVal cPER_TRABAJADOR_OP_CON As Int16, _
           ByVal cPER_BANCO As Boolean, _
           ByVal cPER_BANCO_OP_CON As Int16, _
           ByVal cPER_GRUPO As Boolean, _
           ByVal cPER_GRUPO_OP_CON As Int16, _
           ByVal cPER_CONTACTO As Boolean, _
           ByVal cPER_CONTACTO_OP_CON As Int16, _
           ByVal cPER_TRANSP_PROPIO As Int16, _
           ByVal cPER_NOMBRES As String, _
           ByVal cPER_APE_PAT As String, _
           ByVal cPER_APE_MAT As String, _
           ByVal cPER_BREVETE As String, _
           ByVal cPER_FORMA_VENTA As Int16, _
           ByVal cDIR_ID As String, _
           ByVal cPER_TELEFONOS As String, _
           ByVal cPER_EMAIL As String, _
           ByVal cPER_PAGINA_WEB As String, _
           ByVal cPER_LINEA_CREDITO As Double, _
           ByVal cPER_DIAS_CREDITO As Int16, _
           ByVal cPER_ID_VEN As String, _
           ByVal cPER_ID_COB As String, _
           ByVal cPER_ID_TRA As String, _
           ByVal cPER_ID_BAN As String, _
           ByVal cPER_ID_GRU As String, _
           ByVal cPER_DIASEM_PAGO As Int16, _
           ByVal cPER_COND_DIASEM As Int16, _
           ByVal cPER_DIAMES_PAGO As Int16, _
           ByVal cPER_DOC_PAGO As Int16, _
           ByVal cPER_HORA_PAGO As String, _
           ByVal cPER_OBSERVACIONES As String, _
           ByVal cPER_PROMOCIONES As Boolean, _
           ByVal cPER_CARTA_FIANZA As Int16, _
           ByVal cPER_CUOTA_MENSUAL As Double, _
           ByVal cPER_CUOTA_OBJETIVO As Double, _
           ByVal cPER_BONO As Double, _
           ByVal cCCC_ID As String, _
           ByVal cPER_CARGO As String, _
           ByVal cPER_REP_LEGAL As Boolean, _
           ByVal cPER_FIRMA_AUT As Boolean, _
           ByVal cPER_PROCESAR_DESCUENTO As Boolean, _
           ByVal cPER_ALIAS As String, _
           ByVal cPER_LINEA_CREDITO_ESTADO As Boolean, _
           ByVal cUSU_ID As String, _
           ByVal cPER_FEC_GRAB As DateTime, _
           ByVal cPER_ESTADO As Boolean, _
           ByVal cPER_FECHA_ALTA As Date, _
           ByVal cPER_FECHA_VENC As Date, _
           ByVal cPER_GARANTIA As String, _
           ByVal cPER_EXCESO_LINEA As Double) As Short
        Function spInsertarRegistro(ByVal cPER_ID As String, _
           ByVal cPER_CLIENTE As Boolean, _
           ByVal cPER_CLIENTE_OP_CON As Int16, _
           ByVal cPER_PROVEEDOR As Boolean, _
           ByVal cPER_PROVEEDOR_OP_CON As Int16, _
           ByVal cPER_TRANSPORTISTA As Boolean, _
           ByVal cPER_TRANSPORTISTA_OP_CON As Int16, _
           ByVal cPER_TRABAJADOR As Boolean, _
           ByVal cPER_TRABAJADOR_OP_CON As Int16, _
           ByVal cPER_BANCO As Boolean, _
           ByVal cPER_BANCO_OP_CON As Int16, _
           ByVal cPER_GRUPO As Boolean, _
           ByVal cPER_GRUPO_OP_CON As Int16, _
           ByVal cPER_CONTACTO As Boolean, _
           ByVal cPER_CONTACTO_OP_CON As Int16, _
           ByVal cPER_TRANSP_PROPIO As Int16, _
           ByVal cPER_NOMBRES As String, _
           ByVal cPER_APE_PAT As String, _
           ByVal cPER_APE_MAT As String, _
           ByVal cPER_BREVETE As String, _
           ByVal cPER_FORMA_VENTA As Int16, _
           ByVal cDIR_ID As String, _
           ByVal cPER_TELEFONOS As String, _
           ByVal cPER_EMAIL As String, _
           ByVal cPER_PAGINA_WEB As String, _
           ByVal cPER_LINEA_CREDITO As Double, _
           ByVal cPER_DIAS_CREDITO As Int16, _
           ByVal cPER_ID_VEN As String, _
           ByVal cPER_ID_COB As String, _
           ByVal cPER_ID_TRA As String, _
           ByVal cPER_ID_BAN As String, _
           ByVal cPER_ID_GRU As String, _
           ByVal cPER_DIASEM_PAGO As Int16, _
           ByVal cPER_COND_DIASEM As Int16, _
           ByVal cPER_DIAMES_PAGO As Int16, _
           ByVal cPER_DOC_PAGO As Int16, _
           ByVal cPER_HORA_PAGO As String, _
           ByVal cPER_OBSERVACIONES As String, _
           ByVal cPER_PROMOCIONES As Boolean, _
           ByVal cPER_CARTA_FIANZA As Int16, _
           ByVal cPER_CUOTA_MENSUAL As Double, _
           ByVal cPER_CUOTA_OBJETIVO As Double, _
           ByVal cPER_BONO As Double, _
           ByVal cCCC_ID As String, _
           ByVal cPER_CARGO As String, _
           ByVal cPER_REP_LEGAL As Boolean, _
           ByVal cPER_FIRMA_AUT As Boolean, _
           ByVal cPER_PROCESAR_DESCUENTO As Boolean, _
           ByVal cPER_ALIAS As String,
           ByVal cPER_LINEA_CREDITO_ESTADO As Boolean, _
           ByVal cUSU_ID As String, _
           ByVal cPER_FEC_GRAB As DateTime, _
           ByVal cPER_ESTADO As Boolean, _
           ByVal cPER_FECHA_ALTA As Date, _
           ByVal cPER_FECHA_VENC As Date, _
           ByVal cPER_GARANTIA As String, _
           ByVal cPER_EXCESO_LINEA As Double) As Short
        Function spEliminarRegistro(ByVal cPER_ID As String) As Short
    End Interface
End Namespace


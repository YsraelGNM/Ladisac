Namespace Ladisac.BE.Maestro.Datos
    Public Class Orm
        Public Const mCodigo22 = "Debe de ingresar un CÓDIGO, debe tener 22 carácteres"
        Public Const mCodigo19 = "Debe de ingresar un CÓDIGO, debe tener 19 carácteres"
        Public Const mCodigo14 = "Debe de ingresar un CÓDIGO, debe tener 1 y 14 carácteres"
        Public Const mCodigo10 = "Debe de ingresar un CÓDIGO, debe tener entre 7 y 10 carácteres"
        Public Const mCodigo10_1 = "Debe de ingresar un CÓDIGO, debe tener entre 5 y 10 carácteres"
        Public Const mCodigo8 = "Debe de ingresar un CÓDIGO, debe tener 8 carácteres"
        Public Const mCodigo6 = "Debe de ingresar un CÓDIGO, debe tener 6 carácteres"
        Public Const mCodigo4 = "Debe de ingresar un CÓDIGO, debe tener 4 carácteres"
        Public Const mCodigo3 = "Debe de ingresar un CÓDIGO, debe tener 3 carácteres"
        Public Const mCodigo3_1 = "Debe de ingresar un CÓDIGO, debe tener ente 1 y 3 carácteres"
        Public Const mCodigo2 = "Debe de ingresar un CÓDIGO, debe tener 2 carácteres"
        Public Const mDescripcion = "Debe de ingresar una DESCRIPCIÓN"
        Public Const mUsuario = "Debe de ingresar un CÓDIGO DE USUARIO válido"
        Public Const mFecha = "FECHA DE GRABACIÓN no válida"
        Public Const mEstado = "Debe marca un ESTADO"
        Public Const mDato = "Dato incorrecto"

        Public Property pNumeroVista As Int16 = 0
        Public Property pFiltradoWhere As Boolean = True
        Public Property pBuscarRegistros As Boolean = True
        Public Structure DatosComboBox
            Public NombreCampo As String ' Nombre del campo
            Public Valores(,) As String ' Array con los datos del campo
            Public Ancho As Int16 ' Ancho del objeto de edición
            Public Longitud As Int16 ' Máxima longitud del objeto de edición
            Public ParteEntera As Int16 ' Preción entera en caso de tratarse de un número
            Public ParteDecimal As Int16 ' Preción decimal en caso de tratarse de un número
            Public Flag As Boolean ' Determina si es datos array o texto
            Public Tipo As String ' Tipo del campo
        End Structure

        Public Structure ErrorData
            Public NumeroError As Int16
            Public MensajeError As String
            Public Objeto
            Public MensajeGeneral As String
        End Structure

        Public Function ColocarErrores(ByVal vObjetoDestino As Object, _
                                ByVal vObjetoError As ErrorData, _
                                ByVal vErrorProvides As Object, _
                                Optional ByVal vFila As Integer = 0) As Boolean
            Dim vMensajeFila As String = ""
            If vFila <> 0 Then vMensajeFila = " - En fila : " & vFila
            If vObjetoError.NumeroError = 0 Then
                vErrorProvides.SetError(vObjetoDestino, vObjetoError.MensajeGeneral & vMensajeFila)
                ColocarErrores = False
            Else
                vErrorProvides.SetError(vObjetoDestino, Nothing)
                ColocarErrores = True
            End If
        End Function
    End Class
End Namespace

Option Strict On
Imports System.Text
'Imports System.IO.StringReader
'''''
Namespace Ladisac.DA

    Public Class BusquedaRepositorio
        Implements IBusquedaRepositorio

        Public Function SolicitarString(ByVal report As String, ByVal ParamArray params() As Object) As String Implements IBusquedaRepositorio.SolicitarString
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim reader = context.ExecuteReader(report, params)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                result = sb.ToString()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function SolicitarDecimal(ByVal report As String, ByVal ParamArray params() As Object) As Decimal Implements IBusquedaRepositorio.SolicitarDecimal
            Dim result As Decimal = 0
            Try

                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim reader = context.ExecuteReader(report, params)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetDecimal(0))
                End While
                result = CDec(sb.ToString)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function SolicitarBooelan(ByVal report As String, ByVal ParamArray params() As Object) As Boolean Implements IBusquedaRepositorio.SolicitarBooelan
            Dim result As Boolean = False
            Try

                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim reader = context.ExecuteReader(report, params)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetBoolean(0))
                End While
                result = CBool(sb.ToString)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function SolicitarEntero(ByVal report As String, ByVal ParamArray params() As Object) As Integer Implements IBusquedaRepositorio.SolicitarEntero
            Dim result As Integer = 0
            Try

                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim reader = context.ExecuteReader(report, params)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetInt32(0))
                End While
                result = CInt(sb.ToString)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SolicitarStringXML(ByVal DatosXml As IO.StringReader, ByVal NombreCampo As String) As String Implements IBusquedaRepositorio.SolicitarStringXML
            SolicitarStringXML = ""
            Dim vFlagEncontrado As Boolean = False
            Dim vcontrol As Integer = DatosXml.Peek
            If vcontrol <> -1 Then
                Dim reader As New System.Xml.XmlTextReader(DatosXml)
                While (reader.Read())
                    reader.MoveToContent()
                    If reader.NodeType = Xml.XmlNodeType.Element Then
                        If reader.Name = NombreCampo Then
                            vFlagEncontrado = True
                        Else
                            vFlagEncontrado = False
                        End If
                    End If
                    If reader.NodeType = Xml.XmlNodeType.Text Then
                        If vFlagEncontrado Then
                            SolicitarStringXML = reader.Value
                            Exit While
                        End If
                    End If
                End While
            End If
            Return SolicitarStringXML
        End Function
        Public Function SolicitarDecimalXML(ByVal DatosXml As IO.StringReader, ByVal NombreCampo As String) As Decimal Implements IBusquedaRepositorio.SolicitarDecimalXML
            SolicitarDecimalXML = 0
            Dim vFlagEncontrado As Boolean = False
            Dim vcontrol As Integer = DatosXml.Peek
            If vcontrol <> -1 Then
                Dim reader As New System.Xml.XmlTextReader(DatosXml)
                While (reader.Read())
                    reader.MoveToContent()
                    If reader.NodeType = Xml.XmlNodeType.Element Then
                        If reader.Name = NombreCampo Then
                            vFlagEncontrado = True
                        Else
                            vFlagEncontrado = False
                        End If
                    End If
                    If reader.NodeType = Xml.XmlNodeType.Text Then
                        If vFlagEncontrado Then
                            SolicitarDecimalXML = CDec(reader.Value)
                            Exit While
                        End If
                    End If
                End While
            End If
            Return SolicitarDecimalXML
        End Function
        Public Function SolicitarEnteroXML(ByVal DatosXml As IO.StringReader, ByVal NombreCampo As String) As Integer Implements IBusquedaRepositorio.SolicitarEnteroXML
            SolicitarEnteroXML = 0
            Dim vFlagEncontrado As Boolean = False
            Dim vcontrol As Integer = DatosXml.Peek
            If vcontrol <> -1 Then
                Dim reader As New System.Xml.XmlTextReader(DatosXml)
                While (reader.Read())
                    reader.MoveToContent()
                    If reader.NodeType = Xml.XmlNodeType.Element Then
                        If reader.Name = NombreCampo Then
                            vFlagEncontrado = True
                        Else
                            vFlagEncontrado = False
                        End If
                    End If
                    If reader.NodeType = Xml.XmlNodeType.Text Then
                        If vFlagEncontrado Then
                            SolicitarEnteroXML = CInt(reader.Value)
                            Exit While
                        End If
                    End If
                End While
            End If
            Return SolicitarEnteroXML
        End Function

        Public Function InsertarPorProcedimiento(ByVal procedimiento As String, ByVal ParamArray params() As Object) As Integer Implements IBusquedaRepositorio.InsertarPorProcedimiento
            Dim result As Integer = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                result = context.ExecuteNonQuery(procedimiento, params)
            Catch ex As Exception
                result = 0
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

    End Class
End Namespace

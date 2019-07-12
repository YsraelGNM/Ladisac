Option Strict Off

Imports Ladisac.BE
Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Namespace Ladisac.BL
    Public Class BCUtil
        Implements IBCUtil


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetId(ByVal sTabla As String, ByVal sCampo As String, ByVal sNumeroDigitos As Integer, Optional ByVal sWhere As String = Nothing) As String Implements IBCUtil.GetId

            'Return result
            Dim result As String = Nothing
            Try
                Dim rep As New DA.ReportesRepositorio '= ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPCorrelativo, sTabla, sCampo, sNumeroDigitos, sWhere)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result

        End Function

        Public Function CorrelativoQuery(ByVal sTabla As String, ByVal sCampo As String, ByVal sNumeroDigitos As Integer, Optional ByVal sWhere As String = Nothing) As String Implements IBCUtil.CorrelativoQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                Dim e As New DA.ReportesRepositorio()
                result = rep.EjecutarReporte(DA.SPNames.SPCorrelativo, sTabla, sCampo, sNumeroDigitos, sWhere)

                ' result = rep.EjecutarReporte(DA.SPNames.SPCorrelativo, sTabla, sCampo, sNumeroDigitos, sWhere)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function diferenciaHorasHH(ByVal desde As Double, ByVal hasta As Double) As Double Implements IBCUtil.diferenciaHorasHH
            ' usado en horas de produccion  y horas de mantenimiento
            ' si se cambia esto tern en cuenta los dor formularios

            Dim diferencia As String

            Dim HOraInicio, HOraFin As String

            Dim h1, m1 As String
            Dim h2, m2 As String
            Dim mm1, mm2, mm3 As Double
            Dim hh, mm As Double
            Try

                HOraInicio = desde.ToString()
                HOraFin = hasta.ToString()

                If (HOraInicio.LastIndexOf(".") > 0) Then
                    h1 = HOraInicio.Substring(0, HOraInicio.LastIndexOf("."))
                    Dim d As Int16 = HOraInicio.LastIndexOf(".")
                    m1 = HOraInicio.Substring(HOraInicio.LastIndexOf(".") + 1, HOraInicio.Length - HOraInicio.LastIndexOf(".") - 1)
                    m1 = (m1 & "0000").Substring(0, 2)
                Else
                    h1 = HOraInicio
                    m1 = "00"
                End If
                mm1 = m1 + (h1 * 60)
                HOraInicio = derecha("000" & h1, 2) & ":" & derecha("000" & m1, 2)

                If (HOraFin.LastIndexOf(".") > 0) Then
                    h2 = HOraFin.Substring(0, HOraFin.LastIndexOf("."))
                    m2 = HOraFin.Substring(HOraFin.LastIndexOf(".") + 1, HOraFin.Length - HOraFin.LastIndexOf(".") - 1)
                    m2 = (m2 & "0000").Substring(0, 2)
                Else
                    h2 = HOraFin
                    m2 = "00"
                End If

                mm2 = CDbl(m2) + (CDbl(h2) * 60)


                ' fecha inicio es mayor a fecha final
                If (mm1 > mm2) Then
                    '24horas=1440 minutos
                    mm1 = 1440 - mm1
                    mm3 = mm2 + mm1
                Else
                    mm3 = mm2 - mm1
                End If

                hh = mm3 \ 60
                mm = mm3 - (hh * 60)
                ' diferencia = hh.ToString & "." & IIf(mm < 10, "0" & mm.ToString, mm.ToString)
                diferencia = hh + (CDbl(IIf(mm < 10, "0" & mm.ToString, mm.ToString)) / 60)

                Return CDbl(diferencia)
            Catch ex As Exception
                MsgBox("Error de calculo:" & ex.Message)
                diferencia = "0.00"
            End Try
            Return CDbl(diferencia)

        End Function

        Public Function derecha(ByVal sdato As String, ByVal numeros As Int16) Implements IBCUtil.derecha
            Return sdato.Substring(sdato.Length - numeros, numeros)

        End Function


        Public Sub excelExportar(ByVal oDAta As System.Data.DataTable) Implements IBCUtil.excelExportar



            Dim exApp As New Microsoft.Office.Interop.Excel.Application

            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook

            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


            Try



                exLibro = exApp.Workbooks.Add

                exHoja = CType(exLibro.Worksheets.Add(), Microsoft.Office.Interop.Excel.Worksheet)




                Dim NCol As Integer = oDAta.Columns.Count

                Dim NRow As Integer = oDAta.Rows.Count



                For i As Integer = 1 To NCol

                    exHoja.Cells.Item(1, i) = oDAta.Columns(i - 1).ColumnName.ToString

                Next



                Dim contFila As Integer = 0
                For Fila As Integer = 0 To NRow - 1

                    For Col As Integer = 0 To NCol - 1

                        exHoja.Cells.Item(Fila + 2, Col + 1) = oDAta.Rows(Fila).Item(Col)


                    Next
                    contFila += 1
                Next

                If NRow <> contFila Then
                    Err.Raise(&HFFFFFF01, "Error Provocado", "No coincide las filas.")
                End If

                exHoja.Rows.Item(1).Font.Bold = 1

                exHoja.Rows.Item(1).HorizontalAlignment = 3

                exHoja.Columns.AutoFit()

                exApp.Application.Visible = True

                exHoja = Nothing

                exLibro = Nothing

                exApp = Nothing

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            End Try


        End Sub

        Public Function excelImportacionConFormato(ByVal sRuta As String, ByVal sCabecere As String) As System.Data.DataTable Implements IBCUtil.excelImportacionConFormato
            Dim ruta As String = sRuta '"C:\carnet_madro.xls"
            Dim consulta As String = sCabecere '"SELECT CODTRAB ,NOMBRE, APEMAT,APEPAT ,DOCIDEN , DEPARTAMENTO, Rura FROM [Hoja1$]"

            Dim oConection As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0", ruta)
            Dim OoledbConn As New OleDbConnection(oConection)
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim oTable As New DataTable
            Try

                Dim _cmd As OleDbCommand = New OleDbCommand(consulta, OoledbConn)
                Dim _oleda As OleDbDataAdapter = New OleDbDataAdapter()
                _oleda.SelectCommand = _cmd
                OoledbConn.Open()

                _oleda.Fill(ds)


                oTable = ds.Tables(0)
                OoledbConn.Close()
            Catch EX As Exception

                MsgBox(EX.Message)



            End Try
            Return oTable
        End Function
        Public Function getXml1(ByVal oDataGridView As System.Windows.Forms.DataGridView, ByVal ParamArray Columns() As Integer) As String Implements IBCUtil.getXml
            Dim x, y As Int32
            Dim sRes As String
            x = 0
            y = 0

            sRes = "<MAtablita>"
            While (x < oDataGridView.Rows.Count)
                y = 0
                sRes &= " <rows>"
                While (y < Columns.Length)
                    sRes &= "  <campo" & y.ToString() & ">" & oDataGridView.Rows(x).Cells(Columns(y)).Value & "</campo" & y.ToString() & ">"
                    y += 1
                End While
                sRes &= " </rows>"
                x += 1
            End While
            sRes &= "</MAtablita>"
            Return sRes
        End Function
        Public Function getXml(ByVal ColumnaOK As Int16, ByVal oDataGridView As DataGridView, ByVal ParamArray Columns() As Integer) As String Implements IBCUtil.getXml
            Dim x, y As Int32
            Dim sRes As String
            x = 0
            y = 0

            sRes = "<MAtablita>"
            While (x < oDataGridView.Rows.Count)

                If CBool(oDataGridView.Rows(x).Cells(ColumnaOK).Value) Then
                    y = 0
                    sRes &= " <rows>"
                    While (y < Columns.Length)
                        sRes &= "  <campo" & y.ToString() & ">" & oDataGridView.Rows(x).Cells(Columns(y)).Value & "</campo" & y.ToString() & ">"
                        y += 1
                    End While
                    sRes &= " </rows>"
                End If

                x += 1
            End While
            sRes &= "</MAtablita>"
            Return sRes
        End Function
  

        Public Function getTable(ByVal DataGridView As System.Windows.Forms.DataGridView, ByVal tableName As String) As System.Data.DataTable Implements IBCUtil.getTable
            Dim dgv = DataGridView
           

            Dim table = New DataTable(tableName)
            ' Crea las columnas
            For iCol = 0 To dgv.Columns.Count - 1
                table.Columns.Add(dgv.Columns(iCol).Name)
            Next
            ' '' Agrega las filas
            If dgv.Rows(0).DataBoundItem IsNot Nothing Then
                For i = 0 To dgv.Rows.Count - 1
                    ' Obtiene el DataBound de la fila y copia los valores de la fila
                    Dim boundRow As DataRowView = CType(dgv.Rows(i).DataBoundItem, DataRowView)

                    Dim cells(0 To boundRow.Row.ItemArray.Length - 1) As Object

                    For iCol = 0 To boundRow.Row.ItemArray.Length - 1
                        cells(iCol) = boundRow.Row.ItemArray(iCol)
                    Next
                    ' Agrega la fila clonada
                    table.Rows.Add(cells)
                Next
            Else
                For i = 0 To dgv.Rows.Count - 1
                    Dim r As DataRow
                    r = table.NewRow
                    For iCol = 0 To dgv.Columns.Count - 1   'boundRow.Row.ItemArray.Length - 1
                        Try
                            r.Item(iCol) = dgv.Rows(i).Cells(iCol).Value
                        Catch ex As Exception
                            r.Item(iCol) = Nothing
                        End Try
                    Next
                    table.Rows.Add(r)
                Next
            End If

            Return table
        End Function
    End Class

End Namespace

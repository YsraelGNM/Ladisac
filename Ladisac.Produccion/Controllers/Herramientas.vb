Imports Microsoft.Practices.Unity
Imports Ladisac.Foundation
Imports Ladisac.BE
Imports Ladisac.BL
Imports System.IO
Imports System.Windows.Forms


Public Class Herramientas
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService


    Public Function PermisoEntidad(ByVal ENO_Id As Integer) As Boolean
        Dim Acceso As Boolean = False
        Dim Item As New Entidad
        Item = BCEntidad.EntidadGetById(ENO_Id)
        Do While Item.ENO_ID_PADRE <> -1
            Try
                Dim ds As New DataSet
                Dim query = BCEntidad.ListaUsuarioEntidad(SessionServer.UserId, Item.ENO_ID)
                If query = "" Then
                    Item = BCEntidad.EntidadGetById(Item.ENO_ID_PADRE)
                Else
                    Acceso = True
                    Exit Do
                End If
                'Dim rea As New StringReader(query)
                'ds.ReadXml(rea)
                'Dim dt As DataTable = ds.Tables(0)
                'If dt IsNot Nothing Then
                '    If Not dt.Rows.Count > 0 Then
                '        Item = BCEntidad.EntidadGetById(Item.ENO_ID_PADRE)
                '    Else
                '        Acceso = True
                '        Exit Do
                '    End If
                'End If

            Catch ex As Exception
                Acceso = False
                Exit Do
            End Try
        Loop
        Return Acceso
    End Function

    Public Sub excelExportar(ByVal oDAta As System.Data.DataTable)
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
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = oDAta.Rows(Fila).Item(Col)
                Next
            Next
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

    Public Shared Function ToTable(ByVal DataGridView As DataGridView, ByVal tableName As String) As DataTable
        Dim dgv = DataGridView
        Dim table = New DataTable(tableName)
        ' Crea las columnas
        For iCol = 0 To dgv.Columns.Count - 1
            table.Columns.Add(dgv.Columns(iCol).Name)
        Next
        ' Agrega las filas
        For i = 0 To dgv.Rows.Count - 1
            ' Obtiene el DataBound de la fila y copia los valores de la fila
            Dim mDR As DataRow = table.NewRow

            For iCol = 0 To dgv.Columns.Count - 1
                mDR.Item(iCol) = dgv.Rows(i).Cells(iCol).Value
            Next
            ' Agrega la fila clonada
            table.Rows.Add(mDR)

            'If dgv.Rows(i).DataBoundItem IsNot Nothing Then
            '    Dim boundRow = CType(dgv.Rows(i).DataBoundItem, DataRowView)
            '    Dim cells(0 To boundRow.Row.ItemArray.Length - 1) As Object

            '    For iCol = 0 To boundRow.Row.ItemArray.Length - 1
            '        cells(iCol) = boundRow.Row.ItemArray(iCol)
            '    Next
            '    ' Agrega la fila clonada
            '    table.Rows.Add(cells)
            'End If
        Next
        Return table
    End Function

End Class

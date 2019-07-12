Option Strict On
Imports Microsoft.Practices.Unity
Imports System.Linq
Imports System.IO
Imports Ladisac.BE
Namespace Ladisac.BL.Test
    <TestClass()>
    Public Class BCMaestroTest
        Private testContextInstance As TestContext
        Public Property TestContext() As TestContext
            Get
                Return testContextInstance
            End Get
            Set(ByVal value As TestContext)
                testContextInstance = value
            End Set
        End Property

        Public ContainerService As IUnityContainer


        <TestInitialize()>
        Public Sub MyTestInitialize()
            ContainerService = New UnityContainer
            Me.ContainerService.RegisterType(Of DA.IReportesRepositorio, DA.ReportesRepositorio)()
            Me.ContainerService.RegisterType(Of DA.IMonedaRepositorio, DA.MonedaRepositorio)()
            'Me.ContainerService.RegisterType(Of BL.IBCMoneda, BL.BCMoneda)()
            'Me.ContainerService.RegisterType(Of BL.IBCMonedaQueries, BL.BCMoneda)()
            Me.ContainerService.RegisterType(Of BL.IBCTipoParada, BL.BCTipoParada)()
            Me.ContainerService.RegisterType(Of BL.IBCParada, BL.BCParada)()

        End Sub
        <TestMethod()>
        Public Sub MonedasCRUD()
             Dim bcqueries = Me.ContainerService.Resolve(Of IBCMonedaQueries)()
            Dim bc = Me.ContainerService.Resolve(Of IBCMoneda)()
            Dim query = bcqueries.MonedaQuery()
            Dim resultSet = From c In XElement.Parse(query).Elements("Moneda")
                            Select New With {.Id = c.Element("MON_ID").Value,
                                             .Description = c.Element("MON_DESCRIPCION").Value}
            Dim current = resultSet.ElementAt(0)
            Dim moneda = bcqueries.MonedaSeek(current.Id)
            moneda.MarkAsModified()
            moneda.MON_DESCRIPCION = "cambio test"
            bc.MantenimientoMoneda(moneda)
            bc.MantenimientoMonedaDescripcion(current.Id, "nuevo cambio  description")
        End Sub

        <TestMethod()>
        Public Sub MonedasQuery()
            Dim bc = Me.ContainerService.Resolve(Of IBCMonedaQueries)()
            Dim query = bc.MonedaQuery()

            Dim resultSet = From c In XElement.Parse(query).Elements("Moneda")
                            Select New With {.Id = c.Element("MON_ID").Value,
                                             .Description = c.Element("MON_DESCRIPCION").Value}
            For Each item In resultSet.ToList
                Debug.Write(item.Description)
            Next
            '  modo table 
            Dim ds As New DataSet
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            For Each row As DataRow In ds.Tables(0).Rows
            Next
        End Sub
        <TestMethod()>
        Public Sub MarcaQuery()
        End Sub
    End Class
End Namespace



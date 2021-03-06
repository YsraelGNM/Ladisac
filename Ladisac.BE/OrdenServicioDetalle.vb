'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios en este archivo pueden ocasionar un comportamiento incorrecto y se perderán si
'     el código se vuelve a generar.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.CompilerServices

<DataContract(IsReference:=True)>
<KnownType(GetType(OrdenServicio))>
<KnownType(GetType(Articulos))>
<KnownType(GetType(CuentasContables))>
<KnownType(GetType(Entidad))>
<KnownType(GetType(DocumentoGuiasDetalle))>
Partial Public Class OrdenServicioDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared OSD_ID As string = "OSD_ID"
				public shared OSE_ID As string = "OSE_ID"
				public shared ORD_ID As string = "ORD_ID"
				public shared ART_ID As string = "ART_ID"
				public shared OSD_CANTIDAD As string = "OSD_CANTIDAD"
				public shared OSD_CANTIDAD_INGRESADA As string = "OSD_CANTIDAD_INGRESADA"
				public shared OSD_DESCUENTO As string = "OSD_DESCUENTO"
				public shared OSD_PRECIO_UNITARIO As string = "OSD_PRECIO_UNITARIO"
				public shared OSD_IGV As string = "OSD_IGV"
				public shared OSD_OTROS1 As string = "OSD_OTROS1"
				public shared OSD_OTROS2 As string = "OSD_OTROS2"
				public shared OSD_OTROS3 As string = "OSD_OTROS3"
				public shared OSD_CONTRAVALOR As string = "OSD_CONTRAVALOR"
				public shared OSD_OBSERVACIONES As string = "OSD_OBSERVACIONES"
				public shared OSD_INCLUYE_MATERIAL As string = "OSD_INCLUYE_MATERIAL"
				public shared OSD_PARTE_MATERIAL As string = "OSD_PARTE_MATERIAL"
				public shared PCD_ID As string = "PCD_ID"
				public shared OSD_DESCRIPCION As string = "OSD_DESCRIPCION"
				public shared USU_ID_AUT_2 As string = "USU_ID_AUT_2"
				public shared OSD_FEC_AUT_2 As string = "OSD_FEC_AUT_2"
				public shared USU_ID_AUT_3 As string = "USU_ID_AUT_3"
				public shared OSD_FEC_AUT_3 As string = "OSD_FEC_AUT_3"
				public shared USU_ID_AUT_4 As string = "USU_ID_AUT_4"
				public shared OSD_FEC_AUT_4 As string = "OSD_FEC_AUT_4"
				public shared CUC_ID As string = "CUC_ID"
				public shared ENO_ID As string = "ENO_ID"
				public shared OSD_CONFORMIDAD As string = "OSD_CONFORMIDAD"
				public shared OTR_ID As string = "OTR_ID"
				public shared DGD_ID As string = "DGD_ID"
				public shared PRO_ID As string = "PRO_ID"
				public shared CentroCosto As string = "CentroCosto"
		    End Structure
	



    <DataMember()>
    Public Property OSD_ID() As Integer
        Get
            Return _oSD_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_oSD_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'OSD_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _oSD_ID = value
                OnPropertyChanged("OSD_ID")
            End If
        End Set
    End Property

    Private _oSD_ID As Integer

    <DataMember()>
    Public Property OSE_ID() As Nullable(Of Integer)
        Get
            Return _oSE_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oSE_ID, value) Then
                ChangeTracker.RecordOriginalValue("OSE_ID", _oSE_ID)
                If Not IsDeserializing Then
                    If OrdenServicio IsNot Nothing AndAlso Not Equals(OrdenServicio.OSE_ID, value) Then
                        OrdenServicio = Nothing
                    End If
                End If
                _oSE_ID = value
                OnPropertyChanged("OSE_ID")
            End If
        End Set
    End Property

    Private _oSE_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ORD_ID() As Nullable(Of Integer)
        Get
            Return _oRD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oRD_ID, value) Then
                _oRD_ID = value
                OnPropertyChanged("ORD_ID")
            End If
        End Set
    End Property

    Private _oRD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ART_ID() As String
        Get
            Return _aRT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_aRT_ID, value) Then
                ChangeTracker.RecordOriginalValue("ART_ID", _aRT_ID)
                If Not IsDeserializing Then
                    If Articulos IsNot Nothing AndAlso Not Equals(Articulos.ART_ID, value) Then
                        Articulos = Nothing
                    End If
                End If
                _aRT_ID = value
                OnPropertyChanged("ART_ID")
            End If
        End Set
    End Property

    Private _aRT_ID As String

    <DataMember()>
    Public Property OSD_CANTIDAD() As Nullable(Of Decimal)
        Get
            Return _oSD_CANTIDAD
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oSD_CANTIDAD, value) Then
                _oSD_CANTIDAD = value
                OnPropertyChanged("OSD_CANTIDAD")
            End If
        End Set
    End Property

    Private _oSD_CANTIDAD As Nullable(Of Decimal)

    <DataMember()>
    Public Property OSD_CANTIDAD_INGRESADA() As Nullable(Of Decimal)
        Get
            Return _oSD_CANTIDAD_INGRESADA
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oSD_CANTIDAD_INGRESADA, value) Then
                _oSD_CANTIDAD_INGRESADA = value
                OnPropertyChanged("OSD_CANTIDAD_INGRESADA")
            End If
        End Set
    End Property

    Private _oSD_CANTIDAD_INGRESADA As Nullable(Of Decimal)

    <DataMember()>
    Public Property OSD_DESCUENTO() As Nullable(Of Decimal)
        Get
            Return _oSD_DESCUENTO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oSD_DESCUENTO, value) Then
                _oSD_DESCUENTO = value
                OnPropertyChanged("OSD_DESCUENTO")
            End If
        End Set
    End Property

    Private _oSD_DESCUENTO As Nullable(Of Decimal)

    <DataMember()>
    Public Property OSD_PRECIO_UNITARIO() As Nullable(Of Decimal)
        Get
            Return _oSD_PRECIO_UNITARIO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oSD_PRECIO_UNITARIO, value) Then
                _oSD_PRECIO_UNITARIO = value
                OnPropertyChanged("OSD_PRECIO_UNITARIO")
            End If
        End Set
    End Property

    Private _oSD_PRECIO_UNITARIO As Nullable(Of Decimal)

    <DataMember()>
    Public Property OSD_IGV() As Nullable(Of Decimal)
        Get
            Return _oSD_IGV
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oSD_IGV, value) Then
                _oSD_IGV = value
                OnPropertyChanged("OSD_IGV")
            End If
        End Set
    End Property

    Private _oSD_IGV As Nullable(Of Decimal)

    <DataMember()>
    Public Property OSD_OTROS1() As Nullable(Of Decimal)
        Get
            Return _oSD_OTROS1
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oSD_OTROS1, value) Then
                _oSD_OTROS1 = value
                OnPropertyChanged("OSD_OTROS1")
            End If
        End Set
    End Property

    Private _oSD_OTROS1 As Nullable(Of Decimal)

    <DataMember()>
    Public Property OSD_OTROS2() As Nullable(Of Decimal)
        Get
            Return _oSD_OTROS2
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oSD_OTROS2, value) Then
                _oSD_OTROS2 = value
                OnPropertyChanged("OSD_OTROS2")
            End If
        End Set
    End Property

    Private _oSD_OTROS2 As Nullable(Of Decimal)

    <DataMember()>
    Public Property OSD_OTROS3() As Nullable(Of Decimal)
        Get
            Return _oSD_OTROS3
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oSD_OTROS3, value) Then
                _oSD_OTROS3 = value
                OnPropertyChanged("OSD_OTROS3")
            End If
        End Set
    End Property

    Private _oSD_OTROS3 As Nullable(Of Decimal)

    <DataMember()>
    Public Property OSD_CONTRAVALOR() As Nullable(Of Decimal)
        Get
            Return _oSD_CONTRAVALOR
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oSD_CONTRAVALOR, value) Then
                _oSD_CONTRAVALOR = value
                OnPropertyChanged("OSD_CONTRAVALOR")
            End If
        End Set
    End Property

    Private _oSD_CONTRAVALOR As Nullable(Of Decimal)

    <DataMember()>
    Public Property OSD_OBSERVACIONES() As String
        Get
            Return _oSD_OBSERVACIONES
        End Get
        Set(ByVal value As String)
            If Not Equals(_oSD_OBSERVACIONES, value) Then
                _oSD_OBSERVACIONES = value
                OnPropertyChanged("OSD_OBSERVACIONES")
            End If
        End Set
    End Property

    Private _oSD_OBSERVACIONES As String

    <DataMember()>
    Public Property OSD_INCLUYE_MATERIAL() As Nullable(Of Boolean)
        Get
            Return _oSD_INCLUYE_MATERIAL
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_oSD_INCLUYE_MATERIAL, value) Then
                _oSD_INCLUYE_MATERIAL = value
                OnPropertyChanged("OSD_INCLUYE_MATERIAL")
            End If
        End Set
    End Property

    Private _oSD_INCLUYE_MATERIAL As Nullable(Of Boolean)

    <DataMember()>
    Public Property OSD_PARTE_MATERIAL() As Nullable(Of Boolean)
        Get
            Return _oSD_PARTE_MATERIAL
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_oSD_PARTE_MATERIAL, value) Then
                _oSD_PARTE_MATERIAL = value
                OnPropertyChanged("OSD_PARTE_MATERIAL")
            End If
        End Set
    End Property

    Private _oSD_PARTE_MATERIAL As Nullable(Of Boolean)

    <DataMember()>
    Public Property PCD_ID() As Nullable(Of Integer)
        Get
            Return _pCD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_pCD_ID, value) Then
                _pCD_ID = value
                OnPropertyChanged("PCD_ID")
            End If
        End Set
    End Property

    Private _pCD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property OSD_DESCRIPCION() As String
        Get
            Return _oSD_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_oSD_DESCRIPCION, value) Then
                _oSD_DESCRIPCION = value
                OnPropertyChanged("OSD_DESCRIPCION")
            End If
        End Set
    End Property

    Private _oSD_DESCRIPCION As String

    <DataMember()>
    Public Property USU_ID_AUT_2() As String
        Get
            Return _uSU_ID_AUT_2
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID_AUT_2, value) Then
                _uSU_ID_AUT_2 = value
                OnPropertyChanged("USU_ID_AUT_2")
            End If
        End Set
    End Property

    Private _uSU_ID_AUT_2 As String

    <DataMember()>
    Public Property OSD_FEC_AUT_2() As Nullable(Of Date)
        Get
            Return _oSD_FEC_AUT_2
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_oSD_FEC_AUT_2, value) Then
                _oSD_FEC_AUT_2 = value
                OnPropertyChanged("OSD_FEC_AUT_2")
            End If
        End Set
    End Property

    Private _oSD_FEC_AUT_2 As Nullable(Of Date)

    <DataMember()>
    Public Property USU_ID_AUT_3() As String
        Get
            Return _uSU_ID_AUT_3
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID_AUT_3, value) Then
                _uSU_ID_AUT_3 = value
                OnPropertyChanged("USU_ID_AUT_3")
            End If
        End Set
    End Property

    Private _uSU_ID_AUT_3 As String

    <DataMember()>
    Public Property OSD_FEC_AUT_3() As Nullable(Of Date)
        Get
            Return _oSD_FEC_AUT_3
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_oSD_FEC_AUT_3, value) Then
                _oSD_FEC_AUT_3 = value
                OnPropertyChanged("OSD_FEC_AUT_3")
            End If
        End Set
    End Property

    Private _oSD_FEC_AUT_3 As Nullable(Of Date)

    <DataMember()>
    Public Property USU_ID_AUT_4() As String
        Get
            Return _uSU_ID_AUT_4
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID_AUT_4, value) Then
                _uSU_ID_AUT_4 = value
                OnPropertyChanged("USU_ID_AUT_4")
            End If
        End Set
    End Property

    Private _uSU_ID_AUT_4 As String

    <DataMember()>
    Public Property OSD_FEC_AUT_4() As Nullable(Of Date)
        Get
            Return _oSD_FEC_AUT_4
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_oSD_FEC_AUT_4, value) Then
                _oSD_FEC_AUT_4 = value
                OnPropertyChanged("OSD_FEC_AUT_4")
            End If
        End Set
    End Property

    Private _oSD_FEC_AUT_4 As Nullable(Of Date)

    <DataMember()>
    Public Property CUC_ID() As String
        Get
            Return _cUC_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cUC_ID, value) Then
                ChangeTracker.RecordOriginalValue("CUC_ID", _cUC_ID)
                If Not IsDeserializing Then
                    If CuentasContables IsNot Nothing AndAlso Not Equals(CuentasContables.CUC_ID, value) Then
                        CuentasContables = Nothing
                    End If
                End If
                _cUC_ID = value
                OnPropertyChanged("CUC_ID")
            End If
        End Set
    End Property

    Private _cUC_ID As String

    <DataMember()>
    Public Property ENO_ID() As Nullable(Of Integer)
        Get
            Return _eNO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_eNO_ID, value) Then
                ChangeTracker.RecordOriginalValue("ENO_ID", _eNO_ID)
                If Not IsDeserializing Then
                    If Entidad IsNot Nothing AndAlso Not Equals(Entidad.ENO_ID, value) Then
                        Entidad = Nothing
                    End If
                End If
                _eNO_ID = value
                OnPropertyChanged("ENO_ID")
            End If
        End Set
    End Property

    Private _eNO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property OSD_CONFORMIDAD() As Nullable(Of Integer)
        Get
            Return _oSD_CONFORMIDAD
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oSD_CONFORMIDAD, value) Then
                _oSD_CONFORMIDAD = value
                OnPropertyChanged("OSD_CONFORMIDAD")
            End If
        End Set
    End Property

    Private _oSD_CONFORMIDAD As Nullable(Of Integer)

    <DataMember()>
    Public Property OTR_ID() As Nullable(Of Integer)
        Get
            Return _oTR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oTR_ID, value) Then
                _oTR_ID = value
                OnPropertyChanged("OTR_ID")
            End If
        End Set
    End Property

    Private _oTR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property DGD_ID() As Nullable(Of Integer)
        Get
            Return _dGD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dGD_ID, value) Then
                ChangeTracker.RecordOriginalValue("DGD_ID", _dGD_ID)
                If Not IsDeserializing Then
                    If DocumentoGuiasDetalle IsNot Nothing AndAlso Not Equals(DocumentoGuiasDetalle.DGD_ID, value) Then
                        DocumentoGuiasDetalle = Nothing
                    End If
                End If
                _dGD_ID = value
                OnPropertyChanged("DGD_ID")
            End If
        End Set
    End Property

    Private _dGD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property PRO_ID() As Nullable(Of Integer)
        Get
            Return _pRO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_pRO_ID, value) Then
                _pRO_ID = value
                OnPropertyChanged("PRO_ID")
            End If
        End Set
    End Property

    Private _pRO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property CentroCosto() As String
        Get
            Return _centroCosto
        End Get
        Set(ByVal value As String)
            If Not Equals(_centroCosto, value) Then
                _centroCosto = value
                OnPropertyChanged("CentroCosto")
            End If
        End Set
    End Property

    Private _centroCosto As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property OrdenServicio() As OrdenServicio
        Get
            Return _ordenServicio
        End Get
        Set(ByVal value As OrdenServicio)
            If _ordenServicio IsNot value Then
                Dim previousValue As OrdenServicio = _ordenServicio
                _ordenServicio = value
                FixupOrdenServicio(previousValue)
                OnNavigationPropertyChanged("OrdenServicio")
            End If
        End Set
    End Property

    Private _ordenServicio As OrdenServicio


    <DataMember()>
    Public Property Articulos() As Articulos
        Get
            Return _articulos
        End Get
        Set(ByVal value As Articulos)
            If _articulos IsNot value Then
                Dim previousValue As Articulos = _articulos
                _articulos = value
                FixupArticulos(previousValue)
                OnNavigationPropertyChanged("Articulos")
            End If
        End Set
    End Property

    Private _articulos As Articulos


    <DataMember()>
    Public Property CuentasContables() As CuentasContables
        Get
            Return _cuentasContables
        End Get
        Set(ByVal value As CuentasContables)
            If _cuentasContables IsNot value Then
                Dim previousValue As CuentasContables = _cuentasContables
                _cuentasContables = value
                FixupCuentasContables(previousValue)
                OnNavigationPropertyChanged("CuentasContables")
            End If
        End Set
    End Property

    Private _cuentasContables As CuentasContables


    <DataMember()>
    Public Property Entidad() As Entidad
        Get
            Return _entidad
        End Get
        Set(ByVal value As Entidad)
            If _entidad IsNot value Then
                Dim previousValue As Entidad = _entidad
                _entidad = value
                FixupEntidad(previousValue)
                OnNavigationPropertyChanged("Entidad")
            End If
        End Set
    End Property

    Private _entidad As Entidad


    <DataMember()>
    Public Property DocumentoGuiasDetalle() As DocumentoGuiasDetalle
        Get
            Return _documentoGuiasDetalle
        End Get
        Set(ByVal value As DocumentoGuiasDetalle)
            If _documentoGuiasDetalle IsNot value Then
                Dim previousValue As DocumentoGuiasDetalle = _documentoGuiasDetalle
                _documentoGuiasDetalle = value
                FixupDocumentoGuiasDetalle(previousValue)
                OnNavigationPropertyChanged("DocumentoGuiasDetalle")
            End If
        End Set
    End Property

    Private _documentoGuiasDetalle As DocumentoGuiasDetalle


#End Region
#Region "ChangeTracking"

    Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
        If ChangeTracker.State <> ObjectState.Added AndAlso ChangeTracker.State <> ObjectState.Deleted Then
            ChangeTracker.State = ObjectState.Modified
        End If
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Protected Overridable Sub OnNavigationPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private _changeTracker As ObjectChangeTracker

    <DataMember()>
    Public Property ChangeTracker() As ObjectChangeTracker Implements IObjectWithChangeTracker.ChangeTracker
        Get
            If _changeTracker Is Nothing Then
                _changeTracker = New ObjectChangeTracker()
                AddHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
            Return _changeTracker
        End Get
        Set(ByVal value As ObjectChangeTracker)
            If _changeTracker IsNot Nothing Then
                RemoveHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
            _changeTracker = value
            If _changeTracker IsNot Nothing Then
                AddHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
        End Set
    End Property

    Private Sub HandleObjectStateChanging(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.ClearNavigationProperties()
        End If
    End Sub

    Private _isDeserializing As Boolean
    Protected Property IsDeserializing() As Boolean
        Get
            Return _isDeserializing
        End Get
        Private Set(ByVal value As Boolean)
            _isDeserializing = value
        End Set
    End Property

    <OnDeserializing()>
    Public Sub OnDeserializingMethod(ByVal context As StreamingContext)
        IsDeserializing = True
    End Sub

    <OnDeserialized()>
    Public Sub OnDeserializedMethod(ByVal context As StreamingContext)
        IsDeserializing = False
        ChangeTracker.ChangeTrackingEnabled = True
    End Sub

    Protected Overridable Sub ClearNavigationProperties()
        OrdenServicio = Nothing
        Articulos = Nothing
        CuentasContables = Nothing
        Entidad = Nothing
        DocumentoGuiasDetalle = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupOrdenServicio(ByVal previousValue As OrdenServicio, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.OrdenServicioDetalle.Contains(Me) Then
            previousValue.OrdenServicioDetalle.Remove(Me)
        End If

        If OrdenServicio IsNot Nothing Then
            If Not OrdenServicio.OrdenServicioDetalle.Contains(Me) Then
                OrdenServicio.OrdenServicioDetalle.Add(Me)
            End If

            OSE_ID = OrdenServicio.OSE_ID
        ElseIf Not skipKeys Then
            OSE_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("OrdenServicio") AndAlso
                ChangeTracker.OriginalValues("OrdenServicio") Is OrdenServicio Then
                ChangeTracker.OriginalValues.Remove("OrdenServicio")
            Else
                ChangeTracker.RecordOriginalValue("OrdenServicio", previousValue)
            End If
            If OrdenServicio IsNot Nothing AndAlso Not OrdenServicio.ChangeTracker.ChangeTrackingEnabled Then
                OrdenServicio.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupArticulos(ByVal previousValue As Articulos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.OrdenServicioDetalle.Contains(Me) Then
            previousValue.OrdenServicioDetalle.Remove(Me)
        End If

        If Articulos IsNot Nothing Then
            If Not Articulos.OrdenServicioDetalle.Contains(Me) Then
                Articulos.OrdenServicioDetalle.Add(Me)
            End If

            ART_ID = Articulos.ART_ID
        ElseIf Not skipKeys Then
            ART_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Articulos") AndAlso
                ChangeTracker.OriginalValues("Articulos") Is Articulos Then
                ChangeTracker.OriginalValues.Remove("Articulos")
            Else
                ChangeTracker.RecordOriginalValue("Articulos", previousValue)
            End If
            If Articulos IsNot Nothing AndAlso Not Articulos.ChangeTracker.ChangeTrackingEnabled Then
                Articulos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupCuentasContables(ByVal previousValue As CuentasContables, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.OrdenServicioDetalle.Contains(Me) Then
            previousValue.OrdenServicioDetalle.Remove(Me)
        End If

        If CuentasContables IsNot Nothing Then
            If Not CuentasContables.OrdenServicioDetalle.Contains(Me) Then
                CuentasContables.OrdenServicioDetalle.Add(Me)
            End If

            CUC_ID = CuentasContables.CUC_ID
        ElseIf Not skipKeys Then
            CUC_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("CuentasContables") AndAlso
                ChangeTracker.OriginalValues("CuentasContables") Is CuentasContables Then
                ChangeTracker.OriginalValues.Remove("CuentasContables")
            Else
                ChangeTracker.RecordOriginalValue("CuentasContables", previousValue)
            End If
            If CuentasContables IsNot Nothing AndAlso Not CuentasContables.ChangeTracker.ChangeTrackingEnabled Then
                CuentasContables.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupEntidad(ByVal previousValue As Entidad, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.OrdenServicioDetalle.Contains(Me) Then
            previousValue.OrdenServicioDetalle.Remove(Me)
        End If

        If Entidad IsNot Nothing Then
            If Not Entidad.OrdenServicioDetalle.Contains(Me) Then
                Entidad.OrdenServicioDetalle.Add(Me)
            End If

            ENO_ID = Entidad.ENO_ID
        ElseIf Not skipKeys Then
            ENO_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Entidad") AndAlso
                ChangeTracker.OriginalValues("Entidad") Is Entidad Then
                ChangeTracker.OriginalValues.Remove("Entidad")
            Else
                ChangeTracker.RecordOriginalValue("Entidad", previousValue)
            End If
            If Entidad IsNot Nothing AndAlso Not Entidad.ChangeTracker.ChangeTrackingEnabled Then
                Entidad.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupDocumentoGuiasDetalle(ByVal previousValue As DocumentoGuiasDetalle, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.OrdenServicioDetalle.Contains(Me) Then
            previousValue.OrdenServicioDetalle.Remove(Me)
        End If

        If DocumentoGuiasDetalle IsNot Nothing Then
            If Not DocumentoGuiasDetalle.OrdenServicioDetalle.Contains(Me) Then
                DocumentoGuiasDetalle.OrdenServicioDetalle.Add(Me)
            End If

            DGD_ID = DocumentoGuiasDetalle.DGD_ID
        ElseIf Not skipKeys Then
            DGD_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("DocumentoGuiasDetalle") AndAlso
                ChangeTracker.OriginalValues("DocumentoGuiasDetalle") Is DocumentoGuiasDetalle Then
                ChangeTracker.OriginalValues.Remove("DocumentoGuiasDetalle")
            Else
                ChangeTracker.RecordOriginalValue("DocumentoGuiasDetalle", previousValue)
            End If
            If DocumentoGuiasDetalle IsNot Nothing AndAlso Not DocumentoGuiasDetalle.ChangeTracker.ChangeTrackingEnabled Then
                DocumentoGuiasDetalle.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class

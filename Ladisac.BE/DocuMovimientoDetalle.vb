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
<KnownType(GetType(Articulos))>
<KnownType(GetType(Kardex))>
<KnownType(GetType(Almacen))>
<KnownType(GetType(Produccion))>
Partial Public Class DocuMovimientoDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DMD_ID As string = "DMD_ID"
				public shared DMO_ID As string = "DMO_ID"
				public shared ALM_ID As string = "ALM_ID"
				public shared ART_ID As string = "ART_ID"
				public shared DMD_CANTIDAD As string = "DMD_CANTIDAD"
				public shared DMD_DESCUENTO As string = "DMD_DESCUENTO"
				public shared DMD_PRECIO_UNITARIO As string = "DMD_PRECIO_UNITARIO"
				public shared DMD_IGV As string = "DMD_IGV"
				public shared DMD_CONTRAVALOR As string = "DMD_CONTRAVALOR"
				public shared DMD_GLOSA As string = "DMD_GLOSA"
				public shared ORD_ID As string = "ORD_ID"
				public shared OCD_ID As string = "OCD_ID"
				public shared DMD_ID_REF As string = "DMD_ID_REF"
				public shared TRD_ID As string = "TRD_ID"
				public shared RCD_ID As string = "RCD_ID"
				public shared OSD_ID As string = "OSD_ID"
				public shared PRO_ID As string = "PRO_ID"
		    End Structure
	



    <DataMember()>
    Public Property DMD_ID() As Integer
        Get
            Return _dMD_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dMD_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DMD_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dMD_ID = value
                OnPropertyChanged("DMD_ID")
            End If
        End Set
    End Property

    Private _dMD_ID As Integer

    <DataMember()>
    Public Property DMO_ID() As Nullable(Of Integer)
        Get
            Return _dMO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dMO_ID, value) Then
                ChangeTracker.RecordOriginalValue("DMO_ID", _dMO_ID)
                _dMO_ID = value
                OnPropertyChanged("DMO_ID")
            End If
        End Set
    End Property

    Private _dMO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ALM_ID() As Nullable(Of Integer)
        Get
            Return _aLM_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aLM_ID, value) Then
                ChangeTracker.RecordOriginalValue("ALM_ID", _aLM_ID)
                If Not IsDeserializing Then
                    If Almacen IsNot Nothing AndAlso Not Equals(Almacen.ALM_ID, value) Then
                        Almacen = Nothing
                    End If
                End If
                _aLM_ID = value
                OnPropertyChanged("ALM_ID")
            End If
        End Set
    End Property

    Private _aLM_ID As Nullable(Of Integer)

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
    Public Property DMD_CANTIDAD() As Nullable(Of Decimal)
        Get
            Return _dMD_CANTIDAD
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dMD_CANTIDAD, value) Then
                _dMD_CANTIDAD = value
                OnPropertyChanged("DMD_CANTIDAD")
            End If
        End Set
    End Property

    Private _dMD_CANTIDAD As Nullable(Of Decimal)

    <DataMember()>
    Public Property DMD_DESCUENTO() As Nullable(Of Decimal)
        Get
            Return _dMD_DESCUENTO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dMD_DESCUENTO, value) Then
                _dMD_DESCUENTO = value
                OnPropertyChanged("DMD_DESCUENTO")
            End If
        End Set
    End Property

    Private _dMD_DESCUENTO As Nullable(Of Decimal)

    <DataMember()>
    Public Property DMD_PRECIO_UNITARIO() As Nullable(Of Decimal)
        Get
            Return _dMD_PRECIO_UNITARIO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dMD_PRECIO_UNITARIO, value) Then
                _dMD_PRECIO_UNITARIO = value
                OnPropertyChanged("DMD_PRECIO_UNITARIO")
            End If
        End Set
    End Property

    Private _dMD_PRECIO_UNITARIO As Nullable(Of Decimal)

    <DataMember()>
    Public Property DMD_IGV() As Nullable(Of Decimal)
        Get
            Return _dMD_IGV
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dMD_IGV, value) Then
                _dMD_IGV = value
                OnPropertyChanged("DMD_IGV")
            End If
        End Set
    End Property

    Private _dMD_IGV As Nullable(Of Decimal)

    <DataMember()>
    Public Property DMD_CONTRAVALOR() As Nullable(Of Decimal)
        Get
            Return _dMD_CONTRAVALOR
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dMD_CONTRAVALOR, value) Then
                _dMD_CONTRAVALOR = value
                OnPropertyChanged("DMD_CONTRAVALOR")
            End If
        End Set
    End Property

    Private _dMD_CONTRAVALOR As Nullable(Of Decimal)

    <DataMember()>
    Public Property DMD_GLOSA() As String
        Get
            Return _dMD_GLOSA
        End Get
        Set(ByVal value As String)
            If Not Equals(_dMD_GLOSA, value) Then
                _dMD_GLOSA = value
                OnPropertyChanged("DMD_GLOSA")
            End If
        End Set
    End Property

    Private _dMD_GLOSA As String

    <DataMember()>
    Public Property ORD_ID() As Nullable(Of Integer)
        Get
            Return _oRD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oRD_ID, value) Then
                ChangeTracker.RecordOriginalValue("ORD_ID", _oRD_ID)
                _oRD_ID = value
                OnPropertyChanged("ORD_ID")
            End If
        End Set
    End Property

    Private _oRD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property OCD_ID() As Nullable(Of Integer)
        Get
            Return _oCD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oCD_ID, value) Then
                ChangeTracker.RecordOriginalValue("OCD_ID", _oCD_ID)
                _oCD_ID = value
                OnPropertyChanged("OCD_ID")
            End If
        End Set
    End Property

    Private _oCD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property DMD_ID_REF() As Nullable(Of Integer)
        Get
            Return _dMD_ID_REF
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dMD_ID_REF, value) Then
                _dMD_ID_REF = value
                OnPropertyChanged("DMD_ID_REF")
            End If
        End Set
    End Property

    Private _dMD_ID_REF As Nullable(Of Integer)

    <DataMember()>
    Public Property TRD_ID() As Nullable(Of Integer)
        Get
            Return _tRD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_tRD_ID, value) Then
                ChangeTracker.RecordOriginalValue("TRD_ID", _tRD_ID)
                _tRD_ID = value
                OnPropertyChanged("TRD_ID")
            End If
        End Set
    End Property

    Private _tRD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property RCD_ID() As Nullable(Of Integer)
        Get
            Return _rCD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_rCD_ID, value) Then
                ChangeTracker.RecordOriginalValue("RCD_ID", _rCD_ID)
                _rCD_ID = value
                OnPropertyChanged("RCD_ID")
            End If
        End Set
    End Property

    Private _rCD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property OSD_ID() As Nullable(Of Integer)
        Get
            Return _oSD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oSD_ID, value) Then
                ChangeTracker.RecordOriginalValue("OSD_ID", _oSD_ID)
                _oSD_ID = value
                OnPropertyChanged("OSD_ID")
            End If
        End Set
    End Property

    Private _oSD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property PRO_ID() As Nullable(Of Integer)
        Get
            Return _pRO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_pRO_ID, value) Then
                ChangeTracker.RecordOriginalValue("PRO_ID", _pRO_ID)
                If Not IsDeserializing Then
                    If Produccion IsNot Nothing AndAlso Not Equals(Produccion.PRO_ID, value) Then
                        Produccion = Nothing
                    End If
                End If
                _pRO_ID = value
                OnPropertyChanged("PRO_ID")
            End If
        End Set
    End Property

    Private _pRO_ID As Nullable(Of Integer)

#End Region
#Region "Propiedades de navegación"

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
    Public Property Kardex() As TrackableCollection(Of Kardex)
        Get
            If _kardex Is Nothing Then
                _kardex = New TrackableCollection(Of Kardex)
                AddHandler _kardex.CollectionChanged, AddressOf FixupKardex
            End If
            Return _kardex
        End Get
        Set(ByVal value As TrackableCollection(Of Kardex))
            If Not Object.ReferenceEquals(_kardex, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _kardex IsNot Nothing Then
                    RemoveHandler _kardex.CollectionChanged, AddressOf FixupKardex
                End If
                _kardex = value
                If _kardex IsNot Nothing Then
                    AddHandler _kardex.CollectionChanged, AddressOf FixupKardex
                End If
                OnNavigationPropertyChanged("Kardex")
            End If
        End Set
    End Property

    Private _kardex As TrackableCollection(Of Kardex)

    <DataMember()>
    Public Property Almacen() As Almacen
        Get
            Return _almacen
        End Get
        Set(ByVal value As Almacen)
            If _almacen IsNot value Then
                Dim previousValue As Almacen = _almacen
                _almacen = value
                FixupAlmacen(previousValue)
                OnNavigationPropertyChanged("Almacen")
            End If
        End Set
    End Property

    Private _almacen As Almacen


    <DataMember()>
    Public Property Produccion() As Produccion
        Get
            Return _produccion
        End Get
        Set(ByVal value As Produccion)
            If _produccion IsNot value Then
                Dim previousValue As Produccion = _produccion
                _produccion = value
                FixupProduccion(previousValue)
                OnNavigationPropertyChanged("Produccion")
            End If
        End Set
    End Property

    Private _produccion As Produccion


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
        Articulos = Nothing
        Kardex.Clear()
        Almacen = Nothing
        Produccion = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupArticulos(ByVal previousValue As Articulos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Articulos IsNot Nothing Then
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

    Private Sub FixupAlmacen(ByVal previousValue As Almacen, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Almacen IsNot Nothing Then
            ALM_ID = Almacen.ALM_ID
        ElseIf Not skipKeys Then
            ALM_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Almacen") AndAlso
                ChangeTracker.OriginalValues("Almacen") Is Almacen Then
                ChangeTracker.OriginalValues.Remove("Almacen")
            Else
                ChangeTracker.RecordOriginalValue("Almacen", previousValue)
            End If
            If Almacen IsNot Nothing AndAlso Not Almacen.ChangeTracker.ChangeTrackingEnabled Then
                Almacen.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupProduccion(ByVal previousValue As Produccion, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Produccion IsNot Nothing Then
            PRO_ID = Produccion.PRO_ID
        ElseIf Not skipKeys Then
            PRO_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Produccion") AndAlso
                ChangeTracker.OriginalValues("Produccion") Is Produccion Then
                ChangeTracker.OriginalValues.Remove("Produccion")
            Else
                ChangeTracker.RecordOriginalValue("Produccion", previousValue)
            End If
            If Produccion IsNot Nothing AndAlso Not Produccion.ChangeTracker.ChangeTrackingEnabled Then
                Produccion.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupKardex(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Kardex In e.NewItems
                item.DMD_ID = DMD_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Kardex", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Kardex In e.OldItems
                item.DMD_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Kardex", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

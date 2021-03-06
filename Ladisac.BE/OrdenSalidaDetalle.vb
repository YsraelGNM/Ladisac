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
<KnownType(GetType(Entidad))>
<KnownType(GetType(DocuMovimientoDetalle))>
Partial Public Class OrdenSalidaDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared OSD_ID As string = "OSD_ID"
				public shared OSA_ID As string = "OSA_ID"
				public shared ENO_ID As string = "ENO_ID"
				public shared ART_ID As string = "ART_ID"
				public shared OSD_CANTIDAD As string = "OSD_CANTIDAD"
				public shared OSD_OBSERVACION As string = "OSD_OBSERVACION"
				public shared OSD_VUELVE As string = "OSD_VUELVE"
				public shared OSD_REGRESO As string = "OSD_REGRESO"
				public shared OSD_DESCRIPCION As string = "OSD_DESCRIPCION"
				public shared TRD_ID As string = "TRD_ID"
				public shared ALM_ID_SALIDA As string = "ALM_ID_SALIDA"
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
    Public Property OSA_ID() As Nullable(Of Integer)
        Get
            Return _oSA_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oSA_ID, value) Then
                ChangeTracker.RecordOriginalValue("OSA_ID", _oSA_ID)
                _oSA_ID = value
                OnPropertyChanged("OSA_ID")
            End If
        End Set
    End Property

    Private _oSA_ID As Nullable(Of Integer)

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
    Public Property OSD_OBSERVACION() As String
        Get
            Return _oSD_OBSERVACION
        End Get
        Set(ByVal value As String)
            If Not Equals(_oSD_OBSERVACION, value) Then
                _oSD_OBSERVACION = value
                OnPropertyChanged("OSD_OBSERVACION")
            End If
        End Set
    End Property

    Private _oSD_OBSERVACION As String

    <DataMember()>
    Public Property OSD_VUELVE() As Nullable(Of Boolean)
        Get
            Return _oSD_VUELVE
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_oSD_VUELVE, value) Then
                _oSD_VUELVE = value
                OnPropertyChanged("OSD_VUELVE")
            End If
        End Set
    End Property

    Private _oSD_VUELVE As Nullable(Of Boolean)

    <DataMember()>
    Public Property OSD_REGRESO() As Nullable(Of Boolean)
        Get
            Return _oSD_REGRESO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_oSD_REGRESO, value) Then
                _oSD_REGRESO = value
                OnPropertyChanged("OSD_REGRESO")
            End If
        End Set
    End Property

    Private _oSD_REGRESO As Nullable(Of Boolean)

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
    Public Property TRD_ID() As Nullable(Of Integer)
        Get
            Return _tRD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_tRD_ID, value) Then
                _tRD_ID = value
                OnPropertyChanged("TRD_ID")
            End If
        End Set
    End Property

    Private _tRD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ALM_ID_SALIDA() As Nullable(Of Integer)
        Get
            Return _aLM_ID_SALIDA
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aLM_ID_SALIDA, value) Then
                _aLM_ID_SALIDA = value
                OnPropertyChanged("ALM_ID_SALIDA")
            End If
        End Set
    End Property

    Private _aLM_ID_SALIDA As Nullable(Of Integer)

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
    Public Property DocuMovimientoDetalle() As TrackableCollection(Of DocuMovimientoDetalle)
        Get
            If _docuMovimientoDetalle Is Nothing Then
                _docuMovimientoDetalle = New TrackableCollection(Of DocuMovimientoDetalle)
                AddHandler _docuMovimientoDetalle.CollectionChanged, AddressOf FixupDocuMovimientoDetalle
            End If
            Return _docuMovimientoDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of DocuMovimientoDetalle))
            If Not Object.ReferenceEquals(_docuMovimientoDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _docuMovimientoDetalle IsNot Nothing Then
                    RemoveHandler _docuMovimientoDetalle.CollectionChanged, AddressOf FixupDocuMovimientoDetalle
                End If
                _docuMovimientoDetalle = value
                If _docuMovimientoDetalle IsNot Nothing Then
                    AddHandler _docuMovimientoDetalle.CollectionChanged, AddressOf FixupDocuMovimientoDetalle
                End If
                OnNavigationPropertyChanged("DocuMovimientoDetalle")
            End If
        End Set
    End Property

    Private _docuMovimientoDetalle As TrackableCollection(Of DocuMovimientoDetalle)

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
        Entidad = Nothing
        DocuMovimientoDetalle.Clear()
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

    Private Sub FixupEntidad(ByVal previousValue As Entidad, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Entidad IsNot Nothing Then
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

    Private Sub FixupDocuMovimientoDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DocuMovimientoDetalle In e.NewItems
                item.OSD_ID = OSD_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DocuMovimientoDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DocuMovimientoDetalle In e.OldItems
                item.OSD_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuMovimientoDetalle", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

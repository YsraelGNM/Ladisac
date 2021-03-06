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
<KnownType(GetType(Personas))>
<KnownType(GetType(TransformacionDetalle))>
<KnownType(GetType(DocuMovimiento))>
Partial Public Class Transformacion
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared TFO_ID As string = "TFO_ID"
				public shared TFO_FECHA As string = "TFO_FECHA"
				public shared PER_ID_RESPONSABLE As string = "PER_ID_RESPONSABLE"
				public shared TFO_OBSERVACION As string = "TFO_OBSERVACION"
				public shared TFO_ES_PENDIENTE As string = "TFO_ES_PENDIENTE"
				public shared USU_ID As string = "USU_ID"
				public shared TFO_FEC_GRAB As string = "TFO_FEC_GRAB"
				public shared TFO_ESTADO As string = "TFO_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property TFO_ID() As Integer
        Get
            Return _tFO_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_tFO_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'TFO_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _tFO_ID = value
                OnPropertyChanged("TFO_ID")
            End If
        End Set
    End Property

    Private _tFO_ID As Integer

    <DataMember()>
    Public Property TFO_FECHA() As Nullable(Of Date)
        Get
            Return _tFO_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_tFO_FECHA, value) Then
                _tFO_FECHA = value
                OnPropertyChanged("TFO_FECHA")
            End If
        End Set
    End Property

    Private _tFO_FECHA As Nullable(Of Date)

    <DataMember()>
    Public Property PER_ID_RESPONSABLE() As String
        Get
            Return _pER_ID_RESPONSABLE
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_RESPONSABLE, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_RESPONSABLE", _pER_ID_RESPONSABLE)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID_RESPONSABLE = value
                OnPropertyChanged("PER_ID_RESPONSABLE")
            End If
        End Set
    End Property

    Private _pER_ID_RESPONSABLE As String

    <DataMember()>
    Public Property TFO_OBSERVACION() As String
        Get
            Return _tFO_OBSERVACION
        End Get
        Set(ByVal value As String)
            If Not Equals(_tFO_OBSERVACION, value) Then
                _tFO_OBSERVACION = value
                OnPropertyChanged("TFO_OBSERVACION")
            End If
        End Set
    End Property

    Private _tFO_OBSERVACION As String

    <DataMember()>
    Public Property TFO_ES_PENDIENTE() As String
        Get
            Return _tFO_ES_PENDIENTE
        End Get
        Set(ByVal value As String)
            If Not Equals(_tFO_ES_PENDIENTE, value) Then
                _tFO_ES_PENDIENTE = value
                OnPropertyChanged("TFO_ES_PENDIENTE")
            End If
        End Set
    End Property

    Private _tFO_ES_PENDIENTE As String

    <DataMember()>
    Public Property USU_ID() As String
        Get
            Return _uSU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID, value) Then
                _uSU_ID = value
                OnPropertyChanged("USU_ID")
            End If
        End Set
    End Property

    Private _uSU_ID As String

    <DataMember()>
    Public Property TFO_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _tFO_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_tFO_FEC_GRAB, value) Then
                _tFO_FEC_GRAB = value
                OnPropertyChanged("TFO_FEC_GRAB")
            End If
        End Set
    End Property

    Private _tFO_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property TFO_ESTADO() As Nullable(Of Boolean)
        Get
            Return _tFO_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_tFO_ESTADO, value) Then
                _tFO_ESTADO = value
                OnPropertyChanged("TFO_ESTADO")
            End If
        End Set
    End Property

    Private _tFO_ESTADO As Nullable(Of Boolean)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Personas() As Personas
        Get
            Return _personas
        End Get
        Set(ByVal value As Personas)
            If _personas IsNot value Then
                Dim previousValue As Personas = _personas
                _personas = value
                FixupPersonas(previousValue)
                OnNavigationPropertyChanged("Personas")
            End If
        End Set
    End Property

    Private _personas As Personas


    <DataMember()>
    Public Property TransformacionDetalle() As TrackableCollection(Of TransformacionDetalle)
        Get
            If _transformacionDetalle Is Nothing Then
                _transformacionDetalle = New TrackableCollection(Of TransformacionDetalle)
                AddHandler _transformacionDetalle.CollectionChanged, AddressOf FixupTransformacionDetalle
            End If
            Return _transformacionDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of TransformacionDetalle))
            If Not Object.ReferenceEquals(_transformacionDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _transformacionDetalle IsNot Nothing Then
                    RemoveHandler _transformacionDetalle.CollectionChanged, AddressOf FixupTransformacionDetalle
                End If
                _transformacionDetalle = value
                If _transformacionDetalle IsNot Nothing Then
                    AddHandler _transformacionDetalle.CollectionChanged, AddressOf FixupTransformacionDetalle
                End If
                OnNavigationPropertyChanged("TransformacionDetalle")
            End If
        End Set
    End Property

    Private _transformacionDetalle As TrackableCollection(Of TransformacionDetalle)

    <DataMember()>
    Public Property DocuMovimiento() As TrackableCollection(Of DocuMovimiento)
        Get
            If _docuMovimiento Is Nothing Then
                _docuMovimiento = New TrackableCollection(Of DocuMovimiento)
                AddHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
            End If
            Return _docuMovimiento
        End Get
        Set(ByVal value As TrackableCollection(Of DocuMovimiento))
            If Not Object.ReferenceEquals(_docuMovimiento, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _docuMovimiento IsNot Nothing Then
                    RemoveHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
                End If
                _docuMovimiento = value
                If _docuMovimiento IsNot Nothing Then
                    AddHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
                End If
                OnNavigationPropertyChanged("DocuMovimiento")
            End If
        End Set
    End Property

    Private _docuMovimiento As TrackableCollection(Of DocuMovimiento)

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
        Personas = Nothing
        TransformacionDetalle.Clear()
        DocuMovimiento.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPersonas(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Personas IsNot Nothing Then
            PER_ID_RESPONSABLE = Personas.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_RESPONSABLE = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Personas") AndAlso
                ChangeTracker.OriginalValues("Personas") Is Personas Then
                ChangeTracker.OriginalValues.Remove("Personas")
            Else
                ChangeTracker.RecordOriginalValue("Personas", previousValue)
            End If
            If Personas IsNot Nothing AndAlso Not Personas.ChangeTracker.ChangeTrackingEnabled Then
                Personas.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupTransformacionDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As TransformacionDetalle In e.NewItems
                item.TFO_ID = TFO_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("TransformacionDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As TransformacionDetalle In e.OldItems
                item.TFO_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("TransformacionDetalle", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocuMovimiento(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DocuMovimiento In e.NewItems
                item.TFO_ID = TFO_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DocuMovimiento In e.OldItems
                item.TFO_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

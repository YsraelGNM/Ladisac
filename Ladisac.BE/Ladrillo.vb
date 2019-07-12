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
<KnownType(GetType(LadrilloMalecon))>
Partial Public Class Ladrillo
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared LAD_ID As string = "LAD_ID"
				public shared ART_ID_LADRILLO As string = "ART_ID_LADRILLO"
				public shared LAD_CANT_TABLA As string = "LAD_CANT_TABLA"
				public shared LAD_CANT_CORTE As string = "LAD_CANT_CORTE"
				public shared LAD_TIEMPO_COCCION As string = "LAD_TIEMPO_COCCION"
				public shared LAD_TEMP_COCCION As string = "LAD_TEMP_COCCION"
				public shared USU_ID As string = "USU_ID"
				public shared LAD_FEC_GRAB As string = "LAD_FEC_GRAB"
				public shared LAD_ESTADO As string = "LAD_ESTADO"
				public shared LAD_CANT_VAGON As string = "LAD_CANT_VAGON"
				public shared LAD_PARAM_QUEMA As string = "LAD_PARAM_QUEMA"
		    End Structure
	



    <DataMember()>
    Public Property LAD_ID() As String
        Get
            Return _lAD_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_lAD_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'LAD_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _lAD_ID = value
                OnPropertyChanged("LAD_ID")
            End If
        End Set
    End Property

    Private _lAD_ID As String

    <DataMember()>
    Public Property ART_ID_LADRILLO() As String
        Get
            Return _aRT_ID_LADRILLO
        End Get
        Set(ByVal value As String)
            If Not Equals(_aRT_ID_LADRILLO, value) Then
                ChangeTracker.RecordOriginalValue("ART_ID_LADRILLO", _aRT_ID_LADRILLO)
                If Not IsDeserializing Then
                    If Articulos IsNot Nothing AndAlso Not Equals(Articulos.ART_ID, value) Then
                        Articulos = Nothing
                    End If
                    If Articulos1 IsNot Nothing AndAlso Not Equals(Articulos1.ART_ID, value) Then
                        Articulos1 = Nothing
                    End If
                End If
                _aRT_ID_LADRILLO = value
                OnPropertyChanged("ART_ID_LADRILLO")
            End If
        End Set
    End Property

    Private _aRT_ID_LADRILLO As String

    <DataMember()>
    Public Property LAD_CANT_TABLA() As Nullable(Of Integer)
        Get
            Return _lAD_CANT_TABLA
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_lAD_CANT_TABLA, value) Then
                _lAD_CANT_TABLA = value
                OnPropertyChanged("LAD_CANT_TABLA")
            End If
        End Set
    End Property

    Private _lAD_CANT_TABLA As Nullable(Of Integer)

    <DataMember()>
    Public Property LAD_CANT_CORTE() As Nullable(Of Integer)
        Get
            Return _lAD_CANT_CORTE
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_lAD_CANT_CORTE, value) Then
                _lAD_CANT_CORTE = value
                OnPropertyChanged("LAD_CANT_CORTE")
            End If
        End Set
    End Property

    Private _lAD_CANT_CORTE As Nullable(Of Integer)

    <DataMember()>
    Public Property LAD_TIEMPO_COCCION() As Nullable(Of Decimal)
        Get
            Return _lAD_TIEMPO_COCCION
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_lAD_TIEMPO_COCCION, value) Then
                _lAD_TIEMPO_COCCION = value
                OnPropertyChanged("LAD_TIEMPO_COCCION")
            End If
        End Set
    End Property

    Private _lAD_TIEMPO_COCCION As Nullable(Of Decimal)

    <DataMember()>
    Public Property LAD_TEMP_COCCION() As Nullable(Of Decimal)
        Get
            Return _lAD_TEMP_COCCION
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_lAD_TEMP_COCCION, value) Then
                _lAD_TEMP_COCCION = value
                OnPropertyChanged("LAD_TEMP_COCCION")
            End If
        End Set
    End Property

    Private _lAD_TEMP_COCCION As Nullable(Of Decimal)

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
    Public Property LAD_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _lAD_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_lAD_FEC_GRAB, value) Then
                _lAD_FEC_GRAB = value
                OnPropertyChanged("LAD_FEC_GRAB")
            End If
        End Set
    End Property

    Private _lAD_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property LAD_ESTADO() As Nullable(Of Boolean)
        Get
            Return _lAD_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_lAD_ESTADO, value) Then
                _lAD_ESTADO = value
                OnPropertyChanged("LAD_ESTADO")
            End If
        End Set
    End Property

    Private _lAD_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property LAD_CANT_VAGON() As Nullable(Of Integer)
        Get
            Return _lAD_CANT_VAGON
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_lAD_CANT_VAGON, value) Then
                _lAD_CANT_VAGON = value
                OnPropertyChanged("LAD_CANT_VAGON")
            End If
        End Set
    End Property

    Private _lAD_CANT_VAGON As Nullable(Of Integer)

    <DataMember()>
    Public Property LAD_PARAM_QUEMA() As Nullable(Of Decimal)
        Get
            Return _lAD_PARAM_QUEMA
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_lAD_PARAM_QUEMA, value) Then
                _lAD_PARAM_QUEMA = value
                OnPropertyChanged("LAD_PARAM_QUEMA")
            End If
        End Set
    End Property

    Private _lAD_PARAM_QUEMA As Nullable(Of Decimal)

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
    Public Property Articulos1() As Articulos
        Get
            Return _articulos1
        End Get
        Set(ByVal value As Articulos)
            If _articulos1 IsNot value Then
                Dim previousValue As Articulos = _articulos1
                _articulos1 = value
                FixupArticulos1(previousValue)
                OnNavigationPropertyChanged("Articulos1")
            End If
        End Set
    End Property

    Private _articulos1 As Articulos


    <DataMember()>
    Public Property LadrilloMalecon() As TrackableCollection(Of LadrilloMalecon)
        Get
            If _ladrilloMalecon Is Nothing Then
                _ladrilloMalecon = New TrackableCollection(Of LadrilloMalecon)
                AddHandler _ladrilloMalecon.CollectionChanged, AddressOf FixupLadrilloMalecon
            End If
            Return _ladrilloMalecon
        End Get
        Set(ByVal value As TrackableCollection(Of LadrilloMalecon))
            If Not Object.ReferenceEquals(_ladrilloMalecon, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _ladrilloMalecon IsNot Nothing Then
                    RemoveHandler _ladrilloMalecon.CollectionChanged, AddressOf FixupLadrilloMalecon
                End If
                _ladrilloMalecon = value
                If _ladrilloMalecon IsNot Nothing Then
                    AddHandler _ladrilloMalecon.CollectionChanged, AddressOf FixupLadrilloMalecon
                End If
                OnNavigationPropertyChanged("LadrilloMalecon")
            End If
        End Set
    End Property

    Private _ladrilloMalecon As TrackableCollection(Of LadrilloMalecon)

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
        Articulos1 = Nothing
        LadrilloMalecon.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupArticulos(ByVal previousValue As Articulos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Articulos IsNot Nothing Then
            ART_ID_LADRILLO = Articulos.ART_ID
        ElseIf Not skipKeys Then
            ART_ID_LADRILLO = Nothing
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

    Private Sub FixupArticulos1(ByVal previousValue As Articulos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Articulos1 IsNot Nothing Then
            ART_ID_LADRILLO = Articulos1.ART_ID
        ElseIf Not skipKeys Then
            ART_ID_LADRILLO = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Articulos1") AndAlso
                ChangeTracker.OriginalValues("Articulos1") Is Articulos1 Then
                ChangeTracker.OriginalValues.Remove("Articulos1")
            Else
                ChangeTracker.RecordOriginalValue("Articulos1", previousValue)
            End If
            If Articulos1 IsNot Nothing AndAlso Not Articulos1.ChangeTracker.ChangeTrackingEnabled Then
                Articulos1.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupLadrilloMalecon(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As LadrilloMalecon In e.NewItems
                item.Ladrillo = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("LadrilloMalecon", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As LadrilloMalecon In e.OldItems
                If ReferenceEquals(item.Ladrillo, Me) Then
                    item.Ladrillo = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("LadrilloMalecon", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
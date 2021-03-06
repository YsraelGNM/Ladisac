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
<KnownType(GetType(MaleconPuerta))>
<KnownType(GetType(PlanCargaDescargaHorno))>
Partial Public Class PuertaHorno
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared PUE_ID As string = "PUE_ID"
				public shared HOR_ID As string = "HOR_ID"
				public shared PUE_DESCRIPCION As string = "PUE_DESCRIPCION"
				public shared PUE_DES_CORTA As string = "PUE_DES_CORTA"
				public shared USU_ID As string = "USU_ID"
				public shared PUE_FEC_GRAB As string = "PUE_FEC_GRAB"
				public shared PUE_ESTADO As string = "PUE_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property PUE_ID() As Integer
        Get
            Return _pUE_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_pUE_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PUE_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pUE_ID = value
                OnPropertyChanged("PUE_ID")
            End If
        End Set
    End Property

    Private _pUE_ID As Integer

    <DataMember()>
    Public Property HOR_ID() As Nullable(Of Integer)
        Get
            Return _hOR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_hOR_ID, value) Then
                ChangeTracker.RecordOriginalValue("HOR_ID", _hOR_ID)
                _hOR_ID = value
                OnPropertyChanged("HOR_ID")
            End If
        End Set
    End Property

    Private _hOR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property PUE_DESCRIPCION() As String
        Get
            Return _pUE_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_pUE_DESCRIPCION, value) Then
                _pUE_DESCRIPCION = value
                OnPropertyChanged("PUE_DESCRIPCION")
            End If
        End Set
    End Property

    Private _pUE_DESCRIPCION As String

    <DataMember()>
    Public Property PUE_DES_CORTA() As String
        Get
            Return _pUE_DES_CORTA
        End Get
        Set(ByVal value As String)
            If Not Equals(_pUE_DES_CORTA, value) Then
                _pUE_DES_CORTA = value
                OnPropertyChanged("PUE_DES_CORTA")
            End If
        End Set
    End Property

    Private _pUE_DES_CORTA As String

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
    Public Property PUE_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _pUE_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_pUE_FEC_GRAB, value) Then
                _pUE_FEC_GRAB = value
                OnPropertyChanged("PUE_FEC_GRAB")
            End If
        End Set
    End Property

    Private _pUE_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property PUE_ESTADO() As Nullable(Of Boolean)
        Get
            Return _pUE_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_pUE_ESTADO, value) Then
                _pUE_ESTADO = value
                OnPropertyChanged("PUE_ESTADO")
            End If
        End Set
    End Property

    Private _pUE_ESTADO As Nullable(Of Boolean)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property MaleconPuerta() As TrackableCollection(Of MaleconPuerta)
        Get
            If _maleconPuerta Is Nothing Then
                _maleconPuerta = New TrackableCollection(Of MaleconPuerta)
                AddHandler _maleconPuerta.CollectionChanged, AddressOf FixupMaleconPuerta
            End If
            Return _maleconPuerta
        End Get
        Set(ByVal value As TrackableCollection(Of MaleconPuerta))
            If Not Object.ReferenceEquals(_maleconPuerta, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _maleconPuerta IsNot Nothing Then
                    RemoveHandler _maleconPuerta.CollectionChanged, AddressOf FixupMaleconPuerta
                End If
                _maleconPuerta = value
                If _maleconPuerta IsNot Nothing Then
                    AddHandler _maleconPuerta.CollectionChanged, AddressOf FixupMaleconPuerta
                End If
                OnNavigationPropertyChanged("MaleconPuerta")
            End If
        End Set
    End Property

    Private _maleconPuerta As TrackableCollection(Of MaleconPuerta)

    <DataMember()>
    Public Property PlanCargaDescargaHorno() As TrackableCollection(Of PlanCargaDescargaHorno)
        Get
            If _planCargaDescargaHorno Is Nothing Then
                _planCargaDescargaHorno = New TrackableCollection(Of PlanCargaDescargaHorno)
                AddHandler _planCargaDescargaHorno.CollectionChanged, AddressOf FixupPlanCargaDescargaHorno
            End If
            Return _planCargaDescargaHorno
        End Get
        Set(ByVal value As TrackableCollection(Of PlanCargaDescargaHorno))
            If Not Object.ReferenceEquals(_planCargaDescargaHorno, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _planCargaDescargaHorno IsNot Nothing Then
                    RemoveHandler _planCargaDescargaHorno.CollectionChanged, AddressOf FixupPlanCargaDescargaHorno
                End If
                _planCargaDescargaHorno = value
                If _planCargaDescargaHorno IsNot Nothing Then
                    AddHandler _planCargaDescargaHorno.CollectionChanged, AddressOf FixupPlanCargaDescargaHorno
                End If
                OnNavigationPropertyChanged("PlanCargaDescargaHorno")
            End If
        End Set
    End Property

    Private _planCargaDescargaHorno As TrackableCollection(Of PlanCargaDescargaHorno)

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
        MaleconPuerta.Clear()
        PlanCargaDescargaHorno.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupMaleconPuerta(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As MaleconPuerta In e.NewItems
                item.PUE_ID = PUE_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("MaleconPuerta", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As MaleconPuerta In e.OldItems
                item.PUE_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("MaleconPuerta", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupPlanCargaDescargaHorno(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As PlanCargaDescargaHorno In e.NewItems
                item.PuertaHorno = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("PlanCargaDescargaHorno", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As PlanCargaDescargaHorno In e.OldItems
                If ReferenceEquals(item.PuertaHorno, Me) Then
                    item.PuertaHorno = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("PlanCargaDescargaHorno", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

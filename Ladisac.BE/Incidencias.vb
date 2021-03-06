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
<KnownType(GetType(ActivosFijos))>
<KnownType(GetType(Usuarios))>
Partial Public Class Incidencias
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared INC_ID As string = "INC_ID"
				public shared INC_DESCRIPCION As string = "INC_DESCRIPCION"
				public shared INC_TIPO As string = "INC_TIPO"
				public shared USU_ID As string = "USU_ID"
				public shared INC_FEC_GRAB As string = "INC_FEC_GRAB"
				public shared INC_ESTADO As string = "INC_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property INC_ID() As String
        Get
            Return _iNC_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_iNC_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'INC_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _iNC_ID = value
                OnPropertyChanged("INC_ID")
            End If
        End Set
    End Property

    Private _iNC_ID As String

    <DataMember()>
    Public Property INC_DESCRIPCION() As String
        Get
            Return _iNC_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_iNC_DESCRIPCION, value) Then
                _iNC_DESCRIPCION = value
                OnPropertyChanged("INC_DESCRIPCION")
            End If
        End Set
    End Property

    Private _iNC_DESCRIPCION As String

    <DataMember()>
    Public Property INC_TIPO() As Short
        Get
            Return _iNC_TIPO
        End Get
        Set(ByVal value As Short)
            If Not Equals(_iNC_TIPO, value) Then
                _iNC_TIPO = value
                OnPropertyChanged("INC_TIPO")
            End If
        End Set
    End Property

    Private _iNC_TIPO As Short

    <DataMember()>
    Public Property USU_ID() As String
        Get
            Return _uSU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID, value) Then
                ChangeTracker.RecordOriginalValue("USU_ID", _uSU_ID)
                If Not IsDeserializing Then
                    If Usuarios IsNot Nothing AndAlso Not Equals(Usuarios.USU_ID, value) Then
                        Usuarios = Nothing
                    End If
                End If
                _uSU_ID = value
                OnPropertyChanged("USU_ID")
            End If
        End Set
    End Property

    Private _uSU_ID As String

    <DataMember()>
    Public Property INC_FEC_GRAB() As Date
        Get
            Return _iNC_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_iNC_FEC_GRAB, value) Then
                _iNC_FEC_GRAB = value
                OnPropertyChanged("INC_FEC_GRAB")
            End If
        End Set
    End Property

    Private _iNC_FEC_GRAB As Date

    <DataMember()>
    Public Property INC_ESTADO() As Boolean
        Get
            Return _iNC_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_iNC_ESTADO, value) Then
                _iNC_ESTADO = value
                OnPropertyChanged("INC_ESTADO")
            End If
        End Set
    End Property

    Private _iNC_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property ActivosFijos() As TrackableCollection(Of ActivosFijos)
        Get
            If _activosFijos Is Nothing Then
                _activosFijos = New TrackableCollection(Of ActivosFijos)
                AddHandler _activosFijos.CollectionChanged, AddressOf FixupActivosFijos
            End If
            Return _activosFijos
        End Get
        Set(ByVal value As TrackableCollection(Of ActivosFijos))
            If Not Object.ReferenceEquals(_activosFijos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _activosFijos IsNot Nothing Then
                    RemoveHandler _activosFijos.CollectionChanged, AddressOf FixupActivosFijos
                End If
                _activosFijos = value
                If _activosFijos IsNot Nothing Then
                    AddHandler _activosFijos.CollectionChanged, AddressOf FixupActivosFijos
                End If
                OnNavigationPropertyChanged("ActivosFijos")
            End If
        End Set
    End Property

    Private _activosFijos As TrackableCollection(Of ActivosFijos)

    <DataMember()>
    Public Property Usuarios() As Usuarios
        Get
            Return _usuarios
        End Get
        Set(ByVal value As Usuarios)
            If _usuarios IsNot value Then
                Dim previousValue As Usuarios = _usuarios
                _usuarios = value
                FixupUsuarios(previousValue)
                OnNavigationPropertyChanged("Usuarios")
            End If
        End Set
    End Property

    Private _usuarios As Usuarios


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
        ActivosFijos.Clear()
        Usuarios = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupUsuarios(ByVal previousValue As Usuarios)
        If IsDeserializing Then
            Return
        End If

        If Usuarios IsNot Nothing Then
            USU_ID = Usuarios.USU_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Usuarios") AndAlso
                ChangeTracker.OriginalValues("Usuarios") Is Usuarios Then
                ChangeTracker.OriginalValues.Remove("Usuarios")
            Else
                ChangeTracker.RecordOriginalValue("Usuarios", previousValue)
            End If
            If Usuarios IsNot Nothing AndAlso Not Usuarios.ChangeTracker.ChangeTrackingEnabled Then
                Usuarios.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupActivosFijos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ActivosFijos In e.NewItems
                item.Incidencias = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("ActivosFijos", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As ActivosFijos In e.OldItems
                If ReferenceEquals(item.Incidencias, Me) Then
                    item.Incidencias = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ActivosFijos", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

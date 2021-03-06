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
<KnownType(GetType(RolAlmacenTipoArticulos))>
<KnownType(GetType(RolArticulosTipoArticulos))>
<KnownType(GetType(RolDetalleTipoDocumentoTipoArticulos))>
<KnownType(GetType(Usuarios))>
Partial Public Class TipoArticulos
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared TIP_ID As string = "TIP_ID"
				public shared TIP_DESCRIPCION As string = "TIP_DESCRIPCION"
				public shared USU_ID As string = "USU_ID"
				public shared TIP_FEC_GRAB As string = "TIP_FEC_GRAB"
				public shared TIP_ESTADO As string = "TIP_ESTADO"
				public shared TIP_CONTROL As string = "TIP_CONTROL"
		    End Structure
	



    <DataMember()>
    Public Property TIP_ID() As String
        Get
            Return _tIP_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tIP_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'TIP_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _tIP_ID = value
                OnPropertyChanged("TIP_ID")
            End If
        End Set
    End Property

    Private _tIP_ID As String

    <DataMember()>
    Public Property TIP_DESCRIPCION() As String
        Get
            Return _tIP_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_tIP_DESCRIPCION, value) Then
                _tIP_DESCRIPCION = value
                OnPropertyChanged("TIP_DESCRIPCION")
            End If
        End Set
    End Property

    Private _tIP_DESCRIPCION As String

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
    Public Property TIP_FEC_GRAB() As Date
        Get
            Return _tIP_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_tIP_FEC_GRAB, value) Then
                _tIP_FEC_GRAB = value
                OnPropertyChanged("TIP_FEC_GRAB")
            End If
        End Set
    End Property

    Private _tIP_FEC_GRAB As Date

    <DataMember()>
    Public Property TIP_ESTADO() As Boolean
        Get
            Return _tIP_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tIP_ESTADO, value) Then
                _tIP_ESTADO = value
                OnPropertyChanged("TIP_ESTADO")
            End If
        End Set
    End Property

    Private _tIP_ESTADO As Boolean

    <DataMember()>
    Public Property TIP_CONTROL() As Boolean
        Get
            Return _tIP_CONTROL
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tIP_CONTROL, value) Then
                _tIP_CONTROL = value
                OnPropertyChanged("TIP_CONTROL")
            End If
        End Set
    End Property

    Private _tIP_CONTROL As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property RolAlmacenTipoArticulos() As TrackableCollection(Of RolAlmacenTipoArticulos)
        Get
            If _rolAlmacenTipoArticulos Is Nothing Then
                _rolAlmacenTipoArticulos = New TrackableCollection(Of RolAlmacenTipoArticulos)
                AddHandler _rolAlmacenTipoArticulos.CollectionChanged, AddressOf FixupRolAlmacenTipoArticulos
            End If
            Return _rolAlmacenTipoArticulos
        End Get
        Set(ByVal value As TrackableCollection(Of RolAlmacenTipoArticulos))
            If Not Object.ReferenceEquals(_rolAlmacenTipoArticulos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _rolAlmacenTipoArticulos IsNot Nothing Then
                    RemoveHandler _rolAlmacenTipoArticulos.CollectionChanged, AddressOf FixupRolAlmacenTipoArticulos
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As RolAlmacenTipoArticulos In _rolAlmacenTipoArticulos
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _rolAlmacenTipoArticulos = value
                If _rolAlmacenTipoArticulos IsNot Nothing Then
                    AddHandler _rolAlmacenTipoArticulos.CollectionChanged, AddressOf FixupRolAlmacenTipoArticulos
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As RolAlmacenTipoArticulos In _rolAlmacenTipoArticulos
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("RolAlmacenTipoArticulos")
            End If
        End Set
    End Property

    Private _rolAlmacenTipoArticulos As TrackableCollection(Of RolAlmacenTipoArticulos)

    <DataMember()>
    Public Property RolArticulosTipoArticulos() As TrackableCollection(Of RolArticulosTipoArticulos)
        Get
            If _rolArticulosTipoArticulos Is Nothing Then
                _rolArticulosTipoArticulos = New TrackableCollection(Of RolArticulosTipoArticulos)
                AddHandler _rolArticulosTipoArticulos.CollectionChanged, AddressOf FixupRolArticulosTipoArticulos
            End If
            Return _rolArticulosTipoArticulos
        End Get
        Set(ByVal value As TrackableCollection(Of RolArticulosTipoArticulos))
            If Not Object.ReferenceEquals(_rolArticulosTipoArticulos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _rolArticulosTipoArticulos IsNot Nothing Then
                    RemoveHandler _rolArticulosTipoArticulos.CollectionChanged, AddressOf FixupRolArticulosTipoArticulos
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As RolArticulosTipoArticulos In _rolArticulosTipoArticulos
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _rolArticulosTipoArticulos = value
                If _rolArticulosTipoArticulos IsNot Nothing Then
                    AddHandler _rolArticulosTipoArticulos.CollectionChanged, AddressOf FixupRolArticulosTipoArticulos
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As RolArticulosTipoArticulos In _rolArticulosTipoArticulos
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("RolArticulosTipoArticulos")
            End If
        End Set
    End Property

    Private _rolArticulosTipoArticulos As TrackableCollection(Of RolArticulosTipoArticulos)

    <DataMember()>
    Public Property RolDetalleTipoDocumentoTipoArticulos() As TrackableCollection(Of RolDetalleTipoDocumentoTipoArticulos)
        Get
            If _rolDetalleTipoDocumentoTipoArticulos Is Nothing Then
                _rolDetalleTipoDocumentoTipoArticulos = New TrackableCollection(Of RolDetalleTipoDocumentoTipoArticulos)
                AddHandler _rolDetalleTipoDocumentoTipoArticulos.CollectionChanged, AddressOf FixupRolDetalleTipoDocumentoTipoArticulos
            End If
            Return _rolDetalleTipoDocumentoTipoArticulos
        End Get
        Set(ByVal value As TrackableCollection(Of RolDetalleTipoDocumentoTipoArticulos))
            If Not Object.ReferenceEquals(_rolDetalleTipoDocumentoTipoArticulos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _rolDetalleTipoDocumentoTipoArticulos IsNot Nothing Then
                    RemoveHandler _rolDetalleTipoDocumentoTipoArticulos.CollectionChanged, AddressOf FixupRolDetalleTipoDocumentoTipoArticulos
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As RolDetalleTipoDocumentoTipoArticulos In _rolDetalleTipoDocumentoTipoArticulos
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _rolDetalleTipoDocumentoTipoArticulos = value
                If _rolDetalleTipoDocumentoTipoArticulos IsNot Nothing Then
                    AddHandler _rolDetalleTipoDocumentoTipoArticulos.CollectionChanged, AddressOf FixupRolDetalleTipoDocumentoTipoArticulos
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As RolDetalleTipoDocumentoTipoArticulos In _rolDetalleTipoDocumentoTipoArticulos
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("RolDetalleTipoDocumentoTipoArticulos")
            End If
        End Set
    End Property

    Private _rolDetalleTipoDocumentoTipoArticulos As TrackableCollection(Of RolDetalleTipoDocumentoTipoArticulos)

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
        RolAlmacenTipoArticulos.Clear()
        RolArticulosTipoArticulos.Clear()
        RolDetalleTipoDocumentoTipoArticulos.Clear()
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

    Private Sub FixupRolAlmacenTipoArticulos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As RolAlmacenTipoArticulos In e.NewItems
                item.TipoArticulos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("RolAlmacenTipoArticulos", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As RolAlmacenTipoArticulos In e.OldItems
                If ReferenceEquals(item.TipoArticulos, Me) Then
                    item.TipoArticulos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("RolAlmacenTipoArticulos", item)
                    ' Eliminar el extremo dependiente de esta asociación de identificación. Si el estado actual es agregado,
                    ' permite que la relación se modifique sin eliminar el elemento dependiente.
                    If item.ChangeTracker.State <> ObjectState.Added Then
                        item.MarkAsDeleted()
                    End If
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Quitar el extremo dependiente anterior de la escucha de eventos.
                RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If
    End Sub

    Private Sub FixupRolArticulosTipoArticulos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As RolArticulosTipoArticulos In e.NewItems
                item.TipoArticulos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("RolArticulosTipoArticulos", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As RolArticulosTipoArticulos In e.OldItems
                If ReferenceEquals(item.TipoArticulos, Me) Then
                    item.TipoArticulos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("RolArticulosTipoArticulos", item)
                    ' Eliminar el extremo dependiente de esta asociación de identificación. Si el estado actual es agregado,
                    ' permite que la relación se modifique sin eliminar el elemento dependiente.
                    If item.ChangeTracker.State <> ObjectState.Added Then
                        item.MarkAsDeleted()
                    End If
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Quitar el extremo dependiente anterior de la escucha de eventos.
                RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If
    End Sub

    Private Sub FixupRolDetalleTipoDocumentoTipoArticulos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As RolDetalleTipoDocumentoTipoArticulos In e.NewItems
                item.TipoArticulos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("RolDetalleTipoDocumentoTipoArticulos", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As RolDetalleTipoDocumentoTipoArticulos In e.OldItems
                If ReferenceEquals(item.TipoArticulos, Me) Then
                    item.TipoArticulos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("RolDetalleTipoDocumentoTipoArticulos", item)
                    ' Eliminar el extremo dependiente de esta asociación de identificación. Si el estado actual es agregado,
                    ' permite que la relación se modifique sin eliminar el elemento dependiente.
                    If item.ChangeTracker.State <> ObjectState.Added Then
                        item.MarkAsDeleted()
                    End If
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Quitar el extremo dependiente anterior de la escucha de eventos.
                RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If
    End Sub

#End Region
End Class

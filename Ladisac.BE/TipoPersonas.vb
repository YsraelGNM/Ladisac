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
<KnownType(GetType(Comision))>
<KnownType(GetType(RolPersonaTipoPersona))>
<KnownType(GetType(Usuarios))>
Partial Public Class TipoPersonas
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared TPE_ID As string = "TPE_ID"
				public shared COM_ID As string = "COM_ID"
				public shared TPE_DESCRIPCION As string = "TPE_DESCRIPCION"
				public shared TPE_CLIENTE As string = "TPE_CLIENTE"
				public shared TPE_PROVEEDOR As string = "TPE_PROVEEDOR"
				public shared TPE_TRANSPORTISTA As string = "TPE_TRANSPORTISTA"
				public shared TPE_TRABAJADOR As string = "TPE_TRABAJADOR"
				public shared TPE_BANCO As string = "TPE_BANCO"
				public shared TPE_GRUPO As string = "TPE_GRUPO"
				public shared TPE_CONTACTO As string = "TPE_CONTACTO"
				public shared USU_ID As string = "USU_ID"
				public shared TPE_FEC_GRAB As string = "TPE_FEC_GRAB"
				public shared TPE_ESTADO As string = "TPE_ESTADO"
				public shared TPE_CONTROL As string = "TPE_CONTROL"
		    End Structure
	



    <DataMember()>
    Public Property TPE_ID() As String
        Get
            Return _tPE_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tPE_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'TPE_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _tPE_ID = value
                OnPropertyChanged("TPE_ID")
            End If
        End Set
    End Property

    Private _tPE_ID As String

    <DataMember()>
    Public Property COM_ID() As String
        Get
            Return _cOM_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cOM_ID, value) Then
                ChangeTracker.RecordOriginalValue("COM_ID", _cOM_ID)
                If Not IsDeserializing Then
                    If Comision IsNot Nothing AndAlso Not Equals(Comision.COM_ID, value) Then
                        Comision = Nothing
                    End If
                End If
                _cOM_ID = value
                OnPropertyChanged("COM_ID")
            End If
        End Set
    End Property

    Private _cOM_ID As String

    <DataMember()>
    Public Property TPE_DESCRIPCION() As String
        Get
            Return _tPE_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_tPE_DESCRIPCION, value) Then
                _tPE_DESCRIPCION = value
                OnPropertyChanged("TPE_DESCRIPCION")
            End If
        End Set
    End Property

    Private _tPE_DESCRIPCION As String

    <DataMember()>
    Public Property TPE_CLIENTE() As Boolean
        Get
            Return _tPE_CLIENTE
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tPE_CLIENTE, value) Then
                _tPE_CLIENTE = value
                OnPropertyChanged("TPE_CLIENTE")
            End If
        End Set
    End Property

    Private _tPE_CLIENTE As Boolean

    <DataMember()>
    Public Property TPE_PROVEEDOR() As Boolean
        Get
            Return _tPE_PROVEEDOR
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tPE_PROVEEDOR, value) Then
                _tPE_PROVEEDOR = value
                OnPropertyChanged("TPE_PROVEEDOR")
            End If
        End Set
    End Property

    Private _tPE_PROVEEDOR As Boolean

    <DataMember()>
    Public Property TPE_TRANSPORTISTA() As Boolean
        Get
            Return _tPE_TRANSPORTISTA
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tPE_TRANSPORTISTA, value) Then
                _tPE_TRANSPORTISTA = value
                OnPropertyChanged("TPE_TRANSPORTISTA")
            End If
        End Set
    End Property

    Private _tPE_TRANSPORTISTA As Boolean

    <DataMember()>
    Public Property TPE_TRABAJADOR() As Boolean
        Get
            Return _tPE_TRABAJADOR
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tPE_TRABAJADOR, value) Then
                _tPE_TRABAJADOR = value
                OnPropertyChanged("TPE_TRABAJADOR")
            End If
        End Set
    End Property

    Private _tPE_TRABAJADOR As Boolean

    <DataMember()>
    Public Property TPE_BANCO() As Boolean
        Get
            Return _tPE_BANCO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tPE_BANCO, value) Then
                _tPE_BANCO = value
                OnPropertyChanged("TPE_BANCO")
            End If
        End Set
    End Property

    Private _tPE_BANCO As Boolean

    <DataMember()>
    Public Property TPE_GRUPO() As Boolean
        Get
            Return _tPE_GRUPO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tPE_GRUPO, value) Then
                _tPE_GRUPO = value
                OnPropertyChanged("TPE_GRUPO")
            End If
        End Set
    End Property

    Private _tPE_GRUPO As Boolean

    <DataMember()>
    Public Property TPE_CONTACTO() As Boolean
        Get
            Return _tPE_CONTACTO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tPE_CONTACTO, value) Then
                _tPE_CONTACTO = value
                OnPropertyChanged("TPE_CONTACTO")
            End If
        End Set
    End Property

    Private _tPE_CONTACTO As Boolean

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
    Public Property TPE_FEC_GRAB() As Date
        Get
            Return _tPE_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_tPE_FEC_GRAB, value) Then
                _tPE_FEC_GRAB = value
                OnPropertyChanged("TPE_FEC_GRAB")
            End If
        End Set
    End Property

    Private _tPE_FEC_GRAB As Date

    <DataMember()>
    Public Property TPE_ESTADO() As Boolean
        Get
            Return _tPE_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tPE_ESTADO, value) Then
                _tPE_ESTADO = value
                OnPropertyChanged("TPE_ESTADO")
            End If
        End Set
    End Property

    Private _tPE_ESTADO As Boolean

    <DataMember()>
    Public Property TPE_CONTROL() As Boolean
        Get
            Return _tPE_CONTROL
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tPE_CONTROL, value) Then
                _tPE_CONTROL = value
                OnPropertyChanged("TPE_CONTROL")
            End If
        End Set
    End Property

    Private _tPE_CONTROL As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Comision() As Comision
        Get
            Return _comision
        End Get
        Set(ByVal value As Comision)
            If _comision IsNot value Then
                Dim previousValue As Comision = _comision
                _comision = value
                FixupComision(previousValue)
                OnNavigationPropertyChanged("Comision")
            End If
        End Set
    End Property

    Private _comision As Comision


    <DataMember()>
    Public Property RolPersonaTipoPersona() As TrackableCollection(Of RolPersonaTipoPersona)
        Get
            If _rolPersonaTipoPersona Is Nothing Then
                _rolPersonaTipoPersona = New TrackableCollection(Of RolPersonaTipoPersona)
                AddHandler _rolPersonaTipoPersona.CollectionChanged, AddressOf FixupRolPersonaTipoPersona
            End If
            Return _rolPersonaTipoPersona
        End Get
        Set(ByVal value As TrackableCollection(Of RolPersonaTipoPersona))
            If Not Object.ReferenceEquals(_rolPersonaTipoPersona, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _rolPersonaTipoPersona IsNot Nothing Then
                    RemoveHandler _rolPersonaTipoPersona.CollectionChanged, AddressOf FixupRolPersonaTipoPersona
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As RolPersonaTipoPersona In _rolPersonaTipoPersona
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _rolPersonaTipoPersona = value
                If _rolPersonaTipoPersona IsNot Nothing Then
                    AddHandler _rolPersonaTipoPersona.CollectionChanged, AddressOf FixupRolPersonaTipoPersona
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As RolPersonaTipoPersona In _rolPersonaTipoPersona
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("RolPersonaTipoPersona")
            End If
        End Set
    End Property

    Private _rolPersonaTipoPersona As TrackableCollection(Of RolPersonaTipoPersona)

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
        Comision = Nothing
        RolPersonaTipoPersona.Clear()
        Usuarios = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupComision(ByVal previousValue As Comision, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.TipoPersonas.Contains(Me) Then
            previousValue.TipoPersonas.Remove(Me)
        End If

        If Comision IsNot Nothing Then
            If Not Comision.TipoPersonas.Contains(Me) Then
                Comision.TipoPersonas.Add(Me)
            End If

            COM_ID = Comision.COM_ID
        ElseIf Not skipKeys Then
            COM_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Comision") AndAlso
                ChangeTracker.OriginalValues("Comision") Is Comision Then
                ChangeTracker.OriginalValues.Remove("Comision")
            Else
                ChangeTracker.RecordOriginalValue("Comision", previousValue)
            End If
            If Comision IsNot Nothing AndAlso Not Comision.ChangeTracker.ChangeTrackingEnabled Then
                Comision.StartTracking()
            End If
        End If
    End Sub

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

    Private Sub FixupRolPersonaTipoPersona(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As RolPersonaTipoPersona In e.NewItems
                item.TipoPersonas = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("RolPersonaTipoPersona", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As RolPersonaTipoPersona In e.OldItems
                If ReferenceEquals(item.TipoPersonas, Me) Then
                    item.TipoPersonas = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("RolPersonaTipoPersona", item)
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

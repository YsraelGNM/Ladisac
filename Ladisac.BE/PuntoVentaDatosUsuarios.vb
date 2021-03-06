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
<KnownType(GetType(DatosUsuarios))>
<KnownType(GetType(PuntoVenta))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(SeriesDatosUsuarios))>
Partial Public Class PuntoVentaDatosUsuarios
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DAU_ID As string = "DAU_ID"
				public shared PVE_ID As string = "PVE_ID"
				public shared PDU_TIPO_LISTA As string = "PDU_TIPO_LISTA"
				public shared PDU_ENTREGA_PLANTA As string = "PDU_ENTREGA_PLANTA"
				public shared PDU_ENTREGA_PUNTO_VENTA As string = "PDU_ENTREGA_PUNTO_VENTA"
				public shared USU_ID As string = "USU_ID"
				public shared PDU_FEC_GRAB As string = "PDU_FEC_GRAB"
				public shared PDU_ESTADO As string = "PDU_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property DAU_ID() As String
        Get
            Return _dAU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dAU_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DAU_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If DatosUsuarios IsNot Nothing AndAlso Not Equals(DatosUsuarios.DAU_ID, value) Then
                        DatosUsuarios = Nothing
                    End If
                End If
                _dAU_ID = value
                OnPropertyChanged("DAU_ID")
            End If
        End Set
    End Property

    Private _dAU_ID As String

    <DataMember()>
    Public Property PVE_ID() As String
        Get
            Return _pVE_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pVE_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PVE_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If PuntoVenta IsNot Nothing AndAlso Not Equals(PuntoVenta.PVE_ID, value) Then
                        PuntoVenta = Nothing
                    End If
                End If
                _pVE_ID = value
                OnPropertyChanged("PVE_ID")
            End If
        End Set
    End Property

    Private _pVE_ID As String

    <DataMember()>
    Public Property PDU_TIPO_LISTA() As Short
        Get
            Return _pDU_TIPO_LISTA
        End Get
        Set(ByVal value As Short)
            If Not Equals(_pDU_TIPO_LISTA, value) Then
                _pDU_TIPO_LISTA = value
                OnPropertyChanged("PDU_TIPO_LISTA")
            End If
        End Set
    End Property

    Private _pDU_TIPO_LISTA As Short

    <DataMember()>
    Public Property PDU_ENTREGA_PLANTA() As Short
        Get
            Return _pDU_ENTREGA_PLANTA
        End Get
        Set(ByVal value As Short)
            If Not Equals(_pDU_ENTREGA_PLANTA, value) Then
                _pDU_ENTREGA_PLANTA = value
                OnPropertyChanged("PDU_ENTREGA_PLANTA")
            End If
        End Set
    End Property

    Private _pDU_ENTREGA_PLANTA As Short

    <DataMember()>
    Public Property PDU_ENTREGA_PUNTO_VENTA() As Short
        Get
            Return _pDU_ENTREGA_PUNTO_VENTA
        End Get
        Set(ByVal value As Short)
            If Not Equals(_pDU_ENTREGA_PUNTO_VENTA, value) Then
                _pDU_ENTREGA_PUNTO_VENTA = value
                OnPropertyChanged("PDU_ENTREGA_PUNTO_VENTA")
            End If
        End Set
    End Property

    Private _pDU_ENTREGA_PUNTO_VENTA As Short

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
    Public Property PDU_FEC_GRAB() As Date
        Get
            Return _pDU_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_pDU_FEC_GRAB, value) Then
                _pDU_FEC_GRAB = value
                OnPropertyChanged("PDU_FEC_GRAB")
            End If
        End Set
    End Property

    Private _pDU_FEC_GRAB As Date

    <DataMember()>
    Public Property PDU_ESTADO() As Boolean
        Get
            Return _pDU_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_pDU_ESTADO, value) Then
                _pDU_ESTADO = value
                OnPropertyChanged("PDU_ESTADO")
            End If
        End Set
    End Property

    Private _pDU_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DatosUsuarios() As DatosUsuarios
        Get
            Return _datosUsuarios
        End Get
        Set(ByVal value As DatosUsuarios)
            If _datosUsuarios IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(DAU_ID, value.DAU_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As DatosUsuarios = _datosUsuarios
                _datosUsuarios = value
                FixupDatosUsuarios(previousValue)
                OnNavigationPropertyChanged("DatosUsuarios")
            End If
        End Set
    End Property

    Private _datosUsuarios As DatosUsuarios


    <DataMember()>
    Public Property PuntoVenta() As PuntoVenta
        Get
            Return _puntoVenta
        End Get
        Set(ByVal value As PuntoVenta)
            If _puntoVenta IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(PVE_ID, value.PVE_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As PuntoVenta = _puntoVenta
                _puntoVenta = value
                FixupPuntoVenta(previousValue)
                OnNavigationPropertyChanged("PuntoVenta")
            End If
        End Set
    End Property

    Private _puntoVenta As PuntoVenta


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


    <DataMember()>
    Public Property SeriesDatosUsuarios() As TrackableCollection(Of SeriesDatosUsuarios)
        Get
            If _seriesDatosUsuarios Is Nothing Then
                _seriesDatosUsuarios = New TrackableCollection(Of SeriesDatosUsuarios)
                AddHandler _seriesDatosUsuarios.CollectionChanged, AddressOf FixupSeriesDatosUsuarios
            End If
            Return _seriesDatosUsuarios
        End Get
        Set(ByVal value As TrackableCollection(Of SeriesDatosUsuarios))
            If Not Object.ReferenceEquals(_seriesDatosUsuarios, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _seriesDatosUsuarios IsNot Nothing Then
                    RemoveHandler _seriesDatosUsuarios.CollectionChanged, AddressOf FixupSeriesDatosUsuarios
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As SeriesDatosUsuarios In _seriesDatosUsuarios
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _seriesDatosUsuarios = value
                If _seriesDatosUsuarios IsNot Nothing Then
                    AddHandler _seriesDatosUsuarios.CollectionChanged, AddressOf FixupSeriesDatosUsuarios
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As SeriesDatosUsuarios In _seriesDatosUsuarios
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("SeriesDatosUsuarios")
            End If
        End Set
    End Property

    Private _seriesDatosUsuarios As TrackableCollection(Of SeriesDatosUsuarios)

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

    ' Este tipo de entidad es el extremo dependiente en al menos una asociación que realiza eliminaciones en cascada.
    ' Este controlador de eventos procesará notificaciones que tienen lugar cuando se elimina el extremo principal.
    Friend Sub HandleCascadeDelete(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.MarkAsDeleted()
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
        DatosUsuarios = Nothing
        PuntoVenta = Nothing
        Usuarios = Nothing
        SeriesDatosUsuarios.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupDatosUsuarios(ByVal previousValue As DatosUsuarios)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.PuntoVentaDatosUsuarios.Contains(Me) Then
            previousValue.PuntoVentaDatosUsuarios.Remove(Me)
        End If

        If DatosUsuarios IsNot Nothing Then
            If Not DatosUsuarios.PuntoVentaDatosUsuarios.Contains(Me) Then
                DatosUsuarios.PuntoVentaDatosUsuarios.Add(Me)
            End If

            DAU_ID = DatosUsuarios.DAU_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("DatosUsuarios") AndAlso
                ChangeTracker.OriginalValues("DatosUsuarios") Is DatosUsuarios Then
                ChangeTracker.OriginalValues.Remove("DatosUsuarios")
            Else
                ChangeTracker.RecordOriginalValue("DatosUsuarios", previousValue)
            End If
            If DatosUsuarios IsNot Nothing AndAlso Not DatosUsuarios.ChangeTracker.ChangeTrackingEnabled Then
                DatosUsuarios.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupPuntoVenta(ByVal previousValue As PuntoVenta)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.PuntoVentaDatosUsuarios.Contains(Me) Then
            previousValue.PuntoVentaDatosUsuarios.Remove(Me)
        End If

        If PuntoVenta IsNot Nothing Then
            If Not PuntoVenta.PuntoVentaDatosUsuarios.Contains(Me) Then
                PuntoVenta.PuntoVentaDatosUsuarios.Add(Me)
            End If

            PVE_ID = PuntoVenta.PVE_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("PuntoVenta") AndAlso
                ChangeTracker.OriginalValues("PuntoVenta") Is PuntoVenta Then
                ChangeTracker.OriginalValues.Remove("PuntoVenta")
            Else
                ChangeTracker.RecordOriginalValue("PuntoVenta", previousValue)
            End If
            If PuntoVenta IsNot Nothing AndAlso Not PuntoVenta.ChangeTracker.ChangeTrackingEnabled Then
                PuntoVenta.StartTracking()
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

    Private Sub FixupSeriesDatosUsuarios(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As SeriesDatosUsuarios In e.NewItems
                item.PuntoVentaDatosUsuarios = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("SeriesDatosUsuarios", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As SeriesDatosUsuarios In e.OldItems
                If ReferenceEquals(item.PuntoVentaDatosUsuarios, Me) Then
                    item.PuntoVentaDatosUsuarios = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("SeriesDatosUsuarios", item)
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

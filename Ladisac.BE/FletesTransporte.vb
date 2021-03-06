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
<KnownType(GetType(DetalleFletesTransporte))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(Moneda))>
<KnownType(GetType(PuntoVenta))>
<KnownType(GetType(Documentos))>
<KnownType(GetType(Despachos))>
Partial Public Class FletesTransporte
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared FLE_ID As string = "FLE_ID"
				public shared FLE_DESCRIPCION As string = "FLE_DESCRIPCION"
				public shared PVE_ID As string = "PVE_ID"
				public shared MON_ID As string = "MON_ID"
				public shared FLE_MONTO_COB As string = "FLE_MONTO_COB"
				public shared FLE_MONTO_PAG As string = "FLE_MONTO_PAG"
				public shared FLE_TIPO As string = "FLE_TIPO"
				public shared USU_ID As string = "USU_ID"
				public shared FLE_FEC_GRAB As string = "FLE_FEC_GRAB"
				public shared FLE_ESTADO As string = "FLE_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property FLE_ID() As String
        Get
            Return _fLE_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_fLE_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'FLE_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _fLE_ID = value
                OnPropertyChanged("FLE_ID")
            End If
        End Set
    End Property

    Private _fLE_ID As String

    <DataMember()>
    Public Property FLE_DESCRIPCION() As String
        Get
            Return _fLE_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_fLE_DESCRIPCION, value) Then
                _fLE_DESCRIPCION = value
                OnPropertyChanged("FLE_DESCRIPCION")
            End If
        End Set
    End Property

    Private _fLE_DESCRIPCION As String

    <DataMember()>
    Public Property PVE_ID() As String
        Get
            Return _pVE_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pVE_ID, value) Then
                ChangeTracker.RecordOriginalValue("PVE_ID", _pVE_ID)
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
    Public Property MON_ID() As String
        Get
            Return _mON_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_mON_ID, value) Then
                ChangeTracker.RecordOriginalValue("MON_ID", _mON_ID)
                If Not IsDeserializing Then
                    If Moneda IsNot Nothing AndAlso Not Equals(Moneda.MON_ID, value) Then
                        Moneda = Nothing
                    End If
                End If
                _mON_ID = value
                OnPropertyChanged("MON_ID")
            End If
        End Set
    End Property

    Private _mON_ID As String

    <DataMember()>
    Public Property FLE_MONTO_COB() As Decimal
        Get
            Return _fLE_MONTO_COB
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_fLE_MONTO_COB, value) Then
                _fLE_MONTO_COB = value
                OnPropertyChanged("FLE_MONTO_COB")
            End If
        End Set
    End Property

    Private _fLE_MONTO_COB As Decimal

    <DataMember()>
    Public Property FLE_MONTO_PAG() As Decimal
        Get
            Return _fLE_MONTO_PAG
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_fLE_MONTO_PAG, value) Then
                _fLE_MONTO_PAG = value
                OnPropertyChanged("FLE_MONTO_PAG")
            End If
        End Set
    End Property

    Private _fLE_MONTO_PAG As Decimal

    <DataMember()>
    Public Property FLE_TIPO() As Short
        Get
            Return _fLE_TIPO
        End Get
        Set(ByVal value As Short)
            If Not Equals(_fLE_TIPO, value) Then
                _fLE_TIPO = value
                OnPropertyChanged("FLE_TIPO")
            End If
        End Set
    End Property

    Private _fLE_TIPO As Short

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
    Public Property FLE_FEC_GRAB() As Date
        Get
            Return _fLE_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_fLE_FEC_GRAB, value) Then
                _fLE_FEC_GRAB = value
                OnPropertyChanged("FLE_FEC_GRAB")
            End If
        End Set
    End Property

    Private _fLE_FEC_GRAB As Date

    <DataMember()>
    Public Property FLE_ESTADO() As Boolean
        Get
            Return _fLE_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_fLE_ESTADO, value) Then
                _fLE_ESTADO = value
                OnPropertyChanged("FLE_ESTADO")
            End If
        End Set
    End Property

    Private _fLE_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DetalleFletesTransporte() As TrackableCollection(Of DetalleFletesTransporte)
        Get
            If _detalleFletesTransporte Is Nothing Then
                _detalleFletesTransporte = New TrackableCollection(Of DetalleFletesTransporte)
                AddHandler _detalleFletesTransporte.CollectionChanged, AddressOf FixupDetalleFletesTransporte
            End If
            Return _detalleFletesTransporte
        End Get
        Set(ByVal value As TrackableCollection(Of DetalleFletesTransporte))
            If Not Object.ReferenceEquals(_detalleFletesTransporte, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detalleFletesTransporte IsNot Nothing Then
                    RemoveHandler _detalleFletesTransporte.CollectionChanged, AddressOf FixupDetalleFletesTransporte
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As DetalleFletesTransporte In _detalleFletesTransporte
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _detalleFletesTransporte = value
                If _detalleFletesTransporte IsNot Nothing Then
                    AddHandler _detalleFletesTransporte.CollectionChanged, AddressOf FixupDetalleFletesTransporte
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As DetalleFletesTransporte In _detalleFletesTransporte
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("DetalleFletesTransporte")
            End If
        End Set
    End Property

    Private _detalleFletesTransporte As TrackableCollection(Of DetalleFletesTransporte)

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
    Public Property Moneda() As Moneda
        Get
            Return _moneda
        End Get
        Set(ByVal value As Moneda)
            If _moneda IsNot value Then
                Dim previousValue As Moneda = _moneda
                _moneda = value
                FixupMoneda(previousValue)
                OnNavigationPropertyChanged("Moneda")
            End If
        End Set
    End Property

    Private _moneda As Moneda


    <DataMember()>
    Public Property PuntoVenta() As PuntoVenta
        Get
            Return _puntoVenta
        End Get
        Set(ByVal value As PuntoVenta)
            If _puntoVenta IsNot value Then
                Dim previousValue As PuntoVenta = _puntoVenta
                _puntoVenta = value
                FixupPuntoVenta(previousValue)
                OnNavigationPropertyChanged("PuntoVenta")
            End If
        End Set
    End Property

    Private _puntoVenta As PuntoVenta


    <DataMember()>
    Public Property Documentos() As TrackableCollection(Of Documentos)
        Get
            If _documentos Is Nothing Then
                _documentos = New TrackableCollection(Of Documentos)
                AddHandler _documentos.CollectionChanged, AddressOf FixupDocumentos
            End If
            Return _documentos
        End Get
        Set(ByVal value As TrackableCollection(Of Documentos))
            If Not Object.ReferenceEquals(_documentos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _documentos IsNot Nothing Then
                    RemoveHandler _documentos.CollectionChanged, AddressOf FixupDocumentos
                End If
                _documentos = value
                If _documentos IsNot Nothing Then
                    AddHandler _documentos.CollectionChanged, AddressOf FixupDocumentos
                End If
                OnNavigationPropertyChanged("Documentos")
            End If
        End Set
    End Property

    Private _documentos As TrackableCollection(Of Documentos)

    <DataMember()>
    Public Property Despachos() As TrackableCollection(Of Despachos)
        Get
            If _despachos Is Nothing Then
                _despachos = New TrackableCollection(Of Despachos)
                AddHandler _despachos.CollectionChanged, AddressOf FixupDespachos
            End If
            Return _despachos
        End Get
        Set(ByVal value As TrackableCollection(Of Despachos))
            If Not Object.ReferenceEquals(_despachos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _despachos IsNot Nothing Then
                    RemoveHandler _despachos.CollectionChanged, AddressOf FixupDespachos
                End If
                _despachos = value
                If _despachos IsNot Nothing Then
                    AddHandler _despachos.CollectionChanged, AddressOf FixupDespachos
                End If
                OnNavigationPropertyChanged("Despachos")
            End If
        End Set
    End Property

    Private _despachos As TrackableCollection(Of Despachos)

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
        DetalleFletesTransporte.Clear()
        Usuarios = Nothing
        Moneda = Nothing
        PuntoVenta = Nothing
        Documentos.Clear()
        Despachos.Clear()
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

    Private Sub FixupMoneda(ByVal previousValue As Moneda)
        If IsDeserializing Then
            Return
        End If

        If Moneda IsNot Nothing Then
            MON_ID = Moneda.MON_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Moneda") AndAlso
                ChangeTracker.OriginalValues("Moneda") Is Moneda Then
                ChangeTracker.OriginalValues.Remove("Moneda")
            Else
                ChangeTracker.RecordOriginalValue("Moneda", previousValue)
            End If
            If Moneda IsNot Nothing AndAlso Not Moneda.ChangeTracker.ChangeTrackingEnabled Then
                Moneda.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupPuntoVenta(ByVal previousValue As PuntoVenta)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.FletesTransporte.Contains(Me) Then
            previousValue.FletesTransporte.Remove(Me)
        End If

        If PuntoVenta IsNot Nothing Then
            If Not PuntoVenta.FletesTransporte.Contains(Me) Then
                PuntoVenta.FletesTransporte.Add(Me)
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

    Private Sub FixupDetalleFletesTransporte(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetalleFletesTransporte In e.NewItems
                item.FletesTransporte = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetalleFletesTransporte", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetalleFletesTransporte In e.OldItems
                If ReferenceEquals(item.FletesTransporte, Me) Then
                    item.FletesTransporte = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetalleFletesTransporte", item)
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

    Private Sub FixupDocumentos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Documentos In e.NewItems
                item.FletesTransporte = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Documentos", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Documentos In e.OldItems
                If ReferenceEquals(item.FletesTransporte, Me) Then
                    item.FletesTransporte = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Documentos", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDespachos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Despachos In e.NewItems
                item.FletesTransporte = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Despachos", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Despachos In e.OldItems
                If ReferenceEquals(item.FletesTransporte, Me) Then
                    item.FletesTransporte = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Despachos", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

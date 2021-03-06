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
<KnownType(GetType(Usuarios))>
<KnownType(GetType(Despachos))>
<KnownType(GetType(ProvisionCompras))>
<KnownType(GetType(DocuMovimiento))>
<KnownType(GetType(CuadroComparativo))>
<KnownType(GetType(DetallePrestamo))>
<KnownType(GetType(CuentaRendirDetalle))>
Partial Public Class Moneda
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared MON_ID As string = "MON_ID"
				public shared MON_DESCRIPCION As string = "MON_DESCRIPCION"
				public shared MON_SIMBOLO As string = "MON_SIMBOLO"
				public shared MON_ORIGEN As string = "MON_ORIGEN"
				public shared USU_ID As string = "USU_ID"
				public shared MON_FEC_GRAB As string = "MON_FEC_GRAB"
				public shared MON_ESTADO As string = "MON_ESTADO"
				public shared MON_CONTROL As string = "MON_CONTROL"
		    End Structure
	



    <DataMember()>
    Public Property MON_ID() As String
        Get
            Return _mON_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_mON_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'MON_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _mON_ID = value
                OnPropertyChanged("MON_ID")
            End If
        End Set
    End Property

    Private _mON_ID As String

    <DataMember()>
    Public Property MON_DESCRIPCION() As String
        Get
            Return _mON_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_mON_DESCRIPCION, value) Then
                _mON_DESCRIPCION = value
                OnPropertyChanged("MON_DESCRIPCION")
            End If
        End Set
    End Property

    Private _mON_DESCRIPCION As String

    <DataMember()>
    Public Property MON_SIMBOLO() As String
        Get
            Return _mON_SIMBOLO
        End Get
        Set(ByVal value As String)
            If Not Equals(_mON_SIMBOLO, value) Then
                _mON_SIMBOLO = value
                OnPropertyChanged("MON_SIMBOLO")
            End If
        End Set
    End Property

    Private _mON_SIMBOLO As String

    <DataMember()>
    Public Property MON_ORIGEN() As Boolean
        Get
            Return _mON_ORIGEN
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_mON_ORIGEN, value) Then
                _mON_ORIGEN = value
                OnPropertyChanged("MON_ORIGEN")
            End If
        End Set
    End Property

    Private _mON_ORIGEN As Boolean

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
    Public Property MON_FEC_GRAB() As Date
        Get
            Return _mON_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_mON_FEC_GRAB, value) Then
                _mON_FEC_GRAB = value
                OnPropertyChanged("MON_FEC_GRAB")
            End If
        End Set
    End Property

    Private _mON_FEC_GRAB As Date

    <DataMember()>
    Public Property MON_ESTADO() As Boolean
        Get
            Return _mON_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_mON_ESTADO, value) Then
                _mON_ESTADO = value
                OnPropertyChanged("MON_ESTADO")
            End If
        End Set
    End Property

    Private _mON_ESTADO As Boolean

    <DataMember()>
    Public Property MON_CONTROL() As Boolean
        Get
            Return _mON_CONTROL
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_mON_CONTROL, value) Then
                _mON_CONTROL = value
                OnPropertyChanged("MON_CONTROL")
            End If
        End Set
    End Property

    Private _mON_CONTROL As Boolean

#End Region
#Region "Propiedades de navegación"

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

    <DataMember()>
    Public Property ProvisionCompras() As TrackableCollection(Of ProvisionCompras)
        Get
            If _provisionCompras Is Nothing Then
                _provisionCompras = New TrackableCollection(Of ProvisionCompras)
                AddHandler _provisionCompras.CollectionChanged, AddressOf FixupProvisionCompras
            End If
            Return _provisionCompras
        End Get
        Set(ByVal value As TrackableCollection(Of ProvisionCompras))
            If Not Object.ReferenceEquals(_provisionCompras, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _provisionCompras IsNot Nothing Then
                    RemoveHandler _provisionCompras.CollectionChanged, AddressOf FixupProvisionCompras
                End If
                _provisionCompras = value
                If _provisionCompras IsNot Nothing Then
                    AddHandler _provisionCompras.CollectionChanged, AddressOf FixupProvisionCompras
                End If
                OnNavigationPropertyChanged("ProvisionCompras")
            End If
        End Set
    End Property

    Private _provisionCompras As TrackableCollection(Of ProvisionCompras)

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

    <DataMember()>
    Public Property CuadroComparativo() As TrackableCollection(Of CuadroComparativo)
        Get
            If _cuadroComparativo Is Nothing Then
                _cuadroComparativo = New TrackableCollection(Of CuadroComparativo)
                AddHandler _cuadroComparativo.CollectionChanged, AddressOf FixupCuadroComparativo
            End If
            Return _cuadroComparativo
        End Get
        Set(ByVal value As TrackableCollection(Of CuadroComparativo))
            If Not Object.ReferenceEquals(_cuadroComparativo, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _cuadroComparativo IsNot Nothing Then
                    RemoveHandler _cuadroComparativo.CollectionChanged, AddressOf FixupCuadroComparativo
                End If
                _cuadroComparativo = value
                If _cuadroComparativo IsNot Nothing Then
                    AddHandler _cuadroComparativo.CollectionChanged, AddressOf FixupCuadroComparativo
                End If
                OnNavigationPropertyChanged("CuadroComparativo")
            End If
        End Set
    End Property

    Private _cuadroComparativo As TrackableCollection(Of CuadroComparativo)

    <DataMember()>
    Public Property DetallePrestamo() As TrackableCollection(Of DetallePrestamo)
        Get
            If _detallePrestamo Is Nothing Then
                _detallePrestamo = New TrackableCollection(Of DetallePrestamo)
                AddHandler _detallePrestamo.CollectionChanged, AddressOf FixupDetallePrestamo
            End If
            Return _detallePrestamo
        End Get
        Set(ByVal value As TrackableCollection(Of DetallePrestamo))
            If Not Object.ReferenceEquals(_detallePrestamo, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detallePrestamo IsNot Nothing Then
                    RemoveHandler _detallePrestamo.CollectionChanged, AddressOf FixupDetallePrestamo
                End If
                _detallePrestamo = value
                If _detallePrestamo IsNot Nothing Then
                    AddHandler _detallePrestamo.CollectionChanged, AddressOf FixupDetallePrestamo
                End If
                OnNavigationPropertyChanged("DetallePrestamo")
            End If
        End Set
    End Property

    Private _detallePrestamo As TrackableCollection(Of DetallePrestamo)

    <DataMember()>
    Public Property CuentaRendirDetalle() As TrackableCollection(Of CuentaRendirDetalle)
        Get
            If _cuentaRendirDetalle Is Nothing Then
                _cuentaRendirDetalle = New TrackableCollection(Of CuentaRendirDetalle)
                AddHandler _cuentaRendirDetalle.CollectionChanged, AddressOf FixupCuentaRendirDetalle
            End If
            Return _cuentaRendirDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of CuentaRendirDetalle))
            If Not Object.ReferenceEquals(_cuentaRendirDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _cuentaRendirDetalle IsNot Nothing Then
                    RemoveHandler _cuentaRendirDetalle.CollectionChanged, AddressOf FixupCuentaRendirDetalle
                End If
                _cuentaRendirDetalle = value
                If _cuentaRendirDetalle IsNot Nothing Then
                    AddHandler _cuentaRendirDetalle.CollectionChanged, AddressOf FixupCuentaRendirDetalle
                End If
                OnNavigationPropertyChanged("CuentaRendirDetalle")
            End If
        End Set
    End Property

    Private _cuentaRendirDetalle As TrackableCollection(Of CuentaRendirDetalle)

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
        Usuarios = Nothing
        Despachos.Clear()
        ProvisionCompras.Clear()
        DocuMovimiento.Clear()
        CuadroComparativo.Clear()
        DetallePrestamo.Clear()
        CuentaRendirDetalle.Clear()
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

    Private Sub FixupDespachos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Despachos In e.NewItems
                item.Moneda = Me
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
                If ReferenceEquals(item.Moneda, Me) Then
                    item.Moneda = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Despachos", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupProvisionCompras(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ProvisionCompras In e.NewItems
                item.Moneda = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("ProvisionCompras", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As ProvisionCompras In e.OldItems
                If ReferenceEquals(item.Moneda, Me) Then
                    item.Moneda = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ProvisionCompras", item)
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
                item.Moneda = Me
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
                If ReferenceEquals(item.Moneda, Me) Then
                    item.Moneda = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupCuadroComparativo(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As CuadroComparativo In e.NewItems
                item.Moneda = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("CuadroComparativo", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As CuadroComparativo In e.OldItems
                If ReferenceEquals(item.Moneda, Me) Then
                    item.Moneda = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("CuadroComparativo", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDetallePrestamo(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetallePrestamo In e.NewItems
                item.Moneda = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetallePrestamo", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetallePrestamo In e.OldItems
                If ReferenceEquals(item.Moneda, Me) Then
                    item.Moneda = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetallePrestamo", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupCuentaRendirDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As CuentaRendirDetalle In e.NewItems
                item.Moneda = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("CuentaRendirDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As CuentaRendirDetalle In e.OldItems
                If ReferenceEquals(item.Moneda, Me) Then
                    item.Moneda = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("CuentaRendirDetalle", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

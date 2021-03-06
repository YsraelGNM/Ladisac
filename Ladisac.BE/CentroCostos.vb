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
<KnownType(GetType(DetalleTesoreria))>
<KnownType(GetType(DatosLaborales))>
<KnownType(GetType(Leasing))>
<KnownType(GetType(PlanillaTrabajador))>
<KnownType(GetType(MovimientoCajaBanco))>
<KnownType(GetType(DetalleProvisionCompras))>
<KnownType(GetType(ProvisionCompras))>
Partial Public Class CentroCostos
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared CCO_ID As string = "CCO_ID"
				public shared CCO_DESCRIPCION As string = "CCO_DESCRIPCION"
				public shared USU_ID As string = "USU_ID"
				public shared CCO_FEC_GRAB As string = "CCO_FEC_GRAB"
				public shared CCO_ESTADO As string = "CCO_ESTADO"
				public shared CCO_CUC_ID As string = "CCO_CUC_ID"
				public shared CCO_NIVEL As string = "CCO_NIVEL"
				public shared CCO_ABREVIATURA As string = "CCO_ABREVIATURA"
		    End Structure
	



    <DataMember()>
    Public Property CCO_ID() As String
        Get
            Return _cCO_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCO_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'CCO_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _cCO_ID = value
                OnPropertyChanged("CCO_ID")
            End If
        End Set
    End Property

    Private _cCO_ID As String

    <DataMember()>
    Public Property CCO_DESCRIPCION() As String
        Get
            Return _cCO_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCO_DESCRIPCION, value) Then
                _cCO_DESCRIPCION = value
                OnPropertyChanged("CCO_DESCRIPCION")
            End If
        End Set
    End Property

    Private _cCO_DESCRIPCION As String

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
    Public Property CCO_FEC_GRAB() As Date
        Get
            Return _cCO_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_cCO_FEC_GRAB, value) Then
                _cCO_FEC_GRAB = value
                OnPropertyChanged("CCO_FEC_GRAB")
            End If
        End Set
    End Property

    Private _cCO_FEC_GRAB As Date

    <DataMember()>
    Public Property CCO_ESTADO() As Boolean
        Get
            Return _cCO_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_cCO_ESTADO, value) Then
                _cCO_ESTADO = value
                OnPropertyChanged("CCO_ESTADO")
            End If
        End Set
    End Property

    Private _cCO_ESTADO As Boolean

    <DataMember()>
    Public Property CCO_CUC_ID() As String
        Get
            Return _cCO_CUC_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCO_CUC_ID, value) Then
                _cCO_CUC_ID = value
                OnPropertyChanged("CCO_CUC_ID")
            End If
        End Set
    End Property

    Private _cCO_CUC_ID As String

    <DataMember()>
    Public Property CCO_NIVEL() As Nullable(Of Decimal)
        Get
            Return _cCO_NIVEL
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_cCO_NIVEL, value) Then
                _cCO_NIVEL = value
                OnPropertyChanged("CCO_NIVEL")
            End If
        End Set
    End Property

    Private _cCO_NIVEL As Nullable(Of Decimal)

    <DataMember()>
    Public Property CCO_ABREVIATURA() As String
        Get
            Return _cCO_ABREVIATURA
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCO_ABREVIATURA, value) Then
                _cCO_ABREVIATURA = value
                OnPropertyChanged("CCO_ABREVIATURA")
            End If
        End Set
    End Property

    Private _cCO_ABREVIATURA As String

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
    Public Property DetalleTesoreria() As TrackableCollection(Of DetalleTesoreria)
        Get
            If _detalleTesoreria Is Nothing Then
                _detalleTesoreria = New TrackableCollection(Of DetalleTesoreria)
                AddHandler _detalleTesoreria.CollectionChanged, AddressOf FixupDetalleTesoreria
            End If
            Return _detalleTesoreria
        End Get
        Set(ByVal value As TrackableCollection(Of DetalleTesoreria))
            If Not Object.ReferenceEquals(_detalleTesoreria, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detalleTesoreria IsNot Nothing Then
                    RemoveHandler _detalleTesoreria.CollectionChanged, AddressOf FixupDetalleTesoreria
                End If
                _detalleTesoreria = value
                If _detalleTesoreria IsNot Nothing Then
                    AddHandler _detalleTesoreria.CollectionChanged, AddressOf FixupDetalleTesoreria
                End If
                OnNavigationPropertyChanged("DetalleTesoreria")
            End If
        End Set
    End Property

    Private _detalleTesoreria As TrackableCollection(Of DetalleTesoreria)

    <DataMember()>
    Public Property DatosLaborales() As TrackableCollection(Of DatosLaborales)
        Get
            If _datosLaborales Is Nothing Then
                _datosLaborales = New TrackableCollection(Of DatosLaborales)
                AddHandler _datosLaborales.CollectionChanged, AddressOf FixupDatosLaborales
            End If
            Return _datosLaborales
        End Get
        Set(ByVal value As TrackableCollection(Of DatosLaborales))
            If Not Object.ReferenceEquals(_datosLaborales, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _datosLaborales IsNot Nothing Then
                    RemoveHandler _datosLaborales.CollectionChanged, AddressOf FixupDatosLaborales
                End If
                _datosLaborales = value
                If _datosLaborales IsNot Nothing Then
                    AddHandler _datosLaborales.CollectionChanged, AddressOf FixupDatosLaborales
                End If
                OnNavigationPropertyChanged("DatosLaborales")
            End If
        End Set
    End Property

    Private _datosLaborales As TrackableCollection(Of DatosLaborales)

    <DataMember()>
    Public Property Leasing() As TrackableCollection(Of Leasing)
        Get
            If _leasing Is Nothing Then
                _leasing = New TrackableCollection(Of Leasing)
                AddHandler _leasing.CollectionChanged, AddressOf FixupLeasing
            End If
            Return _leasing
        End Get
        Set(ByVal value As TrackableCollection(Of Leasing))
            If Not Object.ReferenceEquals(_leasing, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _leasing IsNot Nothing Then
                    RemoveHandler _leasing.CollectionChanged, AddressOf FixupLeasing
                End If
                _leasing = value
                If _leasing IsNot Nothing Then
                    AddHandler _leasing.CollectionChanged, AddressOf FixupLeasing
                End If
                OnNavigationPropertyChanged("Leasing")
            End If
        End Set
    End Property

    Private _leasing As TrackableCollection(Of Leasing)

    <DataMember()>
    Public Property PlanillaTrabajador() As TrackableCollection(Of PlanillaTrabajador)
        Get
            If _planillaTrabajador Is Nothing Then
                _planillaTrabajador = New TrackableCollection(Of PlanillaTrabajador)
                AddHandler _planillaTrabajador.CollectionChanged, AddressOf FixupPlanillaTrabajador
            End If
            Return _planillaTrabajador
        End Get
        Set(ByVal value As TrackableCollection(Of PlanillaTrabajador))
            If Not Object.ReferenceEquals(_planillaTrabajador, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _planillaTrabajador IsNot Nothing Then
                    RemoveHandler _planillaTrabajador.CollectionChanged, AddressOf FixupPlanillaTrabajador
                End If
                _planillaTrabajador = value
                If _planillaTrabajador IsNot Nothing Then
                    AddHandler _planillaTrabajador.CollectionChanged, AddressOf FixupPlanillaTrabajador
                End If
                OnNavigationPropertyChanged("PlanillaTrabajador")
            End If
        End Set
    End Property

    Private _planillaTrabajador As TrackableCollection(Of PlanillaTrabajador)

    <DataMember()>
    Public Property MovimientoCajaBanco() As TrackableCollection(Of MovimientoCajaBanco)
        Get
            If _movimientoCajaBanco Is Nothing Then
                _movimientoCajaBanco = New TrackableCollection(Of MovimientoCajaBanco)
                AddHandler _movimientoCajaBanco.CollectionChanged, AddressOf FixupMovimientoCajaBanco
            End If
            Return _movimientoCajaBanco
        End Get
        Set(ByVal value As TrackableCollection(Of MovimientoCajaBanco))
            If Not Object.ReferenceEquals(_movimientoCajaBanco, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _movimientoCajaBanco IsNot Nothing Then
                    RemoveHandler _movimientoCajaBanco.CollectionChanged, AddressOf FixupMovimientoCajaBanco
                End If
                _movimientoCajaBanco = value
                If _movimientoCajaBanco IsNot Nothing Then
                    AddHandler _movimientoCajaBanco.CollectionChanged, AddressOf FixupMovimientoCajaBanco
                End If
                OnNavigationPropertyChanged("MovimientoCajaBanco")
            End If
        End Set
    End Property

    Private _movimientoCajaBanco As TrackableCollection(Of MovimientoCajaBanco)

    <DataMember()>
    Public Property DetalleProvisionCompras() As TrackableCollection(Of DetalleProvisionCompras)
        Get
            If _detalleProvisionCompras Is Nothing Then
                _detalleProvisionCompras = New TrackableCollection(Of DetalleProvisionCompras)
                AddHandler _detalleProvisionCompras.CollectionChanged, AddressOf FixupDetalleProvisionCompras
            End If
            Return _detalleProvisionCompras
        End Get
        Set(ByVal value As TrackableCollection(Of DetalleProvisionCompras))
            If Not Object.ReferenceEquals(_detalleProvisionCompras, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detalleProvisionCompras IsNot Nothing Then
                    RemoveHandler _detalleProvisionCompras.CollectionChanged, AddressOf FixupDetalleProvisionCompras
                End If
                _detalleProvisionCompras = value
                If _detalleProvisionCompras IsNot Nothing Then
                    AddHandler _detalleProvisionCompras.CollectionChanged, AddressOf FixupDetalleProvisionCompras
                End If
                OnNavigationPropertyChanged("DetalleProvisionCompras")
            End If
        End Set
    End Property

    Private _detalleProvisionCompras As TrackableCollection(Of DetalleProvisionCompras)

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
        DetalleTesoreria.Clear()
        DatosLaborales.Clear()
        Leasing.Clear()
        PlanillaTrabajador.Clear()
        MovimientoCajaBanco.Clear()
        DetalleProvisionCompras.Clear()
        ProvisionCompras.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupActivosFijos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ActivosFijos In e.NewItems
                item.CentroCostos = Me
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
                If ReferenceEquals(item.CentroCostos, Me) Then
                    item.CentroCostos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ActivosFijos", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDetalleTesoreria(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetalleTesoreria In e.NewItems
                item.CentroCostos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetalleTesoreria", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetalleTesoreria In e.OldItems
                If ReferenceEquals(item.CentroCostos, Me) Then
                    item.CentroCostos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetalleTesoreria", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDatosLaborales(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DatosLaborales In e.NewItems
                item.CentroCostos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DatosLaborales", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DatosLaborales In e.OldItems
                If ReferenceEquals(item.CentroCostos, Me) Then
                    item.CentroCostos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DatosLaborales", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupLeasing(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Leasing In e.NewItems
                item.CentroCostos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Leasing", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Leasing In e.OldItems
                If ReferenceEquals(item.CentroCostos, Me) Then
                    item.CentroCostos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Leasing", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupPlanillaTrabajador(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As PlanillaTrabajador In e.NewItems
                item.CentroCostos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("PlanillaTrabajador", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As PlanillaTrabajador In e.OldItems
                If ReferenceEquals(item.CentroCostos, Me) Then
                    item.CentroCostos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("PlanillaTrabajador", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupMovimientoCajaBanco(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As MovimientoCajaBanco In e.NewItems
                item.CentroCostos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("MovimientoCajaBanco", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As MovimientoCajaBanco In e.OldItems
                If ReferenceEquals(item.CentroCostos, Me) Then
                    item.CentroCostos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("MovimientoCajaBanco", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDetalleProvisionCompras(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetalleProvisionCompras In e.NewItems
                item.CentroCostos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetalleProvisionCompras", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetalleProvisionCompras In e.OldItems
                If ReferenceEquals(item.CentroCostos, Me) Then
                    item.CentroCostos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetalleProvisionCompras", item)
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
                item.CentroCostos = Me
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
                If ReferenceEquals(item.CentroCostos, Me) Then
                    item.CentroCostos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ProvisionCompras", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

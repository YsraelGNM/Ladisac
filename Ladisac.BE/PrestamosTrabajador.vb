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
<KnownType(GetType(Moneda))>
<KnownType(GetType(PuntoVenta))>
<KnownType(GetType(DetallePrestamosTrabajador))>
<KnownType(GetType(Personas))>
<KnownType(GetType(RolOpeCtaCte))>
Partial Public Class PrestamosTrabajador
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared prt_SeriePres As string = "prt_SeriePres"
				public shared prt_NumeroPres As string = "prt_NumeroPres"
				public shared prt_Observaciones As string = "prt_Observaciones"
				public shared prt_Importe As string = "prt_Importe"
				public shared prt_Fecha As string = "prt_Fecha"
				public shared per_IdTrab As string = "per_IdTrab"
				public shared per_IdAutoriza As string = "per_IdAutoriza"
				public shared Usu_Id As string = "Usu_Id"
				public shared prt_FecGrab As string = "prt_FecGrab"
				public shared prt_estado As string = "prt_estado"
				public shared CCT_ID As string = "CCT_ID"
				public shared TDO_ID As string = "TDO_ID"
				public shared DTD_ID As string = "DTD_ID"
				public shared mon_id As string = "mon_id"
				public shared pve_Id As string = "pve_Id"
		    End Structure
	



    <DataMember()>
    Public Property prt_SeriePres() As String
        Get
            Return _prt_SeriePres
        End Get
        Set(ByVal value As String)
            If Not Equals(_prt_SeriePres, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'prt_SeriePres' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _prt_SeriePres = value
                OnPropertyChanged("prt_SeriePres")
            End If
        End Set
    End Property

    Private _prt_SeriePres As String

    <DataMember()>
    Public Property prt_NumeroPres() As String
        Get
            Return _prt_NumeroPres
        End Get
        Set(ByVal value As String)
            If Not Equals(_prt_NumeroPres, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'prt_NumeroPres' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _prt_NumeroPres = value
                OnPropertyChanged("prt_NumeroPres")
            End If
        End Set
    End Property

    Private _prt_NumeroPres As String

    <DataMember()>
    Public Property prt_Observaciones() As String
        Get
            Return _prt_Observaciones
        End Get
        Set(ByVal value As String)
            If Not Equals(_prt_Observaciones, value) Then
                _prt_Observaciones = value
                OnPropertyChanged("prt_Observaciones")
            End If
        End Set
    End Property

    Private _prt_Observaciones As String

    <DataMember()>
    Public Property prt_Importe() As Decimal
        Get
            Return _prt_Importe
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_prt_Importe, value) Then
                _prt_Importe = value
                OnPropertyChanged("prt_Importe")
            End If
        End Set
    End Property

    Private _prt_Importe As Decimal

    <DataMember()>
    Public Property prt_Fecha() As Date
        Get
            Return _prt_Fecha
        End Get
        Set(ByVal value As Date)
            If Not Equals(_prt_Fecha, value) Then
                _prt_Fecha = value
                OnPropertyChanged("prt_Fecha")
            End If
        End Set
    End Property

    Private _prt_Fecha As Date

    <DataMember()>
    Public Property per_IdTrab() As String
        Get
            Return _per_IdTrab
        End Get
        Set(ByVal value As String)
            If Not Equals(_per_IdTrab, value) Then
                ChangeTracker.RecordOriginalValue("per_IdTrab", _per_IdTrab)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _per_IdTrab = value
                OnPropertyChanged("per_IdTrab")
            End If
        End Set
    End Property

    Private _per_IdTrab As String

    <DataMember()>
    Public Property per_IdAutoriza() As String
        Get
            Return _per_IdAutoriza
        End Get
        Set(ByVal value As String)
            If Not Equals(_per_IdAutoriza, value) Then
                ChangeTracker.RecordOriginalValue("per_IdAutoriza", _per_IdAutoriza)
                If Not IsDeserializing Then
                    If Personas1 IsNot Nothing AndAlso Not Equals(Personas1.PER_ID, value) Then
                        Personas1 = Nothing
                    End If
                End If
                _per_IdAutoriza = value
                OnPropertyChanged("per_IdAutoriza")
            End If
        End Set
    End Property

    Private _per_IdAutoriza As String

    <DataMember()>
    Public Property Usu_Id() As String
        Get
            Return _usu_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_usu_Id, value) Then
                _usu_Id = value
                OnPropertyChanged("Usu_Id")
            End If
        End Set
    End Property

    Private _usu_Id As String

    <DataMember()>
    Public Property prt_FecGrab() As Date
        Get
            Return _prt_FecGrab
        End Get
        Set(ByVal value As Date)
            If Not Equals(_prt_FecGrab, value) Then
                _prt_FecGrab = value
                OnPropertyChanged("prt_FecGrab")
            End If
        End Set
    End Property

    Private _prt_FecGrab As Date

    <DataMember()>
    Public Property prt_estado() As Boolean
        Get
            Return _prt_estado
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_prt_estado, value) Then
                _prt_estado = value
                OnPropertyChanged("prt_estado")
            End If
        End Set
    End Property

    Private _prt_estado As Boolean

    <DataMember()>
    Public Property CCT_ID() As String
        Get
            Return _cCT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCT_ID, value) Then
                ChangeTracker.RecordOriginalValue("CCT_ID", _cCT_ID)
                If Not IsDeserializing Then
                    If RolOpeCtaCte IsNot Nothing AndAlso Not Equals(RolOpeCtaCte.CCT_ID, value) Then
                        RolOpeCtaCte = Nothing
                    End If
                End If
                _cCT_ID = value
                OnPropertyChanged("CCT_ID")
            End If
        End Set
    End Property

    Private _cCT_ID As String

    <DataMember()>
    Public Property TDO_ID() As String
        Get
            Return _tDO_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDO_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'TDO_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If RolOpeCtaCte IsNot Nothing AndAlso Not Equals(RolOpeCtaCte.TDO_ID, value) Then
                        RolOpeCtaCte = Nothing
                    End If
                End If
                _tDO_ID = value
                OnPropertyChanged("TDO_ID")
            End If
        End Set
    End Property

    Private _tDO_ID As String

    <DataMember()>
    Public Property DTD_ID() As String
        Get
            Return _dTD_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTD_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DTD_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If RolOpeCtaCte IsNot Nothing AndAlso Not Equals(RolOpeCtaCte.DTD_ID, value) Then
                        RolOpeCtaCte = Nothing
                    End If
                End If
                _dTD_ID = value
                OnPropertyChanged("DTD_ID")
            End If
        End Set
    End Property

    Private _dTD_ID As String

    <DataMember()>
    Public Property mon_id() As String
        Get
            Return _mon_id
        End Get
        Set(ByVal value As String)
            If Not Equals(_mon_id, value) Then
                ChangeTracker.RecordOriginalValue("mon_id", _mon_id)
                If Not IsDeserializing Then
                    If Moneda IsNot Nothing AndAlso Not Equals(Moneda.MON_ID, value) Then
                        Moneda = Nothing
                    End If
                End If
                _mon_id = value
                OnPropertyChanged("mon_id")
            End If
        End Set
    End Property

    Private _mon_id As String

    <DataMember()>
    Public Property pve_Id() As String
        Get
            Return _pve_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_pve_Id, value) Then
                ChangeTracker.RecordOriginalValue("pve_Id", _pve_Id)
                If Not IsDeserializing Then
                    If PuntoVenta IsNot Nothing AndAlso Not Equals(PuntoVenta.PVE_ID, value) Then
                        PuntoVenta = Nothing
                    End If
                End If
                _pve_Id = value
                OnPropertyChanged("pve_Id")
            End If
        End Set
    End Property

    Private _pve_Id As String

#End Region
#Region "Propiedades de navegación"

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
    Public Property DetallePrestamosTrabajador() As TrackableCollection(Of DetallePrestamosTrabajador)
        Get
            If _detallePrestamosTrabajador Is Nothing Then
                _detallePrestamosTrabajador = New TrackableCollection(Of DetallePrestamosTrabajador)
                AddHandler _detallePrestamosTrabajador.CollectionChanged, AddressOf FixupDetallePrestamosTrabajador
            End If
            Return _detallePrestamosTrabajador
        End Get
        Set(ByVal value As TrackableCollection(Of DetallePrestamosTrabajador))
            If Not Object.ReferenceEquals(_detallePrestamosTrabajador, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detallePrestamosTrabajador IsNot Nothing Then
                    RemoveHandler _detallePrestamosTrabajador.CollectionChanged, AddressOf FixupDetallePrestamosTrabajador
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As DetallePrestamosTrabajador In _detallePrestamosTrabajador
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _detallePrestamosTrabajador = value
                If _detallePrestamosTrabajador IsNot Nothing Then
                    AddHandler _detallePrestamosTrabajador.CollectionChanged, AddressOf FixupDetallePrestamosTrabajador
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As DetallePrestamosTrabajador In _detallePrestamosTrabajador
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("DetallePrestamosTrabajador")
            End If
        End Set
    End Property

    Private _detallePrestamosTrabajador As TrackableCollection(Of DetallePrestamosTrabajador)

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
    Public Property Personas1() As Personas
        Get
            Return _personas1
        End Get
        Set(ByVal value As Personas)
            If _personas1 IsNot value Then
                Dim previousValue As Personas = _personas1
                _personas1 = value
                FixupPersonas1(previousValue)
                OnNavigationPropertyChanged("Personas1")
            End If
        End Set
    End Property

    Private _personas1 As Personas


    <DataMember()>
    Public Property RolOpeCtaCte() As RolOpeCtaCte
        Get
            Return _rolOpeCtaCte
        End Get
        Set(ByVal value As RolOpeCtaCte)
            If _rolOpeCtaCte IsNot value Then
                Dim previousValue As RolOpeCtaCte = _rolOpeCtaCte
                _rolOpeCtaCte = value
                FixupRolOpeCtaCte(previousValue)
                OnNavigationPropertyChanged("RolOpeCtaCte")
            End If
        End Set
    End Property

    Private _rolOpeCtaCte As RolOpeCtaCte


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
        Moneda = Nothing
        PuntoVenta = Nothing
        DetallePrestamosTrabajador.Clear()
        Personas = Nothing
        Personas1 = Nothing
        RolOpeCtaCte = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupMoneda(ByVal previousValue As Moneda, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Moneda IsNot Nothing Then
            mon_id = Moneda.MON_ID
        ElseIf Not skipKeys Then
            mon_id = Nothing
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

    Private Sub FixupPuntoVenta(ByVal previousValue As PuntoVenta, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.PrestamosTrabajador.Contains(Me) Then
            previousValue.PrestamosTrabajador.Remove(Me)
        End If

        If PuntoVenta IsNot Nothing Then
            If Not PuntoVenta.PrestamosTrabajador.Contains(Me) Then
                PuntoVenta.PrestamosTrabajador.Add(Me)
            End If

            pve_Id = PuntoVenta.PVE_ID
        ElseIf Not skipKeys Then
            pve_Id = Nothing
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

    Private Sub FixupPersonas(ByVal previousValue As Personas)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.PrestamosTrabajador.Contains(Me) Then
            previousValue.PrestamosTrabajador.Remove(Me)
        End If

        If Personas IsNot Nothing Then
            If Not Personas.PrestamosTrabajador.Contains(Me) Then
                Personas.PrestamosTrabajador.Add(Me)
            End If

            per_IdTrab = Personas.PER_ID
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

    Private Sub FixupPersonas1(ByVal previousValue As Personas)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.PrestamosTrabajador1.Contains(Me) Then
            previousValue.PrestamosTrabajador1.Remove(Me)
        End If

        If Personas1 IsNot Nothing Then
            If Not Personas1.PrestamosTrabajador1.Contains(Me) Then
                Personas1.PrestamosTrabajador1.Add(Me)
            End If

            per_IdAutoriza = Personas1.PER_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Personas1") AndAlso
                ChangeTracker.OriginalValues("Personas1") Is Personas1 Then
                ChangeTracker.OriginalValues.Remove("Personas1")
            Else
                ChangeTracker.RecordOriginalValue("Personas1", previousValue)
            End If
            If Personas1 IsNot Nothing AndAlso Not Personas1.ChangeTracker.ChangeTrackingEnabled Then
                Personas1.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupRolOpeCtaCte(ByVal previousValue As RolOpeCtaCte)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.PrestamosTrabajador.Contains(Me) Then
            previousValue.PrestamosTrabajador.Remove(Me)
        End If

        If RolOpeCtaCte IsNot Nothing Then
            If Not RolOpeCtaCte.PrestamosTrabajador.Contains(Me) Then
                RolOpeCtaCte.PrestamosTrabajador.Add(Me)
            End If

            CCT_ID = RolOpeCtaCte.CCT_ID
            TDO_ID = RolOpeCtaCte.TDO_ID
            DTD_ID = RolOpeCtaCte.DTD_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("RolOpeCtaCte") AndAlso
                ChangeTracker.OriginalValues("RolOpeCtaCte") Is RolOpeCtaCte Then
                ChangeTracker.OriginalValues.Remove("RolOpeCtaCte")
            Else
                ChangeTracker.RecordOriginalValue("RolOpeCtaCte", previousValue)
            End If
            If RolOpeCtaCte IsNot Nothing AndAlso Not RolOpeCtaCte.ChangeTracker.ChangeTrackingEnabled Then
                RolOpeCtaCte.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupDetallePrestamosTrabajador(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetallePrestamosTrabajador In e.NewItems
                item.prt_SeriePres = prt_SeriePres
                item.prt_NumeroPres = prt_NumeroPres
                item.TDO_ID = TDO_ID
                item.DTD_ID = DTD_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetallePrestamosTrabajador", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetallePrestamosTrabajador In e.OldItems
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetallePrestamosTrabajador", item)
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

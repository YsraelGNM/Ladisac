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
<KnownType(GetType(Distrito))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(Personas))>
<KnownType(GetType(Documentos))>
<KnownType(GetType(Despachos))>
Partial Public Class DireccionesPersonas
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DIR_ID As string = "DIR_ID"
				public shared PER_ID As string = "PER_ID"
				public shared DIR_DESCRIPCION As string = "DIR_DESCRIPCION"
				public shared DIR_TIPO As string = "DIR_TIPO"
				public shared DIR_REFERENCIA As string = "DIR_REFERENCIA"
				public shared DIS_ID As string = "DIS_ID"
				public shared USU_ID As string = "USU_ID"
				public shared DIR_FEC_GRAB As string = "DIR_FEC_GRAB"
				public shared DIR_ESTADO As string = "DIR_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property DIR_ID() As String
        Get
            Return _dIR_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dIR_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DIR_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dIR_ID = value
                OnPropertyChanged("DIR_ID")
            End If
        End Set
    End Property

    Private _dIR_ID As String

    <DataMember()>
    Public Property PER_ID() As String
        Get
            Return _pER_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID", _pER_ID)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID = value
                OnPropertyChanged("PER_ID")
            End If
        End Set
    End Property

    Private _pER_ID As String

    <DataMember()>
    Public Property DIR_DESCRIPCION() As String
        Get
            Return _dIR_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_dIR_DESCRIPCION, value) Then
                _dIR_DESCRIPCION = value
                OnPropertyChanged("DIR_DESCRIPCION")
            End If
        End Set
    End Property

    Private _dIR_DESCRIPCION As String

    <DataMember()>
    Public Property DIR_TIPO() As Decimal
        Get
            Return _dIR_TIPO
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_dIR_TIPO, value) Then
                _dIR_TIPO = value
                OnPropertyChanged("DIR_TIPO")
            End If
        End Set
    End Property

    Private _dIR_TIPO As Decimal

    <DataMember()>
    Public Property DIR_REFERENCIA() As String
        Get
            Return _dIR_REFERENCIA
        End Get
        Set(ByVal value As String)
            If Not Equals(_dIR_REFERENCIA, value) Then
                _dIR_REFERENCIA = value
                OnPropertyChanged("DIR_REFERENCIA")
            End If
        End Set
    End Property

    Private _dIR_REFERENCIA As String

    <DataMember()>
    Public Property DIS_ID() As String
        Get
            Return _dIS_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dIS_ID, value) Then
                ChangeTracker.RecordOriginalValue("DIS_ID", _dIS_ID)
                If Not IsDeserializing Then
                    If Distrito IsNot Nothing AndAlso Not Equals(Distrito.DIS_ID, value) Then
                        Distrito = Nothing
                    End If
                End If
                _dIS_ID = value
                OnPropertyChanged("DIS_ID")
            End If
        End Set
    End Property

    Private _dIS_ID As String

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
    Public Property DIR_FEC_GRAB() As Date
        Get
            Return _dIR_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dIR_FEC_GRAB, value) Then
                _dIR_FEC_GRAB = value
                OnPropertyChanged("DIR_FEC_GRAB")
            End If
        End Set
    End Property

    Private _dIR_FEC_GRAB As Date

    <DataMember()>
    Public Property DIR_ESTADO() As Boolean
        Get
            Return _dIR_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dIR_ESTADO, value) Then
                _dIR_ESTADO = value
                OnPropertyChanged("DIR_ESTADO")
            End If
        End Set
    End Property

    Private _dIR_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Distrito() As Distrito
        Get
            Return _distrito
        End Get
        Set(ByVal value As Distrito)
            If _distrito IsNot value Then
                Dim previousValue As Distrito = _distrito
                _distrito = value
                FixupDistrito(previousValue)
                OnNavigationPropertyChanged("Distrito")
            End If
        End Set
    End Property

    Private _distrito As Distrito


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
    Public Property Personas1() As TrackableCollection(Of Personas)
        Get
            If _personas1 Is Nothing Then
                _personas1 = New TrackableCollection(Of Personas)
                AddHandler _personas1.CollectionChanged, AddressOf FixupPersonas1
            End If
            Return _personas1
        End Get
        Set(ByVal value As TrackableCollection(Of Personas))
            If Not Object.ReferenceEquals(_personas1, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _personas1 IsNot Nothing Then
                    RemoveHandler _personas1.CollectionChanged, AddressOf FixupPersonas1
                End If
                _personas1 = value
                If _personas1 IsNot Nothing Then
                    AddHandler _personas1.CollectionChanged, AddressOf FixupPersonas1
                End If
                OnNavigationPropertyChanged("Personas1")
            End If
        End Set
    End Property

    Private _personas1 As TrackableCollection(Of Personas)

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
    Public Property Documentos1() As TrackableCollection(Of Documentos)
        Get
            If _documentos1 Is Nothing Then
                _documentos1 = New TrackableCollection(Of Documentos)
                AddHandler _documentos1.CollectionChanged, AddressOf FixupDocumentos1
            End If
            Return _documentos1
        End Get
        Set(ByVal value As TrackableCollection(Of Documentos))
            If Not Object.ReferenceEquals(_documentos1, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _documentos1 IsNot Nothing Then
                    RemoveHandler _documentos1.CollectionChanged, AddressOf FixupDocumentos1
                End If
                _documentos1 = value
                If _documentos1 IsNot Nothing Then
                    AddHandler _documentos1.CollectionChanged, AddressOf FixupDocumentos1
                End If
                OnNavigationPropertyChanged("Documentos1")
            End If
        End Set
    End Property

    Private _documentos1 As TrackableCollection(Of Documentos)

    <DataMember()>
    Public Property Documentos2() As TrackableCollection(Of Documentos)
        Get
            If _documentos2 Is Nothing Then
                _documentos2 = New TrackableCollection(Of Documentos)
                AddHandler _documentos2.CollectionChanged, AddressOf FixupDocumentos2
            End If
            Return _documentos2
        End Get
        Set(ByVal value As TrackableCollection(Of Documentos))
            If Not Object.ReferenceEquals(_documentos2, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _documentos2 IsNot Nothing Then
                    RemoveHandler _documentos2.CollectionChanged, AddressOf FixupDocumentos2
                End If
                _documentos2 = value
                If _documentos2 IsNot Nothing Then
                    AddHandler _documentos2.CollectionChanged, AddressOf FixupDocumentos2
                End If
                OnNavigationPropertyChanged("Documentos2")
            End If
        End Set
    End Property

    Private _documentos2 As TrackableCollection(Of Documentos)

    <DataMember()>
    Public Property Documentos3() As TrackableCollection(Of Documentos)
        Get
            If _documentos3 Is Nothing Then
                _documentos3 = New TrackableCollection(Of Documentos)
                AddHandler _documentos3.CollectionChanged, AddressOf FixupDocumentos3
            End If
            Return _documentos3
        End Get
        Set(ByVal value As TrackableCollection(Of Documentos))
            If Not Object.ReferenceEquals(_documentos3, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _documentos3 IsNot Nothing Then
                    RemoveHandler _documentos3.CollectionChanged, AddressOf FixupDocumentos3
                End If
                _documentos3 = value
                If _documentos3 IsNot Nothing Then
                    AddHandler _documentos3.CollectionChanged, AddressOf FixupDocumentos3
                End If
                OnNavigationPropertyChanged("Documentos3")
            End If
        End Set
    End Property

    Private _documentos3 As TrackableCollection(Of Documentos)

    <DataMember()>
    Public Property Documentos4() As TrackableCollection(Of Documentos)
        Get
            If _documentos4 Is Nothing Then
                _documentos4 = New TrackableCollection(Of Documentos)
                AddHandler _documentos4.CollectionChanged, AddressOf FixupDocumentos4
            End If
            Return _documentos4
        End Get
        Set(ByVal value As TrackableCollection(Of Documentos))
            If Not Object.ReferenceEquals(_documentos4, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _documentos4 IsNot Nothing Then
                    RemoveHandler _documentos4.CollectionChanged, AddressOf FixupDocumentos4
                End If
                _documentos4 = value
                If _documentos4 IsNot Nothing Then
                    AddHandler _documentos4.CollectionChanged, AddressOf FixupDocumentos4
                End If
                OnNavigationPropertyChanged("Documentos4")
            End If
        End Set
    End Property

    Private _documentos4 As TrackableCollection(Of Documentos)

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
    Public Property Despachos1() As TrackableCollection(Of Despachos)
        Get
            If _despachos1 Is Nothing Then
                _despachos1 = New TrackableCollection(Of Despachos)
                AddHandler _despachos1.CollectionChanged, AddressOf FixupDespachos1
            End If
            Return _despachos1
        End Get
        Set(ByVal value As TrackableCollection(Of Despachos))
            If Not Object.ReferenceEquals(_despachos1, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _despachos1 IsNot Nothing Then
                    RemoveHandler _despachos1.CollectionChanged, AddressOf FixupDespachos1
                End If
                _despachos1 = value
                If _despachos1 IsNot Nothing Then
                    AddHandler _despachos1.CollectionChanged, AddressOf FixupDespachos1
                End If
                OnNavigationPropertyChanged("Despachos1")
            End If
        End Set
    End Property

    Private _despachos1 As TrackableCollection(Of Despachos)

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
        Distrito = Nothing
        Usuarios = Nothing
        Personas = Nothing
        Personas1.Clear()
        Documentos.Clear()
        Documentos1.Clear()
        Documentos2.Clear()
        Documentos3.Clear()
        Documentos4.Clear()
        Despachos.Clear()
        Despachos1.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupDistrito(ByVal previousValue As Distrito)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DireccionesPersonas.Contains(Me) Then
            previousValue.DireccionesPersonas.Remove(Me)
        End If

        If Distrito IsNot Nothing Then
            If Not Distrito.DireccionesPersonas.Contains(Me) Then
                Distrito.DireccionesPersonas.Add(Me)
            End If

            DIS_ID = Distrito.DIS_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Distrito") AndAlso
                ChangeTracker.OriginalValues("Distrito") Is Distrito Then
                ChangeTracker.OriginalValues.Remove("Distrito")
            Else
                ChangeTracker.RecordOriginalValue("Distrito", previousValue)
            End If
            If Distrito IsNot Nothing AndAlso Not Distrito.ChangeTracker.ChangeTrackingEnabled Then
                Distrito.StartTracking()
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

    Private Sub FixupPersonas(ByVal previousValue As Personas)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DireccionesPersonas.Contains(Me) Then
            previousValue.DireccionesPersonas.Remove(Me)
        End If

        If Personas IsNot Nothing Then
            If Not Personas.DireccionesPersonas.Contains(Me) Then
                Personas.DireccionesPersonas.Add(Me)
            End If

            PER_ID = Personas.PER_ID
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

    Private Sub FixupPersonas1(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Personas In e.NewItems
                item.DireccionesPersonas1 = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Personas1", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Personas In e.OldItems
                If ReferenceEquals(item.DireccionesPersonas1, Me) Then
                    item.DireccionesPersonas1 = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Personas1", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocumentos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Documentos In e.NewItems
                item.DireccionesPersonas = Me
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
                If ReferenceEquals(item.DireccionesPersonas, Me) Then
                    item.DireccionesPersonas = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Documentos", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocumentos1(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Documentos In e.NewItems
                item.DireccionesPersonas1 = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Documentos1", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Documentos In e.OldItems
                If ReferenceEquals(item.DireccionesPersonas1, Me) Then
                    item.DireccionesPersonas1 = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Documentos1", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocumentos2(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Documentos In e.NewItems
                item.DireccionesPersonas2 = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Documentos2", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Documentos In e.OldItems
                If ReferenceEquals(item.DireccionesPersonas2, Me) Then
                    item.DireccionesPersonas2 = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Documentos2", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocumentos3(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Documentos In e.NewItems
                item.DireccionesPersonas3 = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Documentos3", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Documentos In e.OldItems
                If ReferenceEquals(item.DireccionesPersonas3, Me) Then
                    item.DireccionesPersonas3 = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Documentos3", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocumentos4(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Documentos In e.NewItems
                item.DireccionesPersonas4 = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Documentos4", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Documentos In e.OldItems
                If ReferenceEquals(item.DireccionesPersonas4, Me) Then
                    item.DireccionesPersonas4 = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Documentos4", item)
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
                item.DireccionesPersonas = Me
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
                If ReferenceEquals(item.DireccionesPersonas, Me) Then
                    item.DireccionesPersonas = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Despachos", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDespachos1(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Despachos In e.NewItems
                item.DireccionesPersonas1 = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Despachos1", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Despachos In e.OldItems
                If ReferenceEquals(item.DireccionesPersonas1, Me) Then
                    item.DireccionesPersonas1 = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Despachos1", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
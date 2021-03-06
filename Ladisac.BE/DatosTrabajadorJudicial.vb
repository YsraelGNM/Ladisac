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
<KnownType(GetType(DetalleTrabajadorJudicial))>
<KnownType(GetType(Personas))>
Partial Public Class DatosTrabajadorJudicial
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared per_IdTrab As string = "per_IdTrab"
				public shared dtj_Observaciones As string = "dtj_Observaciones"
				public shared dtj_FechaInici As string = "dtj_FechaInici"
				public shared dtj_Estado As string = "dtj_Estado"
				public shared dtj_SerieJudi As string = "dtj_SerieJudi"
				public shared dtj_NumeroJudi As string = "dtj_NumeroJudi"
				public shared per_IdBeneficiario As string = "per_IdBeneficiario"
				public shared Usu_Id As string = "Usu_Id"
				public shared dtj_FecGrab As string = "dtj_FecGrab"
				public shared dtj_FechaFin As string = "dtj_FechaFin"
		    End Structure
	



    <DataMember()>
    Public Property per_IdTrab() As String
        Get
            Return _per_IdTrab
        End Get
        Set(ByVal value As String)
            If Not Equals(_per_IdTrab, value) Then
                ChangeTracker.RecordOriginalValue("per_IdTrab", _per_IdTrab)
                If Not IsDeserializing Then
                    If Personas1 IsNot Nothing AndAlso Not Equals(Personas1.PER_ID, value) Then
                        Personas1 = Nothing
                    End If
                End If
                _per_IdTrab = value
                OnPropertyChanged("per_IdTrab")
            End If
        End Set
    End Property

    Private _per_IdTrab As String

    <DataMember()>
    Public Property dtj_Observaciones() As String
        Get
            Return _dtj_Observaciones
        End Get
        Set(ByVal value As String)
            If Not Equals(_dtj_Observaciones, value) Then
                _dtj_Observaciones = value
                OnPropertyChanged("dtj_Observaciones")
            End If
        End Set
    End Property

    Private _dtj_Observaciones As String

    <DataMember()>
    Public Property dtj_FechaInici() As Date
        Get
            Return _dtj_FechaInici
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dtj_FechaInici, value) Then
                _dtj_FechaInici = value
                OnPropertyChanged("dtj_FechaInici")
            End If
        End Set
    End Property

    Private _dtj_FechaInici As Date

    <DataMember()>
    Public Property dtj_Estado() As Boolean
        Get
            Return _dtj_Estado
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dtj_Estado, value) Then
                _dtj_Estado = value
                OnPropertyChanged("dtj_Estado")
            End If
        End Set
    End Property

    Private _dtj_Estado As Boolean

    <DataMember()>
    Public Property dtj_SerieJudi() As String
        Get
            Return _dtj_SerieJudi
        End Get
        Set(ByVal value As String)
            If Not Equals(_dtj_SerieJudi, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'dtj_SerieJudi' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dtj_SerieJudi = value
                OnPropertyChanged("dtj_SerieJudi")
            End If
        End Set
    End Property

    Private _dtj_SerieJudi As String

    <DataMember()>
    Public Property dtj_NumeroJudi() As String
        Get
            Return _dtj_NumeroJudi
        End Get
        Set(ByVal value As String)
            If Not Equals(_dtj_NumeroJudi, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'dtj_NumeroJudi' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dtj_NumeroJudi = value
                OnPropertyChanged("dtj_NumeroJudi")
            End If
        End Set
    End Property

    Private _dtj_NumeroJudi As String

    <DataMember()>
    Public Property per_IdBeneficiario() As String
        Get
            Return _per_IdBeneficiario
        End Get
        Set(ByVal value As String)
            If Not Equals(_per_IdBeneficiario, value) Then
                ChangeTracker.RecordOriginalValue("per_IdBeneficiario", _per_IdBeneficiario)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _per_IdBeneficiario = value
                OnPropertyChanged("per_IdBeneficiario")
            End If
        End Set
    End Property

    Private _per_IdBeneficiario As String

    <DataMember()>
    Public Property Usu_Id() As String
        Get
            Return _usu_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_usu_Id, value) Then
                ChangeTracker.RecordOriginalValue("Usu_Id", _usu_Id)
                If Not IsDeserializing Then
                    If Usuarios IsNot Nothing AndAlso Not Equals(Usuarios.USU_ID, value) Then
                        Usuarios = Nothing
                    End If
                End If
                _usu_Id = value
                OnPropertyChanged("Usu_Id")
            End If
        End Set
    End Property

    Private _usu_Id As String

    <DataMember()>
    Public Property dtj_FecGrab() As Date
        Get
            Return _dtj_FecGrab
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dtj_FecGrab, value) Then
                _dtj_FecGrab = value
                OnPropertyChanged("dtj_FecGrab")
            End If
        End Set
    End Property

    Private _dtj_FecGrab As Date

    <DataMember()>
    Public Property dtj_FechaFin() As Date
        Get
            Return _dtj_FechaFin
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dtj_FechaFin, value) Then
                _dtj_FechaFin = value
                OnPropertyChanged("dtj_FechaFin")
            End If
        End Set
    End Property

    Private _dtj_FechaFin As Date

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
    Public Property DetalleTrabajadorJudicial() As TrackableCollection(Of DetalleTrabajadorJudicial)
        Get
            If _detalleTrabajadorJudicial Is Nothing Then
                _detalleTrabajadorJudicial = New TrackableCollection(Of DetalleTrabajadorJudicial)
                AddHandler _detalleTrabajadorJudicial.CollectionChanged, AddressOf FixupDetalleTrabajadorJudicial
            End If
            Return _detalleTrabajadorJudicial
        End Get
        Set(ByVal value As TrackableCollection(Of DetalleTrabajadorJudicial))
            If Not Object.ReferenceEquals(_detalleTrabajadorJudicial, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detalleTrabajadorJudicial IsNot Nothing Then
                    RemoveHandler _detalleTrabajadorJudicial.CollectionChanged, AddressOf FixupDetalleTrabajadorJudicial
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As DetalleTrabajadorJudicial In _detalleTrabajadorJudicial
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _detalleTrabajadorJudicial = value
                If _detalleTrabajadorJudicial IsNot Nothing Then
                    AddHandler _detalleTrabajadorJudicial.CollectionChanged, AddressOf FixupDetalleTrabajadorJudicial
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As DetalleTrabajadorJudicial In _detalleTrabajadorJudicial
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("DetalleTrabajadorJudicial")
            End If
        End Set
    End Property

    Private _detalleTrabajadorJudicial As TrackableCollection(Of DetalleTrabajadorJudicial)

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
        DetalleTrabajadorJudicial.Clear()
        Personas = Nothing
        Personas1 = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupUsuarios(ByVal previousValue As Usuarios)
        If IsDeserializing Then
            Return
        End If

        If Usuarios IsNot Nothing Then
            Usu_Id = Usuarios.USU_ID
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

        If previousValue IsNot Nothing AndAlso previousValue.DatosTrabajadorJudicial.Contains(Me) Then
            previousValue.DatosTrabajadorJudicial.Remove(Me)
        End If

        If Personas IsNot Nothing Then
            If Not Personas.DatosTrabajadorJudicial.Contains(Me) Then
                Personas.DatosTrabajadorJudicial.Add(Me)
            End If

            per_IdBeneficiario = Personas.PER_ID
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

        If previousValue IsNot Nothing AndAlso previousValue.DatosTrabajadorJudicial1.Contains(Me) Then
            previousValue.DatosTrabajadorJudicial1.Remove(Me)
        End If

        If Personas1 IsNot Nothing Then
            If Not Personas1.DatosTrabajadorJudicial1.Contains(Me) Then
                Personas1.DatosTrabajadorJudicial1.Add(Me)
            End If

            per_IdTrab = Personas1.PER_ID
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

    Private Sub FixupDetalleTrabajadorJudicial(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetalleTrabajadorJudicial In e.NewItems
                item.dtj_SerieJudi = dtj_SerieJudi
                item.dtj_NumeroJudi = dtj_NumeroJudi
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetalleTrabajadorJudicial", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetalleTrabajadorJudicial In e.OldItems
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetalleTrabajadorJudicial", item)
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

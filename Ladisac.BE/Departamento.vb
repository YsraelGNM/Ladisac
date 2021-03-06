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
<KnownType(GetType(Pais))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(Provincia))>
Partial Public Class Departamento
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DEP_ID As string = "DEP_ID"
				public shared DEP_DESCRIPCION As string = "DEP_DESCRIPCION"
				public shared PAI_ID As string = "PAI_ID"
				public shared DEP_COD_SUNAT As string = "DEP_COD_SUNAT"
				public shared USU_ID As string = "USU_ID"
				public shared DEP_FEC_GRAB As string = "DEP_FEC_GRAB"
				public shared DEP_ESTADO As string = "DEP_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property DEP_ID() As String
        Get
            Return _dEP_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dEP_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DEP_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dEP_ID = value
                OnPropertyChanged("DEP_ID")
            End If
        End Set
    End Property

    Private _dEP_ID As String

    <DataMember()>
    Public Property DEP_DESCRIPCION() As String
        Get
            Return _dEP_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_dEP_DESCRIPCION, value) Then
                _dEP_DESCRIPCION = value
                OnPropertyChanged("DEP_DESCRIPCION")
            End If
        End Set
    End Property

    Private _dEP_DESCRIPCION As String

    <DataMember()>
    Public Property PAI_ID() As String
        Get
            Return _pAI_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pAI_ID, value) Then
                ChangeTracker.RecordOriginalValue("PAI_ID", _pAI_ID)
                If Not IsDeserializing Then
                    If Pais IsNot Nothing AndAlso Not Equals(Pais.PAI_ID, value) Then
                        Pais = Nothing
                    End If
                End If
                _pAI_ID = value
                OnPropertyChanged("PAI_ID")
            End If
        End Set
    End Property

    Private _pAI_ID As String

    <DataMember()>
    Public Property DEP_COD_SUNAT() As String
        Get
            Return _dEP_COD_SUNAT
        End Get
        Set(ByVal value As String)
            If Not Equals(_dEP_COD_SUNAT, value) Then
                _dEP_COD_SUNAT = value
                OnPropertyChanged("DEP_COD_SUNAT")
            End If
        End Set
    End Property

    Private _dEP_COD_SUNAT As String

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
    Public Property DEP_FEC_GRAB() As Date
        Get
            Return _dEP_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dEP_FEC_GRAB, value) Then
                _dEP_FEC_GRAB = value
                OnPropertyChanged("DEP_FEC_GRAB")
            End If
        End Set
    End Property

    Private _dEP_FEC_GRAB As Date

    <DataMember()>
    Public Property DEP_ESTADO() As Boolean
        Get
            Return _dEP_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dEP_ESTADO, value) Then
                _dEP_ESTADO = value
                OnPropertyChanged("DEP_ESTADO")
            End If
        End Set
    End Property

    Private _dEP_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Pais() As Pais
        Get
            Return _pais
        End Get
        Set(ByVal value As Pais)
            If _pais IsNot value Then
                Dim previousValue As Pais = _pais
                _pais = value
                FixupPais(previousValue)
                OnNavigationPropertyChanged("Pais")
            End If
        End Set
    End Property

    Private _pais As Pais


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
    Public Property Provincia() As TrackableCollection(Of Provincia)
        Get
            If _provincia Is Nothing Then
                _provincia = New TrackableCollection(Of Provincia)
                AddHandler _provincia.CollectionChanged, AddressOf FixupProvincia
            End If
            Return _provincia
        End Get
        Set(ByVal value As TrackableCollection(Of Provincia))
            If Not Object.ReferenceEquals(_provincia, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _provincia IsNot Nothing Then
                    RemoveHandler _provincia.CollectionChanged, AddressOf FixupProvincia
                End If
                _provincia = value
                If _provincia IsNot Nothing Then
                    AddHandler _provincia.CollectionChanged, AddressOf FixupProvincia
                End If
                OnNavigationPropertyChanged("Provincia")
            End If
        End Set
    End Property

    Private _provincia As TrackableCollection(Of Provincia)

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
        Pais = Nothing
        Usuarios = Nothing
        Provincia.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPais(ByVal previousValue As Pais)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Departamento.Contains(Me) Then
            previousValue.Departamento.Remove(Me)
        End If

        If Pais IsNot Nothing Then
            If Not Pais.Departamento.Contains(Me) Then
                Pais.Departamento.Add(Me)
            End If

            PAI_ID = Pais.PAI_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Pais") AndAlso
                ChangeTracker.OriginalValues("Pais") Is Pais Then
                ChangeTracker.OriginalValues.Remove("Pais")
            Else
                ChangeTracker.RecordOriginalValue("Pais", previousValue)
            End If
            If Pais IsNot Nothing AndAlso Not Pais.ChangeTracker.ChangeTrackingEnabled Then
                Pais.StartTracking()
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

    Private Sub FixupProvincia(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Provincia In e.NewItems
                item.Departamento = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Provincia", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Provincia In e.OldItems
                If ReferenceEquals(item.Departamento, Me) Then
                    item.Departamento = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Provincia", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

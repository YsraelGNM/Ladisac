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
<KnownType(GetType(RegistroEquipoDetalle))>
<KnownType(GetType(TipoArea))>
Partial Public Class Area
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared ARE_ID As string = "ARE_ID"
				public shared ARE_DESCRIPCION As string = "ARE_DESCRIPCION"
				public shared USU_ID As string = "USU_ID"
				public shared ARE_FEC_GRAB As string = "ARE_FEC_GRAB"
				public shared ARE_ESTADO As string = "ARE_ESTADO"
				public shared TAR_ID As string = "TAR_ID"
				public shared ARE_ID_PADRE As string = "ARE_ID_PADRE"
				public shared ARE_CODIGO As string = "ARE_CODIGO"
		    End Structure
	



    <DataMember()>
    Public Property ARE_ID() As Integer
        Get
            Return _aRE_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_aRE_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'ARE_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _aRE_ID = value
                OnPropertyChanged("ARE_ID")
            End If
        End Set
    End Property

    Private _aRE_ID As Integer

    <DataMember()>
    Public Property ARE_DESCRIPCION() As String
        Get
            Return _aRE_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_aRE_DESCRIPCION, value) Then
                _aRE_DESCRIPCION = value
                OnPropertyChanged("ARE_DESCRIPCION")
            End If
        End Set
    End Property

    Private _aRE_DESCRIPCION As String

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
    Public Property ARE_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _aRE_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_aRE_FEC_GRAB, value) Then
                _aRE_FEC_GRAB = value
                OnPropertyChanged("ARE_FEC_GRAB")
            End If
        End Set
    End Property

    Private _aRE_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property ARE_ESTADO() As Nullable(Of Boolean)
        Get
            Return _aRE_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_aRE_ESTADO, value) Then
                _aRE_ESTADO = value
                OnPropertyChanged("ARE_ESTADO")
            End If
        End Set
    End Property

    Private _aRE_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property TAR_ID() As Nullable(Of Integer)
        Get
            Return _tAR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_tAR_ID, value) Then
                ChangeTracker.RecordOriginalValue("TAR_ID", _tAR_ID)
                If Not IsDeserializing Then
                    If TipoArea IsNot Nothing AndAlso Not Equals(TipoArea.TAR_ID, value) Then
                        TipoArea = Nothing
                    End If
                End If
                _tAR_ID = value
                OnPropertyChanged("TAR_ID")
            End If
        End Set
    End Property

    Private _tAR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ARE_ID_PADRE() As Nullable(Of Integer)
        Get
            Return _aRE_ID_PADRE
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aRE_ID_PADRE, value) Then
                _aRE_ID_PADRE = value
                OnPropertyChanged("ARE_ID_PADRE")
            End If
        End Set
    End Property

    Private _aRE_ID_PADRE As Nullable(Of Integer)

    <DataMember()>
    Public Property ARE_CODIGO() As String
        Get
            Return _aRE_CODIGO
        End Get
        Set(ByVal value As String)
            If Not Equals(_aRE_CODIGO, value) Then
                _aRE_CODIGO = value
                OnPropertyChanged("ARE_CODIGO")
            End If
        End Set
    End Property

    Private _aRE_CODIGO As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property RegistroEquipoDetalle() As TrackableCollection(Of RegistroEquipoDetalle)
        Get
            If _registroEquipoDetalle Is Nothing Then
                _registroEquipoDetalle = New TrackableCollection(Of RegistroEquipoDetalle)
                AddHandler _registroEquipoDetalle.CollectionChanged, AddressOf FixupRegistroEquipoDetalle
            End If
            Return _registroEquipoDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of RegistroEquipoDetalle))
            If Not Object.ReferenceEquals(_registroEquipoDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _registroEquipoDetalle IsNot Nothing Then
                    RemoveHandler _registroEquipoDetalle.CollectionChanged, AddressOf FixupRegistroEquipoDetalle
                End If
                _registroEquipoDetalle = value
                If _registroEquipoDetalle IsNot Nothing Then
                    AddHandler _registroEquipoDetalle.CollectionChanged, AddressOf FixupRegistroEquipoDetalle
                End If
                OnNavigationPropertyChanged("RegistroEquipoDetalle")
            End If
        End Set
    End Property

    Private _registroEquipoDetalle As TrackableCollection(Of RegistroEquipoDetalle)

    <DataMember()>
    Public Property TipoArea() As TipoArea
        Get
            Return _tipoArea
        End Get
        Set(ByVal value As TipoArea)
            If _tipoArea IsNot value Then
                Dim previousValue As TipoArea = _tipoArea
                _tipoArea = value
                FixupTipoArea(previousValue)
                OnNavigationPropertyChanged("TipoArea")
            End If
        End Set
    End Property

    Private _tipoArea As TipoArea


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
        RegistroEquipoDetalle.Clear()
        TipoArea = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupTipoArea(ByVal previousValue As TipoArea, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Area.Contains(Me) Then
            previousValue.Area.Remove(Me)
        End If

        If TipoArea IsNot Nothing Then
            If Not TipoArea.Area.Contains(Me) Then
                TipoArea.Area.Add(Me)
            End If

            TAR_ID = TipoArea.TAR_ID
        ElseIf Not skipKeys Then
            TAR_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("TipoArea") AndAlso
                ChangeTracker.OriginalValues("TipoArea") Is TipoArea Then
                ChangeTracker.OriginalValues.Remove("TipoArea")
            Else
                ChangeTracker.RecordOriginalValue("TipoArea", previousValue)
            End If
            If TipoArea IsNot Nothing AndAlso Not TipoArea.ChangeTracker.ChangeTrackingEnabled Then
                TipoArea.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupRegistroEquipoDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As RegistroEquipoDetalle In e.NewItems
                item.Area = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("RegistroEquipoDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As RegistroEquipoDetalle In e.OldItems
                If ReferenceEquals(item.Area, Me) Then
                    item.Area = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("RegistroEquipoDetalle", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
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
<KnownType(GetType(ControlParada))>
<KnownType(GetType(ControlExtrusoraDetalle))>
Partial Public Class ControlExtrusora
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared CEX_ID As string = "CEX_ID"
				public shared CPA_ID As string = "CPA_ID"
				public shared CEX_HOROMETRO_INICIAL As string = "CEX_HOROMETRO_INICIAL"
				public shared CEX_HOROMETRO_FINAL As string = "CEX_HOROMETRO_FINAL"
				public shared CEX_HOROMETRO_DIGITAL As string = "CEX_HOROMETRO_DIGITAL"
				public shared CEX_MEDIDA_CORTE As string = "CEX_MEDIDA_CORTE"
				public shared USU_ID As string = "USU_ID"
				public shared CEX_FEC_GRAB As string = "CEX_FEC_GRAB"
				public shared CEX_ESTADO As string = "CEX_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property CEX_ID() As Integer
        Get
            Return _cEX_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_cEX_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'CEX_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _cEX_ID = value
                OnPropertyChanged("CEX_ID")
            End If
        End Set
    End Property

    Private _cEX_ID As Integer

    <DataMember()>
    Public Property CPA_ID() As Nullable(Of Integer)
        Get
            Return _cPA_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cPA_ID, value) Then
                ChangeTracker.RecordOriginalValue("CPA_ID", _cPA_ID)
                If Not IsDeserializing Then
                    If ControlParada IsNot Nothing AndAlso Not Equals(ControlParada.CPA_ID, value) Then
                        ControlParada = Nothing
                    End If
                End If
                _cPA_ID = value
                OnPropertyChanged("CPA_ID")
            End If
        End Set
    End Property

    Private _cPA_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property CEX_HOROMETRO_INICIAL() As Nullable(Of Decimal)
        Get
            Return _cEX_HOROMETRO_INICIAL
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_cEX_HOROMETRO_INICIAL, value) Then
                _cEX_HOROMETRO_INICIAL = value
                OnPropertyChanged("CEX_HOROMETRO_INICIAL")
            End If
        End Set
    End Property

    Private _cEX_HOROMETRO_INICIAL As Nullable(Of Decimal)

    <DataMember()>
    Public Property CEX_HOROMETRO_FINAL() As Nullable(Of Decimal)
        Get
            Return _cEX_HOROMETRO_FINAL
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_cEX_HOROMETRO_FINAL, value) Then
                _cEX_HOROMETRO_FINAL = value
                OnPropertyChanged("CEX_HOROMETRO_FINAL")
            End If
        End Set
    End Property

    Private _cEX_HOROMETRO_FINAL As Nullable(Of Decimal)

    <DataMember()>
    Public Property CEX_HOROMETRO_DIGITAL() As Nullable(Of Decimal)
        Get
            Return _cEX_HOROMETRO_DIGITAL
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_cEX_HOROMETRO_DIGITAL, value) Then
                _cEX_HOROMETRO_DIGITAL = value
                OnPropertyChanged("CEX_HOROMETRO_DIGITAL")
            End If
        End Set
    End Property

    Private _cEX_HOROMETRO_DIGITAL As Nullable(Of Decimal)

    <DataMember()>
    Public Property CEX_MEDIDA_CORTE() As Nullable(Of Decimal)
        Get
            Return _cEX_MEDIDA_CORTE
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_cEX_MEDIDA_CORTE, value) Then
                _cEX_MEDIDA_CORTE = value
                OnPropertyChanged("CEX_MEDIDA_CORTE")
            End If
        End Set
    End Property

    Private _cEX_MEDIDA_CORTE As Nullable(Of Decimal)

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
    Public Property CEX_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _cEX_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_cEX_FEC_GRAB, value) Then
                _cEX_FEC_GRAB = value
                OnPropertyChanged("CEX_FEC_GRAB")
            End If
        End Set
    End Property

    Private _cEX_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property CEX_ESTADO() As Nullable(Of Boolean)
        Get
            Return _cEX_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_cEX_ESTADO, value) Then
                _cEX_ESTADO = value
                OnPropertyChanged("CEX_ESTADO")
            End If
        End Set
    End Property

    Private _cEX_ESTADO As Nullable(Of Boolean)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property ControlParada() As ControlParada
        Get
            Return _controlParada
        End Get
        Set(ByVal value As ControlParada)
            If _controlParada IsNot value Then
                Dim previousValue As ControlParada = _controlParada
                _controlParada = value
                FixupControlParada(previousValue)
                OnNavigationPropertyChanged("ControlParada")
            End If
        End Set
    End Property

    Private _controlParada As ControlParada


    <DataMember()>
    Public Property ControlExtrusoraDetalle() As TrackableCollection(Of ControlExtrusoraDetalle)
        Get
            If _controlExtrusoraDetalle Is Nothing Then
                _controlExtrusoraDetalle = New TrackableCollection(Of ControlExtrusoraDetalle)
                AddHandler _controlExtrusoraDetalle.CollectionChanged, AddressOf FixupControlExtrusoraDetalle
            End If
            Return _controlExtrusoraDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of ControlExtrusoraDetalle))
            If Not Object.ReferenceEquals(_controlExtrusoraDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _controlExtrusoraDetalle IsNot Nothing Then
                    RemoveHandler _controlExtrusoraDetalle.CollectionChanged, AddressOf FixupControlExtrusoraDetalle
                End If
                _controlExtrusoraDetalle = value
                If _controlExtrusoraDetalle IsNot Nothing Then
                    AddHandler _controlExtrusoraDetalle.CollectionChanged, AddressOf FixupControlExtrusoraDetalle
                End If
                OnNavigationPropertyChanged("ControlExtrusoraDetalle")
            End If
        End Set
    End Property

    Private _controlExtrusoraDetalle As TrackableCollection(Of ControlExtrusoraDetalle)

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
        ControlParada = Nothing
        ControlExtrusoraDetalle.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupControlParada(ByVal previousValue As ControlParada, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If ControlParada IsNot Nothing Then
            CPA_ID = ControlParada.CPA_ID
        ElseIf Not skipKeys Then
            CPA_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ControlParada") AndAlso
                ChangeTracker.OriginalValues("ControlParada") Is ControlParada Then
                ChangeTracker.OriginalValues.Remove("ControlParada")
            Else
                ChangeTracker.RecordOriginalValue("ControlParada", previousValue)
            End If
            If ControlParada IsNot Nothing AndAlso Not ControlParada.ChangeTracker.ChangeTrackingEnabled Then
                ControlParada.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupControlExtrusoraDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ControlExtrusoraDetalle In e.NewItems
                item.CEX_ID = CEX_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("ControlExtrusoraDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As ControlExtrusoraDetalle In e.OldItems
                item.CEX_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ControlExtrusoraDetalle", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

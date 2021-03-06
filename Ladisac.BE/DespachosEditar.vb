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
Partial Public Class DespachosEditar
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared USU_ID_EDI As string = "USU_ID_EDI"
				public shared PVE_ID As string = "PVE_ID"
				public shared DEE_SERIE As string = "DEE_SERIE"
				public shared DDE_FECHA_EMISION As string = "DDE_FECHA_EMISION"
				public shared USU_ID As string = "USU_ID"
				public shared DEE_FEC_GRAB As string = "DEE_FEC_GRAB"
				public shared DDE_ESTADO As string = "DDE_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property USU_ID_EDI() As String
        Get
            Return _uSU_ID_EDI
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID_EDI, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'USU_ID_EDI' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _uSU_ID_EDI = value
                OnPropertyChanged("USU_ID_EDI")
            End If
        End Set
    End Property

    Private _uSU_ID_EDI As String

    <DataMember()>
    Public Property PVE_ID() As String
        Get
            Return _pVE_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pVE_ID, value) Then
                _pVE_ID = value
                OnPropertyChanged("PVE_ID")
            End If
        End Set
    End Property

    Private _pVE_ID As String

    <DataMember()>
    Public Property DEE_SERIE() As String
        Get
            Return _dEE_SERIE
        End Get
        Set(ByVal value As String)
            If Not Equals(_dEE_SERIE, value) Then
                _dEE_SERIE = value
                OnPropertyChanged("DEE_SERIE")
            End If
        End Set
    End Property

    Private _dEE_SERIE As String

    <DataMember()>
    Public Property DDE_FECHA_EMISION() As Boolean
        Get
            Return _dDE_FECHA_EMISION
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dDE_FECHA_EMISION, value) Then
                _dDE_FECHA_EMISION = value
                OnPropertyChanged("DDE_FECHA_EMISION")
            End If
        End Set
    End Property

    Private _dDE_FECHA_EMISION As Boolean

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
    Public Property DEE_FEC_GRAB() As Date
        Get
            Return _dEE_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dEE_FEC_GRAB, value) Then
                _dEE_FEC_GRAB = value
                OnPropertyChanged("DEE_FEC_GRAB")
            End If
        End Set
    End Property

    Private _dEE_FEC_GRAB As Date

    <DataMember()>
    Public Property DDE_ESTADO() As Boolean
        Get
            Return _dDE_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dDE_ESTADO, value) Then
                _dDE_ESTADO = value
                OnPropertyChanged("DDE_ESTADO")
            End If
        End Set
    End Property

    Private _dDE_ESTADO As Boolean

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
    End Sub

#End Region
End Class

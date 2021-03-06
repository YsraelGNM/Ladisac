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
Partial Public Class DocumentosEditar
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DOE_USU_ID As string = "DOE_USU_ID"
				public shared PVE_ID As string = "PVE_ID"
				public shared DOC_SERIE As string = "DOC_SERIE"
				public shared DOC_FECHA_EMI As string = "DOC_FECHA_EMI"
				public shared USU_ID As string = "USU_ID"
				public shared DOE_FEC_GRAB As string = "DOE_FEC_GRAB"
				public shared DOE_ESTADO As string = "DOE_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property DOE_USU_ID() As String
        Get
            Return _dOE_USU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dOE_USU_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DOE_USU_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dOE_USU_ID = value
                OnPropertyChanged("DOE_USU_ID")
            End If
        End Set
    End Property

    Private _dOE_USU_ID As String

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
    Public Property DOC_SERIE() As String
        Get
            Return _dOC_SERIE
        End Get
        Set(ByVal value As String)
            If Not Equals(_dOC_SERIE, value) Then
                _dOC_SERIE = value
                OnPropertyChanged("DOC_SERIE")
            End If
        End Set
    End Property

    Private _dOC_SERIE As String

    <DataMember()>
    Public Property DOC_FECHA_EMI() As Boolean
        Get
            Return _dOC_FECHA_EMI
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dOC_FECHA_EMI, value) Then
                _dOC_FECHA_EMI = value
                OnPropertyChanged("DOC_FECHA_EMI")
            End If
        End Set
    End Property

    Private _dOC_FECHA_EMI As Boolean

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
    Public Property DOE_FEC_GRAB() As Date
        Get
            Return _dOE_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dOE_FEC_GRAB, value) Then
                _dOE_FEC_GRAB = value
                OnPropertyChanged("DOE_FEC_GRAB")
            End If
        End Set
    End Property

    Private _dOE_FEC_GRAB As Date

    <DataMember()>
    Public Property DOE_ESTADO() As Boolean
        Get
            Return _dOE_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dOE_ESTADO, value) Then
                _dOE_ESTADO = value
                OnPropertyChanged("DOE_ESTADO")
            End If
        End Set
    End Property

    Private _dOE_ESTADO As Boolean

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

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
Partial Public Class Vehiculo
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared VEH_Id As string = "VEH_Id"
				public shared PER_ID_CHOFER As string = "PER_ID_CHOFER"
				public shared PER_ID_EMPRESA As string = "PER_ID_EMPRESA"
				public shared VEH_FECHA As string = "VEH_FECHA"
				public shared VEH_PLACA As string = "VEH_PLACA"
				public shared VEH_KILOMETRAJE As string = "VEH_KILOMETRAJE"
				public shared VEH_HOROMETRO As string = "VEH_HOROMETRO"
				public shared VEH_NRO_SERIE As string = "VEH_NRO_SERIE"
				public shared VEH_NRO_MOTOR As string = "VEH_NRO_MOTOR"
				public shared VEH_ANIO_FABRICACION As string = "VEH_ANIO_FABRICACION"
				public shared VEH_FECHA_ADQUISICION As string = "VEH_FECHA_ADQUISICION"
				public shared USU_ID As string = "USU_ID"
				public shared VEH_FEC_GRAB As string = "VEH_FEC_GRAB"
				public shared VEH_ESTADO As string = "VEH_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property VEH_Id() As String
        Get
            Return _vEH_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_vEH_Id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'VEH_Id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _vEH_Id = value
                OnPropertyChanged("VEH_Id")
            End If
        End Set
    End Property

    Private _vEH_Id As String

    <DataMember()>
    Public Property PER_ID_CHOFER() As String
        Get
            Return _pER_ID_CHOFER
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_CHOFER, value) Then
                _pER_ID_CHOFER = value
                OnPropertyChanged("PER_ID_CHOFER")
            End If
        End Set
    End Property

    Private _pER_ID_CHOFER As String

    <DataMember()>
    Public Property PER_ID_EMPRESA() As String
        Get
            Return _pER_ID_EMPRESA
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_EMPRESA, value) Then
                _pER_ID_EMPRESA = value
                OnPropertyChanged("PER_ID_EMPRESA")
            End If
        End Set
    End Property

    Private _pER_ID_EMPRESA As String

    <DataMember()>
    Public Property VEH_FECHA() As Nullable(Of Date)
        Get
            Return _vEH_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_vEH_FECHA, value) Then
                _vEH_FECHA = value
                OnPropertyChanged("VEH_FECHA")
            End If
        End Set
    End Property

    Private _vEH_FECHA As Nullable(Of Date)

    <DataMember()>
    Public Property VEH_PLACA() As String
        Get
            Return _vEH_PLACA
        End Get
        Set(ByVal value As String)
            If Not Equals(_vEH_PLACA, value) Then
                _vEH_PLACA = value
                OnPropertyChanged("VEH_PLACA")
            End If
        End Set
    End Property

    Private _vEH_PLACA As String

    <DataMember()>
    Public Property VEH_KILOMETRAJE() As Nullable(Of Decimal)
        Get
            Return _vEH_KILOMETRAJE
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_vEH_KILOMETRAJE, value) Then
                _vEH_KILOMETRAJE = value
                OnPropertyChanged("VEH_KILOMETRAJE")
            End If
        End Set
    End Property

    Private _vEH_KILOMETRAJE As Nullable(Of Decimal)

    <DataMember()>
    Public Property VEH_HOROMETRO() As Nullable(Of Decimal)
        Get
            Return _vEH_HOROMETRO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_vEH_HOROMETRO, value) Then
                _vEH_HOROMETRO = value
                OnPropertyChanged("VEH_HOROMETRO")
            End If
        End Set
    End Property

    Private _vEH_HOROMETRO As Nullable(Of Decimal)

    <DataMember()>
    Public Property VEH_NRO_SERIE() As String
        Get
            Return _vEH_NRO_SERIE
        End Get
        Set(ByVal value As String)
            If Not Equals(_vEH_NRO_SERIE, value) Then
                _vEH_NRO_SERIE = value
                OnPropertyChanged("VEH_NRO_SERIE")
            End If
        End Set
    End Property

    Private _vEH_NRO_SERIE As String

    <DataMember()>
    Public Property VEH_NRO_MOTOR() As String
        Get
            Return _vEH_NRO_MOTOR
        End Get
        Set(ByVal value As String)
            If Not Equals(_vEH_NRO_MOTOR, value) Then
                _vEH_NRO_MOTOR = value
                OnPropertyChanged("VEH_NRO_MOTOR")
            End If
        End Set
    End Property

    Private _vEH_NRO_MOTOR As String

    <DataMember()>
    Public Property VEH_ANIO_FABRICACION() As Nullable(Of Integer)
        Get
            Return _vEH_ANIO_FABRICACION
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_vEH_ANIO_FABRICACION, value) Then
                _vEH_ANIO_FABRICACION = value
                OnPropertyChanged("VEH_ANIO_FABRICACION")
            End If
        End Set
    End Property

    Private _vEH_ANIO_FABRICACION As Nullable(Of Integer)

    <DataMember()>
    Public Property VEH_FECHA_ADQUISICION() As Nullable(Of Date)
        Get
            Return _vEH_FECHA_ADQUISICION
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_vEH_FECHA_ADQUISICION, value) Then
                _vEH_FECHA_ADQUISICION = value
                OnPropertyChanged("VEH_FECHA_ADQUISICION")
            End If
        End Set
    End Property

    Private _vEH_FECHA_ADQUISICION As Nullable(Of Date)

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
    Public Property VEH_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _vEH_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_vEH_FEC_GRAB, value) Then
                _vEH_FEC_GRAB = value
                OnPropertyChanged("VEH_FEC_GRAB")
            End If
        End Set
    End Property

    Private _vEH_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property VEH_ESTADO() As Nullable(Of Boolean)
        Get
            Return _vEH_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_vEH_ESTADO, value) Then
                _vEH_ESTADO = value
                OnPropertyChanged("VEH_ESTADO")
            End If
        End Set
    End Property

    Private _vEH_ESTADO As Nullable(Of Boolean)

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
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
<KnownType(GetType(CuentasContables))>
Partial Public Class ConfiguracionFormatos
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared cofo_Id As string = "cofo_Id"
				public shared cofo_Descripcion As string = "cofo_Descripcion"
				public shared cuc_IdInicio As string = "cuc_IdInicio"
				public shared cuc_IdIFin As string = "cuc_IdIFin"
		    End Structure
	



    <DataMember()>
    Public Property cofo_Id() As String
        Get
            Return _cofo_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_cofo_Id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'cofo_Id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _cofo_Id = value
                OnPropertyChanged("cofo_Id")
            End If
        End Set
    End Property

    Private _cofo_Id As String

    <DataMember()>
    Public Property cofo_Descripcion() As String
        Get
            Return _cofo_Descripcion
        End Get
        Set(ByVal value As String)
            If Not Equals(_cofo_Descripcion, value) Then
                _cofo_Descripcion = value
                OnPropertyChanged("cofo_Descripcion")
            End If
        End Set
    End Property

    Private _cofo_Descripcion As String

    <DataMember()>
    Public Property cuc_IdInicio() As String
        Get
            Return _cuc_IdInicio
        End Get
        Set(ByVal value As String)
            If Not Equals(_cuc_IdInicio, value) Then
                ChangeTracker.RecordOriginalValue("cuc_IdInicio", _cuc_IdInicio)
                If Not IsDeserializing Then
                    If CuentasContables IsNot Nothing AndAlso Not Equals(CuentasContables.CUC_ID, value) Then
                        CuentasContables = Nothing
                    End If
                End If
                _cuc_IdInicio = value
                OnPropertyChanged("cuc_IdInicio")
            End If
        End Set
    End Property

    Private _cuc_IdInicio As String

    <DataMember()>
    Public Property cuc_IdIFin() As String
        Get
            Return _cuc_IdIFin
        End Get
        Set(ByVal value As String)
            If Not Equals(_cuc_IdIFin, value) Then
                ChangeTracker.RecordOriginalValue("cuc_IdIFin", _cuc_IdIFin)
                If Not IsDeserializing Then
                    If CuentasContables1 IsNot Nothing AndAlso Not Equals(CuentasContables1.CUC_ID, value) Then
                        CuentasContables1 = Nothing
                    End If
                End If
                _cuc_IdIFin = value
                OnPropertyChanged("cuc_IdIFin")
            End If
        End Set
    End Property

    Private _cuc_IdIFin As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property CuentasContables() As CuentasContables
        Get
            Return _cuentasContables
        End Get
        Set(ByVal value As CuentasContables)
            If _cuentasContables IsNot value Then
                Dim previousValue As CuentasContables = _cuentasContables
                _cuentasContables = value
                FixupCuentasContables(previousValue)
                OnNavigationPropertyChanged("CuentasContables")
            End If
        End Set
    End Property

    Private _cuentasContables As CuentasContables


    <DataMember()>
    Public Property CuentasContables1() As CuentasContables
        Get
            Return _cuentasContables1
        End Get
        Set(ByVal value As CuentasContables)
            If _cuentasContables1 IsNot value Then
                Dim previousValue As CuentasContables = _cuentasContables1
                _cuentasContables1 = value
                FixupCuentasContables1(previousValue)
                OnNavigationPropertyChanged("CuentasContables1")
            End If
        End Set
    End Property

    Private _cuentasContables1 As CuentasContables


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
        CuentasContables = Nothing
        CuentasContables1 = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupCuentasContables(ByVal previousValue As CuentasContables, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If CuentasContables IsNot Nothing Then
            cuc_IdInicio = CuentasContables.CUC_ID
        ElseIf Not skipKeys Then
            cuc_IdInicio = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("CuentasContables") AndAlso
                ChangeTracker.OriginalValues("CuentasContables") Is CuentasContables Then
                ChangeTracker.OriginalValues.Remove("CuentasContables")
            Else
                ChangeTracker.RecordOriginalValue("CuentasContables", previousValue)
            End If
            If CuentasContables IsNot Nothing AndAlso Not CuentasContables.ChangeTracker.ChangeTrackingEnabled Then
                CuentasContables.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupCuentasContables1(ByVal previousValue As CuentasContables, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If CuentasContables1 IsNot Nothing Then
            cuc_IdIFin = CuentasContables1.CUC_ID
        ElseIf Not skipKeys Then
            cuc_IdIFin = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("CuentasContables1") AndAlso
                ChangeTracker.OriginalValues("CuentasContables1") Is CuentasContables1 Then
                ChangeTracker.OriginalValues.Remove("CuentasContables1")
            Else
                ChangeTracker.RecordOriginalValue("CuentasContables1", previousValue)
            End If
            If CuentasContables1 IsNot Nothing AndAlso Not CuentasContables1.ChangeTracker.ChangeTrackingEnabled Then
                CuentasContables1.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class

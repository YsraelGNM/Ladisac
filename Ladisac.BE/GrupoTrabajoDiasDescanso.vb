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
<KnownType(GetType(Personas))>
<KnownType(GetType(Usuarios))>
Partial Public Class GrupoTrabajoDiasDescanso
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared per_Id As string = "per_Id"
				public shared grd_Fecha As string = "grd_Fecha"
				public shared grd_FechaGRab As string = "grd_FechaGRab"
				public shared grd_Doble As string = "grd_Doble"
				public shared grd_observaciones As string = "grd_observaciones"
				public shared Usu_Id As string = "Usu_Id"
		    End Structure
	



    <DataMember()>
    Public Property per_Id() As String
        Get
            Return _per_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_per_Id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'per_Id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _per_Id = value
                OnPropertyChanged("per_Id")
            End If
        End Set
    End Property

    Private _per_Id As String

    <DataMember()>
    Public Property grd_Fecha() As Date
        Get
            Return _grd_Fecha
        End Get
        Set(ByVal value As Date)
            If Not Equals(_grd_Fecha, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'grd_Fecha' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _grd_Fecha = value
                OnPropertyChanged("grd_Fecha")
            End If
        End Set
    End Property

    Private _grd_Fecha As Date

    <DataMember()>
    Public Property grd_FechaGRab() As Date
        Get
            Return _grd_FechaGRab
        End Get
        Set(ByVal value As Date)
            If Not Equals(_grd_FechaGRab, value) Then
                _grd_FechaGRab = value
                OnPropertyChanged("grd_FechaGRab")
            End If
        End Set
    End Property

    Private _grd_FechaGRab As Date

    <DataMember()>
    Public Property grd_Doble() As Nullable(Of Boolean)
        Get
            Return _grd_Doble
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_grd_Doble, value) Then
                _grd_Doble = value
                OnPropertyChanged("grd_Doble")
            End If
        End Set
    End Property

    Private _grd_Doble As Nullable(Of Boolean)

    <DataMember()>
    Public Property grd_observaciones() As String
        Get
            Return _grd_observaciones
        End Get
        Set(ByVal value As String)
            If Not Equals(_grd_observaciones, value) Then
                _grd_observaciones = value
                OnPropertyChanged("grd_observaciones")
            End If
        End Set
    End Property

    Private _grd_observaciones As String

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

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Personas() As Personas
        Get
            Return _personas
        End Get
        Set(ByVal value As Personas)
            If _personas IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(per_Id, value.PER_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As Personas = _personas
                _personas = value
                FixupPersonas(previousValue)
                OnNavigationPropertyChanged("Personas")
            End If
        End Set
    End Property

    Private _personas As Personas


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

    ' Este tipo de entidad es el extremo dependiente en al menos una asociación que realiza eliminaciones en cascada.
    ' Este controlador de eventos procesará notificaciones que tienen lugar cuando se elimina el extremo principal.
    Friend Sub HandleCascadeDelete(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.MarkAsDeleted()
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
        Personas = Nothing
        Usuarios = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPersonas(ByVal previousValue As Personas)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.GrupoTrabajoDiasDescanso.Contains(Me) Then
            previousValue.GrupoTrabajoDiasDescanso.Remove(Me)
        End If

        If Personas IsNot Nothing Then
            If Not Personas.GrupoTrabajoDiasDescanso.Contains(Me) Then
                Personas.GrupoTrabajoDiasDescanso.Add(Me)
            End If

            per_Id = Personas.PER_ID
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

    Private Sub FixupUsuarios(ByVal previousValue As Usuarios, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Usuarios IsNot Nothing Then
            Usu_Id = Usuarios.USU_ID
        ElseIf Not skipKeys Then
            Usu_Id = Nothing
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

#End Region
End Class
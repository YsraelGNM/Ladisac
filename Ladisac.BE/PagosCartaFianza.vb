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
<KnownType(GetType(CartaFianza))>
<KnownType(GetType(Moneda))>
<KnownType(GetType(Usuarios))>
Partial Public Class PagosCartaFianza
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared CAF_ID As string = "CAF_ID"
				public shared PCF_TIPO As string = "PCF_TIPO"
				public shared PCF_FECHA As string = "PCF_FECHA"
				public shared MON_ID As string = "MON_ID"
				public shared PCF_MONTO As string = "PCF_MONTO"
				public shared PCF_CONTRAVALOR As string = "PCF_CONTRAVALOR"
				public shared PCF_OBSERVACIONES As string = "PCF_OBSERVACIONES"
				public shared USU_ID As string = "USU_ID"
				public shared PCF_FEC_GRAB As string = "PCF_FEC_GRAB"
				public shared PCF_ESTADO As string = "PCF_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property CAF_ID() As String
        Get
            Return _cAF_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cAF_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'CAF_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If CartaFianza IsNot Nothing AndAlso Not Equals(CartaFianza.CAF_ID, value) Then
                        CartaFianza = Nothing
                    End If
                End If
                _cAF_ID = value
                OnPropertyChanged("CAF_ID")
            End If
        End Set
    End Property

    Private _cAF_ID As String

    <DataMember()>
    Public Property PCF_TIPO() As Short
        Get
            Return _pCF_TIPO
        End Get
        Set(ByVal value As Short)
            If Not Equals(_pCF_TIPO, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PCF_TIPO' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pCF_TIPO = value
                OnPropertyChanged("PCF_TIPO")
            End If
        End Set
    End Property

    Private _pCF_TIPO As Short

    <DataMember()>
    Public Property PCF_FECHA() As Date
        Get
            Return _pCF_FECHA
        End Get
        Set(ByVal value As Date)
            If Not Equals(_pCF_FECHA, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PCF_FECHA' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pCF_FECHA = value
                OnPropertyChanged("PCF_FECHA")
            End If
        End Set
    End Property

    Private _pCF_FECHA As Date

    <DataMember()>
    Public Property MON_ID() As String
        Get
            Return _mON_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_mON_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'MON_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If Moneda IsNot Nothing AndAlso Not Equals(Moneda.MON_ID, value) Then
                        Moneda = Nothing
                    End If
                End If
                _mON_ID = value
                OnPropertyChanged("MON_ID")
            End If
        End Set
    End Property

    Private _mON_ID As String

    <DataMember()>
    Public Property PCF_MONTO() As Decimal
        Get
            Return _pCF_MONTO
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_pCF_MONTO, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PCF_MONTO' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pCF_MONTO = value
                OnPropertyChanged("PCF_MONTO")
            End If
        End Set
    End Property

    Private _pCF_MONTO As Decimal

    <DataMember()>
    Public Property PCF_CONTRAVALOR() As Decimal
        Get
            Return _pCF_CONTRAVALOR
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_pCF_CONTRAVALOR, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PCF_CONTRAVALOR' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pCF_CONTRAVALOR = value
                OnPropertyChanged("PCF_CONTRAVALOR")
            End If
        End Set
    End Property

    Private _pCF_CONTRAVALOR As Decimal

    <DataMember()>
    Public Property PCF_OBSERVACIONES() As String
        Get
            Return _pCF_OBSERVACIONES
        End Get
        Set(ByVal value As String)
            If Not Equals(_pCF_OBSERVACIONES, value) Then
                _pCF_OBSERVACIONES = value
                OnPropertyChanged("PCF_OBSERVACIONES")
            End If
        End Set
    End Property

    Private _pCF_OBSERVACIONES As String

    <DataMember()>
    Public Property USU_ID() As String
        Get
            Return _uSU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'USU_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
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
    Public Property PCF_FEC_GRAB() As Date
        Get
            Return _pCF_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_pCF_FEC_GRAB, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PCF_FEC_GRAB' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pCF_FEC_GRAB = value
                OnPropertyChanged("PCF_FEC_GRAB")
            End If
        End Set
    End Property

    Private _pCF_FEC_GRAB As Date

    <DataMember()>
    Public Property PCF_ESTADO() As Boolean
        Get
            Return _pCF_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_pCF_ESTADO, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PCF_ESTADO' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pCF_ESTADO = value
                OnPropertyChanged("PCF_ESTADO")
            End If
        End Set
    End Property

    Private _pCF_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property CartaFianza() As CartaFianza
        Get
            Return _cartaFianza
        End Get
        Set(ByVal value As CartaFianza)
            If _cartaFianza IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(CAF_ID, value.CAF_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As CartaFianza = _cartaFianza
                _cartaFianza = value
                FixupCartaFianza(previousValue)
                OnNavigationPropertyChanged("CartaFianza")
            End If
        End Set
    End Property

    Private _cartaFianza As CartaFianza


    <DataMember()>
    Public Property Moneda() As Moneda
        Get
            Return _moneda
        End Get
        Set(ByVal value As Moneda)
            If _moneda IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(MON_ID, value.MON_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As Moneda = _moneda
                _moneda = value
                FixupMoneda(previousValue)
                OnNavigationPropertyChanged("Moneda")
            End If
        End Set
    End Property

    Private _moneda As Moneda


    <DataMember()>
    Public Property Usuarios() As Usuarios
        Get
            Return _usuarios
        End Get
        Set(ByVal value As Usuarios)
            If _usuarios IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(USU_ID, value.USU_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
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
        CartaFianza = Nothing
        Moneda = Nothing
        Usuarios = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupCartaFianza(ByVal previousValue As CartaFianza)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.PagosCartaFianza.Contains(Me) Then
            previousValue.PagosCartaFianza.Remove(Me)
        End If

        If CartaFianza IsNot Nothing Then
            If Not CartaFianza.PagosCartaFianza.Contains(Me) Then
                CartaFianza.PagosCartaFianza.Add(Me)
            End If

            CAF_ID = CartaFianza.CAF_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("CartaFianza") AndAlso
                ChangeTracker.OriginalValues("CartaFianza") Is CartaFianza Then
                ChangeTracker.OriginalValues.Remove("CartaFianza")
            Else
                ChangeTracker.RecordOriginalValue("CartaFianza", previousValue)
            End If
            If CartaFianza IsNot Nothing AndAlso Not CartaFianza.ChangeTracker.ChangeTrackingEnabled Then
                CartaFianza.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupMoneda(ByVal previousValue As Moneda)
        ' Este es el extremo dependiente en una asociación que realiza eliminaciones en cascada.
        ' Actualizar la escucha de eventos del extremo principal para que se refiera al nuevo extremo dependiente.
        ' Esta es una relación unidireccional desde el extremo dependiente al extremo principal por lo que el extremo dependiente es
        ' responsable de administrar el controlador de eventos de eliminación en cascada. En el resto de los casos, será el extremo principal el que lo administrará.
        If previousValue IsNot Nothing Then
            RemoveHandler previousValue.ChangeTracker.ObjectStateChanging, AddressOf HandleCascadeDelete
        End If

        If Moneda IsNot Nothing Then
            AddHandler Moneda.ChangeTracker.ObjectStateChanging, AddressOf HandleCascadeDelete
        End If

        If IsDeserializing Then
            Return
        End If

        If Moneda IsNot Nothing Then
            MON_ID = Moneda.MON_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Moneda") AndAlso
                ChangeTracker.OriginalValues("Moneda") Is Moneda Then
                ChangeTracker.OriginalValues.Remove("Moneda")
            Else
                ChangeTracker.RecordOriginalValue("Moneda", previousValue)
                ' Este es el extremo dependiente de una asociación de identificación, por lo que se debe eliminar cuando la relación se
                ' elimine. Si el estado actual es agregado, la relación se puede modificar sin eliminar el extremo dependiente.
                ' Esta es una relación unidireccional desde el extremo dependiente al extremo principal por lo que el extremo dependiente es
                ' responsable de administrar en cascada la eliminación. En el resto de los casos, será el extremo principal el que lo administre.
                If previousValue IsNot Nothing AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Me.MarkAsDeleted()
                End If
            End If
            If Moneda IsNot Nothing AndAlso Not Moneda.ChangeTracker.ChangeTrackingEnabled Then
                Moneda.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupUsuarios(ByVal previousValue As Usuarios)
        ' Este es el extremo dependiente en una asociación que realiza eliminaciones en cascada.
        ' Actualizar la escucha de eventos del extremo principal para que se refiera al nuevo extremo dependiente.
        ' Esta es una relación unidireccional desde el extremo dependiente al extremo principal por lo que el extremo dependiente es
        ' responsable de administrar el controlador de eventos de eliminación en cascada. En el resto de los casos, será el extremo principal el que lo administrará.
        If previousValue IsNot Nothing Then
            RemoveHandler previousValue.ChangeTracker.ObjectStateChanging, AddressOf HandleCascadeDelete
        End If

        If Usuarios IsNot Nothing Then
            AddHandler Usuarios.ChangeTracker.ObjectStateChanging, AddressOf HandleCascadeDelete
        End If

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
                ' Este es el extremo dependiente de una asociación de identificación, por lo que se debe eliminar cuando la relación se
                ' elimine. Si el estado actual es agregado, la relación se puede modificar sin eliminar el extremo dependiente.
                ' Esta es una relación unidireccional desde el extremo dependiente al extremo principal por lo que el extremo dependiente es
                ' responsable de administrar en cascada la eliminación. En el resto de los casos, será el extremo principal el que lo administre.
                If previousValue IsNot Nothing AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Me.MarkAsDeleted()
                End If
            End If
            If Usuarios IsNot Nothing AndAlso Not Usuarios.ChangeTracker.ChangeTrackingEnabled Then
                Usuarios.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class

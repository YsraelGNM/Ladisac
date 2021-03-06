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
<KnownType(GetType(PuntoVenta))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(DetalleCierre))>
Partial Public Class Cierre
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared CIE_ID As string = "CIE_ID"
				public shared CIE_MES As string = "CIE_MES"
				public shared CIE_ANIO As string = "CIE_ANIO"
				public shared PVE_ID As string = "PVE_ID"
				public shared USU_ID As string = "USU_ID"
				public shared CIE_FEC_GRAB As string = "CIE_FEC_GRAB"
				public shared CIE_ESTADO As string = "CIE_ESTADO"
				public shared CIE_DIA As string = "CIE_DIA"
		    End Structure
	



    <DataMember()>
    Public Property CIE_ID() As String
        Get
            Return _cIE_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cIE_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'CIE_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _cIE_ID = value
                OnPropertyChanged("CIE_ID")
            End If
        End Set
    End Property

    Private _cIE_ID As String

    <DataMember()>
    Public Property CIE_MES() As Short
        Get
            Return _cIE_MES
        End Get
        Set(ByVal value As Short)
            If Not Equals(_cIE_MES, value) Then
                _cIE_MES = value
                OnPropertyChanged("CIE_MES")
            End If
        End Set
    End Property

    Private _cIE_MES As Short

    <DataMember()>
    Public Property CIE_ANIO() As Decimal
        Get
            Return _cIE_ANIO
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_cIE_ANIO, value) Then
                _cIE_ANIO = value
                OnPropertyChanged("CIE_ANIO")
            End If
        End Set
    End Property

    Private _cIE_ANIO As Decimal

    <DataMember()>
    Public Property PVE_ID() As String
        Get
            Return _pVE_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pVE_ID, value) Then
                ChangeTracker.RecordOriginalValue("PVE_ID", _pVE_ID)
                If Not IsDeserializing Then
                    If PuntoVenta IsNot Nothing AndAlso Not Equals(PuntoVenta.PVE_ID, value) Then
                        PuntoVenta = Nothing
                    End If
                End If
                _pVE_ID = value
                OnPropertyChanged("PVE_ID")
            End If
        End Set
    End Property

    Private _pVE_ID As String

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
    Public Property CIE_FEC_GRAB() As Date
        Get
            Return _cIE_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_cIE_FEC_GRAB, value) Then
                _cIE_FEC_GRAB = value
                OnPropertyChanged("CIE_FEC_GRAB")
            End If
        End Set
    End Property

    Private _cIE_FEC_GRAB As Date

    <DataMember()>
    Public Property CIE_ESTADO() As Boolean
        Get
            Return _cIE_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_cIE_ESTADO, value) Then
                _cIE_ESTADO = value
                OnPropertyChanged("CIE_ESTADO")
            End If
        End Set
    End Property

    Private _cIE_ESTADO As Boolean

    <DataMember()>
    Public Property CIE_DIA() As Short
        Get
            Return _cIE_DIA
        End Get
        Set(ByVal value As Short)
            If Not Equals(_cIE_DIA, value) Then
                _cIE_DIA = value
                OnPropertyChanged("CIE_DIA")
            End If
        End Set
    End Property

    Private _cIE_DIA As Short

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property PuntoVenta() As PuntoVenta
        Get
            Return _puntoVenta
        End Get
        Set(ByVal value As PuntoVenta)
            If _puntoVenta IsNot value Then
                Dim previousValue As PuntoVenta = _puntoVenta
                _puntoVenta = value
                FixupPuntoVenta(previousValue)
                OnNavigationPropertyChanged("PuntoVenta")
            End If
        End Set
    End Property

    Private _puntoVenta As PuntoVenta


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
    Public Property DetalleCierre() As TrackableCollection(Of DetalleCierre)
        Get
            If _detalleCierre Is Nothing Then
                _detalleCierre = New TrackableCollection(Of DetalleCierre)
                AddHandler _detalleCierre.CollectionChanged, AddressOf FixupDetalleCierre
            End If
            Return _detalleCierre
        End Get
        Set(ByVal value As TrackableCollection(Of DetalleCierre))
            If Not Object.ReferenceEquals(_detalleCierre, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detalleCierre IsNot Nothing Then
                    RemoveHandler _detalleCierre.CollectionChanged, AddressOf FixupDetalleCierre
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As DetalleCierre In _detalleCierre
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _detalleCierre = value
                If _detalleCierre IsNot Nothing Then
                    AddHandler _detalleCierre.CollectionChanged, AddressOf FixupDetalleCierre
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As DetalleCierre In _detalleCierre
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("DetalleCierre")
            End If
        End Set
    End Property

    Private _detalleCierre As TrackableCollection(Of DetalleCierre)

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
        PuntoVenta = Nothing
        Usuarios = Nothing
        DetalleCierre.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPuntoVenta(ByVal previousValue As PuntoVenta)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Cierre.Contains(Me) Then
            previousValue.Cierre.Remove(Me)
        End If

        If PuntoVenta IsNot Nothing Then
            If Not PuntoVenta.Cierre.Contains(Me) Then
                PuntoVenta.Cierre.Add(Me)
            End If

            PVE_ID = PuntoVenta.PVE_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("PuntoVenta") AndAlso
                ChangeTracker.OriginalValues("PuntoVenta") Is PuntoVenta Then
                ChangeTracker.OriginalValues.Remove("PuntoVenta")
            Else
                ChangeTracker.RecordOriginalValue("PuntoVenta", previousValue)
            End If
            If PuntoVenta IsNot Nothing AndAlso Not PuntoVenta.ChangeTracker.ChangeTrackingEnabled Then
                PuntoVenta.StartTracking()
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

    Private Sub FixupDetalleCierre(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetalleCierre In e.NewItems
                item.Cierre = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetalleCierre", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetalleCierre In e.OldItems
                If ReferenceEquals(item.Cierre, Me) Then
                    item.Cierre = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetalleCierre", item)
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

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
<KnownType(GetType(Articulos))>
<KnownType(GetType(Entidad))>
<KnownType(GetType(OrdenTrabajo))>
Partial Public Class OrdenRequerimientoDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared ORD_ID As string = "ORD_ID"
				public shared ORR_ID As string = "ORR_ID"
				public shared ART_ID As string = "ART_ID"
				public shared ORD_CANTIDAD As string = "ORD_CANTIDAD"
				public shared ORD_CANTIDAD_ATENDIDA As string = "ORD_CANTIDAD_ATENDIDA"
				public shared OTR_ID As string = "OTR_ID"
				public shared ORD_OBSERVACION As string = "ORD_OBSERVACION"
				public shared ORD_ESTADO_COMPRA As string = "ORD_ESTADO_COMPRA"
				public shared ORD_OBS_COMPRA As string = "ORD_OBS_COMPRA"
				public shared ORD_CANTIDAD_COMPRA As string = "ORD_CANTIDAD_COMPRA"
				public shared ALM_ID As string = "ALM_ID"
				public shared ENO_ID As string = "ENO_ID"
				public shared ORD_CONFORMIDAD As string = "ORD_CONFORMIDAD"
				public shared USU_ID_AUT As string = "USU_ID_AUT"
				public shared ORD_FEC_AUT As string = "ORD_FEC_AUT"
				public shared ORD_RECHAZADO As string = "ORD_RECHAZADO"
		    End Structure
	



    <DataMember()>
    Public Property ORD_ID() As Integer
        Get
            Return _oRD_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_oRD_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'ORD_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _oRD_ID = value
                OnPropertyChanged("ORD_ID")
            End If
        End Set
    End Property

    Private _oRD_ID As Integer

    <DataMember()>
    Public Property ORR_ID() As Nullable(Of Integer)
        Get
            Return _oRR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oRR_ID, value) Then
                ChangeTracker.RecordOriginalValue("ORR_ID", _oRR_ID)
                _oRR_ID = value
                OnPropertyChanged("ORR_ID")
            End If
        End Set
    End Property

    Private _oRR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ART_ID() As String
        Get
            Return _aRT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_aRT_ID, value) Then
                ChangeTracker.RecordOriginalValue("ART_ID", _aRT_ID)
                If Not IsDeserializing Then
                    If Articulos IsNot Nothing AndAlso Not Equals(Articulos.ART_ID, value) Then
                        Articulos = Nothing
                    End If
                End If
                _aRT_ID = value
                OnPropertyChanged("ART_ID")
            End If
        End Set
    End Property

    Private _aRT_ID As String

    <DataMember()>
    Public Property ORD_CANTIDAD() As Nullable(Of Decimal)
        Get
            Return _oRD_CANTIDAD
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oRD_CANTIDAD, value) Then
                _oRD_CANTIDAD = value
                OnPropertyChanged("ORD_CANTIDAD")
            End If
        End Set
    End Property

    Private _oRD_CANTIDAD As Nullable(Of Decimal)

    <DataMember()>
    Public Property ORD_CANTIDAD_ATENDIDA() As Nullable(Of Decimal)
        Get
            Return _oRD_CANTIDAD_ATENDIDA
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oRD_CANTIDAD_ATENDIDA, value) Then
                _oRD_CANTIDAD_ATENDIDA = value
                OnPropertyChanged("ORD_CANTIDAD_ATENDIDA")
            End If
        End Set
    End Property

    Private _oRD_CANTIDAD_ATENDIDA As Nullable(Of Decimal)

    <DataMember()>
    Public Property OTR_ID() As Nullable(Of Integer)
        Get
            Return _oTR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oTR_ID, value) Then
                ChangeTracker.RecordOriginalValue("OTR_ID", _oTR_ID)
                If Not IsDeserializing Then
                    If OrdenTrabajo IsNot Nothing AndAlso Not Equals(OrdenTrabajo.OTR_ID, value) Then
                        OrdenTrabajo = Nothing
                    End If
                End If
                _oTR_ID = value
                OnPropertyChanged("OTR_ID")
            End If
        End Set
    End Property

    Private _oTR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ORD_OBSERVACION() As String
        Get
            Return _oRD_OBSERVACION
        End Get
        Set(ByVal value As String)
            If Not Equals(_oRD_OBSERVACION, value) Then
                _oRD_OBSERVACION = value
                OnPropertyChanged("ORD_OBSERVACION")
            End If
        End Set
    End Property

    Private _oRD_OBSERVACION As String

    <DataMember()>
    Public Property ORD_ESTADO_COMPRA() As String
        Get
            Return _oRD_ESTADO_COMPRA
        End Get
        Set(ByVal value As String)
            If Not Equals(_oRD_ESTADO_COMPRA, value) Then
                _oRD_ESTADO_COMPRA = value
                OnPropertyChanged("ORD_ESTADO_COMPRA")
            End If
        End Set
    End Property

    Private _oRD_ESTADO_COMPRA As String

    <DataMember()>
    Public Property ORD_OBS_COMPRA() As String
        Get
            Return _oRD_OBS_COMPRA
        End Get
        Set(ByVal value As String)
            If Not Equals(_oRD_OBS_COMPRA, value) Then
                _oRD_OBS_COMPRA = value
                OnPropertyChanged("ORD_OBS_COMPRA")
            End If
        End Set
    End Property

    Private _oRD_OBS_COMPRA As String

    <DataMember()>
    Public Property ORD_CANTIDAD_COMPRA() As Nullable(Of Decimal)
        Get
            Return _oRD_CANTIDAD_COMPRA
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oRD_CANTIDAD_COMPRA, value) Then
                _oRD_CANTIDAD_COMPRA = value
                OnPropertyChanged("ORD_CANTIDAD_COMPRA")
            End If
        End Set
    End Property

    Private _oRD_CANTIDAD_COMPRA As Nullable(Of Decimal)

    <DataMember()>
    Public Property ALM_ID() As Nullable(Of Integer)
        Get
            Return _aLM_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aLM_ID, value) Then
                _aLM_ID = value
                OnPropertyChanged("ALM_ID")
            End If
        End Set
    End Property

    Private _aLM_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ENO_ID() As Integer
        Get
            Return _eNO_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_eNO_ID, value) Then
                ChangeTracker.RecordOriginalValue("ENO_ID", _eNO_ID)
                If Not IsDeserializing Then
                    If Entidad IsNot Nothing AndAlso Not Equals(Entidad.ENO_ID, value) Then
                        Entidad = Nothing
                    End If
                End If
                _eNO_ID = value
                OnPropertyChanged("ENO_ID")
            End If
        End Set
    End Property

    Private _eNO_ID As Integer

    <DataMember()>
    Public Property ORD_CONFORMIDAD() As Nullable(Of Integer)
        Get
            Return _oRD_CONFORMIDAD
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oRD_CONFORMIDAD, value) Then
                _oRD_CONFORMIDAD = value
                OnPropertyChanged("ORD_CONFORMIDAD")
            End If
        End Set
    End Property

    Private _oRD_CONFORMIDAD As Nullable(Of Integer)

    <DataMember()>
    Public Property USU_ID_AUT() As String
        Get
            Return _uSU_ID_AUT
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID_AUT, value) Then
                _uSU_ID_AUT = value
                OnPropertyChanged("USU_ID_AUT")
            End If
        End Set
    End Property

    Private _uSU_ID_AUT As String

    <DataMember()>
    Public Property ORD_FEC_AUT() As Nullable(Of Date)
        Get
            Return _oRD_FEC_AUT
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_oRD_FEC_AUT, value) Then
                _oRD_FEC_AUT = value
                OnPropertyChanged("ORD_FEC_AUT")
            End If
        End Set
    End Property

    Private _oRD_FEC_AUT As Nullable(Of Date)

    <DataMember()>
    Public Property ORD_RECHAZADO() As Nullable(Of Integer)
        Get
            Return _oRD_RECHAZADO
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oRD_RECHAZADO, value) Then
                _oRD_RECHAZADO = value
                OnPropertyChanged("ORD_RECHAZADO")
            End If
        End Set
    End Property

    Private _oRD_RECHAZADO As Nullable(Of Integer)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Articulos() As Articulos
        Get
            Return _articulos
        End Get
        Set(ByVal value As Articulos)
            If _articulos IsNot value Then
                Dim previousValue As Articulos = _articulos
                _articulos = value
                FixupArticulos(previousValue)
                OnNavigationPropertyChanged("Articulos")
            End If
        End Set
    End Property

    Private _articulos As Articulos


    <DataMember()>
    Public Property Entidad() As Entidad
        Get
            Return _entidad
        End Get
        Set(ByVal value As Entidad)
            If _entidad IsNot value Then
                Dim previousValue As Entidad = _entidad
                _entidad = value
                FixupEntidad(previousValue)
                OnNavigationPropertyChanged("Entidad")
            End If
        End Set
    End Property

    Private _entidad As Entidad


    <DataMember()>
    Public Property OrdenTrabajo() As OrdenTrabajo
        Get
            Return _ordenTrabajo
        End Get
        Set(ByVal value As OrdenTrabajo)
            If _ordenTrabajo IsNot value Then
                Dim previousValue As OrdenTrabajo = _ordenTrabajo
                _ordenTrabajo = value
                FixupOrdenTrabajo(previousValue)
                OnNavigationPropertyChanged("OrdenTrabajo")
            End If
        End Set
    End Property

    Private _ordenTrabajo As OrdenTrabajo


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
        Articulos = Nothing
        Entidad = Nothing
        OrdenTrabajo = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupArticulos(ByVal previousValue As Articulos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Articulos IsNot Nothing Then
            ART_ID = Articulos.ART_ID
        ElseIf Not skipKeys Then
            ART_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Articulos") AndAlso
                ChangeTracker.OriginalValues("Articulos") Is Articulos Then
                ChangeTracker.OriginalValues.Remove("Articulos")
            Else
                ChangeTracker.RecordOriginalValue("Articulos", previousValue)
            End If
            If Articulos IsNot Nothing AndAlso Not Articulos.ChangeTracker.ChangeTrackingEnabled Then
                Articulos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupEntidad(ByVal previousValue As Entidad)
        If IsDeserializing Then
            Return
        End If

        If Entidad IsNot Nothing Then
            ENO_ID = Entidad.ENO_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Entidad") AndAlso
                ChangeTracker.OriginalValues("Entidad") Is Entidad Then
                ChangeTracker.OriginalValues.Remove("Entidad")
            Else
                ChangeTracker.RecordOriginalValue("Entidad", previousValue)
            End If
            If Entidad IsNot Nothing AndAlso Not Entidad.ChangeTracker.ChangeTrackingEnabled Then
                Entidad.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupOrdenTrabajo(ByVal previousValue As OrdenTrabajo, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.OrdenRequerimientoDetalle.Contains(Me) Then
            previousValue.OrdenRequerimientoDetalle.Remove(Me)
        End If

        If OrdenTrabajo IsNot Nothing Then
            If Not OrdenTrabajo.OrdenRequerimientoDetalle.Contains(Me) Then
                OrdenTrabajo.OrdenRequerimientoDetalle.Add(Me)
            End If

            OTR_ID = OrdenTrabajo.OTR_ID
        ElseIf Not skipKeys Then
            OTR_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("OrdenTrabajo") AndAlso
                ChangeTracker.OriginalValues("OrdenTrabajo") Is OrdenTrabajo Then
                ChangeTracker.OriginalValues.Remove("OrdenTrabajo")
            Else
                ChangeTracker.RecordOriginalValue("OrdenTrabajo", previousValue)
            End If
            If OrdenTrabajo IsNot Nothing AndAlso Not OrdenTrabajo.ChangeTracker.ChangeTrackingEnabled Then
                OrdenTrabajo.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class

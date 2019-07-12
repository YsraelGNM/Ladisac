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
<KnownType(GetType(ControlQuema))>
<KnownType(GetType(SalidaSecadero))>
<KnownType(GetType(ArticuloAlmacen))>
<KnownType(GetType(DocuMovimiento))>
Partial Public Class ConsumoCombustible
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared CCO_ID As string = "CCO_ID"
				public shared COQ_ID As string = "COQ_ID"
				public shared SSE_ID As string = "SSE_ID"
				public shared ARA_ID As string = "ARA_ID"
				public shared ALM_ID As string = "ALM_ID"
				public shared ART_ID As string = "ART_ID"
				public shared CCO_FECHA As string = "CCO_FECHA"
				public shared CCO_CANTIDAD As string = "CCO_CANTIDAD"
				public shared CCO_GLOSA As string = "CCO_GLOSA"
				public shared USU_ID As string = "USU_ID"
				public shared CCO_FEC_GRAB As string = "CCO_FEC_GRAB"
				public shared CCO_ESTADO As string = "CCO_ESTADO"
				public shared CCO_INGRESO_SALIDA As string = "CCO_INGRESO_SALIDA"
		    End Structure
	



    <DataMember()>
    Public Property CCO_ID() As Integer
        Get
            Return _cCO_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_cCO_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'CCO_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _cCO_ID = value
                OnPropertyChanged("CCO_ID")
            End If
        End Set
    End Property

    Private _cCO_ID As Integer

    <DataMember()>
    Public Property COQ_ID() As Nullable(Of Integer)
        Get
            Return _cOQ_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cOQ_ID, value) Then
                ChangeTracker.RecordOriginalValue("COQ_ID", _cOQ_ID)
                If Not IsDeserializing Then
                    If ControlQuema IsNot Nothing AndAlso Not Equals(ControlQuema.COQ_ID, value) Then
                        ControlQuema = Nothing
                    End If
                End If
                _cOQ_ID = value
                OnPropertyChanged("COQ_ID")
            End If
        End Set
    End Property

    Private _cOQ_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property SSE_ID() As Nullable(Of Integer)
        Get
            Return _sSE_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_sSE_ID, value) Then
                ChangeTracker.RecordOriginalValue("SSE_ID", _sSE_ID)
                If Not IsDeserializing Then
                    If SalidaSecadero IsNot Nothing AndAlso Not Equals(SalidaSecadero.SSE_ID, value) Then
                        SalidaSecadero = Nothing
                    End If
                End If
                _sSE_ID = value
                OnPropertyChanged("SSE_ID")
            End If
        End Set
    End Property

    Private _sSE_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ARA_ID() As Nullable(Of Integer)
        Get
            Return _aRA_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aRA_ID, value) Then
                ChangeTracker.RecordOriginalValue("ARA_ID", _aRA_ID)
                If Not IsDeserializing Then
                    If ArticuloAlmacen IsNot Nothing AndAlso Not Equals(ArticuloAlmacen.ARA_ID, value) Then
                        ArticuloAlmacen = Nothing
                    End If
                End If
                _aRA_ID = value
                OnPropertyChanged("ARA_ID")
            End If
        End Set
    End Property

    Private _aRA_ID As Nullable(Of Integer)

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
    Public Property ART_ID() As String
        Get
            Return _aRT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_aRT_ID, value) Then
                _aRT_ID = value
                OnPropertyChanged("ART_ID")
            End If
        End Set
    End Property

    Private _aRT_ID As String

    <DataMember()>
    Public Property CCO_FECHA() As Nullable(Of Date)
        Get
            Return _cCO_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_cCO_FECHA, value) Then
                _cCO_FECHA = value
                OnPropertyChanged("CCO_FECHA")
            End If
        End Set
    End Property

    Private _cCO_FECHA As Nullable(Of Date)

    <DataMember()>
    Public Property CCO_CANTIDAD() As Nullable(Of Decimal)
        Get
            Return _cCO_CANTIDAD
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_cCO_CANTIDAD, value) Then
                _cCO_CANTIDAD = value
                OnPropertyChanged("CCO_CANTIDAD")
            End If
        End Set
    End Property

    Private _cCO_CANTIDAD As Nullable(Of Decimal)

    <DataMember()>
    Public Property CCO_GLOSA() As String
        Get
            Return _cCO_GLOSA
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCO_GLOSA, value) Then
                _cCO_GLOSA = value
                OnPropertyChanged("CCO_GLOSA")
            End If
        End Set
    End Property

    Private _cCO_GLOSA As String

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
    Public Property CCO_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _cCO_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_cCO_FEC_GRAB, value) Then
                _cCO_FEC_GRAB = value
                OnPropertyChanged("CCO_FEC_GRAB")
            End If
        End Set
    End Property

    Private _cCO_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property CCO_ESTADO() As Nullable(Of Boolean)
        Get
            Return _cCO_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_cCO_ESTADO, value) Then
                _cCO_ESTADO = value
                OnPropertyChanged("CCO_ESTADO")
            End If
        End Set
    End Property

    Private _cCO_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property CCO_INGRESO_SALIDA() As Nullable(Of Boolean)
        Get
            Return _cCO_INGRESO_SALIDA
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_cCO_INGRESO_SALIDA, value) Then
                _cCO_INGRESO_SALIDA = value
                OnPropertyChanged("CCO_INGRESO_SALIDA")
            End If
        End Set
    End Property

    Private _cCO_INGRESO_SALIDA As Nullable(Of Boolean)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property ControlQuema() As ControlQuema
        Get
            Return _controlQuema
        End Get
        Set(ByVal value As ControlQuema)
            If _controlQuema IsNot value Then
                Dim previousValue As ControlQuema = _controlQuema
                _controlQuema = value
                FixupControlQuema(previousValue)
                OnNavigationPropertyChanged("ControlQuema")
            End If
        End Set
    End Property

    Private _controlQuema As ControlQuema


    <DataMember()>
    Public Property SalidaSecadero() As SalidaSecadero
        Get
            Return _salidaSecadero
        End Get
        Set(ByVal value As SalidaSecadero)
            If _salidaSecadero IsNot value Then
                Dim previousValue As SalidaSecadero = _salidaSecadero
                _salidaSecadero = value
                FixupSalidaSecadero(previousValue)
                OnNavigationPropertyChanged("SalidaSecadero")
            End If
        End Set
    End Property

    Private _salidaSecadero As SalidaSecadero


    <DataMember()>
    Public Property ArticuloAlmacen() As ArticuloAlmacen
        Get
            Return _articuloAlmacen
        End Get
        Set(ByVal value As ArticuloAlmacen)
            If _articuloAlmacen IsNot value Then
                Dim previousValue As ArticuloAlmacen = _articuloAlmacen
                _articuloAlmacen = value
                FixupArticuloAlmacen(previousValue)
                OnNavigationPropertyChanged("ArticuloAlmacen")
            End If
        End Set
    End Property

    Private _articuloAlmacen As ArticuloAlmacen


    <DataMember()>
    Public Property DocuMovimiento() As TrackableCollection(Of DocuMovimiento)
        Get
            If _docuMovimiento Is Nothing Then
                _docuMovimiento = New TrackableCollection(Of DocuMovimiento)
                AddHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
            End If
            Return _docuMovimiento
        End Get
        Set(ByVal value As TrackableCollection(Of DocuMovimiento))
            If Not Object.ReferenceEquals(_docuMovimiento, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _docuMovimiento IsNot Nothing Then
                    RemoveHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
                End If
                _docuMovimiento = value
                If _docuMovimiento IsNot Nothing Then
                    AddHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
                End If
                OnNavigationPropertyChanged("DocuMovimiento")
            End If
        End Set
    End Property

    Private _docuMovimiento As TrackableCollection(Of DocuMovimiento)

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
        ControlQuema = Nothing
        SalidaSecadero = Nothing
        ArticuloAlmacen = Nothing
        DocuMovimiento.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupControlQuema(ByVal previousValue As ControlQuema, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If ControlQuema IsNot Nothing Then
            COQ_ID = ControlQuema.COQ_ID
        ElseIf Not skipKeys Then
            COQ_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ControlQuema") AndAlso
                ChangeTracker.OriginalValues("ControlQuema") Is ControlQuema Then
                ChangeTracker.OriginalValues.Remove("ControlQuema")
            Else
                ChangeTracker.RecordOriginalValue("ControlQuema", previousValue)
            End If
            If ControlQuema IsNot Nothing AndAlso Not ControlQuema.ChangeTracker.ChangeTrackingEnabled Then
                ControlQuema.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupSalidaSecadero(ByVal previousValue As SalidaSecadero, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If SalidaSecadero IsNot Nothing Then
            SSE_ID = SalidaSecadero.SSE_ID
        ElseIf Not skipKeys Then
            SSE_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("SalidaSecadero") AndAlso
                ChangeTracker.OriginalValues("SalidaSecadero") Is SalidaSecadero Then
                ChangeTracker.OriginalValues.Remove("SalidaSecadero")
            Else
                ChangeTracker.RecordOriginalValue("SalidaSecadero", previousValue)
            End If
            If SalidaSecadero IsNot Nothing AndAlso Not SalidaSecadero.ChangeTracker.ChangeTrackingEnabled Then
                SalidaSecadero.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupArticuloAlmacen(ByVal previousValue As ArticuloAlmacen, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If ArticuloAlmacen IsNot Nothing Then
            ARA_ID = ArticuloAlmacen.ARA_ID
        ElseIf Not skipKeys Then
            ARA_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ArticuloAlmacen") AndAlso
                ChangeTracker.OriginalValues("ArticuloAlmacen") Is ArticuloAlmacen Then
                ChangeTracker.OriginalValues.Remove("ArticuloAlmacen")
            Else
                ChangeTracker.RecordOriginalValue("ArticuloAlmacen", previousValue)
            End If
            If ArticuloAlmacen IsNot Nothing AndAlso Not ArticuloAlmacen.ChangeTracker.ChangeTrackingEnabled Then
                ArticuloAlmacen.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupDocuMovimiento(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DocuMovimiento In e.NewItems
                item.CCO_ID = CCO_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DocuMovimiento In e.OldItems
                item.CCO_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
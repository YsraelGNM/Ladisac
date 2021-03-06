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
<KnownType(GetType(OrdenRequerimiento))>
<KnownType(GetType(Articulos))>
<KnownType(GetType(DetalleTipoDocumentos))>
<KnownType(GetType(Personas))>
<KnownType(GetType(Almacen))>
<KnownType(GetType(UnidadesTransporte))>
<KnownType(GetType(DocuMovimiento))>
<KnownType(GetType(RegistroEquipo))>
Partial Public Class SalidaCombustible
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared SCO_ID As string = "SCO_ID"
				public shared TDO_ID As string = "TDO_ID"
				public shared DTD_ID As string = "DTD_ID"
				public shared UNT_ID As string = "UNT_ID"
				public shared ORR_ID As string = "ORR_ID"
				public shared ORD_ID As string = "ORD_ID"
				public shared SCO_FECHA As string = "SCO_FECHA"
				public shared PER_ID_EMPRESA As string = "PER_ID_EMPRESA"
				public shared PER_ID_CHOFER As string = "PER_ID_CHOFER"
				public shared ALM_ID As string = "ALM_ID"
				public shared ART_ID As string = "ART_ID"
				public shared SCO_CANTIDAD As string = "SCO_CANTIDAD"
				public shared SCO_KILOMETRAJE As string = "SCO_KILOMETRAJE"
				public shared SCO_HOROMETRO As string = "SCO_HOROMETRO"
				public shared SCO_OBSERVACION As string = "SCO_OBSERVACION"
				public shared USU_ID As string = "USU_ID"
				public shared SCO_FEC_GRAB As string = "SCO_FEC_GRAB"
				public shared SCO_ESTADO As string = "SCO_ESTADO"
				public shared CCT_ID As string = "CCT_ID"
				public shared SCO_SERIE As string = "SCO_SERIE"
				public shared SCO_NUMERO As string = "SCO_NUMERO"
				public shared SCO_PRECIO_UNITARIO As string = "SCO_PRECIO_UNITARIO"
				public shared SCO_SERIE_SUNAT As string = "SCO_SERIE_SUNAT"
		    End Structure
	



    <DataMember()>
    Public Property SCO_ID() As Integer
        Get
            Return _sCO_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_sCO_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'SCO_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _sCO_ID = value
                OnPropertyChanged("SCO_ID")
            End If
        End Set
    End Property

    Private _sCO_ID As Integer

    <DataMember()>
    Public Property TDO_ID() As String
        Get
            Return _tDO_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDO_ID, value) Then
                _tDO_ID = value
                OnPropertyChanged("TDO_ID")
            End If
        End Set
    End Property

    Private _tDO_ID As String

    <DataMember()>
    Public Property DTD_ID() As String
        Get
            Return _dTD_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTD_ID, value) Then
                ChangeTracker.RecordOriginalValue("DTD_ID", _dTD_ID)
                If Not IsDeserializing Then
                    If DetalleTipoDocumentos IsNot Nothing AndAlso Not Equals(DetalleTipoDocumentos.DTD_ID, value) Then
                        DetalleTipoDocumentos = Nothing
                    End If
                End If
                _dTD_ID = value
                OnPropertyChanged("DTD_ID")
            End If
        End Set
    End Property

    Private _dTD_ID As String

    <DataMember()>
    Public Property UNT_ID() As String
        Get
            Return _uNT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uNT_ID, value) Then
                ChangeTracker.RecordOriginalValue("UNT_ID", _uNT_ID)
                If Not IsDeserializing Then
                    If UnidadesTransporte IsNot Nothing AndAlso Not Equals(UnidadesTransporte.UNT_ID, value) Then
                        UnidadesTransporte = Nothing
                    End If
                End If
                _uNT_ID = value
                OnPropertyChanged("UNT_ID")
            End If
        End Set
    End Property

    Private _uNT_ID As String

    <DataMember()>
    Public Property ORR_ID() As Nullable(Of Integer)
        Get
            Return _oRR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oRR_ID, value) Then
                ChangeTracker.RecordOriginalValue("ORR_ID", _oRR_ID)
                If Not IsDeserializing Then
                    If OrdenRequerimiento IsNot Nothing AndAlso Not Equals(OrdenRequerimiento.ORR_ID, value) Then
                        OrdenRequerimiento = Nothing
                    End If
                End If
                _oRR_ID = value
                OnPropertyChanged("ORR_ID")
            End If
        End Set
    End Property

    Private _oRR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ORD_ID() As Nullable(Of Integer)
        Get
            Return _oRD_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oRD_ID, value) Then
                _oRD_ID = value
                OnPropertyChanged("ORD_ID")
            End If
        End Set
    End Property

    Private _oRD_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property SCO_FECHA() As Nullable(Of Date)
        Get
            Return _sCO_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_sCO_FECHA, value) Then
                _sCO_FECHA = value
                OnPropertyChanged("SCO_FECHA")
            End If
        End Set
    End Property

    Private _sCO_FECHA As Nullable(Of Date)

    <DataMember()>
    Public Property PER_ID_EMPRESA() As String
        Get
            Return _pER_ID_EMPRESA
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_EMPRESA, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_EMPRESA", _pER_ID_EMPRESA)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID_EMPRESA = value
                OnPropertyChanged("PER_ID_EMPRESA")
            End If
        End Set
    End Property

    Private _pER_ID_EMPRESA As String

    <DataMember()>
    Public Property PER_ID_CHOFER() As String
        Get
            Return _pER_ID_CHOFER
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_CHOFER, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_CHOFER", _pER_ID_CHOFER)
                If Not IsDeserializing Then
                    If Personas1 IsNot Nothing AndAlso Not Equals(Personas1.PER_ID, value) Then
                        Personas1 = Nothing
                    End If
                End If
                _pER_ID_CHOFER = value
                OnPropertyChanged("PER_ID_CHOFER")
            End If
        End Set
    End Property

    Private _pER_ID_CHOFER As String

    <DataMember()>
    Public Property ALM_ID() As Nullable(Of Integer)
        Get
            Return _aLM_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aLM_ID, value) Then
                ChangeTracker.RecordOriginalValue("ALM_ID", _aLM_ID)
                If Not IsDeserializing Then
                    If Almacen IsNot Nothing AndAlso Not Equals(Almacen.ALM_ID, value) Then
                        Almacen = Nothing
                    End If
                End If
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
    Public Property SCO_CANTIDAD() As Nullable(Of Decimal)
        Get
            Return _sCO_CANTIDAD
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_sCO_CANTIDAD, value) Then
                _sCO_CANTIDAD = value
                OnPropertyChanged("SCO_CANTIDAD")
            End If
        End Set
    End Property

    Private _sCO_CANTIDAD As Nullable(Of Decimal)

    <DataMember()>
    Public Property SCO_KILOMETRAJE() As Nullable(Of Decimal)
        Get
            Return _sCO_KILOMETRAJE
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_sCO_KILOMETRAJE, value) Then
                _sCO_KILOMETRAJE = value
                OnPropertyChanged("SCO_KILOMETRAJE")
            End If
        End Set
    End Property

    Private _sCO_KILOMETRAJE As Nullable(Of Decimal)

    <DataMember()>
    Public Property SCO_HOROMETRO() As Nullable(Of Decimal)
        Get
            Return _sCO_HOROMETRO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_sCO_HOROMETRO, value) Then
                _sCO_HOROMETRO = value
                OnPropertyChanged("SCO_HOROMETRO")
            End If
        End Set
    End Property

    Private _sCO_HOROMETRO As Nullable(Of Decimal)

    <DataMember()>
    Public Property SCO_OBSERVACION() As String
        Get
            Return _sCO_OBSERVACION
        End Get
        Set(ByVal value As String)
            If Not Equals(_sCO_OBSERVACION, value) Then
                _sCO_OBSERVACION = value
                OnPropertyChanged("SCO_OBSERVACION")
            End If
        End Set
    End Property

    Private _sCO_OBSERVACION As String

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
    Public Property SCO_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _sCO_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_sCO_FEC_GRAB, value) Then
                _sCO_FEC_GRAB = value
                OnPropertyChanged("SCO_FEC_GRAB")
            End If
        End Set
    End Property

    Private _sCO_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property SCO_ESTADO() As Nullable(Of Boolean)
        Get
            Return _sCO_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_sCO_ESTADO, value) Then
                _sCO_ESTADO = value
                OnPropertyChanged("SCO_ESTADO")
            End If
        End Set
    End Property

    Private _sCO_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property CCT_ID() As String
        Get
            Return _cCT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCT_ID, value) Then
                _cCT_ID = value
                OnPropertyChanged("CCT_ID")
            End If
        End Set
    End Property

    Private _cCT_ID As String

    <DataMember()>
    Public Property SCO_SERIE() As String
        Get
            Return _sCO_SERIE
        End Get
        Set(ByVal value As String)
            If Not Equals(_sCO_SERIE, value) Then
                _sCO_SERIE = value
                OnPropertyChanged("SCO_SERIE")
            End If
        End Set
    End Property

    Private _sCO_SERIE As String

    <DataMember()>
    Public Property SCO_NUMERO() As String
        Get
            Return _sCO_NUMERO
        End Get
        Set(ByVal value As String)
            If Not Equals(_sCO_NUMERO, value) Then
                _sCO_NUMERO = value
                OnPropertyChanged("SCO_NUMERO")
            End If
        End Set
    End Property

    Private _sCO_NUMERO As String

    <DataMember()>
    Public Property SCO_PRECIO_UNITARIO() As Nullable(Of Decimal)
        Get
            Return _sCO_PRECIO_UNITARIO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_sCO_PRECIO_UNITARIO, value) Then
                _sCO_PRECIO_UNITARIO = value
                OnPropertyChanged("SCO_PRECIO_UNITARIO")
            End If
        End Set
    End Property

    Private _sCO_PRECIO_UNITARIO As Nullable(Of Decimal)

    <DataMember()>
    Public Property SCO_SERIE_SUNAT() As String
        Get
            Return _sCO_SERIE_SUNAT
        End Get
        Set(ByVal value As String)
            If Not Equals(_sCO_SERIE_SUNAT, value) Then
                _sCO_SERIE_SUNAT = value
                OnPropertyChanged("SCO_SERIE_SUNAT")
            End If
        End Set
    End Property

    Private _sCO_SERIE_SUNAT As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property OrdenRequerimiento() As OrdenRequerimiento
        Get
            Return _ordenRequerimiento
        End Get
        Set(ByVal value As OrdenRequerimiento)
            If _ordenRequerimiento IsNot value Then
                Dim previousValue As OrdenRequerimiento = _ordenRequerimiento
                _ordenRequerimiento = value
                FixupOrdenRequerimiento(previousValue)
                OnNavigationPropertyChanged("OrdenRequerimiento")
            End If
        End Set
    End Property

    Private _ordenRequerimiento As OrdenRequerimiento


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
    Public Property DetalleTipoDocumentos() As DetalleTipoDocumentos
        Get
            Return _detalleTipoDocumentos
        End Get
        Set(ByVal value As DetalleTipoDocumentos)
            If _detalleTipoDocumentos IsNot value Then
                Dim previousValue As DetalleTipoDocumentos = _detalleTipoDocumentos
                _detalleTipoDocumentos = value
                FixupDetalleTipoDocumentos(previousValue)
                OnNavigationPropertyChanged("DetalleTipoDocumentos")
            End If
        End Set
    End Property

    Private _detalleTipoDocumentos As DetalleTipoDocumentos


    <DataMember()>
    Public Property Personas() As Personas
        Get
            Return _personas
        End Get
        Set(ByVal value As Personas)
            If _personas IsNot value Then
                Dim previousValue As Personas = _personas
                _personas = value
                FixupPersonas(previousValue)
                OnNavigationPropertyChanged("Personas")
            End If
        End Set
    End Property

    Private _personas As Personas


    <DataMember()>
    Public Property Personas1() As Personas
        Get
            Return _personas1
        End Get
        Set(ByVal value As Personas)
            If _personas1 IsNot value Then
                Dim previousValue As Personas = _personas1
                _personas1 = value
                FixupPersonas1(previousValue)
                OnNavigationPropertyChanged("Personas1")
            End If
        End Set
    End Property

    Private _personas1 As Personas


    <DataMember()>
    Public Property Almacen() As Almacen
        Get
            Return _almacen
        End Get
        Set(ByVal value As Almacen)
            If _almacen IsNot value Then
                Dim previousValue As Almacen = _almacen
                _almacen = value
                FixupAlmacen(previousValue)
                OnNavigationPropertyChanged("Almacen")
            End If
        End Set
    End Property

    Private _almacen As Almacen


    <DataMember()>
    Public Property UnidadesTransporte() As UnidadesTransporte
        Get
            Return _unidadesTransporte
        End Get
        Set(ByVal value As UnidadesTransporte)
            If _unidadesTransporte IsNot value Then
                Dim previousValue As UnidadesTransporte = _unidadesTransporte
                _unidadesTransporte = value
                FixupUnidadesTransporte(previousValue)
                OnNavigationPropertyChanged("UnidadesTransporte")
            End If
        End Set
    End Property

    Private _unidadesTransporte As UnidadesTransporte


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

    <DataMember()>
    Public Property RegistroEquipo() As TrackableCollection(Of RegistroEquipo)
        Get
            If _registroEquipo Is Nothing Then
                _registroEquipo = New TrackableCollection(Of RegistroEquipo)
                AddHandler _registroEquipo.CollectionChanged, AddressOf FixupRegistroEquipo
            End If
            Return _registroEquipo
        End Get
        Set(ByVal value As TrackableCollection(Of RegistroEquipo))
            If Not Object.ReferenceEquals(_registroEquipo, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _registroEquipo IsNot Nothing Then
                    RemoveHandler _registroEquipo.CollectionChanged, AddressOf FixupRegistroEquipo
                End If
                _registroEquipo = value
                If _registroEquipo IsNot Nothing Then
                    AddHandler _registroEquipo.CollectionChanged, AddressOf FixupRegistroEquipo
                End If
                OnNavigationPropertyChanged("RegistroEquipo")
            End If
        End Set
    End Property

    Private _registroEquipo As TrackableCollection(Of RegistroEquipo)

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
        OrdenRequerimiento = Nothing
        Articulos = Nothing
        DetalleTipoDocumentos = Nothing
        Personas = Nothing
        Personas1 = Nothing
        Almacen = Nothing
        UnidadesTransporte = Nothing
        DocuMovimiento.Clear()
        RegistroEquipo.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupOrdenRequerimiento(ByVal previousValue As OrdenRequerimiento, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If OrdenRequerimiento IsNot Nothing Then
            ORR_ID = OrdenRequerimiento.ORR_ID
        ElseIf Not skipKeys Then
            ORR_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("OrdenRequerimiento") AndAlso
                ChangeTracker.OriginalValues("OrdenRequerimiento") Is OrdenRequerimiento Then
                ChangeTracker.OriginalValues.Remove("OrdenRequerimiento")
            Else
                ChangeTracker.RecordOriginalValue("OrdenRequerimiento", previousValue)
            End If
            If OrdenRequerimiento IsNot Nothing AndAlso Not OrdenRequerimiento.ChangeTracker.ChangeTrackingEnabled Then
                OrdenRequerimiento.StartTracking()
            End If
        End If
    End Sub

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

    Private Sub FixupDetalleTipoDocumentos(ByVal previousValue As DetalleTipoDocumentos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If DetalleTipoDocumentos IsNot Nothing Then
            DTD_ID = DetalleTipoDocumentos.DTD_ID
        ElseIf Not skipKeys Then
            DTD_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("DetalleTipoDocumentos") AndAlso
                ChangeTracker.OriginalValues("DetalleTipoDocumentos") Is DetalleTipoDocumentos Then
                ChangeTracker.OriginalValues.Remove("DetalleTipoDocumentos")
            Else
                ChangeTracker.RecordOriginalValue("DetalleTipoDocumentos", previousValue)
            End If
            If DetalleTipoDocumentos IsNot Nothing AndAlso Not DetalleTipoDocumentos.ChangeTracker.ChangeTrackingEnabled Then
                DetalleTipoDocumentos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupPersonas(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Personas IsNot Nothing Then
            PER_ID_EMPRESA = Personas.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_EMPRESA = Nothing
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

    Private Sub FixupPersonas1(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Personas1 IsNot Nothing Then
            PER_ID_CHOFER = Personas1.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_CHOFER = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Personas1") AndAlso
                ChangeTracker.OriginalValues("Personas1") Is Personas1 Then
                ChangeTracker.OriginalValues.Remove("Personas1")
            Else
                ChangeTracker.RecordOriginalValue("Personas1", previousValue)
            End If
            If Personas1 IsNot Nothing AndAlso Not Personas1.ChangeTracker.ChangeTrackingEnabled Then
                Personas1.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupAlmacen(ByVal previousValue As Almacen, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Almacen IsNot Nothing Then
            ALM_ID = Almacen.ALM_ID
        ElseIf Not skipKeys Then
            ALM_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Almacen") AndAlso
                ChangeTracker.OriginalValues("Almacen") Is Almacen Then
                ChangeTracker.OriginalValues.Remove("Almacen")
            Else
                ChangeTracker.RecordOriginalValue("Almacen", previousValue)
            End If
            If Almacen IsNot Nothing AndAlso Not Almacen.ChangeTracker.ChangeTrackingEnabled Then
                Almacen.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupUnidadesTransporte(ByVal previousValue As UnidadesTransporte, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If UnidadesTransporte IsNot Nothing Then
            UNT_ID = UnidadesTransporte.UNT_ID
        ElseIf Not skipKeys Then
            UNT_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("UnidadesTransporte") AndAlso
                ChangeTracker.OriginalValues("UnidadesTransporte") Is UnidadesTransporte Then
                ChangeTracker.OriginalValues.Remove("UnidadesTransporte")
            Else
                ChangeTracker.RecordOriginalValue("UnidadesTransporte", previousValue)
            End If
            If UnidadesTransporte IsNot Nothing AndAlso Not UnidadesTransporte.ChangeTracker.ChangeTrackingEnabled Then
                UnidadesTransporte.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupDocuMovimiento(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DocuMovimiento In e.NewItems
                item.SCO_ID = SCO_ID
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
                item.SCO_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupRegistroEquipo(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As RegistroEquipo In e.NewItems
                item.SalidaCombustible = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("RegistroEquipo", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As RegistroEquipo In e.OldItems
                If ReferenceEquals(item.SalidaCombustible, Me) Then
                    item.SalidaCombustible = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("RegistroEquipo", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

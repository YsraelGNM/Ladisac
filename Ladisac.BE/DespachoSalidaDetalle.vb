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
<KnownType(GetType(DetalleDespachos))>
Partial Public Class DespachoSalidaDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DSD_ID As string = "DSD_ID"
				public shared DSA_ID As string = "DSA_ID"
				public shared TDO_ID As string = "TDO_ID"
				public shared DTD_ID As string = "DTD_ID"
				public shared DSD_SERIE As string = "DSD_SERIE"
				public shared DSD_NUMERO As string = "DSD_NUMERO"
				public shared DSD_ITEM As string = "DSD_ITEM"
				public shared ART_ID_ORIGINAL As string = "ART_ID_ORIGINAL"
				public shared ART_ID As string = "ART_ID"
				public shared DSD_CANTIDAD As string = "DSD_CANTIDAD"
		    End Structure
	



    <DataMember()>
    Public Property DSD_ID() As Integer
        Get
            Return _dSD_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dSD_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DSD_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dSD_ID = value
                OnPropertyChanged("DSD_ID")
            End If
        End Set
    End Property

    Private _dSD_ID As Integer

    <DataMember()>
    Public Property DSA_ID() As Nullable(Of Integer)
        Get
            Return _dSA_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dSA_ID, value) Then
                ChangeTracker.RecordOriginalValue("DSA_ID", _dSA_ID)
                _dSA_ID = value
                OnPropertyChanged("DSA_ID")
            End If
        End Set
    End Property

    Private _dSA_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property TDO_ID() As String
        Get
            Return _tDO_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDO_ID, value) Then
                ChangeTracker.RecordOriginalValue("TDO_ID", _tDO_ID)
                If Not IsDeserializing Then
                    If DetalleDespachos IsNot Nothing AndAlso Not Equals(DetalleDespachos.TDO_ID, value) Then
                        Dim previousValue As DetalleDespachos = _detalleDespachos
                        _detalleDespachos = Nothing
                        FixupDetalleDespachos(previousValue, skipKeys:=True)
                        OnNavigationPropertyChanged("DetalleDespachos")
                    End If
                End If
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
                    If DetalleDespachos IsNot Nothing AndAlso Not Equals(DetalleDespachos.DTD_ID, value) Then
                        Dim previousValue As DetalleDespachos = _detalleDespachos
                        _detalleDespachos = Nothing
                        FixupDetalleDespachos(previousValue, skipKeys:=True)
                        OnNavigationPropertyChanged("DetalleDespachos")
                    End If
                End If
                _dTD_ID = value
                OnPropertyChanged("DTD_ID")
            End If
        End Set
    End Property

    Private _dTD_ID As String

    <DataMember()>
    Public Property DSD_SERIE() As String
        Get
            Return _dSD_SERIE
        End Get
        Set(ByVal value As String)
            If Not Equals(_dSD_SERIE, value) Then
                ChangeTracker.RecordOriginalValue("DSD_SERIE", _dSD_SERIE)
                If Not IsDeserializing Then
                    If DetalleDespachos IsNot Nothing AndAlso Not Equals(DetalleDespachos.DDE_SERIE, value) Then
                        Dim previousValue As DetalleDespachos = _detalleDespachos
                        _detalleDespachos = Nothing
                        FixupDetalleDespachos(previousValue, skipKeys:=True)
                        OnNavigationPropertyChanged("DetalleDespachos")
                    End If
                End If
                _dSD_SERIE = value
                OnPropertyChanged("DSD_SERIE")
            End If
        End Set
    End Property

    Private _dSD_SERIE As String

    <DataMember()>
    Public Property DSD_NUMERO() As String
        Get
            Return _dSD_NUMERO
        End Get
        Set(ByVal value As String)
            If Not Equals(_dSD_NUMERO, value) Then
                ChangeTracker.RecordOriginalValue("DSD_NUMERO", _dSD_NUMERO)
                If Not IsDeserializing Then
                    If DetalleDespachos IsNot Nothing AndAlso Not Equals(DetalleDespachos.DDE_NUMERO, value) Then
                        Dim previousValue As DetalleDespachos = _detalleDespachos
                        _detalleDespachos = Nothing
                        FixupDetalleDespachos(previousValue, skipKeys:=True)
                        OnNavigationPropertyChanged("DetalleDespachos")
                    End If
                End If
                _dSD_NUMERO = value
                OnPropertyChanged("DSD_NUMERO")
            End If
        End Set
    End Property

    Private _dSD_NUMERO As String

    <DataMember()>
    Public Property DSD_ITEM() As Nullable(Of Decimal)
        Get
            Return _dSD_ITEM
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dSD_ITEM, value) Then
                ChangeTracker.RecordOriginalValue("DSD_ITEM", _dSD_ITEM)
                If Not IsDeserializing Then
                    If DetalleDespachos IsNot Nothing AndAlso Not Equals(DetalleDespachos.DDE_ITEM, value) Then
                        Dim previousValue As DetalleDespachos = _detalleDespachos
                        _detalleDespachos = Nothing
                        FixupDetalleDespachos(previousValue, skipKeys:=True)
                        OnNavigationPropertyChanged("DetalleDespachos")
                    End If
                End If
                _dSD_ITEM = value
                OnPropertyChanged("DSD_ITEM")
            End If
        End Set
    End Property

    Private _dSD_ITEM As Nullable(Of Decimal)

    <DataMember()>
    Public Property ART_ID_ORIGINAL() As String
        Get
            Return _aRT_ID_ORIGINAL
        End Get
        Set(ByVal value As String)
            If Not Equals(_aRT_ID_ORIGINAL, value) Then
                _aRT_ID_ORIGINAL = value
                OnPropertyChanged("ART_ID_ORIGINAL")
            End If
        End Set
    End Property

    Private _aRT_ID_ORIGINAL As String

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
    Public Property DSD_CANTIDAD() As Nullable(Of Decimal)
        Get
            Return _dSD_CANTIDAD
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dSD_CANTIDAD, value) Then
                _dSD_CANTIDAD = value
                OnPropertyChanged("DSD_CANTIDAD")
            End If
        End Set
    End Property

    Private _dSD_CANTIDAD As Nullable(Of Decimal)

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
    Public Property DetalleDespachos() As DetalleDespachos
        Get
            Return _detalleDespachos
        End Get
        Set(ByVal value As DetalleDespachos)
            If _detalleDespachos IsNot value Then
                Dim previousValue As DetalleDespachos = _detalleDespachos
                _detalleDespachos = value
                FixupDetalleDespachos(previousValue)
                OnNavigationPropertyChanged("DetalleDespachos")
            End If
        End Set
    End Property

    Private _detalleDespachos As DetalleDespachos


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
        DetalleDespachos = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupArticulos(ByVal previousValue As Articulos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DespachoSalidaDetalle.Contains(Me) Then
            previousValue.DespachoSalidaDetalle.Remove(Me)
        End If

        If Articulos IsNot Nothing Then
            If Not Articulos.DespachoSalidaDetalle.Contains(Me) Then
                Articulos.DespachoSalidaDetalle.Add(Me)
            End If

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

    Private Sub FixupDetalleDespachos(ByVal previousValue As DetalleDespachos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DespachoSalidaDetalle.Contains(Me) Then
            previousValue.DespachoSalidaDetalle.Remove(Me)
        End If

        If DetalleDespachos IsNot Nothing Then
            If Not DetalleDespachos.DespachoSalidaDetalle.Contains(Me) Then
                DetalleDespachos.DespachoSalidaDetalle.Add(Me)
            End If

            TDO_ID = DetalleDespachos.TDO_ID
            DTD_ID = DetalleDespachos.DTD_ID
            DSD_SERIE = DetalleDespachos.DDE_SERIE
            DSD_NUMERO = DetalleDespachos.DDE_NUMERO
            DSD_ITEM = DetalleDespachos.DDE_ITEM
        ElseIf Not skipKeys Then
            TDO_ID = Nothing
            DTD_ID = Nothing
            DSD_SERIE = Nothing
            DSD_NUMERO = Nothing
            DSD_ITEM = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("DetalleDespachos") AndAlso
                ChangeTracker.OriginalValues("DetalleDespachos") Is DetalleDespachos Then
                ChangeTracker.OriginalValues.Remove("DetalleDespachos")
            Else
                ChangeTracker.RecordOriginalValue("DetalleDespachos", previousValue)
            End If
            If DetalleDespachos IsNot Nothing AndAlso Not DetalleDespachos.ChangeTracker.ChangeTrackingEnabled Then
                DetalleDespachos.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class

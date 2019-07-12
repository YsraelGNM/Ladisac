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
<KnownType(GetType(Ladrillo))>
Partial Public Class LadrilloMalecon
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared LMA_ID As string = "LMA_ID"
				public shared LAD_ID As string = "LAD_ID"
				public shared MAL_ID As string = "MAL_ID"
				public shared LMA_CANTIDAD As string = "LMA_CANTIDAD"
				public shared USU_ID As string = "USU_ID"
				public shared LMA_FEC_GRAB As string = "LMA_FEC_GRAB"
				public shared LMA_ESTADO As string = "LMA_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property LMA_ID() As Integer
        Get
            Return _lMA_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_lMA_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'LMA_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _lMA_ID = value
                OnPropertyChanged("LMA_ID")
            End If
        End Set
    End Property

    Private _lMA_ID As Integer

    <DataMember()>
    Public Property LAD_ID() As String
        Get
            Return _lAD_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_lAD_ID, value) Then
                ChangeTracker.RecordOriginalValue("LAD_ID", _lAD_ID)
                If Not IsDeserializing Then
                    If Ladrillo IsNot Nothing AndAlso Not Equals(Ladrillo.LAD_ID, value) Then
                        Ladrillo = Nothing
                    End If
                End If
                _lAD_ID = value
                OnPropertyChanged("LAD_ID")
            End If
        End Set
    End Property

    Private _lAD_ID As String

    <DataMember()>
    Public Property MAL_ID() As Nullable(Of Integer)
        Get
            Return _mAL_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_mAL_ID, value) Then
                ChangeTracker.RecordOriginalValue("MAL_ID", _mAL_ID)
                _mAL_ID = value
                OnPropertyChanged("MAL_ID")
            End If
        End Set
    End Property

    Private _mAL_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property LMA_CANTIDAD() As Nullable(Of Decimal)
        Get
            Return _lMA_CANTIDAD
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_lMA_CANTIDAD, value) Then
                _lMA_CANTIDAD = value
                OnPropertyChanged("LMA_CANTIDAD")
            End If
        End Set
    End Property

    Private _lMA_CANTIDAD As Nullable(Of Decimal)

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
    Public Property LMA_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _lMA_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_lMA_FEC_GRAB, value) Then
                _lMA_FEC_GRAB = value
                OnPropertyChanged("LMA_FEC_GRAB")
            End If
        End Set
    End Property

    Private _lMA_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property LMA_ESTADO() As Nullable(Of Boolean)
        Get
            Return _lMA_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_lMA_ESTADO, value) Then
                _lMA_ESTADO = value
                OnPropertyChanged("LMA_ESTADO")
            End If
        End Set
    End Property

    Private _lMA_ESTADO As Nullable(Of Boolean)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Ladrillo() As Ladrillo
        Get
            Return _ladrillo
        End Get
        Set(ByVal value As Ladrillo)
            If _ladrillo IsNot value Then
                Dim previousValue As Ladrillo = _ladrillo
                _ladrillo = value
                FixupLadrillo(previousValue)
                OnNavigationPropertyChanged("Ladrillo")
            End If
        End Set
    End Property

    Private _ladrillo As Ladrillo


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
        Ladrillo = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupLadrillo(ByVal previousValue As Ladrillo, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.LadrilloMalecon.Contains(Me) Then
            previousValue.LadrilloMalecon.Remove(Me)
        End If

        If Ladrillo IsNot Nothing Then
            If Not Ladrillo.LadrilloMalecon.Contains(Me) Then
                Ladrillo.LadrilloMalecon.Add(Me)
            End If

            LAD_ID = Ladrillo.LAD_ID
        ElseIf Not skipKeys Then
            LAD_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Ladrillo") AndAlso
                ChangeTracker.OriginalValues("Ladrillo") Is Ladrillo Then
                ChangeTracker.OriginalValues.Remove("Ladrillo")
            Else
                ChangeTracker.RecordOriginalValue("Ladrillo", previousValue)
            End If
            If Ladrillo IsNot Nothing AndAlso Not Ladrillo.ChangeTracker.ChangeTrackingEnabled Then
                Ladrillo.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
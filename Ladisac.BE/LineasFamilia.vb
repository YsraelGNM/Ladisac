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
<KnownType(GetType(FamiliaArticulos))>
<KnownType(GetType(GrupoLineas))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(CuentasArticulo))>
Partial Public Class LineasFamilia
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared LIN_ID As string = "LIN_ID"
				public shared LIN_DESCRIPCION As string = "LIN_DESCRIPCION"
				public shared FAM_ID As string = "FAM_ID"
				public shared USU_ID As string = "USU_ID"
				public shared LIN_FEC_GRAB As string = "LIN_FEC_GRAB"
				public shared LIN_ESTADO As string = "LIN_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property LIN_ID() As String
        Get
            Return _lIN_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_lIN_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'LIN_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _lIN_ID = value
                OnPropertyChanged("LIN_ID")
            End If
        End Set
    End Property

    Private _lIN_ID As String

    <DataMember()>
    Public Property LIN_DESCRIPCION() As String
        Get
            Return _lIN_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_lIN_DESCRIPCION, value) Then
                _lIN_DESCRIPCION = value
                OnPropertyChanged("LIN_DESCRIPCION")
            End If
        End Set
    End Property

    Private _lIN_DESCRIPCION As String

    <DataMember()>
    Public Property FAM_ID() As String
        Get
            Return _fAM_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_fAM_ID, value) Then
                ChangeTracker.RecordOriginalValue("FAM_ID", _fAM_ID)
                If Not IsDeserializing Then
                    If FamiliaArticulos IsNot Nothing AndAlso Not Equals(FamiliaArticulos.FAM_ID, value) Then
                        FamiliaArticulos = Nothing
                    End If
                End If
                _fAM_ID = value
                OnPropertyChanged("FAM_ID")
            End If
        End Set
    End Property

    Private _fAM_ID As String

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
    Public Property LIN_FEC_GRAB() As Date
        Get
            Return _lIN_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_lIN_FEC_GRAB, value) Then
                _lIN_FEC_GRAB = value
                OnPropertyChanged("LIN_FEC_GRAB")
            End If
        End Set
    End Property

    Private _lIN_FEC_GRAB As Date

    <DataMember()>
    Public Property LIN_ESTADO() As Boolean
        Get
            Return _lIN_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_lIN_ESTADO, value) Then
                _lIN_ESTADO = value
                OnPropertyChanged("LIN_ESTADO")
            End If
        End Set
    End Property

    Private _lIN_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property FamiliaArticulos() As FamiliaArticulos
        Get
            Return _familiaArticulos
        End Get
        Set(ByVal value As FamiliaArticulos)
            If _familiaArticulos IsNot value Then
                Dim previousValue As FamiliaArticulos = _familiaArticulos
                _familiaArticulos = value
                FixupFamiliaArticulos(previousValue)
                OnNavigationPropertyChanged("FamiliaArticulos")
            End If
        End Set
    End Property

    Private _familiaArticulos As FamiliaArticulos


    <DataMember()>
    Public Property GrupoLineas() As TrackableCollection(Of GrupoLineas)
        Get
            If _grupoLineas Is Nothing Then
                _grupoLineas = New TrackableCollection(Of GrupoLineas)
                AddHandler _grupoLineas.CollectionChanged, AddressOf FixupGrupoLineas
            End If
            Return _grupoLineas
        End Get
        Set(ByVal value As TrackableCollection(Of GrupoLineas))
            If Not Object.ReferenceEquals(_grupoLineas, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _grupoLineas IsNot Nothing Then
                    RemoveHandler _grupoLineas.CollectionChanged, AddressOf FixupGrupoLineas
                End If
                _grupoLineas = value
                If _grupoLineas IsNot Nothing Then
                    AddHandler _grupoLineas.CollectionChanged, AddressOf FixupGrupoLineas
                End If
                OnNavigationPropertyChanged("GrupoLineas")
            End If
        End Set
    End Property

    Private _grupoLineas As TrackableCollection(Of GrupoLineas)

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
    Public Property CuentasArticulo() As CuentasArticulo
        Get
            Return _cuentasArticulo
        End Get
        Set(ByVal value As CuentasArticulo)
            If _cuentasArticulo IsNot value Then
                Dim previousValue As CuentasArticulo = _cuentasArticulo
                _cuentasArticulo = value
                FixupCuentasArticulo(previousValue)
                OnNavigationPropertyChanged("CuentasArticulo")
            End If
        End Set
    End Property

    Private _cuentasArticulo As CuentasArticulo


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
        FamiliaArticulos = Nothing
        GrupoLineas.Clear()
        Usuarios = Nothing
        CuentasArticulo = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupFamiliaArticulos(ByVal previousValue As FamiliaArticulos)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.LineasFamilia.Contains(Me) Then
            previousValue.LineasFamilia.Remove(Me)
        End If

        If FamiliaArticulos IsNot Nothing Then
            If Not FamiliaArticulos.LineasFamilia.Contains(Me) Then
                FamiliaArticulos.LineasFamilia.Add(Me)
            End If

            FAM_ID = FamiliaArticulos.FAM_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("FamiliaArticulos") AndAlso
                ChangeTracker.OriginalValues("FamiliaArticulos") Is FamiliaArticulos Then
                ChangeTracker.OriginalValues.Remove("FamiliaArticulos")
            Else
                ChangeTracker.RecordOriginalValue("FamiliaArticulos", previousValue)
            End If
            If FamiliaArticulos IsNot Nothing AndAlso Not FamiliaArticulos.ChangeTracker.ChangeTrackingEnabled Then
                FamiliaArticulos.StartTracking()
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

    Private Sub FixupCuentasArticulo(ByVal previousValue As CuentasArticulo)
        If previousValue IsNot Nothing Then
            RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf previousValue.HandleCascadeDelete
        End If

        If CuentasArticulo IsNot Nothing Then
            AddHandler ChangeTracker.ObjectStateChanging, AddressOf CuentasArticulo.HandleCascadeDelete
        End If
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso ReferenceEquals(previousValue.LineasFamilia, Me) Then
            previousValue.LineasFamilia = Nothing
        End If

        If CuentasArticulo IsNot Nothing Then
            CuentasArticulo.LineasFamilia = Me
        End If

        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("CuentasArticulo") AndAlso
                ChangeTracker.OriginalValues("CuentasArticulo") Is CuentasArticulo Then
                ChangeTracker.OriginalValues.Remove("CuentasArticulo")
            Else
                ChangeTracker.RecordOriginalValue("CuentasArticulo", previousValue)
                ' Eliminar el extremo dependiente de esta asociación de identificación. Si el estado actual es agregado,
                ' permite que la relación se modifique sin eliminar el elemento dependiente.
                If previousValue IsNot Nothing AndAlso previousValue.ChangeTracker.State <> ObjectState.Added Then
                    previousValue.MarkAsDeleted()
                End If
            End If
            If CuentasArticulo IsNot Nothing AndAlso Not CuentasArticulo.ChangeTracker.ChangeTrackingEnabled Then
                CuentasArticulo.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupGrupoLineas(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As GrupoLineas In e.NewItems
                item.LineasFamilia = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("GrupoLineas", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As GrupoLineas In e.OldItems
                If ReferenceEquals(item.LineasFamilia, Me) Then
                    item.LineasFamilia = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("GrupoLineas", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class

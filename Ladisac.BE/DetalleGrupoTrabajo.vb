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
<KnownType(GetType(Usuarios))>
<KnownType(GetType(AreaTrabajos))>
<KnownType(GetType(TareaTrabajo))>
<KnownType(GetType(Produccion))>
<KnownType(GetType(Planta))>
<KnownType(GetType(Personas))>
Partial Public Class DetalleGrupoTrabajo
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared prd_Periodo_id As string = "prd_Periodo_id"
				public shared grt_NumeroProd As string = "grt_NumeroProd"
				public shared dgt_Item As string = "dgt_Item"
				public shared ttr_TareaTrab_Id As string = "ttr_TareaTrab_Id"
				public shared per_Id As string = "per_Id"
				public shared dgt_EsTiempoDoble As string = "dgt_EsTiempoDoble"
				public shared dgt_Fecha As string = "dgt_Fecha"
				public shared dgt_HoraDesde As string = "dgt_HoraDesde"
				public shared dgt_HoraHasta As string = "dgt_HoraHasta"
				public shared dgt_HoraTotales As string = "dgt_HoraTotales"
				public shared dgt_Factor As string = "dgt_Factor"
				public shared dgt_Bonificacion As string = "dgt_Bonificacion"
				public shared dgt_Refrigerio As string = "dgt_Refrigerio"
				public shared dgt_Fraccion As string = "dgt_Fraccion"
				public shared dgt_CantidadLadrillo As string = "dgt_CantidadLadrillo"
				public shared dgt_Mesas As string = "dgt_Mesas"
				public shared dgt_Alas As string = "dgt_Alas"
				public shared dgt_Observaciones As string = "dgt_Observaciones"
				public shared dgt_NumPersonas As string = "dgt_NumPersonas"
				public shared tit_TipTarea_Id As string = "tit_TipTarea_Id"
				public shared art_AreaTrab_Id As string = "art_AreaTrab_Id"
				public shared Usu_Id As string = "Usu_Id"
				public shared dgt_FecGrab As string = "dgt_FecGrab"
				public shared pro_Id As string = "pro_Id"
				public shared Pla_id As string = "Pla_id"
				public shared dgt_Descuento As string = "dgt_Descuento"
				public shared dgt_BonificacionGrupo As string = "dgt_BonificacionGrupo"
				public shared dgt_RefrigerioGrupo As string = "dgt_RefrigerioGrupo"
				public shared dgt_FraccionGrupo As string = "dgt_FraccionGrupo"
				public shared dgt_DescuentoGrupo As string = "dgt_DescuentoGrupo"
				public shared dgt_HoraTotalesGrupo As string = "dgt_HoraTotalesGrupo"
		    End Structure
	



    <DataMember()>
    Public Property prd_Periodo_id() As String
        Get
            Return _prd_Periodo_id
        End Get
        Set(ByVal value As String)
            If Not Equals(_prd_Periodo_id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'prd_Periodo_id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _prd_Periodo_id = value
                OnPropertyChanged("prd_Periodo_id")
            End If
        End Set
    End Property

    Private _prd_Periodo_id As String

    <DataMember()>
    Public Property grt_NumeroProd() As String
        Get
            Return _grt_NumeroProd
        End Get
        Set(ByVal value As String)
            If Not Equals(_grt_NumeroProd, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'grt_NumeroProd' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _grt_NumeroProd = value
                OnPropertyChanged("grt_NumeroProd")
            End If
        End Set
    End Property

    Private _grt_NumeroProd As String

    <DataMember()>
    Public Property dgt_Item() As String
        Get
            Return _dgt_Item
        End Get
        Set(ByVal value As String)
            If Not Equals(_dgt_Item, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'dgt_Item' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dgt_Item = value
                OnPropertyChanged("dgt_Item")
            End If
        End Set
    End Property

    Private _dgt_Item As String

    <DataMember()>
    Public Property ttr_TareaTrab_Id() As String
        Get
            Return _ttr_TareaTrab_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_ttr_TareaTrab_Id, value) Then
                ChangeTracker.RecordOriginalValue("ttr_TareaTrab_Id", _ttr_TareaTrab_Id)
                If Not IsDeserializing Then
                    If TareaTrabajo IsNot Nothing AndAlso Not Equals(TareaTrabajo.ttr_TareaTrab_Id, value) Then
                        Dim previousValue As TareaTrabajo = _tareaTrabajo
                        _tareaTrabajo = Nothing
                        FixupTareaTrabajo(previousValue, skipKeys:=True)
                        OnNavigationPropertyChanged("TareaTrabajo")
                    End If
                End If
                _ttr_TareaTrab_Id = value
                OnPropertyChanged("ttr_TareaTrab_Id")
            End If
        End Set
    End Property

    Private _ttr_TareaTrab_Id As String

    <DataMember()>
    Public Property per_Id() As String
        Get
            Return _per_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_per_Id, value) Then
                ChangeTracker.RecordOriginalValue("per_Id", _per_Id)
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
    Public Property dgt_EsTiempoDoble() As Nullable(Of Boolean)
        Get
            Return _dgt_EsTiempoDoble
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_dgt_EsTiempoDoble, value) Then
                _dgt_EsTiempoDoble = value
                OnPropertyChanged("dgt_EsTiempoDoble")
            End If
        End Set
    End Property

    Private _dgt_EsTiempoDoble As Nullable(Of Boolean)

    <DataMember()>
    Public Property dgt_Fecha() As Nullable(Of Date)
        Get
            Return _dgt_Fecha
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_dgt_Fecha, value) Then
                _dgt_Fecha = value
                OnPropertyChanged("dgt_Fecha")
            End If
        End Set
    End Property

    Private _dgt_Fecha As Nullable(Of Date)

    <DataMember()>
    Public Property dgt_HoraDesde() As Nullable(Of Decimal)
        Get
            Return _dgt_HoraDesde
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_HoraDesde, value) Then
                _dgt_HoraDesde = value
                OnPropertyChanged("dgt_HoraDesde")
            End If
        End Set
    End Property

    Private _dgt_HoraDesde As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_HoraHasta() As Nullable(Of Decimal)
        Get
            Return _dgt_HoraHasta
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_HoraHasta, value) Then
                _dgt_HoraHasta = value
                OnPropertyChanged("dgt_HoraHasta")
            End If
        End Set
    End Property

    Private _dgt_HoraHasta As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_HoraTotales() As Nullable(Of Decimal)
        Get
            Return _dgt_HoraTotales
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_HoraTotales, value) Then
                _dgt_HoraTotales = value
                OnPropertyChanged("dgt_HoraTotales")
            End If
        End Set
    End Property

    Private _dgt_HoraTotales As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_Factor() As Nullable(Of Decimal)
        Get
            Return _dgt_Factor
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_Factor, value) Then
                _dgt_Factor = value
                OnPropertyChanged("dgt_Factor")
            End If
        End Set
    End Property

    Private _dgt_Factor As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_Bonificacion() As Nullable(Of Decimal)
        Get
            Return _dgt_Bonificacion
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_Bonificacion, value) Then
                _dgt_Bonificacion = value
                OnPropertyChanged("dgt_Bonificacion")
            End If
        End Set
    End Property

    Private _dgt_Bonificacion As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_Refrigerio() As Nullable(Of Decimal)
        Get
            Return _dgt_Refrigerio
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_Refrigerio, value) Then
                _dgt_Refrigerio = value
                OnPropertyChanged("dgt_Refrigerio")
            End If
        End Set
    End Property

    Private _dgt_Refrigerio As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_Fraccion() As Nullable(Of Decimal)
        Get
            Return _dgt_Fraccion
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_Fraccion, value) Then
                _dgt_Fraccion = value
                OnPropertyChanged("dgt_Fraccion")
            End If
        End Set
    End Property

    Private _dgt_Fraccion As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_CantidadLadrillo() As Nullable(Of Decimal)
        Get
            Return _dgt_CantidadLadrillo
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_CantidadLadrillo, value) Then
                _dgt_CantidadLadrillo = value
                OnPropertyChanged("dgt_CantidadLadrillo")
            End If
        End Set
    End Property

    Private _dgt_CantidadLadrillo As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_Mesas() As Nullable(Of Decimal)
        Get
            Return _dgt_Mesas
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_Mesas, value) Then
                _dgt_Mesas = value
                OnPropertyChanged("dgt_Mesas")
            End If
        End Set
    End Property

    Private _dgt_Mesas As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_Alas() As Nullable(Of Decimal)
        Get
            Return _dgt_Alas
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_Alas, value) Then
                _dgt_Alas = value
                OnPropertyChanged("dgt_Alas")
            End If
        End Set
    End Property

    Private _dgt_Alas As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_Observaciones() As String
        Get
            Return _dgt_Observaciones
        End Get
        Set(ByVal value As String)
            If Not Equals(_dgt_Observaciones, value) Then
                _dgt_Observaciones = value
                OnPropertyChanged("dgt_Observaciones")
            End If
        End Set
    End Property

    Private _dgt_Observaciones As String

    <DataMember()>
    Public Property dgt_NumPersonas() As Nullable(Of Decimal)
        Get
            Return _dgt_NumPersonas
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_NumPersonas, value) Then
                _dgt_NumPersonas = value
                OnPropertyChanged("dgt_NumPersonas")
            End If
        End Set
    End Property

    Private _dgt_NumPersonas As Nullable(Of Decimal)

    <DataMember()>
    Public Property tit_TipTarea_Id() As String
        Get
            Return _tit_TipTarea_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_tit_TipTarea_Id, value) Then
                ChangeTracker.RecordOriginalValue("tit_TipTarea_Id", _tit_TipTarea_Id)
                If Not IsDeserializing Then
                    If TareaTrabajo IsNot Nothing AndAlso Not Equals(TareaTrabajo.tit_TipTarea_Id, value) Then
                        Dim previousValue As TareaTrabajo = _tareaTrabajo
                        _tareaTrabajo = Nothing
                        FixupTareaTrabajo(previousValue, skipKeys:=True)
                        OnNavigationPropertyChanged("TareaTrabajo")
                    End If
                End If
                _tit_TipTarea_Id = value
                OnPropertyChanged("tit_TipTarea_Id")
            End If
        End Set
    End Property

    Private _tit_TipTarea_Id As String

    <DataMember()>
    Public Property art_AreaTrab_Id() As String
        Get
            Return _art_AreaTrab_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_art_AreaTrab_Id, value) Then
                ChangeTracker.RecordOriginalValue("art_AreaTrab_Id", _art_AreaTrab_Id)
                If Not IsDeserializing Then
                    If AreaTrabajos IsNot Nothing AndAlso Not Equals(AreaTrabajos.art_AreaTrab_Id, value) Then
                        AreaTrabajos = Nothing
                    End If
                End If
                _art_AreaTrab_Id = value
                OnPropertyChanged("art_AreaTrab_Id")
            End If
        End Set
    End Property

    Private _art_AreaTrab_Id As String

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

    <DataMember()>
    Public Property dgt_FecGrab() As Nullable(Of Date)
        Get
            Return _dgt_FecGrab
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_dgt_FecGrab, value) Then
                _dgt_FecGrab = value
                OnPropertyChanged("dgt_FecGrab")
            End If
        End Set
    End Property

    Private _dgt_FecGrab As Nullable(Of Date)

    <DataMember()>
    Public Property pro_Id() As Nullable(Of Integer)
        Get
            Return _pro_Id
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_pro_Id, value) Then
                ChangeTracker.RecordOriginalValue("pro_Id", _pro_Id)
                If Not IsDeserializing Then
                    If Produccion IsNot Nothing AndAlso Not Equals(Produccion.PRO_ID, value) Then
                        Produccion = Nothing
                    End If
                End If
                _pro_Id = value
                OnPropertyChanged("pro_Id")
            End If
        End Set
    End Property

    Private _pro_Id As Nullable(Of Integer)

    <DataMember()>
    Public Property Pla_id() As Nullable(Of Integer)
        Get
            Return _pla_id
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_pla_id, value) Then
                ChangeTracker.RecordOriginalValue("Pla_id", _pla_id)
                If Not IsDeserializing Then
                    If Planta IsNot Nothing AndAlso Not Equals(Planta.PLA_ID, value) Then
                        Planta = Nothing
                    End If
                End If
                _pla_id = value
                OnPropertyChanged("Pla_id")
            End If
        End Set
    End Property

    Private _pla_id As Nullable(Of Integer)

    <DataMember()>
    Public Property dgt_Descuento() As Nullable(Of Decimal)
        Get
            Return _dgt_Descuento
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_Descuento, value) Then
                _dgt_Descuento = value
                OnPropertyChanged("dgt_Descuento")
            End If
        End Set
    End Property

    Private _dgt_Descuento As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_BonificacionGrupo() As Nullable(Of Decimal)
        Get
            Return _dgt_BonificacionGrupo
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_BonificacionGrupo, value) Then
                _dgt_BonificacionGrupo = value
                OnPropertyChanged("dgt_BonificacionGrupo")
            End If
        End Set
    End Property

    Private _dgt_BonificacionGrupo As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_RefrigerioGrupo() As Nullable(Of Decimal)
        Get
            Return _dgt_RefrigerioGrupo
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_RefrigerioGrupo, value) Then
                _dgt_RefrigerioGrupo = value
                OnPropertyChanged("dgt_RefrigerioGrupo")
            End If
        End Set
    End Property

    Private _dgt_RefrigerioGrupo As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_FraccionGrupo() As Nullable(Of Decimal)
        Get
            Return _dgt_FraccionGrupo
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_FraccionGrupo, value) Then
                _dgt_FraccionGrupo = value
                OnPropertyChanged("dgt_FraccionGrupo")
            End If
        End Set
    End Property

    Private _dgt_FraccionGrupo As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_DescuentoGrupo() As Nullable(Of Decimal)
        Get
            Return _dgt_DescuentoGrupo
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_DescuentoGrupo, value) Then
                _dgt_DescuentoGrupo = value
                OnPropertyChanged("dgt_DescuentoGrupo")
            End If
        End Set
    End Property

    Private _dgt_DescuentoGrupo As Nullable(Of Decimal)

    <DataMember()>
    Public Property dgt_HoraTotalesGrupo() As Nullable(Of Decimal)
        Get
            Return _dgt_HoraTotalesGrupo
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dgt_HoraTotalesGrupo, value) Then
                _dgt_HoraTotalesGrupo = value
                OnPropertyChanged("dgt_HoraTotalesGrupo")
            End If
        End Set
    End Property

    Private _dgt_HoraTotalesGrupo As Nullable(Of Decimal)

#End Region
#Region "Propiedades de navegación"

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
    Public Property AreaTrabajos() As AreaTrabajos
        Get
            Return _areaTrabajos
        End Get
        Set(ByVal value As AreaTrabajos)
            If _areaTrabajos IsNot value Then
                Dim previousValue As AreaTrabajos = _areaTrabajos
                _areaTrabajos = value
                FixupAreaTrabajos(previousValue)
                OnNavigationPropertyChanged("AreaTrabajos")
            End If
        End Set
    End Property

    Private _areaTrabajos As AreaTrabajos


    <DataMember()>
    Public Property TareaTrabajo() As TareaTrabajo
        Get
            Return _tareaTrabajo
        End Get
        Set(ByVal value As TareaTrabajo)
            If _tareaTrabajo IsNot value Then
                Dim previousValue As TareaTrabajo = _tareaTrabajo
                _tareaTrabajo = value
                FixupTareaTrabajo(previousValue)
                OnNavigationPropertyChanged("TareaTrabajo")
            End If
        End Set
    End Property

    Private _tareaTrabajo As TareaTrabajo


    <DataMember()>
    Public Property Produccion() As Produccion
        Get
            Return _produccion
        End Get
        Set(ByVal value As Produccion)
            If _produccion IsNot value Then
                Dim previousValue As Produccion = _produccion
                _produccion = value
                FixupProduccion(previousValue)
                OnNavigationPropertyChanged("Produccion")
            End If
        End Set
    End Property

    Private _produccion As Produccion


    <DataMember()>
    Public Property Planta() As Planta
        Get
            Return _planta
        End Get
        Set(ByVal value As Planta)
            If _planta IsNot value Then
                Dim previousValue As Planta = _planta
                _planta = value
                FixupPlanta(previousValue)
                OnNavigationPropertyChanged("Planta")
            End If
        End Set
    End Property

    Private _planta As Planta


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
        Usuarios = Nothing
        AreaTrabajos = Nothing
        TareaTrabajo = Nothing
        Produccion = Nothing
        Planta = Nothing
        Personas = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

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

    Private Sub FixupAreaTrabajos(ByVal previousValue As AreaTrabajos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleGrupoTrabajo.Contains(Me) Then
            previousValue.DetalleGrupoTrabajo.Remove(Me)
        End If

        If AreaTrabajos IsNot Nothing Then
            If Not AreaTrabajos.DetalleGrupoTrabajo.Contains(Me) Then
                AreaTrabajos.DetalleGrupoTrabajo.Add(Me)
            End If

            art_AreaTrab_Id = AreaTrabajos.art_AreaTrab_Id
        ElseIf Not skipKeys Then
            art_AreaTrab_Id = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("AreaTrabajos") AndAlso
                ChangeTracker.OriginalValues("AreaTrabajos") Is AreaTrabajos Then
                ChangeTracker.OriginalValues.Remove("AreaTrabajos")
            Else
                ChangeTracker.RecordOriginalValue("AreaTrabajos", previousValue)
            End If
            If AreaTrabajos IsNot Nothing AndAlso Not AreaTrabajos.ChangeTracker.ChangeTrackingEnabled Then
                AreaTrabajos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupTareaTrabajo(ByVal previousValue As TareaTrabajo, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleGrupoTrabajo.Contains(Me) Then
            previousValue.DetalleGrupoTrabajo.Remove(Me)
        End If

        If TareaTrabajo IsNot Nothing Then
            If Not TareaTrabajo.DetalleGrupoTrabajo.Contains(Me) Then
                TareaTrabajo.DetalleGrupoTrabajo.Add(Me)
            End If

            ttr_TareaTrab_Id = TareaTrabajo.ttr_TareaTrab_Id
            tit_TipTarea_Id = TareaTrabajo.tit_TipTarea_Id
        ElseIf Not skipKeys Then
            ttr_TareaTrab_Id = Nothing
            tit_TipTarea_Id = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("TareaTrabajo") AndAlso
                ChangeTracker.OriginalValues("TareaTrabajo") Is TareaTrabajo Then
                ChangeTracker.OriginalValues.Remove("TareaTrabajo")
            Else
                ChangeTracker.RecordOriginalValue("TareaTrabajo", previousValue)
            End If
            If TareaTrabajo IsNot Nothing AndAlso Not TareaTrabajo.ChangeTracker.ChangeTrackingEnabled Then
                TareaTrabajo.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupProduccion(ByVal previousValue As Produccion, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Produccion IsNot Nothing Then
            pro_Id = Produccion.PRO_ID
        ElseIf Not skipKeys Then
            pro_Id = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Produccion") AndAlso
                ChangeTracker.OriginalValues("Produccion") Is Produccion Then
                ChangeTracker.OriginalValues.Remove("Produccion")
            Else
                ChangeTracker.RecordOriginalValue("Produccion", previousValue)
            End If
            If Produccion IsNot Nothing AndAlso Not Produccion.ChangeTracker.ChangeTrackingEnabled Then
                Produccion.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupPlanta(ByVal previousValue As Planta, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleGrupoTrabajo.Contains(Me) Then
            previousValue.DetalleGrupoTrabajo.Remove(Me)
        End If

        If Planta IsNot Nothing Then
            If Not Planta.DetalleGrupoTrabajo.Contains(Me) Then
                Planta.DetalleGrupoTrabajo.Add(Me)
            End If

            Pla_id = Planta.PLA_ID
        ElseIf Not skipKeys Then
            Pla_id = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Planta") AndAlso
                ChangeTracker.OriginalValues("Planta") Is Planta Then
                ChangeTracker.OriginalValues.Remove("Planta")
            Else
                ChangeTracker.RecordOriginalValue("Planta", previousValue)
            End If
            If Planta IsNot Nothing AndAlso Not Planta.ChangeTracker.ChangeTrackingEnabled Then
                Planta.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupPersonas(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleGrupoTrabajo.Contains(Me) Then
            previousValue.DetalleGrupoTrabajo.Remove(Me)
        End If

        If Personas IsNot Nothing Then
            If Not Personas.DetalleGrupoTrabajo.Contains(Me) Then
                Personas.DetalleGrupoTrabajo.Add(Me)
            End If

            per_Id = Personas.PER_ID
        ElseIf Not skipKeys Then
            per_Id = Nothing
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

#End Region
End Class

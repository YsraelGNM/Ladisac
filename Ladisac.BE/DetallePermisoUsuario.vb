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
Partial Public Class DetallePermisoUsuario
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared PEU_ID As string = "PEU_ID"
				public shared DPU_ITEM As string = "DPU_ITEM"
				public shared DPU_CADENA0 As string = "DPU_CADENA0"
				public shared DPU_CADENA1 As string = "DPU_CADENA1"
				public shared DPU_CADENA2 As string = "DPU_CADENA2"
				public shared DPU_CADENA3 As string = "DPU_CADENA3"
				public shared DPU_CADENA4 As string = "DPU_CADENA4"
				public shared DPU_CADENA5 As string = "DPU_CADENA5"
				public shared DPU_CADENA6 As string = "DPU_CADENA6"
				public shared DPU_CADENA7 As string = "DPU_CADENA7"
				public shared DPU_CADENA8 As string = "DPU_CADENA8"
				public shared DPU_CADENA9 As string = "DPU_CADENA9"
				public shared DPU_CADENA10 As string = "DPU_CADENA10"
				public shared DPU_CADENA11 As string = "DPU_CADENA11"
				public shared DPU_CADENA12 As string = "DPU_CADENA12"
				public shared DPU_CADENA13 As string = "DPU_CADENA13"
				public shared DPU_CADENA14 As string = "DPU_CADENA14"
				public shared DPU_CADENA15 As string = "DPU_CADENA15"
				public shared DPU_CADENA16 As string = "DPU_CADENA16"
				public shared DPU_CADENA17 As string = "DPU_CADENA17"
				public shared DPU_VALOR As string = "DPU_VALOR"
				public shared USU_ID_CODIGO As string = "USU_ID_CODIGO"
				public shared DPU_FEC_GRAB As string = "DPU_FEC_GRAB"
				public shared DPU_ESTADO As string = "DPU_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property PEU_ID() As String
        Get
            Return _pEU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pEU_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PEU_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pEU_ID = value
                OnPropertyChanged("PEU_ID")
            End If
        End Set
    End Property

    Private _pEU_ID As String

    <DataMember()>
    Public Property DPU_ITEM() As Integer
        Get
            Return _dPU_ITEM
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dPU_ITEM, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DPU_ITEM' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dPU_ITEM = value
                OnPropertyChanged("DPU_ITEM")
            End If
        End Set
    End Property

    Private _dPU_ITEM As Integer

    <DataMember()>
    Public Property DPU_CADENA0() As String
        Get
            Return _dPU_CADENA0
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA0, value) Then
                _dPU_CADENA0 = value
                OnPropertyChanged("DPU_CADENA0")
            End If
        End Set
    End Property

    Private _dPU_CADENA0 As String

    <DataMember()>
    Public Property DPU_CADENA1() As String
        Get
            Return _dPU_CADENA1
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA1, value) Then
                _dPU_CADENA1 = value
                OnPropertyChanged("DPU_CADENA1")
            End If
        End Set
    End Property

    Private _dPU_CADENA1 As String

    <DataMember()>
    Public Property DPU_CADENA2() As String
        Get
            Return _dPU_CADENA2
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA2, value) Then
                _dPU_CADENA2 = value
                OnPropertyChanged("DPU_CADENA2")
            End If
        End Set
    End Property

    Private _dPU_CADENA2 As String

    <DataMember()>
    Public Property DPU_CADENA3() As String
        Get
            Return _dPU_CADENA3
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA3, value) Then
                _dPU_CADENA3 = value
                OnPropertyChanged("DPU_CADENA3")
            End If
        End Set
    End Property

    Private _dPU_CADENA3 As String

    <DataMember()>
    Public Property DPU_CADENA4() As String
        Get
            Return _dPU_CADENA4
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA4, value) Then
                _dPU_CADENA4 = value
                OnPropertyChanged("DPU_CADENA4")
            End If
        End Set
    End Property

    Private _dPU_CADENA4 As String

    <DataMember()>
    Public Property DPU_CADENA5() As String
        Get
            Return _dPU_CADENA5
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA5, value) Then
                _dPU_CADENA5 = value
                OnPropertyChanged("DPU_CADENA5")
            End If
        End Set
    End Property

    Private _dPU_CADENA5 As String

    <DataMember()>
    Public Property DPU_CADENA6() As String
        Get
            Return _dPU_CADENA6
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA6, value) Then
                _dPU_CADENA6 = value
                OnPropertyChanged("DPU_CADENA6")
            End If
        End Set
    End Property

    Private _dPU_CADENA6 As String

    <DataMember()>
    Public Property DPU_CADENA7() As String
        Get
            Return _dPU_CADENA7
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA7, value) Then
                _dPU_CADENA7 = value
                OnPropertyChanged("DPU_CADENA7")
            End If
        End Set
    End Property

    Private _dPU_CADENA7 As String

    <DataMember()>
    Public Property DPU_CADENA8() As String
        Get
            Return _dPU_CADENA8
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA8, value) Then
                _dPU_CADENA8 = value
                OnPropertyChanged("DPU_CADENA8")
            End If
        End Set
    End Property

    Private _dPU_CADENA8 As String

    <DataMember()>
    Public Property DPU_CADENA9() As String
        Get
            Return _dPU_CADENA9
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA9, value) Then
                _dPU_CADENA9 = value
                OnPropertyChanged("DPU_CADENA9")
            End If
        End Set
    End Property

    Private _dPU_CADENA9 As String

    <DataMember()>
    Public Property DPU_CADENA10() As String
        Get
            Return _dPU_CADENA10
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA10, value) Then
                _dPU_CADENA10 = value
                OnPropertyChanged("DPU_CADENA10")
            End If
        End Set
    End Property

    Private _dPU_CADENA10 As String

    <DataMember()>
    Public Property DPU_CADENA11() As String
        Get
            Return _dPU_CADENA11
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA11, value) Then
                _dPU_CADENA11 = value
                OnPropertyChanged("DPU_CADENA11")
            End If
        End Set
    End Property

    Private _dPU_CADENA11 As String

    <DataMember()>
    Public Property DPU_CADENA12() As String
        Get
            Return _dPU_CADENA12
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA12, value) Then
                _dPU_CADENA12 = value
                OnPropertyChanged("DPU_CADENA12")
            End If
        End Set
    End Property

    Private _dPU_CADENA12 As String

    <DataMember()>
    Public Property DPU_CADENA13() As String
        Get
            Return _dPU_CADENA13
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA13, value) Then
                _dPU_CADENA13 = value
                OnPropertyChanged("DPU_CADENA13")
            End If
        End Set
    End Property

    Private _dPU_CADENA13 As String

    <DataMember()>
    Public Property DPU_CADENA14() As String
        Get
            Return _dPU_CADENA14
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA14, value) Then
                _dPU_CADENA14 = value
                OnPropertyChanged("DPU_CADENA14")
            End If
        End Set
    End Property

    Private _dPU_CADENA14 As String

    <DataMember()>
    Public Property DPU_CADENA15() As String
        Get
            Return _dPU_CADENA15
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA15, value) Then
                _dPU_CADENA15 = value
                OnPropertyChanged("DPU_CADENA15")
            End If
        End Set
    End Property

    Private _dPU_CADENA15 As String

    <DataMember()>
    Public Property DPU_CADENA16() As String
        Get
            Return _dPU_CADENA16
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA16, value) Then
                _dPU_CADENA16 = value
                OnPropertyChanged("DPU_CADENA16")
            End If
        End Set
    End Property

    Private _dPU_CADENA16 As String

    <DataMember()>
    Public Property DPU_CADENA17() As String
        Get
            Return _dPU_CADENA17
        End Get
        Set(ByVal value As String)
            If Not Equals(_dPU_CADENA17, value) Then
                _dPU_CADENA17 = value
                OnPropertyChanged("DPU_CADENA17")
            End If
        End Set
    End Property

    Private _dPU_CADENA17 As String

    <DataMember()>
    Public Property DPU_VALOR() As Integer
        Get
            Return _dPU_VALOR
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dPU_VALOR, value) Then
                _dPU_VALOR = value
                OnPropertyChanged("DPU_VALOR")
            End If
        End Set
    End Property

    Private _dPU_VALOR As Integer

    <DataMember()>
    Public Property USU_ID_CODIGO() As String
        Get
            Return _uSU_ID_CODIGO
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID_CODIGO, value) Then
                ChangeTracker.RecordOriginalValue("USU_ID_CODIGO", _uSU_ID_CODIGO)
                If Not IsDeserializing Then
                    If Usuarios IsNot Nothing AndAlso Not Equals(Usuarios.USU_ID, value) Then
                        Usuarios = Nothing
                    End If
                End If
                _uSU_ID_CODIGO = value
                OnPropertyChanged("USU_ID_CODIGO")
            End If
        End Set
    End Property

    Private _uSU_ID_CODIGO As String

    <DataMember()>
    Public Property DPU_FEC_GRAB() As Date
        Get
            Return _dPU_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dPU_FEC_GRAB, value) Then
                _dPU_FEC_GRAB = value
                OnPropertyChanged("DPU_FEC_GRAB")
            End If
        End Set
    End Property

    Private _dPU_FEC_GRAB As Date

    <DataMember()>
    Public Property DPU_ESTADO() As Boolean
        Get
            Return _dPU_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dPU_ESTADO, value) Then
                _dPU_ESTADO = value
                OnPropertyChanged("DPU_ESTADO")
            End If
        End Set
    End Property

    Private _dPU_ESTADO As Boolean

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
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupUsuarios(ByVal previousValue As Usuarios)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetallePermisoUsuario.Contains(Me) Then
            previousValue.DetallePermisoUsuario.Remove(Me)
        End If

        If Usuarios IsNot Nothing Then
            If Not Usuarios.DetallePermisoUsuario.Contains(Me) Then
                Usuarios.DetallePermisoUsuario.Add(Me)
            End If

            USU_ID_CODIGO = Usuarios.USU_ID
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

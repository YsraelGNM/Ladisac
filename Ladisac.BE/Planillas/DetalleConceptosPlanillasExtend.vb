Imports Ladisac.BE
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.CompilerServices
Partial Public Class DetalleConceptosPlanillas

    <DataMember()>
    Public Property dcp_ItemDetConcPlan() As String
        Get
            Return _dcp_ItemDetConcPlan
        End Get
        Set(ByVal value As String)
            If Not Equals(_dcp_ItemDetConcPlan, value) Then
                'If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                '    Throw New InvalidOperationException("La propiedad 'dcp_ItemDetConcPlan' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                'End If
                _dcp_ItemDetConcPlan = value
                OnPropertyChanged("dcp_ItemDetConcPlan")
            End If
        End Set
    End Property

End Class

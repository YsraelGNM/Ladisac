Imports System.ComponentModel

Partial Public Class RegistroMaquina
    Dim pHora As Decimal = 0
    Dim pKilometros As Decimal = 0
    Dim pTn As Decimal = 0
    Dim pDia As Decimal = 0
    Dim pUso As Decimal = 0

    'Private Const m_DefaultFirstName As String = "<unknown first name>"
    'Private m_FirstName As String = m_DefaultFirstName

    '<DefaultValue(m_DefaultFirstName)> _
    Public Property Hora_Ori() As Decimal
        Get
            Return pHora
        End Get
        Set(ByVal value As Decimal)
            pHora = value
        End Set
    End Property

    Public Property kilometros_Ori() As Decimal
        Get
            Return pKilometros
        End Get
        Set(ByVal value As Decimal)
            pKilometros = value
        End Set
    End Property

    Public Property Tn_Ori() As Decimal
        Get
            Return pTn
        End Get
        Set(ByVal value As Decimal)
            pTn = value
        End Set
    End Property

    Public Property Dia_Ori() As Decimal
        Get
            Return pDia
        End Get
        Set(ByVal value As Decimal)
            pDia = value
        End Set
    End Property

    Public Property Uso_Ori() As Decimal
        Get
            Return pUso
        End Get
        Set(ByVal value As Decimal)
            pUso = value
        End Set
    End Property

End Class

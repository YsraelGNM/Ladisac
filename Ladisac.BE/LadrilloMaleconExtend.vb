Partial Public Class LadrilloMalecon
    Dim pArticulo As Articulos
    Dim pMaleconPuerta As MaleconPuerta

    Public Property Articulo() As Articulos
        Get
            Return pArticulo
        End Get
        Set(ByVal value As Articulos)
            pArticulo = value
        End Set
    End Property

    Public Property MaleconPuerta() As MaleconPuerta
        Get
            Return pMaleconPuerta
        End Get
        Set(ByVal value As MaleconPuerta)
            pMaleconPuerta = value
        End Set
    End Property

End Class

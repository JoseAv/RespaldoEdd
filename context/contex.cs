using FacturaPila;
using RepuestosListaCircular;
using ServiciosCola;
using UserListSimple;
using VehiculosListaDoble;

class Contexto {

    public UserListSimple<int>  ListaUsuarios;
    public VehiculosListaDoble<int> ListaVehiculos;
    public RepuestosListaCircular<int> ListaRepuestos;
    public ServiciosCola<int> servicioscola;
    public FacturaPila<int> facturaPila;
    public unsafe Contexto
    (
    UserListSimple<int>  ListaUsuarios, 
    VehiculosListaDoble<int> ListaVehiculos,
    RepuestosListaCircular<int> ListaRepuestos,
    ServiciosCola<int> servicioscola,
    FacturaPila<int> facturaPila
    )
    {
        this.ListaUsuarios = ListaUsuarios;
        this.ListaVehiculos = ListaVehiculos;
        this.ListaRepuestos =ListaRepuestos;
        this.servicioscola = servicioscola;
        this.facturaPila = facturaPila;
    }



}
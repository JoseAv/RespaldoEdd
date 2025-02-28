using RepuestosListaCircular;
using UserListSimple;
using VehiculosListaDoble;

class Contexto {

    public UserListSimple<int>  ListaUsuarios;
    public VehiculosListaDoble<int> ListaVehiculos;
    public RepuestosListaCircular<int> ListaRepuestos;
    public unsafe Contexto(UserListSimple<int>  ListaUsuarios, VehiculosListaDoble<int> ListaVehiculos, RepuestosListaCircular<int> ListaRepuestos ){
        this.ListaUsuarios = ListaUsuarios;
        this.ListaVehiculos = ListaVehiculos;
        this.ListaRepuestos =ListaRepuestos;
    }



}
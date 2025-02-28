using UserListSimple;
using VehiculosListaDoble;

class Contexto {

    public UserListSimple<int>  ListaUsuarios;
    public VehiculosListaDoble<int> ListaRepuestos;
    public unsafe Contexto(UserListSimple<int>  ListaUsuarios, VehiculosListaDoble<int> ListaRepuestos ){
        this.ListaUsuarios = ListaUsuarios;
        this.ListaRepuestos = ListaRepuestos;
    }



}
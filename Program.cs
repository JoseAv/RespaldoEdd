using Gtk;
using RepuestosListaCircular;
using UserListSimple;
using VehiculosListaDoble;

class Programa {
    [Obsolete]
    static void Main(String[] arg){
        Application.Init();
        UserListSimple<int> userListSimple = new();
        VehiculosListaDoble<int> ListaVehiculos = new();
        RepuestosListaCircular<int> ListaRepuestos = new();
        Contexto contexto = new(userListSimple,ListaVehiculos,ListaRepuestos);
        Login login = new(contexto);
        login.ShowAll();
        Application.Run();

    }


}
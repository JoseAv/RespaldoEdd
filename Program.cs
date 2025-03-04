using FacturaPila;
using Gtk;
using RepuestosListaCircular;
using ServiciosCola;
using UserListSimple;
using VehiculosListaDoble;

class Programa {
    [Obsolete]
    static void Main(String[] arg){
        Application.Init();
        UserListSimple<int> userListSimple = new();
        VehiculosListaDoble<int> ListaVehiculos = new();
        RepuestosListaCircular<int> ListaRepuestos = new();
        FacturaPila<int> facturaPila = new();
        ServiciosCola<int> servicioscola = new(facturaPila,ListaRepuestos,ListaVehiculos );
        Contexto contexto = new(userListSimple,ListaVehiculos,ListaRepuestos,servicioscola,facturaPila);
        Login login = new(contexto);
        login.ShowAll();
        Application.Run();

    }


}
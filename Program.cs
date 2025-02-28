using Gtk;
using UserListSimple;
using VehiculosListaDoble;

class Programa {
    [Obsolete]
    static void Main(String[] arg){
        Application.Init();
        UserListSimple<int> userListSimple = new();
         VehiculosListaDoble<int> ListaRepuestos = new();
        Contexto contexto = new(userListSimple,ListaRepuestos);
        Login login = new(contexto);
        login.ShowAll();
        Application.Run();

    }


}
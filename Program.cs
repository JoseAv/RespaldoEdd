using Gtk;
using UserListSimple;

class Programa {


     static void Main(String[] arg){
        Application.Init();
        UserListSimple<int> userListSimple = new();
        Contexto contexto = new(userListSimple);
        Login login = new(contexto);
        login.ShowAll();
        Application.Run();

    }


}
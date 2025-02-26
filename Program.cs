using Gtk;

class Programa {


     static void Main(String[] arg){
        Application.Init();
        Login login = new();
        login.ShowAll();
        Application.Run();

    }


}
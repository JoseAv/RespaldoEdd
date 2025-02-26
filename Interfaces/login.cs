using Gtk;

class Login: Gtk.Window {

    private Entry userInput = new();
    private Entry passInput = new();
    private Button btnSubmit = new("Login");

    [Obsolete]
    public Login(): base("Login"){

        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        userInput.PlaceholderText = "Ingresa un usuario";
        passInput.PlaceholderText = "Ingresa una contraseña";

        // Crear Boton y Agregar a ventana Inicial para que se muestre
        btnSubmit.Clicked += ComprobateLogin;
        Container.PackStart(userInput,false,false,5);
        Container.PackStart(passInput,false,false,5);
        Container.PackStart(btnSubmit,false,false,5);
        Add(Container);
        ShowAll();



    }

    [Obsolete]
    public void ComprobateLogin(object sent,EventArgs e){
        string user = userInput.Text;
        string password = passInput.Text;
        Console.WriteLine($"Usuario: {user}, Password: {password}");
        Menu menu = new();
        menu.ShowAll();
        Destroy();


    }

        protected static void FinishPrograma(){
        Application.Quit();

    }



}
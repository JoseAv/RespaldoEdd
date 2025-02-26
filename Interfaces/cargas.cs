using Gtk;

class Cargas: Gtk.Window {

    private Button cargaUser = new("Cargar Usuarios");
    private Button cargaCars = new("Cargar Vehiculos");
    private Button cargaRepuestos = new("Cargar Repuestos");

    [Obsolete]
    public Cargas(): base("Login"){

        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        cargaUser.Clicked += LoadUser;
        cargaCars.Clicked += LoadCars;
        cargaRepuestos.Clicked += LoadRepuestos;
        Container.PackStart(cargaUser,false,false,5);
        Container.PackStart(cargaCars,false,false,5);
        Container.PackStart(cargaRepuestos,false,false,5);
        Add(Container);
        ShowAll();



    }


    public void LoadUser(object sent,EventArgs e){
        Console.Write("Pantalla Carga");

    }

    public void LoadCars(object sent,EventArgs e){
        Console.Write("Pantalla Carga");

    }

    public void LoadRepuestos(object sent,EventArgs e){
        Console.Write("Pantalla Carga");

    }

        protected static void FinishPrograma(){
        Application.Quit();

    }



}
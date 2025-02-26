using Gtk;

class Menu: Gtk.Window {

    private Button cargaSubmit = new("Menu");

    [Obsolete]
    public Menu(): base("Login"){

        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        cargaSubmit.Clicked += SendCarga;
        Container.PackStart(cargaSubmit,false,false,5);
        Add(Container);
        ShowAll();



    }


    public void SendCarga(object sent,EventArgs e){
        Cargas cargas = new();
        cargas.ShowAll();
        Destroy();


    }

        protected static void FinishPrograma(){
        Application.Quit();

    }



}
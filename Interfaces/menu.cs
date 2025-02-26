using Gtk;

class Menu: Gtk.Window {

    private Button cargaSubmit = new("Carga Masiva");
    private Button sendUSer = new("Usuarios");
    private Contexto contexto;

    [Obsolete]
    public Menu(Contexto contexto): base("Menu"){
        this.contexto = contexto;
        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        cargaSubmit.Clicked += SendCarga;
        sendUSer.Clicked += SendUSer;
        Container.PackStart(cargaSubmit,false,false,5);
        Container.PackStart(sendUSer,false,false,5);
        Add(Container);
        ShowAll();



    }


    public void SendCarga(object sent,EventArgs e){
        Cargas cargas = new(contexto);
        cargas.ShowAll();
        Destroy();
    }

    public void SendUSer(object sent,EventArgs e){
        IUser user = new(contexto);
        Destroy();
    }

        protected static void FinishPrograma(){
        Application.Quit();

    }



}
using Gtk;

class Menu: Gtk.Window {

    private Button cargaSubmit = new("Carga Masiva");
    private Button sendUSer = new("Usuarios");
    private Button SendVehiculos = new("Crear Vehiculos");
    private Button SendRepuestos = new("Crear Repuestos");
    private Button SendServicios = new("Crear Servicios");
    private Button sendFactura = new("Crear Factura");
    private Contexto contexto;

    [Obsolete]
    public Menu(Contexto contexto): base("Menu"){
        this.contexto = contexto;
        // Medidas de la ventada
        SetDefaultSize(300,350);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        cargaSubmit.Clicked += SendCarga;
        sendUSer.Clicked += SendUSer;
        SendVehiculos.Clicked += CrearVehiculos;
        SendRepuestos.Clicked += CrearRepuestos;
        SendServicios.Clicked += CrearServicios;
        sendFactura.Clicked += CancelFacture;
        Container.PackStart(cargaSubmit,false,false,5);
        Container.PackStart(sendUSer,false,false,5);
        Container.PackStart(SendVehiculos,false,false,5);
        Container.PackStart(SendRepuestos,false,false,5);
        Container.PackStart(SendServicios, false,false,5);
         Container.PackStart(sendFactura, false,false,5);
        Add(Container);
        ShowAll();



    }

    [Obsolete]
    public void SendCarga(object sent,EventArgs e){
        Cargas cargas = new(contexto);
        cargas.ShowAll();
        Destroy();
    }

    [Obsolete]
    public void SendUSer(object sent,EventArgs e){
        IUser user = new(contexto);
        user.ShowAll();
        Destroy();
    }

    [Obsolete]
    public void CrearVehiculos(object sent,EventArgs e){
        ICreateVehiculo createVehiculo = new(contexto);
        createVehiculo.ShowAll();
       
    }

    [Obsolete]
    public void CrearRepuestos(object sent,EventArgs e){
        ICreateRepuestos createRepuestos = new(contexto);
        createRepuestos.ShowAll();
      
    }

    [Obsolete]
    public void CrearServicios(object sent,EventArgs e){
        ICreateServicios createServicios = new(contexto);
        createServicios.ShowAll();
      
    }

    [Obsolete]
    public void CancelFacture(object sent,EventArgs e){
        IShowFacture showFacture= new(contexto);
        showFacture.ShowAll();
        this.contexto.facturaPila.ReporFactura();
      
    }

        protected static void FinishPrograma(){
        Application.Quit();

    }



}
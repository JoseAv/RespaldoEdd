using Gtk;
using UserListSimple;
using VehiculosListaDoble;
class ICreateVehiculo: Gtk.Window {

    private Button CreateSubmit = new("Crear Vehiculo");
    private Entry inputID = new();
    private Entry inputID_Usuario= new();
    private Entry inputMarca = new();
    private Entry inputModelo = new();
    private Entry inputPlaca = new();
    private Contexto contexto;
    public VehiculosListaDoble<int> ListaVehiculos;
    [Obsolete]
    public ICreateVehiculo(Contexto contexto): base("Crear Vehiculos"){
        this.contexto = contexto;
        ListaVehiculos = contexto.ListaVehiculos;
        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        inputID.PlaceholderText = "Ingrese un ID";
        inputID_Usuario.PlaceholderText = "Ingrese Un ID usuario";
        inputMarca.PlaceholderText = "Ingrese el nombre de Marca";
        inputModelo.PlaceholderText = "Ingrese el año del Modelo";
        inputPlaca.PlaceholderText = "Ingrese la placa ";
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        CreateSubmit.Clicked += CreateVehiculos;
        Container.PackStart(inputID,false,false,5);
        Container.PackStart(inputID_Usuario,false,false,5);
        Container.PackStart(inputMarca,false,false,5);
        Container.PackStart(inputModelo,false,false,5);
        Container.PackStart(inputPlaca,false,false,5);
        Container.PackStart(CreateSubmit,false,false,5);
        Add(Container);
        ShowAll();
    }



    public void CreateVehiculos(object sent,EventArgs e){
        string ID= inputID.Text;
        string ID_Usuario= inputID_Usuario.Text;
        string Marca= inputMarca.Text;
        string Modelo= inputModelo.Text;
        string Placa= inputPlaca.Text;
        if(int.TryParse(ID, out int intID) && int.TryParse(ID_Usuario, out int intID_Usuario) && int.TryParse(Modelo, out int intModelo)){
            ListaVehiculos.InsertNewVehiculo(intID,intID_Usuario,Marca,intModelo,Placa);
            ListaVehiculos.ViewVehiculos();
          
        }
        //  Destroy();


    }

        protected static void FinishPrograma(){
        Application.Quit();

    }




}
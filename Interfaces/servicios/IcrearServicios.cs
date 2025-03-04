using Gtk;
using RepuestosListaCircular;
using ServiciosCola;

class ICreateServicios: Gtk.Window {

    private Button CreateSubmit = new("Crear Repuesto");
    private Entry inputID = new();
    private Entry inputID_Repuesto= new();
    private Entry inputID_vehiculos = new();
    private Entry inputDetalles = new();

    private Entry inputCosto = new();
    private Contexto contexto;
    private ServiciosCola<int> servicioscola;
    [Obsolete]
    public ICreateServicios(Contexto contexto): base("Crear Servicios"){
        this.contexto = contexto;
        servicioscola = contexto.servicioscola;
        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        inputID.PlaceholderText = "Ingrese un ID";
        inputID_Repuesto.PlaceholderText = "Ingrese El ID del repuesto";
        inputID_vehiculos.PlaceholderText = "Ingrese El ID del vehiculo";
        inputCosto.PlaceholderText = "Precio del Servicio";
        inputDetalles.PlaceholderText = "Detalles del serivcios";
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        CreateSubmit.Clicked += CreateRepuestos;
        Container.PackStart(inputID,false,false,5);
        Container.PackStart(inputID_Repuesto,false,false,5);
        Container.PackStart(inputID_vehiculos,false,false,5);
        Container.PackStart(inputDetalles,false,false,5);
        Container.PackStart(inputCosto,false,false,5);
        Container.PackStart(CreateSubmit,false,false,5);
        Add(Container);
    }

    public void CreateRepuestos(object sent,EventArgs e){
        string ID= inputID.Text;
        string ID_Repuesto= inputID_Repuesto.Text;
        string ID_vehiculos= inputID_vehiculos.Text;
        string Detalles= inputDetalles.Text;
        string Costo= inputCosto.Text;
        if(int.TryParse(ID, out int intID) && float.TryParse(Costo, out float floatModelo) 
        && int.TryParse(ID_Repuesto, out int intID_Repuesto) 
        && int.TryParse(ID_vehiculos, out int intID_vehiculos)){
            servicioscola.InsertNewServicio(intID,intID_Repuesto,intID_vehiculos,Detalles,floatModelo);
            servicioscola.ViewSercios();
    
        }
         Destroy();


    }


        protected static void FinishPrograma(){
        Application.Quit();

    }




}
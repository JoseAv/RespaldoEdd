using Gtk;
using RepuestosListaCircular;

class ICreateRepuestos: Gtk.Window {

    private Button CreateSubmit = new("Crear Repuesto");
    private Entry inputID = new();
    private Entry inputRepuesto= new();
    private Entry inputDetalles = new();
    private Entry inputCosto = new();
    private Contexto contexto;
    public RepuestosListaCircular<int> ListaRepuestos;
    [Obsolete]
    public ICreateRepuestos(Contexto contexto): base("Crear Repuesto"){
        this.contexto = contexto;
        ListaRepuestos = contexto.ListaRepuestos;
        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        inputID.PlaceholderText = "Ingrese un ID";
        inputRepuesto.PlaceholderText = "Ingrese Nombre Repuesto";
        inputDetalles.PlaceholderText = "Ingrese Detalles";
        inputCosto.PlaceholderText = "Precio del Repuesto";
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        CreateSubmit.Clicked += CreateRepuestos;
        Container.PackStart(inputID,false,false,5);
        Container.PackStart(inputRepuesto,false,false,5);
        Container.PackStart(inputDetalles,false,false,5);
        Container.PackStart(inputCosto,false,false,5);
        Container.PackStart(CreateSubmit,false,false,5);
        Add(Container);
        ShowAll();
    }



    public void CreateRepuestos(object sent,EventArgs e){
        string ID= inputID.Text;
        string Repuesto= inputRepuesto.Text;
        string Detalles= inputDetalles.Text;
        string Costo= inputCosto.Text;
        if(int.TryParse(ID, out int intID) && float.TryParse(Costo, out float floatModelo)){
            ListaRepuestos.InsertNewRepuesto(intID,Repuesto,Detalles,floatModelo);
            ListaRepuestos.viewRepuestos();
        }
         Destroy();


    }


        protected static void FinishPrograma(){
        Application.Quit();

    }




}
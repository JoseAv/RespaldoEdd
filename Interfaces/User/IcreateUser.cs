using Gtk;
using UserListSimple;
class ICreateUser: Gtk.Window {

    private Button CreateSubmit = new("Crear Usuario");
    private Entry inputID = new();
    private Entry inputApellidos= new();
    private Entry inputNombres = new();
    private Entry inputCorreo = new();
    private Entry inputContrasenia = new();
    private Contexto contexto;
    private UserListSimple<int> ListaUsuarios;

    [Obsolete]
    public ICreateUser(Contexto contexto): base("Menu"){
        this.contexto = contexto;
        this.ListaUsuarios = this.contexto.ListaUsuarios;
        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        inputID.PlaceholderText = "Ingrese un ID";
        inputApellidos.PlaceholderText = "Ingrese un Apellido";
        inputNombres.PlaceholderText = "Ingrese un Nombre";
        inputCorreo.PlaceholderText = "Ingrese un Correo";
        inputContrasenia.PlaceholderText = "Ingrese una contraseña";
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        CreateSubmit.Clicked += CreateUSer;
        Container.PackStart(inputID,false,false,5);
        Container.PackStart(inputApellidos,false,false,5);
        Container.PackStart(inputNombres,false,false,5);
        Container.PackStart(inputCorreo,false,false,5);
        Container.PackStart(inputContrasenia,false,false,5);
        Container.PackStart(CreateSubmit,false,false,5);
        Add(Container);
        ShowAll();



    }


    public void CreateUSer(object sent,EventArgs e){
        string ID= inputID.Text;
        string Nombres= inputNombres.Text;
        string Apellido= inputApellidos.Text;
        string Correo= inputCorreo.Text;
        string Contrasenia= inputContrasenia.Text;

        if(int.TryParse(ID, out int intID)){
            this.contexto.ListaUsuarios.InsertNewUser(intID,Nombres,Apellido,Correo,Contrasenia);
            ListaUsuarios.ViewUsuarios();
        }


        Destroy();


    }

        protected static void FinishPrograma(){
        Application.Quit();

    }




}
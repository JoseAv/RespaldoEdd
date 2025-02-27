using Gtk;
using NodoUser;
using UserListSimple;
class IUpdateUser: Gtk.Window {

    private Button UpdateSubmit = new("Actualizar Usuario");
    private Button SearchUserSubmit = new("Buscar Usuario");
    private Entry inputID = new();
    private Entry inputApellidos= new();
    private Entry inputNombres = new();
    private Entry inputCorreo = new();
    private Entry inputContrasenia = new();
    private Contexto contexto;
    private UserListSimple<int> ListaUsuarios;

    [Obsolete]
    public IUpdateUser(Contexto contexto): base("Actualizar un Usuario"){
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
        UpdateSubmit.Clicked += UpdateUser;
        SearchUserSubmit.Clicked += SearchUser;
        Container.PackStart(inputID,false,false,5);
        Container.PackStart(SearchUserSubmit,false,false,5);
        Container.PackStart(inputNombres,false,false,5);
        Container.PackStart(inputApellidos,false,false,5);
        Container.PackStart(inputCorreo,false,false,5);
        Container.PackStart(inputContrasenia,false,false,5);
        Container.PackStart(UpdateSubmit,false,false,5);
        Add(Container);
        ShowAll();



    }


    public void UpdateUser(object sent,EventArgs e){
        string ID= inputID.Text;
        string Nombres= inputNombres.Text;
        string Apellido= inputApellidos.Text;
        string Correo= inputCorreo.Text;
        string Contrasenia= inputContrasenia.Text;

        if(int.TryParse(ID, out int intID)){
            this.contexto.ListaUsuarios.EditUser(intID,Nombres,Apellido,Correo,Contrasenia);
            this.contexto.ListaUsuarios.ViewUsuarios();
        }
        Destroy();
    }

    public unsafe void SearchUser (object sent, EventArgs e){
        string ID = inputID.Text;

        if(int.TryParse(ID, out int intID)){
        NodoUser<int>* dataUser = ListaUsuarios.SearchUser(intID);
        if(dataUser!= null){
            inputNombres.Text = dataUser->Nombres;
            inputApellidos.Text = dataUser->Apellidos;
            inputContrasenia.Text = dataUser->Contrasenia;
            inputCorreo.Text = dataUser->Correo;
        }
        }
    }


    protected static void FinishPrograma(){
        Application.Quit();
    }




}

internal struct T
{
}
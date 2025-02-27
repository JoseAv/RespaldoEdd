using Gtk;

class IUser: Gtk.Window {

    private Button CreateSubmit = new("Crear un Usuario");
    private Button UpdateSubmit = new("Actualizar un  Usuario");
    private Contexto contexto;
    private Label showUser = new();

    [Obsolete]
    public IUser(Contexto contexto): base("Menu"){
        this.contexto = contexto;
        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        CreateSubmit.Clicked += CreateUSer;
        UpdateSubmit.Clicked += UpdateUser;
        Container.PackStart(CreateSubmit,false,false,5);
        Container.PackStart(UpdateSubmit,false,false,5);
        Add(Container);
        ShowAll();



    }


    public void CreateUSer(object sent,EventArgs e){
        ICreateUser createUser = new(contexto);
        createUser.ShowAll();
    }

    public void UpdateUser(object sent,EventArgs e){
        IUpdateUser updateUser = new(contexto);
        updateUser.ShowAll();
    }

        protected static void FinishPrograma(){
        Application.Quit();

    }



}
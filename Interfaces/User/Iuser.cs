using Gtk;

class IUser: Gtk.Window {

    private Button CreateSubmit = new("Crear un Usuario");
    private Button UpdateSubmit = new("Actualizar un  Usuario");
    private Button DeleteSubmit = new("Eliminar un  Usuario");
    private Button Reporte = new("Generar Reporte");

    private Button RegresarSubmit = new("Regresar");
    private Contexto contexto;

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
        DeleteSubmit.Clicked += DeleteUser;
        RegresarSubmit.Clicked += btnRegresar;
        Reporte.Clicked += btnReporte;
        Container.PackStart(CreateSubmit,false,false,5);
        Container.PackStart(UpdateSubmit,false,false,5);
        Container.PackStart(DeleteSubmit,false,false,5);
        Container.PackStart(Reporte,false,false,5);
        Container.PackStart(RegresarSubmit,false,false,5);
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

        public void DeleteUser(object sent,EventArgs e){
        IDeleteUser deleteUser = new(contexto);
        deleteUser.ShowAll();
    }

    public void btnRegresar(object sent,EventArgs e){
        Menu menu = new(contexto);
        menu.ShowAll();
        Destroy();
    }


    public void btnReporte(object sent,EventArgs e){
        this.contexto.ListaUsuarios.ReporUser();
    }

        protected static void FinishPrograma(){
        Application.Quit();

    }



}
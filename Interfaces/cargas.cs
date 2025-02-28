using System.Text.Json;
using System.Text.Json.Serialization;
using Gtk;
using UserListSimple;
using VehiculosListaDoble;
class Cargas: Gtk.Window {

    private Button cargaUser = new("Cargar Usuarios");
    private Button cargaCars = new("Cargar Vehiculos");
    private Button cargaRepuestos = new("Cargar Repuestos");
    private Button Regresar = new("Regresar");
     public Contexto contexto;
     private UserListSimple<int>  ListaUsuarios;
     public VehiculosListaDoble<int> ListaRepuestos;

    [Obsolete]
    public unsafe Cargas(Contexto contexto): base("Cargas Masivas"){
        this.contexto = contexto;
        ListaUsuarios = this.contexto.ListaUsuarios;
        ListaRepuestos = this.contexto.ListaRepuestos;
        
        // Medidas de la ventada
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        // Crear Contenedor y agregar texto
        VBox Container = new(false,5);
        // Crear Boton y Agregar a ventana Inicial para que se muestre
        cargaUser.Clicked += LoadUser;
        cargaCars.Clicked += LoadCars;
        cargaRepuestos.Clicked += LoadRepuestos;
        Regresar.Clicked += RegresarMenu;
        Container.PackStart(cargaUser,false,false,5);
        Container.PackStart(cargaCars,false,false,5);
        Container.PackStart(cargaRepuestos,false,false,5);
          Container.PackStart(Regresar,false,false,5);
        Add(Container);
        ShowAll();
    }

    public void RegresarMenu(object sent,EventArgs e){
        Menu menu = new(this.contexto);
        menu.ShowAll();
        Destroy();
    }


    public void LoadUser(object sent,EventArgs e){
        LoadJson("user");
    }

    public void LoadCars(object sent,EventArgs e){
        LoadJson("vehiculo");

    }

    public void LoadRepuestos(object sent,EventArgs e){
        Console.Write("Pantalla Carga");

    }


    public  void LoadJson(string types){
        FileChooserDialog fileJson = new(
            "Selecciona un archivo Json",
            this,
            FileChooserAction.Open,
            "cancelar",
            ResponseType.Cancel,
            "Abrir", ResponseType.Accept
            );
        // Filtro Archivos Json
        FileFilter filter = new();
        filter.AddPattern("*.json");
        fileJson.Filter = filter;

        if(fileJson.Run() == (int)ResponseType.Accept){
            string filepath = fileJson.Filename;
            fileJson.Destroy();
        try{
            string jsonContent = File.ReadAllText(filepath);
          
            if(types == "user"){
                List<User> users = JsonSerializer.Deserialize<List<User>>(jsonContent);
                foreach( var user in users){
                ListaUsuarios.InsertNewUser(user.ID, user.Nombres,user.Apellidos,user.Correo,user.Contrasenia);
                }
                ListaUsuarios.ViewUsuarios();
                return;
            }
            if(types == "vehiculo"){
                List<Vehiculos> vehiculos = JsonSerializer.Deserialize<List<Vehiculos>>(jsonContent);
                foreach(var vehi in vehiculos){
                    ListaRepuestos.InsertNewVehiculo(vehi.ID,vehi.ID_Usuario,vehi.Marca,vehi.Modelo, vehi.Placa);
                }
            }
            if(types == "repuestos"){
                List<Repuestos> repuestos = JsonSerializer.Deserialize<List<Repuestos>>(jsonContent);
            }


        }catch(Exception e){
            Console.WriteLine("ERROR",e);
        }

        }else {
            fileJson.Destroy();
        }
    }
        protected static void FinishPrograma(){
        Application.Quit();

    }



}

internal class ListaSimple<T>
{
}
using Gtk;
class IError: Gtk.Window {

    private Button btnAccepted = new("Aceptar");
    private Label LblTexto = new();
    [Obsolete]
    public IError(): base("Error"){

        SetDefaultSize(250,100);
        SetPosition(WindowPosition.Center);
        
        LblTexto.Text = "Error";
        VBox Container = new(false,5);
        btnAccepted.Clicked += AcceptedButton;
        Container.PackStart(LblTexto,false,false,5);
        Container.PackStart(btnAccepted,false,false,5);

        Add(Container);
        ShowAll();
    }

    public void AcceptedButton(object sent,EventArgs e ){
        Destroy();
    }

     protected static void FinishPrograma(){
        Application.Quit();

    }




}
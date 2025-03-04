using Gtk;
using NodoFactura;
using UserListSimple;
using VehiculosListaDoble;
class IShowFacture: Gtk.Window {

    private Entry inputID = new();
    private Entry inputID_Orden= new();
    private Entry inputTotal = new();
    private Contexto contexto;
    [Obsolete]
    public unsafe IShowFacture(Contexto contexto): base("Crear Vehiculos"){
        this.contexto = contexto;
        NodoFactura<T>* factura = (NodoFactura<T>*)this.contexto.facturaPila.ListaCola();
        if(factura == null){
            Console.WriteLine("No hay factura");
            Destroy();
            return;
            }

        inputID.Text = $"{factura->ID}";
        inputID_Orden.Text = $"{factura->ID_Orden}";
        inputTotal.Text = $"{factura->Total}";
        SetDefaultSize(250,300);
        SetPosition(WindowPosition.Center);

        VBox Container = new(false,5);
        Container.PackStart(inputID,false,false,5);
        Container.PackStart(inputID_Orden,false,false,5);
        Container.PackStart(inputTotal,false,false,5);
        Add(Container);
        ShowAll();
    }

        protected static void FinishPrograma(){
        Application.Quit();

    }




}
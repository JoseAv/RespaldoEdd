using System.Runtime.InteropServices;
using NodoVehiculos;

namespace VehiculosListaDoble {

    public unsafe class  VehiculosListaDoble<T> where T: unmanaged{

        public NodoVehiculos<T>* header = null;
        
        public bool InsertNewVehiculo(int ID, int ID_Usuario,string Marca,int Modelo,string Placa){
                // if(ComprobateIdUser(ID)){ return true;}
            NodoVehiculos<T>* newNodo = (NodoVehiculos<T>*)Marshal.AllocHGlobal(sizeof(NodoVehiculos<T>));
            newNodo->ID= ID;
            newNodo->ID_Usuario = ID_Usuario;
            newNodo->Marca = Marca;
            newNodo->Modelo=Modelo;
            newNodo->Placa=Placa;
            newNodo->sig=null;
            newNodo->atras=null;


            if(header == null){
                header = newNodo;
                return false;
            }
            NodoVehiculos<T>* NodoRun = header;
            while(NodoRun->sig != null){
                NodoRun= NodoRun->sig;
            }
            NodoRun->sig = newNodo;
            newNodo->atras = NodoRun;
            return false;
        }

    public void ViewVehiculos (){

        if(header == null) return; 
        NodoVehiculos<T>* vehiculos = header;
        while(vehiculos != null){
            Console.WriteLine("Vehiculos" + vehiculos->Marca);
            vehiculos= vehiculos->sig;
        }
    }

    public unsafe NodoVehiculos<T>* ComprobateIDVehiculos(int IDVehiculos){
        if(header == null) return null;

        NodoVehiculos<T>* temp = header;
        while(temp != null){
            if(temp->ID == IDVehiculos){
                return temp;
            }
            temp = temp->sig;
        }
        return null;
    }

    public unsafe void ReporVehiculos(){
        if(header == null){return;}
        var dotBuilder = new System.Text.StringBuilder();
         dotBuilder.AppendLine("digraph G {  rankdir=LR");

        // Primera iteración: Agregar los nodos
        NodoVehiculos<T>* temp = header;
        while (temp != null)
        {
            dotBuilder.AppendLine($"    \"{temp->ID}\" [label=\"ID: {temp->ID}\\nMarca: {temp->Marca}\"];");
            temp = temp->sig;
        }

        temp = header; 
        while (temp != null && temp->sig != null)
        {
            dotBuilder.AppendLine($"\"{temp->ID}\" -> \"{temp->sig->ID}\";");
            dotBuilder.AppendLine($" \"{temp->sig->ID}\" ->  \"{temp->ID}\" ;");
            temp = temp->sig;
        }

        dotBuilder.AppendLine("}");

        string dotFilePath = "Vehiculos.dot";
        System.IO.File.WriteAllText(dotFilePath, dotBuilder.ToString());
        Console.WriteLine($"Archivo DOT generado: {dotFilePath}");
        Grafico.GenerarImagen(dotFilePath, "Vehiculos.png");
        return;
    }




    }
}



namespace NodoVehiculos {
    public unsafe struct NodoVehiculos<T> where T:unmanaged{
        public int ID;
        public int ID_Usuario;
        public string Marca;
        public int Modelo;
        public string Placa;

        public NodoVehiculos<T>* sig;
        public NodoVehiculos<T>* atras;
    }
}
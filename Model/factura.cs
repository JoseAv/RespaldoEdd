using System.Runtime.InteropServices;
using NodoFactura;

namespace FacturaPila {

    public unsafe class  FacturaPila<T> where T: unmanaged{
        public NodoFactura<T>* header = null;  
        public int ID=1;
        public bool InsertNewFactura(int ID_Orden,float Total){
            NodoFactura<T>* newNodo = (NodoFactura<T>*)Marshal.AllocHGlobal(sizeof(NodoFactura<T>));
            newNodo->ID= ID++;
            newNodo->ID_Orden = ID_Orden;
            newNodo->Total = Total;
            newNodo->Cancelada = false;
            newNodo->sig = null;
            newNodo->Top = null;
            if(header == null){
                header = newNodo;
                header->Top = newNodo;
                return false;
            }

            NodoFactura<T>* NodoRun = header;
            while(NodoRun->sig != null){
                NodoRun= NodoRun->sig; 
            }
            NodoRun->sig = newNodo;
            header->Top = newNodo;
            return false;
        }

        public NodoFactura<T>* ListaPila(){
            if(header == null){return null;}
            if(header->sig == null && header->Cancelada == false){
                header->Cancelada = true;
                header->Top = null;
                return header;
            }
            NodoFactura<T>* NodoRun = header;
            while (NodoRun->sig != null && NodoRun->sig->Cancelada == false) {
                NodoRun = NodoRun->sig;
            }
            if (NodoRun->sig != null && NodoRun->sig->Cancelada == false) {
                NodoFactura<T>* lastNode = NodoRun->sig;
                lastNode->Cancelada = true;
                header->Top = NodoRun;

                return lastNode;
            }
            return null;
        }

    public unsafe void ReporFactura(){
        if(header == null){return;}
        var dotBuilder = new System.Text.StringBuilder();
         dotBuilder.AppendLine("digraph G {  rankdir=BT");

        // Primera iteración: Agregar los nodos
        NodoFactura<T>* temp = header;
        while(temp != null) {
            dotBuilder.AppendLine($" \"{temp->ID}\" [label=\"ID: {temp->ID}\\nTotalFactura: {temp->Total}\"];");
            temp = temp->sig;
        }
        temp = header; 

        while(temp->sig != null){
            dotBuilder.AppendLine($"\"{temp->ID}\" -> \"{temp->sig->ID}\" [dir=back];");
            temp = temp->sig;
        }

        dotBuilder.AppendLine("}");

        string dotFilePath = "Factura.dot";
        System.IO.File.WriteAllText(dotFilePath, dotBuilder.ToString());
        Console.WriteLine($"Archivo DOT generado: {dotFilePath}");
        Grafico.GenerarImagen(dotFilePath, "Factura.png");
        return;
    }

    
    }
}


namespace NodoFactura {

    public unsafe struct NodoFactura<T> where T:unmanaged{
        public int ID;
        public int ID_Orden;
        public float Total;
        public bool Cancelada;
        public NodoFactura<T>* Top;
        public NodoFactura<T>* sig;
    }
}

using System.Runtime.InteropServices;
using NodoRepuestos;

namespace RepuestosListaCircular {

    public unsafe class  RepuestosListaCircular<T> where T: unmanaged{
        public NodoRepuestos<T>* header = null;  
        public bool InsertNewRepuesto(int ID,string Repuesto,string Detalles,float Costo){
                // if(ComprobateIdUser(ID)){ return true;}
            NodoRepuestos<T>* newNodo = (NodoRepuestos<T>*)Marshal.AllocHGlobal(sizeof(NodoRepuestos<T>));
            newNodo->ID= ID;
            newNodo->Repuesto = Repuesto;
            newNodo->Detalles = Detalles;
            newNodo->Costo=Costo;
            newNodo->sig=null;
            newNodo->atras=null;

            if(header == null){
                header = newNodo;
                header->atras = header;
                header->sig = header;
                return false;
            }

            NodoRepuestos<T>* NodoRun = header;
            while(NodoRun->sig != header){
                NodoRun= NodoRun->sig;
            }
            NodoRun->sig = newNodo;
            newNodo->atras = NodoRun;
            newNodo->sig = header;
            header->atras = newNodo;
            return false;
        }

    public void viewRepuestos(){
        if(header == null){
            return;
        }

        NodoRepuestos<T>* NodoRun = header;
        do{
            Console.WriteLine("Nombre" + NodoRun->Repuesto);
            NodoRun= NodoRun->sig;

        }while(NodoRun != header);
        return;
    }

    }
}

namespace NodoRepuestos {
    public unsafe struct NodoRepuestos<T> where T:unmanaged{
        public int ID;
        public string Repuesto;
        public string Detalles;
        public float Costo;
        public NodoRepuestos<T>* sig;
        public NodoRepuestos<T>* atras;
    }
}

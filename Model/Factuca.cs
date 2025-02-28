using System.Runtime.InteropServices;
using NodoFactura;

namespace FacturaCola {

    public unsafe class  FacturaCola<T> where T: unmanaged{
        public NodoFactura<T>* header = null;  
        public int ID=1;
        public bool InsertNewServicio(int ID_Orden,float Total){
                // if(ComprobateIdUser(ID)){ return true;}

            NodoFactura<T>* newNodo = (NodoFactura<T>*)Marshal.AllocHGlobal(sizeof(NodoFactura<T>));
            newNodo->ID= ID++;
            newNodo->ID_Orden = ID_Orden;
            newNodo->Total = Total;
            newNodo->sig = null;

            if(header == null){
                header = newNodo;
                return false;
            }

            NodoFactura<T>* NodoRun = header;
            while(NodoRun->sig != null){
                NodoRun= NodoRun->sig;
            }
            NodoRun->sig = newNodo;
            return false;
        }

        public void ListaCola(){
            if(header == null){return;}
            if(header->sig == null){
            NodoFactura<T>* temp = header;
            header = null;
           Marshal.FreeHGlobal((IntPtr)temp);
           return;
            }
            NodoFactura<T>* NodoRun = header;
            while(NodoRun->sig->sig != null){
                NodoRun= NodoRun->sig;
            }
            NodoFactura<T>* lastNode = NodoRun->sig;
            NodoRun->sig = null;
            Marshal.FreeHGlobal((IntPtr)lastNode);
            return;
        }



    }
}


namespace NodoFactura {

    public unsafe struct NodoFactura<T> where T:unmanaged{
        public int ID;
        public int ID_Orden;
        public float Total;
        public NodoFactura<T>* sig;
    }
}

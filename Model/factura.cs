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

        public NodoFactura<T>* ListaCola(){
            if(header == null){return null;}
            if(header->sig == null){
            NodoFactura<T>* temp = header;
            header = null;
           return temp;
            }
            NodoFactura<T>* NodoRun = header;
            while(NodoRun->sig->sig != null){
                NodoRun= NodoRun->sig;
            }
            NodoFactura<T>* lastNode = NodoRun->sig;
            NodoRun->sig = null;
            return lastNode;
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

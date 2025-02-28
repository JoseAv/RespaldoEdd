using System.Runtime.InteropServices;
using FacturaPila;
using NodoRepuestos;
using NodoServicios;

namespace ServiciosCola {

    public unsafe class  ServiciosCola<T> where T: unmanaged{
        public NodoServicios<T>* header = null;  
        public FacturaPila<int> facturaPila;
        public  ServiciosCola(FacturaPila<int> facturaPila){
            this.facturaPila = facturaPila;
        }
        public bool InsertNewServicio(int ID,int ID_Repuesto,int ID_vehiculos,float Costo){
                // if(ComprobateIdUser(ID)){ return true;}

            NodoServicios<T>* newNodo = (NodoServicios<T>*)Marshal.AllocHGlobal(sizeof(NodoServicios<T>));
            newNodo->ID= ID;
            newNodo->ID_Repuesto = ID_Repuesto;
            newNodo->ID_vehiculos = ID_vehiculos;
            newNodo->Costo=Costo;
            newNodo->sig = null;

            if(header == null){
                header = newNodo;
                return false;
            }

            NodoServicios<T>* NodoRun = header;
            while(NodoRun->sig != null){
                NodoRun= NodoRun->sig;
            }
            NodoRun->sig = newNodo;
            

            return false;
        }

        public void ListaCola(){
            if(header == null){return;}
            NodoServicios<T>* NodoRun = header;
            header= header->sig;
            NodoRun = null;
            Marshal.FreeHGlobal((IntPtr)NodoRun);
            return;
        }



    }
}

namespace NodoServicios {
    public unsafe struct NodoServicios<T> where T:unmanaged{
        public int ID;
        public int ID_Repuesto;
        public int ID_vehiculos;
        public string Detalles;
        public float Costo;
        public NodoServicios<T>* sig;
        
    }
}



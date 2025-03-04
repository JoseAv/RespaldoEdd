using System.Runtime.InteropServices;
using FacturaPila;
using NodoRepuestos;
using NodoServicios;
using NodoVehiculos;
using RepuestosListaCircular;
using VehiculosListaDoble;

namespace ServiciosCola {

    public unsafe class  ServiciosCola<T> where T: unmanaged{
        public NodoServicios<T>* header = null;  
        public FacturaPila<int> facturaPila;
        public RepuestosListaCircular<int> ListaRepuestos;
        public VehiculosListaDoble<int> ListaVehiculos;
        public  ServiciosCola(FacturaPila<int> facturaPila, RepuestosListaCircular<int> ListaRepuestos, VehiculosListaDoble<int> ListaVehiculos){
            this.facturaPila = facturaPila;
            this.ListaRepuestos = ListaRepuestos;
            this.ListaVehiculos = ListaVehiculos;
        }
        public bool InsertNewServicio(int ID,int ID_Repuesto,int ID_vehiculos,string Detalles,float Costo){
            NodoRepuestos<T>* Repuestos = (NodoRepuestos<T>*)this.ListaRepuestos.ComprobateIdRpuestos(ID_Repuesto);
            NodoVehiculos<T>* Vehiculos = (NodoVehiculos<T>*)this.ListaVehiculos.ComprobateIDVehiculos(ID_vehiculos);

            if(Repuestos == null || Vehiculos == null){
                Console.WriteLine("Datos no aceptados");
                return true;
            }

                Console.WriteLine("Repeustos" + Repuestos->Detalles);
                Console.WriteLine("Vehiculos" + Vehiculos->ID);


            NodoServicios<T>* newNodo = (NodoServicios<T>*)Marshal.AllocHGlobal(sizeof(NodoServicios<T>));
            newNodo->ID= ID;
            newNodo->ID_Repuesto = ID_Repuesto;
            newNodo->ID_vehiculos = ID_vehiculos;
            newNodo->Costo=Costo;
            newNodo->Detalles=Detalles;
            newNodo->sig = null;
            float total = Repuestos->Costo + Costo;
            if(header == null){
                header = newNodo;
                this.facturaPila.InsertNewFactura(ID, total);
                return false;
            }

            NodoServicios<T>* NodoRun = header;
            while(NodoRun->sig != null){
                NodoRun= NodoRun->sig;
            }
            NodoRun->sig = newNodo;
            this.facturaPila.InsertNewFactura(ID, total);

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

        public void ViewSercios(){
            if(header == null){
                Console.WriteLine("No hay datos aun");
                return;
            }
            NodoServicios<T>* temp = header;
            while(temp != null){
                Console.WriteLine("Esto es un servicios" + temp->Detalles);
                temp = temp->sig;
            }
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



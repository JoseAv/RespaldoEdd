using System.Runtime.InteropServices;
using NodoUser;

namespace UserListSimple {

    public unsafe class  UserListSimple<T> where T: unmanaged{

        public NodoUser<T>* header = null;
        
        public bool InsertNewUser(int ID, string Nombres,string Apellidos,string Correo,string Contrasenia){
            if(ComprobateIdUser(ID)){ return true;}

            NodoUser<T>* newNodo = (NodoUser<T>*)Marshal.AllocHGlobal(sizeof(NodoUser<T>));
            newNodo->ID= ID;
            newNodo->Nombres = Nombres;
            newNodo->Apellidos = Apellidos;
            newNodo->Correo=Correo;
            newNodo->Contrasenia=Contrasenia;
            newNodo->sig=null;

            if(header == null){
                header = newNodo;
                return false;
            }
            NodoUser<T>* NodoRun = header;
            while(NodoRun->sig != null){
                NodoRun= NodoRun->sig;
            }
            NodoRun->sig = newNodo;
            return false;
        }


        public bool DeleteUser(int ID){
            if(header == null){
                return true;
            }
            if(header->ID == ID){
                header = header->sig;
                return false;
            }

            NodoUser<T>* NodoRun = header;
            NodoUser<T>* prev = null;
            while(NodoRun->sig != null && NodoRun->ID != ID){
                prev = NodoRun;
                NodoRun = NodoRun->sig;
            }
            if(NodoRun->ID != ID){
                return true;
            }
            prev->sig = NodoRun->sig;
            return false;
        }

        public bool EditUser(int ID, string? Nombres,string? Apellidos,string? Correo,string? Contrasenia){

        if(header == null){
            return true;
        }
        NodoUser<T>* NodoRun = header;
        while(NodoRun->sig != null && NodoRun->ID != ID){
            NodoRun= NodoRun->sig;
        }
        if(NodoRun->ID != ID){
                return true;
            }
            NodoRun->Nombres = Nombres ?? NodoRun->Nombres;
            NodoRun->Apellidos = Apellidos ?? NodoRun->Apellidos;
            NodoRun->Correo=Correo ?? NodoRun->Correo;
            NodoRun->Contrasenia = Contrasenia ?? NodoRun->Contrasenia;
            return false;
        }
        public bool ComprobateIdUser(int ID){
        if(header == null){
                return false;
        }
         NodoUser<T>* NodoRun = header;
         while(NodoRun->sig != null && NodoRun->ID!=ID){
            NodoRun= NodoRun->sig;
         }
         if(NodoRun->ID != ID){
            return false;
         }
            return true;
        }


    public unsafe NodoUser<T>* SearchNodo(int ID){
        if (header == null)
        {
        return null; 
        }
            NodoUser<T>* current = header;
            do
            {
                if (current->ID == ID)
                {
                    return current; 
                }
                current = current->sig;
            } while (current != header);
            return null;
        } 

    public  void ViewUsuarios(){
    if (header == null)
        {
        return; 
        }
        NodoUser<T>* RunNodo = header;
        do{
            Console.WriteLine($"Nombres: {RunNodo->Nombres} Apellidos: {RunNodo->Apellidos}");
            RunNodo= RunNodo->sig;

        }while(RunNodo->sig != null);
        Console.WriteLine($"Nombres: {RunNodo->Nombres} Apellidos: {RunNodo->Apellidos}");


    }

    }
}
namespace NodoUser {

    public unsafe struct NodoUser<T> where T:unmanaged{
        public int ID;
        public string Nombres;
        public string Apellidos;
        public string Correo;
        public string Contrasenia;
        public NodoUser<T>* sig;
    }
}

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
            if(header == null){return true;}

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


    public unsafe NodoUser<T>* SearchUser(int ID){
        if (header == null)
        {
        return null; 
        }
            NodoUser<T>* current = header;
            while(current != null){
                if(current->ID == ID){
                    return current;
                }
                current = current->sig;
            }
            return null;
        } 

    public unsafe  void ViewUsuarios(){
    if (header == null)
        {
        return; 
        }
        NodoUser<T>* RunNodo = header;
    while (RunNodo != null)
    {
        Console.WriteLine($"Nombres: {RunNodo->Nombres}, Apellidos: {RunNodo->Apellidos}");
        RunNodo = RunNodo->sig;
    }
    }

    public unsafe void ReporUser(){
        if(header == null){return;}
        var dotBuilder = new System.Text.StringBuilder();
         dotBuilder.AppendLine("digraph G {  rankdir=LR");

        // Primera iteración: Agregar los nodos
        NodoUser<T>* temp = header;
        while (temp != null)
        {
            dotBuilder.AppendLine($"    \"{temp->ID}\" [label=\"ID: {temp->ID}\\nNombre: {temp->Nombres}\"];");
            temp = temp->sig;
        }

        temp = header; 
        while (temp != null && temp->sig != null)
        {
            dotBuilder.AppendLine($"    \"{temp->ID}\" -> \"{temp->sig->ID}\";");
            temp = temp->sig;
        }

        dotBuilder.AppendLine("}");

        string dotFilePath = "Usuarios.dot";
        System.IO.File.WriteAllText(dotFilePath, dotBuilder.ToString());
        Console.WriteLine($"Archivo DOT generado: {dotFilePath}");
        Grafico.GenerarImagen(dotFilePath, "Usuarios.png");
        return;
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

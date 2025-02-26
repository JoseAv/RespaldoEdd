using UserListSimple;

class Contexto {

    public UserListSimple<int>  ListaUsuarios;
    public unsafe Contexto(UserListSimple<int>  ListaUsuarios){
        this.ListaUsuarios = ListaUsuarios;
    }



}
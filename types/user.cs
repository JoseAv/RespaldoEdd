class User {
    public int ID {get;set;}
    public string Nombres {get;set;}
    public string Apellidos {get;set;}
    public string Correo {get;set;}
    public string Contrasenia {get;set;}

    public User(int ID, string Nombres,string Apellidos, string Correo, string Contrasenia){
            this.ID=ID;
            this.Nombres=Nombres;
            this.Apellidos=Apellidos;
            this.Correo=Correo;
            this.Contrasenia=Contrasenia;
    }    
}

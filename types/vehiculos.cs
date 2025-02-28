class Vehiculos {
    public int ID {get;set;}
    public int ID_Usuario {get;set;}
    public string Marca {get;set;}
    public int Modelo {get;set;}
    public string Placa {get;set;}
    public Vehiculos(int ID,int ID_Usuario, string Marca,int Modelo, string Placa){
            this.ID=ID;
            this.ID_Usuario=ID_Usuario;
            this.Marca=Marca;
            this.Modelo=Modelo;
            this.Placa=Placa;
    }    
}
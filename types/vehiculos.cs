class Vehiculos {
    public int ID {get;set;}
    public int ID_Usuario {get;set;}
    public string Marca {get;set;}
    public string Modelo {get;set;}
    public string Placa {get;set;}
    public int Anio {get;set;}

    public Vehiculos(int ID,int ID_Usuario, string Marca,string Modelo, string Placa, int Anio){
            this.ID=ID;
            this.ID_Usuario=ID_Usuario;
            this.Marca=Marca;
            this.Modelo=Modelo;
            this.Placa=Placa;
            this.Anio=Anio;
    }    
}
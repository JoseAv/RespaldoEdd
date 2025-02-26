class Repuestos {
    public int ID {get;set;}
    public string Repuesto {get;set;}
    public string Detalles {get;set;}
    public float Costo {get;set;}

    public Repuestos(int ID, string Repuesto,string Detalles, float Costo){
            this.ID=ID;
            this.Repuesto=Repuesto;
            this.Detalles=Detalles;
            this.Costo=Costo;
    }    
}


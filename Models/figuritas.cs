namespace Album.Models;

public class Figuritas
{
    public string Nombre { get; set; }
    public int Numero { get; set; }
    public string Imagen { get; set; }
    public bool yaPegada {get; set;}
    public int cantEnPosesion {get; set;}
    
    Figuritas(string nombre, int numero, string imagen)
    {
        this.Nombre = nombre;
        this.Numero = numero;
        this.Imagen = "fondo.png";
        yaPegada = false;
        cantEnPosesion = 0;
    }
}
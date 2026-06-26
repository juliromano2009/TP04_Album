namespace Album.Models;

public class figuritas
{
    public string Nombre { get; set; }
    public int Numero { get; set; }
    public string Imagen { get; set; }

    
    public figuritas(string nombre, int numero, string imagen)
    {
        this.Nombre = nombre;
        this.Numero = numero;
        this.Imagen = "fondo.png";
    }

}
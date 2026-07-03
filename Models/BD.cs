using Microsoft.Data.SqlClient;
using Dapper; 

namespace Album.Models;

public class BD 
{
    public string _connectionString = @"Server=localhost; DataBase = Album; Integrated Security=True; TrustServerCertificate=True;"; 

    public List<Figuritas> ListaFiguritas()
    {
        List <Figuritas> figuritas = new List<Figuritas>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Nombre, Numero, Imagen FROM Jugadores";
            figuritas = connection.Query<Figuritas>(query).ToList();
        }
        return figuritas; 
    }

    public List<Figuritas> ListaFiguritasPorUsuario()
    {
        List <Figuritas> figuritas = new List<Figuritas>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Nombre, Numero, Imagen FROM figuritas_x_usuario "; 
            figuritas = connection.Query<Figuritas>(query).ToList();
        }
        return figuritas; 
    }

    public List<Figuritas> AbrirSobre ()
    {
        Random random = new Random ();
        List <Figuritas> sobre = new List<Figuritas>();
        List<Figuritas> figuritas = new List<Figuritas>();
        figuritas = ListaFiguritas(); 
        for (int i = 0 ; i < 5 ; i++)
        {
            int x = random.Next(0, figuritas.Count);
            sobre.Add(figuritas[x]);
        }
         return sobre;   
    }

    public void ConfimarSobre ()
    {
        List <Figuritas> sobre = AbrirSobre();
        for (int i = 0 ; i < sobre.Count ; i++)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO figuritas_x_usuario (Nombre, Numero, Imagen) VALUES (@Nombre, @Numero, @Imagen)";
                connection.Execute(query, new { Nombre = sobre[i].Nombre, Numero = sobre[i].Numero, Imagen = sobre[i].Imagen });
            }
        }
    }

    public int pedirCantSelecciones()
    {
        int cantidad;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT ID FROM Selecciones";
            cantidad = connection.Execute(query);
        }
        return cantidad;
    }
    public List<string> pedirNombreSeleccion()
    {
        List<string> nombreSelecciones = new List<string>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
                string query = "SELECT pais FROM Selecciones ORDER BY ID ASC";
                connection.Query<string>(query).ToList();
        }
        return nombreSelecciones;
    }
}


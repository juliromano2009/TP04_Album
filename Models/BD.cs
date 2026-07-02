using Microsoft.Data.SqlClient;
using Dapper; 

namespace Album.Models;

public class BD 
{
    public string _connectionString = @"Server=localhost; DataBase = Album; Integrated Security=True; TrustServerCertificate=True;"; 

    public List<figuritas> ListaFiguritas()
    {
        List <Figuritas> figuritas = new List<Figuritas>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Nombre, Numero, Imagen FROM Figuritas";
            figuritas = connection.Query<figuritas>(query).ToList();
        }
        return figuritas; 
    }

    public List<figuritas> ListaFiguritasPorUsuario(int numero)
    {
        List <figuritas> figuritas = new List<figuritas>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Nombre, Numero, Imagen FROM figuritas_x_usuario ";
            figuritas = connection.Query<figuritas>(query, new { Numero = numero }).ToList();
        }
        return figuritas; 
    }

    public List<figuritas> AbrirSobre ()
    {
        Random random = new Random ();
        List <figuritas> sobre = new List<figuritas>();
        List<figuritas> figuritas = new List<figuritas>();
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
        List <figuritas> sobre = AbrirSobre();
        

     }
}


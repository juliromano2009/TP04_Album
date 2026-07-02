using Microsoft.Data.SqlClient;
using Dapper; 

namespace tp3.Models; 

public class BD 
{
    public string _connectionString = @"Server=localhost; DataBase = Album; Integrated Security=True; TrustServerCertificate=True;"; 

    public List<Figuritas> ListaFiguritas()
    {
        List <Figuritas> figuritas = new List<Figuritas>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Nombre, Numero, Imagen FROM Figuritas";
            figuritas = connection.Query<Figuritas>(query).ToList();
        }
        return figuritas; 
    }

    public List<Figuritas> ListaFiguritasPorUsuario(int numero)
    {
        List <Figuritas> figuritas = new List<Figuritas>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Nombre, Numero, Imagen FROM figuritas_x_usuario ";
            figuritas = connection.Query<Figuritas>(query, new { Numero = numero }).ToList();
        }
        return figuritas; 
    }

    public List<Figuritas> AbrirSobre ()
    {
        Random random = new Random ();
       
        List <Figuritas> sobre = new List<Figuritas>();
        List<Figuritas> figuritas = new List<Figuritas>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Nombre, Numero, Imagen FROM Figuritas";
            figuritas = connection.Query<Figuritas>(query).ToList();
        } 
        int x = random.Next(0, figuritas.Count);

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
     }
}


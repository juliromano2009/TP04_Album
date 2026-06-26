using Microsoft.Data.SqlClient;
using Dapper; 

namespace tp3.Models; 

public class BD 
{
    public string _connectionString = @"Server=localhost; DataBase = Album; Integrated Security=True; TrustServerCertificate=True;"; 

    public List<string> hacerLista()
    {
        List <string> palabras = new List<string>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Texto FROM Palabras";
            palabras = connection.Query<string>(query).ToList();
        }
        return palabras; 
    }
}
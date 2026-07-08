using Microsoft.Data.SqlClient;
using Dapper;
 
namespace Album.Models;
 
public class BD
{
    public string _connectionString = @"Server=localhost; DataBase = Album; Integrated Security=True; TrustServerCertificate=True;";
 
    public List<Figuritas> ListaFiguritas()
    {
        List<Figuritas> figuritas = new List<Figuritas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT nombre AS Nombre, ID AS Numero, img AS Imagen, ID_seleccion AS idSeleccion
                              FROM Jugador";
            figuritas = connection.Query<Figuritas>(query).ToList();
        }
        return figuritas;
    }
 
    public List<Figuritas> ListaFiguritasPorUsuario()
    {
        List<Figuritas> figuritas = new List<Figuritas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT j.nombre AS Nombre, j.ID AS Numero, j.img AS Imagen, j.ID_seleccion AS idSeleccion, f.cantidad AS cantEnPosesion
                              FROM figuritas_x_usuario f
                              INNER JOIN Jugador j ON j.ID = f.ID_Jugador";
            figuritas = connection.Query<Figuritas>(query).ToList();
        }
        return figuritas;
    }

    public List<Figuritas> AbrirSobre()
    {
        Random random = new Random();
        List<Figuritas> sobre = new List<Figuritas>();
        List<Figuritas> figuritas = ListaFiguritas();
 
        for (int i = 0; i < 5; i++)
        {
            int x = random.Next(0, figuritas.Count);
            sobre.Add(figuritas[x]);
        }
        return sobre;
    }
 
    public void ConfimarSobre(List<Figuritas> sobre)
    {
        for (int i = 0; i < sobre.Count; i++)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    IF EXISTS (SELECT 1 FROM figuritas_x_usuario WHERE ID_Jugador = @ID_Jugador)
                        UPDATE figuritas_x_usuario
                        SET cantidad = cantidad + 1
                        WHERE ID_Jugador = @ID_Jugador
                    ELSE
                        INSERT INTO figuritas_x_usuario (ID, ID_Jugador, cantidad)
                        VALUES ((SELECT ISNULL(MAX(ID), 0) + 1 FROM figuritas_x_usuario), @ID_Jugador, 1)";
 
                connection.Execute(query, new { ID_Jugador = sobre[i].Numero });
            }
        }
    }
 
    public int pedirCantSelecciones()
    {
        int cantidad;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT COUNT(*) FROM Selecciones";
            cantidad = connection.ExecuteScalar<int>(query);
        }
        return cantidad;
    }

    public List<string> pedirNombreSeleccion()
    {
        List<string> nombreSelecciones = new List<string>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT pais FROM Selecciones ORDER BY ID ASC";
            nombreSelecciones = connection.Query<string>(query).ToList();
        }
        return nombreSelecciones;
    }
}
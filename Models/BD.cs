
using Microsoft.Data.SqlClient;
using Dapper;
namespace Album.Models;
 
public class BD
{
    public string _connectionString = @"Server=localhost; DataBase = Album; Integrated Security=True; TrustServerCertificate=True;";
    List<Figuritas> figuritas = new List<Figuritas>();

 
    public List<Figuritas> ListaFiguritas()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT Nombre AS Nombre, ID AS Numero, Imagen AS Imagen, IDSeleccion AS idSeleccion
                              FROM Jugadores";
            return connection.Query<Figuritas>(query).ToList();
        }
    }
 
    public List<Figuritas> ListaFiguritasPorUsuario()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT j.Nombre AS Nombre, j.ID AS Numero, j.Imagen AS Imagen, j.IDSeleccion AS idSeleccion, f.Cantidad AS cantEnPosesion
                              FROM Figuritas_X_Usuario f
                              INNER JOIN Jugadores j ON j.ID = f.IDFigurita";
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
 
public void ConfirmarSobre(List<int> sobre)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        foreach (var idFigurita in sobre)
        {
            string query = @"
                IF EXISTS (SELECT 1 FROM Figuritas_X_Usuario WHERE IDFigurita = @ID_Jugador)
                    UPDATE Figuritas_X_Usuario
                    SET Cantidad = Cantidad + 1
                    WHERE IDFigurita = @ID_Jugador
                ELSE
                    INSERT INTO Figuritas_X_Usuario (ID, IDFigurita, Cantidad)
                    VALUES ((SELECT ISNULL(MAX(ID), 0) + 1 FROM Figuritas_X_Usuario), @ID_Jugador, 1)";

            connection.Execute(query, new { ID_Jugador = idFigurita });
            figuritas[idFigurita].cantEnPosesion += 1; 
            
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
 
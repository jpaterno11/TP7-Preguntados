using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

public static class BD
{
    private static List<Categoria> _listaCategorias;
    private static List<Dificultades> _listaDificultades;

    private static string _connectionString = @"Server=localhost; DataBase=PreguntadOrt ; Trusted_Connection=True;";

    public static List<Categoria> ObtenerCategorias()
    {
        string query = "SELECT * FROM Categorias";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return _listaCategorias = db.Query<Categoria>(query).AsList();
        }
    }

    public static List<Dificultades> ObtenerDificultades()
    {
        string query = "SELECT * FROM Dificultades";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return _listaDificultades = db.Query<Dificultades>(query).AsList();
        }
    }

    public static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria)
    {
        string query = "SELECT * FROM Preguntas WHERE (@IdDificultad = -1 OR IdDificultad = @IdDificultad) AND (@IdCategoria = -1 OR IdCategoria = @IdCategoria)"; //creo que esta mal la condicion pero es lo primeor que se me ocurrio
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Preguntas>(query, new { IdDificultades = dificultad, IdCatergoria = categoria }).AsList();
        }
    }

    public static Respuestas ObtenerRespuestas(int idPregunta)
    {
        string query = "SELECT * FROM Respuestas WHERE IdPregunta = @IdPregunta";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.QuerySingleOrDefault<Respuestas>(query, new { IdPregunta = idPregunta });
        }
    }
    public static List<Respuestas> ObtenerRespuestas()
    {
        string query = "SELECT * FROM Respuestas";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Respuestas>(query).AsList();
        }
    }
}

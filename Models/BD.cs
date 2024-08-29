using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

public static class BD
{
    private static List<Catergoria> _listaCategorias;
    private static List<Dificultades> _listaDificultades;

    private static string _connectionString = @"Server=localhost; DataBase=PreguntadOrt ; Trusted_Connection=True;";

    public static List<Categoria> ObtenerCategorias()
    {
        string query = "SELECT * FROM Categorias";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Categoria>(query).AsList();
        }
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        string query = "SELECT * FROM Dificultades";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Dificultad>(query).AsList();
        }
    }

    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        string query = "SELECT * FROM Preguntas WHERE (@IdDificultad = -1 OR IdDificultad = @IdDificultad) AND (@IdCategoria = -1 OR IdCategoria = @IdCategoria)"; //creo que esta mal la condicion pero es lo primeor que se me ocurrio
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Pregunta>(query, new { IdDificultad = dificultad, IdCategoria = categoria }).AsList();
        }
    }

    public static List<Respuesta> ObtenerRespuestas(int idPregunta)
    {
        string query = "SELECT * FROM Respuestas WHERE IdPregunta = @IdPregunta";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Respuesta>(query, new { IdPregunta = idPregunta }).AsList();
        }
    }
}

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
        string query = "SELECT * FROM Preguntas"; //creo que esta mal la condicion pero es lo primeor que se me ocurrio
        if (dificultad != -1 || categoria != -1)
        {
        query += " WHERE ";
        if (dificultad != -1)
        {
            query += "IdDificultad = " + dificultad;
        }
        else
        {
            query += "IdCategoria = " + categoria;
        }
        if (dificultad != -1 && categoria != -1)
        {
            query += "IdDificultad = " + dificultad + " AND IdCategoria = " + categoria;
        }
        }
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Preguntas>(query, new { IdDificultad = dificultad, IdCategoria = categoria }).AsList();
        }
    }

    public static List<Respuestas> ObtenerRespuestas(int idPregunta)
    {
        string query = "SELECT * FROM Respuestas WHERE IdPregunta = @IdPregunta";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Respuestas>(query, new { IdPregunta = idPregunta }).AsList();
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

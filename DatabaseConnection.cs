using Microsoft.Data.SqlClient;
using System;

public class DatabaseConnection
{
    private static string connectionString = 
    "Server=DESKTOP-QOV5IN0\\SQLEXPRESS;Database=RecipeSysDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";
    
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

}
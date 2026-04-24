using Microsoft.Data.SqlClient;

public static class RecipeHelper
{
    public static void AddRecipe(List<Recipe> recipes)
    {
        try
        {

            Console.WriteLine("Ingrese el nombre de la receta:");
            string name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese los ingredientes (separados por comas):");
            string ingredients = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese el tiempo de preparación (en minutos): ");
            int preparationTime = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Ingrese la categoria (Desayuno, Almuerzo, Cena, Postre): ");
            string category = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese la dificultad (Fácil, Media, Difícil): ");
            string difficulty = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite los pasos para la preparacion (separados por comas): ");
            string instructions = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese el número de porciones: ");
            int portions = int.Parse(Console.ReadLine() ?? "0");

            // Guardar en base de datos
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Recipes 
                    (Name, Ingredients, PreparationTime, Category, Difficulty, Instructions, Portions)
                    VALUES (@Name, @Ingredients, @PreparationTime, @Category, @Difficulty, @Instructions, @Portions)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Ingredients", ingredients);
                cmd.Parameters.AddWithValue("@PreparationTime", preparationTime);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Difficulty", difficulty);
                cmd.Parameters.AddWithValue("@Instructions", instructions);
                cmd.Parameters.AddWithValue("@Portions", portions);

                cmd.ExecuteNonQuery();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Receta agregada exitosamente.");
            Console.ResetColor();

        }

        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al agregar la receta: {ex.Message}");
            Console.ResetColor();
        }
    }

    public static void ShowRecipes(List<Recipe> recipes)
    {
        try
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Recipes";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay recetas para mostrar.");
                    Console.ResetColor();
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine("============================");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID: {reader["Id"]}");
                    Console.ResetColor();
                    Console.WriteLine($"Nombre: {reader["Name"]}");
                    Console.WriteLine($"Categoría: {reader["Category"]}");
                    Console.WriteLine($"Dificultad: {reader["Difficulty"]}");
                    Console.WriteLine($"Ingredientes: {reader["Ingredients"]}");
                    Console.WriteLine($"Tiempo: {reader["PreparationTime"]} minutos");
                    Console.WriteLine($"Instrucciones: {reader["Instructions"]}");
                    Console.WriteLine($"Porciones: {reader["Portions"]}");
                    Console.WriteLine($"Creado el: {reader["CreatedAt"]}");
                    Console.WriteLine("============================");
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al mostrar las recetas: {ex.Message}");
            Console.ResetColor();
        }
    }

    public static void SearchByName(List<Recipe> recipes)
    {
        try
        {
            Console.WriteLine("Ingrese el nombre de la receta que desea buscar:");
            string name = Console.ReadLine() ?? string.Empty;

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Recipes WHERE Name LIKE @Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", $"%{name}%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No se encontraron recetas con ese nombre.");
                    Console.ResetColor();
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine("\n============================");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID: {reader["Id"]}");
                    Console.ResetColor();
                    Console.WriteLine($"Nombre: {reader["Name"]}");
                    Console.WriteLine($"Categoría: {reader["Category"]}");
                    Console.WriteLine($"Dificultad: {reader["Difficulty"]}");
                    Console.WriteLine($"Ingredientes: {reader["Ingredients"]}");
                    Console.WriteLine($"Tiempo: {reader["PreparationTime"]} minutos");
                    Console.WriteLine($"Instrucciones: {reader["Instructions"]}");
                    Console.WriteLine($"Porciones: {reader["Portions"]}");
                    Console.WriteLine("============================");
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al buscar: {ex.Message}");
            Console.ResetColor();
        }
    }

    public static void ShowRecipes (List<Recipe> recipes, string category)
    {
        try
        {
            
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Recipes WHERE Category = @Category";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Category", category);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No se encontraron recetas en esa categoría.");
                    Console.ResetColor();
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine("\n============================");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID: {reader["Id"]}");
                    Console.ResetColor();
                    Console.WriteLine($"Nombre: {reader["Name"]}");
                    Console.WriteLine($"Categoría: {reader["Category"]}");
                    Console.WriteLine($"Dificultad: {reader["Difficulty"]}");
                    Console.WriteLine($"Tiempo: {reader["PreparationTime"]} minutos");
                    Console.WriteLine("============================");
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al filtrar: {ex.Message}");
            Console.ResetColor();
        }
    }

    public static void FilterByDifficulty(List<Recipe> recipes, string difficulty)
    {
        try
        {


            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Recipes WHERE Difficulty = @Difficulty";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Difficulty", difficulty);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No se encontraron recetas con esa dificultad.");
                    Console.ResetColor();
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine("\n============================");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID: {reader["Id"]}");
                    Console.ResetColor();
                    Console.WriteLine($"Nombre: {reader["Name"]}");
                    Console.WriteLine($"Dificultad: {reader["Difficulty"]}");
                    Console.WriteLine($"Tiempo: {reader["PreparationTime"]} minutos");
                    Console.WriteLine("============================");
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al filtrar: {ex.Message}");
            Console.ResetColor();
        }
    }

    public static void ShowRecipes(List<Recipe> recipes, int maxTime)
    {
        try
        {


            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Recipes WHERE PreparationTime <= @MaxTime";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaxTime", maxTime);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No se encontraron recetas en ese tiempo.");
                    Console.ResetColor();
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine("\n============================");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID: {reader["Id"]}");
                    Console.ResetColor();
                    Console.WriteLine($"Nombre: {reader["Name"]}");
                    Console.WriteLine($"Tiempo: {reader["PreparationTime"]} minutos");
                    Console.WriteLine("============================");
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al filtrar: {ex.Message}");
            Console.ResetColor();
        }
    }

    public static void EditRecipe(List<Recipe> recipes)
    {
        try
        {
            Console.WriteLine("Ingrese el ID de la receta que desea editar:");
            int id = int.Parse(Console.ReadLine() ?? "0");

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Verificar que existe
                string checkQuery = "SELECT * FROM Recipes WHERE Id = @Id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se encontró una receta con ese ID.");
                    Console.ResetColor();
                    return;
                }

                reader.Read();
                string currentName = reader["Name"].ToString() ?? "";
                string currentIngredients = reader["Ingredients"].ToString() ?? "";
                int currentTime = (int)reader["PreparationTime"];
                string currentCategory = reader["Category"].ToString() ?? "";
                string currentDifficulty = reader["Difficulty"].ToString() ?? "";
                string currentInstructions = reader["Instructions"].ToString() ?? "";
                int currentPortions = (int)reader["Portions"];
                reader.Close();

                Console.WriteLine("(Presione Enter para mantener el valor actual)");

                Console.WriteLine($"Nombre actual: {currentName}");
                string input = Console.ReadLine() ?? "";
                string newName = string.IsNullOrWhiteSpace(input) ? currentName : input;

                Console.WriteLine($"Ingredientes actuales: {currentIngredients}");
                input = Console.ReadLine() ?? "";
                string newIngredients = string.IsNullOrWhiteSpace(input) ? currentIngredients : input;

                Console.WriteLine($"Tiempo actual: {currentTime} minutos");
                input = Console.ReadLine() ?? "";
                int newTime = string.IsNullOrWhiteSpace(input) ? currentTime : int.Parse(input);

                Console.WriteLine($"Categoría actual: {currentCategory}");
                input = Console.ReadLine() ?? "";
                string newCategory = string.IsNullOrWhiteSpace(input) ? currentCategory : input;

                Console.WriteLine($"Dificultad actual: {currentDifficulty}");
                input = Console.ReadLine() ?? "";
                string newDifficulty = string.IsNullOrWhiteSpace(input) ? currentDifficulty : input;

                Console.WriteLine($"Instrucciones actuales: {currentInstructions}");
                input = Console.ReadLine() ?? "";
                string newInstructions = string.IsNullOrWhiteSpace(input) ? currentInstructions : input;

                Console.WriteLine($"Porciones actuales: {currentPortions}");
                input = Console.ReadLine() ?? "";
                int newPortions = string.IsNullOrWhiteSpace(input) ? currentPortions : int.Parse(input);

                string updateQuery = @"UPDATE Recipes SET 
                    Name = @Name,
                    Ingredients = @Ingredients,
                    PreparationTime = @PreparationTime,
                    Category = @Category,
                    Difficulty = @Difficulty,
                    Instructions = @Instructions,
                    Portions = @Portions
                    WHERE Id = @Id";

                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@Name", newName);
                updateCmd.Parameters.AddWithValue("@Ingredients", newIngredients);
                updateCmd.Parameters.AddWithValue("@PreparationTime", newTime);
                updateCmd.Parameters.AddWithValue("@Category", newCategory);
                updateCmd.Parameters.AddWithValue("@Difficulty", newDifficulty);
                updateCmd.Parameters.AddWithValue("@Instructions", newInstructions);
                updateCmd.Parameters.AddWithValue("@Portions", newPortions);
                updateCmd.Parameters.AddWithValue("@Id", id);
                updateCmd.ExecuteNonQuery();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Receta editada exitosamente.");
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al editar: {ex.Message}");
            Console.ResetColor();
        }
    }

    public static void DeleteRecipe(List<Recipe> recipes)
    {
        try
        {
            Console.WriteLine("Ingrese el ID de la receta que desea eliminar:");
            int id = int.Parse(Console.ReadLine() ?? "0");

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Verificar que existe
                string checkQuery = "SELECT Name FROM Recipes WHERE Id = @Id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se encontró una receta con ese ID.");
                    Console.ResetColor();
                    return;
                }

                reader.Read();
                string recipeName = reader["Name"].ToString() ?? "";
                reader.Close();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"¿Estás seguro que deseas eliminar '{recipeName}'? 1. Sí, 2. No");
                Console.ResetColor();
                int confirm = int.Parse(Console.ReadLine() ?? "2");

                if (confirm == 1)
                {
                    string deleteQuery = "DELETE FROM Recipes WHERE Id = @Id";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@Id", id);
                    deleteCmd.ExecuteNonQuery();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Receta eliminada exitosamente.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Eliminación cancelada.");
                    Console.ResetColor();
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al eliminar: {ex.Message}");
            Console.ResetColor();
        }
    }
}
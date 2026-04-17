using System;
using System.Collections.Generic;
using System.Linq;

public static class RecipeHelper
{
    public static void AddRecipe(List<Recipe> recipes)
    {
        try
        {
            int id = recipes.Count + 1;
            Console.WriteLine("Ingrese el nombre de la receta:");
            string name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese los ingredientes (separados por comas):");
            string ingredients = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese el tiempo de preparación (en minutos): ");
            int preparationTime = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Ingrese la categoria de la receta (Desayuno, Almuerzo, Cena, Postre): ");
            string category = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese la dificultad que podría tener la receta (Fácil, Media, Difícil): ");
            string difficulty = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite los pasos para la preparacion (separados por comas): ");
            string instructions = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese el número de porciones que podría prepararse: ");
            int portions = int.Parse(Console.ReadLine() ?? "0");

            Recipe recipe = new Recipe (
                id,
                name,
                ingredients,
                preparationTime,
                category,
                difficulty,
                instructions,
                portions
            );

            recipes.Add(recipe);

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
        if(recipes.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No hay recetas para mostrar.");
            Console.ResetColor();
            return;
        }
                 foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(recipe.GetInfo());
            }
    
    }

    public static void SearchByName(List<Recipe> recipes)
    {
        Console.WriteLine("Ingrese el nombre de la receta que desea buscar:");
        string name = Console.ReadLine() ?? string.Empty;
        
        var result = recipes
        .Where(r =>
        r.Name.ToLower().Contains(name.ToLower()))
        .ToList();

        if (result.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No se encontraron recetas con ese nombre.");
            Console.ResetColor();
            return;
        }

            foreach (var recipe in result)
            {
                Console.WriteLine(recipe.GetInfo());
            }
    }

    public static void FilterByCategory(List<Recipe> recipes)
    {
        Console.WriteLine("Ingrese la categoría de la receta que desea filtrar (Desayuno, Almuerzo, Cena, Postre):");
        string category = Console.ReadLine() ?? string.Empty;
        
        var result = recipes
        .Where(r => r.Category.ToLower() ==
        category.ToLower())
        .ToList();

        if (result.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No se encontraron recetas en esa categoría.");
            Console.ResetColor();
            return;
        }

            foreach (var recipe in result)
            {
                Console.WriteLine(recipe.GetInfo());
            }
    }

    public static void FilterByDifficulty(List<Recipe> recipes)
    {
        Console.WriteLine("Ingrese la dificultad de la receta que desea filtrar (Fácil, Media, Difícil):");
        string difficulty = Console.ReadLine() ?? string.Empty;
        
        var result = recipes
        .Where(r => r.Difficulty.ToLower() ==
        difficulty.ToLower())
        .ToList();

        if (result.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No se encontraron recetas en esa dificultad.");
            Console.ResetColor();
            return;
        }

            foreach (var recipe in result)
            {
                Console.WriteLine(recipe.GetInfo());
            }
    }

    public static void FilterByPreparationTime(List<Recipe> recipes)
    {
        Console.WriteLine("Ingrese el tiempo de preparación máximo (en minutos):");

        if (!int.TryParse(Console.ReadLine(), out int maxTime))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entrada no válida. Por favor ingrese un número entero para el tiempo de preparación.");
            Console.ResetColor();
            return;
        }

        var result = recipes
        .Where(r => r.PreparationTime <= maxTime)
        .ToList();

        if (result.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No se encontraron recetas con ese tiempo de preparación.");
            Console.ResetColor();
            return;
        }

            foreach (var recipe in result)
            {
                Console.WriteLine(recipe.GetInfo());
            }
    }

    public static void EditRecipe(List<Recipe> recipes)
    {
        Console.WriteLine("Ingrese el ID de la receta que desea editar:");
        int id = int.Parse(Console.ReadLine() ?? "0");

        var recipe = recipes.FirstOrDefault(r => r.Id == id);

        if (recipe == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No se encontró una receta con ese ID.");
            Console.ResetColor();
            return;
        }

        string input;

        Console.WriteLine("(Presione Enter para mantener el valor actual)");

        Console.WriteLine($"Nombre actual de la receta: {recipe.Name}");
        input = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(input)) recipe.Name = input;

        Console.WriteLine($"Ingredientes actuales (separados por comas): {recipe.Ingredients}");
        input = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(input)) recipe.Ingredients = input;

        Console.WriteLine($"Tiempo actual: {recipe.PreparationTime} minutos");
        input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out int newTime))
        {
            recipe.PreparationTime = newTime;
        }

        Console.WriteLine($"Categoría actual de la receta (Desayuno, Almuerzo, Cena, Postre): {recipe.Category} ");
        input = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(input)) recipe.Category = input;

        Console.WriteLine($"Dificultad actual de la receta (Fácil, Media, Difícil): {recipe.Difficulty}");
        input = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(input)) recipe.Difficulty = input;

        Console.WriteLine($"Pasos actuales para la preparacion (separados por comas): {recipe.Instructions}");
        input = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(input)) recipe.Instructions = input;


        Console.WriteLine("Ingrese las nuevas porciones:");
        Console.WriteLine($"Actuales: {recipe.Portions}");
        input = Console.ReadLine() ?? "";
        if (int.TryParse(input, out int newPortions)) recipe.Portions = newPortions;


        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Receta editada exitosamente.");
        Console.ResetColor();
    }

    public static void DeleteRecipe(List<Recipe> recipes)
    {
        Console.WriteLine("Ingrese el ID de la receta que desea eliminar: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Recipe recipe = recipes.FirstOrDefault(r => r.Id == id);

        if (recipe == null)
        {
        
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No se encontró una receta con ese ID.");
            Console.ResetColor();
            return;
        }

        recipes.Remove(recipe);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Receta eliminada exitosamente.");
        Console.ResetColor();
    }

}
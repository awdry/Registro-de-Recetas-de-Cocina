using System;
using System.Collections.Generic;

Console.WriteLine("=====================================");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("Bienvenido al sistema de recetas RecipeSys!");
Console.WriteLine("Aquí podrás agregar, mostrar, buscar, filtrar, editar y eliminar tus recetas favoritas.");
Console.ResetColor();
Console.WriteLine("=====================================");

bool running = true;
List<Recipe> recipes = new List<Recipe>();

while(running)
{

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Seleccione una opción:");
    Console.ResetColor();
    Console.WriteLine("=====================================");
    Console.ForegroundColor = ConsoleColor.DarkGreen; 
    Console.WriteLine("1. Agregar receta");
    Console.ResetColor(); 
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("2. Mostrar recetas");
    Console.ResetColor(); 
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("3. Buscar receta por nombre");
    Console.ResetColor(); 
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("4. Filtrar recetas por categoría");
    Console.WriteLine("5. Filtrar recetas por dificultad");
    Console.WriteLine("6. Filtrar recetas por tiempo de preparación");
    Console.ResetColor(); 
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("7. Editar receta");
    Console.ResetColor(); 
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("8. Eliminar receta");
    Console.ResetColor(); 
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("9. Salir");
    Console.ResetColor(); 
    Console.WriteLine("=====================================");

    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Ingrese el número de la opción deseada (1-9): ");
    Console.ResetColor();
    Console.WriteLine("=====================================");

    try
    {
    string option = Console.ReadLine() ?? string.Empty;

        switch (option)
        {
            case "1":
                RecipeHelper.AddRecipe(recipes);
                break;
            case "2":
                RecipeHelper.ShowRecipes(recipes);
                break;
            case "3":
                RecipeHelper.SearchByName(recipes);
                break;
            case "4":
                Console.WriteLine("Ingrese la categoría (Desayuno, Almuerzo, Cena, Postre):");
                string category = Console.ReadLine() ?? string.Empty;
                RecipeHelper.ShowRecipes(recipes, category);
                break;
            case "5":
                Console.WriteLine("Ingrese la dificultad (Fácil, Media, Difícil):");
                string difficulty = Console.ReadLine() ?? string.Empty;
                RecipeHelper.FilterByDifficulty(recipes, difficulty);
                break;
            case "6":
                Console.WriteLine("Ingrese el tiempo máximo de preparación (en minutos):");
                int maxTime = int.Parse(Console.ReadLine() ?? "0");
                RecipeHelper.ShowRecipes(recipes, maxTime);
                break;
            case "7":
                RecipeHelper.EditRecipe(recipes);
                break;
            case "8":
                RecipeHelper.DeleteRecipe(recipes);
                break;
            case "9":
                running = false;
                Console.WriteLine("Gracias por usar RecipeSys. ¡Hasta luego!");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción no válida, por favor intente nuevamente.");
                Console.ResetColor();
                break;
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {ex.Message}");
        Console.ResetColor();
    }
}

Console.ReadKey();
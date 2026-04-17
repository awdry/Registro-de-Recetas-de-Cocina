public class Recipe
{
public int Id { get; set; }
public string? Name { get; set; }
public string? Ingredients { get; set; }
public int PreparationTime { get; set; }
public string? Category { get; set; }
public string? Difficulty { get; set; }
public string? Instructions { get; set; }
public int Portions { get; set; } 
public DateTime CreatedAt { get; set; }

   public Recipe()
   {
       CreatedAt = DateTime.Now;
   }

   public Recipe(

    int id,
    string? name,
    string? ingredients,
    int preparationTime,
    string? category,
    string? difficulty,
    string? instructions,
    int portions)

    {
        Id = id;
        Name = name;
        Ingredients = ingredients;
        PreparationTime = preparationTime;
        Category = category;
        Difficulty = difficulty;
        Instructions = instructions;
        Portions = portions;
        CreatedAt = DateTime.Now;
    }

    public string GetInfo()
    {
        return 
        $"Id: {Id}\n" +
        $"Name: {Name}\n" +
        $"Categoria: {Category}\n" +
        $"Dificultad: {Difficulty}\n" +
        $"Ingredientes: {Ingredients}\n" +
        $"Tiempo de preparación: {PreparationTime} minutos\n" +
        $"Instrucciones: {Instructions}\n" +
        $"Porciones: {Portions}\n" +
        $"Creado el: {CreatedAt}\n";
    }

}
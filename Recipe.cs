public class Recipe
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Ingredients { get; set; }
    public int PreparationTime { get; set; }
   public string? Category { get; set; }
   public int Portions { get; set; } 
   public string? Difficulty { get; set; }
   public string? Instructions { get; set; }
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
    int portions,
    string? difficulty,
    string? instructions)

    {
        Id = id;
        Name = name;
        Ingredients = ingredients;
        PreparationTime = preparationTime;
        Category = category;
        Portions = portions;
        Difficulty = difficulty;
        Instructions = instructions;
        CreatedAt = DateTime.Now;
    }

    public string GetInfo()
    {
        return 
        $"Id: {Id}\n" +
        $"Name: {Name}\n" +
        $"Categoria: {Category}\n" +
        $"Porciones: {Portions}\n" +
        $"Dificultad: {Difficulty}\n" +
        $"Ingredientes: {Ingredients}\n" +
        $"Tiempo de preparación: {PreparationTime} minutos\n" +
        $"Instrucciones: {Instructions}\n" +
        $"Creado el: {CreatedAt}\n";
    }

}
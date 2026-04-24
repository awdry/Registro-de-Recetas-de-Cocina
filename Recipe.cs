public abstract class BaseRecipe
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Ingredients { get; set; }
    public int PreparationTime { get; set; }
    public string? Category { get; set; }
    public DateTime CreatedAt { get; set; }

// Constructor para inicializar la fecha de creación

   public BaseRecipe()
   {
       CreatedAt = DateTime.Now;
   }

    public abstract string GetInfo();
}

public class Recipe : BaseRecipe
{
    public string? Difficulty { get; set; }
    public string? Instructions { get; set; }
    public int Portions { get; set; }

    public Recipe() : base () { }

    public Recipe(int id, string? name, string? ingredients, int preparationTime, string? category, string? difficulty, string? instructions, int portions) : base()
    {
        base.Id = id;
        base.Name = name;
        base.Ingredients = ingredients;
        base.PreparationTime = preparationTime;
        base.Category = category;
        Difficulty = difficulty;
        Instructions = instructions;
        Portions = portions;
        
    }

    public override string GetInfo()
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
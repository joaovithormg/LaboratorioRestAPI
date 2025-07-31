namespace LaboratoriosRestAPI.Models;

public class Autor
{
    public int Id { get; set; }
    public string PrimeiroNome { get; set; }
    public string UltimoNome { get; set; }

    // Relacionamento muitos para muitos
    public ICollection<Livro> Livros { get; set; } = new List<Livro>();
}
namespace LaboratoriosRestAPI.Models;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int AnoPublicacao { get; set; }
    
    // Relacionamento muitos para muitos
    public ICollection<Autor> Autores { get; set; }
    
    // Relacionamento um para muitos
    public ICollection<Emprestimo> Emprestimos { get; set; }
}


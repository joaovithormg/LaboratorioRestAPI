namespace LaboratoriosRestAPI.Models;

public class Emprestimo
{
    public int Id { get; set; }
    public DateTime DataRetirada { get; set; }
    public DateTime? DataDevolucao { get; set; }
    public bool Entregue { get; set; }

    // Chave estrangeira e navegação para Livro
    public int LivroId { get; set; }
    public Livro Livro { get; set; }
}

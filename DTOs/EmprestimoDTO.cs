namespace LaboratoriosRestAPI.DTOs;

public class EmprestimoDTO
{
    // POST
    public class CreateEmprestimoDto
    {
        public DateTime DataRetirada { get; set; }
        public int LivroId { get; set; }
    }

// GET
    public class ReadEmprestimoDto
    {
        public int Id { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public bool Entregue { get; set; }
        public LivroDTO.ReadLivroDto Livro { get; set; }
    }

// PUT/PATCH
    public class UpdateEmprestimoDto
    { 
        public DateTime? DataDevolucao { get; set; }
        public bool Entregue { get; set; }
    }

}
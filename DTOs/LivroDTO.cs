namespace LaboratoriosRestAPI.DTOs;

public class LivroDTO
{
    // POST
    public class CreateLivroDto
    {
        public string Titulo { get; set; }
        public int AnoPublicacao { get; set; }
        public List<int> AutoresIds { get; set; } // Para vincular autores existentes
    }

// GET (listagem e detalhe)
    public class ReadLivroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AnoPublicacao { get; set; }
        public List<AutorDTO.ReadAutorDto> Autores { get; set; }
    }

// PUT/PATCH
    public class UpdateLivroDto
    {
        public string Titulo { get; set; }
        public int AnoPublicacao { get; set; }
        public List<int> AutoresIds { get; set; }
    }

}
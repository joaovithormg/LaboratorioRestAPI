namespace LaboratoriosRestAPI.DTOs;

public class AutorDTO
{
    // POST
    public class CreateAutorDto
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
    }

// GET
    public class ReadAutorDto
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
    }

// PUT/PATCH
    public class UpdateAutorDto
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
    }

}
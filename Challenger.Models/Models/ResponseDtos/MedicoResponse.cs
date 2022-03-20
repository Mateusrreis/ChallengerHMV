namespace Challenger.Models.Models.ResponseDtos
{
    public class MedicoResponse
    {
        protected MedicoResponse(int idMedico, string nomeMedico)
        {
            IdMedico = idMedico;
            NomeMedico = nomeMedico;
        }

        public int IdMedico { get; set; }
        public string NomeMedico { get; set; }

        public static class Builder
        {
            public static MedicoResponse Criar(int idMedico, string nomeMedico)
                => new MedicoResponse(idMedico, nomeMedico);
        }
    }
}

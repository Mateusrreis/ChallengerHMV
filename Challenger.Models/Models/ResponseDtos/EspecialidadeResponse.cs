namespace Challenger.Models.Models.ResponseDtos
{
    public class EspecialidadeResponse
    {
        protected EspecialidadeResponse(int idEspecialidade, string nomeEspecialidade)
        {
            IdEspecialidade = idEspecialidade;
            NomeEspecialidade = nomeEspecialidade;
        }

        public int IdEspecialidade { get; set; }
        public string NomeEspecialidade { get; set; }

        public static class Builder
        {
            public static EspecialidadeResponse Criar(int idEspecialide, string nomeEspecialidade)
                => new EspecialidadeResponse(idEspecialide, nomeEspecialidade);
        }
    }
}

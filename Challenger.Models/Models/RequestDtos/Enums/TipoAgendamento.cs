namespace Challenger.Models.Models.RequestDtos.Enums
{
    public enum TipoAgendamento
    {
        EXAME = 0,
        CONSULTA = 1,
    }

    public static class TipoAgendamentoExtension
    {
        public static bool IsExame(this TipoAgendamento tipoAgendamento)
            => TipoAgendamento.EXAME == tipoAgendamento;
    }
}

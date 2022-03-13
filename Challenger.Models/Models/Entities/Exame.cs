
namespace Challenger.Models.Models.Entities
{
    public class Exame
    {
        public int IdExame { get; set; }
        public string DtExame { get; set; }
        public int? IdAgendaExame { get; set; }
        public string UrlAnexo { get; set; }

        public virtual AgendaExame IdExameNavigation { get; set; }
    }
}

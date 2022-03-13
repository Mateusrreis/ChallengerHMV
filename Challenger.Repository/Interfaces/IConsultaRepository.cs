using Challenger.Models.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Repository.Interfaces
{
    public interface IConsultaRepository
    {
        Task<bool> CadastrarConsulta(Consulta consulta);
        Task<IEnumerable<Consulta>> BuscarConsulta(DateTime dateTime);
    }
}

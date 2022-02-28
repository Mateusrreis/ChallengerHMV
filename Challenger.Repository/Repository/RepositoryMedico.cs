using Challenger.Models.Entities;
using Challenger.Repository.Database;
using Challenger.Repository.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Challenger.Repository.Repository
{
    public class RepositoryMedico : IRepositoryDoctor
    {
        private readonly IDbConnection _dbConnection;
        public RepositoryMedico() => _dbConnection = ConfigurationDatabase.OpenDatabase();

        public async Task<IEnumerable<Medico>> GetDoctorsAsync(int idDoctor)
        {
            var query = $@"SELECT idMedico, 
                           idUsuario,
                           fltCRM as 'CRM',
                           strEspecialidade as 'Especialidade'
                           FROM Medico WHERE idMedico = @idMedico";

            var parameters = new DynamicParameters();
            parameters.Add("idMedico", idDoctor);
            var results = await DatabaseCommand.GetDataRows<Medico>(query, _dbConnection, parameters);
            return results;
        }
    }
}

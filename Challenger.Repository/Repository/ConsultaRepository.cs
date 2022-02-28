using Challenger.Models.Entities;
using Challenger.Repository.Database;
using Challenger.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Challenger.Repository.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly IDbConnection _dbConnection;
        public ConsultaRepository() => _dbConnection = ConfigurationDatabase.OpenDatabase();

        public async Task<bool> AgendarConsulta(Consulta consulta)
        {
            var query = $@"INSERT INTO Consulta 
                          (idMedico,
                           dtConsulta,
                           strRelatorioMedico,
                           idPrescricao,
                           idAtendimento) VALUES
                           (@idMedico,@dtConsulta, @RelatorioMedico, @idPrescricao, @idAtendimento);";

            var parameters = new DynamicParameters();
            parameters.Add("idMedico", consulta.IdMedico);
            parameters.Add("dtConsulta", consulta.DtConsulta);
            parameters.Add("RelatorioMedico", consulta.RelatorioMedico);
            parameters.Add("idPrescricao", consulta.IdPrescricao);
            parameters.Add("idAtendimento", consulta.IdAtendimento);
            var results = await DatabaseCommand.InsertRowsDatabase(query, _dbConnection, parameters);
            return results > 0;
        }
    }
}

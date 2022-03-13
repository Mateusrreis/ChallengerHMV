using Amazon.Lambda.Core;
using Challenger.Models.Models.Interfaces;
using Challenger.Repository.Database;
using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Challenger.Repository.Repository
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly IDbConnection _dbConnection;
        public AtendimentoRepository() => _dbConnection = ConfigurationDatabase.OpenDatabase();
        public async Task<Atendimento> BuscarAtendimento(int idAtendimento)
        {
            try
            {
                var query = @"SELECT 
                               idAtendimento as IdAtendimento,
                               dtAtendimento as DtAtendimento,
                               idPaciente as IdPaciente,
                               idConvenio as IdConvenio,
                               codCartaoConvenio as CodCartaoConvenio,
                               strConvenioCategoria as StrConvenioCategoria,
                               flgParticular as FlgParticular
                               FROM Atendimento 
                               WHERE idAtendimento  = @idAtendimento";
                var parameters = new DynamicParameters();

                parameters.Add("idAtendimento", idAtendimento);

                var datas = await DatabaseCommand.GetDataRows<Atendimento>(query, _dbConnection, parameters);
                return datas.FirstOrDefault();
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(AtendimentoRepository)} - {ex.Message}");
                return new Atendimento();
            }
        }
    }
}

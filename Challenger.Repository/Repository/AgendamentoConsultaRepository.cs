using Amazon.Lambda.Core;
using Challenger.Models.Models.Entities;
using Challenger.Models.Models.Interfaces;
using Challenger.Repository.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Challenger.Repository.Repository
{
    public class AgendamentoConsultaRepository : IAgendamentoConsultaRepository
    {
        private readonly IDbConnection _dbConnection;

        public AgendamentoConsultaRepository() => _dbConnection = ConfigurationDatabase.OpenDatabase();
        public async Task<bool> MarcarConsulta(AgendaConsulta agendaConsulta)
        {
            try
            {
                var query = $@"INSERT INTO HMV.AgendaConsulta
                            (idPaciente,
                            dtCadastro,
                            dtConsulta, 
                            hrConsulta, 
                            intMinsDuracaoConsulta,
                            idEspecialidade,
                            idMedico)
                            VALUES(@idPaciente, @dataCadastro, @dataConsulta, @horaConsulta, @minsDuracaoConsulta, @idEspecialidade, @idMedico)";
                var parameters = new DynamicParameters();
                parameters.Add("@idPaciente", agendaConsulta.IdPaciente);
                parameters.Add("@dataCadastro", agendaConsulta.DtCadastro);
                parameters.Add("@dataConsulta", agendaConsulta.DtConsulta);
                parameters.Add("@horaConsulta", agendaConsulta.HrConsulta);
                parameters.Add("@minsDuracaoConsulta", agendaConsulta.MinsDuracaoConsulta);
                parameters.Add("@idEspecialidade", agendaConsulta.IdEspecialidade);
                parameters.Add("@idMedico", agendaConsulta.IdMedico);
                var result = await DatabaseCommand.InserirDados(query, _dbConnection, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(ConsultaRepository)} - {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<AgendaConsulta>> VerificarAgendaConsulta(DateTime dateConsulta)
        {
            try
            {
                var query = $@"SELECT 
                              idAgendaConsulta as IdAgendaConsulta, 
                              idPaciente as IdPaciente, 
                              dtCadastro as DtCadastro, 
                              dtConsulta as DtConsulta, 
                              hrConsulta as HrConsulta, 
                              intMinsDuracaoConsulta as MinsDuracaoConsulta, 
                              idEspecialidade as IdEspecialidade, 
                              idMedico as IdMedico
                            FROM AgendaConsulta
                            WHERE dtConsulta = @dateConsulta";
                var parameters = new DynamicParameters();
                parameters.Add("@dateConsulta", dateConsulta);
                var datas = await DatabaseCommand.GetDataRows<AgendaConsulta>(query, _dbConnection, parameters);
                return datas;
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(ConsultaRepository)} - {ex.Message}");
                throw;
            }
        }
    }
}

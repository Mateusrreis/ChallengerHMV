using Amazon.Lambda.Core;
using Challenger.Models.Entities;
using Challenger.Repository.Database;
using Challenger.Repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Challenger.Repository.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly IDbConnection _dbConnection;
        public ConsultaRepository() => _dbConnection = ConfigurationDatabase.OpenDatabase();

        public async Task<IEnumerable<Consulta>> BuscarConsulta(DateTime dateTime)
        {
            try
            {
                var query = $@"SELECT
                        	idConsulta IdConsulta,
                        	idMedico IdMedico,
                        	MAX(dtConsulta) DtConsulta,
                        	strRelatorioMedico RelatorioMedico,
                        	idPrescricao IdPrecricao,
                        	idAtendimento idAtendimento 
                        FROM Consulta c 
                        GROUP BY
                        	idConsulta,
                        	idMedico,
                        	strRelatorioMedico,
                        	idPrescricao,
                        	idAtendimento
                        HAVING DtConsulta > @dtConsultaDateBegin AND DtConsulta < @dtConsultaDateEnd";

                var parameters = new DynamicParameters();
                parameters.Add("@dtConsultaDateBegin", dateTime);
                parameters.Add("@dtConsultaDateEnd", dateTime);
                var datas = await DatabaseCommand.GetDataRows<Consulta>(query, _dbConnection, parameters);
                return datas;
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(ConsultaRepository)} - {ex.Message}");
                throw;
            }
        }

        public async Task<bool> MarcarConsulta(Consulta consulta)
        {
            try
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
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(ConsultaRepository)} - {ex.Message}");
                return false;
            }
        }


    }
}

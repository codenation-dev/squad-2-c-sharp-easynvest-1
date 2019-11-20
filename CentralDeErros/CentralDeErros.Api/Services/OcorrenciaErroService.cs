using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class OcorrenciaErroService : IOcorrenciaErroService
    {

        private ErroDbContext _context;

        public OcorrenciaErroService (ErroDbContext context)
        {
            this._context = context;
        }
        public bool CadastrarErro(int erroId, string origem, string detalhe, DateTime dataHora, string userToken)
        {
            _context.OcorrenciaErros.Add(new OcorrenciaErro { Erro_Id = erroId, Origem = origem, Detalhes = detalhe, Data_Hora = dataHora });

            if (_context.OcorrenciaErros.FirstOrDefault(e => e.Erro_Id == erroId && e.Origem == origem && e.Detalhes == detalhe && e.Data_Hora == dataHora) != null)
            {
                return true;
            }

            return false;
        }

        public List<OcorrenciaErro> Consulta(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            // dado vem do frontEnd

            // Campo ordenação
            // 1 - Level
            // 2 - Frequência

            // Campo buscado
            // 1 - Level
            // 2 - Descrição
            // 3 - Origem

            //TODO

            //Func<OcorrenciaErro, Object> orderByFunc = null;
            //if (sortOrder == SortOrder.SortByName)
            //    orderByFunc = item => item.Error.Level;
            //else if (sortOrder == SortOrder.SortByRank)
            //    orderByFunc = item => item.Rank;

            string ordenacao = null;

            if (campoOrdenacao == 1)
            {
                ordenacao = "Error.Level";

            } 
            else if (campoOrdenacao == 2)
            {
                ordenacao = "Error.Frequencia";
            }

            return _context.OcorrenciaErros.Where(o => o.Error.Ambiente_Id == ambiente).ToList();
        }

        public List<OcorrenciaErro> ListarOcorrenciasPorLevel(int level)
        {
            return _context.OcorrenciaErros.Where(o => o.Error.Level_Id == level).ToList();
        }
    }
}

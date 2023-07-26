using DepartamentoPessoal.Data;
using DepartamentoPessoal.Models;
using DepartamentoPessoal.Repositorio.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DepartamentoPessoal.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public PessoaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public PessoaModel Adicionar(PessoaModel pessoa)
        {
            _bancoContext.Pessoas.Add(pessoa);
            _bancoContext.SaveChanges();

            return pessoa;
        }

        public List<PessoaModel> ListarTodos()
        {
            return _bancoContext.Pessoas.ToList();
        }
    }
}

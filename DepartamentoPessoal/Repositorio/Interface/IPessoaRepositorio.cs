using DepartamentoPessoal.Models;
using System.Collections.Generic;

namespace DepartamentoPessoal.Repositorio.Interface
{
    public interface IPessoaRepositorio
    {
        PessoaModel ListarPorid(int id);

        PessoaModel Atualizar(PessoaModel pessoa);

        PessoaModel Adicionar(PessoaModel pessoa);

        List<PessoaModel> ListarTodos();
    }
}

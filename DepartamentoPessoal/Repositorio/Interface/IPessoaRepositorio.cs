using DepartamentoPessoal.Models;
using System.Collections.Generic;

namespace DepartamentoPessoal.Repositorio.Interface
{
    public interface IPessoaRepositorio
    {
        PessoaModel Adicionar(PessoaModel pessoa);

        List<PessoaModel> ListarTodos();
    }
}

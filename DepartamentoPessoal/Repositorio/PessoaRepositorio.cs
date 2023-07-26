﻿using DepartamentoPessoal.Data;
using DepartamentoPessoal.Models;
using DepartamentoPessoal.Repositorio.Interface;
using System;
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

        public PessoaModel Atualizar(PessoaModel pessoa)
        {
            PessoaModel pessoadb = ListarPorid(pessoa.Id);

            if (pessoadb == null) throw new Exception("Houve um erro ao alterar a Pessoa");

            pessoadb.Nome = pessoa.Nome;
            pessoadb.Email = pessoa.Email;
            pessoadb.Cpf = pessoa.Cpf;
            pessoadb.Rg = pessoa.Rg;
            pessoadb.DataNasc = pessoa.DataNasc;
            pessoadb.NomePai = pessoa.NomePai;
            pessoadb.NomeMae = pessoa.NomeMae;

            _bancoContext.Pessoas.Update(pessoadb);
            _bancoContext.SaveChanges();

            return pessoadb;
        }

        public PessoaModel ListarPorid(int id)
        {
            return _bancoContext.Pessoas.FirstOrDefault(x => x.Id == id);
        }

        public List<PessoaModel> ListarTodos()
        {
            return _bancoContext.Pessoas.ToList();
        }
    }
}

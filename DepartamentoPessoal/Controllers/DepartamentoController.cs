using DepartamentoPessoal.Models;
using DepartamentoPessoal.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DepartamentoPessoal.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public DepartamentoController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(PessoaModel pessoa)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _pessoaRepositorio.Adicionar(pessoa);
                    TempData["MensagemSucesso"] = "Pessoa cadastrada com sucesso";
                    return RedirectToAction("Consultar");
                }

                return View(pessoa);
            }
            catch (System.Exception erro)
            {
                _pessoaRepositorio.Adicionar(pessoa);
                TempData["MensagemErro"] = $"Ops, pessoa não conseguiu ser cadastrada, tente novamente, erro: " + erro;
                return RedirectToAction("Consultar");
            }
        }

        public IActionResult Consultar()
        {
            List<PessoaModel> listaPessoa = _pessoaRepositorio.ListarTodos();
            return View(listaPessoa);
        }

        public IActionResult Editar(int id)
        {
            PessoaModel pessoadb = _pessoaRepositorio.ListarPorId(id);
            return View(pessoadb);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            PessoaModel pessoa = _pessoaRepositorio.ListarPorId(id);
            return View(pessoa);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _pessoaRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Departamento Apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar o seu departamento";
                }

                return RedirectToAction("Consultar");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o seu departamento, mais detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(PessoaModel pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pessoaRepositorio.Atualizar(pessoa);
                    TempData["MensagemSucesso"] = "Pessoa cadastrada com sucesso";
                    return RedirectToAction("Consultar");
                }
            }
            catch (System.Exception erro)
            {
                _pessoaRepositorio.Adicionar(pessoa);
                TempData["MensagemErro"] = $"Ops, pessoa não conseguiu ser cadastrada, tente novamente, erro: " + erro;
                return RedirectToAction("Consultar");
            }

            return View("Editar", pessoa);
        }

        public IActionResult Apagar()
        {
            return View();
        }
    }
}

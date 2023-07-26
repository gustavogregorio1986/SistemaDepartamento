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

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        public IActionResult Apagar()
        {
            return View();
        }
    }
}

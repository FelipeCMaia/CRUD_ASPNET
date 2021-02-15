using Agenda_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_ASPNET.Controllers
{
    public class ContatoController : Controller
    {
        private readonly Contexto _contexto;

        public ContatoController(Contexto contexto)
        {
            _contexto = contexto;
        }

        //Função para a listagem dos dado do banco
        public IActionResult Index()
        {
            var lista = _contexto.Contatos.ToList();
            
            return View(lista);
        }

        //Método Get consulta dados para exibição
        [HttpGet]
        public IActionResult CriarContato()
        {
            Contato contato = new Contato();
            
            return View(contato);
        }

        //Método Post envia dados para o banco de dados
        [HttpPost]
        public IActionResult CriarContato(Contato contato)
        {
            //Verifica se todos os campos foram preenchidos
            if (ModelState.IsValid)
            {
                _contexto.Contatos.Add(contato);                
                _contexto.SaveChanges();
                
                return RedirectToAction("Index");
            }
            else
            {
                return View(contato);
            }
        }

        [HttpGet]
        public IActionResult EditarContato(int Id)
        {
            //Procura o Contato via Id
            var contato = _contexto.Contatos.Find(Id);            

            return View(contato);
        }

        [HttpPost]
        public IActionResult EditarContato(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _contexto.Contatos.Update(contato);

                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(contato);
            }
        }

        [HttpGet]
        public IActionResult DeletarContato(int Id)
        {
            var contato = _contexto.Contatos.Find(Id);

            return View(contato);
        }


        [HttpPost]
        public IActionResult DeletarContato(Contato _Contato)
        {
            var contato = _contexto.Contatos.Find(_Contato.Id);

            if (contato != null)
            {
                _contexto.Contatos.Remove(contato);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(contato);
        }
        
    }
}

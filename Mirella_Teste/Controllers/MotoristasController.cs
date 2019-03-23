using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mirella_Teste.Data;
using Mirella_Teste.Models;

namespace Mirella_Teste.Controllers
{
    public class MotoristasController : Controller
    {
        [HttpGet]
        public IActionResult Index(string NomeMotorista,
            string acao = null,
            string idMotorista = null)
        {
            if (acao == "Inativar")
                MotoristaData.DesativarMotorista(idMotorista);
            if (acao == "Ativar")
                MotoristaData.AtivarMotorista(idMotorista);

            List<MotoristaViewModel> viewModels = MotoristaData.BuscarMotorista(NomeMotorista);
            //    new List<MotoristaViewModel>()
            //{
            //    new MotoristaViewModel
            //    {
            //        Id = 1,
            //        Nome = "EEU",
            //        ModeloCarro = "SHOW",
            //        Status = true
            //    }
            //};
                

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(CriarMotoristaViewModel viewModel)
        {
            MotoristaData.CriarMotorista(viewModel);

            return Redirect("Index");
        }


    }
}
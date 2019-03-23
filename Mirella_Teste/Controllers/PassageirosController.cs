using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mirella_Teste.Data;
using Mirella_Teste.Models;

namespace Mirella_Teste.Controllers
{
    public class PassageirosController : Controller
    {
        [HttpGet]
        public IActionResult Index(string NomePassageiro)
        {
            List<PassageirosViewModel> model = PassageiroData.BuscarPassageiro(NomePassageiro);
            return View(model);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(CriarPassageiroViewModel viewModel)
        {
            PassageiroData.CriarPassageiro(viewModel);
            return Redirect("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mirella_Teste.Data;
using Mirella_Teste.Models;

namespace Mirella_Teste.Controllers
{
    public class CorridasController : Controller
    {
        public IActionResult Index()
        {
            List<CorridaViewModel> model = CorridaData.BuscarCorridas();

            return View(model);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            ViewBag.Motoristas = MotoristaData.BuscarMotoristasAtivos();
            ViewBag.Passageiros = PassageiroData.BuscarPassageiro(null);

            return View();
        }

        [HttpPost]
        public IActionResult Criar(CriarCorridaViewModel model)
        {
            model.Valor /= 10;
            CorridaData.CriarCorrida(model);
            return Redirect("Index");
        }
    }
}
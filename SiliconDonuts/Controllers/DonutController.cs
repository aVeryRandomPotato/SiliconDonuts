using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiliconDonuts.Models;
using SiliconDonuts.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiliconDonuts.Controllers
{
    public class DonutController : Controller
    {
        // GET: /<controller>/

        private readonly IDonutRepository _donutRepository;

        public DonutController(IDonutRepository donutRepository)
        {
            donutRepository = _donutRepository;
        }

        public IActionResult Index()
        {
            return View();

        }
        public IActionResult AllDonuts()
        {
            DonutListViewModel donutListView = new DonutListViewModel();
            donutListView.Donuts = _donutRepository.AllDonuts;
            donutListView.CurrentCategory = "Glazed";

            return View(donutListView);
        }
    }
}

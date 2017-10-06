using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ICO.Services.IcoServices;
using ICO.Web.Models;
using AutoMapper;

namespace ICO.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IIcoService _icoService;

        public HomeController(IMapper mapper, IIcoService icoService)
        {
            _mapper = mapper;
            _icoService = icoService;
        }

        [HttpGet]
        public virtual JsonResult GetIcoData(int ico)
        {
            var fromDb = _icoService.GetDataByIcoFromDb(ico);

            if (fromDb != null)
            {
                var result = _mapper.Map<IcoViewModel>(fromDb);
                return Json(result);
            }
            else
            {
                var fromAres = _icoService.GetDataByIcoFromARES(ico);
                var result = _mapper.Map<IcoViewModel>(fromAres);
                return Json(result);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

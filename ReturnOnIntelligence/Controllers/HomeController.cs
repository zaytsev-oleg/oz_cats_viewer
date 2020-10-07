using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace ReturnOnIntelligence.Controllers
{
    using Models;
    using Helpers;

    public class HomeController : Controller
    {
        public RequestHelper RequestHelper;

        public HomeController()
        {
            RequestHelper = new RequestHelper();
        }

        public async Task<ActionResult> Index()
        {
            return View(await RequestHelper.GetCategories());
        }

        public async Task<ActionResult> Items(RequestParameters parameters)
        {
            var images = await RequestHelper.GetImages(parameters.Paginate());

            if (images.Length > parameters.NumOfElements)
            {
                ViewBag.NextPage = parameters.PageIndex + 1;
            }

            if (parameters.PageIndex > 1)
            {
                ViewBag.PreviousPage = parameters.PageIndex - 1;
            }

            var basis  = parameters.PageSize * (parameters.PageIndex - 1);
            var result = images.Skip(basis).Take(parameters.PageSize).ToArray();

            ViewBag.Basis = basis;
            ViewBag.Category = parameters.Category;

            return View(result);
        }
    }
}
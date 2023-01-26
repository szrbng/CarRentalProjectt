using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.APIModel.ResponseModel;
using Web.Services;
using Web.Services.Models;

namespace Web.Controllers
{
    public class BrandController : Controller
    {
        private readonly ApiClient _apiClient;

        public BrandController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            List<BrandVM> brandVMs = new List<BrandVM>();

            var result = await _apiClient.GetBrands();

            foreach(var item in result.data)
            {
                BrandVM brandVM = new BrandVM();

                brandVM.Id=item.Id;
                brandVM.Name=item.Name;

                brandVMs.Add(brandVM);
            }


            return View(brandVMs);
        }
      
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.APIModel.RequestModel;
using Web.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApiClient _apiClient;

        public HomeController(ILogger<HomeController> logger,ApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            //try
            //{
            //    var result = await _apiClient.Login(new LoginRequestModel()
            //    {
            //        Email = "sezer@gmail.com",
            //        Password = "1234567"
            //    });

            //}
            //catch(Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

       


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}

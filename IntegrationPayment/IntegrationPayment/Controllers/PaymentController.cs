using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IntegrationPayment.Helpers;
using IntegrationPayment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IntegrationPayment.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("/Payment")]
        [Route("/Payment/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Payment/Index")]
        public IActionResult Index(PaymentViewModel model)
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 11; i++)
            {
                r += random.Next(10).ToString();
            }

            model.Invoice = r;
            model.SharedKey = _configuration.GetValue<string>("DokuPayment:SharedKey");
            model.mallId = _configuration.GetValue<string>("DokuPayment:MallId");

            string words = model.Amount + model.mallId  + model.SharedKey + model.Invoice + model.Currency;

            model.Words = SHA1Util.SHA1HashStringForUTF8String(words);

            return View("PaymentDokuForm", model);
        }

        [Route("/Payment")]
        [Route("/Payment/PaymentDokuForm")]
        public IActionResult PaymentDokuForm()
        {
            return View();
        }

       
    }
}
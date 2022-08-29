using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using PurchaseBookApp.Models;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PurchaseBookApp
{

    public class PurchaseBook
    {
        private readonly DigitalBookManagementContext _digitalBookManagementContext;

        public PurchaseBook(DigitalBookManagementContext digitalBookManagementContext)
        {
            this._digitalBookManagementContext = digitalBookManagementContext;
        }

        [FunctionName("PurchaseBook")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Post), Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject(requestBody).ToString();
            Payment payment = JsonConvert.DeserializeObject<Payment>(data);

            string responseMessage = default;
            try
            {
                if (payment != null)
                {
                    _digitalBookManagementContext.Payments.Add(payment);
                    _digitalBookManagementContext.SaveChanges();
                    responseMessage = "Payment sucessfull";
                }
            } 
            catch(Exception ex)
            {
                responseMessage = ex.Message;
            }
            return new OkObjectResult(responseMessage);
        }
    }
}

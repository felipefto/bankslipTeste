using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bankslip.Models;
using System.Net;
using bankslip.Services;

namespace bankslip.Controllers
{
    [Route("rest/[Controller]")]
    public class BankslipsController : Controller
    {

        private IbankslipService _bankslipService;

        public BankslipsController(IbankslipService bankslipService)
        {
            _bankslipService = bankslipService;
        }
        /// <summary>
        /// GET: rest/bankslips 
        /// Metodo para retornar a listagem de boletos
        /// </summary>
        /// <returns>Retorna uma lista de boletos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var models = _bankslipService.GetAllItems();
            return Ok(models);
        }

        /// <summary>
        /// GET: rest/bankslips/d1011c05-3416-4f9d-82cd-a27807398417
        /// Metodo para retornar um boleto esperando como parametro um ID.
        /// </summary>
        /// <returns>Retorna um boleto
        /// {
        ///     "id":"c2dbd236-3fa5-4ccc-9c12-bd0ae1d6dd89",
        ///     "due_date":"2018-05-10",
        ///     "payment_date":"2018-05-13",
        ///     "total_in_cents":"99000",
        ///     "customer":"Ford Prefect Company",
        ///     "fine":"1485",
        ///     "status":"PAID"
        /// }
        /// 200: OK
        /// 404: Boleto nao encontrado com o id fornecido.
        /// </returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity("Invalid bankslip provided.The possible reasons are: A field of the provided bankslip was null or with invalid values");
            }

            var model = _bankslipService.GetById(id);
            if (model == null)
            {
                return NotFound("Bankslip not found with the specified id");
            }
            return Ok(model);
        }


        /// <summary>
        /// POST: rest/bankslips
        /// {
        ///    "due_date":"2018-01-01",
        ///    "total_in_cents":"100000",
        ///    "customer":"Trillian Company"
        /// }
        /// Metodo para criar um boleto. Os dados devem vir via Body em application/json
        /// </summary>
        /// <returns>Retorna o boleto criado
        ///  {
        ///     "id":"84e8adbf-1a14-403b-ad73-d78ae19b59bf",
        ///     "due_date":"2018-01-01",
        ///     "total_in_cents":"100000",
        ///     "customer":"Trillian Company",
        ///     "status":"PENDING"
        /// }
        /// 201: Boleto Criado
        /// 400: Dados do boleto nao enviado via Body
        /// 422: Boleto com dados incorretos. Campo inválido ou nulo.
        /// </returns>
        [HttpPost]
        public IActionResult Post([FromBody]Models.bankslip value)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity("Invalid bankslip provided.The possible reasons are: A field of the provided bankslip was null or with invalid values");
            }
            try
            {
                if (value.Equals(null))
                    return BadRequest("Bankslip not provided in the request body");

                var newModel = _bankslipService.Add(value);
                //HttpContext.Response.StatusCode = Convert.ToInt16(HttpStatusCode.Created);

                return StatusCode(201, newModel);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity("Invalid bankslip provided.The possible reasons are: A field of the provided bankslip was null or with invalid values");
            }


        }

        /// <summary>
        /// POST: rest/bankslips/84e8adbf-1a14-403b-ad73-d78ae19b59bf/payments
        /// {
        ///    "payment_date":"2018-06-30"
        /// }
        /// Metodo para pagar um boleto. Os dados devem vir via Body em application/json
        /// </summary>
        /// <returns>      
        /// 204: Boleto pago.
        /// 404: Boleto nao encontrado com o id fornecido.
        /// </returns>
        [HttpPost("{id}")]
        [Route("rest/[controller]/{id}/payments")]
        public IActionResult Post(string id, [FromBody]Models.bankslip value)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity("Invalid bankslip provided.The possible reasons are: A field of the provided bankslip was null or with invalid values");
            }
            try
            {
                if (value.Equals(null))
                    return BadRequest("Bankslip not provided in the request body");

                var model = _bankslipService.Pay(id, value);
                if (model == null)
                {
                    return NotFound("Bankslip not found with the specified id");
                }
                return StatusCode(204);
            }
            catch (Exception )
            {
                return UnprocessableEntity("Invalid bankslip provided.The possible reasons are: A field of the provided bankslip was null or with invalid values");
            }

        }

        /// <summary>
        /// DELETE: rest/bankslips/84e8adbf-1a14-403b-ad73-d78ae19b59bf        
        /// Metodo para cancelar um boleto.
        /// </summary>
        /// <returns>      
        /// 204: Boleto cancelado.
        /// 404: Boleto nao encontrado com o id fornecido.
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            try
            {                
                _bankslipService.Remove(id);
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;    
            }
            catch (Exception)
            {

                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            
        }
    }
}

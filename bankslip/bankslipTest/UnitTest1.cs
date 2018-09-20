using bankslip.Controllers;
using bankslip.Models;
using bankslip.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bankslipTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly bankslipService _bankslipService;
        public UnitTest1()
        {
            _bankslipService = new bankslipService();
            using (var db = new DataBase())
            {
                db.Database.EnsureCreated();
            }
        }
        [TestMethod]
        public void TestMethod1()
        {
            var boletos = _bankslipService.GetAllItems();
            Assert.IsNotNull(boletos);
            Assert.IsInstanceOfType(boletos, typeof(IEnumerable<bankslip.Models.bankslipShort>));
        }
        [TestMethod]
        public void Teste_Add_Boleto()
        {
            var boleto = new bankslip.Models.bankslip()
            {
                due_date = new DateTime(2018, 12, 20),
                customer = "Felipe Tibério de Oliveira",
                total_in_cents = 40005
            };
            var controller = new BankslipsController(new bankslipService());
            var result = controller.Post(boleto);
            Assert.IsNotNull(result);
            ObjectResult objResult = result as ObjectResult;
            Assert.IsNotNull(objResult);
            Assert.AreEqual(201, (int)objResult.StatusCode);
            
        }
    }
}

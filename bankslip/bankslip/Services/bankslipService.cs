using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankslip.Models;

namespace bankslip.Services
{
    public class bankslipService : IbankslipService
    {
        public bankslipShort Add(Models.bankslip bankslip)
        {
            var newBoleto = bankslipManage.CriarBoleto(bankslip);
            return newBoleto;
        }

        public IEnumerable<bankslipShort> GetAllItems()
        {
            var listaBoletos = bankslipManage.GetBoletos();
            return listaBoletos;
        }

        public Models.bankslip GetById(string id)
        {
            var boleto = bankslipManage.GetBoleto(id);
            return boleto;
        }

        public Models.bankslip Pay(string id, Models.bankslip bankslip)
        {
            var boleto = bankslipManage.GetBoleto(id);
            if (boleto != null)
            {
                bankslipManage.PagaBoleto(id, ref boleto);
            }
            return boleto;
        }

        public void Remove(string id)
        {
            bankslipManage.CancelaBoleto(id);
        }
    }
}

using bankslip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankslip.Services
{
    public interface IbankslipService
    {
        IEnumerable<bankslipShort> GetAllItems();
        Models.bankslip GetById(string id);
        bankslipShort Add(Models.bankslip bankslip);
        Models.bankslip Pay(string id, Models.bankslip bankslip);
        void Remove(string id);
    }
}

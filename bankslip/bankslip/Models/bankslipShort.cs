using bankslip.Functions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankslip.Models
{

    /// <summary>
    /// Classe resumida da classe base do boleto (bankslip).
    /// </summary>
    public class bankslipShort
    {
        public Guid Id { get; set; }
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime due_date { get; set; }
        public Decimal total_in_cents { get; set; }
        public String customer { get; set; }        
        public String status { get; set; }

        public bankslipShort(bankslip _bankslip)
        {
            this.Id             = _bankslip.Id;
            this.due_date       = _bankslip.due_date;
            this.total_in_cents = _bankslip.total_in_cents;
            this.customer       = _bankslip.customer;
            this.status         = _bankslip.status;
        }
    }
}

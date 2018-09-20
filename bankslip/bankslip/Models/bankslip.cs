using bankslip.Functions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankslip.Models
{

    /// <summary>
    /// Classe base de boleto para criação da Tabela no arquivo database.db
    /// </summary>
    public class bankslip
    {
        public Guid Id { get; set; }
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime due_date { get; set; }
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime payment_date { get ; set; }
        public Decimal total_in_cents { get; set; }
        public String customer { get; set; }
        public Decimal fine { get; set; }
        public string status {get;set;}
    }    
}


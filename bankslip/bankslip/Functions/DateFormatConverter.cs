using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankslip.Functions
{
    
    /// <summary>
    /// Classe Converter para formatar a saída em Json do DateTime;
    /// </summary>
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            this.DateTimeFormat = format;
        }
    }
}

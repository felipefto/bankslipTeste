using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankslip.Models
{

    /// <summary>
    /// Classe para gerenciar os dados de boleto.
    /// </summary>
    public static class bankslipManage
    {
        public static bankslipShort CriarBoleto(bankslip bankslip)
        {
            try
            {
                var _bankslip = bankslip;
                _bankslip.Id = Guid.NewGuid();
                _bankslip.status = Status.PENDING;
                _bankslip.payment_date = DateTime.MinValue;
                using (var db = new DataBase())
                {
                    db.Bankslip.Add(_bankslip);
                    db.SaveChanges();
                }
                return new bankslipShort(_bankslip);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static List<bankslipShort> GetBoletos()
        {
            var listaBoleto = new List<bankslipShort>();
            using (var db = new DataBase())
            {
                foreach (var item in db.Bankslip.ToList())
                {
                    listaBoleto.Add(new bankslipShort(item));
                }
            }
            return listaBoleto;
        }

        public static bankslip GetBoleto(string id)
        {
            bankslip boleto;
            try
            {

                var _id = new Guid(id);
                using (var db = new DataBase())
                {
                    boleto = db.Bankslip.SingleOrDefault(x => x.Id == _id);
                    AplicaRegraJuros(ref boleto);
                }
                return boleto;
            }
            catch (Exception)
            {

                return null;
            }

        }

        private static void AplicaRegraJuros(ref bankslip boleto)
        {
            if (boleto.status != Status.CANCELED && boleto.status != Status.PAID)
            {
                var diasDiff = (DateTime.Now - boleto.due_date).Days;
                var totalJuros = 0m;
                if (diasDiff >= 10)
                    totalJuros = boleto.total_in_cents * Convert.ToDecimal(diasDiff * 0.01);

                if (diasDiff >= 1 && diasDiff < 10)
                    totalJuros = boleto.total_in_cents * Convert.ToDecimal(diasDiff * 0.005);

                boleto.fine = totalJuros;
                boleto.payment_date = DateTime.Now.Date;
            }

        }

        public static bankslipShort GetBoletoShort(string id)
        {
            bankslipShort boletoShort;
            try
            {
                var _id = new Guid(id);
                using (var db = new DataBase())
                {
                    boletoShort = new bankslipShort(db.Bankslip.SingleOrDefault(x => x.Id == _id));
                }
                return boletoShort;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public static void PagaBoleto(string id,ref bankslip bankslip)
        {
            try
            {
                var boleto = new bankslip();
                var _id = new Guid(id);
                using (var db = new DataBase())
                {
                    boleto = db.Bankslip.SingleOrDefault(x => x.Id == _id);
                    boleto.status = Status.PAID;
                    boleto.payment_date = bankslip.payment_date;
                    db.SaveChanges();
                    bankslip = boleto;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void CancelaBoleto(string id)
        {
            try
            {
                var boleto = new bankslip();
                var _id = new Guid(id);
                using (var db = new DataBase())
                {
                    boleto = db.Bankslip.SingleOrDefault(x => x.Id == _id);
                    if (boleto == null)
                    {
                        throw new Exception("bankslip not found!");
                    }
                    boleto.status = Status.CANCELED;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


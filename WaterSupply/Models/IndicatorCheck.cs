using System;
using System.ComponentModel;

namespace WaterSupply.Models
{
    public class IndicatorCheck
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID показания")]
        public int IndicatorId { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Информация")]
        public string Info { get; set; }
    }
}

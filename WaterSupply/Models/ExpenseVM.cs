using System.ComponentModel;

namespace WaterSupply.Models
{
    public class ExpenseVM
    {
        [DisplayName("Организация")]
        public string Org { get; set; }
        [DisplayName("Среднемесячный расход")]
        public decimal Value { get; set; }
    }
}

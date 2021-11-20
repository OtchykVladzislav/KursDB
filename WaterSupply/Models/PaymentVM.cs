using System.ComponentModel;

namespace WaterSupply.Models
{
    public class PaymentVM
    {
        [DisplayName("Организация")]
        public string OrgName { get; set; }
        [DisplayName("Сумма")]
        public decimal Value { get; set; }
    }
}

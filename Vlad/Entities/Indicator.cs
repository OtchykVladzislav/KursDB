using System;
using System.ComponentModel;

namespace WaterSupply.Models
{
    public class Indicator
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID счётчика")]
        public int TargetId { get; set; }
        [DisplayName("Дата")]
        public DateTime SetupDate { get; set; }
        [DisplayName("Тариф")]
        public decimal Rate { get; set; }
        [DisplayName("Показание (м3)")]
        public int Value { get; set; }
    }
}

using System;
using System.ComponentModel;

namespace WaterSupply.Models
{
    public class CounterVM
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Марка")]
        public string Mark { get; set; }
        [DisplayName("Организация")]
        public string Organization { get; set; }
        [DisplayName("Дата установки")]
        public DateTime SetupDate { get; set; }
        [DisplayName("Местонахождение")]
        public string SetupPlace { get; set; }
        [DisplayName("Последняя проверка")]
        public DateTime LastCheck { get; set; }
        [DisplayName("Информация")]
        public string CheckInfo { get; set; }
    }
}

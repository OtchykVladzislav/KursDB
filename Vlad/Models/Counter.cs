using System;
using System.ComponentModel;

namespace Vlad.Models
{
    public class Counter
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID Марки")]
        public int MarkId { get; set; }
        [DisplayName("ID Организации")]
        public int OrganizationId { get; set; }
        [DisplayName("Дата установки")]
        public DateTime SetupDate { get; set; }
        [DisplayName("Местонахождение")]
        public string SetupPlace { get; set; }
    }
}

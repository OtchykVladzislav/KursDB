using System.ComponentModel;

namespace Vlad.Models
{
    public class CounterMark
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Производитель")]
        public string Builder { get; set; }
        [DisplayName("Срок службы (лет)")]
        public long ServiceLife { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

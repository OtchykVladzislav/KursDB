using System.ComponentModel;

namespace Vlad.Models
{
    public class Organization
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Форма собственности")]
        public string Ownership { get; set; }
        [DisplayName("Ф.И.О. директора")]
        public string DirectorName { get; set; }
        [DisplayName("Телефон директора")]
        public string DirectorPhone { get; set; }
        [DisplayName("Ф.И.О. ответственного")]
        public string SecretaryName { get; set; }
        [DisplayName("Телефон ответственного")]
        public string SecretaryPhone { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

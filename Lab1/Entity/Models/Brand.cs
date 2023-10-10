using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Entity.Models
{
    //[Table("StudentMaster")]
    public class Brand
    {
        public int Id { get; set; }
        public string NameBrand { get; set; }
        public string ProducingCountry { get; set; }

        public ICollection<Model> Models { get; set; }

    }
}

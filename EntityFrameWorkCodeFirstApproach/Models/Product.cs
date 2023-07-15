using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameWorkCodeFirstApproach.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public DateTime SelectionDate { get; set; }
        public int ProductFreshnessId { get; set; }
        public virtual ProductFreshness ProductFreshness { get; set; }
        public int Price { get; set; }
        public string Comment { get; set; }

        [NotMapped]
        public string ProductCategoryName { get; set; }
        [NotMapped]
        public string ProductFreshnessName { get; set; }

    }
}

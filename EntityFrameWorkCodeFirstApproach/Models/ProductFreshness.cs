using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkCodeFirstApproach.Models
{
    public class ProductFreshness
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

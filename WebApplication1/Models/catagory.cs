using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class catagory
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

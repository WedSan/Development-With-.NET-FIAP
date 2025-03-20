using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace checkpoint_1_2_semester.Models
{
    [Table("TOYS")]
    public class Toy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ToyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string ToyType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Classification { get; set; }

        [Required]
        [MaxLength(50)]
        public string Size { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Toy()
        {}

        public Toy(int toyId, string toyName, string toyType, string classification, string size, decimal price)
        {
            ToyId = toyId;
            ToyName = toyName;
            ToyType = toyType;
            Classification = classification;
            Size = size;
            Price = price;
        }

    }
}

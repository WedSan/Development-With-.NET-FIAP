using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzariaDonCorleone.Models;

[Table("CS_CP3_CART")]
public class Cart
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }
    
    [Column("Pizza")]
    [ForeignKey("Pizza")]
    public List<Pizza> Pizzas { get; set; }
    
    
}
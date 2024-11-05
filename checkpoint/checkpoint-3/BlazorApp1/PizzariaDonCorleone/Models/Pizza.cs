using System.ComponentModel.DataAnnotations.Schema;

namespace PizzariaDonCorleone.Models;
[Table("CS_CP3_PIZZA")]
public class Pizza
{
    [Column("NAME")]
    public string Name { get; set; }
    [Column("Price")]
    public decimal Price { get; set; }
    [Column("IMG")]
    public string ImgUrl { get; set; }


    public Pizza()
    {
    }

    public Pizza(string name, decimal price, string imgUrl)
    {
        this.Name = name;
        this.Price = price;
        this.ImgUrl = imgUrl;
    }
}
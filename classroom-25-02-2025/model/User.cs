using System.ComponentModel.DataAnnotations;

namespace classroom_25_02_2025.model;

public class User
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }

    public string Role { get; set; }
}
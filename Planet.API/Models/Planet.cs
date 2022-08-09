using System.ComponentModel.DataAnnotations;

namespace Planet.API.Models;
public class Planet
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
}
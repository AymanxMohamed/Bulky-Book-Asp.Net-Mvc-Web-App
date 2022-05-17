using System.ComponentModel.DataAnnotations;

namespace Bulky.Models;
public class CoverType
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models;
public class Category
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "Display order must be between 1 and 100 only!!")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}
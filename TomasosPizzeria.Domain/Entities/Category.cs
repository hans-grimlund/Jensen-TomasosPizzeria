using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SharedKernel;

namespace TomasosPizzeria.Domain.Entities;

public class Category : EntityBase
{
    [StringLength(20)]
    public string Name { get; set; } = string.Empty;
    
    [JsonIgnore]
    public virtual ICollection<Dish>? Dishes { get; set; }
}
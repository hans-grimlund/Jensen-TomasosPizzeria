using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SharedKernel;

namespace TomasosPizzeria.Domain.Entities;

public class Dish : EntityBase
{
    [StringLength(30)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public virtual ICollection<Ingredient> Ingredients { get; set; } = [];
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = [];
}
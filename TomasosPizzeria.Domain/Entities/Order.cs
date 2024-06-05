using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SharedKernel;

namespace TomasosPizzeria.Domain.Entities;

public class Order : EntityBase
{
    public decimal Total { get; set; }
    public decimal Discount { get; set; } = 1;
    
    [StringLength(20)]
    public string Status { get; set; } = string.Empty;
    public string ApplicationUserId { get; set; } = string.Empty;
    
    [JsonIgnore]
    public virtual ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
    public virtual ICollection<Dish> Dishes { get; set; } = [];

    public void CalculateTotal()
    {
        Total = (Total * Discount);
    }
}
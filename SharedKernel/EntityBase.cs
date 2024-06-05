using System.ComponentModel.DataAnnotations;

namespace SharedKernel;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}
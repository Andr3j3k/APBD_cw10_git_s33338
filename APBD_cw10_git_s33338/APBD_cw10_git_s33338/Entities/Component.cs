namespace APBD_cw10_git_s33338.Entities;

public class Component
{
    public string Code { get; set; }=String.Empty;
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; }
    public int ComponentManufacturerId { get; set; }
    public int ComponentTypeId { get; set; }
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    public ComponentType ComponentType { get; set; } = null!;
    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}
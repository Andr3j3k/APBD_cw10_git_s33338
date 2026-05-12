namespace APBD_cw10_git_s33338.Entities;

public class ComponentType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public ICollection<Component> Components { get; set; } = new List<Component>();
    
}
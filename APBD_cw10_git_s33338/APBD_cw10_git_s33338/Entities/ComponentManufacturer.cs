namespace APBD_cw10_git_s33338.Entities;

public class ComponentManufacturer
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = String.Empty;
    public string FullName { get; set; } = String.Empty;
    public DateTime FoundationDate { get; set; }
    public ICollection<Component> Components { get; set; } = new List<Component>();
}
namespace APBD_cw10_git_s33338.Entities;

public class PC
{
    public int Id { get; set; }
    public string Name { get; set; }=String.Empty;
    public double Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}
namespace APBD_cw10_git_s33338.Entities;

public class PCComponent
{
    public int PCId { get; set; }
    public string ComponentCode { get; set; }=String.Empty;
    public int Amount { get; set; }
    public PC PC { get; set; } = null!;
    public Component Component { get; set; } = null!;
}
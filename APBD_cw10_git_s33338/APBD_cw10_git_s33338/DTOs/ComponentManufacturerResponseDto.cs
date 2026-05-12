namespace APBD_cw10_git_s33338.DTOs;

public class ComponentManufacturerResponseDto
{
    public int Id { get; set; }

    public string Abbreviation { get; set; } = String.Empty;

    public string FullName { get; set; } = String.Empty;

    public DateTime FoundationDate { get; set; }
}
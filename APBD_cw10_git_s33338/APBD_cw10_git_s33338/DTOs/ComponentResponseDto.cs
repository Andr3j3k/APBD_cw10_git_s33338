namespace APBD_cw10_git_s33338.DTOs;

public class ComponentResponseDto
{
    public string Code { get; set; } = String.Empty;

    public string Name { get; set; } = String.Empty;

    public string? Description { get; set; }

    public ComponentManufacturerResponseDto Manufacturer { get; set; } = null!;

    public ComponentTypeResponseDto Type { get; set; } = null!;
}
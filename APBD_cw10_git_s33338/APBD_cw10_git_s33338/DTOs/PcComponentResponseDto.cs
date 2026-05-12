namespace APBD_cw10_git_s33338.DTOs;

public class PcComponentResponseDto
{
    public int Amount { get; set; }

    public ComponentResponseDto Component { get; set; } = null!;
}
using APBD_cw10_git_s33338.DTOs;

namespace APBD_cw10_git_s33338.Services;

public interface IDbService
{
    Task<IEnumerable<PcResponseDto>> GetAllPcsAsync();

    Task<PcDetailsResponseDto> GetPcWithComponentsByIdAsync(int id);

    Task<PcResponseDto> AddPcAsync(CreatePcRequestDto request);

    Task<PcResponseDto> UpdatePcAsync(int id, UpdatePcRequestDto request);

    Task RemovePcByIdAsync(int id);
}
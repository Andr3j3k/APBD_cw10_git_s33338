using APBD_cw10_git_s33338.Data;
using APBD_cw10_git_s33338.DTOs;
using APBD_cw10_git_s33338.Entities;
using APBD_cw10_git_s33338.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw10_git_s33338.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PcResponseDto>> GetAllPcsAsync()
    {
        var pcs = await _dbContext.PCs
            .Select(pc => new PcResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();

        return pcs;
    }

    public async Task<PcDetailsResponseDto> GetPcWithComponentsByIdAsync(int id)
    {
        var pc = await _dbContext.PCs
            .Where(pc => pc.Id == id)
            .Select(pc => new PcDetailsResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock,

                Components = pc.PCComponents.Select(pcComponent => new PcComponentResponseDto
                {
                    Amount = pcComponent.Amount,
                    Component = new ComponentResponseDto
                    {
                        Code = pcComponent.Component.Code.Trim(),
                        Name = pcComponent.Component.Name,
                        Description = pcComponent.Component.Description,

                        Manufacturer = new ComponentManufacturerResponseDto
                        {
                            Id = pcComponent.Component.ComponentManufacturer.Id,
                            Abbreviation = pcComponent.Component.ComponentManufacturer.Abbreviation,
                            FullName = pcComponent.Component.ComponentManufacturer.FullName,
                            FoundationDate = pcComponent.Component.ComponentManufacturer.FoundationDate
                        },

                        Type = new ComponentTypeResponseDto
                        {
                            Id = pcComponent.Component.ComponentType.Id,
                            Abbreviation = pcComponent.Component.ComponentType.Abbreviation,
                            Name = pcComponent.Component.ComponentType.Name
                        }
                    }
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (pc == null)
        {
            throw new NotFoundException();
        }

        return pc;
    }

    public async Task<PcResponseDto> AddPcAsync(CreatePcRequestDto request)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        await _dbContext.PCs.AddAsync(pc);
        await _dbContext.SaveChangesAsync();

        return new PcResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<PcResponseDto> UpdatePcAsync(int id, UpdatePcRequestDto request)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(e => e.Id == id);

        if (pc == null)
        {
            throw new NotFoundException();
        }

        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;

        await _dbContext.SaveChangesAsync();

        return new PcResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task RemovePcByIdAsync(int id)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(e => e.Id == id);

        if (pc == null)
        {
            throw new NotFoundException();
        }

        _dbContext.PCs.Remove(pc);
        await _dbContext.SaveChangesAsync();
    }
}
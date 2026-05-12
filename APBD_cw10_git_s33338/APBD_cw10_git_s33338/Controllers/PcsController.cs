using APBD_cw10_git_s33338.DTOs;
using APBD_cw10_git_s33338.Exceptions;
using APBD_cw10_git_s33338.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_cw10_git_s33338.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PcsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPcsAsync()
    {
        var pcs = await _dbService.GetAllPcsAsync();
        return Ok(pcs);
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPcWithComponentsByIdAsync(int id)
    {
        try
        {
            var pc = await _dbService.GetPcWithComponentsByIdAsync(id);
            return Ok(pc);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPcAsync(CreatePcRequestDto request)
    {
        var createdPc = await _dbService.AddPcAsync(request);

        return Created($"api/pcs/{createdPc.Id}", createdPc);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePcAsync(int id, UpdatePcRequestDto request)
    {
        try
        {
            var updatedPc = await _dbService.UpdatePcAsync(id, request);
            return Ok(updatedPc);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemovePcByIdAsync(int id)
    {
        try
        {
            await _dbService.RemovePcByIdAsync(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}
using DenounceBeasts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectorsController : ControllerBase
{

    private static readonly List<Sector> _sectors = new List<Sector>
        {
            new Sector { Id = 1, Name = "Zona Colonial", MunicipalityId = 1, IsActive = true },
            new Sector { Id = 2, Name = "Gascue", MunicipalityId = 1, IsActive = true },
            new Sector { Id = 3, Name = "Cienfuegos", MunicipalityId = 2, IsActive = true }
        };

    [HttpGet]
    public ActionResult<IEnumerable<Sector>> GetSectors()
    {
        return Ok(_sectors);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Sector> GetSectorById(int id)
    {
        var sector = _sectors.FirstOrDefault(s => s.Id == id);
        if (sector == null)
        {
            return NotFound();
        }
        return Ok(sector);
    }

    [HttpPost]
    public ActionResult<Sector> CreateSector(Sector sector)
    {
        sector.Id = _sectors.Max(s => s.Id) + 1;
        _sectors.Add(sector);
        return CreatedAtAction(nameof(GetSectorById), new { id = sector.Id }, sector);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult UpdateSector(int id, Sector updatedSector)
    {
        var sector = _sectors.FirstOrDefault(s => s.Id == id);
        if (sector == null)
        {
            return NotFound();
        }
        sector.Name = updatedSector.Name;
        sector.MunicipalityId = updatedSector.MunicipalityId;
        sector.IsActive = updatedSector.IsActive;
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteSector(int id)
    {
        var sector = _sectors.FirstOrDefault(s => s.Id == id);
        if (sector == null)
        {
            return NotFound();
        }
        _sectors.Remove(sector);
        return NoContent();
    }


}


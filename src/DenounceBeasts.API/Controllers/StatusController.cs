using DenounceBeasts.API.Data;
using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly DataContext _context;
    public StatusController(DataContext dataContext)
    {
        _context = dataContext;
    }
     
    [HttpGet]
    public ActionResult<IEnumerable<StatusDto>> GetStatus()
    {
        var _status = _context.Status.ToList(); 
        var result = _status.Select(ct => new StatusDto
        {
            Id = ct.Id,
            Name = ct.Name
        }).ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<StatusDto> GetStatusById(int id)
    {
        var status = _context.Status.FirstOrDefault(s => s.Id == id);
        if (status == null)
        {
            return NotFound();
        }
        var respose = new StatusDto
        {
            Id = status.Id,
            Name = status.Name
        };
        return Ok(respose);
    }

    [HttpPost]
    public ActionResult<int> CreateStatus(StatusDto request)
    {
        var status = new Status
        {
            Name = request.Name
        };


        _context.Status.Add(status);
        _context.SaveChanges();

        return Ok(new { Id = status.Id });
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult UpdateStatus(int id, StatusDto updatedStatu)
    {
        var status = _context.Status.FirstOrDefault(s => s.Id == id);
        if (status == null)
        {
            return NotFound();
        }

        status.Name = updatedStatu.Name;

        _context.Status.Update(status);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteStatus(int id)
    {
        var status = _context.Status.FirstOrDefault(s => s.Id == id);
        if (status == null)
        {
            return NotFound();
        }
        _context.Status.Remove(status);
        _context.SaveChanges();
        return NoContent();
    }


}


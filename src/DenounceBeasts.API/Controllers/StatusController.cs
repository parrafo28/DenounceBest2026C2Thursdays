using DenounceBeasts.Application.Models.Dtos;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly DataContext _context;
    private readonly StatusRepository _repository;

    public StatusController(DataContext dataContext, StatusRepository repository)
    {
        _context = dataContext;
        this._repository = repository;
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
        //var status = _context.ComplaintTypes.FirstOrDefault(s => s.Id == id);
        var status = _repository.GetById(id);
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

        _repository.Create(status);

        return Ok(new { Id = status.Id });
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult UpdateStatus(int id, StatusDto updatedStatu)
    {
        var status = _repository.GetById(id);
        if (status == null)
        {
            return NotFound();
        }

        status.Name = updatedStatu.Name;

        _repository.Update(status);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteStatus(int id)
    {
        var status = _repository.GetById(id);
        if (status == null)
        {
            return NotFound();
        }
        _repository.Delete
            (status);
        return NoContent();
    }


}


using DenounceBeasts.API.Data;
using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComplaintTypesController : BaseController
{
    //private readonly DataContext _context;
    public ComplaintTypesController(DataContext dataContext): base(dataContext)
    {
        //_context = dataContext;
    }
     
    [HttpGet]
    public ActionResult<IEnumerable<ComplaintTypeDto>> GetComplaintTypes()
    {
        var _complaintTypes = Context.ComplaintTypes.ToList();
        var response = _complaintTypes.Select(ct => new ComplaintTypeDto
        {
            Id = ct.Id,
            Name = ct.Name
        }).ToList();
        //var response =  Mapper.Map<List<ComplaintTypeDto>>(_complaintTypes);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ComplaintTypeDto> GetComplaintTypeById(int id)
    {
        var complaintType = Context.ComplaintTypes.FirstOrDefault(s => s.Id == id);
        if (complaintType == null)
        {
            return NotFound();
        }
        var respose = new ComplaintTypeDto
        {
            Id = complaintType.Id,
            Name = complaintType.Name
        };
        return Ok(respose);
    }

    [HttpPost]
    public ActionResult<int> CreateComplaintType(ComplaintTypeDto request)
    {
        var complaintType = new ComplaintType
        {
            Name = request.Name
        };


        Context.ComplaintTypes.Add(complaintType);
        Context.SaveChanges();

        return Ok(new { Id = complaintType.Id });
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult UpdateComplaintType(int id, ComplaintTypeDto updatedComplaintType)
    {
        var complaintType = Context.ComplaintTypes.FirstOrDefault(s => s.Id == id);
        if (complaintType == null)
        {
            return NotFound();
        }

        complaintType.Name = updatedComplaintType.Name;

        Context.ComplaintTypes.Update(complaintType);
        Context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteComplaintType(int id)
    {
        var complaintType = Context.ComplaintTypes.FirstOrDefault(s => s.Id == id);
        if (complaintType == null)
        {
            return NotFound();
        }
        Context.ComplaintTypes.Remove(complaintType);
        Context.SaveChanges();
        return NoContent();
    }


}


using AutoMapper;
using DenounceBeasts.API.Data;
using DenounceBeasts.API.Models.Dtos.Sectors;
using DenounceBeasts.API.Models.Entities;
using DenounceBeasts.API.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectorsController : BaseController
{
    private readonly DataContext _context;
    //private readonly IMapper _mapper;

    public SectorsController(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
    {
        _context = dataContext;
        //_mapper = mapper;
    }


    [HttpGet]
    public ApiResponse<IEnumerable<SectorDto>> GetSectors()
    {
        //var _sectors = _context.Sectors.ToList(); 
        var _sectors = _context.Sectors.Include(p => p.Municipality).ToList();
        //var _municipalities = _context.Municipalities.ToList();
        //var response = _sectors.Select(s => new SectorDto
        //{
        //    Id = s.Id,
        //    Name = s.Name,
        //    MunicipalityId = s.MunicipalityId,
        //    IsActive = s.IsActive,
        //    //MunicipalityName = _context.Municipalities
        //    //.FirstOrDefault(m => m.Id == s.MunicipalityId)?.Name
        //    //MunicipalityName = _municipalities
        //    //.FirstOrDefault(m => m.Id == s.MunicipalityId)?.Name
        //    //MunicipalityName = s.Municipality.Name
        //    //MunicipalityName = s.Municipality != null ? s.Municipality.Name : string.Empty
        //    MunicipalityName = (s.Municipality == null) ? string.Empty : s.Municipality.Name
        //}).ToList();

        //var result = Mapper.Map<List<SectorDto>>(_sectors);
        //var response = ApiResponse<IEnumerable<SectorDto>>.SuccessResponse(result);
        //return response ;
        //return ApiResponse<IEnumerable<SectorDto>>.SuccessResponse(result);
        return ApiResponse<IEnumerable<SectorDto>>
            .SuccessResponse(Mapper.Map<List<SectorDto>>(_sectors));

    }

    [HttpGet]
    [Route("{id}")]
    public ApiResponse<SectorDto> GetSectorById(int id)
    {
        var sector = _context.Sectors.FirstOrDefault(s => s.Id == id);
        if (sector == null)
        {
            //return NotFound();
            return ApiResponse<SectorDto>.FailureResponse("Sector not found", 404);

        }
        //var response = new SectorDto
        //{
        //    Id = sector.Id,
        //    Name = sector.Name,
        //    MunicipalityId = sector.MunicipalityId,
        //    IsActive = sector.IsActive,
        //    Deleted = sector.Deleted
        //};
        //var response = Mapper.Map<SectorDto>(sector);
        //return Ok(response);

        return ApiResponse<SectorDto>.SuccessResponse(Mapper.Map<SectorDto>(sector));
    }

    [HttpPost]
    public ApiResponse<int> CreateSector(CreateSectorDto request)
    {
        //var sector = new Sector
        //{
        //    Name = request.Name,
        //    MunicipalityId = request.MunicipalityId,
        //    IsActive = true
        //};
        var sector = Mapper.Map<Sector>(request);

        _context.Sectors.Add(sector);
        _context.SaveChanges();

        //return Ok(new { Id = sector.Id });
        return ApiResponse<int>.SuccessResponse(sector.Id);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult UpdateSector(int id, SectorDto request)
    {
        var sector = _context.Sectors.FirstOrDefault(s => s.Id == id);
        if (sector == null)
        {
            return NotFound();
        }

        sector.Name = request.Name;
        sector.MunicipalityId = request.MunicipalityId;
        sector.IsActive = request.IsActive;

        _context.Sectors.Update(sector);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteSector(int id)
    {
        var sector = _context.Sectors.FirstOrDefault(s => s.Id == id);
        if (sector == null)
        {
            return NotFound();
        }
        _context.Sectors.Remove(sector);
        _context.SaveChanges();
        return NoContent();
    }


}


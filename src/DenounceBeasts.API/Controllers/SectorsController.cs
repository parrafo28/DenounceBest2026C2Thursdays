using AutoMapper;
using DenounceBeasts.Application.Controllers;
using DenounceBeasts.Application.Models.Dtos.Sectors;
using DenounceBeasts.Application.Models.Entities;
using DenounceBeasts.Application.Models.Responses;
using DenounceBeasts.Infraestructure;
using DenounceBeasts.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectorsController : BaseController
{
    //private readonly SectorRepository _repository;
    //private readonly StatusRepository _statusRepository;
    private readonly UnitOfWork _unitOfWork;
    private readonly SectorService _sectorService;
    private readonly DataContext _context;
    //private readonly IMapper _mapper;

    //public SectorsController(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
    //{
    //    _context = dataContext;
    //    //_mapper = mapper;
    //}
    public SectorsController(IMapper mapper,
        //SectorRepository repository, 
        //StatusRepository statusRepository, 
        UnitOfWork unitOfWork,
        SectorService sectorService
        ) : base(mapper)
    {
        //this._repository = repository;
        //this._statusRepository = statusRepository;
        this._unitOfWork = unitOfWork;
        this._sectorService = sectorService;
        //_mapper = mapper;
    }


    [HttpGet]
    public ApiResponse<IEnumerable<SectorDto>> GetSectors()
        => _sectorService.GetSectors();
    //{
    //    ////var _sectors = _context.Sectors.ToList(); 
    //    ////var _sectors = _repository.GetAll();
    //    //var _sectors = _unitOfWork.Sector.GetAll();

    //    //return ApiResponse<IEnumerable<SectorDto>>
    //    //    .SuccessResponse(Mapper.Map<List<SectorDto>>(_sectors));
    //    return _sectorService.GetSectors();

    //}


    [HttpGet]
    [Route("by-status")]
    public ApiResponse<IEnumerable<SectorDto>> GetSectorsFilteredByStatus()
    {
        //var status = _unitOfWork.Status.GetAll();

        //var _sectors = _unitOfWork.Sector.GetAllWithMunicipality();

        ////_unitOfWork.Status = new StatusRepository(_context);

        //return ApiResponse<IEnumerable<SectorDto>>
        //    .SuccessResponse(Mapper.Map<List<SectorDto>>(_sectors));
        return _sectorService.GetSectorsFilteredByStatus();

    }


    [HttpGet]
    [Route("with-municipality")]
    public ApiResponse<IEnumerable<SectorDto>> GetSectorsWithMunicipality()
    {
        //var _sectors = _unitOfWork.Sector.GetAllWithMunicipality();
        ////var _municipalities = _context.Municipalities.ToList();
        ////var response = _sectors.Select(s => new SectorDto
        ////{
        ////    Id = s.Id,
        ////    Name = s.Name,
        ////    MunicipalityId = s.MunicipalityId,
        ////    IsActive = s.IsActive,
        ////    //MunicipalityName = _context.Municipalities
        ////    //.FirstOrDefault(m => m.Id == s.MunicipalityId)?.Name
        ////    //MunicipalityName = _municipalities
        ////    //.FirstOrDefault(m => m.Id == s.MunicipalityId)?.Name
        ////    //MunicipalityName = s.Municipality.Name
        ////    //MunicipalityName = s.Municipality != null ? s.Municipality.Name : string.Empty
        ////    MunicipalityName = (s.Municipality == null) ? string.Empty : s.Municipality.Name
        ////}).ToList();

        ////var result = Mapper.Map<List<SectorDto>>(_sectors);
        ////var response = ApiResponse<IEnumerable<SectorDto>>.SuccessResponse(result);
        ////return response ;
        ////return ApiResponse<IEnumerable<SectorDto>>.SuccessResponse(result);
        //return ApiResponse<IEnumerable<SectorDto>>
        //    .SuccessResponse(Mapper.Map<List<SectorDto>>(_sectors));
        return _sectorService.GetSectorsWithMunicipality();

    }

    [HttpGet]
    [Route("{id}")]
    public ApiResponse<SectorDto> GetSectorById(int id)
    {
        return _sectorService.GetSectorById(id);
        //var sector = _unitOfWork.Sector.GetById(id);
        //if (sector == null)
        //{
        //    //return NotFound();
        //    return ApiResponse<SectorDto>.FailureResponse("Sector not found", 404);

        //}
        ////var response = new SectorDto
        ////{
        ////    Id = sector.Id,
        ////    Name = sector.Name,
        ////    MunicipalityId = sector.MunicipalityId,
        ////    IsActive = sector.IsActive,
        ////    Deleted = sector.Deleted
        ////};
        ////var response = Mapper.Map<SectorDto>(sector);
        ////return Ok(response);

        //return ApiResponse<SectorDto>.SuccessResponse(Mapper.Map<SectorDto>(sector));
    }

    [HttpPost]
    public ApiResponse<int> CreateSector(CreateSectorDto request)
    {
        ////var sector = new Sector
        ////{
        ////    Name = request.Name,
        ////    MunicipalityId = request.MunicipalityId,
        ////    IsActive = true
        ////};
        //var sector = Mapper.Map<Sector>(request);

        ////_context.Sectors.Add(sector);
        ////_context.SaveChanges();
        //_unitOfWork.Sector.Create(sector);
        //_unitOfWork.Complete();

        ////return Ok(new { Id = sector.Id });
        //return ApiResponse<int>.SuccessResponse(sector.Id);
        return _sectorService.CreateSector(request);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult UpdateSector(int id, SectorDto request)
    {
        //var sector = _unitOfWork.Sector.GetById(id);
        //if (sector == null)
        //{
        //    return NotFound();
        //}

        //sector.Name = request.Name;
        //sector.MunicipalityId = request.MunicipalityId;
        //sector.IsActive = request.IsActive;

        ////_context.Sectors.Update(sector);
        ////_context.SaveChanges();
        //_unitOfWork.Sector.Update(sector);
        //_unitOfWork.Complete();
        //var response = _sectorService.UpdateSector(id, request);
        //if (!response.Success)
        if (!_sectorService.UpdateSector(id, request).Success)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteSector(int id)
    {
        //var sector = _unitOfWork.Sector.GetById(id);
        //if (sector == null)
        //{
        //    return NotFound();
        //}
        ////_context.Sectors.Remove(sector);
        ////_context.SaveChanges();
        //_unitOfWork.Sector.Delete(sector);
        //_unitOfWork.Complete();

        return _sectorService.DeleteSector(id).Success ? NoContent() : NotFound();
        //if (!_sectorService.DeleteSector(id).Success)
        //{
        //    return NotFound();
        //}
        //return NoContent();
    }


}


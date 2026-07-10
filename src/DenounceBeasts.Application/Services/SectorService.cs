using AutoMapper;
using DenounceBeasts.Application.Models.Dtos.Sectors;
using DenounceBeasts.Application.Models.Entities;
using DenounceBeasts.Application.Models.Responses;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure;
using DenounceBeasts.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.Application.Controllers;

public class SectorService
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;

     private readonly DataContext _context;
    public SectorService(IMapper mapper, 
        UnitOfWork unitOfWork) 
    {
        this._mapper = mapper;
        this._unitOfWork = unitOfWork;
    }

    public ApiResponse<IEnumerable<SectorDto>> GetSectors()
    {
        var _sectors = _unitOfWork.Sector.GetAll();

        return ApiResponse<IEnumerable<SectorDto>>
            .SuccessResponse(_mapper.Map<List<SectorDto>>(_sectors));

    }


    public ApiResponse<IEnumerable<SectorDto>> GetSectorsFilteredByStatus()
    {
        var status = _unitOfWork.Status.GetAll();

        var _sectors = _unitOfWork.Sector.GetAllWithMunicipality();


        return ApiResponse<IEnumerable<SectorDto>>
            .SuccessResponse(_mapper.Map<List<SectorDto>>(_sectors));

    }


    public ApiResponse<IEnumerable<SectorDto>> GetSectorsWithMunicipality()
    {
        var _sectors = _unitOfWork.Sector.GetAllWithMunicipality();
     
        return ApiResponse<IEnumerable<SectorDto>>
            .SuccessResponse(_mapper.Map<List<SectorDto>>(_sectors));

    }

    public ApiResponse<SectorDto> GetSectorById(int id)
    {
        var sector = _unitOfWork.Sector.GetById(id);
        if (sector == null)
        {
            return ApiResponse<SectorDto>.FailureResponse("Sector not found", 404);

        }

        return ApiResponse<SectorDto>.SuccessResponse(_mapper.Map<SectorDto>(sector));
    }

    public ApiResponse<int> CreateSector(CreateSectorDto request)
    {
        
        var sector = _mapper.Map<Sector>(request);

        _unitOfWork.Sector.Create(sector);
        _unitOfWork.Complete();

        return ApiResponse<int>.SuccessResponse(sector.Id);
    }

    public ApiResponse<bool> UpdateSector(int id, SectorDto request)
    {
        var sector = _unitOfWork.Sector.GetById(id);
        if (sector == null)
        {
            return ApiResponse<bool>.FailureResponse("Sector not found", 404);
        }

        sector.Name = request.Name;
        sector.MunicipalityId = request.MunicipalityId;
        sector.IsActive = request.IsActive;

        _unitOfWork.Sector.Update(sector);
        _unitOfWork.Complete();
        return ApiResponse<bool>.SuccessResponse(true);
    }

    public ApiResponse<bool>  DeleteSector(int id)
    {
        var sector = _unitOfWork.Sector.GetById(id);
        if (sector == null)
        {
            return ApiResponse<bool>.FailureResponse("Sector not found", 404);
        }
        _unitOfWork.Sector.Delete(sector);
        _unitOfWork.Complete();
        return ApiResponse<bool>.SuccessResponse(true);
    }


}


using DenounceBeasts.API.Controllers;
using DenounceBeasts.Application.Models.Dtos;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure;
using DenounceBeasts.Infraestructure.Repositories;

namespace DenounceBeasts.Application.Controllers;

public class ComplaintTypesService
{
    private readonly GenericRepository<ComplaintType> _repository;
    private readonly UnitOfWork _unitOfWork;

    public ComplaintTypesService(DataContext dataContext,
        GenericRepository<ComplaintType> repository,
        UnitOfWork unitOfWork)
    {
        this._repository = repository;
        this._unitOfWork = unitOfWork;
    }

    public IEnumerable<ComplaintTypeDto> GetComplaintTypes()
    {
        var _complaintTypes = _repository.GetAll();
        var response = _complaintTypes.Select(ct => new ComplaintTypeDto
        {
            Id = ct.Id,
            Name = ct.Name
        }).ToList();
       return response;
    }

    public  ComplaintTypeDto  GetComplaintTypeById(int id)
    {
        var complaintType = _repository.GetById(id);
        if (complaintType == null)
        {
            return null;
        }
        var respose = new ComplaintTypeDto
        {
            Id = complaintType.Id,
            Name = complaintType.Name
        };
        return respose;
    }

    public  int  CreateComplaintType(ComplaintTypeDto request)
    {
        var complaintType = new ComplaintType
        {
            Name = request.Name
        };

        _repository.Create(complaintType);
        _unitOfWork.Complete();

        return  complaintType.Id  ;
    }

    public bool  UpdateComplaintType(int id, ComplaintTypeDto updatedComplaintType)
    {
        var complaintType = _repository.GetById(id);
        if (complaintType == null)
        {
            return false;
        }

        complaintType.Name = updatedComplaintType.Name;

        _repository.Update(complaintType);
        _unitOfWork.Complete();

        return true;
    }

    public bool DeleteComplaintType(int id)
    {
        var complaintType = _repository.GetById(id);
        if (complaintType == null)
        {
            return false;
        }
        _repository.Delete(complaintType);
        _unitOfWork.Complete();

        return true;
    }


}


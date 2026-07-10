using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers;

public class ComplaintTypeRepository
{
    private readonly DataContext _context;

    public ComplaintTypeRepository(DataContext dataContext)
    {
        _context = dataContext;
    }

    public IEnumerable<ComplaintType> GetAll()
    {
        var _complaintTypes = _context.ComplaintTypes.ToList();
        return _complaintTypes;
    }
     
    public ComplaintType GetById(int id)
    {
        var complaintType = _context.ComplaintTypes.FirstOrDefault(s => s.Id == id);
        return complaintType;
    }

    public int Create(ComplaintType complaintType)
    {
        _context.ComplaintTypes.Add(complaintType);
        _context.SaveChanges();

        return complaintType.Id;
    }

    public void Update(int id, ComplaintType request)
    {
        var complaintType = _context.ComplaintTypes.FirstOrDefault(s => s.Id == id);

        complaintType.Name = request.Name;
        
        _context.ComplaintTypes.Update(complaintType);
        _context.SaveChanges();

    }

    public void Update(ComplaintType complaintType)
    {
        _context.ComplaintTypes.Update(complaintType);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var complaintType = _context.ComplaintTypes.FirstOrDefault(s => s.Id == id);

        _context.ComplaintTypes.Remove(complaintType);
        _context.SaveChanges();
    }

    public void Delete(ComplaintType complaintType)
    {
        _context.ComplaintTypes.Remove(complaintType);
        _context.SaveChanges();
    }

}


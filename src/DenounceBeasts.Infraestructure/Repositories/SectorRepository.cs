using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers;

public class SectorRepository : GenericRepository<Sector>
{
    private readonly DataContext _context;

    public SectorRepository(DataContext dataContext) : base(dataContext)
    {
        _context = dataContext;
    }
     
    public IEnumerable<Sector> GetAllWithMunicipality()
    {
        var _sectors = _context.Sectors.Include(p => p.Municipality).ToList();
        return _sectors;
    }

    public void Update(int id, Sector request)
    {
        var sector = _context.Sectors.FirstOrDefault(s => s.Id == id);

        sector.Name = request.Name;
        sector.MunicipalityId = request.MunicipalityId;
        sector.IsActive = request.IsActive;

        _context.Sectors.Update(sector);
        _context.SaveChanges();

    }

    //public void Update(Sector sector)
    //{
    //     //var gen = new GenericRepository<int>(_context);
    //     //var gen = new GenericRepository<SectorModel>(_context);
    //     //var gen = new GenericRepository<Sector>(_context);
    //    _context.Sectors.Update(sector);
    //    _context.SaveChanges();
    //}




}


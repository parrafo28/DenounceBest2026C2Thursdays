using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure;

namespace DenounceBeasts.API.Controllers;

public class StatusRepository : GenericRepository<Status>
{
    private readonly DataContext _context;

    public StatusRepository(DataContext dataContext) : base(dataContext)
    {
        _context = dataContext;
    }

}


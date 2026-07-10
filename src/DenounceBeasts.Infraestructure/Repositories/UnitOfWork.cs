using DenounceBeasts.API.Controllers;
using DenounceBeasts.Domain.Entities;

namespace DenounceBeasts.Infraestructure.Repositories
{
    public class UnitOfWork
    {
        //SectorRepository _sectorRepository;

        private readonly DataContext _context;
        public UnitOfWork(DataContext context, 
            SectorRepository sectorRepository,
            StatusRepository status,
            GenericRepository<ComplaintType> complaintType,
            GenericRepository<Municipality> municipality)
        {
            _context = context;
            Sector = sectorRepository;
            Status = status;
            ComplaintType = complaintType;
            Municipality = municipality;
        }

        public SectorRepository Sector { get; private set; }
        public StatusRepository Status { get; private set; }
        public GenericRepository<ComplaintType> ComplaintType { get; private set; }
        public GenericRepository<Municipality> Municipality { get; private set; }

        //public SectorRepository SectorRepository => _sectorRepository ??= new SectorRepository(_context);


        //public SectorRepository SectorRepository
        //{
        //    get
        //    {
        //        if (_sectorRepository == null)
        //        {
        //            _sectorRepository = new SectorRepository(_context);
        //        }
        //        return _sectorRepository;
        //    }
        //}



        public void Complete()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
    }
}

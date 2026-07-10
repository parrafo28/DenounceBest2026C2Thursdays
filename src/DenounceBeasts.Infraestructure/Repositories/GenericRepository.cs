using DenounceBeasts.Domain.Core;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers;

public class GenericRepository<T> where T : BaseEntity
{
    private readonly DataContext _context;

    public GenericRepository(DataContext dataContext)
    {
        _context = dataContext;
    }

    public IEnumerable<T> GetAll()
    {
        var entity = _context.Set<T>().ToList();
        return entity;
    }
     
    public T GetById(int id)
    {
        var entity = _context.Set<T>()
            .FirstOrDefault(s => s.Id == id);
        return entity;
    }

    public int Create(T entity)
    {
        _context.Set<T>().Add(entity);
        //_context.SaveChanges();

        return entity.Id;
    }

    //public void SaveChanges()
    //{
    //    _context.SaveChanges();
    //}



    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        //_context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _context.Set<T>().FirstOrDefault(s => s.Id == id);

        _context.Set<T>().Remove(entity);
        //_context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity); 
        //_context.SaveChanges();
    }

}


using AutoMapper;
using DenounceBeasts.Infraestructure;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        //public readonly DataContext Context;
        public readonly IMapper Mapper;
        private DataContext dataContext;

        //public BaseController(DataContext dataContext)
        //{
        //    Context = dataContext;
        //}

        //public BaseController(DataContext dataContext, IMapper mapper)
        //{
        //    Context = dataContext;
        //    this.Mapper = mapper;
        //}
        public BaseController(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        public BaseController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}

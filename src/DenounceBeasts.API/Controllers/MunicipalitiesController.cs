using DenounceBeasts.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalitiesController : ControllerBase
    {
        private static readonly List<Municipality> _municipalities = new List<Municipality>
        {
            new Municipality { Id = 1, Name = "Santo Domingo", PostalCode = "10101", IsActive = true },
            new Municipality { Id = 2, Name = "Santiago de los Caballeros", PostalCode = "51000", IsActive = true },
            new Municipality { Id = 3, Name = "Puerto Plata", PostalCode = "57000", IsActive = true }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Municipality>> GetAll()
        {
            return Ok(_municipalities);

        }

        [HttpGet]
        [Route("get-ordered")]
        public ActionResult<IEnumerable<Municipality>> GetAllOrderes()
        {
            return Ok(_municipalities.OrderBy(p=> p.Name));

        }

        [HttpGet]
        [Route("api/municipality/get-ordered")]
        public ActionResult<IEnumerable<Municipality>> GetAllOrderesx()
        {
            return Ok(_municipalities.OrderBy(p => p.Name));

        }

        [HttpGet]
        [Route("/api/municipality/get-ordered")]
        public ActionResult<IEnumerable<Municipality>> GetAllOrderesxx()
        {
            return Ok(_municipalities.OrderBy(p => p.Name));

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Municipality> GetById(int id)
        {
            var municipality = _municipalities
                .FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }
            return Ok(municipality);

        }

        [HttpPost]
        public ActionResult<Municipality> Create(Municipality municipality)
        {
            municipality.Id = _municipalities.Max(m => m.Id) + 1;

            ////if (string.IsNullOrEmpty(municipality.Name))
            ////{
            ////    return BadRequest("The Name field is required.");
            ////}


            _municipalities.Add(municipality);
            return CreatedAtAction(nameof(GetById), new { id = municipality.Id }, municipality);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, Municipality updatedMunicipality)
        {
            var municipality = _municipalities
                .FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }
            municipality.Name = updatedMunicipality.Name;
            municipality.PostalCode = updatedMunicipality.PostalCode;
            municipality.IsActive = updatedMunicipality.IsActive;
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var municipality = _municipalities
                .FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }
            _municipalities.Remove(municipality);
            return NoContent();
        } 

    }
}

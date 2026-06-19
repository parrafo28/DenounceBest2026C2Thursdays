using DenounceBeasts.API.Models.Dtos.Base;

namespace DenounceBeasts.API.Models.Entities
{
    public class SectorDto: BaseDto
    {
        //public int Id { get; set; }
        //public string Name { get; set; } = string.Empty;
       public int MunicipalityId { get; set; }
        public bool IsActive { get; set; } = true;
        public string MunicipalityName { get; set; }
        //public bool Deleted { get; set; }
    }

}

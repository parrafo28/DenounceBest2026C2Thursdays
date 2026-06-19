using DenounceBeasts.API.Models.Dtos.Contracts;

namespace DenounceBeasts.API.Models.Dtos.Sectors
{
    public class CreateSectorDto : INameDto
    {
        public string Name { get; set; }
        public int MunicipalityId { get; set; }
    }
}

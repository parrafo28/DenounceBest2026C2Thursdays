using DenounceBeasts.Application.Models.Dtos.Contracts;

namespace DenounceBeasts.Application.Models.Dtos.Sectors
{
    public class CreateSectorDto : INameDto
    {
        public string Name { get; set; }
        public int MunicipalityId { get; set; }
    }
}

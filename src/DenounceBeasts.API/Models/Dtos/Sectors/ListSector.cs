using DenounceBeasts.API.Models.Entities;

namespace DenounceBeasts.API.Models.Dtos.Sectors
{
    public class ListSector
    {
        //public int Id { get; set; }
        //public string Name { get; set; } = string.Empty;
        //public int MunicipalityId { get; set; }
        //public bool IsActive { get; set; } = true;
        List<SectorDto> Sectors { get; set; }
    }
}

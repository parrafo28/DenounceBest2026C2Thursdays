using DenounceBeasts.Domain.Core;

namespace DenounceBeasts.Domain.Entities
{
    public class Sector: BaseEntity
    { 
        public string Name { get; set; } = string.Empty;
        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; }
        public bool IsActive { get; set; } = true;
        //public bool Deleted { get; set; }
    }

}

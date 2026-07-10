using DenounceBeasts.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenounceBeasts.Domain.Entities
{
    //[Table("MUNICIPALITY")]
    public class Municipality: BaseEntity
    { 

        [Required]
        //[Column("MUNICIPALITY_NAME")]
        public string Name { get; set; } = string.Empty;

        public string? PostalCode { get; set; }
        public bool IsActive { get; set; } = true;

        public List<Sector> Sectors { get; set; }

    }
}

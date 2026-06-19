using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenounceBeasts.API.Models.Entities
{
    //[Table("MUNICIPALITY")]
    public class Municipality
    {
        public int Id { get; set; }

        [Required]
        //[Column("MUNICIPALITY_NAME")]
        public string Name { get; set; } = string.Empty;

        public string? PostalCode { get; set; }
        public bool IsActive { get; set; } = true;

        public List<Sector> Sectors { get; set; }

    }
}

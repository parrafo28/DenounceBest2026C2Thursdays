namespace DenounceBeasts.Infraestructure.Models
{
    public class SectorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MunicipalityId { get; set; }
        public bool IsActive { get; set; }

    }
}

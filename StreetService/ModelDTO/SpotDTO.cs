using System.Diagnostics.CodeAnalysis;

namespace StreetService.ModelDTO
{
    public class SpotDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public UserDTO Creator { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        [AllowNull]
        public List<ImageDTO> Images { get; set; }
    }
}


namespace StreetService.ModelDTO
{
    public class GroupDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public List<UserDTO> Users { get; set; }
        public List<SpotDTO> Spots { get; set; }
        public bool IsPublic { get; set; }
    }
}

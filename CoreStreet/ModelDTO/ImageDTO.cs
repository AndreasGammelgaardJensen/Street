namespace CoreStreet.ModelDTO
{
    public class ImageDTO
    {
        public Guid Id { get; set; }
        public string RemoteUrl { get; set; }
        public UserDTO Creator { get; set; }
        public long Created { get; set; }

    }
}

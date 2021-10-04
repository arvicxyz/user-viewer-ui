namespace XamApp.Models.Entities
{
    public class UserModel : EntityRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string name { get; set; }
        public string nameMother { get; set; }
        public string nameFather { get; set; }
        public string email { get; set; }
        public string userMF { get; set; }

    }
}
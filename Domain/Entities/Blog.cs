using PrimeiroAppAws.Domain.Entities.Base;

namespace PrimeiroAppAws.Domain.Entities
{
    public class Blog : BaseModel
    {
        public Blog(string description, ICollection<Post> posts)
        {
            Description = description;
            Posts = posts;
        }

        public string Description { get; private set; }

        public ICollection<Post> Posts { get; private set; }
    }
}

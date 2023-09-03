using PrimeiroAppAws.Domain.Entities.Base;

namespace PrimeiroAppAws.Domain.Entities
{
    public class Blog : BaseModel
    {

        public Blog(string description)
        {
            Description = description;
        }

        public string Description { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}

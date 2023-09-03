namespace PrimeiroAppAws.Domain.Entities.Base
{
    public class BaseModel
    {
        public virtual Guid Id { get; protected set; } = Guid.NewGuid();
        public virtual DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public virtual bool Active { get; protected set; } = true;
    }
}

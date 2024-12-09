namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public bool IsDeleted { get; private set; } = false;
        public DateTime? DeletedTime { get; private set; }
        public void SetIsDeleted()
        {
            this.IsDeleted = true;
            this.DeletedTime = DateTime.Now;
        }
        public Guid SetId(Guid id)
        {
            return this.Id = id;
        }
    }
}

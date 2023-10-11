namespace Domain.Entities
{
    public class BaseEntity
    {

        public int Id { get; protected set; } = default!;
        public DateOnly CreationDate { get; protected set; }
        public DateOnly? ModificationDate { get; protected set; }

        public virtual void SetId(int id)
        {
            Id = id;
        }

        public virtual void SetCreationDate(DateOnly date)
        {
            CreationDate = date;
        }

        public virtual void SetModificationDate(DateOnly date)
        {
            ModificationDate = date;
        }
    }
}

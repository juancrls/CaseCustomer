namespace Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            Status = true;
        }

        public int Id { get; protected set; } = default!;
        public bool? Status { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public DateTime? ModificationDate { get; protected set; }

        public virtual void SetId(int id)
        {
            Id = id;
        }

        public virtual void SetCreationDate(DateTime date)
        {
            CreationDate = date;
        }

        public virtual void SetModificationDate(DateTime date)
        {
            ModificationDate = date;
        }
    }
}

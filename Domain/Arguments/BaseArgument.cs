namespace Domain.Arguments
{
    public class BaseArgument
    {
        public int Id { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly? ModificationDate { get; set; }
    }
}
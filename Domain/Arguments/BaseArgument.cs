namespace Domain.Arguments
{
    public class BaseArgument
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
namespace Domain.Arguments
{
    public class Argument
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
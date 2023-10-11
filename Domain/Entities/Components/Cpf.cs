using Common.Extensions;

namespace Domain.Entities.Components
{
    public class Cpf
    {
        protected Cpf()
        { }

        public Cpf(string number) : this()
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException(nameof(number));

            Number = number.Format(FormatType.Cpf);
        }

        public virtual string Number { get; protected set; } = default!;

        public override string ToString()
        {
            return Number;
        }

        public static bool TryParse(string number, out Cpf result)
        {
            try
            {
                result = new Cpf(number);
                return true;
            }
            catch
            {
                result = default!;
                return false;
            }
        }
    }
}

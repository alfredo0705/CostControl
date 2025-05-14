namespace CostControl.Domain.ValueObjects.Common
{
    public record Name
    {
        public string Value { get; }

        private Name() { }

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (value.Length > 100)
                throw new ArgumentException("El nombre no puede exceder los 100 caracteres.");

            Value = value;
        }

        public override string ToString() => Value;
    }
}

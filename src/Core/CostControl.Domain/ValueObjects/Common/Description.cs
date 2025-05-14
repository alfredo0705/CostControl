namespace CostControl.Domain.ValueObjects.Common
{
    public record Description
    {
        public string Value { get; }

        private Description() { }

        public Description(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La descripción no puede estar vacía.");

            Value = value;
        }

        public override string ToString() => Value;
    }
}

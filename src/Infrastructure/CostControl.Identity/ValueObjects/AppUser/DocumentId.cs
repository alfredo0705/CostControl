namespace CostControl.Identity.ValueObjects.AppUser
{
    public record DocumentId
    {
        public string Value { get; }

        private DocumentId() { }

        public DocumentId(string documentId)
        {
            if (string.IsNullOrWhiteSpace(documentId) || documentId.Length > 20)
                throw new ArgumentException("Invalid document ID.", nameof(documentId));

            Value = documentId;
        }

        public override string ToString() => Value;
    }
}

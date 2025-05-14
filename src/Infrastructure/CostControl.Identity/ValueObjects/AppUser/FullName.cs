namespace CostControl.Identity.ValueObjects.AppUser
{
    public record FullName
    {
        public string FirstName { get; }
        public string LastName { get; }

        private FullName() { }

        public FullName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 50)
                throw new ArgumentException("First name cannot be empty or exceed 50 characters.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 50)
                throw new ArgumentException("Last name cannot be empty or exceed 50 characters.", nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}

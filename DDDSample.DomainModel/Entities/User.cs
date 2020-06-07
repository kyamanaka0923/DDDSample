namespace DDDSample.DomainModel
{
    public class User
    {
        public Id Id { get; }
        public Name Name { get; }

        public User (Id id, Name name)
        {
            Id = id;
            Name = name;
        }
    }
}
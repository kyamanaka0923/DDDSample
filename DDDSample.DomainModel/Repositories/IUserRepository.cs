using DDDSample.DomainModel;

namespace DDDSample.DomainModel
{
    public interface IUserRepository
    {
        Users FindAll ();
        User FindById (Id id);
        User FindByName (string Name);
    }
}
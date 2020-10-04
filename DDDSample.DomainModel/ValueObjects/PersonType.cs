namespace DDDSample.DomainModel
{
    public class PersonType : Enumeration
    {
        public static readonly PersonType Administrator = new PersonType(1, "システム管理者");
        public static readonly PersonType User = new PersonType(2, "一般ユーザ");
        PersonType(int id, string name) : base(id, name)
        {

        }
    }
}
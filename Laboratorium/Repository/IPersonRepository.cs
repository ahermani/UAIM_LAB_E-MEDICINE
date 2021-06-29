namespace Zsut.Patterns.CSharp
{
    public interface IPersonRepository
    {
        Person[] Find(PersonGender gender);
    }
}

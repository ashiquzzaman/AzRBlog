namespace MvcWithMsUnit.Entities
{

    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}

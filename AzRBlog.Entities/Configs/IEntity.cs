namespace AzRBlog.Entities.Configs
{

    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}

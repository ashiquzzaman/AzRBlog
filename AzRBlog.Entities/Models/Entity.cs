using AzRBlog.Entities.Configs;

namespace AzRBlog.Entities.Models
{
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}

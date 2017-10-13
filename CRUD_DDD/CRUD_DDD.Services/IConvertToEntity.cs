namespace CRUD_DDD.Services
{
    public interface IConvertToEntity<TEntity>
    {
        TEntity ConvertToEntity();
    }
}

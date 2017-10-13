namespace CRUD_DDD.Services
{
    public interface IApplyChangesTo<TEntity>
    {
        void ApplyChangesTo(TEntity entity);
    }
}

namespace lw4API.DAO
{
    public interface IDao<TEntity>
    {
        public void Create(TEntity entity);
        public List<TEntity> GetAll();
    }
}

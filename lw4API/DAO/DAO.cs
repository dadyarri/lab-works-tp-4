namespace lw4API.DAO
{
    public interface IDAO<Entity>
    {
        public void Create(Entity entity);
        public List<Entity> GetAll();
    }
}

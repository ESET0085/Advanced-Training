namespace College_App.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<T> getElementById(int id);
    }
}

namespace School.Repositories;

public interface IUserRepository
{
    public List<Data.User> GetUsers();
    public Data.User GetUser(int id);
    public Data.User AddUser(Dtos.CreateOrUpdateUser user);
}

namespace School.Services;

public interface IUserService
{
    public Data.User CreateUser(Dtos.CreateOrUpdateUser user);
    public List<Data.User> GetUsers();
    public Data.User GetUser(int id);
}

using School.Data;
using System.Linq.Expressions;

namespace School.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public Data.User AddUser(Dtos.CreateOrUpdateUser user)
    {
        var u = new Data.User()
        {
            Name = user.Name
        };
        _context.Users.Add(u);
        _context.SaveChanges();

        return u;
    }

    public Data.User GetUser(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        return user;
    }

    public List<User> GetUsers()
    {
        var users = new List<User>();
        var usersData = _context.Users.ToList();
        foreach (var user in usersData)
        {
            users.Add(user);
        }

        return users;
    }
}

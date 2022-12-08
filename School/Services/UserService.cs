using Microsoft.AspNetCore.Components.Forms;
using School.Dtos;
using School.Repositories;

namespace School.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public Data.User? CreateUser(CreateOrUpdateUser user)
    {
        if(string.IsNullOrWhiteSpace(user.Name))
            return null;

        var us = _repository.AddUser(user);

        if (us is null)
            return null;

        return us;
    }

    public Data.User? GetUser(int id)
    {
        var user = _repository.GetUser(id);

        if (user is null)
            return null;

        return user;
    }

    public List<Data.User> GetUsers()
    {
        var users = _repository.GetUsers();

        if (users is null)
            return null;
        
        return users;
    }
}

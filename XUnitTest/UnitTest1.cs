using Moq;
using School.Repositories;
using School.Services;

namespace XUnitTest;

public class UnitTest1
{
    [Fact]
    public void AddUser()
    {
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(c => c.AddUser(new School.Dtos.CreateOrUpdateUser()
        {
            Name = "dsds"
        }));
        var repo = mockRepo.Object;

        var userService = new UserService(repo);
        var user = userService.CreateUser(new School.Dtos.CreateOrUpdateUser()
        {
            Name = "dsds"
        });

        //mockRepo.VerifySet(c => c.AddUser(new School.Dtos.CreateOrUpdateUser()));

        Assert.Null(user);
    }

    [Fact]
    public void GetUser()
    {
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(c => c.GetUser(2))
            .Returns(new School.Data.User()
            {
                Id = 2,
                Name = "BIronkim"
            });
        var repo = mockRepo.Object;

        var userService = new UserService(repo);
        var user = userService.GetUser(2);

        Assert.NotNull(user);
    }

    [Fact]
    public void GetAllUsers()
    {
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(c => c.GetUsers())
            .Returns(new List<School.Data.User>());
        var repo = mockRepo.Object;

        var userService = new UserService(repo);
        var users = userService.GetUsers();

        Assert.NotNull(users);
    }
}
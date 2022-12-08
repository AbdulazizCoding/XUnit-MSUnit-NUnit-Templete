using Moq;
using School.Repositories;
using School.Services;

namespace MSUnit;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void AddUser()
    {
        var mockUserRepo = new Mock<IUserRepository>().Object;
        var userService = new UserService(mockUserRepo);

        var user = userService.CreateUser(new School.Dtos.CreateOrUpdateUser());

        Assert.IsNotNull(user);
    }

    [TestMethod]
    public void GetUserById()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        mockUserRepo.Setup(c => c.GetUser(1))
            .Returns(new School.Data.User());

        var repo = mockUserRepo.Object;
        var userService = new UserService(repo);

        var user = userService.GetUser(1);

        Assert.IsNotNull(user);
    }

    [TestMethod]
    public void GetAllUsers()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        mockUserRepo.Setup(c => c.GetUsers())
            .Returns(new List<School.Data.User>());

        var repo = mockUserRepo.Object;
        var userService = new UserService(repo);

        var users = userService.GetUsers();

        Assert.IsNotNull(users);
    }
}
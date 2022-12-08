using Moq;
using School.Repositories;
using School.Services;

namespace NUnitTestPrj;

public class Tests
{
    private Mock<IUserRepository> _moqRepo;
    private IUserRepository _userRepository;
    private UserService _userService;

    [SetUp]
    public void Setup()
    {
        _userRepository = new Mock<IUserRepository>().Object;
        _userService = new UserService(_userRepository);
        _moqRepo = new Mock<IUserRepository>();
    }

    [Test]
    public void AddUser()
    {
        var user = _userService.CreateUser(new School.Dtos.CreateOrUpdateUser());

        Assert.Null(user);
    }

    [Test]
    public void GetUserById()
    {
        _moqRepo.Setup(s => s.GetUser(2))
            .Returns(new School.Data.User()
            {
                Id = 2,
                Name = "NImadur"
            });
        var user = _userService.GetUser(2);

        Assert.IsNotNull(user);
    }

    [Test]
    public void GetAllUsers()
    {
        _moqRepo.Setup(s => s.GetUsers())
            .Returns(new List<School.Data.User>());

        var users = _userService.GetUsers();

        Assert.IsNotNull(users);
    }
}
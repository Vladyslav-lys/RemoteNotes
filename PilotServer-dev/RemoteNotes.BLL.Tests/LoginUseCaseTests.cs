namespace RemoteNotes.BLL.Tests
{
    public class LoginUseCaseTests
    {
        //private Mock<UserRepository> mock;

        //private IUseCase<EnterRequestEvent, EnterResponseEvent> SetupMock()
        //{
        //    //Arrange
        //    mock = new Mock<UserRepository>();

        //    mock.Setup(x => x.Users).Returns(new User[]
        //    {
        //        new User { Id = 1, Login = "login", Password = "pass", Account = null },
        //        new User { Id = 2, Login = "login2", Password = "pass2", Account = null },
        //        new User { Id = 3, Login = "login3", Password = "pass3", Account = null }
        //    });

        //    IValidationActivity<EnterRequestEvent> validationActivity = new LoginValidationActivity(new EnterOperationValidationRule());
        //    IGetUserByRequest request = new GetUserByRequest(mock.Object);

        //    IUseCase<EnterRequestEvent, EnterResponseEvent> loginUseCase = new LoginUseCase(validationActivity, request);
        //    return loginUseCase;
        //}

        //[Theory]
        //[InlineData("login", "pass")]
        //[InlineData("login2", "pass2")]
        //[InlineData("login3", "pass3")]
        //public void LoginUseCaseTestWithCorrectData(string login, string password)
        //{
        //    var loginUseCase = SetupMock();

        //    EnterResponseEvent response = null;

        //    //Act
        //    try
        //    {
        //        response = loginUseCase.Execute(new EnterRequestEvent(login, password));
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    //Assert
        //    Assert.Equal(mock.Object.Users.First((data) => data.Login == login && data.Password == password), response.user);
        //}

        //[Theory]
        //[InlineData("login", "olikujyhgtrfcd")]
        //[InlineData("ftryuhijmkolp", "pass")]
        //[InlineData("logploikujyhtg", "pol9ikyujtyht")]
        //public void LoginUseCaseTestWithIncorrectData(string login, string password)
        //{
        //    var loginUseCase = SetupMock();

        //    Assert.Throws<MissingMemberException>(() => loginUseCase.Execute(new EnterRequestEvent(login, password)));
        //}

        //[Theory]
        //[InlineData("login", "__!@#%^*&^%$#@,.,")]
        //[InlineData("!@#()<>><<><()!@#*^*!", "pass")]
        //[InlineData("!@##$%^&*(_)_+><!@#<", ")(!@#%&<<><}!@#")]
        //[InlineData("", "")]
        //[InlineData("", "!@#!@#")]
        //[InlineData("!@#!@#", "")]
        //public void LoginUseCaseTestWithInvalidData(string login, string password)
        //{
        //    var loginUseCase = SetupMock();

        //    Assert.Throws<SystemEnterValidationException>(() => loginUseCase.Execute(new EnterRequestEvent(login, password)));
        //}
    }
}
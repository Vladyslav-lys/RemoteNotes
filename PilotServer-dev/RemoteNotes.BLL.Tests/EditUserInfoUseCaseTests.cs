namespace RemoteNotes.BLL.Tests
{
    public class EditUserInfoUseCaseTests
    {
        //private Mock<IUserRepository> mock;
        //private static Account[] correctAccounts = new Account[]
        //{
        //        new Account { Id = 1, Birthday = new DateTime(1998, 8, 5), CreateTime = new DateTime(2019, 8, 12), ModifyTime = new DateTime(2019, 8, 12),
        //            Email = "email1@ffeks.dp.ua", FirstName = "FirstName1" , LastName = "LastName1", IsActive = true,  Nickname = "Nick1", Photo = null },
        //        new Account { Id = 2, Birthday = new DateTime(1998, 12, 14), CreateTime = new DateTime(2016, 7, 14), ModifyTime = new DateTime(2016, 7, 31),
        //            Email = "email2@ffeks.dp.ua", FirstName = "FirstName2" , LastName = "LastName2", IsActive = true,  Nickname = "Nick2", Photo = null },
        //        new Account { Id = 3, Birthday = new DateTime(1961, 8, 24), CreateTime = new DateTime(2001, 1, 1), ModifyTime = new DateTime(2009, 2, 14),
        //            Email = "email3@ffeks.dp.ua", FirstName = "FirstName3" , LastName = "LastName3", IsActive = true,  Nickname = "Nick3", Photo = null }
        //};
        //private static User[] correctUsers = new User[]
        //    {
        //        new User { Id = 1, Login = "login", Password = "pass", Account = correctAccounts[0] },
        //        new User { Id = 2, Login = "login2", Password = "pass2", Account = correctAccounts[1] },
        //        new User { Id = 3, Login = "login3", Password = "pass3", Account = correctAccounts[2] }
        //    };

        //private static Account[] incorrectAccounts = new Account[]
        //{
        //        new Account { Id = 1, Birthday = new DateTime(1998, 8, 5), CreateTime = new DateTime(2019, 8, 12), ModifyTime = new DateTime(2019, 8, 12),
        //            Email = "email1@gmail.com", FirstName = "FirstName1" , LastName = "LastName1", IsActive = true,  Nickname = "Nick1", Photo = null },
        //        new Account { Id = 2, Birthday = new DateTime(1998, 12, 14), CreateTime = new DateTime(2016, 7, 14), ModifyTime = new DateTime(2016, 7, 31),
        //            Email = "email2@ffeks.dp.ru", FirstName = "FirstName2" , LastName = "LastName2", IsActive = true,  Nickname = "Nick2", Photo = null },
        //        new Account { Id = 3, Birthday = new DateTime(1961, 8, 24), CreateTime = new DateTime(2001, 1, 1), ModifyTime = new DateTime(2009, 2, 14),
        //            Email = "email3@ffekss.kbp.ua", FirstName = "FirstName3" , LastName = "LastName3", IsActive = true,  Nickname = "Nick3", Photo = null }
        //};
        //private static User[] incorrectUsers = new User[]
        //{
        //        new User { Id = 1, Login = "login", Password = "pass", Account = incorrectAccounts[0] },
        //        new User { Id = 2, Login = "login2", Password = "pass2", Account = incorrectAccounts[1] },
        //        new User { Id = 3, Login = "login3", Password = "pass3", Account = incorrectAccounts[2] }
        //};

        //public static IEnumerable<object[]> CorrectData => new List<object[]>
        //{
        //    new object[] { correctUsers[0] },
        //    new object[] { correctUsers[1] },
        //    new object[] { correctUsers[2] }
        //};
        //public static IEnumerable<object[]> IncorrectData => new List<object[]>
        //{
        //    new object[] { incorrectUsers[0] },
        //    new object[] { incorrectUsers[1] },
        //    new object[] { incorrectUsers[2] }
        //};
        //public static IEnumerable<object[]> NullData => new List<object[]>
        //{
        //    new object[] { null },
        //    new object[] { null }
        //};

        //[Theory]
        //[MemberData(nameof(CorrectData))]
        //public void EditUserInfoTestWithCorrectData(User user)
        //{
        //    mock = new Mock<IUserRepository>();

        //    mock.Setup(x => x.Users).Returns(correctUsers);
        //    mock.Setup(x => x.Update(It.IsAny<User>()));

        //    IValidationActivity<EditUserRequestEvent> validationActivity = new EditUserValidationActivity(new UpdateUserOperationValidationRule());
        //    IEditUserByRequest editRequest = new EditUserByRequest(mock.Object);

        //    IUseCase<EditUserRequestEvent, EditUserResponseEvent> updateUseCase = new EditUserUseCase(validationActivity, editRequest);

        //    EditUserResponseEvent response = null;

        //    //Act
        //    try
        //    {
        //        response = updateUseCase.Execute(new EditUserRequestEvent(user));
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    //Assert
        //    Assert.Equal(mock.Object.Users.First((data) => data.Id == user.Id), response.User);
        //}

        //[Theory]
        //[MemberData(nameof(IncorrectData))]
        //public void EditUserInfoTestWithIncorrectData(User user)
        //{
        //    mock = new Mock<IUserRepository>();

        //    mock.Setup(x => x.Users).Returns(incorrectUsers);
        //    mock.Setup(x => x.Update(It.IsAny<User>()));

        //    IValidationActivity<EditUserRequestEvent> validationActivity = new EditUserValidationActivity(new UpdateUserOperationValidationRule());
        //    IEditUserByRequest editRequest = new EditUserByRequest(mock.Object);

        //    IUseCase<EditUserRequestEvent, EditUserResponseEvent> updateUseCase = new EditUserUseCase(validationActivity, editRequest);

        //    Assert.Throws<SystemEditUserValidationException>(() => updateUseCase.Execute(new EditUserRequestEvent(user)));
        //}

        //[Theory]
        //[MemberData(nameof(NullData))]
        //public void EditUserInfoTestWithNullData(User user)
        //{
        //    mock = new Mock<IUserRepository>();

        //    mock.Setup(x => x.Users).Returns(incorrectUsers);
        //    mock.Setup(x => x.Update(It.IsAny<User>()));

        //    IValidationActivity<EditUserRequestEvent> validationActivity = new EditUserValidationActivity(new UpdateUserOperationValidationRule());
        //    IEditUserByRequest editRequest = new EditUserByRequest(mock.Object);

        //    IUseCase<EditUserRequestEvent, EditUserResponseEvent> updateUseCase = new EditUserUseCase(validationActivity, editRequest);

        //    Assert.Throws<NullReferenceException>(() => updateUseCase.Execute(new EditUserRequestEvent(user)));
        //}
    }
}
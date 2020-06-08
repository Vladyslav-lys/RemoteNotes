namespace RemoteNotes.BLL.Tests
{
    public class GetNotesUseCaseTests
    {
        //private Mock<NoteRepository> mock;

        //private IUseCase<GetNotesRequestEvent, GetNotesResponseEvent> SetupMock()
        //{
        //    //Arrange
        //    mock = new Mock<NoteRepository>();

        //    mock.Setup(x => x.Notes).Returns(new Note[]
        //    {
        //        new Note { Id = 1, Title = "Title1Test", Account = new Account
        //        {
        //            Id = 1, FirstName = "TestName", LastName = "TestSurname"
        //        }, Image = null, PublishTime = DateTime.Now, ModifyTime = DateTime.Now, Text = "Some text for some note"},

        //        new Note { Id = 2, Title = "Title2Test", Account = new Account
        //        {
        //            Id = 2, FirstName = "TestName2", LastName = "TestSurname2"
        //        }, Image = null, PublishTime = DateTime.Now, ModifyTime = DateTime.Now, Text = "Some text for some note222222"},

        //        new Note { Id = 3, Title = "Title3Test", Account = new Account
        //        {
        //            Id = 3, FirstName = "TestName3", LastName = "TestSurname3"
        //        }, Image = null, PublishTime = DateTime.Now, ModifyTime = DateTime.Now, Text = "Some text for some note33333"}
        //    });

        //    IGetNotesByRequest request = new GetNotesByAccountId(mock.Object);

        //    IUseCase<GetNotesRequestEvent, GetNotesResponseEvent> getNotesUseCase = new GetNotesUseCase(request);
        //    return getNotesUseCase;
        //}

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        //public void GetNotesUseCaseTestWithExistingAccountId(int accountId)
        //{
        //    var getNotesUseCase = SetupMock();

        //    GetNotesResponseEvent response = null;

        //    //Act
        //    try
        //    {
        //        response = getNotesUseCase.Execute(new GetNotesRequestEvent(accountId));
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    //Assert
        //    Assert.Equal(mock.Object.Notes.Where((data)=> data.Id == accountId), response.Notes);
        //}

        //[Theory]
        //[InlineData(823123)]
        //[InlineData(912555)]
        //[InlineData(4256123)]
        //public void GetNotesUseCaseTestWithoutExistingAccountId(int accountId)
        //{
        //    var getNotesUseCase = SetupMock();

        //    Assert.Throws<ArgumentException>(() => getNotesUseCase.Execute(new GetNotesRequestEvent(accountId)));
        //}
    }
}
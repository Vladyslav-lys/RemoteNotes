namespace RemoteNotes.BLL.Tests
{
    public class EditNoteUseCaseTests
    {
        //private Mock<INoteRepository> mock;

        //private IUseCase<EditNoteRequestEvent, EditNoteResponseEvent> SetupMock()
        //{
        //    //Arrange
        //    mock = new Mock<INoteRepository>();

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
        //    mock.Setup(x => x.Update(It.IsAny<Note>())).Callback((Note note) =>
        //    {
        //        Note oldNote = mock.Object.Notes.First((data) => data.Id == note.Id);

        //        oldNote.Title = note.Title;
        //        oldNote.Text = note.Text;
        //        oldNote.ModifyTime = note.ModifyTime;
        //    });
        //    mock.Setup(x => x.GetById(It.IsAny<int>())).Returns<int>((item) =>
        //    {
        //        return mock.Object.Notes.First((data) => data.Id == item);
        //    });

        //    IValidationActivity<EditNoteRequestEvent> validationActivity = new EditNoteValidationActivity(new EditNoteOperationValidationRule());
        //    IEditNoteByRequest request = new EditNoteByRequest(mock.Object);

        //    IUseCase<EditNoteRequestEvent, EditNoteResponseEvent> editNoteUseCase = new EditNoteUseCase(validationActivity, request);
        //    return editNoteUseCase;
        //}

        //[Theory]
        //[InlineData(1, "NewTitle", "NewText")]
        //[InlineData(2, "NewTitle2", "NewText2")]
        //[InlineData(3, "NewTitle3", "NewText3")]
        //public void EditNoteTestWithCorrectData(int NoteId, string NoteTitle, string NoteText)
        //{
        //    var editNoteUseCase = SetupMock();

        //    EditNoteResponseEvent response = null;

        //    //Act
        //    try
        //    {
        //        response = editNoteUseCase.Execute(new EditNoteRequestEvent(NoteId, NoteTitle, NoteText));
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    //Assert
        //    Assert.Equal(mock.Object.Notes.First((data) => data.Id == NoteId), response.Note);
        //}

        //[Theory]
        //[InlineData(1, "", "")]
        //[InlineData(2, "", "NewText2")]
        //[InlineData(3, "NewTitle3", "")]
        //public void EditNoteTestWithNullData(int NoteId, string NoteTitle, string NoteText)
        //{
        //    var editNoteUseCase = SetupMock();

        //    //Assert
        //    Assert.Throws<SystemEditNoteValidationException>(() => editNoteUseCase.Execute(new EditNoteRequestEvent(NoteId, NoteTitle, NoteText)));
        //}

        //[Theory]
        //[InlineData(123123, "asd", "asd")]
        //[InlineData(2125125, "asdyukj", "NewText2")]
        //[InlineData(3111111, "NewTitle3", "jksfek")]
        //public void EditNoteTestWithIncorrectId(int NoteId, string NoteTitle, string NoteText)
        //{
        //    var editNoteUseCase = SetupMock();

        //    //Assert
        //    Assert.Throws<OperationCanceledException>(() => editNoteUseCase.Execute(new EditNoteRequestEvent(NoteId, NoteTitle, NoteText)));
        //}
    }
}
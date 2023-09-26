using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.DeleteBook;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(1,1,"abc")]
        [InlineData(0,1,"abcaa")]
        [InlineData(1,-1,"abcdef")]
        [InlineData(0,0,"abc")]
        [InlineData(-1,-1,"abcdefg")]
        [InlineData(1,1," ")]
        [InlineData(1,1,"")]
        public void WhenInvalidUpdatesAreGiven_Validator_ShouldBeReturnErrors(int bookid, int genreid, string title)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel()
            {
                Title =title,
                GenreId = genreid                
            };
            command.BookId=bookid;

            UpdateBookCommandValidator validations=new UpdateBookCommandValidator();
            var result = validations.Validate(command);

             result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenUpdateDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel()
            {
                Title = "Lord of The Rings",
                PageCount = 100, 
                PublishDate = DateTime.Now.Date,
                GenreId = 1,
                AuthorId = 2
            };

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidUpdateIsGiven_Validator_ShouldNotBeReturnErrors()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.BookId = 1;
            command.Model = new UpdateBookModel()
            {
                Title ="title",
                GenreId = 2                
            };

            UpdateBookCommandValidator validations=new UpdateBookCommandValidator();
            var result = validations.Validate(command);

             result.Errors.Count.Should().Equals(0);
        }
    }
}
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [InlineData(" ")]
        [InlineData("ab")]
        [InlineData("ab ")]
        [InlineData(" a ")]
        [InlineData("abc")]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string genreName)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model=new UpdateGenreModel(){Name=genreName};

            UpdateGenreCommandValidator validations= new UpdateGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldNotBeReturnErrors()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model=new UpdateGenreModel(){ Name= "genreName"};

            UpdateGenreCommandValidator validations= new UpdateGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
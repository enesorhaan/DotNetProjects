using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData("a b")]
        [InlineData("a")]
        [InlineData("ab")]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors(string name)
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model= new CreateGenreModel(){Name=name};

            CreateGenreCommandValidator validations = new CreateGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturn()
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model= new CreateGenreModel(){ Name= "action"};

            CreateGenreCommandValidator validations = new CreateGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
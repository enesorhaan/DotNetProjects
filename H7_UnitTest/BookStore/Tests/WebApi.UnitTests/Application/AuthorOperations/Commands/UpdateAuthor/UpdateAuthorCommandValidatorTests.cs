using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [InlineData("","")]
        [InlineData(" "," ")]
        [InlineData("name"," ")]
        [InlineData(" ","name")]
        [InlineData("nam","na ")]
        [InlineData(" name","nam")]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
            command.Model= new UpdateAuthorViewModel(){ FirstName = name, LastName = surname };

            UpdateAuthorCommandValidator validations = new UpdateAuthorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldNotBeReturnErrors()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
            command.Model= new UpdateAuthorViewModel(){ FirstName = "Enes", LastName = "Orhan"};
 
            UpdateAuthorCommandValidator validations = new UpdateAuthorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
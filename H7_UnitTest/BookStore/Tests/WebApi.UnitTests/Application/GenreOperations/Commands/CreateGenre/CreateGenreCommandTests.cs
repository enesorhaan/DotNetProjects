using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Entities;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dBcontext;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _dBcontext = testFixture.Context;
        }


        [Fact]
        public void WhenAlreadyExistGenreTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var genre = new Genre(){Name="WhenAlreadyExistGenreTitleIsGiven_InvalidOperationException_ShouldBeReturn"};
            _dBcontext.Genres.Add(genre);
            _dBcontext.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_dBcontext);
            command.Model=new CreateGenreModel(){Name = genre.Name};

             FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book Genre already exist..");

        }

        [Fact]
        public void WhenValidInputIsGiven_Genre_ShouldBeCreated()
        {
            CreateGenreCommand command = new CreateGenreCommand(_dBcontext);
            command.Model=new CreateGenreModel(){Name="WhenValidInputIsGiven_Genre_ShouldBeCreated"};
            
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var genre = _dBcontext.Genres.SingleOrDefault(genre => genre.Name == command.Model.Name);
            genre.Should().NotBeNull();//genre null olmamalı 
        }
    }
}
using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Entities;
using Xunit;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void WhenAlreadyExistAuthorNameSurnameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var author = new Author()
            {
                FirstName = "Enes",
                LastName = "Orhan",
                BirthDay = new DateTime(1999,09,22)
            };
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(_dbContext,_mapper);
            command.Model = new CreateAuthorViewModel()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author already exists..");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_dbContext,_mapper);
            command.Model=new CreateAuthorViewModel()
            {
                FirstName = "Enes",
                LastName = "Orhan"
            };

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var author = _dbContext.Authors.SingleOrDefault(author=>author.FirstName == command.Model.FirstName && author.LastName == command.Model.LastName);
            author.Should().NotBeNull();
        }

    }
}
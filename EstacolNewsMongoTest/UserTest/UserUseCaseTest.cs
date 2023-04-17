using EstacolNews.Domain.NoSql.Entities;
using EstacolNews.UseCases.NoSql.Gateway.Repositories.Commands;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNewsMongoTest.UserTest
{
    public class UserUseCaseTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        public UserUseCaseTest()
        {
            _mockUserRepository = new();
        }



        [Fact]
        public async Task InsertUser() {

            //Arrange
            var user = new User
            {

                id_fire = "Test",
                user = "test",
                password ="test"

            };

            _mockUserRepository.Setup(x => x.InsertUserAsync(user).Result).Returns(user);

            //Act
            var result = await _mockUserRepository.Object.InsertUserAsync(user);

            //Assert
            Assert.NotNull(result);
           





        }


        [Fact]
        public async Task GetByIdUser()
        {

            //Arrange
            var user = new User
            {

                id_fire = "Test",
                user = "test",
                password = "test"

            };

            _mockUserRepository.Setup(x => x.GetUserByIdAsync(user.id_fire).Result).Returns(user);

            //Act
            var result = await _mockUserRepository.Object.GetUserByIdAsync(user.id_fire);

            //Assert
            Assert.NotNull(result);






        }

    }
}

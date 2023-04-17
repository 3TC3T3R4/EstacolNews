using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.ContentCommands;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNewsSql.ContentTest
{
    public class ContentRepositoryTest
    {
        private readonly Mock<IContentRepository> _mockContentRepository;
        public ContentRepositoryTest()
        {
            _mockContentRepository = new();
        }


        [Fact]
        public async Task GetContentsAsync()
        {
            //Arrange
            var content = new Content
            {
               title = "Test",
               estate_process = "Test",
               estate = true,
               keywords = "Test",
               type_publication = "Test",
               url = "Test",
               finish_date = DateTime.Now,
               publication_date = DateTime.Now,
               program_date = DateTime.Now,
               number_of_collaborators = 1,
               likes = 1,
               dislikes = 0,
               description = "Test"

            };
            var contentList = new List<Content> { content };
            _mockContentRepository.Setup(x => x.GetAllContentsAsync()).ReturnsAsync(contentList);

            //Act
            var result = await _mockContentRepository.Object.GetAllContentsAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(contentList, result);

        }


        [Fact]
        public async Task CreateContentAsync()
        {
            //arrange
            var content = new Content
            {
                title = "Test",
                estate_process = "Test",
                estate = true,
                keywords = "Test",
                type_publication = "Test",
                url = "Test",
                finish_date = DateTime.Now,
                publication_date = DateTime.Now,
                program_date = DateTime.Now,
                number_of_collaborators = 1,
                likes = 1,
                dislikes = 0,
                description = "Test"

            };

            _mockContentRepository.Setup(x => x.InsertContentAsync(content)).ReturnsAsync(content);
            //act
            var result = await _mockContentRepository.Object.InsertContentAsync(content);
            //assert
            Assert.Equal(content, result);
        }



        [Fact]
        public async Task GetContentByIdAsync()
        {
            //Arrange
            var content = new Content
            {
                title = "Test",
                estate_process = "Test",
                estate = true,
                keywords = "Test",
                type_publication = "Test",
                url = "Test",
                finish_date = DateTime.Now,
                publication_date = DateTime.Now,
                program_date = DateTime.Now,
                number_of_collaborators = 1,
                likes = 1,
                dislikes = 0,
                description = "Test"

            };
            //var editorsList = new List<Editor> { editor };
            _mockContentRepository.Setup(x => x.GetContentByIdAsync(1)).ReturnsAsync(content);

            //Act
            var result = await _mockContentRepository.Object.GetContentByIdAsync(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(content, result);
        }



        [Fact]
        public async Task UpdateContentByIdAsync()
        {
            //arrange
            var content = new InsertNewContent
            {
                title = "Test",
                keywords = "Test",
                finish_date = DateTime.Now,
                publication_date = DateTime.Now,
                program_date = DateTime.Now,
                description = "Test"
              
            };

            _mockContentRepository.Setup(x => x.UpdateContentByIdAsync(1,content)).ReturnsAsync(content);
            //act
            var result = await _mockContentRepository.Object.UpdateContentByIdAsync(1, content);
            //assert
            Assert.Equal(content, result);
        }

        [Fact]
        public async Task DeleteContentAsync()
        {
            //arrange
            string expected = "DeleteSuccess";

            _mockContentRepository.Setup(x => x.DeleteContentByIdAsync(1)).ReturnsAsync("DeleteSuccess");
            //act
            var result = await _mockContentRepository.Object.DeleteContentByIdAsync(1);
            //assert
            Assert.Equal(expected,result);
        }

        [Fact]

        public async Task LikeContentByIdAsync()

        {
            //arrange
            string expected = "LikeSuccess";

            _mockContentRepository.Setup(x => x.LikeContentByIdAsync(1)).ReturnsAsync("LikeSuccess");
            //act
            var result = await _mockContentRepository.Object.LikeContentByIdAsync(1);
            //assert
            Assert.Equal(expected, result);
        }

      




    }
}

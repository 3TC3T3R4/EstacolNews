using Castle.Core.Resource;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNewsSql.EditorTest
{
    public class EditorRepositoryTest
    {
        private readonly Mock<IEditorRepository> _mockEditorRepository;
        public EditorRepositoryTest()
        {
            _mockEditorRepository = new();
        }


        //[Fact]
        //public async Task GetEditorsAsync()
        //{
        //    //Arrange
        //    var editor = new Editor
        //    {
        //        id_user = "MongoDb",
        //        complete_name = "Test",
        //        phone = "21354",
        //        estate = true

        //    };
        //    var editorsList = new List<Editor> { editor };
        //_mockEditorRepository.Setup(x => x.GetAllEditorsAsync()).ReturnsAsync(editorsList);

        //    //Act
        //    var result = await _mockEditorRepository.Object.GetAllEditorsAsync();

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(editorsList, result);

        //}


        //[Fact]
        //public async Task CreateEditorAsync()
        //{
        //    //arrange
        //    var newEditor = new Editor
        //    {
        //        id_user = "MongoDb",
        //        complete_name = "Test",
        //        phone = "21354",
        //        estate = true

        //    };
        //    //var editorCreated = new InsertNewEditor
        //    //{
        //    //    id_user = "MongoDb",
        //    //    complete_name = "Test",
        //    //    phone = "21354",
        //    //    estate = true

        //    //};
        //    _mockEditorRepository.Setup(x => x.InsertEditorAsync(newEditor)).ReturnsAsync(newEditor);
        //    //act
        //    var result = await _mockEditorRepository.Object.InsertEditorAsync(newEditor);
        //    //assert
        //    Assert.Equal(newEditor, result);
        //}



        //[Fact]
        //public async Task GetEditorByIdAsync()
        //{
        //    //Arrange
        //    var editor = new Editor
        //    {
        //        id_user = "MongoDb",
        //        complete_name = "Test",
        //        phone = "21354",
        //        estate = true

        //    };
        //    //var editorsList = new List<Editor> { editor };
        //    _mockEditorRepository.Setup(x => x.GetEditorByIdAsync(1)).ReturnsAsync(editor);

        //    //Act
        //    var result = await _mockEditorRepository.Object.GetEditorByIdAsync(1);

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(editor, result);
        //}






    }
}

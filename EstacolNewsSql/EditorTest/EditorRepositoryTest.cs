using Castle.Core.Resource;
using DriverAdapterSQL.Repositories;
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


        [Fact]
        public async Task GetEditorsAsync()
        {
            //Arrange
            var editor = new Editor
            {
                id_editor = "Firebase",
                complete_name = "Test",
                estate = true
            };
            var editorsList = new List<Editor> { editor };
            _mockEditorRepository.Setup(x => x.GetAllEditorsAsync()).ReturnsAsync(editorsList);

            //Act
            var result = await _mockEditorRepository.Object.GetAllEditorsAsync();

           
            Assert.NotNull(result);
            Assert.Equal(editorsList, result);

        }


        [Fact]
        public async Task CreateEditorAsync()
        {
            //arrange
            var newEditor = new Editor
            {
                id_editor = "firebase",
                complete_name = "Test",
                estate = true

            };
            var editorCreated = new InsertNewEditor
            {
                id_editor = "MongoDb",
                complete_name = "Test",
                estate = true

            };
            _mockEditorRepository.Setup(x => x.InsertEditorAsync(newEditor)).ReturnsAsync(newEditor);
            //act
            var result = await _mockEditorRepository.Object.InsertEditorAsync(newEditor);
            //assert
            Assert.Equal(newEditor, result);
        }



        [Fact]
        public async Task GetEditorByIdAsync()
        {
            //Arrange
            var editor = new InsertNewEditor
            {
                id_editor = "Firebase",
                complete_name = "Test",
                estate = true

            };
            var id = editor.id_editor;
            _mockEditorRepository.Setup(x => x.GetEditorByIdAsync(id)).ReturnsAsync(editor);

            //    //Act
            var result = await _mockEditorRepository.Object.GetEditorByIdAsync(id);

            //    //Assert
            Assert.NotNull(result);
            Assert.Equal(editor, result);


        }

        }

    }


using EstacolNews.Domain.Sql.Entities;
using EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Content;
using EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Publication;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Editor;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Publication;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands;
using Moq;


namespace EstacolNewsSql.PublicationTest
{
   public class PublicationRepositoryTest
    {
        private readonly Mock<IPublicationRepository> _mockPublicationRepository;
        public PublicationRepositoryTest()
        {
            _mockPublicationRepository = new();
        }


        //[Fact]
        //public async Task CreatePublicationAsync()
        //{
        //    //arrange
        //    var newPublication = new Publication
        //    {
        //        id_editor_publication = 1,
        //        id_content_publication = 1,
        //        estate = true

        //    };

        //    _mockPublicationRepository.Setup(x => x.InsertPublicationAsync(newPublication)).ReturnsAsync(newPublication);
        //    //act
        //    var result = await _mockPublicationRepository.Object.InsertPublicationAsync(newPublication);
        //    //assert
        //    Assert.Equal(newPublication, result);
        //}

       

        [Fact]
        public async Task GetPublicationsAsync()
        {
            //Arrange
            var newPublication = new PublicationByEditor
            {
                completeName = "Estevan",
                Publications = new List<PublicationsWithContents>{
                    
                    new PublicationsWithContents
                    {
                         id_publication = 1,
                         Content = new List<Content>{ 
                                
                             new Content{

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

                             }

                         }

                    }

                }

            };


            _mockPublicationRepository.Setup(a => a.GetAllPublicationByEditorAsync(1)).ReturnsAsync(newPublication);

            // Act
            var result = await _mockPublicationRepository.Object.GetAllPublicationByEditorAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newPublication, result);






        }



        //[Fact]
        //public async Task GetPublicationsContentAsync()
        //{
        //    //Arrange
        //    var newPublication = new PublicationByContent

        //    {
        //        title = "Estevan",
        //        Publications = new List<PublicationWithEditors>{

        //            new PublicationWithEditors
        //            {
        //                 id_publication = 1,
        //                 Editor = new List<Editor>{

        //                     new Editor{
        //                         id_user = "Mongo",
        //                         complete_name = "Estevan",
        //                         phone ="213654",
        //                         estate = true
                              

        //                     }

        //                 }

        //            }

        //        }

        //    };


        //    _mockPublicationRepository.Setup(a => a.GetAllPublicationByContentAsync(1)).ReturnsAsync(newPublication);

        //    // Act
        //    var result = await _mockPublicationRepository.Object.GetAllPublicationByContentAsync(1);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(newPublication, result);


        //}


    }
}

using System;
using Xunit;
using DataService.DomainModel;
using DataService.DTO;
using DataService;
using DataService.DataAccessLayer;
using System.Linq;
namespace UnitTests
{
    public class DataAccessLayerTests
    {
        [Fact]
        
        public void CountPosts_ReturnsPostsNumbers()
        {
            var db = new RepositoryBody();
            int postCount = db.CountPosts();
            Assert.Equal(13629, postCount);
        }
        
        [Fact]

        public void PostType_GetPostTypeByPostId()
        {
            var db = new RepositoryBody();
            var PostType = db.GetPostTypeByPostId(19);
            Assert.Equal(1, PostType.Id);
        }

        [Fact]

        public void UserInfo_GetUserByCommentId()
        {
            var db = new RepositoryBody();
            var UserInfo = db.GetUserByCommentId(69759);
            Assert.Equal("Jeff Atwood", UserInfo.DisplayName);
            Assert.Equal("El Cerrito, CA", UserInfo.Location);

        }

        [Fact]

        public void Comments_GetCommentsByPostId()
        {
            var db = new RepositoryBody();
            var Comments = db.GetCommentsByPostId(52002,20,20);
            Assert.Equal(9, Comments.Count());
            Assert.Equal("A man, a plan, a canal, Panama", Comments.First().Body);
            Assert.Equal(15, Comments.First().Score);
        }


        [Fact]

        public void PostTags_GetPostTagsByPostId()
        {
            var db = new RepositoryBody();
            var PostTags = db.GetPostTagsByPostId(26583319);
            var PostTag = db.GetPostTagsByPostId(18332611);
            Assert.Equal(4, PostTags.Count());
            Assert.Equal("android", PostTag.First().Tag.Tag);
            Assert.Equal(1920, PostTag.First().TagId);
        }


        [Fact]

        public void FavoriteTags_GetEachTag()
        {
            var db = new RepositoryBody();
            var tagsCount = db.GetFavoriteTagsByCustomeId(1).Count;
            var firstTag = db.GetFavoriteTagsByCustomeId(1).First().Tag.Tag;
            Assert.Equal(3, tagsCount);
            Assert.Equal("java", firstTag);

        }
        
        [Fact]

        public void QuestionByAnswerId_returnsListOf_Its_Answers()
        {
            var db = new RepositoryBody();
            var parentId = db.GetQuestionByAnswerId(71).Answers.First().ParentId;
            var SameParentId = db.GetQuestionByAnswerId(71).Id;
            Assert.Equal(parentId, SameParentId);


        }

        [Fact]

        public void GetSearchHistories_returns_SearchContent()
        {
            var db = new RepositoryBody();

            var searchHistory = db.GetSearchHistories();

            Assert.Equal("How to create variables in Python?", searchHistory.First().SearchContent);
        }

         
       [Fact]

        public void UserCustomField_GetUserCustomeFieldById()

        {
            var db = new RepositoryBody();
            var Ftag = db.GetUserCustomeFieldById(2);
            Assert.Equal(3, Ftag.FavoriteTags.Count());
        }


        [Fact]

        public void GetAnnotation_GetAnnotations()

        {
            var db = new RepositoryBody();

            var TotalAnnotation = db.GetAnnotations();

            Assert.Equal(0, TotalAnnotation.Count());
            

        }


        [Fact]

        public void GetAnnotation_GetAnnotationById()

        {
            var db = new RepositoryBody();

            var GetAnnotation = db.GetAnnotationById(86513);

            Assert.Equal(0,GetAnnotation.MarkedPostId);


        }


        [Fact]

        public void FavoriteTag_GetFavoriteTagsByCustomeId()

        {
            var db = new RepositoryBody();

            var TotalFavtTags = db.GetFavoriteTagsByCustomeId(2).Count;

            var FavtTag = db.GetFavoriteTagsByCustomeId(1);

            Assert.Equal(3, TotalFavtTags);

            Assert.Equal(2726, FavtTag.First().TagId);

        }

        [Fact]

        public void CountAnnotations_CountAnnotations()

        {
            var db = new RepositoryBody();

            var CountAnnotations = db.CountAnnotations();

           Assert.Equal(0,CountAnnotations);

           

        }

        [Fact]

        public void CustomField_GetUserCustomeFields()
        {
            var db = new RepositoryBody();

            var CountCustomField = db.GetUserCustomeFields().Count;
                        
            Assert.Equal(2, CountCustomField);

           
        }

        
        [Fact]

        public void AnswerbyQuestionid_GetAllAnswersByQuestionId()
        {
            var db = new RepositoryBody();
            var Answers = db.GetAllAnswersByQuestionId(1,20,20).Count;
            Assert.Equal(0, Answers);

   
        }

        [Fact]

        public void DoSearch_MustReturnValidValues()
        {
            var db = new RepositoryBody();
            var foundTitle = db.DoSearch("different between C# and java").First().Title;
            Assert.Equal(foundTitle, "What is the copy-and-swap idiom?");

        }
       

    }
    
    
    }


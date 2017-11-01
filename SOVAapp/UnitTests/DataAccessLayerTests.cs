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
            var db = new Repositorybody();
            int postCount = db.CountPosts();
            Assert.Equal(13629, postCount);
        }
         [Fact]

        public void PostType_GetPostTypeByPostId()
        {
            var db = new Repositorybody();
            var PostType = db.GetPostTypeByPostId(19);
            Assert.Equal(1,PostType.Id);
        }

        [Fact]

        public void UserInfo_GetUserByCommentId()
        {
            var db = new Repositorybody();
            var UserInfo = db.GetUserByCommentId(69759);
            Assert.Equal("Jeff Atwood", UserInfo.OwnerUserDisplayName);
           Assert.Equal("El Cerrito, CA", UserInfo.OwnerUserLocation);
     
        }
        
       [Fact]
        
        public void Comments_GetCommentsByPostId()
        {
            var db = new Repositorybody();
            var Comments = db.GetCommentsByPostId(52002);
            Assert.Equal(9, Comments.Count());
            Assert.Equal("A man, a plan, a canal, Panama", Comments.First().CommentText);
            Assert.Equal(15, Comments.First().CommentScore);
        }

        [Fact]

        public void FavoriteTags_GetEachTag()
        {
            var db = new Repositorybody();
            var tagsCount = db.GetFavoriteTagsByCustomeId(1).Count;
            var firstTag = db.GetFavoriteTagsByCustomeId(1).First().Tag.Tag;
            Assert.Equal(3, tagsCount);
            Assert.Equal("java", firstTag);

        }
        [Fact]

        public void QuestionByAnswerId_returnsListOf_Its_Answers()
        {
            var db = new Repositorybody();
            
            var parentId = db.GetQuestionByAnswerId(71).Answers.First().ParentId;
            var SameParentId = db.GetQuestionByAnswerId(71).Id;

            Assert.Equal(parentId, SameParentId);
         

        }

        [Fact]

        public void GetSearchHistories_returns_SearchContent()
        {
            var db = new Repositorybody();

            var searchHistory = db.GetSearchHistories();
  

            Assert.Equal("How to create variables in Python?", searchHistory.First().SearchContent);


        }
 


    }
}

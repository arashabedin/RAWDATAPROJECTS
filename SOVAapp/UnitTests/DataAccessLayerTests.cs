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

    }
}

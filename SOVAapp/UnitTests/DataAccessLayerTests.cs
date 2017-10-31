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

    }
}

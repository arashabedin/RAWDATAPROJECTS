using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;
using DataService.DTO;
using DataService;
using System.Linq;
namespace DataService.DataAccessLayer
{
    public class Repositorybody : Repository
    {

        //////////////// Posts

       public PostDTO GetPostById(int id)
        {
            using (var db = new SOVAContext())
            {
                var post =  db.Posts.FirstOrDefault(a => a.Id == id);
                return null; /* new PostDTO(post.Id, post.OwneruserId, post.Body, post.Title, post.Score, post.CreationDate, post.ClosedDate
                    , comments, postType, marking, postTags, userInfo); */
            }
        }

        public ICollection<PostDTO> GetPosts()
        {
            throw new NotImplementedException();
        }


        //implemented
        public int CountPosts()
        {
            using (var db = new SOVAContext())
            {
                return db.Posts.Count();
            }
        }

        public PostTypeDTO GetPostTypeByPostId()
        {
            throw new NotImplementedException();
        }


        public bool AddAnnotation()
        {
            throw new NotImplementedException();
        }

       public bool AddFavoriteTags()
        {
            throw new NotImplementedException();
        }

        public bool AddMarking(int postId)
        {
            throw new NotImplementedException();
        }

        public bool AddSearchHistory(string SearchText)
        {
            throw new NotImplementedException();
        }

        public bool AddUserCustomeField()
        {
            throw new NotImplementedException();
        }

        //implemented
        public int CountAnnotations()
        {
            using (var db = new SOVAContext())
            {
                return db.Annotations.Count();
            }
        }

        public int CountAnnotationsById()
        {
            throw new NotImplementedException();
        }

        public int CountAnswers()
        {
            throw new NotImplementedException();
        }

        public int CountAnswersByUserId()
        {
            throw new NotImplementedException();
        }

        //implemented
        public int CountComments()
        {
            using (var db = new SOVAContext())
            {
                return db.Comments.Count();
            }
        }

        //implemented
        public int CountFavoriteTags()
        {
            using (var db = new SOVAContext())
            {
                return db.FavoriteTags.Count();
            }
        }

        //implemented
        public int CountUsers()
        {
            using (var db = new SOVAContext())
            {
                return db.UserInfos.Count();
            }
        }


        //implemented
        public int CountPostTags()
        {
            using (var db = new SOVAContext())
            {
                return db.PostTags.Count();
            }
        }

        public int CountQuestions()
        {
            throw new NotImplementedException();
        }

        public int CountQuestionsByUserId()
        {
            throw new NotImplementedException();
        }

        //implemented
        public int CountTags()
        {
            using (var db = new SOVAContext())
            {
                return db.Tags.Count();
            }
        }
        //implemented
        public int CountUserCustomeFields()
        {
            using (var db = new SOVAContext())
            {
                return db.UserCustomeField.Count();
            }
        }

        public bool DeleteAnnotation(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserCustomeField(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditAnnotation()
        {
            throw new NotImplementedException();
        }

        public ICollection<AnswerDTO> GetAllAnswersByUserId()
        {
            throw new NotImplementedException();
        }

        public ICollection<PostDTO> GetAllPostsByUserId()
        {
            throw new NotImplementedException();
        }

        public ICollection<QuestionDTO> GetAllQuestionsByUserID()
        {
            throw new NotImplementedException();
        }

        public AnnotationsDTO GetAnnotationById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<AnnotationsDTO> GetAnnotations()
        {
            throw new NotImplementedException();
        }

        public AnswerDTO GetAnswerById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<AnswerDTO> GetAnswersByQuestionId()
        {
            throw new NotImplementedException();
        }

        public CommentDTO GetCommentById()
        {
            throw new NotImplementedException();
        }

        public ICollection<CommentDTO> GetComments()
        {
            throw new NotImplementedException();
        }

        public ICollection<CommentDTO> GetCommentsByPostId()
        {
            throw new NotImplementedException();
        }

        public ICollection<FavoriteTagsDTO> GetFavoriteTags()
        {
            throw new NotImplementedException();
        }

        public ICollection<FavoriteTagsDTO> GetFavoriteTagsByCustomeId(int id)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfSearches()
        {
            throw new NotImplementedException();
        }

       

        public ICollection<PostTagsDTO> GetPostTagsByPostId()
        {
            throw new NotImplementedException();
        }

    

        public QuestionDTO GetQuestionByAnswreId()
        {
            throw new NotImplementedException();
        }

        public QuestionDTO GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<QuestionDTO> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public ICollection<SearchHistoryDTO> GetSearchHistories()
        {
            throw new NotImplementedException();
        }

        public SearchHistoryDTO GetSearchHistoryById(int id)
        {
            throw new NotImplementedException();
        }

        public TagsDTO GetTag(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TagsDTO> GetTags()
        {
            throw new NotImplementedException();
        }

        public UserInfoDTO GetUserByPostId()
        {
            throw new NotImplementedException();
        }

        public UserCustomeFieldDTO GetUserCustomeFieldById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserCustomeFieldDTO> GetUserCustomeFields()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFavoriteTags(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveMarking(int id)
        {
            throw new NotImplementedException();
        }
    }
}


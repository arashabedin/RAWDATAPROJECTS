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

        // Posts

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

        bool Repository.AddFavoriteTags()
        {
            throw new NotImplementedException();
        }

        bool Repository.AddMarking(int postId)
        {
            throw new NotImplementedException();
        }

        bool Repository.AddSearchHistory(string SearchText)
        {
            throw new NotImplementedException();
        }

        bool Repository.AddUserCustomeField()
        {
            throw new NotImplementedException();
        }


        int Repository.CountAnnotations()
        {
            throw new NotImplementedException();
        }

        int Repository.CountAnnotationsById()
        {
            throw new NotImplementedException();
        }

        int Repository.CountAnswers()
        {
            throw new NotImplementedException();
        }

        int Repository.CountAnswersByUserId()
        {
            throw new NotImplementedException();
        }

        int Repository.CountComments()
        {
            throw new NotImplementedException();
        }

        int Repository.CountFavoriteTags()
        {
            throw new NotImplementedException();
        }

        int Repository.CountOfUsers()
        {
            throw new NotImplementedException();
        }

   

        int Repository.CountPostTags()
        {
            throw new NotImplementedException();
        }

        int Repository.CountQuestions()
        {
            throw new NotImplementedException();
        }

        int Repository.CountQuestionsByUserId()
        {
            throw new NotImplementedException();
        }

        int Repository.CountTags()
        {
            throw new NotImplementedException();
        }

        int Repository.CountUserCustomeFields()
        {
            throw new NotImplementedException();
        }

        bool Repository.DeleteAnnotation(int id)
        {
            throw new NotImplementedException();
        }

        bool Repository.DeleteUserCustomeField(int id)
        {
            throw new NotImplementedException();
        }

        bool Repository.EditAnnotation()
        {
            throw new NotImplementedException();
        }

        ICollection<AnswerDTO> Repository.GetAllAnswersByUserId()
        {
            throw new NotImplementedException();
        }

        ICollection<PostDTO> Repository.GetAllPostsByUserId()
        {
            throw new NotImplementedException();
        }

        ICollection<QuestionDTO> Repository.GetAllQuestionsByUserID()
        {
            throw new NotImplementedException();
        }

        AnnotationsDTO Repository.GetAnnotationById(int id)
        {
            throw new NotImplementedException();
        }

        ICollection<AnnotationsDTO> Repository.GetAnnotations()
        {
            throw new NotImplementedException();
        }

        AnswerDTO Repository.GetAnswerById(int id)
        {
            throw new NotImplementedException();
        }

        ICollection<AnswerDTO> Repository.GetAnswersByQuestionId()
        {
            throw new NotImplementedException();
        }

        CommentDTO Repository.GetCommentById()
        {
            throw new NotImplementedException();
        }

        ICollection<CommentDTO> Repository.GetComments()
        {
            throw new NotImplementedException();
        }

        ICollection<CommentDTO> Repository.GetCommentsByPostId()
        {
            throw new NotImplementedException();
        }

        ICollection<FavoriteTagsDTO> Repository.GetFavoriteTags()
        {
            throw new NotImplementedException();
        }

        ICollection<FavoriteTagsDTO> Repository.GetFavoriteTagsByCustomeId(int id)
        {
            throw new NotImplementedException();
        }

        int Repository.GetNumberOfSearches()
        {
            throw new NotImplementedException();
        }

       

        ICollection<PostTagsDTO> Repository.GetPostTagsByPostId()
        {
            throw new NotImplementedException();
        }

    

        QuestionDTO Repository.GetQuestionByAnswreId()
        {
            throw new NotImplementedException();
        }

        QuestionDTO Repository.GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }

        ICollection<QuestionDTO> Repository.GetQuestions()
        {
            throw new NotImplementedException();
        }

        ICollection<SearchHistoryDTO> Repository.GetSearchHistories()
        {
            throw new NotImplementedException();
        }

        SearchHistoryDTO Repository.GetSearchHistoryById(int id)
        {
            throw new NotImplementedException();
        }

        TagsDTO Repository.GetTag(int id)
        {
            throw new NotImplementedException();
        }

        ICollection<TagsDTO> Repository.GetTags()
        {
            throw new NotImplementedException();
        }

        UserInfoDTO Repository.GetUserByPostId()
        {
            throw new NotImplementedException();
        }

        UserCustomeFieldDTO Repository.GetUserCustomeFieldById(int id)
        {
            throw new NotImplementedException();
        }

        ICollection<UserCustomeFieldDTO> Repository.GetUserCustomeFields()
        {
            throw new NotImplementedException();
        }

        bool Repository.RemoveFavoriteTags(int id)
        {
            throw new NotImplementedException();
        }

        bool Repository.RemoveMarking(int id)
        {
            throw new NotImplementedException();
        }
    }
}


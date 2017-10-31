using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;
using DataService.DTO;
using DataService;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataService.DataAccessLayer
{
    public class Repositorybody : Repository
    {

        //////////////// Posts

       public PostDTO GetPostById(int id)
        {
            using (var db2 = new SOVAContext())
            {
                var post =  db2.Posts.FirstOrDefault(a => a.Id == id);



                return new PostDTO(post.Id,post.OwnerUserId, post.Body, post.PostTypeId,post.ParentId, post.Title,post.Score,post.CreationDate,post.ClosedDate, GetCommentsByPostId(id), GetPostTypeByPostId(id), GetPostTagsByPostId(id), GetUserByPostId(id)); 
            }
        }

        public ICollection<PostDTO> GetPosts()
        {
            using(var db = new SOVAContext()) {
                var posts = db.Posts.ToList();
                List<PostDTO> postsDTO = new List<PostDTO>();
                foreach(var post in posts)
                {
                    var myPost =  new PostDTO(post.Id, post.OwnerUserId, post.Body, post.PostTypeId, post.ParentId, post.Title, post.Score, post.CreationDate, post.ClosedDate, GetCommentsByPostId(post.Id), GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
                    postsDTO.Add(myPost);
                }
                return postsDTO;

            }
        }


        //implemented
        public int CountPosts()
        {
            using (var db = new SOVAContext())
            {
                return db.Posts.Count();
            }
        }
        //Implemented
        public PostTypeDTO GetPostTypeByPostId(int id)
        {
            using (var db = new SOVAContext())
            {
                var post = db.Posts.FirstOrDefault(i => i.Id == id);
                var postType = db.PostTypes.Where(p => p.Id == post.PostTypeId).FirstOrDefault();
                var postTypeDTO = new PostTypeDTO(postType.Id, postType.Type);
                return postTypeDTO;
            }
        }
        //Comments
        //Implemented 
        public ICollection<CommentDTO> GetCommentsByPostId(int postId)
        {
            using (var db2 = new SOVAContext())
            {
                var Comments = db2.Comments.Include(p=> p.post).Where(p => p.PostId == postId);
                List<CommentDTO> CommentsDTO = new List<CommentDTO>();

                foreach (var item in Comments)
                {
             
var commentDTO = new CommentDTO(item.CommentId, item.PostId, item.CommentText, item.CommentScore, item.CommentCreateDate, item.OwnerUserId, item.post, GetUserByPostId(postId));

                    CommentsDTO.Add(commentDTO);
                }
                return CommentsDTO;
            }
        }

        //implemented
       public UserInfoDTO GetUserByCommentId(int id)
        {
            using (var db = new SOVAContext()) {
                var comment = db.Comments.FirstOrDefault(c => c.CommentId == id);

                var user = db.UserInfo.FirstOrDefault(i => i.OwnerUserId == comment.OwnerUserId);
            return new UserInfoDTO(user.OwnerUserId,user.OwnerUserAge, user.OwnerUserDisplayName,user.CreationDate, user.OwnerUserLocation);
            }

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


        //implemented
        public int CountAnswers()
        {
            using (var db = new SOVAContext()){

                var answers = db.Posts.Where(t => t.PostTypeId == 2);
                return answers.Count();
            }
        }
        //implemented
        public int CountAnswersByUserId(int id)
        {
          using( var db = new SOVAContext())
            {
                var answers = db.Posts.Where(i => i.PostTypeId == 2).ToList();
                return answers.Where(u => u.OwnerUserId == id).Count();

            }
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
                return db.UserInfo.Count();
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
        //implemented
        public int CountQuestions()
        {
            using (var db = new SOVAContext())
            {

                return db.Posts.Where(i => i.PostTypeId == 1).Count();
            }
        }
        //implemented
        public int CountQuestionsByUserId(int id)
        {
            using (var db = new SOVAContext())
            {
                var answers = db.Posts.Where(i => i.PostTypeId == 1).ToList();
                return answers.Where(u => u.OwnerUserId == id).Count();

            }
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
        //implemented
        public ICollection<AnswerDTO> GetAllAnswersByUserId(int id)
        {

            using (var db = new SOVAContext())
            {
                var answers = db.Posts.Where(i => i.PostTypeId == 2).ToList();
                var answersByUserId = answers.Where(u => u.OwnerUserId == id);
                List<AnswerDTO> answersDTO = new List<AnswerDTO>();
                foreach (var post in answersByUserId)
                {
                    var answer = new AnswerDTO(post.Id, (int)post.ParentId, post.OwnerUserId, post.Body, post.Title, post.Score, post.CreationDate,
    post.ClosedDate,GetCommentsByPostId(post.Id), GetQuestionById((int)post.ParentId),GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
                    answersDTO.Add(answer);
                }
                return answersDTO;

            }
        }
        public ICollection<AnswerDTO> GetAllAnswersByQuestionId(int id)
        {

            using (var db = new SOVAContext())
            {
                var answers = db.Posts.Where(i => i.PostTypeId == 2).ToList();
                var answersByUserId = answers.Where(u => u.ParentId == id);
                List<AnswerDTO> answersDTO = new List<AnswerDTO>();
                foreach (var post in answersByUserId)
                {
                    var answer = new AnswerDTO(post.Id, (int)post.ParentId, post.OwnerUserId, post.Body, post.Title, post.Score, post.CreationDate,
    post.ClosedDate, GetCommentsByPostId(post.Id), GetQuestionById((int)post.ParentId), GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
                    answersDTO.Add(answer);
                }
                return answersDTO;

            }
        }
        //not resulted yet
        public ICollection<PostDTO> GetAllPostsByUserId(int id)
        {
            using (var db = new SOVAContext())
            {
                var posts = GetPosts();
                return posts.Where(u => u.OwneruserId == id).ToList();

            }

        }
        //implemented
        public ICollection<QuestionDTO> GetAllQuestionsByUserID(int id)
        {
            using (var db = new SOVAContext())
            {
                var questions = db.Posts.Where(i => i.PostTypeId == 1).ToList();
                var questionsByUserId = questions.Where(u => u.OwnerUserId == id);
                List<QuestionDTO> questionDTO = new List<QuestionDTO>();
               
                foreach (var post in questionsByUserId)
                {
                    var answerCollection = db.Posts.Where(p => p.ParentId == post.Id).ToList();
                    var question = new QuestionDTO(post.Id, post.AcceptedAnswerId, post.OwnerUserId, post.Body, post.Title, post.Score, post.CreationDate,
    post.ClosedDate, GetCommentsByPostId(post.Id), answerCollection, GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
                    questionDTO.Add(question);
                }
                return questionDTO;

            }
        }

        public AnnotationsDTO GetAnnotationById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<AnnotationsDTO> GetAnnotations()
        {
            throw new NotImplementedException();
        }

        //implemented
        public AnswerDTO GetAnswerById(int id)
        {

            using (var db = new SOVAContext())
            {
                var post = GetPostById(id);
                if (post.PostType.Id == 2)
                {
                    return new AnswerDTO(post.Id, (int)post.ParentId, post.OwneruserId, post.Body, post.Title, post.Score, post.CreationDate,
                        post.ClosedDate, post.Comments, GetQuestionById((int)post.ParentId), post.PostType, post.PostTags, post.UserInfo);
                }
                else{
                    return null;
                }
            }
            
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

       
        // implemented 
        public ICollection<PostTagsDTO> GetPostTagsByPostId(int id)
        {
            using (var db = new SOVAContext())
            {
                var postTags = db.PostTags.Where(p => p.PostId == id);
               List<PostTagsDTO> PostTagsDTO = new List<PostTagsDTO>();

                foreach (var item in postTags)
                {
                    var postTagsDTO = new PostTagsDTO(item.PostId, item.TagId,GetTagByPostTagId(item.TagId));

                    PostTagsDTO.Add(postTagsDTO);
                }
                return PostTagsDTO;
            }
        }

    

        public QuestionDTO GetQuestionByAnswreId(int id)
        {

            throw new NotImplementedException();
        }

        //implemented
        public QuestionDTO GetQuestionById(int id)
        {
            
              using (var db = new SOVAContext())
            {
                var answerCollection = db.Posts.Where(p => p.ParentId == id).ToList();
                var post = GetPostById(id);
                return new QuestionDTO(post.Id, post.AcceptedAnswerId, post.OwneruserId, post.Body, post.Title,post.Score, post.CreationDate,
                    post.ClosedDate, post.Comments, answerCollection, post.PostTags, post.UserInfo);
            }
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

        //implemented
        public TagsDTO GetTagByPostTagId(int id)
        {
            using (var db = new SOVAContext())
            {
                var tag = db.Tags.Where(t => t.Id == id).FirstOrDefault();
               TagsDTO tagsDTO = null;
                if (tag != null) { 
                 tagsDTO = new TagsDTO(tag.Id, tag.Tag);
                }
                return tagsDTO;

            
        }
        }

        public ICollection<TagsDTO> GetTags()
        {
            throw new NotImplementedException();
        }

        public UserInfoDTO GetUserByPostId(int id)
        {
            using (var db2 = new SOVAContext())
            {
                var post = db2.Posts.Where(i => i.Id == id).FirstOrDefault();
                var user = db2.UserInfo.Where(u => u.OwnerUserId == post.OwnerUserId).FirstOrDefault();
                return new UserInfoDTO(user.OwnerUserId, user.OwnerUserAge, user.OwnerUserDisplayName, user.CreationDate, user.OwnerUserLocation);
            }
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


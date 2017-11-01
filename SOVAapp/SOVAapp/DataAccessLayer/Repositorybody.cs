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
    post.ClosedDate,GetCommentsByPostId(post.Id), GetQuestionByAnswerId((int)post.ParentId),GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
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
    post.ClosedDate, GetCommentsByPostId(post.Id), GetQuestionByAnswerId((int)post.ParentId), GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
                    answersDTO.Add(answer);
                }
                return answersDTO;

            }
        }
        //implemented
        public ICollection<PostDTO> GetAllPostsByUserId(int id)
        {
            using (var db = new SOVAContext())
            {
                var posts = db.Posts.Where(u => u.OwnerUserId == id);
                List<PostDTO> PostDTO = new List<PostDTO>();

                foreach(var post in posts)
                {

                    var newPost = new PostDTO(post.Id, post.OwnerUserId, post.Body, post.PostTypeId, post.ParentId, post.Title, post.Score, post.CreationDate,
                        post.ClosedDate, GetCommentsByPostId(post.Id), GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
                    PostDTO.Add(newPost);
                }
                return PostDTO;

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
        //implemented
        public AnnotationsDTO GetAnnotationById(int id)
        {
            using (var db = new SOVAContext()) {
                var annotation = db.Annotations.Where(i => i.MarkedPostId == id).FirstOrDefault();
                if (annotation != null) { 
                return new AnnotationsDTO(annotation.MarkedPostId, annotation.Annotation, annotation.Marking);
                }
                return null;
            }
        }
        //implemented
        public ICollection<AnnotationsDTO> GetAnnotations()
        {
            using (var db = new SOVAContext())
            {
                var annotations = db.Annotations.ToList();
                if(annotations != null)
                {
                    List<AnnotationsDTO> AnnotationsDTO = new List<AnnotationsDTO>();
                    foreach(var annotation in annotations)
                    {
                      var newAnn = new AnnotationsDTO(annotation.MarkedPostId, annotation.Annotation, annotation.Marking);
                        AnnotationsDTO.Add(newAnn);

                    }
                    return AnnotationsDTO;

                }
                return null;

            }
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
                        post.ClosedDate, post.Comments, GetQuestionByAnswerId((int)post.ParentId), post.PostType, post.PostTags, post.UserInfo);
                }
                else{
                    return null;
                }
            }
            
        }

        //implemented
        public CommentDTO GetCommentById(int id)
        {
        using(var db = new SOVAContext())
            {
                var c = db.Comments.Where(i => i.CommentId == id).FirstOrDefault();
                var CommentedPost = db.Posts.Where(i => i.Id == c.PostId).FirstOrDefault();
                return new CommentDTO(c.CommentId,c.PostId,c.CommentText,c.CommentScore,c.CommentCreateDate,c.OwnerUserId, CommentedPost , GetUserByCommentId(c.CommentId));

            }
            
        }
        //implemented
        public ICollection<CommentDTO> GetComments()
        {
            using (var db = new SOVAContext())
            {
                var comments = db.Comments.ToList();
                List<CommentDTO> commentsDTO = new List<CommentDTO>();

                foreach (var c in comments)
                {
                    var commentsPost = db.Posts.Where(i => i.Id == c.PostId).FirstOrDefault();
                    var newComment = new CommentDTO(c.CommentId, c.PostId,c.CommentText,c.CommentScore,c.CommentCreateDate,c.OwnerUserId
                        , commentsPost, GetUserByCommentId(c.CommentId));
                    commentsDTO.Add(newComment);
                }
                return commentsDTO;

            }


        }


        //implemented
        public TagsDTO GetTagByID(int id)
        {
            using (var db = new SOVAContext())
            {
                var tag = db.Tags.Where(i => i.Id == id).FirstOrDefault();
                return new TagsDTO(tag.Id, tag.Tag);
            }

        }

        public ICollection<FavoriteTagsDTO> GetFavoriteTagsByCustomeId(int id)
        {

            using (var db = new SOVAContext())
            {
                var FavTags = db.FavoriteTags.Where(i => i.UserCustomeFieldId == id);
                List<FavoriteTagsDTO> FavTagsDTO = new List<FavoriteTagsDTO>();
                foreach (var t in FavTags) {
                    var Customfield = db.UserCustomeField.Where(i => i.Id == t.UserCustomeFieldId).FirstOrDefault();
                    var newTag = new FavoriteTagsDTO(t.UserCustomeFieldId, t.TagId, Customfield, GetTagByID(t.TagId));
                    FavTagsDTO.Add(newTag);
                }
                return FavTagsDTO;
            }


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

    
        //implemented
        public QuestionDTO GetQuestionByAnswerId(int id)
        {

            using (var db = new SOVAContext())
            {
                var answer = db.Posts.Where(i => i.Id == id).FirstOrDefault();
                var q = db.Posts.Where(i => i.Id == answer.ParentId).FirstOrDefault();
                var answersOfq = db.Posts.Where(i => i.ParentId == q.Id).ToList();

                return new QuestionDTO(q.Id, q.AcceptedAnswerId,q.OwnerUserId,q.Body,q.Title,q.Score,q.CreationDate,
                                       q.ClosedDate,GetCommentsByPostId(q.Id), answersOfq , GetPostTagsByPostId(q.Id),GetUserByPostId(q.Id));

            }
        }

        //implemented
        public ICollection<QuestionDTO> GetQuestions()
        {

            using (var db = new SOVAContext())
            {
                var questions = db.Posts.Where(i => i.PostTypeId == 1).ToList();
                List<QuestionDTO> QuestionsDTO = new List<QuestionDTO>();

                foreach (var post in questions)
                {
                    var answersOfq = db.Posts.Where(i => i.ParentId == post.Id).ToList();

                    var newQuestion = new QuestionDTO(post.Id, post.AcceptedAnswerId, post.OwnerUserId, post.Body, post.Title, post.Score, post.CreationDate,
                                      post.ClosedDate, GetCommentsByPostId(post.Id), answersOfq, GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
                    QuestionsDTO.Add(newQuestion);
                }
                return QuestionsDTO;

            }
        }

        // implemeneted
        public ICollection<SearchHistoryDTO> GetSearchHistories()
        {
            using (var db = new SOVAContext())
            {

                var searchHistories = db.SearchHistory.ToList();
                List<SearchHistoryDTO> SearchHistoriesDTO = new List<SearchHistoryDTO>();

                foreach (var s in searchHistories)
                {
                    var newSearchHistory = new SearchHistoryDTO(s.Id, s.SearchContent, s.SearchDate);
                    SearchHistoriesDTO.Add(newSearchHistory);

                }
                return SearchHistoriesDTO;
            }

        }

        //implemented
        public SearchHistoryDTO GetSearchHistoryById(int id)
        {
            using (var db = new SOVAContext())
            {
                var s = db.SearchHistory.Where(i => i.Id == id).FirstOrDefault();
                return new SearchHistoryDTO(s.Id, s.SearchContent, s.SearchDate);

            }
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

        //implemented
        public ICollection<TagsDTO> GetTags()
        {
            using (var db = new SOVAContext())
            {
                var tags = db.Tags.ToList();
                List<TagsDTO> tagsDTO = new List<TagsDTO>();

                foreach (var t in tags)
                {
                    var newtag = new TagsDTO(t.Id, t.Tag);
                    tagsDTO.Add(newtag);

                }
                return tagsDTO;

            }

        }

        //implemented
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


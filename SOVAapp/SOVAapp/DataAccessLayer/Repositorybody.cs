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
    public class RepositoryBody : IRepository
                 
    {

        //////////////// Posts

        public PostDTO GetPostById(int id)
        {
            using (var db2 = new SOVAContext())
            {
                var post = db2.Posts.FirstOrDefault(a => a.Id == id);

                return new PostDTO(post.Id, post.OwnerUserId, post.Body, post.PostTypeId, post.ParentId, post.Title, post.Score, post.CreationDate, post.ClosedDate, GetCommentsByPostId(id), GetPostTypeByPostId(id), GetPostTagsByPostId(id), GetUserByPostId(id));
            }
        }

        public ICollection<PostDTO> GetPosts()
        {
            using (var db = new SOVAContext())
            {
                var posts = db.Posts.ToList();
                List<PostDTO> postsDTO = new List<PostDTO>();
                foreach (var post in posts)
                {
                    var myPost = new PostDTO(post.Id, post.OwnerUserId, post.Body, post.PostTypeId, post.ParentId, post.Title, post.Score, post.CreationDate, post.ClosedDate, GetCommentsByPostId(post.Id), GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
                    postsDTO.Add(myPost);
                }
                return postsDTO;

            }
        }


        public ICollection<PostDTO> GetAllPostsByUserId(int id)
        {
            using (var db = new SOVAContext())
            {
                var posts = db.Posts.Where(u => u.OwnerUserId == id);
                List<PostDTO> PostDTO = new List<PostDTO>();

                foreach (var post in posts)
                {

                    var newPost = new PostDTO(post.Id, post.OwnerUserId, post.Body, post.PostTypeId, post.ParentId, post.Title, post.Score, post.CreationDate,
                        post.ClosedDate, GetCommentsByPostId(post.Id), GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id), GetUserByPostId(post.Id));
                    PostDTO.Add(newPost);
                }
                return PostDTO;

            }

        }

        public int CountPosts()
        {
            using (var db = new SOVAContext())
            {
                return db.Posts.Count();
            }
        }

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

        ////////////////Answers
        public ICollection<Post> GetAnswers(int page, int pageSize)
        {
            using (var db = new SOVAContext())
            {
                var Answers = db.Posts.Where(t => t.PostTypeId == 2).ToList();
                return Answers.OrderBy(x => x.Id)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList(); 
            }


        }

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
                else
                {
                    return null;
                }
            }

        }


        public ICollection<AnswerDTO> GetAllAnswersByUserId(int id, int page, int pageSize)
        {

            using (var db = new SOVAContext())
            {
                var answers = db.Posts.Where(i => i.PostTypeId == 2).ToList();
                var answersByUserId = answers.Where(u => u.OwnerUserId == id);
                List<AnswerDTO> answersDTO = new List<AnswerDTO>();
                foreach (var post in answersByUserId)
                {
                    var answer = new AnswerDTO(post.Id, (int)post.ParentId, post.OwnerUserId, post.Body, post.Title, post.Score, post.CreationDate,
    post.ClosedDate, null, null, GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id), null);
                    answersDTO.Add(answer);
                }
                return answersDTO.OrderBy(x => x.Id)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

            }
        }

        public ICollection<AnswerDTO> GetAllAnswersByQuestionId(int id, int page, int pageSize)
        {

            using (var db = new SOVAContext())
            {
                var answers = db.Posts.Where(i => i.PostTypeId == 2).ToList();
                var answersByUserId = answers.Where(u => u.ParentId == id);
                List<AnswerDTO> answersDTO = new List<AnswerDTO>();
                foreach (var post in answersByUserId)
                {
                    var answer = new AnswerDTO(post.Id, (int)post.ParentId, post.OwnerUserId, post.Body, post.Title, post.Score, post.CreationDate,
    post.ClosedDate, null, null, GetPostTypeByPostId(post.Id), GetPostTagsByPostId(post.Id),null);
                    answersDTO.Add(answer);
                }
                return answersDTO.OrderBy(x => x.Id)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

            }
        }

        public int CountAnswers()
        {
            using (var db = new SOVAContext())
            {

                var answers = db.Posts.Where(t => t.PostTypeId == 2);
                return answers.Count();
            }
        }



        public int CountAnswersByUserId(int id)
        {
            using (var db = new SOVAContext())
            {
                var answers = db.Posts.Where(i => i.PostTypeId == 2).ToList();
                return answers.Where(u => u.OwnerUserId == id).Count();

            }
        }
        public int CountAnswersByQuestionId(int id)
        {
            using (var db = new SOVAContext())
            {
                var answers = db.Posts.Where(i => i.PostTypeId == 2).ToList();
                return answers.Where(u => u.ParentId == id).Count();

            }

        }


        ////////////////Questions
        public QuestionDTO GetQuestionByAnswerId(int id)
        {

            using (var db = new SOVAContext())
            {
                var answer = db.Posts.Where(i => i.Id == id).FirstOrDefault();
                var q = db.Posts.Where(i => i.Id == answer.ParentId).FirstOrDefault();
                var answersOfq = db.Posts.Where(i => i.ParentId == q.Id).ToList();

                return new QuestionDTO(q.Id, q.AcceptedAnswerId, q.OwnerUserId, q.Body, q.Title, q.Score, q.CreationDate,
                                       q.ClosedDate, GetCommentsByPostId(q.Id), answersOfq, GetPostTagsByPostId(q.Id), GetUserByPostId(q.Id));

            }
        }


        public ICollection<Post> GetQuestions(int page, int pageSize)
        {

            using (var db = new SOVAContext())
            {
                var questions = db.Posts.Where(i => i.PostTypeId == 1).ToList();
                return questions.OrderBy(x => x.Id)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList(); 
            

            }
        }

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


        public int CountQuestionsByUserId(int id)
        {
            using (var db = new SOVAContext())
            {
                var answers = db.Posts.Where(i => i.PostTypeId == 1).ToList();
                return answers.Where(u => u.OwnerUserId == id).Count();

            }
        }

        public int CountQuestions()
        {
            using (var db = new SOVAContext())
            {

                return db.Posts.Where(i => i.PostTypeId == 1).Count();
            }
        }


        ////////////////Comments

        public CommentDTO GetCommentById(int id)
        {
            using (var db = new SOVAContext())
            {
                var c = db.Comments.Where(i => i.CommentId == id).FirstOrDefault();
                var CommentedPost = db.Posts.Where(i => i.Id == c.PostId).FirstOrDefault();
                return new CommentDTO(c.CommentId, c.PostId, c.CommentText, c.CommentScore, c.CommentCreateDate, c.OwnerUserId, CommentedPost, GetUserByCommentId(c.CommentId));

            }

        }

        public ICollection<CommentDTO> GetCommentsByPostId(int postId)
        {
            using (var db2 = new SOVAContext())
            {
                var Comments = db2.Comments.Include(p => p.post).Where(p => p.PostId == postId);
                List<CommentDTO> CommentsDTO = new List<CommentDTO>();

                foreach (var item in Comments)
                {

                    var commentDTO = new CommentDTO(item.CommentId, item.PostId, item.CommentText, item.CommentScore, item.CommentCreateDate,
                        item.OwnerUserId, item.post, GetUserByPostId(postId));

                    CommentsDTO.Add(commentDTO);
                }
                return CommentsDTO;
            }
        }


        public ICollection<CommentDTO> GetComments()
        {
            using (var db = new SOVAContext())
            {
                var comments = db.Comments.ToList();
                List<CommentDTO> commentsDTO = new List<CommentDTO>();

                foreach (var c in comments)
                {
                    var commentsPost = db.Posts.Where(i => i.Id == c.PostId).FirstOrDefault();
                    var newComment = new CommentDTO(c.CommentId, c.PostId, c.CommentText, c.CommentScore, c.CommentCreateDate, c.OwnerUserId
                        , commentsPost, GetUserByCommentId(c.CommentId));
                    commentsDTO.Add(newComment);
                }
                return commentsDTO;

            }
        }


        public int CountComments()
        {
            using (var db = new SOVAContext())
            {
                return db.Comments.Count();
            }
        }

        ////////////////Tags

        public TagsDTO GetTagByPostTagId(int id)
        {
            using (var db = new SOVAContext())
            {
                var tag = db.Tags.Where(t => t.Id == id).FirstOrDefault();
                TagsDTO tagsDTO = null;
                if (tag != null)
                {
                    tagsDTO = new TagsDTO(tag.Id, tag.Tag);
                }
                return tagsDTO;


            }
        }


        public TagsDTO GetTagByID(int id)
        {
            using (var db = new SOVAContext())
            {
                var tag = db.Tags.Where(i => i.Id == id).FirstOrDefault();
                return new TagsDTO(tag.Id, tag.Tag);
            }

        }


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

        public int CountTags()
        {
            using (var db = new SOVAContext())
            {
                return db.Tags.Count();
            }
        }
        ////////////////PostTags

        public ICollection<PostTagsDTO> GetPostTagsByPostId(int id)
        {
            using (var db = new SOVAContext())
            {
                var postTags = db.PostTags.Where(p => p.PostId == id);
                List<PostTagsDTO> PostTagsDTO = new List<PostTagsDTO>();

                foreach (var item in postTags)
                {
                    var postTagsDTO = new PostTagsDTO(item.PostId, item.TagId, GetTagByPostTagId(item.TagId));

                    PostTagsDTO.Add(postTagsDTO);
                }
                return PostTagsDTO;
            }
        }


        public int CountPostTags()
        {
            using (var db = new SOVAContext())
            {
                return db.PostTags.Count();
            }
        }

        ////////////////UserInfo
        public ICollection<UserInfoDTO> GetUsers(int page, int pageSize)
        {
            using (var db = new SOVAContext())
            {
                var users = db.UserInfo.ToList();
                List<UserInfoDTO> UsersDTO = new List<UserInfoDTO>();
                foreach( var i in users)
                {
                    var newUser = new UserInfoDTO(i.OwnerUserId, i.OwnerUserAge,i.OwnerUserDisplayName,i.CreationDate,i.OwnerUserLocation);
                    UsersDTO.Add(newUser);
                }
                return UsersDTO.OrderBy(x => x.Id)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public UserInfoDTO GetUserById(int id)
        {
            using (var db = new SOVAContext())
            {
                var user = db.UserInfo.Where(i => i.OwnerUserId == id).FirstOrDefault();
                if (user != null)
                {
                    return new UserInfoDTO(user.OwnerUserId, user.OwnerUserId, user.OwnerUserDisplayName, user.CreationDate, user.OwnerUserLocation);
                }
                return null;
            }
            }
        public UserInfoDTO GetUserByPostId(int id)
        {
            using (var db2 = new SOVAContext())
            {
                var post = db2.Posts.Where(i => i.Id == id).FirstOrDefault();
                var user = db2.UserInfo.Where(u => u.OwnerUserId == post.OwnerUserId).FirstOrDefault();
                if (user != null)
                {
                    var userDTO = new UserInfoDTO(user.OwnerUserId, user.OwnerUserAge, user.OwnerUserDisplayName, user.CreationDate, user.OwnerUserLocation);
                    return userDTO;
                }
                return null;
           
            }
        }

        public UserInfoDTO GetUserByCommentId(int id)
        {
            using (var db = new SOVAContext())
            {
                var comment = db.Comments.FirstOrDefault(c => c.CommentId == id);

                var user = db.UserInfo.FirstOrDefault(i => i.OwnerUserId == comment.OwnerUserId);
                return new UserInfoDTO(user.OwnerUserId, user.OwnerUserAge, user.OwnerUserDisplayName, user.CreationDate, user.OwnerUserLocation);
            }

        }


        public int CountUsers()
        {
            using (var db = new SOVAContext())
            {
                return db.UserInfo.Count();
            }
        }


        ////////////////Marking

        public bool AddMarking(int postId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveMarking(int id)
        {
            throw new NotImplementedException();
        }


        ////////////////Annotations


        public bool AddAnnotation()
        {
            throw new NotImplementedException();
        }

        public bool EditAnnotation()
        {
            throw new NotImplementedException();
        }


        public bool DeleteAnnotation(int id)
        {
            throw new NotImplementedException();
        }


        public AnnotationsDTO GetAnnotationById(int id)
        {
            using (var db = new SOVAContext())
            {
                var annotation = db.Annotations.Where(i => i.MarkedPostId == id).FirstOrDefault();
                if (annotation != null)
                {
                    return new AnnotationsDTO(annotation.MarkedPostId, annotation.Annotation, annotation.Marking);
                }
                return null;
            }
        }

        public ICollection<AnnotationsDTO> GetAnnotations()
        {
            using (var db = new SOVAContext())
            {
                var annotations = db.Annotations.ToList();
                if (annotations != null)
                {
                    List<AnnotationsDTO> AnnotationsDTO = new List<AnnotationsDTO>();
                    foreach (var annotation in annotations)
                    {
                        var newAnn = new AnnotationsDTO(annotation.MarkedPostId, annotation.Annotation, annotation.Marking);
                        AnnotationsDTO.Add(newAnn);

                    }
                    return AnnotationsDTO;

                }
                return null;

            }
        }



        public int CountAnnotations()
        {
            using (var db = new SOVAContext())
            {
                return db.Annotations.Count();
            }
        }

        ////////////////SearchHistory

        public bool AddSearchHistory(string SearchText)
        {
            throw new NotImplementedException();
        }



        public SearchHistoryDTO GetSearchHistoryById(int id)
        {
            using (var db = new SOVAContext())
            {
                var s = db.SearchHistory.Where(i => i.Id == id).FirstOrDefault();
                return new SearchHistoryDTO(s.Id, s.SearchContent, s.SearchDate);

            }
        }


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

        public int GetNumberOfSearches()
        {
            throw new NotImplementedException();
        }


        ////////////////FavoriteTags

        public bool AddFavoriteTags()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFavoriteTags(int id)
        {
            throw new NotImplementedException();
        }



        public ICollection<FavoriteTagsDTO> GetFavoriteTagsByCustomeId(int id)
        {

            using (var db = new SOVAContext())
            {
                var FavTags = db.FavoriteTags.Where(i => i.UserCustomeFieldId == id);
                List<FavoriteTagsDTO> FavTagsDTO = new List<FavoriteTagsDTO>();
                foreach (var t in FavTags)
                {
                    var Customfield = db.UserCustomeField.Where(i => i.Id == t.UserCustomeFieldId).FirstOrDefault();
                    var newTag = new FavoriteTagsDTO(t.UserCustomeFieldId, t.TagId, Customfield, GetTagByID(t.TagId));
                    FavTagsDTO.Add(newTag);
                }
                return FavTagsDTO;
            }
        }


        public int CountFavoriteTags()
        {
            using (var db = new SOVAContext())
            {
                return db.FavoriteTags.Count();
            }
        }

        ////////////////UserCustomeField

        public bool AddUserCustomeField()
        {
            using (var db = new SOVAContext())
            {
                var result = db.UserCustomeField.FromSql("call addUserCustomeField({0},{1})", 5, "excel,JSON");

                db.SaveChanges();
                return true;
            }
        }


        public bool DeleteUserCustomeField(int id)
        {
            throw new NotImplementedException();
        }


        public UserCustomeFieldDTO GetUserCustomeFieldById(int id)
        {
            using (var db = new SOVAContext())
            {
                var u = db.UserCustomeField.Where(i => i.Id == id).FirstOrDefault();

                return new UserCustomeFieldDTO(u.Id, u.Postlimit, u.CreationDate, GetFavoriteTagsByCustomeId(id));
            }
        }


        public ICollection<UserCustomeFieldDTO> GetUserCustomeFields()
        {
            using (var db = new SOVAContext())
            {
                var CustomeFields = db.UserCustomeField.ToList();
                List<UserCustomeFieldDTO> CustomeFieldsDTO = new List<UserCustomeFieldDTO>();
                foreach (var u in CustomeFields)
                {
                    var newCustomeField = new UserCustomeFieldDTO(u.Id, u.Postlimit, u.CreationDate, GetFavoriteTagsByCustomeId(u.Id));
                    CustomeFieldsDTO.Add(newCustomeField);
                }
                return CustomeFieldsDTO;

            }
        }


        public int CountUserCustomeFields()
        {
            using (var db = new SOVAContext())
            {
                return db.UserCustomeField.Count();
            }
        }



    }
}

